using UnityEngine;
using TMPro;

public class MostrarScore : MonoBehaviour
{

    private AccesoBase accesoBase;
    private TextMeshPro ScoreOut;
    // Start is called before the first frame update
    void Start()
    {
        accesoBase = GameObject.FindGameObjectWithTag("AccesoBase").GetComponent<AccesoBase>();
        ScoreOut = GetComponentInChildren<TextMeshPro>();
        Invoke("Mostrar",2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private async void Mostrar(){
        var task = accesoBase.TraerScores();
        var result = await task;
        var linea = "";

        foreach(var score in result)
        {
            linea += score.Jugador + " Puntuacion: " + score.score + "\n";
        }


        ScoreOut.text = linea;

    }
}
