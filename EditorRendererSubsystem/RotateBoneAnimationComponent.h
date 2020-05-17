#pragma once
#include <string>
#include "EditorActorComponent.h"

enum RotateBoneAnimationAxis
{
	None,
	Yaw,
	Pitch,
	Roll
};

class RotateBoneAnimationComponent : public EditorActorComponent
{
	std::string BoneName;
	float Speed;
	RotateBoneAnimationAxis Axis;
	bool IsAnimating;
public:
	virtual void Update(float DeltaTime, float TotalTime);
	virtual void Destroy();
	void StartAnimation(std::string inBoneName, float inSpeed, RotateBoneAnimationAxis inAxis);
	void PauseAnimation();
	void ResumeAnimation();
	void StopAnimation();	
};

