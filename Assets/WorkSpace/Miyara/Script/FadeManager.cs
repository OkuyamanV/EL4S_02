//---------------------------------------------------
// �t�F�[�h�V�X�e��
// ����ҁG�~���� �g�V
// �X�V���e
// Add�F�@�V�K�쐬
//---------------------------------------------------
using System.Collections;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    // �O���ϐ�
    [SerializeField] GameObject fadeObject;   // �t�F�[�h����C���[�W
    [SerializeField] float fadeDuration;    // �t�F�[�h����

    // �����ϐ�
    UnityEngine.Color color;    // �ύX����F
    Image fadeImage;

    void Start()
    {
        fadeObject.SetActive(true);
        fadeImage = fadeObject.GetComponent<Image>();
        FadeOut();
    }

    /// <summary>
    /// �t�F�[�h�C������
    /// </summary>
    /// <param name="sceneName"> �t�F�[�h��J�ڃV�[���� </param>
    public void FadeIn(string sceneName = "")
    {
        color = fadeImage.color;
        fadeObject.SetActive(true);

        // �V�[���������͂���Ă��邩�ǂ���
        if (string.IsNullOrEmpty(sceneName))
            StartCoroutine(Fade(0, 1));
        else
            StartCoroutine(Fade(0, 1, sceneName));

    }

    public void FadeOut()
    {
        fadeObject.SetActive(true);
        color = fadeImage.color;
        StartCoroutine(Fade(1, 0));
    }


    /// <summary>
    /// �t�F�[�h�R���[�`��
    /// </summary>
    private IEnumerator Fade(float start, float end, string sceneName = "")
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(start, end, elapsedTime / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }
        color.a = end;
        fadeImage.color = color;
        fadeObject.SetActive(false);

        // �V�[�������w�肳��Ă�����V�[���J��
        if (!string.IsNullOrEmpty(sceneName))
            SceneManager.LoadScene(sceneName);
    }

}
