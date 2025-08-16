using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public DialogManager dialogManager;

    public SC_FPSController playerMovement; // Ganti dengan script pergerakanmu

    // Dialog versi multibahasa
    public string[] dialogLines_ID;
    public string[] dialogLines_EN;

    public string[] speakers_ID;
    public string[] speakers_EN;

    public AudioClip[] voiceClips_ID;
    public AudioClip[] voiceClips_EN;

    private bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera") && !hasTriggered)
        {
            hasTriggered = true;

            // Nonaktifkan gerakan (tapi bukan kamera)
            if (playerMovement != null)
                playerMovement.canMove = false;

            string language = PlayerPrefs.GetString("LANGUAGE");

            if (language == "INDONESIAN")
            {
                dialogManager.StartDialog(dialogLines_ID, speakers_ID, voiceClips_ID, OnDialogFinished);
            }
            else
            {
                dialogManager.StartDialog(dialogLines_EN, speakers_EN, voiceClips_EN, OnDialogFinished);
            }
        }
    }

    void OnDialogFinished()
    {
        if (playerMovement != null)
            playerMovement.canMove = true;
    }
}
