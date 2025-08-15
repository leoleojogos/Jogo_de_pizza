using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controla os dados do jogo (tempo, e score)
/// </summary>
public class LevelDataController : MonoBehaviour
{
    /// <summary>
    /// Tempo em segundos restante
    /// </summary>
    public static int _TempoSegundos = 320;

	/// <summary>
	/// Compoenente Text do temporizador
	/// </summary>
	private TextMeshProUGUI _timer;

	/// <summary>
	/// Componente Text do score
	/// </summary>
	private static TextMeshProUGUI _pontos;

	void Start()
	{
		_timer = transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
		_pontos = transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
		StartCoroutine(AtualizaTimer());
    }

	void Update()
	{

	}

	/// <summary>
	/// Coroutine que atualiza o tempo no timer
	/// </summary>
	/// <returns></returns>
	private IEnumerator AtualizaTimer()
	{
		while (true)
		{
			int minutos = (int)Mathf.Floor(_TempoSegundos / 60f);

			int segundos = (int)(_TempoSegundos % 60f);
			string segundosStr = segundos < 10? $"0{segundos}": segundos.ToString();

			string tempoStr = $"{minutos}:{segundosStr}";
			_timer.text = tempoStr;

			_TempoSegundos--;
			if (_TempoSegundos <= -1)
			{
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene("Concluir");
			}

			yield return new WaitForSeconds(1f);
		}
	}

	/// <summary>
	/// Adiciona pontos ao score
	/// </summary>
	/// <param name="quantidade">Quantidade de pontos para adicionar</param>
	public static void AddPontos(int quantidade)
	{
		int pontosAtual = int.Parse(_pontos.text);
		pontosAtual += quantidade;
		ScoreManager.score = pontosAtual;
		_pontos.text = pontosAtual.ToString();
	}
}
