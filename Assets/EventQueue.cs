using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventQueue : MonoBehaviour {

	public List<ActionEvent> actionEvents;
	public static EventQueue instance;

	public ActionEvent CurrentEvent(){
		if (actionEvents.Count > 0) {
			return(actionEvents [0]);
		} else {
			return(null);
		}
	}

	// Use this for initialization
	void Start () {
		instance = this;
		actionEvents = new List<ActionEvent> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (CurrentEvent () != null) {
			print ("currentEventFound");
			if (!CurrentEvent ().executed) {
				print ("currentEventExecuted");
				CurrentEvent ().Execute ();
			} else {
				print ("currentEventFinished: " + CurrentEvent().Finished());
				if(CurrentEvent().Finished()){
					print ("currentEventFinishedAndRemoved");
					actionEvents.RemoveAt (0);
				}
			}
		}
	}

	public static void AddEvent(IAttackable attackable, int damage, DamageTypes damageType){
		ActionEvent actionEvent = new ActionEvent ();
		actionEvent.attackable = attackable;
		actionEvent.damage = damage;
		actionEvent.damageType = damageType;
		instance.actionEvents.Add(actionEvent);
	}

	public static void AddDestroy(IAttackable attackable){
		ActionEvent actionEvent = new ActionEvent ();
		actionEvent.attackable = attackable;
		actionEvent.destroy = true;
		instance.actionEvents.Add(actionEvent);
	}

	public static void AddMessage(string message){
		ActionEvent actionEvent = new ActionEvent ();
		actionEvent.text = message;
		instance.actionEvents.Add(actionEvent);
	}
}
