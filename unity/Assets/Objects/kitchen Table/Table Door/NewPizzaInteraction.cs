using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script colocado no balcão para pegar nova pizza
/// </summary>
public class NewPizzaInteraction : MonoBehaviour, IInteractable
{
    /// <summary>
    /// Rótulo que aparece na UI ao mirar no balcão
    /// </summary>
    public string _RotuloInteracao => "Pegar nova pizza";

    /// <summary>
    /// Prefab da pizza para instanciar ao interagir com o balcão
    /// </summary>
    private GameObject _pizzaPrefab;

    /// <summary>
    /// Cria e equipa uma nova pizza, e toca o som de pegar item
    /// </summary>
    public void Interagir()
    {
        GameObject newPizza = Instantiate(_pizzaPrefab);
        GrabItem.TocarSom();
        ItemController.Pegaritem(newPizza.GetComponent<IItem>());
	}

    /// <summary>
    /// Procura o arquivo do prefab, e coloca na variável _pizzaPrefab
    /// </summary>
    void Start()
    {
        _pizzaPrefab = Resources.Load<GameObject>("Pizza");
	}

    void Update()
    {
        
    }
}
