using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
	/// <summary>
	/// Executado quando o bot�o esquerdo do mouse � pressionado segurando o item
	/// </summary>
	public void CliquePrincipal();

	/// <summary>
	/// Executado quando o bot�o direito do mouse � pressionado segurando o item
	/// </summary>
	public void CliqueSecundario();

	/// <summary>
	/// Executado quando o item � pego
	/// </summary>
	public void AoPegar();

	/// <summary>
	/// Executado quando o item � solto
	/// </summary>
	public void AoSoltar();

}
