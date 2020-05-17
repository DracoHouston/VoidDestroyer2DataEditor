#include "pch.h"
#include "EditorActorComponent.h"
#include "EditorActor.h"

void EditorActorComponent::Update(float DeltaTime, float TotalTime)
{
}

void EditorActorComponent::Destroy()
{
	if (Parent)
	{
		EditorActor* actorparent = (EditorActor*)Parent;
		if (actorparent)
		{
			actorparent->RemoveComponent(*this);
		}
	}
	EditorRendererObject::Destroy();
}
