using UnityEngine;

/// <summary>
/// Управляет панелью блокировщика нажатий, обеспечивая отключение
/// интерактивности на заданное время.
/// </summary>
public class TimedTouchBlocker : MonoBehaviour
{
    [Header("Добавьте панель блокировщика нажатий\n")]
    [SerializeField] private GameObject touchBlockerPanel;

    private void Start()
    {
        if (touchBlockerPanel == null) {
            Debug.LogError("TouchBlockerPanel не был присвоен.");
            enabled = false; // Отключаем скрипт, если ссылка отсутствует
        }
    }

    /// <summary>
    /// Включить блокировщик нажатий
    /// </summary>
    /// <param время работы блокировщика="blockTimeInSeconds"></param>
    public void StartTimedTouchBlocker(float blockTimeInSeconds)
    {
        touchBlockerPanel.SetActive(true);
        StartCoroutine(DisablePanelAfterDelay(blockTimeInSeconds));
    }

    /// <summary>
    /// Отсчет времени работы блокировщика
    /// </summary>
    /// <param Время="delay"></param>
    /// <returns></returns>
    private System.Collections.IEnumerator DisablePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        touchBlockerPanel.SetActive(false);
    }
}
