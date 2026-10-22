using UnityEngine;
using UnityEngine.AI;

namespace EnemyAI
{
    public class EnemyHealth : HealthManager
    {
        [Tooltip("The current NPC health.")] public float health = 100f;

        [Tooltip("The game object particle emitted when hit.")]
        public GameObject bloodSample;

        [Tooltip("Use headshot damage multiplier?")]
        public bool headshot;

        [SerializeField] private GameObject _dropGun;
        [SerializeField] private Transform _dropTransform;

        private Transform weapon; // The NPC weapon.

        private Animator anim; // The NPC animator controller.
        private StateController controller; // The NPC AI FSM controller.
        private static readonly int Hit = Animator.StringToHash("Hit");

        private void Awake()
        {
            anim = GetComponent<Animator>();
            foreach (Transform child in anim.GetBoneTransform(HumanBodyBones.RightHand))
            {
                weapon = child.Find("muzzle");
                if (weapon != null)
                {
                    break;
                }
            }

            weapon = weapon.parent;
        }

        public void Kill()
        {
            foreach (MonoBehaviour mb in this.GetComponents<MonoBehaviour>())
            {
                if (this != mb)
                    Destroy(mb);
            }

            Destroy(this.GetComponent<NavMeshAgent>());
            RemoveAllForces();
            anim.enabled = false;
            Destroy(weapon.gameObject);
            dead = true;
            if (_dropGun)
                Instantiate(_dropGun, _dropTransform.position, _dropTransform.rotation);
            Destroy(gameObject, 5f);
        }
        private void RemoveAllForces()
        {
            foreach (Rigidbody member in GetComponentsInChildren<Rigidbody>())
            {
                member.isKinematic = false;
                member.linearVelocity = Vector3.zero;
            }
        }
    }
}