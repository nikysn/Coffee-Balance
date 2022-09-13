using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMover : MonoBehaviour
{
     private float _moveSpeed = - 5f;
    public float MoveSpeed => _moveSpeed;
     
    private void Update()
    {
        transform.Translate(_moveSpeed * Time.deltaTime * Vector3.forward);
    }

    public IEnumerator enumerator()
    {
        _moveSpeed = 2;
        yield return new WaitForSeconds(2f);
        _moveSpeed = -5;
    }
}
