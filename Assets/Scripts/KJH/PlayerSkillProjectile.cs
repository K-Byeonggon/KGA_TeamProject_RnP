using UnityEngine;

public class PlayerSkillProjectile : MonoBehaviour
{
    [SerializeField] GameObject Prefab_Effect;

    Rigidbody rigidbody;
    float _lifeTime;
    GameObject _effect;
    public void Init(Vector3 initPos, Quaternion initRotation, float velocity)
    {
        _lifeTime = 0;

        this.transform.position = initPos;
        this.transform.rotation = initRotation;
        if(rigidbody == null) rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = this.transform.forward * velocity;

        _effect = EffectManager.Instance.EffectGenerate(Prefab_Effect, this.transform);
    }

    private void FixedUpdate()
    {
        _lifeTime += Time.fixedDeltaTime;

        if (_lifeTime > 1)
        {
            DestroyObject();
        }
    }

    private void OnTriggerEnter(Collider other)
    {        
        if(other.gameObject.layer == 7)//Enemy
        {
            if(other.TryGetComponent(out LCH.Enemy enemy))
            {
                enemy.Stun(3);
            }
        }
        if(other.gameObject.layer == 9)//NonDestroyObject
        {
            DestroyObject();
        }
        if (other.gameObject.layer == 6)//Projectile
        {
            if(other.TryGetComponent(out Bullet bullet))
            {
                bullet.ProjectileDestroy();
            }
        }
    }

    void DestroyObject()
    {
        _effect.transform.SetParent(null);
        ObjectPoolManager.Instance.EnqueueObject(this.gameObject);
    }
}
