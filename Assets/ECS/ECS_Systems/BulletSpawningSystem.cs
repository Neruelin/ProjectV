using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class OneTenthSecondFixedStepSystemGroup : FixedStepSimulationSystemGroup
{
    protected override void OnCreate() {
        base.OnCreate();
        Timestep = 0.1f;
    }
}

public partial class OneHalfFixedStepSystemGroup : FixedStepSimulationSystemGroup
{
    protected override void OnCreate() {
        base.OnCreate();
        Timestep = 0.5f;
    }
}
public partial class OneSecondFixedStepSystemGroup : FixedStepSimulationSystemGroup
{
    protected override void OnCreate() {
        base.OnCreate();
        Timestep = 1f;
    }
}

[AlwaysUpdateSystem]
[UpdateInGroup(typeof(OneTenthSecondFixedStepSystemGroup))]
public partial class BulletSpawningSystem : SystemBase
{

    EntityCommandBufferSystem m_EntityCommandBufferSystem;
    protected override void OnCreate() {
        base.OnCreate();
        m_EntityCommandBufferSystem = World.GetOrCreateSystem<EntityCommandBufferSystem>();
    }
    protected override void OnUpdate()
    {
        EntityCommandBuffer ECB = m_EntityCommandBufferSystem.CreateCommandBuffer();
        Entity prefab = ECSImportedEntities.instance.entityPrefabs[1];

        Entities.ForEach((in Translation translation, in PlayerComponentTag tag) => {
            Entity newBullet = ECB.Instantiate(prefab);
            ECB.SetComponent<Translation>(newBullet, translation);
        }).Schedule();
    }
}
