using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Intera��o para pegar o jarro de tomate
/// </summary>
public class JarPickInteraction : MonoBehaviour, IInteractable
{
    /// <summary>
    /// R�tulo que aparece na UI ao mirar no jarro de tomate
    /// </summary>
    public string _RotuloInteracao => "Pegar Molho de Tomate";

    /// <summary>
    /// Toca o som apropriado, e pega o item quando uma intera��o acontece
    /// </summary>
    public void Interagir()
    {
        GrabItem.TocarSom();
        ItemController.Pegaritem(GetComponent<IItem>());
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
