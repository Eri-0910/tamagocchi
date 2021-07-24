using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainSetting : MonoBehaviour
{
    public Text text;

    private static readonly string[]　NOMALMESSAGES =　{"やっほーにゃん",　"今日も元気にゃん？",　"今日も頑張ろうにゃん!", "にゃんにゃにゃーん"};

    // Start is called before the first frame update
    void Start()
    {
        RandomCommentSetting();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomCommentSetting()
    {
        //ランダムなコメントセット
        string comment = NOMALMESSAGES.GetValue(Random.Range(0, NOMALMESSAGES.Length)) as string;
        text.text = comment;
    }
}
