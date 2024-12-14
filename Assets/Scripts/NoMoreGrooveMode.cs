using UnityEngine;

public class NoMoreGrooveMode : StateMachineBehaviour
{
	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Object.Destroy(animator.gameObject, stateInfo.length);
	}
}
