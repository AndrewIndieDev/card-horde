public class DecisionMakingState : CardState
{
    private float timerMax = 1f;
    private float timer = 1f;
    private int maxBestDecisionFailCount = 5;

    public override void OnEnter(CardStateMachine stateMachine, Card card)
    {

    }

    public override void OnExit(CardStateMachine stateMachine, Card card)
    {

    }

    public override void OnUpdate(CardStateMachine stateMachine, Card card, float deltaTime)
    {
        timer -= deltaTime;
        if (timer <= 0f)
        {
            // Weigh the options, and choose the best one if it's above a certain threshold.
            // If it's not above the threshold, choose a random option after the maxBestDecisionFailCount is reached.

            timer = timerMax;
            maxBestDecisionFailCount--;
            if (maxBestDecisionFailCount <= 0)
            {
                // Choose a random option that is above 0.0 weight.
                // If no options are above 0.0 weight, choose a movement option.

                // Debug, go back to IdleCardState.
                stateMachine.ChangeState(new IdleCardState());
            }
        }
    }
}
