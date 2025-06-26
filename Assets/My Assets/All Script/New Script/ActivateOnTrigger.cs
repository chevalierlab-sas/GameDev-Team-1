using UnityEngine;

public class ActivateOnTrigger : MonoBehaviour
{
    public GameObject objectToActivate; // Objek yang ingin diaktifkan
    public AudioSource audioSourceToPlay; // AudioSource yang akan dimainkan
    private bool hasActivated = false;  // Cegah aktivasi berulang

    private void OnTriggerEnter(Collider other)
    {
        if (!hasActivated && other.CompareTag("MainCamera")) // Hanya aktif 1x
        {
            objectToActivate.SetActive(true); // Aktifkan objek

            // Mainkan suara dari AudioSource jika ada
            if (audioSourceToPlay != null)
            {
                audioSourceToPlay.Play();
            }

            hasActivated = true; // Tandai sudah aktif
            gameObject.SetActive(false); // Nonaktifkan trigger ini
        }
    }
}
