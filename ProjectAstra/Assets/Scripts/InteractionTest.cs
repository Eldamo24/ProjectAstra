using UnityEngine;

public class InteractionTest : MonoBehaviour, IInteractable
{
    public void Interaction()
    {
        print("Interactuaste con: " + gameObject.name); 
    }
}
