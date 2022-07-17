using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

namespace BakuSou
{
    public class Result : MonoBehaviour
    {
        public GameObject image;
        public GameObject title;
        public GameObject describe;
        public GameObject rank;
        public GameObject score;
        public GameObject combo;
        public GameObject max_combo;
        public GameObject great;
        public GameObject good;
        public GameObject bad;
        public GameObject late;
        public GameObject newrecord;
        AudioClip[] voices;
        AudioSource voice;
        AudioSource bgm;
        System.Random random;

        // Use this for initialization
        void Start()
        {
            QualitySettings.SetQualityLevel(0);
            FadeManager.FadeIn();

            BakusouMusicData musicData = GameParameter.Instance().GetSelectMusicData();
            ResultData result = GameParameter.Instance().result;

            image.GetComponent<Image>().sprite = musicData.GetImage();
            title.GetComponent<Text>().text = musicData.Inf.title;
            describe.GetComponent<Text>().text = musicData.GetDescribe();
            string rankString="";
            if(GameParameter.Instance().gameMode == "demo" || result == null)
            {
                result = new ResultData(100);
            }
            int result_score = result.Score;
            if(result_score < 5000)
            {
                rankString = "C";
                voices = Resources.LoadAll("Voices/fail", typeof(AudioClip)).Cast<AudioClip>().ToArray();
            }
            else if(result_score < 7000)
            {
                rankString = "B";
                voices = Resources.LoadAll("Voices/fail", typeof(AudioClip)).Cast<AudioClip>().ToArray();
            }
            else if (result_score < 9000)
            {
                rankString = "A";
                voices = Resources.LoadAll("Voices/clear", typeof(AudioClip)).Cast<AudioClip>().ToArray();
            }
            else if (result_score < 10000)
            {
                rankString = "S";
                voices = Resources.LoadAll("Voices/clear", typeof(AudioClip)).Cast<AudioClip>().ToArray();
            }
            else if (result_score == 10000)
            {
                rankString = "SS";
                voices = Resources.LoadAll("Voices/clear", typeof(AudioClip)).Cast<AudioClip>().ToArray();
            }
            rank.GetComponent<Rank>().rank = rankString;
            score.GetComponent<Score>().score = result.Score;
            combo.GetComponent<Text>().text = String.Format("{0:D4}", result.Combo);
            max_combo.GetComponent<Text>().text = String.Format("{0:D4}", result.MaxCombo);
            great.GetComponent<Text>().text = String.Format("{0:D4}", result.Great);
            good.GetComponent<Text>().text = String.Format("{0:D4}", result.Good);
            bad.GetComponent<Text>().text = String.Format("{0:D4}", result.Bad);
            late.GetComponent<Text>().text = String.Format("{0:D4}", result.Late);

            HighScoreDTO highScore = new HighScoreDTO();
            bool isNewRecord = SaveManager.Instance().SetHighScore(musicData.Id,result);
            newrecord.SetActive(isNewRecord);
            SaveManager.Instance().Save();

            random = new System.Random();
            voice = GameObject.Find("Voice").GetComponent<AudioSource>();
            voice.clip = voices[random.Next(voices.Length)];
            voice.Play();

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}