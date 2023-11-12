using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NickSistemi : MonoBehaviour
{
    public TMP_InputField nick;
    [HideInInspector]public string karakternick;

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
            karakternick = nick.text;
        }
    }
}
