using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

namespace BakuSou
{
    public class Rank : MonoBehaviour {
        private Image image;
        public string rank = "C";
        public Sprite ss;
        public Sprite s;
        public Sprite a;
        public Sprite b;
        public Sprite c;

        // Use this for initialization
        void Start() {
            image = GetComponent<Image>();

        }

        // Update is called once per frame
        void Update()
        {
            if (rank ==  "C")
            {
                image.sprite = c;
            }
            else if (rank == "B")
            {
                image.sprite = b;
            }
            else if (rank == "A")
            {
                image.sprite = a;
            }
            else if (rank == "S")
            {
                image.sprite = s;
            }
            else if (rank == "SS")
            {
                image.sprite = ss;
            }

        }
    }
}