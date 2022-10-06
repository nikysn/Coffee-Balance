using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class Coffee : MonoBehaviour
{
    [SerializeField] private PoolCoffee _poolCoffee;
    private BoxCollider _collider;
    private ConfigurableJoint _joint;
    [field: SerializeField] public ChainPoint _chainPoint { get; private set; }
    public Rigidbody Rigidbody { get; private set; }



    private void Awake()
    {
        _joint = GetComponent<ConfigurableJoint>();
        
        Rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Rigidbody.isKinematic = false;
           // _collider.isTrigger = false;
            gameObject.SetActive(false);
            _poolCoffee.AddCoffee(this);
        }
    }

    public void SetParent(Transform newParent)
    {
        transform.SetParent(newParent);
        
    }
    public void IsTriggerOff()
    {
        _collider.isTrigger = false;
    }

    public void IsTriggerOn()
    {
        _collider.isTrigger = true;
    }

    public void FixedPosition()
    {
        _joint.xMotion = ConfigurableJointMotion.Limited;
        _joint.yMotion = ConfigurableJointMotion.Locked;
        _joint.zMotion = ConfigurableJointMotion.Locked;
        _joint.angularXMotion = ConfigurableJointMotion.Limited;
        _joint.angularYMotion = ConfigurableJointMotion.Locked;
        _joint.angularZMotion = ConfigurableJointMotion.Locked;
    }

    public void FixedPositionOff()
    {
        _joint.xMotion = ConfigurableJointMotion.Free;
        _joint.yMotion = ConfigurableJointMotion.Free;
        _joint.zMotion = ConfigurableJointMotion.Free;
        _joint.angularXMotion = ConfigurableJointMotion.Free;
        _joint.angularYMotion = ConfigurableJointMotion.Free;
        _joint.angularZMotion = ConfigurableJointMotion.Free;
        
    }

    public void FixedJoint(Rigidbody rigidbody)
    {
        _joint.connectedBody = rigidbody;
    }

    public void FixedJointOff()
    {
        _joint.connectedBody = null;
    }
}
