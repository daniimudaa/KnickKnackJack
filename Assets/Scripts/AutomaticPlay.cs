using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticPlay : MonoBehaviour 
{
	public Animation anim;
	public Animation anim1;
	public Animation anim2;
	public Animation anim3;
	public Animation anim4;
	public Animation anim5;
	public Animation anim6;
	public Animation anim7;
	public Animation anim8;

	void Update () 
	{
		StartCoroutine (MyAnimations ());
	}

	IEnumerator MyAnimations()
	{
		anim8.Play ();
		anim.Play ();
		yield return new WaitForSeconds(4);
		anim1.Play ();
		yield return new WaitForSeconds(4);
		anim2.Play ();
		yield return new WaitForSeconds(4);
		anim3.Play ();
		yield return new WaitForSeconds(4);
		anim4.Play ();
		yield return new WaitForSeconds(4);
		anim5.Play ();
		yield return new WaitForSeconds(4);
		anim6.Play ();
		yield return new WaitForSeconds(4);
		anim7.Play ();
		yield return new WaitForSeconds(4);

	}
}
