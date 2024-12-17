using UnityEngine;
using UnityEngine.InputSystem;

public class StateGameController : MonoBehaviour
{
    [Header("Idle State References")]
    [SerializeField] private TPController controller;
    [SerializeField] private PlayerInputReader inputReader;
    [SerializeField] private PlayerInput controlIdle;
    [SerializeField] private InteractorRay interactorRay;
    [SerializeField] private Animator idleAnimator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            ActivateDesactivateCombatState();
        }
    }

    public void ActivateDesactivateCombatState()
    {
        controller.enabled = !controller.isActiveAndEnabled;
        inputReader.enabled = !inputReader.isActiveAndEnabled;
        controlIdle.enabled = !controlIdle.isActiveAndEnabled;
        interactorRay.enabled = !interactorRay.isActiveAndEnabled;
        idleAnimator.enabled = !idleAnimator.isActiveAndEnabled;
    }


}
