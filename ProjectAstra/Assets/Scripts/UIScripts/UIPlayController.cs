using UnityEngine;

public class UIPlayController : MonoBehaviour
{
    public static UIPlayController instance;
    [SerializeField] private GameObject interactReference;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ActivateInteractImage()
    {
        interactReference.SetActive(!interactReference.activeSelf);
    }
}
