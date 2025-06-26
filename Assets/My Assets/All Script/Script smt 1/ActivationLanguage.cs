using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivationLanguage : MonoBehaviour
{
    [System.Serializable]
    public enum CLanguageType
    {
        Indonesian, English, Korean, Chinese, Arabian, Japanese
    }

    [Header("Main Settings")]
    public CLanguageType LanguageType;
    public bool SaveOnAwake;

    [Header("Event Settings")]
    public UnityEvent StartEvents;
    public UnityEvent UpdateEvents;
    public UnityEvent IndonesianEvents;
    public UnityEvent EnglishEvents;
    public UnityEvent ChineseEvents;
    public UnityEvent KoreanEvents;
    public UnityEvent ArabianEvents;
    public UnityEvent JapaneseEvents;

    public void LoadLanguage()
    {
        if (PlayerPrefs.GetString("LANGUAGE") == "INDONESIAN")
        {
            LanguageType = CLanguageType.Indonesian;
            IndonesianEvents?.Invoke();
        }
        if (PlayerPrefs.GetString("LANGUAGE") == "ENGLISH")
        {
            LanguageType = CLanguageType.English;
            EnglishEvents?.Invoke();
        }
        if (PlayerPrefs.GetString("LANGUAGE") == "CHINESE")
        {
            LanguageType = CLanguageType.Chinese;
            ChineseEvents?.Invoke();
        }
        if (PlayerPrefs.GetString("LANGUAGE") == "KOREAN")
        {
            LanguageType = CLanguageType.Korean;
            KoreanEvents?.Invoke();
        }
        if (PlayerPrefs.GetString("LANGUAGE") == "ARABIAN")
        {
            LanguageType = CLanguageType.Arabian;
            ArabianEvents?.Invoke();
        }
        if (PlayerPrefs.GetString("LANGUAGE") == "JAPANESE")
        {
            LanguageType = CLanguageType.Japanese;
            JapaneseEvents?.Invoke();
        }
        Debug.Log(PlayerPrefs.GetString("LANGUAGE"));
    }

    public void SaveLanguage()
    {
        if (LanguageType == CLanguageType.Indonesian)
        {
            PlayerPrefs.SetString("LANGUAGE", "INDONESIAN");
        }
        if (LanguageType == CLanguageType.English)
        {
            PlayerPrefs.SetString("LANGUAGE", "ENGLISH");
        }
        if (LanguageType == CLanguageType.Chinese)
        {
            PlayerPrefs.SetString("LANGUAGE", "CHINESE");
        }
        if (LanguageType == CLanguageType.Korean)
        {
            PlayerPrefs.SetString("LANGUAGE", "KOREAN");
        }
        if (LanguageType == CLanguageType.Arabian)
        {
            PlayerPrefs.SetString("LANGUAGE", "ARABIAN");
        }
        if (LanguageType == CLanguageType.Japanese)
        {
            PlayerPrefs.SetString("LANGUAGE", "JAPANESE");
        }
    }

    public void SelectIndonesian()
    {
        LanguageType = CLanguageType.Indonesian;
    }

    public void SelectEnglish()
    {
        LanguageType = CLanguageType.English;
    }

    public void SelectChinese()
    {
        LanguageType = CLanguageType.Chinese;
    }

    public void SelectKorean()
    {
        LanguageType = CLanguageType.Korean;
    }

    public void SelectArabian()
    {
        LanguageType = CLanguageType.Arabian;
    }

    public void SelectJapanese()
    {
        LanguageType = CLanguageType.Japanese;
    }

    public void SaveIndonesian()
    {
        LanguageType = CLanguageType.Indonesian;
        SaveLanguage();
    }

    public void SaveEnglish()
    {
        LanguageType = CLanguageType.English;
        SaveLanguage();
    }

    public void SaveChinese()
    {
        LanguageType = CLanguageType.Chinese;
        SaveLanguage();
    }

    public void SaveKorean()
    {
        LanguageType = CLanguageType.Korean;
        SaveLanguage();
    }

    public void SaveArabian()
    {
        LanguageType = CLanguageType.Arabian;
        SaveLanguage();
    }

    public void SaveJapanese()
    {
        LanguageType = CLanguageType.Japanese;
        SaveLanguage();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (SaveOnAwake)
        {
            SaveLanguage();
        }

        StartEvents?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEvents?.Invoke();
    }
}

