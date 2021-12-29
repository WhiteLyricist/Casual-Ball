using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EObstacleType { Reward, Hit }

public class CorridorManager : MonoBehaviour
{
    [SerializeField]
    List<Section> sections;

    [SerializeField]
    GameObject floor;

    [SerializeField]
    int sectionsIndex = 1;

    [SerializeField]
    private int _moveIndex;


    private Vector3 m_offset;

    [SerializeField]
    private int _minHitCount = 0;
    [SerializeField]
    private int _maxHitCount = 3;
    [SerializeField]
    private int _minRewardCount = 0;
    [SerializeField]
    private int _maxRewardCount = 3;

    [SerializeField]
    private PoolManager _poolManager;

    private Transform m_transform;

    private Vector3 m_lossyScale;

    void Start()
    {
        MoveController.corridorTrigger += OnCorridorTrigger;
        m_lossyScale = floor.transform.lossyScale;
        m_offset = new Vector3(0, m_lossyScale.y * sections.Count, 0);
    }

    void OnCorridorTrigger() 
    {
        if (sectionsIndex - 1 < 0)
        {
            _moveIndex = sections.Count - 1;
        }
        else _moveIndex = sectionsIndex - 1;

        sections[_moveIndex].Move(m_offset);

        m_transform = sections[_moveIndex].transform;

        GenerateObstacle(_minHitCount, _maxHitCount, EObstacleType.Hit);
        GenerateObstacle(_minRewardCount, _maxRewardCount, EObstacleType.Reward);

        if (sectionsIndex == sections.Count - 1)
        {
            sectionsIndex = 0;
        }
        else sectionsIndex++;

    }

    private void GenerateObstacle(int min, int max, EObstacleType obstacles) 
    {
        GameObject go;

        for (int i = 0; i <= Random.Range(min, max); i++)
        {
            switch (obstacles) 
            {
                case EObstacleType.Hit : 
                    go = _poolManager.hitObjectPool.GetFromPool();
                    break;

                case EObstacleType.Reward :
                    go = _poolManager.rewardObjectPool.GetFromPool();
                    break;

                default: 
                    return;
            }

            sections[_moveIndex].AddObstacle(go.transform);

            var localPosition = m_transform.localPosition;

            var x = (int)Random.Range(-m_lossyScale.x / 2 + 1, m_lossyScale.x / 2 - 1);
            var y = (int)Random.Range(localPosition.y - m_lossyScale.y / 2, localPosition.y + m_lossyScale.y / 2);

            go.transform.position = new Vector3(x, y, go.transform.position.z);
        }
    }

    private void OnDestroy()
    {
        MoveController.corridorTrigger -= OnCorridorTrigger;
    }
}
