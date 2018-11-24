using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class plataformaMovel : MonoBehaviour {

	public float MinY,MaxY,MinX,MaxX,VelocidadeX,VelocidadeY;
		// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = new Vector2 (VelocidadeX, VelocidadeY);
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.localPosition.y > MaxY){
			GetComponent<Rigidbody2D>().velocity= new Vector2 (GetComponent<Rigidbody2D>().velocity.x, -VelocidadeY);}
		else if(transform.localPosition.y < MinY){
			GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, VelocidadeY);}
		if(transform.localPosition.x > MaxX){
            GetComponent<Rigidbody2D>().velocity= new Vector2 (-VelocidadeX, GetComponent<Rigidbody2D>().velocity.y);}
		else if(transform.localPosition.x < MinX){
            GetComponent<Rigidbody2D>().velocity = new Vector2 (VelocidadeX, GetComponent<Rigidbody2D>().velocity.y);}
	}
}
