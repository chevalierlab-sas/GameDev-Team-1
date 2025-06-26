using UnityEngine;

[ExecuteAlways] // agar berjalan juga di editor
[RequireComponent(typeof(Renderer))]
public class AutoScaleTexture : MonoBehaviour
{
    [Tooltip("Pengulangan tekstur per unit panjang.")]
    public Vector2 tilingFactor = Vector2.one;

    private void Start()
    {
        ApplyTiling();
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        ApplyTiling();
    }
#endif

    void ApplyTiling()
    {
        Renderer rend = GetComponent<Renderer>();
        if (rend == null) return;

        Material mat;

        if (Application.isPlaying)
        {
            // Runtime: instansiasi material agar tidak memengaruhi objek lain
            mat = rend.material;
        }
        else
        {
            // Edit mode: gunakan sharedMaterial untuk hindari leak
            mat = rend.sharedMaterial;
        }

        if (mat == null) return;

        Vector3 scale = transform.localScale;
        Vector2 tiling = new Vector2(scale.x * tilingFactor.x, scale.z * tilingFactor.y);
        mat.mainTextureScale = tiling;
    }
}
