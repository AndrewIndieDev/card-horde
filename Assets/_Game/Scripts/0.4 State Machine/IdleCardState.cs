public class IdleCardState : CardState
{
    private float decisionTimer;

    public override void OnEnter(CardStateMachine stateMachine, CardObject card)
    {
        decisionTimer = card.unit.stats.ModifiedDecisionTime;
    }

    public override void OnExit(CardStateMachine stateMachine, CardObject card)
    {
        
    }

    public override void OnUpdate(CardStateMachine stateMachine, CardObject card, float deltaTime)
    {
        decisionTimer -= deltaTime;
        if (decisionTimer <= 0f)
        {
            stateMachine.ChangeState(new DecideBestActionState());
        }
    }
}
/* Maybe useful when I get to card movement
timer -= deltaTime;
        if (timer <= 0f)
        {
            timer = Random.Range(0.8f, 1.2f);
            Vector2 currentPosition = card.GridPosition;
            Vector2 randomMove = new Vector2(currentPosition.x + Random.Range(-1, 2), currentPosition.y + Random.Range(-1, 2));
            int iterations = 10;
            while (randomMove == Vector2.zero && iterations > 0)
            {
                randomMove = new Vector2(currentPosition.x + Random.Range(-1, 2), currentPosition.y + Random.Range(-1, 2));
                iterations--;
            }
            GridCell currentCell = Grid.GetCell(currentPosition);
            GridCell targetCell = Grid.GetCell(randomMove);
            bool acceptableMove = targetCell != null && targetCell.IsWalkable && !targetCell.IsOccupied;

            if (acceptableMove)
            {
                currentCell.ClearOccupier();
                moveTween = card.transform.DOMove(GridComponent.Instance.Grid.GridToWorldPosition(randomMove), 0.5f);
                targetCell.SetOccupier(card);
            }
            else if (targetCell != null)
            {
                stateMachine.ChangeState(new ExecuteActionState());
            }
        }
*/