using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationType
{
	Walk,
	Rest,
	Attack,
	Hit,
	Dodge,
	Dead,
}

public class AnimationState : MonoBehaviour
{
	[SerializeField]
	public AnimationType Type { get; private set; } = AnimationType.Walk;

	public RuntimeAnimatorController Walk;
	public RuntimeAnimatorController Rest;
	public RuntimeAnimatorController Attack;
	public RuntimeAnimatorController Hit;
	public RuntimeAnimatorController Dodge;
	public RuntimeAnimatorController Dead;

	private Animator animatorComponent;
	private IEnumerator currentCoroutine;

	void Start ()
	{
		animatorComponent = gameObject.GetComponent<Animator> ();

		SetType (Type, null);
	}

	public void SetType (AnimationType type, Action animationEnd)
	{
		if (currentCoroutine != null)
			StopCoroutine (currentCoroutine);

		RuntimeAnimatorController controller = Walk;
		switch (this.Type = type)
		{
			case AnimationType.Walk: controller = Walk; break;
			case AnimationType.Rest: controller = Rest; break;
			case AnimationType.Attack: controller = Attack; break;
			case AnimationType.Hit: controller = Hit; break;
			case AnimationType.Dodge: controller = Dodge; break;
			case AnimationType.Dead: controller = Dead; break;
		}
		animatorComponent.runtimeAnimatorController = controller;

		StartCoroutine (currentCoroutine = CheckAnimationEnd (animationEnd));
	}

	IEnumerator CheckAnimationEnd (Action animationEnd)
	{
		if (animatorComponent.GetCurrentAnimatorStateInfo (0).loop)
			yield break;
		while (animatorComponent.GetCurrentAnimatorStateInfo (0).normalizedTime < 1)
			yield return new WaitForFixedUpdate ();
		animationEnd?.Invoke ();
		Debug.Log ($"Animation End: {animatorComponent.runtimeAnimatorController.name}", this);
	}
}
