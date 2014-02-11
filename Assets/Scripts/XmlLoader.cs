using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

public class XmlLoader : MonoBehaviour
{
		public string MainMenuXmlName;
//		private MenuCreator menuCreator = new MenuCreator ();
		public MenuCreator menuCreator;
		public ConstantsManager constantsManager;
		
		public GUIText debugtext1;
		public GUIText debugtext2;
		public GUIText debugtext3;

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
						debugtext1.text = tempString;

						menuItemStringDictionary.TryGetValue ("iconname", out tempString);
						Texture iconTexture = Resources.Load<Texture> ("Icons/" + tempString);
						tempDictionary.Add ("icontexture", iconTexture);
						debugtext2.text = tempString;

						menuItemStringDictionary.TryGetValue ("ambientsoundname", out tempString);
						AudioClip iconAmbientAudio = Resources.Load<AudioClip> ("Sounds/" + tempString);
						tempDictionary.Add ("iconambientaudio", iconAmbientAudio);
						debugtext3.text = tempString;

						menuItemsListComplete.Add (tempDictionary);
				}
		}

}

