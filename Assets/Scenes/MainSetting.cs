using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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

    // Start is called before the first frame update
    void Start()
    {
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

        nextAction = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomCommentSetting(string[] messages)
    {
        //ランダムなコメントセット
        string comment = messages.GetValue(Random.Range(0, messages.Length)) as string;
        text.text = comment;
    }
}
