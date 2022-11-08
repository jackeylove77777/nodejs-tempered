
//自定义Emitter，拙劣的模仿
var emitter = new EventEmitter();
emitter.listenOn("event1", (_) =>
{
    Console.WriteLine("event1.1 react!");
});
emitter.listenOn("event1", (objs) =>
{
    var sum = objs?.ToList().Select(x => x is int ? (int)x : 0).Sum();
    Console.WriteLine(sum);
});

emitter.emit("event1", 1, "123", 3, 4);
emitter.emit("event1");


public class EventEmitter
{
    public EventEmitter()
    {
        recorder = new();
    }
    private readonly Dictionary<string, List<EventEmitterHandler>> recorder;

    public void emit(string name, params object[]? args)
    {
        if (!recorder.ContainsKey(name)) return;
        var handlers = recorder[name];
        foreach (var handler in handlers)
        {
            handler?.Invoke(args);
        }
    }

    public void listenOn(string name, EventEmitterHandler handler)
    {
        if (recorder.ContainsKey(name))
        {
            recorder[name].Add(handler);
        }
        else
        {
            recorder.Add(name, new List<EventEmitterHandler>() { handler });
        }
    }
}
public delegate void EventEmitterHandler(params object[]? args);