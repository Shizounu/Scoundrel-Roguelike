using UnityEngine;

namespace Cards.Implementation.Cards
{
    [CreateAssetMenu(fileName = "new Equipment Card", menuName = "Cards/Equipment Card")]
    public class EquipmentCard : PlayingCard
    {
        public override void OnActivate(PlayerManager manager)
        {
            manager.Equip(this);
        }

        public override void OnActivate(PlayerManager manager, BaseCard card)
        {
            manager.Equip(card);
        }
    }

}
