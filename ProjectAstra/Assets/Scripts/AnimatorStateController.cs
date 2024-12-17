using UnityEngine;

public class AnimatorStateController : MonoBehaviour
{
    [SerializeField] private PlayerInputReader inputs;
    [SerializeField] private TPController controller;
    private float velocity;
    private float desacceleration;
    private float acceleration;
    private Animator anim;
    private bool idleState;

    public Animator Anim { get => anim; set => anim = value; }

    private void Start()
    {
        anim = GetComponent<Animator>();
        idleState = true;
        anim.SetBool("IdleState", idleState);
        velocity = 0f;
        desacceleration = -2f;
        acceleration = 1.5f;
    }

    private void Update()
    {
        if (idleState) 
        {
            IdleStateAnimations();
        }
    }

    private void IdleStateAnimations()
    {
        if (inputs.MovementVector == Vector3.zero)
        {
            velocity += Time.deltaTime * desacceleration;
            velocity = Mathf.Clamp(velocity, 0f, 1f);
            anim.SetFloat("Acceleration", velocity);
        }
        else
        {
            velocity += Time.deltaTime * acceleration;
            velocity = Mathf.Clamp(velocity, 0f, 1f);
            anim.SetFloat("Acceleration", velocity);
        }
    }    
}
