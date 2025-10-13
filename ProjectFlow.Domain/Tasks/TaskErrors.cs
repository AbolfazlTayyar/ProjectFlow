using ProjectFlow.Domain.Abstracts;

namespace ProjectFlow.Domain.Task;

public static class TaskErrors
{
    public static readonly Error NotInTodoState = new(
        "Task.NotInTodoState",
        "The task must be in 'To Do' state to start.");

    public static readonly Error CannotCompleteFromCurrentState = new(
        "Task.CannotCompleteFromCurrentState",
        "The task cannot be completed from the current state.");
}
