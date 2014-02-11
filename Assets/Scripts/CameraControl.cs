﻿using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{

		public ConstantsManager constantsManager; //Test
		public Camera mainCamera;
		public SelectionManager selectionManager;

		private float start = 0f; //leftmost icon end
		private float end = 0f; //rightmost icon end
		private float iconSpacing = 5; //Spacing Between Icons	
		private float movementQuickness = 1; //Move camera how fast

	
		private bool moving = false;
		private bool moveDirectionRight = true; //true if we move right, false if we move left

		// Use this for initialization
		void Start ()
		{

		}
	
		// Update is called once per frame
		void Update ()
		{
				end = (constantsManager.ItemCount - 1f) * iconSpacing;

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
				Vector3 tempVector = mainCamera.transform.position;
				if (moveDirectionRight) {
						if (tempVector.x + movementQuickness <= end)						//checks if we haven't yet reached the right end
								tempVector.x = tempVector.x + movementQuickness;
				} else {
						if (tempVector.x - movementQuickness >= start)					//checks if we haven't yet reached the left end
								tempVector.x = tempVector.x - movementQuickness;
				}

				mainCamera.transform.position = tempVector;
				if (mainCamera.transform.position.x % iconSpacing == 0) { //stop at spacing values
						moving = false;
						if (moveDirectionRight) {
								selectionManager.moveRight ();
						} else {
								selectionManager.moveLeft ();
						}
						
				}

		}


}
