using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI
{
    class UIAnimateButtonScale: MonoBehaviour
    {
        [SerializeField] private AnimationCurve easing;
        [SerializeField] private float animationTime = 1f;
        [SerializeField] private float scaleCoef = 1.1f;
        private Vector3 startScale;
        private void Awake()
        {
            startScale = transform.localScale;
        }
        public void Animate()
        {
            StartCoroutine(AnimateScale());
        }
        private IEnumerator AnimateScale()
        {
            float elapsedTime = 0f;

            while (elapsedTime < animationTime)
            {
                float t = Mathf.PingPong(2 * elapsedTime / animationTime, 1f);

                transform.localScale = Vector3.Lerp(startScale, startScale * scaleCoef, easing.Evaluate(t));

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.localScale = startScale;
        }
    }

}
