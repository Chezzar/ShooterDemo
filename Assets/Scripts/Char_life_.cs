using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_life_ : MonoBehaviour {

	Char_stats stats_char;

	// Use this for initialization
	void Start () {

		stats_char = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Char_stats>();

	}

	void OnTriggerEnter(Collider col){

		if (col.tag == "Player" && stats_char.life > 1) {
			stats_char.life += 3;
			Destroy (this.gameObject,0.1f);
		}
	}
}
