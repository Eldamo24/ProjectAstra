using System;
using UnityEditor.Animations;
using UnityEngine;

public class AnimatorStateController : MonoBehaviour
{
    [SerializeField] private PlayerInputReader inputs;
    [SerializeField] private CombatInputReader combatInputReader;
    [SerializeField] private TPController controller;
    [SerializeField] private AnimatorController idleController;
    [SerializeField] private AnimatorController combatController;
    private float velocity;
    private float desacceleration;
    private float acceleration;
    private Animator anim;
    private bool idleState;

    public Animator Anim { get => anim; set => anim = value; }
    public AnimatorController IdleController { get => idleController; set => idleController = value; }
    public AnimatorController CombatController { get => combatController; set => combatController = value; }
    public bool IdleState { get => idleState; set => idleState = value; }

    private void Start()
    {
        anim = GetComponent<Animator>();
        idleState = true;
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
        else
        {
            CombatStateController();
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
            if (inputs.Sprinting)
            {
                velocity += Time.deltaTime * acceleration;
                velocity = Mathf.Clamp(velocity, 0.7f, 1f);
                anim.SetFloat("Acceleration", velocity);
            }
            else
            {
                if (velocity > 0.7f)
                {
                    velocity += Time.deltaTime * desacceleration;
                    velocity = Mathf.Clamp(velocity, 0.7f, 1f);
                    anim.SetFloat("Acceleration", velocity);
                }
                else
                {
                    velocity += Time.deltaTime * acceleration;
                    velocity = Mathf.Clamp(velocity, 0f, 0.7f);
                    anim.SetFloat("Acceleration", velocity);
                }
            }
        }
    }


    private void CombatStateController()
    {
        Vector3 normalizedVector = combatInputReader.MovementVector.normalized;
        anim.SetFloat("MoveHorizontal", normalizedVector.x);
        anim.SetFloat("MoveVertical", normalizedVector.z);
    }
}
