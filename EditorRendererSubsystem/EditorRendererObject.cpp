#include "pch.h"
#include "EditorRendererObject.h"
#include "EditorWorld.h"

void EditorRendererObject::SetName(std::string inName)
{
	Name = inName;
}

std::string EditorRendererObject::GetName()
{
	return Name;
}

void EditorRendererObject::SetWorldPosition(float x, float y, float z)
{
	if (Transform)
	{
		Transform->_setDerivedPosition(Ogre::Vector3(x, y, z));
	}
}

float EditorRendererObject::GetWorldPositionX()
{
	if (Transform)
	{
		return Transform->convertLocalToWorldPosition(Transform->getPosition()).x;
	}
	return 0.0f;
}

float EditorRendererObject::GetWorldPositionY()
{
	if (Transform)
	{
		return Transform->convertLocalToWorldPosition(Transform->getPosition()).y;
	}
	return 0.0f;
}

float EditorRendererObject::GetWorldPositionZ()
{
	if (Transform)
	{
		return Transform->convertLocalToWorldPosition(Transform->getPosition()).z;
	}
	return 0.0f;
}

void EditorRendererObject::SetRelativePosition(float x, float y, float z)
{
	if (Transform)
	{
		Transform->setPosition(Ogre::Vector3(x, y, z));
	}
}

float EditorRendererObject::GetRelativePositionX()
{
	if (Transform)
	{
		return Transform->getPosition().x;
	}
	return 0.0f;
}

float EditorRendererObject::GetRelativePositionY()
{
	if (Transform)
	{
		return Transform->getPosition().y;
	}
	return 0.0f;
}

float EditorRendererObject::GetRelativePositionZ()
{
	if (Transform)
	{
		return Transform->getPosition().z;
	}
	return 0.0f;
}

void EditorRendererObject::SetWorldRotation(float yaw, float pitch, float roll)
{
	if (Transform)
	{
		Transform->resetOrientation();
		Transform->yaw(Ogre::Radian(Ogre::Degree(yaw)), Ogre::Node::TransformSpace::TS_WORLD);
		Transform->pitch(Ogre::Radian(Ogre::Degree(pitch)), Ogre::Node::TransformSpace::TS_WORLD);
		Transform->roll(Ogre::Radian(Ogre::Degree(roll)), Ogre::Node::TransformSpace::TS_WORLD);
	}
}

float EditorRendererObject::GetWorldRotationYaw()
{
	if (Transform)
	{
		return Transform->convertLocalToWorldOrientation(Transform->getOrientation()).getYaw().valueDegrees();
	}
	return 0.0f;
}

float EditorRendererObject::GetWorldRotationPitch()
{
	if (Transform)
	{
		return Transform->convertLocalToWorldOrientation(Transform->getOrientation()).getPitch().valueDegrees();
	}
	return 0.0f;
}

float EditorRendererObject::GetWorldRotationRoll()
{
	if (Transform)
	{
		return Transform->convertLocalToWorldOrientation(Transform->getOrientation()).getRoll().valueDegrees();
	}
	return 0.0f;
}

void EditorRendererObject::SetRelativeRotation(float yaw, float pitch, float roll)
{
	if (Transform)
	{
		Transform->resetOrientation();
		Transform->yaw(Ogre::Radian(Ogre::Degree(yaw)), Ogre::Node::TransformSpace::TS_LOCAL);
		Transform->pitch(Ogre::Radian(Ogre::Degree(pitch)), Ogre::Node::TransformSpace::TS_LOCAL);
		Transform->roll(Ogre::Radian(Ogre::Degree(roll)), Ogre::Node::TransformSpace::TS_LOCAL);
	}
}

float EditorRendererObject::GetRelativeRotationYaw()
{
	if (Transform)
	{
		return Transform->getOrientation().getYaw().valueDegrees();
	}
	return 0.0f;
}

float EditorRendererObject::GetRelativeRotationPitch()
{
	if (Transform)
	{
		return Transform->getOrientation().getPitch().valueDegrees();
	}
	return 0.0f;
}

float EditorRendererObject::GetRelativeRotationRoll()
{
	if (Transform)
	{
		return Transform->getOrientation().getRoll().valueDegrees();
	}
	return 0.0f;
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
	if ((World) && (Transform))
	{
		World->GetSceneManager()->destroySceneNode(Transform);
	}
	Transform = nullptr;
}
