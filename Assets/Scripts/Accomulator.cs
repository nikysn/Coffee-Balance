using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accomulator : MonoBehaviour
{
    [SerializeField] private const float StarDischargeSpeed = 0.04f;
    [SerializeField] private float _dischargeSpeed = 0.01f;
    [SerializeField] private float _dischargeSpeedMultiplier = 4f;

    public float MaxCharge { get; set; }
    public float Charge { get; private set; }
    public float NormalizeCharge => Charge / MaxCharge;

    public void AddCharge(float charge)
    {
        Charge += charge;
        _dischargeSpeed = StarDischargeSpeed;

        if (Charge > MaxCharge)
        {
            Charge = MaxCharge;
        }
    }

    private void Update()
    {
        _dischargeSpeed *= _dischargeSpeedMultiplier;
        Charge -= _dischargeSpeed;

        if (Charge < 0)
            Charge = 0;
    }

}
