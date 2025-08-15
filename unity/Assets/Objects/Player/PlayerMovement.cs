using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Classse responsável por gerenciar movimento do jogador, tando de andar, quanto pular
/// </summary>
public class PlayerMovement : MonoBehaviour
{

    #region Variáveis
    #region Públicas
    /// <summary>
    /// Rapidez de movimento
    /// </summary>
    public float _Rapidez;

    /// <summary>
    /// Força do pulo
    /// </summary>
    public float _ForcaPulo;
    #endregion

    #region Privadas
    /// <summary>
    /// Componente Rigid Body atrelado a esse GameObject
    /// </summary>
    private Rigidbody _rigidbody;

    /// <summary>
    /// Direção de movimento
    /// </summary>
    private Vector3 _direcao;

    /// <summary>
    /// Velocidae de movimento
    /// </summary>
    private Vector3 _velocidade;

    /// <summary>
    /// Componente Transform da câmera
    /// </summary>
    private Transform _camTrs;

    private AudioSource _footsteps;

    #endregion
    #endregion

    /// <summary>
    /// Executa quando o GameObject é criado na cena
    /// </summary>
    private void Start()
    {
        // Procura pelo componente RigidBody no objeto, e referencia ele na variável _rigidbody
        _rigidbody = GetComponent<Rigidbody>();

        // Procura pelo componente Transform na câmera, e referencia ele na variável _camTrs
        _camTrs = Camera.main.transform;

        _footsteps = GetComponent<AudioSource>();
    }

    
    /// <summary>
    /// Executa em todo frame de jogo
    /// </summary>
    private void Update()
    {
        // Captura a direção de movimento vindos do input de teclado
        _direcao.x = Input.GetAxisRaw("Horizontal");
        _direcao.z = Input.GetAxisRaw("Vertical");

        // Ajusta a direção para que fique relativa a direção da câmera
        _direcao = _direcao.z * _camTrs.forward + _direcao.x * _camTrs.right;
        _direcao.y = 0f;
        _direcao.Normalize();
    }

    /// <summary>
    /// Executa em todo frame de simulaçãode física
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
