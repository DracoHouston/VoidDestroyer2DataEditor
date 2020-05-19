#include "pch.h"
#include "EditorActor.h"
#include "EditorWorld.h"
#include "OgreMesh.h"
#include "EditorActorComponent.h"
#include "EditorActorFrameListener.h"
#include "RotateBoneAnimationComponent.h"
#include "PUSystemComponent.h"

void EditorActor::SetMesh(std::string inMeshName)
{
	Ogre::SceneManager* sm = Transform->getCreator();
	if (sm)
	{
		if (Mesh)
		{
			sm->destroyEntity(Mesh);
			Mesh = nullptr;
		}
		if (inMeshName != "")
		{
			Mesh = sm->createEntity(inMeshName);
			Transform->attachObject(Mesh);
		}
	}
	//Mesh->de
}

std::string EditorActor::GetMeshName()
{
	if (Mesh)
	{
		Ogre::MeshPtr ret = Mesh->getMesh();
		if (ret)
		{
			return ret->getName();
		}
	}
	return "";
}

Ogre::Entity* EditorActor::GetMesh()
{
	return Mesh;
}

float EditorActor::GetBoundingRadius()
{
	if (Mesh)
	{
		return Mesh->getBoundingRadius();
	}
	return 0.0f;
}

void EditorActor::Destroy()
{
	std::map<std::string, EditorActor*>::iterator it;

	for (it = Children.begin(); it != Children.end(); it++)
	{
		if (it->second)
		{
			it->second->Destroy();
		}
	}
	Children.clear();
	std::map<std::string, EditorActorComponent*>::iterator itcomp;

	for (itcomp = Components.begin(); itcomp != Components.end(); itcomp = Components.begin())
	{
		if (itcomp->second)
		{
			itcomp->second->Destroy();
		}
	}
	Components.clear();
	if (Parent)
	{
		EditorActor* actorparent = (EditorActor*)Parent;
		if (actorparent)
		{
			actorparent->RemoveChildActor(*this);
		}
	}
	if (Mesh)
	{
		World->GetSceneManager()->destroyEntity(Mesh);
		Mesh = nullptr;
	}
	if (FrameListener)
	{
		Ogre::Root::getSingletonPtr()->removeFrameListener(FrameListener);
		delete FrameListener;
		FrameListener = nullptr;
	}
	EditorRendererObject::Destroy();
}

void EditorActor::RegisterForUpdate()
{
	if (!FrameListener)
	{
		FrameListener = new EditorActorFrameListener();
		FrameListener->ParentActor = this;
		Ogre::Root::getSingletonPtr()->addFrameListener(FrameListener);
	}
}

void EditorActor::Update(float DeltaTime, float TotalTime)
{
	std::map<std::string, EditorActorComponent*>::iterator it;
	for (it = Components.begin(); it != Components.end(); it++)
	{
		if (it->second)
		{
			it->second->Update(DeltaTime, TotalTime);
		}
	}
}

EditorActor& EditorActor::CreateChildActor(std::string inName)
{
	if (Children.count(inName) > 0)
	{
		EditorActor* result = Children[inName];
		return *result;
	}
	EditorActor* result = new EditorActor();
	result->SetWorld(*World);
	Ogre::SceneNode* actortransform = Transform->createChildSceneNode();
	result->SetTransform(actortransform);
	result->RegisterForUpdate();
	result->Parent = this;
	Children[inName] = result;
	return *result;
}

void EditorActor::DestroyChildActor(EditorActor& inDestroyTarget)
{
	std::map<std::string, EditorActor*>::iterator it;

	for (it = Children.begin(); it != Children.end(); it++)
	{
		if (it->second)
		{
			if (it->second == &inDestroyTarget)
			{
				it->second->Destroy();
				return;
			}
		}
	}
}

void EditorActor::DestroyChildActorByName(std::string inName)
{
	if (Children.count(inName) > 0)
	{
		Children[inName]->Destroy();
	}
}

void EditorActor::RemoveChildActor(EditorActor& inDestroyTarget)
{
	std::map<std::string, EditorActor*>::iterator it;

	for (it = Children.begin(); it != Children.end(); it++)
	{
		if (it->second)
		{
			if (it->second == &inDestroyTarget)
			{
				Children.erase(it->first);
				return;
			}
		}
	}
}

void EditorActor::RemoveChildActorByName(std::string inName)
{
	if (Children.count(inName) > 0)
	{
		Children.erase(inName);
	}
}

EditorActor& EditorActor::GetChildActorByName(std::string inName)
{
	if (Children.count(inName) > 0)
	{
		return *Children[inName];
	}
	return *this;
}

RotateBoneAnimationComponent& EditorActor::CreateRotateBoneAnimationComponent(std::string inName)
{	
	if (Components.count(inName) > 0)
	{
		RotateBoneAnimationComponent* result = (RotateBoneAnimationComponent*)Components[inName];
		return *result;
	}
	RotateBoneAnimationComponent* result = new RotateBoneAnimationComponent();
	result->SetWorld(*World);
	result->SetParent(*this);
	Ogre::SceneNode* actortransform = Transform->createChildSceneNode();
	result->SetTransform(actortransform);
	Components[inName] = result;
	return *result;
}

PUSystemComponent& EditorActor::CreatePUSystemComponent(std::string inName, std::string inTemplate, bool inForcedLooping)
{
	if (Components.count(inName) > 0)
	{
		PUSystemComponent* result = (PUSystemComponent*)Components[inName];
		return *result;
	}
	PUSystemComponent* result = new PUSystemComponent();
	result->SetWorld(*World);
	result->SetParent(*this);
	Ogre::SceneNode* actortransform = Transform->createChildSceneNode();
	result->SetTransform(actortransform);
	result->SetName(inName);
	result->SetSystemByTemplate(inTemplate);
	result->SetForcedLooping(inForcedLooping);
	
	Components[inName] = result;
	return *result;
}

EditorActorComponent& EditorActor::GetComponent(std::string inName)
{
	if (Components.count(inName) > 0)
	{
		EditorActorComponent* result = Components[inName];
		return *result;
	}
	EditorActorComponent* result = nullptr;
	return *result;
}

void EditorActor::RemoveComponent(EditorActorComponent& inTarget)
{
	std::map<std::string, EditorActorComponent*>::iterator it;
	for (it = Components.begin(); it != Components.end(); it++)
	{
		if (it->second == &inTarget)
		{
			Components.erase(it->first);
			return;
		}
	}
}

void EditorActor::DestroyComponent(EditorActorComponent& inTarget)
{
	std::map<std::string, EditorActorComponent*>::iterator it;
	for (it = Components.begin(); it != Components.end(); it++)
	{
		if (it->second == &inTarget)
		{
			it->second->Destroy();			
		}
	}
}

void EditorActor::RemoveComponentByName(std::string inName)
{
	if (Components.count(inName) > 0)
	{
		Components.erase(inName);
	}
}

void EditorActor::DestroyComponentByName(std::string inName)
{
	if (Components.count(inName) > 0)
	{
		Components[inName]->Destroy();
	}
}
