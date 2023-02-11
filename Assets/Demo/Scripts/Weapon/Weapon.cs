using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/GunData")]
public class Weapon : ScriptableObject
{
    public float bulletSpeed = 70f;
    public string weaponName;
    public int bulletsPerMag;       // źâ �� ��ź ��
    public int bulletsTotal;        // ��ü ������ �ִ� ��ź ��
        // ���� źâ�� �����ִ� ��ź ��
    public float range;				// �����Ÿ�
    public float fireRate = 0.125f;			// ����ӵ�
    
    public float reloadTime = 1f;
    public float fireTimer;		// ��ź�� ��ź ������ �߻� ���� ����
    public GameObject bulletPrefab;
}
