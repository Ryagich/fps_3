using UnityEngine;
using UnityEngine.Events;

public class GameOuter : MonoBehaviour
{
   [SerializeField] private UnityEvent End;

   public void Init()
   {
      SubsController.Instance.EndWrite +=()=> End?.Invoke();
   }
}
