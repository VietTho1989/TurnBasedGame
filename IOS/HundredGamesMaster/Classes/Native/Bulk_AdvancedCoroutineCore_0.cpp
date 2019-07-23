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

template <typename R, typename T1>
struct VirtFuncInvoker1
{
	typedef R (*Func)(void*, T1, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, p1, invokeData.method);
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
template <typename R>
struct GenericVirtFuncInvoker0
{
	typedef R (*Func)(void*, const RuntimeMethod*);

	static inline R Invoke (const RuntimeMethod* method, RuntimeObject* obj)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_virtual_invoke_data(method, obj, &invokeData);
		return ((Func)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename R, typename T1>
struct GenericVirtFuncInvoker1
{
	typedef R (*Func)(void*, T1, const RuntimeMethod*);

	static inline R Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_virtual_invoke_data(method, obj, &invokeData);
		return ((Func)invokeData.methodPtr)(obj, p1, invokeData.method);
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
template <typename R, typename T1>
struct InterfaceFuncInvoker1
{
	typedef R (*Func)(void*, T1, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		return ((Func)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename R>
struct GenericInterfaceFuncInvoker0
{
	typedef R (*Func)(void*, const RuntimeMethod*);

	static inline R Invoke (const RuntimeMethod* method, RuntimeObject* obj)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_interface_invoke_data(method, obj, &invokeData);
		return ((Func)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename R, typename T1>
struct GenericInterfaceFuncInvoker1
{
	typedef R (*Func)(void*, T1, const RuntimeMethod*);

	static inline R Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_interface_invoke_data(method, obj, &invokeData);
		return ((Func)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};

// AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll
struct AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B;
// AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll/ExtentionMethod
struct ExtentionMethod_t5D761100D20609B5439AA1BE14D9F9BC6F698151;
// AdvancedCoroutines.Routine
struct Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF;
// AdvancedCoroutines.Routine[]
struct RoutineU5BU5D_t50BF3ABB9B86FBCBEF9A99645EBCFB505D8C002F;
// System.ArgumentNullException
struct ArgumentNullException_t581DF992B1F3E0EC6EFB30CC5DC43519A79B27AD;
// System.AsyncCallback
struct AsyncCallback_t3F3DA3BEDAEE81DD1D24125DF8EB30E85EE14DA4;
// System.Char[]
struct CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2;
// System.Collections.Generic.Dictionary`2/Entry<AdvancedCoroutines.Routine,System.String>[]
struct EntryU5BU5D_t1A5088A9C4DBF49823BAF1E52EAF8F6EB5F55843;
// System.Collections.Generic.Dictionary`2/KeyCollection<AdvancedCoroutines.Routine,System.String>
struct KeyCollection_t9F1C8FCE4611F6523379411D47FFDA4BEDF0F6B3;
// System.Collections.Generic.Dictionary`2/ValueCollection<AdvancedCoroutines.Routine,System.String>
struct ValueCollection_t54891972DC949B01F3DC33B70D9C0B316FB42EB7;
// System.Collections.Generic.Dictionary`2<AdvancedCoroutines.Routine,System.String>
struct Dictionary_2_tB10A5D0DDD081F3EFE74C0C35884F2216111ED48;
// System.Collections.Generic.Dictionary`2<System.Object,System.Object>
struct Dictionary_2_t32F25F093828AA9F93CB11C2A2B4648FD62A09BA;
// System.Collections.Generic.IEqualityComparer`1<AdvancedCoroutines.Routine>
struct IEqualityComparer_1_t3BE29E607BB063FC6E8E4236EF2D2DFAD3ED575C;
// System.Collections.Generic.List`1<AdvancedCoroutines.Routine>
struct List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB;
// System.Collections.Generic.List`1<System.Object>
struct List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D;
// System.Collections.IDictionary
struct IDictionary_t1BD5C1546718A374EA8122FBD6C6EE45331E8CE7;
// System.Collections.IEnumerator
struct IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A;
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
// System.Int32[]
struct Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83;
// System.IntPtr[]
struct IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD;
// System.Reflection.MethodInfo
struct MethodInfo_t;
// System.Runtime.Serialization.SafeSerializationManager
struct SafeSerializationManager_t4A754D86B0F784B18CBC36C073BA564BED109770;
// System.String
struct String_t;
// System.Void
struct Void_t22962CB4C05B1D89B55A6E1139F0E87A90987017;

extern RuntimeClass* AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B_il2cpp_TypeInfo_var;
extern RuntimeClass* AdvancedCoroutinesStatistics_tD1A40FB5B47CB66A9325B023E08B94D3F04A126C_il2cpp_TypeInfo_var;
extern RuntimeClass* ArgumentNullException_t581DF992B1F3E0EC6EFB30CC5DC43519A79B27AD_il2cpp_TypeInfo_var;
extern RuntimeClass* Dictionary_2_tB10A5D0DDD081F3EFE74C0C35884F2216111ED48_il2cpp_TypeInfo_var;
extern RuntimeClass* IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var;
extern RuntimeClass* List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB_il2cpp_TypeInfo_var;
extern RuntimeClass* Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF_il2cpp_TypeInfo_var;
extern RuntimeClass* Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B_il2cpp_TypeInfo_var;
extern String_t* _stringLiteral85865F57B794ED3AFFD4B73795491F68D725865A;
extern const RuntimeMethod* Dictionary_2_ContainsKey_m7CCAFEF9A9B3B9C0674FC7B08A5F818ABFBA9340_RuntimeMethod_var;
extern const RuntimeMethod* Dictionary_2_Remove_mDF1C8989572A0C846C14258CAFC82C1359F9C42F_RuntimeMethod_var;
extern const RuntimeMethod* Dictionary_2__ctor_m69ED04E59A57469134B4954B96BC07E608A4914C_RuntimeMethod_var;
extern const RuntimeMethod* List_1_Add_m8E0568559657D5416679C2B0256290CE360F5B70_RuntimeMethod_var;
extern const RuntimeMethod* List_1_RemoveAt_m961C171A3D0AC6CB35B08FE4D9C6775D8E7C119C_RuntimeMethod_var;
extern const RuntimeMethod* List_1__ctor_m2EA5049DFA568BF766FDE80964DBEB69BE0D9D47_RuntimeMethod_var;
extern const RuntimeMethod* List_1_get_Count_m817E36D02851E81A47915E1C711B511A82BFB9AD_RuntimeMethod_var;
extern const RuntimeMethod* List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02_RuntimeMethod_var;
extern const RuntimeMethod* Routine__ctor_m297D1A7613863FF731F6FB5F00FDBB24EB00B913_RuntimeMethod_var;
extern const uint32_t AdvancedCoroutinesCoreDll_DeleteRoutineFromStorage_mD49A26EF1BEF726B3A5AA2193754B5E6C3838A50_MetadataUsageId;
extern const uint32_t AdvancedCoroutinesCoreDll_IsRoutineInNormalCondition_mE639780C54F0EC9D218AEECBACE975C93CA502B1_MetadataUsageId;
extern const uint32_t AdvancedCoroutinesCoreDll_LateUpdateRoutine_mA10F7016F4BBDE3E0A23C38163E70E077D162AFD_MetadataUsageId;
extern const uint32_t AdvancedCoroutinesCoreDll_OnPostRender_mB1870104982402AF3BB60A77D0CA8A220C4B701F_MetadataUsageId;
extern const uint32_t AdvancedCoroutinesCoreDll_StartRoutine_mAB3D200F63F5CD39DA5CEBB42B815C1B46AFD8D4_MetadataUsageId;
extern const uint32_t AdvancedCoroutinesCoreDll_StopAllCoroutines_m067A6ADED4183D91ACA97CBDAC2FE9974FAF2961_MetadataUsageId;
extern const uint32_t AdvancedCoroutinesCoreDll_UpdateRoutine_mD88AA1280D12E597E783AC0AC24F176195181DE5_MetadataUsageId;
extern const uint32_t AdvancedCoroutinesCoreDll__ctor_m3FEE181FC3DB86769CCB14E888F8FD0CBE877D0F_MetadataUsageId;
extern const uint32_t AdvancedCoroutinesStatistics_Remove_mAF48156A8072F97509ED56A4C57965FACD4585BA_MetadataUsageId;
extern const uint32_t AdvancedCoroutinesStatistics__cctor_mCF89762CD3FC398B26CE8638B8FC104D341A7763_MetadataUsageId;
extern const uint32_t AdvancedCoroutinesStatistics_get_TotalCoroutinesStops_mAC4EDF4D9170C333C1B4DACE8B3FD66A869E14D2_MetadataUsageId;
extern const uint32_t AdvancedCoroutinesStatistics_set_TotalCoroutinesStarts_m929A36B197CEB724718474F5B3AC716F589B41E5_MetadataUsageId;
extern const uint32_t AdvancedCoroutinesStatistics_set_TotalCoroutinesStops_m262ED54B841E1FE0FBC748EC4657CB5711B44D9B_MetadataUsageId;
extern const uint32_t Routine__ctor_m297D1A7613863FF731F6FB5F00FDBB24EB00B913_MetadataUsageId;
struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;

struct DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86;


#ifndef U3CMODULEU3E_T0048AF7A6496D1A297234BE1B00E13B325D3CB3C_H
#define U3CMODULEU3E_T0048AF7A6496D1A297234BE1B00E13B325D3CB3C_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct  U3CModuleU3E_t0048AF7A6496D1A297234BE1B00E13B325D3CB3C 
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // U3CMODULEU3E_T0048AF7A6496D1A297234BE1B00E13B325D3CB3C_H
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
#ifndef ADVANCEDCOROUTINESCOREDLL_T69613D35FBCC1700A1B31AE170AC7DEC5745439B_H
#define ADVANCEDCOROUTINESCOREDLL_T69613D35FBCC1700A1B31AE170AC7DEC5745439B_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll
struct  AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B  : public RuntimeObject
{
public:
	// System.Collections.Generic.List`1<AdvancedCoroutines.Routine> AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll::_routines
	List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * ____routines_0;

public:
	inline static int32_t get_offset_of__routines_0() { return static_cast<int32_t>(offsetof(AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B, ____routines_0)); }
	inline List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * get__routines_0() const { return ____routines_0; }
	inline List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB ** get_address_of__routines_0() { return &____routines_0; }
	inline void set__routines_0(List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * value)
	{
		____routines_0 = value;
		Il2CppCodeGenWriteBarrier((&____routines_0), value);
	}
};

struct AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B_StaticFields
{
public:
	// AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll_ExtentionMethod AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll::ExtMethod
	ExtentionMethod_t5D761100D20609B5439AA1BE14D9F9BC6F698151 * ___ExtMethod_1;

public:
	inline static int32_t get_offset_of_ExtMethod_1() { return static_cast<int32_t>(offsetof(AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B_StaticFields, ___ExtMethod_1)); }
	inline ExtentionMethod_t5D761100D20609B5439AA1BE14D9F9BC6F698151 * get_ExtMethod_1() const { return ___ExtMethod_1; }
	inline ExtentionMethod_t5D761100D20609B5439AA1BE14D9F9BC6F698151 ** get_address_of_ExtMethod_1() { return &___ExtMethod_1; }
	inline void set_ExtMethod_1(ExtentionMethod_t5D761100D20609B5439AA1BE14D9F9BC6F698151 * value)
	{
		___ExtMethod_1 = value;
		Il2CppCodeGenWriteBarrier((&___ExtMethod_1), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ADVANCEDCOROUTINESCOREDLL_T69613D35FBCC1700A1B31AE170AC7DEC5745439B_H
#ifndef ROUTINE_T904ED3ED5262F6EA661391CB0EAD6714FA4B81FF_H
#define ROUTINE_T904ED3ED5262F6EA661391CB0EAD6714FA4B81FF_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AdvancedCoroutines.Routine
struct  Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF  : public RuntimeObject
{
public:
	// System.Collections.IEnumerator AdvancedCoroutines.Routine::enumerator
	RuntimeObject* ___enumerator_0;
	// System.Object AdvancedCoroutines.Routine::obj
	RuntimeObject * ___obj_1;
	// System.Single AdvancedCoroutines.Routine::workTime
	float ___workTime_2;
	// System.Single AdvancedCoroutines.Routine::startTime
	float ___startTime_3;
	// System.Boolean AdvancedCoroutines.Routine::isPaused
	bool ___isPaused_4;
	// System.Boolean AdvancedCoroutines.Routine::isStandalone
	bool ___isStandalone_5;
	// System.Boolean AdvancedCoroutines.Routine::needToCheckEndOfUpdate
	bool ___needToCheckEndOfUpdate_6;
	// System.Boolean AdvancedCoroutines.Routine::needToCheckPostRender
	bool ___needToCheckPostRender_7;

public:
	inline static int32_t get_offset_of_enumerator_0() { return static_cast<int32_t>(offsetof(Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF, ___enumerator_0)); }
	inline RuntimeObject* get_enumerator_0() const { return ___enumerator_0; }
	inline RuntimeObject** get_address_of_enumerator_0() { return &___enumerator_0; }
	inline void set_enumerator_0(RuntimeObject* value)
	{
		___enumerator_0 = value;
		Il2CppCodeGenWriteBarrier((&___enumerator_0), value);
	}

	inline static int32_t get_offset_of_obj_1() { return static_cast<int32_t>(offsetof(Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF, ___obj_1)); }
	inline RuntimeObject * get_obj_1() const { return ___obj_1; }
	inline RuntimeObject ** get_address_of_obj_1() { return &___obj_1; }
	inline void set_obj_1(RuntimeObject * value)
	{
		___obj_1 = value;
		Il2CppCodeGenWriteBarrier((&___obj_1), value);
	}

	inline static int32_t get_offset_of_workTime_2() { return static_cast<int32_t>(offsetof(Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF, ___workTime_2)); }
	inline float get_workTime_2() const { return ___workTime_2; }
	inline float* get_address_of_workTime_2() { return &___workTime_2; }
	inline void set_workTime_2(float value)
	{
		___workTime_2 = value;
	}

	inline static int32_t get_offset_of_startTime_3() { return static_cast<int32_t>(offsetof(Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF, ___startTime_3)); }
	inline float get_startTime_3() const { return ___startTime_3; }
	inline float* get_address_of_startTime_3() { return &___startTime_3; }
	inline void set_startTime_3(float value)
	{
		___startTime_3 = value;
	}

	inline static int32_t get_offset_of_isPaused_4() { return static_cast<int32_t>(offsetof(Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF, ___isPaused_4)); }
	inline bool get_isPaused_4() const { return ___isPaused_4; }
	inline bool* get_address_of_isPaused_4() { return &___isPaused_4; }
	inline void set_isPaused_4(bool value)
	{
		___isPaused_4 = value;
	}

	inline static int32_t get_offset_of_isStandalone_5() { return static_cast<int32_t>(offsetof(Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF, ___isStandalone_5)); }
	inline bool get_isStandalone_5() const { return ___isStandalone_5; }
	inline bool* get_address_of_isStandalone_5() { return &___isStandalone_5; }
	inline void set_isStandalone_5(bool value)
	{
		___isStandalone_5 = value;
	}

	inline static int32_t get_offset_of_needToCheckEndOfUpdate_6() { return static_cast<int32_t>(offsetof(Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF, ___needToCheckEndOfUpdate_6)); }
	inline bool get_needToCheckEndOfUpdate_6() const { return ___needToCheckEndOfUpdate_6; }
	inline bool* get_address_of_needToCheckEndOfUpdate_6() { return &___needToCheckEndOfUpdate_6; }
	inline void set_needToCheckEndOfUpdate_6(bool value)
	{
		___needToCheckEndOfUpdate_6 = value;
	}

	inline static int32_t get_offset_of_needToCheckPostRender_7() { return static_cast<int32_t>(offsetof(Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF, ___needToCheckPostRender_7)); }
	inline bool get_needToCheckPostRender_7() const { return ___needToCheckPostRender_7; }
	inline bool* get_address_of_needToCheckPostRender_7() { return &___needToCheckPostRender_7; }
	inline void set_needToCheckPostRender_7(bool value)
	{
		___needToCheckPostRender_7 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ROUTINE_T904ED3ED5262F6EA661391CB0EAD6714FA4B81FF_H
#ifndef ADVANCEDCOROUTINESSTATISTICS_TD1A40FB5B47CB66A9325B023E08B94D3F04A126C_H
#define ADVANCEDCOROUTINESSTATISTICS_TD1A40FB5B47CB66A9325B023E08B94D3F04A126C_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AdvancedCoroutines.Statistics.AdvancedCoroutinesStatistics
struct  AdvancedCoroutinesStatistics_tD1A40FB5B47CB66A9325B023E08B94D3F04A126C  : public RuntimeObject
{
public:

public:
};

struct AdvancedCoroutinesStatistics_tD1A40FB5B47CB66A9325B023E08B94D3F04A126C_StaticFields
{
public:
	// System.Boolean AdvancedCoroutines.Statistics.AdvancedCoroutinesStatistics::IsActive
	bool ___IsActive_0;
	// System.Collections.Generic.Dictionary`2<AdvancedCoroutines.Routine,System.String> AdvancedCoroutines.Statistics.AdvancedCoroutinesStatistics::_rouitinesStatistics
	Dictionary_2_tB10A5D0DDD081F3EFE74C0C35884F2216111ED48 * ____rouitinesStatistics_1;
	// System.Int32 AdvancedCoroutines.Statistics.AdvancedCoroutinesStatistics::<TotalCoroutinesStarts>k__BackingField
	int32_t ___U3CTotalCoroutinesStartsU3Ek__BackingField_2;
	// System.Int32 AdvancedCoroutines.Statistics.AdvancedCoroutinesStatistics::<TotalCoroutinesStops>k__BackingField
	int32_t ___U3CTotalCoroutinesStopsU3Ek__BackingField_3;

public:
	inline static int32_t get_offset_of_IsActive_0() { return static_cast<int32_t>(offsetof(AdvancedCoroutinesStatistics_tD1A40FB5B47CB66A9325B023E08B94D3F04A126C_StaticFields, ___IsActive_0)); }
	inline bool get_IsActive_0() const { return ___IsActive_0; }
	inline bool* get_address_of_IsActive_0() { return &___IsActive_0; }
	inline void set_IsActive_0(bool value)
	{
		___IsActive_0 = value;
	}

	inline static int32_t get_offset_of__rouitinesStatistics_1() { return static_cast<int32_t>(offsetof(AdvancedCoroutinesStatistics_tD1A40FB5B47CB66A9325B023E08B94D3F04A126C_StaticFields, ____rouitinesStatistics_1)); }
	inline Dictionary_2_tB10A5D0DDD081F3EFE74C0C35884F2216111ED48 * get__rouitinesStatistics_1() const { return ____rouitinesStatistics_1; }
	inline Dictionary_2_tB10A5D0DDD081F3EFE74C0C35884F2216111ED48 ** get_address_of__rouitinesStatistics_1() { return &____rouitinesStatistics_1; }
	inline void set__rouitinesStatistics_1(Dictionary_2_tB10A5D0DDD081F3EFE74C0C35884F2216111ED48 * value)
	{
		____rouitinesStatistics_1 = value;
		Il2CppCodeGenWriteBarrier((&____rouitinesStatistics_1), value);
	}

	inline static int32_t get_offset_of_U3CTotalCoroutinesStartsU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(AdvancedCoroutinesStatistics_tD1A40FB5B47CB66A9325B023E08B94D3F04A126C_StaticFields, ___U3CTotalCoroutinesStartsU3Ek__BackingField_2)); }
	inline int32_t get_U3CTotalCoroutinesStartsU3Ek__BackingField_2() const { return ___U3CTotalCoroutinesStartsU3Ek__BackingField_2; }
	inline int32_t* get_address_of_U3CTotalCoroutinesStartsU3Ek__BackingField_2() { return &___U3CTotalCoroutinesStartsU3Ek__BackingField_2; }
	inline void set_U3CTotalCoroutinesStartsU3Ek__BackingField_2(int32_t value)
	{
		___U3CTotalCoroutinesStartsU3Ek__BackingField_2 = value;
	}

	inline static int32_t get_offset_of_U3CTotalCoroutinesStopsU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(AdvancedCoroutinesStatistics_tD1A40FB5B47CB66A9325B023E08B94D3F04A126C_StaticFields, ___U3CTotalCoroutinesStopsU3Ek__BackingField_3)); }
	inline int32_t get_U3CTotalCoroutinesStopsU3Ek__BackingField_3() const { return ___U3CTotalCoroutinesStopsU3Ek__BackingField_3; }
	inline int32_t* get_address_of_U3CTotalCoroutinesStopsU3Ek__BackingField_3() { return &___U3CTotalCoroutinesStopsU3Ek__BackingField_3; }
	inline void set_U3CTotalCoroutinesStopsU3Ek__BackingField_3(int32_t value)
	{
		___U3CTotalCoroutinesStopsU3Ek__BackingField_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ADVANCEDCOROUTINESSTATISTICS_TD1A40FB5B47CB66A9325B023E08B94D3F04A126C_H
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
#ifndef DICTIONARY_2_TB10A5D0DDD081F3EFE74C0C35884F2216111ED48_H
#define DICTIONARY_2_TB10A5D0DDD081F3EFE74C0C35884F2216111ED48_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.Dictionary`2<AdvancedCoroutines.Routine,System.String>
struct  Dictionary_2_tB10A5D0DDD081F3EFE74C0C35884F2216111ED48  : public RuntimeObject
{
public:
	// System.Int32[] System.Collections.Generic.Dictionary`2::buckets
	Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* ___buckets_0;
	// System.Collections.Generic.Dictionary`2_Entry<TKey,TValue>[] System.Collections.Generic.Dictionary`2::entries
	EntryU5BU5D_t1A5088A9C4DBF49823BAF1E52EAF8F6EB5F55843* ___entries_1;
	// System.Int32 System.Collections.Generic.Dictionary`2::count
	int32_t ___count_2;
	// System.Int32 System.Collections.Generic.Dictionary`2::version
	int32_t ___version_3;
	// System.Int32 System.Collections.Generic.Dictionary`2::freeList
	int32_t ___freeList_4;
	// System.Int32 System.Collections.Generic.Dictionary`2::freeCount
	int32_t ___freeCount_5;
	// System.Collections.Generic.IEqualityComparer`1<TKey> System.Collections.Generic.Dictionary`2::comparer
	RuntimeObject* ___comparer_6;
	// System.Collections.Generic.Dictionary`2_KeyCollection<TKey,TValue> System.Collections.Generic.Dictionary`2::keys
	KeyCollection_t9F1C8FCE4611F6523379411D47FFDA4BEDF0F6B3 * ___keys_7;
	// System.Collections.Generic.Dictionary`2_ValueCollection<TKey,TValue> System.Collections.Generic.Dictionary`2::values
	ValueCollection_t54891972DC949B01F3DC33B70D9C0B316FB42EB7 * ___values_8;
	// System.Object System.Collections.Generic.Dictionary`2::_syncRoot
	RuntimeObject * ____syncRoot_9;

public:
	inline static int32_t get_offset_of_buckets_0() { return static_cast<int32_t>(offsetof(Dictionary_2_tB10A5D0DDD081F3EFE74C0C35884F2216111ED48, ___buckets_0)); }
	inline Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* get_buckets_0() const { return ___buckets_0; }
	inline Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83** get_address_of_buckets_0() { return &___buckets_0; }
	inline void set_buckets_0(Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* value)
	{
		___buckets_0 = value;
		Il2CppCodeGenWriteBarrier((&___buckets_0), value);
	}

	inline static int32_t get_offset_of_entries_1() { return static_cast<int32_t>(offsetof(Dictionary_2_tB10A5D0DDD081F3EFE74C0C35884F2216111ED48, ___entries_1)); }
	inline EntryU5BU5D_t1A5088A9C4DBF49823BAF1E52EAF8F6EB5F55843* get_entries_1() const { return ___entries_1; }
	inline EntryU5BU5D_t1A5088A9C4DBF49823BAF1E52EAF8F6EB5F55843** get_address_of_entries_1() { return &___entries_1; }
	inline void set_entries_1(EntryU5BU5D_t1A5088A9C4DBF49823BAF1E52EAF8F6EB5F55843* value)
	{
		___entries_1 = value;
		Il2CppCodeGenWriteBarrier((&___entries_1), value);
	}

	inline static int32_t get_offset_of_count_2() { return static_cast<int32_t>(offsetof(Dictionary_2_tB10A5D0DDD081F3EFE74C0C35884F2216111ED48, ___count_2)); }
	inline int32_t get_count_2() const { return ___count_2; }
	inline int32_t* get_address_of_count_2() { return &___count_2; }
	inline void set_count_2(int32_t value)
	{
		___count_2 = value;
	}

	inline static int32_t get_offset_of_version_3() { return static_cast<int32_t>(offsetof(Dictionary_2_tB10A5D0DDD081F3EFE74C0C35884F2216111ED48, ___version_3)); }
	inline int32_t get_version_3() const { return ___version_3; }
	inline int32_t* get_address_of_version_3() { return &___version_3; }
	inline void set_version_3(int32_t value)
	{
		___version_3 = value;
	}

	inline static int32_t get_offset_of_freeList_4() { return static_cast<int32_t>(offsetof(Dictionary_2_tB10A5D0DDD081F3EFE74C0C35884F2216111ED48, ___freeList_4)); }
	inline int32_t get_freeList_4() const { return ___freeList_4; }
	inline int32_t* get_address_of_freeList_4() { return &___freeList_4; }
	inline void set_freeList_4(int32_t value)
	{
		___freeList_4 = value;
	}

	inline static int32_t get_offset_of_freeCount_5() { return static_cast<int32_t>(offsetof(Dictionary_2_tB10A5D0DDD081F3EFE74C0C35884F2216111ED48, ___freeCount_5)); }
	inline int32_t get_freeCount_5() const { return ___freeCount_5; }
	inline int32_t* get_address_of_freeCount_5() { return &___freeCount_5; }
	inline void set_freeCount_5(int32_t value)
	{
		___freeCount_5 = value;
	}

	inline static int32_t get_offset_of_comparer_6() { return static_cast<int32_t>(offsetof(Dictionary_2_tB10A5D0DDD081F3EFE74C0C35884F2216111ED48, ___comparer_6)); }
	inline RuntimeObject* get_comparer_6() const { return ___comparer_6; }
	inline RuntimeObject** get_address_of_comparer_6() { return &___comparer_6; }
	inline void set_comparer_6(RuntimeObject* value)
	{
		___comparer_6 = value;
		Il2CppCodeGenWriteBarrier((&___comparer_6), value);
	}

	inline static int32_t get_offset_of_keys_7() { return static_cast<int32_t>(offsetof(Dictionary_2_tB10A5D0DDD081F3EFE74C0C35884F2216111ED48, ___keys_7)); }
	inline KeyCollection_t9F1C8FCE4611F6523379411D47FFDA4BEDF0F6B3 * get_keys_7() const { return ___keys_7; }
	inline KeyCollection_t9F1C8FCE4611F6523379411D47FFDA4BEDF0F6B3 ** get_address_of_keys_7() { return &___keys_7; }
	inline void set_keys_7(KeyCollection_t9F1C8FCE4611F6523379411D47FFDA4BEDF0F6B3 * value)
	{
		___keys_7 = value;
		Il2CppCodeGenWriteBarrier((&___keys_7), value);
	}

	inline static int32_t get_offset_of_values_8() { return static_cast<int32_t>(offsetof(Dictionary_2_tB10A5D0DDD081F3EFE74C0C35884F2216111ED48, ___values_8)); }
	inline ValueCollection_t54891972DC949B01F3DC33B70D9C0B316FB42EB7 * get_values_8() const { return ___values_8; }
	inline ValueCollection_t54891972DC949B01F3DC33B70D9C0B316FB42EB7 ** get_address_of_values_8() { return &___values_8; }
	inline void set_values_8(ValueCollection_t54891972DC949B01F3DC33B70D9C0B316FB42EB7 * value)
	{
		___values_8 = value;
		Il2CppCodeGenWriteBarrier((&___values_8), value);
	}

	inline static int32_t get_offset_of__syncRoot_9() { return static_cast<int32_t>(offsetof(Dictionary_2_tB10A5D0DDD081F3EFE74C0C35884F2216111ED48, ____syncRoot_9)); }
	inline RuntimeObject * get__syncRoot_9() const { return ____syncRoot_9; }
	inline RuntimeObject ** get_address_of__syncRoot_9() { return &____syncRoot_9; }
	inline void set__syncRoot_9(RuntimeObject * value)
	{
		____syncRoot_9 = value;
		Il2CppCodeGenWriteBarrier((&____syncRoot_9), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // DICTIONARY_2_TB10A5D0DDD081F3EFE74C0C35884F2216111ED48_H
#ifndef LIST_1_T6CD1050B50D96D7CD11E766D25E925E64BB9D3AB_H
#define LIST_1_T6CD1050B50D96D7CD11E766D25E925E64BB9D3AB_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.List`1<AdvancedCoroutines.Routine>
struct  List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	RoutineU5BU5D_t50BF3ABB9B86FBCBEF9A99645EBCFB505D8C002F* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject * ____syncRoot_4;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB, ____items_1)); }
	inline RoutineU5BU5D_t50BF3ABB9B86FBCBEF9A99645EBCFB505D8C002F* get__items_1() const { return ____items_1; }
	inline RoutineU5BU5D_t50BF3ABB9B86FBCBEF9A99645EBCFB505D8C002F** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(RoutineU5BU5D_t50BF3ABB9B86FBCBEF9A99645EBCFB505D8C002F* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((&____items_1), value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}

	inline static int32_t get_offset_of__syncRoot_4() { return static_cast<int32_t>(offsetof(List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB, ____syncRoot_4)); }
	inline RuntimeObject * get__syncRoot_4() const { return ____syncRoot_4; }
	inline RuntimeObject ** get_address_of__syncRoot_4() { return &____syncRoot_4; }
	inline void set__syncRoot_4(RuntimeObject * value)
	{
		____syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier((&____syncRoot_4), value);
	}
};

struct List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::_emptyArray
	RoutineU5BU5D_t50BF3ABB9B86FBCBEF9A99645EBCFB505D8C002F* ____emptyArray_5;

public:
	inline static int32_t get_offset_of__emptyArray_5() { return static_cast<int32_t>(offsetof(List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB_StaticFields, ____emptyArray_5)); }
	inline RoutineU5BU5D_t50BF3ABB9B86FBCBEF9A99645EBCFB505D8C002F* get__emptyArray_5() const { return ____emptyArray_5; }
	inline RoutineU5BU5D_t50BF3ABB9B86FBCBEF9A99645EBCFB505D8C002F** get_address_of__emptyArray_5() { return &____emptyArray_5; }
	inline void set__emptyArray_5(RoutineU5BU5D_t50BF3ABB9B86FBCBEF9A99645EBCFB505D8C002F* value)
	{
		____emptyArray_5 = value;
		Il2CppCodeGenWriteBarrier((&____emptyArray_5), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LIST_1_T6CD1050B50D96D7CD11E766D25E925E64BB9D3AB_H
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
#ifndef WAITTYPEINTERNAL_TA3112EC8684AAC89D1558A7DD5E0905D17D5CDBB_H
#define WAITTYPEINTERNAL_TA3112EC8684AAC89D1558A7DD5E0905D17D5CDBB_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AdvancedCoroutines.Wait_WaitTypeInternal
struct  WaitTypeInternal_tA3112EC8684AAC89D1558A7DD5E0905D17D5CDBB 
{
public:
	// System.Int32 AdvancedCoroutines.Wait_WaitTypeInternal::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(WaitTypeInternal_tA3112EC8684AAC89D1558A7DD5E0905D17D5CDBB, ___value___2)); }
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
#endif // WAITTYPEINTERNAL_TA3112EC8684AAC89D1558A7DD5E0905D17D5CDBB_H
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
#ifndef WAIT_T2B7CA3C9C8A8241109259437A2F62272E112281B_H
#define WAIT_T2B7CA3C9C8A8241109259437A2F62272E112281B_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AdvancedCoroutines.Wait
struct  Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B 
{
public:
	// System.Single AdvancedCoroutines.Wait::Seconds
	float ___Seconds_0;
	// AdvancedCoroutines.Wait_WaitTypeInternal AdvancedCoroutines.Wait::waitTypeInternal
	int32_t ___waitTypeInternal_1;

public:
	inline static int32_t get_offset_of_Seconds_0() { return static_cast<int32_t>(offsetof(Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B, ___Seconds_0)); }
	inline float get_Seconds_0() const { return ___Seconds_0; }
	inline float* get_address_of_Seconds_0() { return &___Seconds_0; }
	inline void set_Seconds_0(float value)
	{
		___Seconds_0 = value;
	}

	inline static int32_t get_offset_of_waitTypeInternal_1() { return static_cast<int32_t>(offsetof(Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B, ___waitTypeInternal_1)); }
	inline int32_t get_waitTypeInternal_1() const { return ___waitTypeInternal_1; }
	inline int32_t* get_address_of_waitTypeInternal_1() { return &___waitTypeInternal_1; }
	inline void set_waitTypeInternal_1(int32_t value)
	{
		___waitTypeInternal_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // WAIT_T2B7CA3C9C8A8241109259437A2F62272E112281B_H
#ifndef ARGUMENTNULLEXCEPTION_T581DF992B1F3E0EC6EFB30CC5DC43519A79B27AD_H
#define ARGUMENTNULLEXCEPTION_T581DF992B1F3E0EC6EFB30CC5DC43519A79B27AD_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ArgumentNullException
struct  ArgumentNullException_t581DF992B1F3E0EC6EFB30CC5DC43519A79B27AD  : public ArgumentException_tEDCD16F20A09ECE461C3DA766C16EDA8864057D1
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARGUMENTNULLEXCEPTION_T581DF992B1F3E0EC6EFB30CC5DC43519A79B27AD_H
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
#ifndef EXTENTIONMETHOD_T5D761100D20609B5439AA1BE14D9F9BC6F698151_H
#define EXTENTIONMETHOD_T5D761100D20609B5439AA1BE14D9F9BC6F698151_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll_ExtentionMethod
struct  ExtentionMethod_t5D761100D20609B5439AA1BE14D9F9BC6F698151  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // EXTENTIONMETHOD_T5D761100D20609B5439AA1BE14D9F9BC6F698151_H
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
// !0 System.Collections.Generic.List`1<System.Object>::get_Item(System.Int32)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * List_1_get_Item_mFDB8AD680C600072736579BBF5F38F7416396588_gshared (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * __this, int32_t p0, const RuntimeMethod* method);
// System.Int32 System.Collections.Generic.List`1<System.Object>::get_Count()
extern "C" IL2CPP_METHOD_ATTR int32_t List_1_get_Count_m507C9149FF7F83AAC72C29091E745D557DA47D22_gshared (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Object>::Add(!0)
extern "C" IL2CPP_METHOD_ATTR void List_1_Add_m6930161974C7504C80F52EC379EF012387D43138_gshared (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * __this, RuntimeObject * p0, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Object>::RemoveAt(System.Int32)
extern "C" IL2CPP_METHOD_ATTR void List_1_RemoveAt_m3CAF82E0FF61CD84E251E0F7231BBB867C9755C2_gshared (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * __this, int32_t p0, const RuntimeMethod* method);
// System.Void System.Collections.Generic.Dictionary`2<System.Object,System.Object>::.ctor()
extern "C" IL2CPP_METHOD_ATTR void Dictionary_2__ctor_m2C7E51568033239B506E15E7804A0B8658246498_gshared (Dictionary_2_t32F25F093828AA9F93CB11C2A2B4648FD62A09BA * __this, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.Dictionary`2<System.Object,System.Object>::ContainsKey(!0)
extern "C" IL2CPP_METHOD_ATTR bool Dictionary_2_ContainsKey_m4EBC00E16E83DA33851A551757D2B7332D5756B9_gshared (Dictionary_2_t32F25F093828AA9F93CB11C2A2B4648FD62A09BA * __this, RuntimeObject * p0, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.Dictionary`2<System.Object,System.Object>::Remove(!0)
extern "C" IL2CPP_METHOD_ATTR bool Dictionary_2_Remove_m0FCCD33CE2C6A7589E52A2AB0872FE361BF5EF60_gshared (Dictionary_2_t32F25F093828AA9F93CB11C2A2B4648FD62A09BA * __this, RuntimeObject * p0, const RuntimeMethod* method);

// System.Void System.Object::.ctor()
extern "C" IL2CPP_METHOD_ATTR void Object__ctor_m925ECA5E85CA100E3FB86A4F9E15C120E9A184C0 (RuntimeObject * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<AdvancedCoroutines.Routine>::.ctor()
inline void List_1__ctor_m2EA5049DFA568BF766FDE80964DBEB69BE0D9D47 (List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB *, const RuntimeMethod*))List_1__ctor_mC832F1AC0F814BAEB19175F5D7972A7507508BC3_gshared)(__this, method);
}
// System.Void AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll::UpdateRoutine(System.Single)
extern "C" IL2CPP_METHOD_ATTR void AdvancedCoroutinesCoreDll_UpdateRoutine_mD88AA1280D12E597E783AC0AC24F176195181DE5 (AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B * __this, float ___deltaTime0, const RuntimeMethod* method);
// System.Void AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll::LateUpdateRoutine()
extern "C" IL2CPP_METHOD_ATTR void AdvancedCoroutinesCoreDll_LateUpdateRoutine_mA10F7016F4BBDE3E0A23C38163E70E077D162AFD (AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B * __this, const RuntimeMethod* method);
// AdvancedCoroutines.Routine AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll::StartRoutine(System.Collections.IEnumerator,System.Object)
extern "C" IL2CPP_METHOD_ATTR Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * AdvancedCoroutinesCoreDll_StartRoutine_mAB3D200F63F5CD39DA5CEBB42B815C1B46AFD8D4 (AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B * __this, RuntimeObject* ___enumerator0, RuntimeObject * ___obj1, const RuntimeMethod* method);
// System.Boolean AdvancedCoroutines.Routine::IsNull(AdvancedCoroutines.Routine)
extern "C" IL2CPP_METHOD_ATTR bool Routine_IsNull_mEA1F21C592E71B6C4E8D2D1FBF399B9EDADA7261 (Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * ___routine0, const RuntimeMethod* method);
// System.Void AdvancedCoroutines.Routine::Erase(AdvancedCoroutines.Routine)
extern "C" IL2CPP_METHOD_ATTR void Routine_Erase_mBA0FEAAB9CCBB58197EB98EFE49BB0267CEA6E74 (Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * ___routine0, const RuntimeMethod* method);
// !0 System.Collections.Generic.List`1<AdvancedCoroutines.Routine>::get_Item(System.Int32)
inline Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02 (List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * __this, int32_t p0, const RuntimeMethod* method)
{
	return ((  Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * (*) (List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB *, int32_t, const RuntimeMethod*))List_1_get_Item_mFDB8AD680C600072736579BBF5F38F7416396588_gshared)(__this, p0, method);
}
// System.Int32 System.Collections.Generic.List`1<AdvancedCoroutines.Routine>::get_Count()
inline int32_t List_1_get_Count_m817E36D02851E81A47915E1C711B511A82BFB9AD (List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB *, const RuntimeMethod*))List_1_get_Count_m507C9149FF7F83AAC72C29091E745D557DA47D22_gshared)(__this, method);
}
// System.Void AdvancedCoroutines.Routine::.ctor(System.Collections.IEnumerator,System.Object)
extern "C" IL2CPP_METHOD_ATTR void Routine__ctor_m297D1A7613863FF731F6FB5F00FDBB24EB00B913 (Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * __this, RuntimeObject* ___enumerator0, RuntimeObject * ___obj1, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<AdvancedCoroutines.Routine>::Add(!0)
inline void List_1_Add_m8E0568559657D5416679C2B0256290CE360F5B70 (List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * __this, Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * p0, const RuntimeMethod* method)
{
	((  void (*) (List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB *, Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF *, const RuntimeMethod*))List_1_Add_m6930161974C7504C80F52EC379EF012387D43138_gshared)(__this, p0, method);
}
// System.Boolean AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll/ExtentionMethod::Invoke(System.Object)
extern "C" IL2CPP_METHOD_ATTR bool ExtentionMethod_Invoke_m6AFEFC97436D17DA9CAC64113D172F1AA0161EAB (ExtentionMethod_t5D761100D20609B5439AA1BE14D9F9BC6F698151 * __this, RuntimeObject * ___o0, const RuntimeMethod* method);
// System.Boolean AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll::IsRoutineInNormalCondition(System.Int32)
extern "C" IL2CPP_METHOD_ATTR bool AdvancedCoroutinesCoreDll_IsRoutineInNormalCondition_mE639780C54F0EC9D218AEECBACE975C93CA502B1 (AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B * __this, int32_t ___index0, const RuntimeMethod* method);
// System.Void AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll::DeleteRoutineFromStorage(System.Int32&)
extern "C" IL2CPP_METHOD_ATTR void AdvancedCoroutinesCoreDll_DeleteRoutineFromStorage_mD49A26EF1BEF726B3A5AA2193754B5E6C3838A50 (AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B * __this, int32_t* ___iRoutine0, const RuntimeMethod* method);
// System.Void AdvancedCoroutines.Statistics.AdvancedCoroutinesStatistics::Remove(AdvancedCoroutines.Routine)
extern "C" IL2CPP_METHOD_ATTR void AdvancedCoroutinesStatistics_Remove_mAF48156A8072F97509ED56A4C57965FACD4585BA (Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * ___routine0, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<AdvancedCoroutines.Routine>::RemoveAt(System.Int32)
inline void List_1_RemoveAt_m961C171A3D0AC6CB35B08FE4D9C6775D8E7C119C (List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * __this, int32_t p0, const RuntimeMethod* method)
{
	((  void (*) (List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB *, int32_t, const RuntimeMethod*))List_1_RemoveAt_m3CAF82E0FF61CD84E251E0F7231BBB867C9755C2_gshared)(__this, p0, method);
}
// System.Void System.ArgumentNullException::.ctor(System.String)
extern "C" IL2CPP_METHOD_ATTR void ArgumentNullException__ctor_mEE0C0D6FCB2D08CD7967DBB1329A0854BBED49ED (ArgumentNullException_t581DF992B1F3E0EC6EFB30CC5DC43519A79B27AD * __this, String_t* p0, const RuntimeMethod* method);
// System.Void System.Collections.Generic.Dictionary`2<AdvancedCoroutines.Routine,System.String>::.ctor()
inline void Dictionary_2__ctor_m69ED04E59A57469134B4954B96BC07E608A4914C (Dictionary_2_tB10A5D0DDD081F3EFE74C0C35884F2216111ED48 * __this, const RuntimeMethod* method)
{
	((  void (*) (Dictionary_2_tB10A5D0DDD081F3EFE74C0C35884F2216111ED48 *, const RuntimeMethod*))Dictionary_2__ctor_m2C7E51568033239B506E15E7804A0B8658246498_gshared)(__this, method);
}
// System.Void AdvancedCoroutines.Statistics.AdvancedCoroutinesStatistics::set_TotalCoroutinesStarts(System.Int32)
extern "C" IL2CPP_METHOD_ATTR void AdvancedCoroutinesStatistics_set_TotalCoroutinesStarts_m929A36B197CEB724718474F5B3AC716F589B41E5 (int32_t ___value0, const RuntimeMethod* method);
// System.Void AdvancedCoroutines.Statistics.AdvancedCoroutinesStatistics::set_TotalCoroutinesStops(System.Int32)
extern "C" IL2CPP_METHOD_ATTR void AdvancedCoroutinesStatistics_set_TotalCoroutinesStops_m262ED54B841E1FE0FBC748EC4657CB5711B44D9B (int32_t ___value0, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.Dictionary`2<AdvancedCoroutines.Routine,System.String>::ContainsKey(!0)
inline bool Dictionary_2_ContainsKey_m7CCAFEF9A9B3B9C0674FC7B08A5F818ABFBA9340 (Dictionary_2_tB10A5D0DDD081F3EFE74C0C35884F2216111ED48 * __this, Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * p0, const RuntimeMethod* method)
{
	return ((  bool (*) (Dictionary_2_tB10A5D0DDD081F3EFE74C0C35884F2216111ED48 *, Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF *, const RuntimeMethod*))Dictionary_2_ContainsKey_m4EBC00E16E83DA33851A551757D2B7332D5756B9_gshared)(__this, p0, method);
}
// System.Boolean System.Collections.Generic.Dictionary`2<AdvancedCoroutines.Routine,System.String>::Remove(!0)
inline bool Dictionary_2_Remove_mDF1C8989572A0C846C14258CAFC82C1359F9C42F (Dictionary_2_tB10A5D0DDD081F3EFE74C0C35884F2216111ED48 * __this, Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * p0, const RuntimeMethod* method)
{
	return ((  bool (*) (Dictionary_2_tB10A5D0DDD081F3EFE74C0C35884F2216111ED48 *, Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF *, const RuntimeMethod*))Dictionary_2_Remove_m0FCCD33CE2C6A7589E52A2AB0872FE361BF5EF60_gshared)(__this, p0, method);
}
// System.Int32 AdvancedCoroutines.Statistics.AdvancedCoroutinesStatistics::get_TotalCoroutinesStops()
extern "C" IL2CPP_METHOD_ATTR int32_t AdvancedCoroutinesStatistics_get_TotalCoroutinesStops_mAC4EDF4D9170C333C1B4DACE8B3FD66A869E14D2 (const RuntimeMethod* method);
// System.Void AdvancedCoroutines.Wait::.ctor(System.Single)
extern "C" IL2CPP_METHOD_ATTR void Wait__ctor_m4016F6AE2294FEE779228CE5C9A00F4599E582CE (Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B * __this, float ___seconds0, const RuntimeMethod* method);
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
// System.Void AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll::.ctor(AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll_ExtentionMethod)
extern "C" IL2CPP_METHOD_ATTR void AdvancedCoroutinesCoreDll__ctor_m3FEE181FC3DB86769CCB14E888F8FD0CBE877D0F (AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B * __this, ExtentionMethod_t5D761100D20609B5439AA1BE14D9F9BC6F698151 * ___extentionMethod0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (AdvancedCoroutinesCoreDll__ctor_m3FEE181FC3DB86769CCB14E888F8FD0CBE877D0F_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Object__ctor_m925ECA5E85CA100E3FB86A4F9E15C120E9A184C0(__this, /*hidden argument*/NULL);
		ExtentionMethod_t5D761100D20609B5439AA1BE14D9F9BC6F698151 * L_0 = ___extentionMethod0;
		((AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B_StaticFields*)il2cpp_codegen_static_fields_for(AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B_il2cpp_TypeInfo_var))->set_ExtMethod_1(L_0);
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_1 = (List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB *)il2cpp_codegen_object_new(List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB_il2cpp_TypeInfo_var);
		List_1__ctor_m2EA5049DFA568BF766FDE80964DBEB69BE0D9D47(L_1, /*hidden argument*/List_1__ctor_m2EA5049DFA568BF766FDE80964DBEB69BE0D9D47_RuntimeMethod_var);
		__this->set__routines_0(L_1);
		return;
	}
}
// System.Void AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll::Update(System.Single)
extern "C" IL2CPP_METHOD_ATTR void AdvancedCoroutinesCoreDll_Update_mAD3AE55982EB569A348D7A0C31598F96739B9614 (AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B * __this, float ___deltaTime0, const RuntimeMethod* method)
{
	{
		float L_0 = ___deltaTime0;
		AdvancedCoroutinesCoreDll_UpdateRoutine_mD88AA1280D12E597E783AC0AC24F176195181DE5(__this, L_0, /*hidden argument*/NULL);
		return;
	}
}
// System.Void AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll::LateUpdate()
extern "C" IL2CPP_METHOD_ATTR void AdvancedCoroutinesCoreDll_LateUpdate_mC4F6C65EF5AD131BB42C2863B244CB95A490E245 (AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B * __this, const RuntimeMethod* method)
{
	{
		AdvancedCoroutinesCoreDll_LateUpdateRoutine_mA10F7016F4BBDE3E0A23C38163E70E077D162AFD(__this, /*hidden argument*/NULL);
		return;
	}
}
// AdvancedCoroutines.Routine AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll::StartCoroutine(System.Collections.IEnumerator,System.Object)
extern "C" IL2CPP_METHOD_ATTR Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * AdvancedCoroutinesCoreDll_StartCoroutine_m34EE058783EBD0776BBFC8E47738EAF4AE5A697A (AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B * __this, RuntimeObject* ___enumerator0, RuntimeObject * ___obj1, const RuntimeMethod* method)
{
	{
		RuntimeObject* L_0 = ___enumerator0;
		RuntimeObject * L_1 = ___obj1;
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_2 = AdvancedCoroutinesCoreDll_StartRoutine_mAB3D200F63F5CD39DA5CEBB42B815C1B46AFD8D4(__this, L_0, L_1, /*hidden argument*/NULL);
		return L_2;
	}
}
// System.Void AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll::StopCoroutine(AdvancedCoroutines.Routine)
extern "C" IL2CPP_METHOD_ATTR void AdvancedCoroutinesCoreDll_StopCoroutine_m73EBC9B34820B148DD1E7923F75214117A283808 (AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B * __this, Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * ___routine0, const RuntimeMethod* method)
{
	{
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_0 = ___routine0;
		bool L_1 = Routine_IsNull_mEA1F21C592E71B6C4E8D2D1FBF399B9EDADA7261(L_0, /*hidden argument*/NULL);
		if (!L_1)
		{
			goto IL_0009;
		}
	}
	{
		return;
	}

IL_0009:
	{
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_2 = ___routine0;
		Routine_Erase_mBA0FEAAB9CCBB58197EB98EFE49BB0267CEA6E74(L_2, /*hidden argument*/NULL);
		return;
	}
}
// System.Void AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll::StopAllCoroutines(System.Object)
extern "C" IL2CPP_METHOD_ATTR void AdvancedCoroutinesCoreDll_StopAllCoroutines_m067A6ADED4183D91ACA97CBDAC2FE9974FAF2961 (AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B * __this, RuntimeObject * ___o0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (AdvancedCoroutinesCoreDll_StopAllCoroutines_m067A6ADED4183D91ACA97CBDAC2FE9974FAF2961_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		V_0 = 0;
		goto IL_0045;
	}

IL_0004:
	{
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_0 = __this->get__routines_0();
		int32_t L_1 = V_0;
		NullCheck(L_0);
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_2 = List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02(L_0, L_1, /*hidden argument*/List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02_RuntimeMethod_var);
		NullCheck(L_2);
		RuntimeObject * L_3 = L_2->get_obj_1();
		if (!L_3)
		{
			goto IL_0041;
		}
	}
	{
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_4 = __this->get__routines_0();
		int32_t L_5 = V_0;
		NullCheck(L_4);
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_6 = List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02(L_4, L_5, /*hidden argument*/List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02_RuntimeMethod_var);
		NullCheck(L_6);
		RuntimeObject * L_7 = L_6->get_obj_1();
		RuntimeObject * L_8 = ___o0;
		NullCheck(L_7);
		bool L_9 = VirtFuncInvoker1< bool, RuntimeObject * >::Invoke(0 /* System.Boolean System.Object::Equals(System.Object) */, L_7, L_8);
		if (!L_9)
		{
			goto IL_0041;
		}
	}
	{
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_10 = __this->get__routines_0();
		int32_t L_11 = V_0;
		NullCheck(L_10);
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_12 = List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02(L_10, L_11, /*hidden argument*/List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02_RuntimeMethod_var);
		Routine_Erase_mBA0FEAAB9CCBB58197EB98EFE49BB0267CEA6E74(L_12, /*hidden argument*/NULL);
	}

IL_0041:
	{
		int32_t L_13 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add((int32_t)L_13, (int32_t)1));
	}

IL_0045:
	{
		int32_t L_14 = V_0;
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_15 = __this->get__routines_0();
		NullCheck(L_15);
		int32_t L_16 = List_1_get_Count_m817E36D02851E81A47915E1C711B511A82BFB9AD(L_15, /*hidden argument*/List_1_get_Count_m817E36D02851E81A47915E1C711B511A82BFB9AD_RuntimeMethod_var);
		if ((((int32_t)L_14) < ((int32_t)L_16)))
		{
			goto IL_0004;
		}
	}
	{
		return;
	}
}
// AdvancedCoroutines.Routine AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll::StartRoutine(System.Collections.IEnumerator,System.Object)
extern "C" IL2CPP_METHOD_ATTR Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * AdvancedCoroutinesCoreDll_StartRoutine_mAB3D200F63F5CD39DA5CEBB42B815C1B46AFD8D4 (AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B * __this, RuntimeObject* ___enumerator0, RuntimeObject * ___obj1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (AdvancedCoroutinesCoreDll_StartRoutine_mAB3D200F63F5CD39DA5CEBB42B815C1B46AFD8D4_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * V_0 = NULL;
	Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B  V_1;
	memset(&V_1, 0, sizeof(V_1));
	int32_t V_2 = 0;
	{
		RuntimeObject* L_0 = ___enumerator0;
		RuntimeObject * L_1 = ___obj1;
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_2 = (Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF *)il2cpp_codegen_object_new(Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF_il2cpp_TypeInfo_var);
		Routine__ctor_m297D1A7613863FF731F6FB5F00FDBB24EB00B913(L_2, L_0, L_1, /*hidden argument*/NULL);
		V_0 = L_2;
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_3 = V_0;
		NullCheck(L_3);
		RuntimeObject* L_4 = L_3->get_enumerator_0();
		NullCheck(L_4);
		bool L_5 = InterfaceFuncInvoker0< bool >::Invoke(0 /* System.Boolean System.Collections.IEnumerator::MoveNext() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_4);
		if (L_5)
		{
			goto IL_0017;
		}
	}
	{
		return (Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF *)NULL;
	}

IL_0017:
	{
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_6 = V_0;
		NullCheck(L_6);
		RuntimeObject* L_7 = L_6->get_enumerator_0();
		NullCheck(L_7);
		RuntimeObject * L_8 = InterfaceFuncInvoker0< RuntimeObject * >::Invoke(1 /* System.Object System.Collections.IEnumerator::get_Current() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_7);
		if (!L_8)
		{
			goto IL_00c7;
		}
	}
	{
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_9 = V_0;
		NullCheck(L_9);
		RuntimeObject* L_10 = L_9->get_enumerator_0();
		NullCheck(L_10);
		RuntimeObject * L_11 = InterfaceFuncInvoker0< RuntimeObject * >::Invoke(1 /* System.Object System.Collections.IEnumerator::get_Current() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_10);
		if (!((RuntimeObject *)IsInstSealed((RuntimeObject*)L_11, Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B_il2cpp_TypeInfo_var)))
		{
			goto IL_009c;
		}
	}
	{
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_12 = V_0;
		NullCheck(L_12);
		RuntimeObject* L_13 = L_12->get_enumerator_0();
		NullCheck(L_13);
		RuntimeObject * L_14 = InterfaceFuncInvoker0< RuntimeObject * >::Invoke(1 /* System.Object System.Collections.IEnumerator::get_Current() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_13);
		V_1 = ((*(Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B *)((Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B *)UnBox(L_14, Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B_il2cpp_TypeInfo_var))));
		Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B  L_15 = V_1;
		int32_t L_16 = L_15.get_waitTypeInternal_1();
		V_2 = L_16;
		int32_t L_17 = V_2;
		switch (L_17)
		{
			case 0:
			{
				goto IL_0065;
			}
			case 1:
			{
				goto IL_0065;
			}
			case 2:
			{
				goto IL_0073;
			}
		}
	}
	{
		goto IL_00c7;
	}

IL_0065:
	{
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_18 = __this->get__routines_0();
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_19 = V_0;
		NullCheck(L_18);
		List_1_Add_m8E0568559657D5416679C2B0256290CE360F5B70(L_18, L_19, /*hidden argument*/List_1_Add_m8E0568559657D5416679C2B0256290CE360F5B70_RuntimeMethod_var);
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_20 = V_0;
		return L_20;
	}

IL_0073:
	{
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_21 = V_0;
		NullCheck(L_21);
		float L_22 = L_21->get_startTime_3();
		Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B  L_23 = V_1;
		float L_24 = L_23.get_Seconds_0();
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_25 = V_0;
		NullCheck(L_25);
		float L_26 = L_25->get_workTime_2();
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_27 = __this->get__routines_0();
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_28 = V_0;
		NullCheck(L_27);
		List_1_Add_m8E0568559657D5416679C2B0256290CE360F5B70(L_27, L_28, /*hidden argument*/List_1_Add_m8E0568559657D5416679C2B0256290CE360F5B70_RuntimeMethod_var);
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_29 = V_0;
		return L_29;
	}

IL_009c:
	{
		ExtentionMethod_t5D761100D20609B5439AA1BE14D9F9BC6F698151 * L_30 = ((AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B_StaticFields*)il2cpp_codegen_static_fields_for(AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B_il2cpp_TypeInfo_var))->get_ExtMethod_1();
		if (!L_30)
		{
			goto IL_00c7;
		}
	}
	{
		ExtentionMethod_t5D761100D20609B5439AA1BE14D9F9BC6F698151 * L_31 = ((AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B_StaticFields*)il2cpp_codegen_static_fields_for(AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B_il2cpp_TypeInfo_var))->get_ExtMethod_1();
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_32 = V_0;
		NullCheck(L_32);
		RuntimeObject* L_33 = L_32->get_enumerator_0();
		NullCheck(L_33);
		RuntimeObject * L_34 = InterfaceFuncInvoker0< RuntimeObject * >::Invoke(1 /* System.Object System.Collections.IEnumerator::get_Current() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_33);
		NullCheck(L_31);
		ExtentionMethod_Invoke_m6AFEFC97436D17DA9CAC64113D172F1AA0161EAB(L_31, L_34, /*hidden argument*/NULL);
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_35 = __this->get__routines_0();
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_36 = V_0;
		NullCheck(L_35);
		List_1_Add_m8E0568559657D5416679C2B0256290CE360F5B70(L_35, L_36, /*hidden argument*/List_1_Add_m8E0568559657D5416679C2B0256290CE360F5B70_RuntimeMethod_var);
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_37 = V_0;
		return L_37;
	}

IL_00c7:
	{
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_38 = __this->get__routines_0();
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_39 = V_0;
		NullCheck(L_38);
		List_1_Add_m8E0568559657D5416679C2B0256290CE360F5B70(L_38, L_39, /*hidden argument*/List_1_Add_m8E0568559657D5416679C2B0256290CE360F5B70_RuntimeMethod_var);
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_40 = V_0;
		return L_40;
	}
}
// System.Void AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll::UpdateRoutine(System.Single)
extern "C" IL2CPP_METHOD_ATTR void AdvancedCoroutinesCoreDll_UpdateRoutine_mD88AA1280D12E597E783AC0AC24F176195181DE5 (AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B * __this, float ___deltaTime0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (AdvancedCoroutinesCoreDll_UpdateRoutine_mD88AA1280D12E597E783AC0AC24F176195181DE5_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * V_1 = NULL;
	Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B  V_2;
	memset(&V_2, 0, sizeof(V_2));
	float V_3 = 0.0f;
	{
		V_0 = 0;
		goto IL_0114;
	}

IL_0007:
	{
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_0 = __this->get__routines_0();
		int32_t L_1 = V_0;
		NullCheck(L_0);
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_2 = List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02(L_0, L_1, /*hidden argument*/List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02_RuntimeMethod_var);
		V_1 = L_2;
		int32_t L_3 = V_0;
		bool L_4 = AdvancedCoroutinesCoreDll_IsRoutineInNormalCondition_mE639780C54F0EC9D218AEECBACE975C93CA502B1(__this, L_3, /*hidden argument*/NULL);
		if (L_4)
		{
			goto IL_002a;
		}
	}
	{
		AdvancedCoroutinesCoreDll_DeleteRoutineFromStorage_mD49A26EF1BEF726B3A5AA2193754B5E6C3838A50(__this, (int32_t*)(&V_0), /*hidden argument*/NULL);
		goto IL_0110;
	}

IL_002a:
	{
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_5 = V_1;
		NullCheck(L_5);
		bool L_6 = L_5->get_isPaused_4();
		if (L_6)
		{
			goto IL_0110;
		}
	}
	{
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_7 = V_1;
		NullCheck(L_7);
		RuntimeObject* L_8 = L_7->get_enumerator_0();
		NullCheck(L_8);
		RuntimeObject * L_9 = InterfaceFuncInvoker0< RuntimeObject * >::Invoke(1 /* System.Object System.Collections.IEnumerator::get_Current() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_8);
		if (!L_9)
		{
			goto IL_00fb;
		}
	}
	{
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_10 = V_1;
		NullCheck(L_10);
		RuntimeObject* L_11 = L_10->get_enumerator_0();
		NullCheck(L_11);
		RuntimeObject * L_12 = InterfaceFuncInvoker0< RuntimeObject * >::Invoke(1 /* System.Object System.Collections.IEnumerator::get_Current() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_11);
		if (!((RuntimeObject *)IsInstSealed((RuntimeObject*)L_12, Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B_il2cpp_TypeInfo_var)))
		{
			goto IL_00dd;
		}
	}
	{
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_13 = V_1;
		NullCheck(L_13);
		RuntimeObject* L_14 = L_13->get_enumerator_0();
		NullCheck(L_14);
		RuntimeObject * L_15 = InterfaceFuncInvoker0< RuntimeObject * >::Invoke(1 /* System.Object System.Collections.IEnumerator::get_Current() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_14);
		V_2 = ((*(Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B *)((Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B *)UnBox(L_15, Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B_il2cpp_TypeInfo_var))));
		Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B  L_16 = V_2;
		int32_t L_17 = L_16.get_waitTypeInternal_1();
		if (L_17)
		{
			goto IL_007f;
		}
	}
	{
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_18 = V_1;
		NullCheck(L_18);
		L_18->set_needToCheckEndOfUpdate_6((bool)1);
		goto IL_0110;
	}

IL_007f:
	{
		Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B  L_19 = V_2;
		int32_t L_20 = L_19.get_waitTypeInternal_1();
		if ((!(((uint32_t)L_20) == ((uint32_t)1))))
		{
			goto IL_0091;
		}
	}
	{
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_21 = V_1;
		NullCheck(L_21);
		L_21->set_needToCheckPostRender_7((bool)1);
		goto IL_0110;
	}

IL_0091:
	{
		Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B  L_22 = V_2;
		int32_t L_23 = L_22.get_waitTypeInternal_1();
		if ((!(((uint32_t)L_23) == ((uint32_t)2))))
		{
			goto IL_00fb;
		}
	}
	{
		Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B  L_24 = V_2;
		float L_25 = L_24.get_Seconds_0();
		V_3 = L_25;
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_26 = V_1;
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_27 = L_26;
		NullCheck(L_27);
		float L_28 = L_27->get_workTime_2();
		float L_29 = ___deltaTime0;
		NullCheck(L_27);
		L_27->set_workTime_2(((float)il2cpp_codegen_add((float)L_28, (float)L_29)));
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_30 = V_1;
		NullCheck(L_30);
		float L_31 = L_30->get_startTime_3();
		float L_32 = V_3;
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_33 = V_1;
		NullCheck(L_33);
		float L_34 = L_33->get_workTime_2();
		if ((((float)((float)il2cpp_codegen_subtract((float)((float)il2cpp_codegen_add((float)L_31, (float)L_32)), (float)L_34))) > ((float)(0.0f))))
		{
			goto IL_0110;
		}
	}
	{
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_35 = V_1;
		NullCheck(L_35);
		L_35->set_startTime_3((0.0f));
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_36 = V_1;
		NullCheck(L_36);
		L_36->set_workTime_2((0.0f));
		goto IL_00fb;
	}

IL_00dd:
	{
		ExtentionMethod_t5D761100D20609B5439AA1BE14D9F9BC6F698151 * L_37 = ((AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B_StaticFields*)il2cpp_codegen_static_fields_for(AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B_il2cpp_TypeInfo_var))->get_ExtMethod_1();
		if (!L_37)
		{
			goto IL_00fb;
		}
	}
	{
		ExtentionMethod_t5D761100D20609B5439AA1BE14D9F9BC6F698151 * L_38 = ((AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B_StaticFields*)il2cpp_codegen_static_fields_for(AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B_il2cpp_TypeInfo_var))->get_ExtMethod_1();
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_39 = V_1;
		NullCheck(L_39);
		RuntimeObject* L_40 = L_39->get_enumerator_0();
		NullCheck(L_40);
		RuntimeObject * L_41 = InterfaceFuncInvoker0< RuntimeObject * >::Invoke(1 /* System.Object System.Collections.IEnumerator::get_Current() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_40);
		NullCheck(L_38);
		bool L_42 = ExtentionMethod_Invoke_m6AFEFC97436D17DA9CAC64113D172F1AA0161EAB(L_38, L_41, /*hidden argument*/NULL);
		if (L_42)
		{
			goto IL_0110;
		}
	}

IL_00fb:
	{
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_43 = V_1;
		NullCheck(L_43);
		RuntimeObject* L_44 = L_43->get_enumerator_0();
		NullCheck(L_44);
		bool L_45 = InterfaceFuncInvoker0< bool >::Invoke(0 /* System.Boolean System.Collections.IEnumerator::MoveNext() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_44);
		if (L_45)
		{
			goto IL_0110;
		}
	}
	{
		AdvancedCoroutinesCoreDll_DeleteRoutineFromStorage_mD49A26EF1BEF726B3A5AA2193754B5E6C3838A50(__this, (int32_t*)(&V_0), /*hidden argument*/NULL);
	}

IL_0110:
	{
		int32_t L_46 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add((int32_t)L_46, (int32_t)1));
	}

IL_0114:
	{
		int32_t L_47 = V_0;
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_48 = __this->get__routines_0();
		NullCheck(L_48);
		int32_t L_49 = List_1_get_Count_m817E36D02851E81A47915E1C711B511A82BFB9AD(L_48, /*hidden argument*/List_1_get_Count_m817E36D02851E81A47915E1C711B511A82BFB9AD_RuntimeMethod_var);
		if ((((int32_t)L_47) < ((int32_t)L_49)))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll::LateUpdateRoutine()
extern "C" IL2CPP_METHOD_ATTR void AdvancedCoroutinesCoreDll_LateUpdateRoutine_mA10F7016F4BBDE3E0A23C38163E70E077D162AFD (AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (AdvancedCoroutinesCoreDll_LateUpdateRoutine_mA10F7016F4BBDE3E0A23C38163E70E077D162AFD_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		V_0 = 0;
		goto IL_00c1;
	}

IL_0007:
	{
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_0 = __this->get__routines_0();
		int32_t L_1 = V_0;
		NullCheck(L_0);
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_2 = List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02(L_0, L_1, /*hidden argument*/List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02_RuntimeMethod_var);
		NullCheck(L_2);
		bool L_3 = L_2->get_needToCheckEndOfUpdate_6();
		if (!L_3)
		{
			goto IL_00bd;
		}
	}
	{
		int32_t L_4 = V_0;
		bool L_5 = AdvancedCoroutinesCoreDll_IsRoutineInNormalCondition_mE639780C54F0EC9D218AEECBACE975C93CA502B1(__this, L_4, /*hidden argument*/NULL);
		if (L_5)
		{
			goto IL_0033;
		}
	}
	{
		AdvancedCoroutinesCoreDll_DeleteRoutineFromStorage_mD49A26EF1BEF726B3A5AA2193754B5E6C3838A50(__this, (int32_t*)(&V_0), /*hidden argument*/NULL);
		goto IL_00bd;
	}

IL_0033:
	{
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_6 = __this->get__routines_0();
		int32_t L_7 = V_0;
		NullCheck(L_6);
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_8 = List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02(L_6, L_7, /*hidden argument*/List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02_RuntimeMethod_var);
		NullCheck(L_8);
		bool L_9 = L_8->get_isPaused_4();
		if (L_9)
		{
			goto IL_00bd;
		}
	}
	{
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_10 = __this->get__routines_0();
		int32_t L_11 = V_0;
		NullCheck(L_10);
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_12 = List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02(L_10, L_11, /*hidden argument*/List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02_RuntimeMethod_var);
		NullCheck(L_12);
		RuntimeObject* L_13 = L_12->get_enumerator_0();
		NullCheck(L_13);
		RuntimeObject * L_14 = InterfaceFuncInvoker0< RuntimeObject * >::Invoke(1 /* System.Object System.Collections.IEnumerator::get_Current() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_13);
		if (!L_14)
		{
			goto IL_00bd;
		}
	}
	{
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_15 = __this->get__routines_0();
		int32_t L_16 = V_0;
		NullCheck(L_15);
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_17 = List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02(L_15, L_16, /*hidden argument*/List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02_RuntimeMethod_var);
		NullCheck(L_17);
		RuntimeObject* L_18 = L_17->get_enumerator_0();
		NullCheck(L_18);
		RuntimeObject * L_19 = InterfaceFuncInvoker0< RuntimeObject * >::Invoke(1 /* System.Object System.Collections.IEnumerator::get_Current() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_18);
		if (!((RuntimeObject *)IsInstSealed((RuntimeObject*)L_19, Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B_il2cpp_TypeInfo_var)))
		{
			goto IL_00bd;
		}
	}
	{
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_20 = __this->get__routines_0();
		int32_t L_21 = V_0;
		NullCheck(L_20);
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_22 = List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02(L_20, L_21, /*hidden argument*/List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02_RuntimeMethod_var);
		NullCheck(L_22);
		RuntimeObject* L_23 = L_22->get_enumerator_0();
		NullCheck(L_23);
		RuntimeObject * L_24 = InterfaceFuncInvoker0< RuntimeObject * >::Invoke(1 /* System.Object System.Collections.IEnumerator::get_Current() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_23);
		int32_t L_25 = ((*(Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B *)((Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B *)UnBox(L_24, Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B_il2cpp_TypeInfo_var)))).get_waitTypeInternal_1();
		if (L_25)
		{
			goto IL_00bd;
		}
	}
	{
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_26 = __this->get__routines_0();
		int32_t L_27 = V_0;
		NullCheck(L_26);
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_28 = List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02(L_26, L_27, /*hidden argument*/List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02_RuntimeMethod_var);
		NullCheck(L_28);
		RuntimeObject* L_29 = L_28->get_enumerator_0();
		NullCheck(L_29);
		bool L_30 = InterfaceFuncInvoker0< bool >::Invoke(0 /* System.Boolean System.Collections.IEnumerator::MoveNext() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_29);
		if (L_30)
		{
			goto IL_00bd;
		}
	}
	{
		AdvancedCoroutinesCoreDll_DeleteRoutineFromStorage_mD49A26EF1BEF726B3A5AA2193754B5E6C3838A50(__this, (int32_t*)(&V_0), /*hidden argument*/NULL);
	}

IL_00bd:
	{
		int32_t L_31 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add((int32_t)L_31, (int32_t)1));
	}

IL_00c1:
	{
		int32_t L_32 = V_0;
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_33 = __this->get__routines_0();
		NullCheck(L_33);
		int32_t L_34 = List_1_get_Count_m817E36D02851E81A47915E1C711B511A82BFB9AD(L_33, /*hidden argument*/List_1_get_Count_m817E36D02851E81A47915E1C711B511A82BFB9AD_RuntimeMethod_var);
		if ((((int32_t)L_32) < ((int32_t)L_34)))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll::OnPostRender()
extern "C" IL2CPP_METHOD_ATTR void AdvancedCoroutinesCoreDll_OnPostRender_mB1870104982402AF3BB60A77D0CA8A220C4B701F (AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (AdvancedCoroutinesCoreDll_OnPostRender_mB1870104982402AF3BB60A77D0CA8A220C4B701F_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		V_0 = 0;
		goto IL_00c2;
	}

IL_0007:
	{
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_0 = __this->get__routines_0();
		int32_t L_1 = V_0;
		NullCheck(L_0);
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_2 = List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02(L_0, L_1, /*hidden argument*/List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02_RuntimeMethod_var);
		NullCheck(L_2);
		bool L_3 = L_2->get_needToCheckPostRender_7();
		if (!L_3)
		{
			goto IL_00be;
		}
	}
	{
		int32_t L_4 = V_0;
		bool L_5 = AdvancedCoroutinesCoreDll_IsRoutineInNormalCondition_mE639780C54F0EC9D218AEECBACE975C93CA502B1(__this, L_4, /*hidden argument*/NULL);
		if (L_5)
		{
			goto IL_0033;
		}
	}
	{
		AdvancedCoroutinesCoreDll_DeleteRoutineFromStorage_mD49A26EF1BEF726B3A5AA2193754B5E6C3838A50(__this, (int32_t*)(&V_0), /*hidden argument*/NULL);
		goto IL_00be;
	}

IL_0033:
	{
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_6 = __this->get__routines_0();
		int32_t L_7 = V_0;
		NullCheck(L_6);
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_8 = List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02(L_6, L_7, /*hidden argument*/List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02_RuntimeMethod_var);
		NullCheck(L_8);
		bool L_9 = L_8->get_isPaused_4();
		if (L_9)
		{
			goto IL_00be;
		}
	}
	{
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_10 = __this->get__routines_0();
		int32_t L_11 = V_0;
		NullCheck(L_10);
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_12 = List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02(L_10, L_11, /*hidden argument*/List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02_RuntimeMethod_var);
		NullCheck(L_12);
		RuntimeObject* L_13 = L_12->get_enumerator_0();
		NullCheck(L_13);
		RuntimeObject * L_14 = InterfaceFuncInvoker0< RuntimeObject * >::Invoke(1 /* System.Object System.Collections.IEnumerator::get_Current() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_13);
		if (!L_14)
		{
			goto IL_00be;
		}
	}
	{
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_15 = __this->get__routines_0();
		int32_t L_16 = V_0;
		NullCheck(L_15);
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_17 = List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02(L_15, L_16, /*hidden argument*/List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02_RuntimeMethod_var);
		NullCheck(L_17);
		RuntimeObject* L_18 = L_17->get_enumerator_0();
		NullCheck(L_18);
		RuntimeObject * L_19 = InterfaceFuncInvoker0< RuntimeObject * >::Invoke(1 /* System.Object System.Collections.IEnumerator::get_Current() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_18);
		if (!((RuntimeObject *)IsInstSealed((RuntimeObject*)L_19, Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B_il2cpp_TypeInfo_var)))
		{
			goto IL_00be;
		}
	}
	{
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_20 = __this->get__routines_0();
		int32_t L_21 = V_0;
		NullCheck(L_20);
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_22 = List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02(L_20, L_21, /*hidden argument*/List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02_RuntimeMethod_var);
		NullCheck(L_22);
		RuntimeObject* L_23 = L_22->get_enumerator_0();
		NullCheck(L_23);
		RuntimeObject * L_24 = InterfaceFuncInvoker0< RuntimeObject * >::Invoke(1 /* System.Object System.Collections.IEnumerator::get_Current() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_23);
		int32_t L_25 = ((*(Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B *)((Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B *)UnBox(L_24, Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B_il2cpp_TypeInfo_var)))).get_waitTypeInternal_1();
		if ((!(((uint32_t)L_25) == ((uint32_t)1))))
		{
			goto IL_00be;
		}
	}
	{
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_26 = __this->get__routines_0();
		int32_t L_27 = V_0;
		NullCheck(L_26);
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_28 = List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02(L_26, L_27, /*hidden argument*/List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02_RuntimeMethod_var);
		NullCheck(L_28);
		RuntimeObject* L_29 = L_28->get_enumerator_0();
		NullCheck(L_29);
		bool L_30 = InterfaceFuncInvoker0< bool >::Invoke(0 /* System.Boolean System.Collections.IEnumerator::MoveNext() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_29);
		if (L_30)
		{
			goto IL_00be;
		}
	}
	{
		AdvancedCoroutinesCoreDll_DeleteRoutineFromStorage_mD49A26EF1BEF726B3A5AA2193754B5E6C3838A50(__this, (int32_t*)(&V_0), /*hidden argument*/NULL);
	}

IL_00be:
	{
		int32_t L_31 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add((int32_t)L_31, (int32_t)1));
	}

IL_00c2:
	{
		int32_t L_32 = V_0;
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_33 = __this->get__routines_0();
		NullCheck(L_33);
		int32_t L_34 = List_1_get_Count_m817E36D02851E81A47915E1C711B511A82BFB9AD(L_33, /*hidden argument*/List_1_get_Count_m817E36D02851E81A47915E1C711B511A82BFB9AD_RuntimeMethod_var);
		if ((((int32_t)L_32) < ((int32_t)L_34)))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Boolean AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll::IsRoutineInNormalCondition(System.Int32)
extern "C" IL2CPP_METHOD_ATTR bool AdvancedCoroutinesCoreDll_IsRoutineInNormalCondition_mE639780C54F0EC9D218AEECBACE975C93CA502B1 (AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B * __this, int32_t ___index0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (AdvancedCoroutinesCoreDll_IsRoutineInNormalCondition_mE639780C54F0EC9D218AEECBACE975C93CA502B1_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_0 = __this->get__routines_0();
		int32_t L_1 = ___index0;
		NullCheck(L_0);
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_2 = List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02(L_0, L_1, /*hidden argument*/List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02_RuntimeMethod_var);
		NullCheck(L_2);
		RuntimeObject* L_3 = L_2->get_enumerator_0();
		if (((((RuntimeObject*)(RuntimeObject*)L_3) == ((RuntimeObject*)(RuntimeObject *)NULL))? 1 : 0))
		{
			goto IL_0055;
		}
	}
	{
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_4 = __this->get__routines_0();
		int32_t L_5 = ___index0;
		NullCheck(L_4);
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_6 = List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02(L_4, L_5, /*hidden argument*/List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02_RuntimeMethod_var);
		NullCheck(L_6);
		bool L_7 = L_6->get_isStandalone_5();
		if (L_7)
		{
			goto IL_0057;
		}
	}
	{
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_8 = __this->get__routines_0();
		int32_t L_9 = ___index0;
		NullCheck(L_8);
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_10 = List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02(L_8, L_9, /*hidden argument*/List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02_RuntimeMethod_var);
		NullCheck(L_10);
		RuntimeObject * L_11 = L_10->get_obj_1();
		if (!L_11)
		{
			goto IL_0055;
		}
	}
	{
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_12 = __this->get__routines_0();
		int32_t L_13 = ___index0;
		NullCheck(L_12);
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_14 = List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02(L_12, L_13, /*hidden argument*/List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02_RuntimeMethod_var);
		NullCheck(L_14);
		RuntimeObject * L_15 = L_14->get_obj_1();
		NullCheck(L_15);
		bool L_16 = VirtFuncInvoker1< bool, RuntimeObject * >::Invoke(0 /* System.Boolean System.Object::Equals(System.Object) */, L_15, NULL);
		if (!L_16)
		{
			goto IL_0057;
		}
	}

IL_0055:
	{
		return (bool)0;
	}

IL_0057:
	{
		return (bool)1;
	}
}
// System.Void AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll::DeleteRoutineFromStorage(System.Int32U26)
extern "C" IL2CPP_METHOD_ATTR void AdvancedCoroutinesCoreDll_DeleteRoutineFromStorage_mD49A26EF1BEF726B3A5AA2193754B5E6C3838A50 (AdvancedCoroutinesCoreDll_t69613D35FBCC1700A1B31AE170AC7DEC5745439B * __this, int32_t* ___iRoutine0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (AdvancedCoroutinesCoreDll_DeleteRoutineFromStorage_mD49A26EF1BEF726B3A5AA2193754B5E6C3838A50_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(AdvancedCoroutinesStatistics_tD1A40FB5B47CB66A9325B023E08B94D3F04A126C_il2cpp_TypeInfo_var);
		bool L_0 = ((AdvancedCoroutinesStatistics_tD1A40FB5B47CB66A9325B023E08B94D3F04A126C_StaticFields*)il2cpp_codegen_static_fields_for(AdvancedCoroutinesStatistics_tD1A40FB5B47CB66A9325B023E08B94D3F04A126C_il2cpp_TypeInfo_var))->get_IsActive_0();
		if (!L_0)
		{
			goto IL_0019;
		}
	}
	{
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_1 = __this->get__routines_0();
		int32_t* L_2 = ___iRoutine0;
		int32_t L_3 = *((int32_t*)L_2);
		NullCheck(L_1);
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_4 = List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02(L_1, L_3, /*hidden argument*/List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02_RuntimeMethod_var);
		IL2CPP_RUNTIME_CLASS_INIT(AdvancedCoroutinesStatistics_tD1A40FB5B47CB66A9325B023E08B94D3F04A126C_il2cpp_TypeInfo_var);
		AdvancedCoroutinesStatistics_Remove_mAF48156A8072F97509ED56A4C57965FACD4585BA(L_4, /*hidden argument*/NULL);
	}

IL_0019:
	{
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_5 = __this->get__routines_0();
		int32_t* L_6 = ___iRoutine0;
		int32_t L_7 = *((int32_t*)L_6);
		NullCheck(L_5);
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_8 = List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02(L_5, L_7, /*hidden argument*/List_1_get_Item_mE1822F4A03F4B1169B15B2777F47359EAFCE7F02_RuntimeMethod_var);
		Routine_Erase_mBA0FEAAB9CCBB58197EB98EFE49BB0267CEA6E74(L_8, /*hidden argument*/NULL);
		List_1_t6CD1050B50D96D7CD11E766D25E925E64BB9D3AB * L_9 = __this->get__routines_0();
		int32_t* L_10 = ___iRoutine0;
		int32_t L_11 = *((int32_t*)L_10);
		NullCheck(L_9);
		List_1_RemoveAt_m961C171A3D0AC6CB35B08FE4D9C6775D8E7C119C(L_9, L_11, /*hidden argument*/List_1_RemoveAt_m961C171A3D0AC6CB35B08FE4D9C6775D8E7C119C_RuntimeMethod_var);
		int32_t* L_12 = ___iRoutine0;
		int32_t* L_13 = ___iRoutine0;
		int32_t L_14 = *((int32_t*)L_13);
		*((int32_t*)L_12) = (int32_t)((int32_t)il2cpp_codegen_subtract((int32_t)L_14, (int32_t)1));
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
// System.Void AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll_ExtentionMethod::.ctor(System.Object,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR void ExtentionMethod__ctor_m135C380488545641F2CE4D20828C3CDCE252A2C9 (ExtentionMethod_t5D761100D20609B5439AA1BE14D9F9BC6F698151 * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method)
{
	__this->set_method_ptr_0(il2cpp_codegen_get_method_pointer((RuntimeMethod*)___method1));
	__this->set_method_3(___method1);
	__this->set_m_target_2(___object0);
}
// System.Boolean AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll_ExtentionMethod::Invoke(System.Object)
extern "C" IL2CPP_METHOD_ATTR bool ExtentionMethod_Invoke_m6AFEFC97436D17DA9CAC64113D172F1AA0161EAB (ExtentionMethod_t5D761100D20609B5439AA1BE14D9F9BC6F698151 * __this, RuntimeObject * ___o0, const RuntimeMethod* method)
{
	bool result = false;
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
				if (___parameterCount == 1)
				{
					// open
					typedef bool (*FunctionPointerType) (RuntimeObject *, const RuntimeMethod*);
					result = ((FunctionPointerType)targetMethodPointer)(___o0, targetMethod);
				}
				else
				{
					// closed
					typedef bool (*FunctionPointerType) (void*, RuntimeObject *, const RuntimeMethod*);
					result = ((FunctionPointerType)targetMethodPointer)(targetThis, ___o0, targetMethod);
				}
			}
			else if (___parameterCount != 1)
			{
				// open
				if (il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
				{
					if (il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
					{
						if (il2cpp_codegen_method_is_generic_instance(targetMethod))
						{
							if (il2cpp_codegen_method_is_interface_method(targetMethod))
								result = GenericInterfaceFuncInvoker0< bool >::Invoke(targetMethod, ___o0);
							else
								result = GenericVirtFuncInvoker0< bool >::Invoke(targetMethod, ___o0);
						}
						else
						{
							if (il2cpp_codegen_method_is_interface_method(targetMethod))
								result = InterfaceFuncInvoker0< bool >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), ___o0);
							else
								result = VirtFuncInvoker0< bool >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), ___o0);
						}
					}
				}
				else
				{
					typedef bool (*FunctionPointerType) (RuntimeObject *, const RuntimeMethod*);
					result = ((FunctionPointerType)targetMethodPointer)(___o0, targetMethod);
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
							typedef bool (*FunctionPointerType) (RuntimeObject *, const RuntimeMethod*);
							result = ((FunctionPointerType)targetMethodPointer)(___o0, targetMethod);
						}
						else if (il2cpp_codegen_method_is_generic_instance(targetMethod))
						{
							if (il2cpp_codegen_method_is_interface_method(targetMethod))
								result = GenericInterfaceFuncInvoker1< bool, RuntimeObject * >::Invoke(targetMethod, targetThis, ___o0);
							else
								result = GenericVirtFuncInvoker1< bool, RuntimeObject * >::Invoke(targetMethod, targetThis, ___o0);
						}
						else
						{
							if (il2cpp_codegen_method_is_interface_method(targetMethod))
								result = InterfaceFuncInvoker1< bool, RuntimeObject * >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), targetThis, ___o0);
							else
								result = VirtFuncInvoker1< bool, RuntimeObject * >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), targetThis, ___o0);
						}
					}
				}
				else
				{
					typedef bool (*FunctionPointerType) (void*, RuntimeObject *, const RuntimeMethod*);
					result = ((FunctionPointerType)targetMethodPointer)(targetThis, ___o0, targetMethod);
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
			if (___parameterCount == 1)
			{
				// open
				typedef bool (*FunctionPointerType) (RuntimeObject *, const RuntimeMethod*);
				result = ((FunctionPointerType)targetMethodPointer)(___o0, targetMethod);
			}
			else
			{
				// closed
				typedef bool (*FunctionPointerType) (void*, RuntimeObject *, const RuntimeMethod*);
				result = ((FunctionPointerType)targetMethodPointer)(targetThis, ___o0, targetMethod);
			}
		}
		else if (___parameterCount != 1)
		{
			// open
			if (il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
			{
				if (il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
				{
					if (il2cpp_codegen_method_is_generic_instance(targetMethod))
					{
						if (il2cpp_codegen_method_is_interface_method(targetMethod))
							result = GenericInterfaceFuncInvoker0< bool >::Invoke(targetMethod, ___o0);
						else
							result = GenericVirtFuncInvoker0< bool >::Invoke(targetMethod, ___o0);
					}
					else
					{
						if (il2cpp_codegen_method_is_interface_method(targetMethod))
							result = InterfaceFuncInvoker0< bool >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), ___o0);
						else
							result = VirtFuncInvoker0< bool >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), ___o0);
					}
				}
			}
			else
			{
				typedef bool (*FunctionPointerType) (RuntimeObject *, const RuntimeMethod*);
				result = ((FunctionPointerType)targetMethodPointer)(___o0, targetMethod);
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
						typedef bool (*FunctionPointerType) (RuntimeObject *, const RuntimeMethod*);
						result = ((FunctionPointerType)targetMethodPointer)(___o0, targetMethod);
					}
					else if (il2cpp_codegen_method_is_generic_instance(targetMethod))
					{
						if (il2cpp_codegen_method_is_interface_method(targetMethod))
							result = GenericInterfaceFuncInvoker1< bool, RuntimeObject * >::Invoke(targetMethod, targetThis, ___o0);
						else
							result = GenericVirtFuncInvoker1< bool, RuntimeObject * >::Invoke(targetMethod, targetThis, ___o0);
					}
					else
					{
						if (il2cpp_codegen_method_is_interface_method(targetMethod))
							result = InterfaceFuncInvoker1< bool, RuntimeObject * >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), targetThis, ___o0);
						else
							result = VirtFuncInvoker1< bool, RuntimeObject * >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), targetThis, ___o0);
					}
				}
			}
			else
			{
				typedef bool (*FunctionPointerType) (void*, RuntimeObject *, const RuntimeMethod*);
				result = ((FunctionPointerType)targetMethodPointer)(targetThis, ___o0, targetMethod);
			}
		}
	}
	return result;
}
// System.IAsyncResult AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll_ExtentionMethod::BeginInvoke(System.Object,System.AsyncCallback,System.Object)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject* ExtentionMethod_BeginInvoke_m413F96D83D20EAA2552018306F43F79BF18AF880 (ExtentionMethod_t5D761100D20609B5439AA1BE14D9F9BC6F698151 * __this, RuntimeObject * ___o0, AsyncCallback_t3F3DA3BEDAEE81DD1D24125DF8EB30E85EE14DA4 * ___callback1, RuntimeObject * ___object2, const RuntimeMethod* method)
{
	void *__d_args[2] = {0};
	__d_args[0] = ___o0;
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback1, (RuntimeObject*)___object2);
}
// System.Boolean AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll_ExtentionMethod::EndInvoke(System.IAsyncResult)
extern "C" IL2CPP_METHOD_ATTR bool ExtentionMethod_EndInvoke_mF579DA211D7E1E3B090AFFF59C528411119BA83F (ExtentionMethod_t5D761100D20609B5439AA1BE14D9F9BC6F698151 * __this, RuntimeObject* ___result0, const RuntimeMethod* method)
{
	RuntimeObject *__result = il2cpp_codegen_delegate_end_invoke((Il2CppAsyncResult*) ___result0, 0);
	return *(bool*)UnBox ((RuntimeObject*)__result);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void AdvancedCoroutines.Routine::.ctor(System.Collections.IEnumerator,System.Object)
extern "C" IL2CPP_METHOD_ATTR void Routine__ctor_m297D1A7613863FF731F6FB5F00FDBB24EB00B913 (Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * __this, RuntimeObject* ___enumerator0, RuntimeObject * ___obj1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Routine__ctor_m297D1A7613863FF731F6FB5F00FDBB24EB00B913_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Object__ctor_m925ECA5E85CA100E3FB86A4F9E15C120E9A184C0(__this, /*hidden argument*/NULL);
		RuntimeObject* L_0 = ___enumerator0;
		if (L_0)
		{
			goto IL_0014;
		}
	}
	{
		ArgumentNullException_t581DF992B1F3E0EC6EFB30CC5DC43519A79B27AD * L_1 = (ArgumentNullException_t581DF992B1F3E0EC6EFB30CC5DC43519A79B27AD *)il2cpp_codegen_object_new(ArgumentNullException_t581DF992B1F3E0EC6EFB30CC5DC43519A79B27AD_il2cpp_TypeInfo_var);
		ArgumentNullException__ctor_mEE0C0D6FCB2D08CD7967DBB1329A0854BBED49ED(L_1, _stringLiteral85865F57B794ED3AFFD4B73795491F68D725865A, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1, NULL, Routine__ctor_m297D1A7613863FF731F6FB5F00FDBB24EB00B913_RuntimeMethod_var);
	}

IL_0014:
	{
		RuntimeObject * L_2 = ___obj1;
		__this->set_isStandalone_5((bool)((((RuntimeObject*)(RuntimeObject *)L_2) == ((RuntimeObject*)(RuntimeObject *)NULL))? 1 : 0));
		RuntimeObject* L_3 = ___enumerator0;
		__this->set_enumerator_0(L_3);
		RuntimeObject * L_4 = ___obj1;
		__this->set_obj_1(L_4);
		__this->set_startTime_3((0.0f));
		__this->set_isPaused_4((bool)0);
		float L_5 = __this->get_startTime_3();
		__this->set_workTime_2(L_5);
		return;
	}
}
// System.Void AdvancedCoroutines.Routine::Pause()
extern "C" IL2CPP_METHOD_ATTR void Routine_Pause_m888F07EB911B83680C41C29460F4085CCB75FA6F (Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * __this, const RuntimeMethod* method)
{
	{
		__this->set_isPaused_4((bool)1);
		return;
	}
}
// System.Void AdvancedCoroutines.Routine::Resume()
extern "C" IL2CPP_METHOD_ATTR void Routine_Resume_m67F74437CD69B24F967AC98E432FFB82AC51098E (Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * __this, const RuntimeMethod* method)
{
	{
		__this->set_isPaused_4((bool)0);
		return;
	}
}
// System.Boolean AdvancedCoroutines.Routine::IsPaused()
extern "C" IL2CPP_METHOD_ATTR bool Routine_IsPaused_m6546C8FB521C714335150C22D4448E85F8F6F95F (Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * __this, const RuntimeMethod* method)
{
	{
		bool L_0 = __this->get_isPaused_4();
		return L_0;
	}
}
// System.Boolean AdvancedCoroutines.Routine::IsNull(AdvancedCoroutines.Routine)
extern "C" IL2CPP_METHOD_ATTR bool Routine_IsNull_mEA1F21C592E71B6C4E8D2D1FBF399B9EDADA7261 (Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * ___routine0, const RuntimeMethod* method)
{
	{
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_0 = ___routine0;
		if (!L_0)
		{
			goto IL_000d;
		}
	}
	{
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_1 = ___routine0;
		NullCheck(L_1);
		RuntimeObject* L_2 = L_1->get_enumerator_0();
		return (bool)((((RuntimeObject*)(RuntimeObject*)L_2) == ((RuntimeObject*)(RuntimeObject *)NULL))? 1 : 0);
	}

IL_000d:
	{
		return (bool)1;
	}
}
// System.Void AdvancedCoroutines.Routine::Erase(AdvancedCoroutines.Routine)
extern "C" IL2CPP_METHOD_ATTR void Routine_Erase_mBA0FEAAB9CCBB58197EB98EFE49BB0267CEA6E74 (Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * ___routine0, const RuntimeMethod* method)
{
	{
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_0 = ___routine0;
		NullCheck(L_0);
		L_0->set_enumerator_0((RuntimeObject*)NULL);
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_1 = ___routine0;
		NullCheck(L_1);
		L_1->set_obj_1(NULL);
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
// System.Void AdvancedCoroutines.Statistics.AdvancedCoroutinesStatistics::set_TotalCoroutinesStarts(System.Int32)
extern "C" IL2CPP_METHOD_ATTR void AdvancedCoroutinesStatistics_set_TotalCoroutinesStarts_m929A36B197CEB724718474F5B3AC716F589B41E5 (int32_t ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (AdvancedCoroutinesStatistics_set_TotalCoroutinesStarts_m929A36B197CEB724718474F5B3AC716F589B41E5_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		int32_t L_0 = ___value0;
		IL2CPP_RUNTIME_CLASS_INIT(AdvancedCoroutinesStatistics_tD1A40FB5B47CB66A9325B023E08B94D3F04A126C_il2cpp_TypeInfo_var);
		((AdvancedCoroutinesStatistics_tD1A40FB5B47CB66A9325B023E08B94D3F04A126C_StaticFields*)il2cpp_codegen_static_fields_for(AdvancedCoroutinesStatistics_tD1A40FB5B47CB66A9325B023E08B94D3F04A126C_il2cpp_TypeInfo_var))->set_U3CTotalCoroutinesStartsU3Ek__BackingField_2(L_0);
		return;
	}
}
// System.Int32 AdvancedCoroutines.Statistics.AdvancedCoroutinesStatistics::get_TotalCoroutinesStops()
extern "C" IL2CPP_METHOD_ATTR int32_t AdvancedCoroutinesStatistics_get_TotalCoroutinesStops_mAC4EDF4D9170C333C1B4DACE8B3FD66A869E14D2 (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (AdvancedCoroutinesStatistics_get_TotalCoroutinesStops_mAC4EDF4D9170C333C1B4DACE8B3FD66A869E14D2_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(AdvancedCoroutinesStatistics_tD1A40FB5B47CB66A9325B023E08B94D3F04A126C_il2cpp_TypeInfo_var);
		int32_t L_0 = ((AdvancedCoroutinesStatistics_tD1A40FB5B47CB66A9325B023E08B94D3F04A126C_StaticFields*)il2cpp_codegen_static_fields_for(AdvancedCoroutinesStatistics_tD1A40FB5B47CB66A9325B023E08B94D3F04A126C_il2cpp_TypeInfo_var))->get_U3CTotalCoroutinesStopsU3Ek__BackingField_3();
		return L_0;
	}
}
// System.Void AdvancedCoroutines.Statistics.AdvancedCoroutinesStatistics::set_TotalCoroutinesStops(System.Int32)
extern "C" IL2CPP_METHOD_ATTR void AdvancedCoroutinesStatistics_set_TotalCoroutinesStops_m262ED54B841E1FE0FBC748EC4657CB5711B44D9B (int32_t ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (AdvancedCoroutinesStatistics_set_TotalCoroutinesStops_m262ED54B841E1FE0FBC748EC4657CB5711B44D9B_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		int32_t L_0 = ___value0;
		IL2CPP_RUNTIME_CLASS_INIT(AdvancedCoroutinesStatistics_tD1A40FB5B47CB66A9325B023E08B94D3F04A126C_il2cpp_TypeInfo_var);
		((AdvancedCoroutinesStatistics_tD1A40FB5B47CB66A9325B023E08B94D3F04A126C_StaticFields*)il2cpp_codegen_static_fields_for(AdvancedCoroutinesStatistics_tD1A40FB5B47CB66A9325B023E08B94D3F04A126C_il2cpp_TypeInfo_var))->set_U3CTotalCoroutinesStopsU3Ek__BackingField_3(L_0);
		return;
	}
}
// System.Void AdvancedCoroutines.Statistics.AdvancedCoroutinesStatistics::.cctor()
extern "C" IL2CPP_METHOD_ATTR void AdvancedCoroutinesStatistics__cctor_mCF89762CD3FC398B26CE8638B8FC104D341A7763 (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (AdvancedCoroutinesStatistics__cctor_mCF89762CD3FC398B26CE8638B8FC104D341A7763_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Dictionary_2_tB10A5D0DDD081F3EFE74C0C35884F2216111ED48 * L_0 = (Dictionary_2_tB10A5D0DDD081F3EFE74C0C35884F2216111ED48 *)il2cpp_codegen_object_new(Dictionary_2_tB10A5D0DDD081F3EFE74C0C35884F2216111ED48_il2cpp_TypeInfo_var);
		Dictionary_2__ctor_m69ED04E59A57469134B4954B96BC07E608A4914C(L_0, /*hidden argument*/Dictionary_2__ctor_m69ED04E59A57469134B4954B96BC07E608A4914C_RuntimeMethod_var);
		((AdvancedCoroutinesStatistics_tD1A40FB5B47CB66A9325B023E08B94D3F04A126C_StaticFields*)il2cpp_codegen_static_fields_for(AdvancedCoroutinesStatistics_tD1A40FB5B47CB66A9325B023E08B94D3F04A126C_il2cpp_TypeInfo_var))->set__rouitinesStatistics_1(L_0);
		AdvancedCoroutinesStatistics_set_TotalCoroutinesStarts_m929A36B197CEB724718474F5B3AC716F589B41E5(0, /*hidden argument*/NULL);
		AdvancedCoroutinesStatistics_set_TotalCoroutinesStops_m262ED54B841E1FE0FBC748EC4657CB5711B44D9B(0, /*hidden argument*/NULL);
		return;
	}
}
// System.Void AdvancedCoroutines.Statistics.AdvancedCoroutinesStatistics::Remove(AdvancedCoroutines.Routine)
extern "C" IL2CPP_METHOD_ATTR void AdvancedCoroutinesStatistics_Remove_mAF48156A8072F97509ED56A4C57965FACD4585BA (Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * ___routine0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (AdvancedCoroutinesStatistics_Remove_mAF48156A8072F97509ED56A4C57965FACD4585BA_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(AdvancedCoroutinesStatistics_tD1A40FB5B47CB66A9325B023E08B94D3F04A126C_il2cpp_TypeInfo_var);
		Dictionary_2_tB10A5D0DDD081F3EFE74C0C35884F2216111ED48 * L_0 = ((AdvancedCoroutinesStatistics_tD1A40FB5B47CB66A9325B023E08B94D3F04A126C_StaticFields*)il2cpp_codegen_static_fields_for(AdvancedCoroutinesStatistics_tD1A40FB5B47CB66A9325B023E08B94D3F04A126C_il2cpp_TypeInfo_var))->get__rouitinesStatistics_1();
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_1 = ___routine0;
		NullCheck(L_0);
		bool L_2 = Dictionary_2_ContainsKey_m7CCAFEF9A9B3B9C0674FC7B08A5F818ABFBA9340(L_0, L_1, /*hidden argument*/Dictionary_2_ContainsKey_m7CCAFEF9A9B3B9C0674FC7B08A5F818ABFBA9340_RuntimeMethod_var);
		if (!L_2)
		{
			goto IL_0025;
		}
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(AdvancedCoroutinesStatistics_tD1A40FB5B47CB66A9325B023E08B94D3F04A126C_il2cpp_TypeInfo_var);
		Dictionary_2_tB10A5D0DDD081F3EFE74C0C35884F2216111ED48 * L_3 = ((AdvancedCoroutinesStatistics_tD1A40FB5B47CB66A9325B023E08B94D3F04A126C_StaticFields*)il2cpp_codegen_static_fields_for(AdvancedCoroutinesStatistics_tD1A40FB5B47CB66A9325B023E08B94D3F04A126C_il2cpp_TypeInfo_var))->get__rouitinesStatistics_1();
		Routine_t904ED3ED5262F6EA661391CB0EAD6714FA4B81FF * L_4 = ___routine0;
		NullCheck(L_3);
		Dictionary_2_Remove_mDF1C8989572A0C846C14258CAFC82C1359F9C42F(L_3, L_4, /*hidden argument*/Dictionary_2_Remove_mDF1C8989572A0C846C14258CAFC82C1359F9C42F_RuntimeMethod_var);
		int32_t L_5 = AdvancedCoroutinesStatistics_get_TotalCoroutinesStops_mAC4EDF4D9170C333C1B4DACE8B3FD66A869E14D2(/*hidden argument*/NULL);
		AdvancedCoroutinesStatistics_set_TotalCoroutinesStops_m262ED54B841E1FE0FBC748EC4657CB5711B44D9B(((int32_t)il2cpp_codegen_add((int32_t)L_5, (int32_t)1)), /*hidden argument*/NULL);
	}

IL_0025:
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
// System.Void AdvancedCoroutines.Wait::.ctor(System.Single)
extern "C" IL2CPP_METHOD_ATTR void Wait__ctor_m4016F6AE2294FEE779228CE5C9A00F4599E582CE (Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B * __this, float ___seconds0, const RuntimeMethod* method)
{
	{
		__this->set_waitTypeInternal_1(2);
		float L_0 = ___seconds0;
		__this->set_Seconds_0(L_0);
		return;
	}
}
extern "C"  void Wait__ctor_m4016F6AE2294FEE779228CE5C9A00F4599E582CE_AdjustorThunk (RuntimeObject * __this, float ___seconds0, const RuntimeMethod* method)
{
	Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B * _thisAdjusted = reinterpret_cast<Wait_t2B7CA3C9C8A8241109259437A2F62272E112281B *>(__this + 1);
	Wait__ctor_m4016F6AE2294FEE779228CE5C9A00F4599E582CE(_thisAdjusted, ___seconds0, method);
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
