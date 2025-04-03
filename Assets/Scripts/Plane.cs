using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{


    private void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime *0.5f);
    }
}
