using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private float mouseSensitivity = 2f;
    private float _cameraVerticalRotation;

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        _cameraVerticalRotation -= inputY;
        _cameraVerticalRotation = Mathf.Clamp(_cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * _cameraVerticalRotation;
        
        player.Rotate(Vector3.up * inputX);
    }
}
