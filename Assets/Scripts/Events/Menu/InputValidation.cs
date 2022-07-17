using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BakuSou
{
    public class InputValidation : MonoBehaviour
    {
        public int default_key_array_index = -1;
        private InputField inputField1;
        private string before_string;

        void Start()
        {
            inputField1 = GetComponent<InputField>();
            if (default_key_array_index >= 0)
            {
                SettingDTO setting = SaveManager.Instance().GetSaveData().setting;
                inputField1.text = setting.keybord[default_key_array_index];
                before_string = setting.keybord[default_key_array_index];
            }
        }

        // このメソッドをOn Value Changeに指定すると文字変更があった時に呼び出される
        public void OnSpeedChange()
        {
            if (inputField1 == null) return;
            double i = 0;
            if (inputField1.text.Equals(""))
            {
                i = 1.0;
            }
            else if (inputField1.text.Length == 2 && inputField1.text.Substring(1, 1).Equals("."))
            {
                return;
            }
            else if (double.TryParse(inputField1.text, out i))
            {
                if (i > 8.0)
                {
                    i = 8.0;
                }
                if (i < 0.5)
                {
                    i = 0.5;
                }
                if (inputField1.text.Length == 3 && i.ToString().Length == 1)
                {
                    inputField1.text = i.ToString() + ".0";
                }
                else
                {
                    inputField1.text = i.ToString();
                }
            }
        }
        public void OnAdjustChange()
        {
            if (inputField1 == null) return;
            double i = 0;
            if (inputField1.text.Equals(""))
            {
                i = 0.0;
            }
            else if (inputField1.text.Length == 2 && inputField1.text.Substring(1, 1).Equals("."))
            {
                return;
            }
            else if (double.TryParse(inputField1.text, out i))
            {
                if (i > 5.0)
                {
                    i = 5.0;
                }
                if (i < 0)
                {
                    i = 0.0;
                }
                if (inputField1.text.Length == 3 && i.ToString().Length == 1)
                {
                    inputField1.text = i.ToString() + ".0";
                }
                else
                {
                    inputField1.text = i.ToString();
                }
            }
        }
        public void OnKeyChange()
        {
            if (inputField1 == null) return;
            string str = inputField1.text.ToUpper();
            string str2 = before_string;
            if (inputField1.text.Length > 1)
            {
                int num = str.IndexOf(str2);
                if (num == 0) num = 1;
                str = str.Substring(num, 1);
            }
            inputField1.text = str;
            before_string = str;
        }

        // このメソッドをEnd Editに指定すると入力が確定した時に呼び出される
        public void EndSpeedEdit()
        {
            if (inputField1 == null) return;
            double i;
            if (double.TryParse(inputField1.text, out i))
            {
                if (i > 8.0)
                {
                    i = 8.0;
                }
                if (i < 0.5)
                {
                    i = 0.5;
                }
            }
            else
            {
                i = 1;
            }
            inputField1.text = i.ToString();
        }
        public void EndAdjustEdit()
        {
            if (inputField1 == null) return;
            double i;
            if (double.TryParse(inputField1.text, out i))
            {
                if (i > 5.0)
                {
                    i = 5.0;
                }
                if (i < 0)
                {
                    i = 0.0;
                }
            }
            else
            {
                i = 1;
            }
            inputField1.text = i.ToString();
        }
    }
}