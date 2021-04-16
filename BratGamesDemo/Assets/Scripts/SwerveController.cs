using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveController : MonoBehaviour
{
    [SerializeField]
    private float SwerveSpeed = 0.5f;

    [SerializeField]
    private float MaxSwerveAmount = 1f;

    private float _lastTouchPositionX;
    private float _moveFactor;
    //private Character _character;
    private GameObject _road;
    private float _roadEdgeX;

    void Start()
    {
        //_character = Character.Instance;
        _road = GameObject.FindGameObjectWithTag("Road");

        //Calculate movement edges
        if (_road == null)
            Debug.LogError("Road not found");
        else
            _roadEdgeX = (_road.transform.localScale.x / 2) - (_road.transform.localScale.x / 2 * 0.15f);
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastTouchPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            _moveFactor = Input.mousePosition.x - _lastTouchPositionX;
            _lastTouchPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _moveFactor = 0f;
            _lastTouchPositionX = Vector3.zero.x;
        }

        Move();
        Walk();

        //if (GameManager.Instance.HasGameStart && !GameManager.Instance.HasGameOver)
        //{
        //    Move();
        //    Walk();
        //}
        //else
        //{
        //    Stop();
        //}
    }

    private void Move()
    {
        float swerveAmount = Time.deltaTime * SwerveSpeed * _moveFactor;
        swerveAmount = Mathf.Clamp(swerveAmount, -MaxSwerveAmount, MaxSwerveAmount);
        transform.position = Vector3.Lerp(transform.position, new Vector3(swerveAmount, transform.position.y, transform.position.z), Time.deltaTime * SwerveSpeed);
        var targetPos = new Vector3(Mathf.Clamp(transform.position.x, -_roadEdgeX, _roadEdgeX), transform.position.y, transform.position.z);
        //transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * SwerveSpeed);
    }

    private void Walk()
    {
        //transform.Translate(transform.forward * Time.deltaTime * 5f);
        //_character.IsWalking = true;
    }

    private void Stop()
    {
        //_character.IsWalking = false;
    }
}
