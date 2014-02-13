using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
		public MenuPartConnector menuPartConnector;


		private float start = 0f; //leftmost icon end
		private float end = 0f; //rightmost icon end
		private float iconSpacing = 5; //Spacing Between Icons	
		private float movementQuickness = 1; //Move camera how fast

	
		private bool moving = false;
		private bool moveDirectionRight = true; //true if we move right, false if we move left
	
		// Update is called once per frame
		void Update ()
		{
				end = (menuPartConnector.constantsManager.ItemCount - 1f) * iconSpacing;

				if (moving) {

						SlideMotion ();


				} else {

						//Moves Camera Right
						if (Input.GetKeyDown (KeyCode.RightArrow)) {
								SlideMotion (true);
								
			
						}

						//Moves Camera Left
						if (Input.GetKeyDown (KeyCode.LeftArrow)) {
								SlideMotion (false);
			
						}

//		if (Input.GetKeyDown (KeyCode.Return)) 
//		{
//			if(!returnKeyDown){
//				SelectionText.text = getSelection();
//				returnKeyDown = true;
//			}
//		}
//		if (Input.GetKeyUp (KeyCode.Return)) 
//		{
//			if(returnKeyDown){
//				returnKeyDown = false;
//			}
//			
//		}
				}
		}

		void SlideMotion (bool _moveDirectionRight)
		{

				moving = true;
				moveDirectionRight = _moveDirectionRight;
		}

		void SlideMotion ()
		{
				Vector3 tempVector = menuPartConnector.constantsManager.mainCamera.transform.position;
				if (moveDirectionRight) {
						if (tempVector.x + movementQuickness <= end) {						//checks if we haven't yet reached the right end
								tempVector.x = tempVector.x + movementQuickness;
						} else {
								menuPartConnector.soundManager.playSoundEffect (menuPartConnector.constantsManager.getRightBorderSound ()); //Play Sound to signalize end of the menu
						}
				} else {
						if (tempVector.x - movementQuickness >= start) {					//checks if we haven't yet reached the left end
								tempVector.x = tempVector.x - movementQuickness;
						} else {
								menuPartConnector.soundManager.playSoundEffect (menuPartConnector.constantsManager.getLeftBorderSound ()); //Play Sound to signalize end of the menu
						}
				}
				menuPartConnector.constantsManager.mainCamera.transform.position = tempVector;
				if (menuPartConnector.constantsManager.mainCamera.transform.position.x % iconSpacing == 0) { //stop at spacing values
						moving = false;
						if (moveDirectionRight) {
								menuPartConnector.selectionManager.moveRight ();
						} else {
								menuPartConnector.selectionManager.moveLeft ();
						}
						
				}

		}




}
