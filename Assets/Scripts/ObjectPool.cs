using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private Dictionary<string, ObjectPool> pools = new Dictionary<string, ObjectPool>();
    
    public GameObject prefab;
    List<GameObject> pool = new List<GameObject>();
    public int poolSize;

    public string key;

    void Start()
    {
        if (key == "Bullet")
        {
            InitializePool(poolSize, "Bullet");
        }
        else if (key == "Monster")
        {
            InitializePool(poolSize, "Monster");
        }
    }

    public GameObject Get()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeSelf)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        return null;
    }

    public void Release(GameObject obj)
    {
        obj.SetActive(false);
    }

    private void InitializePool(int size, string objectType)
    {
        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            obj.name = objectType + "_" + i;
            pool.Add(obj);
        }
    }
}
