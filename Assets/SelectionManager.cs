using UnityEngine;
using System.Collections.Generic;

public class SelectionManager : MonoBehaviour
{
		public ConstantsManager constantsManager;
		public SoundManager soundManager;

		int selectedItem = 0;
		private List<GameObject> iconList;
		public List<GameObject> Icons {
				get{ return iconList;}
				set {
						iconList = value;
						highlight (iconList [selectedItem]);
				}
		}
		
		public void select (int selection)
		{
				selectedItem = selection;
				highlight (iconList [selectedItem]);
		}

		private void highlight (GameObject plane)
		{
				plane.transform.localScale = new Vector3 (0.4f, 0.4f, 0.4f);
		}
		private void deHighlight (GameObject plane)
		{
				plane.transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f);
		}

		public void moveLeft ()
		{
				if (selectedItem - 1 >= 0) {
						deHighlight (iconList [selectedItem]);
						selectedItem--;
						highlight (iconList [selectedItem]);
						soundManager.playMusic (constantsManager.getMusic (selectedItem));
				}
		}

		public void moveRight ()
		{
				if (selectedItem + 1 <= iconList.Count - 1) {
						deHighlight (iconList [selectedItem]);
						selectedItem++;
						highlight (iconList [selectedItem]);
						soundManager.playMusic (constantsManager.getMusic (selectedItem));
				}
		}

}
