using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BakuSou
{
    public class SettingSwitchHandler : MonoBehaviour
    {
        public AudioSource option;

        public GameObject panel;
        public AudioClip optionOn;
        public void Start()
        {
            optionOn = Resources.Load<AudioClip>("Voices/option");
            option = GameObject.Find("submiton").GetComponent<AudioSource>();
        }
        public void SettingButtonSwitch()
        {
            if (panel.activeSelf)
            {
                panel.SetActive(false);
            }
            else
            {
                panel.SetActive(true);

                option.clip = optionOn;
                option.Play();
            }
        }
        public void SettingReload()
        {
            SaveManager.Instance().LoadSaveData();
        }
    }
}