using UnityEngine;

public class Card : MonoBehaviour, IGridCellOccupier
{
    public Vector2 GridPosition
    {
        get
        {
            return GridComponent.Instance.Grid.WorldToGridPosition(transform.position);
        }
    }

    private CardStateMachine stateMachine;

    public void Start()
    {
        stateMachine = new CardStateMachine(this);
        stateMachine.ChangeState(new IdleCardState());
    }

    public void Update()
    {
        stateMachine.Update(Time.deltaTime);
    }
}
