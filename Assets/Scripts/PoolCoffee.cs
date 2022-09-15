using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCoffee : MonoBehaviour
{
    [SerializeField] Coffee _coffeePrefab;
    private List<Coffee> _listCoffee = new List<Coffee>();


    public Coffee GetCoffee()
    {
        foreach (var item in _listCoffee)
            if (item.gameObject.activeSelf == false)
                return item;


        Coffee coffee = Instantiate(_coffeePrefab, transform);
        _listCoffee.Add(coffee);
        return coffee;

    }
}
