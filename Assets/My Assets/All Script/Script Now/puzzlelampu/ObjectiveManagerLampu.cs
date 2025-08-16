using UnityEngine;
using TMPro;
using System.Collections;

public class ObjectiveManagerLampu : MonoBehaviour
{
    public TextMeshProUGUI objectiveText;
    private Coroutine currentCoroutine;

    public void SetObjective(string text)
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }

        objectiveText.text = text;
        objectiveText.gameObject.SetActive(true);

        currentCoroutine = StartCoroutine(HideTextAfterDelay(5f));
    }

    private IEnumerator HideTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        objectiveText.gameObject.SetActive(false);
    }
}
