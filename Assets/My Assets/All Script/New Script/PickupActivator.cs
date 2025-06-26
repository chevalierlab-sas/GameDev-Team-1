using UnityEngine;

public class PickupActivator : MonoBehaviour
{
    public Collider colliderToActivate;  // Collider yang akan diaktifkan setelah pick-up
    public GameObject objectToPickup;    // Benda yang akan di-pickup (bisa objek ini sendiri juga)

    void Start()
    {
        // Pastikan collider target dimatikan di awal
        if (colliderToActivate != null)
            colliderToActivate.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Aktifkan collider
            if (colliderToActivate != null)
                colliderToActivate.enabled = true;

            // Hilangkan benda yang dipick-up
            if (objectToPickup != null)
                Destroy(objectToPickup);

            // Atau kalau objek ini sendiri yang dipickup:
            // Destroy(gameObject);
        }
    }
}
