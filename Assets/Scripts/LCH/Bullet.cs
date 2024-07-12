using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{    
    [SerializeField] private float bulletSize;
    [SerializeField] private bool isCanParry;

   

    

    public float BulletSize
    {
        get { return bulletSize; }
        set { bulletSize = value; }
    }

    public bool IsCanParry
    {
        get { return isCanParry; }
        set { isCanParry = value; }
    }


    //projectionVector�� �������� �߻�
    public void Shoot(Transform target, Vector3 initPos, Vector3 projectionVector, float bulletSpeed)
    {


        this.transform.position = initPos;
        
        this.GetComponent<Rigidbody>().velocity = projectionVector.normalized * bulletSpeed;
    }
    //Ÿ�� ��ġ�� �߻�
    public virtual void Shoot(Transform target, Vector3 initPos, float bulletSpeed)
    {


        this.transform.position = initPos;

        this.GetComponent<Rigidbody>().velocity = (target.position - this.transform.position).normalized * bulletSpeed;
    }
}
