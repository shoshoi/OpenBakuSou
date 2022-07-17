using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace BakuSou
{
    public class ExitButtonHundler : MonoBehaviour
    {

        public void EixtButton()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      Application.Quit();
#endif
        }
    }
}