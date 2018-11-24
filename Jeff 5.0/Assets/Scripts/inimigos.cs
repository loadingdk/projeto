using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigos : MonoBehaviour {
	private float time=0.0f;
	public float tempo;
	public float forca;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		saltoLateal();
	}
	public void saltoLateal(){
		time +=Time.deltaTime;
		if(time >= tempo){
			time = 0f;
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0,forca),ForceMode2D.Impulse);
		}
	}
	
}
