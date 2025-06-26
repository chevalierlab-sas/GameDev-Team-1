using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public void Respawn()
    {
        Vector3 lastCheckpoint = GameManager.instance.GetCheckpoint();
        transform.position = lastCheckpoint;
    }
}
