//---------------------------------------------------
// フェードシステム
// 制作者；ミヤラ トシ
// 更新内容
// Add：　新規作成
//---------------------------------------------------
using System.Collections;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    // 外部変数
    [SerializeField] GameObject fadeObject;   // フェードするイメージ
    [SerializeField] float fadeDuration;    // フェード時間

    // 内部変数
    UnityEngine.Color color;    // 変更する色
    Image fadeImage;

    void Start()
    {
        fadeObject.SetActive(true);
        fadeImage = fadeObject.GetComponent<Image>();
        FadeOut();
    }

    /// <summary>
    /// フェードイン処理
    /// </summary>
    /// <param name="sceneName"> フェード後遷移シーン名 </param>
    public void FadeIn(string sceneName = "")
    {
        color = fadeImage.color;
        fadeObject.SetActive(true);

        // シーン名が入力されているかどうか
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
    /// フェードコルーチン
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

        // シーン名が指定されていたらシーン遷移
        if (!string.IsNullOrEmpty(sceneName))
            SceneManager.LoadScene(sceneName);
    }

}
