using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
 
public class ScriptPlayer : MonoBehaviour
{
    
    private Animator playerAnimator;

    private Rigidbody2D playerRb;

    public bool Grounded;

    public int IdAnimation;

    public float Jump;

    public float speed;

    public bool lockleft;

    public bool atacking;

    public Transform mao;

    public LayerMask layermask1;

    public LayerMask interacao;

    public Transform groundCheck;

    public Collider2D standing, crouching;
    public float vel = 8.5f;
    private Vector3 dir =Vector3.right;

    public GameObject objeto;
    public GameObject rb;
    public GameObject vida;
    public GameObject vida4;
    public GameObject vida5;
    public GameObject vida6;
    public GameObject Magia1;
    public GameObject hud;
    private SpriteRenderer GameOver;
    public float h;
    public float v; 
    public float manazero = 0;
    public static bool virado;
    public GameObject mana;
    public GameObject obj;
    private float mana1 = 100;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        GameOver = GetComponent<SpriteRenderer>();
        
    }

    void FixedUpdate()
    {
        Grounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f, layermask1);
        interagir();
        
    
    }

    // Update is called once per frame
    void Update()
    {
         if(mana1 < 0){
             hud = GameObject.Find("mana");   
             hud.GetComponent<Text>().text = manazero.ToString();
         }
         h = Input.GetAxisRaw("Horizontal");
         v = Input.GetAxisRaw("Vertical");
        
        if(h > 0 && lockleft == true){
            flip();
            virado = true;
            
                        
        }else if(h < 0 && lockleft == false){
            flip();
            virado = false;            
        }
        if (v < 0)
        {
            IdAnimation = 2;
            h = 0;
        }
        else if (h != 0)
        {
            IdAnimation = 1;
        }
        else
        {
            IdAnimation = 0;
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {   
            float x = transform.localScale.x;
            if(mana1 >= 10){
                obj = Instantiate(Magia1, new Vector3(transform.position.x,transform.position.y,transform.position.z), transform.rotation);
                obj.GetComponent<MovimentoMagia>().vel *= x;
            }else{
                print("Sem mana!!!");
            }
            
            mana1  += -10;
            AtualizaHudmana();
        }   
        if (Input.GetButtonDown("Fire1") && v >= 0 && objeto == null)
        {
            playerAnimator.SetTrigger("Atack");
            

        }
        if (Input.GetButtonDown("Fire1") && v >= 0 && objeto != null)
        {
               playerAnimator.SetTrigger("Atack");
               objeto.SendMessage("interacao",SendMessageOptions.DontRequireReceiver);
        }
     
        if (Input.GetButtonDown("Jump") && Grounded == true)
        {
            playerRb.AddForce(new Vector2(0, Jump));
            
        }
      
        
        if (v < 0 && Grounded == true)
        {
           crouching.enabled = true;
           standing.enabled = false;
        }else if(v >=0 && Grounded == true){
           crouching.enabled = false;
           standing.enabled = true;
        }else if(v != 0 && Grounded == false){
           crouching.enabled = false;
           standing.enabled = true;
        }
      
        playerRb.velocity = new Vector2(h * speed,  playerRb.velocity.y);
        

        playerAnimator.SetBool("chao", Grounded);
        playerAnimator.SetInteger("IdAnimations", IdAnimation);
        playerAnimator.SetFloat("SpeedY", playerRb.velocity.y);
        interagir();
        //life75();
        //life50();
        //life25();
          
        /*if(life <= 0){
            SceneManager.LoadScene(1);
            life = 0;
            AtualizaHud();
        }*/
       
      
    }
    
    void flip(){
        
        lockleft = !lockleft;
        float x = transform.localScale.x;
        x *= -1;
        transform.localScale =new Vector3(x, transform.localScale.y, transform.localScale.z);
        dir.x = x;
        dir = dir;
        
        
    }
   /*public void PassardeFase(){
	    if(!GameObject.Find("Inimigo") && !GameObject.Find("Inimigo2") && !GameObject.Find("Inimigo3")){
            SceneManager.LoadScene(3);
        }
       
    }
*/
    void Atack(int atk){
        switch(atk){
            case 0:
                atacking = false;
                break;
            case 1:
                atacking = true;
                break;
        }
    }
   public void AtualizaHudmana(){
	    hud = GameObject.Find("mana");
        hud.GetComponent<Text>().text = mana1.ToString();
        
    }


      /* void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Inimigo")
        {
            life += -5;
        }
     
    }*/


    /*
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "portal")
        {
            print("Você encontrou uma caixa");
        }
        /*if(col.gameObject.tag == "caixa")
        {
            print("Você colidiu com a caixa!!!");
        }
        
    }
    void OnCollisionExit2D(Collision2D col){
        if(col.gameObject.name == "portal")
        {
            print("Você saiu da caixa");
        }
    }
    void OnCollisionStay2D(Collision2D col){
        if(col.gameObject.name == "portal")
        {
            print("Você está tomando dano da caixa caixa");
        }
    }
     void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "tigger")
        {
            print("Isso é um tigger");
        }
     
    }
    */

    void interagir()
    {
       
        Debug.DrawRay(mao.position, dir * 1.2f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(mao.position, dir, 0.5f, interacao);
        if(hit == true)
        {
           objeto = hit.collider.gameObject;
        }else{
           objeto = null;
        }
    }

}
