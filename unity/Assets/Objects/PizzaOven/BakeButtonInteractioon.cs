using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Intera��o de ligar o forno ao apertar no bot�o
/// </summary>
public class BakeButtonInteractioon : MonoBehaviour, IInteractable
{
	private Animator _animator;
	private bool _ligado = false;
	private OvenController _ovenController;

	public string _RotuloInteracao => "Ligar Forno";

	/// <summary>
	/// Executa ao interagir com o bot�o de ligar do forno
	/// </summary>
	public void Interagir()
	{
		// Se certifica de que a anima��o n�o est� tocando atualmente
		float frameNormalizado = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
		if (frameNormalizado > 0f && frameNormalizado < 1f)
		{
			return;
		}

		// Liga o forno, e seta a anima��o caso a liga��o tenha sucedido
		if (_ovenController.Ligar(!_ligado))
		{
			_ligado = !_ligado;
			_animator.SetFloat("AnimSpd", 1f);
			_animator.SetBool("Ligado", _ligado);
		}
	}

	void Start()
	{
		_animator = GetComponent<Animator>();
		_ovenController = transform.parent.parent.GetComponent<OvenController>();
	}
}
