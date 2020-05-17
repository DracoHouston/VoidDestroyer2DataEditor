#include "pch.h"
#include "EditorViewport.h"
#include "EditorWorld.h"

bool EditorViewport::Create(std::string inName, std::string inHandle)
{
	Ogre::NameValuePairList misc = Ogre::NameValuePairList();
	misc["externalWindowHandle"] = inHandle;
	const std::string newname = std::string(inName + inHandle);
	OgreWindow = Ogre::Root::getSingletonPtr()->createRenderWindow(newname, 800, 600, false, &misc);

	Ogre::TextureManager::getSingletonPtr()->setDefaultNumMipmaps(5);
	//ResourceGroupManager.getSingleton().
	//ResourceGroupManager.getSingleton().setLoadingListener(new FileCollisionResolver());
	Ogre::ResourceGroupManager::getSingletonPtr()->initialiseAllResourceGroups();
	return false;
}

void EditorViewport::Destroy()
{
	Ogre::SceneManager* sm = OgreCameraTransform->getCreator();
	sm->destroyCamera(OgreCamera);
	OgreCamera = nullptr;
	sm->destroySceneNode(OgreCameraTransform);
	OgreCameraTransform = nullptr;
	OgreWindow->destroy();
	OgreWindow = nullptr;
}

void EditorViewport::SetWorld(EditorWorld& inWorld)
{
	World = &inWorld;
	if (World)
	{
		Ogre::SceneManager* sm = World->GetSceneManager();
		OgreCamera = sm->createCamera("myCam");
		OgreCamera->setAutoAspectRatio(true);
		OgreCamera->setNearClipDistance(5);
		OgreCameraTransform = sm->getRootSceneNode()->createChildSceneNode();
		OgreCameraTransform->attachObject(OgreCamera);

		OgreCameraMan = new OgreBites::CameraMan(OgreCameraTransform);
		OgreCameraMan->setStyle(OgreBites::CameraStyle::CS_ORBIT);
		CamDistance = 200;
		CamYaw = 0;
		CamPitch = 0.3f;
		OgreCameraMan->setYawPitchDist(Ogre::Radian(CamYaw), Ogre::Radian(CamPitch), CamDistance);
		Ogre::Viewport* vp = OgreWindow->addViewport(OgreCamera);
		vp->setBackgroundColour(Ogre::ColourValue(.3f, .3f, .3f));
		//Ogre::Root::getSingletonPtr()->renderOneFrame();
	}
	
}

void EditorViewport::WindowMovedOrResized()
{
	OgreWindow->windowMovedOrResized();
	//Ogre::Root::getSingletonPtr()->renderOneFrame();
}

EditorWorld& EditorViewport::GetWorld()
{
	return *World;
}

EditorWorld& EditorViewport::CreateWorld(bool inSetActive)
{
	EditorWorld* result = new EditorWorld();
	result->Init();
	if (inSetActive)
	{
		SetWorld(*result);
	}	
	return *result;
}

void EditorViewport::SetCameraYawPitchDistance(float inYaw, float inPitch, float inDistance)
{
	CamDistance = inDistance;
	CamYaw = inYaw;
	CamPitch = inPitch;
	OgreCameraMan->setYawPitchDist(Ogre::Radian(CamYaw), Ogre::Radian(CamPitch), CamDistance);
}

void EditorViewport::SetCameraDistance(float inDistance)
{
	CamDistance = inDistance;
	OgreCameraMan->setYawPitchDist(Ogre::Radian(CamYaw), Ogre::Radian(CamPitch), CamDistance);
}

void EditorViewport::SetCameraYaw(float inYaw)
{
	CamYaw = inYaw;
	OgreCameraMan->setYawPitchDist(Ogre::Radian(CamYaw), Ogre::Radian(CamPitch), CamDistance);
}

void EditorViewport::SetCameraPitch(float inPitch)
{
	CamPitch = inPitch;
	OgreCameraMan->setYawPitchDist(Ogre::Radian(CamYaw), Ogre::Radian(CamPitch), CamDistance);
}
