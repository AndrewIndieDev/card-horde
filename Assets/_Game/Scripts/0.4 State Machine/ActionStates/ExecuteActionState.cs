using DrewDev.GridSystem;

public class ExecuteActionState : CardState
{
    public ExecuteActionState(ActionSO action)
    {
        this.action = action;
    }

    private ActionSO action;

    public override async void OnEnter(CardStateMachine stateMachine, CardObject card)
    {
        if (action == null)
            return;

        await action.Execute(card);
    }

    public override void OnExit(CardStateMachine stateMachine, CardObject card)
    {
        
    }

    public override async void OnUpdate(CardStateMachine stateMachine, CardObject card, float deltaTime)
    {
        
    }
}
