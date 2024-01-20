using System.Collections;
using System.Globalization;
using UnityEngine;

/// <summary>
/// Управляет перемещением объекта камеры к целевой позиции.
/// </summary>
public class MoveCamera : MonoBehaviour
{
    [Header("Добавьте объект камеры для перемещения\n")]
    [SerializeField] private GameObject cameraObject;

    [Header("Скорость перемещения камеры\n")]
    [SerializeField] private float speed = 1.0f;

    private Vector3 targetPosition; // Вектор целевой позиции для перемещения камеры

    /// <summary>
    /// Перемещение камеры к целевой позиции
    /// </summary>
    /// <param Целевая позиция для перемещения камеры="toPosition"></param>
    public void MoveCameraToTarget(string toPosition)
    {
        if (TryParsePosition(toPosition, out targetPosition)) {
            StartCoroutine(MoveToTarget());
        }
        else {
            Debug.LogError("Ошибка парсинга координат");
        }
    }

    /// <summary>
    /// Порсинг позиции
    /// </summary>
    /// <param Строка целевой позиции для перемещения камеры="positionString"></param>
    /// <param Результат парсинга="result"></param>
    /// <returns></returns>
    private bool TryParsePosition(string positionString, out Vector3 result)
    {
        result = Vector3.zero;
        string[] positionValues = positionString.Split(' ');
        // Проверка на то, что получено достаточно значений
        if (positionValues.Length >= 3) {
            float x, y, z;
            if (float.TryParse(positionValues[0], NumberStyles.Float, CultureInfo.InvariantCulture, out x) &&
                float.TryParse(positionValues[1], NumberStyles.Float, CultureInfo.InvariantCulture, out y) &&
                float.TryParse(positionValues[2], NumberStyles.Float, CultureInfo.InvariantCulture, out z))
            {
                // Создание нового вектора
                result = new Vector3(x, y, z);
                return true;
            }
            else {
                Debug.LogError("Ошибка парсинга координат");
            }
        }
        else {
            Debug.LogError("Недостаточно координат");
        }
        return false;
    }

    /// <summary>
    /// Корутина перемещения камеры к целевой точке (по локальной позиции)
    /// </summary>
    /// <returns></returns>
    private IEnumerator MoveToTarget()
    {
        float t = 0f;
        Vector3 startingPosition = cameraObject.transform.localPosition;
        while (t < 1f) {
            // Интерполяция между начальной и конечной позициями
            t += Time.deltaTime * speed;
            cameraObject.transform.localPosition = Vector3.Lerp(startingPosition, targetPosition, t);
            yield return null;
        }
    }

    /// <summary>
    /// Задать скорость перемещения анимации
    /// </summary>
    /// <param Скорость перемещения="setSpeed"></param>
    public void SetSpeed(float setSpeed)
    {
        speed = setSpeed;
    }
}

