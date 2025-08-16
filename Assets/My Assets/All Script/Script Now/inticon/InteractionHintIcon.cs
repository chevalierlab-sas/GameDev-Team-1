using UnityEngine;

public class InteractionHintIcon : MonoBehaviour
{
    public GameObject iconPrefab;
    private GameObject iconInstance;
    private bool isPlayerNear = false;

    void Start()
    {
        // Spawn ikon tapi nonaktif
        iconInstance = Instantiate(iconPrefab, transform.position + Vector3.up * 1.5f, Quaternion.identity);
        iconInstance.transform.SetParent(transform); // supaya ikut gerakan objek
        iconInstance.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            iconInstance.SetActive(true);
            isPlayerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            iconInstance.SetActive(false);
            isPlayerNear = false;
        }
    }

    void OnDisable()
    {
        if (iconInstance != null)
            iconInstance.SetActive(false);
    }

}
