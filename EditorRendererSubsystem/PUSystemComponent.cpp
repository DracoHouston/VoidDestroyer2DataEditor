#include "pch.h"
#include "PUSystemComponent.h"

void PUSystemComponent::Update(float DeltaTime, float TotalTime)
{
	if (PUSystem)
	{
		if (ForcedLooping)
		{
			if (PUSystem->getState() == ParticleUniverse::ParticleSystem::ParticleSystemState::PSS_STOPPED)
			{
				PUSystem->start();
			}
		}
	}
}

void PUSystemComponent::Destroy()
{
	ParticleUniverse::ParticleSystemManager::getSingletonPtr()->destroyParticleSystem(PUSystem, Transform->getCreator());
	EditorActorComponent::Destroy();
}

void PUSystemComponent::SetSystemByTemplate(std::string inName)
{
	PUSystem = ParticleUniverse::ParticleSystemManager::getSingletonPtr()->createParticleSystem(Name + inName, inName, Transform->getCreator());
	Transform->attachObject(PUSystem);
}

void PUSystemComponent::SetForcedLooping(bool inLooping)
{
	ForcedLooping = inLooping;
}

void PUSystemComponent::PlaySystem()
{
	PUSystem->start();
}

void PUSystemComponent::StopSystem()
{
	PUSystem->stop();
}

void PUSystemComponent::SetName(std::string inName)
{
	Name = inName;
}
