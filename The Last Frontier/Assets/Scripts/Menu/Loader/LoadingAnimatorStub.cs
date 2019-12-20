using System.Collections;
using UnityEngine;

namespace Menu.Loader
{
    public class LoadingAnimatorStub : MonoBehaviour
    {
        private void OnEnable()
        {
            StartCoroutine(Disable());
        }

        private IEnumerator Disable()
        {
            yield return new WaitForSecondsRealtime(1f);
            transform.gameObject.SetActive(false);
        }
    }
}