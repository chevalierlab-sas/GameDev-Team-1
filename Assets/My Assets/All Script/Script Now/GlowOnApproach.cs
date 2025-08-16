using UnityEngine;

public class GlowOnApproach : MonoBehaviour
{
    public Renderer objectRenderer; // drag objek mesh di Inspector
    public Color glowColor = Color.cyan;

    private Material matInstance;
    private bool glowing = false;

    void Start()
    {
        // Buat instance material supaya tidak mempengaruhi semua objek
        matInstance = objectRenderer.material;
        DisableGlow();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnableGlow();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DisableGlow();
        }
    }

    void EnableGlow()
    {
        matInstance.EnableKeyword("_EMISSION");
        matInstance.SetColor("_EmissionColor", glowColor);
        glowing = true;
    }

    void DisableGlow()
    {
        matInstance.DisableKeyword("_EMISSION");
        matInstance.SetColor("_EmissionColor", Color.black);
        glowing = false;
    }
}
