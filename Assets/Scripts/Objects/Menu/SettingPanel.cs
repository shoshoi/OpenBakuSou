using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BakuSou{
    public class SettingPanel : MonoBehaviour
    {

        public GameObject root;

        public GameObject adjustBox;
        public GameObject speedBox;
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

        bool before_isActive = false;

        // Use this for initialization
        void Start()
        {
            speed_text = speedBox.GetComponent<InputField>();
            //adjust_text = adjustBox.GetComponent<InputField>();
            key1_text = key1Box.GetComponent<InputField>();
            key2_text = key2Box.GetComponent<InputField>();
            key3_text = key3Box.GetComponent<InputField>();
            key4_text = key4Box.GetComponent<InputField>();
            key5_text = key5Box.GetComponent<InputField>();
            bgmVolume_image = bgmVolumeBar.GetComponent<Slider>();
            soundVolume_image = soundVolumeBar.GetComponent<Slider>();
            voiceVolume_image = voiceVolumeBar.GetComponent<Slider>();
            if(SaveManager.Instance().GetSaveData().setting.adjust <= 256)
            {
                keiryouka_on.SetActive(false);
                keiryouka_off.SetActive(true);

            }
            else
            {
                keiryouka_on.SetActive(true);
                keiryouka_off.SetActive(false);

            }
        }

        // Update is called once per frame
        void OnDisable()
        {
                Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
                SaveManager.Instance().LoadSaveData();
                SettingDTO setting = SaveManager.Instance().GetSaveData().setting;
                speed_text.text = setting.speed.ToString();

                if((int)setting.adjust <= 256)
            {
                keiryouka_off.SetActive(true);
                keiryouka_on.SetActive(false);
            }
            else
            {
                keiryouka_off.SetActive(false);
                keiryouka_on.SetActive(true);
            }
                key1_text.text = setting.keybord[0];
                key2_text.text = setting.keybord[1];
                key3_text.text = setting.keybord[2];
                key4_text.text = setting.keybord[3];
                key5_text.text = setting.keybord[4];
            Debug.Log(setting.bgm_volume);
                bgmVolume_image.value = setting.bgm_volume * 100;
                soundVolume_image.value = setting.sound_volume * 100;
                voiceVolume_image.value = setting.voice_volume * 100;
                before_isActive = root.activeSelf;
        }
    }
}
