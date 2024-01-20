using System.Collections;
using UnityEngine;

/// <summary>
/// Возвращение параметра rotate объектов к исходному состоянию.
/// </summary>
public class RestoreOriginalValues : MonoBehaviour
{
    [Header("Массив деталей редуктора\n")]
    [SerializeField] private GameObject[] details;
    [Header("Объект редуктора\n")]
    [SerializeField] private GameObject redictor;
    [Header("Скорость вращения\n")]
    [SerializeField] private float restoreSpeed;

    private bool isRestoring = false;
    private Quaternion[] originalRotations;

    void Start()
    {
        // Запоминаем исходные вращения
        StoreOriginalRotations();
    }

    /// <summary>
    /// Запись исходных состояний объектов
    /// </summary>
    void StoreOriginalRotations()
    {
        originalRotations = new Quaternion[details.Length + 1]; // +1 for redictor
        // Записываем исходное вращение для redictor
        originalRotations[originalRotations.Length - 1] = redictor.transform.rotation;
        // Записываем исходные вращения для details
        for (int i = 0; i < details.Length; i++)
        {
            originalRotations[i] = details[i].transform.localRotation;
        }
    }

    /// <summary>
    /// Перезаписать данные
    /// </summary>
    public void RestoreValues()
    {
        if (!isRestoring)
        {
            StartCoroutine(RestoreRotations());
        }
    }

    /// <summary>
    /// Корутина возврата объктов к исходный значениям rotation
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
        // Завершаем восстановление точным выравниванием объектов с их исходными значениями
        for (int i = 0; i < details.Length; i++) {
            details[i].transform.localRotation = originalRotations[i];
        }
        redictor.transform.rotation = originalRotations[originalRotations.Length - 1];
        isRestoring = false;
    }
}