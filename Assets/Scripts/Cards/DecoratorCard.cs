using UnityEngine;

namespace Cards
{
    public abstract class DecoratorCard : BaseCard
    {
        public BaseCard CardToDecorate;

        public override string CardName => CardToDecorate.CardName;
        public override Sprite CardSprite => CardToDecorate.CardSprite;
        public override int PointValue => CardToDecorate.PointValue;

        public override void OnActivate(PlayerManager manager)
        {
            CardToDecorate.OnActivate(manager, this);
        }

        public override void OnActivate(PlayerManager manager, BaseCard card)
        {
            CardToDecorate.OnActivate(manager, card);
        }
    
        public static void DecorateCard<T>(PlayerManager manager, BaseCard card) where T : DecoratorCard 
        {
            manager.CurrentDeck.Cards.Remove(card);
            T Card = CreateInstance<T>();
            manager.CurrentDeck.Cards.Add(Card);
        }
    }
}
