using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.PlayerLoop;

public class Tray : MonoBehaviour
{

    [field: SerializeField] public List<Coffee> CoffeesOnTray { get; private set; }
    [field: SerializeField] public ChainPoint ChainPoint { get; private set; }

    private int gap = 2;
    private float _coffeeSpeed = 15f;
    private List<int> _coffeePartsIndex = new List<int>();
    private List<Vector3> _positionHistory = new List<Vector3>();

  /* private void FixedUpdate()
    {
        _positionHistory.Insert(0, transform.position);
        int index = 0;

        foreach(var coffee in CoffeesOnTray)
        {
            Vector3 point = _positionHistory[Mathf.Min(index * gap, _positionHistory.Count - 1)];
            Vector3 moveDir = point - coffee.transform.position;
            coffee.transform.position += moveDir * _coffeeSpeed * Time.deltaTime;
            coffee.transform.LookAt(point);
            index++;
        }
    }*/

    public void GrowBody(Coffee coffee)
    {
        CoffeesOnTray.Add(coffee);
        int index = 0;
        index++;
        _coffeePartsIndex.Add(index);
    }

    public void AddCoffeeOnTray(Coffee coffee)
    {
        CoffeesOnTray.Add(coffee);
    }

    public Vector3 GetPositionLastCoffeeOnTray()
    {
        Vector3 coffeePosition = new Vector3(TargetSelection().position.x + 0.5f, TargetSelection().position.y - 0.5f, TargetSelection().transform.position.z);
        return coffeePosition;
    }

    public IEnumerator PassCoffee(Transform chainPoints)
    {
        Coffee lastCoffee = CoffeesOnTray.Last();
        CoffeesOnTray.Remove(lastCoffee);
        lastCoffee.IsTriggerOn();
        lastCoffee.SetParent(chainPoints);
        Coffee lastCoffee2 = CoffeesOnTray.Last();
        lastCoffee2.FixedPositionOff();
        Transform current = lastCoffee.transform;

        while (Vector3.zero != current.localPosition)
        {
            current.localPosition = Vector3.MoveTowards(current.localPosition, Vector3.zero, 0.2f * Time.deltaTime);
            current.localRotation = Quaternion.identity;
            yield return null;
        }

        lastCoffee.IsTriggerOff();
    }

    public void DropCoffee(Transform chainPoints)
    {
        Coffee penultimateCoffee = CoffeesOnTray[CoffeesOnTray.Count - 2];
        penultimateCoffee.FixedJointOff();
        penultimateCoffee.FixedPositionOff();
        penultimateCoffee.SetSpringXDrive(0);

        Coffee lastCoffee = CoffeesOnTray.Last();
        lastCoffee.SetParent(chainPoints);
        CoffeesOnTray.Remove(lastCoffee);
    }

    public Transform TargetSelection()
    {
        if (CoffeesOnTray.Count == 0)
            return ChainPoint.transform;

        else
        {
            Coffee lastCoffee = CoffeesOnTray.Last();
            return lastCoffee._chainPoint.transform;
        }
    }

    public Transform TargetRotation()
    {
        if (CoffeesOnTray.Count == 0)
            return transform;

        else
        {
            Coffee lastCoffee = CoffeesOnTray.Last();
            return lastCoffee.transform;
        }
    }

    public Transform GetTarget()
    {
        if (CoffeesOnTray.Count == 0)
            return transform;

        else
        {
            Coffee lastCoffee = CoffeesOnTray.Last();
            return lastCoffee.transform;
        }
    }
    

    
}
