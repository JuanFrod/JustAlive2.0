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
    public GameObject palm;
    [SerializeField]
    private TextMeshProUGUI Text;

    string name1;
    Vector3 pos;
    void Start()
    {
        Text = FindObjectOfType<TextMeshProUGUI>();
        cam = GetComponent<Camera>();
        Text.enabled = false;
    }

    void Update()
    {
        //Check if mouse is clicked





        if (Input.GetMouseButtonDown(0))
        {

            Disparar();

           
        }

        void Disparar()
        {
            RaycastHit hit;
            name1 = (palm.name);
            //Get ray from mouse postion
            Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Raycast and check if any object is hit
            if (Physics.Raycast(rayCast, out hit))
            {
                //var objetivo = hit.transform.GetComponent<VidaEnemigo>();

                print(palm.name);
                print(hit.collider.name);
                //Check which tag is hit
                if (hit.collider.name == name1)
                {
                    //object.RecibirDaño(damage);
                    pos = hit.transform.position;
                    print(hit.collider.name);
                    string post = pos.ToString();
                    
                    Text.enabled = true;



                }

            }


        }

    }

}