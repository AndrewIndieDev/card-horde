using DrewDev.GridSystem;

public class DecideBestActionState : CardState
{
    public override async void OnEnter(CardStateMachine stateMachine, CardObject card)
    {
        ActionSO bestAction = null;
        float bestScore = -1f;

        // Go through a list of actions
        // Make sure the action isn't on cooldown
        // Test the actions and give it a score based on how well it works
        // Save the action with the highest score
        foreach (var action in card.AvailableActions)
        {
            if (!action.OnCooldown)
            {
                float score = await action.CalculateValue(card);
                if (score > bestScore)
                {
                    bestAction = action;
                    bestScore = score;
                }
            }
        }

        if (bestAction != null)
        {
            stateMachine.ChangeState(new ExecuteActionState(bestAction));
        }
        else
        {
            stateMachine.ChangeState(new IdleCardState());
        }
    }

    public override void OnExit(CardStateMachine stateMachine, CardObject card)
    {
        
    }

    public override void OnUpdate(CardStateMachine stateMachine, CardObject card, float deltaTime)
    {
        
    }
}
