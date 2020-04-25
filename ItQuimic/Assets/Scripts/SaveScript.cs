using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


[RequireComponent(typeof(GPS))]
public class SaveScript : MonoBehaviour {


    //................................................................EXPLICACIÓ..............................................................................

        //Necessita script GPS.
        //Si el dispositiu es un movil o tauleta, guarda una ruta, sino t'avisa que o hi estas.
        //Guarda la latitud i la longitud a l'arxiu de la ruta creada.
        //Busca/carrega les dades guardades a l'arxiu.
        //Cada segon actualitza la distancia entre el punt actual i la guardada 

    //................................................................EXPLICACIÓ..............................................................................

    public GameObject panelEliminar;
    public Text dadesAEliminar;  
    private float distancia;  
    private GPS GPS; 
    private string savePath;  
    float _eQuatorialEarthRadius = 6378.1370f; 
    float _d2r = (Mathf.PI / 180f); 
    public Text distanciaMetres; 
    public GameObject panelSerCoordenades; 
    public Text textSerCoordenades; //al ser a les cordenades surt el panell amb el text guardat

    //Al començar, agafa el component de GPS, i guarda la ruta on guardarà
    void Start() {

        GPS = GetComponent<GPS>();

        if (DeviceType.Handheld == SystemInfo.deviceType) {
            savePath = Application.persistentDataPath + "/gamesave.save";
        } else {
            Debug.Log("Per a utilitzar aquesta aplicació necessites un movil o una tablet");
        }
    }

    //Guardar la latitud, longitud i el text en el document del lloc que vols guardar
    public void SaveData() {
        var save = new Save() {
            SavedLat = GPS.GameLat,
            SavedLong = GPS.GameLong,
        };

        var binaryFormatter = new BinaryFormatter();

        using (var fileStream = File.Create(savePath)) {
            binaryFormatter.Serialize(fileStream, save);
        }
        Debug.Log("Dades guardades");
    }

    //Recuperar les dades de l'arxiu (??)
    public void LoadData(){

        //si existeix l'arxiu, carrega les dades
        if (File.Exists(savePath) && DeviceType.Handheld != SystemInfo.deviceType) { 

            Save save;
            var binaryFormatter = new BinaryFormatter();

            using (var fileStream = File.Open(savePath, FileMode.Open)) {
                save = (Save)binaryFormatter.Deserialize(fileStream);
            }
            Debug.Log("Dades carragades");
        } else {
            Debug.Log("L'arxiu amb les dades guardades no existeix");
        }
    }

    //Cada moment, va actualitzant la distancia entre el punt guardat i la localitzacio actual. i ho mostra per text distancia
    void FixedUpdate() {
    
        Save save;
        var binaryFormatter = new BinaryFormatter();

        using (var fileStream = File.Open(savePath, FileMode.Open)) {
            save = (Save)binaryFormatter.Deserialize(fileStream);
        }

        distancia = (1000f * HaversineInKM(save.SavedLat, save.SavedLong, GPS.GameLat, GPS.GameLong));
        distanciaMetres.text = distancia.ToString() + " m";

        //quan estigui aprop de l'objectiu, que faci x
        if (distancia <= 2.0f) {
            //mostrar el panell i el text guardat en  aquella localitzacio si esta  a dos metres o menys
            if (panelSerCoordenades != null) { //si no hi ha res guardat 
                bool isActive = panelSerCoordenades.activeSelf;
                panelSerCoordenades.SetActive(!isActive);
            }
            textSerCoordenades.text = save.SavedText;
        }
    }

    //formula per a calcular la distancia
    private float HaversineInKM(float lat1, float long1, float lat2, float long2) {
        float dlong = (long2 - long1) * _d2r;
        float dlat = (lat2 - lat1) * _d2r;
        float a = Mathf.Pow(Mathf.Sin(dlat / 2f), 2f) + Mathf.Cos(lat1 * _d2r) * Mathf.Cos(lat2 * _d2r) * Mathf.Pow(Mathf.Sin(dlong / 2f), 2f);
        float c = 2f * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1f - a));
        float distancia = _eQuatorialEarthRadius * c;

        Debug.Log("entra4747474744");

        return distancia;
    }
}







































































































































































































































/* public void Confirmar() {
     //Obre panell de confirmacio de si es vol eliminar o no el text
     if (panelEliminar != null) {
         bool isActive = panelEliminar.activeSelf;
         panelEliminar.SetActive(!isActive);
     } else {
         return;
     }
     //Agafar les dades al document i mostrarles al panell d'eliminar
     if (File.Exists(savePath)) {
         Save save;
         var binaryFormatter = new BinaryFormatter();
         using (var fileStream = File.Open(savePath, FileMode.Open)) {
             save = (Save)binaryFormatter.Deserialize(fileStream);
         }
         dadesAEliminar.text = ("Lat: " + save.SavedLat + " Long: " + save.SavedLong + " Text: " + save.SavedText);
         Debug.Log("Dades carragades");
     } else {
         Debug.Log("L'arxiu amb les dades guardades no existeix");
     }
 }*/
/*
//Eliminar les dades guardades
public void DeleteData() {
var save = new Save() {
    SavedLat = 0,
    SavedLong = 0,
    SavedText = null
};
var binaryFormatter = new BinaryFormatter();
using (var fileStream = File.Create(savePath)) {
    binaryFormatter.Serialize(fileStream, save);
}
panelEliminar.SetActive(false);
Debug.Log("Dades eliminades");
}
*/