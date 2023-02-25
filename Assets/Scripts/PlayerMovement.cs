using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float verticalSpeed;
    [SerializeField] private float jumpForce;

    private bool isGrounded;
    
    private void FixedUpdate()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) >= 0.1f)
        {
            rb.AddForce(new Vector3(Input.GetAxis("Horizontal") * horizontalSpeed * Time.fixedDeltaTime * rb.mass, 0f, 0f));
        }
        
        if (Mathf.Abs(Input.GetAxis("Vertical")) >= 0.1f)
        {
            rb.AddForce(new Vector3(0f, 0f, Input.GetAxis("Vertical") * verticalSpeed * Time.fixedDeltaTime * rb.mass));
        }

        if (Input.GetAxis("Jump") >= 0.1f)
        {
            rb.AddForce(new Vector3(0f, Input.GetAxis("Jump") * jumpForce * rb.mass, 0f));
        }
    }
}
