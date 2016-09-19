using UnityEngine;
using System.Collections;
using Photon;


public class NetworkManager : PunBehaviour
{

    const string VERSION = "0.0.1";

    // Use this for initialization
    void Start()
    {
        ConnectToServer();
    }

    void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings(VERSION);
    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionState.ToString());
    }

    void OnJoinLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("Can't Join Random Room....Creating a new Room!");
        PhotonNetwork.CreateRoom(null);
    }

    void OnJoinedRoom()
    {
        // Do nothing
    }
}
