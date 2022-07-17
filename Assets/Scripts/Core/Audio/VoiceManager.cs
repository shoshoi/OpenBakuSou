using UnityEngine;

namespace BakuSou
{
    public class VoiceManager : SingletonMonoBehaviour<VoiceManager>
    {
        private AudioSource myAudioSource;
        public float default_volume = 0.3f;
        public float itiji = 1f;

        void Start()
        {
            myAudioSource = GetComponent<AudioSource>();
        }
        private void Update()
        {
            myAudioSource.volume = SaveManager.Instance().GetSaveData().setting.voice_volume * default_volume * itiji;
        }
        public void SetClip(AudioClip clip)
        {
            myAudioSource = GetComponent<AudioSource>();
            myAudioSource.clip = clip;
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