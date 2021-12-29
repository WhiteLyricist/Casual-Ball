using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject _panel;

    void Start()
    {
        UIController.life += OnLife;
    }

    private void OnLife(int life) 
    {
        if (life <= 0) 
        {
            _panel.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }  
    }

    public void Restart() 
    {
        SceneManager.LoadScene("Game");
    }

    private void OnDestroy()
    {
        UIController.life -= OnLife;
    }
}
