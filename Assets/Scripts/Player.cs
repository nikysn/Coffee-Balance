using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Tray _tray;
    [SerializeField] private PlaneMover _plane;
    private Coroutine _coroutine;
    public void SellCoffee(Transform chainPoint)
    {
        _coroutine = StartCoroutine(_tray.PassCoffee(chainPoint));
    }

    public void Slide()
    {
        _tray.DropCoffee(_plane.transform);
    }
}
