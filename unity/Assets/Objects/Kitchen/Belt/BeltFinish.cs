using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Adiciona score ao colocar pizza na esteira
/// </summary>
public class BeltFinish : MonoBehaviour
{

	private void Start()
	{
		
	}

	private void Update()
	{

	}

	/// <summary>
	/// verifica se o objecto é uma pizza, e se está assada
	/// </summary>
	/// <param name="other"></param>
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.TryGetComponent(out PizzaItem pizzaItem))
		{
			if (PizzaTextureSet.PizzaAssada(other.gameObject))
			{
				int multiplicador = PizzaTextureSet.GetAssadaPontos(other.gameObject);
				LevelDataController.AddPontos(multiplicador * Random.Range(1, 5));
				return;
			}
		}

		DialogController.MostrarMsg("Envie uma pizza assada!");
		other.gameObject.transform.position = ItemRespawn.s_pontoRespawn;
	}
}
