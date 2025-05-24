//---------------------------------------------------
// オーディオシステム
// 制作者；ミヤラ トシ
// 更新内容
// Add      ：　新規作成
//---------------------------------------------------
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class AudioData              // オーディオクラス
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
    /// BGM、SE再生
    /// </summary>
    /// <param name="name"> 再生したい名前 </param>
    /// <param name="loop"> ループするかどうか </param>
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

