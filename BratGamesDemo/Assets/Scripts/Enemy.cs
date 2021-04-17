using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField]
    private int life = 1;

    public void Damage(int damageAmount)
    {
        life -= damageAmount;

        if (life < 1)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<President>() != null || other.GetComponent<Guard>() != null || other.tag == "EndPoint")
            Damage(1);
    }
}
