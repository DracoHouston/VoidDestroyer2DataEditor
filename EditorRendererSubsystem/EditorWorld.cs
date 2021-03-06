//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 4.0.0
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class EditorWorld : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal EditorWorld(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(EditorWorld obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~EditorWorld() {
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
          EditorRendererPINVOKE.delete_EditorWorld(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public EditorActor CreateActor(string inName) {
    EditorActor ret = new EditorActor(EditorRendererPINVOKE.EditorWorld_CreateActor(swigCPtr, inName), false);
    if (EditorRendererPINVOKE.SWIGPendingException.Pending) throw EditorRendererPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void Init() {
    EditorRendererPINVOKE.EditorWorld_Init(swigCPtr);
  }

  public void Destroy() {
    EditorRendererPINVOKE.EditorWorld_Destroy(swigCPtr);
  }

  public EditorWorld() : this(EditorRendererPINVOKE.new_EditorWorld(), true) {
  }

}
