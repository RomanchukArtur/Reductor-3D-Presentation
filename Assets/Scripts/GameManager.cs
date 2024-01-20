using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Класс исполнительных действий билда
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Загрузка сцены
    /// </summary>
    /// <param Индекс сцены в билде="sceneIndexToLoad"></param>
    public void LoadSceneByIndex(int sceneIndexToLoad)
    {
        if (sceneIndexToLoad >= 0 && sceneIndexToLoad < SceneManager.sceneCountInBuildSettings) {
            SceneManager.LoadScene(sceneIndexToLoad);
        }
        else {
            Debug.LogError("Ошибка: Недопустимый индекс сцены для загрузки.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            QuitGame();
        }
    }

    /// <summary>
    /// Выход из игры
    /// </summary>
    public void QuitGame()
    {
        // Закрытие приложения в режиме редактора
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // Закрытие приложения в билде
            Application.Quit();
        #endif
    }
}