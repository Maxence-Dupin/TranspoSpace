using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;
    public float jumpForce;
    public KeyCode dashKey = KeyCode.LeftAlt;
    public float dashForce;
    public float dashCooldown;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("Transposition")]
    public KeyCode transpositionKey = KeyCode.A;
    public float transpositionCooldown;
    public float transpositionRange;
    public LayerMask swapLayerMask;
    public Transform orientation;
    
    private bool _canDash = true;
    private bool _canSwap = true;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        MyInput();
        SpeedControl();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if(Input.GetKey(jumpKey) && grounded)
        {
            Jump();
        }

        if (Input.GetKey(dashKey) && _canDash && grounded)
        {
            Dash();
        }
        
        if (Input.GetKey(transpositionKey) && _canSwap)
        {
            if (Physics.Raycast(orientation.position, orientation.forward, out var hit, transpositionRange, swapLayerMask))
            {
                Swap(hit.transform.gameObject);   
            }
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    
    private void Dash()
    {
        rb.AddForce((orientation.forward * verticalInput + orientation.right * horizontalInput) * dashForce, ForceMode.Impulse);
        _canDash = false;
        StartCoroutine(WaitDash());
    }
    
    private IEnumerator WaitDash() 
    {
        yield return new WaitForSeconds(dashCooldown);
        _canDash = true;
    }
    
    private IEnumerator WaitSwap() 
    {
        yield return new WaitForSeconds(transpositionCooldown);
        _canSwap = true;
    }
    
    public void Swap(GameObject enemy)
    {
        (transform.position, enemy.transform.position) = (enemy.transform.position, transform.position);
        _canSwap = false;
        StartCoroutine(WaitSwap());
    }
}