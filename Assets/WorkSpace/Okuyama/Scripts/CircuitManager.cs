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

	[SerializeField, EnumArray(typeof(CircuitState))] Sprite[] _circuitTextures = new Sprite[(int)CircuitState.End];
	[SerializeField] string[] _outputStrings = new string[2];

	[SerializeField] CircuitPoint[] _circuitPoints = new CircuitPoint[0];//手前にあるものから順に登録する

	bool _change;

	private void Start()
	{
		_change = true;
		SetStartTextures();
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

	void SetStartTextures()
	{
		foreach (var circuit in _circuitPoints)
		{
			circuit.SetSprite();
		}
	}

	//テクスチャ取得用
	public Sprite GetCircuitTexture(CircuitState state)
	{
		return _circuitTextures[(int)state];
	}

	//テクスチャ取得用
	public string GetOutputTexture(bool state)
	{
		int index = (state) ? 1 : 0;//true=1,false=0として変換

		return _outputStrings[index];
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

	public void SetChange() { _change = true; }
}