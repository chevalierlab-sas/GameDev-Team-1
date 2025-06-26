using UnityEngine;

public class DisableObjectOnCollision : MonoBehaviour
{
    public GameObject objectToDisable;  // Objek yang akan dinonaktifkan
    public string playerTag = "Player"; // Tag dari player

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            if (objectToDisable != null)
            {
                objectToDisable.SetActive(false);
            }
        }
    }
}