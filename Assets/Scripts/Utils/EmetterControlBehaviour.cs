using UnityEngine;
using UnityEngine.Playables;

public class EmetterControlBehaviour : PlayableBehaviour
{
    public EmetterType emetterType = EmetterType.StraightLine;

    public float speed = 0.5f;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        ProjectileEmetter emetter = playerData as ProjectileEmetter;

        if (emetter != null)
        {
            emetter.emetterType = emetterType;
            emetter.speed = speed;
            emetter.Shoot();
        }
    }
}
