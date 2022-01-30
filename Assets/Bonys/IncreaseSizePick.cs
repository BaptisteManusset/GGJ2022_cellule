using UnityEngine;

namespace Bonys {
    [CreateAssetMenu(fileName = "IncreaseSize with Pick", menuName = "Bonus/IncreaseSize with Pick", order = 0)]

    public class IncreaseSizePick : Bonus {
        public override void Action() {
            base.Action();
            Player.Instance.IncreaSize(TypeOfBodyPart.pick);
        }
    }
}