using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Olusanlobi : MonoBehaviour
{
    public GameObject lobi;
    public TMP_Text lobibaslık;
    public TMP_Text[] karakteradları;
    void Start()
    {
        lobibaslık.text = GameObject.Find("NickTaşıyıcı").GetComponent<NickSistemi>().lobyname;

        for (int i = 0; i < karakteradları.Length; i++)
        {
            karakteradları[i].text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            karakteradları[i].text = PhotonNetwork.PlayerList[i].NickName;
        }
    }
}
