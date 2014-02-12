using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{

		public MenuPartConnector menuPartConnector;		

		public void playMusic (AudioClip audioClip)
		{
				menuPartConnector.constantsManager.musicSource.Stop ();
				menuPartConnector.constantsManager.musicSource.clip = audioClip;
				menuPartConnector.constantsManager.musicSource.Play ();
		}

		public void playAudioEffect (AudioClip audioClip)
		{
				menuPartConnector.constantsManager.soundEffectSource.clip = audioClip;
				menuPartConnector.constantsManager.soundEffectSource.Play ();
		}

		

}
