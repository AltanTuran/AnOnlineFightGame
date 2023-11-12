using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class MaınMenu : MonoBehaviourPunCallbacks
{
    public GameObject loading;
    public GameObject menu;
    public GameObject Nicksistem;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Servere bağlanıldı");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("Lobiye bağlanıldı");
        loading.SetActive(false);
        menu.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLobi()
    {
        if(Nicksistem.GetComponent<NickSistemi>().nick.text == null || Nicksistem.GetComponent<NickSistemi>().nick.text == "nigga")
        {

        }
        else
        {
            SceneManager.LoadScene("Lobi");
        }
        
    }
}
