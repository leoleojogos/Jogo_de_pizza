using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Classse respons�vel por gerenciar movimento do jogador, tando de andar, quanto pular
/// </summary>
public class PlayerMovement : MonoBehaviour
{

    #region Vari�veis
    #region P�blicas
    /// <summary>
    /// Rapidez de movimento
    /// </summary>
    public float _Rapidez;

    /// <summary>
    /// For�a do pulo
    /// </summary>
    public float _ForcaPulo;
    #endregion

    #region Privadas
    /// <summary>
    /// Componente Rigid Body atrelado a esse GameObject
    /// </summary>
    private Rigidbody _rigidbody;

    /// <summary>
    /// Dire��o de movimento
    /// </summary>
    private Vector3 _direcao;

    /// <summary>
    /// Velocidae de movimento
    /// </summary>
    private Vector3 _velocidade;

    /// <summary>
    /// Componente Transform da c�mera
    /// </summary>
    private Transform _camTrs;

    private AudioSource _footsteps;

    #endregion
    #endregion

    /// <summary>
    /// Executa quando o GameObject � criado na cena
    /// </summary>
    private void Start()
    {
        // Procura pelo componente RigidBody no objeto, e referencia ele na vari�vel _rigidbody
        _rigidbody = GetComponent<Rigidbody>();

        // Procura pelo componente Transform na c�mera, e referencia ele na vari�vel _camTrs
        _camTrs = Camera.main.transform;

        _footsteps = GetComponent<AudioSource>();
    }

    
    /// <summary>
    /// Executa em todo frame de jogo
    /// </summary>
    private void Update()
    {
        // Captura a dire��o de movimento vindos do input de teclado
        _direcao.x = Input.GetAxisRaw("Horizontal");
        _direcao.z = Input.GetAxisRaw("Vertical");

        // Ajusta a dire��o para que fique relativa a dire��o da c�mera
        _direcao = _direcao.z * _camTrs.forward + _direcao.x * _camTrs.right;
        _direcao.y = 0f;
        _direcao.Normalize();
    }

    /// <summary>
    /// Executa em todo frame de simula��ode f�sica
    /// </summary>
    private void FixedUpdate()
    {
        _velocidade = _direcao * _Rapidez;
        _velocidade.y = _rigidbody.velocity.y;
        _rigidbody.velocity = _velocidade;

        if (_velocidade.sqrMagnitude > 0.1f)
        {
            if (!_footsteps.isPlaying)
            {
                _footsteps.Play();
            }
        }
        else
        {
            if (_footsteps.isPlaying)
            {
                _footsteps.Stop();
            }
        }
    }
}
