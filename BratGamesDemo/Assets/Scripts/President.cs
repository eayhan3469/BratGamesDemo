using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class President : MonoBehaviour, IDamagable
{
    [SerializeField]
    private int life = 2;

    public void Damage(int damageAmount)
    {
        life -= damageAmount;

        if (life < 1)
            GameManager.Instance.HasGameOver = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() != null)
            Damage(1);
    }
}
