using UnityEngine;
using System.Collections;

public class UIFadeController : MonoBehaviour
{
    public enum FadeMode { FadeIn, FadeOut, FadeInOut }
    public CanvasGroup uiElement;
    public float fadeDuration = 1f;
    public float holdTime = 2f; // Waktu bertahan saat FadeInOut
    public FadeMode fadeMode = FadeMode.FadeIn;

    private Coroutine currentCoroutine;

    void Awake()
    {
        if (uiElement == null)
        {
            uiElement = GetComponent<CanvasGroup>();
        }
    }

    public void StartFade()
    {
        if (currentCoroutine != null) StopCoroutine(currentCoroutine);

        switch (fadeMode)
        {
            case FadeMode.FadeIn:
                currentCoroutine = StartCoroutine(FadeCanvasGroup(uiElement.alpha, 1f));
                break;

            case FadeMode.FadeOut:
                currentCoroutine = StartCoroutine(FadeCanvasGroup(uiElement.alpha, 0f));
                break;

            case FadeMode.FadeInOut:
                currentCoroutine = StartCoroutine(FadeInOutRoutine());
                break;
        }
    }

    private IEnumerator FadeCanvasGroup(float start, float end)
    {
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            uiElement.alpha = Mathf.Lerp(start, end, elapsed / fadeDuration);
            yield return null;
        }
        uiElement.alpha = end;
    }

    private IEnumerator FadeInOutRoutine()
    {
        yield return FadeCanvasGroup(uiElement.alpha, 1f);
        yield return new WaitForSeconds(holdTime);
        yield return FadeCanvasGroup(1f, 0f);
    }
}
