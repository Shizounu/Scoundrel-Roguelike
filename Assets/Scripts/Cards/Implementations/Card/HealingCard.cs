using UnityEngine;

namespace Cards.Implementation.Cards
{
    [CreateAssetMenu(fileName = "new Healing Card", menuName = "Cards/Healing Card")]
    public class HealingCard : PlayingCard
    {
        public override void OnActivate(PlayerManager manager)
        {
            manager.Heal(PointValue);
        }

        public override void OnActivate(PlayerManager manager, BaseCard card)
        {
            manager.Heal(card.PointValue);
        }
    }

}
