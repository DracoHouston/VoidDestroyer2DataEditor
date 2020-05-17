#include "pch.h"
#include "EditorWorld.h"
#include "EditorViewport.h"
#include "EditorActor.h"

EditorActor& EditorWorld::CreateActor(std::string inName)
{
	EditorActor* result = new EditorActor();
	result->SetWorld(*this);
	Ogre::SceneNode* actortransform = OgreScene->getRootSceneNode()->createChildSceneNode();
	result->SetTransform(actortransform);
	result->RegisterForUpdate();
	return *result;
}

void EditorWorld::Init()
{
	OgreScene = Ogre::Root::getSingletonPtr()->createSceneManager();
	OgreScene->setAmbientLight(Ogre::ColourValue(.6f, .6f, .6f));

	Ogre::Light* light = OgreScene->createLight("MainLight");
	Ogre::SceneNode* lightnode = OgreScene->getRootSceneNode()->createChildSceneNode();
	lightnode->setPosition(0, 10, 15);
	lightnode->attachObject(light);
}

void EditorWorld::Destroy()
{
	OgreScene->destroyAllLights();
	OgreScene->destroyAllEntities();
	OgreScene->clearScene();
	Ogre::Root::getSingletonPtr()->destroySceneManager(OgreScene);
	OgreScene = nullptr;
}

Ogre::SceneManager* EditorWorld::GetSceneManager()
{
	return OgreScene;
}
