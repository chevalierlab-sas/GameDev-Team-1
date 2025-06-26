using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LatterPickupManager : MonoBehaviour
{
    public int totalLatter = 5;
    private int collectedLatter = 0;

    public Text pickupText;          // Contoh: "Kayu bakar: 1/5"
    public Text interactionText;     // Contoh: "Tekan R untuk mengambil kayu"
    public Text completeText;        // Teks yang muncul jika semua sudah terkumpul
    public GameObject objectToDeactivate; // Objek yang akan dinonaktifkan saat quest selesai
    public GameObject objectToActivate;   // Objek yang akan diaktifkan saat quest selesai

    public string interactKey = "e";
    private GameObject nearbyLatter;

    public float completeMessageDuration = 5f;

    void Start()
    {
        UpdateUI();
        if (interactionText != null) interactionText.gameObject.SetActive(false);
        if (completeText != null) completeText.gameObject.SetActive(false);

        // Pastikan objek yang ingin diaktifkan awalnya nonaktif (opsional)
        if (objectToActivate != null)
            objectToActivate.SetActive(false);
    }

    void Update()
    {
        if (nearbyLatter != null)
        {
            if (interactionText != null)
                interactionText.gameObject.SetActive(true);

            if (Input.GetKeyDown(interactKey))
            {
                PickupLatter(nearbyLatter);
            }
        }
        else
        {
            if (interactionText != null)
                interactionText.gameObject.SetActive(false);
        }
    }

    void PickupLatter(GameObject latter)
    {
        collectedLatter++;
        UpdateUI();

        // Sembunyikan objek kayu
        Collider col = latter.GetComponent<Collider>();
        if (col != null) col.enabled = false;

        Renderer rend = latter.GetComponent<Renderer>();
        if (rend != null) rend.enabled = false;

        nearbyLatter = null;

        // Cek apakah sudah terkumpul semua
        if (collectedLatter >= totalLatter)
        {
            ShowCompleteMessage();
        }
    }

    void UpdateUI()
    {
        if (pickupText != null)
        {
            if (collectedLatter >= totalLatter)
                pickupText.text = " ";
            else
                pickupText.text = "Firewood: " + collectedLatter + "/" + totalLatter;
        }
    }

    void ShowCompleteMessage()
    {
        if (completeText != null)
        {
            completeText.gameObject.SetActive(true);
            completeText.text = "All the wood has been collected and we can continue into the forest!";
            StartCoroutine(HideCompleteTextAfterDelay());
        }

        // Menonaktifkan objek saat quest selesai
        if (objectToDeactivate != null)
        {
            objectToDeactivate.SetActive(false);
        }

        // Mengaktifkan objek saat quest selesai
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }

    IEnumerator HideCompleteTextAfterDelay()
    {
        yield return new WaitForSeconds(completeMessageDuration);
        if (completeText != null)
            completeText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Latter"))
        {
            nearbyLatter = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Latter") && other.gameObject == nearbyLatter)
        {
            nearbyLatter = null;
        }
    }

    public void ForceUIUpdate()
    {
        UpdateUI();
    }
}