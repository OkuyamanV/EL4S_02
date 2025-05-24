using UnityEngine;

public class Output : MonoBehaviour
{
	bool _output = true;


	//İ’è—p
	public void SetOutput(bool output)
	{
		_output = output;
	}

	//æ“¾—p
	public bool GetOutput() { return _output; }
}
