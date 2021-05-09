using System;
using UnityEngine;

namespace DefaultNamespace.Audio
{
    public class AudioManager : MonoBehaviour
    {
        
        private AudioSource[] sources;

        private void Awake()
        {
            sources = GetComponentsInChildren<AudioSource>();
        }

        public void PlayClip(int clip)
        {
            sources[clip].Play();
        }
        
        public void StopAll()
        {
            foreach (var audioSource in sources)
            {
                audioSource.Stop();
            }
        }
    }
}