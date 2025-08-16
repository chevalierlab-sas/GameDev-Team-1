using UnityEngine;
using UnityEngine.UI;

public class SwitchLampController : MonoBehaviour
{
    public GameObject interactionUI;
    private SwitchTarget currentSwitch;  // Saklar aktif yang disentuh

    private void Start()
    {
        if (interactionUI != null)
            interactionUI.SetActive(false);
    }

    private void Update()
    {
        if (currentSwitch != null && Input.GetKeyDown(KeyCode.E))
        {
            currentSwitch.ToggleLamp();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Switch"))
        {
            currentSwitch = other.GetComponent<SwitchTarget>();
            if (interactionUI != null)
                interactionUI.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Switch"))
        {
            if (currentSwitch == null)
                currentSwitch = other.GetComponent<SwitchTarget>();

            if (interactionUI != null && !interactionUI.activeSelf)
                interactionUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Switch"))
        {
            currentSwitch = null;
            if (interactionUI != null)
                interactionUI.SetActive(false);
        }
    }
}
