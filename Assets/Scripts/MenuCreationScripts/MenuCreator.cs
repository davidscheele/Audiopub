using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuCreator : MonoBehaviour
{

		public MenuPartConnector menuPartConnector;

		private float offset = 5f;
		private float offsetMultiplicator = 0;
		private List<GameObject> iconList = new List<GameObject> ();


		public void createMenu (List<Dictionary<string,object>> menuContents)
		{
				foreach (Dictionary<string,object> menuItem in menuContents) {
						createIcon (menuItem);
						offsetMultiplicator = offsetMultiplicator + 1f;
						menuPartConnector.constantsManager.addToItemCount ();
				}
				menuPartConnector.selectionManager.Icons = iconList;
				menuPartConnector.soundManager.playAmbientMusic (menuPartConnector.constantsManager.getAmbientMusic ());
				
				
				
		}

		private void createIcon (Dictionary<string,object> menuButton)
		{
				GameObject plane;
				plane = GameObject.CreatePrimitive (PrimitiveType.Plane);

				object tempObject = null;
				menuButton.TryGetValue ("iconname", out tempObject);
				plane.name = (string)tempObject;

				plane.transform.position = new Vector3 (offset * offsetMultiplicator, 0, 0);
				plane.transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f);
				plane.transform.Rotate (new Vector3 (90f, 180f));
				
				menuButton.TryGetValue ("icontexture", out tempObject);
				plane.renderer.material.mainTexture = (Texture)tempObject;
				plane.layer = 1;
				
				iconList.Add (plane);
		}
}


//GameObject plane;
//plane = GameObject.CreatePrimitive (PrimitiveType.Plane);
//string tempString = "Noname";
//menuButton.TryGetValue ("name", out tempString);
//plane.name = tempString;
//plane.transform.position = new Vector3 (offset * offsetMultiplicator, 0, 0);
//plane.transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f);
//plane.transform.Rotate (new Vector3 (90f, 180f));
//menuButton.TryGetValue ("iconname", out tempString);
//plane.renderer.material.mainTexture = Resources.Load<Texture> ("Icons/" + tempString);