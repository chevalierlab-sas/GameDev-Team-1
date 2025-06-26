using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaryEventTrigger : MonoBehaviour
{
    public GameObject scare;                // Objek scare (misalnya hantu/monster)
    public AudioSource scareSounds1;        // Suara jumpscare
    public Collider collision;              // Collider trigger ini sendiri (agar bisa dinonaktifkan)

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera")) // BUKAN lagi "Player"
        {
            if (scare != null)
                scare.SetActive(true);

            if (scareSounds1 != null)
                scareSounds1.Play();

            if (collision != null)
                collision.enabled = false; // Menonaktifkan collider agar tidak bisa dipicu dua kali
        }
    }
}
