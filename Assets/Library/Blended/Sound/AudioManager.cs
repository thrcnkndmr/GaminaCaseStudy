using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blended.Sound
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoSingleton<AudioManager>
    {
        public AudioSource audioSource;
        public List<AudioClip> soundList;

        public void PlayOneShot(int index, float volumeScale = 1)
        {
            audioSource.PlayOneShot(soundList[index], volumeScale);
        }

        public void PlaySound(int index)
        {
            audioSource.clip = soundList[index];
            audioSource.Play();
        }

        public IEnumerator PlayOneShotWithTime(float time, int index, float volumeScale = 1)
        {
            yield return time.GetWait();
            audioSource.PlayOneShot(soundList[index], volumeScale);
        }

        public IEnumerator PlaySoundWithTime(float time, int index)
        {
            yield return time.GetWait();
            audioSource.clip = soundList[index];
            audioSource.Play();
        }

        public IEnumerator PlayTwoSound(int firstSound, int secondSound)
        {
            audioSource.clip = soundList[firstSound];
            audioSource.Play();
            yield return audioSource.clip.length.GetWait();
            audioSource.clip = soundList[secondSound];
            audioSource.Play();
        }
    }
}