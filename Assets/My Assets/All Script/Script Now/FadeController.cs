using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
    public Image fadeImage; // drag image hitam di sini
    public float fadeSpeed = 1.5f;
    public string nextSceneName = "NextScene"; // ganti dengan scene tujuan

    public void StartFadeToBlack()
    {
        StartCoroutine(FadeOutAndLoadScene());
    }

    IEnumerator FadeOutAndLoadScene()
    {
        float alpha = 0f;
        fadeImage.gameObject.SetActive(true);

        while (alpha < 1f)
        {
            alpha += Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0f, 0f, 0f, alpha);
            yield return null;
        }

        yield return new WaitForSeconds(2f); // delay setelah full black
        SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
    }
}
