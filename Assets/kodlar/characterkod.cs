using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class characterkod : MonoBehaviour
{
    PhotonView pw;
    void Start()
    {
        pw = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pw.IsMine)
        {
             if (transform.GetComponentInChildren<enerjican>().can <= 0)
        {
                Destroy(GameObject.FindGameObjectWithTag("scenetransfer"));
                PhotonNetwork.LeaveRoom();
                PhotonNetwork.Destroy(this.gameObject);
                PhotonNetwork.Disconnect();
                SceneManager.LoadScene("menü");
        }
        }
        
       
    }
}
