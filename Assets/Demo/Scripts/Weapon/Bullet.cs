using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   
    public GameObject Explosion;

    private Rigidbody _rigid;
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        GameObject particleOBJ = Instantiate(Explosion) as GameObject;
        particleOBJ.transform.position = transform.position;
        Destroy(particleOBJ, 1f);
        int colLayer = col.gameObject.layer;
        if(colLayer == LayerMask.NameToLayer("Enemy"))
        {
            
        }
        Destroy(gameObject);
    }
}
