using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsável por montar os ingredientes da pizza
/// </summary>
public class PizzaMount : MonoBehaviour
{

    private Material m_pizzaMat;
    private int m_currentIngridient;

    void Start()
    {
        m_pizzaMat = GetComponent<Renderer>().material;
        m_currentIngridient = 0;
    }

    void Update()
    {
        
    }

    /// <summary>
    /// Retorna o id do ingrediente atual da pizza
    /// </summary>
    /// <returns></returns>
    public int GetIngrediente()
    {
        return m_currentIngridient;
    }

    /// <summary>
    /// Coloca um ingrediente na pizza
    /// </summary>
    /// <param name="id">Id do ingrediente para colocar</param>
    /// <returns>True caso o ingrediente seja colocado, falso caso alguma das condições são seja atendida</returns>
    public bool MontarIngrediente(int id)
    {

        // Confirma que a pizza está amassada
		if (GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0) < 1f)
        {
            DialogController.MostrarMsg("Amasse a pizza primeiro!");
			return false;
        }

        // Confirma que a sequência certa de ingredientes setá sendo seguida
        if (m_currentIngridient + 1 == id)
        {
            int newIngridientId = id;

            // Seta a textura de acordo com o id
            m_pizzaMat.SetTexture("_MainTex", PizzaTextureSet.s_ingridientList[newIngridientId].Texture);
            m_currentIngridient = newIngridientId;
            return true;
        }
        else
        {
			DialogController.MostrarMsg("Ordem de ingredientes Incorreta!");
			return false;
		}
	}

    /// <summary>
    /// Coloca um ingrediente forçadamente na pizza, sem testar a ordem correta dos ids
    /// </summary>
    /// <param name="id">O id do ingrediente para colocar</param>
    /// <returns>True, caso o ingrediente seja colocado, falso caso alguma das condições não sejam atendidas</returns>
    public bool ForcarIngrediente(int id)
    {

        // Se certifica de que a pizza está amassada
		if (GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0) < 1f)
		{
			DialogController.MostrarMsg("Amasse a pizza primeiro!");
			return false;
		}

		int newIngridientId = id;

        // Seta a texutura de acordo
		m_pizzaMat.SetTexture("_MainTex", PizzaTextureSet.s_ingridientList[newIngridientId].Texture);
		m_currentIngridient = newIngridientId;
		return true;
	}
}
