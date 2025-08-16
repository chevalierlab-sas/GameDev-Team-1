using UnityEngine;

public class ColliderObjective : MonoBehaviour
{
    [Header("Objective Messages")]
    [TextArea] public string objectiveMessageID; // Teks objektif bahasa Indonesia
    [TextArea] public string objectiveMessageEN; // Teks objektif bahasa Inggris

    public bool hideObjective; // Jika true, teks akan hilang ketika menyentuh collider ini

    private bool hasTriggered = false; // Supaya hanya trigger sekali

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return; // Sudah pernah triggered? skip.

        if (other.CompareTag("MainCamera")) // Pastikan MainCamera punya collider
        {
            ObjectiveManager manager = FindObjectOfType<ObjectiveManager>();

            if (hideObjective)
            {
                manager.HideObjective();
            }
            else
            {
                string currentLang = PlayerPrefs.GetString("LANGUAGE", "INDONESIAN"); // default INDONESIAN
                string messageToShow;

                if (currentLang == "ENGLISH")
                {
                    messageToShow = objectiveMessageEN;
                }
                else // Default Indonesian
                {
                    messageToShow = objectiveMessageID;
                }

                manager.ShowObjective(messageToShow);
            }

            hasTriggered = true; // Tandai sudah pernah triggered
        }
    }
}
