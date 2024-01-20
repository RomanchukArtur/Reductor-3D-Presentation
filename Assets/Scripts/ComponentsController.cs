using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �������� ���������� ������������
/// </summary>
public class ComponentsController : MonoBehaviour
{
    [SerializeField] private GameObject[] details;
    [SerializeField] private GameObject reductor;
    [SerializeField] GameObject[] backButtons;
    [SerializeField] GameObject[] detailButtons;

    /// <summary>
    /// ������������� / ��������������� ��� ������� �� ����� (��� ������� details)
    /// </summary>
    /// <param �������� SetActive="isActive"></param>
    public void SetAllGameObjectsActive(bool isActive)
    {
        foreach (GameObject go in details) {
            go.SetActive(isActive);
        }
    }

    /// <summary>
    /// ��������������� ��� ������ ������ �� ��������� ������ (��� ������� backButtons)
    /// </summary>
    public void SetAllBackButtonsDisactive()
    {
        foreach (GameObject button in backButtons) {
            button.SetActive(false);
        }
    }

    /// <summary>
    /// ������������ ��� ������ ������ ������ ��� ��������� (��� ������� detailButtons)
    /// </summary>
    public void SetAllDetailButtonsActive()
    {
        foreach (GameObject button in detailButtons) {
            button.SetActive(true);
        }
    }

    /// <summary>
    /// ��������������� ��� ���������� DisableAllMouseRotateObject
    /// </summary>
    public void DisableAllMouseRotateObject()
    {
        foreach (GameObject go in details) {
            MouseRotateObject mouseRotateObject = go.GetComponent<MouseRotateObject>();
            mouseRotateObject.StopAllCoroutines();
            mouseRotateObject.enabled = false;
        }
        MouseRotateObject mouseRotateObjectReductor = reductor.GetComponent<MouseRotateObject>();
        mouseRotateObjectReductor.StopAllCoroutines();
        mouseRotateObjectReductor.enabled = false;
    }
}
