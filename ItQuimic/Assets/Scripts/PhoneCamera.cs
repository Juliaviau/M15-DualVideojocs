using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneCamera : MonoBehaviour {

    //................................................................EXPLICACIÓ..............................................................................

        //START
        //Al començar, posen que la imatge de fons sigui una per a defecte, busca si el dispositiu té cameres i les posa en una lista.
        //Si no n'hi ha cap, surt un error dient que no n'hi ha, activa panell d'errors i posa que no hi ha cameres disponibles.
        //Si n'hi ha més de 0, per a cada camera trobada, mira si és frontal. Si no ho és, posa com a fons la imatge que surt de la pantalla.
        //Si totes són frontals, surt un error dient que no hi ha cap camera que no sigui frontal.
        //Quan el dispositiu te una camera de darrere, obre la camera, posa a la pantalla l'imatge que ve de la camera i posa que si hi ha una camera disponible.

        //UPDATE
        //Si no hi ha la camera disponible, retorna. Corregeix escala, tamany i rotació de la camera.

    //................................................................EXPLICACIÓ..............................................................................


    private bool camDisponible;            // comprovar si la camera esta disponible
    private WebCamTexture cameraTextura;        // agafar la textura de la camera del darrere
    private Texture fonsDefecte;    // la textura inicial del fons
    public RawImage fons;           // l'imatge del fons
    public AspectRatioFitter fit;         
    public Text missatgeError;
    public GameObject panellErrors;

    void Start()
    {
        //posar per defecte l'imatge de fons
        fonsDefecte = fons.texture;

        //Guardar dins la variable devices, tots els dispositius disponibles
        WebCamDevice[] dispositius = WebCamTexture.devices;

        //Si no pot detectar cap camera avisa de l'error 
        if (dispositius.Length == 0) {
            missatgeError.text = missatgeError.text + " No s'ha detectat cap càmera";
            panellErrors.SetActive(true);
            Debug.Log("No s'ha detectat cap càmera");
            camDisponible = false;
            return;
        }
        
        //Per a cada camera del sipositiu, busca la del darrere
        for (int i = 0; i < dispositius.Length; i++) {
            if (!dispositius[i].isFrontFacing) {
                cameraTextura = new WebCamTexture(dispositius[i].name, Screen.width, Screen.height);
            }
        }

        //Si no ha trobat cap camera del darrere
        if (cameraTextura == null) {
            missatgeError.text = missatgeError.text + " No es pot trobar la camera del darrere";
            panellErrors.SetActive(true);
            Debug.Log("No es pot trobar la camera del darrere");
            return;
        }

        //Te la camera del darrere, l'activa i la posa com a fons.
        cameraTextura.Play();
        fons.texture = cameraTextura;
        camDisponible = true;
    }


    void Update() {

        if (!camDisponible) {
            return;
        }

        //Tamany de la camera
        float ratio = (float)cameraTextura.width / (float)cameraTextura.height;
        fit.aspectRatio = ratio;

        //Escala de la camera
        float scaleY = cameraTextura.videoVerticallyMirrored ? -1f : 1f;
        fons.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        //Rotació de la camera
        int orient = -cameraTextura.videoRotationAngle;
        fons.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }
}