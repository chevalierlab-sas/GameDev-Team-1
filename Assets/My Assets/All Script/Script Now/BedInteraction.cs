using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BedInteraction : MonoBehaviour
{
    public GameObject interactionUI;        // UI "Press E"
    public Camera playerCamera;             // Kamera player
    public Camera bedCamera;                // Kamera kasur
    public Animator bedCameraAnimator;      // Animator tidur
    private bool isPlayerNear = false;
    private bool hasInteracted = false;
    public FadeController fadeController;   // Drag script fade ke sini

    void Start()
    {
        interactionUI.SetActive(false);
        bedCamera.gameObject.SetActive(false); // Kamera kasur nonaktif di awal
    }

    void Update()
    {
        if (isPlayerNear && !hasInteracted)
        {
            interactionUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                hasInteracted = true;
                interactionUI.SetActive(false);
                StartCoroutine(PlaySleepAndChangeScene());
            }
        }
        else if (!isPlayerNear)
        {
            interactionUI.SetActive(false);
        }
    }

    IEnumerator PlaySleepAndChangeScene()
    {
        Debug.Log("Mulai efek tidur");

        // Alihkan kamera
        playerCamera.gameObject.SetActive(false);
        bedCamera.gameObject.SetActive(true);

        // Mainkan animasi tidur
        if (bedCameraAnimator != null)
        {
            bedCameraAnimator.SetTrigger("Sleep");
        }

        yield return new WaitForSeconds(1f); // Tunggu animasi tidur sedikit
        fadeController.StartFadeToBlack();

        yield return new WaitForSeconds(2f); // Tunggu efek fade selesai

    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            isPlayerNear = false;
        }
    }
}
