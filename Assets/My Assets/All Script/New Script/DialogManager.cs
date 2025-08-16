using System;
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

    private Action onDialogFinishedCallback; // ✅ Tambahan untuk callback

    void Start()
    {
        dialogUI.SetActive(false);
    }

    // ✅ Ditambahkan parameter callback
    public void StartDialog(string[] dialogLines, string[] speakerNames, AudioClip[] clips, Action onFinished = null)
    {
        lines = dialogLines;
        speakers = speakerNames;
        voiceClips = clips;

        currentLineIndex = 0;
        dialogUI.SetActive(true);

        onDialogFinishedCallback = onFinished; // Simpan callback

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
                audioSource.Stop();

            return;
        }

        if (currentLineIndex < lines.Length)
        {
            nameText.text = speakers[currentLineIndex];
            currentLine = lines[currentLineIndex];

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

            // ✅ Panggil callback setelah dialog selesai
            if (onDialogFinishedCallback != null)
            {
                onDialogFinishedCallback.Invoke();
                onDialogFinishedCallback = null; // reset supaya aman
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
