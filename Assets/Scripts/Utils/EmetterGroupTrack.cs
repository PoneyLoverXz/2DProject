using UnityEngine;
using UnityEngine.Timeline;

namespace Assets.Scripts.Utils
{
    [TrackClipType(typeof(EmetterControlAsset))]
    [TrackBindingType(typeof(ProjectileEmetter))]
    class EmetterGroupTrack : TrackAsset
    {
    }
}
