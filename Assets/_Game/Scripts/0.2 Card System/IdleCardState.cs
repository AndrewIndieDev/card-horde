using DG.Tweening;
using DrewDev.GridSystem;
using UnityEngine;

public class IdleCardState : CardState
{
    private MyGrid Grid => GridComponent.Instance.Grid;

    private float timer;
    private Tween moveTween;

    public override void OnEnter(CardStateMachine stateMachine, Card card)
    {
        timer = Random.Range(0f, 2f);
    }

    public override void OnExit(CardStateMachine stateMachine, Card card)
    {
        moveTween?.Complete();
    }

    public override void OnUpdate(CardStateMachine stateMachine, Card card, float deltaTime)
    {
        timer -= deltaTime;
        if (timer <= 0f)
        {
            timer = Random.Range(0.8f, 1.2f);
            Vector2 currentPosition = card.GridPosition;
            Vector2 randomMove = new Vector2(currentPosition.x + Random.Range(-5, 6), currentPosition.y + Random.Range(-5, 6));
            GridCell currentCell = Grid.GetCell(currentPosition);
            GridCell moveToCell = Grid.GetCell(randomMove);
            bool canMoveTo = moveToCell != null && moveToCell.IsWalkable && !moveToCell.IsOccupied;

            if (canMoveTo)
            {
                currentCell.ClearOccupier();
                moveTween = card.transform.DOMove(GridComponent.Instance.Grid.GridToWorldPosition(randomMove), 0.5f);
                moveToCell.SetOccupier(card);
            }
        }
    }
}
