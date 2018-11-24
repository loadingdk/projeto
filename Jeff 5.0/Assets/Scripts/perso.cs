using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class perso : MonoBehaviour {
	public float velocidade = 40f;
    public float forcaPulo;
    public bool pulo = true;
    Rigidbody2D rb;

    public int Vida;
    public Text TextVida;
        void Start () 
    {
        TextVida.text = Vida.ToString();
		rb = GetComponent<Rigidbody2D>();
    }
    
    void Update () 
    {
        TextVida.text = Vida.ToString();
		Movimentacao();
        Pulo();
        restar();
    }


    void FixedUpdate()
    {
        
        //Virar Personagem

        if((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow))){
            GetComponent<SpriteRenderer>().flipX = false;
        }else if((Input.GetKey(KeyCode.D))|| (Input.GetKey(KeyCode.RightArrow))){
            GetComponent<SpriteRenderer>().flipX = true;
        }

        //Iniciar animação de movimento
        if((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow))){
            GetComponent<Animator>().SetBool("Andar", true );
        }else{
            GetComponent<Animator>().SetBool("Andar", false );
        }

        //Iniciar animação das Ondas de Perturbação
        if(Input.GetKey(KeyCode.LeftShift)){
            GetComponent<Animator>().SetBool("OndasDePerturbacao", true );
            GetComponent<AudioSource>().Play();//ativa o audio do Hadouken.
        }else{
            GetComponent<Animator>().SetBool("OndasDePerturbacao", false );
        }
    }
		//parte da movimentacao
	void Movimentacao()
    {
        if ((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            rb.velocity = new Vector2(-velocidade * Time.deltaTime, rb.velocity.y);
        }
        if ((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow)))
        {
            rb.velocity = new Vector2(velocidade * Time.deltaTime, rb.velocity.y);
        }
    }

    void Pulo()
    {
        if ( Input.GetKeyDown(KeyCode.Space))
        {
            if (pulo)
            {
                rb.AddForce(new Vector2(0f, forcaPulo), ForceMode2D.Impulse);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("Colidiu");
        if (collision.gameObject.CompareTag("Chao"))
        {
            Debug.Log("No chão");
            pulo = true;
            rb.drag = 10;// coloca arrasto no chao.

        }
    }

    void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Chao"))
        {
            Debug.Log("Saiu do chão");
            pulo = false;
            rb.drag = 0;//retira o arrasto durante o pulo.
        }
    }
    public void restar(){
        if((Input.GetKey(KeyCode.B))){
		UnityEngine.SceneManagement.Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene.name);}
    }

}
