using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interação com o pacote de Mussarela
/// </summary>
public class MuzzarelaPickInteraction : MonoBehaviour, IInteractable
{
    /// <summary>
    /// Rótulo que aparece na UI ao passar o mouse sobre o pacote
    /// </summary>
    public string _RotuloInteracao => "Pegar Mussarela";

    /// <summary>
    /// Pega o item ao interagir com ele
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
