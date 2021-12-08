using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGomi : MonoBehaviour
{
    public Image effect;
    // Start is called before the first frame update
    void Start()
    {
        // お世話アイテム取得
        var json = PlayerPrefs.GetString("Osewa");
        OsewaItems osewaItems = JsonUtility.FromJson<OsewaItems>(json);

        // 綺麗
        List<OsewaItem> osewaItemsClean = osewaItems.clean;

        // 達成率の合計
        int done = 0;
        foreach (OsewaItem osewaItem in osewaItemsClean)
        {
            if (osewaItem.IsClear() || osewaItem.IsClearBefore())
            {
                done++;
            }
        }

        double clearRate = done / (double) osewaItemsClean.Count;

        if (clearRate < 0.8)
        {
            effect.enabled = true;
        } else
        {
            effect.enabled = false;
        }
    }
}
