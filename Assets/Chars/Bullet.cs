using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


	public float speed = 0.3f;
	public float life_time = 0.3f;

	Rigidbody rigid;

	void Awake(){

		rigid = GetComponent<Rigidbody> ();
		rigid.AddForce (transform.forward * speed);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Destroy (this.gameObject, life_time);
		
	}
}
