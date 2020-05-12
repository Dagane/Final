using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
	[SerializeField]
	GameObject[] pickUps;
    
	private bool hasInst = false;
	EnemyHealth enemy;

	void Awake()
	{
		enemy = GetComponent<EnemyHealth>();
		//enemy.OnDead += Drop;
	}

	public void Drop()
	{
		if (!hasInst)
		{
			foreach (GameObject pickUp in pickUps)
			{
				//instanciar todos los gameObjects
				Instantiate(pickUp, enemy.transform.position, enemy.transform.rotation);
			}
			//Evita que se instancee mas de 1
			hasInst = true;
		}
	}
}