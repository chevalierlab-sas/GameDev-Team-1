using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public DialogManager dialogManager;

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
            string language = PlayerPrefs.GetString("LANGUAGE");

            if (language == "INDONESIAN")
            {
                dialogManager.StartDialog(dialogLines_ID, speakers_ID, voiceClips_ID);
            }
            else if (language == "ENGLISH")
            {
                dialogManager.StartDialog(dialogLines_EN, speakers_EN, voiceClips_EN);
            }
            else
            {
                // Default fallback
                dialogManager.StartDialog(dialogLines_EN, speakers_EN, voiceClips_EN);
            }

            hasTriggered = true;
        }
    }
}
