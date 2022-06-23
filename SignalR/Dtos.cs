namespace SignalRTest;

public record NoteNotifier(string Context, Guid ContextId);

public record ChatNotifier(string Context, Guid ContextId, string ChatId, int Order);

public record ChatMessage(string Context,
                          Guid ContextId,
                          string ChatId,
                          int Order,
                          string Message)
    : ChatNotifier(Context,
                   ContextId,
                   ChatId,
                   Order);

public record ChatEntered(string ChatId);

public record ChatLeft(string ChatId);