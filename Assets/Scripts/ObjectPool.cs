using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    private Dictionary<string, List<GameObject>> pools = new Dictionary<string, List<GameObject>>();

    public GameObject bulletPrefab;
    public GameObject monsterPrefab;
    public int bulletPoolSize;
    public int monsterPoolSize;
    string bulletKey = "Bullet";
    string monsterKey = "Monster";

    void Start()
    {
        InitializePool(bulletPoolSize, bulletKey, bulletPrefab);
        InitializePool(monsterPoolSize, monsterKey, monsterPrefab);
    }
    public GameObject Get(string objectType)
    {
        if (pools.ContainsKey(objectType))
        {
            foreach (GameObject obj in pools[objectType])
            {
                if (!obj.activeInHierarchy)
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

    private void InitializePool(int size, string objectType, GameObject prefab)
    {
        if (!pools.ContainsKey(objectType))
        {
            pools[objectType] = new List<GameObject>();
        }

        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            obj.name = objectType + "_" + (i + 1);
            pools[objectType].Add(obj);
        }
    }
}
