using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

// [AlwaysUpdateSystem]
public partial class EnemyFollowPlayerSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entity player = ECSImportedEntities.GetPlayer();
        Translation playerPosition = EntityManager.GetComponentData<Translation>(player);

        Entities.ForEach((ref Translation translation, in Stats stats, in EnemyComponentTag tag) => {
            float dist = math.distance(playerPosition.Value, translation.Value);
            float3 dir = math.normalize(playerPosition.Value - translation.Value);
            if (dist < 1f) {
                translation.Value += dir * dist * deltaTime * stats.Speed;
            } else {
                translation.Value += dir * deltaTime * stats.Speed;
            }
        }).Schedule();
    }
}
