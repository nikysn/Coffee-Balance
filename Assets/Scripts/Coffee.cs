using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coffee : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<PlayerMover>(out PlayerMover playerMover))
        {
            gameObject.SetActive(false);
        }
    }

}
