using UnityEngine;
using System.Collections.Generic;

public class SelectionManager : MonoBehaviour
{
		public MenuPartConnector menuPartConnector;


		int selectedItem = 0;
		private List<GameObject> iconList;
		public List<GameObject> Icons {
				get{ return iconList;}
				set {
						iconList = value;
						select (selectedItem);
				}
		}

		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.Return)) {
//						menuPartConnector.soundManager.playSoundEffect (menuPartConnector.constantsManager.getIconSelectSound ()); //Use if every Selection should have their own Selection Sound
						menuPartConnector.soundManager.playSoundEffect (menuPartConnector.constantsManager.getMenuSelectionSound ()); //Use this if every Selection should sound the same
						Application.LoadLevel (menuPartConnector.constantsManager.getSelectedScene ());
				}
		}
		
		public void select (int selection)
		{
				selectedItem = selection;
				highlight (iconList [selectedItem]);
				menuPartConnector.soundManager.playMusic (menuPartConnector.constantsManager.getIconAmbientMusic ());
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
						menuPartConnector.soundManager.playMusic (menuPartConnector.constantsManager.getIconAmbientMusic ());
						menuPartConnector.soundManager.playSoundEffect (menuPartConnector.constantsManager.getSwipeLeftSound ());
				}
		}

		public void moveRight ()
		{
				if (selectedItem + 1 <= iconList.Count - 1) {
						deHighlight (iconList [selectedItem]);
						selectedItem++;
						highlight (iconList [selectedItem]);
						menuPartConnector.soundManager.playMusic (menuPartConnector.constantsManager.getIconAmbientMusic ());
						menuPartConnector.soundManager.playSoundEffect (menuPartConnector.constantsManager.getSwipeRightSound ());
				}
		}
		public int getSelectedItemIndex ()
		{
				return selectedItem;
		}
}
