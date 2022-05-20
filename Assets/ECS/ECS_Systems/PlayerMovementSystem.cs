using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

// [AlwaysUpdateSystem]
public partial class PlayerMovementSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        float3 direction = new float3(0f,0f,0f);
        if (Input.GetKey(KeyCode.A)) direction += new float3(-1f,0f,0f);
        if (Input.GetKey(KeyCode.D)) direction += new float3(1f,0f,0f);
        if (Input.GetKey(KeyCode.W)) direction += new float3(0f,0f,1f);
        if (Input.GetKey(KeyCode.S)) direction += new float3(0f,0f,-1f);

        Entities.ForEach((ref Translation translation, in Stats stats, in RecieveInputComponentTag tag) => {
            if (!direction.Equals(new float3(0f,0f,0f))) {
                translation.Value += math.normalize(direction) * deltaTime * stats.Speed;
            }
        }).Schedule();
    }
}
