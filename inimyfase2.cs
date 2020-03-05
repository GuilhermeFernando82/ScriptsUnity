using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimyfase2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float timeLeft;
    bool facingRight = false;
    bool noChao = false;
    public Transform mao;
    Transform groundCheck;
    public float lifeinimigo;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("graundCheck");
    }
    public void interacao1()
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
        timeLeft -= Time.deltaTime;
         if(timeLeft < 0)
         {
             speed *= -1;
         }
         
        
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
}
