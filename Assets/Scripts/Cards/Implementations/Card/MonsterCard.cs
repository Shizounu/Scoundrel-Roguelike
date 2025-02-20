using UnityEngine;

namespace Cards.Implementation.Cards {
    [CreateAssetMenu(fileName = "new Monster Card", menuName = "Cards/Monster Card")]
    public class MonsterCard : PlayingCard
    {
        public override void OnActivate(PlayerManager manager)
        {
            manager.DoCombat(this);
        }

        public override void OnActivate(PlayerManager manager, BaseCard card)
        {
            manager.DoCombat(card);
        }
    }
}
