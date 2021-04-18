using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class President : MonoBehaviour, IDamagable
{
    [SerializeField]
    private int life = 2;

    private Vector3 _rotateLeftTo = new Vector3(0f, -10f, 0f);
    private Vector3 _rotateRightTo = new Vector3(0f, 10f, 0f);
    private bool rotating;

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

        if (other.tag == "Finish")
            GameManager.Instance.HasGameOver = true;
    }

    private void Update()
    {
        SwerveMovement.Instance.RotateBasedDirection(this.transform);
    }
}
