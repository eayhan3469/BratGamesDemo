using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    public static SwerveMovement Instance;

    private SwerveInputSystem _swerveInputSystem;

    [SerializeField]
    private float swerveSpeed = 0.5f;

    [SerializeField]
    private float maxSwerveAmount = 1f;

    private float _maxPosX;
    private float _minPosX;
    private Transform _road;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("'SwerveMovement' must be one");
        else
            Instance = this;
    }

    private void Start()
    {
        _swerveInputSystem = GetComponent<SwerveInputSystem>();
        _road = GameObject.FindGameObjectWithTag("Road").transform;

        if (_road == null)
        {
            Debug.LogError("'Road' Not Found, assign 'Road' tag to your road object");
            return;
        }

        CalculateEdges();
    }

    public void CalculateEdges()
    {
        _maxPosX = (_road.localScale.x / 2 - 0.5f) - (Convoy.Instance.RightGuards.Count > 0 ? 1f : 0f);
        _minPosX = (0.5f - _road.localScale.x / 2) + (Convoy.Instance.LeftGuards.Count > 0 ? 1f : 0f);
    }

    private void Update()
    {
        float swerveAmount = Time.deltaTime * swerveSpeed * _swerveInputSystem.MoveFactorX;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        transform.Translate(swerveAmount, 0f, 0f);
        var clampedPosX = Mathf.Clamp(transform.position.x, _minPosX, _maxPosX);
        transform.position = new Vector3(clampedPosX, transform.position.y, transform.position.z);
    }
}
