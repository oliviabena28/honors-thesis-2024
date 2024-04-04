using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class chairLock : MonoBehaviour
{
    Camera cam;
    bool isSnapping = false;
    Vector3 targetPosition;
    private float xRotation;
    private float mouseX;
    private float mouseY;
    public float mouseSensitivity = 10;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleClick();
        }

        if (isSnapping)
        {
            SnapToTarget();
        }

    }

    void HandleClick()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Chair"))
                {
                    targetPosition = hit.point;
                    isSnapping = true;
                }
            }
        }


    }

    void SnapToTarget()
    {

        float speed = 5f;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);

        float threshold = 0.1f;
        if (Vector3.Distance(transform.position, targetPosition) < threshold)
        {
            transform.position = targetPosition;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            cam.transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
            isSnapping = false;
            //OnLook();
            
        }
    }

    /*void OnLook(InputValue lookValue)
    {

        Vector2 mouseLook = lookValue.Get<Vector2>();


        mouseX = mouseLook.x * Time.deltaTime * mouseSensitivity;
        mouseY = mouseLook.y * Time.deltaTime * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
    } */

}

