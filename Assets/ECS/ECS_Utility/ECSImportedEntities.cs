using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using Unity.Physics;
using Unity.Mathematics;

public class ECSImportedEntities : MonoBehaviour
{
    private EntityManager _manager;
    private BlobAssetStore _blobAssetStore;
    private GameObjectConversionSettings _settings;
    
    public GameObject[] gameObjectPrefabs;
    private Entity[] entityPrefabs;
    public GameObject PlayerGameObject;
    private static Entity BasePlayerEntity;
    private static Entity PlayerEntity;

    void Start()
    {
        entityPrefabs = new Entity[gameObjectPrefabs.Length];
        
        _blobAssetStore = new BlobAssetStore();
        _manager = World.DefaultGameObjectInjectionWorld.EntityManager;
        _settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, _blobAssetStore);

        //Conversion from gameobject to entity
        //General objects
        for (int i = 0; i < gameObjectPrefabs.Length; i++) {
            entityPrefabs[i] = GameObjectConversionUtility.ConvertGameObjectHierarchy(gameObjectPrefabs[i], _settings);
        }
        //Player object
        BasePlayerEntity = GameObjectConversionUtility.ConvertGameObjectHierarchy(PlayerGameObject, _settings);

        for (int i = 0; i < 1000; i++) {
            Entity enemy = RequestEntity(0);
            _manager.SetComponentData(enemy, new Translation{
                Value = new float3(UnityEngine.Random.Range(-10f, 10f),UnityEngine.Random.Range(-10f, 10f),UnityEngine.Random.Range(-10f, 10f))
            });
        }

        SpawnPlayer(new float3(0f,0f,0f));
    }

    void SpawnPlayer(float3 position) {
        PlayerEntity = _manager.Instantiate(BasePlayerEntity);
        _manager.SetComponentData(PlayerEntity, new Translation{Value=position});
        _manager.SetComponentData(PlayerEntity, new Stats{Speed=5f});
    }

    public static Entity GetPlayer() {
        return PlayerEntity;
    }

    public Entity RequestEntity(int idx) {
        return _manager.Instantiate(entityPrefabs[idx]);
    }

    private void OnDestroy() {
        _blobAssetStore.Dispose();
    }
}
