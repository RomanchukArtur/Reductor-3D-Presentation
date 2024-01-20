using UnityEngine;

/// <summary>
/// ��������� ���������� ������ � �������� ���������� ����.
/// </summary>
public class AnimationController : MonoBehaviour
{
    [Header("�������� ��������� Animation ���������� ����\n")]
    [SerializeField] private Animation animationReductor;
    [Header("�������� ������������ ���� ������� ���������� ����\n")]
    [SerializeField] private AnimationClip clipReductorDisassembly;
    [Header("�������� ������������ ���� ������ ���������� ����\n")]
    [SerializeField] private AnimationClip clipReductorAssembly;

    // ��������� �� �������� ������� ���������� ����.
    private bool isReductorDemounted = false;

    void Start()
    {
        animationReductor.AddClip(clipReductorDisassembly, "ReductorDisassembly");
        animationReductor.AddClip(clipReductorAssembly, "ReductorAssembly");
    }

    /// <summary>
    /// �������� ������ - ��������.
    /// ������������ ����� ���������� � ����������� �� ��������� ���������� ����.
    /// </summary>
    public void PlayReductorAnimation()
    {
        // ���� ��������� ���� ������
        if (!isReductorDemounted) {
            animationReductor.Play("ReductorAssembly");
            isReductorDemounted = true;
        }
        // ���� ��������� ���� ��������
        else if (isReductorDemounted) {
            animationReductor.Play("ReductorDisassembly");
            isReductorDemounted = false;
        }
    }
}