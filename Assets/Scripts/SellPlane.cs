using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SellPlane : MonoBehaviour
{
    [SerializeField] private Table table;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.SellCoffee(table._chainPoint1.transform);
            player.SellCoffee(table._chainPoint2.transform);
        }
    }
}
