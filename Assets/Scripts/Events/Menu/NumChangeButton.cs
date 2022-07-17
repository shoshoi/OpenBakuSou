using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BakuSou
{
    public class NumChangeButton : MonoBehaviour
    {
        public GameObject obj;
        public double num = 0.5;
        InputField field;
        // Use this for initialization
        void Start()
        {
            field = obj.GetComponent<InputField>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Plus()
        {
            double val = double.Parse(field.text);
            val += num;
            field.text = val.ToString();
        }
        public void Minus()
        {
            double val = double.Parse(field.text);
            val -= num;
            field.text = val.ToString();
        }
        public void Multiple()
        {
            double val = double.Parse(field.text);
            val *= 2;
            if(val > 8)
            {
                val = 8;
            }
            field.text = val.ToString();
        }
        public void Divide()
        {
            double val = double.Parse(field.text);
            val /= 2;
            if (val < 0.5)
            {
                val = 0.5;
            }
            field.text = val.ToString();
        }

    }
}