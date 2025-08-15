using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controle de item do pacote de peppeeroni
/// </summary>
public class PepperoniItem : MonoBehaviour, IItem
{
    private Rigidbody _rigidbody;
    private BoxCollider _collider;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<BoxCollider>();
    }

    void Update()
    {

    }

    /// <summary>
    /// Coloca que o pepperoni na mão do jogador ao ser equipado
    /// </summary>
    public void AoPegar()
    {
        Transform maoTrs = GameObject.FindGameObjectWithTag("Hand").transform;

        transform.position = maoTrs.position;
        transform.rotation = Quaternion.Euler(Vector3.left * 90f);
        transform.SetParent(maoTrs);
        _rigidbody.isKinematic = true;
        _collider.enabled = false;
        gameObject.layer = LayerMask.NameToLayer("Item");
    }

    /// <summary>
    /// Solta o pepperoni ao desequipar
    /// </summary>
    public void AoSoltar()
    {
        transform.SetParent(null);
        transform.position = ItemController.PosicaoSoltar;

        _rigidbody.isKinematic = false;
        _collider.enabled = true;
        gameObject.layer = LayerMask.NameToLayer("Interactable");
    }

    /// <summary>
    /// Verifica se o joador está mirando a pizza e seta o ingrediente de acordo
    /// </summary>
    public void CliquePrincipal()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitInfo, 2, 1 << 6))
        {
            PizzaMount pizzaMount = hitInfo.collider.GetComponent<PizzaMount>();
            if (pizzaMount != null)
            {
                pizzaMount.MontarIngrediente(3);
            }
        }
    }

    public void CliqueSecundario()
    {

    }
}
