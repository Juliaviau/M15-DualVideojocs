using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarNumeros : MonoBehaviour
{
    float speed = 50.0f;

    void Update()
    {
        // this.transform.Rotate(angles * Time.deltaTime, Space.Self);
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
        // transform.Rotate(new Vector3(0f, 1f,0f) * Time.deltaTime);
        // transform.RotateAroundLocal(new Vector3(0f, 1f, 0f), 1);
    }
}
