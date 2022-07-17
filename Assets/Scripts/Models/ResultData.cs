using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BakuSou
{
    public class ResultData
    {
        bool dummy;
        public int Score
        {
            get
            {
                double clearCount = Great + Good * 0.5 + Bad * 0.1;
                return (int)((double)10000 * (clearCount / MaxCount));
            }
        }
        public int HighScore { get; private set; }
        public int Combo { get; private set; }
        public int MaxCombo { get; private set; }
        public int Great { get; private set; }
        public int Good { get; private set; }
        public int Bad { get; private set; }
        public int Late { get; private set; }
        public int MaxCount { get; private set; }

        public ResultData(int max_count)
        {
            this.MaxCount = max_count;
        }
        public bool IsFullCombo()
        {
            return this.MaxCount == MaxCombo;
        }
        public void AddScore(Judgement judge)
        {
            switch (judge)
            {
                case Judgement.GREAT:
                    Great++;
                    break;
                case Judgement.GOOD:
                    Good++;
                    break;
                case Judgement.BAD:
                    Bad++;
                    break;
                case Judgement.LATE:
                    Late++;
                    break;
                default:
                    break;
            }
            ComboCount(judge);
        }
        private void ComboCount(Judgement judge)
        {
            if (judge == Judgement.GREAT || judge == Judgement.GOOD)
            {
                Combo++;
                if (Combo > MaxCombo )
                {
                    MaxCombo = Combo;
                }
            }
            else
            {
                Combo = 0;
            }
        }
        public string GetRank()
        {
            string rankString = "";
            if (Score < 5000)
            {
                rankString = "C";
            }
            else if (Score < 7000)
            {
                rankString = "B";
            }
            else if (Score < 9000)
            {
                rankString = "A";
            }
            else if (Score < 10000)
            {
                rankString = "S";
            }
            else if (Score == 10000)
            {
                rankString = "SS";
            }
            return rankString;
        }
    }
}