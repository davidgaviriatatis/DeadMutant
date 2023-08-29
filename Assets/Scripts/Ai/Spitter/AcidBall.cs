using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidBall : MonoBehaviour
{
    float speed = 6f;
    Vector3 target;

    void Start()
    {
        target = GameManager.Instance.player.transform.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) <= 0.2)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.health -= 2;
            Debug.Log(GameManager.Instance.health);
        }
    }
}
