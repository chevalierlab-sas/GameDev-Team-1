using UnityEngine;

public class InteractSwitch : MonoBehaviour
{
    public string switchName;
    public SwitchPuzzle puzzleManager;
    public AudioSource switchClickAudio; // Suara klik saklar

    public void Interact()
    {
        if (switchClickAudio != null)
        {
            switchClickAudio.Play(); // Mainkan suara klik
        }

        puzzleManager.ActivateSwitch(switchName);
    }
}
