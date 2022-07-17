using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BakuSou
{
    public class StartButton : MonoBehaviour
    {
        public void StartButtonClick()
        {
            MenuController menu = GameObject.Find("MenuController").GetComponent<MenuController>();
            menu.onClick = true;
        }
    
    }
}