using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObject : MonoBehaviour
{
	public float moveUnit;

	private float spriteWidthUnit;

	void Start ()
	{
		var sprite = GetComponent<SpriteRenderer> ().sprite;
		spriteWidthUnit = sprite.rect.width / sprite.pixelsPerUnit;
	}

	void Update ()
	{
		if (!transform.parent.gameObject.GetComponent<BackgroundLooper> ().isMoving)
			return;

		transform.Translate (new Vector3 (-moveUnit * Time.deltaTime, 0, 0));
	}

	private void OnBecameInvisible ()
	{
		if (transform.localPosition.x < 0)
			transform.Translate (new Vector3 (spriteWidthUnit * 2, 0, 0));
	}
}
