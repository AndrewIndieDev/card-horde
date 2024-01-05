public class AbilityMeleeState : CardState
{
    public override void OnEnter(CardStateMachine stateMachine, Card card)
    {
        //card.enterFeedbacks.PlayFeedbacks();
    }

    public override void OnExit(CardStateMachine stateMachine, Card card)
    {
        
    }

    public override void OnUpdate(CardStateMachine stateMachine, Card card, float deltaTime)
    {
        //if (!card.enterFeedbacks.IsPlaying)
        //{
        //    stateMachine.ChangeState(new IdleCardState());
        //}
    }
}
