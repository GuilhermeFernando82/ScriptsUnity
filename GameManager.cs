using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static  GameManager instance;
    private float life = 100;
    private float mana1 = 100;
    public GameObject hud;
    private GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        AtualizaHud();
    }

    // Update is called once per frame
    void Update()
    {
        
        AtualizaHud();
        if(life <= 0){
            SceneManager.LoadScene(1);
            life = 0;
        }
    }
     public void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.name == "Inimigo" || col.gameObject.name == "Inimigo2" || col.gameObject.name == "Inimigo3")
        {
            life += -0.125f;
            AtualizaHud();
      }
    }
    public void OnCollisionExit2D(Collision2D col){
        if(col.gameObject.name == "Inimigo" || col.gameObject.name == "Inimigo2" || col.gameObject.name == "Inimigo3" )
        {
            life += -0.125f;
            AtualizaHud();
      }
    }
    public void AtualizaHud(){
	    hud = GameObject.Find("LifeText");
        hud.GetComponent<Text>().text = life.ToString();
        
    }
     
  
}
