using UnityEngine;
using System.Collections;

public interface IAttackable {

	void ReceiveHit(int damage, DamageTypes damageType);

//	void RegisterSuccessfulDestroy(float value);

}
