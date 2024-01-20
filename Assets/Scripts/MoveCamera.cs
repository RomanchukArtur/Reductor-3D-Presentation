using System.Collections;
using System.Globalization;
using UnityEngine;

/// <summary>
/// ��������� ������������ ������� ������ � ������� �������.
/// </summary>
public class MoveCamera : MonoBehaviour
{
    [Header("�������� ������ ������ ��� �����������\n")]
    [SerializeField] private GameObject cameraObject;

    [Header("�������� ����������� ������\n")]
    [SerializeField] private float speed = 1.0f;

    private Vector3 targetPosition; // ������ ������� ������� ��� ����������� ������

    /// <summary>
    /// ����������� ������ � ������� �������
    /// </summary>
    /// <param ������� ������� ��� ����������� ������="toPosition"></param>
    public void MoveCameraToTarget(string toPosition)
    {
        if (TryParsePosition(toPosition, out targetPosition)) {
            StartCoroutine(MoveToTarget());
        }
        else {
            Debug.LogError("������ �������� ���������");
        }
    }

    /// <summary>
    /// ������� �������
    /// </summary>
    /// <param ������ ������� ������� ��� ����������� ������="positionString"></param>
    /// <param ��������� ��������="result"></param>
    /// <returns></returns>
    private bool TryParsePosition(string positionString, out Vector3 result)
    {
        result = Vector3.zero;
        string[] positionValues = positionString.Split(' ');
        // �������� �� ��, ��� �������� ���������� ��������
        if (positionValues.Length >= 3) {
            float x, y, z;
            if (float.TryParse(positionValues[0], NumberStyles.Float, CultureInfo.InvariantCulture, out x) &&
                float.TryParse(positionValues[1], NumberStyles.Float, CultureInfo.InvariantCulture, out y) &&
                float.TryParse(positionValues[2], NumberStyles.Float, CultureInfo.InvariantCulture, out z))
            {
                // �������� ������ �������
                result = new Vector3(x, y, z);
                return true;
            }
            else {
                Debug.LogError("������ �������� ���������");
            }
        }
        else {
            Debug.LogError("������������ ���������");
        }
        return false;
    }

    /// <summary>
    /// �������� ����������� ������ � ������� ����� (�� ��������� �������)
    /// </summary>
    /// <returns></returns>
    private IEnumerator MoveToTarget()
    {
        float t = 0f;
        Vector3 startingPosition = cameraObject.transform.localPosition;
        while (t < 1f) {
            // ������������ ����� ��������� � �������� ���������
            t += Time.deltaTime * speed;
            cameraObject.transform.localPosition = Vector3.Lerp(startingPosition, targetPosition, t);
            yield return null;
        }
    }

    /// <summary>
    /// ������ �������� ����������� ��������
    /// </summary>
    /// <param �������� �����������="setSpeed"></param>
    public void SetSpeed(float setSpeed)
    {
        speed = setSpeed;
    }
}

