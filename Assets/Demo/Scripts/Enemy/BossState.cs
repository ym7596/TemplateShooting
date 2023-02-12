using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BossState : MonoBehaviour
{
    public bossState state = bossState.None;
    // Start is called before the first frame update
    private Transform _transform;
    private Transform _playerTransform;
    
    private NavMeshAgent _nav;

    [SerializeField]
    private Transform _spawnPoint;
    [SerializeField]
    private Weapon _weaponData;
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private float _traceDist = 600f;
    [SerializeField]
    private float _attackDist = 400f;

    private float _lastFireTime;
    private bool isDead = false;
    private bool isPlayer = false;

    void Start()
    {
        state = bossState.Idle;
        _transform = GetComponent<Transform>();
        _nav = GetComponent<NavMeshAgent>();


        StartCoroutine(PlayerCheck());
      //  StartCoroutine(CheckStateForAction());
    }

    IEnumerator PlayerCheck()
    {
        yield return new WaitUntil(() => GameObject.FindGameObjectWithTag("Player"));
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        isPlayer = true;
    }

    private void Update()
    {
        if(isPlayer == true)
        {
            Vector3 dist = _playerTransform.position - transform.position;

            float sqrLen = dist.sqrMagnitude;
            // Debug.Log(sqrLen);
            switch (state)
            {
                case bossState.Idle:
                    {
                        anim.SetBool("isMove", false);
                        _nav.isStopped = true;
                        if (sqrLen < _traceDist)
                            state = bossState.Trace;
                    }
                    break;
                case bossState.Trace:
                    {

                        anim.SetBool("isMove", true);
                        _nav.isStopped = false;

                        _nav.SetDestination(_playerTransform.position);
                        if (sqrLen > _traceDist)
                        {
                            state = bossState.Idle;
                            _nav.isStopped = true;
                        }
                        else if (sqrLen < _attackDist)
                        {
                            state = bossState.Attack;
                            _nav.isStopped = true;
                        }


                    }
                    break;
                case bossState.Attack:
                    {
                        Quaternion rot = Quaternion.LookRotation(dist.normalized);
                        transform.rotation = rot;
                        anim.SetBool("Fire1", true);
                        EnemyAttack(_spawnPoint,dist.normalized);
                        if (sqrLen > _attackDist)
                        {
                            state = bossState.Trace;
                        }
                    }
                    break;
                case bossState.Die:
                    {
                        anim.SetBool("death", true);
                    }
                    break;
                default:
                    break;

            }
        }
    }
    
    private void EnemyAttack(Transform _spawnPoint,Vector3 dir)
    {
        if (Time.time >= _lastFireTime + _weaponData.fireRate) 
        {
            _lastFireTime = Time.time;

            Shot(_spawnPoint,dir);
        }
    }
    private void Shot(Transform _spawnPoint,Vector3 dir)
    {
        var Bullet = Instantiate(_weaponData.bulletPrefab, _spawnPoint);
        Bullet.GetComponent<Rigidbody>().AddForce(dir * _weaponData.bulletSpeed, ForceMode.Impulse);
    }
}
