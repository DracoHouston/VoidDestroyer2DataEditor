#include "pch.h"
#include "EditorRendererSubsystem.h"
#include <iostream>
#include "EditorViewport.h"
#include "ParticleUniverseSystemManager.h"

void EditorRendererSubsystem::Init(std::string inVD2Path)
{
    LogFile.open("EditorRendererSubsystem.log");
    PrintLogLine("Setting Path!");
	VD2Path = inVD2Path;    
    PrintLogLine("initing root!");
    OgreRoot = new Ogre::Root();
    PrintLogLine("Adding resource locations!");
    
	Ogre::ResourceGroupManager* rgm = Ogre::ResourceGroupManager::getSingletonPtr();
    LoadListener = new EditorResourceLoadingListener();
    rgm->setLoadingListener(LoadListener);
	if (rgm)
	{
        PrintLogLine(VD2Path + "Media\\packs\\SdkTrays.zip");
        rgm->addResourceLocation(VD2Path + "media/packs/SdkTrays.zip", "Zip", "Essential");
        PrintLogLine(VD2Path + "Mod\\Media\\materials\\scripts");
        rgm->addResourceLocation(VD2Path + "Mod/Media/materials/scripts", "FileSystem", "General");
        PrintLogLine(VD2Path + "Mod\\Media\\materials\\programs");
        rgm->addResourceLocation(VD2Path + "Mod/Media/materials/programs", "FileSystem", "General");
        PrintLogLine(VD2Path + "Media\\materials\\scripts");
        rgm->addResourceLocation(VD2Path + "Media/materials/scripts", "FileSystem", "General");
        PrintLogLine(VD2Path + "Media\\materials\\programs");
        rgm->addResourceLocation(VD2Path + "Media/materials/programs", "FileSystem", "General");
        PrintLogLine(VD2Path + "Mod\\Media");
        rgm->addResourceLocation(VD2Path + "Mod/media", "FileSystem", "General");
        PrintLogLine(VD2Path + "Mod\\Media\\gui");
        rgm->addResourceLocation(VD2Path + "Mod/media/gui", "FileSystem", "General");
        PrintLogLine(VD2Path + "Mod\\Media\\materials\\textures");
        rgm->addResourceLocation(VD2Path + "Mod/media/materials/textures", "FileSystem", "General");
        PrintLogLine(VD2Path + "Mod\\Media\\materials\\textures\\backgrounds");
        rgm->addResourceLocation(VD2Path + "Mod/media/materials/textures/backgrounds", "FileSystem", "General");
        PrintLogLine(VD2Path + "Mod\\Media\\materials\\textures\\effects");
        rgm->addResourceLocation(VD2Path + "Mod/media/materials/textures/effects", "FileSystem", "General");
        PrintLogLine(VD2Path + "Mod\\Media\\materials\\textures\\hud");
        rgm->addResourceLocation(VD2Path + "Mod/media/materials/textures/hud", "FileSystem", "General");
        PrintLogLine(VD2Path + "Mod\\Media\\materials\\textures\\hud\\CBA");
        rgm->addResourceLocation(VD2Path + "Mod/media/materials/textures/hud/CBA", "FileSystem", "General");
        PrintLogLine(VD2Path + "Mod\\Media\\materials\\textures\\wireframes");
        rgm->addResourceLocation(VD2Path + "Mod/media/materials/textures/wireframes", "FileSystem", "General");
        PrintLogLine(VD2Path + "Mod\\Media\\materials\\textures\\shipclasses");
        rgm->addResourceLocation(VD2Path + "Mod/media/materials/textures/shipclasses", "FileSystem", "General");
        
        PrintLogLine(VD2Path + "Media");
        rgm->addResourceLocation(VD2Path + "media", "FileSystem", "General");
        PrintLogLine(VD2Path + "Media\\gui");
        rgm->addResourceLocation(VD2Path + "media/gui", "FileSystem", "General");
        PrintLogLine(VD2Path + "Media\\materials\\textures");
        rgm->addResourceLocation(VD2Path + "media/materials/textures", "FileSystem", "General");
        PrintLogLine(VD2Path + "Media\\materials\\textures\\backgrounds");
        rgm->addResourceLocation(VD2Path + "media/materials/textures/backgrounds", "FileSystem", "General");
        PrintLogLine(VD2Path + "Media\\materials\\textures\\effects");
        rgm->addResourceLocation(VD2Path + "media/materials/textures/effects", "FileSystem", "General");
        PrintLogLine(VD2Path + "Media\\materials\\textures\\hud");
        rgm->addResourceLocation(VD2Path + "media/materials/textures/hud", "FileSystem", "General");
        PrintLogLine(VD2Path + "Media\\materials\\textures\\hud\\CBA");
        rgm->addResourceLocation(VD2Path + "media/materials/textures/hud/CBA", "FileSystem", "General");
        PrintLogLine(VD2Path + "Media\\materials\\textures\\wireframes");
        rgm->addResourceLocation(VD2Path + "media/materials/textures/wireframes", "FileSystem", "General");
        PrintLogLine(VD2Path + "Media\\materials\\textures\\shipclasses");
        rgm->addResourceLocation(VD2Path + "media/materials/textures/shipclasses", "FileSystem", "General");

        PrintLogLine(VD2Path + "Mod\\Media\\models");
        rgm->addResourceLocation(VD2Path + "Mod/media/models", "FileSystem", "General");
        PrintLogLine(VD2Path + "Mod\\Media\\models\\asteroids");
        rgm->addResourceLocation(VD2Path + "Mod/media/models/asteroids", "FileSystem", "General");
        PrintLogLine(VD2Path + "Mod\\Media\\models\\bases");
        rgm->addResourceLocation(VD2Path + "Mod/media/models/bases", "FileSystem", "General");
        PrintLogLine(VD2Path + "Mod\\Media\\models\\debris");
        rgm->addResourceLocation(VD2Path + "Mod/media/models/debris", "FileSystem", "General");
        PrintLogLine(VD2Path + "Mod\\Media\\models\\missiles");
        rgm->addResourceLocation(VD2Path + "Mod/media/models/missiles", "FileSystem", "General");
        PrintLogLine(VD2Path + "Mod\\Media\\models\\other");
        rgm->addResourceLocation(VD2Path + "Mod/media/models/other", "FileSystem", "General");
        PrintLogLine(VD2Path + "Mod\\Media\\models\\ships");
        rgm->addResourceLocation(VD2Path + "Mod/media/models/ships", "FileSystem", "General");
        PrintLogLine(VD2Path + "Mod\\Media\\models\\shields");
        rgm->addResourceLocation(VD2Path + "Mod/media/models/shields", "FileSystem", "General");
        PrintLogLine(VD2Path + "Mod\\Media\\models\\stations");
        rgm->addResourceLocation(VD2Path + "Mod/media/models/stations", "FileSystem", "General");
        PrintLogLine(VD2Path + "Mod\\Media\\models\\turrets");
        rgm->addResourceLocation(VD2Path + "Mod/media/models/turrets", "FileSystem", "General");
        PrintLogLine(VD2Path + "Mod\\Media\\models\\cockpits");
        rgm->addResourceLocation(VD2Path + "Mod/media/models/cockpits", "FileSystem", "General");
        PrintLogLine(VD2Path + "Mod\\Media\\models\\interiors");
        rgm->addResourceLocation(VD2Path + "Mod/media/models/interiors", "FileSystem", "General");
        PrintLogLine(VD2Path + "Mod\\Media\\models\\overworld");
        rgm->addResourceLocation(VD2Path + "Mod/media/models/overworld", "FileSystem", "General");        
        
        PrintLogLine(VD2Path + "Media\\models");
        rgm->addResourceLocation(VD2Path + "media/models", "FileSystem", "General");
        PrintLogLine(VD2Path + "Media\\models\\asteroids");
        rgm->addResourceLocation(VD2Path + "media/models/asteroids", "FileSystem", "General");
        PrintLogLine(VD2Path + "Media\\models\\bases");
        rgm->addResourceLocation(VD2Path + "media/models/bases", "FileSystem", "General");
        PrintLogLine(VD2Path + "Media\\models\\debris");
        rgm->addResourceLocation(VD2Path + "media/models/debris", "FileSystem", "General");
        PrintLogLine(VD2Path + "Media\\models\\missiles");
        rgm->addResourceLocation(VD2Path + "media/models/missiles", "FileSystem", "General");
        PrintLogLine(VD2Path + "Media\\models\\other");
        rgm->addResourceLocation(VD2Path + "media/models/other", "FileSystem", "General");
        PrintLogLine(VD2Path + "Media\\models\\ships");
        rgm->addResourceLocation(VD2Path + "media/models/ships", "FileSystem", "General");
        PrintLogLine(VD2Path + "Media\\models\\shields");
        rgm->addResourceLocation(VD2Path + "media/models/shields", "FileSystem", "General");
        PrintLogLine(VD2Path + "Media\\models\\stations");
        rgm->addResourceLocation(VD2Path + "media/models/stations", "FileSystem", "General");
        PrintLogLine(VD2Path + "Media\\models\\turrets");
        rgm->addResourceLocation(VD2Path + "media/models/turrets", "FileSystem", "General");
        PrintLogLine(VD2Path + "Media\\models\\cockpits");
        rgm->addResourceLocation(VD2Path + "media/models/cockpits", "FileSystem", "General");
        PrintLogLine(VD2Path + "Media\\models\\interiors");
        rgm->addResourceLocation(VD2Path + "media/models/interiors", "FileSystem", "General");
        PrintLogLine(VD2Path + "Media\\models\\overworld");
        rgm->addResourceLocation(VD2Path + "media/models/overworld", "FileSystem", "General");

        PrintLogLine(VD2Path + "Mod\\Media\\ParticleUniverse");
        rgm->addResourceLocation(VD2Path + "mod/media/ParticleUniverse", "FileSystem", "General");
        PrintLogLine(VD2Path + "Mod\\Media\\ParticleUniverse\\textures");
        rgm->addResourceLocation(VD2Path + "mod/media/ParticleUniverse/textures", "FileSystem", "General");

        PrintLogLine(VD2Path + "Media\\ParticleUniverse");
        rgm->addResourceLocation(VD2Path + "media/ParticleUniverse", "FileSystem", "General");
        PrintLogLine(VD2Path + "Media\\ParticleUniverse\\textures");
        rgm->addResourceLocation(VD2Path + "media/ParticleUniverse/textures", "FileSystem", "General");
        
        
        PrintLogLine("Getting D3D9!");
        Ogre::RenderSystem* rs = OgreRoot->getRenderSystemByName("Direct3D9 Rendering Subsystem");
        PrintLogLine("Setting!");
        OgreRoot->setRenderSystem(rs);
        rs->setConfigOption("Full Screen", "No");
        rs->setConfigOption("Video Mode", "800 x 600 @ 32-bit colour");
        PrintLogLine("Initializing Root!");
        OgreRoot->initialise(false, "Main Ogre Window");
        PrintLogLine("Did we make it? Good.");
        
        
	}
}

