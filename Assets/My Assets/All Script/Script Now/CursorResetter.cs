using UnityEngine;

public class CursorResetter : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("Cursor diaktifkan kembali");
    }
}
