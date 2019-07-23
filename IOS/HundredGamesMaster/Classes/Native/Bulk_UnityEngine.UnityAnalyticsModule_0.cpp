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

template <typename T1, typename T2, typename T3, typename T4>
struct VirtActionInvoker4
{
	typedef void (*Action)(void*, T1, T2, T3, T4, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, invokeData.method);
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
struct VirtActionInvoker0
{
	typedef void (*Action)(void*, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4>
struct GenericVirtActionInvoker4
{
	typedef void (*Action)(void*, T1, T2, T3, T4, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_virtual_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, invokeData.method);
	}
};
struct GenericVirtActionInvoker0
{
	typedef void (*Action)(void*, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_virtual_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4>
struct InterfaceActionInvoker4
{
	typedef void (*Action)(void*, T1, T2, T3, T4, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, invokeData.method);
	}
};
template <typename R>
struct InterfaceFuncInvoker0
{
	typedef R (*Func)(void*, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		return ((Func)invokeData.methodPtr)(obj, invokeData.method);
	}
};
struct InterfaceActionInvoker0
{
	typedef void (*Action)(void*, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4>
struct GenericInterfaceActionInvoker4
{
	typedef void (*Action)(void*, T1, T2, T3, T4, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_interface_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, invokeData.method);
	}
};
struct GenericInterfaceActionInvoker0
{
	typedef void (*Action)(void*, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_interface_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, invokeData.method);
	}
};

// System.Action
struct Action_t591D2A86165F896B4B800BB5C25CE18672A55579;
// System.Action`1<System.Boolean>
struct Action_1_tAA0F894C98302D68F7D5034E8104E9AB4763CCAD;
// System.Action`3<System.Boolean,System.Boolean,System.Int32>
struct Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E;
// System.ArgumentException
struct ArgumentException_tEDCD16F20A09ECE461C3DA766C16EDA8864057D1;
// System.AsyncCallback
struct AsyncCallback_t3F3DA3BEDAEE81DD1D24125DF8EB30E85EE14DA4;
// System.Byte[]
struct ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821;
// System.Char[]
struct CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2;
// System.Collections.Generic.IDictionary`2<System.String,System.Object>
struct IDictionary_2_t6AF508DE18DA398DBB91330BEEB14B0CFBD4A8ED;
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
// System.IAsyncResult
struct IAsyncResult_t8E194308510B375B42432981AE5E7488C458D598;
// System.IntPtr[]
struct IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD;
// System.Reflection.Binder
struct Binder_t4D5CB06963501D32847C057B57157D6DC49CA759;
// System.Reflection.MemberFilter
struct MemberFilter_t25C1BD92C42BE94426E300787C13C452CB89B381;
// System.Reflection.MethodInfo
struct MethodInfo_t;
// System.Runtime.Serialization.SafeSerializationManager
struct SafeSerializationManager_t4A754D86B0F784B18CBC36C073BA564BED109770;
// System.String
struct String_t;
// System.Type
struct Type_t;
// System.Type[]
struct TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F;
// System.UInt32[]
struct UInt32U5BU5D_t9AA834AF2940E75BBF8E3F08FF0D20D266DB71CB;
// System.Void
struct Void_t22962CB4C05B1D89B55A6E1139F0E87A90987017;
// UnityEngine.Analytics.AnalyticsSessionInfo/SessionStateChanged
struct SessionStateChanged_t9084549A636BD45086D66CC6765DA8C3DD31066F;
// UnityEngine.Analytics.CustomEventData
struct CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37;
// UnityEngine.RemoteConfigSettings
struct RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A;
// UnityEngine.RemoteSettings/UpdatedEventHandler
struct UpdatedEventHandler_tB0230BC83686D7126AB4D3800A66351028CA514F;

extern RuntimeClass* Action_1_tAA0F894C98302D68F7D5034E8104E9AB4763CCAD_il2cpp_TypeInfo_var;
extern RuntimeClass* Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E_il2cpp_TypeInfo_var;
extern RuntimeClass* AnalyticsSessionInfo_tE075F764A74D2B095CFD57F3B179397F504B7D8C_il2cpp_TypeInfo_var;
extern RuntimeClass* AnalyticsSessionState_t61CA873937E9A3B881B71B32F518A954A4C8F267_il2cpp_TypeInfo_var;
extern RuntimeClass* ArgumentException_tEDCD16F20A09ECE461C3DA766C16EDA8864057D1_il2cpp_TypeInfo_var;
extern RuntimeClass* Boolean_tB53F6830F670160873277339AA58F15CAED4399C_il2cpp_TypeInfo_var;
extern RuntimeClass* Byte_tF87C579059BD4633E6840EBBBEEF899C6E33EF07_il2cpp_TypeInfo_var;
extern RuntimeClass* Char_tBF22D9FC341BE970735250BB6FF1A4A92BBA58B9_il2cpp_TypeInfo_var;
extern RuntimeClass* Convert_t1C7A851BFB2F0782FD7F72F6AA1DCBB7B53A9C7E_il2cpp_TypeInfo_var;
extern RuntimeClass* CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37_il2cpp_TypeInfo_var;
extern RuntimeClass* Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8_il2cpp_TypeInfo_var;
extern RuntimeClass* Double_t358B8F23BDC52A5DD700E727E204F9F7CDE12409_il2cpp_TypeInfo_var;
extern RuntimeClass* GC_tC1D7BD74E8F44ECCEF5CD2B5D84BFF9AAE02D01D_il2cpp_TypeInfo_var;
extern RuntimeClass* IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var;
extern RuntimeClass* IEnumerable_1_t228E0A04E82D18717D57712E2B1A5A685AD987C9_il2cpp_TypeInfo_var;
extern RuntimeClass* IEnumerator_1_t13E977F5B7D3467DB6E01785432A3C4E21E4CDE0_il2cpp_TypeInfo_var;
extern RuntimeClass* IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var;
extern RuntimeClass* Int16_t823A20635DAF5A3D93A1E01CFBF3CBA27CF00B4D_il2cpp_TypeInfo_var;
extern RuntimeClass* Int32_t585191389E07734F19F3156FF88FB3EF4800D102_il2cpp_TypeInfo_var;
extern RuntimeClass* Int64_t7A386C2FF7B0280A0F516992401DDFCF0FF7B436_il2cpp_TypeInfo_var;
extern RuntimeClass* IntPtr_t_il2cpp_TypeInfo_var;
extern RuntimeClass* RemoteSettings_t3F7E07D15288B0DF84A4A32044592D8AFA6D36ED_il2cpp_TypeInfo_var;
extern RuntimeClass* SByte_t9070AEA2966184235653CB9B4D33B149CDA831DF_il2cpp_TypeInfo_var;
extern RuntimeClass* Single_tDDDA9169C4E4E308AC6D7A824F9B28DC82204AE1_il2cpp_TypeInfo_var;
extern RuntimeClass* String_t_il2cpp_TypeInfo_var;
extern RuntimeClass* Type_t_il2cpp_TypeInfo_var;
extern RuntimeClass* UInt16_tAE45CEF73BF720100519F6867F32145D075F928E_il2cpp_TypeInfo_var;
extern RuntimeClass* UInt32_t4980FA09003AFAAB5A6E361BA2748EA9A005709B_il2cpp_TypeInfo_var;
extern RuntimeClass* UInt64_tA02DF3B59C8FC4A849BD207DA11038CC64E4CB4E_il2cpp_TypeInfo_var;
extern String_t* _stringLiteral2BE88CA4242C76E8253AC62474851065032D6833;
extern String_t* _stringLiteral351DB7DBABE98AE0DDE4A114100B1D9CFE38CDC8;
extern String_t* _stringLiteral6427E65FC1EB2FCB0B733856926B458525F717D0;
extern String_t* _stringLiteral95142210B034E24DA1953BF3D5DB636DAD468302;
extern String_t* _stringLiteralEF9343981EC10013222A31ABF8393BC213AEAF80;
extern const RuntimeMethod* Action_1_Invoke_m45E8F9900F9DB395C48A868A7C6A83BDD7FC692F_RuntimeMethod_var;
extern const RuntimeMethod* Action_3_Invoke_m8A4240174E60397816F6EACC65FE1E27F4275FA5_RuntimeMethod_var;
extern const RuntimeMethod* Analytics_CustomEvent_mB0F6DDF5C94D0D6540E427B71E4081F443CA6E02_RuntimeMethod_var;
extern const RuntimeMethod* Analytics_Transaction_mEE22A703EE6834D458722D204C7261ECBEFF4612_RuntimeMethod_var;
extern const RuntimeMethod* CustomEventData_AddDictionary_mDA0270C0DE80222EEB3D5B9E6432E59E99C48FA4_RuntimeMethod_var;
extern const RuntimeMethod* KeyValuePair_2_get_Key_mAC09B6950211936EF2A4251B70DF5124DED3CD0B_RuntimeMethod_var;
extern const RuntimeMethod* KeyValuePair_2_get_Value_m5D1180FCE84ACA037CCCF151B9696C4575634758_RuntimeMethod_var;
extern const RuntimeType* Boolean_tB53F6830F670160873277339AA58F15CAED4399C_0_0_0_var;
extern const RuntimeType* Byte_tF87C579059BD4633E6840EBBBEEF899C6E33EF07_0_0_0_var;
extern const RuntimeType* Char_tBF22D9FC341BE970735250BB6FF1A4A92BBA58B9_0_0_0_var;
extern const RuntimeType* Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8_0_0_0_var;
extern const RuntimeType* Double_t358B8F23BDC52A5DD700E727E204F9F7CDE12409_0_0_0_var;
extern const RuntimeType* Int16_t823A20635DAF5A3D93A1E01CFBF3CBA27CF00B4D_0_0_0_var;
extern const RuntimeType* Int32_t585191389E07734F19F3156FF88FB3EF4800D102_0_0_0_var;
extern const RuntimeType* Int64_t7A386C2FF7B0280A0F516992401DDFCF0FF7B436_0_0_0_var;
extern const RuntimeType* SByte_t9070AEA2966184235653CB9B4D33B149CDA831DF_0_0_0_var;
extern const RuntimeType* Single_tDDDA9169C4E4E308AC6D7A824F9B28DC82204AE1_0_0_0_var;
extern const RuntimeType* String_t_0_0_0_var;
extern const RuntimeType* UInt16_tAE45CEF73BF720100519F6867F32145D075F928E_0_0_0_var;
extern const RuntimeType* UInt32_t4980FA09003AFAAB5A6E361BA2748EA9A005709B_0_0_0_var;
extern const RuntimeType* UInt64_tA02DF3B59C8FC4A849BD207DA11038CC64E4CB4E_0_0_0_var;
extern const uint32_t AnalyticsSessionInfo_CallSessionStateChanged_mB5E3A42407B97BD8A6A4827FADDA91DB85B0F294_MetadataUsageId;
extern const uint32_t Analytics_CustomEvent_mB0F6DDF5C94D0D6540E427B71E4081F443CA6E02_MetadataUsageId;
extern const uint32_t Analytics_Transaction_mEE22A703EE6834D458722D204C7261ECBEFF4612_MetadataUsageId;
extern const uint32_t CustomEventData_AddDictionary_mDA0270C0DE80222EEB3D5B9E6432E59E99C48FA4_MetadataUsageId;
extern const uint32_t CustomEventData_Destroy_m60BE08121AFF38808FBD62CC9BF5929E30C444CA_MetadataUsageId;
extern const uint32_t CustomEventData_Dispose_m62D34DC34233E96231793EB2A3F165ED17C29B6C_MetadataUsageId;
extern const uint32_t RemoteConfigSettings_Destroy_m91215D772DF190B8AD9A73C8165DEDBE129C7A10_MetadataUsageId;
extern const uint32_t RemoteConfigSettings_Dispose_m0A43CAB1AE923C6D6D7854A9F78B8842E8E1F39E_MetadataUsageId;
extern const uint32_t RemoteConfigSettings_RemoteConfigSettingsUpdated_mF72E8C9F99B752FEA9EA388CCC1EFECC24733504_MetadataUsageId;
extern const uint32_t RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A_com_FromNativeMethodDefinition_MetadataUsageId;
extern const uint32_t RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A_pinvoke_FromNativeMethodDefinition_MetadataUsageId;
extern const uint32_t RemoteSettings_RemoteSettingsBeforeFetchFromServer_mBF1BEF2ACAFE13AE7B820FCA5CB7B81CF614EF11_MetadataUsageId;
extern const uint32_t RemoteSettings_RemoteSettingsUpdateCompleted_m6C6C3568C5A8F319CD06F8303111F06AB3718A02_MetadataUsageId;
extern const uint32_t RemoteSettings_RemoteSettingsUpdated_mD5427A08A622FDAA576A3D9CF05AD4C7CC6102F5_MetadataUsageId;
extern const uint32_t RemoteSettings_add_Completed_m8BD179217DCB0B9561DF18871458096979F64002_MetadataUsageId;
extern const uint32_t RemoteSettings_remove_Completed_m396F802C4D5DD73B3FC54522705C974CB3E28D97_MetadataUsageId;
extern const uint32_t SessionStateChanged_BeginInvoke_mD75E6832EC29F8B01CEEAAACD5DC54322F03D4B3_MetadataUsageId;
struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;

struct DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86;


#ifndef U3CMODULEU3E_TCD4309F8DDA0F37A98DBCDFE49F6C8F300C242B0_H
#define U3CMODULEU3E_TCD4309F8DDA0F37A98DBCDFE49F6C8F300C242B0_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct  U3CModuleU3E_tCD4309F8DDA0F37A98DBCDFE49F6C8F300C242B0 
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // U3CMODULEU3E_TCD4309F8DDA0F37A98DBCDFE49F6C8F300C242B0_H
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
#ifndef MEMBERINFO_T_H
#define MEMBERINFO_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Reflection.MemberInfo
struct  MemberInfo_t  : public RuntimeObject
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MEMBERINFO_T_H
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
#ifndef ANALYTICS_TCA6E11F003D5B8AD0A5F0780BF5954566C7EB724_H
#define ANALYTICS_TCA6E11F003D5B8AD0A5F0780BF5954566C7EB724_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Analytics.Analytics
struct  Analytics_tCA6E11F003D5B8AD0A5F0780BF5954566C7EB724  : public RuntimeObject
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.Analytics.Analytics
struct Analytics_tCA6E11F003D5B8AD0A5F0780BF5954566C7EB724_marshaled_pinvoke
{
};
// Native definition for COM marshalling of UnityEngine.Analytics.Analytics
struct Analytics_tCA6E11F003D5B8AD0A5F0780BF5954566C7EB724_marshaled_com
{
};
#endif // ANALYTICS_TCA6E11F003D5B8AD0A5F0780BF5954566C7EB724_H
#ifndef ANALYTICSSESSIONINFO_TE075F764A74D2B095CFD57F3B179397F504B7D8C_H
#define ANALYTICSSESSIONINFO_TE075F764A74D2B095CFD57F3B179397F504B7D8C_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Analytics.AnalyticsSessionInfo
struct  AnalyticsSessionInfo_tE075F764A74D2B095CFD57F3B179397F504B7D8C  : public RuntimeObject
{
public:

public:
};

struct AnalyticsSessionInfo_tE075F764A74D2B095CFD57F3B179397F504B7D8C_StaticFields
{
public:
	// UnityEngine.Analytics.AnalyticsSessionInfo_SessionStateChanged UnityEngine.Analytics.AnalyticsSessionInfo::sessionStateChanged
	SessionStateChanged_t9084549A636BD45086D66CC6765DA8C3DD31066F * ___sessionStateChanged_0;

public:
	inline static int32_t get_offset_of_sessionStateChanged_0() { return static_cast<int32_t>(offsetof(AnalyticsSessionInfo_tE075F764A74D2B095CFD57F3B179397F504B7D8C_StaticFields, ___sessionStateChanged_0)); }
	inline SessionStateChanged_t9084549A636BD45086D66CC6765DA8C3DD31066F * get_sessionStateChanged_0() const { return ___sessionStateChanged_0; }
	inline SessionStateChanged_t9084549A636BD45086D66CC6765DA8C3DD31066F ** get_address_of_sessionStateChanged_0() { return &___sessionStateChanged_0; }
	inline void set_sessionStateChanged_0(SessionStateChanged_t9084549A636BD45086D66CC6765DA8C3DD31066F * value)
	{
		___sessionStateChanged_0 = value;
		Il2CppCodeGenWriteBarrier((&___sessionStateChanged_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ANALYTICSSESSIONINFO_TE075F764A74D2B095CFD57F3B179397F504B7D8C_H
#ifndef CONTINUOUSEVENT_TBAB6336255F3FC327CBA03CE368CD4D8D027107A_H
#define CONTINUOUSEVENT_TBAB6336255F3FC327CBA03CE368CD4D8D027107A_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Analytics.ContinuousEvent
struct  ContinuousEvent_tBAB6336255F3FC327CBA03CE368CD4D8D027107A  : public RuntimeObject
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // CONTINUOUSEVENT_TBAB6336255F3FC327CBA03CE368CD4D8D027107A_H
#ifndef REMOTESETTINGS_T3F7E07D15288B0DF84A4A32044592D8AFA6D36ED_H
#define REMOTESETTINGS_T3F7E07D15288B0DF84A4A32044592D8AFA6D36ED_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.RemoteSettings
struct  RemoteSettings_t3F7E07D15288B0DF84A4A32044592D8AFA6D36ED  : public RuntimeObject
{
public:

public:
};

struct RemoteSettings_t3F7E07D15288B0DF84A4A32044592D8AFA6D36ED_StaticFields
{
public:
	// UnityEngine.RemoteSettings_UpdatedEventHandler UnityEngine.RemoteSettings::Updated
	UpdatedEventHandler_tB0230BC83686D7126AB4D3800A66351028CA514F * ___Updated_0;
	// System.Action UnityEngine.RemoteSettings::BeforeFetchFromServer
	Action_t591D2A86165F896B4B800BB5C25CE18672A55579 * ___BeforeFetchFromServer_1;
	// System.Action`3<System.Boolean,System.Boolean,System.Int32> UnityEngine.RemoteSettings::Completed
	Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * ___Completed_2;

public:
	inline static int32_t get_offset_of_Updated_0() { return static_cast<int32_t>(offsetof(RemoteSettings_t3F7E07D15288B0DF84A4A32044592D8AFA6D36ED_StaticFields, ___Updated_0)); }
	inline UpdatedEventHandler_tB0230BC83686D7126AB4D3800A66351028CA514F * get_Updated_0() const { return ___Updated_0; }
	inline UpdatedEventHandler_tB0230BC83686D7126AB4D3800A66351028CA514F ** get_address_of_Updated_0() { return &___Updated_0; }
	inline void set_Updated_0(UpdatedEventHandler_tB0230BC83686D7126AB4D3800A66351028CA514F * value)
	{
		___Updated_0 = value;
		Il2CppCodeGenWriteBarrier((&___Updated_0), value);
	}

	inline static int32_t get_offset_of_BeforeFetchFromServer_1() { return static_cast<int32_t>(offsetof(RemoteSettings_t3F7E07D15288B0DF84A4A32044592D8AFA6D36ED_StaticFields, ___BeforeFetchFromServer_1)); }
	inline Action_t591D2A86165F896B4B800BB5C25CE18672A55579 * get_BeforeFetchFromServer_1() const { return ___BeforeFetchFromServer_1; }
	inline Action_t591D2A86165F896B4B800BB5C25CE18672A55579 ** get_address_of_BeforeFetchFromServer_1() { return &___BeforeFetchFromServer_1; }
	inline void set_BeforeFetchFromServer_1(Action_t591D2A86165F896B4B800BB5C25CE18672A55579 * value)
	{
		___BeforeFetchFromServer_1 = value;
		Il2CppCodeGenWriteBarrier((&___BeforeFetchFromServer_1), value);
	}

	inline static int32_t get_offset_of_Completed_2() { return static_cast<int32_t>(offsetof(RemoteSettings_t3F7E07D15288B0DF84A4A32044592D8AFA6D36ED_StaticFields, ___Completed_2)); }
	inline Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * get_Completed_2() const { return ___Completed_2; }
	inline Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E ** get_address_of_Completed_2() { return &___Completed_2; }
	inline void set_Completed_2(Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * value)
	{
		___Completed_2 = value;
		Il2CppCodeGenWriteBarrier((&___Completed_2), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // REMOTESETTINGS_T3F7E07D15288B0DF84A4A32044592D8AFA6D36ED_H
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
#ifndef BYTE_TF87C579059BD4633E6840EBBBEEF899C6E33EF07_H
#define BYTE_TF87C579059BD4633E6840EBBBEEF899C6E33EF07_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Byte
struct  Byte_tF87C579059BD4633E6840EBBBEEF899C6E33EF07 
{
public:
	// System.Byte System.Byte::m_value
	uint8_t ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Byte_tF87C579059BD4633E6840EBBBEEF899C6E33EF07, ___m_value_0)); }
	inline uint8_t get_m_value_0() const { return ___m_value_0; }
	inline uint8_t* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(uint8_t value)
	{
		___m_value_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // BYTE_TF87C579059BD4633E6840EBBBEEF899C6E33EF07_H
#ifndef CHAR_TBF22D9FC341BE970735250BB6FF1A4A92BBA58B9_H
#define CHAR_TBF22D9FC341BE970735250BB6FF1A4A92BBA58B9_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Char
struct  Char_tBF22D9FC341BE970735250BB6FF1A4A92BBA58B9 
{
public:
	// System.Char System.Char::m_value
	Il2CppChar ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Char_tBF22D9FC341BE970735250BB6FF1A4A92BBA58B9, ___m_value_0)); }
	inline Il2CppChar get_m_value_0() const { return ___m_value_0; }
	inline Il2CppChar* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(Il2CppChar value)
	{
		___m_value_0 = value;
	}
};

struct Char_tBF22D9FC341BE970735250BB6FF1A4A92BBA58B9_StaticFields
{
public:
	// System.Byte[] System.Char::categoryForLatin1
	ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___categoryForLatin1_3;

public:
	inline static int32_t get_offset_of_categoryForLatin1_3() { return static_cast<int32_t>(offsetof(Char_tBF22D9FC341BE970735250BB6FF1A4A92BBA58B9_StaticFields, ___categoryForLatin1_3)); }
	inline ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* get_categoryForLatin1_3() const { return ___categoryForLatin1_3; }
	inline ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821** get_address_of_categoryForLatin1_3() { return &___categoryForLatin1_3; }
	inline void set_categoryForLatin1_3(ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* value)
	{
		___categoryForLatin1_3 = value;
		Il2CppCodeGenWriteBarrier((&___categoryForLatin1_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // CHAR_TBF22D9FC341BE970735250BB6FF1A4A92BBA58B9_H
#ifndef KEYVALUEPAIR_2_T23481547E419E16E3B96A303578C1EB685C99EEE_H
#define KEYVALUEPAIR_2_T23481547E419E16E3B96A303578C1EB685C99EEE_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.KeyValuePair`2<System.Object,System.Object>
struct  KeyValuePair_2_t23481547E419E16E3B96A303578C1EB685C99EEE 
{
public:
	// TKey System.Collections.Generic.KeyValuePair`2::key
	RuntimeObject * ___key_0;
	// TValue System.Collections.Generic.KeyValuePair`2::value
	RuntimeObject * ___value_1;

public:
	inline static int32_t get_offset_of_key_0() { return static_cast<int32_t>(offsetof(KeyValuePair_2_t23481547E419E16E3B96A303578C1EB685C99EEE, ___key_0)); }
	inline RuntimeObject * get_key_0() const { return ___key_0; }
	inline RuntimeObject ** get_address_of_key_0() { return &___key_0; }
	inline void set_key_0(RuntimeObject * value)
	{
		___key_0 = value;
		Il2CppCodeGenWriteBarrier((&___key_0), value);
	}

	inline static int32_t get_offset_of_value_1() { return static_cast<int32_t>(offsetof(KeyValuePair_2_t23481547E419E16E3B96A303578C1EB685C99EEE, ___value_1)); }
	inline RuntimeObject * get_value_1() const { return ___value_1; }
	inline RuntimeObject ** get_address_of_value_1() { return &___value_1; }
	inline void set_value_1(RuntimeObject * value)
	{
		___value_1 = value;
		Il2CppCodeGenWriteBarrier((&___value_1), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // KEYVALUEPAIR_2_T23481547E419E16E3B96A303578C1EB685C99EEE_H
#ifndef KEYVALUEPAIR_2_TBC573EE45BE549307D189378677DF98C3A6C8059_H
#define KEYVALUEPAIR_2_TBC573EE45BE549307D189378677DF98C3A6C8059_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.KeyValuePair`2<System.String,System.Object>
struct  KeyValuePair_2_tBC573EE45BE549307D189378677DF98C3A6C8059 
{
public:
	// TKey System.Collections.Generic.KeyValuePair`2::key
	String_t* ___key_0;
	// TValue System.Collections.Generic.KeyValuePair`2::value
	RuntimeObject * ___value_1;

public:
	inline static int32_t get_offset_of_key_0() { return static_cast<int32_t>(offsetof(KeyValuePair_2_tBC573EE45BE549307D189378677DF98C3A6C8059, ___key_0)); }
	inline String_t* get_key_0() const { return ___key_0; }
	inline String_t** get_address_of_key_0() { return &___key_0; }
	inline void set_key_0(String_t* value)
	{
		___key_0 = value;
		Il2CppCodeGenWriteBarrier((&___key_0), value);
	}

	inline static int32_t get_offset_of_value_1() { return static_cast<int32_t>(offsetof(KeyValuePair_2_tBC573EE45BE549307D189378677DF98C3A6C8059, ___value_1)); }
	inline RuntimeObject * get_value_1() const { return ___value_1; }
	inline RuntimeObject ** get_address_of_value_1() { return &___value_1; }
	inline void set_value_1(RuntimeObject * value)
	{
		___value_1 = value;
		Il2CppCodeGenWriteBarrier((&___value_1), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // KEYVALUEPAIR_2_TBC573EE45BE549307D189378677DF98C3A6C8059_H
#ifndef DECIMAL_T44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8_H
#define DECIMAL_T44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Decimal
struct  Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8 
{
public:
	// System.Int32 System.Decimal::flags
	int32_t ___flags_14;
	// System.Int32 System.Decimal::hi
	int32_t ___hi_15;
	// System.Int32 System.Decimal::lo
	int32_t ___lo_16;
	// System.Int32 System.Decimal::mid
	int32_t ___mid_17;

public:
	inline static int32_t get_offset_of_flags_14() { return static_cast<int32_t>(offsetof(Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8, ___flags_14)); }
	inline int32_t get_flags_14() const { return ___flags_14; }
	inline int32_t* get_address_of_flags_14() { return &___flags_14; }
	inline void set_flags_14(int32_t value)
	{
		___flags_14 = value;
	}

	inline static int32_t get_offset_of_hi_15() { return static_cast<int32_t>(offsetof(Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8, ___hi_15)); }
	inline int32_t get_hi_15() const { return ___hi_15; }
	inline int32_t* get_address_of_hi_15() { return &___hi_15; }
	inline void set_hi_15(int32_t value)
	{
		___hi_15 = value;
	}

	inline static int32_t get_offset_of_lo_16() { return static_cast<int32_t>(offsetof(Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8, ___lo_16)); }
	inline int32_t get_lo_16() const { return ___lo_16; }
	inline int32_t* get_address_of_lo_16() { return &___lo_16; }
	inline void set_lo_16(int32_t value)
	{
		___lo_16 = value;
	}

	inline static int32_t get_offset_of_mid_17() { return static_cast<int32_t>(offsetof(Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8, ___mid_17)); }
	inline int32_t get_mid_17() const { return ___mid_17; }
	inline int32_t* get_address_of_mid_17() { return &___mid_17; }
	inline void set_mid_17(int32_t value)
	{
		___mid_17 = value;
	}
};

struct Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8_StaticFields
{
public:
	// System.UInt32[] System.Decimal::Powers10
	UInt32U5BU5D_t9AA834AF2940E75BBF8E3F08FF0D20D266DB71CB* ___Powers10_6;
	// System.Decimal System.Decimal::Zero
	Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  ___Zero_7;
	// System.Decimal System.Decimal::One
	Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  ___One_8;
	// System.Decimal System.Decimal::MinusOne
	Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  ___MinusOne_9;
	// System.Decimal System.Decimal::MaxValue
	Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  ___MaxValue_10;
	// System.Decimal System.Decimal::MinValue
	Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  ___MinValue_11;
	// System.Decimal System.Decimal::NearNegativeZero
	Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  ___NearNegativeZero_12;
	// System.Decimal System.Decimal::NearPositiveZero
	Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  ___NearPositiveZero_13;

public:
	inline static int32_t get_offset_of_Powers10_6() { return static_cast<int32_t>(offsetof(Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8_StaticFields, ___Powers10_6)); }
	inline UInt32U5BU5D_t9AA834AF2940E75BBF8E3F08FF0D20D266DB71CB* get_Powers10_6() const { return ___Powers10_6; }
	inline UInt32U5BU5D_t9AA834AF2940E75BBF8E3F08FF0D20D266DB71CB** get_address_of_Powers10_6() { return &___Powers10_6; }
	inline void set_Powers10_6(UInt32U5BU5D_t9AA834AF2940E75BBF8E3F08FF0D20D266DB71CB* value)
	{
		___Powers10_6 = value;
		Il2CppCodeGenWriteBarrier((&___Powers10_6), value);
	}

	inline static int32_t get_offset_of_Zero_7() { return static_cast<int32_t>(offsetof(Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8_StaticFields, ___Zero_7)); }
	inline Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  get_Zero_7() const { return ___Zero_7; }
	inline Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8 * get_address_of_Zero_7() { return &___Zero_7; }
	inline void set_Zero_7(Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  value)
	{
		___Zero_7 = value;
	}

	inline static int32_t get_offset_of_One_8() { return static_cast<int32_t>(offsetof(Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8_StaticFields, ___One_8)); }
	inline Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  get_One_8() const { return ___One_8; }
	inline Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8 * get_address_of_One_8() { return &___One_8; }
	inline void set_One_8(Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  value)
	{
		___One_8 = value;
	}

	inline static int32_t get_offset_of_MinusOne_9() { return static_cast<int32_t>(offsetof(Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8_StaticFields, ___MinusOne_9)); }
	inline Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  get_MinusOne_9() const { return ___MinusOne_9; }
	inline Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8 * get_address_of_MinusOne_9() { return &___MinusOne_9; }
	inline void set_MinusOne_9(Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  value)
	{
		___MinusOne_9 = value;
	}

	inline static int32_t get_offset_of_MaxValue_10() { return static_cast<int32_t>(offsetof(Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8_StaticFields, ___MaxValue_10)); }
	inline Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  get_MaxValue_10() const { return ___MaxValue_10; }
	inline Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8 * get_address_of_MaxValue_10() { return &___MaxValue_10; }
	inline void set_MaxValue_10(Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  value)
	{
		___MaxValue_10 = value;
	}

	inline static int32_t get_offset_of_MinValue_11() { return static_cast<int32_t>(offsetof(Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8_StaticFields, ___MinValue_11)); }
	inline Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  get_MinValue_11() const { return ___MinValue_11; }
	inline Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8 * get_address_of_MinValue_11() { return &___MinValue_11; }
	inline void set_MinValue_11(Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  value)
	{
		___MinValue_11 = value;
	}

	inline static int32_t get_offset_of_NearNegativeZero_12() { return static_cast<int32_t>(offsetof(Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8_StaticFields, ___NearNegativeZero_12)); }
	inline Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  get_NearNegativeZero_12() const { return ___NearNegativeZero_12; }
	inline Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8 * get_address_of_NearNegativeZero_12() { return &___NearNegativeZero_12; }
	inline void set_NearNegativeZero_12(Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  value)
	{
		___NearNegativeZero_12 = value;
	}

	inline static int32_t get_offset_of_NearPositiveZero_13() { return static_cast<int32_t>(offsetof(Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8_StaticFields, ___NearPositiveZero_13)); }
	inline Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  get_NearPositiveZero_13() const { return ___NearPositiveZero_13; }
	inline Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8 * get_address_of_NearPositiveZero_13() { return &___NearPositiveZero_13; }
	inline void set_NearPositiveZero_13(Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  value)
	{
		___NearPositiveZero_13 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // DECIMAL_T44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8_H
#ifndef DOUBLE_T358B8F23BDC52A5DD700E727E204F9F7CDE12409_H
#define DOUBLE_T358B8F23BDC52A5DD700E727E204F9F7CDE12409_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Double
struct  Double_t358B8F23BDC52A5DD700E727E204F9F7CDE12409 
{
public:
	// System.Double System.Double::m_value
	double ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Double_t358B8F23BDC52A5DD700E727E204F9F7CDE12409, ___m_value_0)); }
	inline double get_m_value_0() const { return ___m_value_0; }
	inline double* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(double value)
	{
		___m_value_0 = value;
	}
};

struct Double_t358B8F23BDC52A5DD700E727E204F9F7CDE12409_StaticFields
{
public:
	// System.Double System.Double::NegativeZero
	double ___NegativeZero_7;

public:
	inline static int32_t get_offset_of_NegativeZero_7() { return static_cast<int32_t>(offsetof(Double_t358B8F23BDC52A5DD700E727E204F9F7CDE12409_StaticFields, ___NegativeZero_7)); }
	inline double get_NegativeZero_7() const { return ___NegativeZero_7; }
	inline double* get_address_of_NegativeZero_7() { return &___NegativeZero_7; }
	inline void set_NegativeZero_7(double value)
	{
		___NegativeZero_7 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // DOUBLE_T358B8F23BDC52A5DD700E727E204F9F7CDE12409_H
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
#ifndef INT16_T823A20635DAF5A3D93A1E01CFBF3CBA27CF00B4D_H
#define INT16_T823A20635DAF5A3D93A1E01CFBF3CBA27CF00B4D_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Int16
struct  Int16_t823A20635DAF5A3D93A1E01CFBF3CBA27CF00B4D 
{
public:
	// System.Int16 System.Int16::m_value
	int16_t ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Int16_t823A20635DAF5A3D93A1E01CFBF3CBA27CF00B4D, ___m_value_0)); }
	inline int16_t get_m_value_0() const { return ___m_value_0; }
	inline int16_t* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(int16_t value)
	{
		___m_value_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // INT16_T823A20635DAF5A3D93A1E01CFBF3CBA27CF00B4D_H
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
#ifndef INT64_T7A386C2FF7B0280A0F516992401DDFCF0FF7B436_H
#define INT64_T7A386C2FF7B0280A0F516992401DDFCF0FF7B436_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Int64
struct  Int64_t7A386C2FF7B0280A0F516992401DDFCF0FF7B436 
{
public:
	// System.Int64 System.Int64::m_value
	int64_t ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Int64_t7A386C2FF7B0280A0F516992401DDFCF0FF7B436, ___m_value_0)); }
	inline int64_t get_m_value_0() const { return ___m_value_0; }
	inline int64_t* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(int64_t value)
	{
		___m_value_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // INT64_T7A386C2FF7B0280A0F516992401DDFCF0FF7B436_H
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
#ifndef SBYTE_T9070AEA2966184235653CB9B4D33B149CDA831DF_H
#define SBYTE_T9070AEA2966184235653CB9B4D33B149CDA831DF_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.SByte
struct  SByte_t9070AEA2966184235653CB9B4D33B149CDA831DF 
{
public:
	// System.SByte System.SByte::m_value
	int8_t ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(SByte_t9070AEA2966184235653CB9B4D33B149CDA831DF, ___m_value_0)); }
	inline int8_t get_m_value_0() const { return ___m_value_0; }
	inline int8_t* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(int8_t value)
	{
		___m_value_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SBYTE_T9070AEA2966184235653CB9B4D33B149CDA831DF_H
#ifndef SINGLE_TDDDA9169C4E4E308AC6D7A824F9B28DC82204AE1_H
#define SINGLE_TDDDA9169C4E4E308AC6D7A824F9B28DC82204AE1_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Single
struct  Single_tDDDA9169C4E4E308AC6D7A824F9B28DC82204AE1 
{
public:
	// System.Single System.Single::m_value
	float ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Single_tDDDA9169C4E4E308AC6D7A824F9B28DC82204AE1, ___m_value_0)); }
	inline float get_m_value_0() const { return ___m_value_0; }
	inline float* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(float value)
	{
		___m_value_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SINGLE_TDDDA9169C4E4E308AC6D7A824F9B28DC82204AE1_H
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
#ifndef UINT16_TAE45CEF73BF720100519F6867F32145D075F928E_H
#define UINT16_TAE45CEF73BF720100519F6867F32145D075F928E_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.UInt16
struct  UInt16_tAE45CEF73BF720100519F6867F32145D075F928E 
{
public:
	// System.UInt16 System.UInt16::m_value
	uint16_t ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(UInt16_tAE45CEF73BF720100519F6867F32145D075F928E, ___m_value_0)); }
	inline uint16_t get_m_value_0() const { return ___m_value_0; }
	inline uint16_t* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(uint16_t value)
	{
		___m_value_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UINT16_TAE45CEF73BF720100519F6867F32145D075F928E_H
#ifndef UINT32_T4980FA09003AFAAB5A6E361BA2748EA9A005709B_H
#define UINT32_T4980FA09003AFAAB5A6E361BA2748EA9A005709B_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.UInt32
struct  UInt32_t4980FA09003AFAAB5A6E361BA2748EA9A005709B 
{
public:
	// System.UInt32 System.UInt32::m_value
	uint32_t ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(UInt32_t4980FA09003AFAAB5A6E361BA2748EA9A005709B, ___m_value_0)); }
	inline uint32_t get_m_value_0() const { return ___m_value_0; }
	inline uint32_t* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(uint32_t value)
	{
		___m_value_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UINT32_T4980FA09003AFAAB5A6E361BA2748EA9A005709B_H
#ifndef UINT64_TA02DF3B59C8FC4A849BD207DA11038CC64E4CB4E_H
#define UINT64_TA02DF3B59C8FC4A849BD207DA11038CC64E4CB4E_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.UInt64
struct  UInt64_tA02DF3B59C8FC4A849BD207DA11038CC64E4CB4E 
{
public:
	// System.UInt64 System.UInt64::m_value
	uint64_t ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(UInt64_tA02DF3B59C8FC4A849BD207DA11038CC64E4CB4E, ___m_value_0)); }
	inline uint64_t get_m_value_0() const { return ___m_value_0; }
	inline uint64_t* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(uint64_t value)
	{
		___m_value_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UINT64_TA02DF3B59C8FC4A849BD207DA11038CC64E4CB4E_H
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
#ifndef ARGUMENTEXCEPTION_TEDCD16F20A09ECE461C3DA766C16EDA8864057D1_H
#define ARGUMENTEXCEPTION_TEDCD16F20A09ECE461C3DA766C16EDA8864057D1_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ArgumentException
struct  ArgumentException_tEDCD16F20A09ECE461C3DA766C16EDA8864057D1  : public SystemException_t5380468142AA850BE4A341D7AF3EAB9C78746782
{
public:
	// System.String System.ArgumentException::m_paramName
	String_t* ___m_paramName_17;

public:
	inline static int32_t get_offset_of_m_paramName_17() { return static_cast<int32_t>(offsetof(ArgumentException_tEDCD16F20A09ECE461C3DA766C16EDA8864057D1, ___m_paramName_17)); }
	inline String_t* get_m_paramName_17() const { return ___m_paramName_17; }
	inline String_t** get_address_of_m_paramName_17() { return &___m_paramName_17; }
	inline void set_m_paramName_17(String_t* value)
	{
		___m_paramName_17 = value;
		Il2CppCodeGenWriteBarrier((&___m_paramName_17), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARGUMENTEXCEPTION_TEDCD16F20A09ECE461C3DA766C16EDA8864057D1_H
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
#ifndef BINDINGFLAGS_TE35C91D046E63A1B92BB9AB909FCF9DA84379ED0_H
#define BINDINGFLAGS_TE35C91D046E63A1B92BB9AB909FCF9DA84379ED0_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Reflection.BindingFlags
struct  BindingFlags_tE35C91D046E63A1B92BB9AB909FCF9DA84379ED0 
{
public:
	// System.Int32 System.Reflection.BindingFlags::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(BindingFlags_tE35C91D046E63A1B92BB9AB909FCF9DA84379ED0, ___value___2)); }
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
#endif // BINDINGFLAGS_TE35C91D046E63A1B92BB9AB909FCF9DA84379ED0_H
#ifndef RUNTIMETYPEHANDLE_T7B542280A22F0EC4EAC2061C29178845847A8B2D_H
#define RUNTIMETYPEHANDLE_T7B542280A22F0EC4EAC2061C29178845847A8B2D_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.RuntimeTypeHandle
struct  RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D 
{
public:
	// System.IntPtr System.RuntimeTypeHandle::value
	intptr_t ___value_0;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D, ___value_0)); }
	inline intptr_t get_value_0() const { return ___value_0; }
	inline intptr_t* get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(intptr_t value)
	{
		___value_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // RUNTIMETYPEHANDLE_T7B542280A22F0EC4EAC2061C29178845847A8B2D_H
#ifndef ANALYTICSRESULT_TD85E76975F9D738CA8110F664D5482A8608D131C_H
#define ANALYTICSRESULT_TD85E76975F9D738CA8110F664D5482A8608D131C_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Analytics.AnalyticsResult
struct  AnalyticsResult_tD85E76975F9D738CA8110F664D5482A8608D131C 
{
public:
	// System.Int32 UnityEngine.Analytics.AnalyticsResult::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(AnalyticsResult_tD85E76975F9D738CA8110F664D5482A8608D131C, ___value___2)); }
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
#endif // ANALYTICSRESULT_TD85E76975F9D738CA8110F664D5482A8608D131C_H
#ifndef ANALYTICSSESSIONSTATE_T61CA873937E9A3B881B71B32F518A954A4C8F267_H
#define ANALYTICSSESSIONSTATE_T61CA873937E9A3B881B71B32F518A954A4C8F267_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Analytics.AnalyticsSessionState
struct  AnalyticsSessionState_t61CA873937E9A3B881B71B32F518A954A4C8F267 
{
public:
	// System.Int32 UnityEngine.Analytics.AnalyticsSessionState::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(AnalyticsSessionState_t61CA873937E9A3B881B71B32F518A954A4C8F267, ___value___2)); }
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
#endif // ANALYTICSSESSIONSTATE_T61CA873937E9A3B881B71B32F518A954A4C8F267_H
#ifndef CUSTOMEVENTDATA_T0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37_H
#define CUSTOMEVENTDATA_T0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Analytics.CustomEventData
struct  CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37  : public RuntimeObject
{
public:
	// System.IntPtr UnityEngine.Analytics.CustomEventData::m_Ptr
	intptr_t ___m_Ptr_0;

public:
	inline static int32_t get_offset_of_m_Ptr_0() { return static_cast<int32_t>(offsetof(CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37, ___m_Ptr_0)); }
	inline intptr_t get_m_Ptr_0() const { return ___m_Ptr_0; }
	inline intptr_t* get_address_of_m_Ptr_0() { return &___m_Ptr_0; }
	inline void set_m_Ptr_0(intptr_t value)
	{
		___m_Ptr_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.Analytics.CustomEventData
struct CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37_marshaled_pinvoke
{
	intptr_t ___m_Ptr_0;
};
// Native definition for COM marshalling of UnityEngine.Analytics.CustomEventData
struct CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37_marshaled_com
{
	intptr_t ___m_Ptr_0;
};
#endif // CUSTOMEVENTDATA_T0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37_H
#ifndef REMOTECONFIGSETTINGS_T97154F5546B47CE72257CC2F0B677BDF696AEC4A_H
#define REMOTECONFIGSETTINGS_T97154F5546B47CE72257CC2F0B677BDF696AEC4A_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.RemoteConfigSettings
struct  RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A  : public RuntimeObject
{
public:
	// System.IntPtr UnityEngine.RemoteConfigSettings::m_Ptr
	intptr_t ___m_Ptr_0;
	// System.Action`1<System.Boolean> UnityEngine.RemoteConfigSettings::Updated
	Action_1_tAA0F894C98302D68F7D5034E8104E9AB4763CCAD * ___Updated_1;

public:
	inline static int32_t get_offset_of_m_Ptr_0() { return static_cast<int32_t>(offsetof(RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A, ___m_Ptr_0)); }
	inline intptr_t get_m_Ptr_0() const { return ___m_Ptr_0; }
	inline intptr_t* get_address_of_m_Ptr_0() { return &___m_Ptr_0; }
	inline void set_m_Ptr_0(intptr_t value)
	{
		___m_Ptr_0 = value;
	}

	inline static int32_t get_offset_of_Updated_1() { return static_cast<int32_t>(offsetof(RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A, ___Updated_1)); }
	inline Action_1_tAA0F894C98302D68F7D5034E8104E9AB4763CCAD * get_Updated_1() const { return ___Updated_1; }
	inline Action_1_tAA0F894C98302D68F7D5034E8104E9AB4763CCAD ** get_address_of_Updated_1() { return &___Updated_1; }
	inline void set_Updated_1(Action_1_tAA0F894C98302D68F7D5034E8104E9AB4763CCAD * value)
	{
		___Updated_1 = value;
		Il2CppCodeGenWriteBarrier((&___Updated_1), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.RemoteConfigSettings
struct RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A_marshaled_pinvoke
{
	intptr_t ___m_Ptr_0;
	Il2CppMethodPointer ___Updated_1;
};
// Native definition for COM marshalling of UnityEngine.RemoteConfigSettings
struct RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A_marshaled_com
{
	intptr_t ___m_Ptr_0;
	Il2CppMethodPointer ___Updated_1;
};
#endif // REMOTECONFIGSETTINGS_T97154F5546B47CE72257CC2F0B677BDF696AEC4A_H
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
#ifndef TYPE_T_H
#define TYPE_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Type
struct  Type_t  : public MemberInfo_t
{
public:
	// System.RuntimeTypeHandle System.Type::_impl
	RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  ____impl_9;

public:
	inline static int32_t get_offset_of__impl_9() { return static_cast<int32_t>(offsetof(Type_t, ____impl_9)); }
	inline RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  get__impl_9() const { return ____impl_9; }
	inline RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D * get_address_of__impl_9() { return &____impl_9; }
	inline void set__impl_9(RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  value)
	{
		____impl_9 = value;
	}
};

struct Type_t_StaticFields
{
public:
	// System.Reflection.MemberFilter System.Type::FilterAttribute
	MemberFilter_t25C1BD92C42BE94426E300787C13C452CB89B381 * ___FilterAttribute_0;
	// System.Reflection.MemberFilter System.Type::FilterName
	MemberFilter_t25C1BD92C42BE94426E300787C13C452CB89B381 * ___FilterName_1;
	// System.Reflection.MemberFilter System.Type::FilterNameIgnoreCase
	MemberFilter_t25C1BD92C42BE94426E300787C13C452CB89B381 * ___FilterNameIgnoreCase_2;
	// System.Object System.Type::Missing
	RuntimeObject * ___Missing_3;
	// System.Char System.Type::Delimiter
	Il2CppChar ___Delimiter_4;
	// System.Type[] System.Type::EmptyTypes
	TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F* ___EmptyTypes_5;
	// System.Reflection.Binder System.Type::defaultBinder
	Binder_t4D5CB06963501D32847C057B57157D6DC49CA759 * ___defaultBinder_6;

public:
	inline static int32_t get_offset_of_FilterAttribute_0() { return static_cast<int32_t>(offsetof(Type_t_StaticFields, ___FilterAttribute_0)); }
	inline MemberFilter_t25C1BD92C42BE94426E300787C13C452CB89B381 * get_FilterAttribute_0() const { return ___FilterAttribute_0; }
	inline MemberFilter_t25C1BD92C42BE94426E300787C13C452CB89B381 ** get_address_of_FilterAttribute_0() { return &___FilterAttribute_0; }
	inline void set_FilterAttribute_0(MemberFilter_t25C1BD92C42BE94426E300787C13C452CB89B381 * value)
	{
		___FilterAttribute_0 = value;
		Il2CppCodeGenWriteBarrier((&___FilterAttribute_0), value);
	}

	inline static int32_t get_offset_of_FilterName_1() { return static_cast<int32_t>(offsetof(Type_t_StaticFields, ___FilterName_1)); }
	inline MemberFilter_t25C1BD92C42BE94426E300787C13C452CB89B381 * get_FilterName_1() const { return ___FilterName_1; }
	inline MemberFilter_t25C1BD92C42BE94426E300787C13C452CB89B381 ** get_address_of_FilterName_1() { return &___FilterName_1; }
	inline void set_FilterName_1(MemberFilter_t25C1BD92C42BE94426E300787C13C452CB89B381 * value)
	{
		___FilterName_1 = value;
		Il2CppCodeGenWriteBarrier((&___FilterName_1), value);
	}

	inline static int32_t get_offset_of_FilterNameIgnoreCase_2() { return static_cast<int32_t>(offsetof(Type_t_StaticFields, ___FilterNameIgnoreCase_2)); }
	inline MemberFilter_t25C1BD92C42BE94426E300787C13C452CB89B381 * get_FilterNameIgnoreCase_2() const { return ___FilterNameIgnoreCase_2; }
	inline MemberFilter_t25C1BD92C42BE94426E300787C13C452CB89B381 ** get_address_of_FilterNameIgnoreCase_2() { return &___FilterNameIgnoreCase_2; }
	inline void set_FilterNameIgnoreCase_2(MemberFilter_t25C1BD92C42BE94426E300787C13C452CB89B381 * value)
	{
		___FilterNameIgnoreCase_2 = value;
		Il2CppCodeGenWriteBarrier((&___FilterNameIgnoreCase_2), value);
	}

	inline static int32_t get_offset_of_Missing_3() { return static_cast<int32_t>(offsetof(Type_t_StaticFields, ___Missing_3)); }
	inline RuntimeObject * get_Missing_3() const { return ___Missing_3; }
	inline RuntimeObject ** get_address_of_Missing_3() { return &___Missing_3; }
	inline void set_Missing_3(RuntimeObject * value)
	{
		___Missing_3 = value;
		Il2CppCodeGenWriteBarrier((&___Missing_3), value);
	}

	inline static int32_t get_offset_of_Delimiter_4() { return static_cast<int32_t>(offsetof(Type_t_StaticFields, ___Delimiter_4)); }
	inline Il2CppChar get_Delimiter_4() const { return ___Delimiter_4; }
	inline Il2CppChar* get_address_of_Delimiter_4() { return &___Delimiter_4; }
	inline void set_Delimiter_4(Il2CppChar value)
	{
		___Delimiter_4 = value;
	}

	inline static int32_t get_offset_of_EmptyTypes_5() { return static_cast<int32_t>(offsetof(Type_t_StaticFields, ___EmptyTypes_5)); }
	inline TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F* get_EmptyTypes_5() const { return ___EmptyTypes_5; }
	inline TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F** get_address_of_EmptyTypes_5() { return &___EmptyTypes_5; }
	inline void set_EmptyTypes_5(TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F* value)
	{
		___EmptyTypes_5 = value;
		Il2CppCodeGenWriteBarrier((&___EmptyTypes_5), value);
	}

	inline static int32_t get_offset_of_defaultBinder_6() { return static_cast<int32_t>(offsetof(Type_t_StaticFields, ___defaultBinder_6)); }
	inline Binder_t4D5CB06963501D32847C057B57157D6DC49CA759 * get_defaultBinder_6() const { return ___defaultBinder_6; }
	inline Binder_t4D5CB06963501D32847C057B57157D6DC49CA759 ** get_address_of_defaultBinder_6() { return &___defaultBinder_6; }
	inline void set_defaultBinder_6(Binder_t4D5CB06963501D32847C057B57157D6DC49CA759 * value)
	{
		___defaultBinder_6 = value;
		Il2CppCodeGenWriteBarrier((&___defaultBinder_6), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TYPE_T_H
#ifndef ACTION_T591D2A86165F896B4B800BB5C25CE18672A55579_H
#define ACTION_T591D2A86165F896B4B800BB5C25CE18672A55579_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Action
struct  Action_t591D2A86165F896B4B800BB5C25CE18672A55579  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ACTION_T591D2A86165F896B4B800BB5C25CE18672A55579_H
#ifndef ACTION_1_TAA0F894C98302D68F7D5034E8104E9AB4763CCAD_H
#define ACTION_1_TAA0F894C98302D68F7D5034E8104E9AB4763CCAD_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Action`1<System.Boolean>
struct  Action_1_tAA0F894C98302D68F7D5034E8104E9AB4763CCAD  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ACTION_1_TAA0F894C98302D68F7D5034E8104E9AB4763CCAD_H
#ifndef ACTION_3_TEE1FB0623176AFA5109FAA9BA7E82293445CAE1E_H
#define ACTION_3_TEE1FB0623176AFA5109FAA9BA7E82293445CAE1E_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Action`3<System.Boolean,System.Boolean,System.Int32>
struct  Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ACTION_3_TEE1FB0623176AFA5109FAA9BA7E82293445CAE1E_H
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
#ifndef SESSIONSTATECHANGED_T9084549A636BD45086D66CC6765DA8C3DD31066F_H
#define SESSIONSTATECHANGED_T9084549A636BD45086D66CC6765DA8C3DD31066F_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Analytics.AnalyticsSessionInfo_SessionStateChanged
struct  SessionStateChanged_t9084549A636BD45086D66CC6765DA8C3DD31066F  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SESSIONSTATECHANGED_T9084549A636BD45086D66CC6765DA8C3DD31066F_H
#ifndef UPDATEDEVENTHANDLER_TB0230BC83686D7126AB4D3800A66351028CA514F_H
#define UPDATEDEVENTHANDLER_TB0230BC83686D7126AB4D3800A66351028CA514F_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.RemoteSettings_UpdatedEventHandler
struct  UpdatedEventHandler_tB0230BC83686D7126AB4D3800A66351028CA514F  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UPDATEDEVENTHANDLER_TB0230BC83686D7126AB4D3800A66351028CA514F_H
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


// !0 System.Collections.Generic.KeyValuePair`2<System.Object,System.Object>::get_Key()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * KeyValuePair_2_get_Key_m9D4E9BCBAB1BE560871A0889C851FC22A09975F4_gshared (KeyValuePair_2_t23481547E419E16E3B96A303578C1EB685C99EEE * __this, const RuntimeMethod* method);
// !1 System.Collections.Generic.KeyValuePair`2<System.Object,System.Object>::get_Value()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * KeyValuePair_2_get_Value_m8C7B882C4D425535288FAAD08EAF11D289A43AEC_gshared (KeyValuePair_2_t23481547E419E16E3B96A303578C1EB685C99EEE * __this, const RuntimeMethod* method);
// System.Void System.Action`1<System.Boolean>::Invoke(!0)
extern "C" IL2CPP_METHOD_ATTR void Action_1_Invoke_m45E8F9900F9DB395C48A868A7C6A83BDD7FC692F_gshared (Action_1_tAA0F894C98302D68F7D5034E8104E9AB4763CCAD * __this, bool p0, const RuntimeMethod* method);
// System.Void System.Action`3<System.Boolean,System.Boolean,System.Int32>::Invoke(!0,!1,!2)
extern "C" IL2CPP_METHOD_ATTR void Action_3_Invoke_m8A4240174E60397816F6EACC65FE1E27F4275FA5_gshared (Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * __this, bool p0, bool p1, int32_t p2, const RuntimeMethod* method);

// System.Boolean System.String::IsNullOrEmpty(System.String)
extern "C" IL2CPP_METHOD_ATTR bool String_IsNullOrEmpty_m06A85A206AC2106D1982826C5665B9BD35324229 (String_t* p0, const RuntimeMethod* method);
// System.Void System.ArgumentException::.ctor(System.String)
extern "C" IL2CPP_METHOD_ATTR void ArgumentException__ctor_m9A85EF7FEFEC21DDD525A67E831D77278E5165B7 (ArgumentException_tEDCD16F20A09ECE461C3DA766C16EDA8864057D1 * __this, String_t* p0, const RuntimeMethod* method);
// System.Boolean UnityEngine.Analytics.Analytics::IsInitialized()
extern "C" IL2CPP_METHOD_ATTR bool Analytics_IsInitialized_m8F7A2AA62A95AFB1362BB98DC5C45FEEC27E38F3 (const RuntimeMethod* method);
// System.Double System.Convert::ToDouble(System.Decimal)
extern "C" IL2CPP_METHOD_ATTR double Convert_ToDouble_mB31B6067B5E9336860641CBD4424E17CA42EC3FA (Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  p0, const RuntimeMethod* method);
// UnityEngine.Analytics.AnalyticsResult UnityEngine.Analytics.Analytics::Transaction(System.String,System.Double,System.String,System.String,System.String,System.Boolean)
extern "C" IL2CPP_METHOD_ATTR int32_t Analytics_Transaction_mADBCBB85344EB6F014B2F5C6FC30417C54F0B842 (String_t* ___productId0, double ___amount1, String_t* ___currency2, String_t* ___receiptPurchaseData3, String_t* ___signature4, bool ___usingIAPService5, const RuntimeMethod* method);
// UnityEngine.Analytics.AnalyticsResult UnityEngine.Analytics.Analytics::SendCustomEventName(System.String)
extern "C" IL2CPP_METHOD_ATTR int32_t Analytics_SendCustomEventName_mF80F99569E2BEC2B440F13CF4B7019F867B7D92E (String_t* ___customEventName0, const RuntimeMethod* method);
// System.Void UnityEngine.Analytics.CustomEventData::.ctor(System.String)
extern "C" IL2CPP_METHOD_ATTR void CustomEventData__ctor_mDD616A5357DCBBBEB79725C779E86B9AC2F73078 (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * __this, String_t* ___name0, const RuntimeMethod* method);
// System.Boolean UnityEngine.Analytics.CustomEventData::AddDictionary(System.Collections.Generic.IDictionary`2<System.String,System.Object>)
extern "C" IL2CPP_METHOD_ATTR bool CustomEventData_AddDictionary_mDA0270C0DE80222EEB3D5B9E6432E59E99C48FA4 (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * __this, RuntimeObject* ___eventData0, const RuntimeMethod* method);
// UnityEngine.Analytics.AnalyticsResult UnityEngine.Analytics.Analytics::SendCustomEvent(UnityEngine.Analytics.CustomEventData)
extern "C" IL2CPP_METHOD_ATTR int32_t Analytics_SendCustomEvent_mBF3E8A1FDB7F4B32F6A0CEB60EC59185CA11AF18 (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * ___eventData0, const RuntimeMethod* method);
// System.Void UnityEngine.Analytics.CustomEventData::Dispose()
extern "C" IL2CPP_METHOD_ATTR void CustomEventData_Dispose_m62D34DC34233E96231793EB2A3F165ED17C29B6C (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Analytics.AnalyticsSessionInfo/SessionStateChanged::Invoke(UnityEngine.Analytics.AnalyticsSessionState,System.Int64,System.Int64,System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void SessionStateChanged_Invoke_m04E35EE6755FE675385F783A6FA7096BACD96740 (SessionStateChanged_t9084549A636BD45086D66CC6765DA8C3DD31066F * __this, int32_t ___sessionState0, int64_t ___sessionId1, int64_t ___sessionElapsedTime2, bool ___sessionChanged3, const RuntimeMethod* method);
// System.Void System.Object::.ctor()
extern "C" IL2CPP_METHOD_ATTR void Object__ctor_m925ECA5E85CA100E3FB86A4F9E15C120E9A184C0 (RuntimeObject * __this, const RuntimeMethod* method);
// System.IntPtr UnityEngine.Analytics.CustomEventData::Internal_Create(UnityEngine.Analytics.CustomEventData,System.String)
extern "C" IL2CPP_METHOD_ATTR intptr_t CustomEventData_Internal_Create_m42DF97054891EB8D52D92EC1E1875AF1E0893A1C (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * ___ced0, String_t* ___name1, const RuntimeMethod* method);
// System.Void UnityEngine.Analytics.CustomEventData::Destroy()
extern "C" IL2CPP_METHOD_ATTR void CustomEventData_Destroy_m60BE08121AFF38808FBD62CC9BF5929E30C444CA (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * __this, const RuntimeMethod* method);
// System.Void System.Object::Finalize()
extern "C" IL2CPP_METHOD_ATTR void Object_Finalize_m4015B7D3A44DE125C5FE34D7276CD4697C06F380 (RuntimeObject * __this, const RuntimeMethod* method);
// System.Boolean System.IntPtr::op_Inequality(System.IntPtr,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR bool IntPtr_op_Inequality_mB4886A806009EA825EFCC60CD2A7F6EB8E273A61 (intptr_t p0, intptr_t p1, const RuntimeMethod* method);
// System.Void UnityEngine.Analytics.CustomEventData::Internal_Destroy(System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR void CustomEventData_Internal_Destroy_mE1D3E1966E7D047C3AB2C49A2E6680DF3097C683 (intptr_t ___ptr0, const RuntimeMethod* method);
// System.Void System.GC::SuppressFinalize(System.Object)
extern "C" IL2CPP_METHOD_ATTR void GC_SuppressFinalize_m037319A9B95A5BA437E806DE592802225EE5B425 (RuntimeObject * p0, const RuntimeMethod* method);
// !0 System.Collections.Generic.KeyValuePair`2<System.String,System.Object>::get_Key()
inline String_t* KeyValuePair_2_get_Key_mAC09B6950211936EF2A4251B70DF5124DED3CD0B (KeyValuePair_2_tBC573EE45BE549307D189378677DF98C3A6C8059 * __this, const RuntimeMethod* method)
{
	return ((  String_t* (*) (KeyValuePair_2_tBC573EE45BE549307D189378677DF98C3A6C8059 *, const RuntimeMethod*))KeyValuePair_2_get_Key_m9D4E9BCBAB1BE560871A0889C851FC22A09975F4_gshared)(__this, method);
}
// !1 System.Collections.Generic.KeyValuePair`2<System.String,System.Object>::get_Value()
inline RuntimeObject * KeyValuePair_2_get_Value_m5D1180FCE84ACA037CCCF151B9696C4575634758 (KeyValuePair_2_tBC573EE45BE549307D189378677DF98C3A6C8059 * __this, const RuntimeMethod* method)
{
	return ((  RuntimeObject * (*) (KeyValuePair_2_tBC573EE45BE549307D189378677DF98C3A6C8059 *, const RuntimeMethod*))KeyValuePair_2_get_Value_m8C7B882C4D425535288FAAD08EAF11D289A43AEC_gshared)(__this, method);
}
// System.Boolean UnityEngine.Analytics.CustomEventData::AddString(System.String,System.String)
extern "C" IL2CPP_METHOD_ATTR bool CustomEventData_AddString_m5E4382F85BC1A6A9814F4DCF887D86EC4D30BF3C (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * __this, String_t* ___key0, String_t* ___value1, const RuntimeMethod* method);
// System.Type System.Object::GetType()
extern "C" IL2CPP_METHOD_ATTR Type_t * Object_GetType_m2E0B62414ECCAA3094B703790CE88CBB2F83EA60 (RuntimeObject * __this, const RuntimeMethod* method);
// System.Type System.Type::GetTypeFromHandle(System.RuntimeTypeHandle)
extern "C" IL2CPP_METHOD_ATTR Type_t * Type_GetTypeFromHandle_m9DC58ADF0512987012A8A016FB64B068F3B1AFF6 (RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  p0, const RuntimeMethod* method);
// System.String System.Char::ToString(System.Char)
extern "C" IL2CPP_METHOD_ATTR String_t* Char_ToString_m106C901B4CB0DDEF732750349DAB71498C42C53F (Il2CppChar p0, const RuntimeMethod* method);
// System.Boolean UnityEngine.Analytics.CustomEventData::AddInt32(System.String,System.Int32)
extern "C" IL2CPP_METHOD_ATTR bool CustomEventData_AddInt32_m473A606F146A2ABDC1F1E5F0401217E10E088A75 (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * __this, String_t* ___key0, int32_t ___value1, const RuntimeMethod* method);
// System.Boolean UnityEngine.Analytics.CustomEventData::AddUInt32(System.String,System.UInt32)
extern "C" IL2CPP_METHOD_ATTR bool CustomEventData_AddUInt32_mEBEA494F859541865FDEC26CBD925E03AB11D78A (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * __this, String_t* ___key0, uint32_t ___value1, const RuntimeMethod* method);
// System.Boolean UnityEngine.Analytics.CustomEventData::AddInt64(System.String,System.Int64)
extern "C" IL2CPP_METHOD_ATTR bool CustomEventData_AddInt64_mF79A8D03EB18BE5CC097FDFED8E7DDF9D931B224 (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * __this, String_t* ___key0, int64_t ___value1, const RuntimeMethod* method);
// System.Boolean UnityEngine.Analytics.CustomEventData::AddUInt64(System.String,System.UInt64)
extern "C" IL2CPP_METHOD_ATTR bool CustomEventData_AddUInt64_mE0C4870736E758BC54EB4360A834304C72A23432 (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * __this, String_t* ___key0, uint64_t ___value1, const RuntimeMethod* method);
// System.Boolean UnityEngine.Analytics.CustomEventData::AddBool(System.String,System.Boolean)
extern "C" IL2CPP_METHOD_ATTR bool CustomEventData_AddBool_m0807E669CA6F9EB72FB53FDD3E45DC66C83B9E41 (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * __this, String_t* ___key0, bool ___value1, const RuntimeMethod* method);
// System.Decimal System.Convert::ToDecimal(System.Single)
extern "C" IL2CPP_METHOD_ATTR Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  Convert_ToDecimal_m0723C02BC98733C38A826B8BBF2C4AE24B7CB557 (float p0, const RuntimeMethod* method);
// System.Double System.Decimal::op_Explicit(System.Decimal)
extern "C" IL2CPP_METHOD_ATTR double Decimal_op_Explicit_mB7F34E3B2DFB6211CA5ACB5497DA6CDCB09FC6CE (Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  p0, const RuntimeMethod* method);
// System.Boolean UnityEngine.Analytics.CustomEventData::AddDouble(System.String,System.Double)
extern "C" IL2CPP_METHOD_ATTR bool CustomEventData_AddDouble_m71B600B1553314D300A4C250272BD97706DE48F5 (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * __this, String_t* ___key0, double ___value1, const RuntimeMethod* method);
// System.Decimal System.Convert::ToDecimal(System.Decimal)
extern "C" IL2CPP_METHOD_ATTR Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  Convert_ToDecimal_m4084B6BF683AE0078FDC431EAE0A77DD161AC045 (Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  p0, const RuntimeMethod* method);
// System.Boolean System.Type::get_IsValueType()
extern "C" IL2CPP_METHOD_ATTR bool Type_get_IsValueType_mDDCCBAE9B59A483CBC3E5C02E3D68CEBEB2E41A8 (Type_t * __this, const RuntimeMethod* method);
// System.String System.String::Format(System.String,System.Object)
extern "C" IL2CPP_METHOD_ATTR String_t* String_Format_m0ACDD8B34764E4040AED0B3EEB753567E4576BFA (String_t* p0, RuntimeObject * p1, const RuntimeMethod* method);
// System.Void UnityEngine.RemoteConfigSettings::Destroy()
extern "C" IL2CPP_METHOD_ATTR void RemoteConfigSettings_Destroy_m91215D772DF190B8AD9A73C8165DEDBE129C7A10 (RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A * __this, const RuntimeMethod* method);
// System.Void UnityEngine.RemoteConfigSettings::Internal_Destroy(System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR void RemoteConfigSettings_Internal_Destroy_mC419232704AC40CF7B3C5FB17A8A3D9FD2604F66 (intptr_t ___ptr0, const RuntimeMethod* method);
// System.Void System.Action`1<System.Boolean>::Invoke(!0)
inline void Action_1_Invoke_m45E8F9900F9DB395C48A868A7C6A83BDD7FC692F (Action_1_tAA0F894C98302D68F7D5034E8104E9AB4763CCAD * __this, bool p0, const RuntimeMethod* method)
{
	((  void (*) (Action_1_tAA0F894C98302D68F7D5034E8104E9AB4763CCAD *, bool, const RuntimeMethod*))Action_1_Invoke_m45E8F9900F9DB395C48A868A7C6A83BDD7FC692F_gshared)(__this, p0, method);
}
// System.Delegate System.Delegate::Combine(System.Delegate,System.Delegate)
extern "C" IL2CPP_METHOD_ATTR Delegate_t * Delegate_Combine_mC25D2F7DECAFBA6D9A2F9EBA8A77063F0658ECF1 (Delegate_t * p0, Delegate_t * p1, const RuntimeMethod* method);
// System.Delegate System.Delegate::Remove(System.Delegate,System.Delegate)
extern "C" IL2CPP_METHOD_ATTR Delegate_t * Delegate_Remove_m0B0DB7D1B3AF96B71AFAA72BA0EFE32FBBC2932D (Delegate_t * p0, Delegate_t * p1, const RuntimeMethod* method);
// System.Void UnityEngine.RemoteSettings/UpdatedEventHandler::Invoke()
extern "C" IL2CPP_METHOD_ATTR void UpdatedEventHandler_Invoke_mD2D72D86708690251A8A947FECE091E8EE0107E7 (UpdatedEventHandler_tB0230BC83686D7126AB4D3800A66351028CA514F * __this, const RuntimeMethod* method);
// System.Void System.Action::Invoke()
extern "C" IL2CPP_METHOD_ATTR void Action_Invoke_mC8D676E5DDF967EC5D23DD0E96FB52AA499817FD (Action_t591D2A86165F896B4B800BB5C25CE18672A55579 * __this, const RuntimeMethod* method);
// System.Void System.Action`3<System.Boolean,System.Boolean,System.Int32>::Invoke(!0,!1,!2)
inline void Action_3_Invoke_m8A4240174E60397816F6EACC65FE1E27F4275FA5 (Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * __this, bool p0, bool p1, int32_t p2, const RuntimeMethod* method)
{
	((  void (*) (Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E *, bool, bool, int32_t, const RuntimeMethod*))Action_3_Invoke_m8A4240174E60397816F6EACC65FE1E27F4275FA5_gshared)(__this, p0, p1, p2, method);
}
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
// Conversion methods for marshalling of: UnityEngine.Analytics.Analytics
extern "C" void Analytics_tCA6E11F003D5B8AD0A5F0780BF5954566C7EB724_marshal_pinvoke(const Analytics_tCA6E11F003D5B8AD0A5F0780BF5954566C7EB724& unmarshaled, Analytics_tCA6E11F003D5B8AD0A5F0780BF5954566C7EB724_marshaled_pinvoke& marshaled)
{
}
extern "C" void Analytics_tCA6E11F003D5B8AD0A5F0780BF5954566C7EB724_marshal_pinvoke_back(const Analytics_tCA6E11F003D5B8AD0A5F0780BF5954566C7EB724_marshaled_pinvoke& marshaled, Analytics_tCA6E11F003D5B8AD0A5F0780BF5954566C7EB724& unmarshaled)
{
}
// Conversion method for clean up from marshalling of: UnityEngine.Analytics.Analytics
extern "C" void Analytics_tCA6E11F003D5B8AD0A5F0780BF5954566C7EB724_marshal_pinvoke_cleanup(Analytics_tCA6E11F003D5B8AD0A5F0780BF5954566C7EB724_marshaled_pinvoke& marshaled)
{
}
// Conversion methods for marshalling of: UnityEngine.Analytics.Analytics
extern "C" void Analytics_tCA6E11F003D5B8AD0A5F0780BF5954566C7EB724_marshal_com(const Analytics_tCA6E11F003D5B8AD0A5F0780BF5954566C7EB724& unmarshaled, Analytics_tCA6E11F003D5B8AD0A5F0780BF5954566C7EB724_marshaled_com& marshaled)
{
}
extern "C" void Analytics_tCA6E11F003D5B8AD0A5F0780BF5954566C7EB724_marshal_com_back(const Analytics_tCA6E11F003D5B8AD0A5F0780BF5954566C7EB724_marshaled_com& marshaled, Analytics_tCA6E11F003D5B8AD0A5F0780BF5954566C7EB724& unmarshaled)
{
}
// Conversion method for clean up from marshalling of: UnityEngine.Analytics.Analytics
extern "C" void Analytics_tCA6E11F003D5B8AD0A5F0780BF5954566C7EB724_marshal_com_cleanup(Analytics_tCA6E11F003D5B8AD0A5F0780BF5954566C7EB724_marshaled_com& marshaled)
{
}
// System.Boolean UnityEngine.Analytics.Analytics::IsInitialized()
extern "C" IL2CPP_METHOD_ATTR bool Analytics_IsInitialized_m8F7A2AA62A95AFB1362BB98DC5C45FEEC27E38F3 (const RuntimeMethod* method)
{
	typedef bool (*Analytics_IsInitialized_m8F7A2AA62A95AFB1362BB98DC5C45FEEC27E38F3_ftn) ();
	static Analytics_IsInitialized_m8F7A2AA62A95AFB1362BB98DC5C45FEEC27E38F3_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Analytics_IsInitialized_m8F7A2AA62A95AFB1362BB98DC5C45FEEC27E38F3_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Analytics.Analytics::IsInitialized()");
	bool retVal = _il2cpp_icall_func();
	return retVal;
}
// UnityEngine.Analytics.AnalyticsResult UnityEngine.Analytics.Analytics::Transaction(System.String,System.Double,System.String,System.String,System.String,System.Boolean)
extern "C" IL2CPP_METHOD_ATTR int32_t Analytics_Transaction_mADBCBB85344EB6F014B2F5C6FC30417C54F0B842 (String_t* ___productId0, double ___amount1, String_t* ___currency2, String_t* ___receiptPurchaseData3, String_t* ___signature4, bool ___usingIAPService5, const RuntimeMethod* method)
{
	typedef int32_t (*Analytics_Transaction_mADBCBB85344EB6F014B2F5C6FC30417C54F0B842_ftn) (String_t*, double, String_t*, String_t*, String_t*, bool);
	static Analytics_Transaction_mADBCBB85344EB6F014B2F5C6FC30417C54F0B842_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Analytics_Transaction_mADBCBB85344EB6F014B2F5C6FC30417C54F0B842_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Analytics.Analytics::Transaction(System.String,System.Double,System.String,System.String,System.String,System.Boolean)");
	int32_t retVal = _il2cpp_icall_func(___productId0, ___amount1, ___currency2, ___receiptPurchaseData3, ___signature4, ___usingIAPService5);
	return retVal;
}
// UnityEngine.Analytics.AnalyticsResult UnityEngine.Analytics.Analytics::SendCustomEventName(System.String)
extern "C" IL2CPP_METHOD_ATTR int32_t Analytics_SendCustomEventName_mF80F99569E2BEC2B440F13CF4B7019F867B7D92E (String_t* ___customEventName0, const RuntimeMethod* method)
{
	typedef int32_t (*Analytics_SendCustomEventName_mF80F99569E2BEC2B440F13CF4B7019F867B7D92E_ftn) (String_t*);
	static Analytics_SendCustomEventName_mF80F99569E2BEC2B440F13CF4B7019F867B7D92E_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Analytics_SendCustomEventName_mF80F99569E2BEC2B440F13CF4B7019F867B7D92E_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Analytics.Analytics::SendCustomEventName(System.String)");
	int32_t retVal = _il2cpp_icall_func(___customEventName0);
	return retVal;
}
// UnityEngine.Analytics.AnalyticsResult UnityEngine.Analytics.Analytics::SendCustomEvent(UnityEngine.Analytics.CustomEventData)
extern "C" IL2CPP_METHOD_ATTR int32_t Analytics_SendCustomEvent_mBF3E8A1FDB7F4B32F6A0CEB60EC59185CA11AF18 (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * ___eventData0, const RuntimeMethod* method)
{
	typedef int32_t (*Analytics_SendCustomEvent_mBF3E8A1FDB7F4B32F6A0CEB60EC59185CA11AF18_ftn) (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 *);
	static Analytics_SendCustomEvent_mBF3E8A1FDB7F4B32F6A0CEB60EC59185CA11AF18_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Analytics_SendCustomEvent_mBF3E8A1FDB7F4B32F6A0CEB60EC59185CA11AF18_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Analytics.Analytics::SendCustomEvent(UnityEngine.Analytics.CustomEventData)");
	int32_t retVal = _il2cpp_icall_func(___eventData0);
	return retVal;
}
// UnityEngine.Analytics.AnalyticsResult UnityEngine.Analytics.Analytics::Transaction(System.String,System.Decimal,System.String,System.String,System.String,System.Boolean)
extern "C" IL2CPP_METHOD_ATTR int32_t Analytics_Transaction_mEE22A703EE6834D458722D204C7261ECBEFF4612 (String_t* ___productId0, Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  ___amount1, String_t* ___currency2, String_t* ___receiptPurchaseData3, String_t* ___signature4, bool ___usingIAPService5, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Analytics_Transaction_mEE22A703EE6834D458722D204C7261ECBEFF4612_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		String_t* L_0 = ___productId0;
		bool L_1 = String_IsNullOrEmpty_m06A85A206AC2106D1982826C5665B9BD35324229(L_0, /*hidden argument*/NULL);
		if (!L_1)
		{
			goto IL_0017;
		}
	}
	{
		ArgumentException_tEDCD16F20A09ECE461C3DA766C16EDA8864057D1 * L_2 = (ArgumentException_tEDCD16F20A09ECE461C3DA766C16EDA8864057D1 *)il2cpp_codegen_object_new(ArgumentException_tEDCD16F20A09ECE461C3DA766C16EDA8864057D1_il2cpp_TypeInfo_var);
		ArgumentException__ctor_m9A85EF7FEFEC21DDD525A67E831D77278E5165B7(L_2, _stringLiteral6427E65FC1EB2FCB0B733856926B458525F717D0, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_2, NULL, Analytics_Transaction_mEE22A703EE6834D458722D204C7261ECBEFF4612_RuntimeMethod_var);
	}

IL_0017:
	{
		String_t* L_3 = ___currency2;
		bool L_4 = String_IsNullOrEmpty_m06A85A206AC2106D1982826C5665B9BD35324229(L_3, /*hidden argument*/NULL);
		if (!L_4)
		{
			goto IL_002d;
		}
	}
	{
		ArgumentException_tEDCD16F20A09ECE461C3DA766C16EDA8864057D1 * L_5 = (ArgumentException_tEDCD16F20A09ECE461C3DA766C16EDA8864057D1 *)il2cpp_codegen_object_new(ArgumentException_tEDCD16F20A09ECE461C3DA766C16EDA8864057D1_il2cpp_TypeInfo_var);
		ArgumentException__ctor_m9A85EF7FEFEC21DDD525A67E831D77278E5165B7(L_5, _stringLiteral95142210B034E24DA1953BF3D5DB636DAD468302, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_5, NULL, Analytics_Transaction_mEE22A703EE6834D458722D204C7261ECBEFF4612_RuntimeMethod_var);
	}

IL_002d:
	{
		bool L_6 = Analytics_IsInitialized_m8F7A2AA62A95AFB1362BB98DC5C45FEEC27E38F3(/*hidden argument*/NULL);
		if (L_6)
		{
			goto IL_003e;
		}
	}
	{
		V_0 = 1;
		goto IL_0071;
	}

IL_003e:
	{
		String_t* L_7 = ___receiptPurchaseData3;
		if (L_7)
		{
			goto IL_004b;
		}
	}
	{
		String_t* L_8 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_5();
		___receiptPurchaseData3 = L_8;
	}

IL_004b:
	{
		String_t* L_9 = ___signature4;
		if (L_9)
		{
			goto IL_0059;
		}
	}
	{
		String_t* L_10 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_5();
		___signature4 = L_10;
	}

IL_0059:
	{
		String_t* L_11 = ___productId0;
		Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  L_12 = ___amount1;
		IL2CPP_RUNTIME_CLASS_INIT(Convert_t1C7A851BFB2F0782FD7F72F6AA1DCBB7B53A9C7E_il2cpp_TypeInfo_var);
		double L_13 = Convert_ToDouble_mB31B6067B5E9336860641CBD4424E17CA42EC3FA(L_12, /*hidden argument*/NULL);
		String_t* L_14 = ___currency2;
		String_t* L_15 = ___receiptPurchaseData3;
		String_t* L_16 = ___signature4;
		bool L_17 = ___usingIAPService5;
		int32_t L_18 = Analytics_Transaction_mADBCBB85344EB6F014B2F5C6FC30417C54F0B842(L_11, L_13, L_14, L_15, L_16, L_17, /*hidden argument*/NULL);
		V_0 = L_18;
		goto IL_0071;
	}

IL_0071:
	{
		int32_t L_19 = V_0;
		return L_19;
	}
}
// UnityEngine.Analytics.AnalyticsResult UnityEngine.Analytics.Analytics::CustomEvent(System.String,System.Collections.Generic.IDictionary`2<System.String,System.Object>)
extern "C" IL2CPP_METHOD_ATTR int32_t Analytics_CustomEvent_mB0F6DDF5C94D0D6540E427B71E4081F443CA6E02 (String_t* ___customEventName0, RuntimeObject* ___eventData1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Analytics_CustomEvent_mB0F6DDF5C94D0D6540E427B71E4081F443CA6E02_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * V_1 = NULL;
	int32_t V_2 = 0;
	{
		String_t* L_0 = ___customEventName0;
		bool L_1 = String_IsNullOrEmpty_m06A85A206AC2106D1982826C5665B9BD35324229(L_0, /*hidden argument*/NULL);
		if (!L_1)
		{
			goto IL_0017;
		}
	}
	{
		ArgumentException_tEDCD16F20A09ECE461C3DA766C16EDA8864057D1 * L_2 = (ArgumentException_tEDCD16F20A09ECE461C3DA766C16EDA8864057D1 *)il2cpp_codegen_object_new(ArgumentException_tEDCD16F20A09ECE461C3DA766C16EDA8864057D1_il2cpp_TypeInfo_var);
		ArgumentException__ctor_m9A85EF7FEFEC21DDD525A67E831D77278E5165B7(L_2, _stringLiteralEF9343981EC10013222A31ABF8393BC213AEAF80, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_2, NULL, Analytics_CustomEvent_mB0F6DDF5C94D0D6540E427B71E4081F443CA6E02_RuntimeMethod_var);
	}

IL_0017:
	{
		bool L_3 = Analytics_IsInitialized_m8F7A2AA62A95AFB1362BB98DC5C45FEEC27E38F3(/*hidden argument*/NULL);
		if (L_3)
		{
			goto IL_0028;
		}
	}
	{
		V_0 = 1;
		goto IL_005d;
	}

IL_0028:
	{
		RuntimeObject* L_4 = ___eventData1;
		if (L_4)
		{
			goto IL_003a;
		}
	}
	{
		String_t* L_5 = ___customEventName0;
		int32_t L_6 = Analytics_SendCustomEventName_mF80F99569E2BEC2B440F13CF4B7019F867B7D92E(L_5, /*hidden argument*/NULL);
		V_0 = L_6;
		goto IL_005d;
	}

IL_003a:
	{
		String_t* L_7 = ___customEventName0;
		CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * L_8 = (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 *)il2cpp_codegen_object_new(CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37_il2cpp_TypeInfo_var);
		CustomEventData__ctor_mDD616A5357DCBBBEB79725C779E86B9AC2F73078(L_8, L_7, /*hidden argument*/NULL);
		V_1 = L_8;
		CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * L_9 = V_1;
		RuntimeObject* L_10 = ___eventData1;
		NullCheck(L_9);
		CustomEventData_AddDictionary_mDA0270C0DE80222EEB3D5B9E6432E59E99C48FA4(L_9, L_10, /*hidden argument*/NULL);
		CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * L_11 = V_1;
		int32_t L_12 = Analytics_SendCustomEvent_mBF3E8A1FDB7F4B32F6A0CEB60EC59185CA11AF18(L_11, /*hidden argument*/NULL);
		V_2 = L_12;
		CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * L_13 = V_1;
		NullCheck(L_13);
		CustomEventData_Dispose_m62D34DC34233E96231793EB2A3F165ED17C29B6C(L_13, /*hidden argument*/NULL);
		int32_t L_14 = V_2;
		V_0 = L_14;
		goto IL_005d;
	}

IL_005d:
	{
		int32_t L_15 = V_0;
		return L_15;
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
// System.Void UnityEngine.Analytics.AnalyticsSessionInfo::CallSessionStateChanged(UnityEngine.Analytics.AnalyticsSessionState,System.Int64,System.Int64,System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void AnalyticsSessionInfo_CallSessionStateChanged_mB5E3A42407B97BD8A6A4827FADDA91DB85B0F294 (int32_t ___sessionState0, int64_t ___sessionId1, int64_t ___sessionElapsedTime2, bool ___sessionChanged3, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (AnalyticsSessionInfo_CallSessionStateChanged_mB5E3A42407B97BD8A6A4827FADDA91DB85B0F294_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	SessionStateChanged_t9084549A636BD45086D66CC6765DA8C3DD31066F * V_0 = NULL;
	{
		SessionStateChanged_t9084549A636BD45086D66CC6765DA8C3DD31066F * L_0 = ((AnalyticsSessionInfo_tE075F764A74D2B095CFD57F3B179397F504B7D8C_StaticFields*)il2cpp_codegen_static_fields_for(AnalyticsSessionInfo_tE075F764A74D2B095CFD57F3B179397F504B7D8C_il2cpp_TypeInfo_var))->get_sessionStateChanged_0();
		V_0 = L_0;
		SessionStateChanged_t9084549A636BD45086D66CC6765DA8C3DD31066F * L_1 = V_0;
		if (!L_1)
		{
			goto IL_0017;
		}
	}
	{
		SessionStateChanged_t9084549A636BD45086D66CC6765DA8C3DD31066F * L_2 = V_0;
		int32_t L_3 = ___sessionState0;
		int64_t L_4 = ___sessionId1;
		int64_t L_5 = ___sessionElapsedTime2;
		bool L_6 = ___sessionChanged3;
		NullCheck(L_2);
		SessionStateChanged_Invoke_m04E35EE6755FE675385F783A6FA7096BACD96740(L_2, L_3, L_4, L_5, L_6, /*hidden argument*/NULL);
	}

IL_0017:
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
extern "C"  void DelegatePInvokeWrapper_SessionStateChanged_t9084549A636BD45086D66CC6765DA8C3DD31066F (SessionStateChanged_t9084549A636BD45086D66CC6765DA8C3DD31066F * __this, int32_t ___sessionState0, int64_t ___sessionId1, int64_t ___sessionElapsedTime2, bool ___sessionChanged3, const RuntimeMethod* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc)(int32_t, int64_t, int64_t, int32_t);
	PInvokeFunc il2cppPInvokeFunc = reinterpret_cast<PInvokeFunc>(il2cpp_codegen_get_method_pointer(((RuntimeDelegate*)__this)->method));

	// Native function invocation
	il2cppPInvokeFunc(___sessionState0, ___sessionId1, ___sessionElapsedTime2, static_cast<int32_t>(___sessionChanged3));

}
// System.Void UnityEngine.Analytics.AnalyticsSessionInfo_SessionStateChanged::.ctor(System.Object,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR void SessionStateChanged__ctor_m596C4D6873E1F9841C454BA7542D468F53A2DB25 (SessionStateChanged_t9084549A636BD45086D66CC6765DA8C3DD31066F * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method)
{
	__this->set_method_ptr_0(il2cpp_codegen_get_method_pointer((RuntimeMethod*)___method1));
	__this->set_method_3(___method1);
	__this->set_m_target_2(___object0);
}
// System.Void UnityEngine.Analytics.AnalyticsSessionInfo_SessionStateChanged::Invoke(UnityEngine.Analytics.AnalyticsSessionState,System.Int64,System.Int64,System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void SessionStateChanged_Invoke_m04E35EE6755FE675385F783A6FA7096BACD96740 (SessionStateChanged_t9084549A636BD45086D66CC6765DA8C3DD31066F * __this, int32_t ___sessionState0, int64_t ___sessionId1, int64_t ___sessionElapsedTime2, bool ___sessionChanged3, const RuntimeMethod* method)
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
				if (___parameterCount == 4)
				{
					// open
					typedef void (*FunctionPointerType) (int32_t, int64_t, int64_t, bool, const RuntimeMethod*);
					((FunctionPointerType)targetMethodPointer)(___sessionState0, ___sessionId1, ___sessionElapsedTime2, ___sessionChanged3, targetMethod);
				}
				else
				{
					// closed
					typedef void (*FunctionPointerType) (void*, int32_t, int64_t, int64_t, bool, const RuntimeMethod*);
					((FunctionPointerType)targetMethodPointer)(targetThis, ___sessionState0, ___sessionId1, ___sessionElapsedTime2, ___sessionChanged3, targetMethod);
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
							typedef void (*FunctionPointerType) (int32_t, int64_t, int64_t, bool, const RuntimeMethod*);
							((FunctionPointerType)targetMethodPointer)(___sessionState0, ___sessionId1, ___sessionElapsedTime2, ___sessionChanged3, targetMethod);
						}
						else if (il2cpp_codegen_method_is_generic_instance(targetMethod))
						{
							if (il2cpp_codegen_method_is_interface_method(targetMethod))
								GenericInterfaceActionInvoker4< int32_t, int64_t, int64_t, bool >::Invoke(targetMethod, targetThis, ___sessionState0, ___sessionId1, ___sessionElapsedTime2, ___sessionChanged3);
							else
								GenericVirtActionInvoker4< int32_t, int64_t, int64_t, bool >::Invoke(targetMethod, targetThis, ___sessionState0, ___sessionId1, ___sessionElapsedTime2, ___sessionChanged3);
						}
						else
						{
							if (il2cpp_codegen_method_is_interface_method(targetMethod))
								InterfaceActionInvoker4< int32_t, int64_t, int64_t, bool >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), targetThis, ___sessionState0, ___sessionId1, ___sessionElapsedTime2, ___sessionChanged3);
							else
								VirtActionInvoker4< int32_t, int64_t, int64_t, bool >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), targetThis, ___sessionState0, ___sessionId1, ___sessionElapsedTime2, ___sessionChanged3);
						}
					}
				}
				else
				{
					typedef void (*FunctionPointerType) (void*, int32_t, int64_t, int64_t, bool, const RuntimeMethod*);
					((FunctionPointerType)targetMethodPointer)(targetThis, ___sessionState0, ___sessionId1, ___sessionElapsedTime2, ___sessionChanged3, targetMethod);
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
			if (___parameterCount == 4)
			{
				// open
				typedef void (*FunctionPointerType) (int32_t, int64_t, int64_t, bool, const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(___sessionState0, ___sessionId1, ___sessionElapsedTime2, ___sessionChanged3, targetMethod);
			}
			else
			{
				// closed
				typedef void (*FunctionPointerType) (void*, int32_t, int64_t, int64_t, bool, const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(targetThis, ___sessionState0, ___sessionId1, ___sessionElapsedTime2, ___sessionChanged3, targetMethod);
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
						typedef void (*FunctionPointerType) (int32_t, int64_t, int64_t, bool, const RuntimeMethod*);
						((FunctionPointerType)targetMethodPointer)(___sessionState0, ___sessionId1, ___sessionElapsedTime2, ___sessionChanged3, targetMethod);
					}
					else if (il2cpp_codegen_method_is_generic_instance(targetMethod))
					{
						if (il2cpp_codegen_method_is_interface_method(targetMethod))
							GenericInterfaceActionInvoker4< int32_t, int64_t, int64_t, bool >::Invoke(targetMethod, targetThis, ___sessionState0, ___sessionId1, ___sessionElapsedTime2, ___sessionChanged3);
						else
							GenericVirtActionInvoker4< int32_t, int64_t, int64_t, bool >::Invoke(targetMethod, targetThis, ___sessionState0, ___sessionId1, ___sessionElapsedTime2, ___sessionChanged3);
					}
					else
					{
						if (il2cpp_codegen_method_is_interface_method(targetMethod))
							InterfaceActionInvoker4< int32_t, int64_t, int64_t, bool >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), targetThis, ___sessionState0, ___sessionId1, ___sessionElapsedTime2, ___sessionChanged3);
						else
							VirtActionInvoker4< int32_t, int64_t, int64_t, bool >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), targetThis, ___sessionState0, ___sessionId1, ___sessionElapsedTime2, ___sessionChanged3);
					}
				}
			}
			else
			{
				typedef void (*FunctionPointerType) (void*, int32_t, int64_t, int64_t, bool, const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(targetThis, ___sessionState0, ___sessionId1, ___sessionElapsedTime2, ___sessionChanged3, targetMethod);
			}
		}
	}
}
// System.IAsyncResult UnityEngine.Analytics.AnalyticsSessionInfo_SessionStateChanged::BeginInvoke(UnityEngine.Analytics.AnalyticsSessionState,System.Int64,System.Int64,System.Boolean,System.AsyncCallback,System.Object)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject* SessionStateChanged_BeginInvoke_mD75E6832EC29F8B01CEEAAACD5DC54322F03D4B3 (SessionStateChanged_t9084549A636BD45086D66CC6765DA8C3DD31066F * __this, int32_t ___sessionState0, int64_t ___sessionId1, int64_t ___sessionElapsedTime2, bool ___sessionChanged3, AsyncCallback_t3F3DA3BEDAEE81DD1D24125DF8EB30E85EE14DA4 * ___callback4, RuntimeObject * ___object5, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SessionStateChanged_BeginInvoke_mD75E6832EC29F8B01CEEAAACD5DC54322F03D4B3_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	void *__d_args[5] = {0};
	__d_args[0] = Box(AnalyticsSessionState_t61CA873937E9A3B881B71B32F518A954A4C8F267_il2cpp_TypeInfo_var, &___sessionState0);
	__d_args[1] = Box(Int64_t7A386C2FF7B0280A0F516992401DDFCF0FF7B436_il2cpp_TypeInfo_var, &___sessionId1);
	__d_args[2] = Box(Int64_t7A386C2FF7B0280A0F516992401DDFCF0FF7B436_il2cpp_TypeInfo_var, &___sessionElapsedTime2);
	__d_args[3] = Box(Boolean_tB53F6830F670160873277339AA58F15CAED4399C_il2cpp_TypeInfo_var, &___sessionChanged3);
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback4, (RuntimeObject*)___object5);
}
// System.Void UnityEngine.Analytics.AnalyticsSessionInfo_SessionStateChanged::EndInvoke(System.IAsyncResult)
extern "C" IL2CPP_METHOD_ATTR void SessionStateChanged_EndInvoke_m1BE07B322DE61DE095B2E2F0D99F41D125F95E42 (SessionStateChanged_t9084549A636BD45086D66CC6765DA8C3DD31066F * __this, RuntimeObject* ___result0, const RuntimeMethod* method)
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
// Conversion methods for marshalling of: UnityEngine.Analytics.CustomEventData
extern "C" void CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37_marshal_pinvoke(const CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37& unmarshaled, CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37_marshaled_pinvoke& marshaled)
{
	marshaled.___m_Ptr_0 = unmarshaled.get_m_Ptr_0();
}
extern "C" void CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37_marshal_pinvoke_back(const CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37_marshaled_pinvoke& marshaled, CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37& unmarshaled)
{
	intptr_t unmarshaled_m_Ptr_temp_0;
	memset(&unmarshaled_m_Ptr_temp_0, 0, sizeof(unmarshaled_m_Ptr_temp_0));
	unmarshaled_m_Ptr_temp_0 = marshaled.___m_Ptr_0;
	unmarshaled.set_m_Ptr_0(unmarshaled_m_Ptr_temp_0);
}
// Conversion method for clean up from marshalling of: UnityEngine.Analytics.CustomEventData
extern "C" void CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37_marshal_pinvoke_cleanup(CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37_marshaled_pinvoke& marshaled)
{
}
// Conversion methods for marshalling of: UnityEngine.Analytics.CustomEventData
extern "C" void CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37_marshal_com(const CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37& unmarshaled, CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37_marshaled_com& marshaled)
{
	marshaled.___m_Ptr_0 = unmarshaled.get_m_Ptr_0();
}
extern "C" void CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37_marshal_com_back(const CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37_marshaled_com& marshaled, CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37& unmarshaled)
{
	intptr_t unmarshaled_m_Ptr_temp_0;
	memset(&unmarshaled_m_Ptr_temp_0, 0, sizeof(unmarshaled_m_Ptr_temp_0));
	unmarshaled_m_Ptr_temp_0 = marshaled.___m_Ptr_0;
	unmarshaled.set_m_Ptr_0(unmarshaled_m_Ptr_temp_0);
}
// Conversion method for clean up from marshalling of: UnityEngine.Analytics.CustomEventData
extern "C" void CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37_marshal_com_cleanup(CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37_marshaled_com& marshaled)
{
}
// System.Void UnityEngine.Analytics.CustomEventData::.ctor(System.String)
extern "C" IL2CPP_METHOD_ATTR void CustomEventData__ctor_mDD616A5357DCBBBEB79725C779E86B9AC2F73078 (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * __this, String_t* ___name0, const RuntimeMethod* method)
{
	{
		Object__ctor_m925ECA5E85CA100E3FB86A4F9E15C120E9A184C0(__this, /*hidden argument*/NULL);
		String_t* L_0 = ___name0;
		intptr_t L_1 = CustomEventData_Internal_Create_m42DF97054891EB8D52D92EC1E1875AF1E0893A1C(__this, L_0, /*hidden argument*/NULL);
		__this->set_m_Ptr_0((intptr_t)L_1);
		return;
	}
}
// System.Void UnityEngine.Analytics.CustomEventData::Finalize()
extern "C" IL2CPP_METHOD_ATTR void CustomEventData_Finalize_mD75450572E12709EC321DF5E82B8FF0F861EE423 (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * __this, const RuntimeMethod* method)
{
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	void* __leave_targets_storage = alloca(sizeof(int32_t) * 1);
	il2cpp::utils::LeaveTargetStack __leave_targets(__leave_targets_storage);
	NO_UNUSED_WARNING (__leave_targets);
	{
	}

IL_0001:
	try
	{ // begin try (depth: 1)
		CustomEventData_Destroy_m60BE08121AFF38808FBD62CC9BF5929E30C444CA(__this, /*hidden argument*/NULL);
		IL2CPP_LEAVE(0x13, FINALLY_000c);
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_000c;
	}

FINALLY_000c:
	{ // begin finally (depth: 1)
		Object_Finalize_m4015B7D3A44DE125C5FE34D7276CD4697C06F380(__this, /*hidden argument*/NULL);
		IL2CPP_END_FINALLY(12)
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(12)
	{
		IL2CPP_JUMP_TBL(0x13, IL_0013)
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
	}

IL_0013:
	{
		return;
	}
}
// System.Void UnityEngine.Analytics.CustomEventData::Destroy()
extern "C" IL2CPP_METHOD_ATTR void CustomEventData_Destroy_m60BE08121AFF38808FBD62CC9BF5929E30C444CA (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (CustomEventData_Destroy_m60BE08121AFF38808FBD62CC9BF5929E30C444CA_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		intptr_t L_0 = __this->get_m_Ptr_0();
		bool L_1 = IntPtr_op_Inequality_mB4886A806009EA825EFCC60CD2A7F6EB8E273A61((intptr_t)L_0, (intptr_t)(0), /*hidden argument*/NULL);
		if (!L_1)
		{
			goto IL_002e;
		}
	}
	{
		intptr_t L_2 = __this->get_m_Ptr_0();
		CustomEventData_Internal_Destroy_mE1D3E1966E7D047C3AB2C49A2E6680DF3097C683((intptr_t)L_2, /*hidden argument*/NULL);
		__this->set_m_Ptr_0((intptr_t)(0));
	}

IL_002e:
	{
		return;
	}
}
// System.Void UnityEngine.Analytics.CustomEventData::Dispose()
extern "C" IL2CPP_METHOD_ATTR void CustomEventData_Dispose_m62D34DC34233E96231793EB2A3F165ED17C29B6C (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (CustomEventData_Dispose_m62D34DC34233E96231793EB2A3F165ED17C29B6C_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		CustomEventData_Destroy_m60BE08121AFF38808FBD62CC9BF5929E30C444CA(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(GC_tC1D7BD74E8F44ECCEF5CD2B5D84BFF9AAE02D01D_il2cpp_TypeInfo_var);
		GC_SuppressFinalize_m037319A9B95A5BA437E806DE592802225EE5B425(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.IntPtr UnityEngine.Analytics.CustomEventData::Internal_Create(UnityEngine.Analytics.CustomEventData,System.String)
extern "C" IL2CPP_METHOD_ATTR intptr_t CustomEventData_Internal_Create_m42DF97054891EB8D52D92EC1E1875AF1E0893A1C (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * ___ced0, String_t* ___name1, const RuntimeMethod* method)
{
	typedef intptr_t (*CustomEventData_Internal_Create_m42DF97054891EB8D52D92EC1E1875AF1E0893A1C_ftn) (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 *, String_t*);
	static CustomEventData_Internal_Create_m42DF97054891EB8D52D92EC1E1875AF1E0893A1C_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (CustomEventData_Internal_Create_m42DF97054891EB8D52D92EC1E1875AF1E0893A1C_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Analytics.CustomEventData::Internal_Create(UnityEngine.Analytics.CustomEventData,System.String)");
	intptr_t retVal = _il2cpp_icall_func(___ced0, ___name1);
	return retVal;
}
// System.Void UnityEngine.Analytics.CustomEventData::Internal_Destroy(System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR void CustomEventData_Internal_Destroy_mE1D3E1966E7D047C3AB2C49A2E6680DF3097C683 (intptr_t ___ptr0, const RuntimeMethod* method)
{
	typedef void (*CustomEventData_Internal_Destroy_mE1D3E1966E7D047C3AB2C49A2E6680DF3097C683_ftn) (intptr_t);
	static CustomEventData_Internal_Destroy_mE1D3E1966E7D047C3AB2C49A2E6680DF3097C683_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (CustomEventData_Internal_Destroy_mE1D3E1966E7D047C3AB2C49A2E6680DF3097C683_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Analytics.CustomEventData::Internal_Destroy(System.IntPtr)");
	_il2cpp_icall_func(___ptr0);
}
// System.Boolean UnityEngine.Analytics.CustomEventData::AddString(System.String,System.String)
extern "C" IL2CPP_METHOD_ATTR bool CustomEventData_AddString_m5E4382F85BC1A6A9814F4DCF887D86EC4D30BF3C (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * __this, String_t* ___key0, String_t* ___value1, const RuntimeMethod* method)
{
	typedef bool (*CustomEventData_AddString_m5E4382F85BC1A6A9814F4DCF887D86EC4D30BF3C_ftn) (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 *, String_t*, String_t*);
	static CustomEventData_AddString_m5E4382F85BC1A6A9814F4DCF887D86EC4D30BF3C_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (CustomEventData_AddString_m5E4382F85BC1A6A9814F4DCF887D86EC4D30BF3C_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Analytics.CustomEventData::AddString(System.String,System.String)");
	bool retVal = _il2cpp_icall_func(__this, ___key0, ___value1);
	return retVal;
}
// System.Boolean UnityEngine.Analytics.CustomEventData::AddInt32(System.String,System.Int32)
extern "C" IL2CPP_METHOD_ATTR bool CustomEventData_AddInt32_m473A606F146A2ABDC1F1E5F0401217E10E088A75 (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * __this, String_t* ___key0, int32_t ___value1, const RuntimeMethod* method)
{
	typedef bool (*CustomEventData_AddInt32_m473A606F146A2ABDC1F1E5F0401217E10E088A75_ftn) (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 *, String_t*, int32_t);
	static CustomEventData_AddInt32_m473A606F146A2ABDC1F1E5F0401217E10E088A75_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (CustomEventData_AddInt32_m473A606F146A2ABDC1F1E5F0401217E10E088A75_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Analytics.CustomEventData::AddInt32(System.String,System.Int32)");
	bool retVal = _il2cpp_icall_func(__this, ___key0, ___value1);
	return retVal;
}
// System.Boolean UnityEngine.Analytics.CustomEventData::AddUInt32(System.String,System.UInt32)
extern "C" IL2CPP_METHOD_ATTR bool CustomEventData_AddUInt32_mEBEA494F859541865FDEC26CBD925E03AB11D78A (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * __this, String_t* ___key0, uint32_t ___value1, const RuntimeMethod* method)
{
	typedef bool (*CustomEventData_AddUInt32_mEBEA494F859541865FDEC26CBD925E03AB11D78A_ftn) (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 *, String_t*, uint32_t);
	static CustomEventData_AddUInt32_mEBEA494F859541865FDEC26CBD925E03AB11D78A_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (CustomEventData_AddUInt32_mEBEA494F859541865FDEC26CBD925E03AB11D78A_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Analytics.CustomEventData::AddUInt32(System.String,System.UInt32)");
	bool retVal = _il2cpp_icall_func(__this, ___key0, ___value1);
	return retVal;
}
// System.Boolean UnityEngine.Analytics.CustomEventData::AddInt64(System.String,System.Int64)
extern "C" IL2CPP_METHOD_ATTR bool CustomEventData_AddInt64_mF79A8D03EB18BE5CC097FDFED8E7DDF9D931B224 (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * __this, String_t* ___key0, int64_t ___value1, const RuntimeMethod* method)
{
	typedef bool (*CustomEventData_AddInt64_mF79A8D03EB18BE5CC097FDFED8E7DDF9D931B224_ftn) (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 *, String_t*, int64_t);
	static CustomEventData_AddInt64_mF79A8D03EB18BE5CC097FDFED8E7DDF9D931B224_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (CustomEventData_AddInt64_mF79A8D03EB18BE5CC097FDFED8E7DDF9D931B224_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Analytics.CustomEventData::AddInt64(System.String,System.Int64)");
	bool retVal = _il2cpp_icall_func(__this, ___key0, ___value1);
	return retVal;
}
// System.Boolean UnityEngine.Analytics.CustomEventData::AddUInt64(System.String,System.UInt64)
extern "C" IL2CPP_METHOD_ATTR bool CustomEventData_AddUInt64_mE0C4870736E758BC54EB4360A834304C72A23432 (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * __this, String_t* ___key0, uint64_t ___value1, const RuntimeMethod* method)
{
	typedef bool (*CustomEventData_AddUInt64_mE0C4870736E758BC54EB4360A834304C72A23432_ftn) (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 *, String_t*, uint64_t);
	static CustomEventData_AddUInt64_mE0C4870736E758BC54EB4360A834304C72A23432_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (CustomEventData_AddUInt64_mE0C4870736E758BC54EB4360A834304C72A23432_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Analytics.CustomEventData::AddUInt64(System.String,System.UInt64)");
	bool retVal = _il2cpp_icall_func(__this, ___key0, ___value1);
	return retVal;
}
// System.Boolean UnityEngine.Analytics.CustomEventData::AddBool(System.String,System.Boolean)
extern "C" IL2CPP_METHOD_ATTR bool CustomEventData_AddBool_m0807E669CA6F9EB72FB53FDD3E45DC66C83B9E41 (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * __this, String_t* ___key0, bool ___value1, const RuntimeMethod* method)
{
	typedef bool (*CustomEventData_AddBool_m0807E669CA6F9EB72FB53FDD3E45DC66C83B9E41_ftn) (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 *, String_t*, bool);
	static CustomEventData_AddBool_m0807E669CA6F9EB72FB53FDD3E45DC66C83B9E41_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (CustomEventData_AddBool_m0807E669CA6F9EB72FB53FDD3E45DC66C83B9E41_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Analytics.CustomEventData::AddBool(System.String,System.Boolean)");
	bool retVal = _il2cpp_icall_func(__this, ___key0, ___value1);
	return retVal;
}
// System.Boolean UnityEngine.Analytics.CustomEventData::AddDouble(System.String,System.Double)
extern "C" IL2CPP_METHOD_ATTR bool CustomEventData_AddDouble_m71B600B1553314D300A4C250272BD97706DE48F5 (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * __this, String_t* ___key0, double ___value1, const RuntimeMethod* method)
{
	typedef bool (*CustomEventData_AddDouble_m71B600B1553314D300A4C250272BD97706DE48F5_ftn) (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 *, String_t*, double);
	static CustomEventData_AddDouble_m71B600B1553314D300A4C250272BD97706DE48F5_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (CustomEventData_AddDouble_m71B600B1553314D300A4C250272BD97706DE48F5_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Analytics.CustomEventData::AddDouble(System.String,System.Double)");
	bool retVal = _il2cpp_icall_func(__this, ___key0, ___value1);
	return retVal;
}
// System.Boolean UnityEngine.Analytics.CustomEventData::AddDictionary(System.Collections.Generic.IDictionary`2<System.String,System.Object>)
extern "C" IL2CPP_METHOD_ATTR bool CustomEventData_AddDictionary_mDA0270C0DE80222EEB3D5B9E6432E59E99C48FA4 (CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37 * __this, RuntimeObject* ___eventData0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (CustomEventData_AddDictionary_mDA0270C0DE80222EEB3D5B9E6432E59E99C48FA4_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	KeyValuePair_2_tBC573EE45BE549307D189378677DF98C3A6C8059  V_0;
	memset(&V_0, 0, sizeof(V_0));
	RuntimeObject* V_1 = NULL;
	String_t* V_2 = NULL;
	RuntimeObject * V_3 = NULL;
	Type_t * V_4 = NULL;
	bool V_5 = false;
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	void* __leave_targets_storage = alloca(sizeof(int32_t) * 2);
	il2cpp::utils::LeaveTargetStack __leave_targets(__leave_targets_storage);
	NO_UNUSED_WARNING (__leave_targets);
	{
		RuntimeObject* L_0 = ___eventData0;
		NullCheck(L_0);
		RuntimeObject* L_1 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* System.Collections.Generic.IEnumerator`1<!0> System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<System.String,System.Object>>::GetEnumerator() */, IEnumerable_1_t228E0A04E82D18717D57712E2B1A5A685AD987C9_il2cpp_TypeInfo_var, L_0);
		V_1 = L_1;
	}

IL_0009:
	try
	{ // begin try (depth: 1)
		{
			goto IL_0291;
		}

IL_000e:
		{
			RuntimeObject* L_2 = V_1;
			NullCheck(L_2);
			KeyValuePair_2_tBC573EE45BE549307D189378677DF98C3A6C8059  L_3 = InterfaceFuncInvoker0< KeyValuePair_2_tBC573EE45BE549307D189378677DF98C3A6C8059  >::Invoke(0 /* !0 System.Collections.Generic.IEnumerator`1<System.Collections.Generic.KeyValuePair`2<System.String,System.Object>>::get_Current() */, IEnumerator_1_t13E977F5B7D3467DB6E01785432A3C4E21E4CDE0_il2cpp_TypeInfo_var, L_2);
			V_0 = L_3;
			String_t* L_4 = KeyValuePair_2_get_Key_mAC09B6950211936EF2A4251B70DF5124DED3CD0B((KeyValuePair_2_tBC573EE45BE549307D189378677DF98C3A6C8059 *)(&V_0), /*hidden argument*/KeyValuePair_2_get_Key_mAC09B6950211936EF2A4251B70DF5124DED3CD0B_RuntimeMethod_var);
			V_2 = L_4;
			RuntimeObject * L_5 = KeyValuePair_2_get_Value_m5D1180FCE84ACA037CCCF151B9696C4575634758((KeyValuePair_2_tBC573EE45BE549307D189378677DF98C3A6C8059 *)(&V_0), /*hidden argument*/KeyValuePair_2_get_Value_m5D1180FCE84ACA037CCCF151B9696C4575634758_RuntimeMethod_var);
			V_3 = L_5;
			RuntimeObject * L_6 = V_3;
			if (L_6)
			{
				goto IL_003f;
			}
		}

IL_002c:
		{
			String_t* L_7 = V_2;
			CustomEventData_AddString_m5E4382F85BC1A6A9814F4DCF887D86EC4D30BF3C(__this, L_7, _stringLiteral2BE88CA4242C76E8253AC62474851065032D6833, /*hidden argument*/NULL);
			goto IL_0291;
		}

IL_003f:
		{
			RuntimeObject * L_8 = V_3;
			NullCheck(L_8);
			Type_t * L_9 = Object_GetType_m2E0B62414ECCAA3094B703790CE88CBB2F83EA60(L_8, /*hidden argument*/NULL);
			V_4 = L_9;
			Type_t * L_10 = V_4;
			RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  L_11 = { reinterpret_cast<intptr_t> (String_t_0_0_0_var) };
			IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
			Type_t * L_12 = Type_GetTypeFromHandle_m9DC58ADF0512987012A8A016FB64B068F3B1AFF6(L_11, /*hidden argument*/NULL);
			if ((!(((RuntimeObject*)(Type_t *)L_10) == ((RuntimeObject*)(Type_t *)L_12))))
			{
				goto IL_006b;
			}
		}

IL_0058:
		{
			String_t* L_13 = V_2;
			RuntimeObject * L_14 = V_3;
			CustomEventData_AddString_m5E4382F85BC1A6A9814F4DCF887D86EC4D30BF3C(__this, L_13, ((String_t*)CastclassSealed((RuntimeObject*)L_14, String_t_il2cpp_TypeInfo_var)), /*hidden argument*/NULL);
			goto IL_0290;
		}

IL_006b:
		{
			Type_t * L_15 = V_4;
			RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  L_16 = { reinterpret_cast<intptr_t> (Char_tBF22D9FC341BE970735250BB6FF1A4A92BBA58B9_0_0_0_var) };
			IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
			Type_t * L_17 = Type_GetTypeFromHandle_m9DC58ADF0512987012A8A016FB64B068F3B1AFF6(L_16, /*hidden argument*/NULL);
			if ((!(((RuntimeObject*)(Type_t *)L_15) == ((RuntimeObject*)(Type_t *)L_17))))
			{
				goto IL_0094;
			}
		}

IL_007c:
		{
			String_t* L_18 = V_2;
			RuntimeObject * L_19 = V_3;
			IL2CPP_RUNTIME_CLASS_INIT(Char_tBF22D9FC341BE970735250BB6FF1A4A92BBA58B9_il2cpp_TypeInfo_var);
			String_t* L_20 = Char_ToString_m106C901B4CB0DDEF732750349DAB71498C42C53F(((*(Il2CppChar*)((Il2CppChar*)UnBox(L_19, Char_tBF22D9FC341BE970735250BB6FF1A4A92BBA58B9_il2cpp_TypeInfo_var)))), /*hidden argument*/NULL);
			CustomEventData_AddString_m5E4382F85BC1A6A9814F4DCF887D86EC4D30BF3C(__this, L_18, L_20, /*hidden argument*/NULL);
			goto IL_0290;
		}

IL_0094:
		{
			Type_t * L_21 = V_4;
			RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  L_22 = { reinterpret_cast<intptr_t> (SByte_t9070AEA2966184235653CB9B4D33B149CDA831DF_0_0_0_var) };
			IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
			Type_t * L_23 = Type_GetTypeFromHandle_m9DC58ADF0512987012A8A016FB64B068F3B1AFF6(L_22, /*hidden argument*/NULL);
			if ((!(((RuntimeObject*)(Type_t *)L_21) == ((RuntimeObject*)(Type_t *)L_23))))
			{
				goto IL_00b9;
			}
		}

IL_00a5:
		{
			String_t* L_24 = V_2;
			RuntimeObject * L_25 = V_3;
			CustomEventData_AddInt32_m473A606F146A2ABDC1F1E5F0401217E10E088A75(__this, L_24, (((int32_t)((int32_t)((*(int8_t*)((int8_t*)UnBox(L_25, SByte_t9070AEA2966184235653CB9B4D33B149CDA831DF_il2cpp_TypeInfo_var))))))), /*hidden argument*/NULL);
			goto IL_0290;
		}

IL_00b9:
		{
			Type_t * L_26 = V_4;
			RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  L_27 = { reinterpret_cast<intptr_t> (Byte_tF87C579059BD4633E6840EBBBEEF899C6E33EF07_0_0_0_var) };
			IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
			Type_t * L_28 = Type_GetTypeFromHandle_m9DC58ADF0512987012A8A016FB64B068F3B1AFF6(L_27, /*hidden argument*/NULL);
			if ((!(((RuntimeObject*)(Type_t *)L_26) == ((RuntimeObject*)(Type_t *)L_28))))
			{
				goto IL_00dd;
			}
		}

IL_00ca:
		{
			String_t* L_29 = V_2;
			RuntimeObject * L_30 = V_3;
			CustomEventData_AddInt32_m473A606F146A2ABDC1F1E5F0401217E10E088A75(__this, L_29, ((*(uint8_t*)((uint8_t*)UnBox(L_30, Byte_tF87C579059BD4633E6840EBBBEEF899C6E33EF07_il2cpp_TypeInfo_var)))), /*hidden argument*/NULL);
			goto IL_0290;
		}

IL_00dd:
		{
			Type_t * L_31 = V_4;
			RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  L_32 = { reinterpret_cast<intptr_t> (Int16_t823A20635DAF5A3D93A1E01CFBF3CBA27CF00B4D_0_0_0_var) };
			IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
			Type_t * L_33 = Type_GetTypeFromHandle_m9DC58ADF0512987012A8A016FB64B068F3B1AFF6(L_32, /*hidden argument*/NULL);
			if ((!(((RuntimeObject*)(Type_t *)L_31) == ((RuntimeObject*)(Type_t *)L_33))))
			{
				goto IL_0101;
			}
		}

IL_00ee:
		{
			String_t* L_34 = V_2;
			RuntimeObject * L_35 = V_3;
			CustomEventData_AddInt32_m473A606F146A2ABDC1F1E5F0401217E10E088A75(__this, L_34, ((*(int16_t*)((int16_t*)UnBox(L_35, Int16_t823A20635DAF5A3D93A1E01CFBF3CBA27CF00B4D_il2cpp_TypeInfo_var)))), /*hidden argument*/NULL);
			goto IL_0290;
		}

IL_0101:
		{
			Type_t * L_36 = V_4;
			RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  L_37 = { reinterpret_cast<intptr_t> (UInt16_tAE45CEF73BF720100519F6867F32145D075F928E_0_0_0_var) };
			IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
			Type_t * L_38 = Type_GetTypeFromHandle_m9DC58ADF0512987012A8A016FB64B068F3B1AFF6(L_37, /*hidden argument*/NULL);
			if ((!(((RuntimeObject*)(Type_t *)L_36) == ((RuntimeObject*)(Type_t *)L_38))))
			{
				goto IL_0125;
			}
		}

IL_0112:
		{
			String_t* L_39 = V_2;
			RuntimeObject * L_40 = V_3;
			CustomEventData_AddUInt32_mEBEA494F859541865FDEC26CBD925E03AB11D78A(__this, L_39, ((*(uint16_t*)((uint16_t*)UnBox(L_40, UInt16_tAE45CEF73BF720100519F6867F32145D075F928E_il2cpp_TypeInfo_var)))), /*hidden argument*/NULL);
			goto IL_0290;
		}

IL_0125:
		{
			Type_t * L_41 = V_4;
			RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  L_42 = { reinterpret_cast<intptr_t> (Int32_t585191389E07734F19F3156FF88FB3EF4800D102_0_0_0_var) };
			IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
			Type_t * L_43 = Type_GetTypeFromHandle_m9DC58ADF0512987012A8A016FB64B068F3B1AFF6(L_42, /*hidden argument*/NULL);
			if ((!(((RuntimeObject*)(Type_t *)L_41) == ((RuntimeObject*)(Type_t *)L_43))))
			{
				goto IL_0149;
			}
		}

IL_0136:
		{
			String_t* L_44 = V_2;
			RuntimeObject * L_45 = V_3;
			CustomEventData_AddInt32_m473A606F146A2ABDC1F1E5F0401217E10E088A75(__this, L_44, ((*(int32_t*)((int32_t*)UnBox(L_45, Int32_t585191389E07734F19F3156FF88FB3EF4800D102_il2cpp_TypeInfo_var)))), /*hidden argument*/NULL);
			goto IL_0290;
		}

IL_0149:
		{
			Type_t * L_46 = V_4;
			RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  L_47 = { reinterpret_cast<intptr_t> (UInt32_t4980FA09003AFAAB5A6E361BA2748EA9A005709B_0_0_0_var) };
			IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
			Type_t * L_48 = Type_GetTypeFromHandle_m9DC58ADF0512987012A8A016FB64B068F3B1AFF6(L_47, /*hidden argument*/NULL);
			if ((!(((RuntimeObject*)(Type_t *)L_46) == ((RuntimeObject*)(Type_t *)L_48))))
			{
				goto IL_0173;
			}
		}

IL_015a:
		{
			String_t* L_49 = KeyValuePair_2_get_Key_mAC09B6950211936EF2A4251B70DF5124DED3CD0B((KeyValuePair_2_tBC573EE45BE549307D189378677DF98C3A6C8059 *)(&V_0), /*hidden argument*/KeyValuePair_2_get_Key_mAC09B6950211936EF2A4251B70DF5124DED3CD0B_RuntimeMethod_var);
			RuntimeObject * L_50 = V_3;
			CustomEventData_AddUInt32_mEBEA494F859541865FDEC26CBD925E03AB11D78A(__this, L_49, ((*(uint32_t*)((uint32_t*)UnBox(L_50, UInt32_t4980FA09003AFAAB5A6E361BA2748EA9A005709B_il2cpp_TypeInfo_var)))), /*hidden argument*/NULL);
			goto IL_0290;
		}

IL_0173:
		{
			Type_t * L_51 = V_4;
			RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  L_52 = { reinterpret_cast<intptr_t> (Int64_t7A386C2FF7B0280A0F516992401DDFCF0FF7B436_0_0_0_var) };
			IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
			Type_t * L_53 = Type_GetTypeFromHandle_m9DC58ADF0512987012A8A016FB64B068F3B1AFF6(L_52, /*hidden argument*/NULL);
			if ((!(((RuntimeObject*)(Type_t *)L_51) == ((RuntimeObject*)(Type_t *)L_53))))
			{
				goto IL_0197;
			}
		}

IL_0184:
		{
			String_t* L_54 = V_2;
			RuntimeObject * L_55 = V_3;
			CustomEventData_AddInt64_mF79A8D03EB18BE5CC097FDFED8E7DDF9D931B224(__this, L_54, ((*(int64_t*)((int64_t*)UnBox(L_55, Int64_t7A386C2FF7B0280A0F516992401DDFCF0FF7B436_il2cpp_TypeInfo_var)))), /*hidden argument*/NULL);
			goto IL_0290;
		}

IL_0197:
		{
			Type_t * L_56 = V_4;
			RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  L_57 = { reinterpret_cast<intptr_t> (UInt64_tA02DF3B59C8FC4A849BD207DA11038CC64E4CB4E_0_0_0_var) };
			IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
			Type_t * L_58 = Type_GetTypeFromHandle_m9DC58ADF0512987012A8A016FB64B068F3B1AFF6(L_57, /*hidden argument*/NULL);
			if ((!(((RuntimeObject*)(Type_t *)L_56) == ((RuntimeObject*)(Type_t *)L_58))))
			{
				goto IL_01bb;
			}
		}

IL_01a8:
		{
			String_t* L_59 = V_2;
			RuntimeObject * L_60 = V_3;
			CustomEventData_AddUInt64_mE0C4870736E758BC54EB4360A834304C72A23432(__this, L_59, ((*(uint64_t*)((uint64_t*)UnBox(L_60, UInt64_tA02DF3B59C8FC4A849BD207DA11038CC64E4CB4E_il2cpp_TypeInfo_var)))), /*hidden argument*/NULL);
			goto IL_0290;
		}

IL_01bb:
		{
			Type_t * L_61 = V_4;
			RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  L_62 = { reinterpret_cast<intptr_t> (Boolean_tB53F6830F670160873277339AA58F15CAED4399C_0_0_0_var) };
			IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
			Type_t * L_63 = Type_GetTypeFromHandle_m9DC58ADF0512987012A8A016FB64B068F3B1AFF6(L_62, /*hidden argument*/NULL);
			if ((!(((RuntimeObject*)(Type_t *)L_61) == ((RuntimeObject*)(Type_t *)L_63))))
			{
				goto IL_01df;
			}
		}

IL_01cc:
		{
			String_t* L_64 = V_2;
			RuntimeObject * L_65 = V_3;
			CustomEventData_AddBool_m0807E669CA6F9EB72FB53FDD3E45DC66C83B9E41(__this, L_64, ((*(bool*)((bool*)UnBox(L_65, Boolean_tB53F6830F670160873277339AA58F15CAED4399C_il2cpp_TypeInfo_var)))), /*hidden argument*/NULL);
			goto IL_0290;
		}

IL_01df:
		{
			Type_t * L_66 = V_4;
			RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  L_67 = { reinterpret_cast<intptr_t> (Single_tDDDA9169C4E4E308AC6D7A824F9B28DC82204AE1_0_0_0_var) };
			IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
			Type_t * L_68 = Type_GetTypeFromHandle_m9DC58ADF0512987012A8A016FB64B068F3B1AFF6(L_67, /*hidden argument*/NULL);
			if ((!(((RuntimeObject*)(Type_t *)L_66) == ((RuntimeObject*)(Type_t *)L_68))))
			{
				goto IL_020d;
			}
		}

IL_01f0:
		{
			String_t* L_69 = V_2;
			RuntimeObject * L_70 = V_3;
			IL2CPP_RUNTIME_CLASS_INIT(Convert_t1C7A851BFB2F0782FD7F72F6AA1DCBB7B53A9C7E_il2cpp_TypeInfo_var);
			Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  L_71 = Convert_ToDecimal_m0723C02BC98733C38A826B8BBF2C4AE24B7CB557(((*(float*)((float*)UnBox(L_70, Single_tDDDA9169C4E4E308AC6D7A824F9B28DC82204AE1_il2cpp_TypeInfo_var)))), /*hidden argument*/NULL);
			IL2CPP_RUNTIME_CLASS_INIT(Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8_il2cpp_TypeInfo_var);
			double L_72 = Decimal_op_Explicit_mB7F34E3B2DFB6211CA5ACB5497DA6CDCB09FC6CE(L_71, /*hidden argument*/NULL);
			CustomEventData_AddDouble_m71B600B1553314D300A4C250272BD97706DE48F5(__this, L_69, L_72, /*hidden argument*/NULL);
			goto IL_0290;
		}

IL_020d:
		{
			Type_t * L_73 = V_4;
			RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  L_74 = { reinterpret_cast<intptr_t> (Double_t358B8F23BDC52A5DD700E727E204F9F7CDE12409_0_0_0_var) };
			IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
			Type_t * L_75 = Type_GetTypeFromHandle_m9DC58ADF0512987012A8A016FB64B068F3B1AFF6(L_74, /*hidden argument*/NULL);
			if ((!(((RuntimeObject*)(Type_t *)L_73) == ((RuntimeObject*)(Type_t *)L_75))))
			{
				goto IL_0231;
			}
		}

IL_021e:
		{
			String_t* L_76 = V_2;
			RuntimeObject * L_77 = V_3;
			CustomEventData_AddDouble_m71B600B1553314D300A4C250272BD97706DE48F5(__this, L_76, ((*(double*)((double*)UnBox(L_77, Double_t358B8F23BDC52A5DD700E727E204F9F7CDE12409_il2cpp_TypeInfo_var)))), /*hidden argument*/NULL);
			goto IL_0290;
		}

IL_0231:
		{
			Type_t * L_78 = V_4;
			RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  L_79 = { reinterpret_cast<intptr_t> (Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8_0_0_0_var) };
			IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
			Type_t * L_80 = Type_GetTypeFromHandle_m9DC58ADF0512987012A8A016FB64B068F3B1AFF6(L_79, /*hidden argument*/NULL);
			if ((!(((RuntimeObject*)(Type_t *)L_78) == ((RuntimeObject*)(Type_t *)L_80))))
			{
				goto IL_025f;
			}
		}

IL_0242:
		{
			String_t* L_81 = V_2;
			RuntimeObject * L_82 = V_3;
			IL2CPP_RUNTIME_CLASS_INIT(Convert_t1C7A851BFB2F0782FD7F72F6AA1DCBB7B53A9C7E_il2cpp_TypeInfo_var);
			Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  L_83 = Convert_ToDecimal_m4084B6BF683AE0078FDC431EAE0A77DD161AC045(((*(Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8 *)((Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8 *)UnBox(L_82, Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8_il2cpp_TypeInfo_var)))), /*hidden argument*/NULL);
			IL2CPP_RUNTIME_CLASS_INIT(Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8_il2cpp_TypeInfo_var);
			double L_84 = Decimal_op_Explicit_mB7F34E3B2DFB6211CA5ACB5497DA6CDCB09FC6CE(L_83, /*hidden argument*/NULL);
			CustomEventData_AddDouble_m71B600B1553314D300A4C250272BD97706DE48F5(__this, L_81, L_84, /*hidden argument*/NULL);
			goto IL_0290;
		}

IL_025f:
		{
			Type_t * L_85 = V_4;
			NullCheck(L_85);
			bool L_86 = Type_get_IsValueType_mDDCCBAE9B59A483CBC3E5C02E3D68CEBEB2E41A8(L_85, /*hidden argument*/NULL);
			if (!L_86)
			{
				goto IL_027e;
			}
		}

IL_026b:
		{
			String_t* L_87 = V_2;
			RuntimeObject * L_88 = V_3;
			NullCheck(L_88);
			String_t* L_89 = VirtFuncInvoker0< String_t* >::Invoke(3 /* System.String System.Object::ToString() */, L_88);
			CustomEventData_AddString_m5E4382F85BC1A6A9814F4DCF887D86EC4D30BF3C(__this, L_87, L_89, /*hidden argument*/NULL);
			goto IL_0290;
		}

IL_027e:
		{
			Type_t * L_90 = V_4;
			String_t* L_91 = String_Format_m0ACDD8B34764E4040AED0B3EEB753567E4576BFA(_stringLiteral351DB7DBABE98AE0DDE4A114100B1D9CFE38CDC8, L_90, /*hidden argument*/NULL);
			ArgumentException_tEDCD16F20A09ECE461C3DA766C16EDA8864057D1 * L_92 = (ArgumentException_tEDCD16F20A09ECE461C3DA766C16EDA8864057D1 *)il2cpp_codegen_object_new(ArgumentException_tEDCD16F20A09ECE461C3DA766C16EDA8864057D1_il2cpp_TypeInfo_var);
			ArgumentException__ctor_m9A85EF7FEFEC21DDD525A67E831D77278E5165B7(L_92, L_91, /*hidden argument*/NULL);
			IL2CPP_RAISE_MANAGED_EXCEPTION(L_92, NULL, CustomEventData_AddDictionary_mDA0270C0DE80222EEB3D5B9E6432E59E99C48FA4_RuntimeMethod_var);
		}

IL_0290:
		{
		}

IL_0291:
		{
			RuntimeObject* L_93 = V_1;
			NullCheck(L_93);
			bool L_94 = InterfaceFuncInvoker0< bool >::Invoke(0 /* System.Boolean System.Collections.IEnumerator::MoveNext() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_93);
			if (L_94)
			{
				goto IL_000e;
			}
		}

IL_029c:
		{
			IL2CPP_LEAVE(0x2AE, FINALLY_02a1);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_02a1;
	}

FINALLY_02a1:
	{ // begin finally (depth: 1)
		{
			RuntimeObject* L_95 = V_1;
			if (!L_95)
			{
				goto IL_02ad;
			}
		}

IL_02a7:
		{
			RuntimeObject* L_96 = V_1;
			NullCheck(L_96);
			InterfaceActionInvoker0::Invoke(0 /* System.Void System.IDisposable::Dispose() */, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var, L_96);
		}

IL_02ad:
		{
			IL2CPP_END_FINALLY(673)
		}
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(673)
	{
		IL2CPP_JUMP_TBL(0x2AE, IL_02ae)
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
	}

IL_02ae:
	{
		V_5 = (bool)1;
		goto IL_02b6;
	}

IL_02b6:
	{
		bool L_97 = V_5;
		return L_97;
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
// Conversion methods for marshalling of: UnityEngine.RemoteConfigSettings
extern "C" void RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A_marshal_pinvoke(const RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A& unmarshaled, RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A_marshaled_pinvoke& marshaled)
{
	marshaled.___m_Ptr_0 = unmarshaled.get_m_Ptr_0();
	marshaled.___Updated_1 = il2cpp_codegen_marshal_delegate(reinterpret_cast<MulticastDelegate_t*>(unmarshaled.get_Updated_1()));
}
extern "C" void RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A_marshal_pinvoke_back(const RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A_marshaled_pinvoke& marshaled, RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A& unmarshaled)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A_pinvoke_FromNativeMethodDefinition_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	intptr_t unmarshaled_m_Ptr_temp_0;
	memset(&unmarshaled_m_Ptr_temp_0, 0, sizeof(unmarshaled_m_Ptr_temp_0));
	unmarshaled_m_Ptr_temp_0 = marshaled.___m_Ptr_0;
	unmarshaled.set_m_Ptr_0(unmarshaled_m_Ptr_temp_0);
	unmarshaled.set_Updated_1(il2cpp_codegen_marshal_function_ptr_to_delegate<Action_1_tAA0F894C98302D68F7D5034E8104E9AB4763CCAD>(marshaled.___Updated_1, Action_1_tAA0F894C98302D68F7D5034E8104E9AB4763CCAD_il2cpp_TypeInfo_var));
}
// Conversion method for clean up from marshalling of: UnityEngine.RemoteConfigSettings
extern "C" void RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A_marshal_pinvoke_cleanup(RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A_marshaled_pinvoke& marshaled)
{
}
// Conversion methods for marshalling of: UnityEngine.RemoteConfigSettings
extern "C" void RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A_marshal_com(const RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A& unmarshaled, RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A_marshaled_com& marshaled)
{
	marshaled.___m_Ptr_0 = unmarshaled.get_m_Ptr_0();
	marshaled.___Updated_1 = il2cpp_codegen_marshal_delegate(reinterpret_cast<MulticastDelegate_t*>(unmarshaled.get_Updated_1()));
}
extern "C" void RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A_marshal_com_back(const RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A_marshaled_com& marshaled, RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A& unmarshaled)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A_com_FromNativeMethodDefinition_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	intptr_t unmarshaled_m_Ptr_temp_0;
	memset(&unmarshaled_m_Ptr_temp_0, 0, sizeof(unmarshaled_m_Ptr_temp_0));
	unmarshaled_m_Ptr_temp_0 = marshaled.___m_Ptr_0;
	unmarshaled.set_m_Ptr_0(unmarshaled_m_Ptr_temp_0);
	unmarshaled.set_Updated_1(il2cpp_codegen_marshal_function_ptr_to_delegate<Action_1_tAA0F894C98302D68F7D5034E8104E9AB4763CCAD>(marshaled.___Updated_1, Action_1_tAA0F894C98302D68F7D5034E8104E9AB4763CCAD_il2cpp_TypeInfo_var));
}
// Conversion method for clean up from marshalling of: UnityEngine.RemoteConfigSettings
extern "C" void RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A_marshal_com_cleanup(RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A_marshaled_com& marshaled)
{
}
// System.Void UnityEngine.RemoteConfigSettings::Finalize()
extern "C" IL2CPP_METHOD_ATTR void RemoteConfigSettings_Finalize_mCF0EFDB4164F476B8835E6B16DA29165536ADC9A (RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A * __this, const RuntimeMethod* method)
{
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	void* __leave_targets_storage = alloca(sizeof(int32_t) * 1);
	il2cpp::utils::LeaveTargetStack __leave_targets(__leave_targets_storage);
	NO_UNUSED_WARNING (__leave_targets);
	{
	}

IL_0001:
	try
	{ // begin try (depth: 1)
		RemoteConfigSettings_Destroy_m91215D772DF190B8AD9A73C8165DEDBE129C7A10(__this, /*hidden argument*/NULL);
		IL2CPP_LEAVE(0x13, FINALLY_000c);
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_000c;
	}

FINALLY_000c:
	{ // begin finally (depth: 1)
		Object_Finalize_m4015B7D3A44DE125C5FE34D7276CD4697C06F380(__this, /*hidden argument*/NULL);
		IL2CPP_END_FINALLY(12)
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(12)
	{
		IL2CPP_JUMP_TBL(0x13, IL_0013)
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
	}

IL_0013:
	{
		return;
	}
}
// System.Void UnityEngine.RemoteConfigSettings::Destroy()
extern "C" IL2CPP_METHOD_ATTR void RemoteConfigSettings_Destroy_m91215D772DF190B8AD9A73C8165DEDBE129C7A10 (RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (RemoteConfigSettings_Destroy_m91215D772DF190B8AD9A73C8165DEDBE129C7A10_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		intptr_t L_0 = __this->get_m_Ptr_0();
		bool L_1 = IntPtr_op_Inequality_mB4886A806009EA825EFCC60CD2A7F6EB8E273A61((intptr_t)L_0, (intptr_t)(0), /*hidden argument*/NULL);
		if (!L_1)
		{
			goto IL_002e;
		}
	}
	{
		intptr_t L_2 = __this->get_m_Ptr_0();
		RemoteConfigSettings_Internal_Destroy_mC419232704AC40CF7B3C5FB17A8A3D9FD2604F66((intptr_t)L_2, /*hidden argument*/NULL);
		__this->set_m_Ptr_0((intptr_t)(0));
	}

IL_002e:
	{
		return;
	}
}
// System.Void UnityEngine.RemoteConfigSettings::Dispose()
extern "C" IL2CPP_METHOD_ATTR void RemoteConfigSettings_Dispose_m0A43CAB1AE923C6D6D7854A9F78B8842E8E1F39E (RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (RemoteConfigSettings_Dispose_m0A43CAB1AE923C6D6D7854A9F78B8842E8E1F39E_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		RemoteConfigSettings_Destroy_m91215D772DF190B8AD9A73C8165DEDBE129C7A10(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(GC_tC1D7BD74E8F44ECCEF5CD2B5D84BFF9AAE02D01D_il2cpp_TypeInfo_var);
		GC_SuppressFinalize_m037319A9B95A5BA437E806DE592802225EE5B425(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void UnityEngine.RemoteConfigSettings::Internal_Destroy(System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR void RemoteConfigSettings_Internal_Destroy_mC419232704AC40CF7B3C5FB17A8A3D9FD2604F66 (intptr_t ___ptr0, const RuntimeMethod* method)
{
	typedef void (*RemoteConfigSettings_Internal_Destroy_mC419232704AC40CF7B3C5FB17A8A3D9FD2604F66_ftn) (intptr_t);
	static RemoteConfigSettings_Internal_Destroy_mC419232704AC40CF7B3C5FB17A8A3D9FD2604F66_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (RemoteConfigSettings_Internal_Destroy_mC419232704AC40CF7B3C5FB17A8A3D9FD2604F66_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.RemoteConfigSettings::Internal_Destroy(System.IntPtr)");
	_il2cpp_icall_func(___ptr0);
}
// System.Void UnityEngine.RemoteConfigSettings::RemoteConfigSettingsUpdated(UnityEngine.RemoteConfigSettings,System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void RemoteConfigSettings_RemoteConfigSettingsUpdated_mF72E8C9F99B752FEA9EA388CCC1EFECC24733504 (RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A * ___rcs0, bool ___wasLastUpdatedFromServer1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (RemoteConfigSettings_RemoteConfigSettingsUpdated_mF72E8C9F99B752FEA9EA388CCC1EFECC24733504_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_tAA0F894C98302D68F7D5034E8104E9AB4763CCAD * V_0 = NULL;
	{
		RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A * L_0 = ___rcs0;
		NullCheck(L_0);
		Action_1_tAA0F894C98302D68F7D5034E8104E9AB4763CCAD * L_1 = L_0->get_Updated_1();
		V_0 = L_1;
		Action_1_tAA0F894C98302D68F7D5034E8104E9AB4763CCAD * L_2 = V_0;
		if (!L_2)
		{
			goto IL_0015;
		}
	}
	{
		Action_1_tAA0F894C98302D68F7D5034E8104E9AB4763CCAD * L_3 = V_0;
		bool L_4 = ___wasLastUpdatedFromServer1;
		NullCheck(L_3);
		Action_1_Invoke_m45E8F9900F9DB395C48A868A7C6A83BDD7FC692F(L_3, L_4, /*hidden argument*/Action_1_Invoke_m45E8F9900F9DB395C48A868A7C6A83BDD7FC692F_RuntimeMethod_var);
	}

IL_0015:
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
// System.Void UnityEngine.RemoteSettings::add_Completed(System.Action`3<System.Boolean,System.Boolean,System.Int32>)
extern "C" IL2CPP_METHOD_ATTR void RemoteSettings_add_Completed_m8BD179217DCB0B9561DF18871458096979F64002 (Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (RemoteSettings_add_Completed_m8BD179217DCB0B9561DF18871458096979F64002_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * V_0 = NULL;
	Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * V_1 = NULL;
	{
		Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * L_0 = ((RemoteSettings_t3F7E07D15288B0DF84A4A32044592D8AFA6D36ED_StaticFields*)il2cpp_codegen_static_fields_for(RemoteSettings_t3F7E07D15288B0DF84A4A32044592D8AFA6D36ED_il2cpp_TypeInfo_var))->get_Completed_2();
		V_0 = L_0;
	}

IL_0006:
	{
		Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * L_1 = V_0;
		V_1 = L_1;
		Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * L_2 = V_1;
		Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * L_3 = ___value0;
		Delegate_t * L_4 = Delegate_Combine_mC25D2F7DECAFBA6D9A2F9EBA8A77063F0658ECF1(L_2, L_3, /*hidden argument*/NULL);
		Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * L_5 = V_0;
		Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * L_6 = InterlockedCompareExchangeImpl<Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E *>((Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E **)(((RemoteSettings_t3F7E07D15288B0DF84A4A32044592D8AFA6D36ED_StaticFields*)il2cpp_codegen_static_fields_for(RemoteSettings_t3F7E07D15288B0DF84A4A32044592D8AFA6D36ED_il2cpp_TypeInfo_var))->get_address_of_Completed_2()), ((Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E *)CastclassSealed((RuntimeObject*)L_4, Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E_il2cpp_TypeInfo_var)), L_5);
		V_0 = L_6;
		Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * L_7 = V_0;
		Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * L_8 = V_1;
		if ((!(((RuntimeObject*)(Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E *)L_7) == ((RuntimeObject*)(Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E *)L_8))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
// System.Void UnityEngine.RemoteSettings::remove_Completed(System.Action`3<System.Boolean,System.Boolean,System.Int32>)
extern "C" IL2CPP_METHOD_ATTR void RemoteSettings_remove_Completed_m396F802C4D5DD73B3FC54522705C974CB3E28D97 (Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (RemoteSettings_remove_Completed_m396F802C4D5DD73B3FC54522705C974CB3E28D97_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * V_0 = NULL;
	Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * V_1 = NULL;
	{
		Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * L_0 = ((RemoteSettings_t3F7E07D15288B0DF84A4A32044592D8AFA6D36ED_StaticFields*)il2cpp_codegen_static_fields_for(RemoteSettings_t3F7E07D15288B0DF84A4A32044592D8AFA6D36ED_il2cpp_TypeInfo_var))->get_Completed_2();
		V_0 = L_0;
	}

IL_0006:
	{
		Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * L_1 = V_0;
		V_1 = L_1;
		Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * L_2 = V_1;
		Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * L_3 = ___value0;
		Delegate_t * L_4 = Delegate_Remove_m0B0DB7D1B3AF96B71AFAA72BA0EFE32FBBC2932D(L_2, L_3, /*hidden argument*/NULL);
		Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * L_5 = V_0;
		Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * L_6 = InterlockedCompareExchangeImpl<Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E *>((Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E **)(((RemoteSettings_t3F7E07D15288B0DF84A4A32044592D8AFA6D36ED_StaticFields*)il2cpp_codegen_static_fields_for(RemoteSettings_t3F7E07D15288B0DF84A4A32044592D8AFA6D36ED_il2cpp_TypeInfo_var))->get_address_of_Completed_2()), ((Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E *)CastclassSealed((RuntimeObject*)L_4, Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E_il2cpp_TypeInfo_var)), L_5);
		V_0 = L_6;
		Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * L_7 = V_0;
		Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * L_8 = V_1;
		if ((!(((RuntimeObject*)(Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E *)L_7) == ((RuntimeObject*)(Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E *)L_8))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
// System.Void UnityEngine.RemoteSettings::RemoteSettingsUpdated(System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void RemoteSettings_RemoteSettingsUpdated_mD5427A08A622FDAA576A3D9CF05AD4C7CC6102F5 (bool ___wasLastUpdatedFromServer0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (RemoteSettings_RemoteSettingsUpdated_mD5427A08A622FDAA576A3D9CF05AD4C7CC6102F5_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	UpdatedEventHandler_tB0230BC83686D7126AB4D3800A66351028CA514F * V_0 = NULL;
	{
		UpdatedEventHandler_tB0230BC83686D7126AB4D3800A66351028CA514F * L_0 = ((RemoteSettings_t3F7E07D15288B0DF84A4A32044592D8AFA6D36ED_StaticFields*)il2cpp_codegen_static_fields_for(RemoteSettings_t3F7E07D15288B0DF84A4A32044592D8AFA6D36ED_il2cpp_TypeInfo_var))->get_Updated_0();
		V_0 = L_0;
		UpdatedEventHandler_tB0230BC83686D7126AB4D3800A66351028CA514F * L_1 = V_0;
		if (!L_1)
		{
			goto IL_0013;
		}
	}
	{
		UpdatedEventHandler_tB0230BC83686D7126AB4D3800A66351028CA514F * L_2 = V_0;
		NullCheck(L_2);
		UpdatedEventHandler_Invoke_mD2D72D86708690251A8A947FECE091E8EE0107E7(L_2, /*hidden argument*/NULL);
	}

IL_0013:
	{
		return;
	}
}
// System.Void UnityEngine.RemoteSettings::RemoteSettingsBeforeFetchFromServer()
extern "C" IL2CPP_METHOD_ATTR void RemoteSettings_RemoteSettingsBeforeFetchFromServer_mBF1BEF2ACAFE13AE7B820FCA5CB7B81CF614EF11 (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (RemoteSettings_RemoteSettingsBeforeFetchFromServer_mBF1BEF2ACAFE13AE7B820FCA5CB7B81CF614EF11_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Action_t591D2A86165F896B4B800BB5C25CE18672A55579 * V_0 = NULL;
	{
		Action_t591D2A86165F896B4B800BB5C25CE18672A55579 * L_0 = ((RemoteSettings_t3F7E07D15288B0DF84A4A32044592D8AFA6D36ED_StaticFields*)il2cpp_codegen_static_fields_for(RemoteSettings_t3F7E07D15288B0DF84A4A32044592D8AFA6D36ED_il2cpp_TypeInfo_var))->get_BeforeFetchFromServer_1();
		V_0 = L_0;
		Action_t591D2A86165F896B4B800BB5C25CE18672A55579 * L_1 = V_0;
		if (!L_1)
		{
			goto IL_0013;
		}
	}
	{
		Action_t591D2A86165F896B4B800BB5C25CE18672A55579 * L_2 = V_0;
		NullCheck(L_2);
		Action_Invoke_mC8D676E5DDF967EC5D23DD0E96FB52AA499817FD(L_2, /*hidden argument*/NULL);
	}

IL_0013:
	{
		return;
	}
}
// System.Void UnityEngine.RemoteSettings::RemoteSettingsUpdateCompleted(System.Boolean,System.Boolean,System.Int32)
extern "C" IL2CPP_METHOD_ATTR void RemoteSettings_RemoteSettingsUpdateCompleted_m6C6C3568C5A8F319CD06F8303111F06AB3718A02 (bool ___wasLastUpdatedFromServer0, bool ___settingsChanged1, int32_t ___response2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (RemoteSettings_RemoteSettingsUpdateCompleted_m6C6C3568C5A8F319CD06F8303111F06AB3718A02_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * V_0 = NULL;
	{
		Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * L_0 = ((RemoteSettings_t3F7E07D15288B0DF84A4A32044592D8AFA6D36ED_StaticFields*)il2cpp_codegen_static_fields_for(RemoteSettings_t3F7E07D15288B0DF84A4A32044592D8AFA6D36ED_il2cpp_TypeInfo_var))->get_Completed_2();
		V_0 = L_0;
		Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * L_1 = V_0;
		if (!L_1)
		{
			goto IL_0016;
		}
	}
	{
		Action_3_tEE1FB0623176AFA5109FAA9BA7E82293445CAE1E * L_2 = V_0;
		bool L_3 = ___wasLastUpdatedFromServer0;
		bool L_4 = ___settingsChanged1;
		int32_t L_5 = ___response2;
		NullCheck(L_2);
		Action_3_Invoke_m8A4240174E60397816F6EACC65FE1E27F4275FA5(L_2, L_3, L_4, L_5, /*hidden argument*/Action_3_Invoke_m8A4240174E60397816F6EACC65FE1E27F4275FA5_RuntimeMethod_var);
	}

IL_0016:
	{
		return;
	}
}
// System.Int32 UnityEngine.RemoteSettings::GetInt(System.String,System.Int32)
extern "C" IL2CPP_METHOD_ATTR int32_t RemoteSettings_GetInt_mCFBD46FD8AC6148F16AFFA2BBA6B42E3DA26F89F (String_t* ___key0, int32_t ___defaultValue1, const RuntimeMethod* method)
{
	typedef int32_t (*RemoteSettings_GetInt_mCFBD46FD8AC6148F16AFFA2BBA6B42E3DA26F89F_ftn) (String_t*, int32_t);
	static RemoteSettings_GetInt_mCFBD46FD8AC6148F16AFFA2BBA6B42E3DA26F89F_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (RemoteSettings_GetInt_mCFBD46FD8AC6148F16AFFA2BBA6B42E3DA26F89F_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.RemoteSettings::GetInt(System.String,System.Int32)");
	int32_t retVal = _il2cpp_icall_func(___key0, ___defaultValue1);
	return retVal;
}
// System.Single UnityEngine.RemoteSettings::GetFloat(System.String,System.Single)
extern "C" IL2CPP_METHOD_ATTR float RemoteSettings_GetFloat_m12591A38CBF22B607F96DFC898EDE89C8B1DFAB3 (String_t* ___key0, float ___defaultValue1, const RuntimeMethod* method)
{
	typedef float (*RemoteSettings_GetFloat_m12591A38CBF22B607F96DFC898EDE89C8B1DFAB3_ftn) (String_t*, float);
	static RemoteSettings_GetFloat_m12591A38CBF22B607F96DFC898EDE89C8B1DFAB3_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (RemoteSettings_GetFloat_m12591A38CBF22B607F96DFC898EDE89C8B1DFAB3_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.RemoteSettings::GetFloat(System.String,System.Single)");
	float retVal = _il2cpp_icall_func(___key0, ___defaultValue1);
	return retVal;
}
// System.String UnityEngine.RemoteSettings::GetString(System.String,System.String)
extern "C" IL2CPP_METHOD_ATTR String_t* RemoteSettings_GetString_mE8A5FA0E3DBF4C5CA508410FF1B2B660E54F045D (String_t* ___key0, String_t* ___defaultValue1, const RuntimeMethod* method)
{
	typedef String_t* (*RemoteSettings_GetString_mE8A5FA0E3DBF4C5CA508410FF1B2B660E54F045D_ftn) (String_t*, String_t*);
	static RemoteSettings_GetString_mE8A5FA0E3DBF4C5CA508410FF1B2B660E54F045D_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (RemoteSettings_GetString_mE8A5FA0E3DBF4C5CA508410FF1B2B660E54F045D_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.RemoteSettings::GetString(System.String,System.String)");
	String_t* retVal = _il2cpp_icall_func(___key0, ___defaultValue1);
	return retVal;
}
// System.Boolean UnityEngine.RemoteSettings::GetBool(System.String,System.Boolean)
extern "C" IL2CPP_METHOD_ATTR bool RemoteSettings_GetBool_m802B9B58A66D1D81D166A6D09735FE2A15707714 (String_t* ___key0, bool ___defaultValue1, const RuntimeMethod* method)
{
	typedef bool (*RemoteSettings_GetBool_m802B9B58A66D1D81D166A6D09735FE2A15707714_ftn) (String_t*, bool);
	static RemoteSettings_GetBool_m802B9B58A66D1D81D166A6D09735FE2A15707714_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (RemoteSettings_GetBool_m802B9B58A66D1D81D166A6D09735FE2A15707714_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.RemoteSettings::GetBool(System.String,System.Boolean)");
	bool retVal = _il2cpp_icall_func(___key0, ___defaultValue1);
	return retVal;
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
extern "C"  void DelegatePInvokeWrapper_UpdatedEventHandler_tB0230BC83686D7126AB4D3800A66351028CA514F (UpdatedEventHandler_tB0230BC83686D7126AB4D3800A66351028CA514F * __this, const RuntimeMethod* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc)();
	PInvokeFunc il2cppPInvokeFunc = reinterpret_cast<PInvokeFunc>(il2cpp_codegen_get_method_pointer(((RuntimeDelegate*)__this)->method));

	// Native function invocation
	il2cppPInvokeFunc();

}
// System.Void UnityEngine.RemoteSettings_UpdatedEventHandler::.ctor(System.Object,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR void UpdatedEventHandler__ctor_mB0CFE6A3B394C3858502E54A9CBEE97B40690DE7 (UpdatedEventHandler_tB0230BC83686D7126AB4D3800A66351028CA514F * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method)
{
	__this->set_method_ptr_0(il2cpp_codegen_get_method_pointer((RuntimeMethod*)___method1));
	__this->set_method_3(___method1);
	__this->set_m_target_2(___object0);
}
// System.Void UnityEngine.RemoteSettings_UpdatedEventHandler::Invoke()
extern "C" IL2CPP_METHOD_ATTR void UpdatedEventHandler_Invoke_mD2D72D86708690251A8A947FECE091E8EE0107E7 (UpdatedEventHandler_tB0230BC83686D7126AB4D3800A66351028CA514F * __this, const RuntimeMethod* method)
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
				if (___parameterCount == 0)
				{
					// open
					typedef void (*FunctionPointerType) (const RuntimeMethod*);
					((FunctionPointerType)targetMethodPointer)(targetMethod);
				}
				else
				{
					// closed
					typedef void (*FunctionPointerType) (void*, const RuntimeMethod*);
					((FunctionPointerType)targetMethodPointer)(targetThis, targetMethod);
				}
			}
			else
			{
				// closed
				if (il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
				{
					if (il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
					{
						if (il2cpp_codegen_method_is_generic_instance(targetMethod))
						{
							if (il2cpp_codegen_method_is_interface_method(targetMethod))
								GenericInterfaceActionInvoker0::Invoke(targetMethod, targetThis);
							else
								GenericVirtActionInvoker0::Invoke(targetMethod, targetThis);
						}
						else
						{
							if (il2cpp_codegen_method_is_interface_method(targetMethod))
								InterfaceActionInvoker0::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), targetThis);
							else
								VirtActionInvoker0::Invoke(il2cpp_codegen_method_get_slot(targetMethod), targetThis);
						}
					}
				}
				else
				{
					typedef void (*FunctionPointerType) (void*, const RuntimeMethod*);
					((FunctionPointerType)targetMethodPointer)(targetThis, targetMethod);
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
			if (___parameterCount == 0)
			{
				// open
				typedef void (*FunctionPointerType) (const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(targetMethod);
			}
			else
			{
				// closed
				typedef void (*FunctionPointerType) (void*, const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(targetThis, targetMethod);
			}
		}
		else
		{
			// closed
			if (il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
			{
				if (il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
				{
					if (il2cpp_codegen_method_is_generic_instance(targetMethod))
					{
						if (il2cpp_codegen_method_is_interface_method(targetMethod))
							GenericInterfaceActionInvoker0::Invoke(targetMethod, targetThis);
						else
							GenericVirtActionInvoker0::Invoke(targetMethod, targetThis);
					}
					else
					{
						if (il2cpp_codegen_method_is_interface_method(targetMethod))
							InterfaceActionInvoker0::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), targetThis);
						else
							VirtActionInvoker0::Invoke(il2cpp_codegen_method_get_slot(targetMethod), targetThis);
					}
				}
			}
			else
			{
				typedef void (*FunctionPointerType) (void*, const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(targetThis, targetMethod);
			}
		}
	}
}
// System.IAsyncResult UnityEngine.RemoteSettings_UpdatedEventHandler::BeginInvoke(System.AsyncCallback,System.Object)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject* UpdatedEventHandler_BeginInvoke_m45D924AF948243AD8BD8D2E403DD57544E34507E (UpdatedEventHandler_tB0230BC83686D7126AB4D3800A66351028CA514F * __this, AsyncCallback_t3F3DA3BEDAEE81DD1D24125DF8EB30E85EE14DA4 * ___callback0, RuntimeObject * ___object1, const RuntimeMethod* method)
{
	void *__d_args[1] = {0};
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback0, (RuntimeObject*)___object1);
}
// System.Void UnityEngine.RemoteSettings_UpdatedEventHandler::EndInvoke(System.IAsyncResult)
extern "C" IL2CPP_METHOD_ATTR void UpdatedEventHandler_EndInvoke_m54BCADBF1EE00E9C6DFF9D59C578C3C244CA3EA5 (UpdatedEventHandler_tB0230BC83686D7126AB4D3800A66351028CA514F * __this, RuntimeObject* ___result0, const RuntimeMethod* method)
{
	il2cpp_codegen_delegate_end_invoke((Il2CppAsyncResult*) ___result0, 0);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
