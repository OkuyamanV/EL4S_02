using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

//�S�R�s�y�I�I�I�I�I

/// <summary>
/// �Q�[�����ɐ������Ԃ��u���F�b�v�ŕ\������N���X
/// </summary>
public class TimerScript : MonoBehaviour
{

    [SerializeField, Header("�������Ԃ̐ݒ�l")]
    public int playTime;
    [SerializeField, Header("�������Ԃ̕\��")]
    public TMP_Text playTimeText;
    [SerializeField, Header("�t�F�[�h�}�l�[�W���[")]
    FadeManager fadeManager;

    //���Ԍv���p
    private float timer;

    void Start()
    {
        DisplayPlayTime(playTime);
    }

    void Update()
    {
        //timer�𗘗p���Čo�ߎ��Ԃ��v��
        timer += Time.deltaTime;
        //1�b�o�߂��Ƃ�timer��0�ɖ߂��AplayTime(currentTime)�����Z����
        if (timer >= 1)
        {
            timer = 0;
            playTime--;

            if (playTime < 0)
            {
                //�ꉞ�}�C�i�X�l�����Ȃ��悤��
                playTime = 0;
                //�����V�[���ړ�
                SceneManager.LoadScene("FailedScene");
            }

            //���ԕ\�����X�V���郁�\�b�h���Ăяo��
            DisplayPlayTime(playTime);
        }

        if (playTime <= 0)
        {
            //�Q�[���I�[�o�[���� - �t�F�[�h�C��(�A�E�g)
            fadeManager.FadeIn("FailedScene");
        }
    }

    /// <summary>
    /// �������Ԃ��X�V����[��:�b]�ŕ\������
    /// </summary>
    private void DisplayPlayTime(int limitTime)
    {
        //�����Ŏ󂯎�����l��[��:�b]�ɕϊ����ĕ\������
        //ToString("00")�Ń[���v���[�X�t�H���_�[���āA�P���̂Ƃ��͓���0������
        playTimeText.text = ((int)(limitTime / 60)).ToString("00") + ":" + ((int)limitTime % 60).ToString("00");
    }
}