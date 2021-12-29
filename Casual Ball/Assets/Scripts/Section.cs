using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section : MonoBehaviour
{
    [SerializeField]
    private Transform _obstacleRoot;

    private Transform m_transform;

    private void Awake()
    {
        m_transform = transform;
    }

    public void AddObstacle(Transform _transform) 
    {
        _transform.parent = _obstacleRoot;
    }

    public void Move(Vector3 offset) 
    {
        m_transform.position += offset;
        ClearObstacle();
    }

    private void ClearObstacle() 
    {
        foreach (Transform obstacle in _obstacleRoot) 
        {
            obstacle.gameObject.SetActive(false);
        }
    }
}
