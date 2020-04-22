using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLooper : MonoBehaviour
{
	[SerializeField]
	public Sprite [] layers;

	[SerializeField]
	public bool isMoving = true;

	private List<GameObject> managingObjects = new List<GameObject> ();

	// Start is called before the first frame update
	void Start ()
	{
		InitializeSprites ();
	}

	private GameObject CreateSpriteObject (Sprite sprite, int sortingOrder, float moveUnit)
	{
		GameObject backgroundObject = new GameObject (sprite.name);

		var spriteRenderer = backgroundObject.AddComponent<SpriteRenderer> ();
		spriteRenderer.sprite = sprite;
		spriteRenderer.sortingOrder = sortingOrder;

		var backgroundObjectComponent = backgroundObject.AddComponent<BackgroundObject> ();
		backgroundObjectComponent.moveUnit = moveUnit;

		return backgroundObject;
	}

	private void InitializeSprites ()
	{
		float moveUnitUnit = 1f / layers.Length;
		float moveUnit = moveUnitUnit;
		int order = 0;
		foreach (var layer in layers)
		{
			GameObject backgroundObject = CreateSpriteObject (layer, order, moveUnit);
			float objectWidth = layer.rect.width / layer.pixelsPerUnit;

			backgroundObject.transform.SetParent (transform);
			backgroundObject.transform.localPosition = new Vector3 (0, 0, 10);

			backgroundObject = CreateSpriteObject (layer, order, moveUnit);
			backgroundObject.transform.SetParent (transform);
			backgroundObject.transform.localPosition = new Vector3 (objectWidth, 0, 10);

			backgroundObject = CreateSpriteObject (layer, order, moveUnit);
			backgroundObject.transform.SetParent (transform);
			backgroundObject.transform.localPosition = new Vector3 (objectWidth * 2, 0, 10);

			++order;
			moveUnit += moveUnitUnit;

			managingObjects.Add (backgroundObject);
		}
	}
}
