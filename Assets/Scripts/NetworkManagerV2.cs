using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

[System.Serializable]
public class Room
{
    public string Name;
    public int sceneIndex;
    public int Size;
}


public class NetworkManagerV2 : MonoBehaviourPunCallbacks
{
    public List<Room> Rooms;
    public GameObject roomUI;

    public void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Connecting to server...");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Server!");
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
    } 

    public void InitializeRoom(int roomIndex)
    {
        // Get appropiate room settings
        Room roomSettings = Rooms[roomIndex];
        // Load scene associated with room
        PhotonNetwork.LoadLevel(roomSettings.sceneIndex);
        // Create a room and join it
        RoomOptions roomoptions = new RoomOptions();
        roomoptions.MaxPlayers = (byte)roomSettings.Size;
        roomoptions.IsVisible = true;
        roomoptions.IsOpen = true;
        PhotonNetwork.JoinOrCreateRoom(roomSettings.Name, roomoptions, TypedLobby.Default);
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("Lobby has been joined!");
        roomUI.SetActive(true);
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
