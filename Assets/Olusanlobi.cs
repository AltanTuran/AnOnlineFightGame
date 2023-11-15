using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Olusanlobi : MonoBehaviour
{
    public GameObject lobi;
    public TMP_Text lobibaslýk;
    public TMP_Text[] karakteradlarý;
    void Start()
    {
        lobibaslýk.text = GameObject.Find("NickTaþýyýcý").GetComponent<NickSistemi>().lobyname;

        for (int i = 0; i < karakteradlarý.Length; i++)
        {
            karakteradlarý[i].text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            karakteradlarý[i].text = PhotonNetwork.PlayerList[i].NickName;
        }
    }
}
