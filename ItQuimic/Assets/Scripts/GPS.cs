using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GPS : MonoBehaviour {

    //................................................................EXPLICACIÓ..............................................................................

    //Comprova que hi hagi el GPS activat, si no ho esta. Surt. Si esta activat, busca la localització.
    //Busca la localització durant 15 segons si no la troba, surt error que no s'ha pogut inicialitzar el GPS.
    //Si no es pot geolocalitzar, surt error no s'ha pogut geolocalitzar. 
    //Si es pot, les guarda a coordenades que les mostra per pantalla. I les posa com a les actuals. Diu que GPS esta activat.
    //Sempre que estigui activat, actualitza les dades.
        
    //................................................................EXPLICACIÓ..............................................................................


    public static GPS Instance { set; get; }
    public float GameLat { get; set; }
    public float GameLong { get; set; }
    private bool isGPSready;
    public Text coordinates; //Diu les coordenades on esta
    public Text miss_errors;
    public GameObject panellErrors;

    IEnumerator Start() {

        //Comprovar que hi hagi el GPS activat
        if (!Input.location.isEnabledByUser)
            yield break;

        //Començar a localitzar el dispositiu
        Input.location.Start();

        //Esperar a que s'inicialitzi (com a maxim 15 segons)
        int maxWait = 15;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        //Si no s'ha inicialitzat en 15 segons, surt
        if (maxWait < 1) {
            miss_errors.text = miss_errors.text + " No s'ha pogut inicialitzar el GPS";
            print("Timed out");
            yield break;
        }

        //Si ha fallat la conexió i no es pot geolocalitzar el dispositiu
        if (Input.location.status == LocationServiceStatus.Failed) {
            miss_errors.text = miss_errors.text + " No s'ha pogut geolocalitzar el dispositiu";
            print("Unable to determine device location");
            panellErrors.SetActive(true);
            yield break;

        } else {
            //S'ha trobat la localitzacio del movil i es posa el text en el text anomenat cordenades

            //Posar les coordenades en el text
            coordinates.text = ("  Lat: " + Input.location.lastData.latitude + "  Long: " + Input.location.lastData.longitude);
            //Guarda la posicio actual
            GameLat = Input.location.lastData.latitude;
            GameLong = Input.location.lastData.longitude;
            //guarda la localització actual dins de les variables que es guardaran a l'script saveScript, Save
        }
        isGPSready = true; //gps esta activat
    }

    //canviar funcio per que 
    private void FixedUpdate() {
        //Sempre que hi hagi el GPS activat, actualitza el text, i posa be les variables
        if (isGPSready) {
            coordinates.text = ("  Lat: " + Input.location.lastData.latitude + "  Long: " + Input.location.lastData.longitude);
            GameLat          = Input.location.lastData.latitude;
            GameLong         = Input.location.lastData.longitude;
        }
    }
}