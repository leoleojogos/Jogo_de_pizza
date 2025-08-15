using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script colocado no balc�o para pegar nova pizza
/// </summary>
public class NewPizzaInteraction : MonoBehaviour, IInteractable
{
    /// <summary>
    /// R�tulo que aparece na UI ao mirar no balc�o
    /// </summary>
    public string _RotuloInteracao => "Pegar nova pizza";

    /// <summary>
    /// Prefab da pizza para instanciar ao interagir com o balc�o
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
    /// Procura o arquivo do prefab, e coloca na vari�vel _pizzaPrefab
    /// </summary>
    void Start()
    {
        _pizzaPrefab = Resources.Load<GameObject>("Pizza");
	}

    void Update()
    {
        
    }
}
