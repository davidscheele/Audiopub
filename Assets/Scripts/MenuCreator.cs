using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuCreator : MonoBehaviour
{

		public ConstantsManager constantsManager;

		private float offset = 5f;
		private float offsetMultiplicator = 0;


		public void createMenu (List<Dictionary<string,string>> menuContents)
		{
				foreach (Dictionary<string,string> menuItem in menuContents) {
						createButton (menuItem);
						offsetMultiplicator = offsetMultiplicator + 1f;
						constantsManager.addToItemCount ();
				}
		}

		private void createButton (Dictionary<string,string> menuButton)
		{
				
				GameObject plane;
				plane = GameObject.CreatePrimitive (PrimitiveType.Plane);
				string tempString = "Noname";
				menuButton.TryGetValue ("name", out tempString);
				plane.name = tempString;
				plane.transform.position = new Vector3 (offset * offsetMultiplicator, 0, 0);
				plane.transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f);
				plane.transform.Rotate (new Vector3 (90f, 180f));
				menuButton.TryGetValue ("iconname", out tempString);
				plane.renderer.material.mainTexture = Resources.Load<Texture> ("Icons/" + tempString);
//				plane.renderer.material.mainTexture = 
		}
}
