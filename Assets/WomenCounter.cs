using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WomenCounter : MonoBehaviour {


    private int womanCount = 0;
    private Text t;

    void Start()
    {
        t = GetComponent<Text>();
    }

    public void AddWoman()
    {
        womanCount++;
        t.text = "Women: " + womanCount;
    }

}
