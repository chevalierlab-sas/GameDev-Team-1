using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collidertext : MonoBehaviour
{
    public GameObject dialogue,collider;
    public string dialogueString;    
    public float dialogueTime;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {          
            dialogue.SetActive(true);
            StartCoroutine(disableDialogue());
            collider.SetActive(false);
        }
    }
    IEnumerator disableDialogue()
    {
        yield return new WaitForSeconds(3);
        dialogue.SetActive(false);
    }
}