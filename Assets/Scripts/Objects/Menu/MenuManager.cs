using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace BakuSou
{
    public class MenuManager : MonoBehaviour
    {


        public GameObject speedBox;
        public GameObject adjustBox;
        public GameObject key1Box;
        public GameObject key2Box;
        public GameObject key3Box;
        public GameObject key4Box;
        public GameObject key5Box;
        public GameObject bgmVolumeBar;
        public GameObject soundVolumeBar;
        public GameObject voiceVolumeBar;

        private InputField speed_text;
        private InputField adjust_text;
        private InputField key1_text;
        private InputField key2_text;
        private InputField key3_text;
        private InputField key4_text;
        private InputField key5_text;
        private Slider bgmVolume_image;
        private Slider soundVolume_image;
        private Slider voiceVolume_image;
        private float llAmount;

        private bool settingKeyInitialized = false;

        public void Start()
        {
            GameParameter.Instance().gameMode = "play";
            GameParameter.Instance().InitKeyLog();
            speed_text = speedBox.GetComponent<InputField>();
            adjust_text = adjustBox.GetComponent<InputField>();
            key1_text = key1Box.GetComponent<InputField>();
            key2_text = key2Box.GetComponent<InputField>();
            key3_text = key3Box.GetComponent<InputField>();
            key4_text = key4Box.GetComponent<InputField>();
            key5_text = key5Box.GetComponent<InputField>();
            bgmVolume_image = bgmVolumeBar.GetComponent<Slider>();
            soundVolume_image = soundVolumeBar.GetComponent<Slider>();
            voiceVolume_image = voiceVolumeBar.GetComponent<Slider>();

        }

        // Update is called once per frame
        void Update()
        {
            if(!settingKeyInitialized)
            {
                SettingDTO setting = SaveManager.Instance().GetSaveData().setting;
                Debug.Log("Text:" + speed_text.text);
                Debug.Log("Save:" + setting.speed.ToString());
                speed_text.text = setting.speed.ToString();
                adjust_text.text = setting.adjust.ToString();
                bgmVolume_image.value = setting.bgm_volume * 100;
                soundVolume_image.value = setting.sound_volume * 100;
                voiceVolume_image.value = setting.voice_volume * 100;
                settingKeyInitialized = true;
            }

        }
    }
}