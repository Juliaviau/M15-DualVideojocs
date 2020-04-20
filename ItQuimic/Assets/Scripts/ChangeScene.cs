using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(LaRuta))]
public class ChangeScene : MonoBehaviour {
    //................................................................EXPLICACIÓ..............................................................................

    //Canvia d'escena i activa/desactiva el panell d'informació de la parada a la pantalla de dins l'itinerari. A partir del botó d'informació

    //................................................................EXPLICACIÓ..............................................................................

    public LaRuta ruta;

    public void canviarScena (string scene)
    {
        SceneManager.LoadScene(scene);
    }

    //AL CARREGAR L'ESCENA DEPENENT DEL LARUTA I DROPDOWN CARREGAR PER UNA RUTA O PER UNA ALTRE

    //al clicar boto informació, si estas a'linici, surt informació de l'app
    //si estas en un dels itineraris, segons la parada que tinguis més aprop, posa l'informació sobre aquella parada
    //si estas dins el marge d'una parada, posa informacio sobre aquella parada i al tancar torna a lìtinerari que estava abans o un panell desactivat 

    public void ObrirUnOAltre () {
        
    }

    public GameObject panellInfo;
    private bool var = false;

    public void DesacAct()
    {
        var = !var;
        panellInfo.SetActive(var);
    }
}