using UnityEngine;
using System.Collections;

public class ActionEvent {

	public IAttackable attackable;
	public int damage;
	public DamageTypes damageType;
	public bool destroy;
	public string text;
	public bool executed;

	public void Execute(){
		if (text != null) {
			SpeechBubble.AddMessage (text);
		} else {
			if (!destroy) {
				attackable.ReceiveHit (damage, damageType);
			} else {
				attackable.DestroyMe ();
			}

		}
		executed = true;
	}

	public bool Finished(){
		if (text == null) {
			return(true);
		}else{
			return(SpeechBubble.mainBubble.done);
		}
	}

}
