using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.Demo.Cockpit;

public class OyunaKatıl : MonoBehaviourPunCallbacks
{
    public TMP_InputField oyunakatıl;
    
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OyunaGiris()
    {
        
        PhotonNetwork.JoinRoom(oyunakatıl.text);
        
    }
    public override void OnJoinedRoom()
    {
        Photon.Realtime.Player[] oyuncular = PhotonNetwork.PlayerList;

        // Her oyuncuyu döngü içinde kontrol et ve bilgilerini görüntüle
        foreach (Photon.Realtime.Player oyuncu in oyuncular)
        {
            Debug.Log("Oyuncu ID: " + oyuncu.ActorNumber + ", Oyuncu Adı: " + oyuncu.NickName);
        }
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        // Odaya katılma başarısız olduğunda
        Debug.LogError("Photon: Odaya katılma başarısız! Hata Kodu: " + returnCode + ", Hata Mesajı: " + message);
    }

}
