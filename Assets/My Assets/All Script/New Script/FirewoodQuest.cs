using UnityEngine;
using UnityEngine.UI; // Untuk UI Text

public class FirewoodQuest : MonoBehaviour
{
    public Text questText;            // Referensi ke teks quest di UI
    private int firewoodCount = 0;     // Jumlah kayu yang sudah dikumpulkan
    private int firewoodTarget = 5;    // Target kayu yang harus dikumpulkan

    void Start()
    {
        UpdateQuestText();
    }

    // Panggil fungsi ini saat player mengambil kayu bakar
    public void PickupFirewood()
    {
        firewoodCount++;

        // Pastikan tidak melebihi target
        if (firewoodCount > firewoodTarget)
            firewoodCount = firewoodTarget;

        UpdateQuestText();
    }

    private void UpdateQuestText()
    {
        if (firewoodCount < firewoodTarget)
        {
            questText.text = "Kumpulkan kayu bakar: " + firewoodCount + "/" + firewoodTarget;
        }
        else
        {
            questText.text = "Kayu bakar terkumpul! Kembali ke base. ✅";
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Firewood"))
        {
            FindObjectOfType<FirewoodQuest>().PickupFirewood();
            Destroy(other.gameObject); // Hancurkan kayu yang sudah dipick up
        }
    }

}
