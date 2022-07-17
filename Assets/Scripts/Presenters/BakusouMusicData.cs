using UnityEngine;
using UnityEngine.UI;

namespace BakuSou
{
    public class BakusouMusicData
    {
        public int Id { get; set; }         public string Path { get; set; }         public MusicInf Inf { get; set; }         public int Bpm { get; set; }         public double[] TimingArray { get; set; }         public int[] KeyArray { get; set; }

        private AudioClip aClip;
        private AudioClip preview;
        private Sprite sprite;

        /// <summary>         /// 楽曲の音源を、AudioClipで返す         /// </summary>         /// <returns>AudioClip</returns>         public AudioClip GetAudioClip()         {
            if (aClip != null) return aClip;
                         if (GameParameter.Instance().localResources == null)             {                 aClip = Resources.Load<AudioClip>("Music/" + Path + "/music");             }             else             {                 GameObject gameObject = GameObject.Find("LocalResources");                 LocalResourcesManager localResources = GameParameter.Instance().localResources;                 aClip = (AudioClip)localResources.GetLoadFile(Path + "/music");             }             return aClip;         }
        /// <summary>
        /// 楽曲のプレビュー音源を、AudioClipで返す
        /// </summary>
        /// <returns>AudioClip</returns>
        public AudioClip GetPreviewAudioClip()
        {
            if (preview != null) return preview;

            if (GameParameter.Instance().localResources == null)
            {
                preview = Resources.Load<AudioClip>("Music/" + Path + "/preview");
            }
            else
            {
                GameObject gameObject = GameObject.Find("LocalResources");
                LocalResourcesManager localResources = GameParameter.Instance().localResources;
                preview = (AudioClip)localResources.GetLoadFile(Path + "/preview");
            }
            return preview;
        }
        /// <summary>         /// 楽曲のジャケットイメージを返す         /// </summary>         /// <returns>Sprite</returns>         public Sprite GetImage()         {
            if (sprite != null) return sprite;             Texture2D texture = null;              if (GameParameter.Instance().localResources == null)             {                 texture = Resources.Load<Texture>("Music/" + Path + "/image") as Texture2D;                 if (texture != null)                 {                     sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);                 }             }             else             {                 LocalResourcesManager localResources = GameParameter.Instance().localResources;                 texture = (UnityEngine.Texture)localResources.GetLoadFile(Path + "/image") as Texture2D;
                if (texture != null)
                {
                    sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                }             }             return sprite;         }         public string GetDescribe()         {
            //return "Artist:" + Inf.artist + "  Arranger:" + Inf.arranger + "  Author:" + Inf.author;
            return "Artist:" + Inf.artist + "  Arranger:" + Inf.arranger;         }
        public string GetHighScore()
        {
            return "HighScore:" + SaveManager.Instance().GetHighScore(Id).score;
        }
        public string GetMaxCombo()
        {
            return "MaxCombo:" + SaveManager.Instance().GetHighScore(Id).max_combo;
        }     } } 