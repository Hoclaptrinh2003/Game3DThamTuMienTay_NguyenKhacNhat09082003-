using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : Singleton<PlayerController>
{
    public Camera playerCam;


    public float walkSpeed = 3f;
    public float runSpeed = 5f;
    public float jumpPower = 3f;
    public float gravity = 10f;
    public float lookSpeed = 2f;
    public float lookXLimit = 75f;
    public float cameraRotationSmooth = 5f;
    public float curSpeedX;
    public float curSpeedY;

    private float rotationX = 0;
    private float rotationY = 0;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 velocity = Vector3.zero;

    private bool canMove = true;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerCam.fieldOfView = 40;
    }

    void Update()
    {
        HandleMovement();
        HandleCameraRotation();

    }


    private void HandleMovement()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift); 
        float speed = isRunning ? runSpeed : walkSpeed; 

        curSpeedX = canMove ? speed * Input.GetAxis("Vertical") : 0;
        curSpeedY = canMove ? speed * Input.GetAxis("Horizontal") : 0;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (characterController.isGrounded)
        {
            velocity.y = -0.5f;

            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = jumpPower;
            }
        }
        else
        {
            velocity.y -= gravity * Time.deltaTime; 
        }

        characterController.Move((moveDirection + velocity) * Time.deltaTime);
    }

    private void HandleCameraRotation()
    {
        if (canMove)
        {
            rotationX -= Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

            rotationY += Input.GetAxis("Mouse X") * lookSpeed;

            Quaternion targetRotationX = Quaternion.Euler(rotationX, 0, 0);
            Quaternion targetRotationY = Quaternion.Euler(0, rotationY, 0);

            playerCam.transform.localRotation = Quaternion.Slerp(playerCam.transform.localRotation, targetRotationX, Time.deltaTime * cameraRotationSmooth);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationY, Time.deltaTime * cameraRotationSmooth);
        }
    }




}