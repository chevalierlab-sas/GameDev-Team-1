using UnityEngine;
using UnityEngine.UI;

public class RadioController : MonoBehaviour
{
    public AudioSource radioAudio;
    public Text interactText;

    public AudioClip[] playlist; // Daftar lagu
    private int currentTrack = -1;

    private bool isOn = false;
    private bool isPlayerInRange = false;

    void Start()
    {
        interactText.text = "";
        radioAudio.loop = true; // Biar tiap lagu bisa berulang
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ToggleRadio();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            isPlayerInRange = true;
            interactText.text = isOn ? "E to turn off" : "E to turn on";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            isPlayerInRange = false;
            interactText.text = "";
        }
    }

    void ToggleRadio()
    {
        isOn = !isOn;

        if (isOn)
        {
            PlayNextTrack();
            radioAudio.Play();
            interactText.text = "E to turn off";
        }
        else
        {
            radioAudio.Stop();
            interactText.text = "E to turn on";
        }
    }

    void PlayNextTrack()
    {
        if (playlist.Length == 0) return;

        currentTrack = (currentTrack + 1) % playlist.Length;
        radioAudio.clip = playlist[currentTrack];
    }
}
