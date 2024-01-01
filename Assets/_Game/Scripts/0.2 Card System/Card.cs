using UnityEngine;

public class Card : MonoBehaviour
{
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
