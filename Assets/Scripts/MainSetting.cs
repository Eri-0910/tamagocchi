using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.U2D.Animation;
using static Utils;

public class MainSetting : MonoBehaviour
{
    public Text text;
    public static string nextAction;

    private static readonly string[] NOMALMESSAGES =　{"やっほーにゃん",　"今日も元気にゃん？",　"今日も頑張ろうにゃん!", "にゃんにゃにゃーん"};
    private static readonly string[] EATMESSAGES =　{"わーい、ごはん！",　"もぐもぐもぐもぐ",　"おいしー！"};
    private static readonly string[] BATHMESSAGES =　{"からだピカピカ〜"};
    private static readonly string[] CLEANMESSAGES =　{"おへやピカピカ〜"};
    private static readonly string[] WASHMESSAGES =　{"綺麗になった〜"};
    private static readonly string[] EXERCISEMESSAGES =　{"むきむきになるぞ！"};
    private static readonly string[] STUDYMESSAGES =　{"賢くなったぞ"};
    private static readonly string[] PLAYMESSAGES =　{"わーい、楽しい！"};

    [SerializeField]
    SpriteResolver resolver;
    [SerializeField]
    Animator animator;
    [SerializeField]
    Text age;
    [SerializeField]
    Text generationTextArea;

    // Start is called before the first frame update
    void Start()
    {
        // 年齢
        SetAge();

        // 世代
        SetGeneration();

        // アクションによる変化
        // コメントのセット
        SetComment(nextAction);
        // アニメーションのセット
        ChangeAnimation(nextAction);
        // アニメーションリセット
        nextAction = "";

        // ctoに変化するなどのキャラ変設定
        SetCharactorType();

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 年齢のセット
    /// </summary>
    void SetAge()
    {
        // 生まれた日を取得
        DateTime birthDay = Utils.StringToDateTime(PlayerPrefs.GetString("BirthDay"));
        // 今日の日付
        DateTime today = DateTime.Today.Date;

        // 何日あるか
        TimeSpan liveDate = today - birthDay;

        // 3日で１歳なので、3で割って最大の整数を年齢とする
        age.text = AgeToAgeText(Math.Floor(liveDate.Days/3.0));
    }

    string AgeToAgeText(double age)
    {
        return age.ToString() + "歳";
    }

    /// <summary>
    /// 世代のセット
    /// </summary>
    void SetGeneration()
    {
        int generation = PlayerPrefs.GetInt("Generation", 1);
        generationTextArea.text = GenerationToGenerationText(generation);
    }

    string GenerationToGenerationText(int generation)
    {
        return "第" + generation.ToString() + "世代";
    }

    /// <summary>
    /// ネコの変身をさせていた場合、その状態にセットする
    /// </summary>
    void SetCharactorType()
    {
        var charactorType = PlayerPrefs.GetString("CharactorType");

        if (charactorType != "normal")
        {
            GameObject.Find("switchcatbutton").GetComponent<CatChange>().change();
        }
    }

    /// <summary>
    /// 直前のアクションをもとに、ランダムにコメントをセットする
    /// </summary>
    /// <param name="nextAction">次のアクション</param>
    void SetComment(string nextAction)
    {
        string[] messages = GetActionComment(nextAction);
        string selectedMessage = messages.GetValue(UnityEngine.Random.Range(0, messages.Length)) as string;
        text.text = selectedMessage;
    }

    /// <summary>
    /// アクションに対応するメッセージセットを返す
    /// </summary>
    /// <param name="nextAction">次のアクショ</param>
    /// <return>メッセージセット</param>
    string[] GetActionComment(string nextAction)
    {
        string[] comments;
        switch (nextAction)
        {
            case "eat":
                comments = EATMESSAGES;
                break;
            case "bath":
                comments = BATHMESSAGES;
                break;
            case "clean":
                comments = CLEANMESSAGES;
                break;
            case "wash":
                comments = WASHMESSAGES;
                break;
            case "exercise":
                comments = EXERCISEMESSAGES;
                break;
            case "study":
                comments = STUDYMESSAGES;
                break;
            case "play":
                comments = PLAYMESSAGES;
                break;
            default:
                comments = NOMALMESSAGES;
                break;
        }
        return comments;
    }

    /// <summary>
    /// アクションに応じてアニメーションを変化させる
    /// </summary>
    public void ChangeAnimation(string nextAction)
    {
        switch (nextAction)
        {
            case "eat":
                animator.SetTrigger("eat");
                break;
            default:
                break;
        }
    }
}
