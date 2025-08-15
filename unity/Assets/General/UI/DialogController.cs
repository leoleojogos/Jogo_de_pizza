using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Sistema de controle de alertas que aparecem na tela
/// </summary>
public class DialogController: MonoBehaviour
{
	/// <summary>
	/// GameObject da caixa de diálogo
	/// </summary>
	private static GameObject s_dialogBox;

	/// <summary>
	/// Texto da caixa de diálogo
	/// </summary>
	private static TextMeshProUGUI s_dialogText;

	private void Start()
	{
		if (s_dialogBox != null)
		{
			Destroy(this);
			return;
		}

		s_dialogBox = GameObject.FindGameObjectWithTag("Dialog");
		s_dialogText = s_dialogBox.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
		s_dialogBox.SetActive(false);
	}

	private void Update()
	{
		// Esconde o diálogo ao apertar enter
		if (Input.GetKeyDown(KeyCode.Return))
		{
			if (s_dialogBox.activeInHierarchy)
			{
				MostrarMsg("");
			}
		}
	}

	/// <summary>
	/// Mostra uma mensagem na tela, e pausa o jogo, se não for especificada, esconde a caixa
	/// </summary>
	/// <param name="mensagem">A mensagem para exibir na caixa</param>
	public static void MostrarMsg(string mensagem)
	{

		if (mensagem == "")
		{
			s_dialogBox.SetActive(false);
			Time.timeScale = 1f;
		}
		else
		{
			s_dialogBox.SetActive(true);
			s_dialogText.text = mensagem;
			Time.timeScale = 0f;
		}
	}
}
