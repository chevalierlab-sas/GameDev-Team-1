using UnityEngine;

public class ActivateOnTrigger : MonoBehaviour
{
    [Header("Object Settings")]
    public GameObject objectToActivate;     // Objek yang ingin diaktifkan
    public GameObject objectToDeactivate;   // Objek yang ingin dinonaktifkan

    [Header("Audio Settings")]
    public AudioSource audioSourceToPlay;   // AudioSource yang akan dimainkan

    private bool hasActivated = false;      // Cegah aktivasi berulang

    private void OnTriggerEnter(Collider other)
    {
        if (!hasActivated && other.CompareTag("MainCamera")) // Hanya aktif 1x
        {
            // Aktifkan objek
            if (objectToActivate != null)
                objectToActivate.SetActive(true);

            // Nonaktifkan objek
            if (objectToDeactivate != null)
                objectToDeactivate.SetActive(false);

            // Mainkan suara dari AudioSource jika ada
            if (audioSourceToPlay != null)
                audioSourceToPlay.Play();

            hasActivated = true;
            gameObject.SetActive(false); // Nonaktifkan trigger ini
        }
    }
}
