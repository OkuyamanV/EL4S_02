using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
	[SerializeField] GoalPoint _goalPoint;
	[SerializeField] UnityEditor.SceneAsset _sceneAsset;

    Button _button;

	private void Start()
	{
		_button = GetComponent<Button>();

		//ボタンクリック時の処理追加
		_button.onClick.AddListener(OnButtonClick);
	}


	//ボタンクリック時の処理
	void OnButtonClick()
	{
		//正解だった時のみシーン遷移
		if (_goalPoint.Answer())
		{
			SceneManager.LoadScene(_sceneAsset.name);
		}
    }

}
