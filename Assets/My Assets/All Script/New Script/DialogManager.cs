using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogText;
    public GameObject dialogUI;
    public Animator npcAnimator;
    public string endDialogTrigger = "React";

    public float typingSpeed = 0.05f;
    public AudioSource audioSource;

    private string[] lines;
    private string[] speakers;
    private AudioClip[] voiceClips;

    private int currentLineIndex;
    private bool isTyping = false;
    private Coroutine typingCoroutine;
    private string currentLine;

    void Start()
    {
        dialogUI.SetActive(false);
    }

    public void StartDialog(string[] dialogLines, string[] speakerNames, AudioClip[] clips)
    {
        lines = dialogLines;
        speakers = speakerNames;
        voiceClips = clips;

        currentLineIndex = 0;
        dialogUI.SetActive(true);
        ShowNextLine();
    }

    public void ShowNextLine()
    {
        if (isTyping)
        {
            StopCoroutine(typingCoroutine);
            dialogText.text = currentLine;
            isTyping = false;

            if (audioSource.isPlaying)
                audioSource.Stop(); // Hentikan suara jika typing di-skip

            return;
        }

        if (currentLineIndex < lines.Length)
        {
            nameText.text = speakers[currentLineIndex];
            currentLine = lines[currentLineIndex];

            // Mainkan suara
            if (voiceClips != null && currentLineIndex < voiceClips.Length && voiceClips[currentLineIndex] != null)
            {
                audioSource.Stop();
                audioSource.clip = voiceClips[currentLineIndex];
                audioSource.Play();
            }

            typingCoroutine = StartCoroutine(TypeLine(currentLine));
            currentLineIndex++;
        }
        else
        {
            dialogUI.SetActive(false);

            if (audioSource.isPlaying)
                audioSource.Stop();

            if (npcAnimator != null)
            {
                npcAnimator.SetTrigger(endDialogTrigger);
            }
        }
    }

    IEnumerator TypeLine(string line)
    {
        isTyping = true;
        dialogText.text = "";

        foreach (char c in line)
        {
            dialogText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;

        // ?? Tambahan penting: Hentikan suara ketika typing selesai
        if (audioSource.isPlaying)
            audioSource.Stop();
    }

    void Update()
    {
        if (dialogUI.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            ShowNextLine();
        }
    }
}
