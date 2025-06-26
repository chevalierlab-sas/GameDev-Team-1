using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JumpscareSequence : MonoBehaviour
{
    public Transform scareTarget;             // Posisi atau objek hantu
    public Transform originalCameraPosition;  // Posisi awal kamera
    public GameObject hantu;                  // Objek hantu yang akan muncul
    public Text dialogText;                  // UI Text untuk dialog
    public string scareMessage = "AAAAAAAAHH!!!"; // Isi dialog jumpscare
    public float scareDuration = 3f;          // Lama jumpscare
    public AudioSource scareAudio;           // (Optional) Suara jumpscare

    private bool hasTriggered = false;
    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
        hantu.SetActive(false);
        dialogText.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;
            StartCoroutine(JumpscareRoutine());
        }
    }

    IEnumerator JumpscareRoutine()
    {
        // Pindahkan kamera ke arah hantu
        Vector3 originalPos = mainCam.transform.position;
        Quaternion originalRot = mainCam.transform.rotation;

        hantu.SetActive(true);

        // Arahkan kamera ke hantu
        mainCam.transform.LookAt(scareTarget);

        // Optional: suara jumpscare
        if (scareAudio != null)
            scareAudio.Play();

        // Tampilkan dialog
        dialogText.text = scareMessage;

        yield return new WaitForSeconds(scareDuration);

        // Reset kamera dan dialog
        mainCam.transform.position = originalPos;
        mainCam.transform.rotation = originalRot;

        dialogText.text = "";
        hantu.SetActive(false);
    }
}
