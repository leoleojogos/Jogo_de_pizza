using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla o Item do pacote de Mussarela
/// </summary>
public class MuzzarelaItem : MonoBehaviour, IItem
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
    /// Coloca o item na mão do jogador, quando ele for pego
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
    /// Faz com que o item seja solto
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
    /// Verifica um clique na pizza, e seta o ingrediente da pizza de acordo
    /// </summary>
    public void CliquePrincipal()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitInfo, 2, 1 << 6))
        {
            PizzaMount pizzaMount = hitInfo.collider.GetComponent<PizzaMount>();
            if (pizzaMount != null)
            {
                pizzaMount.MontarIngrediente(2);
            }
        }
    }

    public void CliqueSecundario()
    {

    }
}
