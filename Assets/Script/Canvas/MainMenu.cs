using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class MainMenu : MonoBehaviour
{

    public void Jugar()
    {
        SceneManager.LoadScene("TestMAP");
    }

    public void Instrucciones()
    {
        SceneManager.LoadScene("Instrucciones");
    }

    public void Atras()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Salir()
    {
        Application.Quit();
    }
 }
