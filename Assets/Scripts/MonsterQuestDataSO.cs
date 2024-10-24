using UnityEngine;

[CreateAssetMenu(fileName = "MonsterQuestDataSO", menuName = "SpartaRPGQuest/Quests/Monster")]

public class MonsterQuestDataSO : QuestDataSO
{
    [Header("MonsterQuest Info")]
    public int MonsterID;
    public int MonsterCount;
}