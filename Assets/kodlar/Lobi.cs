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
    public TMP_Text lobibasl�k;
    public TMP_Text[] karakteradlar�;
    GameObject nicksistemi;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        nicksistemi = GameObject.Find("NickTa��y�c�");
        
    }

    // Update is called once per frame
    void Update()
    {
        karakteradlar�[0].text = nicksistemi.GetComponent<NickSistemi>().karakternick;
    }

    public void OdaAc()
    {

      if (lobiad.text == null || lobiad.text == "")
        {
            
        }
        else
        {
            RoomOptions odaayarlar� = new RoomOptions();
            odaayarlar�.IsVisible = true;
            odaayarlar�.MaxPlayers = 4;
            PhotonNetwork.CreateRoom(lobiad.text, odaayarlar�, TypedLobby.Default);
            odaolusturucu.SetActive(false);
            loading.SetActive(true);
            PhotonNetwork.JoinRoom(lobiad.text);
        }

    }
    public override void OnJoinedRoom()
    {
        loading.SetActive(false);
        lobi.SetActive(true);
        lobibasl�k.text = lobiad.text;
    }

}
