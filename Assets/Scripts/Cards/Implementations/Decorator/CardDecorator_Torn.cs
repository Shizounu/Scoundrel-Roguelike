using Unity.VisualScripting;
using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(fileName = "new Torn Decorator", menuName = "Cards/Decorator/Torn")]
    public class CardDecorator_Torn : DecoratorCard
    {
        public override string CardName => $"Torn {CardToDecorate.CardName}";
        public override int PointValue => CardToDecorate.PointValue - 3 > 1 ? CardToDecorate.PointValue - 3 : 1;

        public static void DecorateCard(PlayerManager manager, BaseCard card)
        {
            DecorateCard<CardDecorator_Torn>(manager, card);
        }
    }
}
