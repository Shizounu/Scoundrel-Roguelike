using UnityEngine;

namespace Cards
{
    public abstract class BaseCard : ScriptableObject
    {
        public abstract string CardName { get; }
        public abstract Sprite CardSprite { get; }
        public abstract int PointValue { get; }

        public abstract void OnActivate(PlayerManager manager);
        public abstract void OnActivate(PlayerManager manager, BaseCard card);
    }
}
