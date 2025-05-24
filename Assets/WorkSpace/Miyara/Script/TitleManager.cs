//---------------------------------------------------
// �^�C�g���}�l�[�W���[
// ����ҁG�~���� �g�V
// �X�V���e
// Update   �F�@�X�e�[�W�Z���N�g�����ǉ�
// Add      �F�@�V�K�쐬
//---------------------------------------------------
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    // �O���R���|�[�l���g
    [SerializeField] FadeManager fadeManager;   // �t�F�[�h�}�l�[�W���[
    [SerializeField] GameObject titleUI;        // �^�C�g��UI
    [SerializeField] GameObject stageSelectUI;  // �X�e�[�W�Z���N�gUI

    // �����ϐ�
    private enum UISelect   // UI�\��
    {
        None = 0,
        TitleUI,
        StageSelectUI,
    }
    UISelect uiSelect = UISelect.TitleUI;   // �ŏ��̓^�C�g���\��


    private void Start()
    {
        uiSelect = UISelect.TitleUI;
    }

    void Update()
    {
        // �\��UI�̕ύX
        if(uiSelect == UISelect.TitleUI)
        {
            stageSelectUI.SetActive(false);
            titleUI.SetActive(true);

            if (Input.GetMouseButtonDown(0))
                uiSelect = UISelect.StageSelectUI;  // �X�e�[�W�Z���N�g�ɕύX
        }
        if(uiSelect == UISelect.StageSelectUI)
        {
            titleUI.SetActive(false);
            stageSelectUI.SetActive(true);
        }
    }



    #region �{�^���̏���
    public void Stage01Button()
    {
        fadeManager.FadeIn("GameScene01");
    }
    public void BackButton()
    {
        uiSelect = UISelect.TitleUI;  // �^�C�g��UI�ɕύX
    }

    #endregion
}
