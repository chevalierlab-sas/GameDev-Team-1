using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class monsterAI : MonoBehaviour
{
    public NavMeshAgent ai;
    public Animator anim;
    public Transform player;
    Vector3 dest;

    void Update()
    {
        dest = player.position;
        ai.destination = dest;
        if (pickupLetter.pagesCollected == 1)
        {
            ai.speed = 15f;
            anim.speed = 1f;
        }
        if (pickupLetter.pagesCollected == 2)
        {
            ai.speed = 8f;
            anim.speed = 1f;
        }
        if (pickupLetter.pagesCollected == 3)
        {
            ai.speed = 9f;
            anim.speed = 1f;
        }
        if (pickupLetter.pagesCollected == 4)
        {
            ai.speed = 12f;
            anim.speed = 1f;
        }
        if (pickupLetter.pagesCollected == 5)
        {
            ai.speed = 14f;
            anim.speed = 1f;
        }
        if (pickupLetter.pagesCollected == 6)
        {
            ai.speed = 16f;
            anim.speed = 1f;
        }
        if (pickupLetter.pagesCollected == 7)
        {
            ai.speed = 17f;
            anim.speed = 1f;
        }
        if (pickupLetter.pagesCollected == 8)
        {
            ai.speed = 18f;
            anim.speed = 1f;
        }
    }
}