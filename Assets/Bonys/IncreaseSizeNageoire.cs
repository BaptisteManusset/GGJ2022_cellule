using UnityEngine;

namespace Bonys {
    [CreateAssetMenu(fileName = "IncreaseSizeNageoire", menuName = "Bonus/IncreaseSizeNageoire", order = 0)]
    public class IncreaseSizeNageoire : Bonus {
        public override void Action() {
            base.Action();
            Player.Instance.IncreaSize(TypeOfBodyPart.nageoire);
            Player.Instance.IncreaseSpeedBonus();
            Manager.IncreaseScore(18);
        }
    }
}