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
            // FIXME: 各変身をそれぞれ関数化、タイプ名で変身できるようにする
            case "ctocat":
                // 変身
                bodyResolver.SetCategoryAndLabel("Body", "normal");
                leftHand.enabled = true;
                rightHand.enabled = true;
                face.enabled = true;
                // 変身状態設定
                PlayerPrefs.SetString("CharactorType", "normal");
                break;
            default:
                // 変身
                bodyResolver.SetCategoryAndLabel("Body", "ctocat");
                leftHand.enabled = false;
                rightHand.enabled = false;
                face.enabled = false;
                // 変身状態設定
                PlayerPrefs.SetString("CharactorType", "ctocat");
                break;
        }
    }
}
