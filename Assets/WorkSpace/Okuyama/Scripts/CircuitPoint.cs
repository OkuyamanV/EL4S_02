using UnityEngine;
using UnityEngine.UI;

public class CircuitPoint : MonoBehaviour
{
	CircuitManager _circuitManager;
	Output _output;
	[SerializeField] Output[] _input = new Output[2];
	[SerializeField] CircuitManager.CircuitState[] _selectState = new CircuitManager.CircuitState[1];
	[SerializeField] int _state;

	Button _button;

	private void Start()
	{
		_circuitManager = FindAnyObjectByType<CircuitManager>();
		_button = GetComponent<Button>();

		//�{�^���N���b�N���̏����ǉ�
		_button.onClick.AddListener(OnButtonClick);

		_state = 0;
	}

	//����output�̕ύX�ɂ��킹��
	public void Change()
	{
		//�o�͓��e�X�V
		_output.SetOutput(_circuitManager.Circuit(_selectState[_state], _input[0].GetOutput(), _input[1].GetOutput()));
	}

	//�{�^���N���b�N���̏���
	void OnButtonClick()
	{
		_state++;
		if (_selectState.Length <= _state)
		{
			_state = 0;
		}

		//Sprite�ύX
		Sprite sprite = _circuitManager.GetCircuitTexture(_selectState[_state]);
		_button.image.sprite = sprite;

		//output�ύX
		_output.SetOutput(_circuitManager.Circuit(_selectState[_state], _input[0].GetOutput(), _input[1].GetOutput()));

	}
}
