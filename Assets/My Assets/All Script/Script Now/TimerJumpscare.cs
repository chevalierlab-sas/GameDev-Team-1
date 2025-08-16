using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerJumpscare : MonoBehaviour
{
    [Header("Timer Settings")]
    public float timerDuration = 20f;
    private float timer;
    private bool timerActive = false;
    private bool hasTriggered = false;

    [Header("UI Timer")]
    public Text timerText;

    [Header("Jumpscare & Scene")]
    public GameObject jumpscareObject;
    public string nextSceneName = "DeathScene";

    [Header("Fade Settings")]
    public CanvasGroup blackFadeCanvasGroup;
    public float fadeDuration = 2f;

    [Header("MainCamera")]
    public string maincameraTag = "MainCamera";

    private void Start()
    {
        if (jumpscareObject != null)
            jumpscareObject.SetActive(false);
    }

    private void Update()
    {
        if (!timerActive || hasTriggered) return;

        timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, 0f, timerDuration);

        if (timerText != null)
            UpdateTimerUI(timer);

        if (timer <= 0f)
        {
            timerActive = false;
            hasTriggered = true;
            StartCoroutine(TriggerJumpscare());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(maincameraTag) && !timerActive && !hasTriggered)
        {
            StartTimer();
        }
    }

    private void StartTimer()
    {
        timer = timerDuration;
        timerActive = true;
        Debug.Log("Timer dimulai: " + timerDuration + " detik");
    }

    private void UpdateTimerUI(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private IEnumerator TriggerJumpscare()
    {
        Debug.Log("Timer habis! Jumpscare muncul.");

        if (jumpscareObject != null)
            jumpscareObject.SetActive(true);

        // Tunggu durasi animasi (default fallback: 3 detik)
        float animDuration = 3f;
        Animator anim = jumpscareObject.GetComponent<Animator>();
        if (anim != null)
        {
            AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);
            animDuration = state.length > 0 ? state.length : animDuration;
        }

        yield return new WaitForSeconds(animDuration);

        // Fade out
        yield return StartCoroutine(FadeOut());

        // Pastikan cursor muncul kembali jika scene berikutnya menggunakan UI
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Pindah ke scene baru (Single mode = hanya 1 scene aktif)
        Debug.Log("Pindah ke scene: " + nextSceneName);
        SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;

        if (blackFadeCanvasGroup != null)
        {
            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                blackFadeCanvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
                yield return null;
            }
        }
    }
}
