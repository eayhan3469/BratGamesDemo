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
        //if (SwerveMovement.Instance.SwerveAmount < 0f)
        //{
        //    RotateBasedDirection(-1);
        //}
        //else if (SwerveMovement.Instance.SwerveAmount > 0f)
        //{
        //    RotateBasedDirection(1);
        //    Debug.Log(1);
        //}
        //else
        //{
        //    RotateBasedDirection(0);
        //    Debug.Log(0);
        //}
    }

    //private void RotateBasedDirection(int direction)
    //{
    //    float currentDegrees = 0f;
    //    if (direction < 0) // Left
    //    {
    //        if (Vector3.Distance(transform.eulerAngles, _rotateLeftTo) > 0.01f)
    //        {
    //            currentDegrees = Mathf.Lerp(currentDegrees, -10f, Time.deltaTime * 100f);
    //            transform.rotation = Quaternion.Euler(0f, currentDegrees, 0f);
    //            rotating = true;
    //        }
    //        else
    //        {
    //            transform.eulerAngles = _rotateLeftTo;
    //            rotating = false;
    //        }
    //    }
    //    else if (direction > 0)
    //    {
    //        if (Vector3.Distance(transform.eulerAngles, _rotateRightTo) > 0.01f)
    //        {
    //            currentDegrees = Mathf.Lerp(currentDegrees, 10f, Time.deltaTime * 100f);
    //            transform.rotation = Quaternion.Euler(0f, currentDegrees, 0f);
    //            rotating = true;
    //        }
    //        else
    //        {
    //            transform.eulerAngles = _rotateRightTo; 
    //            rotating = false;
    //        }
    //    }
    //    else
    //    {
    //        if (Vector3.Distance(transform.eulerAngles, Vector3.zero) > 0.01f)
    //        {
    //            currentDegrees = Mathf.Lerp(currentDegrees, 0f, Time.deltaTime * 10f);
    //            transform.rotation = Quaternion.Euler(0f, currentDegrees, 0f);
    //        }
    //        else
    //        {
    //            rotating = false;
    //        }
    //    }
    //}
}
