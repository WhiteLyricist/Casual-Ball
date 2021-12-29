using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIController : MonoBehaviour
{

    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _lifelText;

    private int _score = 0;
    private int _life = 3;

    public static Action<int> score;
    public static Action<int> life;

    void Start()
    {
        Reward.reward += OnReward;
        Hit.hit += OnHit;

        _scoreText.text ="Ваш счёт: " + _score.ToString();
        _lifelText.text ="Количество жизней: " + _life.ToString();
    }

    private void OnReward() 
    {
        _score++;
        _scoreText.text = "Ваш счёт: " + _score.ToString();
        score(_score);
    }

    private void OnHit() 
    {
        _life--;
        _lifelText.text = "Количество жизней: " + _life.ToString();
        life(_life);
    }

    private void OnDestroy()
    {
        Reward.reward -= OnReward;
        Hit.hit -= OnHit;
    }

}
