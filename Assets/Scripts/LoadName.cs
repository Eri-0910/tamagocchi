using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        name = PlayerPrefs.GetString("Name", "ナナシのたまごっち");
        GetComponent<Text>().text = name;
    }

}
