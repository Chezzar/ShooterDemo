using UnityEngine;
using System.Collections;

public class Poder_mago_enemie : MonoBehaviour {

	public int angulo; 
	public float velocidad;
	public float velocidad_1;
	public float velocidad_2;

	public float tiempo = 0;
	// Use this for initialization
	void Start () {

		velocidad_1 = Mathf.Cos (Mathf.Rad2Deg* angulo);

		velocidad_2 = Mathf.Sin (Mathf.Rad2Deg* angulo);
	
	}
	
	// Update is called once per frame
	void Update () {

		tiempo += Time.deltaTime;
		//angulo += 1;

		velocidad_1 = Mathf.Cos ((angulo * Mathf.PI)/180);// * Time.deltaTime * velocidad;

		velocidad_2 = Mathf.Sin ((angulo * Mathf.PI)/180);// * Time.deltaTime * velocidad;

		this.transform.position = new Vector3(this.transform.position.x + velocidad_1*Time.deltaTime*velocidad,
		                                      this.transform.position.y,
		                                      this.transform.position.z + velocidad_2*Time.deltaTime*velocidad);

		if (tiempo > 4f)
			Destroy (this.gameObject);

	
	}

	public void set_angulo(int ang){
		angulo = ang;

	}

	void OnTriggerEnter(Collider node){
		if (node.tag == "Player") {
			node.gameObject.GetComponent<Char_stats> ().life -= 1;
			Destroy (this.gameObject);
		}
	}
}
