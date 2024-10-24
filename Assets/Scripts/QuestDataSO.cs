using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="DefaultQuestDataSO", menuName = "SpartaRPGQuest/Quests/Default")]

public class QuestDataSO : ScriptableObject
{
    /*
- `QuestName` - 퀘스트의 이름
- `QuestRequiredLevel` - 퀘스트의 최소레벨
- `QuestNPC` - 퀘스트를 주는 NPC의 id (int)
- `QuestPrerequisites` - 선행 퀘스트의 id들의 리스트
    */
    [Header("Quest Info")]
    public string QuestName;
    public int QuestRequiredLevel;
    public int QuestNPC;
    public List<int> QuestPrerequisites;
}
