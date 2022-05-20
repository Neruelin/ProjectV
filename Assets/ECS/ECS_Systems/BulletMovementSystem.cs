using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[AlwaysUpdateSystem]
public partial class BulletMovementSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref Translation translation, in LocalToWorld ltw, in BulletTag tag) => {
            translation.Value += math.normalize(ltw.Up) * deltaTime * 30;
        }).Schedule();
    }
}
