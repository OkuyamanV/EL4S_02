using UnityEngine;
using UnityEngine.UI;

public class GoalPoint : MonoBehaviour
{
	CircuitManager _circuitManager;
	[SerializeField] bool _target;
	[SerializeField] Output _input;

	Image _image;

	private void Start()
	{
		_circuitManager = FindAnyObjectByType<CircuitManager>();

		//テクスチャ変更
		_image = GetComponent<Image>();
		_image.sprite = _circuitManager.GetOutputTexture(_target);
	}

	public bool Answer()
	{
		return _target == _input.GetOutput();
	}

}
