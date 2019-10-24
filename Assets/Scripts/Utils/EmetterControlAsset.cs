using UnityEngine;
using UnityEngine.Playables;

public class EmetterControlAsset : PlayableAsset
{
    public EmetterType emetterType = EmetterType.StraightLine;
    public float speed = 0.5f;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<EmetterControlBehaviour>.Create(graph);

        var emetterControlBehaviour = playable.GetBehaviour();
        emetterControlBehaviour.emetterType = emetterType;
        emetterControlBehaviour.speed = speed;

        return playable;
    }
}
