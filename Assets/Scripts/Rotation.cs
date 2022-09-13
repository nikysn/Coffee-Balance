using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    private void Update()
    {
        transform.Rotate(new Vector3(15, 15, 45) * Time.deltaTime);
    }

    private void FixedUpdate()
    {
       /* Quaternion rotationY = Quaternion.AngleAxis(3, Vector3.fwd);
         Quaternion rotationX = Quaternion.AngleAxis(1, Vector3.left);
        transform.rotation *= rotationY * rotationX;*/

    }
}
