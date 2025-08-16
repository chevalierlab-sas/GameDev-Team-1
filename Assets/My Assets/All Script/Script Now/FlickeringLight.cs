using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public Light lampu;
    public float minTime = 0.05f;   // Waktu minimum antar flicker
    public float maxTime = 0.3f;    // Waktu maksimum antar flicker
    public bool isFlickering = true;

    private void Start()
    {
        if (lampu == null)
            lampu = GetComponent<Light>();

        StartCoroutine(FlickerRoutine());
    }

    private System.Collections.IEnumerator FlickerRoutine()
    {
        while (isFlickering)
        {
            float waitTime = Random.Range(minTime, maxTime);
            lampu.enabled = !lampu.enabled;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
