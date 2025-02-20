using Cards;
using UnityEngine;
using Cards.Implementation.Cards;
using System.Collections.Generic;
using UnityEngine.Rendering;
public class PlayerManager : MonoBehaviour {
    [Header("Dungeon")]
    [SerializeField] private Deck DeckDefinition;
    [HideInInspector] public Deck CurrentDeck;

    public List<BaseCard> CurrentCards;
    public int MaxRoomSize = 4;

    [Header("Health")]
    [SerializeField] private int CurrentHealth = 20;
    [SerializeField] private int MaxHealth = 20;
    public int Health
    {
        get => CurrentHealth;
        set
        {
            CurrentHealth = value;
            if (CurrentHealth > MaxHealth)
                CurrentHealth = MaxHealth;
        }
    }

    [Header("Equipment Card")]
    [SerializeField] private bool useEquipment; 
    [SerializeField] private BaseCard equipment;
    [SerializeField] private List<BaseCard> defeatedMonsters;

    private void Start()
    {
        CurrentDeck = Instantiate(DeckDefinition);
        CurrentDeck.Shuffle();
        DrawUntilRoomSize();
    }

    public void UseCardAtIndex(int index)
    {
        CurrentCards[index].OnActivate(this);
        CurrentCards.RemoveAt(index);
        if (CurrentCards.Count == 1)
            DrawUntilRoomSize();
    }

    public void Heal(int Amount)
    {
        Health += Amount;
    }
    public void Equip(BaseCard newEquipment)
    {
        equipment = newEquipment;
        defeatedMonsters = new();
    }
    public void DoCombat(BaseCard monsterCard)
    {
        if (useEquipment) {
            Health -= Mathf.Max(0, (monsterCard.PointValue - equipment.PointValue));
            defeatedMonsters.Add(monsterCard);
        } else {
            Health -= monsterCard.PointValue;
        }
    }
    public int GetDurability() => defeatedMonsters[^1].PointValue;
    public void DrawUntilRoomSize()
    {
        while(CurrentCards.Count < MaxRoomSize) {
            CurrentCards.Add(CurrentDeck.DrawCard());
        }
    }
}
