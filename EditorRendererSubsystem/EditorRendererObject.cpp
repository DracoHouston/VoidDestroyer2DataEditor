#include "pch.h"
#include "EditorRendererObject.h"
#include "EditorWorld.h"

void EditorRendererObject::SetWorldPosition(float x, float y, float z)
{
	Transform->_setDerivedPosition(Ogre::Vector3(x, y, z));
}

float EditorRendererObject::GetWorldPositionX()
{
	return Transform->convertLocalToWorldPosition(Transform->getPosition()).x;
}

float EditorRendererObject::GetWorldPositionY()
{
	return Transform->convertLocalToWorldPosition(Transform->getPosition()).y;
}

float EditorRendererObject::GetWorldPositionZ()
{
	return Transform->convertLocalToWorldPosition(Transform->getPosition()).z;
}

void EditorRendererObject::SetRelativePosition(float x, float y, float z)
{
	Transform->setPosition(Ogre::Vector3(x, y, z));
}

float EditorRendererObject::GetRelativePositionX()
{
	return Transform->getPosition().x;
}

float EditorRendererObject::GetRelativePositionY()
{
	return Transform->getPosition().y;
}

float EditorRendererObject::GetRelativePositionZ()
{
	return Transform->getPosition().z;
}

void EditorRendererObject::SetWorldRotation(float yaw, float pitch, float roll)
{
	Transform->resetOrientation();
	Transform->yaw(Ogre::Radian(Ogre::Degree(yaw)), Ogre::Node::TransformSpace::TS_WORLD);
	Transform->pitch(Ogre::Radian(Ogre::Degree(pitch)), Ogre::Node::TransformSpace::TS_WORLD);
	Transform->roll(Ogre::Radian(Ogre::Degree(roll)), Ogre::Node::TransformSpace::TS_WORLD);
	
}

float EditorRendererObject::GetWorldRotationYaw()
{
	return Transform->convertLocalToWorldOrientation(Transform->getOrientation()).getYaw().valueDegrees();
}

float EditorRendererObject::GetWorldRotationPitch()
{
	return Transform->convertLocalToWorldOrientation(Transform->getOrientation()).getPitch().valueDegrees();
}

float EditorRendererObject::GetWorldRotationRoll()
{
	return Transform->convertLocalToWorldOrientation(Transform->getOrientation()).getRoll().valueDegrees();
}

void EditorRendererObject::SetRelativeRotation(float yaw, float pitch, float roll)
{
	Transform->resetOrientation();
	Transform->yaw(Ogre::Radian(Ogre::Degree(yaw)), Ogre::Node::TransformSpace::TS_LOCAL);
	Transform->pitch(Ogre::Radian(Ogre::Degree(pitch)), Ogre::Node::TransformSpace::TS_LOCAL);
	Transform->roll(Ogre::Radian(Ogre::Degree(roll)), Ogre::Node::TransformSpace::TS_LOCAL);
}

float EditorRendererObject::GetRelativeRotationYaw()
{
	return Transform->getOrientation().getYaw().valueDegrees();
}

float EditorRendererObject::GetRelativeRotationPitch()
{
	return Transform->getOrientation().getPitch().valueDegrees();
}

float EditorRendererObject::GetRelativeRotationRoll()
{
	return Transform->getOrientation().getRoll().valueDegrees();
}

EditorWorld& EditorRendererObject::GetWorld()
{
	return *World;
}

void EditorRendererObject::SetWorld(EditorWorld& inWorld)
{
	World = &inWorld;
}

void EditorRendererObject::SetTransform(Ogre::SceneNode* inTransform)
{
	Transform = inTransform;
}

void EditorRendererObject::SetParent(EditorRendererObject& inParent)
{
	Parent = &inParent;
}

EditorRendererObject& EditorRendererObject::GetParent()
{
	return *Parent;
}

float EditorRendererObject::GetBoundingRadius()
{
	return 0.0f;
}

void EditorRendererObject::Destroy()
{
	World->GetSceneManager()->destroySceneNode(Transform);
	Transform = nullptr;
}
