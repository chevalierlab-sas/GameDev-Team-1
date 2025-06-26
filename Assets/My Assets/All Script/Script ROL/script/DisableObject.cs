using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObject : MonoBehaviour
{
    public GameObject Obj,begintext;
    public float activeTime;

    void Update()
    {
        if (Obj.active == true)
        {   
            begintext.SetActive(false);
            StartCoroutine(Disableobj());
        }
    }
    IEnumerator Disableobj()
    {
        yield return new WaitForSeconds(activeTime);
        Obj.SetActive(false);
    }
}