using UnityEngine;

public class PickupTriggerActivator : MonoBehaviour
{
    public Collider targetCollider;     // Collider target yang akan diaktifkan sebagai trigger
    public bool onlyTriggerOnce = true;

    private bool hasTriggered = false;

    void Start()
    {
        if (targetCollider != null)
        {
            targetCollider.enabled = false;     // Matikan collider dulu
            targetCollider.isTrigger = false;   // Pastikan belum jadi trigger
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            if (targetCollider != null)
            {
                targetCollider.enabled = true;     // Aktifkan collider
                targetCollider.isTrigger = true;   // Jadikan trigger
                Debug.Log("Collider diaktifkan dan dijadikan trigger.");
            }

            if (onlyTriggerOnce)
                hasTriggered = true;
        }
    }
}
