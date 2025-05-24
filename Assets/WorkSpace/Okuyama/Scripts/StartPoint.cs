using UnityEngine;
using UnityEngine.UI;

public class StartPoint : MonoBehaviour
{
	CircuitManager _circuitManager;
	Output _output;
	[SerializeField] bool _startOutput;
	Text _text;

	private void Start()
	{
		_circuitManager = FindAnyObjectByType<CircuitManager>();
		_output = GetComponent<Output>();
		_output.SetOutput(_startOutput);

		//�e�L�X�g�ύX
		_text = GetComponentInChildren<Text>();
		_text.text = (_startOutput) ? "1" : "0";
	}

}
