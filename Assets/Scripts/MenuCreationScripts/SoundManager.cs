using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{

		public MenuPartConnector menuPartConnector;		

		public void playMusic (AudioClip audioClip)
		{
				menuPartConnector.constantsManager.musicSource.clip = audioClip;
				menuPartConnector.constantsManager.musicSource.Play ();
		}

		public void playSoundEffect (AudioClip audioClip)
		{
				menuPartConnector.constantsManager.soundEffectSource.clip = audioClip;
				menuPartConnector.constantsManager.soundEffectSource.Play ();
		}

		public void playVoiceOver (AudioClip audioClip)
		{
				menuPartConnector.constantsManager.voiceOverSource.clip = audioClip;
				menuPartConnector.constantsManager.voiceOverSource.Play ();
		}

		

}
