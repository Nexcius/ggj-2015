using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {

	[SerializeField]
	GameObject disableObject;

	[SerializeField]
	GameObject enableObject;

	public void Collect() {
		if(disableObject != null)
			disableObject.SetActive (false);

		if(enableObject != null)
			enableObject.SetActive (true);

		gameObject.SetActive (false);
	}


}
