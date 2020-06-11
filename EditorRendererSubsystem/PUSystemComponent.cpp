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
				ResetSystem(true);
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
	if (PUSystem)
	{
		ParticleUniverse::ParticleSystemManager::getSingletonPtr()->destroyParticleSystem(PUSystem, Transform->getCreator());
	}
	PUSystem = ParticleUniverse::ParticleSystemManager::getSingletonPtr()->createParticleSystem(Name + inName, inName, Transform->getCreator());
	PUSystemName = inName;
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

void PUSystemComponent::ResetSystem(bool inAutoPlay)
{
	ParticleUniverse::ParticleSystemManager::getSingletonPtr()->destroyParticleSystem(PUSystem, Transform->getCreator());
	PUSystem = ParticleUniverse::ParticleSystemManager::getSingletonPtr()->createParticleSystem(Name + PUSystemName, PUSystemName, Transform->getCreator());
	Transform->attachObject(PUSystem);
	if (inAutoPlay)
	{
		PlaySystem();
	}
}

std::string PUSystemComponent::GetPUSystemName()
{
	return PUSystemName;
}
