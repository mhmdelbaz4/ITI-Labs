internal class Duration
{
    int seconds;
    int minutes;
    int hours;

    public int Seconds
    {
        get => seconds;
        set
        {
            if (value >= 0)
            {
                seconds = value % 60;
                minutes += value / 60;

            }
        }
    }

    public int Minutes
    {
        get => minutes;
        set
        {
            if (value >= 0)
            {
                minutes += value % 60;
                Hours += value / 60;
            }
        }
    }
    public int Hours
    {
        get => hours;
        set
        {
            if (value >= 0)
                hours = value;
        }
    }

    public Duration(int _seconds)
    {
        Seconds = _seconds;
    }

    public Duration(int sec, int min, int hr)
    {
        Seconds = sec;
        Minutes = min;
        Hours = hr;
    }


    public override string ToString()
    {
        return $"Hours :{Hours} ,Minutes :{Minutes} ,Seconds :{seconds}";
    }

    private int converToSeconds()
    {
        return hours * 60 * 24 + minutes * 60 + seconds;
    }

    // D1+D2
    public static Duration operator +(Duration left, Duration right)
    {
        return new Duration(left.Seconds + right.seconds, left.Minutes + right.Minutes, left.Hours + right.Hours);
    }

    // D1+100
    public static Duration operator +(Duration left, int seconds)
    {
        Duration right = new Duration(seconds);

        return left + right;
    }

    // 100+D1
    public static Duration operator +(int seconds, Duration right)
    {
        Duration left = new Duration(seconds);

        return left + right;
    }

    // D1++
    public static Duration operator ++(Duration duration)
    {
        duration.Minutes++;
        return duration;
    }

    //D1--
    public static Duration operator --(Duration duration)
    {
        duration.Minutes--;
        return duration;
    }

    // D1>D2
    public static bool operator >(Duration left, Duration right)
    {
        return left.converToSeconds() > right.converToSeconds();
    }

    // D1<D2
    public static bool operator <(Duration left, Duration right)
    {
        return left.converToSeconds() < right.converToSeconds();
    }

    // if(D1)
    public static implicit operator bool(Duration duration)
    {
        return duration.converToSeconds() >= 0;
    }

    // (DateTime)D1
    public static explicit operator DateTime(Duration duration)
    {
        DateTime current = DateTime.Now;
        DateTime durationFromNow = new DateTime(current.Year, current.Month, current.Day, current.Hour + duration.Hours,
                                                current.Minute + duration.Minutes, current.Second + duration.Seconds);


        return durationFromNow;
    }

}
