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
		private List<Dictionary<string,string>> menuItemsList = new List<Dictionary<string,string>> ();
		private Dictionary<string, string> menuItem;

		// Use this for initialization
		void Start ()
		{
	
				ReadMainMenuXml ();
				menuCreator.createMenu (menuItemsList);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
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
}
