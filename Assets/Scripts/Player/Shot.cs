using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bullet;
    public LineRenderer laser;
    public float shotForce = 1000f, shotRate = 0.5f;

    PlayerState playerState;
    PlayerSounds playerSounds;
    float shotRateTime = 0;

    private void Start()
    {
        playerState = GetComponent<PlayerState>();
        playerSounds = GetComponent<PlayerSounds>();
    }

    void Update()
    {
        if (!GameManager.Instance.gameOver && !GameManager.Instance.winner && !playerState.isAttackingMele)
        {
            DrawLaser();
        }
        else
        {
            laser.enabled = false;
        }

        ShootBullet();
    }

    private void ShootBullet()
    {
        if (Input.GetButtonDown("Fire1") && !GameManager.Instance.gameOver && !GameManager.Instance.winner && !playerState.isAttackingMele)
        {
            if (Time.time > shotRateTime && GameManager.Instance.gunAmmo > 0)
            {
                playerState.isShooting = true;

                StartCoroutine(NotShoot());

                playerSounds.ShotPistolSound();

                GameObject newBullet;

                newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);

                GameManager.Instance.gunAmmo--;

                shotRateTime = Time.time + shotRate;

                Destroy(newBullet, 3);
            }
        }
    }

    private void DrawLaser()
    {
        if (!laser.enabled)
        {
            laser.enabled = true;
        }

        laser.SetPosition(0, spawnPoint.position);

        Vector3 SecondPointLaser = spawnPoint.position + spawnPoint.transform.forward * 50;

        laser.SetPosition(1, SecondPointLaser);
    }

    IEnumerator NotShoot()
    {
        yield return new WaitForSeconds(0.5f);
        playerState.isShooting = false;
    }
}
