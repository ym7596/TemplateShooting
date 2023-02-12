using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
   
    public GameObject Explosion;

    [SerializeField]
    private BulletInfo _bulletInfo;

    private Rigidbody _rigid;

    public int bulletDamage { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();

        bulletDamage = _bulletInfo.bulletDamage;
    }



    private void OnTriggerEnter(Collider col)
    {
        GameObject particleOBJ = Instantiate(_bulletInfo.Explosion) as GameObject;
        particleOBJ.transform.position = transform.position;
        Destroy(particleOBJ, 1f);

        Destroy(gameObject);
    }
}
