using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    private player pcontroller;

[Header("Config. Personagem")]
   //Limite de movimentação
    public float limiteMaxY;
    public float limiteMinY;
     public float limiteMaxX;
    public float limiteMinX;
    //velocidade do personagem
    public float velocidade;

    [Header("Config. Ponte")]
    public float velocidadePonte;
    public float distanciaDestruir;

    public float tamanhoPonte;

    //Declaro o objeto que irei instanciar posteriormente
    public GameObject pontePrefab;

    [Header("Config. Barril")]
    
    //order in Layer do Barril
    public int orderInLayerTop;
    public int orderInLayerDown;

    //Posição do Barril
    public float  posYTop;
    public float posYDown;

    public float tempoSpawn;
    public GameObject barrilPrefab;

    [Header("Globals")]

    public int score;
    
    //Classe Text pertence a UnityEngine.UI
    public Text TxtScore;

    public float posXPlayer;

    [Header("FX Sound")]
    public AudioSource fxSource;
    public AudioClip fxPontos;
    
    // Start is called before the first frame update
    void Start()
    {
        pcontroller=FindObjectOfType(typeof(player)) as player;
        
        //inicializa a coroutina
        StartCoroutine("spawnBarril");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Após a atualização do frame
    //Ocorre imediatamente após o término do Update
    void LateUpdate() {
        posXPlayer= pcontroller.transform.position.x;
    }

    // aguarda o tempo de spawn e instancia o objeto
    IEnumerator spawnBarril()
    {        
        //aguarde o tempo de spawn 
        yield return new WaitForSeconds(tempoSpawn);

        float posY=0;
        int order=0;

        //posição aleatória das instancias do barril
        int rand = Random.Range(0,100);
        if(rand < 50)
        {
            //instancia na posição de cima
            posY=posYTop;
            order=orderInLayerTop;

        }
        else
        {
            //instancia na posição de baixo
            posY=posYDown;
            order=orderInLayerDown;
        }        

        //Instancie o barril
        GameObject temp = Instantiate(barrilPrefab);

        //posição inicial do barril
        temp.transform.position=new Vector3(temp.transform.position.x, posY,0);
        temp.GetComponent<SpriteRenderer>().sortingOrder=order;

        //chamada recursiva a coroutina
        StartCoroutine("spawnBarril");

    }

    public void pontuar(int pontos)
    {
        score+=pontos;
        TxtScore.text="Score: " + score.ToString();
        fxSource.PlayOneShot(fxPontos);
    }

    public void mudaCena(string cena)
    {
        SceneManager.LoadScene(cena);
    }



}
