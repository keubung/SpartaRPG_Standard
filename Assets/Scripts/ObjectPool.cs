using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject findObject = GameObject.Find("bullet");

    public GameObject prefeb;
    List<GameObject> pool = new List<GameObject>();
    public int poolSize = 300;

    public string Key;

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(prefeb);
            pool.Add(bullet);
        }
    }

    public GameObject Get()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (findObject.activeSelf == false)
            {
                pool[i].SetActive(true);
            }
            return pool[i];
        }
        return null;
    }

    public void Release(GameObject obj)
    {
        obj.SetActive(false);
    }
    //Q2-2 진행중, 유니티에서 제대로 생성이 되는지 확인하고 제출
}
