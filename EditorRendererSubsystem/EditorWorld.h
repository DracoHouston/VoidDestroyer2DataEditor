#pragma once
#include <map>
#include <string>
#include "Ogre.h"

class EditorViewport;
class EditorActor;

class EditorWorld
{
	Ogre::SceneManager* OgreScene;
	std::map<std::string, EditorActor*> Actors;
public:
	EditorActor& CreateActor(std::string inName);
	void Init();
	void Destroy();
	Ogre::SceneManager* GetSceneManager();
};

