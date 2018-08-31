# Code Library
The collection of source code of custom, reusable components

**Beta projects are subject to frequent changes and updates.**

### ObjectMapper
Maps an instance of one class to an instance of another class

### ScheduledTaskRunner (BETA)
Allows you to schedule a task to be run at the specified intervals. It is based on MemoryCache and can be used with any application framework including web and console. The functionality is equivalent of the Windows Task Scheduler.

``` csharp
// set up at startup 
ScheduledTaskRunner runner new ScheduledTaskRunner(() => Console.WriteLine("Hello."), TimeSpan.FromMinutes(1))

// start
runner.Start();

// pause or end
runner.Stop();
```
