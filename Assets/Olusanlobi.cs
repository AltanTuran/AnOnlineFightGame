using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Olusanlobi : MonoBehaviour
{
    public GameObject lobi;
    public TMP_Text lobibasl�k;
    public TMP_Text[] karakteradlar�;
    void Start()
    {
        lobibasl�k.text = GameObject.Find("NickTa��y�c�").GetComponent<NickSistemi>().lobyname;

        for (int i = 0; i < karakteradlar�.Length; i++)
        {
            karakteradlar�[i].text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            karakteradlar�[i].text = PhotonNetwork.PlayerList[i].NickName;
        }
    }
}
