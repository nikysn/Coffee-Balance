using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

public class PoolCoffee : MonoBehaviour
{
    [SerializeField] Coffee _coffeePrefab;
    [SerializeField] private List<Coffee> _poolCoffee = new List<Coffee>();
    [SerializeField] private List<Coffee> _listCoffeeAnPlane = new List<Coffee>();
    [SerializeField] private Tray _tray;
    

    private void Update()
    {
        transform.position = _tray.GetPositionLastCoffeeOnTray();
    }

    public Coffee GetCoffee()
    {
        foreach (var item in _poolCoffee)
            if (item.gameObject.activeSelf == false)
            {
                item.gameObject.SetActive(true);
                return item;
            }

        Coffee coffee = Instantiate(_coffeePrefab, transform);
        _poolCoffee.Add(coffee);
        return coffee;
    }

    public void AddCoffee(Coffee coffee)
    {
        TakeCoffee();
        _listCoffeeAnPlane.Remove(coffee);
       // _poolCoffee.Add(coffee);
    }

    private void TakeCoffee()
    {
        Coffee coffee = GetCoffee();
        StartCoroutine(MoveCoffee(coffee));
    }

    IEnumerator MoveCoffee(Coffee coffee)
    {
        Transform targetPosition = _tray.TargetSelection();
        Transform targerRotation = _tray.TargetRotation();
        Transform target = _tray.GetTarget();
        coffee.SetParent(targetPosition);
        Transform current = coffee.transform;
        float speed = 4f;

        while (current.localPosition != Vector3.zero)
        {
            current.localPosition = Vector3.MoveTowards(current.localPosition, Vector3.zero, speed * Time.deltaTime);
            coffee.transform.DORotate(Vector3.zero, 0.2f, RotateMode.Fast);
            yield return null;
        }

        current.localRotation = targetPosition.localRotation;
        coffee.SetParent(null);
        coffee.Following(targetPosition, targerRotation, target, true);
       // lastCoffee.FixedJoint(coffee.Rigidbody);
       //  lastCoffee.FixedPosition();
       //  lastCoffee.SetSpringXDrive(3000);
        _tray.AddCoffeeOnTray(coffee);
        _poolCoffee.Remove(coffee);
       // coffee.IsTriggerOff();
    }

}
