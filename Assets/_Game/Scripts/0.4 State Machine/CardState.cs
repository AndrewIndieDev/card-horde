public class CardState
{
    public async virtual void OnEnter(CardStateMachine stateMachine, CardObject card) { }
    public virtual void OnExit(CardStateMachine stateMachine, CardObject card) { }
    public async virtual void OnUpdate(CardStateMachine stateMachine, CardObject card, float deltaTime) { }
}
