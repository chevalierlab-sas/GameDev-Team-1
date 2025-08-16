using UnityEngine;

public class SwitchPuzzle : MonoBehaviour
{
    public ObjectiveManagerLampu objective;   // UI atau log pesan
    public string[] correctOrder;             // Urutan benar (isi 6 tombol)
    public GameObject objectToActivate;       // Objek yang aktif setelah puzzle selesai
    public AudioSource successAudio;          // Suara sukses

    private string[] playerOrder = new string[4]; // Menyimpan input player
    private int currentIndex = 0;                  // Index input player
    private bool puzzleComplete = false;

    public bool ActivateSwitch(string switchName)
    {
        if (puzzleComplete) return true;

        // Simpan input tombol
        playerOrder[currentIndex] = switchName;
        currentIndex++;

        // Jika sudah tekan 6 tombol
        if (currentIndex >= 4)
        {
            CheckCombination(); // Periksa hasil
        }

        return puzzleComplete;
    }

    void CheckCombination()
    {
        bool correct = true;
        for (int i = 0; i < correctOrder.Length; i++)
        {
            if (playerOrder[i] != correctOrder[i])
            {
                correct = false;
                break;
            }
        }

        if (correct)
        {
            PuzzleSolved();
        }
        else
        {
            ShowWarning();
            ResetPlayerInput();
        }
    }

    void PuzzleSolved()
    {
        puzzleComplete = true;

        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }

        if (successAudio != null)
        {
            successAudio.Play();
        }

        if (objective != null)
        {
            objective.SetObjective("Power restored.");
        }

        Debug.Log("Puzzle selesai!");
    }

    void ShowWarning()
    {
        if (objective != null)
        {
            objective.SetObjective("Incorrect code. Try again.");
        }

        Debug.LogWarning("Peringatan: Kombinasi salah!");
    }

    void ResetPlayerInput()
    {
        currentIndex = 0;
        for (int i = 0; i < playerOrder.Length; i++)
        {
            playerOrder[i] = "";
        }
    }
}
