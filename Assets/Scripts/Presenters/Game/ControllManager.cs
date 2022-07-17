using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BakuSou
{
    public class ControllManager : MonoBehaviour
    {
        private string[] keybord;
        public GameObject clapObject;
        private AudioSource clap;
        private NotesManager notesManager;
        private AudioManager audioManager;

        private NotesLineEffect[] notesLineEffects;
        private PushNeonEffect[] pushNeonEffects;
        public GameObject line1;
        public GameObject line2;
        public GameObject line3;
        public GameObject line4;
        public GameObject line5;
        public GameObject push_neon1;
        public GameObject push_neon2;
        public GameObject push_neon3;
        public GameObject push_neon4;
        public GameObject push_neon5;
        public GameObject label1;
        public GameObject label2;
        public GameObject label3;
        public GameObject label4;
        public GameObject label5;

        public GameObject demoPanel;

        GameParameter gameParameter;
        private int previewCount = 0;
        private int[] keyArray;
        private double[] timingArray;
        void Start()
        {
            gameParameter = GameParameter.Instance();
            audioManager = AudioManager.Instance;
            keyArray = gameParameter.GetSelectMusicData().KeyArray;
            timingArray = gameParameter.GetSelectMusicData().TimingArray;
            clapObject = GameObject.Find("Clap");
            clap = clapObject.GetComponent<AudioSource>();

            keybord = SaveManager.Instance().GetSaveData().setting.keybord;
            label1.GetComponent<Text>().text = keybord[0].ToUpper();
            label2.GetComponent<Text>().text = keybord[1].ToUpper();
            label3.GetComponent<Text>().text = keybord[2].ToUpper();
            label4.GetComponent<Text>().text = keybord[3].ToUpper();
            label5.GetComponent<Text>().text = keybord[4].ToUpper();
            notesManager = NotesManager.Instance;
            notesLineEffects = new NotesLineEffect[5];
            notesLineEffects[0] = line1.GetComponent<NotesLineEffect>();
            notesLineEffects[1] = line2.GetComponent<NotesLineEffect>();
            notesLineEffects[2] = line3.GetComponent<NotesLineEffect>();
            notesLineEffects[3] = line4.GetComponent<NotesLineEffect>();
            notesLineEffects[4] = line5.GetComponent<NotesLineEffect>();

            pushNeonEffects = new PushNeonEffect[5];
            pushNeonEffects[0] = push_neon1.GetComponent<PushNeonEffect>();
            pushNeonEffects[1] = push_neon2.GetComponent<PushNeonEffect>();
            pushNeonEffects[2] = push_neon3.GetComponent<PushNeonEffect>();
            pushNeonEffects[3] = push_neon4.GetComponent<PushNeonEffect>();
            pushNeonEffects[4] = push_neon5.GetComponent<PushNeonEffect>();
            if (gameParameter.gameMode != "demo")
            {
                demoPanel.SetActive(false);
            }
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(gameParameter.gameStatus == "pause")
                {
                    GameObject.Find("GameManager").GetComponent<GameManager>().GameUnPause();
                }
                else
                {
                    GameObject.Find("GameManager").GetComponent<GameManager>().GamePause();
                }
                //FadeManager.FadeOut(1);
            }

            if(gameParameter.gameStatus != "pause")
            {
                ControllUpdate();
            }
        }

        void ControllUpdate()
        {

            bool isKeyDown = false;
            Debug.Log("gameMode" + gameParameter.gameMode);
            // キー押下時、ノートをシークする
            Judgement[] judges = { Judgement.NOJUDGE, Judgement.NOJUDGE, Judgement.NOJUDGE, Judgement.NOJUDGE, Judgement.NOJUDGE };
            if (gameParameter.gameMode == "play")
            {
                for (int i = 0; i < keybord.Length; i++)
                {
                    if (Input.GetKeyDown(keybord[i]))
                    {
                        gameParameter.SetKeyLog(audioManager.GetTime(), i);
                        isKeyDown = true;
                        judges[i] = notesManager.NoteSeek(i);
                    }
                }
            }
            else if (gameParameter.gameMode == "replay")
            {
                while (previewCount < gameParameter.keyLog.Count && gameParameter.keyLog[previewCount]["time"] <= audioManager.GetTime())
                {
                    isKeyDown = true;
                    int key = (int)gameParameter.keyLog[previewCount]["key"];
                    judges[key] = notesManager.NoteSeek(key);
                    notesLineEffects[key].Play(judges[key]);
                    pushNeonEffects[key].Play(judges[key]);
                    previewCount++;
                }

            }
            else
            {
                while (previewCount < timingArray.Length && timingArray[previewCount] <= audioManager.GetTime())
                {
                    isKeyDown = true;
                    int key = keyArray[previewCount];
                    judges[key] = notesManager.NoteSeek(key);
                    notesLineEffects[key].Play(judges[key]);
                    pushNeonEffects[key].Play(judges[key]);
                    previewCount++;
                }
            }
            // キー押下時、効果音を再生する
            if (isKeyDown)
            {
                if (clap.time > 0)
                {
                    clap.Stop();
                }
                clap.Play();
            }
            // 押下したキーに対応するノーツエフェクトを再生する
            if (gameParameter.gameMode == "play")
            {
                for (int i = 0; i < keybord.Length; i++)
                {
                    if (Input.GetKeyDown(keybord[i]))
                    {
                        notesLineEffects[i].Play(judges[i]);
                        pushNeonEffects[i].Play(judges[i]);
                    }
                }
            }
        }
    }
}