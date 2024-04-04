using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class x2Zoom : MonoBehaviour
{
    public float sensitivity = 5f;

    public float minXRange = -1f; // Minimum X range of camera movement
    public float maxXRange = 5f; // Maximum X range of camera movement

    public float minYRange = -1f; // Minimum Y range of camera movement
    public float maxYRange = 5f; // Maximum Y range of camera movement


    public Camera cam;
    public float defaultFov = 90;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {

            float mouseX = -Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            cam.fieldOfView = (defaultFov / 2);

            float clampedMouseX = Mathf.Clamp(transform.localPosition.x + mouseX, minXRange, maxXRange);
            transform.localPosition = new Vector3(clampedMouseX, transform.localPosition.y, transform.localPosition.z);

            float clampedMouseY = Mathf.Clamp(transform.localPosition.y + mouseY, minYRange, maxYRange);
            transform.localPosition = new Vector3(transform.localPosition.x, clampedMouseY, transform.localPosition.z);

        }
        else
        {
            cam.fieldOfView = (defaultFov);

            if (transform.position != originalPosition || transform.rotation != originalRotation)
            {
                // Reset the camera to its original position and rotation
                transform.position = originalPosition;
                transform.rotation = originalRotation;
            }
        }
    }
}