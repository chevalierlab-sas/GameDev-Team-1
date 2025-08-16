using UnityEngine;
using UnityEngine.UI;

public class PlayerChoiceSystem : MonoBehaviour
{
    [Header("UI Components")]
    public GameObject choiceUI;
    public Text questionText;
    public Button optionAButton;
    public Button optionBButton;

    [Header("Option A Settings")]
    public GameObject[] activateOnA;   // Objek yang diaktifkan saat A
    public GameObject[] deactivateOnA; // Objek yang dinonaktifkan saat A

    [Header("Option B Settings")]
    public GameObject[] activateOnB;   // Objek yang diaktifkan saat B
    public GameObject[] deactivateOnB; // Objek yang dinonaktifkan saat B

    [Header("Player")]
    public MonoBehaviour playerController;

    void Start()
    {
        choiceUI.SetActive(false);
        optionAButton.onClick.AddListener(ChooseA);
        optionBButton.onClick.AddListener(ChooseB);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowChoices();
        }
    }

    private void ShowChoices()
    {
        choiceUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (playerController != null)
            playerController.enabled = false;
    }

    private void HideChoices()
    {
        choiceUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (playerController != null)
            playerController.enabled = true;
    }

    private void ChooseA()
    {
        ToggleObjects(activateOnA, true);
        ToggleObjects(deactivateOnA, false);

        HideChoices();
        DisableSystem();
    }

    private void ChooseB()
    {
        ToggleObjects(activateOnB, true);
        ToggleObjects(deactivateOnB, false);

        HideChoices();
        DisableSystem();
    }

    private void ToggleObjects(GameObject[] objects, bool state)
    {
        if (objects == null) return;
        foreach (GameObject obj in objects)
        {
            if (obj != null)
                obj.SetActive(state);
        }
    }

    private void DisableSystem()
    {
        gameObject.SetActive(false);
    }
}
