using UnityEngine;

/// <summary>
/// Управляет анимациями сборки и разборки сборочного узла.
/// </summary>
public class AnimationController : MonoBehaviour
{
    [Header("Добавьте компонент Animation сборочного узла\n")]
    [SerializeField] private Animation animationReductor;
    [Header("Добавьте анимационный клип разбора сборочного узла\n")]
    [SerializeField] private AnimationClip clipReductorDisassembly;
    [Header("Добавьте анимационный клип сборки сборочного узла\n")]
    [SerializeField] private AnimationClip clipReductorAssembly;

    // Проиграна ли анимация разбора сборочного узла.
    private bool isReductorDemounted = false;

    void Start()
    {
        animationReductor.AddClip(clipReductorDisassembly, "ReductorDisassembly");
        animationReductor.AddClip(clipReductorAssembly, "ReductorAssembly");
    }

    /// <summary>
    /// Анимация сборки - разборки.
    /// Анимационные клипы чередуются в зависимости от состояния сборочного узла.
    /// </summary>
    public void PlayReductorAnimation()
    {
        // Если сборочный узел собран
        if (!isReductorDemounted) {
            animationReductor.Play("ReductorAssembly");
            isReductorDemounted = true;
        }
        // Если сборочный узел разобран
        else if (isReductorDemounted) {
            animationReductor.Play("ReductorDisassembly");
            isReductorDemounted = false;
        }
    }
}