//---------------------------------------------------
// �`���[�g���A���}�l�[�W���[
// ����ҁG�~���� �g�V
// �X�V���e
// Add      �F�@�V�K�쐬
//---------------------------------------------------
using Unity.VisualScripting;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    // �O���R���|�[�l���g
    [SerializeField] FadeManager fadeManager;   // �t�F�[�h�}�l�[�W���[
    [SerializeField] AudioManager audioManager; // �I�[�f�B�I�}�l�[�W���[
    [SerializeField] GameObject tutorialObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager.PlayAudio("BGM", true);
        tutorialObject.SetActive(true);
    }


    #region �{�^������

    public void BackButton()
    {
        audioManager.PlayAudio("Button");
        fadeManager.FadeIn("TitleScene");
        tutorialObject.SetActive(false);
    }

    #endregion
}
