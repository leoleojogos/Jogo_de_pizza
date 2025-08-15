using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Responsável por controlar todas as interações com o forno (ligar, desligar, abrir, colocar pizza, etc...)
/// </summary>
public class OvenController : MonoBehaviour
{

	public float _TempoDeAssar;
	public float _TempoAlerta;

    private bool _ligado = false;
    private bool _aberto = false;
	private bool _assando = false;

    private bool _temPizza = false;
    private GameObject _pizza = null;
	private Transform _posicaoPizza;

	private GameObject _cookCanvas;
	private RectTransform _progressBarTrs;

	private GameObject _alertCanvas;
	private Image _alertImage;
	private Coroutine _rotinaAlerta;

	private OvenTakePizzaInteraction _takePizzaScript;

	void Start()
	{
		_posicaoPizza = transform.GetChild(0);


		_cookCanvas = transform.GetChild(1).GetChild(0).gameObject;
		_progressBarTrs = _cookCanvas.transform.GetChild(1).GetChild(0).GetComponent<RectTransform>();

		_alertCanvas = transform.GetChild(1).GetChild(1).gameObject;
		_alertImage = _alertCanvas.transform.GetChild(0).GetComponent<Image>();
		_takePizzaScript = GetComponent<OvenTakePizzaInteraction>();
	}

	void Update()
	{

	}
	
	/// <summary>
	/// Coroutine que atualiza o tempo, assim como a barra de timer e o canvas do forno, ativa quando uma pizza está assando
	/// </summary>
	/// <returns></returns>
	IEnumerator Assar()
	{
		#region Ao iniciar Coroutine
		_cookCanvas.SetActive(true);
		float intervalo = _TempoDeAssar / 60f;
		#endregion

		#region Loop da Coroutine
		for (float i = 0; i < _TempoDeAssar; i += intervalo)
		{
			float porcentagem = i / _TempoDeAssar;
			Vector3 novaEscala = new Vector3(porcentagem, 1f, 1f);
			_progressBarTrs.localScale = novaEscala;

			yield return new WaitForSeconds(intervalo);
		}
		#endregion

		#region Ao finalizar Coroutine
		_cookCanvas.SetActive(false);
		_assando = false;

		int pizzaAssadaId = PizzaTextureSet.PizzaVersaoAssada(_pizza);
		_pizza.GetComponent<PizzaMount>().ForcarIngrediente(pizzaAssadaId);

		_takePizzaScript.enabled = true;
		_takePizzaScript.Ativar(this);

		_rotinaAlerta = StartCoroutine(Alerta());
		#endregion
	}

	/// <summary>
	/// Coroutine que atualiza o tempo, assim como o ícone de alerta do forno, ativa quando uma pizza assada está prestes a queimar
	/// </summary>
	/// <returns></returns>
	IEnumerator Alerta()
	{

		#region Ao iniciar Coroutine
		_alertCanvas.SetActive(true);

		float intervalo = _TempoAlerta / 60f;
		#endregion

		#region Loop da Coroutine
		for (float i = 0; i < _TempoAlerta; i += intervalo)
		{
			float brilho = i / _TempoAlerta;
			Color novaCor = new Color(brilho, brilho, brilho);
			_alertImage.color = novaCor;

			yield return new WaitForSeconds(intervalo);
		}
		#endregion

		#region Ao parar Coroutine
		_alertCanvas.SetActive(false);
		_pizza.GetComponent<PizzaMount>().ForcarIngrediente(6);
		#endregion
	}

