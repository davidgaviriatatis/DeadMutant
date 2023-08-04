using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mele : MonoBehaviour
{
    public float attackRate = 0.8f;
    public GameObject meleWeapon, fireWeapon;
    public BoxCollider meleCollider;

    PlayerState playerState;
    float attackRateTime = 0;

    void Start()
    {
        playerState = GetComponent<PlayerState>();
        meleWeapon.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !GameManager.Instance.gameOver && !GameManager.Instance.winner && !playerState.isRunning)
        {
            MeleAttack();
        }
    }

    private void MeleAttack()
    {
        if (Time.time > attackRateTime)
        {
            fireWeapon.SetActive(false);
            meleWeapon.SetActive(true);
            playerState.isAttackingMele = true;
            StartCoroutine(NotMele());
            attackRateTime = Time.time + attackRate;
        }
    }

    IEnumerator NotMele()
    {
        yield return new WaitForSeconds(0.3f);
        meleCollider.enabled = true;
        yield return new WaitForSeconds(0.5f);
        playerState.isAttackingMele = false;
        meleCollider.enabled = false;
        meleWeapon.SetActive(false);
        fireWeapon.SetActive(true);
    }
}
