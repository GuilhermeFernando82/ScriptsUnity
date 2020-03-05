using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoMagiadoInimigo : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;
    public GameObject hud;
    public float dano = -10;
    public Transform Target;
    public float countdown = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
         //Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       
            transform.Translate(new Vector2 (Speed * Time.deltaTime,0));
            //countdown = 3.0f;
        
         
         //transform.position = Vector2.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime); 
          
       
    }
    public void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.name == "Barbarian1_0")
        {
            hud = GameObject.FindGameObjectWithTag("Player");
            hud.GetComponent<_GameController>().life += dano;
            hud.GetComponent<_GameController>().AtualizaHud();

      }
    }

   /* public void OnCollisionStay2D(Collision2D col){
        if(col.gameObject.name == "Barbarian1_0")
        {
            hud = GameObject.FindGameObjectWithTag("Player");
            hud.GetComponent<MovimentoInimigo>().lifeinimigo += dano;

      }
    }
    public void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.name == "Barbarian1_0")
        {
            hud = GameObject.FindGameObjectWithTag("Player");
            hud.GetComponent<MovimentoInimigo>().lifeinimigo += dano;

      }
    }
    */
}
