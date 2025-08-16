using UnityEngine;

public class SwitchTarget : MonoBehaviour
{
    public Light targetLamp;
    public AudioSource switchAudio;   // AudioSource langsung, bukan AudioClip

    public void ToggleLamp()
    {
        if (targetLamp != null)
            targetLamp.enabled = !targetLamp.enabled;

        if (switchAudio != null)
            switchAudio.Play();  // Mainkan audio switch
    }
}
