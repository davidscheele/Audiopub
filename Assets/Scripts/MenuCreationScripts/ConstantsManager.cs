using UnityEngine;
using System.Collections.Generic;

public class ConstantsManager : MonoBehaviour
{

		public MenuPartConnector menuPartConnector;
		public Camera mainCamera;
		public AudioSource musicSource;
		public AudioSource soundEffectSource;	
		public AudioSource voiceOverSource;
		public string XmlName;
		public string SpecificMenuSoundsFolder;
		public string GeneralMenuSoundsFolder;

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

		public AudioClip getRightBorderSound ()
		{
				object audioClip;
				menuSounds.TryGetValue ("rightbordersound", out audioClip);
				return (AudioClip)audioClip;
		}

		public AudioClip getLeftBorderSound ()
		{
				object audioClip;
				menuSounds.TryGetValue ("leftbordersound", out audioClip);
				return (AudioClip)audioClip;
		}

		public AudioClip getGUIButtonSelectSound ()
		{
				object audioClip;
				menuSounds.TryGetValue ("guibuttonselectsound", out audioClip);
				return (AudioClip)audioClip;
		}

		public AudioClip getIconAmbientMusic ()
		{
				object audioClip;
				menuContents [menuPartConnector.selectionManager.getSelectedItemIndex ()].TryGetValue ("iconambientaudio", out audioClip);
				return (AudioClip)audioClip;
		}

		public AudioClip getIconSelectSound ()
		{
				object audioClip;
				menuContents [menuPartConnector.selectionManager.getSelectedItemIndex ()].TryGetValue ("iconselectsound", out audioClip);
				return (AudioClip)audioClip;
		}

		public AudioClip getIconVoiceOver ()
		{
				object audioClip;
				menuContents [menuPartConnector.selectionManager.getSelectedItemIndex ()].TryGetValue ("iconvoiceover", out audioClip);
				return (AudioClip)audioClip;
		}

		public string getSelectedScene ()
		{
				object sceneName;
				menuContents [menuPartConnector.selectionManager.getSelectedItemIndex ()].TryGetValue ("iconscene", out sceneName);
				return (string)sceneName;
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
