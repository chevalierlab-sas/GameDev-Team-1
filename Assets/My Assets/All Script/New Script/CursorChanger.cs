using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    public Texture2D customCursor;  // drag & drop di inspector
    public Vector2 hotSpot = Vector2.zero; // titik fokus cursor
    public CursorMode cursorMode = CursorMode.Auto;

    void Start()
    {
        Cursor.SetCursor(customCursor, hotSpot, cursorMode);
    }
}
