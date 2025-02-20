using UnityEngine;

namespace Cards
{
    public abstract class PlayingCard : BaseCard
    {
        [Header("Visuals")]
        [SerializeField] private string _CardName;
        [SerializeField] private Sprite _CardSprite;

        [Header("Mechanics")]
        [SerializeField] private int _PointValue;

        public override string CardName => _CardName;
        public override Sprite CardSprite => _CardSprite;
        public override int PointValue => _PointValue;
    }
}
