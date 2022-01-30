using Unity.Mathematics;
using UnityEngine;

public class VFXManager : MonoBehaviour {
    public GameObject damage;
    [SerializeField] private AudioClip damageSound;

    public GameObject death;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip bonusSound;

    public static VFXManager Instance;

    private void Awake() {
        Instance = GetComponent<VFXManager>();
    }

    public void SpawnDamage(Transform position) {
        Debug.Log("Damage " + AudioManager.Instance);
        Instantiate(damage, position.position, quaternion.identity, position);
        AudioManager.Instance.PlaySound(damageSound);
    }

    public void SpawnDeath(Transform position) {
        Debug.Log("Death " + AudioManager.Instance);
        Instantiate(death, position.position, quaternion.identity, position);
        AudioManager.Instance.PlaySound(deathSound);
    }
    public void SpawnBonus(Transform position) {
        
        AudioManager.Instance.PlaySound(bonusSound);
    }
}