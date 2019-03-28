using UnityEngine;
using System.Collections;

public class Enemie_Mago : MonoBehaviour {


	public GameObject pared_der;
	public GameObject pared_izq;
	public GameObject pared_arr;
	public GameObject pared_aba;


	public float area = 0;
	public float dist_pared_der = 0;
	public float dist_pared_izq = 0;
	public float dist_pared_arr = 0;
	public float dist_pared_aba = 0;

	public float tiempo = 0;
	public float limite = 0;

	public Vector3 random_posicion;
	// Use this for initialization
	void Start () {

		pared_der = GameObject.Find ("Pared_der");
		pared_izq = GameObject.Find ("Pared_izq");
		pared_arr = GameObject.Find ("Pared_arr");
		pared_aba = GameObject.Find ("Pared_aba");

		limite = 5f;

	}
	
	// Update is called once per frame
	void Update () {

		this.transform.rotation = Quaternion.Euler(0,180,0);;

		dist_pared_der = Vector3.Distance (this.transform.position, pared_der.transform.position);
		dist_pared_izq = Vector3.Distance (this.transform.position, pared_izq.transform.position);
		dist_pared_arr = Vector3.Distance (this.transform.position, pared_arr.transform.position);
		dist_pared_aba = Vector3.Distance (this.transform.position, pared_aba.transform.position);

		area = Vector3.Distance (pared_izq.transform.position, pared_der.transform.position)
			   *
			   Vector3.Distance (pared_arr.transform.position, pared_aba.transform.position);

		if ((tiempo = Espera (limite, tiempo)) == 0) {
			random_posicion = new Vector3 (Random.Range (-9, 9), 0.6f, Random.Range (-9, 9));
			this.transform.position = random_posicion;
			Power_1 ();
			tiempo = 0;
		}
	
	}

	float Espera(float limit,float tiem){

		tiem += Time.deltaTime;

		if (tiem > limit)
			return 0;
		else
			return tiem;
	}

	void Teleport(){

	}

	void Power_1(){

		GameObject bala_1 = Instantiate(Resources.Load("Magia_mago", typeof(GameObject)),
		                                new Vector3(this.transform.position.x +1,this.transform.position.y,this.transform.position.z +1),
		                                Quaternion.identity) as GameObject;
		//bala_1.transform.SetParent (this.transform);
		bala_1.transform.GetComponent<Poder_mago_enemie> ().set_angulo (45);
		
		GameObject bala_2 = Instantiate(Resources.Load("Magia_mago", typeof(GameObject)),
		                                new Vector3(this.transform.position.x - 1,this.transform.position.y,this.transform.position.z + 1),
		                                Quaternion.identity) as GameObject;
		//bala_2.transform.SetParent (this.transform);
		bala_2.transform.GetComponent<Poder_mago_enemie> ().set_angulo (190 - 45);
		
		GameObject bala_3 = Instantiate(Resources.Load("Magia_mago", typeof(GameObject)),
		                                new Vector3(this.transform.position.x - 1,this.transform.position.y,this.transform.position.z - 1),
		                                Quaternion.identity) as GameObject;
		//bala_3.transform.SetParent (this.transform);
		bala_3.transform.GetComponent<Poder_mago_enemie> ().set_angulo (270 - 45);
		
		GameObject bala_4 = Instantiate(Resources.Load("Magia_mago", typeof(GameObject)),
		                                new Vector3(this.transform.position.x + 1,this.transform.position.y,this.transform.position.z -1),
		                                Quaternion.identity) as GameObject;
		//bala_4.transform.SetParent (this.transform);
		bala_4.transform.GetComponent<Poder_mago_enemie> ().set_angulo (360 - 45);
	}

	void OnTriggerEnter(Collider node){
		if (node.tag == "Weapon") {
			;
		}
	}
}
