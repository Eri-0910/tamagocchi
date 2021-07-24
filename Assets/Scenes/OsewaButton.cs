using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsewaButton : MonoBehaviour
{
    // ダイアログを追加する親のCanvas
    [SerializeField] private Canvas parent = default;
    // 表示するダイアログ
    [SerializeField] private OsewaModal modal = default;

    public void ShowModal()
    {
        // 生成してCanvasの子要素に設定
        var _modal = Instantiate(modal);
        _modal.transform.SetParent(parent.transform, false);
    }
}
