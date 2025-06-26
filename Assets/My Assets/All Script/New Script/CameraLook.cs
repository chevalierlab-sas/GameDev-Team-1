using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Transform playerBody;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Ambil sensitivitas dari PlayerPrefs
        float rawSensitivity = PlayerPrefs.GetFloat("sensitivity", 1.0f);
        float sensitivity = Mathf.Pow(rawSensitivity, 10); // Biar lebih terasa efeknya

        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime * 100f;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime * 100f;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
