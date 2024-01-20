using System.Collections;
using UnityEngine;

/// <summary>
/// ��������� ��������� ������, ����������� ������������� ����������� � ������� ������ � �������� ���������.
/// </summary>
public class MovePanel : MonoBehaviour
{
    [Header("�������� ��������\n")]
    [SerializeField] private float moveSpeed = 1.0f;

    private bool isPanelShown = false;
    private RectTransform panelRectTransform;

    private void Start()
    {
        panelRectTransform = GetComponent<RectTransform>();
        // �������� ������ ����� �������������
        panelRectTransform.anchoredPosition = new Vector2(panelRectTransform.anchoredPosition.x, panelRectTransform.sizeDelta.y);
    }

    public void StartMovingPanel()
    {
        if (isPanelShown) {
            HidePanel();
        }
        else if (!isPanelShown) {
            ShowPanel();
        }
    }

    /// <summary>
    /// ������ ������
    /// </summary>
    public void HidePanel()
    {
        StartCoroutine(MovePanelCoroutine(panelRectTransform.anchoredPosition.y, panelRectTransform.sizeDelta.y));
        isPanelShown = false;
    }

    /// <summary>
    /// �������� ������
    /// </summary>
    public void ShowPanel()
    {
        StartCoroutine(MovePanelCoroutine(panelRectTransform.anchoredPosition.y, -panelRectTransform.sizeDelta.y));
        isPanelShown = true;
    }

    /// <summary>
    /// �������� �������� ������ � �������� �����������
    /// </summary>
    /// <param ��������� ������� �� ��� Y="startPositionY"></param>
    /// <param ������� ������� �� ��� Y="targetOffsetY"></param>
    /// <returns></returns>
    private IEnumerator MovePanelCoroutine(float startPositionY, float targetOffsetY)
    {
        // ������������� ������� �������� �� ��������� �� ������� �������
        float elapsedTime = 0f;
        while (elapsedTime < 1f) {
            elapsedTime += Time.deltaTime * moveSpeed;
            // ��������� ����� �������
            float newY = Mathf.Lerp(startPositionY, startPositionY + targetOffsetY, elapsedTime);
            panelRectTransform.anchoredPosition = new Vector2(panelRectTransform.anchoredPosition.x, newY);
            yield return null;
        }
    }
}