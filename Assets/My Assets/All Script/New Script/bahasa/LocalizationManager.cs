using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager Instance;

    public enum Language
    {
        English,
        Indonesian,
        Japanese
        // Tambahkan lainnya
    }

    public Language CurrentLanguage { get; private set; }

    private Dictionary<string, string> localizedText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadLanguage();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetLanguage(Language newLang)
    {
        CurrentLanguage = newLang;
        PlayerPrefs.SetString("LANGUAGE", newLang.ToString());
        LoadLanguage();
    }

    public void LoadLanguage()
    {
        string lang = PlayerPrefs.GetString("LANGUAGE", "English");
        CurrentLanguage = (Language)System.Enum.Parse(typeof(Language), lang);

        // Bisa diganti dengan load dari JSON/Text
        localizedText = new Dictionary<string, string>();

        switch (CurrentLanguage)
        {
            case Language.English:
                localizedText["start"] = "Start";
                localizedText["quit"] = "Quit";
                localizedText["language"] = "Language";
                break;
            case Language.Indonesian:
                localizedText["start"] = "Mulai";
                localizedText["quit"] = "Keluar";
                localizedText["language"] = "Bahasa";
                break;
            case Language.Japanese:
                localizedText["start"] = "????";
                localizedText["quit"] = "??";
                localizedText["language"] = "??";
                break;
        }
    }

    public string GetLocalizedValue(string key)
    {
        return localizedText.ContainsKey(key) ? localizedText[key] : key;
    }
}
