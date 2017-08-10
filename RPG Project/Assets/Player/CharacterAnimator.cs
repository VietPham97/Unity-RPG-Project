using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour 
{
    const float locomotionAnimationSmoothTime = 0.1f;

    NavMeshAgent agent;
	Animator animator;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent", speedPercent, locomotionAnimationSmoothTime, Time.deltaTime);
    }
}
