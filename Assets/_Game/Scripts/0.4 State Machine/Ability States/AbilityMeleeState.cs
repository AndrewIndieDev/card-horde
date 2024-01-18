public class AbilityMeleeState : CardState
{
    private float time;

    public override void OnEnter(CardStateMachine stateMachine, Card card)
    {
        time = (card.ability1Feedbacks != null) ? card.ability1Feedbacks.TotalDuration : 1f;
        card.ability1Feedbacks?.PlayFeedbacks();
    }

    public override void OnExit(CardStateMachine stateMachine, Card card)
    {
        
    }

    public override void OnUpdate(CardStateMachine stateMachine, Card card, float deltaTime)
    {
        time -= deltaTime;
        if (time > 0)
            return;

        stateMachine.ChangeState(new IdleCardState());
    }
}
