using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(fileName = "new Test Card", menuName = "Cards/Test Card")]
    public class TestCard : PlayingCard
    {
        public override void OnActivate(PlayerManager manager)
        {
            Debug.Log($"{CardName} was activated with {PointValue} as its value");
        }

        public override void OnActivate(PlayerManager manager, BaseCard card)
        {
            Debug.Log($"{card.CardName} was activated with {card.PointValue} as its value");
        }
    }
}
