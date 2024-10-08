using MoreMountains.Feedbacks;
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

    public MMF_Player moveFeedbacks;
    public MMF_Player ability1Feedbacks;

    public void Start()
    {
        stateMachine = new CardStateMachine(this);
        stateMachine.ChangeState(new IdleCardState());
    }

    public void Update()
    {
        stateMachine?.Update(Time.deltaTime);
    }
}
