using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongGame : MonoBehaviour
{
    public GameObject[] basePositions;
    public GameObject[] cups;
    public GameObject cupPrefab;
    public GameObject cupParent;

    private GameObject newCup;

    public void ResetCupPositions()
    {
        Debug.Log("Resetting cup positions");
        for (int i = 0; i < cups.Length; i++)
        {
            Destroy(cups[i]);   // Destroy all current cups
            // Instantiate a new cup for each one that is destroyed (Quaternion.Euler(-90,0,0) used to be Quaternion.identity)
            newCup = Instantiate(cupPrefab, new Vector3(basePositions[i].transform.position.x, basePositions[i].transform.position.y, basePositions[i].transform.position.z), Quaternion.Euler(-90,0,0), cupParent.transform);
            cups[i] = newCup;   // Keep reference to it in the "cups" list
        }
        Debug.Log("Positions reset!");
    }

}
