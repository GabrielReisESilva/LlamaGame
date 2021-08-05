using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
	public Pen pen;
	public Animator playerAnimator;
	public NavMeshAgent agent;

	private int health;
	private int coins;
	private Inventory inventory;

	public int Coins { get => coins; }
	public List<Item> Inventory { get => inventory?.List; }

	void Start()
	{
		health = 100;
		coins = 0;
		inventory = GetComponent<Inventory>();

		if(inventory == null)
        {
			Debug.LogError("PLAYER: Inventory not found");
        }
	}

	void Update()
	{
		if (playerAnimator != null && agent != null)
		{
			playerAnimator.SetFloat("Velocity", agent.velocity.magnitude);
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Llama"))
		{
			//If collides with a llama, try to capture it
			Llama llama = other.GetComponent<Llama>();
			if(llama == null)
            {
				Debug.LogError(other.name + ": Object is tagged as Llama, but doesn't have a llama component");
				return;
            }

			if(pen != null)
			{
				pen.TryCaptureLlama(llama);
            }
		}
	}
	public void TryToFeedLlama(Llama llama)
    {
		if(llama != null)
		{
			//Try to feed a llama with the items in the inventory
			Item stock = inventory.GetItem(llama.Diet);
			if (stock != null && stock.amount > 0)
			{
                if (llama.GetFed(stock.type))
				{
					stock.amount--;
				}
			}
		}
    }
	public void CollectMoney()
	{
		coins++;
	}

	public void SetData(int coins, List<Item> inventory)
    {
		this.coins = coins;
		this.inventory.SetList(inventory);
    }
}
