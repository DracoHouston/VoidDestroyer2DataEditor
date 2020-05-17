#pragma once
#include "Ogre.h"
#include <string>
#include <map>
#include "EditorRendererObject.h"

class EditorActorComponent;
class EditorActorFrameListener;
class RotateBoneAnimationComponent;

class EditorActor : public EditorRendererObject
{
	Ogre::Entity* Mesh;
	//Ogre::SceneNode* Transform;
	//EditorActor* ParentActor;
	//EditorWorld* ParentWorld;
	std::map<std::string, EditorActor*> Children;
	std::map<std::string, EditorActorComponent*> Components;
	EditorActorFrameListener* FrameListener;
public:
	
	
	void SetMesh(std::string inMeshName);
	std::string GetMeshName();
	Ogre::Entity* GetMesh();
	virtual float GetBoundingRadius();
	virtual void Destroy();
	void RegisterForUpdate();
	void Update(float DeltaTime, float TotalTime);
	/*void SetParentActor(EditorActor& inParent);
	EditorActor& GetParentActor();*/
	EditorActor& CreateChildActor(std::string inName);
	void DestroyChildActor(EditorActor& inDestroyTarget);
	void DestroyChildActorByName(std::string inName);
	void RemoveChildActor(EditorActor& inDestroyTarget);
	void RemoveChildActorByName(std::string inName);
	EditorActor& GetChildActorByName(std::string inName);	
	RotateBoneAnimationComponent& CreateRotateBoneAnimationComponent(std::string inName);
	EditorActorComponent& GetComponent(std::string inName);
	void RemoveComponent(EditorActorComponent& inTarget);
	void DestroyComponent(EditorActorComponent& inTarget);
	void RemoveComponentByName(std::string inName);
	void DestroyComponentByName(std::string inName);
	//void SetWorld(EditorWorld& inParent);
	
};

