using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(GPS))]
public class DistanciaParada : MonoBehaviour {
    private float distancia;
    private GPS GPS;
    float _eQuatorialEarthRadius = 6378.1370f;
    float _d2r = (Mathf.PI / 180f);
    public GameObject BotoPreguntes;

    void Update() {

        //1    41.984895 , 2.828841
        //2    41.984314 , 2.828180
        //3    41.984963 , 2.826188
        //4    41.985166 , 2.824720
        //5    41.985312 , 2.824791
        //6    41.985497 , 2.824239
        //7    41.985587 , 2.823518
        //8    41.987246 , 2.822837
        //9    41.987971 , 2.824257
        //10   41.986793 , 2.824463
        //11   41.985342 , 2.824953

        //Els dos primers son les coordenades de la proxima parada a on han d'anar

        distancia = (1000f * HaversineInKM(41.984895f, 2.828841f, GPS.GameLat, GPS.GameLong)); //Hi ha la primera parada


        //Si esta a menys de la distancia especificada, es mostrarà a la pantalla un botó per a contestar les preguntes
        if (distancia <= 2.0f) {
            BotoPreguntes.SetActive(true);
        } else {
            BotoPreguntes.SetActive(false);
        }
    }

    //Formula per a calcular la distancia entre dos punts
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