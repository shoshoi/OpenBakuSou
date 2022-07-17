using System.Collections.Generic;
using UnityEngine;

namespace BakuSou
{
    public class PushNeonEffect : MonoBehaviour
    {
        int framebunkatu = 2;
        long frame = 0;
        Renderer rend;
        Material material;
        Shader shader;
        Color defaultColor;
        Color disableColor;
        Color alpha = new Color(0, 0, 0, 0.04f);
        float waitTime = 0f;

        //カラープール
        private List<Color> colorPool;
        private readonly int poolSize = 1000;
        private int poolIndex = 0;

        private Color minusColor_30;
        private Color minusColor_60;
        private Color minusColor_120;
        private Color minusColor_240;

        void Start()
        {
            rend = GetComponent<Renderer>();
            shader = GetComponent<Shader>();
            defaultColor = rend.material.color;
            material = rend.material;
            material.color = new Color(0, 0, 0, 0);
            disableColor = new Color(0, 0, 0, 0);
            float delta_30 = 0.03333333333f * framebunkatu;
            float delta_60 = 0.01666666666f * framebunkatu;
            float delta_120 = 0.00833333333f * framebunkatu;
            float delta_240 = 0.00416666666f * framebunkatu;
            minusColor_30 = new Color(0, 0, 0, defaultColor.a * delta_30 * 4f);
            minusColor_60 = new Color(0, 0, 0, defaultColor.a * delta_60 * 4f);
            minusColor_120 = new Color(0, 0, 0, defaultColor.a * delta_120 * 4f);
            minusColor_240 = new Color(0, 0, 0, defaultColor.a * delta_240 * 4f);
            InitColors();
        }

        void Update()
        {
            frame++;
            if(frame % framebunkatu == 0 & waitTime > 0f)
            {
                waitTime -= Time.deltaTime;
            }
            else if (material.color.a > 0)
            {
                Color minusColor;
                if (Time.deltaTime > 0.02222222222f)
                {
                    minusColor = minusColor_30;
                }
                else if (Time.deltaTime > 0.01111111111f)
                {
                    minusColor = minusColor_60;
                }
                else if (Time.deltaTime > 0.00555555555f)
                {
                    minusColor = minusColor_120;
                }
                else
                {
                    minusColor = minusColor_240;
                }

                material.color -= minusColor;

                if (material.color.a <= 0)
                {
                    material.color = disableColor;
                }
            }

        }
        public void Play(Judgement judge)
        {
            if (judge == Judgement.GREAT)
            {
                waitTime = 0.1f;
                material.color = GetColor();
            }
        }
        void InitColors()
        {
            poolIndex = 0;

            colorPool = new List<Color>();

            for (var i = 0; i < poolSize; i++)
            {
                Color color = new Color(defaultColor.r, defaultColor.g, defaultColor.b, defaultColor.a);
                colorPool.Add(color);
            }
        }
        Color GetColor()
        {
            Color color;
            if (poolIndex < poolSize)
            {
                color = colorPool[poolIndex];
                poolIndex++;
            }
            else
            {
                color = new Color(defaultColor.r, defaultColor.g, defaultColor.b, defaultColor.a);
            }
            return color;
        }
    }
}