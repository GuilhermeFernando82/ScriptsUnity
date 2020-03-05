using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkEnemy : MonoBehaviour
{
    public GameObject hud;
    public float dano = -5;
    public Transform Target;
    public GameObject obj;
    public GameObject Magia1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         float x = transform.localScale.x;
         obj = Instantiate(Magia1, new Vector3(transform.position.x,transform.position.y,transform.position.z), transform.rotation);
         obj.GetComponent<MovimentoMagia>().vel *= x;
       
    }
    public void OnCollisionStay2D(Collision2D col){
        if(col.gameObject.name == "Barbarian1_0")
        {
            hud = GameObject.FindGameObjectWithTag("Player");
            hud.GetComponent<_GameController>().life += dano;

      }
    }
}
