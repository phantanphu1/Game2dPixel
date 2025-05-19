using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Shotting : MonoBehaviour
{
    // lấy đưuocj các hành động bên kia
    public ObjectPool objectPool;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public float fireRate = 0.2f; // thời gian giữa mỗi viên
    private void Start()
    {
        // StartCoroutine(LoopShoot());
    }
    // IEnumerator LoopShoot()
    // {
    //     while (true)
    //     {

    //         Shoot();
    //         yield return new WaitForSeconds(fireRate);
    //     }
    // }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject bullet = objectPool.GetObject();
        bullet.transform.position = firePoint.position;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * bulletSpeed;

    }

}
