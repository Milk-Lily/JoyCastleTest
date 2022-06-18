using System;
using System.Collections;
using UnityEngine;

public enum CustomEase
{
    easeIn,
    easeOut,
    easeInOut
}

public class MoveController : MonoBehaviour
{
    private CustomEase _ease = CustomEase.easeIn;
    
    // Start is called before the first frame update
    void Start()
    {
        Move(gameObject, Vector3.zero, Vector3.one * 10, 2f, true);
    }

    private void Move(GameObject gameObject, Vector3 begin, Vector3 end, float time, bool pingpong)
    {
        gameObject.transform.position = begin;
        StartCoroutine(MoveCoroutine(gameObject, begin, end, time, pingpong));
    }

    private IEnumerator MoveCoroutine(GameObject gameObject, Vector3 begin, Vector3 end, float time, bool pingpong)
    {
        float timer = 0;
        float normalizedProgress;
        float ease;
        bool isForward;

        while (true)
        {
            timer += Time.deltaTime;
            isForward = (timer / time) % 2 < 1;
            normalizedProgress = (timer / time) % 2 - (isForward ? 0 : 1);
            ease = GetEaseValue(normalizedProgress, 0, 1, 1);
            gameObject.transform.position = isForward ? Vector3.Lerp(begin, end, ease) : Vector3.Lerp(end, begin, ease);

            if (!pingpong && (timer / time) >= 1f)
            {
                break;
            }
            yield return null;
        }
    }

    private float GetEaseValue(float time, float nBegin, float nChange, float nDuration)
    {
        switch (_ease)
        {
            case CustomEase.easeIn:
                return Expo.easeIn(time, nBegin, nChange, nDuration);
            case CustomEase.easeOut:
                return Expo.easeOut(time, nBegin, nChange, nDuration);
            case CustomEase.easeInOut:
                return Expo.easeInOut(time, nBegin, nChange, nDuration);
            default:
                return 1;
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
