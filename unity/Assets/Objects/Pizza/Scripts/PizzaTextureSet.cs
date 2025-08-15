using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum PizzaEstado
{
	Inteira,
	Crua,
	ParaAssar,
	Assada
}

/// <summary>
/// Esctruct que armazena a textura da pizza, assim como o nome da textura
/// </summary>
public struct PizzaIngridient
{
    public PizzaIngridient(string textureName)
    {
        this.Texture = Resources.Load<Texture>(textureName);
        this.TextureName = textureName;
    }

    public Texture Texture;
    public string TextureName;
}

/// <summary>
/// Armazena todos os dados e função de utilidade relativas aos ingredientes da pizza
/// </summary>
public static class PizzaTextureSet
{
	/// <summary>
	/// Lista de todas as texturas dispóníveis pra pizza
	/// </summary>
    public static PizzaIngridient[] s_ingridientList =
    {
        new PizzaIngridient("PizzaBase"), //Pizza crua
        new PizzaIngridient("PizzaSauce"), // Com tomate
        new PizzaIngridient("PizzaMuzzarela"), // Mussarela
        new PizzaIngridient("PizzaPepperoni"), // Pepperoni
        new PizzaIngridient("PizzaMuzzarelaBaked"), // Mussarela assada
        new PizzaIngridient("PizzaPepperoniBaked"), // Pepperoni assada
        new PizzaIngridient("PizzaBurned") // Queimada
    };
	/// <summary>
	/// Lista de índices das texturas de pizza que podem ser colocadas no forno para assar
	/// </summary>
    private static readonly int[] s_readyToBakeList = { 2, 3 };

	/// <summary>
	/// Lista de índices das texturas de pizza que estão assadas
	/// </summary>
    private static readonly int[] s_bakedList = { 4, 5 };
	
	/// <summary>
	/// Mapeia a pizza crua (Vector.x) com sua versão assada (Vector.y)
	/// </summary>
	private static readonly Vector2Int[] s_rawToBaked = {
		new Vector2Int(2, 4),
		new Vector2Int(3, 5)
	};

	/// <summary>
	/// Retorna o índice de uma pizza da lista de texturas
	/// </summary>
	/// <param name="nomeTextura">Nome da textura para procurar</param>
	/// <returns>od id da pizza caso esse seja encontrado, -1 do contrário</returns>
    public static int GetId(string nomeTextura)
    {
        int i = 0;
        foreach(PizzaIngridient itrIngrediente in s_ingridientList)
        {
            if (itrIngrediente.TextureName == nomeTextura)
            {
                return i;
            }
            i++;
        }
        return -1;
    }


	public static int GetAssadaPontos(GameObject pizza)
	{
		return GetAssadaPontos(pizza.GetComponent<PizzaMount>().GetIngrediente());
	}
	public static int GetAssadaPontos(PizzaMount pizza)
	{
		return GetAssadaPontos(pizza.GetIngrediente());
	}

	/// <summary>
	/// Retorna o quantidade de pontos que uma certa pizza assada vale (Mussarela 1, pepperoni 2)
	/// </summary>
	/// <param name="idNormal"></param>
	/// <returns></returns>
	public static int GetAssadaPontos(int idNormal)
	{
		if (Array.IndexOf(s_bakedList, idNormal) != -1)
		{
			return idNormal - 3;
		}
		else
		{
			return -1;
		}
	}

	#region Associar pizza assada à pizza crua
    public static int PizzaVersaoAssada(GameObject pizza)
    {
		return PizzaVersaoAssada(pizza.GetComponent<PizzaMount>().GetIngrediente());
    }
	public static int PizzaVersaoAssada(PizzaMount pizza)
	{
		return PizzaVersaoAssada(pizza.GetIngrediente());
	}

	/// <summary>
	/// Devolve a versão assada de uma pizza
	/// </summary>
	/// <param name="pizza">Id da pizza crua</param>
	/// <returns>a versão assada associada ao id da crua, -1 caso a pesquisa falhe</returns>
	public static int PizzaVersaoAssada(int pizza)
	{
		foreach (Vector2Int pair in s_rawToBaked)
		{
			if (pair.x == pizza)
			{
				return pair.y;
			}
		}
		return -1;
	}
	#endregion

	#region Pizza Pronta Para Assar
	public static bool PizzaProntaAssar(GameObject pizza)
	{
		return PizzaProntaAssar(pizza.GetComponent<PizzaMount>().GetIngrediente());
	}
	public static bool PizzaProntaAssar(PizzaMount pizzaMount)
	{
		return PizzaProntaAssar(pizzaMount.GetIngrediente());
	}

	/// <summary>
	/// Verifica se a pizza está pronta para assar
	/// </summary>
	/// <param name="id">Id da pizza para verificar</param>
	/// <returns>True, caso esteja pronta para assar, false do contrário</returns>
	public static bool PizzaProntaAssar(int id)
	{
		return (Array.IndexOf(s_readyToBakeList, id) > -1);
	}
	#endregion

	public static PizzaEstado PizzaGetEstado(GameObject pizza)
	{
		return PizzaGetEstado(pizza.GetComponent<PizzaMount>());
	}

	/// <summary>
	/// Retorna o estado da pizza
	/// </summary>
	/// <param name="pizza">Id da pizza para verificar</param>
	/// <returns>O estado da pizza (Inteira, assada, ou crua)</returns>
	public static PizzaEstado PizzaGetEstado(PizzaMount pizza)
	{
		float pizzaWeight = pizza.GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0);
		if (pizzaWeight < 1f)
		{
			return PizzaEstado.Inteira;
		}
		else if (PizzaProntaAssar(pizza))
		{
			return PizzaEstado.ParaAssar;
		}
		else if (PizzaAssada(pizza))
		{
			return PizzaEstado.Assada;
		}
		else
		{
			return PizzaEstado.Crua;
		}
	}

	#region Pizza Assada
	public static bool PizzaAssada(GameObject pizza)
	{
		return PizzaAssada(pizza.GetComponent<PizzaMount>().GetIngrediente());
	}
	public static bool PizzaAssada(PizzaMount pizzaMount)
	{
		return PizzaAssada(pizzaMount.GetIngrediente());
	}

	/// <summary>
	/// Verifica se uma pizza está assada
	/// </summary>
	/// <param name="id">Id da pizza para verificar</param>
	/// <returns>True caso a pizza esteja assada, false do contrário</returns>
	public static bool PizzaAssada(int id)
	{
		return (Array.IndexOf(s_bakedList, id) > -1);
	}
	#endregion

}
