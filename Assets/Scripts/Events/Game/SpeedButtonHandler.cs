using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BakuSou
{
    public class SpeedButtonHandler : MonoBehaviour
    {
        public GameObject audioManager;
        AudioSource audioSource;
        public float pitch = 1.0f;
        // Start is called before the first frame update
        void Start()
        {
            audioSource = audioManager.GetComponent<AudioSource>();
        }

        public void SpeedButton()
        {
            audioSource.pitch = pitch;
        }

    }
}