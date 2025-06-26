using UnityEngine;

public class ColliderTriggerOther : MonoBehaviour
{
    public Collider targetCollider;   // Collider lain yang ingin di-trigger
    public bool setAsTrigger = true;  // Apakah ingin menjadikan target sebagai trigger
    public bool enableIfDisabled = true; // Apakah ingin mengaktifkan collider jika awalnya nonaktif

    private bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            if (targetCollider != null)
            {
                if (enableIfDisabled)
                    targetCollider.enabled = true;

                if (setAsTrigger)
                    targetCollider.isTrigger = true;

                Debug.Log("Collider lain telah diaktifkan dan dijadikan trigger.");
            }

            hasTriggered = true;
        }
    }
}
