// using Unity.Burst;
// using Unity.Collections;
// using Unity.Entities;
// using Unity.Jobs;
// using Unity.Mathematics;
// using Unity.Transforms;
// using UnityEngine;

// [AlwaysUpdateSystem]
// public partial class Template_System : SystemBase
// {
//     protected override void OnUpdate()
//     {
//         float deltaTime = Time.DeltaTime;

//         Entities.ForEach((ref Translation translation, in EnemyComponentTag tag) => {
//             // Implement the work to perform for each entity here.
//             // You should only access data that is local or that is a
//             // field on this job. Note that the 'rotation' parameter is
//             // marked as 'in', which means it cannot be modified,
//             // but allows this job to run in parallel with other jobs
//             // that want to read Rotation component data.
//             // For example,
//             translation.Value.z += deltaTime;
//         }).Schedule();
//     }
// }
