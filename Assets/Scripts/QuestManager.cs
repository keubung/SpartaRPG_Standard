using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour
{
    private static QuestManager instance;

    public QuestDataSO[] quests;
    public GameObject questPrefab;
    public Transform contentTransform;


    public static QuestManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<QuestManager>();

                if (instance == null)
                {
                    GameObject questManagerObject = new GameObject("QuestManager");
                    instance = questManagerObject.AddComponent<QuestManager>();
                }
            }

            return instance;
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ObjectPool.Instantiate(instance);
        for (int i = 0; i < quests.Length; i++)
        {
            QuestDataSO quest = quests[i];

            GameObject questObject = Instantiate(questPrefab, contentTransform);

            Text questText = questObject.GetComponent<Text>();
            if(questText != null)
            {
                questText.text = $"Quest {i + 1} - {quest.QuestName} (최소 레벨) {quest.QuestRequiredLevel}";
                Debug.Log("퀘스트 출력");
            }
        }
    }

}
