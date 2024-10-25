using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    private Dictionary<string, List<GameObject>> pools = new Dictionary<string, List<GameObject>>();
    
    public GameObject prefab;
    public int poolSize;

    public string key;

    void Start()
    {
        InitializePool(poolSize, key);
    }
    public GameObject Get(string objectType)
    {
        if (pools.ContainsKey(objectType))
        {
            foreach (GameObject obj in pools[objectType])
            {
                if (!obj.activeSelf)
                {
                    obj.SetActive(true);
                    return obj;
                }
            }
        }
        return null;
    }

    public void Release(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(null);
    }

    private void InitializePool(int size, string objectType)
    {
        if (!pools.ContainsKey(objectType))
        {
            pools[objectType] = new List<GameObject>();
        }

        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            obj.name = objectType + "_" + i;
            pools[objectType].Add(obj);
        }
    }
}
