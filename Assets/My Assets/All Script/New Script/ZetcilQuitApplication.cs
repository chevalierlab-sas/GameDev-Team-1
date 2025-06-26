
using UnityEngine;
using UnityEditor;

public class ZetcilQuitApplication : MonoBehaviour
{
    public void QuitApplication()
    {
        // Quit for built application
        Application.Quit();

        // Stop play mode in the Unity editor
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
    }
}

