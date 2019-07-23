#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <cstring>
#include <string.h>
#include <stdio.h>
#include <cmath>
#include <limits>
#include <assert.h>
#include <stdint.h>

#include "il2cpp-class-internals.h"
#include "codegen/il2cpp-codegen.h"
#include "il2cpp-object-internals.h"

struct VirtActionInvoker0
{
	typedef void (*Action)(void*, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename R>
struct VirtFuncInvoker0
{
	typedef R (*Func)(void*, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename R, typename T1, typename T2>
struct VirtFuncInvoker2
{
	typedef R (*Func)(void*, T1, T2, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};
template <typename T1>
struct VirtActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename T1, typename T2>
struct VirtActionInvoker2
{
	typedef void (*Action)(void*, T1, T2, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};
template <typename T1>
struct GenericVirtActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_virtual_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename T1, typename T2>
struct GenericVirtActionInvoker2
{
	typedef void (*Action)(void*, T1, T2, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_virtual_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};
template <typename T1>
struct InterfaceActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename T1, typename T2>
struct InterfaceActionInvoker2
{
	typedef void (*Action)(void*, T1, T2, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};
template <typename T1>
struct GenericInterfaceActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_interface_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename T1, typename T2>
struct GenericInterfaceActionInvoker2
{
	typedef void (*Action)(void*, T1, T2, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_interface_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};

// Microsoft.Win32.SafeHandles.SafeWaitHandle
struct SafeWaitHandle_t51DB35FF382E636FF3B868D87816733894D46CF2;
// System.AsyncCallback
struct AsyncCallback_t3F3DA3BEDAEE81DD1D24125DF8EB30E85EE14DA4;
// System.Attribute
struct Attribute_tF048C13FB3C8CFCC53F82290E4A3F621089F9A74;
// System.Char[]
struct CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2;
// System.Collections.ArrayList
struct ArrayList_t4131E0C29C7E1B9BC9DFE37BEC41A5EB1481ADF4;
// System.Collections.Generic.Dictionary`2<System.String,System.Int32>
struct Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB;
// System.Collections.Generic.List`1<System.Object>
struct List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D;
// System.Collections.Generic.List`1<System.Transactions.IEnlistmentNotification>
struct List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5;
// System.Collections.Generic.List`1<System.Transactions.ISinglePhaseNotification>
struct List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84;
// System.Collections.IDictionary
struct IDictionary_t1BD5C1546718A374EA8122FBD6C6EE45331E8CE7;
// System.Delegate
struct Delegate_t;
// System.DelegateData
struct DelegateData_t1BF9F691B56DAE5F8C28C5E084FDE94F15F27BBE;
// System.Delegate[]
struct DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86;
// System.Diagnostics.StackTrace[]
struct StackTraceU5BU5D_t855F09649EA34DEE7C1B6F088E0538E3CCC3F196;
// System.EventArgs
struct EventArgs_t8E6CA180BE0E56674C6407011A94BAF7C757352E;
// System.Exception
struct Exception_t;
// System.IAsyncResult
struct IAsyncResult_t8E194308510B375B42432981AE5E7488C458D598;
// System.Int32[]
struct Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83;
// System.IntPtr[]
struct IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD;
// System.InvalidOperationException
struct InvalidOperationException_t0530E734D823F78310CAFAFA424CA5164D93A1F1;
// System.MonoTODOAttribute
struct MonoTODOAttribute_t3C9A5765E42675DA136240D678090D792AD2B26C;
// System.NotImplementedException
struct NotImplementedException_t8AD6EBE5FEDB0AEBECEE0961CF73C35B372EFFA4;
// System.Object[]
struct ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A;
// System.Reflection.MethodInfo
struct MethodInfo_t;
// System.Runtime.Serialization.IFormatterConverter
struct IFormatterConverter_tC3280D64D358F47EA4DAF1A65609BA0FC081888A;
// System.Runtime.Serialization.SafeSerializationManager
struct SafeSerializationManager_t4A754D86B0F784B18CBC36C073BA564BED109770;
// System.Runtime.Serialization.SerializationInfo
struct SerializationInfo_t1BB80E9C9DEA52DBF464487234B045E2930ADA26;
// System.Security.Cryptography.RandomNumberGenerator
struct RandomNumberGenerator_t12277F7F965BA79C54E4B3BFABD27A5FFB725EE2;
// System.String
struct String_t;
// System.String[]
struct StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E;
// System.SystemException
struct SystemException_t5380468142AA850BE4A341D7AF3EAB9C78746782;
// System.Threading.EventWaitHandle
struct EventWaitHandle_t7603BF1D3D30FE42DD07A450C8D09E2684DC4D98;
// System.Threading.ManualResetEvent
struct ManualResetEvent_tDFAF117B200ECA4CCF4FD09593F949A016D55408;
// System.Threading.WaitCallback
struct WaitCallback_t61C5F053CAC7A7FE923208EFA060693D7997B4EC;
// System.Threading.WaitHandle
struct WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6;
// System.TimeoutException
struct TimeoutException_t15A6E9A2A5819966712B5CFAF756BAEA40E3B1B7;
// System.Transactions.Enlistment
struct Enlistment_t9E19C9353D07B13F6DEA340C15D562EAE001CB2D;
// System.Transactions.IEnlistmentNotification
struct IEnlistmentNotification_t16012AAA61792A55BF729AB561D7BD113C0890D4;
// System.Transactions.IEnlistmentNotification[]
struct IEnlistmentNotificationU5BU5D_t1F91969CDC67BA5C39D98E8734F5A7E7FD4B81C7;
// System.Transactions.IPromotableSinglePhaseNotification
struct IPromotableSinglePhaseNotification_t4E3897767FACCC747B6D0AF2750B2D42B9729492;
// System.Transactions.ISinglePhaseNotification
struct ISinglePhaseNotification_t70B179E8BC10CE3B486A1834D28DCDCE21C095EF;
// System.Transactions.ISinglePhaseNotification[]
struct ISinglePhaseNotificationU5BU5D_t9981A85690F12A9311FABF91AC391345790FAB18;
// System.Transactions.PreparingEnlistment
struct PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496;
// System.Transactions.SinglePhaseEnlistment
struct SinglePhaseEnlistment_t29EFB2BAA0D8E39ABCAAE5061AF9D889DED528F6;
// System.Transactions.Transaction
struct Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10;
// System.Transactions.TransactionAbortedException
struct TransactionAbortedException_tDE489364A598740F9F9D7CCEE8EC7259318F386D;
// System.Transactions.TransactionCompletedEventHandler
struct TransactionCompletedEventHandler_t57EB4B1B2B3FE844563C580C04E6257A58CA5B6D;
// System.Transactions.TransactionEventArgs
struct TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6;
// System.Transactions.TransactionException
struct TransactionException_tC34049F157BD87E4259E78D5F78FFC6FA0774658;
// System.Transactions.TransactionInformation
struct TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7;
// System.Transactions.TransactionScope
struct TransactionScope_t92F03DF5872F107284A443999A34977F918A6613;
// System.Type
struct Type_t;
// System.Type[]
struct TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F;
// System.Void
struct Void_t22962CB4C05B1D89B55A6E1139F0E87A90987017;

extern RuntimeClass* ArrayList_t4131E0C29C7E1B9BC9DFE37BEC41A5EB1481ADF4_il2cpp_TypeInfo_var;
extern RuntimeClass* DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132_il2cpp_TypeInfo_var;
extern RuntimeClass* Enlistment_t9E19C9353D07B13F6DEA340C15D562EAE001CB2D_il2cpp_TypeInfo_var;
extern RuntimeClass* EventArgs_t8E6CA180BE0E56674C6407011A94BAF7C757352E_il2cpp_TypeInfo_var;
extern RuntimeClass* Exception_t_il2cpp_TypeInfo_var;
extern RuntimeClass* Guid_t_il2cpp_TypeInfo_var;
extern RuntimeClass* IEnlistmentNotification_t16012AAA61792A55BF729AB561D7BD113C0890D4_il2cpp_TypeInfo_var;
extern RuntimeClass* IPromotableSinglePhaseNotification_t4E3897767FACCC747B6D0AF2750B2D42B9729492_il2cpp_TypeInfo_var;
extern RuntimeClass* ISinglePhaseNotification_t70B179E8BC10CE3B486A1834D28DCDCE21C095EF_il2cpp_TypeInfo_var;
extern RuntimeClass* InvalidOperationException_t0530E734D823F78310CAFAFA424CA5164D93A1F1_il2cpp_TypeInfo_var;
extern RuntimeClass* List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5_il2cpp_TypeInfo_var;
extern RuntimeClass* List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84_il2cpp_TypeInfo_var;
extern RuntimeClass* ManualResetEvent_tDFAF117B200ECA4CCF4FD09593F949A016D55408_il2cpp_TypeInfo_var;
extern RuntimeClass* NotImplementedException_t8AD6EBE5FEDB0AEBECEE0961CF73C35B372EFFA4_il2cpp_TypeInfo_var;
extern RuntimeClass* PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496_il2cpp_TypeInfo_var;
extern RuntimeClass* SinglePhaseEnlistment_t29EFB2BAA0D8E39ABCAAE5061AF9D889DED528F6_il2cpp_TypeInfo_var;
extern RuntimeClass* TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4_il2cpp_TypeInfo_var;
extern RuntimeClass* TimeoutException_t15A6E9A2A5819966712B5CFAF756BAEA40E3B1B7_il2cpp_TypeInfo_var;
extern RuntimeClass* TransactionAbortedException_tDE489364A598740F9F9D7CCEE8EC7259318F386D_il2cpp_TypeInfo_var;
extern RuntimeClass* TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6_il2cpp_TypeInfo_var;
extern RuntimeClass* TransactionException_tC34049F157BD87E4259E78D5F78FFC6FA0774658_il2cpp_TypeInfo_var;
extern RuntimeClass* TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7_il2cpp_TypeInfo_var;
extern RuntimeClass* TransactionManager_t89B5F1C0446C7A1D72FEB287569D47BAB58BBB64_il2cpp_TypeInfo_var;
extern RuntimeClass* TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F_il2cpp_TypeInfo_var;
extern RuntimeClass* TransactionScope_t92F03DF5872F107284A443999A34977F918A6613_il2cpp_TypeInfo_var;
extern RuntimeClass* Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10_il2cpp_TypeInfo_var;
extern RuntimeClass* WaitCallback_t61C5F053CAC7A7FE923208EFA060693D7997B4EC_il2cpp_TypeInfo_var;
extern String_t* _stringLiteral2081D19189B95B31D55BEBC4C77E0563E3FE486A;
extern String_t* _stringLiteral21BCBD295EC54B5735EFCAEB008312714381BD7C;
extern String_t* _stringLiteral297C1D782653E80FF9D58E7D4BC5FB5543DBC48F;
extern String_t* _stringLiteral3938659212BDF8DEB0FBDB29D3877DF586ED993F;
extern String_t* _stringLiteral39C7C154BE39F5CB6C9E9F7C1EF849C0F3478BFA;
extern String_t* _stringLiteral49A7719DF4108BB552D6A5D1C1030CCA238E293F;
extern String_t* _stringLiteral5279B4EDF19727785FA9AE748460798E8DF3A412;
extern String_t* _stringLiteral5A78AFA7A723BDBE19F5FFDF3E7DD314FB030C6F;
extern String_t* _stringLiteralA26A5289691F94E51D2D1661F4E4AA77277610B4;
extern const RuntimeMethod* Enumerator_Dispose_m599293FC0F1D20C18A3217F0CA5B0E6075A40042_RuntimeMethod_var;
extern const RuntimeMethod* Enumerator_MoveNext_mE66C4E35D1F864ACAD8B530D38662885FA6E3BE8_RuntimeMethod_var;
extern const RuntimeMethod* Enumerator_get_Current_m758972DF00AE225BC0EE5ACCBFE67F0E7CE7F044_RuntimeMethod_var;
extern const RuntimeMethod* List_1_Add_m44D114DEFF088D3DCF2DC644EECD01C147953830_RuntimeMethod_var;
extern const RuntimeMethod* List_1_GetEnumerator_m5ED6E47986C9AF6F4D4F7CF4C9199A2D4D887913_RuntimeMethod_var;
extern const RuntimeMethod* List_1__ctor_m98B046142D9A7B5AA9759E1762DA2E78659197E8_RuntimeMethod_var;
extern const RuntimeMethod* List_1__ctor_mE34FEBC8BE6C0D7E894858B74958B62F10DD35B0_RuntimeMethod_var;
extern const RuntimeMethod* List_1_get_Count_mBA184835CF46C764C3557F94597B5D9E9EDA5EA1_RuntimeMethod_var;
extern const RuntimeMethod* List_1_get_Count_mEEC95EC94015469DDE9F88D5430C55EC5B943DA3_RuntimeMethod_var;
extern const RuntimeMethod* List_1_get_Item_m4921DD2F4764D52107D17497D257FC1D1A1C11DB_RuntimeMethod_var;
extern const RuntimeMethod* List_1_get_Item_m98BBC5DF4A64AADB6AF47A1A864CD53D23D9C5DE_RuntimeMethod_var;
extern const RuntimeMethod* TransactionScope_Dispose_mD59AC22CF6811FA85272C31E4DBE98C655571807_RuntimeMethod_var;
extern const RuntimeMethod* Transaction_CheckAborted_m1ECDF392DD73E73FD0BFB964393BDA176D6EE724_RuntimeMethod_var;
extern const RuntimeMethod* Transaction_CommitInternal_mBAF35E65DD83B90A5FEE1A2B5E927A4D0EA31754_RuntimeMethod_var;
extern const RuntimeMethod* Transaction_DoPreparePhase_mBDC0F165B339998CEB02855953DF8FB2A9D69F54_RuntimeMethod_var;
extern const RuntimeMethod* Transaction_EnsureIncompleteCurrentScope_m14043E8F8E23D22ADEA7C43977CE84556591A71C_RuntimeMethod_var;
extern const RuntimeMethod* Transaction_PrepareCallbackWrapper_m469877B0CC5286CBF830532CF52D620435C36024_RuntimeMethod_var;
extern const RuntimeMethod* Transaction_Rollback_mFC332C9E4B355D640C92C72D18452E6502FDA19B_RuntimeMethod_var;
extern const RuntimeMethod* Transaction_System_Runtime_Serialization_ISerializable_GetObjectData_m70E0AB7319A7701A899B80F16D6A482754CDD2CB_RuntimeMethod_var;
extern const uint32_t PreparingEnlistment_ForceRollback_m208CADBB1497EECE47DC5E7EDD1A6AAC0683993E_MetadataUsageId;
extern const uint32_t PreparingEnlistment_Prepared_mACADBBE0D89BAC36C08BDDDFD0A7013DFAFBDF7B_MetadataUsageId;
extern const uint32_t PreparingEnlistment__ctor_m7F5B840FEFA4D7434F7059A86E3D0FD89296C8AA_MetadataUsageId;
extern const uint32_t TransactionEventArgs__ctor_m6CE6078481C1D1D18D229A8DC56BC254E1573A0F_MetadataUsageId;
extern const uint32_t TransactionInformation__ctor_mAB9F12A2A4EB65E91503CCF9B2B9E303E38DCF45_MetadataUsageId;
extern const uint32_t TransactionManager__cctor_m0FA54029D54D84844F8CE868E7628F8BB321159A_MetadataUsageId;
extern const uint32_t TransactionManager_get_DefaultTimeout_m787C350D9D35FF5E68D4C02EB9003148180EA76B_MetadataUsageId;
extern const uint32_t TransactionOptions_Equals_mD61A2902A74D8512486CA4CB47BD453BE87C8CD6_MetadataUsageId;
extern const uint32_t TransactionOptions_op_Equality_m496545B47A671A5F4269611E2DCE57226A6EAFBF_MetadataUsageId;
extern const uint32_t TransactionScope_Dispose_mD59AC22CF6811FA85272C31E4DBE98C655571807_MetadataUsageId;
extern const uint32_t TransactionScope__cctor_m1E1B2A2CACEC45BC8AE2606E324AEE134C428B28_MetadataUsageId;
extern const uint32_t Transaction_CheckAborted_m1ECDF392DD73E73FD0BFB964393BDA176D6EE724_MetadataUsageId;
extern const uint32_t Transaction_CommitInternal_mBAF35E65DD83B90A5FEE1A2B5E927A4D0EA31754_MetadataUsageId;
extern const uint32_t Transaction_DoCommitPhase_m8105329BE1D5F1FA0D676E26F8B0695ED8B427F4_MetadataUsageId;
extern const uint32_t Transaction_DoCommit_m5BD1493F18973F18506F0D79A9F8D9F676310EAB_MetadataUsageId;
extern const uint32_t Transaction_DoPreparePhase_mBDC0F165B339998CEB02855953DF8FB2A9D69F54_MetadataUsageId;
extern const uint32_t Transaction_DoSingleCommit_m4A8637DBA68B7D883D045C018BBB1C20FF4FB67C_MetadataUsageId;
extern const uint32_t Transaction_DoSingleCommit_m6D603CDBD6C094779156C4092701056247D13C98_MetadataUsageId;
extern const uint32_t Transaction_EnlistVolatileInternal_m2665C0DE16FD54520FF635486D348D1792F1786A_MetadataUsageId;
extern const uint32_t Transaction_EnsureIncompleteCurrentScope_m14043E8F8E23D22ADEA7C43977CE84556591A71C_MetadataUsageId;
extern const uint32_t Transaction_Equals_mDED0B202830E07A0EEA4FCF885D97C8DD8DADA4B_MetadataUsageId;
extern const uint32_t Transaction_FireCompleted_mBD57957732D7FAFF0D7A83EA5823EC6B66A10986_MetadataUsageId;
extern const uint32_t Transaction_PrepareCallbackWrapper_m469877B0CC5286CBF830532CF52D620435C36024_MetadataUsageId;
extern const uint32_t Transaction_Rollback_mFC332C9E4B355D640C92C72D18452E6502FDA19B_MetadataUsageId;
extern const uint32_t Transaction_System_Runtime_Serialization_ISerializable_GetObjectData_m70E0AB7319A7701A899B80F16D6A482754CDD2CB_MetadataUsageId;
extern const uint32_t Transaction__ctor_mD3B0EE36CAFDB4E2D826040BDD8166787C3BD77C_MetadataUsageId;
extern const uint32_t Transaction_get_CurrentInternal_mD2ADB6241C7D4AD453E70854F9917DCB38F20424_MetadataUsageId;
extern const uint32_t Transaction_get_Durables_m88EA94C8F588D6154C0EA39F4B10AE78E36F0844_MetadataUsageId;
extern const uint32_t Transaction_get_Volatiles_mE34920A5BF129E05A21659CA6A5D4B847E7EA47F_MetadataUsageId;
extern const uint32_t Transaction_set_CurrentInternal_m1505D3EF6C939658083C98A79445D586477E99EF_MetadataUsageId;
struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;

struct DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86;


#ifndef U3CMODULEU3E_TFBBBB93E1E8B295D1092207AC59C01247D8454E1_H
#define U3CMODULEU3E_TFBBBB93E1E8B295D1092207AC59C01247D8454E1_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct  U3CModuleU3E_tFBBBB93E1E8B295D1092207AC59C01247D8454E1 
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // U3CMODULEU3E_TFBBBB93E1E8B295D1092207AC59C01247D8454E1_H
#ifndef RUNTIMEOBJECT_H
#define RUNTIMEOBJECT_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Object

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // RUNTIMEOBJECT_H
struct Il2CppArrayBounds;
#ifndef RUNTIMEARRAY_H
#define RUNTIMEARRAY_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Array

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // RUNTIMEARRAY_H
#ifndef ATTRIBUTE_TF048C13FB3C8CFCC53F82290E4A3F621089F9A74_H
#define ATTRIBUTE_TF048C13FB3C8CFCC53F82290E4A3F621089F9A74_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Attribute
struct  Attribute_tF048C13FB3C8CFCC53F82290E4A3F621089F9A74  : public RuntimeObject
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ATTRIBUTE_TF048C13FB3C8CFCC53F82290E4A3F621089F9A74_H
#ifndef ARRAYLIST_T4131E0C29C7E1B9BC9DFE37BEC41A5EB1481ADF4_H
#define ARRAYLIST_T4131E0C29C7E1B9BC9DFE37BEC41A5EB1481ADF4_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.ArrayList
struct  ArrayList_t4131E0C29C7E1B9BC9DFE37BEC41A5EB1481ADF4  : public RuntimeObject
{
public:
	// System.Object[] System.Collections.ArrayList::_items
	ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* ____items_0;
	// System.Int32 System.Collections.ArrayList::_size
	int32_t ____size_1;
	// System.Int32 System.Collections.ArrayList::_version
	int32_t ____version_2;
	// System.Object System.Collections.ArrayList::_syncRoot
	RuntimeObject * ____syncRoot_3;

public:
	inline static int32_t get_offset_of__items_0() { return static_cast<int32_t>(offsetof(ArrayList_t4131E0C29C7E1B9BC9DFE37BEC41A5EB1481ADF4, ____items_0)); }
	inline ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* get__items_0() const { return ____items_0; }
	inline ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A** get_address_of__items_0() { return &____items_0; }
	inline void set__items_0(ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* value)
	{
		____items_0 = value;
		Il2CppCodeGenWriteBarrier((&____items_0), value);
	}

	inline static int32_t get_offset_of__size_1() { return static_cast<int32_t>(offsetof(ArrayList_t4131E0C29C7E1B9BC9DFE37BEC41A5EB1481ADF4, ____size_1)); }
	inline int32_t get__size_1() const { return ____size_1; }
	inline int32_t* get_address_of__size_1() { return &____size_1; }
	inline void set__size_1(int32_t value)
	{
		____size_1 = value;
	}

	inline static int32_t get_offset_of__version_2() { return static_cast<int32_t>(offsetof(ArrayList_t4131E0C29C7E1B9BC9DFE37BEC41A5EB1481ADF4, ____version_2)); }
	inline int32_t get__version_2() const { return ____version_2; }
	inline int32_t* get_address_of__version_2() { return &____version_2; }
	inline void set__version_2(int32_t value)
	{
		____version_2 = value;
	}

	inline static int32_t get_offset_of__syncRoot_3() { return static_cast<int32_t>(offsetof(ArrayList_t4131E0C29C7E1B9BC9DFE37BEC41A5EB1481ADF4, ____syncRoot_3)); }
	inline RuntimeObject * get__syncRoot_3() const { return ____syncRoot_3; }
	inline RuntimeObject ** get_address_of__syncRoot_3() { return &____syncRoot_3; }
	inline void set__syncRoot_3(RuntimeObject * value)
	{
		____syncRoot_3 = value;
		Il2CppCodeGenWriteBarrier((&____syncRoot_3), value);
	}
};

struct ArrayList_t4131E0C29C7E1B9BC9DFE37BEC41A5EB1481ADF4_StaticFields
{
public:
	// System.Object[] System.Collections.ArrayList::emptyArray
	ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* ___emptyArray_4;

public:
	inline static int32_t get_offset_of_emptyArray_4() { return static_cast<int32_t>(offsetof(ArrayList_t4131E0C29C7E1B9BC9DFE37BEC41A5EB1481ADF4_StaticFields, ___emptyArray_4)); }
	inline ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* get_emptyArray_4() const { return ___emptyArray_4; }
	inline ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A** get_address_of_emptyArray_4() { return &___emptyArray_4; }
	inline void set_emptyArray_4(ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* value)
	{
		___emptyArray_4 = value;
		Il2CppCodeGenWriteBarrier((&___emptyArray_4), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARRAYLIST_T4131E0C29C7E1B9BC9DFE37BEC41A5EB1481ADF4_H
#ifndef LIST_1_T433E53268E62E3881110DA61A3B077FAA122E4A5_H
#define LIST_1_T433E53268E62E3881110DA61A3B077FAA122E4A5_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.List`1<System.Transactions.IEnlistmentNotification>
struct  List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	IEnlistmentNotificationU5BU5D_t1F91969CDC67BA5C39D98E8734F5A7E7FD4B81C7* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject * ____syncRoot_4;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5, ____items_1)); }
	inline IEnlistmentNotificationU5BU5D_t1F91969CDC67BA5C39D98E8734F5A7E7FD4B81C7* get__items_1() const { return ____items_1; }
	inline IEnlistmentNotificationU5BU5D_t1F91969CDC67BA5C39D98E8734F5A7E7FD4B81C7** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(IEnlistmentNotificationU5BU5D_t1F91969CDC67BA5C39D98E8734F5A7E7FD4B81C7* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((&____items_1), value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}

	inline static int32_t get_offset_of__syncRoot_4() { return static_cast<int32_t>(offsetof(List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5, ____syncRoot_4)); }
	inline RuntimeObject * get__syncRoot_4() const { return ____syncRoot_4; }
	inline RuntimeObject ** get_address_of__syncRoot_4() { return &____syncRoot_4; }
	inline void set__syncRoot_4(RuntimeObject * value)
	{
		____syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier((&____syncRoot_4), value);
	}
};

struct List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::_emptyArray
	IEnlistmentNotificationU5BU5D_t1F91969CDC67BA5C39D98E8734F5A7E7FD4B81C7* ____emptyArray_5;

public:
	inline static int32_t get_offset_of__emptyArray_5() { return static_cast<int32_t>(offsetof(List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5_StaticFields, ____emptyArray_5)); }
	inline IEnlistmentNotificationU5BU5D_t1F91969CDC67BA5C39D98E8734F5A7E7FD4B81C7* get__emptyArray_5() const { return ____emptyArray_5; }
	inline IEnlistmentNotificationU5BU5D_t1F91969CDC67BA5C39D98E8734F5A7E7FD4B81C7** get_address_of__emptyArray_5() { return &____emptyArray_5; }
	inline void set__emptyArray_5(IEnlistmentNotificationU5BU5D_t1F91969CDC67BA5C39D98E8734F5A7E7FD4B81C7* value)
	{
		____emptyArray_5 = value;
		Il2CppCodeGenWriteBarrier((&____emptyArray_5), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LIST_1_T433E53268E62E3881110DA61A3B077FAA122E4A5_H
#ifndef LIST_1_TD0B07938609DB3D411C851750ADD986B40B5EB84_H
#define LIST_1_TD0B07938609DB3D411C851750ADD986B40B5EB84_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.List`1<System.Transactions.ISinglePhaseNotification>
struct  List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	ISinglePhaseNotificationU5BU5D_t9981A85690F12A9311FABF91AC391345790FAB18* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject * ____syncRoot_4;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84, ____items_1)); }
	inline ISinglePhaseNotificationU5BU5D_t9981A85690F12A9311FABF91AC391345790FAB18* get__items_1() const { return ____items_1; }
	inline ISinglePhaseNotificationU5BU5D_t9981A85690F12A9311FABF91AC391345790FAB18** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(ISinglePhaseNotificationU5BU5D_t9981A85690F12A9311FABF91AC391345790FAB18* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((&____items_1), value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}

	inline static int32_t get_offset_of__syncRoot_4() { return static_cast<int32_t>(offsetof(List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84, ____syncRoot_4)); }
	inline RuntimeObject * get__syncRoot_4() const { return ____syncRoot_4; }
	inline RuntimeObject ** get_address_of__syncRoot_4() { return &____syncRoot_4; }
	inline void set__syncRoot_4(RuntimeObject * value)
	{
		____syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier((&____syncRoot_4), value);
	}
};

struct List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::_emptyArray
	ISinglePhaseNotificationU5BU5D_t9981A85690F12A9311FABF91AC391345790FAB18* ____emptyArray_5;

public:
	inline static int32_t get_offset_of__emptyArray_5() { return static_cast<int32_t>(offsetof(List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84_StaticFields, ____emptyArray_5)); }
	inline ISinglePhaseNotificationU5BU5D_t9981A85690F12A9311FABF91AC391345790FAB18* get__emptyArray_5() const { return ____emptyArray_5; }
	inline ISinglePhaseNotificationU5BU5D_t9981A85690F12A9311FABF91AC391345790FAB18** get_address_of__emptyArray_5() { return &____emptyArray_5; }
	inline void set__emptyArray_5(ISinglePhaseNotificationU5BU5D_t9981A85690F12A9311FABF91AC391345790FAB18* value)
	{
		____emptyArray_5 = value;
		Il2CppCodeGenWriteBarrier((&____emptyArray_5), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LIST_1_TD0B07938609DB3D411C851750ADD986B40B5EB84_H
#ifndef EVENTARGS_T8E6CA180BE0E56674C6407011A94BAF7C757352E_H
#define EVENTARGS_T8E6CA180BE0E56674C6407011A94BAF7C757352E_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.EventArgs
struct  EventArgs_t8E6CA180BE0E56674C6407011A94BAF7C757352E  : public RuntimeObject
{
public:

public:
};

struct EventArgs_t8E6CA180BE0E56674C6407011A94BAF7C757352E_StaticFields
{
public:
	// System.EventArgs System.EventArgs::Empty
	EventArgs_t8E6CA180BE0E56674C6407011A94BAF7C757352E * ___Empty_0;

public:
	inline static int32_t get_offset_of_Empty_0() { return static_cast<int32_t>(offsetof(EventArgs_t8E6CA180BE0E56674C6407011A94BAF7C757352E_StaticFields, ___Empty_0)); }
	inline EventArgs_t8E6CA180BE0E56674C6407011A94BAF7C757352E * get_Empty_0() const { return ___Empty_0; }
	inline EventArgs_t8E6CA180BE0E56674C6407011A94BAF7C757352E ** get_address_of_Empty_0() { return &___Empty_0; }
	inline void set_Empty_0(EventArgs_t8E6CA180BE0E56674C6407011A94BAF7C757352E * value)
	{
		___Empty_0 = value;
		Il2CppCodeGenWriteBarrier((&___Empty_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // EVENTARGS_T8E6CA180BE0E56674C6407011A94BAF7C757352E_H
#ifndef EXCEPTION_T_H
#define EXCEPTION_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Exception
struct  Exception_t  : public RuntimeObject
{
public:
	// System.String System.Exception::_className
	String_t* ____className_1;
	// System.String System.Exception::_message
	String_t* ____message_2;
	// System.Collections.IDictionary System.Exception::_data
	RuntimeObject* ____data_3;
	// System.Exception System.Exception::_innerException
	Exception_t * ____innerException_4;
	// System.String System.Exception::_helpURL
	String_t* ____helpURL_5;
	// System.Object System.Exception::_stackTrace
	RuntimeObject * ____stackTrace_6;
	// System.String System.Exception::_stackTraceString
	String_t* ____stackTraceString_7;
	// System.String System.Exception::_remoteStackTraceString
	String_t* ____remoteStackTraceString_8;
	// System.Int32 System.Exception::_remoteStackIndex
	int32_t ____remoteStackIndex_9;
	// System.Object System.Exception::_dynamicMethods
	RuntimeObject * ____dynamicMethods_10;
	// System.Int32 System.Exception::_HResult
	int32_t ____HResult_11;
	// System.String System.Exception::_source
	String_t* ____source_12;
	// System.Runtime.Serialization.SafeSerializationManager System.Exception::_safeSerializationManager
	SafeSerializationManager_t4A754D86B0F784B18CBC36C073BA564BED109770 * ____safeSerializationManager_13;
	// System.Diagnostics.StackTrace[] System.Exception::captured_traces
	StackTraceU5BU5D_t855F09649EA34DEE7C1B6F088E0538E3CCC3F196* ___captured_traces_14;
	// System.IntPtr[] System.Exception::native_trace_ips
	IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD* ___native_trace_ips_15;

public:
	inline static int32_t get_offset_of__className_1() { return static_cast<int32_t>(offsetof(Exception_t, ____className_1)); }
	inline String_t* get__className_1() const { return ____className_1; }
	inline String_t** get_address_of__className_1() { return &____className_1; }
	inline void set__className_1(String_t* value)
	{
		____className_1 = value;
		Il2CppCodeGenWriteBarrier((&____className_1), value);
	}

	inline static int32_t get_offset_of__message_2() { return static_cast<int32_t>(offsetof(Exception_t, ____message_2)); }
	inline String_t* get__message_2() const { return ____message_2; }
	inline String_t** get_address_of__message_2() { return &____message_2; }
	inline void set__message_2(String_t* value)
	{
		____message_2 = value;
		Il2CppCodeGenWriteBarrier((&____message_2), value);
	}

	inline static int32_t get_offset_of__data_3() { return static_cast<int32_t>(offsetof(Exception_t, ____data_3)); }
	inline RuntimeObject* get__data_3() const { return ____data_3; }
	inline RuntimeObject** get_address_of__data_3() { return &____data_3; }
	inline void set__data_3(RuntimeObject* value)
	{
		____data_3 = value;
		Il2CppCodeGenWriteBarrier((&____data_3), value);
	}

	inline static int32_t get_offset_of__innerException_4() { return static_cast<int32_t>(offsetof(Exception_t, ____innerException_4)); }
	inline Exception_t * get__innerException_4() const { return ____innerException_4; }
	inline Exception_t ** get_address_of__innerException_4() { return &____innerException_4; }
	inline void set__innerException_4(Exception_t * value)
	{
		____innerException_4 = value;
		Il2CppCodeGenWriteBarrier((&____innerException_4), value);
	}

	inline static int32_t get_offset_of__helpURL_5() { return static_cast<int32_t>(offsetof(Exception_t, ____helpURL_5)); }
	inline String_t* get__helpURL_5() const { return ____helpURL_5; }
	inline String_t** get_address_of__helpURL_5() { return &____helpURL_5; }
	inline void set__helpURL_5(String_t* value)
	{
		____helpURL_5 = value;
		Il2CppCodeGenWriteBarrier((&____helpURL_5), value);
	}

	inline static int32_t get_offset_of__stackTrace_6() { return static_cast<int32_t>(offsetof(Exception_t, ____stackTrace_6)); }
	inline RuntimeObject * get__stackTrace_6() const { return ____stackTrace_6; }
	inline RuntimeObject ** get_address_of__stackTrace_6() { return &____stackTrace_6; }
	inline void set__stackTrace_6(RuntimeObject * value)
	{
		____stackTrace_6 = value;
		Il2CppCodeGenWriteBarrier((&____stackTrace_6), value);
	}

	inline static int32_t get_offset_of__stackTraceString_7() { return static_cast<int32_t>(offsetof(Exception_t, ____stackTraceString_7)); }
	inline String_t* get__stackTraceString_7() const { return ____stackTraceString_7; }
	inline String_t** get_address_of__stackTraceString_7() { return &____stackTraceString_7; }
	inline void set__stackTraceString_7(String_t* value)
	{
		____stackTraceString_7 = value;
		Il2CppCodeGenWriteBarrier((&____stackTraceString_7), value);
	}

	inline static int32_t get_offset_of__remoteStackTraceString_8() { return static_cast<int32_t>(offsetof(Exception_t, ____remoteStackTraceString_8)); }
	inline String_t* get__remoteStackTraceString_8() const { return ____remoteStackTraceString_8; }
	inline String_t** get_address_of__remoteStackTraceString_8() { return &____remoteStackTraceString_8; }
	inline void set__remoteStackTraceString_8(String_t* value)
	{
		____remoteStackTraceString_8 = value;
		Il2CppCodeGenWriteBarrier((&____remoteStackTraceString_8), value);
	}

	inline static int32_t get_offset_of__remoteStackIndex_9() { return static_cast<int32_t>(offsetof(Exception_t, ____remoteStackIndex_9)); }
	inline int32_t get__remoteStackIndex_9() const { return ____remoteStackIndex_9; }
	inline int32_t* get_address_of__remoteStackIndex_9() { return &____remoteStackIndex_9; }
	inline void set__remoteStackIndex_9(int32_t value)
	{
		____remoteStackIndex_9 = value;
	}

	inline static int32_t get_offset_of__dynamicMethods_10() { return static_cast<int32_t>(offsetof(Exception_t, ____dynamicMethods_10)); }
	inline RuntimeObject * get__dynamicMethods_10() const { return ____dynamicMethods_10; }
	inline RuntimeObject ** get_address_of__dynamicMethods_10() { return &____dynamicMethods_10; }
	inline void set__dynamicMethods_10(RuntimeObject * value)
	{
		____dynamicMethods_10 = value;
		Il2CppCodeGenWriteBarrier((&____dynamicMethods_10), value);
	}

	inline static int32_t get_offset_of__HResult_11() { return static_cast<int32_t>(offsetof(Exception_t, ____HResult_11)); }
	inline int32_t get__HResult_11() const { return ____HResult_11; }
	inline int32_t* get_address_of__HResult_11() { return &____HResult_11; }
	inline void set__HResult_11(int32_t value)
	{
		____HResult_11 = value;
	}

	inline static int32_t get_offset_of__source_12() { return static_cast<int32_t>(offsetof(Exception_t, ____source_12)); }
	inline String_t* get__source_12() const { return ____source_12; }
	inline String_t** get_address_of__source_12() { return &____source_12; }
	inline void set__source_12(String_t* value)
	{
		____source_12 = value;
		Il2CppCodeGenWriteBarrier((&____source_12), value);
	}

	inline static int32_t get_offset_of__safeSerializationManager_13() { return static_cast<int32_t>(offsetof(Exception_t, ____safeSerializationManager_13)); }
	inline SafeSerializationManager_t4A754D86B0F784B18CBC36C073BA564BED109770 * get__safeSerializationManager_13() const { return ____safeSerializationManager_13; }
	inline SafeSerializationManager_t4A754D86B0F784B18CBC36C073BA564BED109770 ** get_address_of__safeSerializationManager_13() { return &____safeSerializationManager_13; }
	inline void set__safeSerializationManager_13(SafeSerializationManager_t4A754D86B0F784B18CBC36C073BA564BED109770 * value)
	{
		____safeSerializationManager_13 = value;
		Il2CppCodeGenWriteBarrier((&____safeSerializationManager_13), value);
	}

	inline static int32_t get_offset_of_captured_traces_14() { return static_cast<int32_t>(offsetof(Exception_t, ___captured_traces_14)); }
	inline StackTraceU5BU5D_t855F09649EA34DEE7C1B6F088E0538E3CCC3F196* get_captured_traces_14() const { return ___captured_traces_14; }
	inline StackTraceU5BU5D_t855F09649EA34DEE7C1B6F088E0538E3CCC3F196** get_address_of_captured_traces_14() { return &___captured_traces_14; }
	inline void set_captured_traces_14(StackTraceU5BU5D_t855F09649EA34DEE7C1B6F088E0538E3CCC3F196* value)
	{
		___captured_traces_14 = value;
		Il2CppCodeGenWriteBarrier((&___captured_traces_14), value);
	}

	inline static int32_t get_offset_of_native_trace_ips_15() { return static_cast<int32_t>(offsetof(Exception_t, ___native_trace_ips_15)); }
	inline IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD* get_native_trace_ips_15() const { return ___native_trace_ips_15; }
	inline IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD** get_address_of_native_trace_ips_15() { return &___native_trace_ips_15; }
	inline void set_native_trace_ips_15(IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD* value)
	{
		___native_trace_ips_15 = value;
		Il2CppCodeGenWriteBarrier((&___native_trace_ips_15), value);
	}
};

struct Exception_t_StaticFields
{
public:
	// System.Object System.Exception::s_EDILock
	RuntimeObject * ___s_EDILock_0;

public:
	inline static int32_t get_offset_of_s_EDILock_0() { return static_cast<int32_t>(offsetof(Exception_t_StaticFields, ___s_EDILock_0)); }
	inline RuntimeObject * get_s_EDILock_0() const { return ___s_EDILock_0; }
	inline RuntimeObject ** get_address_of_s_EDILock_0() { return &___s_EDILock_0; }
	inline void set_s_EDILock_0(RuntimeObject * value)
	{
		___s_EDILock_0 = value;
		Il2CppCodeGenWriteBarrier((&___s_EDILock_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.Exception
struct Exception_t_marshaled_pinvoke
{
	char* ____className_1;
	char* ____message_2;
	RuntimeObject* ____data_3;
	Exception_t_marshaled_pinvoke* ____innerException_4;
	char* ____helpURL_5;
	Il2CppIUnknown* ____stackTrace_6;
	char* ____stackTraceString_7;
	char* ____remoteStackTraceString_8;
	int32_t ____remoteStackIndex_9;
	Il2CppIUnknown* ____dynamicMethods_10;
	int32_t ____HResult_11;
	char* ____source_12;
	SafeSerializationManager_t4A754D86B0F784B18CBC36C073BA564BED109770 * ____safeSerializationManager_13;
	StackTraceU5BU5D_t855F09649EA34DEE7C1B6F088E0538E3CCC3F196* ___captured_traces_14;
	intptr_t* ___native_trace_ips_15;
};
// Native definition for COM marshalling of System.Exception
struct Exception_t_marshaled_com
{
	Il2CppChar* ____className_1;
	Il2CppChar* ____message_2;
	RuntimeObject* ____data_3;
	Exception_t_marshaled_com* ____innerException_4;
	Il2CppChar* ____helpURL_5;
	Il2CppIUnknown* ____stackTrace_6;
	Il2CppChar* ____stackTraceString_7;
	Il2CppChar* ____remoteStackTraceString_8;
	int32_t ____remoteStackIndex_9;
	Il2CppIUnknown* ____dynamicMethods_10;
	int32_t ____HResult_11;
	Il2CppChar* ____source_12;
	SafeSerializationManager_t4A754D86B0F784B18CBC36C073BA564BED109770 * ____safeSerializationManager_13;
	StackTraceU5BU5D_t855F09649EA34DEE7C1B6F088E0538E3CCC3F196* ___captured_traces_14;
	intptr_t* ___native_trace_ips_15;
};
#endif // EXCEPTION_T_H
#ifndef MARSHALBYREFOBJECT_TC4577953D0A44D0AB8597CFA868E01C858B1C9AF_H
#define MARSHALBYREFOBJECT_TC4577953D0A44D0AB8597CFA868E01C858B1C9AF_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.MarshalByRefObject
struct  MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF  : public RuntimeObject
{
public:
	// System.Object System.MarshalByRefObject::_identity
	RuntimeObject * ____identity_0;

public:
	inline static int32_t get_offset_of__identity_0() { return static_cast<int32_t>(offsetof(MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF, ____identity_0)); }
	inline RuntimeObject * get__identity_0() const { return ____identity_0; }
	inline RuntimeObject ** get_address_of__identity_0() { return &____identity_0; }
	inline void set__identity_0(RuntimeObject * value)
	{
		____identity_0 = value;
		Il2CppCodeGenWriteBarrier((&____identity_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.MarshalByRefObject
struct MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF_marshaled_pinvoke
{
	Il2CppIUnknown* ____identity_0;
};
// Native definition for COM marshalling of System.MarshalByRefObject
struct MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF_marshaled_com
{
	Il2CppIUnknown* ____identity_0;
};
#endif // MARSHALBYREFOBJECT_TC4577953D0A44D0AB8597CFA868E01C858B1C9AF_H
#ifndef SERIALIZATIONINFO_T1BB80E9C9DEA52DBF464487234B045E2930ADA26_H
#define SERIALIZATIONINFO_T1BB80E9C9DEA52DBF464487234B045E2930ADA26_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Runtime.Serialization.SerializationInfo
struct  SerializationInfo_t1BB80E9C9DEA52DBF464487234B045E2930ADA26  : public RuntimeObject
{
public:
	// System.String[] System.Runtime.Serialization.SerializationInfo::m_members
	StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* ___m_members_3;
	// System.Object[] System.Runtime.Serialization.SerializationInfo::m_data
	ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* ___m_data_4;
	// System.Type[] System.Runtime.Serialization.SerializationInfo::m_types
	TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F* ___m_types_5;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> System.Runtime.Serialization.SerializationInfo::m_nameToIndex
	Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB * ___m_nameToIndex_6;
	// System.Int32 System.Runtime.Serialization.SerializationInfo::m_currMember
	int32_t ___m_currMember_7;
	// System.Runtime.Serialization.IFormatterConverter System.Runtime.Serialization.SerializationInfo::m_converter
	RuntimeObject* ___m_converter_8;
	// System.String System.Runtime.Serialization.SerializationInfo::m_fullTypeName
	String_t* ___m_fullTypeName_9;
	// System.String System.Runtime.Serialization.SerializationInfo::m_assemName
	String_t* ___m_assemName_10;
	// System.Type System.Runtime.Serialization.SerializationInfo::objectType
	Type_t * ___objectType_11;
	// System.Boolean System.Runtime.Serialization.SerializationInfo::isFullTypeNameSetExplicit
	bool ___isFullTypeNameSetExplicit_12;
	// System.Boolean System.Runtime.Serialization.SerializationInfo::isAssemblyNameSetExplicit
	bool ___isAssemblyNameSetExplicit_13;
	// System.Boolean System.Runtime.Serialization.SerializationInfo::requireSameTokenInPartialTrust
	bool ___requireSameTokenInPartialTrust_14;

public:
	inline static int32_t get_offset_of_m_members_3() { return static_cast<int32_t>(offsetof(SerializationInfo_t1BB80E9C9DEA52DBF464487234B045E2930ADA26, ___m_members_3)); }
	inline StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* get_m_members_3() const { return ___m_members_3; }
	inline StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E** get_address_of_m_members_3() { return &___m_members_3; }
	inline void set_m_members_3(StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* value)
	{
		___m_members_3 = value;
		Il2CppCodeGenWriteBarrier((&___m_members_3), value);
	}

	inline static int32_t get_offset_of_m_data_4() { return static_cast<int32_t>(offsetof(SerializationInfo_t1BB80E9C9DEA52DBF464487234B045E2930ADA26, ___m_data_4)); }
	inline ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* get_m_data_4() const { return ___m_data_4; }
	inline ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A** get_address_of_m_data_4() { return &___m_data_4; }
	inline void set_m_data_4(ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* value)
	{
		___m_data_4 = value;
		Il2CppCodeGenWriteBarrier((&___m_data_4), value);
	}

	inline static int32_t get_offset_of_m_types_5() { return static_cast<int32_t>(offsetof(SerializationInfo_t1BB80E9C9DEA52DBF464487234B045E2930ADA26, ___m_types_5)); }
	inline TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F* get_m_types_5() const { return ___m_types_5; }
	inline TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F** get_address_of_m_types_5() { return &___m_types_5; }
	inline void set_m_types_5(TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F* value)
	{
		___m_types_5 = value;
		Il2CppCodeGenWriteBarrier((&___m_types_5), value);
	}

	inline static int32_t get_offset_of_m_nameToIndex_6() { return static_cast<int32_t>(offsetof(SerializationInfo_t1BB80E9C9DEA52DBF464487234B045E2930ADA26, ___m_nameToIndex_6)); }
	inline Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB * get_m_nameToIndex_6() const { return ___m_nameToIndex_6; }
	inline Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB ** get_address_of_m_nameToIndex_6() { return &___m_nameToIndex_6; }
	inline void set_m_nameToIndex_6(Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB * value)
	{
		___m_nameToIndex_6 = value;
		Il2CppCodeGenWriteBarrier((&___m_nameToIndex_6), value);
	}

	inline static int32_t get_offset_of_m_currMember_7() { return static_cast<int32_t>(offsetof(SerializationInfo_t1BB80E9C9DEA52DBF464487234B045E2930ADA26, ___m_currMember_7)); }
	inline int32_t get_m_currMember_7() const { return ___m_currMember_7; }
	inline int32_t* get_address_of_m_currMember_7() { return &___m_currMember_7; }
	inline void set_m_currMember_7(int32_t value)
	{
		___m_currMember_7 = value;
	}

	inline static int32_t get_offset_of_m_converter_8() { return static_cast<int32_t>(offsetof(SerializationInfo_t1BB80E9C9DEA52DBF464487234B045E2930ADA26, ___m_converter_8)); }
	inline RuntimeObject* get_m_converter_8() const { return ___m_converter_8; }
	inline RuntimeObject** get_address_of_m_converter_8() { return &___m_converter_8; }
	inline void set_m_converter_8(RuntimeObject* value)
	{
		___m_converter_8 = value;
		Il2CppCodeGenWriteBarrier((&___m_converter_8), value);
	}

	inline static int32_t get_offset_of_m_fullTypeName_9() { return static_cast<int32_t>(offsetof(SerializationInfo_t1BB80E9C9DEA52DBF464487234B045E2930ADA26, ___m_fullTypeName_9)); }
	inline String_t* get_m_fullTypeName_9() const { return ___m_fullTypeName_9; }
	inline String_t** get_address_of_m_fullTypeName_9() { return &___m_fullTypeName_9; }
	inline void set_m_fullTypeName_9(String_t* value)
	{
		___m_fullTypeName_9 = value;
		Il2CppCodeGenWriteBarrier((&___m_fullTypeName_9), value);
	}

	inline static int32_t get_offset_of_m_assemName_10() { return static_cast<int32_t>(offsetof(SerializationInfo_t1BB80E9C9DEA52DBF464487234B045E2930ADA26, ___m_assemName_10)); }
	inline String_t* get_m_assemName_10() const { return ___m_assemName_10; }
	inline String_t** get_address_of_m_assemName_10() { return &___m_assemName_10; }
	inline void set_m_assemName_10(String_t* value)
	{
		___m_assemName_10 = value;
		Il2CppCodeGenWriteBarrier((&___m_assemName_10), value);
	}

	inline static int32_t get_offset_of_objectType_11() { return static_cast<int32_t>(offsetof(SerializationInfo_t1BB80E9C9DEA52DBF464487234B045E2930ADA26, ___objectType_11)); }
	inline Type_t * get_objectType_11() const { return ___objectType_11; }
	inline Type_t ** get_address_of_objectType_11() { return &___objectType_11; }
	inline void set_objectType_11(Type_t * value)
	{
		___objectType_11 = value;
		Il2CppCodeGenWriteBarrier((&___objectType_11), value);
	}

	inline static int32_t get_offset_of_isFullTypeNameSetExplicit_12() { return static_cast<int32_t>(offsetof(SerializationInfo_t1BB80E9C9DEA52DBF464487234B045E2930ADA26, ___isFullTypeNameSetExplicit_12)); }
	inline bool get_isFullTypeNameSetExplicit_12() const { return ___isFullTypeNameSetExplicit_12; }
	inline bool* get_address_of_isFullTypeNameSetExplicit_12() { return &___isFullTypeNameSetExplicit_12; }
	inline void set_isFullTypeNameSetExplicit_12(bool value)
	{
		___isFullTypeNameSetExplicit_12 = value;
	}

	inline static int32_t get_offset_of_isAssemblyNameSetExplicit_13() { return static_cast<int32_t>(offsetof(SerializationInfo_t1BB80E9C9DEA52DBF464487234B045E2930ADA26, ___isAssemblyNameSetExplicit_13)); }
	inline bool get_isAssemblyNameSetExplicit_13() const { return ___isAssemblyNameSetExplicit_13; }
	inline bool* get_address_of_isAssemblyNameSetExplicit_13() { return &___isAssemblyNameSetExplicit_13; }
	inline void set_isAssemblyNameSetExplicit_13(bool value)
	{
		___isAssemblyNameSetExplicit_13 = value;
	}

	inline static int32_t get_offset_of_requireSameTokenInPartialTrust_14() { return static_cast<int32_t>(offsetof(SerializationInfo_t1BB80E9C9DEA52DBF464487234B045E2930ADA26, ___requireSameTokenInPartialTrust_14)); }
	inline bool get_requireSameTokenInPartialTrust_14() const { return ___requireSameTokenInPartialTrust_14; }
	inline bool* get_address_of_requireSameTokenInPartialTrust_14() { return &___requireSameTokenInPartialTrust_14; }
	inline void set_requireSameTokenInPartialTrust_14(bool value)
	{
		___requireSameTokenInPartialTrust_14 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SERIALIZATIONINFO_T1BB80E9C9DEA52DBF464487234B045E2930ADA26_H
#ifndef STRING_T_H
#define STRING_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.String
struct  String_t  : public RuntimeObject
{
public:
	// System.Int32 System.String::m_stringLength
	int32_t ___m_stringLength_0;
	// System.Char System.String::m_firstChar
	Il2CppChar ___m_firstChar_1;

public:
	inline static int32_t get_offset_of_m_stringLength_0() { return static_cast<int32_t>(offsetof(String_t, ___m_stringLength_0)); }
	inline int32_t get_m_stringLength_0() const { return ___m_stringLength_0; }
	inline int32_t* get_address_of_m_stringLength_0() { return &___m_stringLength_0; }
	inline void set_m_stringLength_0(int32_t value)
	{
		___m_stringLength_0 = value;
	}

	inline static int32_t get_offset_of_m_firstChar_1() { return static_cast<int32_t>(offsetof(String_t, ___m_firstChar_1)); }
	inline Il2CppChar get_m_firstChar_1() const { return ___m_firstChar_1; }
	inline Il2CppChar* get_address_of_m_firstChar_1() { return &___m_firstChar_1; }
	inline void set_m_firstChar_1(Il2CppChar value)
	{
		___m_firstChar_1 = value;
	}
};

struct String_t_StaticFields
{
public:
	// System.String System.String::Empty
	String_t* ___Empty_5;

public:
	inline static int32_t get_offset_of_Empty_5() { return static_cast<int32_t>(offsetof(String_t_StaticFields, ___Empty_5)); }
	inline String_t* get_Empty_5() const { return ___Empty_5; }
	inline String_t** get_address_of_Empty_5() { return &___Empty_5; }
	inline void set_Empty_5(String_t* value)
	{
		___Empty_5 = value;
		Il2CppCodeGenWriteBarrier((&___Empty_5), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // STRING_T_H
#ifndef ENLISTMENT_T9E19C9353D07B13F6DEA340C15D562EAE001CB2D_H
#define ENLISTMENT_T9E19C9353D07B13F6DEA340C15D562EAE001CB2D_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Transactions.Enlistment
struct  Enlistment_t9E19C9353D07B13F6DEA340C15D562EAE001CB2D  : public RuntimeObject
{
public:
	// System.Boolean System.Transactions.Enlistment::done
	bool ___done_0;

public:
	inline static int32_t get_offset_of_done_0() { return static_cast<int32_t>(offsetof(Enlistment_t9E19C9353D07B13F6DEA340C15D562EAE001CB2D, ___done_0)); }
	inline bool get_done_0() const { return ___done_0; }
	inline bool* get_address_of_done_0() { return &___done_0; }
	inline void set_done_0(bool value)
	{
		___done_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ENLISTMENT_T9E19C9353D07B13F6DEA340C15D562EAE001CB2D_H
#ifndef VALUETYPE_T4D0C27076F7C36E76190FB3328E232BCB1CD1FFF_H
#define VALUETYPE_T4D0C27076F7C36E76190FB3328E232BCB1CD1FFF_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ValueType
struct  ValueType_t4D0C27076F7C36E76190FB3328E232BCB1CD1FFF  : public RuntimeObject
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_t4D0C27076F7C36E76190FB3328E232BCB1CD1FFF_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_t4D0C27076F7C36E76190FB3328E232BCB1CD1FFF_marshaled_com
{
};
#endif // VALUETYPE_T4D0C27076F7C36E76190FB3328E232BCB1CD1FFF_H
#ifndef BOOLEAN_TB53F6830F670160873277339AA58F15CAED4399C_H
#define BOOLEAN_TB53F6830F670160873277339AA58F15CAED4399C_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Boolean
struct  Boolean_tB53F6830F670160873277339AA58F15CAED4399C 
{
public:
	// System.Boolean System.Boolean::m_value
	bool ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Boolean_tB53F6830F670160873277339AA58F15CAED4399C, ___m_value_0)); }
	inline bool get_m_value_0() const { return ___m_value_0; }
	inline bool* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(bool value)
	{
		___m_value_0 = value;
	}
};

struct Boolean_tB53F6830F670160873277339AA58F15CAED4399C_StaticFields
{
public:
	// System.String System.Boolean::TrueString
	String_t* ___TrueString_5;
	// System.String System.Boolean::FalseString
	String_t* ___FalseString_6;

public:
	inline static int32_t get_offset_of_TrueString_5() { return static_cast<int32_t>(offsetof(Boolean_tB53F6830F670160873277339AA58F15CAED4399C_StaticFields, ___TrueString_5)); }
	inline String_t* get_TrueString_5() const { return ___TrueString_5; }
	inline String_t** get_address_of_TrueString_5() { return &___TrueString_5; }
	inline void set_TrueString_5(String_t* value)
	{
		___TrueString_5 = value;
		Il2CppCodeGenWriteBarrier((&___TrueString_5), value);
	}

	inline static int32_t get_offset_of_FalseString_6() { return static_cast<int32_t>(offsetof(Boolean_tB53F6830F670160873277339AA58F15CAED4399C_StaticFields, ___FalseString_6)); }
	inline String_t* get_FalseString_6() const { return ___FalseString_6; }
	inline String_t** get_address_of_FalseString_6() { return &___FalseString_6; }
	inline void set_FalseString_6(String_t* value)
	{
		___FalseString_6 = value;
		Il2CppCodeGenWriteBarrier((&___FalseString_6), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // BOOLEAN_TB53F6830F670160873277339AA58F15CAED4399C_H
#ifndef ENUMERATOR_TE0C99528D3DCE5863566CE37BD94162A4C0431CD_H
#define ENUMERATOR_TE0C99528D3DCE5863566CE37BD94162A4C0431CD_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.List`1_Enumerator<System.Object>
struct  Enumerator_tE0C99528D3DCE5863566CE37BD94162A4C0431CD 
{
public:
	// System.Collections.Generic.List`1<T> System.Collections.Generic.List`1_Enumerator::list
	List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * ___list_0;
	// System.Int32 System.Collections.Generic.List`1_Enumerator::index
	int32_t ___index_1;
	// System.Int32 System.Collections.Generic.List`1_Enumerator::version
	int32_t ___version_2;
	// T System.Collections.Generic.List`1_Enumerator::current
	RuntimeObject * ___current_3;

public:
	inline static int32_t get_offset_of_list_0() { return static_cast<int32_t>(offsetof(Enumerator_tE0C99528D3DCE5863566CE37BD94162A4C0431CD, ___list_0)); }
	inline List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * get_list_0() const { return ___list_0; }
	inline List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D ** get_address_of_list_0() { return &___list_0; }
	inline void set_list_0(List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * value)
	{
		___list_0 = value;
		Il2CppCodeGenWriteBarrier((&___list_0), value);
	}

	inline static int32_t get_offset_of_index_1() { return static_cast<int32_t>(offsetof(Enumerator_tE0C99528D3DCE5863566CE37BD94162A4C0431CD, ___index_1)); }
	inline int32_t get_index_1() const { return ___index_1; }
	inline int32_t* get_address_of_index_1() { return &___index_1; }
	inline void set_index_1(int32_t value)
	{
		___index_1 = value;
	}

	inline static int32_t get_offset_of_version_2() { return static_cast<int32_t>(offsetof(Enumerator_tE0C99528D3DCE5863566CE37BD94162A4C0431CD, ___version_2)); }
	inline int32_t get_version_2() const { return ___version_2; }
	inline int32_t* get_address_of_version_2() { return &___version_2; }
	inline void set_version_2(int32_t value)
	{
		___version_2 = value;
	}

	inline static int32_t get_offset_of_current_3() { return static_cast<int32_t>(offsetof(Enumerator_tE0C99528D3DCE5863566CE37BD94162A4C0431CD, ___current_3)); }
	inline RuntimeObject * get_current_3() const { return ___current_3; }
	inline RuntimeObject ** get_address_of_current_3() { return &___current_3; }
	inline void set_current_3(RuntimeObject * value)
	{
		___current_3 = value;
		Il2CppCodeGenWriteBarrier((&___current_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ENUMERATOR_TE0C99528D3DCE5863566CE37BD94162A4C0431CD_H
#ifndef ENUMERATOR_TCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD_H
#define ENUMERATOR_TCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.List`1_Enumerator<System.Transactions.IEnlistmentNotification>
struct  Enumerator_tCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD 
{
public:
	// System.Collections.Generic.List`1<T> System.Collections.Generic.List`1_Enumerator::list
	List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 * ___list_0;
	// System.Int32 System.Collections.Generic.List`1_Enumerator::index
	int32_t ___index_1;
	// System.Int32 System.Collections.Generic.List`1_Enumerator::version
	int32_t ___version_2;
	// T System.Collections.Generic.List`1_Enumerator::current
	RuntimeObject* ___current_3;

public:
	inline static int32_t get_offset_of_list_0() { return static_cast<int32_t>(offsetof(Enumerator_tCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD, ___list_0)); }
	inline List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 * get_list_0() const { return ___list_0; }
	inline List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 ** get_address_of_list_0() { return &___list_0; }
	inline void set_list_0(List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 * value)
	{
		___list_0 = value;
		Il2CppCodeGenWriteBarrier((&___list_0), value);
	}

	inline static int32_t get_offset_of_index_1() { return static_cast<int32_t>(offsetof(Enumerator_tCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD, ___index_1)); }
	inline int32_t get_index_1() const { return ___index_1; }
	inline int32_t* get_address_of_index_1() { return &___index_1; }
	inline void set_index_1(int32_t value)
	{
		___index_1 = value;
	}

	inline static int32_t get_offset_of_version_2() { return static_cast<int32_t>(offsetof(Enumerator_tCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD, ___version_2)); }
	inline int32_t get_version_2() const { return ___version_2; }
	inline int32_t* get_address_of_version_2() { return &___version_2; }
	inline void set_version_2(int32_t value)
	{
		___version_2 = value;
	}

	inline static int32_t get_offset_of_current_3() { return static_cast<int32_t>(offsetof(Enumerator_tCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD, ___current_3)); }
	inline RuntimeObject* get_current_3() const { return ___current_3; }
	inline RuntimeObject** get_address_of_current_3() { return &___current_3; }
	inline void set_current_3(RuntimeObject* value)
	{
		___current_3 = value;
		Il2CppCodeGenWriteBarrier((&___current_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ENUMERATOR_TCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD_H
#ifndef DATETIME_T349B7449FBAAFF4192636E2B7A07694DA9236132_H
#define DATETIME_T349B7449FBAAFF4192636E2B7A07694DA9236132_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.DateTime
struct  DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132 
{
public:
	// System.UInt64 System.DateTime::dateData
	uint64_t ___dateData_44;

public:
	inline static int32_t get_offset_of_dateData_44() { return static_cast<int32_t>(offsetof(DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132, ___dateData_44)); }
	inline uint64_t get_dateData_44() const { return ___dateData_44; }
	inline uint64_t* get_address_of_dateData_44() { return &___dateData_44; }
	inline void set_dateData_44(uint64_t value)
	{
		___dateData_44 = value;
	}
};

struct DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132_StaticFields
{
public:
	// System.Int32[] System.DateTime::DaysToMonth365
	Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* ___DaysToMonth365_29;
	// System.Int32[] System.DateTime::DaysToMonth366
	Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* ___DaysToMonth366_30;
	// System.DateTime System.DateTime::MinValue
	DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132  ___MinValue_31;
	// System.DateTime System.DateTime::MaxValue
	DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132  ___MaxValue_32;

public:
	inline static int32_t get_offset_of_DaysToMonth365_29() { return static_cast<int32_t>(offsetof(DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132_StaticFields, ___DaysToMonth365_29)); }
	inline Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* get_DaysToMonth365_29() const { return ___DaysToMonth365_29; }
	inline Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83** get_address_of_DaysToMonth365_29() { return &___DaysToMonth365_29; }
	inline void set_DaysToMonth365_29(Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* value)
	{
		___DaysToMonth365_29 = value;
		Il2CppCodeGenWriteBarrier((&___DaysToMonth365_29), value);
	}

	inline static int32_t get_offset_of_DaysToMonth366_30() { return static_cast<int32_t>(offsetof(DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132_StaticFields, ___DaysToMonth366_30)); }
	inline Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* get_DaysToMonth366_30() const { return ___DaysToMonth366_30; }
	inline Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83** get_address_of_DaysToMonth366_30() { return &___DaysToMonth366_30; }
	inline void set_DaysToMonth366_30(Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* value)
	{
		___DaysToMonth366_30 = value;
		Il2CppCodeGenWriteBarrier((&___DaysToMonth366_30), value);
	}

	inline static int32_t get_offset_of_MinValue_31() { return static_cast<int32_t>(offsetof(DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132_StaticFields, ___MinValue_31)); }
	inline DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132  get_MinValue_31() const { return ___MinValue_31; }
	inline DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132 * get_address_of_MinValue_31() { return &___MinValue_31; }
	inline void set_MinValue_31(DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132  value)
	{
		___MinValue_31 = value;
	}

	inline static int32_t get_offset_of_MaxValue_32() { return static_cast<int32_t>(offsetof(DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132_StaticFields, ___MaxValue_32)); }
	inline DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132  get_MaxValue_32() const { return ___MaxValue_32; }
	inline DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132 * get_address_of_MaxValue_32() { return &___MaxValue_32; }
	inline void set_MaxValue_32(DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132  value)
	{
		___MaxValue_32 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // DATETIME_T349B7449FBAAFF4192636E2B7A07694DA9236132_H
#ifndef ENUM_T2AF27C02B8653AE29442467390005ABC74D8F521_H
#define ENUM_T2AF27C02B8653AE29442467390005ABC74D8F521_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Enum
struct  Enum_t2AF27C02B8653AE29442467390005ABC74D8F521  : public ValueType_t4D0C27076F7C36E76190FB3328E232BCB1CD1FFF
{
public:

public:
};

struct Enum_t2AF27C02B8653AE29442467390005ABC74D8F521_StaticFields
{
public:
	// System.Char[] System.Enum::enumSeperatorCharArray
	CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* ___enumSeperatorCharArray_0;

public:
	inline static int32_t get_offset_of_enumSeperatorCharArray_0() { return static_cast<int32_t>(offsetof(Enum_t2AF27C02B8653AE29442467390005ABC74D8F521_StaticFields, ___enumSeperatorCharArray_0)); }
	inline CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* get_enumSeperatorCharArray_0() const { return ___enumSeperatorCharArray_0; }
	inline CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2** get_address_of_enumSeperatorCharArray_0() { return &___enumSeperatorCharArray_0; }
	inline void set_enumSeperatorCharArray_0(CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* value)
	{
		___enumSeperatorCharArray_0 = value;
		Il2CppCodeGenWriteBarrier((&___enumSeperatorCharArray_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.Enum
struct Enum_t2AF27C02B8653AE29442467390005ABC74D8F521_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.Enum
struct Enum_t2AF27C02B8653AE29442467390005ABC74D8F521_marshaled_com
{
};
#endif // ENUM_T2AF27C02B8653AE29442467390005ABC74D8F521_H
#ifndef GUID_T_H
#define GUID_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Guid
struct  Guid_t 
{
public:
	// System.Int32 System.Guid::_a
	int32_t ____a_1;
	// System.Int16 System.Guid::_b
	int16_t ____b_2;
	// System.Int16 System.Guid::_c
	int16_t ____c_3;
	// System.Byte System.Guid::_d
	uint8_t ____d_4;
	// System.Byte System.Guid::_e
	uint8_t ____e_5;
	// System.Byte System.Guid::_f
	uint8_t ____f_6;
	// System.Byte System.Guid::_g
	uint8_t ____g_7;
	// System.Byte System.Guid::_h
	uint8_t ____h_8;
	// System.Byte System.Guid::_i
	uint8_t ____i_9;
	// System.Byte System.Guid::_j
	uint8_t ____j_10;
	// System.Byte System.Guid::_k
	uint8_t ____k_11;

public:
	inline static int32_t get_offset_of__a_1() { return static_cast<int32_t>(offsetof(Guid_t, ____a_1)); }
	inline int32_t get__a_1() const { return ____a_1; }
	inline int32_t* get_address_of__a_1() { return &____a_1; }
	inline void set__a_1(int32_t value)
	{
		____a_1 = value;
	}

	inline static int32_t get_offset_of__b_2() { return static_cast<int32_t>(offsetof(Guid_t, ____b_2)); }
	inline int16_t get__b_2() const { return ____b_2; }
	inline int16_t* get_address_of__b_2() { return &____b_2; }
	inline void set__b_2(int16_t value)
	{
		____b_2 = value;
	}

	inline static int32_t get_offset_of__c_3() { return static_cast<int32_t>(offsetof(Guid_t, ____c_3)); }
	inline int16_t get__c_3() const { return ____c_3; }
	inline int16_t* get_address_of__c_3() { return &____c_3; }
	inline void set__c_3(int16_t value)
	{
		____c_3 = value;
	}

	inline static int32_t get_offset_of__d_4() { return static_cast<int32_t>(offsetof(Guid_t, ____d_4)); }
	inline uint8_t get__d_4() const { return ____d_4; }
	inline uint8_t* get_address_of__d_4() { return &____d_4; }
	inline void set__d_4(uint8_t value)
	{
		____d_4 = value;
	}

	inline static int32_t get_offset_of__e_5() { return static_cast<int32_t>(offsetof(Guid_t, ____e_5)); }
	inline uint8_t get__e_5() const { return ____e_5; }
	inline uint8_t* get_address_of__e_5() { return &____e_5; }
	inline void set__e_5(uint8_t value)
	{
		____e_5 = value;
	}

	inline static int32_t get_offset_of__f_6() { return static_cast<int32_t>(offsetof(Guid_t, ____f_6)); }
	inline uint8_t get__f_6() const { return ____f_6; }
	inline uint8_t* get_address_of__f_6() { return &____f_6; }
	inline void set__f_6(uint8_t value)
	{
		____f_6 = value;
	}

	inline static int32_t get_offset_of__g_7() { return static_cast<int32_t>(offsetof(Guid_t, ____g_7)); }
	inline uint8_t get__g_7() const { return ____g_7; }
	inline uint8_t* get_address_of__g_7() { return &____g_7; }
	inline void set__g_7(uint8_t value)
	{
		____g_7 = value;
	}

	inline static int32_t get_offset_of__h_8() { return static_cast<int32_t>(offsetof(Guid_t, ____h_8)); }
	inline uint8_t get__h_8() const { return ____h_8; }
	inline uint8_t* get_address_of__h_8() { return &____h_8; }
	inline void set__h_8(uint8_t value)
	{
		____h_8 = value;
	}

	inline static int32_t get_offset_of__i_9() { return static_cast<int32_t>(offsetof(Guid_t, ____i_9)); }
	inline uint8_t get__i_9() const { return ____i_9; }
	inline uint8_t* get_address_of__i_9() { return &____i_9; }
	inline void set__i_9(uint8_t value)
	{
		____i_9 = value;
	}

	inline static int32_t get_offset_of__j_10() { return static_cast<int32_t>(offsetof(Guid_t, ____j_10)); }
	inline uint8_t get__j_10() const { return ____j_10; }
	inline uint8_t* get_address_of__j_10() { return &____j_10; }
	inline void set__j_10(uint8_t value)
	{
		____j_10 = value;
	}

	inline static int32_t get_offset_of__k_11() { return static_cast<int32_t>(offsetof(Guid_t, ____k_11)); }
	inline uint8_t get__k_11() const { return ____k_11; }
	inline uint8_t* get_address_of__k_11() { return &____k_11; }
	inline void set__k_11(uint8_t value)
	{
		____k_11 = value;
	}
};

struct Guid_t_StaticFields
{
public:
	// System.Guid System.Guid::Empty
	Guid_t  ___Empty_0;
	// System.Object System.Guid::_rngAccess
	RuntimeObject * ____rngAccess_12;
	// System.Security.Cryptography.RandomNumberGenerator System.Guid::_rng
	RandomNumberGenerator_t12277F7F965BA79C54E4B3BFABD27A5FFB725EE2 * ____rng_13;
	// System.Security.Cryptography.RandomNumberGenerator System.Guid::_fastRng
	RandomNumberGenerator_t12277F7F965BA79C54E4B3BFABD27A5FFB725EE2 * ____fastRng_14;

public:
	inline static int32_t get_offset_of_Empty_0() { return static_cast<int32_t>(offsetof(Guid_t_StaticFields, ___Empty_0)); }
	inline Guid_t  get_Empty_0() const { return ___Empty_0; }
	inline Guid_t * get_address_of_Empty_0() { return &___Empty_0; }
	inline void set_Empty_0(Guid_t  value)
	{
		___Empty_0 = value;
	}

	inline static int32_t get_offset_of__rngAccess_12() { return static_cast<int32_t>(offsetof(Guid_t_StaticFields, ____rngAccess_12)); }
	inline RuntimeObject * get__rngAccess_12() const { return ____rngAccess_12; }
	inline RuntimeObject ** get_address_of__rngAccess_12() { return &____rngAccess_12; }
	inline void set__rngAccess_12(RuntimeObject * value)
	{
		____rngAccess_12 = value;
		Il2CppCodeGenWriteBarrier((&____rngAccess_12), value);
	}

	inline static int32_t get_offset_of__rng_13() { return static_cast<int32_t>(offsetof(Guid_t_StaticFields, ____rng_13)); }
	inline RandomNumberGenerator_t12277F7F965BA79C54E4B3BFABD27A5FFB725EE2 * get__rng_13() const { return ____rng_13; }
	inline RandomNumberGenerator_t12277F7F965BA79C54E4B3BFABD27A5FFB725EE2 ** get_address_of__rng_13() { return &____rng_13; }
	inline void set__rng_13(RandomNumberGenerator_t12277F7F965BA79C54E4B3BFABD27A5FFB725EE2 * value)
	{
		____rng_13 = value;
		Il2CppCodeGenWriteBarrier((&____rng_13), value);
	}

	inline static int32_t get_offset_of__fastRng_14() { return static_cast<int32_t>(offsetof(Guid_t_StaticFields, ____fastRng_14)); }
	inline RandomNumberGenerator_t12277F7F965BA79C54E4B3BFABD27A5FFB725EE2 * get__fastRng_14() const { return ____fastRng_14; }
	inline RandomNumberGenerator_t12277F7F965BA79C54E4B3BFABD27A5FFB725EE2 ** get_address_of__fastRng_14() { return &____fastRng_14; }
	inline void set__fastRng_14(RandomNumberGenerator_t12277F7F965BA79C54E4B3BFABD27A5FFB725EE2 * value)
	{
		____fastRng_14 = value;
		Il2CppCodeGenWriteBarrier((&____fastRng_14), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // GUID_T_H
#ifndef INT32_T585191389E07734F19F3156FF88FB3EF4800D102_H
#define INT32_T585191389E07734F19F3156FF88FB3EF4800D102_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Int32
struct  Int32_t585191389E07734F19F3156FF88FB3EF4800D102 
{
public:
	// System.Int32 System.Int32::m_value
	int32_t ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Int32_t585191389E07734F19F3156FF88FB3EF4800D102, ___m_value_0)); }
	inline int32_t get_m_value_0() const { return ___m_value_0; }
	inline int32_t* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(int32_t value)
	{
		___m_value_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // INT32_T585191389E07734F19F3156FF88FB3EF4800D102_H
#ifndef INTPTR_T_H
#define INTPTR_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.IntPtr
struct  IntPtr_t 
{
public:
	// System.Void* System.IntPtr::m_value
	void* ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(IntPtr_t, ___m_value_0)); }
	inline void* get_m_value_0() const { return ___m_value_0; }
	inline void** get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(void* value)
	{
		___m_value_0 = value;
	}
};

struct IntPtr_t_StaticFields
{
public:
	// System.IntPtr System.IntPtr::Zero
	intptr_t ___Zero_1;

public:
	inline static int32_t get_offset_of_Zero_1() { return static_cast<int32_t>(offsetof(IntPtr_t_StaticFields, ___Zero_1)); }
	inline intptr_t get_Zero_1() const { return ___Zero_1; }
	inline intptr_t* get_address_of_Zero_1() { return &___Zero_1; }
	inline void set_Zero_1(intptr_t value)
	{
		___Zero_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // INTPTR_T_H
#ifndef MONOTODOATTRIBUTE_T3C9A5765E42675DA136240D678090D792AD2B26C_H
#define MONOTODOATTRIBUTE_T3C9A5765E42675DA136240D678090D792AD2B26C_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.MonoTODOAttribute
struct  MonoTODOAttribute_t3C9A5765E42675DA136240D678090D792AD2B26C  : public Attribute_tF048C13FB3C8CFCC53F82290E4A3F621089F9A74
{
public:
	// System.String System.MonoTODOAttribute::comment
	String_t* ___comment_0;

public:
	inline static int32_t get_offset_of_comment_0() { return static_cast<int32_t>(offsetof(MonoTODOAttribute_t3C9A5765E42675DA136240D678090D792AD2B26C, ___comment_0)); }
	inline String_t* get_comment_0() const { return ___comment_0; }
	inline String_t** get_address_of_comment_0() { return &___comment_0; }
	inline void set_comment_0(String_t* value)
	{
		___comment_0 = value;
		Il2CppCodeGenWriteBarrier((&___comment_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MONOTODOATTRIBUTE_T3C9A5765E42675DA136240D678090D792AD2B26C_H
#ifndef SYSTEMEXCEPTION_T5380468142AA850BE4A341D7AF3EAB9C78746782_H
#define SYSTEMEXCEPTION_T5380468142AA850BE4A341D7AF3EAB9C78746782_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.SystemException
struct  SystemException_t5380468142AA850BE4A341D7AF3EAB9C78746782  : public Exception_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SYSTEMEXCEPTION_T5380468142AA850BE4A341D7AF3EAB9C78746782_H
#ifndef PREPARINGENLISTMENT_T2ADCAA14B9C7105B160E48051239A6DBEE521496_H
#define PREPARINGENLISTMENT_T2ADCAA14B9C7105B160E48051239A6DBEE521496_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Transactions.PreparingEnlistment
struct  PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496  : public Enlistment_t9E19C9353D07B13F6DEA340C15D562EAE001CB2D
{
public:
	// System.Boolean System.Transactions.PreparingEnlistment::prepared
	bool ___prepared_1;
	// System.Transactions.Transaction System.Transactions.PreparingEnlistment::tx
	Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * ___tx_2;
	// System.Transactions.IEnlistmentNotification System.Transactions.PreparingEnlistment::enlisted
	RuntimeObject* ___enlisted_3;
	// System.Threading.WaitHandle System.Transactions.PreparingEnlistment::waitHandle
	WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6 * ___waitHandle_4;
	// System.Exception System.Transactions.PreparingEnlistment::ex
	Exception_t * ___ex_5;

public:
	inline static int32_t get_offset_of_prepared_1() { return static_cast<int32_t>(offsetof(PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496, ___prepared_1)); }
	inline bool get_prepared_1() const { return ___prepared_1; }
	inline bool* get_address_of_prepared_1() { return &___prepared_1; }
	inline void set_prepared_1(bool value)
	{
		___prepared_1 = value;
	}

	inline static int32_t get_offset_of_tx_2() { return static_cast<int32_t>(offsetof(PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496, ___tx_2)); }
	inline Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * get_tx_2() const { return ___tx_2; }
	inline Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 ** get_address_of_tx_2() { return &___tx_2; }
	inline void set_tx_2(Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * value)
	{
		___tx_2 = value;
		Il2CppCodeGenWriteBarrier((&___tx_2), value);
	}

	inline static int32_t get_offset_of_enlisted_3() { return static_cast<int32_t>(offsetof(PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496, ___enlisted_3)); }
	inline RuntimeObject* get_enlisted_3() const { return ___enlisted_3; }
	inline RuntimeObject** get_address_of_enlisted_3() { return &___enlisted_3; }
	inline void set_enlisted_3(RuntimeObject* value)
	{
		___enlisted_3 = value;
		Il2CppCodeGenWriteBarrier((&___enlisted_3), value);
	}

	inline static int32_t get_offset_of_waitHandle_4() { return static_cast<int32_t>(offsetof(PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496, ___waitHandle_4)); }
	inline WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6 * get_waitHandle_4() const { return ___waitHandle_4; }
	inline WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6 ** get_address_of_waitHandle_4() { return &___waitHandle_4; }
	inline void set_waitHandle_4(WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6 * value)
	{
		___waitHandle_4 = value;
		Il2CppCodeGenWriteBarrier((&___waitHandle_4), value);
	}

	inline static int32_t get_offset_of_ex_5() { return static_cast<int32_t>(offsetof(PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496, ___ex_5)); }
	inline Exception_t * get_ex_5() const { return ___ex_5; }
	inline Exception_t ** get_address_of_ex_5() { return &___ex_5; }
	inline void set_ex_5(Exception_t * value)
	{
		___ex_5 = value;
		Il2CppCodeGenWriteBarrier((&___ex_5), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // PREPARINGENLISTMENT_T2ADCAA14B9C7105B160E48051239A6DBEE521496_H
#ifndef SINGLEPHASEENLISTMENT_T29EFB2BAA0D8E39ABCAAE5061AF9D889DED528F6_H
#define SINGLEPHASEENLISTMENT_T29EFB2BAA0D8E39ABCAAE5061AF9D889DED528F6_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Transactions.SinglePhaseEnlistment
struct  SinglePhaseEnlistment_t29EFB2BAA0D8E39ABCAAE5061AF9D889DED528F6  : public Enlistment_t9E19C9353D07B13F6DEA340C15D562EAE001CB2D
{
public:
	// System.Transactions.Transaction System.Transactions.SinglePhaseEnlistment::tx
	Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * ___tx_1;
	// System.Object System.Transactions.SinglePhaseEnlistment::abortingEnlisted
	RuntimeObject * ___abortingEnlisted_2;

public:
	inline static int32_t get_offset_of_tx_1() { return static_cast<int32_t>(offsetof(SinglePhaseEnlistment_t29EFB2BAA0D8E39ABCAAE5061AF9D889DED528F6, ___tx_1)); }
	inline Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * get_tx_1() const { return ___tx_1; }
	inline Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 ** get_address_of_tx_1() { return &___tx_1; }
	inline void set_tx_1(Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * value)
	{
		___tx_1 = value;
		Il2CppCodeGenWriteBarrier((&___tx_1), value);
	}

	inline static int32_t get_offset_of_abortingEnlisted_2() { return static_cast<int32_t>(offsetof(SinglePhaseEnlistment_t29EFB2BAA0D8E39ABCAAE5061AF9D889DED528F6, ___abortingEnlisted_2)); }
	inline RuntimeObject * get_abortingEnlisted_2() const { return ___abortingEnlisted_2; }
	inline RuntimeObject ** get_address_of_abortingEnlisted_2() { return &___abortingEnlisted_2; }
	inline void set_abortingEnlisted_2(RuntimeObject * value)
	{
		___abortingEnlisted_2 = value;
		Il2CppCodeGenWriteBarrier((&___abortingEnlisted_2), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SINGLEPHASEENLISTMENT_T29EFB2BAA0D8E39ABCAAE5061AF9D889DED528F6_H
#ifndef TRANSACTIONEVENTARGS_T3681DC7BCA98278A61430810F0627003BB8F83B6_H
#define TRANSACTIONEVENTARGS_T3681DC7BCA98278A61430810F0627003BB8F83B6_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Transactions.TransactionEventArgs
struct  TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6  : public EventArgs_t8E6CA180BE0E56674C6407011A94BAF7C757352E
{
public:
	// System.Transactions.Transaction System.Transactions.TransactionEventArgs::transaction
	Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * ___transaction_1;

public:
	inline static int32_t get_offset_of_transaction_1() { return static_cast<int32_t>(offsetof(TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6, ___transaction_1)); }
	inline Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * get_transaction_1() const { return ___transaction_1; }
	inline Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 ** get_address_of_transaction_1() { return &___transaction_1; }
	inline void set_transaction_1(Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * value)
	{
		___transaction_1 = value;
		Il2CppCodeGenWriteBarrier((&___transaction_1), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TRANSACTIONEVENTARGS_T3681DC7BCA98278A61430810F0627003BB8F83B6_H
#ifndef VOID_T22962CB4C05B1D89B55A6E1139F0E87A90987017_H
#define VOID_T22962CB4C05B1D89B55A6E1139F0E87A90987017_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Void
struct  Void_t22962CB4C05B1D89B55A6E1139F0E87A90987017 
{
public:
	union
	{
		struct
		{
		};
		uint8_t Void_t22962CB4C05B1D89B55A6E1139F0E87A90987017__padding[1];
	};

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // VOID_T22962CB4C05B1D89B55A6E1139F0E87A90987017_H
#ifndef DELEGATE_T_H
#define DELEGATE_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Delegate
struct  Delegate_t  : public RuntimeObject
{
public:
	// System.IntPtr System.Delegate::method_ptr
	Il2CppMethodPointer ___method_ptr_0;
	// System.IntPtr System.Delegate::invoke_impl
	intptr_t ___invoke_impl_1;
	// System.Object System.Delegate::m_target
	RuntimeObject * ___m_target_2;
	// System.IntPtr System.Delegate::method
	intptr_t ___method_3;
	// System.IntPtr System.Delegate::delegate_trampoline
	intptr_t ___delegate_trampoline_4;
	// System.IntPtr System.Delegate::extra_arg
	intptr_t ___extra_arg_5;
	// System.IntPtr System.Delegate::method_code
	intptr_t ___method_code_6;
	// System.Reflection.MethodInfo System.Delegate::method_info
	MethodInfo_t * ___method_info_7;
	// System.Reflection.MethodInfo System.Delegate::original_method_info
	MethodInfo_t * ___original_method_info_8;
	// System.DelegateData System.Delegate::data
	DelegateData_t1BF9F691B56DAE5F8C28C5E084FDE94F15F27BBE * ___data_9;
	// System.Boolean System.Delegate::method_is_virtual
	bool ___method_is_virtual_10;

public:
	inline static int32_t get_offset_of_method_ptr_0() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_ptr_0)); }
	inline Il2CppMethodPointer get_method_ptr_0() const { return ___method_ptr_0; }
	inline Il2CppMethodPointer* get_address_of_method_ptr_0() { return &___method_ptr_0; }
	inline void set_method_ptr_0(Il2CppMethodPointer value)
	{
		___method_ptr_0 = value;
	}

	inline static int32_t get_offset_of_invoke_impl_1() { return static_cast<int32_t>(offsetof(Delegate_t, ___invoke_impl_1)); }
	inline intptr_t get_invoke_impl_1() const { return ___invoke_impl_1; }
	inline intptr_t* get_address_of_invoke_impl_1() { return &___invoke_impl_1; }
	inline void set_invoke_impl_1(intptr_t value)
	{
		___invoke_impl_1 = value;
	}

	inline static int32_t get_offset_of_m_target_2() { return static_cast<int32_t>(offsetof(Delegate_t, ___m_target_2)); }
	inline RuntimeObject * get_m_target_2() const { return ___m_target_2; }
	inline RuntimeObject ** get_address_of_m_target_2() { return &___m_target_2; }
	inline void set_m_target_2(RuntimeObject * value)
	{
		___m_target_2 = value;
		Il2CppCodeGenWriteBarrier((&___m_target_2), value);
	}

	inline static int32_t get_offset_of_method_3() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_3)); }
	inline intptr_t get_method_3() const { return ___method_3; }
	inline intptr_t* get_address_of_method_3() { return &___method_3; }
	inline void set_method_3(intptr_t value)
	{
		___method_3 = value;
	}

	inline static int32_t get_offset_of_delegate_trampoline_4() { return static_cast<int32_t>(offsetof(Delegate_t, ___delegate_trampoline_4)); }
	inline intptr_t get_delegate_trampoline_4() const { return ___delegate_trampoline_4; }
	inline intptr_t* get_address_of_delegate_trampoline_4() { return &___delegate_trampoline_4; }
	inline void set_delegate_trampoline_4(intptr_t value)
	{
		___delegate_trampoline_4 = value;
	}

	inline static int32_t get_offset_of_extra_arg_5() { return static_cast<int32_t>(offsetof(Delegate_t, ___extra_arg_5)); }
	inline intptr_t get_extra_arg_5() const { return ___extra_arg_5; }
	inline intptr_t* get_address_of_extra_arg_5() { return &___extra_arg_5; }
	inline void set_extra_arg_5(intptr_t value)
	{
		___extra_arg_5 = value;
	}

	inline static int32_t get_offset_of_method_code_6() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_code_6)); }
	inline intptr_t get_method_code_6() const { return ___method_code_6; }
	inline intptr_t* get_address_of_method_code_6() { return &___method_code_6; }
	inline void set_method_code_6(intptr_t value)
	{
		___method_code_6 = value;
	}

	inline static int32_t get_offset_of_method_info_7() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_info_7)); }
	inline MethodInfo_t * get_method_info_7() const { return ___method_info_7; }
	inline MethodInfo_t ** get_address_of_method_info_7() { return &___method_info_7; }
	inline void set_method_info_7(MethodInfo_t * value)
	{
		___method_info_7 = value;
		Il2CppCodeGenWriteBarrier((&___method_info_7), value);
	}

	inline static int32_t get_offset_of_original_method_info_8() { return static_cast<int32_t>(offsetof(Delegate_t, ___original_method_info_8)); }
	inline MethodInfo_t * get_original_method_info_8() const { return ___original_method_info_8; }
	inline MethodInfo_t ** get_address_of_original_method_info_8() { return &___original_method_info_8; }
	inline void set_original_method_info_8(MethodInfo_t * value)
	{
		___original_method_info_8 = value;
		Il2CppCodeGenWriteBarrier((&___original_method_info_8), value);
	}

	inline static int32_t get_offset_of_data_9() { return static_cast<int32_t>(offsetof(Delegate_t, ___data_9)); }
	inline DelegateData_t1BF9F691B56DAE5F8C28C5E084FDE94F15F27BBE * get_data_9() const { return ___data_9; }
	inline DelegateData_t1BF9F691B56DAE5F8C28C5E084FDE94F15F27BBE ** get_address_of_data_9() { return &___data_9; }
	inline void set_data_9(DelegateData_t1BF9F691B56DAE5F8C28C5E084FDE94F15F27BBE * value)
	{
		___data_9 = value;
		Il2CppCodeGenWriteBarrier((&___data_9), value);
	}

	inline static int32_t get_offset_of_method_is_virtual_10() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_is_virtual_10)); }
	inline bool get_method_is_virtual_10() const { return ___method_is_virtual_10; }
	inline bool* get_address_of_method_is_virtual_10() { return &___method_is_virtual_10; }
	inline void set_method_is_virtual_10(bool value)
	{
		___method_is_virtual_10 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.Delegate
struct Delegate_t_marshaled_pinvoke
{
	intptr_t ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	Il2CppIUnknown* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	MethodInfo_t * ___method_info_7;
	MethodInfo_t * ___original_method_info_8;
	DelegateData_t1BF9F691B56DAE5F8C28C5E084FDE94F15F27BBE * ___data_9;
	int32_t ___method_is_virtual_10;
};
// Native definition for COM marshalling of System.Delegate
struct Delegate_t_marshaled_com
{
	intptr_t ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	Il2CppIUnknown* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	MethodInfo_t * ___method_info_7;
	MethodInfo_t * ___original_method_info_8;
	DelegateData_t1BF9F691B56DAE5F8C28C5E084FDE94F15F27BBE * ___data_9;
	int32_t ___method_is_virtual_10;
};
#endif // DELEGATE_T_H
#ifndef INVALIDOPERATIONEXCEPTION_T0530E734D823F78310CAFAFA424CA5164D93A1F1_H
#define INVALIDOPERATIONEXCEPTION_T0530E734D823F78310CAFAFA424CA5164D93A1F1_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.InvalidOperationException
struct  InvalidOperationException_t0530E734D823F78310CAFAFA424CA5164D93A1F1  : public SystemException_t5380468142AA850BE4A341D7AF3EAB9C78746782
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // INVALIDOPERATIONEXCEPTION_T0530E734D823F78310CAFAFA424CA5164D93A1F1_H
#ifndef NOTIMPLEMENTEDEXCEPTION_T8AD6EBE5FEDB0AEBECEE0961CF73C35B372EFFA4_H
#define NOTIMPLEMENTEDEXCEPTION_T8AD6EBE5FEDB0AEBECEE0961CF73C35B372EFFA4_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.NotImplementedException
struct  NotImplementedException_t8AD6EBE5FEDB0AEBECEE0961CF73C35B372EFFA4  : public SystemException_t5380468142AA850BE4A341D7AF3EAB9C78746782
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // NOTIMPLEMENTEDEXCEPTION_T8AD6EBE5FEDB0AEBECEE0961CF73C35B372EFFA4_H
#ifndef STREAMINGCONTEXTSTATES_T6D16CD7BC584A66A29B702F5FD59DF62BB1BDD3F_H
#define STREAMINGCONTEXTSTATES_T6D16CD7BC584A66A29B702F5FD59DF62BB1BDD3F_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Runtime.Serialization.StreamingContextStates
struct  StreamingContextStates_t6D16CD7BC584A66A29B702F5FD59DF62BB1BDD3F 
{
public:
	// System.Int32 System.Runtime.Serialization.StreamingContextStates::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(StreamingContextStates_t6D16CD7BC584A66A29B702F5FD59DF62BB1BDD3F, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // STREAMINGCONTEXTSTATES_T6D16CD7BC584A66A29B702F5FD59DF62BB1BDD3F_H
#ifndef WAITHANDLE_TFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6_H
#define WAITHANDLE_TFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Threading.WaitHandle
struct  WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6  : public MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF
{
public:
	// System.IntPtr System.Threading.WaitHandle::waitHandle
	intptr_t ___waitHandle_3;
	// Microsoft.Win32.SafeHandles.SafeWaitHandle modreq(System.Runtime.CompilerServices.IsVolatile) System.Threading.WaitHandle::safeWaitHandle
	SafeWaitHandle_t51DB35FF382E636FF3B868D87816733894D46CF2 * ___safeWaitHandle_4;
	// System.Boolean System.Threading.WaitHandle::hasThreadAffinity
	bool ___hasThreadAffinity_5;

public:
	inline static int32_t get_offset_of_waitHandle_3() { return static_cast<int32_t>(offsetof(WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6, ___waitHandle_3)); }
	inline intptr_t get_waitHandle_3() const { return ___waitHandle_3; }
	inline intptr_t* get_address_of_waitHandle_3() { return &___waitHandle_3; }
	inline void set_waitHandle_3(intptr_t value)
	{
		___waitHandle_3 = value;
	}

	inline static int32_t get_offset_of_safeWaitHandle_4() { return static_cast<int32_t>(offsetof(WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6, ___safeWaitHandle_4)); }
	inline SafeWaitHandle_t51DB35FF382E636FF3B868D87816733894D46CF2 * get_safeWaitHandle_4() const { return ___safeWaitHandle_4; }
	inline SafeWaitHandle_t51DB35FF382E636FF3B868D87816733894D46CF2 ** get_address_of_safeWaitHandle_4() { return &___safeWaitHandle_4; }
	inline void set_safeWaitHandle_4(SafeWaitHandle_t51DB35FF382E636FF3B868D87816733894D46CF2 * value)
	{
		___safeWaitHandle_4 = value;
		Il2CppCodeGenWriteBarrier((&___safeWaitHandle_4), value);
	}

	inline static int32_t get_offset_of_hasThreadAffinity_5() { return static_cast<int32_t>(offsetof(WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6, ___hasThreadAffinity_5)); }
	inline bool get_hasThreadAffinity_5() const { return ___hasThreadAffinity_5; }
	inline bool* get_address_of_hasThreadAffinity_5() { return &___hasThreadAffinity_5; }
	inline void set_hasThreadAffinity_5(bool value)
	{
		___hasThreadAffinity_5 = value;
	}
};

struct WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6_StaticFields
{
public:
	// System.IntPtr System.Threading.WaitHandle::InvalidHandle
	intptr_t ___InvalidHandle_10;

public:
	inline static int32_t get_offset_of_InvalidHandle_10() { return static_cast<int32_t>(offsetof(WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6_StaticFields, ___InvalidHandle_10)); }
	inline intptr_t get_InvalidHandle_10() const { return ___InvalidHandle_10; }
	inline intptr_t* get_address_of_InvalidHandle_10() { return &___InvalidHandle_10; }
	inline void set_InvalidHandle_10(intptr_t value)
	{
		___InvalidHandle_10 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.Threading.WaitHandle
struct WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6_marshaled_pinvoke : public MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF_marshaled_pinvoke
{
	intptr_t ___waitHandle_3;
	void* ___safeWaitHandle_4;
	int32_t ___hasThreadAffinity_5;
};
// Native definition for COM marshalling of System.Threading.WaitHandle
struct WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6_marshaled_com : public MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF_marshaled_com
{
	intptr_t ___waitHandle_3;
	void* ___safeWaitHandle_4;
	int32_t ___hasThreadAffinity_5;
};
#endif // WAITHANDLE_TFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6_H
#ifndef TIMESPAN_TA8069278ACE8A74D6DF7D514A9CD4432433F64C4_H
#define TIMESPAN_TA8069278ACE8A74D6DF7D514A9CD4432433F64C4_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.TimeSpan
struct  TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4 
{
public:
	// System.Int64 System.TimeSpan::_ticks
	int64_t ____ticks_22;

public:
	inline static int32_t get_offset_of__ticks_22() { return static_cast<int32_t>(offsetof(TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4, ____ticks_22)); }
	inline int64_t get__ticks_22() const { return ____ticks_22; }
	inline int64_t* get_address_of__ticks_22() { return &____ticks_22; }
	inline void set__ticks_22(int64_t value)
	{
		____ticks_22 = value;
	}
};

struct TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4_StaticFields
{
public:
	// System.TimeSpan System.TimeSpan::Zero
	TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  ___Zero_19;
	// System.TimeSpan System.TimeSpan::MaxValue
	TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  ___MaxValue_20;
	// System.TimeSpan System.TimeSpan::MinValue
	TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  ___MinValue_21;
	// System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile) System.TimeSpan::_legacyConfigChecked
	bool ____legacyConfigChecked_23;
	// System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile) System.TimeSpan::_legacyMode
	bool ____legacyMode_24;

public:
	inline static int32_t get_offset_of_Zero_19() { return static_cast<int32_t>(offsetof(TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4_StaticFields, ___Zero_19)); }
	inline TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  get_Zero_19() const { return ___Zero_19; }
	inline TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4 * get_address_of_Zero_19() { return &___Zero_19; }
	inline void set_Zero_19(TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  value)
	{
		___Zero_19 = value;
	}

	inline static int32_t get_offset_of_MaxValue_20() { return static_cast<int32_t>(offsetof(TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4_StaticFields, ___MaxValue_20)); }
	inline TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  get_MaxValue_20() const { return ___MaxValue_20; }
	inline TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4 * get_address_of_MaxValue_20() { return &___MaxValue_20; }
	inline void set_MaxValue_20(TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  value)
	{
		___MaxValue_20 = value;
	}

	inline static int32_t get_offset_of_MinValue_21() { return static_cast<int32_t>(offsetof(TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4_StaticFields, ___MinValue_21)); }
	inline TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  get_MinValue_21() const { return ___MinValue_21; }
	inline TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4 * get_address_of_MinValue_21() { return &___MinValue_21; }
	inline void set_MinValue_21(TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  value)
	{
		___MinValue_21 = value;
	}

	inline static int32_t get_offset_of__legacyConfigChecked_23() { return static_cast<int32_t>(offsetof(TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4_StaticFields, ____legacyConfigChecked_23)); }
	inline bool get__legacyConfigChecked_23() const { return ____legacyConfigChecked_23; }
	inline bool* get_address_of__legacyConfigChecked_23() { return &____legacyConfigChecked_23; }
	inline void set__legacyConfigChecked_23(bool value)
	{
		____legacyConfigChecked_23 = value;
	}

	inline static int32_t get_offset_of__legacyMode_24() { return static_cast<int32_t>(offsetof(TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4_StaticFields, ____legacyMode_24)); }
	inline bool get__legacyMode_24() const { return ____legacyMode_24; }
	inline bool* get_address_of__legacyMode_24() { return &____legacyMode_24; }
	inline void set__legacyMode_24(bool value)
	{
		____legacyMode_24 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TIMESPAN_TA8069278ACE8A74D6DF7D514A9CD4432433F64C4_H
#ifndef TIMEOUTEXCEPTION_T15A6E9A2A5819966712B5CFAF756BAEA40E3B1B7_H
#define TIMEOUTEXCEPTION_T15A6E9A2A5819966712B5CFAF756BAEA40E3B1B7_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.TimeoutException
struct  TimeoutException_t15A6E9A2A5819966712B5CFAF756BAEA40E3B1B7  : public SystemException_t5380468142AA850BE4A341D7AF3EAB9C78746782
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TIMEOUTEXCEPTION_T15A6E9A2A5819966712B5CFAF756BAEA40E3B1B7_H
#ifndef ENLISTMENTOPTIONS_TBA1332713E2952C8813E622DFD3584C5E8271420_H
#define ENLISTMENTOPTIONS_TBA1332713E2952C8813E622DFD3584C5E8271420_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Transactions.EnlistmentOptions
struct  EnlistmentOptions_tBA1332713E2952C8813E622DFD3584C5E8271420 
{
public:
	// System.Int32 System.Transactions.EnlistmentOptions::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(EnlistmentOptions_tBA1332713E2952C8813E622DFD3584C5E8271420, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ENLISTMENTOPTIONS_TBA1332713E2952C8813E622DFD3584C5E8271420_H
#ifndef ISOLATIONLEVEL_T0841B742C09D590657AB7AF50A4BB846F82F4493_H
#define ISOLATIONLEVEL_T0841B742C09D590657AB7AF50A4BB846F82F4493_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Transactions.IsolationLevel
struct  IsolationLevel_t0841B742C09D590657AB7AF50A4BB846F82F4493 
{
public:
	// System.Int32 System.Transactions.IsolationLevel::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(IsolationLevel_t0841B742C09D590657AB7AF50A4BB846F82F4493, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ISOLATIONLEVEL_T0841B742C09D590657AB7AF50A4BB846F82F4493_H
#ifndef TRANSACTIONEXCEPTION_TC34049F157BD87E4259E78D5F78FFC6FA0774658_H
#define TRANSACTIONEXCEPTION_TC34049F157BD87E4259E78D5F78FFC6FA0774658_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Transactions.TransactionException
struct  TransactionException_tC34049F157BD87E4259E78D5F78FFC6FA0774658  : public SystemException_t5380468142AA850BE4A341D7AF3EAB9C78746782
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TRANSACTIONEXCEPTION_TC34049F157BD87E4259E78D5F78FFC6FA0774658_H
#ifndef TRANSACTIONSTATUS_T947D8AE4FB9E9EEA76325965A8F894E553893D4F_H
#define TRANSACTIONSTATUS_T947D8AE4FB9E9EEA76325965A8F894E553893D4F_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Transactions.TransactionStatus
struct  TransactionStatus_t947D8AE4FB9E9EEA76325965A8F894E553893D4F 
{
public:
	// System.Int32 System.Transactions.TransactionStatus::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(TransactionStatus_t947D8AE4FB9E9EEA76325965A8F894E553893D4F, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TRANSACTIONSTATUS_T947D8AE4FB9E9EEA76325965A8F894E553893D4F_H
#ifndef MULTICASTDELEGATE_T_H
#define MULTICASTDELEGATE_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.MulticastDelegate
struct  MulticastDelegate_t  : public Delegate_t
{
public:
	// System.Delegate[] System.MulticastDelegate::delegates
	DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86* ___delegates_11;

public:
	inline static int32_t get_offset_of_delegates_11() { return static_cast<int32_t>(offsetof(MulticastDelegate_t, ___delegates_11)); }
	inline DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86* get_delegates_11() const { return ___delegates_11; }
	inline DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86** get_address_of_delegates_11() { return &___delegates_11; }
	inline void set_delegates_11(DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86* value)
	{
		___delegates_11 = value;
		Il2CppCodeGenWriteBarrier((&___delegates_11), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.MulticastDelegate
struct MulticastDelegate_t_marshaled_pinvoke : public Delegate_t_marshaled_pinvoke
{
	Delegate_t_marshaled_pinvoke** ___delegates_11;
};
// Native definition for COM marshalling of System.MulticastDelegate
struct MulticastDelegate_t_marshaled_com : public Delegate_t_marshaled_com
{
	Delegate_t_marshaled_com** ___delegates_11;
};
#endif // MULTICASTDELEGATE_T_H
#ifndef STREAMINGCONTEXT_T2CCDC54E0E8D078AF4A50E3A8B921B828A900034_H
#define STREAMINGCONTEXT_T2CCDC54E0E8D078AF4A50E3A8B921B828A900034_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Runtime.Serialization.StreamingContext
struct  StreamingContext_t2CCDC54E0E8D078AF4A50E3A8B921B828A900034 
{
public:
	// System.Object System.Runtime.Serialization.StreamingContext::m_additionalContext
	RuntimeObject * ___m_additionalContext_0;
	// System.Runtime.Serialization.StreamingContextStates System.Runtime.Serialization.StreamingContext::m_state
	int32_t ___m_state_1;

public:
	inline static int32_t get_offset_of_m_additionalContext_0() { return static_cast<int32_t>(offsetof(StreamingContext_t2CCDC54E0E8D078AF4A50E3A8B921B828A900034, ___m_additionalContext_0)); }
	inline RuntimeObject * get_m_additionalContext_0() const { return ___m_additionalContext_0; }
	inline RuntimeObject ** get_address_of_m_additionalContext_0() { return &___m_additionalContext_0; }
	inline void set_m_additionalContext_0(RuntimeObject * value)
	{
		___m_additionalContext_0 = value;
		Il2CppCodeGenWriteBarrier((&___m_additionalContext_0), value);
	}

	inline static int32_t get_offset_of_m_state_1() { return static_cast<int32_t>(offsetof(StreamingContext_t2CCDC54E0E8D078AF4A50E3A8B921B828A900034, ___m_state_1)); }
	inline int32_t get_m_state_1() const { return ___m_state_1; }
	inline int32_t* get_address_of_m_state_1() { return &___m_state_1; }
	inline void set_m_state_1(int32_t value)
	{
		___m_state_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.Runtime.Serialization.StreamingContext
struct StreamingContext_t2CCDC54E0E8D078AF4A50E3A8B921B828A900034_marshaled_pinvoke
{
	Il2CppIUnknown* ___m_additionalContext_0;
	int32_t ___m_state_1;
};
// Native definition for COM marshalling of System.Runtime.Serialization.StreamingContext
struct StreamingContext_t2CCDC54E0E8D078AF4A50E3A8B921B828A900034_marshaled_com
{
	Il2CppIUnknown* ___m_additionalContext_0;
	int32_t ___m_state_1;
};
#endif // STREAMINGCONTEXT_T2CCDC54E0E8D078AF4A50E3A8B921B828A900034_H
#ifndef EVENTWAITHANDLE_T7603BF1D3D30FE42DD07A450C8D09E2684DC4D98_H
#define EVENTWAITHANDLE_T7603BF1D3D30FE42DD07A450C8D09E2684DC4D98_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Threading.EventWaitHandle
struct  EventWaitHandle_t7603BF1D3D30FE42DD07A450C8D09E2684DC4D98  : public WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // EVENTWAITHANDLE_T7603BF1D3D30FE42DD07A450C8D09E2684DC4D98_H
#ifndef TRANSACTION_TCE6846BE0210EDE818811BF23767BC3798241D10_H
#define TRANSACTION_TCE6846BE0210EDE818811BF23767BC3798241D10_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Transactions.Transaction
struct  Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10  : public RuntimeObject
{
public:
	// System.Transactions.IsolationLevel System.Transactions.Transaction::level
	int32_t ___level_1;
	// System.Transactions.TransactionInformation System.Transactions.Transaction::info
	TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7 * ___info_2;
	// System.Collections.ArrayList System.Transactions.Transaction::dependents
	ArrayList_t4131E0C29C7E1B9BC9DFE37BEC41A5EB1481ADF4 * ___dependents_3;
	// System.Collections.Generic.List`1<System.Transactions.IEnlistmentNotification> System.Transactions.Transaction::volatiles
	List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 * ___volatiles_4;
	// System.Collections.Generic.List`1<System.Transactions.ISinglePhaseNotification> System.Transactions.Transaction::durables
	List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84 * ___durables_5;
	// System.Transactions.IPromotableSinglePhaseNotification System.Transactions.Transaction::pspe
	RuntimeObject* ___pspe_6;
	// System.Boolean System.Transactions.Transaction::committing
	bool ___committing_7;
	// System.Boolean System.Transactions.Transaction::committed
	bool ___committed_8;
	// System.Boolean System.Transactions.Transaction::aborted
	bool ___aborted_9;
	// System.Transactions.TransactionScope System.Transactions.Transaction::scope
	TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 * ___scope_10;
	// System.Exception System.Transactions.Transaction::innerException
	Exception_t * ___innerException_11;
	// System.Guid System.Transactions.Transaction::tag
	Guid_t  ___tag_12;
	// System.Transactions.TransactionCompletedEventHandler System.Transactions.Transaction::TransactionCompleted
	TransactionCompletedEventHandler_t57EB4B1B2B3FE844563C580C04E6257A58CA5B6D * ___TransactionCompleted_13;

public:
	inline static int32_t get_offset_of_level_1() { return static_cast<int32_t>(offsetof(Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10, ___level_1)); }
	inline int32_t get_level_1() const { return ___level_1; }
	inline int32_t* get_address_of_level_1() { return &___level_1; }
	inline void set_level_1(int32_t value)
	{
		___level_1 = value;
	}

	inline static int32_t get_offset_of_info_2() { return static_cast<int32_t>(offsetof(Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10, ___info_2)); }
	inline TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7 * get_info_2() const { return ___info_2; }
	inline TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7 ** get_address_of_info_2() { return &___info_2; }
	inline void set_info_2(TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7 * value)
	{
		___info_2 = value;
		Il2CppCodeGenWriteBarrier((&___info_2), value);
	}

	inline static int32_t get_offset_of_dependents_3() { return static_cast<int32_t>(offsetof(Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10, ___dependents_3)); }
	inline ArrayList_t4131E0C29C7E1B9BC9DFE37BEC41A5EB1481ADF4 * get_dependents_3() const { return ___dependents_3; }
	inline ArrayList_t4131E0C29C7E1B9BC9DFE37BEC41A5EB1481ADF4 ** get_address_of_dependents_3() { return &___dependents_3; }
	inline void set_dependents_3(ArrayList_t4131E0C29C7E1B9BC9DFE37BEC41A5EB1481ADF4 * value)
	{
		___dependents_3 = value;
		Il2CppCodeGenWriteBarrier((&___dependents_3), value);
	}

	inline static int32_t get_offset_of_volatiles_4() { return static_cast<int32_t>(offsetof(Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10, ___volatiles_4)); }
	inline List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 * get_volatiles_4() const { return ___volatiles_4; }
	inline List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 ** get_address_of_volatiles_4() { return &___volatiles_4; }
	inline void set_volatiles_4(List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 * value)
	{
		___volatiles_4 = value;
		Il2CppCodeGenWriteBarrier((&___volatiles_4), value);
	}

	inline static int32_t get_offset_of_durables_5() { return static_cast<int32_t>(offsetof(Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10, ___durables_5)); }
	inline List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84 * get_durables_5() const { return ___durables_5; }
	inline List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84 ** get_address_of_durables_5() { return &___durables_5; }
	inline void set_durables_5(List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84 * value)
	{
		___durables_5 = value;
		Il2CppCodeGenWriteBarrier((&___durables_5), value);
	}

	inline static int32_t get_offset_of_pspe_6() { return static_cast<int32_t>(offsetof(Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10, ___pspe_6)); }
	inline RuntimeObject* get_pspe_6() const { return ___pspe_6; }
	inline RuntimeObject** get_address_of_pspe_6() { return &___pspe_6; }
	inline void set_pspe_6(RuntimeObject* value)
	{
		___pspe_6 = value;
		Il2CppCodeGenWriteBarrier((&___pspe_6), value);
	}

	inline static int32_t get_offset_of_committing_7() { return static_cast<int32_t>(offsetof(Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10, ___committing_7)); }
	inline bool get_committing_7() const { return ___committing_7; }
	inline bool* get_address_of_committing_7() { return &___committing_7; }
	inline void set_committing_7(bool value)
	{
		___committing_7 = value;
	}

	inline static int32_t get_offset_of_committed_8() { return static_cast<int32_t>(offsetof(Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10, ___committed_8)); }
	inline bool get_committed_8() const { return ___committed_8; }
	inline bool* get_address_of_committed_8() { return &___committed_8; }
	inline void set_committed_8(bool value)
	{
		___committed_8 = value;
	}

	inline static int32_t get_offset_of_aborted_9() { return static_cast<int32_t>(offsetof(Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10, ___aborted_9)); }
	inline bool get_aborted_9() const { return ___aborted_9; }
	inline bool* get_address_of_aborted_9() { return &___aborted_9; }
	inline void set_aborted_9(bool value)
	{
		___aborted_9 = value;
	}

	inline static int32_t get_offset_of_scope_10() { return static_cast<int32_t>(offsetof(Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10, ___scope_10)); }
	inline TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 * get_scope_10() const { return ___scope_10; }
	inline TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 ** get_address_of_scope_10() { return &___scope_10; }
	inline void set_scope_10(TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 * value)
	{
		___scope_10 = value;
		Il2CppCodeGenWriteBarrier((&___scope_10), value);
	}

	inline static int32_t get_offset_of_innerException_11() { return static_cast<int32_t>(offsetof(Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10, ___innerException_11)); }
	inline Exception_t * get_innerException_11() const { return ___innerException_11; }
	inline Exception_t ** get_address_of_innerException_11() { return &___innerException_11; }
	inline void set_innerException_11(Exception_t * value)
	{
		___innerException_11 = value;
		Il2CppCodeGenWriteBarrier((&___innerException_11), value);
	}

	inline static int32_t get_offset_of_tag_12() { return static_cast<int32_t>(offsetof(Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10, ___tag_12)); }
	inline Guid_t  get_tag_12() const { return ___tag_12; }
	inline Guid_t * get_address_of_tag_12() { return &___tag_12; }
	inline void set_tag_12(Guid_t  value)
	{
		___tag_12 = value;
	}

	inline static int32_t get_offset_of_TransactionCompleted_13() { return static_cast<int32_t>(offsetof(Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10, ___TransactionCompleted_13)); }
	inline TransactionCompletedEventHandler_t57EB4B1B2B3FE844563C580C04E6257A58CA5B6D * get_TransactionCompleted_13() const { return ___TransactionCompleted_13; }
	inline TransactionCompletedEventHandler_t57EB4B1B2B3FE844563C580C04E6257A58CA5B6D ** get_address_of_TransactionCompleted_13() { return &___TransactionCompleted_13; }
	inline void set_TransactionCompleted_13(TransactionCompletedEventHandler_t57EB4B1B2B3FE844563C580C04E6257A58CA5B6D * value)
	{
		___TransactionCompleted_13 = value;
		Il2CppCodeGenWriteBarrier((&___TransactionCompleted_13), value);
	}
};

struct Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10_ThreadStaticFields
{
public:
	// System.Transactions.Transaction System.Transactions.Transaction::ambient
	Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * ___ambient_0;

public:
	inline static int32_t get_offset_of_ambient_0() { return static_cast<int32_t>(offsetof(Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10_ThreadStaticFields, ___ambient_0)); }
	inline Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * get_ambient_0() const { return ___ambient_0; }
	inline Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 ** get_address_of_ambient_0() { return &___ambient_0; }
	inline void set_ambient_0(Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * value)
	{
		___ambient_0 = value;
		Il2CppCodeGenWriteBarrier((&___ambient_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TRANSACTION_TCE6846BE0210EDE818811BF23767BC3798241D10_H
#ifndef TRANSACTIONABORTEDEXCEPTION_TDE489364A598740F9F9D7CCEE8EC7259318F386D_H
#define TRANSACTIONABORTEDEXCEPTION_TDE489364A598740F9F9D7CCEE8EC7259318F386D_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Transactions.TransactionAbortedException
struct  TransactionAbortedException_tDE489364A598740F9F9D7CCEE8EC7259318F386D  : public TransactionException_tC34049F157BD87E4259E78D5F78FFC6FA0774658
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TRANSACTIONABORTEDEXCEPTION_TDE489364A598740F9F9D7CCEE8EC7259318F386D_H
#ifndef TRANSACTIONINFORMATION_T1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7_H
#define TRANSACTIONINFORMATION_T1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Transactions.TransactionInformation
struct  TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7  : public RuntimeObject
{
public:
	// System.String System.Transactions.TransactionInformation::local_id
	String_t* ___local_id_0;
	// System.Guid System.Transactions.TransactionInformation::dtcId
	Guid_t  ___dtcId_1;
	// System.DateTime System.Transactions.TransactionInformation::creation_time
	DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132  ___creation_time_2;
	// System.Transactions.TransactionStatus System.Transactions.TransactionInformation::status
	int32_t ___status_3;

public:
	inline static int32_t get_offset_of_local_id_0() { return static_cast<int32_t>(offsetof(TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7, ___local_id_0)); }
	inline String_t* get_local_id_0() const { return ___local_id_0; }
	inline String_t** get_address_of_local_id_0() { return &___local_id_0; }
	inline void set_local_id_0(String_t* value)
	{
		___local_id_0 = value;
		Il2CppCodeGenWriteBarrier((&___local_id_0), value);
	}

	inline static int32_t get_offset_of_dtcId_1() { return static_cast<int32_t>(offsetof(TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7, ___dtcId_1)); }
	inline Guid_t  get_dtcId_1() const { return ___dtcId_1; }
	inline Guid_t * get_address_of_dtcId_1() { return &___dtcId_1; }
	inline void set_dtcId_1(Guid_t  value)
	{
		___dtcId_1 = value;
	}

	inline static int32_t get_offset_of_creation_time_2() { return static_cast<int32_t>(offsetof(TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7, ___creation_time_2)); }
	inline DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132  get_creation_time_2() const { return ___creation_time_2; }
	inline DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132 * get_address_of_creation_time_2() { return &___creation_time_2; }
	inline void set_creation_time_2(DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132  value)
	{
		___creation_time_2 = value;
	}

	inline static int32_t get_offset_of_status_3() { return static_cast<int32_t>(offsetof(TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7, ___status_3)); }
	inline int32_t get_status_3() const { return ___status_3; }
	inline int32_t* get_address_of_status_3() { return &___status_3; }
	inline void set_status_3(int32_t value)
	{
		___status_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TRANSACTIONINFORMATION_T1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7_H
#ifndef TRANSACTIONMANAGER_T89B5F1C0446C7A1D72FEB287569D47BAB58BBB64_H
#define TRANSACTIONMANAGER_T89B5F1C0446C7A1D72FEB287569D47BAB58BBB64_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Transactions.TransactionManager
struct  TransactionManager_t89B5F1C0446C7A1D72FEB287569D47BAB58BBB64  : public RuntimeObject
{
public:

public:
};

struct TransactionManager_t89B5F1C0446C7A1D72FEB287569D47BAB58BBB64_StaticFields
{
public:
	// System.TimeSpan System.Transactions.TransactionManager::defaultTimeout
	TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  ___defaultTimeout_0;
	// System.TimeSpan System.Transactions.TransactionManager::maxTimeout
	TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  ___maxTimeout_1;

public:
	inline static int32_t get_offset_of_defaultTimeout_0() { return static_cast<int32_t>(offsetof(TransactionManager_t89B5F1C0446C7A1D72FEB287569D47BAB58BBB64_StaticFields, ___defaultTimeout_0)); }
	inline TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  get_defaultTimeout_0() const { return ___defaultTimeout_0; }
	inline TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4 * get_address_of_defaultTimeout_0() { return &___defaultTimeout_0; }
	inline void set_defaultTimeout_0(TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  value)
	{
		___defaultTimeout_0 = value;
	}

	inline static int32_t get_offset_of_maxTimeout_1() { return static_cast<int32_t>(offsetof(TransactionManager_t89B5F1C0446C7A1D72FEB287569D47BAB58BBB64_StaticFields, ___maxTimeout_1)); }
	inline TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  get_maxTimeout_1() const { return ___maxTimeout_1; }
	inline TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4 * get_address_of_maxTimeout_1() { return &___maxTimeout_1; }
	inline void set_maxTimeout_1(TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  value)
	{
		___maxTimeout_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TRANSACTIONMANAGER_T89B5F1C0446C7A1D72FEB287569D47BAB58BBB64_H
#ifndef TRANSACTIONOPTIONS_TCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F_H
#define TRANSACTIONOPTIONS_TCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Transactions.TransactionOptions
struct  TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F 
{
public:
	// System.Transactions.IsolationLevel System.Transactions.TransactionOptions::level
	int32_t ___level_0;
	// System.TimeSpan System.Transactions.TransactionOptions::timeout
	TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  ___timeout_1;

public:
	inline static int32_t get_offset_of_level_0() { return static_cast<int32_t>(offsetof(TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F, ___level_0)); }
	inline int32_t get_level_0() const { return ___level_0; }
	inline int32_t* get_address_of_level_0() { return &___level_0; }
	inline void set_level_0(int32_t value)
	{
		___level_0 = value;
	}

	inline static int32_t get_offset_of_timeout_1() { return static_cast<int32_t>(offsetof(TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F, ___timeout_1)); }
	inline TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  get_timeout_1() const { return ___timeout_1; }
	inline TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4 * get_address_of_timeout_1() { return &___timeout_1; }
	inline void set_timeout_1(TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  value)
	{
		___timeout_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TRANSACTIONOPTIONS_TCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F_H
#ifndef ASYNCCALLBACK_T3F3DA3BEDAEE81DD1D24125DF8EB30E85EE14DA4_H
#define ASYNCCALLBACK_T3F3DA3BEDAEE81DD1D24125DF8EB30E85EE14DA4_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.AsyncCallback
struct  AsyncCallback_t3F3DA3BEDAEE81DD1D24125DF8EB30E85EE14DA4  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ASYNCCALLBACK_T3F3DA3BEDAEE81DD1D24125DF8EB30E85EE14DA4_H
#ifndef MANUALRESETEVENT_TDFAF117B200ECA4CCF4FD09593F949A016D55408_H
#define MANUALRESETEVENT_TDFAF117B200ECA4CCF4FD09593F949A016D55408_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Threading.ManualResetEvent
struct  ManualResetEvent_tDFAF117B200ECA4CCF4FD09593F949A016D55408  : public EventWaitHandle_t7603BF1D3D30FE42DD07A450C8D09E2684DC4D98
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MANUALRESETEVENT_TDFAF117B200ECA4CCF4FD09593F949A016D55408_H
#ifndef WAITCALLBACK_T61C5F053CAC7A7FE923208EFA060693D7997B4EC_H
#define WAITCALLBACK_T61C5F053CAC7A7FE923208EFA060693D7997B4EC_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Threading.WaitCallback
struct  WaitCallback_t61C5F053CAC7A7FE923208EFA060693D7997B4EC  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // WAITCALLBACK_T61C5F053CAC7A7FE923208EFA060693D7997B4EC_H
#ifndef TRANSACTIONCOMPLETEDEVENTHANDLER_T57EB4B1B2B3FE844563C580C04E6257A58CA5B6D_H
#define TRANSACTIONCOMPLETEDEVENTHANDLER_T57EB4B1B2B3FE844563C580C04E6257A58CA5B6D_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Transactions.TransactionCompletedEventHandler
struct  TransactionCompletedEventHandler_t57EB4B1B2B3FE844563C580C04E6257A58CA5B6D  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TRANSACTIONCOMPLETEDEVENTHANDLER_T57EB4B1B2B3FE844563C580C04E6257A58CA5B6D_H
#ifndef TRANSACTIONSCOPE_T92F03DF5872F107284A443999A34977F918A6613_H
#define TRANSACTIONSCOPE_T92F03DF5872F107284A443999A34977F918A6613_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Transactions.TransactionScope
struct  TransactionScope_t92F03DF5872F107284A443999A34977F918A6613  : public RuntimeObject
{
public:
	// System.Transactions.Transaction System.Transactions.TransactionScope::transaction
	Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * ___transaction_1;
	// System.Transactions.Transaction System.Transactions.TransactionScope::oldTransaction
	Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * ___oldTransaction_2;
	// System.Transactions.TransactionScope System.Transactions.TransactionScope::parentScope
	TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 * ___parentScope_3;
	// System.TimeSpan System.Transactions.TransactionScope::timeout
	TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  ___timeout_4;
	// System.Int32 System.Transactions.TransactionScope::nested
	int32_t ___nested_5;
	// System.Boolean System.Transactions.TransactionScope::disposed
	bool ___disposed_6;
	// System.Boolean System.Transactions.TransactionScope::completed
	bool ___completed_7;
	// System.Boolean System.Transactions.TransactionScope::isRoot
	bool ___isRoot_8;
	// System.Boolean System.Transactions.TransactionScope::asyncFlowEnabled
	bool ___asyncFlowEnabled_9;

public:
	inline static int32_t get_offset_of_transaction_1() { return static_cast<int32_t>(offsetof(TransactionScope_t92F03DF5872F107284A443999A34977F918A6613, ___transaction_1)); }
	inline Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * get_transaction_1() const { return ___transaction_1; }
	inline Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 ** get_address_of_transaction_1() { return &___transaction_1; }
	inline void set_transaction_1(Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * value)
	{
		___transaction_1 = value;
		Il2CppCodeGenWriteBarrier((&___transaction_1), value);
	}

	inline static int32_t get_offset_of_oldTransaction_2() { return static_cast<int32_t>(offsetof(TransactionScope_t92F03DF5872F107284A443999A34977F918A6613, ___oldTransaction_2)); }
	inline Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * get_oldTransaction_2() const { return ___oldTransaction_2; }
	inline Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 ** get_address_of_oldTransaction_2() { return &___oldTransaction_2; }
	inline void set_oldTransaction_2(Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * value)
	{
		___oldTransaction_2 = value;
		Il2CppCodeGenWriteBarrier((&___oldTransaction_2), value);
	}

	inline static int32_t get_offset_of_parentScope_3() { return static_cast<int32_t>(offsetof(TransactionScope_t92F03DF5872F107284A443999A34977F918A6613, ___parentScope_3)); }
	inline TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 * get_parentScope_3() const { return ___parentScope_3; }
	inline TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 ** get_address_of_parentScope_3() { return &___parentScope_3; }
	inline void set_parentScope_3(TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 * value)
	{
		___parentScope_3 = value;
		Il2CppCodeGenWriteBarrier((&___parentScope_3), value);
	}

	inline static int32_t get_offset_of_timeout_4() { return static_cast<int32_t>(offsetof(TransactionScope_t92F03DF5872F107284A443999A34977F918A6613, ___timeout_4)); }
	inline TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  get_timeout_4() const { return ___timeout_4; }
	inline TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4 * get_address_of_timeout_4() { return &___timeout_4; }
	inline void set_timeout_4(TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  value)
	{
		___timeout_4 = value;
	}

	inline static int32_t get_offset_of_nested_5() { return static_cast<int32_t>(offsetof(TransactionScope_t92F03DF5872F107284A443999A34977F918A6613, ___nested_5)); }
	inline int32_t get_nested_5() const { return ___nested_5; }
	inline int32_t* get_address_of_nested_5() { return &___nested_5; }
	inline void set_nested_5(int32_t value)
	{
		___nested_5 = value;
	}

	inline static int32_t get_offset_of_disposed_6() { return static_cast<int32_t>(offsetof(TransactionScope_t92F03DF5872F107284A443999A34977F918A6613, ___disposed_6)); }
	inline bool get_disposed_6() const { return ___disposed_6; }
	inline bool* get_address_of_disposed_6() { return &___disposed_6; }
	inline void set_disposed_6(bool value)
	{
		___disposed_6 = value;
	}

	inline static int32_t get_offset_of_completed_7() { return static_cast<int32_t>(offsetof(TransactionScope_t92F03DF5872F107284A443999A34977F918A6613, ___completed_7)); }
	inline bool get_completed_7() const { return ___completed_7; }
	inline bool* get_address_of_completed_7() { return &___completed_7; }
	inline void set_completed_7(bool value)
	{
		___completed_7 = value;
	}

	inline static int32_t get_offset_of_isRoot_8() { return static_cast<int32_t>(offsetof(TransactionScope_t92F03DF5872F107284A443999A34977F918A6613, ___isRoot_8)); }
	inline bool get_isRoot_8() const { return ___isRoot_8; }
	inline bool* get_address_of_isRoot_8() { return &___isRoot_8; }
	inline void set_isRoot_8(bool value)
	{
		___isRoot_8 = value;
	}

	inline static int32_t get_offset_of_asyncFlowEnabled_9() { return static_cast<int32_t>(offsetof(TransactionScope_t92F03DF5872F107284A443999A34977F918A6613, ___asyncFlowEnabled_9)); }
	inline bool get_asyncFlowEnabled_9() const { return ___asyncFlowEnabled_9; }
	inline bool* get_address_of_asyncFlowEnabled_9() { return &___asyncFlowEnabled_9; }
	inline void set_asyncFlowEnabled_9(bool value)
	{
		___asyncFlowEnabled_9 = value;
	}
};

struct TransactionScope_t92F03DF5872F107284A443999A34977F918A6613_StaticFields
{
public:
	// System.Transactions.TransactionOptions System.Transactions.TransactionScope::defaultOptions
	TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F  ___defaultOptions_0;

public:
	inline static int32_t get_offset_of_defaultOptions_0() { return static_cast<int32_t>(offsetof(TransactionScope_t92F03DF5872F107284A443999A34977F918A6613_StaticFields, ___defaultOptions_0)); }
	inline TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F  get_defaultOptions_0() const { return ___defaultOptions_0; }
	inline TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F * get_address_of_defaultOptions_0() { return &___defaultOptions_0; }
	inline void set_defaultOptions_0(TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F  value)
	{
		___defaultOptions_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TRANSACTIONSCOPE_T92F03DF5872F107284A443999A34977F918A6613_H
// System.Delegate[]
struct DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) Delegate_t * m_Items[1];

public:
	inline Delegate_t * GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Delegate_t ** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Delegate_t * value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
	inline Delegate_t * GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Delegate_t ** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Delegate_t * value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
};


// System.Void System.Collections.Generic.List`1<System.Object>::.ctor()
extern "C" IL2CPP_METHOD_ATTR void List_1__ctor_mC832F1AC0F814BAEB19175F5D7972A7507508BC3_gshared (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Object>::Add(!0)
extern "C" IL2CPP_METHOD_ATTR void List_1_Add_m6930161974C7504C80F52EC379EF012387D43138_gshared (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * __this, RuntimeObject * p0, const RuntimeMethod* method);
// System.Collections.Generic.List`1/Enumerator<!0> System.Collections.Generic.List`1<System.Object>::GetEnumerator()
extern "C" IL2CPP_METHOD_ATTR Enumerator_tE0C99528D3DCE5863566CE37BD94162A4C0431CD  List_1_GetEnumerator_m52CC760E475D226A2B75048D70C4E22692F9F68D_gshared (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * __this, const RuntimeMethod* method);
// !0 System.Collections.Generic.List`1/Enumerator<System.Object>::get_Current()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * Enumerator_get_Current_mD7829C7E8CFBEDD463B15A951CDE9B90A12CC55C_gshared (Enumerator_tE0C99528D3DCE5863566CE37BD94162A4C0431CD * __this, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.List`1/Enumerator<System.Object>::MoveNext()
extern "C" IL2CPP_METHOD_ATTR bool Enumerator_MoveNext_m38B1099DDAD7EEDE2F4CDAB11C095AC784AC2E34_gshared (Enumerator_tE0C99528D3DCE5863566CE37BD94162A4C0431CD * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1/Enumerator<System.Object>::Dispose()
extern "C" IL2CPP_METHOD_ATTR void Enumerator_Dispose_m94D0DAE031619503CDA6E53C5C3CC78AF3139472_gshared (Enumerator_tE0C99528D3DCE5863566CE37BD94162A4C0431CD * __this, const RuntimeMethod* method);
// System.Int32 System.Collections.Generic.List`1<System.Object>::get_Count()
extern "C" IL2CPP_METHOD_ATTR int32_t List_1_get_Count_m507C9149FF7F83AAC72C29091E745D557DA47D22_gshared (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * __this, const RuntimeMethod* method);
// !0 System.Collections.Generic.List`1<System.Object>::get_Item(System.Int32)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * List_1_get_Item_mFDB8AD680C600072736579BBF5F38F7416396588_gshared (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * __this, int32_t p0, const RuntimeMethod* method);

// System.Void System.Attribute::.ctor()
extern "C" IL2CPP_METHOD_ATTR void Attribute__ctor_m45CAD4B01265CC84CC5A84F62EE2DBE85DE89EC0 (Attribute_tF048C13FB3C8CFCC53F82290E4A3F621089F9A74 * __this, const RuntimeMethod* method);
// System.Void System.Object::.ctor()
extern "C" IL2CPP_METHOD_ATTR void Object__ctor_m925ECA5E85CA100E3FB86A4F9E15C120E9A184C0 (RuntimeObject * __this, const RuntimeMethod* method);
// System.Void System.Transactions.Enlistment::.ctor()
extern "C" IL2CPP_METHOD_ATTR void Enlistment__ctor_mC0AAE974F224D78D51D172B49DCDFEDECDB8F63E (Enlistment_t9E19C9353D07B13F6DEA340C15D562EAE001CB2D * __this, const RuntimeMethod* method);
// System.Void System.Threading.ManualResetEvent::.ctor(System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void ManualResetEvent__ctor_m8973D9E3C622B9602641C017A33870F51D0311E1 (ManualResetEvent_tDFAF117B200ECA4CCF4FD09593F949A016D55408 * __this, bool p0, const RuntimeMethod* method);
// System.Void System.Transactions.PreparingEnlistment::ForceRollback(System.Exception)
extern "C" IL2CPP_METHOD_ATTR void PreparingEnlistment_ForceRollback_m208CADBB1497EECE47DC5E7EDD1A6AAC0683993E (PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * __this, Exception_t * ___e0, const RuntimeMethod* method);
// System.Void System.Transactions.PreparingEnlistment::Prepared()
extern "C" IL2CPP_METHOD_ATTR void PreparingEnlistment_Prepared_mACADBBE0D89BAC36C08BDDDFD0A7013DFAFBDF7B (PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * __this, const RuntimeMethod* method);
// System.Void System.Transactions.Transaction::Rollback(System.Exception,System.Object)
extern "C" IL2CPP_METHOD_ATTR void Transaction_Rollback_mFC332C9E4B355D640C92C72D18452E6502FDA19B (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, Exception_t * ___ex0, RuntimeObject * ___abortingEnlisted1, const RuntimeMethod* method);
// System.Boolean System.Threading.EventWaitHandle::Set()
extern "C" IL2CPP_METHOD_ATTR bool EventWaitHandle_Set_m7959A86A39735296FC949EC86FDA42A6CFAAB94C (EventWaitHandle_t7603BF1D3D30FE42DD07A450C8D09E2684DC4D98 * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Transactions.IEnlistmentNotification>::.ctor()
inline void List_1__ctor_mE34FEBC8BE6C0D7E894858B74958B62F10DD35B0 (List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 * __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 *, const RuntimeMethod*))List_1__ctor_mC832F1AC0F814BAEB19175F5D7972A7507508BC3_gshared)(__this, method);
}
// System.Void System.Collections.Generic.List`1<System.Transactions.ISinglePhaseNotification>::.ctor()
inline void List_1__ctor_m98B046142D9A7B5AA9759E1762DA2E78659197E8 (List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84 * __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84 *, const RuntimeMethod*))List_1__ctor_mC832F1AC0F814BAEB19175F5D7972A7507508BC3_gshared)(__this, method);
}
// System.Void System.Collections.ArrayList::.ctor()
extern "C" IL2CPP_METHOD_ATTR void ArrayList__ctor_m481FA7B37620B59B8C0434A764F5705A6ABDEAE6 (ArrayList_t4131E0C29C7E1B9BC9DFE37BEC41A5EB1481ADF4 * __this, const RuntimeMethod* method);
// System.Guid System.Guid::NewGuid()
extern "C" IL2CPP_METHOD_ATTR Guid_t  Guid_NewGuid_m541CAC23EBB140DFD3AB5B313315647E95FADB29 (const RuntimeMethod* method);
// System.Void System.Transactions.TransactionInformation::.ctor()
extern "C" IL2CPP_METHOD_ATTR void TransactionInformation__ctor_mAB9F12A2A4EB65E91503CCF9B2B9E303E38DCF45 (TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7 * __this, const RuntimeMethod* method);
// System.Void System.NotImplementedException::.ctor()
extern "C" IL2CPP_METHOD_ATTR void NotImplementedException__ctor_m8BEA657E260FC05F0C6D2C43A6E9BC08040F59C4 (NotImplementedException_t8AD6EBE5FEDB0AEBECEE0961CF73C35B372EFFA4 * __this, const RuntimeMethod* method);
// System.Void System.Transactions.Transaction::EnsureIncompleteCurrentScope()
extern "C" IL2CPP_METHOD_ATTR void Transaction_EnsureIncompleteCurrentScope_m14043E8F8E23D22ADEA7C43977CE84556591A71C (const RuntimeMethod* method);
// System.Transactions.Transaction System.Transactions.Transaction::get_CurrentInternal()
extern "C" IL2CPP_METHOD_ATTR Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * Transaction_get_CurrentInternal_mD2ADB6241C7D4AD453E70854F9917DCB38F20424 (const RuntimeMethod* method);
// System.Transactions.TransactionInformation System.Transactions.Transaction::get_TransactionInformation()
extern "C" IL2CPP_METHOD_ATTR TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7 * Transaction_get_TransactionInformation_mC82938F9BAC1997A0A59AEA426CF5CA0B2BCA9E8 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, const RuntimeMethod* method);
// System.Transactions.TransactionStatus System.Transactions.TransactionInformation::get_Status()
extern "C" IL2CPP_METHOD_ATTR int32_t TransactionInformation_get_Status_mDAAF24D2911205030F52A799B5D2D2B8CFBD4B99 (TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7 * __this, const RuntimeMethod* method);
// System.Void System.Transactions.Transaction::Rollback()
extern "C" IL2CPP_METHOD_ATTR void Transaction_Rollback_mD1E2C0BAC184FDF71F005870731C0197A61651B6 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, const RuntimeMethod* method);
// System.Transactions.Enlistment System.Transactions.Transaction::EnlistVolatileInternal(System.Transactions.IEnlistmentNotification,System.Transactions.EnlistmentOptions)
extern "C" IL2CPP_METHOD_ATTR Enlistment_t9E19C9353D07B13F6DEA340C15D562EAE001CB2D * Transaction_EnlistVolatileInternal_m2665C0DE16FD54520FF635486D348D1792F1786A (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, RuntimeObject* ___notification0, int32_t ___options1, const RuntimeMethod* method);
// System.Collections.Generic.List`1<System.Transactions.IEnlistmentNotification> System.Transactions.Transaction::get_Volatiles()
extern "C" IL2CPP_METHOD_ATTR List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 * Transaction_get_Volatiles_mE34920A5BF129E05A21659CA6A5D4B847E7EA47F (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Transactions.IEnlistmentNotification>::Add(!0)
inline void List_1_Add_m44D114DEFF088D3DCF2DC644EECD01C147953830 (List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 * __this, RuntimeObject* p0, const RuntimeMethod* method)
{
	((  void (*) (List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 *, RuntimeObject*, const RuntimeMethod*))List_1_Add_m6930161974C7504C80F52EC379EF012387D43138_gshared)(__this, p0, method);
}
// System.Boolean System.Transactions.Transaction::Equals(System.Transactions.Transaction)
extern "C" IL2CPP_METHOD_ATTR bool Transaction_Equals_m78A3B8C762024EFFE53FC4B9C8D31B7F553C518C (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * ___t0, const RuntimeMethod* method);
// System.Boolean System.Transactions.Transaction::op_Equality(System.Transactions.Transaction,System.Transactions.Transaction)
extern "C" IL2CPP_METHOD_ATTR bool Transaction_op_Equality_m3922A8F89D6B043AEC236B180B1D6CD0C6C139FA (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * ___x0, Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * ___y1, const RuntimeMethod* method);
// System.Void System.Transactions.Transaction::Rollback(System.Exception)
extern "C" IL2CPP_METHOD_ATTR void Transaction_Rollback_m037D6A82684C64157E0BDA70F934D6EAD8E3E928 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, Exception_t * ___e0, const RuntimeMethod* method);
// System.Void System.Transactions.Transaction::FireCompleted()
extern "C" IL2CPP_METHOD_ATTR void Transaction_FireCompleted_mBD57957732D7FAFF0D7A83EA5823EC6B66A10986 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, const RuntimeMethod* method);
// System.Void System.Transactions.TransactionException::.ctor(System.String)
extern "C" IL2CPP_METHOD_ATTR void TransactionException__ctor_mCB5EC250D8B6D85BC9F7BB8CD768740D1630D1B9 (TransactionException_tC34049F157BD87E4259E78D5F78FFC6FA0774658 * __this, String_t* ___message0, const RuntimeMethod* method);
// System.Void System.Transactions.SinglePhaseEnlistment::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SinglePhaseEnlistment__ctor_m4547F9A8C2F78EC950E4EFBB22724FD229499349 (SinglePhaseEnlistment_t29EFB2BAA0D8E39ABCAAE5061AF9D889DED528F6 * __this, const RuntimeMethod* method);
// System.Collections.Generic.List`1/Enumerator<!0> System.Collections.Generic.List`1<System.Transactions.IEnlistmentNotification>::GetEnumerator()
inline Enumerator_tCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD  List_1_GetEnumerator_m5ED6E47986C9AF6F4D4F7CF4C9199A2D4D887913 (List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 * __this, const RuntimeMethod* method)
{
	return ((  Enumerator_tCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD  (*) (List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 *, const RuntimeMethod*))List_1_GetEnumerator_m52CC760E475D226A2B75048D70C4E22692F9F68D_gshared)(__this, method);
}
// !0 System.Collections.Generic.List`1/Enumerator<System.Transactions.IEnlistmentNotification>::get_Current()
inline RuntimeObject* Enumerator_get_Current_m758972DF00AE225BC0EE5ACCBFE67F0E7CE7F044 (Enumerator_tCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD * __this, const RuntimeMethod* method)
{
	return ((  RuntimeObject* (*) (Enumerator_tCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD *, const RuntimeMethod*))Enumerator_get_Current_mD7829C7E8CFBEDD463B15A951CDE9B90A12CC55C_gshared)(__this, method);
}
// System.Boolean System.Collections.Generic.List`1/Enumerator<System.Transactions.IEnlistmentNotification>::MoveNext()
inline bool Enumerator_MoveNext_mE66C4E35D1F864ACAD8B530D38662885FA6E3BE8 (Enumerator_tCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD * __this, const RuntimeMethod* method)
{
	return ((  bool (*) (Enumerator_tCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD *, const RuntimeMethod*))Enumerator_MoveNext_m38B1099DDAD7EEDE2F4CDAB11C095AC784AC2E34_gshared)(__this, method);
}
// System.Void System.Collections.Generic.List`1/Enumerator<System.Transactions.IEnlistmentNotification>::Dispose()
inline void Enumerator_Dispose_m599293FC0F1D20C18A3217F0CA5B0E6075A40042 (Enumerator_tCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD * __this, const RuntimeMethod* method)
{
	((  void (*) (Enumerator_tCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD *, const RuntimeMethod*))Enumerator_Dispose_m94D0DAE031619503CDA6E53C5C3CC78AF3139472_gshared)(__this, method);
}
// System.Collections.Generic.List`1<System.Transactions.ISinglePhaseNotification> System.Transactions.Transaction::get_Durables()
extern "C" IL2CPP_METHOD_ATTR List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84 * Transaction_get_Durables_m88EA94C8F588D6154C0EA39F4B10AE78E36F0844 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, const RuntimeMethod* method);
// System.Int32 System.Collections.Generic.List`1<System.Transactions.ISinglePhaseNotification>::get_Count()
inline int32_t List_1_get_Count_mEEC95EC94015469DDE9F88D5430C55EC5B943DA3 (List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84 * __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84 *, const RuntimeMethod*))List_1_get_Count_m507C9149FF7F83AAC72C29091E745D557DA47D22_gshared)(__this, method);
}
// !0 System.Collections.Generic.List`1<System.Transactions.ISinglePhaseNotification>::get_Item(System.Int32)
inline RuntimeObject* List_1_get_Item_m98BBC5DF4A64AADB6AF47A1A864CD53D23D9C5DE (List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84 * __this, int32_t p0, const RuntimeMethod* method)
{
	return ((  RuntimeObject* (*) (List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84 *, int32_t, const RuntimeMethod*))List_1_get_Item_mFDB8AD680C600072736579BBF5F38F7416396588_gshared)(__this, p0, method);
}
// System.Void System.Transactions.Transaction::set_Aborted(System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void Transaction_set_Aborted_m023E019C637B315DF28815630466791C6AD6ADC6 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, bool ___value0, const RuntimeMethod* method);
// System.Void System.Transactions.TransactionInformation::set_Status(System.Transactions.TransactionStatus)
extern "C" IL2CPP_METHOD_ATTR void TransactionInformation_set_Status_mF2FDB0AEE416525D3A9B8507218959B0B5B11A2C (TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7 * __this, int32_t ___value0, const RuntimeMethod* method);
// System.Void System.InvalidOperationException::.ctor(System.String)
extern "C" IL2CPP_METHOD_ATTR void InvalidOperationException__ctor_m72027D5F1D513C25C05137E203EEED8FD8297706 (InvalidOperationException_t0530E734D823F78310CAFAFA424CA5164D93A1F1 * __this, String_t* p0, const RuntimeMethod* method);
// System.Void System.Transactions.Transaction::DoCommit()
extern "C" IL2CPP_METHOD_ATTR void Transaction_DoCommit_m5BD1493F18973F18506F0D79A9F8D9F676310EAB (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, const RuntimeMethod* method);
// System.Void System.Transactions.TransactionAbortedException::.ctor(System.String,System.Exception)
extern "C" IL2CPP_METHOD_ATTR void TransactionAbortedException__ctor_mCAEF35081991D70342541145306EDA99AF2C2911 (TransactionAbortedException_tDE489364A598740F9F9D7CCEE8EC7259318F386D * __this, String_t* ___message0, Exception_t * ___innerException1, const RuntimeMethod* method);
// System.Transactions.TransactionScope System.Transactions.Transaction::get_Scope()
extern "C" IL2CPP_METHOD_ATTR TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 * Transaction_get_Scope_mAE876EEA8215941994BF0AE015134665DC89AE2A (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, const RuntimeMethod* method);
// System.Void System.Transactions.Transaction::CheckAborted()
extern "C" IL2CPP_METHOD_ATTR void Transaction_CheckAborted_m1ECDF392DD73E73FD0BFB964393BDA176D6EE724 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, const RuntimeMethod* method);
// System.Int32 System.Collections.Generic.List`1<System.Transactions.IEnlistmentNotification>::get_Count()
inline int32_t List_1_get_Count_mBA184835CF46C764C3557F94597B5D9E9EDA5EA1 (List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 * __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 *, const RuntimeMethod*))List_1_get_Count_m507C9149FF7F83AAC72C29091E745D557DA47D22_gshared)(__this, method);
}
// !0 System.Collections.Generic.List`1<System.Transactions.IEnlistmentNotification>::get_Item(System.Int32)
inline RuntimeObject* List_1_get_Item_m4921DD2F4764D52107D17497D257FC1D1A1C11DB (List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 * __this, int32_t p0, const RuntimeMethod* method)
{
	return ((  RuntimeObject* (*) (List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 *, int32_t, const RuntimeMethod*))List_1_get_Item_mFDB8AD680C600072736579BBF5F38F7416396588_gshared)(__this, p0, method);
}
// System.Void System.Transactions.Transaction::DoSingleCommit(System.Transactions.ISinglePhaseNotification)
extern "C" IL2CPP_METHOD_ATTR void Transaction_DoSingleCommit_m6D603CDBD6C094779156C4092701056247D13C98 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, RuntimeObject* ___single0, const RuntimeMethod* method);
// System.Void System.Transactions.Transaction::Complete()
extern "C" IL2CPP_METHOD_ATTR void Transaction_Complete_mD42561ED6F510FFBD79E2E0F9243572FA7A64935 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, const RuntimeMethod* method);
// System.Void System.Transactions.Transaction::DoPreparePhase()
extern "C" IL2CPP_METHOD_ATTR void Transaction_DoPreparePhase_mBDC0F165B339998CEB02855953DF8FB2A9D69F54 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, const RuntimeMethod* method);
// System.Void System.Transactions.Transaction::DoSingleCommit(System.Transactions.IPromotableSinglePhaseNotification)
extern "C" IL2CPP_METHOD_ATTR void Transaction_DoSingleCommit_m4A8637DBA68B7D883D045C018BBB1C20FF4FB67C (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, RuntimeObject* ___single0, const RuntimeMethod* method);
// System.Void System.Transactions.Transaction::DoCommitPhase()
extern "C" IL2CPP_METHOD_ATTR void Transaction_DoCommitPhase_m8105329BE1D5F1FA0D676E26F8B0695ED8B427F4 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, const RuntimeMethod* method);
// System.Transactions.IEnlistmentNotification System.Transactions.PreparingEnlistment::get_EnlistmentNotification()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject* PreparingEnlistment_get_EnlistmentNotification_m64EB230CF668940A64001FC4DF9231C5645C2DBD (PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * __this, const RuntimeMethod* method);
// System.Void System.Transactions.PreparingEnlistment::set_Exception(System.Exception)
extern "C" IL2CPP_METHOD_ATTR void PreparingEnlistment_set_Exception_m3DAFAAC79B491071400082A6BB53CDD08892C2C7 (PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * __this, Exception_t * ___value0, const RuntimeMethod* method);
// System.Boolean System.Transactions.PreparingEnlistment::get_IsPrepared()
extern "C" IL2CPP_METHOD_ATTR bool PreparingEnlistment_get_IsPrepared_m17D048FB0148FFE2A2985BB9AF64250363540DF3 (PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * __this, const RuntimeMethod* method);
// System.Threading.WaitHandle System.Transactions.PreparingEnlistment::get_WaitHandle()
extern "C" IL2CPP_METHOD_ATTR WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6 * PreparingEnlistment_get_WaitHandle_m3323A8B882D2264C7ACDF9AB3242B8C9CCB6834C (PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * __this, const RuntimeMethod* method);
// System.Void System.Transactions.PreparingEnlistment::.ctor(System.Transactions.Transaction,System.Transactions.IEnlistmentNotification)
extern "C" IL2CPP_METHOD_ATTR void PreparingEnlistment__ctor_m7F5B840FEFA4D7434F7059A86E3D0FD89296C8AA (PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * __this, Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * ___tx0, RuntimeObject* ___enlisted1, const RuntimeMethod* method);
// System.Void System.Threading.WaitCallback::.ctor(System.Object,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR void WaitCallback__ctor_m375A357FD7C64F4182FD88B8276D88FE5BE75B31 (WaitCallback_t61C5F053CAC7A7FE923208EFA060693D7997B4EC * __this, RuntimeObject * p0, intptr_t p1, const RuntimeMethod* method);
// System.Boolean System.Threading.ThreadPool::QueueUserWorkItem(System.Threading.WaitCallback,System.Object)
extern "C" IL2CPP_NO_INLINE IL2CPP_METHOD_ATTR bool ThreadPool_QueueUserWorkItem_mF344DA7B44CDBE8C7163C1539D429F27E8553185 (WaitCallback_t61C5F053CAC7A7FE923208EFA060693D7997B4EC * p0, RuntimeObject * p1, const RuntimeMethod* method);
// System.TimeSpan System.Transactions.TransactionManager::get_DefaultTimeout()
extern "C" IL2CPP_METHOD_ATTR TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  TransactionManager_get_DefaultTimeout_m787C350D9D35FF5E68D4C02EB9003148180EA76B (const RuntimeMethod* method);
// System.TimeSpan System.Transactions.TransactionScope::get_Timeout()
extern "C" IL2CPP_METHOD_ATTR TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  TransactionScope_get_Timeout_m9D2CA787E003B8E3E0BC694F4EAAFB19ADC3E693 (TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 * __this, const RuntimeMethod* method);
// System.Void System.TimeoutException::.ctor(System.String)
extern "C" IL2CPP_METHOD_ATTR void TimeoutException__ctor_mF1C60F8EDC528DD4115617C3A3ED34CB20175F1A (TimeoutException_t15A6E9A2A5819966712B5CFAF756BAEA40E3B1B7 * __this, String_t* p0, const RuntimeMethod* method);
// System.Exception System.Transactions.PreparingEnlistment::get_Exception()
extern "C" IL2CPP_METHOD_ATTR Exception_t * PreparingEnlistment_get_Exception_m7439CB0F9606400650A2D7C9E7B1E0E35A35DE85 (PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * __this, const RuntimeMethod* method);
// System.Void System.Transactions.SinglePhaseEnlistment::.ctor(System.Transactions.Transaction,System.Object)
extern "C" IL2CPP_METHOD_ATTR void SinglePhaseEnlistment__ctor_m09CB7F2E784B6A1C45C385EABD8E541C0011B107 (SinglePhaseEnlistment_t29EFB2BAA0D8E39ABCAAE5061AF9D889DED528F6 * __this, Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * ___tx0, RuntimeObject * ___abortingEnlisted1, const RuntimeMethod* method);
// System.Void System.Transactions.TransactionEventArgs::.ctor(System.Transactions.Transaction)
extern "C" IL2CPP_METHOD_ATTR void TransactionEventArgs__ctor_m84DE8025880A2E98018451123AE1B2CE70467BF3 (TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 * __this, Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * ___transaction0, const RuntimeMethod* method);
// System.Void System.Transactions.TransactionCompletedEventHandler::Invoke(System.Object,System.Transactions.TransactionEventArgs)
extern "C" IL2CPP_METHOD_ATTR void TransactionCompletedEventHandler_Invoke_m73AA1D4092447CB19BA846D252EE279625CE1B8F (TransactionCompletedEventHandler_t57EB4B1B2B3FE844563C580C04E6257A58CA5B6D * __this, RuntimeObject * ___sender0, TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 * ___e1, const RuntimeMethod* method);
// System.Boolean System.Transactions.TransactionScope::get_IsComplete()
extern "C" IL2CPP_METHOD_ATTR bool TransactionScope_get_IsComplete_m435B2667F1FC8FC00F8D70F53B196EABEC2385E5 (TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 * __this, const RuntimeMethod* method);
// System.Void System.Transactions.TransactionException::.ctor()
extern "C" IL2CPP_METHOD_ATTR void TransactionException__ctor_m83205811BC7C812F5B3E223C22A9CB2FAF2853D9 (TransactionException_tC34049F157BD87E4259E78D5F78FFC6FA0774658 * __this, const RuntimeMethod* method);
// System.Void System.Transactions.TransactionException::.ctor(System.String,System.Exception)
extern "C" IL2CPP_METHOD_ATTR void TransactionException__ctor_mC3BB2AEE63D219DA15C5B0B29B8C3E155ECF180D (TransactionException_tC34049F157BD87E4259E78D5F78FFC6FA0774658 * __this, String_t* ___message0, Exception_t * ___innerException1, const RuntimeMethod* method);
// System.Void System.Transactions.TransactionException::.ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
extern "C" IL2CPP_METHOD_ATTR void TransactionException__ctor_m63FC6C5C0E08A59E83CAB09F2C9A90D83EE8B760 (TransactionException_tC34049F157BD87E4259E78D5F78FFC6FA0774658 * __this, SerializationInfo_t1BB80E9C9DEA52DBF464487234B045E2930ADA26 * ___info0, StreamingContext_t2CCDC54E0E8D078AF4A50E3A8B921B828A900034  ___context1, const RuntimeMethod* method);
// System.Void System.EventArgs::.ctor()
extern "C" IL2CPP_METHOD_ATTR void EventArgs__ctor_m3551293259861C5A78CD47689D559F828ED29DF7 (EventArgs_t8E6CA180BE0E56674C6407011A94BAF7C757352E * __this, const RuntimeMethod* method);
// System.Void System.Transactions.TransactionEventArgs::.ctor()
extern "C" IL2CPP_METHOD_ATTR void TransactionEventArgs__ctor_m6CE6078481C1D1D18D229A8DC56BC254E1573A0F (TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 * __this, const RuntimeMethod* method);
// System.Void System.SystemException::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SystemException__ctor_mEB9049B75DE1D23B0515DD294BEF0AAC7792F465 (SystemException_t5380468142AA850BE4A341D7AF3EAB9C78746782 * __this, const RuntimeMethod* method);
// System.Void System.SystemException::.ctor(System.String)
extern "C" IL2CPP_METHOD_ATTR void SystemException__ctor_mF67B7FA639B457BDFB2103D7C21C8059E806175A (SystemException_t5380468142AA850BE4A341D7AF3EAB9C78746782 * __this, String_t* p0, const RuntimeMethod* method);
// System.Void System.SystemException::.ctor(System.String,System.Exception)
extern "C" IL2CPP_METHOD_ATTR void SystemException__ctor_mA18D2EA5642C066F35CB8C965398F9A542C33B0A (SystemException_t5380468142AA850BE4A341D7AF3EAB9C78746782 * __this, String_t* p0, Exception_t * p1, const RuntimeMethod* method);
// System.Void System.SystemException::.ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
extern "C" IL2CPP_METHOD_ATTR void SystemException__ctor_mB0550111A1A8D18B697B618F811A5B20C160D949 (SystemException_t5380468142AA850BE4A341D7AF3EAB9C78746782 * __this, SerializationInfo_t1BB80E9C9DEA52DBF464487234B045E2930ADA26 * p0, StreamingContext_t2CCDC54E0E8D078AF4A50E3A8B921B828A900034  p1, const RuntimeMethod* method);
// System.DateTime System.DateTime::get_Now()
extern "C" IL2CPP_METHOD_ATTR DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132  DateTime_get_Now_mB464D30F15C97069F92C1F910DCDDC3DFCC7F7D2 (const RuntimeMethod* method);
// System.DateTime System.DateTime::ToUniversalTime()
extern "C" IL2CPP_METHOD_ATTR DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132  DateTime_ToUniversalTime_mA8B74D947E186568C55D9C6F56D59F9A3C7775B1 (DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132 * __this, const RuntimeMethod* method);
// System.String System.Guid::ToString()
extern "C" IL2CPP_METHOD_ATTR String_t* Guid_ToString_m3024AB4FA6189BC28BE77BBD6A9F55841FE190A5 (Guid_t * __this, const RuntimeMethod* method);
// System.String System.String::Concat(System.String,System.String)
extern "C" IL2CPP_METHOD_ATTR String_t* String_Concat_mB78D0094592718DA6D5DB6C712A9C225631666BE (String_t* p0, String_t* p1, const RuntimeMethod* method);
// System.Void System.TimeSpan::.ctor(System.Int32,System.Int32,System.Int32)
extern "C" IL2CPP_METHOD_ATTR void TimeSpan__ctor_m44268277AFF84DEF6CA3442907CE8116A982FB87 (TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4 * __this, int32_t p0, int32_t p1, int32_t p2, const RuntimeMethod* method);
// System.Void System.Transactions.TransactionOptions::.ctor(System.Transactions.IsolationLevel,System.TimeSpan)
extern "C" IL2CPP_METHOD_ATTR void TransactionOptions__ctor_m55CFF612EB0B67FBB7B63790EBBF57DC1F51CB95 (TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F * __this, int32_t ___level0, TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  ___timeout1, const RuntimeMethod* method);
// System.Boolean System.TimeSpan::op_Equality(System.TimeSpan,System.TimeSpan)
extern "C" IL2CPP_METHOD_ATTR bool TimeSpan_op_Equality_mEA0A4B7FDCAFA54C636292F7EB76F9A16C44096D (TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  p0, TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  p1, const RuntimeMethod* method);
// System.Boolean System.Transactions.TransactionOptions::op_Equality(System.Transactions.TransactionOptions,System.Transactions.TransactionOptions)
extern "C" IL2CPP_METHOD_ATTR bool TransactionOptions_op_Equality_m496545B47A671A5F4269611E2DCE57226A6EAFBF (TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F  ___x0, TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F  ___y1, const RuntimeMethod* method);
// System.Boolean System.Transactions.TransactionOptions::Equals(System.Object)
extern "C" IL2CPP_METHOD_ATTR bool TransactionOptions_Equals_mD61A2902A74D8512486CA4CB47BD453BE87C8CD6 (TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F * __this, RuntimeObject * ___obj0, const RuntimeMethod* method);
// System.Int32 System.TimeSpan::GetHashCode()
extern "C" IL2CPP_METHOD_ATTR int32_t TimeSpan_GetHashCode_m4FD4BD6B179EDD97650F594B0E671EC8FB1E535F (TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4 * __this, const RuntimeMethod* method);
// System.Int32 System.Transactions.TransactionOptions::GetHashCode()
extern "C" IL2CPP_METHOD_ATTR int32_t TransactionOptions_GetHashCode_mDB692B4DB9C864AA9749B31A25538F834FBCB13D (TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F * __this, const RuntimeMethod* method);
// System.Boolean System.Transactions.Transaction::op_Inequality(System.Transactions.Transaction,System.Transactions.Transaction)
extern "C" IL2CPP_METHOD_ATTR bool Transaction_op_Inequality_mB8AC9FA5FD15CC891FBAD3058A7E01FFE3797C00 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * ___x0, Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * ___y1, const RuntimeMethod* method);
// System.Void System.Transactions.Transaction::set_Scope(System.Transactions.TransactionScope)
extern "C" IL2CPP_METHOD_ATTR void Transaction_set_Scope_m7D0B5FA981676EC749DEEE0136902EDE9D6C259F (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 * ___value0, const RuntimeMethod* method);
// System.Void System.Transactions.Transaction::set_CurrentInternal(System.Transactions.Transaction)
extern "C" IL2CPP_METHOD_ATTR void Transaction_set_CurrentInternal_m1505D3EF6C939658083C98A79445D586477E99EF (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * ___value0, const RuntimeMethod* method);
// System.Void System.Transactions.Transaction::CommitInternal()
extern "C" IL2CPP_METHOD_ATTR void Transaction_CommitInternal_mBAF35E65DD83B90A5FEE1A2B5E927A4D0EA31754 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, const RuntimeMethod* method);
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void System.MonoTODOAttribute::.ctor()
extern "C" IL2CPP_METHOD_ATTR void MonoTODOAttribute__ctor_m23F73D46C33E1F800CBB7AF9F748D6503DD74224 (MonoTODOAttribute_t3C9A5765E42675DA136240D678090D792AD2B26C * __this, const RuntimeMethod* method)
{
	{
		Attribute__ctor_m45CAD4B01265CC84CC5A84F62EE2DBE85DE89EC0(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.MonoTODOAttribute::.ctor(System.String)
extern "C" IL2CPP_METHOD_ATTR void MonoTODOAttribute__ctor_mE5E6C4408C0FC069E337B984982659EFAE76A774 (MonoTODOAttribute_t3C9A5765E42675DA136240D678090D792AD2B26C * __this, String_t* ___comment0, const RuntimeMethod* method)
{
	{
		Attribute__ctor_m45CAD4B01265CC84CC5A84F62EE2DBE85DE89EC0(__this, /*hidden argument*/NULL);
		String_t* L_0 = ___comment0;
		__this->set_comment_0(L_0);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void System.Transactions.Enlistment::.ctor()
extern "C" IL2CPP_METHOD_ATTR void Enlistment__ctor_mC0AAE974F224D78D51D172B49DCDFEDECDB8F63E (Enlistment_t9E19C9353D07B13F6DEA340C15D562EAE001CB2D * __this, const RuntimeMethod* method)
{
	{
		Object__ctor_m925ECA5E85CA100E3FB86A4F9E15C120E9A184C0(__this, /*hidden argument*/NULL);
		__this->set_done_0((bool)0);
		return;
	}
}
// System.Void System.Transactions.Enlistment::Done()
extern "C" IL2CPP_METHOD_ATTR void Enlistment_Done_m85476497E51100A527513E7DA010CF82B0B9BEE4 (Enlistment_t9E19C9353D07B13F6DEA340C15D562EAE001CB2D * __this, const RuntimeMethod* method)
{
	{
		__this->set_done_0((bool)1);
		VirtActionInvoker0::Invoke(4 /* System.Void System.Transactions.Enlistment::InternalOnDone() */, __this);
		return;
	}
}
// System.Void System.Transactions.Enlistment::InternalOnDone()
extern "C" IL2CPP_METHOD_ATTR void Enlistment_InternalOnDone_mE1687154DF8761036039B2EC5CCC672C4BCC8A9F (Enlistment_t9E19C9353D07B13F6DEA340C15D562EAE001CB2D * __this, const RuntimeMethod* method)
{
	{
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void System.Transactions.PreparingEnlistment::.ctor(System.Transactions.Transaction,System.Transactions.IEnlistmentNotification)
extern "C" IL2CPP_METHOD_ATTR void PreparingEnlistment__ctor_m7F5B840FEFA4D7434F7059A86E3D0FD89296C8AA (PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * __this, Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * ___tx0, RuntimeObject* ___enlisted1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (PreparingEnlistment__ctor_m7F5B840FEFA4D7434F7059A86E3D0FD89296C8AA_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Enlistment__ctor_mC0AAE974F224D78D51D172B49DCDFEDECDB8F63E(__this, /*hidden argument*/NULL);
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_0 = ___tx0;
		__this->set_tx_2(L_0);
		RuntimeObject* L_1 = ___enlisted1;
		__this->set_enlisted_3(L_1);
		ManualResetEvent_tDFAF117B200ECA4CCF4FD09593F949A016D55408 * L_2 = (ManualResetEvent_tDFAF117B200ECA4CCF4FD09593F949A016D55408 *)il2cpp_codegen_object_new(ManualResetEvent_tDFAF117B200ECA4CCF4FD09593F949A016D55408_il2cpp_TypeInfo_var);
		ManualResetEvent__ctor_m8973D9E3C622B9602641C017A33870F51D0311E1(L_2, (bool)0, /*hidden argument*/NULL);
		__this->set_waitHandle_4(L_2);
		return;
	}
}
// System.Void System.Transactions.PreparingEnlistment::ForceRollback()
extern "C" IL2CPP_METHOD_ATTR void PreparingEnlistment_ForceRollback_m9E39E1C2F8BFD7920940473A1375C9590FC82660 (PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * __this, const RuntimeMethod* method)
{
	{
		PreparingEnlistment_ForceRollback_m208CADBB1497EECE47DC5E7EDD1A6AAC0683993E(__this, (Exception_t *)NULL, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.Transactions.PreparingEnlistment::InternalOnDone()
extern "C" IL2CPP_METHOD_ATTR void PreparingEnlistment_InternalOnDone_mA8828C2A2DB434858AC8EAD21DDC368F10F60965 (PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * __this, const RuntimeMethod* method)
{
	{
		PreparingEnlistment_Prepared_mACADBBE0D89BAC36C08BDDDFD0A7013DFAFBDF7B(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.Transactions.PreparingEnlistment::ForceRollback(System.Exception)
extern "C" IL2CPP_METHOD_ATTR void PreparingEnlistment_ForceRollback_m208CADBB1497EECE47DC5E7EDD1A6AAC0683993E (PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * __this, Exception_t * ___e0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (PreparingEnlistment_ForceRollback_m208CADBB1497EECE47DC5E7EDD1A6AAC0683993E_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_0 = __this->get_tx_2();
		Exception_t * L_1 = ___e0;
		RuntimeObject* L_2 = __this->get_enlisted_3();
		NullCheck(L_0);
		Transaction_Rollback_mFC332C9E4B355D640C92C72D18452E6502FDA19B(L_0, L_1, L_2, /*hidden argument*/NULL);
		WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6 * L_3 = __this->get_waitHandle_4();
		NullCheck(((ManualResetEvent_tDFAF117B200ECA4CCF4FD09593F949A016D55408 *)CastclassSealed((RuntimeObject*)L_3, ManualResetEvent_tDFAF117B200ECA4CCF4FD09593F949A016D55408_il2cpp_TypeInfo_var)));
		EventWaitHandle_Set_m7959A86A39735296FC949EC86FDA42A6CFAAB94C(((ManualResetEvent_tDFAF117B200ECA4CCF4FD09593F949A016D55408 *)CastclassSealed((RuntimeObject*)L_3, ManualResetEvent_tDFAF117B200ECA4CCF4FD09593F949A016D55408_il2cpp_TypeInfo_var)), /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.Transactions.PreparingEnlistment::Prepared()
extern "C" IL2CPP_METHOD_ATTR void PreparingEnlistment_Prepared_mACADBBE0D89BAC36C08BDDDFD0A7013DFAFBDF7B (PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (PreparingEnlistment_Prepared_mACADBBE0D89BAC36C08BDDDFD0A7013DFAFBDF7B_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		__this->set_prepared_1((bool)1);
		WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6 * L_0 = __this->get_waitHandle_4();
		NullCheck(((ManualResetEvent_tDFAF117B200ECA4CCF4FD09593F949A016D55408 *)CastclassSealed((RuntimeObject*)L_0, ManualResetEvent_tDFAF117B200ECA4CCF4FD09593F949A016D55408_il2cpp_TypeInfo_var)));
		EventWaitHandle_Set_m7959A86A39735296FC949EC86FDA42A6CFAAB94C(((ManualResetEvent_tDFAF117B200ECA4CCF4FD09593F949A016D55408 *)CastclassSealed((RuntimeObject*)L_0, ManualResetEvent_tDFAF117B200ECA4CCF4FD09593F949A016D55408_il2cpp_TypeInfo_var)), /*hidden argument*/NULL);
		return;
	}
}
// System.Boolean System.Transactions.PreparingEnlistment::get_IsPrepared()
extern "C" IL2CPP_METHOD_ATTR bool PreparingEnlistment_get_IsPrepared_m17D048FB0148FFE2A2985BB9AF64250363540DF3 (PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * __this, const RuntimeMethod* method)
{
	{
		bool L_0 = __this->get_prepared_1();
		return L_0;
	}
}
// System.Threading.WaitHandle System.Transactions.PreparingEnlistment::get_WaitHandle()
extern "C" IL2CPP_METHOD_ATTR WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6 * PreparingEnlistment_get_WaitHandle_m3323A8B882D2264C7ACDF9AB3242B8C9CCB6834C (PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * __this, const RuntimeMethod* method)
{
	{
		WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6 * L_0 = __this->get_waitHandle_4();
		return L_0;
	}
}
// System.Transactions.IEnlistmentNotification System.Transactions.PreparingEnlistment::get_EnlistmentNotification()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject* PreparingEnlistment_get_EnlistmentNotification_m64EB230CF668940A64001FC4DF9231C5645C2DBD (PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * __this, const RuntimeMethod* method)
{
	{
		RuntimeObject* L_0 = __this->get_enlisted_3();
		return L_0;
	}
}
// System.Exception System.Transactions.PreparingEnlistment::get_Exception()
extern "C" IL2CPP_METHOD_ATTR Exception_t * PreparingEnlistment_get_Exception_m7439CB0F9606400650A2D7C9E7B1E0E35A35DE85 (PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * __this, const RuntimeMethod* method)
{
	{
		Exception_t * L_0 = __this->get_ex_5();
		return L_0;
	}
}
// System.Void System.Transactions.PreparingEnlistment::set_Exception(System.Exception)
extern "C" IL2CPP_METHOD_ATTR void PreparingEnlistment_set_Exception_m3DAFAAC79B491071400082A6BB53CDD08892C2C7 (PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * __this, Exception_t * ___value0, const RuntimeMethod* method)
{
	{
		Exception_t * L_0 = ___value0;
		__this->set_ex_5(L_0);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void System.Transactions.SinglePhaseEnlistment::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SinglePhaseEnlistment__ctor_m4547F9A8C2F78EC950E4EFBB22724FD229499349 (SinglePhaseEnlistment_t29EFB2BAA0D8E39ABCAAE5061AF9D889DED528F6 * __this, const RuntimeMethod* method)
{
	{
		Enlistment__ctor_mC0AAE974F224D78D51D172B49DCDFEDECDB8F63E(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.Transactions.SinglePhaseEnlistment::.ctor(System.Transactions.Transaction,System.Object)
extern "C" IL2CPP_METHOD_ATTR void SinglePhaseEnlistment__ctor_m09CB7F2E784B6A1C45C385EABD8E541C0011B107 (SinglePhaseEnlistment_t29EFB2BAA0D8E39ABCAAE5061AF9D889DED528F6 * __this, Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * ___tx0, RuntimeObject * ___abortingEnlisted1, const RuntimeMethod* method)
{
	{
		Enlistment__ctor_mC0AAE974F224D78D51D172B49DCDFEDECDB8F63E(__this, /*hidden argument*/NULL);
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_0 = ___tx0;
		__this->set_tx_1(L_0);
		RuntimeObject * L_1 = ___abortingEnlisted1;
		__this->set_abortingEnlisted_2(L_1);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Collections.Generic.List`1<System.Transactions.IEnlistmentNotification> System.Transactions.Transaction::get_Volatiles()
extern "C" IL2CPP_METHOD_ATTR List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 * Transaction_get_Volatiles_mE34920A5BF129E05A21659CA6A5D4B847E7EA47F (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Transaction_get_Volatiles_mE34920A5BF129E05A21659CA6A5D4B847E7EA47F_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 * L_0 = __this->get_volatiles_4();
		if (L_0)
		{
			goto IL_0013;
		}
	}
	{
		List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 * L_1 = (List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 *)il2cpp_codegen_object_new(List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5_il2cpp_TypeInfo_var);
		List_1__ctor_mE34FEBC8BE6C0D7E894858B74958B62F10DD35B0(L_1, /*hidden argument*/List_1__ctor_mE34FEBC8BE6C0D7E894858B74958B62F10DD35B0_RuntimeMethod_var);
		__this->set_volatiles_4(L_1);
	}

IL_0013:
	{
		List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 * L_2 = __this->get_volatiles_4();
		return L_2;
	}
}
// System.Collections.Generic.List`1<System.Transactions.ISinglePhaseNotification> System.Transactions.Transaction::get_Durables()
extern "C" IL2CPP_METHOD_ATTR List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84 * Transaction_get_Durables_m88EA94C8F588D6154C0EA39F4B10AE78E36F0844 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Transaction_get_Durables_m88EA94C8F588D6154C0EA39F4B10AE78E36F0844_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84 * L_0 = __this->get_durables_5();
		if (L_0)
		{
			goto IL_0013;
		}
	}
	{
		List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84 * L_1 = (List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84 *)il2cpp_codegen_object_new(List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84_il2cpp_TypeInfo_var);
		List_1__ctor_m98B046142D9A7B5AA9759E1762DA2E78659197E8(L_1, /*hidden argument*/List_1__ctor_m98B046142D9A7B5AA9759E1762DA2E78659197E8_RuntimeMethod_var);
		__this->set_durables_5(L_1);
	}

IL_0013:
	{
		List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84 * L_2 = __this->get_durables_5();
		return L_2;
	}
}
// System.Void System.Transactions.Transaction::.ctor()
extern "C" IL2CPP_METHOD_ATTR void Transaction__ctor_mD3B0EE36CAFDB4E2D826040BDD8166787C3BD77C (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Transaction__ctor_mD3B0EE36CAFDB4E2D826040BDD8166787C3BD77C_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		ArrayList_t4131E0C29C7E1B9BC9DFE37BEC41A5EB1481ADF4 * L_0 = (ArrayList_t4131E0C29C7E1B9BC9DFE37BEC41A5EB1481ADF4 *)il2cpp_codegen_object_new(ArrayList_t4131E0C29C7E1B9BC9DFE37BEC41A5EB1481ADF4_il2cpp_TypeInfo_var);
		ArrayList__ctor_m481FA7B37620B59B8C0434A764F5705A6ABDEAE6(L_0, /*hidden argument*/NULL);
		__this->set_dependents_3(L_0);
		IL2CPP_RUNTIME_CLASS_INIT(Guid_t_il2cpp_TypeInfo_var);
		Guid_t  L_1 = Guid_NewGuid_m541CAC23EBB140DFD3AB5B313315647E95FADB29(/*hidden argument*/NULL);
		__this->set_tag_12(L_1);
		Object__ctor_m925ECA5E85CA100E3FB86A4F9E15C120E9A184C0(__this, /*hidden argument*/NULL);
		TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7 * L_2 = (TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7 *)il2cpp_codegen_object_new(TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7_il2cpp_TypeInfo_var);
		TransactionInformation__ctor_mAB9F12A2A4EB65E91503CCF9B2B9E303E38DCF45(L_2, /*hidden argument*/NULL);
		__this->set_info_2(L_2);
		__this->set_level_1(0);
		return;
	}
}
// System.Void System.Transactions.Transaction::System.Runtime.Serialization.ISerializable.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
extern "C" IL2CPP_METHOD_ATTR void Transaction_System_Runtime_Serialization_ISerializable_GetObjectData_m70E0AB7319A7701A899B80F16D6A482754CDD2CB (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, SerializationInfo_t1BB80E9C9DEA52DBF464487234B045E2930ADA26 * ___info0, StreamingContext_t2CCDC54E0E8D078AF4A50E3A8B921B828A900034  ___context1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Transaction_System_Runtime_Serialization_ISerializable_GetObjectData_m70E0AB7319A7701A899B80F16D6A482754CDD2CB_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		NotImplementedException_t8AD6EBE5FEDB0AEBECEE0961CF73C35B372EFFA4 * L_0 = (NotImplementedException_t8AD6EBE5FEDB0AEBECEE0961CF73C35B372EFFA4 *)il2cpp_codegen_object_new(NotImplementedException_t8AD6EBE5FEDB0AEBECEE0961CF73C35B372EFFA4_il2cpp_TypeInfo_var);
		NotImplementedException__ctor_m8BEA657E260FC05F0C6D2C43A6E9BC08040F59C4(L_0, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_0, NULL, Transaction_System_Runtime_Serialization_ISerializable_GetObjectData_m70E0AB7319A7701A899B80F16D6A482754CDD2CB_RuntimeMethod_var);
	}
}
// System.Transactions.Transaction System.Transactions.Transaction::get_Current()
extern "C" IL2CPP_METHOD_ATTR Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * Transaction_get_Current_m9D02CD439A38B07A3E088ED35A362A80DDF3C873 (const RuntimeMethod* method)
{
	{
		Transaction_EnsureIncompleteCurrentScope_m14043E8F8E23D22ADEA7C43977CE84556591A71C(/*hidden argument*/NULL);
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_0 = Transaction_get_CurrentInternal_mD2ADB6241C7D4AD453E70854F9917DCB38F20424(/*hidden argument*/NULL);
		return L_0;
	}
}
// System.Transactions.Transaction System.Transactions.Transaction::get_CurrentInternal()
extern "C" IL2CPP_METHOD_ATTR Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * Transaction_get_CurrentInternal_mD2ADB6241C7D4AD453E70854F9917DCB38F20424 (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Transaction_get_CurrentInternal_mD2ADB6241C7D4AD453E70854F9917DCB38F20424_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_0 = ((Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10_ThreadStaticFields*)il2cpp_codegen_get_thread_static_data(Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10_il2cpp_TypeInfo_var))->get_ambient_0();
		return L_0;
	}
}
// System.Void System.Transactions.Transaction::set_CurrentInternal(System.Transactions.Transaction)
extern "C" IL2CPP_METHOD_ATTR void Transaction_set_CurrentInternal_m1505D3EF6C939658083C98A79445D586477E99EF (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Transaction_set_CurrentInternal_m1505D3EF6C939658083C98A79445D586477E99EF_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_0 = ___value0;
		((Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10_ThreadStaticFields*)il2cpp_codegen_get_thread_static_data(Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10_il2cpp_TypeInfo_var))->set_ambient_0(L_0);
		return;
	}
}
// System.Transactions.TransactionInformation System.Transactions.Transaction::get_TransactionInformation()
extern "C" IL2CPP_METHOD_ATTR TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7 * Transaction_get_TransactionInformation_mC82938F9BAC1997A0A59AEA426CF5CA0B2BCA9E8 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, const RuntimeMethod* method)
{
	{
		Transaction_EnsureIncompleteCurrentScope_m14043E8F8E23D22ADEA7C43977CE84556591A71C(/*hidden argument*/NULL);
		TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7 * L_0 = __this->get_info_2();
		return L_0;
	}
}
// System.Void System.Transactions.Transaction::Dispose()
extern "C" IL2CPP_METHOD_ATTR void Transaction_Dispose_mB9DED428BF18A869AEC3B62EC21971625216D519 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, const RuntimeMethod* method)
{
	{
		TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7 * L_0 = Transaction_get_TransactionInformation_mC82938F9BAC1997A0A59AEA426CF5CA0B2BCA9E8(__this, /*hidden argument*/NULL);
		NullCheck(L_0);
		int32_t L_1 = TransactionInformation_get_Status_mDAAF24D2911205030F52A799B5D2D2B8CFBD4B99(L_0, /*hidden argument*/NULL);
		if (L_1)
		{
			goto IL_0013;
		}
	}
	{
		Transaction_Rollback_mD1E2C0BAC184FDF71F005870731C0197A61651B6(__this, /*hidden argument*/NULL);
	}

IL_0013:
	{
		return;
	}
}
// System.Transactions.Enlistment System.Transactions.Transaction::EnlistVolatile(System.Transactions.IEnlistmentNotification,System.Transactions.EnlistmentOptions)
extern "C" IL2CPP_METHOD_ATTR Enlistment_t9E19C9353D07B13F6DEA340C15D562EAE001CB2D * Transaction_EnlistVolatile_m7B8A88D030DA1D8A6706BE0CB0AEF09CAD7FA3C5 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, RuntimeObject* ___enlistmentNotification0, int32_t ___enlistmentOptions1, const RuntimeMethod* method)
{
	{
		RuntimeObject* L_0 = ___enlistmentNotification0;
		int32_t L_1 = ___enlistmentOptions1;
		Enlistment_t9E19C9353D07B13F6DEA340C15D562EAE001CB2D * L_2 = Transaction_EnlistVolatileInternal_m2665C0DE16FD54520FF635486D348D1792F1786A(__this, L_0, L_1, /*hidden argument*/NULL);
		return L_2;
	}
}
// System.Transactions.Enlistment System.Transactions.Transaction::EnlistVolatileInternal(System.Transactions.IEnlistmentNotification,System.Transactions.EnlistmentOptions)
extern "C" IL2CPP_METHOD_ATTR Enlistment_t9E19C9353D07B13F6DEA340C15D562EAE001CB2D * Transaction_EnlistVolatileInternal_m2665C0DE16FD54520FF635486D348D1792F1786A (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, RuntimeObject* ___notification0, int32_t ___options1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Transaction_EnlistVolatileInternal_m2665C0DE16FD54520FF635486D348D1792F1786A_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Transaction_EnsureIncompleteCurrentScope_m14043E8F8E23D22ADEA7C43977CE84556591A71C(/*hidden argument*/NULL);
		List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 * L_0 = Transaction_get_Volatiles_mE34920A5BF129E05A21659CA6A5D4B847E7EA47F(__this, /*hidden argument*/NULL);
		RuntimeObject* L_1 = ___notification0;
		NullCheck(L_0);
		List_1_Add_m44D114DEFF088D3DCF2DC644EECD01C147953830(L_0, L_1, /*hidden argument*/List_1_Add_m44D114DEFF088D3DCF2DC644EECD01C147953830_RuntimeMethod_var);
		Enlistment_t9E19C9353D07B13F6DEA340C15D562EAE001CB2D * L_2 = (Enlistment_t9E19C9353D07B13F6DEA340C15D562EAE001CB2D *)il2cpp_codegen_object_new(Enlistment_t9E19C9353D07B13F6DEA340C15D562EAE001CB2D_il2cpp_TypeInfo_var);
		Enlistment__ctor_mC0AAE974F224D78D51D172B49DCDFEDECDB8F63E(L_2, /*hidden argument*/NULL);
		return L_2;
	}
}
// System.Boolean System.Transactions.Transaction::Equals(System.Object)
extern "C" IL2CPP_METHOD_ATTR bool Transaction_Equals_mDED0B202830E07A0EEA4FCF885D97C8DD8DADA4B (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, RuntimeObject * ___obj0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Transaction_Equals_mDED0B202830E07A0EEA4FCF885D97C8DD8DADA4B_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject * L_0 = ___obj0;
		bool L_1 = Transaction_Equals_m78A3B8C762024EFFE53FC4B9C8D31B7F553C518C(__this, ((Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 *)IsInstClass((RuntimeObject*)L_0, Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10_il2cpp_TypeInfo_var)), /*hidden argument*/NULL);
		return L_1;
	}
}
// System.Boolean System.Transactions.Transaction::Equals(System.Transactions.Transaction)
extern "C" IL2CPP_METHOD_ATTR bool Transaction_Equals_m78A3B8C762024EFFE53FC4B9C8D31B7F553C518C (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * ___t0, const RuntimeMethod* method)
{
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_0 = ___t0;
		if ((!(((RuntimeObject*)(Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 *)L_0) == ((RuntimeObject*)(Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 *)__this))))
		{
			goto IL_0006;
		}
	}
	{
		return (bool)1;
	}

IL_0006:
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_1 = ___t0;
		if (L_1)
		{
			goto IL_000b;
		}
	}
	{
		return (bool)0;
	}

IL_000b:
	{
		int32_t L_2 = __this->get_level_1();
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_3 = ___t0;
		NullCheck(L_3);
		int32_t L_4 = L_3->get_level_1();
		if ((!(((uint32_t)L_2) == ((uint32_t)L_4))))
		{
			goto IL_0028;
		}
	}
	{
		TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7 * L_5 = __this->get_info_2();
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_6 = ___t0;
		NullCheck(L_6);
		TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7 * L_7 = L_6->get_info_2();
		return (bool)((((RuntimeObject*)(TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7 *)L_5) == ((RuntimeObject*)(TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7 *)L_7))? 1 : 0);
	}

IL_0028:
	{
		return (bool)0;
	}
}
// System.Boolean System.Transactions.Transaction::op_Equality(System.Transactions.Transaction,System.Transactions.Transaction)
extern "C" IL2CPP_METHOD_ATTR bool Transaction_op_Equality_m3922A8F89D6B043AEC236B180B1D6CD0C6C139FA (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * ___x0, Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * ___y1, const RuntimeMethod* method)
{
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_0 = ___x0;
		if (L_0)
		{
			goto IL_0008;
		}
	}
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_1 = ___y1;
		return (bool)((((RuntimeObject*)(Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 *)L_1) == ((RuntimeObject*)(RuntimeObject *)NULL))? 1 : 0);
	}

IL_0008:
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_2 = ___x0;
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_3 = ___y1;
		NullCheck(L_2);
		bool L_4 = Transaction_Equals_m78A3B8C762024EFFE53FC4B9C8D31B7F553C518C(L_2, L_3, /*hidden argument*/NULL);
		return L_4;
	}
}
// System.Boolean System.Transactions.Transaction::op_Inequality(System.Transactions.Transaction,System.Transactions.Transaction)
extern "C" IL2CPP_METHOD_ATTR bool Transaction_op_Inequality_mB8AC9FA5FD15CC891FBAD3058A7E01FFE3797C00 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * ___x0, Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * ___y1, const RuntimeMethod* method)
{
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_0 = ___x0;
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_1 = ___y1;
		bool L_2 = Transaction_op_Equality_m3922A8F89D6B043AEC236B180B1D6CD0C6C139FA(L_0, L_1, /*hidden argument*/NULL);
		return (bool)((((int32_t)L_2) == ((int32_t)0))? 1 : 0);
	}
}
// System.Int32 System.Transactions.Transaction::GetHashCode()
extern "C" IL2CPP_METHOD_ATTR int32_t Transaction_GetHashCode_mF2F6EB68AA43DB4A5B250884D686D6DC517B0979 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, const RuntimeMethod* method)
{
	{
		int32_t L_0 = __this->get_level_1();
		TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7 * L_1 = __this->get_info_2();
		NullCheck(L_1);
		int32_t L_2 = VirtFuncInvoker0< int32_t >::Invoke(2 /* System.Int32 System.Object::GetHashCode() */, L_1);
		ArrayList_t4131E0C29C7E1B9BC9DFE37BEC41A5EB1481ADF4 * L_3 = __this->get_dependents_3();
		NullCheck(L_3);
		int32_t L_4 = VirtFuncInvoker0< int32_t >::Invoke(2 /* System.Int32 System.Object::GetHashCode() */, L_3);
		return ((int32_t)((int32_t)((int32_t)((int32_t)L_0^(int32_t)L_2))^(int32_t)L_4));
	}
}
// System.Void System.Transactions.Transaction::Rollback()
extern "C" IL2CPP_METHOD_ATTR void Transaction_Rollback_mD1E2C0BAC184FDF71F005870731C0197A61651B6 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, const RuntimeMethod* method)
{
	{
		Transaction_Rollback_m037D6A82684C64157E0BDA70F934D6EAD8E3E928(__this, (Exception_t *)NULL, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.Transactions.Transaction::Rollback(System.Exception)
extern "C" IL2CPP_METHOD_ATTR void Transaction_Rollback_m037D6A82684C64157E0BDA70F934D6EAD8E3E928 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, Exception_t * ___e0, const RuntimeMethod* method)
{
	{
		Transaction_EnsureIncompleteCurrentScope_m14043E8F8E23D22ADEA7C43977CE84556591A71C(/*hidden argument*/NULL);
		Exception_t * L_0 = ___e0;
		Transaction_Rollback_mFC332C9E4B355D640C92C72D18452E6502FDA19B(__this, L_0, NULL, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.Transactions.Transaction::Rollback(System.Exception,System.Object)
extern "C" IL2CPP_METHOD_ATTR void Transaction_Rollback_mFC332C9E4B355D640C92C72D18452E6502FDA19B (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, Exception_t * ___ex0, RuntimeObject * ___abortingEnlisted1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Transaction_Rollback_mFC332C9E4B355D640C92C72D18452E6502FDA19B_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	SinglePhaseEnlistment_t29EFB2BAA0D8E39ABCAAE5061AF9D889DED528F6 * V_0 = NULL;
	List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84 * V_1 = NULL;
	Enumerator_tCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD  V_2;
	memset(&V_2, 0, sizeof(V_2));
	RuntimeObject* V_3 = NULL;
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	void* __leave_targets_storage = alloca(sizeof(int32_t) * 1);
	il2cpp::utils::LeaveTargetStack __leave_targets(__leave_targets_storage);
	NO_UNUSED_WARNING (__leave_targets);
	{
		bool L_0 = __this->get_aborted_9();
		if (!L_0)
		{
			goto IL_000f;
		}
	}
	{
		Transaction_FireCompleted_mBD57957732D7FAFF0D7A83EA5823EC6B66A10986(__this, /*hidden argument*/NULL);
		return;
	}

IL_000f:
	{
		TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7 * L_1 = __this->get_info_2();
		NullCheck(L_1);
		int32_t L_2 = TransactionInformation_get_Status_mDAAF24D2911205030F52A799B5D2D2B8CFBD4B99(L_1, /*hidden argument*/NULL);
		if ((!(((uint32_t)L_2) == ((uint32_t)1))))
		{
			goto IL_0028;
		}
	}
	{
		TransactionException_tC34049F157BD87E4259E78D5F78FFC6FA0774658 * L_3 = (TransactionException_tC34049F157BD87E4259E78D5F78FFC6FA0774658 *)il2cpp_codegen_object_new(TransactionException_tC34049F157BD87E4259E78D5F78FFC6FA0774658_il2cpp_TypeInfo_var);
		TransactionException__ctor_mCB5EC250D8B6D85BC9F7BB8CD768740D1630D1B9(L_3, _stringLiteralA26A5289691F94E51D2D1661F4E4AA77277610B4, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_3, NULL, Transaction_Rollback_mFC332C9E4B355D640C92C72D18452E6502FDA19B_RuntimeMethod_var);
	}

IL_0028:
	{
		Exception_t * L_4 = ___ex0;
		__this->set_innerException_11(L_4);
		SinglePhaseEnlistment_t29EFB2BAA0D8E39ABCAAE5061AF9D889DED528F6 * L_5 = (SinglePhaseEnlistment_t29EFB2BAA0D8E39ABCAAE5061AF9D889DED528F6 *)il2cpp_codegen_object_new(SinglePhaseEnlistment_t29EFB2BAA0D8E39ABCAAE5061AF9D889DED528F6_il2cpp_TypeInfo_var);
		SinglePhaseEnlistment__ctor_m4547F9A8C2F78EC950E4EFBB22724FD229499349(L_5, /*hidden argument*/NULL);
		V_0 = L_5;
		List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 * L_6 = Transaction_get_Volatiles_mE34920A5BF129E05A21659CA6A5D4B847E7EA47F(__this, /*hidden argument*/NULL);
		NullCheck(L_6);
		Enumerator_tCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD  L_7 = List_1_GetEnumerator_m5ED6E47986C9AF6F4D4F7CF4C9199A2D4D887913(L_6, /*hidden argument*/List_1_GetEnumerator_m5ED6E47986C9AF6F4D4F7CF4C9199A2D4D887913_RuntimeMethod_var);
		V_2 = L_7;
	}

IL_0041:
	try
	{ // begin try (depth: 1)
		{
			goto IL_0056;
		}

IL_0043:
		{
			RuntimeObject* L_8 = Enumerator_get_Current_m758972DF00AE225BC0EE5ACCBFE67F0E7CE7F044((Enumerator_tCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD *)(&V_2), /*hidden argument*/Enumerator_get_Current_m758972DF00AE225BC0EE5ACCBFE67F0E7CE7F044_RuntimeMethod_var);
			V_3 = L_8;
			RuntimeObject* L_9 = V_3;
			RuntimeObject * L_10 = ___abortingEnlisted1;
			if ((((RuntimeObject*)(RuntimeObject*)L_9) == ((RuntimeObject*)(RuntimeObject *)L_10)))
			{
				goto IL_0056;
			}
		}

IL_004f:
		{
			RuntimeObject* L_11 = V_3;
			SinglePhaseEnlistment_t29EFB2BAA0D8E39ABCAAE5061AF9D889DED528F6 * L_12 = V_0;
			NullCheck(L_11);
			InterfaceActionInvoker1< Enlistment_t9E19C9353D07B13F6DEA340C15D562EAE001CB2D * >::Invoke(2 /* System.Void System.Transactions.IEnlistmentNotification::Rollback(System.Transactions.Enlistment) */, IEnlistmentNotification_t16012AAA61792A55BF729AB561D7BD113C0890D4_il2cpp_TypeInfo_var, L_11, L_12);
		}

IL_0056:
		{
			bool L_13 = Enumerator_MoveNext_mE66C4E35D1F864ACAD8B530D38662885FA6E3BE8((Enumerator_tCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD *)(&V_2), /*hidden argument*/Enumerator_MoveNext_mE66C4E35D1F864ACAD8B530D38662885FA6E3BE8_RuntimeMethod_var);
			if (L_13)
			{
				goto IL_0043;
			}
		}

IL_005f:
		{
			IL2CPP_LEAVE(0x6F, FINALLY_0061);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_0061;
	}

FINALLY_0061:
	{ // begin finally (depth: 1)
		Enumerator_Dispose_m599293FC0F1D20C18A3217F0CA5B0E6075A40042((Enumerator_tCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD *)(&V_2), /*hidden argument*/Enumerator_Dispose_m599293FC0F1D20C18A3217F0CA5B0E6075A40042_RuntimeMethod_var);
		IL2CPP_END_FINALLY(97)
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(97)
	{
		IL2CPP_JUMP_TBL(0x6F, IL_006f)
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
	}

IL_006f:
	{
		List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84 * L_14 = Transaction_get_Durables_m88EA94C8F588D6154C0EA39F4B10AE78E36F0844(__this, /*hidden argument*/NULL);
		V_1 = L_14;
		List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84 * L_15 = V_1;
		NullCheck(L_15);
		int32_t L_16 = List_1_get_Count_mEEC95EC94015469DDE9F88D5430C55EC5B943DA3(L_15, /*hidden argument*/List_1_get_Count_mEEC95EC94015469DDE9F88D5430C55EC5B943DA3_RuntimeMethod_var);
		if ((((int32_t)L_16) <= ((int32_t)0)))
		{
			goto IL_0096;
		}
	}
	{
		List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84 * L_17 = V_1;
		NullCheck(L_17);
		RuntimeObject* L_18 = List_1_get_Item_m98BBC5DF4A64AADB6AF47A1A864CD53D23D9C5DE(L_17, 0, /*hidden argument*/List_1_get_Item_m98BBC5DF4A64AADB6AF47A1A864CD53D23D9C5DE_RuntimeMethod_var);
		RuntimeObject * L_19 = ___abortingEnlisted1;
		if ((((RuntimeObject*)(RuntimeObject*)L_18) == ((RuntimeObject*)(RuntimeObject *)L_19)))
		{
			goto IL_0096;
		}
	}
	{
		List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84 * L_20 = V_1;
		NullCheck(L_20);
		RuntimeObject* L_21 = List_1_get_Item_m98BBC5DF4A64AADB6AF47A1A864CD53D23D9C5DE(L_20, 0, /*hidden argument*/List_1_get_Item_m98BBC5DF4A64AADB6AF47A1A864CD53D23D9C5DE_RuntimeMethod_var);
		SinglePhaseEnlistment_t29EFB2BAA0D8E39ABCAAE5061AF9D889DED528F6 * L_22 = V_0;
		NullCheck(L_21);
		InterfaceActionInvoker1< Enlistment_t9E19C9353D07B13F6DEA340C15D562EAE001CB2D * >::Invoke(2 /* System.Void System.Transactions.IEnlistmentNotification::Rollback(System.Transactions.Enlistment) */, IEnlistmentNotification_t16012AAA61792A55BF729AB561D7BD113C0890D4_il2cpp_TypeInfo_var, L_21, L_22);
	}

IL_0096:
	{
		RuntimeObject* L_23 = __this->get_pspe_6();
		if (!L_23)
		{
			goto IL_00b3;
		}
	}
	{
		RuntimeObject* L_24 = __this->get_pspe_6();
		RuntimeObject * L_25 = ___abortingEnlisted1;
		if ((((RuntimeObject*)(RuntimeObject*)L_24) == ((RuntimeObject*)(RuntimeObject *)L_25)))
		{
			goto IL_00b3;
		}
	}
	{
		RuntimeObject* L_26 = __this->get_pspe_6();
		SinglePhaseEnlistment_t29EFB2BAA0D8E39ABCAAE5061AF9D889DED528F6 * L_27 = V_0;
		NullCheck(L_26);
		InterfaceActionInvoker1< SinglePhaseEnlistment_t29EFB2BAA0D8E39ABCAAE5061AF9D889DED528F6 * >::Invoke(0 /* System.Void System.Transactions.IPromotableSinglePhaseNotification::Rollback(System.Transactions.SinglePhaseEnlistment) */, IPromotableSinglePhaseNotification_t4E3897767FACCC747B6D0AF2750B2D42B9729492_il2cpp_TypeInfo_var, L_26, L_27);
	}

IL_00b3:
	{
		Transaction_set_Aborted_m023E019C637B315DF28815630466791C6AD6ADC6(__this, (bool)1, /*hidden argument*/NULL);
		Transaction_FireCompleted_mBD57957732D7FAFF0D7A83EA5823EC6B66A10986(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.Transactions.Transaction::set_Aborted(System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void Transaction_set_Aborted_m023E019C637B315DF28815630466791C6AD6ADC6 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, bool ___value0, const RuntimeMethod* method)
{
	{
		bool L_0 = ___value0;
		__this->set_aborted_9(L_0);
		bool L_1 = __this->get_aborted_9();
		if (!L_1)
		{
			goto IL_001b;
		}
	}
	{
		TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7 * L_2 = __this->get_info_2();
		NullCheck(L_2);
		TransactionInformation_set_Status_mF2FDB0AEE416525D3A9B8507218959B0B5B11A2C(L_2, 2, /*hidden argument*/NULL);
	}

IL_001b:
	{
		return;
	}
}
// System.Transactions.TransactionScope System.Transactions.Transaction::get_Scope()
extern "C" IL2CPP_METHOD_ATTR TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 * Transaction_get_Scope_mAE876EEA8215941994BF0AE015134665DC89AE2A (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, const RuntimeMethod* method)
{
	{
		TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 * L_0 = __this->get_scope_10();
		return L_0;
	}
}
// System.Void System.Transactions.Transaction::set_Scope(System.Transactions.TransactionScope)
extern "C" IL2CPP_METHOD_ATTR void Transaction_set_Scope_m7D0B5FA981676EC749DEEE0136902EDE9D6C259F (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 * ___value0, const RuntimeMethod* method)
{
	{
		TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 * L_0 = ___value0;
		__this->set_scope_10(L_0);
		return;
	}
}
// System.Void System.Transactions.Transaction::CommitInternal()
extern "C" IL2CPP_METHOD_ATTR void Transaction_CommitInternal_mBAF35E65DD83B90A5FEE1A2B5E927A4D0EA31754 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Transaction_CommitInternal_mBAF35E65DD83B90A5FEE1A2B5E927A4D0EA31754_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Exception_t * V_0 = NULL;
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	void* __leave_targets_storage = alloca(sizeof(int32_t) * 1);
	il2cpp::utils::LeaveTargetStack __leave_targets(__leave_targets_storage);
	NO_UNUSED_WARNING (__leave_targets);
	{
		bool L_0 = __this->get_committed_8();
		if (L_0)
		{
			goto IL_0010;
		}
	}
	{
		bool L_1 = __this->get_committing_7();
		if (!L_1)
		{
			goto IL_001b;
		}
	}

IL_0010:
	{
		InvalidOperationException_t0530E734D823F78310CAFAFA424CA5164D93A1F1 * L_2 = (InvalidOperationException_t0530E734D823F78310CAFAFA424CA5164D93A1F1 *)il2cpp_codegen_object_new(InvalidOperationException_t0530E734D823F78310CAFAFA424CA5164D93A1F1_il2cpp_TypeInfo_var);
		InvalidOperationException__ctor_m72027D5F1D513C25C05137E203EEED8FD8297706(L_2, _stringLiteral5279B4EDF19727785FA9AE748460798E8DF3A412, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_2, NULL, Transaction_CommitInternal_mBAF35E65DD83B90A5FEE1A2B5E927A4D0EA31754_RuntimeMethod_var);
	}

IL_001b:
	{
		__this->set_committing_7((bool)1);
	}

IL_0022:
	try
	{ // begin try (depth: 1)
		Transaction_DoCommit_m5BD1493F18973F18506F0D79A9F8D9F676310EAB(__this, /*hidden argument*/NULL);
		goto IL_003a;
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__exception_local = (Exception_t *)e.ex;
		if(il2cpp_codegen_class_is_assignable_from (TransactionException_tC34049F157BD87E4259E78D5F78FFC6FA0774658_il2cpp_TypeInfo_var, il2cpp_codegen_object_class(e.ex)))
			goto CATCH_002a;
		if(il2cpp_codegen_class_is_assignable_from (Exception_t_il2cpp_TypeInfo_var, il2cpp_codegen_object_class(e.ex)))
			goto CATCH_002d;
		throw e;
	}

CATCH_002a:
	{ // begin catch(System.Transactions.TransactionException)
		IL2CPP_RAISE_MANAGED_EXCEPTION(__exception_local, NULL, Transaction_CommitInternal_mBAF35E65DD83B90A5FEE1A2B5E927A4D0EA31754_RuntimeMethod_var);
	} // end catch (depth: 1)

CATCH_002d:
	{ // begin catch(System.Exception)
		V_0 = ((Exception_t *)__exception_local);
		Exception_t * L_3 = V_0;
		TransactionAbortedException_tDE489364A598740F9F9D7CCEE8EC7259318F386D * L_4 = (TransactionAbortedException_tDE489364A598740F9F9D7CCEE8EC7259318F386D *)il2cpp_codegen_object_new(TransactionAbortedException_tDE489364A598740F9F9D7CCEE8EC7259318F386D_il2cpp_TypeInfo_var);
		TransactionAbortedException__ctor_mCAEF35081991D70342541145306EDA99AF2C2911(L_4, _stringLiteral2081D19189B95B31D55BEBC4C77E0563E3FE486A, L_3, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_4, NULL, Transaction_CommitInternal_mBAF35E65DD83B90A5FEE1A2B5E927A4D0EA31754_RuntimeMethod_var);
	} // end catch (depth: 1)

IL_003a:
	{
		return;
	}
}
// System.Void System.Transactions.Transaction::DoCommit()
extern "C" IL2CPP_METHOD_ATTR void Transaction_DoCommit_m5BD1493F18973F18506F0D79A9F8D9F676310EAB (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Transaction_DoCommit_m5BD1493F18973F18506F0D79A9F8D9F676310EAB_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 * V_0 = NULL;
	List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84 * V_1 = NULL;
	RuntimeObject* V_2 = NULL;
	{
		TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 * L_0 = Transaction_get_Scope_mAE876EEA8215941994BF0AE015134665DC89AE2A(__this, /*hidden argument*/NULL);
		if (!L_0)
		{
			goto IL_0016;
		}
	}
	{
		Transaction_Rollback_mFC332C9E4B355D640C92C72D18452E6502FDA19B(__this, (Exception_t *)NULL, NULL, /*hidden argument*/NULL);
		Transaction_CheckAborted_m1ECDF392DD73E73FD0BFB964393BDA176D6EE724(__this, /*hidden argument*/NULL);
	}

IL_0016:
	{
		List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 * L_1 = Transaction_get_Volatiles_mE34920A5BF129E05A21659CA6A5D4B847E7EA47F(__this, /*hidden argument*/NULL);
		V_0 = L_1;
		List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84 * L_2 = Transaction_get_Durables_m88EA94C8F588D6154C0EA39F4B10AE78E36F0844(__this, /*hidden argument*/NULL);
		V_1 = L_2;
		List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 * L_3 = V_0;
		NullCheck(L_3);
		int32_t L_4 = List_1_get_Count_mBA184835CF46C764C3557F94597B5D9E9EDA5EA1(L_3, /*hidden argument*/List_1_get_Count_mBA184835CF46C764C3557F94597B5D9E9EDA5EA1_RuntimeMethod_var);
		if ((!(((uint32_t)L_4) == ((uint32_t)1))))
		{
			goto IL_0053;
		}
	}
	{
		List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84 * L_5 = V_1;
		NullCheck(L_5);
		int32_t L_6 = List_1_get_Count_mEEC95EC94015469DDE9F88D5430C55EC5B943DA3(L_5, /*hidden argument*/List_1_get_Count_mEEC95EC94015469DDE9F88D5430C55EC5B943DA3_RuntimeMethod_var);
		if (L_6)
		{
			goto IL_0053;
		}
	}
	{
		List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 * L_7 = V_0;
		NullCheck(L_7);
		RuntimeObject* L_8 = List_1_get_Item_m4921DD2F4764D52107D17497D257FC1D1A1C11DB(L_7, 0, /*hidden argument*/List_1_get_Item_m4921DD2F4764D52107D17497D257FC1D1A1C11DB_RuntimeMethod_var);
		V_2 = ((RuntimeObject*)IsInst((RuntimeObject*)L_8, ISinglePhaseNotification_t70B179E8BC10CE3B486A1834D28DCDCE21C095EF_il2cpp_TypeInfo_var));
		RuntimeObject* L_9 = V_2;
		if (!L_9)
		{
			goto IL_0053;
		}
	}
	{
		RuntimeObject* L_10 = V_2;
		Transaction_DoSingleCommit_m6D603CDBD6C094779156C4092701056247D13C98(__this, L_10, /*hidden argument*/NULL);
		Transaction_Complete_mD42561ED6F510FFBD79E2E0F9243572FA7A64935(__this, /*hidden argument*/NULL);
		return;
	}

IL_0053:
	{
		List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 * L_11 = V_0;
		NullCheck(L_11);
		int32_t L_12 = List_1_get_Count_mBA184835CF46C764C3557F94597B5D9E9EDA5EA1(L_11, /*hidden argument*/List_1_get_Count_mBA184835CF46C764C3557F94597B5D9E9EDA5EA1_RuntimeMethod_var);
		if ((((int32_t)L_12) <= ((int32_t)0)))
		{
			goto IL_0062;
		}
	}
	{
		Transaction_DoPreparePhase_mBDC0F165B339998CEB02855953DF8FB2A9D69F54(__this, /*hidden argument*/NULL);
	}

IL_0062:
	{
		List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84 * L_13 = V_1;
		NullCheck(L_13);
		int32_t L_14 = List_1_get_Count_mEEC95EC94015469DDE9F88D5430C55EC5B943DA3(L_13, /*hidden argument*/List_1_get_Count_mEEC95EC94015469DDE9F88D5430C55EC5B943DA3_RuntimeMethod_var);
		if ((((int32_t)L_14) <= ((int32_t)0)))
		{
			goto IL_0078;
		}
	}
	{
		List_1_tD0B07938609DB3D411C851750ADD986B40B5EB84 * L_15 = V_1;
		NullCheck(L_15);
		RuntimeObject* L_16 = List_1_get_Item_m98BBC5DF4A64AADB6AF47A1A864CD53D23D9C5DE(L_15, 0, /*hidden argument*/List_1_get_Item_m98BBC5DF4A64AADB6AF47A1A864CD53D23D9C5DE_RuntimeMethod_var);
		Transaction_DoSingleCommit_m6D603CDBD6C094779156C4092701056247D13C98(__this, L_16, /*hidden argument*/NULL);
	}

IL_0078:
	{
		RuntimeObject* L_17 = __this->get_pspe_6();
		if (!L_17)
		{
			goto IL_008c;
		}
	}
	{
		RuntimeObject* L_18 = __this->get_pspe_6();
		Transaction_DoSingleCommit_m4A8637DBA68B7D883D045C018BBB1C20FF4FB67C(__this, L_18, /*hidden argument*/NULL);
	}

IL_008c:
	{
		List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 * L_19 = V_0;
		NullCheck(L_19);
		int32_t L_20 = List_1_get_Count_mBA184835CF46C764C3557F94597B5D9E9EDA5EA1(L_19, /*hidden argument*/List_1_get_Count_mBA184835CF46C764C3557F94597B5D9E9EDA5EA1_RuntimeMethod_var);
		if ((((int32_t)L_20) <= ((int32_t)0)))
		{
			goto IL_009b;
		}
	}
	{
		Transaction_DoCommitPhase_m8105329BE1D5F1FA0D676E26F8B0695ED8B427F4(__this, /*hidden argument*/NULL);
	}

IL_009b:
	{
		Transaction_Complete_mD42561ED6F510FFBD79E2E0F9243572FA7A64935(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.Transactions.Transaction::Complete()
extern "C" IL2CPP_METHOD_ATTR void Transaction_Complete_mD42561ED6F510FFBD79E2E0F9243572FA7A64935 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, const RuntimeMethod* method)
{
	{
		__this->set_committing_7((bool)0);
		__this->set_committed_8((bool)1);
		bool L_0 = __this->get_aborted_9();
		if (L_0)
		{
			goto IL_0022;
		}
	}
	{
		TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7 * L_1 = __this->get_info_2();
		NullCheck(L_1);
		TransactionInformation_set_Status_mF2FDB0AEE416525D3A9B8507218959B0B5B11A2C(L_1, 1, /*hidden argument*/NULL);
	}

IL_0022:
	{
		Transaction_FireCompleted_mBD57957732D7FAFF0D7A83EA5823EC6B66A10986(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.Transactions.Transaction::PrepareCallbackWrapper(System.Object)
extern "C" IL2CPP_METHOD_ATTR void Transaction_PrepareCallbackWrapper_m469877B0CC5286CBF830532CF52D620435C36024 (RuntimeObject * ___state0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Transaction_PrepareCallbackWrapper_m469877B0CC5286CBF830532CF52D620435C36024_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * V_0 = NULL;
	Exception_t * V_1 = NULL;
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	void* __leave_targets_storage = alloca(sizeof(int32_t) * 2);
	il2cpp::utils::LeaveTargetStack __leave_targets(__leave_targets_storage);
	NO_UNUSED_WARNING (__leave_targets);
	{
		RuntimeObject * L_0 = ___state0;
		V_0 = ((PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 *)IsInstClass((RuntimeObject*)L_0, PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496_il2cpp_TypeInfo_var));
	}

IL_0007:
	try
	{ // begin try (depth: 1)
		PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * L_1 = V_0;
		NullCheck(L_1);
		RuntimeObject* L_2 = PreparingEnlistment_get_EnlistmentNotification_m64EB230CF668940A64001FC4DF9231C5645C2DBD(L_1, /*hidden argument*/NULL);
		PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * L_3 = V_0;
		NullCheck(L_2);
		InterfaceActionInvoker1< PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * >::Invoke(1 /* System.Void System.Transactions.IEnlistmentNotification::Prepare(System.Transactions.PreparingEnlistment) */, IEnlistmentNotification_t16012AAA61792A55BF729AB561D7BD113C0890D4_il2cpp_TypeInfo_var, L_2, L_3);
		goto IL_0038;
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__exception_local = (Exception_t *)e.ex;
		if(il2cpp_codegen_class_is_assignable_from (Exception_t_il2cpp_TypeInfo_var, il2cpp_codegen_object_class(e.ex)))
			goto CATCH_0015;
		throw e;
	}

CATCH_0015:
	{ // begin catch(System.Exception)
		{
			V_1 = ((Exception_t *)__exception_local);
			PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * L_4 = V_0;
			Exception_t * L_5 = V_1;
			NullCheck(L_4);
			PreparingEnlistment_set_Exception_m3DAFAAC79B491071400082A6BB53CDD08892C2C7(L_4, L_5, /*hidden argument*/NULL);
			PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * L_6 = V_0;
			NullCheck(L_6);
			bool L_7 = PreparingEnlistment_get_IsPrepared_m17D048FB0148FFE2A2985BB9AF64250363540DF3(L_6, /*hidden argument*/NULL);
			if (L_7)
			{
				goto IL_0036;
			}
		}

IL_0025:
		{
			PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * L_8 = V_0;
			NullCheck(L_8);
			WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6 * L_9 = PreparingEnlistment_get_WaitHandle_m3323A8B882D2264C7ACDF9AB3242B8C9CCB6834C(L_8, /*hidden argument*/NULL);
			NullCheck(((ManualResetEvent_tDFAF117B200ECA4CCF4FD09593F949A016D55408 *)CastclassSealed((RuntimeObject*)L_9, ManualResetEvent_tDFAF117B200ECA4CCF4FD09593F949A016D55408_il2cpp_TypeInfo_var)));
			EventWaitHandle_Set_m7959A86A39735296FC949EC86FDA42A6CFAAB94C(((ManualResetEvent_tDFAF117B200ECA4CCF4FD09593F949A016D55408 *)CastclassSealed((RuntimeObject*)L_9, ManualResetEvent_tDFAF117B200ECA4CCF4FD09593F949A016D55408_il2cpp_TypeInfo_var)), /*hidden argument*/NULL);
		}

IL_0036:
		{
			goto IL_0038;
		}
	} // end catch (depth: 1)

IL_0038:
	{
		return;
	}
}
// System.Void System.Transactions.Transaction::DoPreparePhase()
extern "C" IL2CPP_METHOD_ATTR void Transaction_DoPreparePhase_mBDC0F165B339998CEB02855953DF8FB2A9D69F54 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Transaction_DoPreparePhase_mBDC0F165B339998CEB02855953DF8FB2A9D69F54_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Enumerator_tCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD  V_0;
	memset(&V_0, 0, sizeof(V_0));
	RuntimeObject* V_1 = NULL;
	PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * V_2 = NULL;
	TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  V_3;
	memset(&V_3, 0, sizeof(V_3));
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	void* __leave_targets_storage = alloca(sizeof(int32_t) * 3);
	il2cpp::utils::LeaveTargetStack __leave_targets(__leave_targets_storage);
	NO_UNUSED_WARNING (__leave_targets);
	TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  G_B5_0;
	memset(&G_B5_0, 0, sizeof(G_B5_0));
	{
		List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 * L_0 = Transaction_get_Volatiles_mE34920A5BF129E05A21659CA6A5D4B847E7EA47F(__this, /*hidden argument*/NULL);
		NullCheck(L_0);
		Enumerator_tCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD  L_1 = List_1_GetEnumerator_m5ED6E47986C9AF6F4D4F7CF4C9199A2D4D887913(L_0, /*hidden argument*/List_1_GetEnumerator_m5ED6E47986C9AF6F4D4F7CF4C9199A2D4D887913_RuntimeMethod_var);
		V_0 = L_1;
	}

IL_000c:
	try
	{ // begin try (depth: 1)
		{
			goto IL_009e;
		}

IL_0011:
		{
			RuntimeObject* L_2 = Enumerator_get_Current_m758972DF00AE225BC0EE5ACCBFE67F0E7CE7F044((Enumerator_tCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD *)(&V_0), /*hidden argument*/Enumerator_get_Current_m758972DF00AE225BC0EE5ACCBFE67F0E7CE7F044_RuntimeMethod_var);
			V_1 = L_2;
			RuntimeObject* L_3 = V_1;
			PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * L_4 = (PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 *)il2cpp_codegen_object_new(PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496_il2cpp_TypeInfo_var);
			PreparingEnlistment__ctor_m7F5B840FEFA4D7434F7059A86E3D0FD89296C8AA(L_4, __this, L_3, /*hidden argument*/NULL);
			V_2 = L_4;
			WaitCallback_t61C5F053CAC7A7FE923208EFA060693D7997B4EC * L_5 = (WaitCallback_t61C5F053CAC7A7FE923208EFA060693D7997B4EC *)il2cpp_codegen_object_new(WaitCallback_t61C5F053CAC7A7FE923208EFA060693D7997B4EC_il2cpp_TypeInfo_var);
			WaitCallback__ctor_m375A357FD7C64F4182FD88B8276D88FE5BE75B31(L_5, NULL, (intptr_t)((intptr_t)Transaction_PrepareCallbackWrapper_m469877B0CC5286CBF830532CF52D620435C36024_RuntimeMethod_var), /*hidden argument*/NULL);
			PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * L_6 = V_2;
			ThreadPool_QueueUserWorkItem_mF344DA7B44CDBE8C7163C1539D429F27E8553185(L_5, L_6, /*hidden argument*/NULL);
			TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 * L_7 = Transaction_get_Scope_mAE876EEA8215941994BF0AE015134665DC89AE2A(__this, /*hidden argument*/NULL);
			if (L_7)
			{
				goto IL_0043;
			}
		}

IL_003c:
		{
			IL2CPP_RUNTIME_CLASS_INIT(TransactionManager_t89B5F1C0446C7A1D72FEB287569D47BAB58BBB64_il2cpp_TypeInfo_var);
			TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  L_8 = TransactionManager_get_DefaultTimeout_m787C350D9D35FF5E68D4C02EB9003148180EA76B(/*hidden argument*/NULL);
			G_B5_0 = L_8;
			goto IL_004e;
		}

IL_0043:
		{
			TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 * L_9 = Transaction_get_Scope_mAE876EEA8215941994BF0AE015134665DC89AE2A(__this, /*hidden argument*/NULL);
			NullCheck(L_9);
			TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  L_10 = TransactionScope_get_Timeout_m9D2CA787E003B8E3E0BC694F4EAAFB19ADC3E693(L_9, /*hidden argument*/NULL);
			G_B5_0 = L_10;
		}

IL_004e:
		{
			V_3 = G_B5_0;
			PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * L_11 = V_2;
			NullCheck(L_11);
			WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6 * L_12 = PreparingEnlistment_get_WaitHandle_m3323A8B882D2264C7ACDF9AB3242B8C9CCB6834C(L_11, /*hidden argument*/NULL);
			TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  L_13 = V_3;
			NullCheck(L_12);
			bool L_14 = VirtFuncInvoker2< bool, TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4 , bool >::Invoke(9 /* System.Boolean System.Threading.WaitHandle::WaitOne(System.TimeSpan,System.Boolean) */, L_12, L_13, (bool)1);
			if (L_14)
			{
				goto IL_0070;
			}
		}

IL_005e:
		{
			Transaction_set_Aborted_m023E019C637B315DF28815630466791C6AD6ADC6(__this, (bool)1, /*hidden argument*/NULL);
			TimeoutException_t15A6E9A2A5819966712B5CFAF756BAEA40E3B1B7 * L_15 = (TimeoutException_t15A6E9A2A5819966712B5CFAF756BAEA40E3B1B7 *)il2cpp_codegen_object_new(TimeoutException_t15A6E9A2A5819966712B5CFAF756BAEA40E3B1B7_il2cpp_TypeInfo_var);
			TimeoutException__ctor_mF1C60F8EDC528DD4115617C3A3ED34CB20175F1A(L_15, _stringLiteral49A7719DF4108BB552D6A5D1C1030CCA238E293F, /*hidden argument*/NULL);
			IL2CPP_RAISE_MANAGED_EXCEPTION(L_15, NULL, Transaction_DoPreparePhase_mBDC0F165B339998CEB02855953DF8FB2A9D69F54_RuntimeMethod_var);
		}

IL_0070:
		{
			PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * L_16 = V_2;
			NullCheck(L_16);
			Exception_t * L_17 = PreparingEnlistment_get_Exception_m7439CB0F9606400650A2D7C9E7B1E0E35A35DE85(L_16, /*hidden argument*/NULL);
			if (!L_17)
			{
				goto IL_008d;
			}
		}

IL_0078:
		{
			PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * L_18 = V_2;
			NullCheck(L_18);
			Exception_t * L_19 = PreparingEnlistment_get_Exception_m7439CB0F9606400650A2D7C9E7B1E0E35A35DE85(L_18, /*hidden argument*/NULL);
			__this->set_innerException_11(L_19);
			Transaction_set_Aborted_m023E019C637B315DF28815630466791C6AD6ADC6(__this, (bool)1, /*hidden argument*/NULL);
			IL2CPP_LEAVE(0xBA, FINALLY_00ac);
		}

IL_008d:
		{
			PreparingEnlistment_t2ADCAA14B9C7105B160E48051239A6DBEE521496 * L_20 = V_2;
			NullCheck(L_20);
			bool L_21 = PreparingEnlistment_get_IsPrepared_m17D048FB0148FFE2A2985BB9AF64250363540DF3(L_20, /*hidden argument*/NULL);
			if (L_21)
			{
				goto IL_009e;
			}
		}

IL_0095:
		{
			Transaction_set_Aborted_m023E019C637B315DF28815630466791C6AD6ADC6(__this, (bool)1, /*hidden argument*/NULL);
			IL2CPP_LEAVE(0xBA, FINALLY_00ac);
		}

IL_009e:
		{
			bool L_22 = Enumerator_MoveNext_mE66C4E35D1F864ACAD8B530D38662885FA6E3BE8((Enumerator_tCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD *)(&V_0), /*hidden argument*/Enumerator_MoveNext_mE66C4E35D1F864ACAD8B530D38662885FA6E3BE8_RuntimeMethod_var);
			if (L_22)
			{
				goto IL_0011;
			}
		}

IL_00aa:
		{
			IL2CPP_LEAVE(0xBA, FINALLY_00ac);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_00ac;
	}

FINALLY_00ac:
	{ // begin finally (depth: 1)
		Enumerator_Dispose_m599293FC0F1D20C18A3217F0CA5B0E6075A40042((Enumerator_tCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD *)(&V_0), /*hidden argument*/Enumerator_Dispose_m599293FC0F1D20C18A3217F0CA5B0E6075A40042_RuntimeMethod_var);
		IL2CPP_END_FINALLY(172)
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(172)
	{
		IL2CPP_JUMP_TBL(0xBA, IL_00ba)
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
	}

IL_00ba:
	{
		Transaction_CheckAborted_m1ECDF392DD73E73FD0BFB964393BDA176D6EE724(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.Transactions.Transaction::DoCommitPhase()
extern "C" IL2CPP_METHOD_ATTR void Transaction_DoCommitPhase_m8105329BE1D5F1FA0D676E26F8B0695ED8B427F4 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Transaction_DoCommitPhase_m8105329BE1D5F1FA0D676E26F8B0695ED8B427F4_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Enumerator_tCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD  V_0;
	memset(&V_0, 0, sizeof(V_0));
	Enlistment_t9E19C9353D07B13F6DEA340C15D562EAE001CB2D * V_1 = NULL;
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	void* __leave_targets_storage = alloca(sizeof(int32_t) * 1);
	il2cpp::utils::LeaveTargetStack __leave_targets(__leave_targets_storage);
	NO_UNUSED_WARNING (__leave_targets);
	{
		List_1_t433E53268E62E3881110DA61A3B077FAA122E4A5 * L_0 = Transaction_get_Volatiles_mE34920A5BF129E05A21659CA6A5D4B847E7EA47F(__this, /*hidden argument*/NULL);
		NullCheck(L_0);
		Enumerator_tCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD  L_1 = List_1_GetEnumerator_m5ED6E47986C9AF6F4D4F7CF4C9199A2D4D887913(L_0, /*hidden argument*/List_1_GetEnumerator_m5ED6E47986C9AF6F4D4F7CF4C9199A2D4D887913_RuntimeMethod_var);
		V_0 = L_1;
	}

IL_000c:
	try
	{ // begin try (depth: 1)
		{
			goto IL_0021;
		}

IL_000e:
		{
			RuntimeObject* L_2 = Enumerator_get_Current_m758972DF00AE225BC0EE5ACCBFE67F0E7CE7F044((Enumerator_tCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD *)(&V_0), /*hidden argument*/Enumerator_get_Current_m758972DF00AE225BC0EE5ACCBFE67F0E7CE7F044_RuntimeMethod_var);
			Enlistment_t9E19C9353D07B13F6DEA340C15D562EAE001CB2D * L_3 = (Enlistment_t9E19C9353D07B13F6DEA340C15D562EAE001CB2D *)il2cpp_codegen_object_new(Enlistment_t9E19C9353D07B13F6DEA340C15D562EAE001CB2D_il2cpp_TypeInfo_var);
			Enlistment__ctor_mC0AAE974F224D78D51D172B49DCDFEDECDB8F63E(L_3, /*hidden argument*/NULL);
			V_1 = L_3;
			Enlistment_t9E19C9353D07B13F6DEA340C15D562EAE001CB2D * L_4 = V_1;
			NullCheck(L_2);
			InterfaceActionInvoker1< Enlistment_t9E19C9353D07B13F6DEA340C15D562EAE001CB2D * >::Invoke(0 /* System.Void System.Transactions.IEnlistmentNotification::Commit(System.Transactions.Enlistment) */, IEnlistmentNotification_t16012AAA61792A55BF729AB561D7BD113C0890D4_il2cpp_TypeInfo_var, L_2, L_4);
		}

IL_0021:
		{
			bool L_5 = Enumerator_MoveNext_mE66C4E35D1F864ACAD8B530D38662885FA6E3BE8((Enumerator_tCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD *)(&V_0), /*hidden argument*/Enumerator_MoveNext_mE66C4E35D1F864ACAD8B530D38662885FA6E3BE8_RuntimeMethod_var);
			if (L_5)
			{
				goto IL_000e;
			}
		}

IL_002a:
		{
			IL2CPP_LEAVE(0x3A, FINALLY_002c);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_002c;
	}

FINALLY_002c:
	{ // begin finally (depth: 1)
		Enumerator_Dispose_m599293FC0F1D20C18A3217F0CA5B0E6075A40042((Enumerator_tCC2E9915EEFBF730C6A0F4186DD47F9A2FC18BCD *)(&V_0), /*hidden argument*/Enumerator_Dispose_m599293FC0F1D20C18A3217F0CA5B0E6075A40042_RuntimeMethod_var);
		IL2CPP_END_FINALLY(44)
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(44)
	{
		IL2CPP_JUMP_TBL(0x3A, IL_003a)
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
	}

IL_003a:
	{
		return;
	}
}
// System.Void System.Transactions.Transaction::DoSingleCommit(System.Transactions.ISinglePhaseNotification)
extern "C" IL2CPP_METHOD_ATTR void Transaction_DoSingleCommit_m6D603CDBD6C094779156C4092701056247D13C98 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, RuntimeObject* ___single0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Transaction_DoSingleCommit_m6D603CDBD6C094779156C4092701056247D13C98_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = ___single0;
		if (L_0)
		{
			goto IL_0004;
		}
	}
	{
		return;
	}

IL_0004:
	{
		RuntimeObject* L_1 = ___single0;
		RuntimeObject* L_2 = ___single0;
		SinglePhaseEnlistment_t29EFB2BAA0D8E39ABCAAE5061AF9D889DED528F6 * L_3 = (SinglePhaseEnlistment_t29EFB2BAA0D8E39ABCAAE5061AF9D889DED528F6 *)il2cpp_codegen_object_new(SinglePhaseEnlistment_t29EFB2BAA0D8E39ABCAAE5061AF9D889DED528F6_il2cpp_TypeInfo_var);
		SinglePhaseEnlistment__ctor_m09CB7F2E784B6A1C45C385EABD8E541C0011B107(L_3, __this, L_2, /*hidden argument*/NULL);
		NullCheck(L_1);
		InterfaceActionInvoker1< SinglePhaseEnlistment_t29EFB2BAA0D8E39ABCAAE5061AF9D889DED528F6 * >::Invoke(0 /* System.Void System.Transactions.ISinglePhaseNotification::SinglePhaseCommit(System.Transactions.SinglePhaseEnlistment) */, ISinglePhaseNotification_t70B179E8BC10CE3B486A1834D28DCDCE21C095EF_il2cpp_TypeInfo_var, L_1, L_3);
		Transaction_CheckAborted_m1ECDF392DD73E73FD0BFB964393BDA176D6EE724(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.Transactions.Transaction::DoSingleCommit(System.Transactions.IPromotableSinglePhaseNotification)
extern "C" IL2CPP_METHOD_ATTR void Transaction_DoSingleCommit_m4A8637DBA68B7D883D045C018BBB1C20FF4FB67C (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, RuntimeObject* ___single0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Transaction_DoSingleCommit_m4A8637DBA68B7D883D045C018BBB1C20FF4FB67C_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = ___single0;
		if (L_0)
		{
			goto IL_0004;
		}
	}
	{
		return;
	}

IL_0004:
	{
		RuntimeObject* L_1 = ___single0;
		RuntimeObject* L_2 = ___single0;
		SinglePhaseEnlistment_t29EFB2BAA0D8E39ABCAAE5061AF9D889DED528F6 * L_3 = (SinglePhaseEnlistment_t29EFB2BAA0D8E39ABCAAE5061AF9D889DED528F6 *)il2cpp_codegen_object_new(SinglePhaseEnlistment_t29EFB2BAA0D8E39ABCAAE5061AF9D889DED528F6_il2cpp_TypeInfo_var);
		SinglePhaseEnlistment__ctor_m09CB7F2E784B6A1C45C385EABD8E541C0011B107(L_3, __this, L_2, /*hidden argument*/NULL);
		NullCheck(L_1);
		InterfaceActionInvoker1< SinglePhaseEnlistment_t29EFB2BAA0D8E39ABCAAE5061AF9D889DED528F6 * >::Invoke(1 /* System.Void System.Transactions.IPromotableSinglePhaseNotification::SinglePhaseCommit(System.Transactions.SinglePhaseEnlistment) */, IPromotableSinglePhaseNotification_t4E3897767FACCC747B6D0AF2750B2D42B9729492_il2cpp_TypeInfo_var, L_1, L_3);
		Transaction_CheckAborted_m1ECDF392DD73E73FD0BFB964393BDA176D6EE724(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.Transactions.Transaction::CheckAborted()
extern "C" IL2CPP_METHOD_ATTR void Transaction_CheckAborted_m1ECDF392DD73E73FD0BFB964393BDA176D6EE724 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Transaction_CheckAborted_m1ECDF392DD73E73FD0BFB964393BDA176D6EE724_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		bool L_0 = __this->get_aborted_9();
		if (!L_0)
		{
			goto IL_0019;
		}
	}
	{
		Exception_t * L_1 = __this->get_innerException_11();
		TransactionAbortedException_tDE489364A598740F9F9D7CCEE8EC7259318F386D * L_2 = (TransactionAbortedException_tDE489364A598740F9F9D7CCEE8EC7259318F386D *)il2cpp_codegen_object_new(TransactionAbortedException_tDE489364A598740F9F9D7CCEE8EC7259318F386D_il2cpp_TypeInfo_var);
		TransactionAbortedException__ctor_mCAEF35081991D70342541145306EDA99AF2C2911(L_2, _stringLiteral3938659212BDF8DEB0FBDB29D3877DF586ED993F, L_1, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_2, NULL, Transaction_CheckAborted_m1ECDF392DD73E73FD0BFB964393BDA176D6EE724_RuntimeMethod_var);
	}

IL_0019:
	{
		return;
	}
}
// System.Void System.Transactions.Transaction::FireCompleted()
extern "C" IL2CPP_METHOD_ATTR void Transaction_FireCompleted_mBD57957732D7FAFF0D7A83EA5823EC6B66A10986 (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Transaction_FireCompleted_mBD57957732D7FAFF0D7A83EA5823EC6B66A10986_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		TransactionCompletedEventHandler_t57EB4B1B2B3FE844563C580C04E6257A58CA5B6D * L_0 = __this->get_TransactionCompleted_13();
		if (!L_0)
		{
			goto IL_001a;
		}
	}
	{
		TransactionCompletedEventHandler_t57EB4B1B2B3FE844563C580C04E6257A58CA5B6D * L_1 = __this->get_TransactionCompleted_13();
		TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 * L_2 = (TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 *)il2cpp_codegen_object_new(TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6_il2cpp_TypeInfo_var);
		TransactionEventArgs__ctor_m84DE8025880A2E98018451123AE1B2CE70467BF3(L_2, __this, /*hidden argument*/NULL);
		NullCheck(L_1);
		TransactionCompletedEventHandler_Invoke_m73AA1D4092447CB19BA846D252EE279625CE1B8F(L_1, __this, L_2, /*hidden argument*/NULL);
	}

IL_001a:
	{
		return;
	}
}
// System.Void System.Transactions.Transaction::EnsureIncompleteCurrentScope()
extern "C" IL2CPP_METHOD_ATTR void Transaction_EnsureIncompleteCurrentScope_m14043E8F8E23D22ADEA7C43977CE84556591A71C (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Transaction_EnsureIncompleteCurrentScope_m14043E8F8E23D22ADEA7C43977CE84556591A71C_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_0 = Transaction_get_CurrentInternal_mD2ADB6241C7D4AD453E70854F9917DCB38F20424(/*hidden argument*/NULL);
		bool L_1 = Transaction_op_Equality_m3922A8F89D6B043AEC236B180B1D6CD0C6C139FA(L_0, (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 *)NULL, /*hidden argument*/NULL);
		if (!L_1)
		{
			goto IL_000e;
		}
	}
	{
		return;
	}

IL_000e:
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_2 = Transaction_get_CurrentInternal_mD2ADB6241C7D4AD453E70854F9917DCB38F20424(/*hidden argument*/NULL);
		NullCheck(L_2);
		TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 * L_3 = Transaction_get_Scope_mAE876EEA8215941994BF0AE015134665DC89AE2A(L_2, /*hidden argument*/NULL);
		if (!L_3)
		{
			goto IL_0036;
		}
	}
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_4 = Transaction_get_CurrentInternal_mD2ADB6241C7D4AD453E70854F9917DCB38F20424(/*hidden argument*/NULL);
		NullCheck(L_4);
		TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 * L_5 = Transaction_get_Scope_mAE876EEA8215941994BF0AE015134665DC89AE2A(L_4, /*hidden argument*/NULL);
		NullCheck(L_5);
		bool L_6 = TransactionScope_get_IsComplete_m435B2667F1FC8FC00F8D70F53B196EABEC2385E5(L_5, /*hidden argument*/NULL);
		if (!L_6)
		{
			goto IL_0036;
		}
	}
	{
		InvalidOperationException_t0530E734D823F78310CAFAFA424CA5164D93A1F1 * L_7 = (InvalidOperationException_t0530E734D823F78310CAFAFA424CA5164D93A1F1 *)il2cpp_codegen_object_new(InvalidOperationException_t0530E734D823F78310CAFAFA424CA5164D93A1F1_il2cpp_TypeInfo_var);
		InvalidOperationException__ctor_m72027D5F1D513C25C05137E203EEED8FD8297706(L_7, _stringLiteral5A78AFA7A723BDBE19F5FFDF3E7DD314FB030C6F, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_7, NULL, Transaction_EnsureIncompleteCurrentScope_m14043E8F8E23D22ADEA7C43977CE84556591A71C_RuntimeMethod_var);
	}

IL_0036:
	{
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void System.Transactions.TransactionAbortedException::.ctor()
extern "C" IL2CPP_METHOD_ATTR void TransactionAbortedException__ctor_mF07F98F7E58E8F2E8F9D68080802D01E8AC438EA (TransactionAbortedException_tDE489364A598740F9F9D7CCEE8EC7259318F386D * __this, const RuntimeMethod* method)
{
	{
		TransactionException__ctor_m83205811BC7C812F5B3E223C22A9CB2FAF2853D9(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.Transactions.TransactionAbortedException::.ctor(System.String,System.Exception)
extern "C" IL2CPP_METHOD_ATTR void TransactionAbortedException__ctor_mCAEF35081991D70342541145306EDA99AF2C2911 (TransactionAbortedException_tDE489364A598740F9F9D7CCEE8EC7259318F386D * __this, String_t* ___message0, Exception_t * ___innerException1, const RuntimeMethod* method)
{
	{
		String_t* L_0 = ___message0;
		Exception_t * L_1 = ___innerException1;
		TransactionException__ctor_mC3BB2AEE63D219DA15C5B0B29B8C3E155ECF180D(__this, L_0, L_1, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.Transactions.TransactionAbortedException::.ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
extern "C" IL2CPP_METHOD_ATTR void TransactionAbortedException__ctor_mDEAA253FD77FBA237B579CED167DEABBA56B11E6 (TransactionAbortedException_tDE489364A598740F9F9D7CCEE8EC7259318F386D * __this, SerializationInfo_t1BB80E9C9DEA52DBF464487234B045E2930ADA26 * ___info0, StreamingContext_t2CCDC54E0E8D078AF4A50E3A8B921B828A900034  ___context1, const RuntimeMethod* method)
{
	{
		SerializationInfo_t1BB80E9C9DEA52DBF464487234B045E2930ADA26 * L_0 = ___info0;
		StreamingContext_t2CCDC54E0E8D078AF4A50E3A8B921B828A900034  L_1 = ___context1;
		TransactionException__ctor_m63FC6C5C0E08A59E83CAB09F2C9A90D83EE8B760(__this, L_0, L_1, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void System.Transactions.TransactionCompletedEventHandler::.ctor(System.Object,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR void TransactionCompletedEventHandler__ctor_mD70FF259C94ADAE0211189FC0B2D922D60DBDD61 (TransactionCompletedEventHandler_t57EB4B1B2B3FE844563C580C04E6257A58CA5B6D * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method)
{
	__this->set_method_ptr_0(il2cpp_codegen_get_method_pointer((RuntimeMethod*)___method1));
	__this->set_method_3(___method1);
	__this->set_m_target_2(___object0);
}
// System.Void System.Transactions.TransactionCompletedEventHandler::Invoke(System.Object,System.Transactions.TransactionEventArgs)
extern "C" IL2CPP_METHOD_ATTR void TransactionCompletedEventHandler_Invoke_m73AA1D4092447CB19BA846D252EE279625CE1B8F (TransactionCompletedEventHandler_t57EB4B1B2B3FE844563C580C04E6257A58CA5B6D * __this, RuntimeObject * ___sender0, TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 * ___e1, const RuntimeMethod* method)
{
	DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86* delegatesToInvoke = __this->get_delegates_11();
	if (delegatesToInvoke != NULL)
	{
		il2cpp_array_size_t length = delegatesToInvoke->max_length;
		for (il2cpp_array_size_t i = 0; i < length; i++)
		{
			Delegate_t* currentDelegate = (delegatesToInvoke)->GetAtUnchecked(static_cast<il2cpp_array_size_t>(i));
			Il2CppMethodPointer targetMethodPointer = currentDelegate->get_method_ptr_0();
			RuntimeMethod* targetMethod = (RuntimeMethod*)(currentDelegate->get_method_3());
			RuntimeObject* targetThis = currentDelegate->get_m_target_2();
			if (!il2cpp_codegen_method_is_virtual(targetMethod))
			{
				il2cpp_codegen_raise_execution_engine_exception_if_method_is_not_found(targetMethod);
			}
			bool ___methodIsStatic = MethodIsStatic(targetMethod);
			int ___parameterCount = il2cpp_codegen_method_parameter_count(targetMethod);
			if (___methodIsStatic)
			{
				if (___parameterCount == 2)
				{
					// open
					typedef void (*FunctionPointerType) (RuntimeObject *, TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 *, const RuntimeMethod*);
					((FunctionPointerType)targetMethodPointer)(___sender0, ___e1, targetMethod);
				}
				else
				{
					// closed
					typedef void (*FunctionPointerType) (void*, RuntimeObject *, TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 *, const RuntimeMethod*);
					((FunctionPointerType)targetMethodPointer)(targetThis, ___sender0, ___e1, targetMethod);
				}
			}
			else if (___parameterCount != 2)
			{
				// open
				if (il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
				{
					if (il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
					{
						if (il2cpp_codegen_method_is_generic_instance(targetMethod))
						{
							if (il2cpp_codegen_method_is_interface_method(targetMethod))
								GenericInterfaceActionInvoker1< TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 * >::Invoke(targetMethod, ___sender0, ___e1);
							else
								GenericVirtActionInvoker1< TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 * >::Invoke(targetMethod, ___sender0, ___e1);
						}
						else
						{
							if (il2cpp_codegen_method_is_interface_method(targetMethod))
								InterfaceActionInvoker1< TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 * >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), ___sender0, ___e1);
							else
								VirtActionInvoker1< TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 * >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), ___sender0, ___e1);
						}
					}
				}
				else
				{
					typedef void (*FunctionPointerType) (RuntimeObject *, TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 *, const RuntimeMethod*);
					((FunctionPointerType)targetMethodPointer)(___sender0, ___e1, targetMethod);
				}
			}
			else
			{
				// closed
				if (il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
				{
					if (il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
					{
						if (targetThis == NULL)
						{
							typedef void (*FunctionPointerType) (RuntimeObject *, TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 *, const RuntimeMethod*);
							((FunctionPointerType)targetMethodPointer)(___sender0, ___e1, targetMethod);
						}
						else if (il2cpp_codegen_method_is_generic_instance(targetMethod))
						{
							if (il2cpp_codegen_method_is_interface_method(targetMethod))
								GenericInterfaceActionInvoker2< RuntimeObject *, TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 * >::Invoke(targetMethod, targetThis, ___sender0, ___e1);
							else
								GenericVirtActionInvoker2< RuntimeObject *, TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 * >::Invoke(targetMethod, targetThis, ___sender0, ___e1);
						}
						else
						{
							if (il2cpp_codegen_method_is_interface_method(targetMethod))
								InterfaceActionInvoker2< RuntimeObject *, TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 * >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), targetThis, ___sender0, ___e1);
							else
								VirtActionInvoker2< RuntimeObject *, TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 * >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), targetThis, ___sender0, ___e1);
						}
					}
				}
				else
				{
					typedef void (*FunctionPointerType) (void*, RuntimeObject *, TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 *, const RuntimeMethod*);
					((FunctionPointerType)targetMethodPointer)(targetThis, ___sender0, ___e1, targetMethod);
				}
			}
		}
	}
	else
	{
		Il2CppMethodPointer targetMethodPointer = __this->get_method_ptr_0();
		RuntimeMethod* targetMethod = (RuntimeMethod*)(__this->get_method_3());
		RuntimeObject* targetThis = __this->get_m_target_2();
		if (!il2cpp_codegen_method_is_virtual(targetMethod))
		{
			il2cpp_codegen_raise_execution_engine_exception_if_method_is_not_found(targetMethod);
		}
		bool ___methodIsStatic = MethodIsStatic(targetMethod);
		int ___parameterCount = il2cpp_codegen_method_parameter_count(targetMethod);
		if (___methodIsStatic)
		{
			if (___parameterCount == 2)
			{
				// open
				typedef void (*FunctionPointerType) (RuntimeObject *, TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 *, const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(___sender0, ___e1, targetMethod);
			}
			else
			{
				// closed
				typedef void (*FunctionPointerType) (void*, RuntimeObject *, TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 *, const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(targetThis, ___sender0, ___e1, targetMethod);
			}
		}
		else if (___parameterCount != 2)
		{
			// open
			if (il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
			{
				if (il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
				{
					if (il2cpp_codegen_method_is_generic_instance(targetMethod))
					{
						if (il2cpp_codegen_method_is_interface_method(targetMethod))
							GenericInterfaceActionInvoker1< TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 * >::Invoke(targetMethod, ___sender0, ___e1);
						else
							GenericVirtActionInvoker1< TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 * >::Invoke(targetMethod, ___sender0, ___e1);
					}
					else
					{
						if (il2cpp_codegen_method_is_interface_method(targetMethod))
							InterfaceActionInvoker1< TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 * >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), ___sender0, ___e1);
						else
							VirtActionInvoker1< TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 * >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), ___sender0, ___e1);
					}
				}
			}
			else
			{
				typedef void (*FunctionPointerType) (RuntimeObject *, TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 *, const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(___sender0, ___e1, targetMethod);
			}
		}
		else
		{
			// closed
			if (il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
			{
				if (il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
				{
					if (targetThis == NULL)
					{
						typedef void (*FunctionPointerType) (RuntimeObject *, TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 *, const RuntimeMethod*);
						((FunctionPointerType)targetMethodPointer)(___sender0, ___e1, targetMethod);
					}
					else if (il2cpp_codegen_method_is_generic_instance(targetMethod))
					{
						if (il2cpp_codegen_method_is_interface_method(targetMethod))
							GenericInterfaceActionInvoker2< RuntimeObject *, TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 * >::Invoke(targetMethod, targetThis, ___sender0, ___e1);
						else
							GenericVirtActionInvoker2< RuntimeObject *, TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 * >::Invoke(targetMethod, targetThis, ___sender0, ___e1);
					}
					else
					{
						if (il2cpp_codegen_method_is_interface_method(targetMethod))
							InterfaceActionInvoker2< RuntimeObject *, TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 * >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), targetThis, ___sender0, ___e1);
						else
							VirtActionInvoker2< RuntimeObject *, TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 * >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), targetThis, ___sender0, ___e1);
					}
				}
			}
			else
			{
				typedef void (*FunctionPointerType) (void*, RuntimeObject *, TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 *, const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(targetThis, ___sender0, ___e1, targetMethod);
			}
		}
	}
}
// System.IAsyncResult System.Transactions.TransactionCompletedEventHandler::BeginInvoke(System.Object,System.Transactions.TransactionEventArgs,System.AsyncCallback,System.Object)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject* TransactionCompletedEventHandler_BeginInvoke_m3C7C7F1EBF35C77C8EA29C5375B19AB024CB3D28 (TransactionCompletedEventHandler_t57EB4B1B2B3FE844563C580C04E6257A58CA5B6D * __this, RuntimeObject * ___sender0, TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 * ___e1, AsyncCallback_t3F3DA3BEDAEE81DD1D24125DF8EB30E85EE14DA4 * ___callback2, RuntimeObject * ___object3, const RuntimeMethod* method)
{
	void *__d_args[3] = {0};
	__d_args[0] = ___sender0;
	__d_args[1] = ___e1;
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback2, (RuntimeObject*)___object3);
}
// System.Void System.Transactions.TransactionCompletedEventHandler::EndInvoke(System.IAsyncResult)
extern "C" IL2CPP_METHOD_ATTR void TransactionCompletedEventHandler_EndInvoke_mD3C5979C740A57A88536952BE133DB9AA466FB4C (TransactionCompletedEventHandler_t57EB4B1B2B3FE844563C580C04E6257A58CA5B6D * __this, RuntimeObject* ___result0, const RuntimeMethod* method)
{
	il2cpp_codegen_delegate_end_invoke((Il2CppAsyncResult*) ___result0, 0);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void System.Transactions.TransactionEventArgs::.ctor()
extern "C" IL2CPP_METHOD_ATTR void TransactionEventArgs__ctor_m6CE6078481C1D1D18D229A8DC56BC254E1573A0F (TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (TransactionEventArgs__ctor_m6CE6078481C1D1D18D229A8DC56BC254E1573A0F_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(EventArgs_t8E6CA180BE0E56674C6407011A94BAF7C757352E_il2cpp_TypeInfo_var);
		EventArgs__ctor_m3551293259861C5A78CD47689D559F828ED29DF7(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.Transactions.TransactionEventArgs::.ctor(System.Transactions.Transaction)
extern "C" IL2CPP_METHOD_ATTR void TransactionEventArgs__ctor_m84DE8025880A2E98018451123AE1B2CE70467BF3 (TransactionEventArgs_t3681DC7BCA98278A61430810F0627003BB8F83B6 * __this, Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * ___transaction0, const RuntimeMethod* method)
{
	{
		TransactionEventArgs__ctor_m6CE6078481C1D1D18D229A8DC56BC254E1573A0F(__this, /*hidden argument*/NULL);
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_0 = ___transaction0;
		__this->set_transaction_1(L_0);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void System.Transactions.TransactionException::.ctor()
extern "C" IL2CPP_METHOD_ATTR void TransactionException__ctor_m83205811BC7C812F5B3E223C22A9CB2FAF2853D9 (TransactionException_tC34049F157BD87E4259E78D5F78FFC6FA0774658 * __this, const RuntimeMethod* method)
{
	{
		SystemException__ctor_mEB9049B75DE1D23B0515DD294BEF0AAC7792F465(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.Transactions.TransactionException::.ctor(System.String)
extern "C" IL2CPP_METHOD_ATTR void TransactionException__ctor_mCB5EC250D8B6D85BC9F7BB8CD768740D1630D1B9 (TransactionException_tC34049F157BD87E4259E78D5F78FFC6FA0774658 * __this, String_t* ___message0, const RuntimeMethod* method)
{
	{
		String_t* L_0 = ___message0;
		SystemException__ctor_mF67B7FA639B457BDFB2103D7C21C8059E806175A(__this, L_0, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.Transactions.TransactionException::.ctor(System.String,System.Exception)
extern "C" IL2CPP_METHOD_ATTR void TransactionException__ctor_mC3BB2AEE63D219DA15C5B0B29B8C3E155ECF180D (TransactionException_tC34049F157BD87E4259E78D5F78FFC6FA0774658 * __this, String_t* ___message0, Exception_t * ___innerException1, const RuntimeMethod* method)
{
	{
		String_t* L_0 = ___message0;
		Exception_t * L_1 = ___innerException1;
		SystemException__ctor_mA18D2EA5642C066F35CB8C965398F9A542C33B0A(__this, L_0, L_1, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.Transactions.TransactionException::.ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
extern "C" IL2CPP_METHOD_ATTR void TransactionException__ctor_m63FC6C5C0E08A59E83CAB09F2C9A90D83EE8B760 (TransactionException_tC34049F157BD87E4259E78D5F78FFC6FA0774658 * __this, SerializationInfo_t1BB80E9C9DEA52DBF464487234B045E2930ADA26 * ___info0, StreamingContext_t2CCDC54E0E8D078AF4A50E3A8B921B828A900034  ___context1, const RuntimeMethod* method)
{
	{
		SerializationInfo_t1BB80E9C9DEA52DBF464487234B045E2930ADA26 * L_0 = ___info0;
		StreamingContext_t2CCDC54E0E8D078AF4A50E3A8B921B828A900034  L_1 = ___context1;
		SystemException__ctor_mB0550111A1A8D18B697B618F811A5B20C160D949(__this, L_0, L_1, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void System.Transactions.TransactionInformation::.ctor()
extern "C" IL2CPP_METHOD_ATTR void TransactionInformation__ctor_mAB9F12A2A4EB65E91503CCF9B2B9E303E38DCF45 (TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (TransactionInformation__ctor_mAB9F12A2A4EB65E91503CCF9B2B9E303E38DCF45_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132  V_0;
	memset(&V_0, 0, sizeof(V_0));
	Guid_t  V_1;
	memset(&V_1, 0, sizeof(V_1));
	{
		IL2CPP_RUNTIME_CLASS_INIT(Guid_t_il2cpp_TypeInfo_var);
		Guid_t  L_0 = ((Guid_t_StaticFields*)il2cpp_codegen_static_fields_for(Guid_t_il2cpp_TypeInfo_var))->get_Empty_0();
		__this->set_dtcId_1(L_0);
		Object__ctor_m925ECA5E85CA100E3FB86A4F9E15C120E9A184C0(__this, /*hidden argument*/NULL);
		__this->set_status_3(0);
		IL2CPP_RUNTIME_CLASS_INIT(DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132_il2cpp_TypeInfo_var);
		DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132  L_1 = DateTime_get_Now_mB464D30F15C97069F92C1F910DCDDC3DFCC7F7D2(/*hidden argument*/NULL);
		V_0 = L_1;
		DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132  L_2 = DateTime_ToUniversalTime_mA8B74D947E186568C55D9C6F56D59F9A3C7775B1((DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132 *)(&V_0), /*hidden argument*/NULL);
		__this->set_creation_time_2(L_2);
		Guid_t  L_3 = Guid_NewGuid_m541CAC23EBB140DFD3AB5B313315647E95FADB29(/*hidden argument*/NULL);
		V_1 = L_3;
		String_t* L_4 = Guid_ToString_m3024AB4FA6189BC28BE77BBD6A9F55841FE190A5((Guid_t *)(&V_1), /*hidden argument*/NULL);
		String_t* L_5 = String_Concat_mB78D0094592718DA6D5DB6C712A9C225631666BE(L_4, _stringLiteral297C1D782653E80FF9D58E7D4BC5FB5543DBC48F, /*hidden argument*/NULL);
		__this->set_local_id_0(L_5);
		return;
	}
}
// System.Transactions.TransactionStatus System.Transactions.TransactionInformation::get_Status()
extern "C" IL2CPP_METHOD_ATTR int32_t TransactionInformation_get_Status_mDAAF24D2911205030F52A799B5D2D2B8CFBD4B99 (TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7 * __this, const RuntimeMethod* method)
{
	{
		int32_t L_0 = __this->get_status_3();
		return L_0;
	}
}
// System.Void System.Transactions.TransactionInformation::set_Status(System.Transactions.TransactionStatus)
extern "C" IL2CPP_METHOD_ATTR void TransactionInformation_set_Status_mF2FDB0AEE416525D3A9B8507218959B0B5B11A2C (TransactionInformation_t1C236EAF1EACEBECA877FA4FA9BF49A6E956A2F7 * __this, int32_t ___value0, const RuntimeMethod* method)
{
	{
		int32_t L_0 = ___value0;
		__this->set_status_3(L_0);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void System.Transactions.TransactionManager::.cctor()
extern "C" IL2CPP_METHOD_ATTR void TransactionManager__cctor_m0FA54029D54D84844F8CE868E7628F8BB321159A (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (TransactionManager__cctor_m0FA54029D54D84844F8CE868E7628F8BB321159A_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  L_0;
		memset(&L_0, 0, sizeof(L_0));
		TimeSpan__ctor_m44268277AFF84DEF6CA3442907CE8116A982FB87((&L_0), 0, 1, 0, /*hidden argument*/NULL);
		((TransactionManager_t89B5F1C0446C7A1D72FEB287569D47BAB58BBB64_StaticFields*)il2cpp_codegen_static_fields_for(TransactionManager_t89B5F1C0446C7A1D72FEB287569D47BAB58BBB64_il2cpp_TypeInfo_var))->set_defaultTimeout_0(L_0);
		TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  L_1;
		memset(&L_1, 0, sizeof(L_1));
		TimeSpan__ctor_m44268277AFF84DEF6CA3442907CE8116A982FB87((&L_1), 0, ((int32_t)10), 0, /*hidden argument*/NULL);
		((TransactionManager_t89B5F1C0446C7A1D72FEB287569D47BAB58BBB64_StaticFields*)il2cpp_codegen_static_fields_for(TransactionManager_t89B5F1C0446C7A1D72FEB287569D47BAB58BBB64_il2cpp_TypeInfo_var))->set_maxTimeout_1(L_1);
		return;
	}
}
// System.TimeSpan System.Transactions.TransactionManager::get_DefaultTimeout()
extern "C" IL2CPP_METHOD_ATTR TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  TransactionManager_get_DefaultTimeout_m787C350D9D35FF5E68D4C02EB9003148180EA76B (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (TransactionManager_get_DefaultTimeout_m787C350D9D35FF5E68D4C02EB9003148180EA76B_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(TransactionManager_t89B5F1C0446C7A1D72FEB287569D47BAB58BBB64_il2cpp_TypeInfo_var);
		TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  L_0 = ((TransactionManager_t89B5F1C0446C7A1D72FEB287569D47BAB58BBB64_StaticFields*)il2cpp_codegen_static_fields_for(TransactionManager_t89B5F1C0446C7A1D72FEB287569D47BAB58BBB64_il2cpp_TypeInfo_var))->get_defaultTimeout_0();
		return L_0;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void System.Transactions.TransactionOptions::.ctor(System.Transactions.IsolationLevel,System.TimeSpan)
extern "C" IL2CPP_METHOD_ATTR void TransactionOptions__ctor_m55CFF612EB0B67FBB7B63790EBBF57DC1F51CB95 (TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F * __this, int32_t ___level0, TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  ___timeout1, const RuntimeMethod* method)
{
	{
		int32_t L_0 = ___level0;
		__this->set_level_0(L_0);
		TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  L_1 = ___timeout1;
		__this->set_timeout_1(L_1);
		return;
	}
}
extern "C"  void TransactionOptions__ctor_m55CFF612EB0B67FBB7B63790EBBF57DC1F51CB95_AdjustorThunk (RuntimeObject * __this, int32_t ___level0, TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  ___timeout1, const RuntimeMethod* method)
{
	TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F * _thisAdjusted = reinterpret_cast<TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F *>(__this + 1);
	TransactionOptions__ctor_m55CFF612EB0B67FBB7B63790EBBF57DC1F51CB95(_thisAdjusted, ___level0, ___timeout1, method);
}
// System.Boolean System.Transactions.TransactionOptions::op_Equality(System.Transactions.TransactionOptions,System.Transactions.TransactionOptions)
extern "C" IL2CPP_METHOD_ATTR bool TransactionOptions_op_Equality_m496545B47A671A5F4269611E2DCE57226A6EAFBF (TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F  ___x0, TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F  ___y1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (TransactionOptions_op_Equality_m496545B47A671A5F4269611E2DCE57226A6EAFBF_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F  L_0 = ___x0;
		int32_t L_1 = L_0.get_level_0();
		TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F  L_2 = ___y1;
		int32_t L_3 = L_2.get_level_0();
		if ((!(((uint32_t)L_1) == ((uint32_t)L_3))))
		{
			goto IL_0020;
		}
	}
	{
		TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F  L_4 = ___x0;
		TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  L_5 = L_4.get_timeout_1();
		TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F  L_6 = ___y1;
		TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  L_7 = L_6.get_timeout_1();
		IL2CPP_RUNTIME_CLASS_INIT(TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4_il2cpp_TypeInfo_var);
		bool L_8 = TimeSpan_op_Equality_mEA0A4B7FDCAFA54C636292F7EB76F9A16C44096D(L_5, L_7, /*hidden argument*/NULL);
		return L_8;
	}

IL_0020:
	{
		return (bool)0;
	}
}
// System.Boolean System.Transactions.TransactionOptions::Equals(System.Object)
extern "C" IL2CPP_METHOD_ATTR bool TransactionOptions_Equals_mD61A2902A74D8512486CA4CB47BD453BE87C8CD6 (TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F * __this, RuntimeObject * ___obj0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (TransactionOptions_Equals_mD61A2902A74D8512486CA4CB47BD453BE87C8CD6_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject * L_0 = ___obj0;
		if (((RuntimeObject *)IsInstSealed((RuntimeObject*)L_0, TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F_il2cpp_TypeInfo_var)))
		{
			goto IL_000a;
		}
	}
	{
		return (bool)0;
	}

IL_000a:
	{
		TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F  L_1 = (*(TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F *)__this);
		RuntimeObject * L_2 = ___obj0;
		bool L_3 = TransactionOptions_op_Equality_m496545B47A671A5F4269611E2DCE57226A6EAFBF(L_1, ((*(TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F *)((TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F *)UnBox(L_2, TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F_il2cpp_TypeInfo_var)))), /*hidden argument*/NULL);
		return L_3;
	}
}
extern "C"  bool TransactionOptions_Equals_mD61A2902A74D8512486CA4CB47BD453BE87C8CD6_AdjustorThunk (RuntimeObject * __this, RuntimeObject * ___obj0, const RuntimeMethod* method)
{
	TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F * _thisAdjusted = reinterpret_cast<TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F *>(__this + 1);
	return TransactionOptions_Equals_mD61A2902A74D8512486CA4CB47BD453BE87C8CD6(_thisAdjusted, ___obj0, method);
}
// System.Int32 System.Transactions.TransactionOptions::GetHashCode()
extern "C" IL2CPP_METHOD_ATTR int32_t TransactionOptions_GetHashCode_mDB692B4DB9C864AA9749B31A25538F834FBCB13D (TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F * __this, const RuntimeMethod* method)
{
	{
		int32_t L_0 = __this->get_level_0();
		TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4 * L_1 = __this->get_address_of_timeout_1();
		int32_t L_2 = TimeSpan_GetHashCode_m4FD4BD6B179EDD97650F594B0E671EC8FB1E535F((TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4 *)L_1, /*hidden argument*/NULL);
		return ((int32_t)((int32_t)L_0^(int32_t)L_2));
	}
}
extern "C"  int32_t TransactionOptions_GetHashCode_mDB692B4DB9C864AA9749B31A25538F834FBCB13D_AdjustorThunk (RuntimeObject * __this, const RuntimeMethod* method)
{
	TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F * _thisAdjusted = reinterpret_cast<TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F *>(__this + 1);
	return TransactionOptions_GetHashCode_mDB692B4DB9C864AA9749B31A25538F834FBCB13D(_thisAdjusted, method);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Boolean System.Transactions.TransactionScope::get_IsComplete()
extern "C" IL2CPP_METHOD_ATTR bool TransactionScope_get_IsComplete_m435B2667F1FC8FC00F8D70F53B196EABEC2385E5 (TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 * __this, const RuntimeMethod* method)
{
	{
		bool L_0 = __this->get_completed_7();
		return L_0;
	}
}
// System.TimeSpan System.Transactions.TransactionScope::get_Timeout()
extern "C" IL2CPP_METHOD_ATTR TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  TransactionScope_get_Timeout_m9D2CA787E003B8E3E0BC694F4EAAFB19ADC3E693 (TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 * __this, const RuntimeMethod* method)
{
	{
		TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  L_0 = __this->get_timeout_4();
		return L_0;
	}
}
// System.Void System.Transactions.TransactionScope::Dispose()
extern "C" IL2CPP_METHOD_ATTR void TransactionScope_Dispose_mD59AC22CF6811FA85272C31E4DBE98C655571807 (TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (TransactionScope_Dispose_mD59AC22CF6811FA85272C31E4DBE98C655571807_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * V_0 = NULL;
	{
		bool L_0 = __this->get_disposed_6();
		if (!L_0)
		{
			goto IL_0009;
		}
	}
	{
		return;
	}

IL_0009:
	{
		__this->set_disposed_6((bool)1);
		TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 * L_1 = __this->get_parentScope_3();
		if (!L_1)
		{
			goto IL_002b;
		}
	}
	{
		TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 * L_2 = __this->get_parentScope_3();
		TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 * L_3 = L_2;
		NullCheck(L_3);
		int32_t L_4 = L_3->get_nested_5();
		NullCheck(L_3);
		L_3->set_nested_5(((int32_t)il2cpp_codegen_subtract((int32_t)L_4, (int32_t)1)));
	}

IL_002b:
	{
		int32_t L_5 = __this->get_nested_5();
		if ((((int32_t)L_5) <= ((int32_t)0)))
		{
			goto IL_004a;
		}
	}
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_6 = __this->get_transaction_1();
		NullCheck(L_6);
		Transaction_Rollback_mD1E2C0BAC184FDF71F005870731C0197A61651B6(L_6, /*hidden argument*/NULL);
		InvalidOperationException_t0530E734D823F78310CAFAFA424CA5164D93A1F1 * L_7 = (InvalidOperationException_t0530E734D823F78310CAFAFA424CA5164D93A1F1 *)il2cpp_codegen_object_new(InvalidOperationException_t0530E734D823F78310CAFAFA424CA5164D93A1F1_il2cpp_TypeInfo_var);
		InvalidOperationException__ctor_m72027D5F1D513C25C05137E203EEED8FD8297706(L_7, _stringLiteral39C7C154BE39F5CB6C9E9F7C1EF849C0F3478BFA, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_7, NULL, TransactionScope_Dispose_mD59AC22CF6811FA85272C31E4DBE98C655571807_RuntimeMethod_var);
	}

IL_004a:
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_8 = Transaction_get_CurrentInternal_mD2ADB6241C7D4AD453E70854F9917DCB38F20424(/*hidden argument*/NULL);
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_9 = __this->get_transaction_1();
		bool L_10 = Transaction_op_Inequality_mB8AC9FA5FD15CC891FBAD3058A7E01FFE3797C00(L_8, L_9, /*hidden argument*/NULL);
		if (!L_10)
		{
			goto IL_009f;
		}
	}
	{
		bool L_11 = __this->get_asyncFlowEnabled_9();
		if (L_11)
		{
			goto IL_009f;
		}
	}
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_12 = __this->get_transaction_1();
		bool L_13 = Transaction_op_Inequality_mB8AC9FA5FD15CC891FBAD3058A7E01FFE3797C00(L_12, (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 *)NULL, /*hidden argument*/NULL);
		if (!L_13)
		{
			goto IL_007d;
		}
	}
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_14 = __this->get_transaction_1();
		NullCheck(L_14);
		Transaction_Rollback_mD1E2C0BAC184FDF71F005870731C0197A61651B6(L_14, /*hidden argument*/NULL);
	}

IL_007d:
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_15 = Transaction_get_CurrentInternal_mD2ADB6241C7D4AD453E70854F9917DCB38F20424(/*hidden argument*/NULL);
		bool L_16 = Transaction_op_Inequality_mB8AC9FA5FD15CC891FBAD3058A7E01FFE3797C00(L_15, (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 *)NULL, /*hidden argument*/NULL);
		if (!L_16)
		{
			goto IL_0094;
		}
	}
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_17 = Transaction_get_CurrentInternal_mD2ADB6241C7D4AD453E70854F9917DCB38F20424(/*hidden argument*/NULL);
		NullCheck(L_17);
		Transaction_Rollback_mD1E2C0BAC184FDF71F005870731C0197A61651B6(L_17, /*hidden argument*/NULL);
	}

IL_0094:
	{
		InvalidOperationException_t0530E734D823F78310CAFAFA424CA5164D93A1F1 * L_18 = (InvalidOperationException_t0530E734D823F78310CAFAFA424CA5164D93A1F1 *)il2cpp_codegen_object_new(InvalidOperationException_t0530E734D823F78310CAFAFA424CA5164D93A1F1_il2cpp_TypeInfo_var);
		InvalidOperationException__ctor_m72027D5F1D513C25C05137E203EEED8FD8297706(L_18, _stringLiteral21BCBD295EC54B5735EFCAEB008312714381BD7C, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_18, NULL, TransactionScope_Dispose_mD59AC22CF6811FA85272C31E4DBE98C655571807_RuntimeMethod_var);
	}

IL_009f:
	{
		bool L_19 = __this->get_asyncFlowEnabled_9();
		if (!L_19)
		{
			goto IL_013f;
		}
	}
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_20 = __this->get_oldTransaction_2();
		bool L_21 = Transaction_op_Inequality_mB8AC9FA5FD15CC891FBAD3058A7E01FFE3797C00(L_20, (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 *)NULL, /*hidden argument*/NULL);
		if (!L_21)
		{
			goto IL_00c9;
		}
	}
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_22 = __this->get_oldTransaction_2();
		TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 * L_23 = __this->get_parentScope_3();
		NullCheck(L_22);
		Transaction_set_Scope_m7D0B5FA981676EC749DEEE0136902EDE9D6C259F(L_22, L_23, /*hidden argument*/NULL);
	}

IL_00c9:
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_24 = Transaction_get_CurrentInternal_mD2ADB6241C7D4AD453E70854F9917DCB38F20424(/*hidden argument*/NULL);
		V_0 = L_24;
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_25 = __this->get_transaction_1();
		bool L_26 = Transaction_op_Equality_m3922A8F89D6B043AEC236B180B1D6CD0C6C139FA(L_25, (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 *)NULL, /*hidden argument*/NULL);
		if (!L_26)
		{
			goto IL_00e7;
		}
	}
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_27 = V_0;
		bool L_28 = Transaction_op_Equality_m3922A8F89D6B043AEC236B180B1D6CD0C6C139FA(L_27, (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 *)NULL, /*hidden argument*/NULL);
		if (!L_28)
		{
			goto IL_00e7;
		}
	}
	{
		return;
	}

IL_00e7:
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_29 = V_0;
		TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 * L_30 = __this->get_parentScope_3();
		NullCheck(L_29);
		Transaction_set_Scope_m7D0B5FA981676EC749DEEE0136902EDE9D6C259F(L_29, L_30, /*hidden argument*/NULL);
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_31 = __this->get_oldTransaction_2();
		Transaction_set_CurrentInternal_m1505D3EF6C939658083C98A79445D586477E99EF(L_31, /*hidden argument*/NULL);
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_32 = __this->get_transaction_1();
		NullCheck(L_32);
		Transaction_set_Scope_m7D0B5FA981676EC749DEEE0136902EDE9D6C259F(L_32, (TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 *)NULL, /*hidden argument*/NULL);
		bool L_33 = TransactionScope_get_IsComplete_m435B2667F1FC8FC00F8D70F53B196EABEC2385E5(__this, /*hidden argument*/NULL);
		if (L_33)
		{
			goto IL_0124;
		}
	}
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_34 = __this->get_transaction_1();
		NullCheck(L_34);
		Transaction_Rollback_mD1E2C0BAC184FDF71F005870731C0197A61651B6(L_34, /*hidden argument*/NULL);
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_35 = V_0;
		NullCheck(L_35);
		Transaction_Rollback_mD1E2C0BAC184FDF71F005870731C0197A61651B6(L_35, /*hidden argument*/NULL);
		return;
	}

IL_0124:
	{
		bool L_36 = __this->get_isRoot_8();
		if (L_36)
		{
			goto IL_012d;
		}
	}
	{
		return;
	}

IL_012d:
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_37 = V_0;
		NullCheck(L_37);
		Transaction_CommitInternal_mBAF35E65DD83B90A5FEE1A2B5E927A4D0EA31754(L_37, /*hidden argument*/NULL);
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_38 = __this->get_transaction_1();
		NullCheck(L_38);
		Transaction_CommitInternal_mBAF35E65DD83B90A5FEE1A2B5E927A4D0EA31754(L_38, /*hidden argument*/NULL);
		return;
	}

IL_013f:
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_39 = Transaction_get_CurrentInternal_mD2ADB6241C7D4AD453E70854F9917DCB38F20424(/*hidden argument*/NULL);
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_40 = __this->get_oldTransaction_2();
		bool L_41 = Transaction_op_Equality_m3922A8F89D6B043AEC236B180B1D6CD0C6C139FA(L_39, L_40, /*hidden argument*/NULL);
		if (!L_41)
		{
			goto IL_0170;
		}
	}
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_42 = __this->get_oldTransaction_2();
		bool L_43 = Transaction_op_Inequality_mB8AC9FA5FD15CC891FBAD3058A7E01FFE3797C00(L_42, (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 *)NULL, /*hidden argument*/NULL);
		if (!L_43)
		{
			goto IL_0170;
		}
	}
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_44 = __this->get_oldTransaction_2();
		TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 * L_45 = __this->get_parentScope_3();
		NullCheck(L_44);
		Transaction_set_Scope_m7D0B5FA981676EC749DEEE0136902EDE9D6C259F(L_44, L_45, /*hidden argument*/NULL);
	}

IL_0170:
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_46 = __this->get_oldTransaction_2();
		Transaction_set_CurrentInternal_m1505D3EF6C939658083C98A79445D586477E99EF(L_46, /*hidden argument*/NULL);
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_47 = __this->get_transaction_1();
		bool L_48 = Transaction_op_Equality_m3922A8F89D6B043AEC236B180B1D6CD0C6C139FA(L_47, (Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 *)NULL, /*hidden argument*/NULL);
		if (!L_48)
		{
			goto IL_018a;
		}
	}
	{
		return;
	}

IL_018a:
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_49 = __this->get_transaction_1();
		NullCheck(L_49);
		Transaction_set_Scope_m7D0B5FA981676EC749DEEE0136902EDE9D6C259F(L_49, (TransactionScope_t92F03DF5872F107284A443999A34977F918A6613 *)NULL, /*hidden argument*/NULL);
		bool L_50 = TransactionScope_get_IsComplete_m435B2667F1FC8FC00F8D70F53B196EABEC2385E5(__this, /*hidden argument*/NULL);
		if (L_50)
		{
			goto IL_01aa;
		}
	}
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_51 = __this->get_transaction_1();
		NullCheck(L_51);
		Transaction_Rollback_mD1E2C0BAC184FDF71F005870731C0197A61651B6(L_51, /*hidden argument*/NULL);
		return;
	}

IL_01aa:
	{
		bool L_52 = __this->get_isRoot_8();
		if (L_52)
		{
			goto IL_01b3;
		}
	}
	{
		return;
	}

IL_01b3:
	{
		Transaction_tCE6846BE0210EDE818811BF23767BC3798241D10 * L_53 = __this->get_transaction_1();
		NullCheck(L_53);
		Transaction_CommitInternal_mBAF35E65DD83B90A5FEE1A2B5E927A4D0EA31754(L_53, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.Transactions.TransactionScope::.cctor()
extern "C" IL2CPP_METHOD_ATTR void TransactionScope__cctor_m1E1B2A2CACEC45BC8AE2606E324AEE134C428B28 (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (TransactionScope__cctor_m1E1B2A2CACEC45BC8AE2606E324AEE134C428B28_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(TransactionManager_t89B5F1C0446C7A1D72FEB287569D47BAB58BBB64_il2cpp_TypeInfo_var);
		TimeSpan_tA8069278ACE8A74D6DF7D514A9CD4432433F64C4  L_0 = TransactionManager_get_DefaultTimeout_m787C350D9D35FF5E68D4C02EB9003148180EA76B(/*hidden argument*/NULL);
		TransactionOptions_tCFA1D94672A401FA16F36ECAE0EE5EBE3008F70F  L_1;
		memset(&L_1, 0, sizeof(L_1));
		TransactionOptions__ctor_m55CFF612EB0B67FBB7B63790EBBF57DC1F51CB95((&L_1), 0, L_0, /*hidden argument*/NULL);
		((TransactionScope_t92F03DF5872F107284A443999A34977F918A6613_StaticFields*)il2cpp_codegen_static_fields_for(TransactionScope_t92F03DF5872F107284A443999A34977F918A6613_il2cpp_TypeInfo_var))->set_defaultOptions_0(L_1);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
