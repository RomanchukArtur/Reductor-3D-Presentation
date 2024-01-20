using System.Collections;
using UnityEngine;

/// <summary>
/// Управляет движением панели, обеспечивая анимированное отображение и скрытие панели с заданной скоростью.
/// </summary>
public class MovePanel : MonoBehaviour
{
    [Header("Скорость движения\n")]
    [SerializeField] private float moveSpeed = 1.0f;

    private bool isPanelShown = false;
    private RectTransform panelRectTransform;

    private void Start()
    {
        panelRectTransform = GetComponent<RectTransform>();
        // Скрываем панель после инициализации
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
    /// Скрыть панель
    /// </summary>
    public void HidePanel()
    {
        StartCoroutine(MovePanelCoroutine(panelRectTransform.anchoredPosition.y, panelRectTransform.sizeDelta.y));
        isPanelShown = false;
    }

    /// <summary>
    /// Показать панель
    /// </summary>
    public void ShowPanel()
    {
        StartCoroutine(MovePanelCoroutine(panelRectTransform.anchoredPosition.y, -panelRectTransform.sizeDelta.y));
        isPanelShown = true;
    }

    /// <summary>
    /// Корутина движения панели в звдвнном направлении
    /// </summary>
    /// <param Начальная позиция по оси Y="startPositionY"></param>
    /// <param Целевая поциция по оси Y="targetOffsetY"></param>
    /// <returns></returns>
    private IEnumerator MovePanelCoroutine(float startPositionY, float targetOffsetY)
    {
        // Интерполируем плавное движение от начальной до целевой позиции
        float elapsedTime = 0f;
        while (elapsedTime < 1f) {
            elapsedTime += Time.deltaTime * moveSpeed;
            // Вычисляем новую позицию
            float newY = Mathf.Lerp(startPositionY, startPositionY + targetOffsetY, elapsedTime);
            panelRectTransform.anchoredPosition = new Vector2(panelRectTransform.anchoredPosition.x, newY);
            yield return null;
        }
    }
}