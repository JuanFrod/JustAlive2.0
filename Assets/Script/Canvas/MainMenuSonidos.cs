using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSonidos : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip Encima;
    public AudioClip Click;

    public async void EncimaSonido(){
        Source.PlayOneShot(Encima);
    }

    public async void UndirSonido(){
        Source.PlayOneShot(Click);
    }
}
