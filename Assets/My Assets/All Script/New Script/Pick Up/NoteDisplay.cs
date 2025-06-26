using UnityEngine;

public class NoteDisplay : MonoBehaviour
{
    private bool isNoteActive = false;
    private float timer = 0f;
    private GameObject currentNoteUI;

    void Update()
    {
        if (isNoteActive)
        {
            timer -= Time.unscaledDeltaTime;

            if (timer <= 0f || Input.GetKeyDown(KeyCode.F))
            {
                CloseNote();
            }
        }
    }

    public void ShowNoteUI(GameObject noteUI, float duration)
    {
        currentNoteUI = noteUI;
        currentNoteUI.SetActive(true);
        timer = duration;
        isNoteActive = true;
        Time.timeScale = 0f; // pause game
    }

    void CloseNote()
    {
        if (currentNoteUI != null)
            currentNoteUI.SetActive(false);

        isNoteActive = false;
        Time.timeScale = 1f; // resume game
    }
}
