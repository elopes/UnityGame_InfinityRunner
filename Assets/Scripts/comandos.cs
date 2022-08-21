using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class comandos : MonoBehaviour
{

    public void menu(string cena) 
   {
        SceneManager.LoadScene(cena); 
   }

   public void sair()
   {
     Application.Quit();
   }


}
