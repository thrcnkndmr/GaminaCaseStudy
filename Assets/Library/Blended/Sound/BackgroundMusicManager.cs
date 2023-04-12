using System.Collections.Generic;
using UnityEngine;

namespace Blended.Sound
{
    public class BackgroundMusicManager : MonoSingleton<BackgroundMusicManager>
    {
        public static BackgroundMusicManager BackgroundMusic;

        public int currentMusicIndex = -1;
        public AudioSource audioSource;
        public List<AudioClip> musicClip;

        public void ChangeBackgroundMusic(int index)
        {
            audioSource.clip = musicClip[index];
            audioSource.Play();
        }

        public void NextBackgroundMusic()
        {
            currentMusicIndex = PlayerPrefs.GetInt("CurrentBackgroundMusic", -1);
            if (currentMusicIndex == musicClip.Count - 1) currentMusicIndex = 0;
            else currentMusicIndex++;
            audioSource.clip = musicClip[currentMusicIndex];
            audioSource.Play();
            PlayerPrefs.SetInt("CurrentBackgroundMusic", currentMusicIndex);
        }
    }
}