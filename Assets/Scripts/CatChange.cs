using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class CatChange : MonoBehaviour
{

    // 表示非表示を切り替える
    public SpriteRenderer leftHand;
    public SpriteRenderer rightHand;
    public SpriteRenderer face;
    public SpriteResolver bodyResolver;

    public void change()
    {
        switch (bodyResolver.GetLabel())
        {
            case "ctocat":
                bodyResolver.SetCategoryAndLabel("Body", "nomal");
                leftHand.enabled = true;
                rightHand.enabled = true;
                face.enabled = true;
                break;
            default:
                bodyResolver.SetCategoryAndLabel("Body", "ctocat");
                leftHand.enabled = false;
                rightHand.enabled = false;
                face.enabled = false;
                break;
        }
    }
}
