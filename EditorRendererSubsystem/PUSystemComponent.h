#pragma once
#include <string>
#include "Ogre.h"
#include "EditorActorComponent.h"
#include "ParticleUniverseSystemManager.h"

class PUSystemComponent : public EditorActorComponent
{
	std::string PUSystemName;
	ParticleUniverse::ParticleSystem* PUSystem;
	std::string Name;
	bool ForcedLooping;
public:
	virtual void Update(float DeltaTime, float TotalTime);
	virtual void Destroy();
	void SetSystemByTemplate(std::string inName);
	void SetForcedLooping(bool inLooping);
	void PlaySystem();
	void StopSystem();
	void SetName(std::string inName);
};

