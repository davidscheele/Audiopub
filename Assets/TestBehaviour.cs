using UnityEngine;
using System.Collections;

public class TestBehaviour : MonoBehaviour
{

		public GUIText debugText;
		private int clickcount = 0;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnMouseDown ()
		{
				clickcount++;
				debugText.text = clickcount + "times clicked!";
		}

}
