using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Inetera��o de pegar o pepperoni
/// </summary>
public class PepperoniPickInteraction : MonoBehaviour, IInteractable
{
    /// <summary>
    /// R�tulo que aparece na UI ao mirar no pacote de pepperoni
    /// </summary>
    public string _RotuloInteracao => "Pegar Pepperoni";

    /// <summary>
    /// Ao interagir, equipa o item e toca o som apropriado
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
