using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BakuSou
{
    public class TopController : MonoBehaviour
    {
        void Start()
        {
            // クラスのNCMBObjectを作成
            QualitySettings.SetQualityLevel(0);
            SettingDTO setting = SaveManager.Instance().GetSaveData().setting;
            AudioConfiguration ac = AudioSettings.GetConfiguration();
            if (setting.adjust >= 512)
            {
                ac.dspBufferSize = (int)setting.adjust;
                AudioSettings.Reset(ac);

                GameObject bgm = GameObject.Find("AudioManager");
                var clip = bgm.GetComponent<AudioSource>();
                clip.Play();
                Debug.Log("buf : " + ac.dspBufferSize);
            }
            else
            {
                Debug.Log("buf : " + ac.dspBufferSize);
            }
        }

        void Update()
        {
                if (Input.GetKey(KeyCode.Return))
                {
                    GameObject enter = GameObject.Find("enter");
                    var clip = enter.GetComponent<AudioSource>();
                    if (!clip.isPlaying)
                    {
                        clip.Play();
                    }
                    FadeManager.FadeOut(1);
                }

        }
    }
}