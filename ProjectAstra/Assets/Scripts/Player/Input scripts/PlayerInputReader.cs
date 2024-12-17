using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    private Vector3 movementVector;
    private bool jumping;
    private bool interactKeyPressed;
    private bool interacting;
    public Vector3 MovementVector { get => movementVector; set => movementVector = value; }
    public bool Jumping { get => jumping; set => jumping = value; }
    public bool InteractKeyPressed { get => interactKeyPressed; set => interactKeyPressed = value; }
    public bool Interacting { get => interacting; set => interacting = value; }

    private void Start()
    {
        jumping = false;
        interactKeyPressed = false;
        interacting = false;
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

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactKeyPressed = true;
        }
        else if (context.canceled)
        {
            interactKeyPressed = false;
            interacting = false;
        }
    }
}
