using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private gameController gcontroller;
    
    //Acesso ao rigidbody 
    private Rigidbody2D personagemRb;

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount=1;
        Application.targetFrameRate=60;

        gcontroller=FindObjectOfType(typeof(gameController)) as gameController;

        //Inicializar o componente     
        personagemRb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {   //lendo o valor de entrada para os movimentos 
        float horizontal= Input.GetAxisRaw("Horizontal");
        float vertical= Input.GetAxisRaw("Vertical");
        
        //adicionando velocidade ao movimento
        personagemRb.velocity= new Vector2(horizontal * gcontroller.velocidade,vertical * gcontroller.velocidade);

        //recebe aposição atual do objeto
        float posY=transform.position.y;
        float posX=transform.position.x;

         //verifica limite x
        if(transform.position.x > gcontroller.limiteMaxX)
        {
            posX=gcontroller.limiteMaxX;

        }else if(transform.position.x < gcontroller.limiteMinX)
        {
             posX=gcontroller.limiteMinX;
        }

        //verifica limite Y
        if(transform.position.y > gcontroller.limiteMaxY)
        {
            posY=gcontroller.limiteMaxY;

        }else if(transform.position.y < gcontroller.limiteMinY)
        {
             posY=gcontroller.limiteMinY;
        }

        transform.position=new Vector3(posX,posY,0);


        }
        
         private void OnTriggerEnter2D() {
           gcontroller.mudaCena("GameOver");        
        }
              
}
