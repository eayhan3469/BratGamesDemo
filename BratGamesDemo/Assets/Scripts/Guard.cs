using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Guard : MonoBehaviour, IDamagable
{
    [SerializeField]
    private int life = 1;

    public void Damage(int damageAmount)
    {
        life -= damageAmount;

        if (life < 1)
        {
            FindAndRemoveFromGuardList();
            SwerveMovement.Instance.CalculateEdges();
            Destroy(gameObject);
        }
    }

    private void FindAndRemoveFromGuardList()
    {
        var left = Convoy.Instance.LeftGuards.Where(g => g.gameObject == gameObject).FirstOrDefault();
        var right = Convoy.Instance.RightGuards.Where(g => g.gameObject == gameObject).FirstOrDefault();
        var front = Convoy.Instance.FrontGuards.Where(g => g.gameObject == gameObject).FirstOrDefault();

        if (left != null)
            Convoy.Instance.LeftGuards.Remove(left);
        else if (right != null)
            Convoy.Instance.RightGuards.Remove(right);
        else if (front != null)
            Convoy.Instance.FrontGuards.Remove(front);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() != null)
            Damage(1);
    }

    private void Update()
    {
        SwerveMovement.Instance.RotateBasedDirection(this.transform);
    }
}
