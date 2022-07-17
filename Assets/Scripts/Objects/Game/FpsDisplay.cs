using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BakuSou
{
    public class FpsDisplay : MonoBehaviour
    {

        // 変数
        int frameCount;
        float prevTime;
        float fps;
        Text text;

        // 初期化処理
        void Start()
        {
            frameCount = 0;
            prevTime = 0.0f;
            text = GetComponent<Text>();
        }
        // 更新処理
        void Update()
        {
            frameCount++;
            float time = Time.realtimeSinceStartup - prevTime;

            if (time >= 0.5f)
            {
                fps = frameCount / time;
                text.text = "FPS:" + (Math.Round(fps * 10.0f) / 10.0f);

                frameCount = 0;
                prevTime = Time.realtimeSinceStartup;
            }
        }
    }
}