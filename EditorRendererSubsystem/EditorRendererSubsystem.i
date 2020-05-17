%module EditorRenderer
%include "std_string.i"

%{
#include "EditorRendererSubsystem.h"
#include "EditorViewport.h"
#include "EditorWorld.h"
#include "EditorRendererObject.h"
#include "EditorActor.h"
#include "EditorActorComponent.h"
#include "RotateBoneAnimationComponent.h"
%}

/* Let's just grab the original header file here */
%ignore EditorRendererSubsystem::VD2Path;
%ignore EditorRendererSubsystem::PrintLogLine;
%include "EditorRendererSubsystem.h"
%include "EditorViewport.h"
%ignore EditorWorld::GetSceneManager;
%include "EditorWorld.h"
%ignore EditorRendererObject::SetTransform;
%include "EditorRendererObject.h"
%ignore EditorActor::GetMesh;
%include "EditorActor.h"
%include "EditorActorComponent.h"
%include "RotateBoneAnimationComponent.h"
