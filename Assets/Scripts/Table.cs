using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [field: SerializeField] public ChainPoint _chainPoint1 { get; private set; }
    [field: SerializeField] public ChainPoint _chainPoint2 { get; private set; }

}
