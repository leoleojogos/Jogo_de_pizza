using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Set a variável Hitting do animator para false quando a animação de ataque da marreta finaliza
/// </summary>
public class HammerAttackBahaviour : StateMachineBehaviour
{
	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetBool("Hitting", false);
	}
}
