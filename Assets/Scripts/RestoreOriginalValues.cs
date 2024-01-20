using System.Collections;
using UnityEngine;

/// <summary>
/// ����������� ��������� rotate �������� � ��������� ���������.
/// </summary>
public class RestoreOriginalValues : MonoBehaviour
{
    [Header("������ ������� ���������\n")]
    [SerializeField] private GameObject[] details;
    [Header("������ ���������\n")]
    [SerializeField] private GameObject redictor;
    [Header("�������� ��������\n")]
    [SerializeField] private float restoreSpeed;

    private bool isRestoring = false;
    private Quaternion[] originalRotations;

    void Start()
    {
        // ���������� �������� ��������
        StoreOriginalRotations();
    }

    /// <summary>
    /// ������ �������� ��������� ��������
    /// </summary>
    void StoreOriginalRotations()
    {
        originalRotations = new Quaternion[details.Length + 1]; // +1 for redictor
        // ���������� �������� �������� ��� redictor
        originalRotations[originalRotations.Length - 1] = redictor.transform.rotation;
        // ���������� �������� �������� ��� details
        for (int i = 0; i < details.Length; i++)
        {
            originalRotations[i] = details[i].transform.localRotation;
        }
    }

    /// <summary>
    /// ������������ ������
    /// </summary>
    public void RestoreValues()
    {
        if (!isRestoring)
        {
            StartCoroutine(RestoreRotations());
        }
    }

    /// <summary>
    /// �������� �������� ������� � �������� ��������� rotation
    /// </summary>
    /// <returns></returns>
    IEnumerator RestoreRotations()
    {
        isRestoring = true;
        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * restoreSpeed;
            for (int i = 0; i < details.Length; i++) {
                details[i].transform.localRotation = Quaternion.Lerp(details[i].transform.localRotation, originalRotations[i], elapsedTime);
            }
            redictor.transform.rotation = Quaternion.Lerp(redictor.transform.rotation, originalRotations[originalRotations.Length - 1], elapsedTime);
            yield return null;
        }
        // ��������� �������������� ������ ������������� �������� � �� ��������� ����������
        for (int i = 0; i < details.Length; i++) {
            details[i].transform.localRotation = originalRotations[i];
        }
        redictor.transform.rotation = originalRotations[originalRotations.Length - 1];
        isRestoring = false;
    }
}