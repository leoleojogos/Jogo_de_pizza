using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

/// <summary>
/// Componente da interface IItem da marreta
/// </summary>
public class HammerItem : MonoBehaviour, IItem
{

    public float _InteracaoDistancia;
    public LayerMask _InteracaoMask;

    private Animator _animator;
    private Rigidbody _rigidbody;
    private MeshCollider _collider;

	void Start()
	{
		_animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<MeshCollider>();
	}
	void Update()
	{

	}

    /// <summary>
    /// Executa ao clicar com o bot�o esquerdo com o item equipado
    /// </summary>
	public void CliquePrincipal()
    {
        if (!_animator.GetBool("Hitting"))
        {
            // Seta a anima��o de ataque
            _animator.SetBool("Hitting", true);

            // Lan�a um raio que procura pela pizza
            Transform camTrs = Camera.main.transform;
			if (Physics.Raycast(camTrs.position, camTrs.forward, out RaycastHit hitInfo, _InteracaoDistancia, _InteracaoMask))
			{
                PizzaSmash pizza = hitInfo.collider.GetComponent<PizzaSmash>();
                if (pizza != null)
                {
                    // Esmaga a pizza
                    pizza.Interagir();
				}
			}
		}
    }
    public void CliqueSecundario()
    {

    }

    /// <summary>
    /// Equipa o item ao pega-lo
    /// </summary>
    public void AoPegar()
    {
        Transform maoTrs = GameObject.FindGameObjectWithTag("Hand").transform;

        transform.position = maoTrs.position;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        transform.SetParent(maoTrs);
        _animator.enabled = true;
        _rigidbody.isKinematic = true;
        _collider.enabled = false;
        gameObject.layer = LayerMask.NameToLayer("Item");
    }

    /// <summary>
    /// Desequipa o item ao solt�-lo
    /// </summary>
    public void AoSoltar()
    {
		transform.SetParent(null);
        transform.position = ItemController.PosicaoSoltar;

		_animator.enabled = false;
		_rigidbody.isKinematic = false;
        _collider.enabled = true;
		gameObject.layer = LayerMask.NameToLayer("Interactable");
	}
}
