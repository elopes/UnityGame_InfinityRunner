using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controleBarril : MonoBehaviour
{

      private gameController gcontroller;
     private Rigidbody2D barrilRb;

     private bool ponto;

     private bool instanciado;
    // Start is called before the first frame update
    void Start()
    {
        gcontroller=FindObjectOfType(typeof(gameController)) as gameController;
        barrilRb = GetComponent<Rigidbody2D>();
        //movimenta a ponte 
        barrilRb.velocity= new Vector2(gcontroller.velocidadePonte,0);
        
    }

    // Update is called once per frame
    void Update()
    {
         if(transform.position.x < gcontroller.distanciaDestruir)
        {
            //destroi o objeto
            Destroy(this.gameObject);
        }
        
    }

    void LateUpdate(){
        if (ponto==false && transform.position.x < gcontroller.posXPlayer)
        {
            ponto=true;
            gcontroller.pontuar(10);
           
        }
    }


}
