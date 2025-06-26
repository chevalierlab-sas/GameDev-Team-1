using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jumpscareTrig : MonoBehaviour
{
    public GameObject playerObj, jumpscareCam, ambianceLayers;
    public Animator monsterAnim;
    public string sceneName;
    public float jumpscareTime;
    public monsterAI monsterScript;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerObj.SetActive(false);
            monsterScript.enabled = false;
            monsterAnim.speed = 1f;
            jumpscareCam.SetActive(true);
            ambianceLayers.SetActive(false);
            StartCoroutine(changeScene());
            monsterAnim.SetTrigger("scare");
        }
    }
    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(jumpscareTime);
        SceneManager.LoadScene(sceneName);
    }
}