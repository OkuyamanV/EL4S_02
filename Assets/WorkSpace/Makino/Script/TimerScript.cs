using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

//全コピペ！！！！！

/// <summary>
/// ゲーム内に制限時間を「分：秒」で表示するクラス
/// </summary>
public class TimerScript : MonoBehaviour
{

    [SerializeField, Header("制限時間の設定値")]
    public int playTime;
    [SerializeField, Header("制限時間の表示")]
    public TMP_Text playTimeText;
    [SerializeField, Header("フェードマネージャー")]
    FadeManager fadeManager;

    //時間計測用
    private float timer;

    void Start()
    {
        DisplayPlayTime(playTime);
    }

    void Update()
    {
        //timerを利用して経過時間を計測
        timer += Time.deltaTime;
        //1秒経過ごとにtimerを0に戻し、playTime(currentTime)を減算する
        if (timer >= 1)
        {
            timer = 0;
            playTime--;

            if (playTime < 0)
            {
                //一応マイナス値いかないように
                playTime = 0;
                //強制シーン移動
                SceneManager.LoadScene("FailedScene");
            }

            //時間表示を更新するメソッドを呼び出す
            DisplayPlayTime(playTime);
        }

        if (playTime <= 0)
        {
            //ゲームオーバー処理 - フェードイン(アウト)
            fadeManager.FadeIn("FailedScene");
        }
    }

    /// <summary>
    /// 制限時間を更新して[分:秒]で表示する
    /// </summary>
    private void DisplayPlayTime(int limitTime)
    {
        //引数で受け取った値を[分:秒]に変換して表示する
        //ToString("00")でゼロプレースフォルダーして、１桁のときは頭に0をつける
        playTimeText.text = ((int)(limitTime / 60)).ToString("00") + ":" + ((int)limitTime % 60).ToString("00");
    }
}