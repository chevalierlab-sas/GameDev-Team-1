using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class TeleportWithUILoading : MonoBehaviour
{
    [Header("Scene Settings")]
    public string targetScene = "GoodendScene";

    [Header("UI Settings")]
    public GameObject loadingPanel; // Panel UI yang berisi loading screen
    public Slider loadingBar;       // Optional: progress bar

    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isTriggered && other.CompareTag("Player"))
        {
            isTriggered = true;
            StartCoroutine(LoadSceneWithUI());
        }
    }

    IEnumerator LoadSceneWithUI()
    {
        if (loadingPanel != null)
            loadingPanel.SetActive(true);

        yield return new WaitForSeconds(0.5f); // Delay awal agar panel tampil dulu

        AsyncOperation operation = SceneManager.LoadSceneAsync(targetScene);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            if (loadingBar != null)
                loadingBar.value = progress;

            if (operation.progress >= 0.9f)
            {
                yield return new WaitForSeconds(1f); // Delay sedikit sebelum masuk scene
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
