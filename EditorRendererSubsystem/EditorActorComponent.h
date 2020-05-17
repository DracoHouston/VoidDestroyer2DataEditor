#pragma once
#include "Ogre.h"
#include "EditorRendererObject.h"

class EditorActorComponent : public EditorRendererObject
{
	//Ogre::SceneNode* Transform;
	//EditorActor* ParentActor;
	//EditorWorld* ParentWorld;
public: 
	virtual void Update(float DeltaTime, float TotalTime);
	virtual void Destroy();
};

