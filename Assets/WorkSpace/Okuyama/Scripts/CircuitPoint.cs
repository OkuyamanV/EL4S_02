using UnityEngine;
using UnityEngine.UI;

public class CircuitPoint : MonoBehaviour
{
	CircuitManager _circuitManager;
	Output _output;
	[SerializeField] Output[] _input = new Output[2];
	[SerializeField] CircuitManager.CircuitState[] _selectState = new CircuitManager.CircuitState[1];
	int _state;

	Button _button;

	private void Start()
	{
		_circuitManager = FindAnyObjectByType<CircuitManager>();
		_output = GetComponent<Output>();
		Debug.Log(_circuitManager.name);
		_button = GetComponent<Button>();

		//ボタンクリック時の処理追加
		_button.onClick.AddListener(OnButtonClick);

		_state = 0;
	}

	//他のoutputの変更にあわせて
	public void Change()
	{
		//出力内容更新
		_output.SetOutput(_circuitManager.Circuit(_selectState[_state], _input[0].GetOutput(), _input[1].GetOutput()));
	}

	//ボタンクリック時の処理
	void OnButtonClick()
	{
		_state++;
		if (_selectState.Length <= _state)
		{
			_state = 0;
		}

		SetSprite();

		//output変更
		_output.SetOutput(_circuitManager.Circuit(_selectState[_state], _input[0].GetOutput(), _input[1].GetOutput()));

		_circuitManager.SetChange();
	}

	public void SetSprite()
	{
		//Sprite変更
		Sprite sprite = _circuitManager.GetCircuitTexture(_selectState[_state]);

		if (_button == null)
		{
			_button = GetComponent<Button>();
		}
		_button.image.sprite = sprite;
	}
}
