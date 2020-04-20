using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class InformacioParades : MonoBehaviour
{
    private TextMesh textInfoParada;
    private int parada = 1;//de 1 a 11
    TextMeshProUGUI mText;

    void Start()
    {
        mText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update() {
        //agafar parada de la base de dades
        switch (parada) {
            case 1:
                mText.text = "informacio parada 1";
                break;
            case 2:
                mText.text = "informacio parada 2";
                break;
            case 3:
                mText.text = "informacio parada 3";
                break;
            case 4:
                mText.text = "informacio parada 4";
                break;
            case 5:
                mText.text = "informacio parada 5";
                break;
            case 6:
                mText.text = "informacio parada 6";
                break;
            case 7:
                mText.text = "informacio parada 7";
                break;
            case 8:
                mText.text = "informacio parada 8";
                break;
            case 9:
                mText.text = "informacio parada 9";
                break;
            case 10:
                mText.text = "informacio parada 10";
                break;
            case 11:
                mText.text = "informacio parada 11";
                break;
        }
    }
}