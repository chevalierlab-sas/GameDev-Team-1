using UnityEngine;
using UnityEngine.SceneManagement;

public class PindahSceneSaatTabrak : MonoBehaviour
{
    [Header("GoodendingScene")]
    public string sceneTujuan;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneTujuan, LoadSceneMode.Single);
        }
    }
}
