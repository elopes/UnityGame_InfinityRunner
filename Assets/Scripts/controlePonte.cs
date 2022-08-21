using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlePonte : MonoBehaviour
{
     private gameController gcontroller;
     private Rigidbody2D ponteRb;

     private bool instanciado;

    // Start is called before the first frame update
    void Start()
    {
        //acessa a classe de controle
        gcontroller=FindObjectOfType(typeof(gameController)) as gameController;
        ponteRb = GetComponent<Rigidbody2D>();
        //movimenta a ponte 
        ponteRb.velocity= new Vector2(gcontroller.velocidadePonte,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(instanciado==false)
        {
            // Limita uma instância a cada frame
            if(transform.position.x <=0)
            {
                instanciado=true;
                //Instancia o objeto
                GameObject temp=Instantiate(gcontroller.pontePrefab);
                float posX=transform.position.x + gcontroller.tamanhoPonte;
                float posY=transform.position.y;
                temp.transform.position= new Vector3(posX,posY,0);
            }
        }

        if(transform.position.x < gcontroller.distanciaDestruir)
        {
            //destroi o objeto
            Destroy(this.gameObject);
        }
    }
}
