using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class enerjican : MonoBehaviour , IPunObservable
{
    public float can = 100f;
    public float enerji = 100f;
    public Slider Canslider;
    public Slider Enerjislider;
    PhotonView pw;
    void Start()
    {
        pw = GetComponent<PhotonView>();    
    }
    [PunRPC]
    public void SliderUpdate()
    {
        Enerjislider.value = enerji;
        Canslider.value = can;
    }
    // Update is called once per frame
    void Update()
    {
        enerji = Mathf.Min(enerji + 60 * Time.deltaTime, 100);
        pw.RPC("SliderUpdate", RpcTarget.AllBuffered);
        
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
        
        if (stream.IsWriting)
        {
            // Veri gönderme
            
            stream.SendNext(can);
            stream.SendNext(enerji);


        }
        else
        {
            // Veri alma
            
            can = (float)stream.ReceiveNext();
            enerji = (float)stream.ReceiveNext();

        }

        
    }
}
