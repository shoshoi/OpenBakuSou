using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BakuSou
{
    public class Character : MonoBehaviour
    {
        public GameObject character;
        public Image charaImage;
        public Sprite sprite1;
        public Sprite sprite2;
        public Sprite sprite3;
        public Sprite sprite4;
        int bpm = 0;
        float before_mod;
        bool boundSwitch = false;
        bool isUp = false;
        private Vector3 default_pos;
        private float aftertime = 0;
        public GameObject endPanel;
        // Use this for initialization
        void Start()
        {
            bpm = GameParameter.Instance().GetSelectMusicData().Bpm;
            charaImage = character.GetComponent<Image>();
            before_mod = 0f;
            default_pos = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z);
        }

        // Update is called once per frame
        void Update()
        {
            float mod = 0f;
            if (endPanel.activeSelf)
            {
                mod = (AudioManager.Instance.GetTime() + aftertime) % (120f / bpm);
                aftertime += Time.deltaTime;
            }
            else
            {
                mod = AudioManager.Instance.GetTime() % (120f / bpm);
            }

            if (mod < before_mod)
            {
                boundSwitch = true;
                isUp = true;
            }
            before_mod = mod;

            if(boundSwitch)
            {
                if(isUp){
                    this.transform.Translate(0, 100 * Time.deltaTime, 0);
                    if (this.transform.localPosition.y > 50)
                    {
                        this.transform.localPosition = new Vector3(this.transform.localPosition.x, 50, this.transform.localPosition.z);
                        isUp = false;
                    }
                }else{
                    this.transform.Translate(0, -100 * Time.deltaTime, 0);
                    if (this.transform.localPosition.y < 0)
                    {
                        this.transform.localPosition = default_pos;
                        boundSwitch = false;
                    }
                }
            }

            int score = GameParameter.Instance().result.Score;
            if(score < 5000)
            {
                charaImage.sprite = sprite1;
            }
            else if(score < 7000)
            {
                charaImage.sprite = sprite2;
            }
            else if(score < 9000)
            {
                charaImage.sprite = sprite3;
            }
            else if(score < 10000)
            {
                charaImage.sprite = sprite4;
            }
            else if(score == 10000)
            {
                charaImage.sprite = sprite4;
            }
        }
    }
}