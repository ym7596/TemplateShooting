using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/GunData")]
public class Weapon : ScriptableObject
{
    public float bulletSpeed = 70f;
    public string weaponName;
    public int bulletsPerMag;       // 탄창 당 장탄 수
    public int bulletsTotal;        // 전체 가지고 있는 총탄 수
        // 현재 탄창에 남아있는 총탄 수
    public float range;				// 사정거리
    public float fireRate = 0.125f;			// 연사속도
    
    public float reloadTime = 1f;
    public float fireTimer;		// 총탄과 총탄 사이의 발사 간격 설정
    public GameObject bulletPrefab;
}
