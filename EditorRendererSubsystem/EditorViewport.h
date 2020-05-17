#pragma once
#include "Ogre.h"
#include "OgreCameraMan.h"
#include <string>

class EditorWorld;

class EditorViewport
{
	Ogre::RenderWindow* OgreWindow;
	EditorWorld* World;
	Ogre::SceneNode* OgreCameraTransform;
	Ogre::Camera* OgreCamera;
	OgreBites::CameraMan* OgreCameraMan;
	float CamDistance;
	float CamYaw;
	float CamPitch;
public:
	bool Create(std::string inName, std::string inHandle);
	void Destroy();
	void SetWorld(EditorWorld& inWorld);
	void WindowMovedOrResized();
	EditorWorld& GetWorld();
	EditorWorld& CreateWorld(bool inSetActive);
	void SetCameraYawPitchDistance(float inYaw, float inPitch, float inDistance);
	void SetCameraDistance(float inDistance);
	void SetCameraYaw(float inYaw);
	void SetCameraPitch(float inPitch);
};

