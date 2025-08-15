using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
	/// <summary>
	/// Texto que aparece na tela ao mirar no objeto
	/// </summary>
	public string _RotuloInteracao { get; }
	/// <summary>
	/// Função executada ao interagir com o objeto
	/// </summary>
	public void Interagir();
}
