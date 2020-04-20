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


    private bool camAvaliable;            // comprovar si la camera esta disponible
    private WebCamTexture backCam;        // agafar la textura de la camera del darrere
    private Texture defaultBackgorund;    // la textura inicial del fons
    public RawImage background;           // l'imatge del fons
    public AspectRatioFitter fit;         // 
    public Text miss_error;
    public GameObject panellErrors;

    void Start()
    {
        //posar per defecte l'imatge de fons
        defaultBackgorund = background.texture;

        //Guardar dins la variable devices, tots els dispositius disponibles
        WebCamDevice[] devices = WebCamTexture.devices;

        //Si no pot detectar cap camera avisa de l'error 
        if (devices.Length == 0) {
            miss_error.text = miss_error.text + " No s'ha detectat cap càmera";
            panellErrors.SetActive(true);
            Debug.Log("No s'ha detectat cap càmera");
            camAvaliable = false;
            return;
        }
        
        //Per a cada camera del sipositiu, busca la del darrere
        for (int i = 0; i < devices.Length; i++) {
            if (!devices[i].isFrontFacing) {
                backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            }
        }

        //Si no ha trobat cap camera del darrere
        if (backCam == null) {
            miss_error.text = miss_error.text + " No es pot trobar la camera del darrere";
            panellErrors.SetActive(true);
            Debug.Log("No es pot trobar la camera del darrere");
            return;
        }

        //Te la camera del darrere, l'activa i la posa com a fons.
        backCam.Play();
        background.texture = backCam;
        camAvaliable = true;
    }


    void Update() {

        if (!camAvaliable) {
            return;
        }

        //Tamany de la camera
        float ratio = (float)backCam.width / (float)backCam.height;
        fit.aspectRatio = ratio;

        //Escala de la camera
        float scaleY = backCam.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        //Rotació de la camera
        int orient = -backCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }
}