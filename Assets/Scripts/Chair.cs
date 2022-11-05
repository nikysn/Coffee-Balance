using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    [SerializeField] private PlaneMover _planeMover;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<PlayerMover>(out PlayerMover player))
        {
            _planeMover.StartCoroutine(_planeMover.enumerator());
        }
    }
}
