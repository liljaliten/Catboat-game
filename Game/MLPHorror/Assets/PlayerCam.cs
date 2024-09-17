using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    private float xRotation = 0f;  // For vertical rotation (up and down)
    private float yRotation = 0f;  // For horizontal rotation (left and right)

    void Start()
    {
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get mouse input for both axes
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the camera left/right along the Y-axis (horizontal rotation)
        yRotation += mouseX;

        // Rotate the camera up/down along the X-axis (vertical rotation)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limit up/down rotation to 90 degrees

        // Apply rotations to the camera
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
