﻿using UnityEngine;
using System.Collections.Generic;

public class ConstantsManager : MonoBehaviour
{

		private List<Dictionary<string,object>> menuContents;

		public List<Dictionary<string,object>> MenuContents {
				set{ menuContents = value;}
		}

		public AudioClip getMusic (int itemNumber)
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
