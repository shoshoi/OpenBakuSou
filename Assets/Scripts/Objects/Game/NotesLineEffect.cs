using System.Collections.Generic;
using UnityEngine;

namespace BakuSou
{
    public class NotesLineEffect : MonoBehaviour
    {
        int framebunkatu = 3;
        private long frame = 0;
        Renderer rend;
        Shader shader;
        Material material;
        Judgement beforejudge = Judgement.NOJUDGE;
        public Material greatMaterial;
        public Material goodMaterial;
        public Material badMaterial;
        public Material nojudgeMaterial;
        Color defaultColor;
        Color disableColor;
        Color alpha = new Color(0, 0, 0, 0.02f);

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
            rend.material = nojudgeMaterial;
            material = rend.material;
            defaultColor = material.color;
            disableColor = new Color(0, 0, 0, 0);
            material.color = new Color(0, 0, 0, 0);
            float delta_30 = 0.03333333333f * framebunkatu;
            float delta_60 = 0.01666666666f * framebunkatu;
            float delta_120 = 0.00833333333f * framebunkatu;
            float delta_240 = 0.00416666666f * framebunkatu;
            minusColor_30 = new Color(0, 0, 0, defaultColor.a * delta_30 * 1.5f);
            minusColor_60 = new Color(0, 0, 0, defaultColor.a * delta_60 * 1.5f);
            minusColor_120 = new Color(0, 0, 0, defaultColor.a * delta_120 * 1.5f);
            minusColor_240 = new Color(0, 0, 0, defaultColor.a * delta_240 * 1.5f);
            InitColors();
        }

        void Update()
        {
            frame++;
            if (frame % framebunkatu == 0 & material.color.a > 0)
            {
                Color minusColor;
                if(Time.deltaTime > 0.02222222222f)
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
            material.color = defaultColor;

            if(judge != beforejudge)
            {
                Material destroy_mat = material;
                switch (judge)
                {
                    case Judgement.GREAT:
                        rend.material = greatMaterial;
                        break;
                    case Judgement.GOOD:
                        rend.material = goodMaterial;
                        break;
                    case Judgement.BAD:
                        rend.material = badMaterial;
                        break;
                    default:
                        rend.material = nojudgeMaterial;
                        break;
                }
                material = rend.material;
                material.color = GetColor();
                beforejudge = judge;
                DestroyImmediate(destroy_mat);
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
            if(poolIndex < poolSize)
            {
                color =  colorPool[poolIndex];
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