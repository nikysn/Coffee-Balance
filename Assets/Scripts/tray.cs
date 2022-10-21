using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tray : MonoBehaviour
{
    [field: SerializeField] public List<Coffee> CoffeesOnTray { get; private set; }

    public void AddCoffeeOnTray(Coffee coffee)
    {
        CoffeesOnTray.Add(coffee);
    }

    public Vector3 GetPositionLastCoffeeOnTray()
    {
        Vector3 coffeePosition = new Vector3(CoffeesOnTray.Last()._chainPoint.transform.position.x + 0.5f, CoffeesOnTray.Last()._chainPoint.transform.position.y - 0.5f, CoffeesOnTray.Last()._chainPoint.transform.position.z);
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

        Coffee lastCoffee = CoffeesOnTray.Last();
        lastCoffee.SetParent(chainPoints);
        CoffeesOnTray.Remove(lastCoffee);
    }
}
