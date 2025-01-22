using UnityEngine;
using System.Collections.Generic;
using System.IO;
public class NewState : MonoBehaviour
{
    public static NewState Instance { get; private set; }

    private string jsonFilePath;
    private Dictionary<string, NPCDialogueHistory> dialogueHistories = new Dictionary<string, NPCDialogueHistory>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        jsonFilePath = Path.GetFullPath(Path.Combine(Application.persistentDataPath, "DialogueHistory.json"));

        Debug.Log($"JSON file will be saved at: {jsonFilePath}");

        LoadDialogueHistory();
    }

    public void SaveDialogue(string npcId, string npcText, NPC_State npcEmotion, string playerText, NPC_State playerEmotion)
    {
        if (!dialogueHistories.ContainsKey(npcId))
        {
            dialogueHistories[npcId] = new NPCDialogueHistory { npcId = npcId };
        }

        dialogueHistories[npcId].conversation.Add(new DialogueEntry
        {
            npcText = npcText,
            npcEmotion = npcEmotion.ToString(),
            playerText = playerText,
            playerEmotion = playerEmotion.ToString()
        });

        SaveDialogueHistory();
    }

    public NPCDialogueHistory GetDialogueHistory(string npcId)
    {
        if (dialogueHistories.ContainsKey(npcId))
        {
            return dialogueHistories[npcId];
        }
        return null;
    }

    private void SaveDialogueHistory()
    {
        try
        {
            string json = JsonUtility.ToJson(new NPCDialogueHistoryWrapper(dialogueHistories), true);
            File.WriteAllText(jsonFilePath, json);
            Debug.Log("Dialogue history saved to JSON.");
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Failed to save dialogue history: {ex.Message}");
        }
    }

    private void LoadDialogueHistory()
    {
        if (File.Exists(jsonFilePath))
        {
            try
            {
                string json = File.ReadAllText(jsonFilePath);
                NPCDialogueHistoryWrapper wrapper = JsonUtility.FromJson<NPCDialogueHistoryWrapper>(json);
                dialogueHistories = wrapper.ToDictionary();
                Debug.Log("Dialogue history loaded from JSON.");
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Failed to load dialogue history: {ex.Message}");
            }
        }
    }
}

[System.Serializable]
public class NPCDialogueHistory
{
    public string npcId;
    public List<DialogueEntry> conversation = new List<DialogueEntry>();
}

[System.Serializable]
public class DialogueEntry
{
    public string npcText;
    public string npcEmotion;
    public string playerText;
    public string playerEmotion;
}

[System.Serializable]
public class NPCDialogueHistoryWrapper
{
    public List<NPCDialogueHistory> histories;

    public NPCDialogueHistoryWrapper(Dictionary<string, NPCDialogueHistory> historyDict)
    {
        histories = new List<NPCDialogueHistory>(historyDict.Values);
    }

    public Dictionary<string, NPCDialogueHistory> ToDictionary()
    {
        var dict = new Dictionary<string, NPCDialogueHistory>();
        foreach (var history in histories)
        {
            dict[history.npcId] = history;
        }
        return dict;
    }
}
