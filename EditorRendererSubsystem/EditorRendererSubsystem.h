#pragma once
#include <string>
#include "Ogre.h"
#include "EditorResourceLoadingListener.h"

class EditorViewport;

class EditorRendererSubsystem
{
	Ogre::Root* OgreRoot;
	std::ofstream LogFile;
	EditorResourceLoadingListener* LoadListener;
public:	
	std::string VD2Path;
	void Init(std::string inVD2Path);
	void Shutdown();
	EditorViewport& CreateEditorViewport(std::string inName, std::string inWindowHandle);
	bool IsActive();
	bool Render();
	void PrintLogLine(std::string inMessage);
};

