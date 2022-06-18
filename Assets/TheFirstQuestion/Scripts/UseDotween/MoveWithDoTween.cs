using UnityEngine;
using DG.Tweening;

public class MoveWithDoTween : MonoBehaviour
{
    private Ease _ease = Ease.InCubic;
    // Start is called before the first frame update
    void Start()
    {
        Move(gameObject, Vector3.zero, Vector3.one * 10, 2f, true);
    }

    private void Move(GameObject gameObject, Vector3 begin, Vector3 end, float time, bool pingpong)
    {
        Sequence sequence = DOTween.Sequence();
        gameObject.transform.position = begin;
        sequence.Append(gameObject.transform.DOMove(end, time).SetEase(_ease));
        if (pingpong)
        {
            sequence.Append(gameObject.transform.DOMove(begin, time).SetEase(_ease));
            sequence.SetLoops(-1);
        }

        sequence.Play();
    }
}
