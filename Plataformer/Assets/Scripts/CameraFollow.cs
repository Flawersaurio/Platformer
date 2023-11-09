using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Cavernicola;

    

    // Update is called once per frame
    void Update()
    {
        if (Cavernicola!=null)
        {
            Vector3 position = transform.position;
            position.x = Cavernicola.position.x;
            transform.position = position;

        }

    }
}
