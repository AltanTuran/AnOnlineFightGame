using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneloader : MonoBehaviour
{
    public string sahneadi;
    public Scene sahne;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void SahneYukle()
    {
        if (!string.IsNullOrEmpty(sahneadi))
        {
            SceneManager.LoadScene(sahneadi);
        }
        else
        {
            Debug.LogError("Sahne adý boþ olamaz!");
        }
    }
}
