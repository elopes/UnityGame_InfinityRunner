using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOffset : MonoBehaviour
{
    //declaração do objeto meshrenderer
    private Renderer meshRenderer;
    private Material currentMaterial;
     
    [Header("Config. Offset")] 
    public float incrementaOffset;
    public float velocidade;
    public string sortingLayer;
    public int orderInLayer;
    private float offset;

    // Start is called before the first frame update
    void Start()
    {
        //acessa o componente
        meshRenderer=GetComponent<MeshRenderer>();
        //altera a layer
        meshRenderer.sortingLayerName=sortingLayer;
        //altera a ordem na layer
        meshRenderer.sortingOrder=orderInLayer;

        //recupera o material
        currentMaterial=meshRenderer.material;  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //efeito paralax
        offset += incrementaOffset;
        currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset*velocidade,0));
    }
}
