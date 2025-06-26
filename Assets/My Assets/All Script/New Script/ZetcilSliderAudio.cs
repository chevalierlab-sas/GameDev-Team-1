using UnityEngine;
using UnityEngine.UI;

public class ZetcilSliderAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider volumeSlider;

    void Start()
    {
        // Atur nilai awal slider ke tengah (0.5)
        volumeSlider.value = 0.2f;

        // Atur volume audio ke tengah (0.5)
        audioSource.volume = 0.2f;

        // Tambahkan listener agar saat slider diubah, volume ikut berubah
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    void ChangeVolume(float value)
    {
        audioSource.volume = value;
    }
}
