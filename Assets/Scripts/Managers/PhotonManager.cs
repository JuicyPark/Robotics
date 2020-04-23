using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using System;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    public Action<bool> Ready;

    public void Connect() => PhotonNetwork.ConnectUsingSettings();
    public void Disconnect() => PhotonNetwork.Disconnect();
    public void JoinLobby() => PhotonNetwork.JoinLobby();

    public override void OnConnectedToMaster()
    {
        JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("로비접속완료");
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        // DISCONNECT 
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("방 참가");
        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            SceneManager.LoadScene(1);
        }
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            SceneManager.LoadScene(1);
        }
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("방 생성");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateRoom();
    }

    public void ClickStartButton()
    {
        if (PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinRandomRoom();
            Ready?.Invoke(true);
        }
        else if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
            Ready?.Invoke(false);
        }
    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
    }

    void Start()
    {
        Connect();
    }

    void CreateRoom() => PhotonNetwork.CreateRoom("USERNAME", new RoomOptions { MaxPlayers = 2 }); // TEMP
}