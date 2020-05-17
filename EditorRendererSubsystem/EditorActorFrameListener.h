#pragma once
#include "Ogre.h"

class EditorActor;

class EditorActorFrameListener : public Ogre::FrameListener
{
public:
	virtual bool frameStarted(const Ogre::FrameEvent& evt);
	virtual bool frameRenderingQueued(const Ogre::FrameEvent& evt);
	virtual bool frameEnded(const Ogre::FrameEvent& evt);
	EditorActor* ParentActor;
	float TotalTime;
};

