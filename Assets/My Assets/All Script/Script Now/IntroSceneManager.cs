using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IntroSceneManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject fadePanel;
    public Text descriptionText;
    public float typingSpeed = 0.05f;
    public GameObject objectToActivate;

    [Header("Text Translations")]
    [TextArea]
    public string indonesianText = "Seorang mahasiswi melihat selembar kertas...";
    [TextArea]
    public string englishText = "A female college student sees a piece of paper...";

    private Image panelImage;
    private SC_FPSController playerController;
    private string currentText; // The text to display depending on language

    void Start()
    {
        panelImage = fadePanel.GetComponent<Image>();
        playerController = FindObjectOfType<SC_FPSController>();

        // Disable player control at start
        if (playerController != null)
            playerController.enabled = false;

        // Load language setting from PlayerPrefs
        string lang = PlayerPrefs.GetString("LANGUAGE", "INDONESIAN").ToUpper();
        if (lang == "ENGLISH")
        {
            currentText = englishText;
        }
        else
        {
            currentText = indonesianText;
        }

        // Clear text for typing effect
        descriptionText.text = "";

        // Start intro sequence
        StartCoroutine(PlayIntroSequence());
    }

    IEnumerator PlayIntroSequence()
    {
        // Typewriter effect
        yield return StartCoroutine(TypeText());

        // Small pause
        yield return new WaitForSeconds(2f);

        // Fade out
        yield return StartCoroutine(FadeOutPanel());

        // Enable player control
        if (playerController != null)
            playerController.enabled = true;

        // Activate target object
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }

    IEnumerator TypeText()
    {
        foreach (char c in currentText)
        {
            descriptionText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator FadeOutPanel()
    {
        float duration = 1f;
        float t = 0;
        Color color = panelImage.color;

        while (t < duration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(1, 0, t / duration);
            panelImage.color = color;
            yield return null;
        }

        fadePanel.SetActive(false);
    }
}
