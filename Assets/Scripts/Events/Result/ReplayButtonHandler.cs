using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BakuSou
{
    public class ReplayButtonHandler : MonoBehaviour
    {

        public void ReplayButton()
        {
            if (GameParameter.Instance().gameMode == "demo")
            {
                GameParameter.Instance().gameMode = "demo";
            }
            else
            {
                GameParameter.Instance().gameMode = "replay";
            }
            FadeManager.FadeOut(2);
        }
    }
}
