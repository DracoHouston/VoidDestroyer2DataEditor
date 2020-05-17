#include "pch.h"
#include "EditorResourceLoadingListener.h"

Ogre::DataStreamPtr EditorResourceLoadingListener::resourceLoading(const Ogre::String& name, const Ogre::String& group, Ogre::Resource* resource)
{
	return Ogre::DataStreamPtr();
}

void EditorResourceLoadingListener::resourceStreamOpened(const Ogre::String& name, const Ogre::String& group, Ogre::Resource* resource, Ogre::DataStreamPtr& dataStream)
{
}

bool EditorResourceLoadingListener::resourceCollision(Ogre::Resource* resource, Ogre::ResourceManager* resourceManager)
{
	return false;
}
