public class CardState
{
    public virtual void OnEnter(CardStateMachine stateMachine, Card card) { }
    public virtual void OnExit(CardStateMachine stateMachine, Card card) { }
    public virtual void OnUpdate(CardStateMachine stateMachine, Card card, float deltaTime) { }
}
