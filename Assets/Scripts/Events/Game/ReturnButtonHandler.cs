using UnityEngine;
using UnityEngine.SceneManagement;

namespace BakuSou
{
    public class ReturnButtonHandler : MonoBehaviour
    {

        public void ReturnButton()
        {
            Time.timeScale = 1f;
            FadeManager.FadeOut(1);
        }
        public void RetryButton()
        {
            GameParameter.Instance().InitKeyLog();
            Time.timeScale = 1f;
            FadeManager.FadeOut(2);
        }
        public void UnPauseButton()
        {
            Time.timeScale = 1f;
            GameObject.Find("GameManager").GetComponent<GameManager>().GameUnPause();
        }
    }
}