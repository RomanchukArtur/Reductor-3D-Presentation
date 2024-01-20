using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ����� �������������� �������� �����
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// �������� �����
    /// </summary>
    /// <param ������ ����� � �����="sceneIndexToLoad"></param>
    public void LoadSceneByIndex(int sceneIndexToLoad)
    {
        if (sceneIndexToLoad >= 0 && sceneIndexToLoad < SceneManager.sceneCountInBuildSettings) {
            SceneManager.LoadScene(sceneIndexToLoad);
        }
        else {
            Debug.LogError("������: ������������ ������ ����� ��� ��������.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            QuitGame();
        }
    }

    /// <summary>
    /// ����� �� ����
    /// </summary>
    public void QuitGame()
    {
        // �������� ���������� � ������ ���������
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // �������� ���������� � �����
            Application.Quit();
        #endif
    }
}