using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.U2D.Animation;

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
        DateTime birthDay =  DateTime.ParseExact(PlayerPrefs.GetString("BirthDay"), "M/d/yyyy h:m:s tt", new CultureInfo("en-US")).Date;
        DateTime today = DateTime.Today.Date;

        TimeSpan liveDate = today - birthDay;

        age.text = Math.Floor(liveDate.Days/3.0).ToString() + "歳";

        // 世代
        int generation = PlayerPrefs.GetInt("Generation", 1);
        Debug.Log(PlayerPrefs.GetInt("Generation"));
        generationTextArea.text = "第" + generation.ToString() + "世代";

        // アクション
        Debug.Log(nextAction);
        switch (nextAction)
        {
            case "eat":
                RandomCommentSetting(EATMESSAGES);
                break;
            case "bath":
                RandomCommentSetting(BATHMESSAGES);
                break;
            case "clean":
                RandomCommentSetting(CLEANMESSAGES);
                break;
            case "wash":
                RandomCommentSetting(WASHMESSAGES);
                break;
            case "exercise":
                RandomCommentSetting(EXERCISEMESSAGES);
                break;
            case "study":
                RandomCommentSetting(STUDYMESSAGES);
                break;
            case "play":
                RandomCommentSetting(PLAYMESSAGES);
                break;
            default:
                RandomCommentSetting(NOMALMESSAGES);
                break;
        }

        ChangeAnimation(nextAction);

        // ctoに変化するなどのキャラ変設定
        SetCharactorType();

        nextAction = "";
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetCharactorType()
    {
        var charactorType = PlayerPrefs.GetString("CharactorType");

        Debug.Log(charactorType);

        if (charactorType != "normal")
        {
            GameObject.Find("switchcatbutton").GetComponent<CatChange>().change();
        }
    }

    public void RandomCommentSetting(string[] messages)
    {
        //ランダムなコメントセット
        string comment = messages.GetValue(UnityEngine.Random.Range(0, messages.Length)) as string;
        text.text = comment;
    }


    public void ChangeHand(string nextAction)
    {
        switch (nextAction)
        {
            case "eat":
                resolver.SetCategoryAndLabel("Hand", "eat");
                Debug.Log(resolver.GetLabel());
                break;
            default:
                resolver.SetCategoryAndLabel("Hand", "nomal");
                break;
        }
    }

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
