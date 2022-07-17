using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BakuSou
{
    public class Information : MonoBehaviour
    {
        public GameObject title;
        Text title_text;
        public GameObject describe;
        Text describe_text;
        public GameObject high_score;
        Text high_score_text;
        public GameObject max_combo;
        Text max_combo_text;
        public GameObject level;
        Text level_text;
        public GameObject star;
        Image star_image;
        // Use this for initialization

        private Color easy_color;
        private Color normal_color;
        private Color hard_color;
        void Start()
        {
            title_text = title.GetComponent<Text>();
            describe_text = describe.GetComponent<Text>();
            high_score_text = high_score.GetComponent<Text>();
            max_combo_text = max_combo.GetComponent<Text>();
            level_text = level.GetComponent<Text>();
            star_image = star.GetComponent<Image>();
            easy_color = new Color(0f, 255 / 255.0f, 255,255);
            normal_color = new Color(240 / 255.0f, 255 / 255.0f, 0f, 255 / 255.0f);
            hard_color = new Color(255 / 255.0f, 70 / 255.0f, 0f, 255 / 255.0f);
        }

        // Update is called once per frame
        void Update()
        {
            GameParameter gameParameter = GameParameter.Instance();

            title_text.text = gameParameter.GetSelectMusicData().Inf.title;
            describe_text.text = gameParameter.GetSelectMusicData().GetDescribe();
            high_score_text.text = gameParameter.GetSelectMusicData().GetHighScore();
            max_combo_text.text = gameParameter.GetSelectMusicData().GetMaxCombo();
            level_text.text = gameParameter.GetSelectMusicData().Inf.level.ToString();
            if (gameParameter.GetSelectMusicData().Inf.level < 4)
            {
                star_image.color = easy_color;
            }
            else if(gameParameter.GetSelectMusicData().Inf.level < 7)
            {
                star_image.color = normal_color;
            }
            else if(gameParameter.GetSelectMusicData().Inf.level >= 7)
            {
                star_image.color = hard_color;

            }

        }
    }
}