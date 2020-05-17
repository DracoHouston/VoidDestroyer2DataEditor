#pragma once
#include "Ogre.h"

class EditorWorld;

class EditorRendererObject
{
protected:
	Ogre::SceneNode* Transform;
	EditorWorld* World;
	EditorRendererObject* Parent;
public:
	//bool Create(std::string inName);
	void SetWorldPosition(float x, float y, float z);
	float GetWorldPositionX();
	float GetWorldPositionY();
	float GetWorldPositionZ();
	void SetRelativePosition(float x, float y, float z);
	float GetRelativePositionX();
	float GetRelativePositionY();
	float GetRelativePositionZ();
	void SetWorldRotation(float yaw, float pitch, float roll);
	float GetWorldRotationYaw();
	float GetWorldRotationPitch();
	float GetWorldRotationRoll();
	void SetRelativeRotation(float yaw, float pitch, float roll);
	float GetRelativeRotationYaw();
	float GetRelativeRotationPitch();
	float GetRelativeRotationRoll();
	EditorWorld& GetWorld();
	void SetWorld(EditorWorld& inWorld);
	void SetTransform(Ogre::SceneNode* inTransform);
	void SetParent(EditorRendererObject& inParent);
	EditorRendererObject& GetParent();
	virtual float GetBoundingRadius();
	virtual void Destroy();
};

