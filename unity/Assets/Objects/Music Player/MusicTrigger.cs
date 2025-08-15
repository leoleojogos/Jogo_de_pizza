using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{

    public string _Musica;

    void Start()
    {
        if (MusicController.GetMusica() != _Musica || !MusicController._musicaSource.isPlaying)
        {
            MusicController.TocarMusica(_Musica);
        }
    }

    void Update()
    {
        
    }
}
