/// <summary>
/// Task scheduler implemented with MemoryCache for repeated tasks to run at the specified interval
/// </summary>
public sealed class ScheduledTaskRunner
{
    public string Name { get; private set; }
    public TimeSpan Frequency { get; private set; }
    public bool AllowMultipleSessions { get; private set; }

    Guid _id = Guid.NewGuid();
    Action _action;
    TimeSpan _initialDelay;
    bool __terminationRequested = false;
    long _inProgress = 0;
    
    public ScheduledTaskRunner(Action action, TimeSpan frequency)
    {
        _action = action;
        Frequency = frequency;
    }

    public ScheduledTaskRunner(string name, Action action, TimeSpan frequency)
    {
        Name = name;
        _action = action;
        Frequency = frequency;
    }

    public ScheduledTaskRunner(string name, Action action, TimeSpan frequency, TimeSpan initialDelay)
    {
        Name = name;
        _action = action;
        Frequency = frequency;
        _initialDelay = initialDelay;
    }

    public void Start()
    {
        __terminationRequested = false;
        RegisterCacheEntry(_initialDelay);
    }

    public void Stop()
    {
        __terminationRequested = true;
    }

    void RegisterCacheEntry(TimeSpan frequency)
    {
        var cachePolicy = new CacheItemPolicy
        {
            AbsoluteExpiration = DateTimeOffset.UtcNow.AddSeconds(frequency.TotalSeconds),
            SlidingExpiration = TimeSpan.Zero,
            Priority = System.Runtime.Caching.CacheItemPriority.Default,
            RemovedCallback = CacheEntryRemovedCallback,
        };

        MemoryCache.Default.Add(GetType().FullName + " (" + Name + ") " + _id, null, cachePolicy);
    }

    void CacheEntryRemovedCallback(CacheEntryRemovedArguments arguments)
    {
        if (!__terminationRequested)
        {
            if (AllowMultipleSessions || Interlocked.Read(ref _inProgress) == 0)
            {
                Interlocked.Increment(ref _inProgress);

                try
                {
                    _action();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
                finally
                {
                    Interlocked.Exchange(ref _inProgress, 0);
                }
            }

            RegisterCacheEntry(Frequency);
        }
    }
}
