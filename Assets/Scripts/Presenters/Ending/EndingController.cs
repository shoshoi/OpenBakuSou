using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BakuSou
{ 
    public class EndingController : MonoBehaviour
    {
        private float endingtime;
        public GameObject rank;
        public GameObject ranktext;
        public GameObject sai;
        public GameObject saka;
        // Start is called before the first frame update
        void Start()
        {
            QualitySettings.SetQualityLevel(0);
            FadeManager.FadeIn();
            ResultData result = GameParameter.Instance().result;
            if (GameParameter.Instance().gameMode == "demo" || result == null)
            {
                result = new ResultData(100);
            }
            BakusouMusicData musicData = GameParameter.Instance().GetSelectMusicData();
            int sum = 0;
            foreach (BakusouMusicData data in GameParameter.Instance().musicDatas)
            {
                if (data.Id != 33)
                {
                    Debug.Log(data.Id + ":" + SaveManager.Instance().GetHighScore(data.Id).score);
                    sum += SaveManager.Instance().GetHighScore(data.Id).score;
                }
            }
            int lastHighScore = SaveManager.Instance().GetHighScore(musicData.Id).score;
            string rankString = "";
            if (result.Score > lastHighScore)
            {
                sum += result.Score;
            }
            else
            {
                sum += lastHighScore;
            }
            int result_score = sum / GameParameter.Instance().musicDatas.Count;
            if (result_score < 5000)
            {
                rankString = "C";
            }
            else if (result_score < 7000)
            {
                rankString = "B";
            }
            else if (result_score < 9000)
            {
                rankString = "A";
            }
            else if (result_score < 10000)
            {
                rankString = "S";
            }
            else if (result_score == 10000)
            {
                rankString = "SS";
            }

            rank.GetComponent<Rank>().rank = rankString;
            ranktext.GetComponent<Text>().text = "Player Rank " + rankString + " (AVERAGE:" + result_score + ")";
            sai.GetComponent<EndingCharacter>().score = result_score;
            saka.GetComponent<EndingCharacter>().score = result_score;

        }

        // Update is called once per frame
        void Update()
        {
            endingtime += Time.deltaTime;
            if(endingtime > 12.0f)
            {
                FadeManager.FadeOut(3);

            }
            if (Input.GetKey(KeyCode.Return))
            {
                FadeManager.FadeOut(3);
            }

        }
    }
}