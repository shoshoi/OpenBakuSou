using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace BakuSou
{
    public class SaveButtonHandler : MonoBehaviour
    {
        public GameObject speedBox;
        //public GameObject adjustBox;
        public GameObject key1Box;
        public GameObject key2Box;
        public GameObject key3Box;
        public GameObject key4Box;
        public GameObject key5Box;
        public GameObject bgmVolumeBar;
        public GameObject soundVolumeBar;
        public GameObject voiceVolumeBar;
        public GameObject keiryouka_on;
        public GameObject keiryouka_off;

        private Text speed_text;
        //private Text adjust_text;
        private Text key1_text;
        private Text key2_text;
        private Text key3_text;
        private Text key4_text;
        private Text key5_text;
        private Slider bgmVolume_image;
        private Slider soundVolume_image;
        private Slider voiceVolume_image;

        public void Start()
        {
            speed_text = speedBox.GetComponent<Text>();
            //adjust_text = adjustBox.GetComponent<Text>();
            key1_text = key1Box.GetComponent<Text>();
            key2_text = key2Box.GetComponent<Text>();
            key3_text = key3Box.GetComponent<Text>();
            key4_text = key4Box.GetComponent<Text>();
            key5_text = key5Box.GetComponent<Text>();
            bgmVolume_image = bgmVolumeBar.GetComponent<Slider>();
            soundVolume_image = soundVolumeBar.GetComponent<Slider>();
            voiceVolume_image = voiceVolumeBar.GetComponent<Slider>();
        }

        public void SaveButton()
        {
            double speed = double.Parse(speed_text.text);
            double adjust = 256;
            if (keiryouka_on.activeSelf)
            {
                adjust = 512;
            }
            else
            {
                adjust = 256;
            }
            string key1 = key1_text.text.ToLower();
            string key2 = key2_text.text.ToLower();
            string key3 = key3_text.text.ToLower();
            string key4 = key4_text.text.ToLower();
            string key5 = key5_text.text.ToLower();
            float bgmVolume = bgmVolume_image.value / 100f;
            float soundVolume = soundVolume_image.value / 100f;
            float voiceVolume = voiceVolume_image.value / 100f;

            SettingDTO setting = SaveManager.Instance().GetSaveData().setting;
            setting.speed = speed;
            setting.adjust = adjust;
            setting.keybord = new string[]{key1,key2,key3,key4,key5};
            setting.bgm_volume = bgmVolume;
            setting.sound_volume = soundVolume;
            setting.voice_volume = voiceVolume;
            SaveManager.Instance().Save();
        }
    }
}