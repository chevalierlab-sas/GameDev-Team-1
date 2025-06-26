using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightMovement : MonoBehaviour
{
    public Animator flashlightAnim;

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                flashlightAnim.ResetTrigger("lari");
                flashlightAnim.SetTrigger("jalan");
            }
            else
            {
                flashlightAnim.ResetTrigger("jalan");
                flashlightAnim.SetTrigger("lari");
            }
        }
    }
}
