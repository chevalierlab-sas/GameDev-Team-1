using UnityEngine;
using UnityEngine.AI;

public class GhostAI : MonoBehaviour
{
    public NavMeshAgent ai;
    public Transform player;

    void Start()
    {
        if (ai == null)
            ai = GetComponent<NavMeshAgent>();

        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        ai.SetDestination(player.position);
    }
}
