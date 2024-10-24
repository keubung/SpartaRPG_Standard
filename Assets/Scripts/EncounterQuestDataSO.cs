using UnityEngine;

[CreateAssetMenu(fileName = "EncounterQuestDataSO", menuName = "SpartaRPGQuest/Quests/Encounter")]

public class EncounterQuestDataSO : QuestDataSO
{
    [Header("EncounterQuest Info")]
    public int EncounterNPC;
}