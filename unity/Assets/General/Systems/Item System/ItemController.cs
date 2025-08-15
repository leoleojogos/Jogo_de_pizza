using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
	/// <summary>
	/// Item equipado pelo jogador
	/// </summary>
	public static IItem _ItemEquipado = null;

	/// <summary>
	/// Inst�ncia �nica do Singleton
	/// </summary>
	private static ItemController s_instancia;

	/// <summary>
	/// Posi��o assumida por um item que � solto pelo jogador
	/// </summary>
	public static Vector3 PosicaoSoltar => GetInstancia().transform.position + GetInstancia().transform.forward;

	private void Start()
	{
		if (s_instancia == null)
		{
			s_instancia = this;
		}
	}

	private void Update()
	{
		ChecarUso();
	}

	/// <summary>
	/// Verifica o clique principal e secund�rio do item equipado
	/// </summary>
	private void ChecarUso()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (_ItemEquipado != null)
			{
				// Executa a fun��o de clique principal do item equipado
				_ItemEquipado.CliquePrincipal();
			}
		}
		else if (Input.GetMouseButton(2))
		{
			if (_ItemEquipado != null)
			{
                // Executa a fun��o de clique secund�rio do item equipado
                _ItemEquipado.CliqueSecundario();
			}
		}

		if (Input.GetKeyDown(KeyCode.Q))
		{
			Pegaritem(null);
		}
	}

	/// <summary>
	/// Retorna a inst�ncia do Singleton
	/// </summary>
	/// <returns></returns>
	public static ItemController GetInstancia()
	{
		return s_instancia;
	}

	/// <summary>
	/// Solta o item equipado e pega um novo
	/// </summary>
	/// <param name="itemParaPegar">Novo item para ser pego</param>
	public static void Pegaritem(IItem itemParaPegar)
	{
		if (_ItemEquipado != null)
		{
			_ItemEquipado.AoSoltar();
		}
		_ItemEquipado = itemParaPegar;
		if (_ItemEquipado != null)
		{
			_ItemEquipado.AoPegar();
		}
	}
}
