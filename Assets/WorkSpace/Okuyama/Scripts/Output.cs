using UnityEngine;

public class Output : MonoBehaviour
{
	bool _output = true;


	//�ݒ�p
	public void SetOutput(bool output)
	{
		_output = output;
	}

	//�擾�p
	public bool GetOutput() { return _output; }
}
