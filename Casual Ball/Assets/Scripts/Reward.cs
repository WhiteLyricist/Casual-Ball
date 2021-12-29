using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Reward : MonoBehaviour
{
    public static Action reward;

    private void OnCollisionEnter(Collision collision)
    {
        reward();
        gameObject.SetActive(false);
    }
}
