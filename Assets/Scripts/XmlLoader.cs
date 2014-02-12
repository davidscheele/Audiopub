﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

public class XmlLoader : MonoBehaviour
{
		public string MainMenuXmlName;
		public string FileFolderName;
		public MenuCreator menuCreator;
		public ConstantsManager constantsManager;


		private List<Dictionary<string,string>> menuItemsList = new List<Dictionary<string,string>> ();
		private List<Dictionary<string,object>> menuItemsListComplete = new List<Dictionary<string,object>> ();
		private Dictionary<string, string> menuItem;


		
		// Use this for initialization
		void Start ()
		{
	
				ReadMainMenuXml ();
				LoadResources ();
				constantsManager.MenuContents = menuItemsListComplete;
				menuCreator.createMenu (menuItemsListComplete);
		}

		void ReadMainMenuXml ()
		{
				XmlDocument mainMenuXml = new XmlDocument ();
				mainMenuXml.Load (MainMenuXmlName);
				XmlNodeList _menuItemsList = mainMenuXml.GetElementsByTagName ("menuitem");

				foreach (XmlNode _menuItem in _menuItemsList) {
						XmlNodeList _menuItemData = _menuItem.ChildNodes;
						menuItem = new Dictionary<string, string> ();

						foreach (XmlNode _menuItemField in _menuItemData) {

								menuItem.Add (_menuItemField.Name, _menuItemField.InnerText);

						}

						menuItemsList.Add (menuItem);

				}

		}

		void LoadResources ()
		{
				foreach (Dictionary<string,string> menuItemStringDictionary in menuItemsList) {

						Dictionary<string,object> tempDictionary = new Dictionary<string, object> ();

						string tempString = "";


						menuItemStringDictionary.TryGetValue ("name", out tempString);
						tempDictionary.Add ("iconname", tempString);

						menuItemStringDictionary.TryGetValue ("iconname", out tempString);
						Texture iconTexture = Resources.Load<Texture> ("Icons/" + FileFolderName + "/" + tempString);
						tempDictionary.Add ("icontexture", iconTexture);

						menuItemStringDictionary.TryGetValue ("ambientsoundname", out tempString);
						AudioClip iconAmbientAudio = Resources.Load<AudioClip> ("Sounds/" + FileFolderName + "/" + tempString);
						tempDictionary.Add ("iconambientaudio", iconAmbientAudio);

						menuItemsListComplete.Add (tempDictionary);
				}
		}

}

