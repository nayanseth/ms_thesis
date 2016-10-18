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

    // Update is called once per frame
    void ConnectToServer()
    {

        PhotonNetwork.ConnectUsingSettings(VERSION);

    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionState.ToString());
    }

	public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("Can't Join Random Room....Creating a new Room!");
        PhotonNetwork.CreateRoom(null);
    }

	public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room!");
    }
}
