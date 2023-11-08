using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;

public class nickname : MonoBehaviour
{
    PhotonView pw;
    public string input;
    private void Awake()
    {
        DontDestroyOnLoad(this.transform);
        pw = GetComponent<PhotonView>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ReadStringInput(string s)
    {
        if (pw.IsMine)
        {
            input = s;
            Debug.Log(input);

        }
        


    }


    public void OyunaGiris()
    {
            
        PhotonNetwork.NickName = input;
            SceneManager.LoadScene("arena");
    }
}
