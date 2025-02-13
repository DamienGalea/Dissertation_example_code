using System.Collections;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class Player : MonoBehaviour
{

    public States_NPC state;
    void Start()
    {
        StartCoroutine(ChangeStateRoutine());
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    private IEnumerator ChangeStateRoutine()
    {
        while (true)
        {
            // Wait for 20 seconds
            yield return new WaitForSeconds(5f);

            // Get the total number of states in the enum
            int enumLength = System.Enum.GetValues(typeof(States_NPC)).Length;
            // Choose a random index between 0 and enumLength - 1
            int randomIndex = Random.Range(0, enumLength);
            // Set the current state to the randomly chosen state
            state = (States_NPC)randomIndex;

            Debug.Log("New state: " + state);
        }
    }
}
