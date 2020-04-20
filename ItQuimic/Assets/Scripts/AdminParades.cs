using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(GPS))]
public class AdminParades : MonoBehaviour {


    //................................................................EXPLICACIÓ..............................................................................

    //Guarda a les llistes latParades i lonParades la latitud i la longitud respectivament de cada parada
    //Mira on esta el jugador. Comprovant si esta prou aprop del punt de la parada com per a activar el boto d'informació i la camera amb l'objecte amb realitat augmentada
    //Activa/desactiva el panell amb la foto del mapa de la pantalla de parades
    //Activa/desactiva el text amb el text de la parada de la pantalla de parades
    //Enfosqueix el fons (activar/desactivar un panell), i activa/desactiva el panell que conté el titol i el text curt explicatiu de cada parada. Posa el titol de la parada al panell.

    //................................................................EXPLICACIÓ..............................................................................


    public GameObject panell;
    public GPS gps;
    public Text titolP;
    public Text descripcio;

    public GameObject enfosquir;
    public GameObject PanfotoMapa;
    public List<double> latParades = new List<double>();
    public List<double> lonParades = new List<double>();


    private bool fotoMapAct = false;
    //Depenent del boto que toqui s'haura de canviar el text del panell que s'obre


    //Controlar quina es la seguent parada. agafar les seves cordinades i quan estigui aprop, actiivar boto info (avisar) i quan estigui alla, acriva boto camera (avisar) 

    void Start() {
       // List<double> latParades = new List<double>();
        latParades.Add(41.984895); //1  //1   41.984895  , 2.828841
        latParades.Add(41.984314); //2  //2   41.984314  , 2.828180
        latParades.Add(41.984963); //3  //3   41.984963  , 2.826188

        latParades.Add(41.985166); //4  //4   41.985166  , 2.824720
        latParades.Add(41.985312); //5  //5   41.985312  , 2.824791
        latParades.Add(41.985497); //6  //6   41.985497  , 2.824239
        latParades.Add(41.985587); //7  //7   41.985587  , 2.823518

        //41.985166, 2.824720

        latParades.Add(41.987246); //8    41.987246 , 2.822837
        latParades.Add(41.987971); //9    41.987971 , 2.824257
        latParades.Add(41.986793); //10   41.986793 , 2.824463
        latParades.Add(41.985342); //11   41.985342 , 2.824953

        lonParades.Add(2.828841); // 2.828841
        lonParades.Add(2.828180); // 2.828180
        lonParades.Add(2.826188); // 2.826188

        lonParades.Add(2.824720); // 2.824720
        lonParades.Add(2.824791); // 2.824791
        lonParades.Add(2.824239); // 2.824239
        lonParades.Add(2.823518); // 2.823518

        lonParades.Add(2.822837); //8   2.822837
        lonParades.Add(2.824257); //9   2.824257
        lonParades.Add(2.824463); //10  2.824463
        lonParades.Add(2.824953); //11  2.824953
    }

    public void mirarOnSoc () {
        // Mirar a la posicio que esta i si es una de les guardades a les llistes,
        // depenent de la distancia activa info, o info i camera

        for (int i = 0; i < 11; i++) {
            //si esta al mateix punt identic pot estar a mes i a menys primer mirar per a info despres per a camera

            //informacio
            if ( ((lonParades.Contains(gps.GameLong + 0.000003)) && (lonParades.Contains(gps.GameLong - 0.000003))) &&
                ((latParades.Contains(gps.GameLat + 0.000003)) && ((latParades.Contains(gps.GameLat - 0.000003))))) {

                //activar boto informacio
                // panell informació disponible

                //camera
                if ( ((lonParades.Contains(gps.GameLong + 0.000001)) && (lonParades.Contains(gps.GameLong - 0.000001)) 
                    && ((latParades.Contains(gps.GameLat + 0.000001)) && (latParades.Contains(gps.GameLat - 0.000001))))) {
                    // activar boto camera
                    //panell camera disponible
                }
            }
        }
    }

    public void PosarFoto () {
        PanfotoMapa.SetActive(!fotoMapAct);
        fotoMapAct = !fotoMapAct;
    }

    public void TextSegonsParada (int numero)
    {
        switch (numero)
        {
            case 1:
                PosarDescripcio("parada 1");
                break;
            case 2:
                PosarDescripcio("parada 2");
                break;
            case 3:
                PosarDescripcio("parada 3");
                break;
            case 4:
                PosarDescripcio("parada 4");
                break;
            case 5:
                PosarDescripcio("parada 5");
                break;
            case 6:
                PosarDescripcio("parada 6");
                break;
            case 7:
                PosarDescripcio("parada 7");
                break;
            case 8:
                PosarDescripcio("parada 8");
                break;
            case 9:
                PosarDescripcio("parada 9");
                break;
            case 10:
                PosarDescripcio("parada 10");
                break;
            case 11:
                PosarDescripcio("parada 11");
                break;
        }
    }

    public void PosarDescripcio (string desc) {
        descripcio.text = desc;
    }

    public void PosarTitol (string titol) {
        enfosquir.SetActive(true);
        panell.SetActive(true);
        titolP.text = titol;
    }
}