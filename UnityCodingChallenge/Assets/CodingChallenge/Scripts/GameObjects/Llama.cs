using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Llama : MonoBehaviour
{
    public const float HUNGRY_TIMER = 3f;
    public Transform root;
    public Renderer rend;

    private string id;
    private int health;
    private int age;
    private Item.ItemType diet;
    private int maxHealth;
    private int starvingThreshold;
    private float timer = 0;
    private bool isCaptured = true;
    private bool isStarving = false;
    private WanderAround wanderAround;
    private Material material;

    private UnityEvent<Llama> onChangeHealth;
    private UnityEvent<Llama> onStarving;
    private UnityEvent<Llama> onDeath;

    public string ID { get => id; }
    public int Health { get => health; }
    public int MaxHealth { get => maxHealth; }
    public int Age { get => age; }
    public Item.ItemType Diet { get => diet; }
    public bool IsStarving { get => isStarving; }
    public UnityEvent<Llama> OnChangeHealth { set => onChangeHealth = value; get => onChangeHealth; }
    public UnityEvent<Llama> OnStarving { set => onStarving = value; get => onStarving; }
    public UnityEvent<Llama> OnDeath { set => onDeath = value; get => onDeath; }

    #region POOL
    public void Reborn()
    {
        //Resets all parameters, creating a new llama from a recycled (pooled) one
        id = GetRandomName();
        health = Random.Range(50, 100);
        age = Random.Range(1, 11);
        diet = GetRandomDiet();
        maxHealth = health;
        starvingThreshold = (int)(0.2f * health);
        timer = 0;
        isCaptured = false;
        isStarving = false;
        onChangeHealth?.RemoveAllListeners();
        onStarving?.RemoveAllListeners();
        onDeath?.RemoveAllListeners();

        if(root != null)
        {
            root.localScale = Vector3.one * (0.5f + (age-1)/11f);
        }
        if(rend != null)
        {
            if(material == null)
            {
                material = new Material(rend.material);
            }
            material.SetColor("_BaseColor", Llama.GetDietColor(diet));
            rend.material = material;
        }
    }
    #endregion

    void Start()
    {
        wanderAround = GetComponent<WanderAround>();
        if(wanderAround == null)
        {
            Debug.Log("LLAMA: Wander Around component not found.");
        }
        onChangeHealth = new UnityEvent<Llama>();
        onStarving = new UnityEvent<Llama>();
        onDeath = new UnityEvent<Llama>();
    }
    void Update()
    {
        //Captured llamas lose 1 HP every 3 seconds
        if (isCaptured)
        {
            timer += Time.deltaTime;
            if (timer > HUNGRY_TIMER)
            {
                health -= 1;
                onChangeHealth?.Invoke(this);
                if (!isStarving && health < starvingThreshold)
                {
                    Starving();
                }
                else if (health <= 0)
                {
                    Die();
                }
                timer = 0;
            }
        }
    }
    public void GetCaptured(Vector3 position)
    {
        if(wanderAround != null)
        {
            wanderAround.TeleportTo(position);
        }
        isCaptured = true;
    }
    public bool GetFed(Item.ItemType food)
    {
        //If given the right food, heals 20 HP, up to maxHealth
        if(health == MaxHealth)
        {
            return false;
        }
        if (food == diet)
        {
            health = Mathf.Min(maxHealth, health + 20);
            if (health > starvingThreshold)
            {
                isStarving = false;
            }
            onChangeHealth?.Invoke(this);
            return true;
        }
        return false;
    }
    private void Starving()
    {
        onStarving?.Invoke(this);
        isStarving = true;
    }
    private void Die()
    {
        onDeath?.Invoke(this);
        gameObject.SetActive(false);
    }
    #region STATIC
    private static Item.ItemType GetRandomDiet()
    {
        switch (Random.Range(0, 3))
        {
            case 0: return Item.ItemType.GRASS;
            case 1: return Item.ItemType.FLOWER;
            case 2: return Item.ItemType.SHRUB;
            default: return Item.ItemType.GRASS;
        }
    }
    private static Color GetDietColor(Item.ItemType diet)
    {
        switch (diet)
        {
            case Item.ItemType.GRASS:
                return new Color(0.8f, 1f, 0.7f);
            case Item.ItemType.FLOWER:
                return new Color(1f, 0.7f, 0.8f);
            case Item.ItemType.SHRUB:
                return new Color(0.7f, 0.8f, 1f);
        }
        return Color.white;
    }
    private static readonly string[] Names = new string[]
{
            "Amy", "Brian", "Claire", "Dan", "Ellie", "Fox", "Gabe", "Hector", "Ivan", "Jack",
            "Kyle", "Lion", "Mike", "Nelly", "Omar", "Parker", "Qin", "Ryan", "Stu", "Trevor",
            "Uggi", "Victoria", "William", "Xavier", "Yasmin", "Zoey"
};

    private static string GetRandomName()
    {
        return Names[Random.Range(0, Names.Length)];
    }
    #endregion
}
