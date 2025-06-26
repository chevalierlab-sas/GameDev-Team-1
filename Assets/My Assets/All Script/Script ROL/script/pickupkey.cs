using UnityEngine;
using UnityEngine.UI;

public class Pickupkey : MonoBehaviour
{
    public GameObject inttext;       // UI petunjuk "Tekan E"
    public GameObject key;           // Objek kunci
    public GameObject dialogue;      // UI panel dialog
    public AudioSource pickup;       // Audio saat ambil

    public Text dialogueText;        // Text UI untuk dialog
    public float dialogueTime = 3f;  // Durasi tampil

    private bool interactable = false;
    private bool toggle = false;

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
        if (interactable && Input.GetKeyDown(KeyCode.E))
        {
            inttext.SetActive(false);
            interactable = false;
            pickup.Play();
            key.SetActive(false);

            // Aktifkan UI dialog yang sudah diisi teks-nya dari editor
            dialogue.SetActive(true);
            toggle = true;

            // Sembunyikan dialog setelah beberapa detik
            Invoke("HideDialogue", dialogueTime);
        }
    }

    void HideDialogue()
    {
        dialogue.SetActive(false);
        toggle = false;
    }
}
