using UnityEngine;

public class ColliderText : MonoBehaviour
{
    public GameObject dialogue;          // UI Text
    public GameObject firstTrigger;      // Collider pertama (untuk menampilkan teks)
    public GameObject secondTrigger;     // Collider kedua (untuk menghilangkan teks)

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == firstTrigger) // Jika menyentuh collider pertama
        {
            dialogue.SetActive(true);        // Tampilkan teks
        }

        if (other.gameObject == secondTrigger) // Jika menyentuh collider kedua
        {
            dialogue.SetActive(false);       // Hilangkan teks
        }
    }
}
