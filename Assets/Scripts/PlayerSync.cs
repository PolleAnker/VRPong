using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerSync : MonoBehaviour
{
    // The objects to sync
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;

    // PhotonView for connectivitiy
    private PhotonView pv;

    // For being able to access rig transform at all times and decide where to move objects
    private Transform headRig;
    private Transform leftHandRig;
    private Transform rightHandRig;


    void Start()
    {
        pv = GetComponent<PhotonView>();
        XRRig rig = FindObjectOfType<XRRig>();
        headRig = rig.transform.Find("Camera Offset/Main Camera");
        leftHandRig = rig.transform.Find("Camera Offset/LeftHand Controller");
        rightHandRig = rig.transform.Find("Camera Offset/RightHand Controller");
    }


    void Update()
    {
        if(pv.IsMine)
        {
            head.gameObject.SetActive(false);
            leftHand.gameObject.SetActive(false);
            rightHand.gameObject.SetActive(false);

            MapPosition(head, headRig);
            MapPosition(leftHand, leftHandRig);
            MapPosition(rightHand, rightHandRig);
        }
    }


    void MapPosition(Transform target, Transform rigTransform)
    {
        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
    }
}
