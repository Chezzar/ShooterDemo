using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_enemy : MonoBehaviour {

	public GameObject[] enemies;
	public int count_enemies = 0;
	public float cooldown = 0f;
	public bool begin;
	public float spawn_time;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(cooldown >= spawn_time){
			Instantiate (enemies [Random.Range (0, enemies.Length)], 
				this.transform.position + new Vector3 (Random.Range(0,2),this.transform.position.y,Random.Range(0,2)), 
				Quaternion.identity);
			
			count_enemies += 1;
			begin = true;
		}

		if (!begin)
			cooldown += Time.deltaTime;
		else if (begin) {
			cooldown = 0f;
			begin = false;
		}
			
	}
}
