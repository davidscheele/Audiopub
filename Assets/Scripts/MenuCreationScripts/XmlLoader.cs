using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

public class XmlLoader : MonoBehaviour
{

		public MenuPartConnector menuPartConnector;


		private List<Dictionary<string,string>> menuItemsList = new List<Dictionary<string,string>> ();
		private List<Dictionary<string,object>> menuItemsListLoaded = new List<Dictionary<string,object>> ();
		private Dictionary<string, string> menuItem;

		private Dictionary<string, string> generalMenuSounds;
		private Dictionary<string, object> generalMenuSoundsLoaded;

		
		// Use this for initialization
		void Start ()
		{
	
				ReadMainMenuXml ();
				LoadResources ();
				menuPartConnector.constantsManager.MenuContents = menuItemsListLoaded;
				menuPartConnector.menuCreator.createMenu (menuItemsListLoaded);
				menuPartConnector.constantsManager.MenuSounds = generalMenuSoundsLoaded;
		}

		void ReadMainMenuXml ()
		{
				XmlDocument menuXml = new XmlDocument ();
				menuXml.Load ("Assets/Xml Files/" + menuPartConnector.constantsManager.XmlName + ".xml");
				XmlNodeList _menuItemsList = menuXml.GetElementsByTagName ("menuitem");

				foreach (XmlNode _menuItem in _menuItemsList) {
						XmlNodeList _menuItemData = _menuItem.ChildNodes;
						menuItem = new Dictionary<string, string> ();

						foreach (XmlNode _menuItemField in _menuItemData) {

								menuItem.Add (_menuItemField.Name, _menuItemField.InnerText);

						}

						menuItemsList.Add (menuItem);

				}
				_menuItemsList = menuXml.GetElementsByTagName ("generalmenuvariables");
				foreach (XmlNode _generalMenuVariables in _menuItemsList) {
						XmlNodeList _generalMenuVariablesData = _generalMenuVariables.ChildNodes;
						generalMenuSounds = new Dictionary<string, string> ();
			
						foreach (XmlNode _generalMenuVariablesField in _generalMenuVariablesData) {
				
								generalMenuSounds.Add (_generalMenuVariablesField.Name, _generalMenuVariablesField.InnerText);
				
						}			
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
						Texture iconTexture = Resources.Load<Texture> ("Icons/" + menuPartConnector.constantsManager.SpecificMenuSoundsFolder + "/" + tempString);
						tempDictionary.Add ("icontexture", iconTexture);

						menuItemStringDictionary.TryGetValue ("ambientsoundname", out tempString);
						AudioClip iconAmbientAudio = Resources.Load<AudioClip> ("Sounds/" + menuPartConnector.constantsManager.SpecificMenuSoundsFolder + "/" + tempString);
						tempDictionary.Add ("iconambientaudio", iconAmbientAudio);

						menuItemStringDictionary.TryGetValue ("selectsoundname", out tempString);
						AudioClip iconSelectSound = Resources.Load<AudioClip> ("Sounds/" + menuPartConnector.constantsManager.SpecificMenuSoundsFolder + "/" + tempString);
						tempDictionary.Add ("iconselectsound", iconSelectSound);

						menuItemStringDictionary.TryGetValue ("voiceovername", out tempString);
						AudioClip iconVoiceOverSound = Resources.Load<AudioClip> ("Sounds/" + menuPartConnector.constantsManager.SpecificMenuSoundsFolder + "/" + tempString);
						tempDictionary.Add ("iconvoiceover", iconVoiceOverSound);

						menuItemStringDictionary.TryGetValue ("scenename", out tempString);
						tempDictionary.Add ("iconscene", tempString);

						menuItemsListLoaded.Add (tempDictionary);
				}
				Dictionary<string,object> _tempDictionary = new Dictionary<string, object> ();
		
				string _tempString = "";
				
				generalMenuSounds.TryGetValue ("swipeleftsound", out _tempString);
				AudioClip _tempSound = Resources.Load<AudioClip> ("Sounds/" + menuPartConnector.constantsManager.GeneralMenuSoundsFolder + "/" + _tempString);
				_tempDictionary.Add ("swipeleftsound", _tempSound);

				generalMenuSounds.TryGetValue ("swiperightsound", out _tempString);
				_tempSound = Resources.Load<AudioClip> ("Sounds/" + menuPartConnector.constantsManager.GeneralMenuSoundsFolder + "/" + _tempString);
				_tempDictionary.Add ("swiperightsound", _tempSound);

				generalMenuSounds.TryGetValue ("leftbordersound", out _tempString);
				_tempSound = Resources.Load<AudioClip> ("Sounds/" + menuPartConnector.constantsManager.GeneralMenuSoundsFolder + "/" + _tempString);
				_tempDictionary.Add ("leftbordersound", _tempSound);
		
				generalMenuSounds.TryGetValue ("rightbordersound", out _tempString);
				_tempSound = Resources.Load<AudioClip> ("Sounds/" + menuPartConnector.constantsManager.GeneralMenuSoundsFolder + "/" + _tempString);
				_tempDictionary.Add ("rightbordersound", _tempSound);

				generalMenuSounds.TryGetValue ("guibuttonselectsound", out _tempString);
				_tempSound = Resources.Load<AudioClip> ("Sounds/" + menuPartConnector.constantsManager.GeneralMenuSoundsFolder + "/" + _tempString);
				_tempDictionary.Add ("guibuttonselectsound", _tempSound);

				generalMenuSounds.TryGetValue ("ambientmusic", out _tempString);
				_tempSound = Resources.Load<AudioClip> ("Sounds/" + menuPartConnector.constantsManager.GeneralMenuSoundsFolder + "/" + _tempString);
				_tempDictionary.Add ("ambientmusic", _tempSound);
		
				generalMenuSoundsLoaded = _tempDictionary;
				
		}

}

