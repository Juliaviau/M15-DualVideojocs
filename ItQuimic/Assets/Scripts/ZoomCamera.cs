using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomCamera : MonoBehaviour
{
    public GameObject prefab;
    public Camera camera;
    public Button botoAmpliar;
    public Button botoReduir;

    // Start is called before the first frame update
    void Start() {

        prefab.transform.localScale = new Vector3(2,2,2);       
    }

    // Update is called once per frame
    void Update() {
        
    } 

    public void Ampliar () {

        Vector3 zoom = camera.transform.position;
       // zoom.x += 0.1f;
        zoom.y -= 3f;
        zoom.z += 3f;

        if (((camera.transform.position.y + zoom.y) == 56.9) || ((camera.transform.position.z + zoom.z) == -21.9)) {
            botoAmpliar.gameObject.SetActive(false);
        } else {
            botoAmpliar.gameObject.SetActive(true);
        }
        /*max
            x - 3.100006
            y  293.9
            z - 258.9
        min
            x - 3.100006
            y  56.9
            z - 21.9*/

        //fa zoom al clicar el +. quan arriba 

        //si la posicio de la camera és superior o igual a el valor del maxim zoom
        //com mes aprop, mes petit el numero.
        //si arriba al numero el boto no fa res perque no es pot acostar més 

       // if (((camera.transform.position.y + zoom.y) != 56.9) && ((camera.transform.position.z + zoom.z) != -21.9)) {

            camera.transform.position = zoom;

            //si es major o igual a 5. redueix. no fa res, sino resta
            float mida = prefab.transform.localScale.x;

            if (mida <= 5f) {
                return;
            } else {
                prefab.transform.localScale -= new Vector3(3, 3, 3);
            } 
       // }

        //camera.transform.position = new Vector3(20, 20, 0);
       // camera.transform.position += new Vector3(10, 20, 0);
    }

    public void Reduir () {

        Vector3 zoom = camera.transform.position;

        zoom.y += 3f;
        zoom.z -= 3f;

        //119.9  y
        //-84.9  z

        if (((camera.transform.position.y + zoom.y) < 293.9) || ((camera.transform.position.z + zoom.z) < -258.9)) {
            botoReduir.gameObject.SetActive(false);
        } else {
            botoReduir.gameObject.SetActive(true);
        }

        //s'allunya del mapa
        //quan la camera arriba a una posicio maxima, no pot anar mes enrere

       // if (    ( (camera.transform.position.y + zoom.y) < 293.9)   || ((camera.transform.position.z + zoom.z) < -258.9)) {
            camera.transform.position = zoom;

            float mida = prefab.transform.localScale.x;

            if (mida <= 5f) {
                return;
            } else {
                prefab.transform.localScale += new Vector3(3, 3, 3);
            }
        //}
    }
}