using UnityEngine;
using UnityEngine.UI;

public class StartPoint : MonoBehaviour
{
	CircuitManager _circuitManager;
	Output _output;
	[SerializeField] bool _startOutput;
	Image _image;

	private void Start()
	{
		_circuitManager = FindAnyObjectByType<CircuitManager>();
		_output = GetComponent<Output>();
		_output.SetOutput(_startOutput);

		//テクスチャ変更
		_image = GetComponent<Image>();
		_image.sprite = _circuitManager.GetOutputTexture(_startOutput);
	}

}
