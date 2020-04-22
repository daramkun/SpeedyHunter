using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListView : MonoBehaviour
{
	GameObject contentView;

	UpgradeItem [] upgradeItems;

	void Awake ()
	{
		contentView = gameObject.GetComponent<ScrollRect> ().content.gameObject;
	}


}
