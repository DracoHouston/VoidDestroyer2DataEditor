#include "pch.h"
#include "RotateBoneAnimationComponent.h"
#include "EditorActor.h"

void RotateBoneAnimationComponent::Update(float DeltaTime, float TotalTime)
{
	if (IsAnimating)
	{
		if (Parent)
		{
			EditorActor* actorparent = (EditorActor*)Parent;
			if (actorparent)
			{
				if (actorparent->GetMesh()->hasSkeleton())
				{
					Ogre::SkeletonInstance* skele = actorparent->GetMesh()->getSkeleton();
					if (skele)
					{
						if (skele->hasBone(BoneName))
						{
							Ogre::Bone* bone = skele->getBone(BoneName);
							bone->setManuallyControlled(true);
							switch (Axis)
							{
							case RotateBoneAnimationAxis::Yaw:
								bone->yaw(Ogre::Radian(Ogre::Degree(Speed * DeltaTime)));
								break;
							case RotateBoneAnimationAxis::Pitch:
								bone->pitch(Ogre::Radian(Ogre::Degree(Speed * DeltaTime)));
								break;
							case RotateBoneAnimationAxis::Roll:
								bone->roll(Ogre::Radian(Ogre::Degree(Speed * DeltaTime)));
								break;
							}
						}
					}
				}
			}
		}
	}
}

void RotateBoneAnimationComponent::Destroy()
{
	StopAnimation();
	EditorActorComponent::Destroy();
}

void RotateBoneAnimationComponent::StartAnimation(std::string inBoneName, float inSpeed, RotateBoneAnimationAxis inAxis)
{
	BoneName = inBoneName;
	Speed = inSpeed;
	Axis = inAxis;
	IsAnimating = true;
}

void RotateBoneAnimationComponent::PauseAnimation()
{
	IsAnimating = false;
}

void RotateBoneAnimationComponent::ResumeAnimation()
{
	IsAnimating = true;
}

void RotateBoneAnimationComponent::StopAnimation()
{
	Axis = RotateBoneAnimationAxis::None;
	Speed = 0;
	BoneName = "";
	IsAnimating = false;
}
