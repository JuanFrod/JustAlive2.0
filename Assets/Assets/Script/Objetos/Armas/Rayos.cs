using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;

public class Rayos : MonoBehaviour
{
    [SerializeField]
    public Camera cam;
    [SerializeField]
    public GameObject Zombie;
    [SerializeField]
    public GameObject Zombie1;
    [SerializeField]
    public float range;
    [SerializeField]
    public float damage = 25;
    [SerializeField]
    public ParticleSystem ps;
    Vector3 pos;
    string name1;
    string name2;
    bool s = false;
    public GameObject effect;
    public GameObject effect2;
    [SerializeField]
    public AudioSource shoot;

    void Start()
    {
        
        cam = GetComponent<Camera>();
        name1 = (Zombie.name);
        name2 = (Zombie1.name);

    }

    void Update()
    {
        //Check if mouse is clicked

        if (Input.GetMouseButtonDown(0))
        {
            
            Disparar();
          
        }

        

    }

    void Disparar()
    {
        shoot.Play();
         RaycastHit hit;
       
        

        Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(rayCast, out hit, range))
        {

             var objetivo = hit.transform.GetComponent<VidaEnemigo>();


            print(hit.collider.name);


            if (hit.collider.name != name1 )
            {
                if (hit.collider.name != name2)
                {

                    GameObject impactGO = Instantiate(effect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(impactGO, 1f);
                }

            }


                if (hit.collider.name == name1)
            {
               
                objetivo.RecibirDaño(damage);
                pos = hit.transform.position;
                GameObject impactGO1 = Instantiate(effect2, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO1, 1f);
            }

            if (hit.collider.name == name2)
            {

                objetivo.RecibirDaño(damage);
                pos = hit.transform.position;
                print(hit.collider.name);
                print("Hit");

                GameObject impactGO1 = Instantiate(effect2, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO1, 1f);
            }


        }

       
    }
    

}