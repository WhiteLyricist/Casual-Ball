using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class MoveController : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _acceleration = 1;

    [SerializeField]
    private float time = 2f;

    private float _horSpeed = 0;

    public static Action corridorTrigger;

    private void Start()
    {
        HorSpeed.horSpeed += OnHorSpeed;
        UIController.score += OnScore;
    }

    private void OnTriggerEnter(Collider other)
    {
        corridorTrigger();
    }

    private void OnHorSpeed(float horSpeed)
    {
        _horSpeed = horSpeed;
    }

    void Update()
    {
        gameObject.transform.Translate(_horSpeed * _acceleration * Time.deltaTime, _speed * _acceleration * Time.deltaTime, 0);


    }

    private void OnDestroy()
    {
        HorSpeed.horSpeed -= OnHorSpeed;
        UIController.score -= OnScore;
    }

    private void OnScore(int score) 
    {
        switch (score) 
        {
            case 10:
                StartCoroutine(Acceleration( 1.5f, time));
                break;
            case 25:
                StartCoroutine(Acceleration(2f, time));
                break;
            case 50:
                StartCoroutine(Acceleration(3f, time));
                break;
            case 100:
                StartCoroutine(Acceleration(4f, time));
                break;
        }
    }

    IEnumerator Acceleration(float to, float timer)
    {

        float t = 0.0f;

        while (t < timer)
        {
            t += Time.deltaTime * (1.0f / timer);

            _acceleration = Mathf.Lerp(_acceleration, to, t);

            yield return 0;
        }


    }
}
