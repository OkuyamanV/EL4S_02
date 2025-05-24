using UnityEngine;
using UnityEngine.UI;

public class GoalPoint : MonoBehaviour
{
	CircuitManager _circuitManager;
	[SerializeField] bool _target;
	[SerializeField] Output _input;

	Text _text;

	private void Start()
	{
		_circuitManager = FindAnyObjectByType<CircuitManager>();

		//テキスト変更
		_text = GetComponentInChildren<Text>();
		_text.text = (_target) ? "1" : "0";
	}

	public bool Answer()
	{
		return _target == _input.GetOutput();
	}

}
