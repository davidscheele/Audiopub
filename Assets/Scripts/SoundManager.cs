using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{

		public AudioSource musicSource;
		public AudioSource soundEffectSource;	
		

		public void playMusic (AudioClip audioClip)
		{
				musicSource.Stop ();
				musicSource.clip = audioClip;
				musicSource.Play ();
		}

		public void playAudioEffect (AudioClip audioClip)
		{
				soundEffectSource.clip = audioClip;
				soundEffectSource.Play ();
		}

		

}
