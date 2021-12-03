using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CatChange : MonoBehaviour
{

    // 表示非表示を切り替える
    public SpriteRenderer leftHand;
    public SpriteRenderer rightHand;
    public SpriteRenderer body;
    public SpriteRenderer face;
    public SpriteRenderer ctoBody;

    public void change()
    {
        leftHand.enabled = !leftHand.enabled;
        rightHand.enabled = !rightHand.enabled;
        body.enabled = !body.enabled;
        ctoBody.enabled = !ctoBody.enabled;
    }
}
