using UnityEngine;
using UnityEngine.UI;

public class PickupActivateCollider : MonoBehaviour
{
    public Collider colliderToActivate;         // Collider yang akan diaktifkan
    public GameObject pickupTextUI;             // UI teks setelah pickup
    public GameObject interactTextUI;           // UI "Press E to Pick Up"
    public KeyCode pickupKey = KeyCode.E;       // Tombol untuk pickup
    public AudioClip pickupSound;               // Suara saat pickup
    public AudioSource audioSource;             // Sumber suara

    private bool isPlayerCameraTouching = false;
    private bool isItemPickedUp = false;

    void Start()
    {
        if (pickupTextUI != null)
            pickupTextUI.SetActive(false);

        if (interactTextUI != null)
            interactTextUI.SetActive(false);
    }

    void Update()
    {
        if (isPlayerCameraTouching && !isItemPickedUp)
        {
            if (interactTextUI != null)
                interactTextUI.SetActive(true);

            if (Input.GetKeyDown(pickupKey))
            {
                PickUpItem();
            }
        }
        else
        {
            if (interactTextUI != null)
                interactTextUI.SetActive(false);
        }
    }

    void PickUpItem()
    {
        if (colliderToActivate != null)
            colliderToActivate.enabled = true;

        isItemPickedUp = true;

        if (interactTextUI != null)
            interactTextUI.SetActive(false);

        if (pickupTextUI != null)
            pickupTextUI.SetActive(true);

        // 🔊 Mainkan suara pickup
        if (pickupSound != null && audioSource != null)
            audioSource.PlayOneShot(pickupSound);

        // Hancurkan objek ini setelah suara diputar (opsional: bisa pakai delay kalau perlu)
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
            isPlayerCameraTouching = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
            isPlayerCameraTouching = false;
    }
}
