using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interação responsável por pegar a pizza
/// </summary>
public class PizzaPickInteraction : MonoBehaviour, IInteractable
{
    /// <summary>
    /// Rótulo de interação que aparece na UI ao mirar na pizza
    /// </summary>
    public string _RotuloInteracao => "Pegar Pizza";

    /// <summary>
    /// Pega a pizza e toca o som apropriado ao interagir com a pizza
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
