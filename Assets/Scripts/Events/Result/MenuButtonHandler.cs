using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BakuSou
{
    public class MenuButtonHandler : MonoBehaviour
    {

        public void StartButton()
        {
            GameParameter.Instance().gameMode = "play";

                FadeManager.FadeOut(1);

        }
    }
}