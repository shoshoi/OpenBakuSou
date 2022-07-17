using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BakuSou
{
    public class StartButtonHandler : MonoBehaviour
    {

        public void StartButton()
        {
            FadeManager.FadeOut(1);
        }
    }
}