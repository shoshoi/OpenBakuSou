using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

namespace BakuSou
{
    public class GameManager : MonoBehaviour
    {
        //TODO:クラス名はGameSceneManagerとかのがいい

        // オブジェクト格納変数
        public GameObject scoreBord;
        public Image startPanelImage;
        public Text text;
        public AudioManager audioManager;
        public SoundManager soundManager;
        public VoiceManager voiceManager;
        public Text title;
        public Image jacket;
        public Text title2;
        public Image jacket2;
        AudioClip[] startVoices;
        AudioClip[] endVoices;
        AudioClip toubakuVoice;
        AudioClip failVoice;
        AudioClip clearVoice;
        System.Random random;
        private BakusouMusicData musicData;
        private bool isStarted = false;
        private float waitTime = 0f;
        private float afterTime = 0f;
        private GameObject endPanel;
        private GameObject pausePanel;
        float alfa;    //A値を操作するための変数
        float red, green, blue;    //RGBを操作するための変数


        void Start()
        {
            QualitySettings.SetQualityLevel(0);


            FadeManager.FadeIn();
            // 楽曲データを読み込む
            GameParameter gameParameter = GameParameter.Instance();
            musicData = gameParameter.GetSelectMusicData();
            audioManager = AudioManager.Instance;
            soundManager = SoundManager.Instance;
            voiceManager = VoiceManager.Instance;

            title = GameObject.Find("Title").GetComponent<Text>();
            title.text = musicData.Inf.title;
            title2 = GameObject.Find("Title2").GetComponent<Text>();
            title2.text = musicData.Inf.title;

            jacket = GameObject.Find("JacketImage").GetComponent<Image>();
            jacket.sprite = musicData.GetImage();
            jacket2 = GameObject.Find("JacketImage2").GetComponent<Image>();
            jacket2.sprite = musicData.GetImage();

            startVoices = Resources.LoadAll("Voices/start", typeof(AudioClip)).Cast<AudioClip>().ToArray();
            toubakuVoice = Resources.Load("Voices/toubakumania/start", typeof(AudioClip)) as AudioClip;
            random = new System.Random();
            foreach (var t in startVoices)
            {
                Debug.Log(t.name);
            }

            // オーディオソースの準備
            AudioClip startClip = startVoices[random.Next(startVoices.Length)];
            if (GameParameter.Instance().IsToubakuMania())
            {
                startClip = toubakuVoice;
            }
            voiceManager.SetClip(startClip);
            waitTime = startClip.length;

            audioManager.SetClip(musicData.GetAudioClip());

            // 楽曲を再生（ゲーム開始）する。
            voiceManager.Play();
            startPanelImage = GameObject.Find("StartPanel").GetComponent<Image>();

            red = startPanelImage.color.r;
            green = startPanelImage.color.g;
            blue = startPanelImage.color.b;

            failVoice = Resources.Load("Voices/end/fail", typeof(AudioClip)) as AudioClip;
            clearVoice = Resources.Load("Voices/end/clear", typeof(AudioClip)) as AudioClip;
            endVoices = Resources.LoadAll("Voices/end", typeof(AudioClip)).Cast<AudioClip>().ToArray();
            random = new System.Random();
            foreach (var t in endVoices)
            {
                Debug.Log(t.name);
            }

            endPanel = GameObject.Find("EndPanel");
            endPanel.SetActive(false);

            pausePanel = GameObject.Find("PausePanel");
            pausePanel.SetActive(false);

            if(gameParameter.gameMode != "demo")
            {
                GameObject speedPanel = GameObject.Find("SpeedPanel");
                speedPanel.SetActive(false);
            }

            GameParameter.Instance().gameStatus = "";
        }
        private void Update()
        {
            if(GameParameter.Instance().gameStatus != "pause")
            {
                GameUpdate();
            }
        }
        private void GameUpdate()
        {

            if (isStarted)
            {
                if (!audioManager.IsPlaying())
                {
                    if (afterTime < 3.0f)
                    {
                        afterTime += Time.deltaTime;
                        if (!endPanel.activeSelf)
                        {

                            string text = "";
                            soundManager.SetClip(failVoice);
                            switch (GameParameter.Instance().result.GetRank())
                            {
                                case "C":
                                case "B":
                                    text = "Fail...";
                                    break;
                                case "A":
                                case "S":
                                    soundManager.SetClip(clearVoice);
                                    if (GameParameter.Instance().result.IsFullCombo())
                                    {
                                        text = "FULL COMBO!!";
                                    }
                                    else
                                    {
                                        text = "CLEAR!!";

                                    }
                                    break;
                                case "SS":
                                    soundManager.SetClip(clearVoice);
                                    text = "PERFECT!!!";
                                    break;
                                default:
                                    text = "ERROR";
                                    break;
                            }

                            GameParameter gameParameter = GameParameter.Instance();
                            musicData = gameParameter.GetSelectMusicData();
                            if (musicData.Id == 33)
                            {
                                text = "幕末志士ありがとう";
                            }
                            else
                            {
                                soundManager.Play();
                            }
                            endPanel.SetActive(true);
                            GameObject.Find("Message").GetComponent<Text>().text = text;
                        }
                    }
                    else
                    {
                        DebugData.print();
                        GameParameter gameParameter = GameParameter.Instance();
                        musicData = gameParameter.GetSelectMusicData();
                        if(musicData.Id == 33　&& gameParameter.gameMode == "play")
                        {

                            FadeManager.FadeOut(4);
                        }
                        else
                        {
                            FadeManager.FadeOut(3);

                        }
                    }
                }
            }
            else
            {
                if (!voiceManager.IsPlaying())
                {
                    startPanelImage.color = new Color(0, 0, 0, 0);
                    isStarted = true;
                    audioManager.Play();
                }
                float time = waitTime - voiceManager.GetTime();
                if (time < 1.0f)
                {
                    startPanelImage.color = new Color(red, green, blue, 0.5f * (time / 1.0f));
                    jacket2.color = new Color(255, 255, 255, 1f * (time / 1.0f));
                    title2.color = new Color(255, 255, 255, 1f * (time / 1.0f));
                }
            }
        }
        public void GamePause()
        {
            GameParameter.Instance().gameStatus = "pause";
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            audioManager.Pause();
        }
        public void GameUnPause()
        {
            GameParameter.Instance().gameStatus = "";
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
            audioManager.UnPause();
        }
    }
}