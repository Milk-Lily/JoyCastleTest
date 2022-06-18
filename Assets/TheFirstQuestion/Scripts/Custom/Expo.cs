
public class Expo
{
    public static float GetTime(float time, float nDuration)
    {
        return time > nDuration ? nDuration : time;
    }
    
    public static float easeIn(float time, float nBegin, float nChange, float nDuration)
    {
        time = GetTime(time, nDuration);
        time = time / nDuration;
        return nChange * time * time * time + nBegin;
    }

    public static float easeOut(float time, float nBegin, float nChange, float nDuration)
    {
        time = GetTime(time, nDuration);
        time = time / nDuration - 1;
        return nChange * (time * time * time + 1) + nBegin;
    }

    public static float easeInOut(float time, float nBegin, float nChange, float nDuration)
    {
        time = GetTime(time, nDuration);
        time = time / (nDuration / 2);
        if (time < 1)
        {
            return nChange / 2 * time * time * time + nBegin;
        }
        time -= 2;
        return nChange / 2 * (time * time * time + 2) + nBegin;
    }
}