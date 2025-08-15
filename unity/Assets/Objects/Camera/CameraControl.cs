using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

/// <summary>
/// Classe respons�vel por gerenciar movimento de c�mera
/// </summary>
public class CameraControl : MonoBehaviour
{

	#region Vari�veis
	#region P�blicas
	public float _SensibilidadeX;
	public float _SensibilidadeY;
	#endregion
	#region Privadas
	private Vector3 _velocidadeEuler;
	private Transform _playerRoot;
	#endregion
	#endregion

	/// <summary>
	/// Executa quando o GameObject � criado na cena
	/// </summary>
	private void Start()
    {
		// Prende o cursor no centro da tela
        Cursor.lockState = CursorLockMode.Locked;
		// Faz o cursor ficar invis�vel
		Cursor.visible = false;

		_playerRoot = transform.parent.GetChild(1);
    }

	/// <summary>
	/// Executa em todo frame de jogo
	/// </summary>
	private void Update()
    {
		_velocidadeEuler.x -= Input.GetAxis("Mouse Y") * _SensibilidadeY * Time.deltaTime;
		_velocidadeEuler.y += Input.GetAxis("Mouse X") * _SensibilidadeX * Time.deltaTime;

		transform.rotation = Quaternion.Euler(_velocidadeEuler);
		_playerRoot.rotation = Quaternion.Euler(_velocidadeEuler);
    }
}
