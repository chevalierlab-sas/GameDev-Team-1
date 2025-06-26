using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class VisualizationText : MonoBehaviour
{

    [Header("Language Settings")]
    [TextArea(5, 5)]
    public string IndonesianText;
    [TextArea(5, 5)]
    public string EnglishText;
    [TextArea(5, 5)]
    public string KoreanText;
    [TextArea(5, 5)]
    public string ChineseText;
    [TextArea(5, 5)]
    public string ArabianText;
    [TextArea(5, 5)]
    public string JapaneseText;

    private Text CurrentText;
    string CurrentLanguage;

    [Header("Event Settings")]
    public UnityEvent StartEvents;
    public UnityEvent UpdateEvents;

    // Start is called before the first frame update
    void Start()
    {
        CurrentText = GetComponent<Text>();
        InvokeRepeating("UpdateText", 0, 1f);
        StartEvents?.Invoke();
    }

    // Update is called once per frame
    void UpdateText()
    {
        CurrentLanguage = PlayerPrefs.GetString("LANGUAGE");
        if (PlayerPrefs.GetString("LANGUAGE") == "INDONESIAN")
        {
            CurrentText.text = IndonesianText;
        }
        if (PlayerPrefs.GetString("LANGUAGE") == "ENGLISH")
        {
            CurrentText.text = EnglishText;
        }
        if (PlayerPrefs.GetString("LANGUAGE") == "CHINESE")
        {
            CurrentText.text = ChineseText;
        }
        if (PlayerPrefs.GetString("LANGUAGE") == "KOREAN")
        {
            CurrentText.text = KoreanText;
        }
        if (PlayerPrefs.GetString("LANGUAGE") == "ARABIAN")
        {
            CurrentText.text = ArabianText;
        }
        if (PlayerPrefs.GetString("LANGUAGE") == "JAPANESE")
        {
            CurrentText.text = JapaneseText;
        }

        UpdateEvents?.Invoke();
    }
}

