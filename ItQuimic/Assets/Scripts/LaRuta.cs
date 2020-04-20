using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LaRuta {

    //................................................................EXPLICACIÓ..............................................................................

        //Guarda per cada itinerari si les parades 8-9 i 10 són disponibles o no.

    //................................................................EXPLICACIÓ..............................................................................



    //CURT:          1 2 3 4 5 6 7 * * ** 11   true  true
    //MITJA:         1 2 3 4 5 6 7 * * 10 11   true  false
    //LLARG/COMPLET: 1 2 3 4 5 6 7 8 9 10 11   false false

    //depenent l'itinerari que s'ha clicat. nomes una escena que faci de totes depenent de les parades 

    //si es clica boto de curt es posa vuitnou i deu a true i s'obra l'escena amb la ruta daquelles parades
    //si es clica boto de mitja es posa vuitnou a true i s'obra escena amb la ruta de tots menya 8 i 9
    //si es clica boto de llarg es posen totes les parades i s'obra escena amb totes les parades

    public bool vuitNou = true; //si esta en true, lno es pasa per les parades 8 i 9
    public bool deu = true;   //si esta en true, no es pasa per la parada 10
}
