using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
public class EntityFollow : MonoBehaviour
{
    public float3 offset = new float3(10f, 10f, 10f);
    public Entity entityToFollow;
    private EntityManager _manager;
    // Start is called before the first frame update
    void Awake()
    {
        _manager = World.DefaultGameObjectInjectionWorld.EntityManager;
    }

    // Update is called once per frame
    void Update()
    {
        if (entityToFollow == Entity.Null) entityToFollow = ECSImportedEntities.GetPlayer();
        if (entityToFollow == Entity.Null) return;
        Translation entityPosition = _manager.GetComponentData<Translation>(entityToFollow);
        transform.position = entityPosition.Value + offset;
        transform.LookAt(entityPosition.Value);
    }
}
