#include "pch.h"
#include "EditorActorFrameListener.h"
#include "EditorActor.h"

bool EditorActorFrameListener::frameStarted(const Ogre::FrameEvent& evt)
{
	return true;
}

bool EditorActorFrameListener::frameRenderingQueued(const Ogre::FrameEvent& evt)
{
	return true;
}

bool EditorActorFrameListener::frameEnded(const Ogre::FrameEvent& evt)
{
	TotalTime += evt.timeSinceLastFrame;
	ParentActor->Update(evt.timeSinceLastFrame, TotalTime);
	return true;
}
