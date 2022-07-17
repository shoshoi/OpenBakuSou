using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BakuSou
{
    public class RetryButtonHandler : MonoBehaviour
    {

        public void RetryButton()
        {
            GameParameter.Instance().gameMode = "play";
            GameParameter.Instance().InitKeyLog();
            FadeManager.FadeOut(2);
        }
    }
}
