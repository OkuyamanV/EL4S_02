using UnityEngine;

public class Output : MonoBehaviour
{
	bool _output = true;


	//設定用
	public void SetOutput(bool output)
	{
		_output = output;
	}

	//取得用
	public bool GetOutput() { return _output; }
}
