using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {
	[SerializeField]
	private GameObject _cratedDestroyed;


	public void DestroyCrate(){
		Instantiate(_cratedDestroyed,transform.position, transform.rotation);
		Destroy(this.gameObject);
	}
}
