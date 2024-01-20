using UnityEngine;

/// <summary>
/// ��������� ������� ������������ �������, ����������� ����������
/// ��������������� �� �������� �����.
/// </summary>
public class TimedTouchBlocker : MonoBehaviour
{
    [Header("�������� ������ ������������ �������\n")]
    [SerializeField] private GameObject touchBlockerPanel;

    private void Start()
    {
        if (touchBlockerPanel == null) {
            Debug.LogError("TouchBlockerPanel �� ��� ��������.");
            enabled = false; // ��������� ������, ���� ������ �����������
        }
    }

    /// <summary>
    /// �������� ����������� �������
    /// </summary>
    /// <param ����� ������ ������������="blockTimeInSeconds"></param>
    public void StartTimedTouchBlocker(float blockTimeInSeconds)
    {
        touchBlockerPanel.SetActive(true);
        StartCoroutine(DisablePanelAfterDelay(blockTimeInSeconds));
    }

    /// <summary>
    /// ������ ������� ������ ������������
    /// </summary>
    /// <param �����="delay"></param>
    /// <returns></returns>
    private System.Collections.IEnumerator DisablePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        touchBlockerPanel.SetActive(false);
    }
}
