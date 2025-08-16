using UnityEngine;
using TMPro;

public class ObjectiveManager : MonoBehaviour
{
    public TextMeshProUGUI objectiveText;

    public void ShowObjective(string text)
    {
        objectiveText.text = text;
        objectiveText.gameObject.SetActive(true);
    }

    public void HideObjective()
    {
        objectiveText.gameObject.SetActive(false);
    }
}
