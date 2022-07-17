using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BakuSou
{
    public class SoundManager : SingletonMonoBehaviour<SoundManager>
    {
        private AudioSource myAudioSource;
        public float default_volume = 0.3f;

        void Start()
        {
            myAudioSource = GetComponent<AudioSource>();
        }
        private void Update()
        {
            myAudioSource.volume = SaveManager.Instance().GetSaveData().setting.bgm_volume * default_volume;
        }
        public void SetClip(AudioClip clip)
        {
            myAudioSource = GetComponent<AudioSource>();
            myAudioSource.clip = clip;
        }
        public AudioClip GetClip()
        {
            return myAudioSource.clip;
        }
        public float GetTime()
        {
            return myAudioSource.time;
        }
        public void Play()
        {
            myAudioSource.Play();
        }
        public void Stop()
        {
            myAudioSource.Stop();
        }
        public bool IsPlaying()
        {
            return myAudioSource.isPlaying;
        }
    }
}