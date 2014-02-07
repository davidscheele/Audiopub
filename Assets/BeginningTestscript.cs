using UnityEngine;
using System.Collections;

public class BeginningTestscript : MonoBehaviour
{

		public Texture2D my_img;

		// Use this for initialization
		void Start ()
		{
				GameObject plane;
				plane = GameObject.CreatePrimitive (PrimitiveType.Plane);
				plane.transform.position = new Vector3 (0, 0, 0);
				plane.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
				plane.transform.Rotate (new Vector3 (90f, 180f));
				plane.renderer.material.mainTexture = my_img;


		}
		
		// Update is called once per frame
		void Update ()
		{

		}

}


