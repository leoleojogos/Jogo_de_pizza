using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interação para tirar a pizza do forno
/// </summary>
public class OvenTakePizzaInteraction : MonoBehaviour, IInteractable
{
    /// <summary>
    /// Rótulo de interação que aparece na UI ao mirar no forno com uma pizza assada dentro
    /// </summary>
    public string _RotuloInteracao => "Pegar Pizza assada";
    public OvenController _OvenController = null;

    /// <summary>
    /// Ativa a interação
    /// </summary>
    /// <param name="ovController">Referência ao script OvenController anexado ao forno</param>
    public void Ativar(OvenController ovController)
    {
        _OvenController = ovController;
		gameObject.layer = LayerMask.NameToLayer("Interactable");
	}

    /// <summary>
    /// Desativa a interação
    /// </summary>
    public void Desativar()
    {
        _OvenController = null;
        gameObject.layer = LayerMask.NameToLayer("Default");
    }

    /// <summary>
    /// Tira a piza do forno
    /// </summary>
    public void Interagir()
    {
        // Verifica se a pizza pode ser retirada
        if (_OvenController.TirarPizza())
        {
            // Desativa a interação caso seja
			Desativar();
		}
	}

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
