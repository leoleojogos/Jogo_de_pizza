using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Funcionalidade de item da pizza
/// </summary>
public class PizzaItem : MonoBehaviour, IItem
{

	private Animator _animator;
	private Rigidbody _rigidbody;
	private MeshCollider _collider;

	void Awake()
	{
		_animator = GetComponent<Animator>();
		_rigidbody = GetComponent<Rigidbody>();
		_collider = GetComponent<MeshCollider>();
	}
	void Update()
	{

	}

	/// <summary>
	/// Verifica se o jogador clicou em um forno com a pizza equipada
	/// </summary>
	public void CliquePrincipal()
	{
		if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitInfo, 5, 1))
		{
			OvenController ovenController = hitInfo.collider.GetComponent<OvenController>();
			if (ovenController != null)
			{
				ovenController.ColocarPizza(gameObject);
			}
		}
	}

	public void CliqueSecundario()
	{

	}

	/// <summary>
	/// Equipa o item quando esse for pego
	/// </summary>
	public void AoPegar()
	{
		Transform maoTrs = GameObject.FindGameObjectWithTag("Hand").transform;

		transform.position = maoTrs.position;
		transform.rotation = Quaternion.Euler(Vector3.left * 90f);
		transform.SetParent(maoTrs);
		_animator.enabled = false;
		_rigidbody.isKinematic = true;
		_collider.enabled = false;
		gameObject.layer = LayerMask.NameToLayer("Item");
	}

	/// <summary>
	/// Desequipa o item quando esse for solto
	/// </summary>
	public void AoSoltar()
	{
		transform.SetParent(null);
		transform.position = ItemController.PosicaoSoltar;

		_animator.enabled = true;
		_rigidbody.isKinematic = false;
		_collider.enabled = true;
		gameObject.layer = LayerMask.NameToLayer("Interactable");
	}
}
