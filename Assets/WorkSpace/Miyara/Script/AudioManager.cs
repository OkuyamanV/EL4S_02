//---------------------------------------------------
// �I�[�f�B�I�V�X�e��
// ����ҁG�~���� �g�V
// �X�V���e
// Add      �F�@�V�K�쐬
//---------------------------------------------------
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class AudioData              // �I�[�f�B�I�N���X
    {
        public string name;
        public AudioClip clip;
        public float volume = 1.0f;
    }

    public List<AudioData> bgmList;
    public List<AudioData> seList;

    private Dictionary<string, AudioData> audioDict = new Dictionary<string, AudioData>();
    private AudioSource bgmSource;
    private AudioSource seSource;

    void Awake()
    {
        bgmSource = gameObject.AddComponent<AudioSource>();
        seSource = gameObject.AddComponent<AudioSource>();

        foreach (var bgm in bgmList)
        {
            audioDict[bgm.name] = bgm;
        }
        foreach (var se in seList)
        {
            audioDict[se.name] = se;
        }
    }

    /// <summary>
    /// BGM�ASE�Đ�
    /// </summary>
    /// <param name="name"> �Đ����������O </param>
    /// <param name="loop"> ���[�v���邩�ǂ��� </param>
    public void PlayAudio(string name, bool loop = false)
    {
        if (audioDict.ContainsKey(name))
        {
            var audioData = audioDict[name];

            AudioSource source = loop ? bgmSource : seSource;
            source.clip = audioData.clip;
            source.volume = audioData.volume;
            source.loop = loop;
            source.Play();
        }
        else
        {
            Debug.LogWarning($"Audio {name} not found!");
        }
    }
}

