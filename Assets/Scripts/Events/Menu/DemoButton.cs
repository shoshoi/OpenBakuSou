using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BakuSou
{
    public class DemoButton : MonoBehaviour
    {
        public void DemoButtonClick()
        {
            MenuController menu = GameObject.Find("MenuController").GetComponent<MenuController>();
            menu.onClick = true;
            GameParameter.Instance().gameMode = "demo";
        }

    }
}