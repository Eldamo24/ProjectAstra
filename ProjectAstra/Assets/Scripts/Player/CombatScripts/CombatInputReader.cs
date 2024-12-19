using UnityEngine;
using UnityEngine.InputSystem;

public class CombatInputReader : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;

    private Vector3 movementVector;
    public Vector3 MovementVector { get => movementVector; set => movementVector = value; }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        movementVector = playerInput.actions["Move"].ReadValue<Vector3>();
    }
}
