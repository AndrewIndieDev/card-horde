public class IdleCardState : CardState
{
    private float timer = 1f;

    public override void OnEnter(CardStateMachine stateMachine, Card card)
    {
        
    }

    public override void OnExit(CardStateMachine stateMachine, Card card)
    {
        
    }

    public override void OnUpdate(CardStateMachine stateMachine, Card card, float deltaTime)
    {
        timer -= deltaTime;
        if (timer <= 0f)
        {
            //stateMachine.ChangeState(new DecisionMakingState());
        }
    }
}
