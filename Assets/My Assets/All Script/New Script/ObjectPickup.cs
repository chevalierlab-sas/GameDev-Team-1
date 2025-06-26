using UnityEngine;
using TMPro; // Tambahkan ini jika menggunakan TextMeshPro

public class ObjectPickup : MonoBehaviour
{
    public Transform handPosition; // Posisi tangan
    public float pickupRange = 3f; // Jarak pickup
    public LayerMask pickupLayer; // Layer objek pickup
    public TextMeshProUGUI pickupText; // Referensi ke UI Text

    private GameObject heldObject = null;
    private Rigidbody heldObjectRb;
    private bool canPickup = false; // Apakah objek bisa diambil

    [Header("Audio")]
    public AudioSource audioSource; // Audio Source untuk memainkan suara
    public AudioClip pickupClip; // Suara saat mengambil
    public AudioClip dropClip;   // Suara saat menjatuhkan

    void Update()
    {
        CheckForPickupableObject();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (heldObject == null && canPickup)
            {
                TryPickup();
            }
            else if (heldObject != null)
            {
                DropObject();
            }
        }
    }

    void CheckForPickupableObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, pickupRange, pickupLayer))
        {
            if (hit.collider.CompareTag("Pickupable"))
            {
                pickupText.text = "[Q]";
                pickupText.enabled = true;
                canPickup = true;
                return;
            }
        }

        pickupText.enabled = false;
        canPickup = false;
    }

    void TryPickup()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, pickupRange, pickupLayer))
        {
            if (hit.collider.CompareTag("Pickupable"))
            {
                heldObject = hit.collider.gameObject;
                heldObjectRb = heldObject.GetComponent<Rigidbody>();

                if (heldObjectRb != null)
                {
                    heldObjectRb.isKinematic = true;
                    heldObject.transform.SetParent(handPosition);
                    heldObject.transform.localPosition = Vector3.zero;
                    heldObject.transform.localRotation = Quaternion.identity;

                    PlaySound(pickupClip); // Mainkan suara pickup
                }
            }
        }
    }

    void DropObject()
    {
        if (heldObject != null)
        {
            heldObject.transform.SetParent(null);
            heldObjectRb.isKinematic = false;
            heldObjectRb.AddForce(transform.forward * 2f, ForceMode.Impulse);
            heldObject = null;

            PlaySound(dropClip); // Mainkan suara drop
        }
    }

    void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
