using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_shoot : MonoBehaviour {


	public AudioSource shoot;

	public GameObject Bullet;

	public int ammo = 30;

	private float cooldown;

	public float axis_y;

	private bool active = false;

	public float time_recarga;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		time_recarga += Time.deltaTime;

		if(time_recarga > 2 && ammo < 10){
			ammo += 1;
			time_recarga = 0;
		}

		axis_y = Input.GetAxis("Mouse Y");

		transform.Rotate (new Vector3 (-axis_y, 0 ,0));

		if (Input.GetMouseButtonDown (0) && !active && ammo >0) {
			Instantiate (Bullet,this.transform.position,this.transform.rotation);
			ammo -= 1;
			active = true;
		}

		if (active)
			cooldown += Time.deltaTime;

		if (cooldown > 0.5f)
			active = false;
	}

	void FixedUpdate(){


	}
}
