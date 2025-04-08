using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target;         // ��������� �� ������
    [SerializeField] private float yOffset = 2f;       // ³����� ������ ��� �������
    [SerializeField] private float smoothSpeed = 5f;   // �������� ������������

    private float highestY; // ������� ���������, ��� ������ ������

    private void Start()
    {
        if (target != null)
        {
            highestY = target.position.y + yOffset;
        }
    }

    private void LateUpdate()
    {
        if (target == null) return;

        float desiredY = target.position.y + yOffset;

        // ���� ������ �������� ���� � ��������� �������
        if (desiredY > highestY)
        {
            highestY = desiredY;
        }

        Vector3 newPos = new Vector3(transform.position.x, highestY, transform.position.z);

        // ������ ���������� ������
        transform.position = Vector3.Lerp(transform.position, newPos, smoothSpeed * Time.deltaTime);
    }
}
