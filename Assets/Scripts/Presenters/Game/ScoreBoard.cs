using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace BakuSou
{
    public class ScoreBoard : SingletonMonoBehaviour<ScoreBoard>
    {
        private GameObject scoreBoard;
        private Text scoreText;
        private Text scoreAll;

        private ResultData result;
        private int late_count;
        private int max_count;
        private int before_combo = 0;
        JudgeIcon judgeIconScript;
        AudioClip[] bvoices;
        AudioClip[] avoices;
        AudioClip[] svoices;
        AudioSource voice;
        System.Random random;
        RectTransform exp_bar_fail;
        RectTransform exp_bar_clear;
        float init_width_fail;
        float init_width_clear;
        float offset = 0f;
        Combo comboObj;
        Text comboText;

        // Use this for initialization
        void Start()
        {
            exp_bar_fail = GameObject.Find("Exp_Bar_fail").GetComponent<RectTransform>();
            exp_bar_clear = GameObject.Find("Exp_Bar_clear").GetComponent<RectTransform>();
            init_width_fail = exp_bar_fail.sizeDelta.x;
            init_width_clear = exp_bar_clear.sizeDelta.x;
            exp_bar_fail.sizeDelta = new Vector2(offset, exp_bar_fail.sizeDelta.y);
            exp_bar_clear.sizeDelta = new Vector2(offset, exp_bar_clear.sizeDelta.y);

            BakusouMusicData musicData = GameParameter.Instance().GetSelectMusicData();
            max_count = (musicData.KeyArray == null) ? 0 : musicData.KeyArray.Length;
            result = new ResultData(max_count);
            scoreBoard = GameObject.Find("ScoreBoard");
            scoreAll = scoreBoard.GetComponent<Text>();
            scoreText = GameObject.Find("ScoreText").GetComponent<Text>();

            GameParameter.Instance().result = result;
            GameObject judgeIcon = GameObject.Find("JudgeIcon");
            judgeIconScript = judgeIcon.GetComponent<JudgeIcon>();
            bvoices = Resources.LoadAll("Voices/game/B", typeof(AudioClip)).Cast<AudioClip>().ToArray();
            avoices = Resources.LoadAll("Voices/game/A", typeof(AudioClip)).Cast<AudioClip>().ToArray();
            svoices = Resources.LoadAll("Voices/game/S", typeof(AudioClip)).Cast<AudioClip>().ToArray();
            random = new System.Random();
            voice = GameObject.Find("Voice").GetComponent<AudioSource>();


            comboText = GameObject.Find("ComboText").GetComponent<Text>();
            comboObj = GameObject.Find("Combo").GetComponent<Combo>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void AddScore(Judgement judge)
        {
            var before_score = result.Score;
            if(GameParameter.Instance().gameMode == "demo")
            {
                if (Debug.isDebugBuild)
                {
                    result.AddScore(judge);
                }
            }
            else
            {
                result.AddScore(judge);
            }
            judgeIconScript.JudgeDisp(judge);
            string text = "SCORE:" + result.Score + "\n" +
                          "COMBO:" + result.Combo + "\n" +
                          "MAXCOMBO:" + result.MaxCombo;
            scoreAll.text = text;
            if (before_score < 5000 && result.Score >= 5000)
            {
                voice.clip = bvoices[random.Next(bvoices.Length)];
                voice.Play();
            }
            else if (before_score < 7000 && result.Score >= 7000)
            {
                voice.clip = avoices[random.Next(avoices.Length)];
                voice.Play();
            }
            else if (before_score < 9000 && result.Score >= 9000)
            {
                voice.clip = svoices[random.Next(svoices.Length)];
                voice.Play();
            }
            else if (before_score < 10000 && result.Score == 9000)
            {
            }
            if(result.Combo > 1)
            {
                comboObj.Disp(result.Combo.ToString());
            }
            if (result.Combo == 0)
            {
                comboObj.Hide();
            }
            scoreText.text = result.Score + "/10000";
            if (result.Score < 7000)
            {

                exp_bar_fail.sizeDelta = new Vector2(offset + ((init_width_fail - offset) * result.Score / 7000), exp_bar_fail.sizeDelta.y);
            }
            else
            {
                exp_bar_clear.sizeDelta = new Vector2(offset + ((init_width_clear - offset) * (result.Score - 7000) / 3000), exp_bar_clear.sizeDelta.y);
            }
        }
    }
}