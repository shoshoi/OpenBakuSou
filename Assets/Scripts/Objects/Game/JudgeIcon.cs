using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace BakuSou
{
    public class JudgeIcon : MonoBehaviour
    {
        public Text text;
        public float disptime = 2f;
        public float nowtime = 0;
        public bool dispStart = false;
        private float scaleX = 0;
        private float scaleY = 0;

        private Color color_great = new Color(0f / 255f, 253f / 255f, 49f / 255f);
        private Color color_good = new Color(0f / 255f, 179f / 255f, 243f / 255f);
        private Color color_bad = new Color(42f / 255f, 0f / 255f,167f / 255f);


        // Use this for initialization
        void Start()
        {
            GameObject game = GameObject.Find("JudgeIcon");
            text = game.GetComponent<Text>();
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
        public void JudgeDisp(Judgement judge)
        {
            if(judge == Judgement.GREAT || judge == Judgement.GOOD || judge == Judgement.BAD || judge == Judgement.LATE)
            {
                nowtime = 0;
                scaleX = 0;
                scaleY = 0;
                dispStart = true;
                switch (judge)
                {
                    case Judgement.GREAT:
                        text.text = "Great!!";
                        text.color = color_great;
                        break;
                    case Judgement.GOOD:
                        text.text = "Good!";
                        text.color = color_good;
                        break;
                    case Judgement.BAD:
                        text.text = "Bad";
                        text.color = color_bad;
                        break;
                    case Judgement.LATE:
                        text.text = "Miss";
                        text.color = color_bad;
                        break;
                }
            }
        }
    }
}