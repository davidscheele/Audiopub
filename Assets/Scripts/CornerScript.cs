using UnityEngine;
using System.Collections;

public class CornerScript : MonoBehaviour
{
	
		public MenuPartConnector menuPartConnector;
		private int counter = 0;
		private bool cornerHeld = false;

		// Update is called once per frame
		void Update ()
		{
				if (cornerHeld) {
						counter++;
				}

				if (counter > 50) {
						cornerHeld = false;
						counter = 0;
						menuPartConnector.soundManager.playAudioEffect (menuPartConnector.constantsManager.getGUIButtonSelectSound ());
				}

		}

		void OnMouseDown ()
		{
				cornerHeld = true;
		}

		void OnMouseUp ()
		{
				cornerHeld = false;
				counter = 0;
		}

		void OnMouseExit ()
		{
				cornerHeld = false;
				counter = 0;
		}

}
