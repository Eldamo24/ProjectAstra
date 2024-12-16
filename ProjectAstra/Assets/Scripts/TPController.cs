using System;
using UnityEngine;

public class TPController : MonoBehaviour
{
    [Header("Player References")]
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerObj;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerInputReader playerInputReader;

    private Vector3 inputs;

    [Header("Speed Variables")]
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float speedMovement;

    [Header("Jump References")]
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform checkGround;



    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        Movement();
        Grounded();
        if (playerInputReader.Jumping && isGrounded)
        {
            Jump();
        }
    }



    private void Movement()
    {
        Vector3 viewDir = player.position - new Vector3(Camera.main.transform.position.x, player.position.y, Camera.main.transform.position.z);
        orientation.forward = viewDir.normalized;
        inputs = playerInputReader.MovementVector;
        Vector3 inputDir = orientation.forward * inputs.z + orientation.right * inputs.x;
        if (inputDir != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
            rb.MovePosition(rb.position + inputDir * speedMovement * Time.deltaTime);
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce);
    }

    private void Grounded()
    {
        isGrounded = Physics.CheckSphere(checkGround.position, 0.2f, groundLayer);
    }
}
