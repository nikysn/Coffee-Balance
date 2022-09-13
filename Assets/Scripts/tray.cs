using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tray : MonoBehaviour
{
    private float _rangeRotation = 15;
    private Quaternion m_MyQuaternion;

    public void RotationTray(float readValue)
    {
        if (readValue < 0 && (transform.rotation.z <= _rangeRotation))
        {
            //  Mathf.MoveTowards(transform.rotation.z, 45, 1 * Time.deltaTime);
            // transform.Rotate(new Vector3(0, 0, 45) * 10 * Time.deltaTime);
            // SetPositionX(-_rangeRotation);
        }

        if (readValue > 0)
        {
            transform.Rotate(new Vector3(0, 0, -45) * 1 * Time.deltaTime);
        }

    }

    public void ResetRotation(float readValue)
    {
        if (readValue == 0)
        {
            Mathf.MoveTowards(transform.rotation.z, Quaternion.identity.z, 100 * Time.deltaTime);

        }
        // transform.rotation = Quaternion.identity;
    }

    public void SetPositionX(float readValue)
    {
        if (readValue <= 0 && transform.rotation.z >= -_rangeRotation)
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, _rangeRotation, -45);

    }


}
