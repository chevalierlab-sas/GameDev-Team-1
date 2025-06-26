using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickupFlashlight : MonoBehaviour
{
    public GameObject inttext, dialogue, flashlight_table, flashlight_hand, wincollider;
    public string dialogueString;
    public Text dialogueText;
    public AudioSource pickup;
    public bool interactable,toggle;
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
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inttext.SetActive(false);
                interactable = false;
                pickup.Play();
                flashlight_hand.SetActive(true);
                flashlight_table.SetActive(false);
                dialogueText.text = dialogueString;
                dialogue.SetActive(true);
                inttext.SetActive(false);
                toggle = true;
                interactable = false;
            }
        }
    }
}