void EditorRendererSubsystem::Shutdown()
{
    if (OgreRoot)
    {
        OgreRoot->shutdown();
        OgreRoot = nullptr;
    }
}

EditorViewport& EditorRendererSubsystem::CreateEditorViewport(std::string inName, std::string inWindowHandle)
{
    EditorViewport* result = new EditorViewport();
    result->Create(inName, inWindowHandle);
    return *result;
}

bool EditorRendererSubsystem::IsActive()
{
    return (OgreRoot != nullptr);
}

bool EditorRendererSubsystem::Render()
{
    if (OgreRoot)
    {
        return OgreRoot->renderOneFrame();
    }
    return false;
}

void EditorRendererSubsystem::PrintLogLine(std::string inMessage)
{
    OutputDebugStringA(inMessage.c_str());
    OutputDebugStringA("\n");
    LogFile << inMessage << std::endl;
    LogFile.flush();
}

int EditorRendererSubsystem::GetPUTemplatesCount()
{
    if (PUTemplates.size() == 0)
    {
        ParticleUniverse::ParticleSystemManager::getSingletonPtr()->particleSystemTemplateNames(PUTemplates);
    }
    return PUTemplates.size();
}

std::string EditorRendererSubsystem::GetPUTemplatesAtIndex(int inIndex)
{
    if (PUTemplates.size() > inIndex)
    {
        return PUTemplates[inIndex];
    }
    return "";
}
