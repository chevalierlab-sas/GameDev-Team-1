using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject intText, key, lockedText;
    public bool interactable, toggle;
    public Animator doorAnim;
    public AudioSource doorsound,locksound;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
            interactable = false;
        }
    }
    void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (key.active == false)
                {
                    toggle = !toggle;
                    doorsound.Play();   
                    if (toggle == true)
                    {
                        doorAnim.ResetTrigger("tutup");
                        doorAnim.SetTrigger("buka");
                    }
                    if (toggle == false)
                    {
                        doorAnim.ResetTrigger("buka");
                        doorAnim.SetTrigger("tutup");
                    }
                    intText.SetActive(false);
                    interactable = false;
                }
                if (key.active == true)
                {
                    lockedText.SetActive(true);
                    locksound.Play();
                    StopCoroutine("disableText");
                    StartCoroutine("disableText");
                }
            }
        }
    }
    IEnumerator disableText()
    {
        yield return new WaitForSeconds(2.0f);
        lockedText.SetActive(false);
    }
}
