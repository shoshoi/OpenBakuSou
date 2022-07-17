using UnityEditor;
using UnityEngine;

namespace BakuSou
{
    public class ButtonManager : MonoBehaviour
    {
        public void OpenTop()
        {
            FadeManager.FadeOut(0);
        }
        public void OpenMenu()
        {
            FadeManager.FadeOut(1);
        }
        public void OpenGame()
        {
            FadeManager.FadeOut(2);
        }
        public void OpenResult()
        {
            FadeManager.FadeOut(3);
        }
        public void EixtGame()
        {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
            Application.Quit();
        #endif
        }
    }
}