using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Item do Jarro de tomate
/// </summary>
public class JarItem : MonoBehaviour, IItem
{

    private Rigidbody _rigidbody;
    private MeshCollider _collider;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<MeshCollider>();
    }
    void Update()
    {

    }

    /// <summary>
    /// Coloca molho de tomate ao clicar na pizza
    /// </summary>
    public void CliquePrincipal()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitInfo, 2, 1 << 6))
        {
            PizzaMount pizzaMount = hitInfo.collider.GetComponent<PizzaMount>();
            if (pizzaMount != null)
            {
                pizzaMount.MontarIngrediente(1);
            }
        }
    }

    public void CliqueSecundario()
    {

    }

    /// <summary>
    /// Executa ao pegar o jarro de tomate
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
    /// Executa ao soltar o jarro de tomate
    /// </summary>
    public void AoSoltar()
    {
        transform.SetParent(null);
        transform.position = ItemController.PosicaoSoltar;

        _rigidbody.isKinematic = false;
        _collider.enabled = true;
        gameObject.layer = LayerMask.NameToLayer("Interactable");
    }

}
