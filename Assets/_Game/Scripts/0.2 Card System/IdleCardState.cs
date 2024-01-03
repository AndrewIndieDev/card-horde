using DG.Tweening;
using DrewDev.GridSystem;
using UnityEngine;

public class IdleCardState : CardState
{
    private MyGrid Grid => GridComponent.Instance.Grid;

    private float maxTimer = 1.1f;
    private float timer = 1f;

    public override void OnEnter(CardStateMachine stateMachine, Card card)
    {
        timer = Random.Range(0f, maxTimer);
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
            timer = maxTimer;
            Vector2 currentPosition = card.GridPosition;
            Vector2 randomMove = new Vector2(currentPosition.x + Random.Range(-5, 6), currentPosition.y + Random.Range(-5, 6));
            if (Grid.GetCell(randomMove).IsWalkable)
                card.transform.DOMove(GridComponent.Instance.Grid.GridToWorldPosition(randomMove), 1f);
        }
    }
}
