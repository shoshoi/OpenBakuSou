using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BakuSou
{
    public sealed class SaveManager
    {
        private static SaveManager _singleInstance = new SaveManager();
        private string saveDataPath = Application.persistentDataPath + "/";
        private readonly string saveDataFileName = "save.bakusou";
        private readonly string saveDataFileName_debug = "save_debug.bakusou";
        private SaveDataDTO saveData;

        public static SaveManager Instance()
        {
            return _singleInstance;
        }
        private SaveManager()
        {
            saveDataPath = Application.persistentDataPath + "/";
            saveDataPath += Debug.isDebugBuild? saveDataFileName_debug : saveDataFileName;
            Debug.Log(saveDataPath);

            LoadSaveData();
        }
        public void LoadSaveData()
        {
            if (System.IO.File.Exists(saveDataPath))
            {
                SaveDataDTO obj = BinaryUtil.Deserialize<SaveDataDTO>(saveDataPath);
                if (obj != null)
                {
                    if (Validate(obj))
                    {
                        saveData = obj;
                    }
                }
            }
            if (saveData == null)
            {
                saveData = new SaveDataDTO();
                saveData.high_scores = new List<HighScoreDTO>();
                saveData.setting = new SettingDTO();

                saveData.setting.adjust = 0.0;
                saveData.setting.speed = 1.0;
                saveData.setting.keybord = new string[] { "z", "x", "c", "v", "b" };
                saveData.setting.bgm_volume = 0.8f;
                saveData.setting.sound_volume = 0.8f;
                saveData.setting.voice_volume = 0.8f;
            }
            for (int i = 0; i < saveData.high_scores.Count; i++)
            {

                Debug.Log(saveData.high_scores[i].id);
                Debug.Log(saveData.high_scores[i].score);
                Debug.Log(saveData.high_scores[i].max_combo);
            }
        }
        public SaveDataDTO GetSaveData()
        {
            return saveData;
        }
        public void print()
        {
            for (int i = 0; i < saveData.high_scores.Count; i++)
            {
                Debug.Log("----------------------------");
                Debug.Log("id:" + saveData.high_scores[i].id);
                Debug.Log("score:" + saveData.high_scores[i].score);
                Debug.Log("combo:" + saveData.high_scores[i].max_combo);
            }
        }
        public bool SetHighScore(int id,ResultData result)
        {
            bool changed = false;
            HighScoreDTO highScore = GetHighScore(id);
            if (result.MaxCombo > highScore.max_combo)
            {
                highScore.max_combo = result.MaxCombo;
                changed = true;
            }
            if (result.Score > highScore.score)
            {
                highScore.score = result.Score;
                changed = true;
            }
            
            return changed;
        }
        public HighScoreDTO GetHighScore(int id)
        {
            for (int i = 0; i < saveData.high_scores.Count; i++)
            {
                if (saveData.high_scores[i].id == id)
                {
                    return saveData.high_scores[i];
                }
            }
            HighScoreDTO highScore = new HighScoreDTO();
            highScore.id = id;
            saveData.high_scores.Add(highScore);
            return highScore;
        }
        public void Save()
        {
            BinaryUtil.Seialize<SaveDataDTO>(saveDataPath,saveData);
            Debug.Log(saveDataPath);
        }
        private bool Validate(SaveDataDTO save_data) 
        {
            for (int i = 0; i < 0;i++)
            {
                //HighScoreDTO high_score = saveData.high_scores[i];
                //high_score.id;
                //high_score.max_combo;
                //high_score.score;
            }
            return true;
        }
    }
}