using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class nextLevel : MonoBehaviour
{
    public string sceneName;
    public int levelNumber;

    public GameObject loadingPanel;   // Panel UI loading dari Canvas (drag dari inspector)
    public Slider progressBar;        // (Opsional) Slider untuk progress bar

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            PlayerPrefs.SetInt("level", levelNumber);
            PlayerPrefs.Save();

            StartCoroutine(LoadSceneWithLoading());
        }
    }

    IEnumerator LoadSceneWithLoading()
    {
        if (loadingPanel != null)
            loadingPanel.SetActive(true);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            if (progressBar != null)
                progressBar.value = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            yield return null;
        }
    }
}
