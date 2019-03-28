using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_ammo_ : MonoBehaviour {

	Weapon_shoot stats_weapon;

	// Use this for initialization
	void Start () {

		stats_weapon = GameObject.FindGameObjectWithTag("Player").transform.Find("Weapon").transform.GetComponent<Weapon_shoot>();

	}

	void OnTriggerEnter(Collider col){

		if (col.tag == "Player") {
			stats_weapon.ammo += 6;
			Destroy (this.gameObject,0.1f);
		}
	}
}
