using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace BakuSou
{
    public class MenuController : MonoBehaviour
    {
        private readonly string[] keybord = new string[] { "z", "x", "c", "v", "b" };
        private FancyScrollView.MenuScrollViewScene viewScript;
        float waitTime = 0;
        float startTime = 0.2f;
        AudioSource submit;
        AudioManager preview;
        bool isActive = true;
        AudioClip[] voices;
        AudioClip toubakuVoice;
        System.Random random;
        public bool onClick = false;
        public string mode = "play";
        void Start()
        {
            QualitySettings.SetQualityLevel(0);


            var viewScene = GameObject.Find("MainCanvas");
            viewScript = viewScene.GetComponent<FancyScrollView.MenuScrollViewScene>();
            GameObject selecton = GameObject.Find("submiton");
            GameObject pre = GameObject.Find("preview");
            submit = selecton.GetComponent<AudioSource>();
            preview = pre.GetComponent<AudioManager>();
            preview.Play();

            voices = Resources.LoadAll("Voices/enter", typeof(AudioClip)).Cast<AudioClip>().ToArray();
            toubakuVoice = Resources.Load("Voices/toubakumania/enter", typeof(AudioClip)) as AudioClip;
            random = new System.Random();
            foreach (var t in voices)
            {
                Debug.Log(t.name);
            }
        }

        void Update()
        {
            bool isKeyDown = false;
            if (waitTime <= 0 && isActive)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    viewScript.HandlePrevButton();
                    isKeyDown = true;
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    viewScript.HandleNextButton();
                    isKeyDown = true;
                }
                else if (Input.GetKey(KeyCode.Return) || onClick)
                {
                    Debug.Log("start");
                    if (!submit.isPlaying)
                    {
                        if (GameParameter.Instance().IsToubakuMania())
                        {
                            submit.clip = toubakuVoice;
                        }
                        else
                        {
                            submit.clip = voices[random.Next(voices.Length)];

                        }
                        preview.itiji = 0.5f;
                        submit.Play();
                    }
                    isKeyDown = true;
                    isActive = false;
                }

                if (isKeyDown)
                {
                    Debug.Log(waitTime);
                    waitTime = startTime;
                }
                else
                {
                    waitTime = 0;
                }
            }
            else
            {
                Debug.Log(waitTime);
                waitTime -= Time.deltaTime;
            }
            if (!isActive && (submit.time > submit.clip.length - 0.5f))
            {
                FadeManager.FadeOut(2);
            }
        }
        private void OnEnable()
        {
            isActive = true;
        }
    }
}