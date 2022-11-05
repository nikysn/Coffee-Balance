using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _sideLerpSpeed;


    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveSideways();
        }
    }

    private void MoveSideways()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            var position = transform.position;
           // Debug.Log(hit.point.x);
            position = Vector3.Lerp(position, new Vector3(hit.point.x, position.y, position.z),
                _sideLerpSpeed * Time.deltaTime);

            if (hit.point.x > -1.5 && hit.point.x < 1.5)
                transform.position = position;
        }
    }
}
