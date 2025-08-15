using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Intera��o com a porta do forno
/// </summary>
public class OvenDoorinteraction : MonoBehaviour, IInteractable
{
	private Animator _animator;
	private bool _aberto = false;
	private OvenController _ovenController;

	/// <summary>
	/// R�tulo que aparece na UI ao mirar na porta do forno
	/// </summary>
	public string _RotuloInteracao => "Abrir Forno";

	/// <summary>
	/// Executa ao interagir com o forno, tenta tocar a anima��o de abrir, e abri-lo
	/// </summary>
	public void Interagir()
	{
		// Certifica de que a anima��o n�o est� tocando ainda
		float frameNormalizado = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
		if (frameNormalizado > 0f && frameNormalizado < 1f)
		{
			return;
		}

		// Certifica de que o forno pode ser aberto
		if (_ovenController.Abrir(!_aberto)) {
			// Seta as anima��es
			_aberto = !_aberto;
			_animator.SetFloat("AnimSpd", 1f);
			_animator.SetBool("Aberto", _aberto);
		}
	}

	void Start()
	{
		_animator = GetComponent<Animator>();
		_ovenController = transform.parent.GetComponent<OvenController>();
	}

}
