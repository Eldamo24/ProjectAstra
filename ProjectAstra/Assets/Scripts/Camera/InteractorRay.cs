using System;
using UnityEngine;

public class InteractorRay : MonoBehaviour
{
    private bool canInteract;
    private int flag = 0;
    private float maxDistance;
    [SerializeField] private LayerMask interactLayer;
    private RaycastHit hit;
    public bool CanInteract { get => canInteract; set => canInteract = value; }
    public RaycastHit Hit { get => hit; set => hit = value; }

    private void Start()
    {
        canInteract = false;
        maxDistance = 5f;
    }

    private void Update()
    {
        DetectInteraction();
    }

    private void DetectInteraction()
    {
        Camera cam = Camera.main;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        canInteract = Physics.Raycast(ray, out hit, maxDistance, interactLayer);
        if (canInteract && flag == 0)
        {
            UIPlayController.instance.ActivateInteractImage();
            flag = 1;
        }
        else if(!canInteract && flag == 1)
        {
            flag = 0;
            UIPlayController.instance.ActivateInteractImage();
        }
    }
}
