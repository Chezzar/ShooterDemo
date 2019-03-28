using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats_enemy : MonoBehaviour {


	GameObject char_;

	Stats_UI stats_global;

	Char_stats stats_char;

	public int life = 5;

	public int damage = 3;

	public GameObject[] loot;

	// Use this for initialization
	void Start () {

		char_ = GameObject.FindGameObjectWithTag("Player").gameObject;
		stats_global = GameObject.FindGameObjectWithTag ("Stats").transform.GetComponent<Stats_UI> ();
		stats_char = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Char_stats>();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (life <= 0) {

			if (Random.Range (0, 4) == 0) {
				
				Instantiate (loot [Random.Range (0, loot.Length)], this.transform.position + new Vector3 (0, 0.5f, 0), Quaternion.identity);
			}
			stats_global.score_UI += 1;
			Destroy (this.gameObject);
		}
		
	}

	void OnTriggerEnter(Collider col){

		if (col.tag == "Weapon")
			life -= 1;

		if (col.tag == "Player") {
			stats_char.life -= 1;
			char_.GetComponent<Rigidbody>().AddForce(-col.transform.forward * 1000);
		}
	}
		
}
