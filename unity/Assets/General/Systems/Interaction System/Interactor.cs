using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interactor : MonoBehaviour
{

    /// <summary>
    /// Dist�ncia m�xima de intera��o
    /// </summary>
    [SerializeField] private float _interacaoDistancia;

    /// <summary>
    /// Layer mask de intera��o
    /// </summary>
    [SerializeField] private LayerMask _interacaoMask;

    void Start()
    {
        
    }

    void Update()
    {
        // Lan�a um raio na layer _interacaoMask
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, _interacaoDistancia, _interacaoMask))
        {
            // Procura por um componente que herda da interface IInteractable
            IInteractable interactable = hitInfo.collider.GetComponent<IInteractable>();

            // Verifica se foi possivel pegar o componente
            if (interactable == null)
            {
                Debug.LogWarning("Interface interactable n�o encontrada");
                return;
            }

            // R�tulo exibido na tela ao mirar em um object com inter���o
			string rotulo = interactable._RotuloInteracao;

            // Mostra o r�tulo na tela
            InteractionTrigger trigger = GameObject.FindGameObjectWithTag("InteractionUI").GetComponent<InteractionTrigger>();
            trigger.SetarInteracao(rotulo, true);

            // Executa o c�digo de intera��o do componente caso E seja pressionado
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactable.Interagir();
			}
        }
        else
        {
            // Esconde o r�tulo e o �cone de intera��o da UI caso o raio n�o tenha atingido nenhum objeto
			InteractionTrigger trigger = GameObject.FindGameObjectWithTag("InteractionUI").GetComponent<InteractionTrigger>();
			trigger.SetarInteracao("", false);
		}
	}
}
