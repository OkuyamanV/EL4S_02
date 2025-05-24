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

		//�{�^���N���b�N���̏����ǉ�
		_button.onClick.AddListener(OnButtonClick);
	}


	//�{�^���N���b�N���̏���
	void OnButtonClick()
	{
		//�������������̂݃V�[���J��
		if (_goalPoint.Answer())
		{
			SceneManager.LoadScene(_sceneAsset.name);
		}
    }

}
