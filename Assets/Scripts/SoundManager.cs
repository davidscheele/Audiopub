using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{

		public AudioSource musicTest;
		
		public void playMusic (AudioClip audioClip)
		{
				musicTest.Stop ();
				musicTest.clip = audioClip;
				musicTest.Play ();
		}

}
