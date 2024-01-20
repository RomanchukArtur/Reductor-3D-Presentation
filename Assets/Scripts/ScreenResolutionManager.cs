using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ��������� ���������� �������� ��������� ����������������� ���������� ������������ ������ ���������.
/// ������������ ��� ��������� ���������� ������� � ������� ���� � ����������� �� ���������� ������.
/// </summary>
public class ScreenResolutionManager : MonoBehaviour
{
    [Header("�������� ������ Canvas c ������� ����")]
    [SerializeField] GameObject canvasMenu;

    [Header("�������� ������ �������� �������� ����")]
    [SerializeField] GameObject mainMenuPanel;

    [Header("�������� ������ ������ �������")]
    [SerializeField] GameObject listOfDetailsPanel;

    [Header("�������� ������ � ������� ���������")]
    [SerializeField] GameObject headerPanel;

    [Header("�������� ������ � �������� ������ �������")]
    [SerializeField] GameObject detailsButtonsPanel;

    [Header("�������� ����������� ��������")]
    [SerializeField] GameObject blindImage; // ��������, ��� �������� ��������� detailsButtonsPanel



    // Start is called before the first frame update
    void Start()
    {
        ResizeRelativeTo(mainMenuPanel, canvasMenu, 0.3f, 0f);
        ResizeRelativeTo(listOfDetailsPanel, mainMenuPanel, 0.7f, 0.6f);
        ResizeRelativeTo(headerPanel, listOfDetailsPanel, 1f, 0.2f);
        ResizeRelativeTo(detailsButtonsPanel, listOfDetailsPanel, 1f, 0.8f);
        ResizeRelativeTo(blindImage, canvasMenu, 0.3f, 0.2f);
    }

    /// <summary>
    /// ��������� RectTransform UI �������, ������������ ������� UI �������.
    /// </summary>
    /// <param ���������� UI ������="targetObject"></param>
    /// <param ����������� ������="referenceObject"></param>
    /// <param ����������� ��������� �� ��� X="xMultiplier"></param>
    /// <param ����������� ��������� �� ��� Y="yMultiplier"></param>
    public void ResizeRelativeTo(GameObject targetObject, GameObject referenceObject, float xMultiplier, float yMultiplier)
    {
        // �������� �� null ��� ��������
        if (targetObject == null || referenceObject == null) {
            Debug.LogError("�������� targetObject / referenceObject � ����������.");
            return;
        }
        // �������� ���������� RectTransform ��� ��������
        RectTransform referenceObjectRectTransform = referenceObject.GetComponent<RectTransform>();
        RectTransform targetObjectRectTransform = targetObject.GetComponent<RectTransform>();
        // �������� �� null ��� ����������� RectTransform
        if (referenceObjectRectTransform == null || targetObjectRectTransform == null) {
            Debug.LogError("RectTransform ���������� �� ������� targetObject / referenceObject");
            return;
        }
        float targetObjectWidth = referenceObjectRectTransform.rect.width * xMultiplier;
        float targetObjectHeight = referenceObjectRectTransform.rect.height * yMultiplier;
        targetObjectRectTransform.sizeDelta = new Vector2(targetObjectWidth, targetObjectHeight);
    }
}
