using UnityEngine;

namespace BakuSou
{
    public class Note : MonoBehaviour
    {
        // 譜面情報を保持する変数
        private double timing;
        private int line;
        private float x;

        // ノートの位置を保持する変数
        // TODO:publicプロパティにアクセサ追加
        public float fallDist;
        public float fallDistOffset;
        public double fallTime;
        public double fallSpeed;
        private double createTime = 0;
        private Vector3 defaultPosition;

        void Start()
        {
            defaultPosition = new Vector3(0, -2, -100);
        }
        void Update()
        {
            if (gameObject.activeSelf)
            {
                // 現在の再生時間から、現在位置を算出する。
                float nowDist = (float)(fallDist / fallSpeed * (timing - AudioManager.Instance.GetTime()));

                if (Judge() == Judgement.LATE)
                {
                    // BADの時間を超えたらボタンを押さなくても判定する
                    NoteOn();
                }

                // ノートを移動する
                if (!float.IsNaN(nowDist))
                {
                    Vector3 v = transform.position;
                    v.x = x;
                    v.y = 0.02f;
                    v.z = nowDist + fallDistOffset;
                    transform.position = v;
                }
            }
        }
        public int GetLine()
        {
            return line;
        }
        public double GetTiming()
        {
            return timing;
        }
        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
        public bool GetActive()
        {
            return gameObject.activeSelf;
        }
        public void InitNote()
        {
            Hide();
        }
        public void Show(double timing, int line)
        {
            this.timing = timing;
            this.line = line;
            createTime = timing - fallSpeed;

            double width = Constants.NOTEO_OBJECT_WIDTH;
            this.x = (float)(width * -2 + width * line);
            Vector3 v = transform.position;
            v.x = x;
            v.y = 0.02f;
            v.z = -100;
            transform.position = v;
        }
        public void Hide()
        {
            transform.position = defaultPosition;
            gameObject.SetActive(false);
        }
        public Judgement NoteOn()
        {
            Judgement judge = Judge();

            if (judge != Judgement.EARLY)
            {
                float audio_time = AudioManager.Instance.GetTime() - Constants.JUDGE_OFFSET_TIME;
                DebugData.Add((float)timing - audio_time);
                Hide();
            }
            return judge;
        }
        public Judgement Judge()
        {
            Judgement judge = Judgement.EARLY;
            float audio_time = AudioManager.Instance.GetTime() + Constants.JUDGE_OFFSET_TIME;
            if (audio_time > timing - Constants.JUDGE_GREAT_TIME && audio_time < timing + Constants.JUDGE_GREAT_TIME)
            {
                judge = Judgement.GREAT;
            }
            else if (audio_time > timing - Constants.JUDGE_GOOD_TIME && audio_time < timing + Constants.JUDGE_GOOD_TIME)
            {
                judge = Judgement.GOOD;
            }
            else if (audio_time > timing - Constants.JUDGE_BAD_TIME && audio_time < timing + Constants.JUDGE_BAD_TIME)
            {
                judge = Judgement.BAD;
            }
            else if (audio_time <= timing + Constants.JUDGE_GREAT_TIME)
            {
                judge = Judgement.EARLY;
            }
            else if (audio_time >= timing + Constants.JUDGE_BAD_TIME)
            {
                judge = Judgement.LATE;
            }
            return judge;
        }
    }
}