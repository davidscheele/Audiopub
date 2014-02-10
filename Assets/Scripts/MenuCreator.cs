using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuCreator
{

		private float offset = 5f;
		private float offsetMultiplicator = 0;
		private int itemCount = 0;

		public void createMenu (List<Dictionary<string,string>> menuContents)
		{
				foreach (Dictionary<string,string> menuItem in menuContents) {
						createButton (menuItem);
						offsetMultiplicator = offsetMultiplicator + 1f;
						itemCount++;
				}
		}

		private void createButton (Dictionary<string,string> menuButton)
		{
				
				GameObject plane;
				plane = GameObject.CreatePrimitive (PrimitiveType.Plane);
				string name = "Noname";
				menuButton.TryGetValue ("name", out name);
				plane.name = name;
				plane.transform.position = new Vector3 (offset * offsetMultiplicator, 0, 0);
				plane.transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f);
				plane.transform.Rotate (new Vector3 (90f, 180f));
				plane.renderer.material.mainTexture = Resources.Load<Texture> ("Icons/bestgameicon");
//				plane.renderer.material.mainTexture = 
		}
}
