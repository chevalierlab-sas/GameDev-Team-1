using UnityEngine;
using UnityEngine.UI;

public class KayuTriggerActivator : MonoBehaviour
{
    public GameObject[] kayuList;
    public Text pickupText; // Referensi ke UI teks pickup jumlah kayu
    public LatterPickupManager pickupManager; // Referensi ke script pengambil kayu

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Aktifkan semua kayu
            foreach (GameObject kayu in kayuList)
            {
                kayu.SetActive(true);
            }

            // Tampilkan teks jumlah kayu (misalnya: "Kayu bakar: 0/5")
            if (pickupText != null)
            {
                pickupText.gameObject.SetActive(true);
                pickupManager.ForceUIUpdate(); // panggil update teks secara manual
            }

            // Hapus trigger biar tidak bisa aktif dua kali
            Destroy(gameObject);
        }
    }
}
