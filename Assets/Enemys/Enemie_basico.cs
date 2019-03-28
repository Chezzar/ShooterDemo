using UnityEngine;
using System.Collections;

public class Enemie_basico : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.rotation =  Quaternion.LookRotation (new Vector3(GameObject.Find("Char").transform.position.x,
		                         GameObject.Find("Char").transform.position.y,
		                         GameObject.Find("Char").transform.position.z) - this.transform.position);
	
	}
}
