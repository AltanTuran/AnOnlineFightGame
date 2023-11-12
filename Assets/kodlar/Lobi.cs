using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.UI;

public class Lobi : MonoBehaviourPunCallbacks
{
    public TMP_InputField lobiad;
    public GameObject odaolusturucu;
    public GameObject loading;
    public GameObject lobi;
    public TMP_Text lobibaslık;
    public TMP_Text[] karakteradları;
    GameObject nicksistemi;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        nicksistemi = GameObject.Find("NickTaşıyıcı");
        
    }

    // Update is called once per frame
    void Update()
    {
        karakteradları[0].text = nicksistemi.GetComponent<NickSistemi>().karakternick;
    }

    public void OdaAc()
    {

      if (lobiad.text == null || lobiad.text == "")
        {
            
        }
        else
        {
            RoomOptions odaayarları = new RoomOptions();
            odaayarları.IsVisible = true;
            odaayarları.MaxPlayers = 4;
            PhotonNetwork.CreateRoom(lobiad.text, odaayarları, TypedLobby.Default);
            odaolusturucu.SetActive(false);
            loading.SetActive(true);
            PhotonNetwork.JoinRoom(lobiad.text);
        }

    }
    public override void OnJoinedRoom()
    {
        loading.SetActive(false);
        lobi.SetActive(true);
        lobibaslık.text = lobiad.text;
    }

}
