using UnityEngine;
using UnityEngine.UI;

namespace BakuSou
{
    public class TweetButtonHandler : MonoBehaviour
    {

        public GameObject title;
        public GameObject rank;
        public GameObject score;
        public void TwitterButton()
        {
            string title_str = title.GetComponent<Text>().text;
			string rank_str = rank.GetComponent<Rank>().rank;
            string score_str = score.GetComponent<Score>().score.ToString();
            string text = WWW.EscapeURL(string.Format("幕奏-BAKU SOU-で「{0}」をプレイ！SCORE：{1}（{2}ランク）", title_str, score_str, rank_str));
            string url = WWW.EscapeURL("http://www.7fusigi.com");
            string hashtag = WWW.EscapeURL("幕奏");
            string intent = string.Format("https://twitter.com/intent/tweet?text={0}&hashtags={1}&related={2}", text,hashtag, "bakusou_");
            Application.OpenURL(intent);
            Debug.Log("log");
        }
    }
}