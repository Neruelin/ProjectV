using UnityEngine;
using Unity.Entities;

public class LeaderAuthoring : MonoBehaviour, IConvertGameObjectToEntity {
    public GameObject followerObject;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem) {
        if (followerObject == null) followerObject = GameObject.FindWithTag("MainCamera");
        EntityFollow entityFollow = followerObject.GetComponent<EntityFollow>();

        if (entityFollow == null) {
            entityFollow = followerObject.AddComponent<EntityFollow>();
        }

        entityFollow.entityToFollow = entity;
    }
}