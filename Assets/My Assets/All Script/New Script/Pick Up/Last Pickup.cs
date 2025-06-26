using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastPickup : MonoBehaviour
{
    public GameObject inttext, key, dialogue;
    public GameObject objectToActivate; // Objek yang akan diaktifkan saat kunci dipickup
    public AudioSource pickup;
    public bool interactable, toggle;
    public string dialogueString;
    public Text dialogueText;
    public float dialogueTime;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(false);
            interactable = false;
        }
    }

    void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inttext.SetActive(false);
                interactable = false;
                pickup.Play();
                key.SetActive(false);
                dialogueText.text = dialogueString;
                dialogue.SetActive(true);
                toggle = true;

                if (objectToActivate != null)
                {
                    objectToActivate.SetActive(true); // Aktifkan objek tambahan saat pickup
                }
            }
        }
    }
}
