using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneWithLoading : MonoBehaviour
{
    public string sceneToLoad; // Nama scene yang akan dimuat
    public GameObject loadingScreen; // Panel loading
    public Slider progressBar; // Slider untuk progress loading

    public float minLoadingTime; // Durasi minimal loading (dalam detik)

    public void PlayGame()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        loadingScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);
        operation.allowSceneActivation = false;

        float timer = 0f;

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressBar.value = progress;

            timer += Time.deltaTime;

            if (operation.progress >= 0.9f && timer >= minLoadingTime)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
