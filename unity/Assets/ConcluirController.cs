using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConcluirController : MonoBehaviour
{
    public void Voltar()
    {
        BeltDrag.s_moving = new List<Rigidbody>();
        SceneManager.LoadScene("Menu");
    }
}
