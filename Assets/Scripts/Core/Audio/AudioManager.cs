using UnityEngine;

namespace BakuSou
{
    public class AudioManager : SingletonMonoBehaviour<AudioManager>
    {
        private AudioSource myAudioSource;
        public float default_volume = 0.7f;
        public float itiji = 1f;

        void Start()
        {
            myAudioSource = GetComponent<AudioSource>();
        }
        private void Update()
        {
            myAudioSource.volume = SaveManager.Instance().GetSaveData().setting.bgm_volume * default_volume * itiji;
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
        public void Pause()
        {
            myAudioSource.Pause();
        }
        public void UnPause()
        {
            myAudioSource.UnPause();
        }
    }
}