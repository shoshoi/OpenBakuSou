using System;
using System.Collections.Generic;

namespace BakuSou
{
    [Serializable]
    public class SaveDataDTO
    {
        public List<HighScoreDTO> high_scores;
        public SettingDTO setting;
    }
    [Serializable]
    public class HighScoreDTO
    {
        public int id;
        public int score;
        public int max_combo;
        public string rank;
    }
    [Serializable]
    public class SettingDTO
    {
        public string[] keybord;
        public double speed;
        public double adjust;
        public float bgm_volume;
        public float sound_volume;
        public float voice_volume;
    }
    [Serializable]
    public class SortDTO
    {
        public string sort;
        public string[] type;
        public string[] genre;
    }
}