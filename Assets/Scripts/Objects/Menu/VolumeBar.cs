using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BakuSou
{
    public class VolumeBar : MonoBehaviour
    {
        Slider myImage;
        // Use this for initialization
        void Start()
        {
            myImage = GetComponent<Slider>();

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SoundVolumeChange()
        {
            if (myImage == null) return;
            SaveManager.Instance().GetSaveData().setting.sound_volume = myImage.value / 100f;
        }

        public void BgmVolumeChange()
        {
            if (myImage == null) return;
            SaveManager.Instance().GetSaveData().setting.bgm_volume = myImage.value / 100f;
        }
    }
}