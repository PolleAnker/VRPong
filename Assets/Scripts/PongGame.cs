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
            //Debug.Log("Deleting cup" + i);
            Destroy(cups[i]);
            //Debug.Log("Instantiating cup " + i);
            newCup = Instantiate(cupPrefab, new Vector3(basePositions[i].transform.position.x, basePositions[i].transform.position.y, basePositions[i].transform.position.z), Quaternion.identity, cupParent.transform);
            cups[i] = newCup;
        }
        Debug.Log("Positions reset!");
    }

}
