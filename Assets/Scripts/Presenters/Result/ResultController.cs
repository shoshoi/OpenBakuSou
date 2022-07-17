using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BakuSou
{
    public class ResultController : MonoBehaviour
    {
        float waitTime = 0;
        float startTime = 0.2f;
        void Start()
        {
            QualitySettings.SetQualityLevel(0);
        }

        void Update()
        {
                if (Input.GetKey(KeyCode.Return))
                {
                    //GameParameter.Instance().gameMode.Equals("play");
                    GameParameter.Instance().gameMode = "play";

                        FadeManager.FadeOut(1);

                }
        }
    }
}