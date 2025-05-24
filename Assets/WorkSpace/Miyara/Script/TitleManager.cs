//---------------------------------------------------
// タイトルマネージャー
// 制作者；ミヤラ トシ
// 更新内容
// Update   ：　ステージセレクト処理追加
// Add      ：　新規作成
//---------------------------------------------------
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    // 外部コンポーネント
    [SerializeField] FadeManager fadeManager;   // フェードマネージャー
    [SerializeField] GameObject titleUI;        // タイトルUI
    [SerializeField] GameObject stageSelectUI;  // ステージセレクトUI

    // 内部変数
    private enum UISelect   // UI表示
    {
        None = 0,
        TitleUI,
        StageSelectUI,
    }
    UISelect uiSelect = UISelect.TitleUI;   // 最初はタイトル表示


    private void Start()
    {
        uiSelect = UISelect.TitleUI;
    }

    void Update()
    {
        // 表示UIの変更
        if(uiSelect == UISelect.TitleUI)
        {
            stageSelectUI.SetActive(false);
            titleUI.SetActive(true);

            if (Input.GetMouseButtonDown(0))
                uiSelect = UISelect.StageSelectUI;  // ステージセレクトに変更
        }
        if(uiSelect == UISelect.StageSelectUI)
        {
            titleUI.SetActive(false);
            stageSelectUI.SetActive(true);
        }
    }



    #region ボタンの処理
    public void Stage01Button()
    {
        fadeManager.FadeIn("GameScene01");
    }
    public void BackButton()
    {
        uiSelect = UISelect.TitleUI;  // タイトルUIに変更
    }

    #endregion
}
