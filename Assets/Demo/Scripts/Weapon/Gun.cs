using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum State
{
    Ready, // ¹ß»ç ÁØºñµÊ
    Empty, // ÅºÃ¢ÀÌ ºö
    Reloading // ÀçÀåÀü Áß
}
public class Gun : MonoBehaviour
{

    private int _currentBullet;
    public State state { get; private set; } // ÇöÀç ÃÑÀÇ »óÅÂ
    public int currentBullets
    {
        get
        {
            return _currentBullet;
        }
        set
        {
            _currentBullet = value;
            InGameUI.instance.bulletCnt =
                string.Format("{0} / {1}", _currentBullet, _weaponData.bulletsPerMag);
        }
    }

   

    private float _lastFireTime;
    [SerializeField]
    private Weapon _weaponData;
 

    private void OnEnable()
    {
        currentBullets = _weaponData.bulletsPerMag;
        state = State.Ready;
        _lastFireTime = 0;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
    // Update is called once per frame

    public bool Fire(Transform _spawnPoint)
    {
        switch (state)
        {
            case State.Ready:
                {
                    if(Time.time >= _lastFireTime + _weaponData.fireRate)
                    {
                        _lastFireTime = Time.time;

                        Shot(_spawnPoint);
                    }

                }
                break;
            case State.Empty:
                {

                }break;
            case State.Reloading:
                {

                }break;


        }
        Debug.Log("ASd2");
    
        return false;
    }

    private void Shot(Transform _spawnPoint)
    {
        if(currentBullets > 0)
        {
            Debug.Log("ASd");
            var Bullet = Instantiate(_weaponData.bulletPrefab,_spawnPoint);
            Bullet.GetComponent<Rigidbody>().AddForce(_spawnPoint.forward * _weaponData.bulletSpeed,ForceMode.Impulse);
            currentBullets -= 1;
        }
        else
        {
            state = State.Empty;
        }
        
    }                                                                                         

    public void Reload()
    {
        state = State.Reloading;
        InGameUI.instance._reloadPanel.SetActive(true);
        StartCoroutine(ReloadBullet());
    }

    IEnumerator ReloadBullet()
    {
        for(float i = 0; i < _weaponData.reloadTime; i += 0.1f)
        {
            InGameUI.instance.sliderValue = i;
            yield return new WaitForSeconds(0.1f);
        }
        state = State.Ready;
        currentBullets = _weaponData.bulletsPerMag;
        InGameUI.instance._reloadPanel.SetActive(false);
    }
}
