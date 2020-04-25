using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(LaRuta))]
public class dropDown : MonoBehaviour {


    //................................................................EXPLICACIÓ..............................................................................

    //Crea una llista amb les diferents opcions de ruta en una llista (dropdown) a escollir.
    //Depenent de l'opció que elegeixi, si agafen la primera opció, desactiva el botó d'entrar al joc. en cas contrari, l'activa.
    //Depenent de l'opció escollida, posa true o false a les parades que son opcionals depenent de la ruta escollida i carrega l'escena que toca.
    
    //................................................................EXPLICACIÓ..............................................................................


    public Dropdown dropdown;
    public LaRuta ruta;
    public Button botoComen;

    List<string> noms = new List<string>() { "Selecciona un itinerari" ,"Itinerari llarg", "Itinerari mitjà", "Itinerari curt" };

    public void Dropdown_IndexChanged ()
    {
        dropdown.GetComponent<Dropdown>();
        if (dropdown.value == 0) {
            botoComen.gameObject.SetActive(false);
            //botoComen.IsInteractable(false);
        } else {
            botoComen.gameObject.SetActive(true);
        }
    }

    public void ComencarJoc () {
        int itinerari = dropdown.value;
        switch (itinerari) {
            //true si es cancela
            case 1:
                //llarg
                //es juga amb totes les parades
                ruta.deu = false;   ruta.vuitNou = false;
                SceneManager.LoadScene("ItinerariLlarg");
                break;
            case 2:
                //mitja
                ruta.deu = false;    ruta.vuitNou = true;
                SceneManager.LoadScene("ItinerariMitja");
                break;
            case 3:
                //curt
                ruta.deu = true;    ruta.vuitNou = true;
                SceneManager.LoadScene("ItinerariCurt");
                break;
        }
    }

    void Start()
    {
        PopulateList();
    }

    //Afegir la llista per a escollir l'itinerari a seguir
    void PopulateList ()
    {
        dropdown.AddOptions(noms);
    }
}