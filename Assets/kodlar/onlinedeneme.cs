using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
public class onlinedeneme : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Servere baðlanýldý");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("Lobiye baðlanýldý");
        PhotonNetwork.JoinOrCreateRoom("oda", new RoomOptions { MaxPlayers = 4, IsOpen = true, IsVisible = true }, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Odaya girildi");
        GameObject karakter = PhotonNetwork.Instantiate("character", Vector3.zero, Quaternion.identity, 0, null);
        karakter.GetComponent<PhotonView>().Owner.NickName = GameObject.FindGameObjectWithTag("scenetransfer").GetComponent<nickname>().input;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
