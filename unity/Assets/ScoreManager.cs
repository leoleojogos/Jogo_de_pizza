using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    public static GameObject instance;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
