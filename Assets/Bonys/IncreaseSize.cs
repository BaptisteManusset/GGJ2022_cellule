using UnityEngine;

namespace Bonys {
    [CreateAssetMenu(fileName = "IncreaseSize", menuName = "Bonus/IncreaseSize", order = 0)]

    public class IncreaseSize : Bonus {
        public override void Action() {
            base.Action();
            Player.Instance.IncreaSize();
        }
    }
}