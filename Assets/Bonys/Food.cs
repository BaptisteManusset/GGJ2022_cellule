using UnityEngine;

namespace Bonys {
    [CreateAssetMenu(fileName = "Food", menuName = "Bonus/Food", order = 0)]
    public class Food : Bonus {
        public override void Action() {
            base.Action();
            Player.Instance._healthManager.IncreaseHealth();
        }
    }
}