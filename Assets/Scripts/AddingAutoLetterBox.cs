using LetterboxCamera;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddingAutoLetterBox : MonoBehaviour
{
	// Start is called before the first frame update
	void Start ()
	{
		if (Screen.width > Screen.height)
		{
			var forceCameraRatio = gameObject.AddComponent<ForceCameraRatio> ();
			forceCameraRatio.ratio = new Vector2 (720, 640);
			forceCameraRatio.listenForWindowChanges = true;
			forceCameraRatio.forceRatioOnAwake = true;
		}
	}

	// Update is called once per frame
	void Update ()
	{

	}
}
