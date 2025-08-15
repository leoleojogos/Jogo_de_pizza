using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Intera��o para tirar a pizza do forno
/// </summary>
public class OvenTakePizzaInteraction : MonoBehaviour, IInteractable
{
    /// <summary>
    /// R�tulo de intera��o que aparece na UI ao mirar no forno com uma pizza assada dentro
    /// </summary>
    public string _RotuloInteracao => "Pegar Pizza assada";
    public OvenController _OvenController = null;

    /// <summary>
    /// Ativa a intera��o
    /// </summary>
    /// <param name="ovController">Refer�ncia ao script OvenController anexado ao forno</param>
    public void Ativar(OvenController ovController)
    {
        _OvenController = ovController;
		gameObject.layer = LayerMask.NameToLayer("Interactable");
	}

    /// <summary>
    /// Desativa a intera��o
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
            // Desativa a intera��o caso seja
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
