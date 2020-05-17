#pragma once
#include "Ogre.h"

class EditorResourceLoadingListener : public Ogre::ResourceLoadingListener
{
public:
	virtual Ogre::DataStreamPtr resourceLoading(const Ogre::String& name, const Ogre::String& group, Ogre::Resource* resource);
	virtual void resourceStreamOpened(const Ogre::String& name, const Ogre::String& group, Ogre::Resource* resource, Ogre::DataStreamPtr& dataStream);
	virtual bool resourceCollision(Ogre::Resource* resource, Ogre::ResourceManager* resourceManager);
};

