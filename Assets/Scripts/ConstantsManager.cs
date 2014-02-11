using UnityEngine;
using System.Collections;

public class ConstantsManager : MonoBehaviour
{

		private float itemCount = 0;

		public float ItemCount {
				get{ return itemCount;}
		}

		public void addToItemCount ()
		{
				itemCount = itemCount + 1f;
		}

}
