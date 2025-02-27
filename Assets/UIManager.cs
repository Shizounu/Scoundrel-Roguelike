using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using Cards.Implementation.Cards;
using TMPro;

public class UIManager : MonoBehaviour {
    public PlayerManager playerManager;
    public List<int> CurrentSelection = new();

    [Header("Room Cards")]
    public CardSlot CardSlot0 = new();
    public CardSlot CardSlot1 = new();
    public CardSlot CardSlot2 = new();
    public CardSlot CardSlot3 = new();

    [Header("Equipment and Health")]
    public CardSlot EquipmentCard;
    public Image highestCard;
    [Space()]
    public Image healthImage;
    public TextMeshProUGUI text;

    [Space(), Header("Color Reference")]
    public Color SoloSelectColor;
    public Color MultiSelectColor;
    public Color UnableToCombatColor;
    public Gradient HealthColorGradient;
    private void LateUpdate()
    {
        //Update Visuals
        for (int i = 0; i < playerManager.MaxRoomSize; i++) {
            if (i < playerManager.CurrentCards.Count) {
                IndexToSlot(i).Image.sprite = playerManager.CurrentCards[i].CardSprite;
                IndexToSlot(i).SetVisible();
            } else {
                IndexToSlot(i).SetInvisible();
            }
            IndexToSlot(i).SetUnselected();
        }
        if (playerManager.equipment != null) {
            EquipmentCard.UpdateSprite(playerManager.equipment.CardSprite);
            EquipmentCard.SetVisible();
        } else {
            EquipmentCard.SetInvisible();
        }

        if(playerManager.defeatedMonsters.Count > 0) {
            highestCard.enabled = true; 
            highestCard.sprite = playerManager.defeatedMonsters[^1].CardSprite;
        } else {
            highestCard.enabled = false; 
        }

        foreach (int index in CurrentSelection)
        {
            if (CurrentSelection.Count == 1) {
                if(playerManager.useEquipment && playerManager.CurrentCards[index].GetType() == typeof(MonsterCard) && playerManager.GetDurability() <= playerManager.CurrentCards[index].PointValue)
                    IndexToSlot(index).SetUnableToCombat(UnableToCombatColor);
                else
                    IndexToSlot(index).SetSoloSelected(SoloSelectColor);
                
            }
            else
            {
                IndexToSlot(index).SetMultiSelected(MultiSelectColor);
            }
        }

        text.text = $"{playerManager.Health}";
        healthImage.color = HealthColorGradient.Evaluate((float)playerManager.Health / playerManager.MaxHealth);
    }


    public void ClearSelection()
    {
        /*
        IndexToSlot(0).SetUnselected();
        IndexToSlot(1).SetUnselected();
        IndexToSlot(2).SetUnselected();
        IndexToSlot(3).SetUnselected();
        */
        CurrentSelection.Clear();
    }
    public CardSlot IndexToSlot(int index)
    {
        return index switch
        {
            0 => CardSlot0,
            1 => CardSlot1,
            2 => CardSlot2,
            3 => CardSlot3,
            _ => throw new System.IndexOutOfRangeException(),
        };
    }
    public void SwapSelection(int index)
    {
        if (CurrentSelection.Contains(index))
            CurrentSelection.Remove(index);
        else
            CurrentSelection.Add(index);
    }
    public void ToggleUseEquipment()
    {
        EquipmentCard.ActivateButtonImage.enabled = !EquipmentCard.ActivateButtonImage.enabled;
    }
}

[System.Serializable]
public class CardSlot
{
    public Image Image;
    public Button Button;
    [Space()]
    public Button ActivateButton;
    public Image ActivateButtonImage;
    public void UpdateSprite(Sprite sprite)
    {
        Image.sprite = sprite;
    }

    public void SetInvisible() {
        Image.enabled = false;
        Button.enabled = false;
    }
    public void SetVisible()
    {
        Image.enabled = true;
        Button.enabled = true;
    }
    public void SetSoloSelected(Color soloSelectColor)
    {
        ActivateButton.gameObject.SetActive(true);
        ActivateButton.interactable = true;
        ActivateButtonImage.color = soloSelectColor;
    }
    public void SetUnableToCombat(Color unableToCombat)
    {
        ActivateButton.gameObject.SetActive(true);
        ActivateButton.interactable = false;
        ActivateButtonImage.color = unableToCombat;
    }
    public void SetMultiSelected(Color multiSelectColor)
    {
        ActivateButton.gameObject.SetActive(true);
        ActivateButton.interactable = false;
        ActivateButtonImage.color = multiSelectColor;
    }
    public void SetUnselected()
    {
        ActivateButton.gameObject.SetActive(false);
    }


}
