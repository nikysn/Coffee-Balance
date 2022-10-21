using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField] private Tray _tray;
    [SerializeField] private PlaneMover _plane;
    [SerializeField] private Material m_material;
    [SerializeField] private Material m_materialRed;
    [SerializeField] private Material m_materialWhite;
    [SerializeField] private Accomulator _accomulator;
    private Coroutine _coroutineWhite;
    private Coroutine _coroutineRed;
    private float _speed;
    private Rigidbody rigidbody;
    private float _lastPositionX = 0;
    public float DeltaPositionX  => Mathf.Abs(transform.position.x - _lastPositionX) * 30;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _accomulator.MaxCharge = 220;
    }

    private void Update()
    {
        Speed();
        _accomulator.AddCharge(DeltaPositionX);
        m_material.Lerp(m_materialWhite, m_materialRed, _accomulator.NormalizeCharge);
        Debug.Log(_accomulator.NormalizeCharge);
        _lastPositionX = transform.position.x;
    }


    public void SellCoffee(Transform chainPoint)
    {
        _coroutineWhite = StartCoroutine(_tray.PassCoffee(chainPoint));
    }

    private void SetDefaultColor()
    {

    }

    public void Slide()
    {
        _tray.DropCoffee(_plane.transform);
    }

    public void Speed()
    {
        Vector3 v3Velocity = rigidbody.velocity;
        _speed = rigidbody.velocity.x;
      //  Debug.Log(_speed);
    }

  /*  public void ChangeColorm()
    {
        if (_speed == 0)
        {
            m_material.SetColor("_Color", Color.Lerp(m_material.GetColor("_Color"), m_color, _speed * Time.deltaTime));
        }
        else
        {
            m_material.SetColor("_Color", Color.Lerp(m_material.GetColor("_Color"), Color.red, _speed * Time.deltaTime));
        }
    }*/

    IEnumerator ChangeColor(Color color, float speedChangeColor)
    {
        // m_material.SetColor("_Color", Color.Lerp(m_material.GetColor("_Color"), color, Time.deltaTime));
      //  m_material.DOColor(color, speedChangeColor);
            yield break;
    }
   

    public void SetColor(Color white, Color red)
    {
        if (_speed == 0)
        {
            if (_coroutineRed != null)
            {
                StopCoroutine(_coroutineRed);
             //   DOTween.Pause(this);
            }
            if (_coroutineWhite == null)
                _coroutineWhite = StartCoroutine(ChangeColor(white,1f));
        }
        else
        {
            if (_coroutineWhite != null)
            {
                StopCoroutine(_coroutineWhite);
               // DOTween.Pause(this);
            }
           // if (_coroutineRed == null)
                _coroutineRed = StartCoroutine(ChangeColor(red,10f));
        }
    }
}
