using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lobi : MonoBehaviourPunCallbacks
{
    public TMP_InputField lobiad;
    public GameObject odaolusturucu;
    public GameObject loading;
    
    GameObject nicksistemi;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        nicksistemi = GameObject.Find("NickTaþýyýcý");

      
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OdaAc()
    {

      if (lobiad.text == null || lobiad.text == "")
        {
            
        }
        else
        {
            RoomOptions odaayarlarý = new RoomOptions();
            odaayarlarý.IsVisible = true;
            odaayarlarý.MaxPlayers = 4;
            PhotonNetwork.CreateRoom(lobiad.text, odaayarlarý, TypedLobby.Default);
            odaolusturucu.SetActive(false);
            loading.SetActive(true);
            PhotonNetwork.JoinRoom(lobiad.text);
            
        }

    }
    public override void OnJoinedRoom()
    {
        loading.SetActive(false);
        nicksistemi.GetComponent<NickSistemi>().lobyname = lobiad.text;

        SceneManager.LoadScene("Lobi");
    }

}
