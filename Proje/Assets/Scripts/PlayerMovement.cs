using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //movement
    private CharacterController controller;
    public float speed = 2.75f;

    //camera controller
    private float xRotation = 0f;
    public float mouseSensitivity = 150f;
    
    //jump and gravity
    private Vector3 velocity;
    private float gravity = -9.81f;
    private bool isGround;
    public Transform groundChecker;
    public float grounCheckerRadius;
    public LayerMask obstacleLayer;
    public float jumpHeight = 0.002f;
    public float gravityDivide = 10f;
    public float jumpSpeed = 100f;
    private float aTimer;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();

        //cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
    private void Update()
    {
        //check caracter is ground
        isGround = Physics.CheckSphere(groundChecker.position, grounCheckerRadius, obstacleLayer);
        //movement
        Vector3 moveInputs = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        Vector3 moveVelocity = moveInputs * Time.deltaTime * speed;
        controller.Move(moveVelocity);

        //camera Control
        transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity, 0);
        xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        //jump and gravity        
        if (!isGround)
        {
            velocity.y += gravity * Time.deltaTime/gravityDivide;
            aTimer += Time.deltaTime/3;
            speed = Mathf.Lerp(10,jumpSpeed,aTimer);
        }
        else
        {
            velocity.y = -0.01f;
            speed = 10;
            aTimer = 0;
        }
        if(Input.GetKeyDown(KeyCode.Space)&&isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity/gravityDivide*Time.deltaTime);
        }        
        controller.Move(velocity);      
        
    }
}
