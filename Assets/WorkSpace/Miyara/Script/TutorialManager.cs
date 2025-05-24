//---------------------------------------------------
// チュートリアルマネージャー
// 制作者；ミヤラ トシ
// 更新内容
// Add      ：　新規作成
//---------------------------------------------------
using Unity.VisualScripting;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    // 外部コンポーネント
    [SerializeField] FadeManager fadeManager;   // フェードマネージャー
    [SerializeField] AudioManager audioManager; // オーディオマネージャー
    [SerializeField] GameObject tutorialObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager.PlayAudio("BGM", true);
        tutorialObject.SetActive(true);
    }


    #region ボタン処理

    public void BackButton()
    {
        audioManager.PlayAudio("Button");
        fadeManager.FadeIn("TitleScene");
        tutorialObject.SetActive(false);
    }

    #endregion
}
