using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public AudioSource dead;
    public float vidaE = 10f;
    public void RecibirDaño(float Amount)
    {
        
vidaE -= Amount;
if(vidaE <= 0f)
{
    Muerte();
            dead.Play();

        }


    }

    // Update is called once per frame
    void Muerte()
    {
        Destroy(gameObject);
        dead.Play();
    }
}
