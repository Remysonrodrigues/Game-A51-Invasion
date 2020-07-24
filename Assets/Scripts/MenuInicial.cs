using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    int primeiraVez = 0;
    int secunds= 36;
    public void ChamaCutscene()
    {   
        if(primeiraVez == 0){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Cutscene");
            primeiraVez++;
        }
        else{
             UnityEngine.SceneManagement.SceneManager.LoadScene("SceneFase3");
        }
    }
    public void menu()
    {

    }
    public void SairDoJogo()
    {
        Application.Quit();
    }

      void ChamaFase1()
    {
         if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("SceneFase3");     
        }
    }

}
