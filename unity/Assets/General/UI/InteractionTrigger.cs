using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Controle de UI de interação
/// </summary>
public class InteractionTrigger : MonoBehaviour
{
    /// <summary>
    /// O Game Object com o ícone de interação
    /// </summary>
    private GameObject _keyInfo;

    /// <summary>
    /// O Game Object com o texto de interação
    /// </summary>
    private GameObject _label;

    void Start()
    {
        _keyInfo = transform.GetChild(0).gameObject;
        _label = transform.GetChild(1).gameObject;

        _keyInfo.SetActive(false);
        _label.SetActive(false);
    }

    /// <summary>
    /// Ativa ou desativa uma interação
    /// </summary>
    /// <param name="rotulo">Texto de interação</param>
    /// <param name="ativo">Ativar ou desativar</param>
    public void SetarInteracao(string rotulo, bool ativo)
    {

		_keyInfo.SetActive(ativo);
		_label.SetActive(ativo);

		if (ativo)
        {
            _label.GetComponent<TextMeshProUGUI>().text = rotulo;
        }
    }
}
