using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private float mouseX;
    private float mouseY;
    private float xRotation;
    private Vector2 movement;
    private CharacterController controller;
    private Vector3 moveDirection;

    [HideInInspector]
    public int count = 0;

    [Header("Player Settings")]
    public float speed;


    [Header("Camera Settings")]
    public GameObject cam;
    public float mouseSensitivity = 10;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);


    }

    void Update()
    {
        transform.Rotate(Vector3.up * mouseX);

        moveDirection = (transform.right * movement.x) + (transform.forward * movement.y);

        controller.SimpleMove(moveDirection * speed);


    }

    void OnLook(InputValue lookValue)
    {

        Vector2 mouseLook = lookValue.Get<Vector2>();
        

        mouseX = mouseLook.x * Time.deltaTime * mouseSensitivity;
        mouseY = mouseLook.y * Time.deltaTime * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
    }




    void OnMove(InputValue moveValue)
    {
        movement = moveValue.Get<Vector2>();
        
    }
}




