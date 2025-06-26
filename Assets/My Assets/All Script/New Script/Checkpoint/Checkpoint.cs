using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Simpan posisi checkpoint ke GameManager
            GameManager.instance.SetCheckpoint(transform.position);
        }
    }
}
