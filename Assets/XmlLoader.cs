using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

public class XmlLoader : MonoBehaviour
{
//		public TextAsset MainMenuXmlName;
		public string MainMenuXmlName;
		public GUIText debugText;

		private List<Dictionary<string,string>> menuItemsList = new List<Dictionary<string,string>> ();
		private Dictionary<string, string> menuItem;

		// Use this for initialization
		void Start ()
		{
	
				ReadMainMenuXml ();
				string stringout = "";
				menuItemsList [0].TryGetValue ("name", out stringout);
				debugText.text = stringout;
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void ReadMainMenuXml ()
		{
				XmlDocument mainMenuXml = new XmlDocument ();
//				mainMenuXml.LoadXml (MainMenuXmlName.text);
//				mainMenuXml.LoadXml (MainMenuXmlName);
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
}
