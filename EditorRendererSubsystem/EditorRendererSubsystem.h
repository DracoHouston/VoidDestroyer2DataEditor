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
	std::vector<std::string> PUTemplates;
public:	
	std::string VD2Path;
	void Init(std::string inVD2Path);
	void Shutdown();
	EditorViewport& CreateEditorViewport(std::string inName, std::string inWindowHandle);
	bool IsActive();
	bool Render();
	void PrintLogLine(std::string inMessage);
	int GetPUTemplatesCount();
	std::string GetPUTemplatesAtIndex(int inIndex);
};

