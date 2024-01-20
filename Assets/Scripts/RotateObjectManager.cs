using System.Collections;
using UnityEngine;

/// <summary>
/// �������� ������� � / ��� ������ � ������� ����.
/// </summary>
public class MouseRotateObject : MonoBehaviour
{
    [Header("�������� �������� �������\n")]
    [SerializeField] private float rotationSpeed = 5f;

    [Header("������, ������� ����� ��������� �� �����������\n")]
    [Tooltip("���� ��������� ������ cameraContainerObject, ���� targetObject ����� �������� ������ \n")]
    [SerializeField] private GameObject targetObject;

    [Header("��������� ������, ������� ����� ��������� �� ���������\n")]
    [Tooltip("���� ��������� ������ targetObject, ���� cameraContainerObject ����� �������� ������ \n")]
    [SerializeField] private GameObject cameraContainerObject;

    private bool isRotating = false;
    private Vector3 lastMousePosition;

    void Update()
    {
        // �������� �������� ��� ������� ����� ������ ����
        if (Input.GetMouseButtonDown(0))
        {
            isRotating = true;
            lastMousePosition = Input.mousePosition;
            StartCoroutine(RotateObjects());
        }
        // ���������� �������� ��� ���������� ����� ������ ����
        if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }
    }

    IEnumerator RotateObjects()
    {
        while (isRotating) {
            float mouseXDelta = Input.mousePosition.x - lastMousePosition.x;
            float mouseYDelta = Input.mousePosition.y - lastMousePosition.y;
            // ������� targetObject �� �����������, ���� �� �����
            if (targetObject != null) {
                targetObject.transform.Rotate(Vector3.up, -mouseXDelta * rotationSpeed * Time.deltaTime);
            }
            // ������� cameraContainerObject �� ���������, ���� �� �����
            if (cameraContainerObject != null) {
                cameraContainerObject.transform.Rotate(Vector3.right, -mouseYDelta * rotationSpeed * Time.deltaTime);
            }
            // ��������� ������� ��������� ���� ��� ���������� �����
            lastMousePosition = Input.mousePosition;
            yield return null;
        }
    }
}
