using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItem : MonoBehaviour
{

    public static AudioSource _GrabItem;

    void Start()
    {
        _GrabItem = GetComponent<AudioSource>();
    }

    public static void TocarSom()
    {
        _GrabItem.Play();
    }
}
