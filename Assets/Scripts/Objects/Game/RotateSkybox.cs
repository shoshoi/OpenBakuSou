using UnityEngine;
using System.Collections;

namespace BakuSou
{
    public class RotateSkybox : MonoBehaviour
    {
        public float _anglePerFrame = 1.0f;    // 1フレームに何度回すか[unit : deg]
        float _rot = 0.0f;

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            _rot += _anglePerFrame * Time.deltaTime / ( 1f / 60f );
            if (_rot >= 360.0f)
            {    // 0～360°の範囲におさめたい
                _rot -= 360.0f;
            }
            RenderSettings.skybox.SetFloat("_Rotation", _rot);    // 回す
        }
    }
}