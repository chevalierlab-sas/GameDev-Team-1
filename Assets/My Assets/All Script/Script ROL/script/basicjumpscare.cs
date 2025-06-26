using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class basicjumpscare : MonoBehaviour
{
    public GameObject playerObj, playerCam, jumpscareCam, monster;
    public Animator monsterAnim;
    public AudioSource scaresound;
    public float jumpscareDuration = 5f; 
    


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(JumpscareSequence());
        }
    }

    IEnumerator JumpscareSequence()
    {
        playerObj.SetActive(false);
        playerCam.SetActive(false); 
        scaresound.Play();
        monsterAnim.speed = 2f;
        jumpscareCam.SetActive(true);
        monster.SetActive(true);

        yield return new WaitForSeconds(jumpscareDuration);

        jumpscareCam.SetActive(false);
        monster.SetActive(false);
        playerObj.SetActive(true);
        playerCam.SetActive(true); 

        
    }
}
