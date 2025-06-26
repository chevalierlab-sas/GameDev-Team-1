using UnityEngine;

public class NotePickup : MonoBehaviour
{
    public float showDuration = 5f;
    public GameObject promptUI;       // UI petunjuk "Tekan E"
    public GameObject noteUI;         // Panel UI catatan (sudah berisi teks di dalamnya)

    private bool isPlayerNear = false;
    private bool isNoteShown = false;

    private NoteDisplay noteDisplay;

    void Start()
    {
        noteDisplay = FindObjectOfType<NoteDisplay>();
        if (promptUI != null) promptUI.SetActive(false);
        if (noteUI != null) noteUI.SetActive(false); // pastikan tidak tampil dulu
    }

    void Update()
    {
        if (isPlayerNear && !isNoteShown)
        {
            if (promptUI != null)
                promptUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                isNoteShown = true;

                if (promptUI != null)
                    promptUI.SetActive(false);

                if (noteDisplay != null)
                    noteDisplay.ShowNoteUI(noteUI, showDuration); // aktifkan UI yang sudah ada

                gameObject.SetActive(false); // hilangkan objek pickup
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
            isPlayerNear = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            isPlayerNear = false;
            if (promptUI != null)
                promptUI.SetActive(false);
        }
    }
}
