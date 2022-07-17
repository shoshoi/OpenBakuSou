using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BakuSou
{
    public class EndingCharacter : MonoBehaviour
    {
        private Image charaImage;
        public Sprite sprite1;
        public Sprite sprite2;
        public Sprite sprite3;
        public Sprite sprite4;
        public int score = 0;
        void Start()
        {
            charaImage = GetComponent<Image>();
            if (score < 5000)
            {
                charaImage.sprite = sprite1;
            }
            else if (score < 7000)
            {
                charaImage.sprite = sprite2;
            }
            else if (score < 9000)
            {
                charaImage.sprite = sprite3;
            }
            else if (score < 10000)
            {
                charaImage.sprite = sprite4;
            }
            else if (score == 10000)
            {
                charaImage.sprite = sprite4;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (score < 5000)
            {
                charaImage.sprite = sprite1;
            }
            else if (score < 7000)
            {
                charaImage.sprite = sprite2;
            }
            else if (score < 9000)
            {
                charaImage.sprite = sprite3;
            }
            else if (score < 10000)
            {
                charaImage.sprite = sprite4;
            }
            else if (score == 10000)
            {
                charaImage.sprite = sprite4;
            }
        }
    }
}