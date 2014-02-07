using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
		public float iconSpacing; //Spacing Between Icons	
		public float movementQuickness = 1; //Move camera how fast

		public GUIText debugtext;

		private float start = 0f; //leftmost icon end
		private float end = 20f; //rightmost icon end

	
		private bool moving = false;
	private bool moveDirectionRight = true; //true if we move right, false if we move left

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{

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
				Vector3 tempVector = transform.position;
		if (moveDirectionRight) {
			if(tempVector.x + movementQuickness <= end)						//checks if we haven't yet reached the right end
						tempVector.x = tempVector.x + movementQuickness;
				} else {
			if(tempVector.x - movementQuickness >= start)					//checks if we haven't yet reached the left end
						tempVector.x = tempVector.x - movementQuickness;
				}

		transform.position = tempVector;
		if (transform.position.x % iconSpacing == 0) { //stop at spacing values
			moving = false;
		}

		}


}
//	if ((tempVector.x + (movementQuickness * moveDirectionSign)) > end ) { //if camera would move out of bounds, stop.
//		//do nothing
//	} else {
//		tempVector.x = tempVector.x + (movementQuickness * moveDirectionSign);
//		transform.position = tempVector;
//		if (transform.position.x % 5 == 0) {
//			moving = false;
//		}
//	}
//}