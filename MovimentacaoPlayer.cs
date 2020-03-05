using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoPlayer : MonoBehaviour
{
    private Animator playerAnimator;

    private Rigidbody2D playerRb;

    public bool Grounded;

    public int IdAnimation;

    public float Jump;

    public float speed;

    public bool lockleft;

    public bool atacking;

    private Vector3 dir =Vector3.right;

    // Start is called before the first frame update
    void Start()
    {
      playerRb = GetComponent<Rigidbody2D>();
      playerAnimator = GetComponent<Animator>();  
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
        if (Input.GetButtonDown("Fire1") && v >= 0)
        {
            playerAnimator.SetTrigger("Atack");
            

        }
       
     
        if (Input.GetButtonDown("Jump"))
        {
            playerRb.AddForce(new Vector2(0, Jump));
            
        }

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
