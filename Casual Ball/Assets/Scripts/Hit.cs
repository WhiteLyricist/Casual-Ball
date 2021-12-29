using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hit : MonoBehaviour
{
    public static Action hit;

    private void OnCollisionEnter(Collision collision)
    {
        hit();
        gameObject.SetActive(false);
    }
}
