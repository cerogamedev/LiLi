using UnityEngine;

namespace Lili.Combat {
    
    [CreateAssetMenu(fileName = "Weapon", menuName = "LiLi/Weapon", order = 0)]
    public class Weapon : ScriptableObject {
        enum WeaponType
        {
            Bow,
            Melee
        }
        [SerializeField] float weaponDamage;
        [SerializeField] float weaponRange;
        [SerializeField] WeaponType weaponType;

        public float[] weaponStats() {
            float[] stats = {weaponDamage, weaponRange};
            return stats;
        }
        
    }
}

