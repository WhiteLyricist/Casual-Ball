using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PoolData 
{
    [SerializeField]
    List<GameObject> pooledObjects;
    
    [SerializeField]
    GameObject objectToPool;
    
    [SerializeField]
    int amountToPool;

    public void Init() 
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < amountToPool; i++) 
        {
            AddToPool();
        }
    }

    public GameObject GetFromPool() 
    {
        foreach (GameObject go in pooledObjects) 
        {
            if (!go.activeInHierarchy) 
            {
                go.SetActive(true);

                return go;
            }
        }

        return AddToPool(true); ;
    }

    private GameObject AddToPool(bool newObject = false) 
    {
        var go = GameObject.Instantiate(objectToPool);

        go.SetActive(newObject);

        pooledObjects.Add(go);

        return go;
    }
}

public class PoolManager : MonoBehaviour
{
    public PoolData rewardObjectPool;
    public PoolData hitObjectPool;

    void Start()
    {
        rewardObjectPool.Init();
        hitObjectPool.Init();
    }

    void Update()
    {
        
    }
}
