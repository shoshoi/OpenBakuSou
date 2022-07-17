using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combo : MonoBehaviour {

    public GameObject text;
     Text comboText;
    public float disptime = 1000f;
    public float nowtime = 0;
    public bool dispStart = false;
    private float scaleX = 0;
    private float scaleY = 0;
    // Use this for initialization
    void Start () {
        comboText = text.GetComponent<Text>();
	}

    // Update is called once per frame
    void Update()
    {
        if (dispStart)
        {
            scaleX += 20f * Time.deltaTime;
            scaleY += 20f * Time.deltaTime;
            if (scaleX > 1f)
            {
                scaleX = 1f;
                scaleY = 1f;
                dispStart = false;
                nowtime = disptime;
            }
        }
        else if (nowtime > 0)
        {
            nowtime -= Time.deltaTime;
        }
        else if (nowtime <= 0)
        {
            nowtime = 0f;
            scaleX = 0;
            scaleY = 0;
        }
        this.transform.localScale = new Vector3(scaleX, scaleY, 1);
    }
    public void Disp(string combo)
    {
        comboText.text = combo;
        nowtime = 0;
        scaleX = 0;
        scaleY = 0;
        dispStart = true;
    }
    public void Hide()
    {
        nowtime = 0;
        scaleX = 0;
        scaleY = 0;
        dispStart = false;
    }
}
