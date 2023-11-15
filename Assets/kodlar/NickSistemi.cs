using System.Collections;
using System.Collections.Generic;
using TMPro;
using Photon.Pun;
using UnityEngine;

public class NickSistemi : MonoBehaviourPunCallbacks
{
    public TMP_InputField nick;
    [HideInInspector]public string karakternick;
    public string lobyname;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NickAlýs()
    {
        if(nick.text == null || nick.text == "" || nick.text == "nigga")
        {
        }
        else
        {
            PhotonNetwork.NickName = nick.text; 
        }
    }
}
