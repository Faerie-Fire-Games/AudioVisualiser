using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lunity.AudioVis
{
    public class ParticleBurst : MonoBehaviour
    {
        public SoundCapture.DataSource Target = SoundCapture.DataSource.AverageVolume;
        public int BandIndex = 0;
        public float burstThreshold = 20f;

        private SoundCapture _sc;
        private ParticleSystem particles;
        private Camera cam;

        public List<GameObject> circles;

        public void Start()
        {
            _sc = FindObjectOfType<SoundCapture>();
            particles = GetComponent<ParticleSystem>();
            cam = Camera.main;
            cam.backgroundColor = circles[0].GetComponent<SpriteRenderer>().color;
        }


        public void Update()
        {
            if(GetValue() > burstThreshold)
            {
                foreach (GameObject circle in circles)
                {
                    var colour = new Color32((byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255));
                    circle.GetComponent<SpriteRenderer>().color = colour;
                }
                cam.backgroundColor = circles[0].GetComponent<SpriteRenderer>().color;
                var colBuffer = circles[2].GetComponent<SpriteRenderer>().color; 
                particles.startColor = new Color32((byte)(255 - (int)colBuffer.r), (byte)(255 - (int)colBuffer.g), (byte)(255 - (int)colBuffer.b), 255); //This was supposed to invert the colour but for some reason I did.. this instead? Dunno why. But the white looks nicer anyway tbh.
                particles.Play();
            }
        }

        private float GetValue()
        {
            switch (Target)
            {
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
