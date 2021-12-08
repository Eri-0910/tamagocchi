using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckLife : MonoBehaviour
{
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Image heart4;
    public Image heart5;
    // Start is called before the first frame update
    void Start()
    {
        // お世話アイテム取得
        var json = PlayerPrefs.GetString("Osewa");
        OsewaItems osewaItems = JsonUtility.FromJson<OsewaItems>(json);

        // 達成率の合計
        double rateSum = 0;
        foreach (List<OsewaItem> osewaItemsByCategory in osewaItems.OsewaItemsToList())
        {
            int done = 0;
            int over = 0;
            foreach (OsewaItem osewaItem in osewaItemsByCategory)
            {
                if (osewaItem.IsClear() || osewaItem.IsClearBefore())
                {
                    done++;
                }
                if (osewaItem.IsOver())
                {
                    over++;
                }
            }

            rateSum += done / (double) osewaItemsByCategory.Count;
        }

        // 平均を取る
        double totalRate = rateSum/7.0;

        // ハートの表示を切り替える
        if (totalRate < 0.88)
        {
            heart5.enabled = false;
        }
        if (totalRate < 0.76)
        {
            heart4.enabled = false;
        }
        if (totalRate < 0.64)
        {
            heart3.enabled = false;
        }
        if (totalRate < 0.52)
        {
            heart2.enabled = false;
        }
        if (totalRate < 0.40)
        {
            heart1.enabled = false;
        }

    }
}
