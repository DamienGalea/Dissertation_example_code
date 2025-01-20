using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText;
    public Button[] responseButtons;
    public DialogueNode currentNode;

    public List<GameObject> npcList = new List<GameObject>();

    [SerializeField]
    private DialogueStateManager stateManager;

    public void Start()
    {
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("NPC");
        npcList.AddRange(enemyObjects);
    }

    public void StartDialogue(DialogueNode startNode, string npcId)
    {
        currentNode = startNode;
        //Debug.Log(currentNode.name);
        if (currentNode.responseOptions == null || currentNode.responseOptions.Length == 0)
        {
            StartCoroutine(EndDialogueAfterDelay());
            return; // Exit to avoid calling DisplayDialogue
        }

        foreach (GameObject obj in npcList)
        {
            NPCDialogueChecker npcScript = obj.GetComponent<NPCDialogueChecker>();
            if (npcScript != null)
            {
                npcScript.React = startNode.npc_mod_React;
            }
        }

        DisplayDialogue(currentNode, npcId);

    }

    public void DisplayDialogue(DialogueNode node, string npcId)
    {


        dialogueText.text = node.dialogueText;



        for (int i = 0; i < responseButtons.Length; i++)
        {
            if (i < node.responseOptions.Length)
            {
                if (node.responseOptions[i] == null)
                {
                    Debug.LogError($"responseOptions[{i}] is null in node: {node.name}");
                    continue; // Skip null entries
                }

                responseButtons[i].gameObject.SetActive(true);
                responseButtons[i].GetComponentInChildren<TMP_Text>().text = node.responseOptions[i].overallText;

                int index = i; // Capture index for button
                responseButtons[i].onClick.RemoveAllListeners();
                responseButtons[i].onClick.AddListener(() => SelectResponse(index, npcId));
            }
            else
            {
                responseButtons[i].gameObject.SetActive(false);
            }
        }
    }

    public void SelectResponse(int index, string npcId)
    {
        DialogueOption selectedOption = currentNode.responseOptions[index];

        stateManager.SaveResponse(npcId, selectedOption.responseText, currentNode.npc_State);
        
        Debug.Log($"Saved response for NPC: {npcId}: {selectedOption.responseText} (Emotion: {selectedOption.playerEmotion})");

        SetButtonsVisibility(false);
        StartCoroutine(ShowResponseThenDialogue(selectedOption, npcId));


    }

    public void EndDialogue()
    {
        Debug.Log("Dialogue ended.");
        dialogueText.text = "";
        foreach (Button button in responseButtons)
        {
            button.gameObject.SetActive(false);
        }
    }


    private IEnumerator ShowResponseThenDialogue(DialogueOption selectedOption, string npcId)
    {
        // Display the player's response text
        dialogueText.text = selectedOption.responseText;


        // Wait for a short delay
        yield return new WaitForSeconds(2f);

        // Select a random NPC node if available
        if (selectedOption.NPCnodes != null && selectedOption.NPCnodes.Length > 0)
        {
            DialogueNode randomNode = selectedOption.NPCnodes[Random.Range(0, selectedOption.NPCnodes.Length)];
            Debug.Log($"Randomly selected NPC Node: {randomNode.name}");


            // Display the NPC's dialogue text
            dialogueText.text = randomNode.dialogueText;

            // Wait for another delay before allowing further interaction
            yield return new WaitForSeconds(2f);

            StartDialogue(randomNode, npcId);
        }

        else
        {
            SetButtonsVisibility(false);
            EndDialogue();
        }
        SetButtonsVisibility(true);
    }

    private IEnumerator EndDialogueAfterDelay()
    {
        // Wait for 2 seconds (adjust the delay as needed)
        yield return new WaitForSeconds(2f);

        // End the dialogue
        EndDialogue();
    }

    private void SetButtonsVisibility(bool isVisible)
    {
        foreach (var button in responseButtons)
        {
            button.gameObject.SetActive(isVisible);
        }
    }
}