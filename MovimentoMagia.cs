using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoMagia : MonoBehaviour
{
    public float vel = -100f;
    public GameObject hud;
    public float dano = -5;
    public Transform Target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
         transform.Translate(new Vector2 (vel * Time.deltaTime,0)); 
       
    }
     public void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.name == "Inimigo" || col.gameObject.name == "Inimigo2" || col.gameObject.name == "Inimigo3")
        {
            hud = GameObject.FindGameObjectWithTag("Inimigo1");
            hud.GetComponent<MovimentoInimigo>().lifeinimigo += dano;

      }
    }
}
