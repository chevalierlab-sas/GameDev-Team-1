using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beginningCutscene : MonoBehaviour
{
    public GameObject cutsceneCam, player,begintext,tutor;
    public float cutsceneTime;

    void Start()
    {
        StartCoroutine(cutscene());
    }
    IEnumerator cutscene()
    {
        yield return new WaitForSeconds(cutsceneTime);
        player.SetActive(true);
        cutsceneCam.SetActive(false);
        tutor.SetActive(true);      
        begintext.SetActive(true);
   
       
    }
}