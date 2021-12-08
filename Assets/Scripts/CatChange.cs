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
        // 今のキャラクターを取得
        int charactorTypeInt = PlayerPrefs.GetInt("CharactorType", 0);
        CharactorType charactorType = new CharactorType(charactorTypeInt);

        // 次に変身するキャラクターIDを取得
        CharactorType.CharactorTypeId next = charactorType.Next();

        // 変身
        changeById(next);
    }

    public void changeById(CharactorType.CharactorTypeId id)
    {

        switch (id)
        {
            case CharactorType.CharactorTypeId.normal:
                // ノーマルに変身
                bodyResolver.SetCategoryAndLabel("Body", "normal");
                leftHand.enabled = true;
                rightHand.enabled = true;
                face.enabled = true;
                break;
            case CharactorType.CharactorTypeId.cto:
                // 変身
                bodyResolver.SetCategoryAndLabel("Body", "ctocat");
                leftHand.enabled = false;
                rightHand.enabled = false;
                face.enabled = false;
                break;
            default:
                // ノーマルに変身
                bodyResolver.SetCategoryAndLabel("Body", "normal");
                leftHand.enabled = true;
                rightHand.enabled = true;
                face.enabled = true;
                break;
        }

        // 変身状態保存
        PlayerPrefs.SetInt("CharactorType", (int)id);
    }
}
