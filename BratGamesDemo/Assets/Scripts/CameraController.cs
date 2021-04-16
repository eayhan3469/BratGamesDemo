using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform Target;

    public float SmoothFactor;

    private Vector3 cameraOffset;

    private void Start()
    {
        cameraOffset = transform.position - Target.position;
    }

    private void LateUpdate()
    {
        if (Target != null)
        {
            Vector3 newPosition = (Target.position + cameraOffset);// *;/*+ (Target.localScale * 0.2f)*/; //TODO: topuk sayısına göre uzaklık değişecek
            transform.position = Vector3.Slerp(transform.position, newPosition, Time.deltaTime * SmoothFactor);
        }
    }
}
