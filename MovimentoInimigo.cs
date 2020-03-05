using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimentoInimigo : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float velo;
    public float timeLeft;
    bool facingRight = false;
    bool noChao = false;
    public Transform mao;
    Transform groundCheck;
    public float lifeinimigo;
    public Transform  Target;
    public float Speed = 2.5f;
    public GameObject Magia;
    public GameObject obj;
    private Vector3 dir =Vector3.right;
    public float countdown = 4.0f;
    public bool lockleft;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("graundCheck");
    }
    public void interacao()
    {
     lifeinimigo += -10;
     if (lifeinimigo == 0)
			{
				Destroy(gameObject);
			}
    }
    // Update is called once per frame
    void Update()
    {
         float h = Input.GetAxisRaw("Horizontal");
         float v = Input.GetAxisRaw("Vertical");
        
        if(h > 0 && lockleft == true){
            flip();
            
        
                        
        }else if(h < 0 && lockleft == false){
            flip();
                  
        }
         countdown -= Time.deltaTime;
             if(countdown <= 0.0f){
                float x = transform.localScale.x;
           
                obj = Instantiate(Magia, new Vector3(transform.position.x,transform.position.y,transform.position.z), transform.rotation);
                obj.GetComponent<MovimentoMagiadoInimigo>().Speed *= x;
                countdown = 4.0f;
                }
         
                


     
         if (lifeinimigo == 0)
			{
				Destroy(gameObject);
			}
        transform.position = Vector2.MoveTowards(transform.position, Target.position, velo * Time.deltaTime);

        /*timeLeft -= Time.deltaTime;
         if(timeLeft < 0)
         {
             speed *= -1;
         }
      */
        
        /*
        noChao = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("ground"));
	    if (!noChao)
	    {	
	        speed *= -1;
	    }
        */
    }
   

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        
       
    }
    void flip(){
        
        lockleft = !lockleft;
        float x = transform.localScale.x;
        x *= -1;
        transform.localScale =new Vector3(x, transform.localScale.y, transform.localScale.z);
        dir.x = x;
        dir = dir;
        
        
    }
}
