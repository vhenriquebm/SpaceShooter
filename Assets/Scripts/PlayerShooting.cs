using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject laserBullet;
    [SerializeField] private GameObject basicShootPoint;
    [SerializeField] private float shootingInterval;
    private float intervalReset;

    void Start()
    {
        intervalReset = shootingInterval;
    }

    void Update()
    {
        shootingInterval -= Time.deltaTime;

        if (shootingInterval <= 0) {
            shootingInterval = intervalReset;
            Shoot(); // opcional: dispara após resetar
        }
    }

    private void Shoot() {
        Instantiate(laserBullet, basicShootPoint.transform.position, Quaternion.identity);
    }
}
