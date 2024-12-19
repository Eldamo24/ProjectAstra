
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombatController : MonoBehaviour
{
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerObj;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private CombatInputReader combatInputReader;
    [SerializeField] private Transform combatLookAt;
    private Vector3 inputs;


    [SerializeField] private float speedMovement;
    [SerializeField] private float rotationSpeed;

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        Vector3 viewDir = player.position - new Vector3(Camera.main.transform.position.x, player.position.y, Camera.main.transform.position.z);
        orientation.forward = viewDir.normalized;
        inputs = combatInputReader.MovementVector;
        Vector3 inputDir = orientation.forward * inputs.z + orientation.right * inputs.x;
        Vector3 dirToCombatLookAt = combatLookAt.position - new Vector3(Camera.main.transform.position.x, combatLookAt.position.y, Camera.main.transform.position.z);
        orientation.forward = dirToCombatLookAt.normalized;
        playerObj.forward = dirToCombatLookAt.normalized;
        Vector3 moveVelocity = inputDir.normalized * speedMovement;
        rb.linearVelocity = new Vector3(moveVelocity.x, rb.linearVelocity.y, moveVelocity.z);
    }
}

