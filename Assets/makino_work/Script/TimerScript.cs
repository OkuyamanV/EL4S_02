using UnityEngine;
using TMPro;

//�S�R�s�y�I�I�I�I�I

/// <summary>
/// �Q�[�����ɐ������Ԃ��u���F�b�v�ŕ\������N���X
/// </summary>
public class TimerScript : MonoBehaviour
{

    [SerializeField, Header("�������Ԃ̐ݒ�l")]
    public int battleTime;
    [SerializeField, Header("�������Ԃ̕\��")]
    public TMP_Text battleTimeText;

    private int currentTime;              // ���݂̎c�莞�ԁi�s�v�ȏꍇ�͐錾���Ȃ��j
    private float timer;                  // ���Ԍv���p

    void Start()
    {
        // currentTime�𗘗p����ꍇ�ɂ͂����ő������B�ȉ��A�K�v�ɉ�����battleTime��currentTime�ɏ���������
        currentTime = battleTime;
        DisplayBattleTime(battleTime);
    }

    void Update()
    {
        // timer�𗘗p���Čo�ߎ��Ԃ��v��
        timer += Time.deltaTime;
        // 1�b�o�߂��Ƃ�timer��0�ɖ߂��AbattleTime(currentTime)�����Z����
        if (timer >= 1)
        {
            timer = 0;
            battleTime--;  // ���邢�́AcurrentTime--;
            // ���ԕ\�����X�V���郁�\�b�h���Ăяo��
            DisplayBattleTime(battleTime);   // ���邢�́ADisplayBattleTime(currentTime);
        }
    }

    /// <summary>
    /// �������Ԃ��X�V����[��:�b]�ŕ\������
    /// </summary>
    private void DisplayBattleTime(int limitTime)
    {
        // �����Ŏ󂯎�����l��[��:�b]�ɕϊ����ĕ\������
        // ToString("00")�Ń[���v���[�X�t�H���_�[���āA�P���̂Ƃ��͓���0������
        battleTimeText.text = ((int)(limitTime / 60)).ToString("00") + ":" + ((int)limitTime % 60).ToString("00");
    }
}