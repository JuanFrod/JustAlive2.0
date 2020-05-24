using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class MainMenu : MonoBehaviour
{
    public Animator animator;

    public void Jugar()
    {
        StartCoroutine("Fade");
    }

    public void Atras()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Salir()
    {
        Application.Quit();
    }

    IEnumerator Fade() 
    {
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Principal");
    }

 }
