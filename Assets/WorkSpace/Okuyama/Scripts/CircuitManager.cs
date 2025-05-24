using UnityEngine;

public class CircuitManager : MonoBehaviour
{
	public enum CircuitState
	{
		AND = 0,
		OR,
		NOT,
		NAND,
		NOR,
		XOR,
		NXOR,

		End
	};

	[SerializeField] Sprite[] _circuitTextures = new Sprite[(int)CircuitState.End];
	[SerializeField] Sprite[] _outputTextures = new Sprite[2];

	[SerializeField] CircuitPoint[] _circuitPoints = new CircuitPoint[2];//��O�ɂ�����̂��珇�ɓo�^����

	bool _change;

	private void Start()
	{
		_change = true;
	}

	private void Update()
	{
		if (_change)
		{
			_change = false;
			foreach (var circuit in _circuitPoints)
			{
				circuit.Change();
			}
		}
	}

	//�e�N�X�`���擾�p
	public Sprite GetCircuitTexture(CircuitState state)
	{
		return _circuitTextures[(int)state];
	}

	//�e�N�X�`���擾�p
	public Sprite GetOutputTexture(bool state)
	{
		int index = (state) ? 1 : 0;//true=1,false=0�Ƃ��ĕϊ�

		return _outputTextures[index];
	}

	public bool Circuit(CircuitState state, bool input1, bool input2)
	{
		switch (state)
		{
			case CircuitState.AND:
				return (input1 && input2);

			case CircuitState.OR:
				return (input1 || input2);

			case CircuitState.NOT:
				return !input1;

			case CircuitState.NAND:
				return !(input1 && input2);

			case CircuitState.NOR:
				return !(input1 || input2);

			case CircuitState.XOR:
				return ((input1 && !input2) || (!input1 && input2));

			case CircuitState.NXOR:
				return !((input1 && !input2) || (!input1 && input2));

			default:
				return false;
		}

	}
}
