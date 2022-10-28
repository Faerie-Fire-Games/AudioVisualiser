using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lunity.AudioVis
{

    //I know that this is literally a copy and paste of your code but also like,,, it's perfect for this simple effect sooo... Eep
    public class SizeBySound : MonoBehaviour
    {
        public SoundCapture.DataSource Target = SoundCapture.DataSource.AverageVolume;
        public int BandIndex = 0;

        public float MinScale = 0.1f;
        public float ScaleAmount = 1f;
        public float burstThreshold = 20f;


        private SoundCapture _sc;
        
        public void Awake()
        {
            _sc = FindObjectOfType<SoundCapture>();
            GetComponent<SpriteRenderer>().color = new Color32((byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255));
        }

        public void Update()
        {
            transform.localScale = new Vector3(MinScale + ScaleAmount * GetValue(), MinScale + ScaleAmount * GetValue(), MinScale + ScaleAmount * GetValue()); //Yeah.. It really is this simple. Sorry man. I know.
        }

        private float GetValue()
        {
            switch (Target) {
                case SoundCapture.DataSource.AverageVolume:
                    return _sc.AverageVolume;
                case SoundCapture.DataSource.PeakVolume:
                    return _sc.PeakVolume;
                case SoundCapture.DataSource.SingleBand:
                    return _sc.BarData[Mathf.Clamp(BandIndex, 0, _sc.BarData.Length)];
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

    }
}