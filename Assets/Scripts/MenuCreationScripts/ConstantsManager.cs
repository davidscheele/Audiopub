using UnityEngine;
using System.Collections.Generic;

public class ConstantsManager : MonoBehaviour
{


		public Camera mainCamera;
		public AudioClip debugSoundEffect;
		public AudioSource musicSource;
		public AudioSource soundEffectSource;	
		public string XmlName;
		public string FileFolderName;

		private List<Dictionary<string,object>> menuContents;

		public List<Dictionary<string,object>> MenuContents {
				set{ menuContents = value;}
		}

		private Dictionary<string,object> menuSounds;
	
		public Dictionary<string,object> MenuSounds {
				set{ menuSounds = value;}
		}

		public AudioClip getAmbientMusic ()
		{
				object audioClip;
				menuSounds.TryGetValue ("ambientmusic", out audioClip);
				return (AudioClip)audioClip;
		}

		public AudioClip getSwipeLeftSound ()
		{
				object audioClip;
				menuSounds.TryGetValue ("swipeleftsound", out audioClip);
				return (AudioClip)audioClip;
		}

		public AudioClip getSwipeRightSound ()
		{
				object audioClip;
				menuSounds.TryGetValue ("swiperightsound", out audioClip);
				return (AudioClip)audioClip;
		}

		public AudioClip getGUIButtonSelectSound ()
		{
				object audioClip;
				menuSounds.TryGetValue ("guibuttonselectsound", out audioClip);
				return (AudioClip)audioClip;
		}

		public AudioClip getIconAmbientMusic (int itemNumber)
		{
				object audioClip;
				menuContents [itemNumber].TryGetValue ("iconambientaudio", out audioClip);
				return (AudioClip)audioClip;
		}
		private float itemCount = 0;

		public float ItemCount {
				get{ return itemCount;}
		}

		public void addToItemCount ()
		{
				itemCount = itemCount + 1f;
		}

		

}
