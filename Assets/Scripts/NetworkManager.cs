using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        ConnectToServer();
    }

    void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Connecting to server...");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Server!");
        base.OnConnectedToMaster();
        
        RoomOptions roomoptions = new RoomOptions();
        roomoptions.MaxPlayers = 20;
        roomoptions.IsVisible = true;
        roomoptions.IsOpen = true;
        PhotonNetwork.JoinOrCreateRoom("Room 1", roomoptions, TypedLobby.Default);
    } 

    public override void OnJoinedRoom()
    {
        Debug.Log("Room has been joined!");
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("New player entered room!");
        base.OnPlayerEnteredRoom(newPlayer);
    }
}
