using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_POST_PROCESSING_STACK_V2
using UnityEngine.Rendering.PostProcessing;
#endif

namespace NeoFPS
{
    [HelpURL("https://docs.neofps.com/manual/graphicsref-mb-postprocesslayerfix.html")]
    public class PostProcessLayerFix : MonoBehaviour
    {
#if UNITY_POST_PROCESSING_STACK_V2

#else
        protected void Awake()
        {
            Destroy(this);
        }
#endif
    }
}