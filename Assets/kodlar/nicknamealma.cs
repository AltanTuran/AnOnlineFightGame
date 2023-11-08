using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Windows;

public class nicknamealma : MonoBehaviour
{
    PhotonView pw;
    TextMesh textMesh;
    private void Awake()
    {
        textMesh = GetComponent<TextMesh>();
        pw = GetComponent<PhotonView>();
    }

    void Start()
    {
        if (pw.IsMine)
        {

           

        }
        textMesh.text = GetComponentInParent<PhotonView>().Owner.NickName;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector2(0.1f, 0.1f);
    }
}
