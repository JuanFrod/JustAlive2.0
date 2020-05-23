using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
     
    public float damage = 10;
    public float range = 10;
    public Camera CamaraPersonaje;
    public GameObject effect;
    public float impactForce = 30f;
    public ParticleSystem muzzleFlash;

    public GameObject impactGO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
          
           Disparar();

        }
    }

void Disparar() {
 muzzleFlash.Play();           
RaycastHit hit;
if(Physics.Raycast(CamaraPersonaje.transform.position, CamaraPersonaje.transform.forward, out hit, range)){


 var objetivo = hit.transform.GetComponent<VidaEnemigo>();

  if(objetivo != null){

   objetivo.RecibirDaño(damage);

  }  

  if(hit.rigidbody != null){

  hit.rigidbody.AddForce(-hit.normal * impactForce);

  }

  GameObject impactGO = Instantiate(effect, hit.point, Quaternion.LookRotation(hit.normal));
  Destroy(impactGO, 2f);

  }


 

}


}
  
