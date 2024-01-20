using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Управляет изменением размеров элементов пользовательского интерфейса относительно других элементов.
/// Используется для настройки размещения панелей в игровом меню в зависимости от разрешения экрана.
/// </summary>
public class ScreenResolutionManager : MonoBehaviour
{
    [Header("Добавьте объект Canvas c игровым меню")]
    [SerializeField] GameObject canvasMenu;

    [Header("Добавьте панель главного игрового меню")]
    [SerializeField] GameObject mainMenuPanel;

    [Header("Добавьте панель списка деталей")]
    [SerializeField] GameObject listOfDetailsPanel;

    [Header("Добавьте панель с кнопкой заголовка")]
    [SerializeField] GameObject headerPanel;

    [Header("Добавьте панель с кнопками выбора деталей")]
    [SerializeField] GameObject detailsButtonsPanel;

    [Header("Добавьте изображение заглушки")]
    [SerializeField] GameObject blindImage; // Заглушка, для анимации выпадания detailsButtonsPanel



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
    /// Изменение RectTransform UI объекта, относительно другого UI объекта.
    /// </summary>
    /// <param Изменяемый UI объект="targetObject"></param>
    /// <param Референсный объект="referenceObject"></param>
    /// <param Коэффициент изменения по оси X="xMultiplier"></param>
    /// <param Коэффициент изменения по оси Y="yMultiplier"></param>
    public void ResizeRelativeTo(GameObject targetObject, GameObject referenceObject, float xMultiplier, float yMultiplier)
    {
        // Проверка на null для объектов
        if (targetObject == null || referenceObject == null) {
            Debug.LogError("Добавить targetObject / referenceObject в инспекторе.");
            return;
        }
        // Получаем компоненты RectTransform для объектов
        RectTransform referenceObjectRectTransform = referenceObject.GetComponent<RectTransform>();
        RectTransform targetObjectRectTransform = targetObject.GetComponent<RectTransform>();
        // Проверка на null для компонентов RectTransform
        if (referenceObjectRectTransform == null || targetObjectRectTransform == null) {
            Debug.LogError("RectTransform отсутсвует на объекте targetObject / referenceObject");
            return;
        }
        float targetObjectWidth = referenceObjectRectTransform.rect.width * xMultiplier;
        float targetObjectHeight = referenceObjectRectTransform.rect.height * yMultiplier;
        targetObjectRectTransform.sizeDelta = new Vector2(targetObjectWidth, targetObjectHeight);
    }
}
