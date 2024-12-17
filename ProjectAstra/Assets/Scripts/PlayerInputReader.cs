using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    private Vector3 movementVector;
    private bool jumping;
    public Vector3 MovementVector { get => movementVector; set => movementVector = value; }
    public bool Jumping { get => jumping; set => jumping = value; }

    private void Start()
    {
        jumping = false;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        movementVector = playerInput.actions["Move"].ReadValue<Vector3>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            jumping = true;
        }
        else if (context.canceled)
        {
            jumping = false;
        }
    }
}
