//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 4.0.0
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class EditorRendererSubsystem : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal EditorRendererSubsystem(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(EditorRendererSubsystem obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~EditorRendererSubsystem() {
    Dispose(false);
  }

  public void Dispose() {
    Dispose(true);
    global::System.GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing) {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          EditorRendererPINVOKE.delete_EditorRendererSubsystem(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public void Init(string inVD2Path) {
    EditorRendererPINVOKE.EditorRendererSubsystem_Init(swigCPtr, inVD2Path);
    if (EditorRendererPINVOKE.SWIGPendingException.Pending) throw EditorRendererPINVOKE.SWIGPendingException.Retrieve();
  }

  public void Shutdown() {
    EditorRendererPINVOKE.EditorRendererSubsystem_Shutdown(swigCPtr);
  }

  public EditorViewport CreateEditorViewport(string inName, string inWindowHandle) {
    EditorViewport ret = new EditorViewport(EditorRendererPINVOKE.EditorRendererSubsystem_CreateEditorViewport(swigCPtr, inName, inWindowHandle), false);
    if (EditorRendererPINVOKE.SWIGPendingException.Pending) throw EditorRendererPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool IsActive() {
    bool ret = EditorRendererPINVOKE.EditorRendererSubsystem_IsActive(swigCPtr);
    return ret;
  }

  public bool Render() {
    bool ret = EditorRendererPINVOKE.EditorRendererSubsystem_Render(swigCPtr);
    return ret;
  }

  public EditorRendererSubsystem() : this(EditorRendererPINVOKE.new_EditorRendererSubsystem(), true) {
  }

}