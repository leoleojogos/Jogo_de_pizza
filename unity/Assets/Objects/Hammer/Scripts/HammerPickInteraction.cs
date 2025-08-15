using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerPickInteraction : MonoBehaviour, IInteractable
{
	// Rótulo que mostra na tela ao mirar no objeto
	public string _RotuloInteracao => "Pegar Martelo";

	/// <summary>
	/// Executado ao apertar E olhando para a marreta
	/// </summary>
	public void Interagir()
	{
		// Toca o som de pegar item
		GrabItem.TocarSom();

		
		ItemController.Pegaritem(GetComponent<IItem>());
	}
}
