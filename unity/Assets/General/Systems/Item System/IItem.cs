using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
	/// <summary>
	/// Executado quando o botão esquerdo do mouse é pressionado segurando o item
	/// </summary>
	public void CliquePrincipal();

	/// <summary>
	/// Executado quando o botão direito do mouse é pressionado segurando o item
	/// </summary>
	public void CliqueSecundario();

	/// <summary>
	/// Executado quando o item é pego
	/// </summary>
	public void AoPegar();

	/// <summary>
	/// Executado quando o item é solto
	/// </summary>
	public void AoSoltar();

}
