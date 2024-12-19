using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class StateGameController : MonoBehaviour
{
    [Header("Idle State References")]
    [SerializeField] private TPController controller;
    [SerializeField] private PlayerInputReader inputReader;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private InteractorRay interactorRay;
    [SerializeField] private AnimatorStateController animStateController;
    [SerializeField] private CombatInputReader combatInputReader;
    [SerializeField] private PlayerCombatController playerCombatController;
    [SerializeField] private GameObject idleCamera;
    [SerializeField] private GameObject combatCamera;

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
        interactorRay.enabled = !interactorRay.isActiveAndEnabled;
        animStateController.IdleState = !animStateController.IdleState;
        combatInputReader.enabled = !combatInputReader.isActiveAndEnabled;
        playerCombatController.enabled = !playerCombatController.isActiveAndEnabled;
        if (playerInput.currentActionMap.name.Equals("Player"))
        {
            idleCamera.SetActive(false);
            combatCamera.SetActive(true);
            playerInput.SwitchCurrentActionMap("Combat");
            animStateController.Anim.runtimeAnimatorController = animStateController.CombatController;
        }
        else
        {
            idleCamera.SetActive(true);
            combatCamera.SetActive(false);
            playerInput.SwitchCurrentActionMap("Player");
            animStateController.Anim.runtimeAnimatorController = animStateController.IdleController;
        }
    }
}