	/// <summary>
	/// Tenta ligar ou desligar o forno
	/// </summary>
	/// <param name="valor">Verifica se o forno será ligado(true), ou desligado(false)</param>
	/// <returns>True caso ligado/desligado com sucesso, false do contrário</returns>
	public bool Ligar(bool valor)
    {
		// Executa quando tentando ligar
		if (valor)
		{
			// Certifica de que o forno não está ligado ainda
			if (_ligado)
			{
				DialogController.MostrarMsg("Forno já está ligado!");
				return false;
			}

			// Certifica de que o forno esteja fechado
			if (_aberto)
			{
				DialogController.MostrarMsg("Forno deve estar fechado para ligar!");
				return false;
			}

			// Certifica de que o forno tem pizza
			if (!_temPizza)
			{
				DialogController.MostrarMsg("Forno deve ter pizza para ligar!");
				return false;
			}

			// Certifica de que a piza dentro do forno esteja crua
			if (PizzaTextureSet.PizzaAssada(_pizza))
			{
				DialogController.MostrarMsg("Pizza já está assada!");
				return false;
			}

			_ligado = true;
			_assando = true;
			StartCoroutine(Assar());
			return true;
		}
		// Executa quando tentando desligar
		else
		{
			// Verifica se não há pizza assando
			if (_assando)
			{
				DialogController.MostrarMsg("Espere a pizza assar antes de desligar!");
				return false;
			}

			// Desliga a Coroutine de Alerta, no caso desta estar executando
			_ligado = false;
			if (_rotinaAlerta != null)
			{
				_alertCanvas.SetActive(false);
				StopCoroutine(_rotinaAlerta);
			}
			return true;
		}
	}

	/// <summary>
	/// Tenta abrir/fechar o forno
	/// </summary>
	/// <param name="valor">Representa se o forno será abert(true), ou fechado(false)</param>
	/// <returns></returns>
    public bool Abrir(bool valor)
    {
		// Executa quando tentando abrir o forno
        if (valor)
		{
			// Certifica de que o forno está fechado
			if (_aberto)
			{
				DialogController.MostrarMsg("Forno já está aberto!");
				return false;
			}
			// Certifica de que o forno está desligado
			if (_ligado)
			{
				DialogController.MostrarMsg("Forno deve estar desligado para abrir!");
				return false;
			}

			_aberto = true;
			return true;
		}
		// Executa quando fechando o forno
		else
		{
			_aberto = false;
			return true;
		}
    }

	public bool TirarPizza()
	{
		if (_ligado)
		{
			DialogController.MostrarMsg("Forno deve estar desligado para pegar!");
			return false;
		}
		if (!_aberto)
		{
			DialogController.MostrarMsg("Forno deve estar aberto para pegar!");
			return false;
		}
		if (_temPizza == false)
		{
			DialogController.MostrarMsg("Forno está vazio!");
			return false;
		}

		ItemController.Pegaritem(_pizza.GetComponent<IItem>());
		_pizza = null;
		_temPizza = false;
		return true;
	}
	public bool ColocarPizza(GameObject pizza)
	{
		#region Verificações
		if (pizza == null)
		{
			throw new UnityException("O parâmetro piza não pode ser null");
		}

		if (!_aberto)
		{
			DialogController.MostrarMsg("Forno deve estar aberto!");
			return false;
		}
		if (_ligado)
		{
			DialogController.MostrarMsg("Forno deve estar desligado");
			return false;
		}

		PizzaEstado pizzaEstado = PizzaTextureSet.PizzaGetEstado(pizza);
		switch(pizzaEstado)
		{
			case PizzaEstado.Inteira:
			{
				DialogController.MostrarMsg("Ammasse a pizza antes de assar!");
				return false;
			};
			case PizzaEstado.Crua:
			{
				DialogController.MostrarMsg("Coloque os ingredientes na pizza antes de assar!");
				return false;
			};
			case PizzaEstado.Assada:
			{
				DialogController.MostrarMsg("A pizza já está assada!");
				return false;
			};
		}
		#endregion

		#region Lógica
		ItemController.Pegaritem(null);
		_temPizza = true;
		_pizza = pizza;

		_pizza.transform.SetParent(_posicaoPizza);
		_pizza.transform.localPosition = Vector3.zero;
		_pizza.transform.localRotation = Quaternion.Euler(Vector3.zero);

		_pizza.GetComponent<Animator>().enabled = false;
		_pizza.GetComponent<Rigidbody>().isKinematic = true;
		_pizza.GetComponent<MeshCollider>().enabled = false;

		return true;
		#endregion
	}
}
