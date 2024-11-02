public class CardStateMachine
{
    public CardObject Card { get; set; }
    public CardState CurrentState { get; set; }

    public CardStateMachine(CardObject card)
    {
        Card = card;
    }

    public void Update(float deltaTime)
    {
        CurrentState?.OnUpdate(this, Card, deltaTime);
    }

    public void ChangeState(CardState state)
    {
        CurrentState?.OnExit(this, Card);
        CurrentState = state;
        CurrentState?.OnEnter(this, Card);
    }
}
