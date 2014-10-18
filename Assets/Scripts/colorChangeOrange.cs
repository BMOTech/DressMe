using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour 
{
		public Color colorStart = Color.red;
		public Color colorEnd = Color.green;
		public float duration = 1.0F;
		void Update() {
			float lerp = Mathf.PingPong(Time.time, duration) / duration;
			renderer.material.color = Color.Lerp(colorStart, colorEnd, lerp);
		}
	}