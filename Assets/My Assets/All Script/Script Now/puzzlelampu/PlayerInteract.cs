using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E;
    public GameObject interactUI; // UI "Press E" text
    private InteractSwitch currentSwitch;

    private void OnTriggerEnter(Collider other)
    {
        InteractSwitch interactable = other.GetComponent<InteractSwitch>();
        if (interactable != null)
        {
            interactUI.SetActive(true);
            currentSwitch = interactable;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        InteractSwitch interactable = other.GetComponent<InteractSwitch>();
        if (interactable != null && interactable == currentSwitch)
        {
            interactUI.SetActive(false);
            currentSwitch = null;
        }
    }

    private void Update()
    {
        if (currentSwitch != null && Input.GetKeyDown(interactKey))
        {
            currentSwitch.Interact();
        }
    }
}
