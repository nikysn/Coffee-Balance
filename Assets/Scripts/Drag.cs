using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
   /* [SerializeField] public Transform _object; // Объект для движения
   
    private float speed = 0.1f; //Скорость

    private void OnMouseDrag()
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _object.position = Vector2.MoveTowards(_object.position, new Vector3(mousePos.x, mousePos.y, mousePos.z), speed * Time.deltaTime);

    }*/



         private Vector3 _dragOffset;
        private float _speedDrag = 10f;

        private void OnMouseDown()
        {
            _dragOffset = this.transform.position - GetMousePosition();
        }
        private void OnMouseDrag()
        {
            this.transform.position = GetMousePosition() + _dragOffset;
            this.transform.position = Vector3.MoveTowards(this.transform.position, GetMousePosition() + _dragOffset, _speedDrag * Time.deltaTime);
        }
        private Vector3 GetMousePosition()
        {
            var _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           // _mousePosition.z = 0;
            return _mousePosition;
        }
    }
