using UnityEngine;

public class DisableAfterTime : MonoBehaviour
{
    public float duration;

    void Start()
    {
        Invoke("DisableObject", duration);
    }

    void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
