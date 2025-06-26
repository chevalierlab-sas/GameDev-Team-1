using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    public Transform player;               // Referensi ke posisi player
    public float chaseRange = 10f;         // Jarak maksimal untuk mulai mengejar

    private NavMeshAgent agent;
    private float distanceToPlayer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= chaseRange)
        {
            agent.SetDestination(player.position); // Kejar player
        }
        else
        {
            agent.ResetPath(); // Berhenti jika player terlalu jauh
        }
    }

    void OnDrawGizmosSelected()
    {
        // Gambar lingkaran chase range di editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
