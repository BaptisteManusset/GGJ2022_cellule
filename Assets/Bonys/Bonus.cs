using System;
using UnityEngine;

namespace Bonys {
    public class Bonus : ScriptableObject {
        public virtual void Action() {
        }
    }

    public enum TypeOfBodyPart {
        normal = 0,
        pick = 1,
        nageoire = 2
    }
}