using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Vector3 checkpointPos;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject); // agar tidak hilang saat load ulang
    }

    public void SetCheckpoint(Vector3 pos)
    {
        checkpointPos = pos;
    }

    public Vector3 GetCheckpoint()
    {
        return checkpointPos;
    }
}
