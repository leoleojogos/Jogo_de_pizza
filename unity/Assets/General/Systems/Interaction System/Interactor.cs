using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interactor : MonoBehaviour
{

    /// <summary>
    /// Distância máxima de interação
    /// </summary>
    [SerializeField] private float _interacaoDistancia;

    /// <summary>
    /// Layer mask de interação
    /// </summary>
    [SerializeField] private LayerMask _interacaoMask;

    void Start()
    {
        
    }

    void Update()
    {
        // Lança um raio na layer _interacaoMask
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, _interacaoDistancia, _interacaoMask))
        {
            // Procura por um componente que herda da interface IInteractable
            IInteractable interactable = hitInfo.collider.GetComponent<IInteractable>();

            // Verifica se foi possivel pegar o componente
            if (interactable == null)
            {
                Debug.LogWarning("Interface interactable não encontrada");
                return;
            }

            // Rótulo exibido na tela ao mirar em um object com interãção
			string rotulo = interactable._RotuloInteracao;

            // Mostra o rótulo na tela
            InteractionTrigger trigger = GameObject.FindGameObjectWithTag("InteractionUI").GetComponent<InteractionTrigger>();
            trigger.SetarInteracao(rotulo, true);

            // Executa o código de interação do componente caso E seja pressionado
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactable.Interagir();
			}
        }
        else
        {
            // Esconde o rótulo e o ícone de interação da UI caso o raio não tenha atingido nenhum objeto
			InteractionTrigger trigger = GameObject.FindGameObjectWithTag("InteractionUI").GetComponent<InteractionTrigger>();
			trigger.SetarInteracao("", false);
		}
	}
}
