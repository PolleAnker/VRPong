using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

public class ObjectSync : XRGrabInteractable
{
    private PhotonView pv;
    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        pv.RequestOwnership();
        Debug.Log("Ownership changed to " + pv);
        base.OnSelectEntered(args);
        Debug.Log("On select entered sucessfully executed");
    }
}
