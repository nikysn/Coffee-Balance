using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using Unity.Mathematics;
using System.Drawing;

public class Coffee : MonoBehaviour
{
    [SerializeField] private PoolCoffee _poolCoffee;
    [SerializeField] private float followSpeed;

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
        _joint.xMotion = ConfigurableJointMotion.Free;
        _joint.yMotion = ConfigurableJointMotion.Locked;
        _joint.zMotion = ConfigurableJointMotion.Locked;
        _joint.angularXMotion = ConfigurableJointMotion.Locked;
        _joint.angularYMotion = ConfigurableJointMotion.Locked;
        _joint.angularZMotion = ConfigurableJointMotion.Limited;
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

    public void SetSpringXDrive(int xDriveValue)
    {
        var xDrive = _joint.xDrive;
        xDrive.positionSpring = xDriveValue;
        _joint.xDrive = xDrive;
    }

    public void FixedJoint(Rigidbody rigidbody)
    {
        _joint.connectedBody = rigidbody;
    }

    public void FixedJointOff()
    {
        _joint.connectedBody = null;
    }

    public void Following(Transform followedCube, Transform targetQuaternion, Transform target, bool isFollowStart)
    {
        StartCoroutine(StartFollowingToLastCubePosition(followedCube, targetQuaternion, target, isFollowStart));
    }

    IEnumerator StartFollowingToLastCubePosition(Transform targetPosition, Transform targetQuaternion, Transform target, bool isFollowStart)
    {
        while (isFollowStart)
        {
            //float angles = targetQuaternion.rotation.eulerAngles.z * 1.5f;
            yield return new WaitForEndOfFrame();
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetPosition.position.x, followSpeed * Time.deltaTime),
                transform.position.y, transform.position.z);

            transform.LookAt(target);
            // transform.rotation = Quaternion.RotateTowards(transform.rotation, targetQuaternion.rotation, 200);

            // Debug.Log(angles);
        }
    }

}
