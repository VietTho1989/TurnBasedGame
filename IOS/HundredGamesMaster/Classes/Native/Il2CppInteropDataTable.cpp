﻿#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <stdint.h>

#include "il2cpp-class-internals.h"
#include "codegen/il2cpp-codegen.h"
#include "il2cpp-object-internals.h"


// System.Collections.IDictionary
struct IDictionary_t1BD5C1546718A374EA8122FBD6C6EE45331E8CE7;
// System.Diagnostics.StackTrace[]
struct StackTraceU5BU5D_t855F09649EA34DEE7C1B6F088E0538E3CCC3F196;
// System.IntPtr[]
struct IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD;
// System.Runtime.Serialization.SafeSerializationManager
struct SafeSerializationManager_t4A754D86B0F784B18CBC36C073BA564BED109770;
// System.String
struct String_t;

struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;



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
#ifndef ZLIBEXCEPTION_T2F0C2A9C169C9729EA1A649DD3A2D58AFA7F7028_H
#define ZLIBEXCEPTION_T2F0C2A9C169C9729EA1A649DD3A2D58AFA7F7028_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.Decompression.Zlib.ZlibException
struct  ZlibException_t2F0C2A9C169C9729EA1A649DD3A2D58AFA7F7028  : public Exception_t
{
public:
	static const Il2CppGuid CLSID;

public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ZLIBEXCEPTION_T2F0C2A9C169C9729EA1A649DD3A2D58AFA7F7028_H



extern "C" void Escape_t7D205DCBE40F7D5FE25F443E2DBF79A63870C5C6_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Escape_t7D205DCBE40F7D5FE25F443E2DBF79A63870C5C6_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Escape_t7D205DCBE40F7D5FE25F443E2DBF79A63870C5C6_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Escape_t7D205DCBE40F7D5FE25F443E2DBF79A63870C5C6_0_0_0;
extern "C" void SafeStringMarshal_tD41B530333F2C9F500BD6FEC91735D16F06C9A6F_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SafeStringMarshal_tD41B530333F2C9F500BD6FEC91735D16F06C9A6F_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SafeStringMarshal_tD41B530333F2C9F500BD6FEC91735D16F06C9A6F_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SafeStringMarshal_tD41B530333F2C9F500BD6FEC91735D16F06C9A6F_0_0_0;
extern "C" void UriScheme_tD4C9E109AAE4DEFCAA20A5D4D756767924C8F089_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void UriScheme_tD4C9E109AAE4DEFCAA20A5D4D756767924C8F089_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void UriScheme_tD4C9E109AAE4DEFCAA20A5D4D756767924C8F089_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType UriScheme_tD4C9E109AAE4DEFCAA20A5D4D756767924C8F089_0_0_0;
extern "C" void DelegatePInvokeWrapper_Action_t591D2A86165F896B4B800BB5C25CE18672A55579();
extern const RuntimeType Action_t591D2A86165F896B4B800BB5C25CE18672A55579_0_0_0;
extern "C" void AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8_0_0_0;
extern "C" void AppDomainSetup_t80DF2915BB100D4BD515920B49C959E9FA451306_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AppDomainSetup_t80DF2915BB100D4BD515920B49C959E9FA451306_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AppDomainSetup_t80DF2915BB100D4BD515920B49C959E9FA451306_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AppDomainSetup_t80DF2915BB100D4BD515920B49C959E9FA451306_0_0_0;
extern "C" void SorterGenericArray_t4742EBDD434279DCC671369AB18AD4DC64587891_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SorterGenericArray_t4742EBDD434279DCC671369AB18AD4DC64587891_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SorterGenericArray_t4742EBDD434279DCC671369AB18AD4DC64587891_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SorterGenericArray_t4742EBDD434279DCC671369AB18AD4DC64587891_0_0_0;
extern "C" void SorterObjectArray_tFBBE2F63F86573B28BE7E3BE0BFF9C614F12BDB4_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SorterObjectArray_tFBBE2F63F86573B28BE7E3BE0BFF9C614F12BDB4_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SorterObjectArray_tFBBE2F63F86573B28BE7E3BE0BFF9C614F12BDB4_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SorterObjectArray_tFBBE2F63F86573B28BE7E3BE0BFF9C614F12BDB4_0_0_0;
extern "C" void DictionaryEntry_tB5348A26B94274FCC1DD77185BD5946E283B11A4_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void DictionaryEntry_tB5348A26B94274FCC1DD77185BD5946E283B11A4_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void DictionaryEntry_tB5348A26B94274FCC1DD77185BD5946E283B11A4_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType DictionaryEntry_tB5348A26B94274FCC1DD77185BD5946E283B11A4_0_0_0;
extern "C" void bucket_t1C848488DF65838689F7773D46F9E7E8C881B083_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void bucket_t1C848488DF65838689F7773D46F9E7E8C881B083_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void bucket_t1C848488DF65838689F7773D46F9E7E8C881B083_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType bucket_t1C848488DF65838689F7773D46F9E7E8C881B083_0_0_0;
extern "C" void DelegatePInvokeWrapper_InternalCancelHandler_t2DD134D8150B67E2F9FAD1BC2E6BE92EED57968A();
extern const RuntimeType InternalCancelHandler_t2DD134D8150B67E2F9FAD1BC2E6BE92EED57968A_0_0_0;
extern "C" void DelegatePInvokeWrapper_WindowsCancelHandler_t1D05BCFB512603DCF87A126FE9969F1D876B9B51();
extern const RuntimeType WindowsCancelHandler_t1D05BCFB512603DCF87A126FE9969F1D876B9B51_0_0_0;
extern "C" void ConsoleKeyInfo_t5BE3CE05E8258CDB5404256E96AF7C22BC5DE768_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ConsoleKeyInfo_t5BE3CE05E8258CDB5404256E96AF7C22BC5DE768_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ConsoleKeyInfo_t5BE3CE05E8258CDB5404256E96AF7C22BC5DE768_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ConsoleKeyInfo_t5BE3CE05E8258CDB5404256E96AF7C22BC5DE768_0_0_0;
extern "C" void DTSubString_t0B5F9998AD0833CCE29248DE20EFEBFE9EBFB93D_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void DTSubString_t0B5F9998AD0833CCE29248DE20EFEBFE9EBFB93D_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void DTSubString_t0B5F9998AD0833CCE29248DE20EFEBFE9EBFB93D_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType DTSubString_t0B5F9998AD0833CCE29248DE20EFEBFE9EBFB93D_0_0_0;
extern "C" void DateTimeRawInfo_t9FCF0836569E074269DCA1D04061D8E3720D451E_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void DateTimeRawInfo_t9FCF0836569E074269DCA1D04061D8E3720D451E_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void DateTimeRawInfo_t9FCF0836569E074269DCA1D04061D8E3720D451E_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType DateTimeRawInfo_t9FCF0836569E074269DCA1D04061D8E3720D451E_0_0_0;
extern "C" void DateTimeResult_tF71BA2895BFBF33241086E9BDF836567EBD2F6AB_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void DateTimeResult_tF71BA2895BFBF33241086E9BDF836567EBD2F6AB_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void DateTimeResult_tF71BA2895BFBF33241086E9BDF836567EBD2F6AB_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType DateTimeResult_tF71BA2895BFBF33241086E9BDF836567EBD2F6AB_0_0_0;
extern "C" void Delegate_t_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Delegate_t_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Delegate_t_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Delegate_t_0_0_0;
extern "C" void StackFrame_tD06959DD2B585E9BEB73C60AB5C110DE69F23A00_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void StackFrame_tD06959DD2B585E9BEB73C60AB5C110DE69F23A00_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void StackFrame_tD06959DD2B585E9BEB73C60AB5C110DE69F23A00_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType StackFrame_tD06959DD2B585E9BEB73C60AB5C110DE69F23A00_0_0_0;
extern "C" void Enum_t2AF27C02B8653AE29442467390005ABC74D8F521_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Enum_t2AF27C02B8653AE29442467390005ABC74D8F521_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Enum_t2AF27C02B8653AE29442467390005ABC74D8F521_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Enum_t2AF27C02B8653AE29442467390005ABC74D8F521_0_0_0;
extern "C" void EnumResult_t35D8EE76FAC6638FD89A5338957F377BF893566C_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void EnumResult_t35D8EE76FAC6638FD89A5338957F377BF893566C_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void EnumResult_t35D8EE76FAC6638FD89A5338957F377BF893566C_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType EnumResult_t35D8EE76FAC6638FD89A5338957F377BF893566C_0_0_0;
extern "C" void Exception_t_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Exception_t_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Exception_t_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Exception_t_0_0_0;
extern "C" void CalendarData_t1D4C55E2ECDDE4EB7B69C75D0E28AA0AF9952B3E_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void CalendarData_t1D4C55E2ECDDE4EB7B69C75D0E28AA0AF9952B3E_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void CalendarData_t1D4C55E2ECDDE4EB7B69C75D0E28AA0AF9952B3E_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType CalendarData_t1D4C55E2ECDDE4EB7B69C75D0E28AA0AF9952B3E_0_0_0;
extern "C" void CultureData_tF43B080FFA6EB278F4F289BCDA3FB74B6C208ECD_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void CultureData_tF43B080FFA6EB278F4F289BCDA3FB74B6C208ECD_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void CultureData_tF43B080FFA6EB278F4F289BCDA3FB74B6C208ECD_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType CultureData_tF43B080FFA6EB278F4F289BCDA3FB74B6C208ECD_0_0_0;
extern "C" void CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_0_0_0;
extern "C" void Data_t25CAFAACB31D34B4A9385638281C56D4D250BA2F_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Data_t25CAFAACB31D34B4A9385638281C56D4D250BA2F_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Data_t25CAFAACB31D34B4A9385638281C56D4D250BA2F_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Data_t25CAFAACB31D34B4A9385638281C56D4D250BA2F_0_0_0;
extern "C" void InternalCodePageDataItem_t34EE39DE4A481B875348BB9BC6751E2A109AD0D4_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void InternalCodePageDataItem_t34EE39DE4A481B875348BB9BC6751E2A109AD0D4_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void InternalCodePageDataItem_t34EE39DE4A481B875348BB9BC6751E2A109AD0D4_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType InternalCodePageDataItem_t34EE39DE4A481B875348BB9BC6751E2A109AD0D4_0_0_0;
extern "C" void InternalEncodingDataItem_t34BEF550D56496035752E8E0607127CD43378211_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void InternalEncodingDataItem_t34BEF550D56496035752E8E0607127CD43378211_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void InternalEncodingDataItem_t34BEF550D56496035752E8E0607127CD43378211_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType InternalEncodingDataItem_t34BEF550D56496035752E8E0607127CD43378211_0_0_0;
extern "C" void RegionInfo_tC410DA2D1030267AF1E8F6AD7026990EE9A9F0C1_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void RegionInfo_tC410DA2D1030267AF1E8F6AD7026990EE9A9F0C1_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void RegionInfo_tC410DA2D1030267AF1E8F6AD7026990EE9A9F0C1_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType RegionInfo_tC410DA2D1030267AF1E8F6AD7026990EE9A9F0C1_0_0_0;
extern "C" void SortKey_tD5C96B638D8C6D0C4C2F49F27387D51202D78FD9_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SortKey_tD5C96B638D8C6D0C4C2F49F27387D51202D78FD9_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SortKey_tD5C96B638D8C6D0C4C2F49F27387D51202D78FD9_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SortKey_tD5C96B638D8C6D0C4C2F49F27387D51202D78FD9_0_0_0;
extern "C" void FormatLiterals_tE93C12450F24FECD414C8FC2B3F3EE606F807223_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void FormatLiterals_tE93C12450F24FECD414C8FC2B3F3EE606F807223_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void FormatLiterals_tE93C12450F24FECD414C8FC2B3F3EE606F807223_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType FormatLiterals_tE93C12450F24FECD414C8FC2B3F3EE606F807223_0_0_0;
extern "C" void TimeSpanRawInfo_t41C41424D2A6BC45542E49CB1843F08221F844FB_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void TimeSpanRawInfo_t41C41424D2A6BC45542E49CB1843F08221F844FB_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void TimeSpanRawInfo_t41C41424D2A6BC45542E49CB1843F08221F844FB_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType TimeSpanRawInfo_t41C41424D2A6BC45542E49CB1843F08221F844FB_0_0_0;
extern "C" void TimeSpanResult_t7C77BD9AF32E298E8818A8C884A2428C92283963_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void TimeSpanResult_t7C77BD9AF32E298E8818A8C884A2428C92283963_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void TimeSpanResult_t7C77BD9AF32E298E8818A8C884A2428C92283963_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType TimeSpanResult_t7C77BD9AF32E298E8818A8C884A2428C92283963_0_0_0;
extern "C" void TimeSpanToken_tAD6BBF1FE7922C2D3281576FD816F33901C87492_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void TimeSpanToken_tAD6BBF1FE7922C2D3281576FD816F33901C87492_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void TimeSpanToken_tAD6BBF1FE7922C2D3281576FD816F33901C87492_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType TimeSpanToken_tAD6BBF1FE7922C2D3281576FD816F33901C87492_0_0_0;
extern "C" void TimeSpanTokenizer_t7A2B1F99E6478C1B3D12EB1F7765D3C6E545B000_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void TimeSpanTokenizer_t7A2B1F99E6478C1B3D12EB1F7765D3C6E545B000_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void TimeSpanTokenizer_t7A2B1F99E6478C1B3D12EB1F7765D3C6E545B000_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType TimeSpanTokenizer_t7A2B1F99E6478C1B3D12EB1F7765D3C6E545B000_0_0_0;
extern "C" void GuidResult_t8E78929A7A732656B7BAF6A5482FD037F81DB3F3_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void GuidResult_t8E78929A7A732656B7BAF6A5482FD037F81DB3F3_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void GuidResult_t8E78929A7A732656B7BAF6A5482FD037F81DB3F3_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType GuidResult_t8E78929A7A732656B7BAF6A5482FD037F81DB3F3_0_0_0;
extern "C" void DelegatePInvokeWrapper_ReadDelegate_tC33791FF7613756CDEEC3ADFE91B2EE59A24FB48();
extern const RuntimeType ReadDelegate_tC33791FF7613756CDEEC3ADFE91B2EE59A24FB48_0_0_0;
extern "C" void DelegatePInvokeWrapper_WriteDelegate_t905F47C2C01F98FB87E2E19894AB9BAC6F02838C();
extern const RuntimeType WriteDelegate_t905F47C2C01F98FB87E2E19894AB9BAC6F02838C_0_0_0;
extern "C" void InputRecord_tAB007C739F339BE208F3C4796B53E9044ADF0A78_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void InputRecord_tAB007C739F339BE208F3C4796B53E9044ADF0A78_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void InputRecord_tAB007C739F339BE208F3C4796B53E9044ADF0A78_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType InputRecord_tAB007C739F339BE208F3C4796B53E9044ADF0A78_0_0_0;
extern "C" void MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF_0_0_0;
extern "C" void MonoAsyncCall_t5D4F895C7FEF7A36A60AFD3C64078A86BAF681FD_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void MonoAsyncCall_t5D4F895C7FEF7A36A60AFD3C64078A86BAF681FD_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void MonoAsyncCall_t5D4F895C7FEF7A36A60AFD3C64078A86BAF681FD_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType MonoAsyncCall_t5D4F895C7FEF7A36A60AFD3C64078A86BAF681FD_0_0_0;
extern "C" void MonoTypeInfo_t9A65BA5324D14FDFEB7644EEE6E1BDF74B8A393D_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void MonoTypeInfo_t9A65BA5324D14FDFEB7644EEE6E1BDF74B8A393D_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void MonoTypeInfo_t9A65BA5324D14FDFEB7644EEE6E1BDF74B8A393D_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType MonoTypeInfo_t9A65BA5324D14FDFEB7644EEE6E1BDF74B8A393D_0_0_0;
extern "C" void MulticastDelegate_t_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void MulticastDelegate_t_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void MulticastDelegate_t_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType MulticastDelegate_t_0_0_0;
extern "C" void NumberBuffer_tBD2266C521F098915F124D7A62AFF8DB05918075_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void NumberBuffer_tBD2266C521F098915F124D7A62AFF8DB05918075_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void NumberBuffer_tBD2266C521F098915F124D7A62AFF8DB05918075_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType NumberBuffer_tBD2266C521F098915F124D7A62AFF8DB05918075_0_0_0;
extern "C" void FormatParam_t1901DD0E7CD1B3A17B09040A6E2FCA5307328800_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void FormatParam_t1901DD0E7CD1B3A17B09040A6E2FCA5307328800_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void FormatParam_t1901DD0E7CD1B3A17B09040A6E2FCA5307328800_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType FormatParam_t1901DD0E7CD1B3A17B09040A6E2FCA5307328800_0_0_0;
extern "C" void ParamsArray_t2DD480A5C806C0920DC218523EF3673332A68023_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ParamsArray_t2DD480A5C806C0920DC218523EF3673332A68023_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ParamsArray_t2DD480A5C806C0920DC218523EF3673332A68023_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ParamsArray_t2DD480A5C806C0920DC218523EF3673332A68023_0_0_0;
extern "C" void ParsingInfo_t7E92EB1D56110F024979E1E497A675BC596BA7B7_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ParsingInfo_t7E92EB1D56110F024979E1E497A675BC596BA7B7_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ParsingInfo_t7E92EB1D56110F024979E1E497A675BC596BA7B7_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ParsingInfo_t7E92EB1D56110F024979E1E497A675BC596BA7B7_0_0_0;
extern "C" void Assembly_t_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Assembly_t_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Assembly_t_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Assembly_t_0_0_0;
extern "C" void AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82_0_0_0;
extern "C" void CustomAttributeNamedArgument_t08BA731A94FD7F173551DF3098384CB9B3056E9E_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void CustomAttributeNamedArgument_t08BA731A94FD7F173551DF3098384CB9B3056E9E_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void CustomAttributeNamedArgument_t08BA731A94FD7F173551DF3098384CB9B3056E9E_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType CustomAttributeNamedArgument_t08BA731A94FD7F173551DF3098384CB9B3056E9E_0_0_0;
extern "C" void CustomAttributeTypedArgument_t238ACCB3A438CB5EDE4A924C637B288CCEC958E8_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void CustomAttributeTypedArgument_t238ACCB3A438CB5EDE4A924C637B288CCEC958E8_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void CustomAttributeTypedArgument_t238ACCB3A438CB5EDE4A924C637B288CCEC958E8_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType CustomAttributeTypedArgument_t238ACCB3A438CB5EDE4A924C637B288CCEC958E8_0_0_0;
extern "C" void LocalBuilder_t7A455571119EA1514A1158BBB78890FF7AB6A469_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void LocalBuilder_t7A455571119EA1514A1158BBB78890FF7AB6A469_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void LocalBuilder_t7A455571119EA1514A1158BBB78890FF7AB6A469_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType LocalBuilder_t7A455571119EA1514A1158BBB78890FF7AB6A469_0_0_0;
extern "C" void ExceptionHandlingClause_t112046BB7ECF503629487282AC37B55A6C2FEDC8_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ExceptionHandlingClause_t112046BB7ECF503629487282AC37B55A6C2FEDC8_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ExceptionHandlingClause_t112046BB7ECF503629487282AC37B55A6C2FEDC8_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ExceptionHandlingClause_t112046BB7ECF503629487282AC37B55A6C2FEDC8_0_0_0;
extern "C" void LocalVariableInfo_t9DBEDBE3F55EEEA102C20A450433E3ECB255858C_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void LocalVariableInfo_t9DBEDBE3F55EEEA102C20A450433E3ECB255858C_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void LocalVariableInfo_t9DBEDBE3F55EEEA102C20A450433E3ECB255858C_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType LocalVariableInfo_t9DBEDBE3F55EEEA102C20A450433E3ECB255858C_0_0_0;
extern "C" void MethodBody_t900C79A470F33FA739168B232092420240DC11F2_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void MethodBody_t900C79A470F33FA739168B232092420240DC11F2_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void MethodBody_t900C79A470F33FA739168B232092420240DC11F2_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType MethodBody_t900C79A470F33FA739168B232092420240DC11F2_0_0_0;
extern "C" void Module_t882FB0C491B9CD194BE7CD1AC62FEFB31EEBE5D7_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Module_t882FB0C491B9CD194BE7CD1AC62FEFB31EEBE5D7_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Module_t882FB0C491B9CD194BE7CD1AC62FEFB31EEBE5D7_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Module_t882FB0C491B9CD194BE7CD1AC62FEFB31EEBE5D7_0_0_0;
extern "C" void MonoEventInfo_t4DD903D7D2A55C62BF50165523ADC010115A4DAB_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void MonoEventInfo_t4DD903D7D2A55C62BF50165523ADC010115A4DAB_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void MonoEventInfo_t4DD903D7D2A55C62BF50165523ADC010115A4DAB_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType MonoEventInfo_t4DD903D7D2A55C62BF50165523ADC010115A4DAB_0_0_0;
extern "C" void MonoMethodInfo_t846D423B6DB28262B9AC22C1D07EC38D23DF7D5D_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void MonoMethodInfo_t846D423B6DB28262B9AC22C1D07EC38D23DF7D5D_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void MonoMethodInfo_t846D423B6DB28262B9AC22C1D07EC38D23DF7D5D_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType MonoMethodInfo_t846D423B6DB28262B9AC22C1D07EC38D23DF7D5D_0_0_0;
extern "C" void MonoPropertyInfo_tC5EFF918A3DCFB6A5DBAFB9B7DE3DEB56C72885F_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void MonoPropertyInfo_tC5EFF918A3DCFB6A5DBAFB9B7DE3DEB56C72885F_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void MonoPropertyInfo_tC5EFF918A3DCFB6A5DBAFB9B7DE3DEB56C72885F_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType MonoPropertyInfo_tC5EFF918A3DCFB6A5DBAFB9B7DE3DEB56C72885F_0_0_0;
extern "C" void ParameterInfo_t37AB8D79D44E14C48CDA9004CB696E240C3FD4DB_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ParameterInfo_t37AB8D79D44E14C48CDA9004CB696E240C3FD4DB_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ParameterInfo_t37AB8D79D44E14C48CDA9004CB696E240C3FD4DB_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ParameterInfo_t37AB8D79D44E14C48CDA9004CB696E240C3FD4DB_0_0_0;
extern "C" void ParameterModifier_t7BEFF7C52C8D7CD73D787BDAE6A1A50196204E3E_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ParameterModifier_t7BEFF7C52C8D7CD73D787BDAE6A1A50196204E3E_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ParameterModifier_t7BEFF7C52C8D7CD73D787BDAE6A1A50196204E3E_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ParameterModifier_t7BEFF7C52C8D7CD73D787BDAE6A1A50196204E3E_0_0_0;
extern "C" void ResourceLocator_t1783916E271C27CB09DF57E7E5ED08ECA4B3275C_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ResourceLocator_t1783916E271C27CB09DF57E7E5ED08ECA4B3275C_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ResourceLocator_t1783916E271C27CB09DF57E7E5ED08ECA4B3275C_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ResourceLocator_t1783916E271C27CB09DF57E7E5ED08ECA4B3275C_0_0_0;
extern "C" void AsyncMethodBuilderCore_t4CE6C1E4B0621A6EC45CF6E0E8F1F633FFF9FF01_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AsyncMethodBuilderCore_t4CE6C1E4B0621A6EC45CF6E0E8F1F633FFF9FF01_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AsyncMethodBuilderCore_t4CE6C1E4B0621A6EC45CF6E0E8F1F633FFF9FF01_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AsyncMethodBuilderCore_t4CE6C1E4B0621A6EC45CF6E0E8F1F633FFF9FF01_0_0_0;
extern "C" void AsyncTaskMethodBuilder_t0CD1893D670405BED201BE8CA6F2E811F2C0F487_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AsyncTaskMethodBuilder_t0CD1893D670405BED201BE8CA6F2E811F2C0F487_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AsyncTaskMethodBuilder_t0CD1893D670405BED201BE8CA6F2E811F2C0F487_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AsyncTaskMethodBuilder_t0CD1893D670405BED201BE8CA6F2E811F2C0F487_0_0_0;
extern "C" void ConfiguredTaskAwaitable_t24DE1415466EE20060BE5AD528DC5C812CFA53A9_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ConfiguredTaskAwaitable_t24DE1415466EE20060BE5AD528DC5C812CFA53A9_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ConfiguredTaskAwaitable_t24DE1415466EE20060BE5AD528DC5C812CFA53A9_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ConfiguredTaskAwaitable_t24DE1415466EE20060BE5AD528DC5C812CFA53A9_0_0_0;
extern "C" void ConfiguredTaskAwaiter_tF1AAA16B8A1250CA037E32157A3424CD2BA47874_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ConfiguredTaskAwaiter_tF1AAA16B8A1250CA037E32157A3424CD2BA47874_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ConfiguredTaskAwaiter_tF1AAA16B8A1250CA037E32157A3424CD2BA47874_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ConfiguredTaskAwaiter_tF1AAA16B8A1250CA037E32157A3424CD2BA47874_0_0_0;
extern "C" void Ephemeron_t6F0B12401657FF132AB44052E5BCD06D358FF1BA_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Ephemeron_t6F0B12401657FF132AB44052E5BCD06D358FF1BA_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Ephemeron_t6F0B12401657FF132AB44052E5BCD06D358FF1BA_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Ephemeron_t6F0B12401657FF132AB44052E5BCD06D358FF1BA_0_0_0;
extern "C" void TaskAwaiter_t0CDE8DBB564F0A0EA55FA6B3D43EEF96BC26252F_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void TaskAwaiter_t0CDE8DBB564F0A0EA55FA6B3D43EEF96BC26252F_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void TaskAwaiter_t0CDE8DBB564F0A0EA55FA6B3D43EEF96BC26252F_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType TaskAwaiter_t0CDE8DBB564F0A0EA55FA6B3D43EEF96BC26252F_0_0_0;
extern "C" void ProcessMessageRes_t17F028A89C1685A6BE96D7B59DD490E4CB859957_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ProcessMessageRes_t17F028A89C1685A6BE96D7B59DD490E4CB859957_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ProcessMessageRes_t17F028A89C1685A6BE96D7B59DD490E4CB859957_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ProcessMessageRes_t17F028A89C1685A6BE96D7B59DD490E4CB859957_0_0_0;
extern "C" void Context_tE86AB6B3D9759C8E715184808579EFE761683724_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Context_tE86AB6B3D9759C8E715184808579EFE761683724_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Context_tE86AB6B3D9759C8E715184808579EFE761683724_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Context_tE86AB6B3D9759C8E715184808579EFE761683724_0_0_0;
extern "C" void DelegatePInvokeWrapper_CrossContextDelegate_tB042FB42C495873AAE7558740B190D857C74CD9F();
extern const RuntimeType CrossContextDelegate_tB042FB42C495873AAE7558740B190D857C74CD9F_0_0_0;
extern "C" void AsyncResult_tCCDC69FF29D3DE32F7BD57870BBC329EFF8E58E2_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AsyncResult_tCCDC69FF29D3DE32F7BD57870BBC329EFF8E58E2_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AsyncResult_tCCDC69FF29D3DE32F7BD57870BBC329EFF8E58E2_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AsyncResult_tCCDC69FF29D3DE32F7BD57870BBC329EFF8E58E2_0_0_0;
extern "C" void Reader_t8A0F3818A710941785287CE8D7184C05480C2EA6_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Reader_t8A0F3818A710941785287CE8D7184C05480C2EA6_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Reader_t8A0F3818A710941785287CE8D7184C05480C2EA6_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Reader_t8A0F3818A710941785287CE8D7184C05480C2EA6_0_0_0;
extern "C" void MonoMethodMessage_t0846334ADE91F66FECE638BEF57256CFF6EEA234_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void MonoMethodMessage_t0846334ADE91F66FECE638BEF57256CFF6EEA234_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void MonoMethodMessage_t0846334ADE91F66FECE638BEF57256CFF6EEA234_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType MonoMethodMessage_t0846334ADE91F66FECE638BEF57256CFF6EEA234_0_0_0;
extern "C" void RealProxy_t4B0A745F7C99373132CC67FE86D13421411361EF_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void RealProxy_t4B0A745F7C99373132CC67FE86D13421411361EF_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void RealProxy_t4B0A745F7C99373132CC67FE86D13421411361EF_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType RealProxy_t4B0A745F7C99373132CC67FE86D13421411361EF_0_0_0;
extern "C" void TransparentProxy_t86DE1FBB00F5A5B8859BB8E8375ED2F5C42D8000_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void TransparentProxy_t86DE1FBB00F5A5B8859BB8E8375ED2F5C42D8000_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void TransparentProxy_t86DE1FBB00F5A5B8859BB8E8375ED2F5C42D8000_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType TransparentProxy_t86DE1FBB00F5A5B8859BB8E8375ED2F5C42D8000_0_0_0;
extern "C" void SerializationEntry_tA4CE7B0176B45BD820A7802C84479174F5EBE5EA_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SerializationEntry_tA4CE7B0176B45BD820A7802C84479174F5EBE5EA_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SerializationEntry_tA4CE7B0176B45BD820A7802C84479174F5EBE5EA_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SerializationEntry_tA4CE7B0176B45BD820A7802C84479174F5EBE5EA_0_0_0;
extern "C" void DelegatePInvokeWrapper_SerializationEventHandler_t89AF9E752DCE27CE604337BD1FFE644B37D5CB6A();
extern const RuntimeType SerializationEventHandler_t89AF9E752DCE27CE604337BD1FFE644B37D5CB6A_0_0_0;
extern "C" void StreamingContext_t2CCDC54E0E8D078AF4A50E3A8B921B828A900034_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void StreamingContext_t2CCDC54E0E8D078AF4A50E3A8B921B828A900034_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void StreamingContext_t2CCDC54E0E8D078AF4A50E3A8B921B828A900034_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType StreamingContext_t2CCDC54E0E8D078AF4A50E3A8B921B828A900034_0_0_0;
extern "C" void HashAlgorithmName_tD62515D9082F4E5599534680DC6E20D5B638A18F_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void HashAlgorithmName_tD62515D9082F4E5599534680DC6E20D5B638A18F_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void HashAlgorithmName_tD62515D9082F4E5599534680DC6E20D5B638A18F_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType HashAlgorithmName_tD62515D9082F4E5599534680DC6E20D5B638A18F_0_0_0;
extern "C" void CancellationCallbackCoreWorkArguments_t6290788CA17D8028FC4BC98AE2EDD437396675DB_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void CancellationCallbackCoreWorkArguments_t6290788CA17D8028FC4BC98AE2EDD437396675DB_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void CancellationCallbackCoreWorkArguments_t6290788CA17D8028FC4BC98AE2EDD437396675DB_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType CancellationCallbackCoreWorkArguments_t6290788CA17D8028FC4BC98AE2EDD437396675DB_0_0_0;
extern "C" void CancellationToken_t9E956952F7F20908F2AE72EDF36D97E6C7DB63AB_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void CancellationToken_t9E956952F7F20908F2AE72EDF36D97E6C7DB63AB_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void CancellationToken_t9E956952F7F20908F2AE72EDF36D97E6C7DB63AB_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType CancellationToken_t9E956952F7F20908F2AE72EDF36D97E6C7DB63AB_0_0_0;
extern "C" void CancellationTokenRegistration_tCDB9825D1854DD0D7FF737C82B099FC468107BB2_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void CancellationTokenRegistration_tCDB9825D1854DD0D7FF737C82B099FC468107BB2_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void CancellationTokenRegistration_tCDB9825D1854DD0D7FF737C82B099FC468107BB2_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType CancellationTokenRegistration_tCDB9825D1854DD0D7FF737C82B099FC468107BB2_0_0_0;
extern "C" void Reader_t5766DE258B6B590281150D8DB517B651F9F4F33B_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Reader_t5766DE258B6B590281150D8DB517B651F9F4F33B_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Reader_t5766DE258B6B590281150D8DB517B651F9F4F33B_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Reader_t5766DE258B6B590281150D8DB517B651F9F4F33B_0_0_0;
extern "C" void ExecutionContextSwitcher_t739C861A327D724A4E59DE865463B32097395159_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ExecutionContextSwitcher_t739C861A327D724A4E59DE865463B32097395159_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ExecutionContextSwitcher_t739C861A327D724A4E59DE865463B32097395159_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ExecutionContextSwitcher_t739C861A327D724A4E59DE865463B32097395159_0_0_0;
extern "C" void DelegatePInvokeWrapper_ThreadStart_t09FFA4371E4B2A713F212B157CC9B8B61983B5BF();
extern const RuntimeType ThreadStart_t09FFA4371E4B2A713F212B157CC9B8B61983B5BF_0_0_0;
extern "C" void WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6_0_0_0;
extern "C" void DYNAMIC_TIME_ZONE_INFORMATION_tE2A7A07ADC8726A5FC7954EA9CDE9168756C9B1F_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void DYNAMIC_TIME_ZONE_INFORMATION_tE2A7A07ADC8726A5FC7954EA9CDE9168756C9B1F_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void DYNAMIC_TIME_ZONE_INFORMATION_tE2A7A07ADC8726A5FC7954EA9CDE9168756C9B1F_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType DYNAMIC_TIME_ZONE_INFORMATION_tE2A7A07ADC8726A5FC7954EA9CDE9168756C9B1F_0_0_0;
extern "C" void TIME_ZONE_INFORMATION_tE8C6F24D5D50D01E03E52B00DDF74849F3DE9811_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void TIME_ZONE_INFORMATION_tE8C6F24D5D50D01E03E52B00DDF74849F3DE9811_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void TIME_ZONE_INFORMATION_tE8C6F24D5D50D01E03E52B00DDF74849F3DE9811_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType TIME_ZONE_INFORMATION_tE8C6F24D5D50D01E03E52B00DDF74849F3DE9811_0_0_0;
extern "C" void TransitionTime_t9958178434A0688FD45EF028B1AE9EA665C3E116_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void TransitionTime_t9958178434A0688FD45EF028B1AE9EA665C3E116_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void TransitionTime_t9958178434A0688FD45EF028B1AE9EA665C3E116_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType TransitionTime_t9958178434A0688FD45EF028B1AE9EA665C3E116_0_0_0;
extern "C" void UnSafeCharBuffer_t99F0962CE65E71C4BA612D5434276C51AC33AF0C_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void UnSafeCharBuffer_t99F0962CE65E71C4BA612D5434276C51AC33AF0C_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void UnSafeCharBuffer_t99F0962CE65E71C4BA612D5434276C51AC33AF0C_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType UnSafeCharBuffer_t99F0962CE65E71C4BA612D5434276C51AC33AF0C_0_0_0;
extern "C" void ValueType_t4D0C27076F7C36E76190FB3328E232BCB1CD1FFF_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ValueType_t4D0C27076F7C36E76190FB3328E232BCB1CD1FFF_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ValueType_t4D0C27076F7C36E76190FB3328E232BCB1CD1FFF_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ValueType_t4D0C27076F7C36E76190FB3328E232BCB1CD1FFF_0_0_0;
extern "C" void VersionResult_tA97F3FDF3CF3FF5D0E43768C08D1C4D4568E88CE_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void VersionResult_tA97F3FDF3CF3FF5D0E43768C08D1C4D4568E88CE_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void VersionResult_tA97F3FDF3CF3FF5D0E43768C08D1C4D4568E88CE_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType VersionResult_tA97F3FDF3CF3FF5D0E43768C08D1C4D4568E88CE_0_0_0;
extern "C" void __DTString_t6E7DE2A99E4F15F384EC29CC6CD5185F46818DD9_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void __DTString_t6E7DE2A99E4F15F384EC29CC6CD5185F46818DD9_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void __DTString_t6E7DE2A99E4F15F384EC29CC6CD5185F46818DD9_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType __DTString_t6E7DE2A99E4F15F384EC29CC6CD5185F46818DD9_0_0_0;
extern "C" void XPathNode_tC207ED6C653E80055FE6C5ECD3E6137A326659A0_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void XPathNode_tC207ED6C653E80055FE6C5ECD3E6137A326659A0_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void XPathNode_tC207ED6C653E80055FE6C5ECD3E6137A326659A0_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType XPathNode_tC207ED6C653E80055FE6C5ECD3E6137A326659A0_0_0_0;
extern "C" void XPathNodeRef_t6F631244BF7B58CE7DB9239662B4EE745CD54E14_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void XPathNodeRef_t6F631244BF7B58CE7DB9239662B4EE745CD54E14_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void XPathNodeRef_t6F631244BF7B58CE7DB9239662B4EE745CD54E14_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType XPathNodeRef_t6F631244BF7B58CE7DB9239662B4EE745CD54E14_0_0_0;
extern "C" void FacetsCompiler_t91E639F7F083D79393593CD660539AC912314233_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void FacetsCompiler_t91E639F7F083D79393593CD660539AC912314233_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void FacetsCompiler_t91E639F7F083D79393593CD660539AC912314233_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType FacetsCompiler_t91E639F7F083D79393593CD660539AC912314233_0_0_0;
extern "C" void Map_t95CF8863CD8CAC88704F399964E9ED0524DD731D_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Map_t95CF8863CD8CAC88704F399964E9ED0524DD731D_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Map_t95CF8863CD8CAC88704F399964E9ED0524DD731D_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Map_t95CF8863CD8CAC88704F399964E9ED0524DD731D_0_0_0;
extern "C" void Position_t089976E4BEB3D345DA28CFA95786EE065063E228_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Position_t089976E4BEB3D345DA28CFA95786EE065063E228_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Position_t089976E4BEB3D345DA28CFA95786EE065063E228_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Position_t089976E4BEB3D345DA28CFA95786EE065063E228_0_0_0;
extern "C" void RangePositionInfo_tDCA2617E7E1292998A9700E38DBBA177330A80CA_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void RangePositionInfo_tDCA2617E7E1292998A9700E38DBBA177330A80CA_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void RangePositionInfo_tDCA2617E7E1292998A9700E38DBBA177330A80CA_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType RangePositionInfo_tDCA2617E7E1292998A9700E38DBBA177330A80CA_0_0_0;
extern "C" void SequenceConstructPosContext_t72DF930B1BE2676BD225E8D9622C78EF2B0DFAC1_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SequenceConstructPosContext_t72DF930B1BE2676BD225E8D9622C78EF2B0DFAC1_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SequenceConstructPosContext_t72DF930B1BE2676BD225E8D9622C78EF2B0DFAC1_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SequenceConstructPosContext_t72DF930B1BE2676BD225E8D9622C78EF2B0DFAC1_0_0_0;
extern "C" void Union_t75FE76D5ECF7F32BF3656D21BD446F4E42996391_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Union_t75FE76D5ECF7F32BF3656D21BD446F4E42996391_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Union_t75FE76D5ECF7F32BF3656D21BD446F4E42996391_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Union_t75FE76D5ECF7F32BF3656D21BD446F4E42996391_0_0_0;
extern "C" void XmlSchemaObjectEntry_tD7A5D31C794A4D04759882DDAD01103D2C19D63B_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void XmlSchemaObjectEntry_tD7A5D31C794A4D04759882DDAD01103D2C19D63B_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void XmlSchemaObjectEntry_tD7A5D31C794A4D04759882DDAD01103D2C19D63B_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType XmlSchemaObjectEntry_tD7A5D31C794A4D04759882DDAD01103D2C19D63B_0_0_0;
extern "C" void XsdDateTime_tEA54A4A77DD9458E97F1306F2013714582663CC5_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void XsdDateTime_tEA54A4A77DD9458E97F1306F2013714582663CC5_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void XsdDateTime_tEA54A4A77DD9458E97F1306F2013714582663CC5_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType XsdDateTime_tEA54A4A77DD9458E97F1306F2013714582663CC5_0_0_0;
extern "C" void Parser_t402903C4103D1084228988A8DA76C1FCB8D890B9_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Parser_t402903C4103D1084228988A8DA76C1FCB8D890B9_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Parser_t402903C4103D1084228988A8DA76C1FCB8D890B9_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Parser_t402903C4103D1084228988A8DA76C1FCB8D890B9_0_0_0;
extern "C" void DelegatePInvokeWrapper_HashCodeOfStringDelegate_tC8B9E43DCB47789C0CCA2921BE18838AB95B323E();
extern const RuntimeType HashCodeOfStringDelegate_tC8B9E43DCB47789C0CCA2921BE18838AB95B323E_0_0_0;
extern "C" void SmallXmlNodeList_t962D7A66CF19950FE6DFA9476903952B76844A1E_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SmallXmlNodeList_t962D7A66CF19950FE6DFA9476903952B76844A1E_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SmallXmlNodeList_t962D7A66CF19950FE6DFA9476903952B76844A1E_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SmallXmlNodeList_t962D7A66CF19950FE6DFA9476903952B76844A1E_0_0_0;
extern "C" void NamespaceDeclaration_tFD9A771E0585F887CE869FA7D0FAD365A40D436A_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void NamespaceDeclaration_tFD9A771E0585F887CE869FA7D0FAD365A40D436A_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void NamespaceDeclaration_tFD9A771E0585F887CE869FA7D0FAD365A40D436A_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType NamespaceDeclaration_tFD9A771E0585F887CE869FA7D0FAD365A40D436A_0_0_0;
extern "C" void VirtualAttribute_t3CED95AE4D2D98B3E1C79C4CA6C4B076326DC465_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void VirtualAttribute_t3CED95AE4D2D98B3E1C79C4CA6C4B076326DC465_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void VirtualAttribute_t3CED95AE4D2D98B3E1C79C4CA6C4B076326DC465_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType VirtualAttribute_t3CED95AE4D2D98B3E1C79C4CA6C4B076326DC465_0_0_0;
extern "C" void DelegatePInvokeWrapper_HashCodeOfStringDelegate_tCAF2245F039C500045953429EF1FB0BA86326AE8();
extern const RuntimeType HashCodeOfStringDelegate_tCAF2245F039C500045953429EF1FB0BA86326AE8_0_0_0;
extern "C" void AttrInfo_tC56788540A1F53E77E0A21E93000A66846FAFC0B_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AttrInfo_tC56788540A1F53E77E0A21E93000A66846FAFC0B_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AttrInfo_tC56788540A1F53E77E0A21E93000A66846FAFC0B_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AttrInfo_tC56788540A1F53E77E0A21E93000A66846FAFC0B_0_0_0;
extern "C" void ElemInfo_t930901F4C4D70BD460913E85E8B87AB5C5A8571F_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ElemInfo_t930901F4C4D70BD460913E85E8B87AB5C5A8571F_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ElemInfo_t930901F4C4D70BD460913E85E8B87AB5C5A8571F_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ElemInfo_t930901F4C4D70BD460913E85E8B87AB5C5A8571F_0_0_0;
extern "C" void QName_t49332A07486EFE325DF0D3F34BE798ED3497C42F_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void QName_t49332A07486EFE325DF0D3F34BE798ED3497C42F_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void QName_t49332A07486EFE325DF0D3F34BE798ED3497C42F_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType QName_t49332A07486EFE325DF0D3F34BE798ED3497C42F_0_0_0;
extern "C" void SymbolTables_t8F49FC5423EF06561EBAF65E6130FA03C025325E_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SymbolTables_t8F49FC5423EF06561EBAF65E6130FA03C025325E_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SymbolTables_t8F49FC5423EF06561EBAF65E6130FA03C025325E_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SymbolTables_t8F49FC5423EF06561EBAF65E6130FA03C025325E_0_0_0;
extern "C" void ParsingState_tE4A8E7F14B2068AE43ECF99F81F55B0301A551A2_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ParsingState_tE4A8E7F14B2068AE43ECF99F81F55B0301A551A2_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ParsingState_tE4A8E7F14B2068AE43ECF99F81F55B0301A551A2_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ParsingState_tE4A8E7F14B2068AE43ECF99F81F55B0301A551A2_0_0_0;
extern "C" void Namespace_t092048EEBC7FF22AF20114DDA7633072C44CA26B_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Namespace_t092048EEBC7FF22AF20114DDA7633072C44CA26B_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Namespace_t092048EEBC7FF22AF20114DDA7633072C44CA26B_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Namespace_t092048EEBC7FF22AF20114DDA7633072C44CA26B_0_0_0;
extern "C" void TagInfo_t9F395B388162AB8B9277E4ABA1ADEF785AE197B5_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void TagInfo_t9F395B388162AB8B9277E4ABA1ADEF785AE197B5_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void TagInfo_t9F395B388162AB8B9277E4ABA1ADEF785AE197B5_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType TagInfo_t9F395B388162AB8B9277E4ABA1ADEF785AE197B5_0_0_0;
extern "C" void DelegatePInvokeWrapper_CFProxyAutoConfigurationResultCallback_t19A48665D1D7A47D6CEFF82779F5853E9B0B6506();
extern const RuntimeType CFProxyAutoConfigurationResultCallback_t19A48665D1D7A47D6CEFF82779F5853E9B0B6506_0_0_0;
extern "C" void unitytls_interface_struct_t0AD7ED5EDF9F15F1879FC9140A7D40C8D95A1BAF_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void unitytls_interface_struct_t0AD7ED5EDF9F15F1879FC9140A7D40C8D95A1BAF_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void unitytls_interface_struct_t0AD7ED5EDF9F15F1879FC9140A7D40C8D95A1BAF_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType unitytls_interface_struct_t0AD7ED5EDF9F15F1879FC9140A7D40C8D95A1BAF_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_errorstate_create_t_t104BADBBE1265BD1A3F84C153EB7A67CDDBF35A9();
extern const RuntimeType unitytls_errorstate_create_t_t104BADBBE1265BD1A3F84C153EB7A67CDDBF35A9_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_errorstate_raise_error_t_tC441A37D4A6F1BAC1AFCA0108D4F7570EFF9E0D1();
extern const RuntimeType unitytls_errorstate_raise_error_t_tC441A37D4A6F1BAC1AFCA0108D4F7570EFF9E0D1_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_key_free_t_tCC7AD95D3B758BB99785645E65EDCD65A1D243AB();
extern const RuntimeType unitytls_key_free_t_tCC7AD95D3B758BB99785645E65EDCD65A1D243AB_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_key_get_ref_t_t2F4EF4CD2F6AFC4F2D166953E834C6F0A13382A7();
extern const RuntimeType unitytls_key_get_ref_t_t2F4EF4CD2F6AFC4F2D166953E834C6F0A13382A7_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_key_parse_der_t_t2ABD1C146C8B9405F6E5A78CD59A779EA607741B();
extern const RuntimeType unitytls_key_parse_der_t_t2ABD1C146C8B9405F6E5A78CD59A779EA607741B_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_key_parse_pem_t_tB4BCEBA4194442C8C85FA19E80B808D0EDA462AB();
extern const RuntimeType unitytls_key_parse_pem_t_tB4BCEBA4194442C8C85FA19E80B808D0EDA462AB_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_random_generate_bytes_t_t494B8599A6D4247BB0C8AB7341DDC73BE42623F7();
extern const RuntimeType unitytls_random_generate_bytes_t_t494B8599A6D4247BB0C8AB7341DDC73BE42623F7_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_tlsctx_create_client_t_tD9DFBDB5559983F0E11A67FA92E0F7182114C8F2();
extern const RuntimeType unitytls_tlsctx_create_client_t_tD9DFBDB5559983F0E11A67FA92E0F7182114C8F2_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_tlsctx_create_server_t_t6E7812D40DDD91958E3CFBB92B5F5748D477E19D();
extern const RuntimeType unitytls_tlsctx_create_server_t_t6E7812D40DDD91958E3CFBB92B5F5748D477E19D_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_tlsctx_free_t_tB27A3B6F9D1B784ABE082849EAB6B81F51FAC8E2();
extern const RuntimeType unitytls_tlsctx_free_t_tB27A3B6F9D1B784ABE082849EAB6B81F51FAC8E2_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_tlsctx_get_ciphersuite_t_t94A91CB42A2EBB2CC598EF3E278770AFD80696A0();
extern const RuntimeType unitytls_tlsctx_get_ciphersuite_t_t94A91CB42A2EBB2CC598EF3E278770AFD80696A0_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_tlsctx_get_protocol_t_tB29092875D3CBD25E4461BFD165B5373FA54DB14();
extern const RuntimeType unitytls_tlsctx_get_protocol_t_tB29092875D3CBD25E4461BFD165B5373FA54DB14_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_tlsctx_notify_close_t_t2FC4C08BACF1AEA509ABCAF3B22475E196E74A0D();
extern const RuntimeType unitytls_tlsctx_notify_close_t_t2FC4C08BACF1AEA509ABCAF3B22475E196E74A0D_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_tlsctx_process_handshake_t_tC8AAF317CBE4CA216F22BF031ECF89315B963C9D();
extern const RuntimeType unitytls_tlsctx_process_handshake_t_tC8AAF317CBE4CA216F22BF031ECF89315B963C9D_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_tlsctx_read_t_tA8D1209D5F488E02F826EE2362F5AA61C8FF2EE2();
extern const RuntimeType unitytls_tlsctx_read_t_tA8D1209D5F488E02F826EE2362F5AA61C8FF2EE2_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_tlsctx_server_require_client_authentication_t_t77B3CAFF25690A45405E3C957E40CC4FF83B49C6();
extern const RuntimeType unitytls_tlsctx_server_require_client_authentication_t_t77B3CAFF25690A45405E3C957E40CC4FF83B49C6_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_tlsctx_set_certificate_callback_t_tC4864FE0F6A3398A572F2511AA64C72126640937();
extern const RuntimeType unitytls_tlsctx_set_certificate_callback_t_tC4864FE0F6A3398A572F2511AA64C72126640937_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_tlsctx_set_supported_ciphersuites_t_t6914054EA0F7A59C8A4ED4B9CDD5AF143F7D8BFE();
extern const RuntimeType unitytls_tlsctx_set_supported_ciphersuites_t_t6914054EA0F7A59C8A4ED4B9CDD5AF143F7D8BFE_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_tlsctx_set_trace_callback_t_tA11F424F68D297B6FD2B2EA26C6764F80146662A();
extern const RuntimeType unitytls_tlsctx_set_trace_callback_t_tA11F424F68D297B6FD2B2EA26C6764F80146662A_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_tlsctx_set_x509verify_callback_t_t34EEB7BA38CA2C86F847416785ADB22BC4A04F4B();
extern const RuntimeType unitytls_tlsctx_set_x509verify_callback_t_t34EEB7BA38CA2C86F847416785ADB22BC4A04F4B_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_tlsctx_write_t_t0B4A49BBA592FE4EC0630B490463AE116AF07C9C();
extern const RuntimeType unitytls_tlsctx_write_t_t0B4A49BBA592FE4EC0630B490463AE116AF07C9C_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_x509_export_der_t_tB0D0A02DE7E75757AFCA780298BF95467BF82856();
extern const RuntimeType unitytls_x509_export_der_t_tB0D0A02DE7E75757AFCA780298BF95467BF82856_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_x509list_append_der_t_tDA1C93A382058FB563F8772B119D5B598DC37A5C();
extern const RuntimeType unitytls_x509list_append_der_t_tDA1C93A382058FB563F8772B119D5B598DC37A5C_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_x509list_append_t_tAB1C185C77DFD6BD96DF7909370AA1FAD6BB90AF();
extern const RuntimeType unitytls_x509list_append_t_tAB1C185C77DFD6BD96DF7909370AA1FAD6BB90AF_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_x509list_create_t_tC040C2CF47D5426B7F6B1D6A2751507DC681CFF3();
extern const RuntimeType unitytls_x509list_create_t_tC040C2CF47D5426B7F6B1D6A2751507DC681CFF3_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_x509list_free_t_tE3FC523507F07BD9901D84E9F6968CD8A583FF09();
extern const RuntimeType unitytls_x509list_free_t_tE3FC523507F07BD9901D84E9F6968CD8A583FF09_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_x509list_get_ref_t_t1FAB0CD82E536E0C9EB5255B145FC5AF434B3986();
extern const RuntimeType unitytls_x509list_get_ref_t_t1FAB0CD82E536E0C9EB5255B145FC5AF434B3986_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_x509list_get_x509_t_t028BB06EEB95E8F62511F2301B90D8181F4FFDB5();
extern const RuntimeType unitytls_x509list_get_x509_t_t028BB06EEB95E8F62511F2301B90D8181F4FFDB5_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_x509verify_default_ca_t_t4BACB6B49AA85C025AF9B18B3F30F63C9881DE2D();
extern const RuntimeType unitytls_x509verify_default_ca_t_t4BACB6B49AA85C025AF9B18B3F30F63C9881DE2D_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_x509verify_explicit_ca_t_t6C8BE964C5EE9B24D3734F028EFCD83F5893D2E6();
extern const RuntimeType unitytls_x509verify_explicit_ca_t_t6C8BE964C5EE9B24D3734F028EFCD83F5893D2E6_0_0_0;
extern "C" void unitytls_tlsctx_callbacks_t7BB5F622E014A8EC300C578657E2B0550DA828B2_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void unitytls_tlsctx_callbacks_t7BB5F622E014A8EC300C578657E2B0550DA828B2_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void unitytls_tlsctx_callbacks_t7BB5F622E014A8EC300C578657E2B0550DA828B2_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType unitytls_tlsctx_callbacks_t7BB5F622E014A8EC300C578657E2B0550DA828B2_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_tlsctx_certificate_callback_t55149A988CA1CE32772ACAC0031DAF4DC0F6D740();
extern const RuntimeType unitytls_tlsctx_certificate_callback_t55149A988CA1CE32772ACAC0031DAF4DC0F6D740_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_tlsctx_read_callback_tD85E7923018681355C1D851137CEC527F04093F5();
extern const RuntimeType unitytls_tlsctx_read_callback_tD85E7923018681355C1D851137CEC527F04093F5_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_tlsctx_trace_callback_t2C8F0895EF17ECAC042835D68A6BFDB9CBC7F2AA();
extern const RuntimeType unitytls_tlsctx_trace_callback_t2C8F0895EF17ECAC042835D68A6BFDB9CBC7F2AA_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_tlsctx_write_callback_tBDF40F27E011F577C3E834B14788491861F870D6();
extern const RuntimeType unitytls_tlsctx_write_callback_tBDF40F27E011F577C3E834B14788491861F870D6_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_tlsctx_x509verify_callback_t5FCF0307C4AB263BC611FE396EC4D2B9CF93528A();
extern const RuntimeType unitytls_tlsctx_x509verify_callback_t5FCF0307C4AB263BC611FE396EC4D2B9CF93528A_0_0_0;
extern "C" void DelegatePInvokeWrapper_unitytls_x509verify_callback_t90C02C529DB2B9F434C18797BACC456BCB5400A9();
extern const RuntimeType unitytls_x509verify_callback_t90C02C529DB2B9F434C18797BACC456BCB5400A9_0_0_0;
extern "C" void AttributeEntry_t03E9BFE6BF6BE56EA2568359ACD774FE8C8661DD_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AttributeEntry_t03E9BFE6BF6BE56EA2568359ACD774FE8C8661DD_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AttributeEntry_t03E9BFE6BF6BE56EA2568359ACD774FE8C8661DD_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AttributeEntry_t03E9BFE6BF6BE56EA2568359ACD774FE8C8661DD_0_0_0;
extern "C" void DefaultExtendedTypeDescriptor_t89890252F6A685D141ECBB0C2878C6E913883ECE_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void DefaultExtendedTypeDescriptor_t89890252F6A685D141ECBB0C2878C6E913883ECE_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void DefaultExtendedTypeDescriptor_t89890252F6A685D141ECBB0C2878C6E913883ECE_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType DefaultExtendedTypeDescriptor_t89890252F6A685D141ECBB0C2878C6E913883ECE_0_0_0;
extern "C" void DefaultTypeDescriptor_t45C7CF272F02817B0F1C69470B4E786E746996F4_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void DefaultTypeDescriptor_t45C7CF272F02817B0F1C69470B4E786E746996F4_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void DefaultTypeDescriptor_t45C7CF272F02817B0F1C69470B4E786E746996F4_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType DefaultTypeDescriptor_t45C7CF272F02817B0F1C69470B4E786E746996F4_0_0_0;
extern "C" void ProcInfo_t3E3017C52253681B44DDCB325D45E7D7526E9424_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ProcInfo_t3E3017C52253681B44DDCB325D45E7D7526E9424_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ProcInfo_t3E3017C52253681B44DDCB325D45E7D7526E9424_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ProcInfo_t3E3017C52253681B44DDCB325D45E7D7526E9424_0_0_0;
extern "C" void ProcessStartInfo_t5130526E78224EE02475E7A0FBF5BCE821977706_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ProcessStartInfo_t5130526E78224EE02475E7A0FBF5BCE821977706_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ProcessStartInfo_t5130526E78224EE02475E7A0FBF5BCE821977706_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ProcessStartInfo_t5130526E78224EE02475E7A0FBF5BCE821977706_0_0_0;
extern "C" void DelegatePInvokeWrapper_ReadMethod_t6D92A091070756743232D28A30A05FFCFB7928C4();
extern const RuntimeType ReadMethod_t6D92A091070756743232D28A30A05FFCFB7928C4_0_0_0;
extern "C" void DelegatePInvokeWrapper_WriteMethod_tA5073EA0B599530C5CB5FF202832E16DD4C48397();
extern const RuntimeType WriteMethod_tA5073EA0B599530C5CB5FF202832E16DD4C48397_0_0_0;
extern "C" void DelegatePInvokeWrapper_UnmanagedReadOrWrite_tE27F26A26800EB8FA74A54956323F29F04E055B0();
extern const RuntimeType UnmanagedReadOrWrite_tE27F26A26800EB8FA74A54956323F29F04E055B0_0_0_0;
extern "C" void IOAsyncResult_tB02ABC485035B18A731F1B61FB27EE17F4B792AD_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void IOAsyncResult_tB02ABC485035B18A731F1B61FB27EE17F4B792AD_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void IOAsyncResult_tB02ABC485035B18A731F1B61FB27EE17F4B792AD_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType IOAsyncResult_tB02ABC485035B18A731F1B61FB27EE17F4B792AD_0_0_0;
extern "C" void IOSelectorJob_t2B03604D19B81660C4C1C06590C76BC8630DDE99_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void IOSelectorJob_t2B03604D19B81660C4C1C06590C76BC8630DDE99_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void IOSelectorJob_t2B03604D19B81660C4C1C06590C76BC8630DDE99_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType IOSelectorJob_t2B03604D19B81660C4C1C06590C76BC8630DDE99_0_0_0;
extern "C" void RecognizedAttribute_t300D9F628CDAED6F665BFE996936B9CE0FA0D95B_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void RecognizedAttribute_t300D9F628CDAED6F665BFE996936B9CE0FA0D95B_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void RecognizedAttribute_t300D9F628CDAED6F665BFE996936B9CE0FA0D95B_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType RecognizedAttribute_t300D9F628CDAED6F665BFE996936B9CE0FA0D95B_0_0_0;
extern "C" void DelegatePInvokeWrapper_ReadDelegate_tBC77AE628966A21E63D8BB344BC3D7C79441A6DE();
extern const RuntimeType ReadDelegate_tBC77AE628966A21E63D8BB344BC3D7C79441A6DE_0_0_0;
extern "C" void DelegatePInvokeWrapper_WriteDelegate_tCA763F3444D2578FB21239EDFC1C3632E469FC49();
extern const RuntimeType WriteDelegate_tCA763F3444D2578FB21239EDFC1C3632E469FC49_0_0_0;
extern "C" void DelegatePInvokeWrapper_HeaderParser_t6B59FF0FD79FFD511A019AE5383DCEF641BA822E();
extern const RuntimeType HeaderParser_t6B59FF0FD79FFD511A019AE5383DCEF641BA822E_0_0_0;
extern "C" void HeaderVariantInfo_tFF12EDB71F2B9508779B160689F99BA209DA9E64_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void HeaderVariantInfo_tFF12EDB71F2B9508779B160689F99BA209DA9E64_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void HeaderVariantInfo_tFF12EDB71F2B9508779B160689F99BA209DA9E64_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType HeaderVariantInfo_tFF12EDB71F2B9508779B160689F99BA209DA9E64_0_0_0;
extern "C" void AuthorizationState_t5C342070F47B5DBAE0089B8B6A391FDEB6914AAB_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AuthorizationState_t5C342070F47B5DBAE0089B8B6A391FDEB6914AAB_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AuthorizationState_t5C342070F47B5DBAE0089B8B6A391FDEB6914AAB_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AuthorizationState_t5C342070F47B5DBAE0089B8B6A391FDEB6914AAB_0_0_0;
extern "C" void Win32_FIXED_INFO_t3A3D06BDBE4DDA090E3A7151E5D761E867A870DD_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Win32_FIXED_INFO_t3A3D06BDBE4DDA090E3A7151E5D761E867A870DD_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Win32_FIXED_INFO_t3A3D06BDBE4DDA090E3A7151E5D761E867A870DD_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Win32_FIXED_INFO_t3A3D06BDBE4DDA090E3A7151E5D761E867A870DD_0_0_0;
extern "C" void Win32_IP_ADDR_STRING_tDA9F56F72EA92CA09591BA7A512706A1A3BCC16F_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Win32_IP_ADDR_STRING_tDA9F56F72EA92CA09591BA7A512706A1A3BCC16F_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Win32_IP_ADDR_STRING_tDA9F56F72EA92CA09591BA7A512706A1A3BCC16F_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Win32_IP_ADDR_STRING_tDA9F56F72EA92CA09591BA7A512706A1A3BCC16F_0_0_0;
extern "C" void SocketAsyncResult_t63145D172556590482549D41328C0668E19CB69C_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SocketAsyncResult_t63145D172556590482549D41328C0668E19CB69C_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SocketAsyncResult_t63145D172556590482549D41328C0668E19CB69C_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SocketAsyncResult_t63145D172556590482549D41328C0668E19CB69C_0_0_0;
extern "C" void X509ChainStatus_t9E05BD8700EA6158AC82F71CBE53AD20F6B99B0C_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void X509ChainStatus_t9E05BD8700EA6158AC82F71CBE53AD20F6B99B0C_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void X509ChainStatus_t9E05BD8700EA6158AC82F71CBE53AD20F6B99B0C_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType X509ChainStatus_t9E05BD8700EA6158AC82F71CBE53AD20F6B99B0C_0_0_0;
extern "C" void LowerCaseMapping_t3F087D71A4D7A309FD5492CE33501FD4F4709D7B_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void LowerCaseMapping_t3F087D71A4D7A309FD5492CE33501FD4F4709D7B_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void LowerCaseMapping_t3F087D71A4D7A309FD5492CE33501FD4F4709D7B_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType LowerCaseMapping_t3F087D71A4D7A309FD5492CE33501FD4F4709D7B_0_0_0;
extern "C" void DelegatePInvokeWrapper_AndroidJavaRunnable_tBE7371D29A525C4F51DC1CBEBA5E193644F6AFE1();
extern const RuntimeType AndroidJavaRunnable_tBE7371D29A525C4F51DC1CBEBA5E193644F6AFE1_0_0_0;
extern "C" void AnimationCurve_tD2F265379583AAF1BF8D84F1BB8DB12980FA504C_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AnimationCurve_tD2F265379583AAF1BF8D84F1BB8DB12980FA504C_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AnimationCurve_tD2F265379583AAF1BF8D84F1BB8DB12980FA504C_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AnimationCurve_tD2F265379583AAF1BF8D84F1BB8DB12980FA504C_0_0_0;
extern "C" void DelegatePInvokeWrapper_LogCallback_t73139DDD22E0DAFAB5F0E39D4D9B1522682C4778();
extern const RuntimeType LogCallback_t73139DDD22E0DAFAB5F0E39D4D9B1522682C4778_0_0_0;
extern "C" void DelegatePInvokeWrapper_LowMemoryCallback_t3862486677D10CD16ECDA703CFB75039A4B3AE00();
extern const RuntimeType LowMemoryCallback_t3862486677D10CD16ECDA703CFB75039A4B3AE00_0_0_0;
extern "C" void AsyncOperation_t304C51ABED8AE734CC8DDDFE13013D8D5A44641D_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AsyncOperation_t304C51ABED8AE734CC8DDDFE13013D8D5A44641D_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AsyncOperation_t304C51ABED8AE734CC8DDDFE13013D8D5A44641D_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AsyncOperation_t304C51ABED8AE734CC8DDDFE13013D8D5A44641D_0_0_0;
extern "C" void OrderBlock_t3B2BBCE8320FAEC3DB605F7DC9AB641102F53727_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void OrderBlock_t3B2BBCE8320FAEC3DB605F7DC9AB641102F53727_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void OrderBlock_t3B2BBCE8320FAEC3DB605F7DC9AB641102F53727_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType OrderBlock_t3B2BBCE8320FAEC3DB605F7DC9AB641102F53727_0_0_0;
extern "C" void Coroutine_tAE7DB2FC70A0AE6477F896F852057CB0754F06EC_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Coroutine_tAE7DB2FC70A0AE6477F896F852057CB0754F06EC_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Coroutine_tAE7DB2FC70A0AE6477F896F852057CB0754F06EC_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Coroutine_tAE7DB2FC70A0AE6477F896F852057CB0754F06EC_0_0_0;
extern "C" void CullingGroup_t7F71E48F69794B87C5A7F3F27AD1F1517B2FBF1F_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void CullingGroup_t7F71E48F69794B87C5A7F3F27AD1F1517B2FBF1F_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void CullingGroup_t7F71E48F69794B87C5A7F3F27AD1F1517B2FBF1F_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType CullingGroup_t7F71E48F69794B87C5A7F3F27AD1F1517B2FBF1F_0_0_0;
extern "C" void DelegatePInvokeWrapper_StateChanged_t6B81A48F3E917979B3F56CE50FEEB8E4DE46F161();
extern const RuntimeType StateChanged_t6B81A48F3E917979B3F56CE50FEEB8E4DE46F161_0_0_0;
extern "C" void DelegatePInvokeWrapper_DisplaysUpdatedDelegate_t2FAF995B47D691BD7C5BBC17D533DD8B19BE9A90();
extern const RuntimeType DisplaysUpdatedDelegate_t2FAF995B47D691BD7C5BBC17D533DD8B19BE9A90_0_0_0;
extern "C" void DelegatePInvokeWrapper_UnityAction_tD19B26F1B2C048E38FD5801A33573BE01064CAF4();
extern const RuntimeType UnityAction_tD19B26F1B2C048E38FD5801A33573BE01064CAF4_0_0_0;
extern "C" void PlayerLoopSystem_t89BC6208BDD3B7C57FED7B0201341A7D4E846A6D_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void PlayerLoopSystem_t89BC6208BDD3B7C57FED7B0201341A7D4E846A6D_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void PlayerLoopSystem_t89BC6208BDD3B7C57FED7B0201341A7D4E846A6D_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType PlayerLoopSystem_t89BC6208BDD3B7C57FED7B0201341A7D4E846A6D_0_0_0;
extern "C" void DelegatePInvokeWrapper_UpdateFunction_tE0936D5A5B8C3367F0E6E464162E1FB1E9F304A8();
extern const RuntimeType UpdateFunction_tE0936D5A5B8C3367F0E6E464162E1FB1E9F304A8_0_0_0;
extern "C" void PlayerLoopSystemInternal_tE0D30607A74F1E0D695E5E83717C26308CB5C9E9_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void PlayerLoopSystemInternal_tE0D30607A74F1E0D695E5E83717C26308CB5C9E9_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void PlayerLoopSystemInternal_tE0D30607A74F1E0D695E5E83717C26308CB5C9E9_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType PlayerLoopSystemInternal_tE0D30607A74F1E0D695E5E83717C26308CB5C9E9_0_0_0;
extern "C" void SpriteBone_tD75C1B533C9282AEC369B66DF430C1CAC3C8BEB2_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SpriteBone_tD75C1B533C9282AEC369B66DF430C1CAC3C8BEB2_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SpriteBone_tD75C1B533C9282AEC369B66DF430C1CAC3C8BEB2_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SpriteBone_tD75C1B533C9282AEC369B66DF430C1CAC3C8BEB2_0_0_0;
extern "C" void FailedToLoadScriptObject_tB9D2DBB36BA1E86F2A7392AF112B455206E8E83B_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void FailedToLoadScriptObject_tB9D2DBB36BA1E86F2A7392AF112B455206E8E83B_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void FailedToLoadScriptObject_tB9D2DBB36BA1E86F2A7392AF112B455206E8E83B_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType FailedToLoadScriptObject_tB9D2DBB36BA1E86F2A7392AF112B455206E8E83B_0_0_0;
extern "C" void Gradient_t35A694DDA1066524440E325E582B01E33DE66A3A_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Gradient_t35A694DDA1066524440E325E582B01E33DE66A3A_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Gradient_t35A694DDA1066524440E325E582B01E33DE66A3A_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Gradient_t35A694DDA1066524440E325E582B01E33DE66A3A_0_0_0;
extern "C" void Internal_DrawTextureArguments_t4C3F2D141F43C3EF7D12FEA79BAD68985C0C52AF_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Internal_DrawTextureArguments_t4C3F2D141F43C3EF7D12FEA79BAD68985C0C52AF_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Internal_DrawTextureArguments_t4C3F2D141F43C3EF7D12FEA79BAD68985C0C52AF_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Internal_DrawTextureArguments_t4C3F2D141F43C3EF7D12FEA79BAD68985C0C52AF_0_0_0;
extern "C" void Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_0_0_0;
extern "C" void PlayableBinding_t4D92F4CF16B8608DD83947E5D40CB7690F23F9C8_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void PlayableBinding_t4D92F4CF16B8608DD83947E5D40CB7690F23F9C8_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void PlayableBinding_t4D92F4CF16B8608DD83947E5D40CB7690F23F9C8_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType PlayableBinding_t4D92F4CF16B8608DD83947E5D40CB7690F23F9C8_0_0_0;
extern "C" void DelegatePInvokeWrapper_CreateOutputMethod_tA7B649F49822FC5DD0B0D9F17247C73CAECB1CA3();
extern const RuntimeType CreateOutputMethod_tA7B649F49822FC5DD0B0D9F17247C73CAECB1CA3_0_0_0;
extern "C" void RectOffset_tED44B1176E93501050480416699D1F11BAE8C87A_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void RectOffset_tED44B1176E93501050480416699D1F11BAE8C87A_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void RectOffset_tED44B1176E93501050480416699D1F11BAE8C87A_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType RectOffset_tED44B1176E93501050480416699D1F11BAE8C87A_0_0_0;
extern "C" void ResourceRequest_t22744D420D4DEF7C924A01EB117C0FEC6B07D486_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ResourceRequest_t22744D420D4DEF7C924A01EB117C0FEC6B07D486_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ResourceRequest_t22744D420D4DEF7C924A01EB117C0FEC6B07D486_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ResourceRequest_t22744D420D4DEF7C924A01EB117C0FEC6B07D486_0_0_0;
extern "C" void ScriptableObject_tAB015486CEAB714DA0D5C1BA389B84FB90427734_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ScriptableObject_tAB015486CEAB714DA0D5C1BA389B84FB90427734_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ScriptableObject_tAB015486CEAB714DA0D5C1BA389B84FB90427734_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ScriptableObject_tAB015486CEAB714DA0D5C1BA389B84FB90427734_0_0_0;
extern "C" void HitInfo_t3DDACA0CB28E94463E17542FA7F04245A8AE1C12_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void HitInfo_t3DDACA0CB28E94463E17542FA7F04245A8AE1C12_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void HitInfo_t3DDACA0CB28E94463E17542FA7F04245A8AE1C12_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType HitInfo_t3DDACA0CB28E94463E17542FA7F04245A8AE1C12_0_0_0;
extern "C" void TrackedReference_tE93229EF7055CBB35B2A98DD2493947428D06107_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void TrackedReference_tE93229EF7055CBB35B2A98DD2493947428D06107_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void TrackedReference_tE93229EF7055CBB35B2A98DD2493947428D06107_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType TrackedReference_tE93229EF7055CBB35B2A98DD2493947428D06107_0_0_0;
extern "C" void WorkRequest_t0247B62D135204EAA95FC0B2EC829CB27B433F94_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void WorkRequest_t0247B62D135204EAA95FC0B2EC829CB27B433F94_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void WorkRequest_t0247B62D135204EAA95FC0B2EC829CB27B433F94_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType WorkRequest_t0247B62D135204EAA95FC0B2EC829CB27B433F94_0_0_0;
extern "C" void WaitForSeconds_t3E9E78D3BB53F03F96C7F28BA9B9086CD1A5F4E8_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void WaitForSeconds_t3E9E78D3BB53F03F96C7F28BA9B9086CD1A5F4E8_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void WaitForSeconds_t3E9E78D3BB53F03F96C7F28BA9B9086CD1A5F4E8_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType WaitForSeconds_t3E9E78D3BB53F03F96C7F28BA9B9086CD1A5F4E8_0_0_0;
extern "C" void YieldInstruction_t836035AC7BD07A3C7909F7AD2A5B42DE99D91C44_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void YieldInstruction_t836035AC7BD07A3C7909F7AD2A5B42DE99D91C44_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void YieldInstruction_t836035AC7BD07A3C7909F7AD2A5B42DE99D91C44_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType YieldInstruction_t836035AC7BD07A3C7909F7AD2A5B42DE99D91C44_0_0_0;
extern "C" void Collision_t7FF0F4B0E24A2AEB1131DD980F63AB8CBF11FC3C_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Collision_t7FF0F4B0E24A2AEB1131DD980F63AB8CBF11FC3C_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Collision_t7FF0F4B0E24A2AEB1131DD980F63AB8CBF11FC3C_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Collision_t7FF0F4B0E24A2AEB1131DD980F63AB8CBF11FC3C_0_0_0;
extern "C" void ControllerColliderHit_tB009AA7F769B4A3E988DEF71F4C5A29AB6A38968_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ControllerColliderHit_tB009AA7F769B4A3E988DEF71F4C5A29AB6A38968_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ControllerColliderHit_tB009AA7F769B4A3E988DEF71F4C5A29AB6A38968_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ControllerColliderHit_tB009AA7F769B4A3E988DEF71F4C5A29AB6A38968_0_0_0;
extern "C" void DelegatePInvokeWrapper_FontTextureRebuildCallback_tD700C63BB1A449E3A0464C81701E981677D3021C();
extern const RuntimeType FontTextureRebuildCallback_tD700C63BB1A449E3A0464C81701E981677D3021C_0_0_0;
extern "C" void TextGenerationSettings_t37703542535A1638D2A08F41DB629A483616AF68_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void TextGenerationSettings_t37703542535A1638D2A08F41DB629A483616AF68_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void TextGenerationSettings_t37703542535A1638D2A08F41DB629A483616AF68_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType TextGenerationSettings_t37703542535A1638D2A08F41DB629A483616AF68_0_0_0;
extern "C" void TextGenerator_tD455BE18A64C7DDF854F6DB3CCEBF705121C58A8_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void TextGenerator_tD455BE18A64C7DDF854F6DB3CCEBF705121C58A8_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void TextGenerator_tD455BE18A64C7DDF854F6DB3CCEBF705121C58A8_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType TextGenerator_tD455BE18A64C7DDF854F6DB3CCEBF705121C58A8_0_0_0;
extern "C" void AssetBundleCreateRequest_t8D8FCFC0424680D7B5E04346D932442D5886CD2E_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AssetBundleCreateRequest_t8D8FCFC0424680D7B5E04346D932442D5886CD2E_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AssetBundleCreateRequest_t8D8FCFC0424680D7B5E04346D932442D5886CD2E_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AssetBundleCreateRequest_t8D8FCFC0424680D7B5E04346D932442D5886CD2E_0_0_0;
extern "C" void AssetBundleRecompressOperation_tD941F40367DFE0A376269FCBE02234C5C8E9BFB6_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AssetBundleRecompressOperation_tD941F40367DFE0A376269FCBE02234C5C8E9BFB6_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AssetBundleRecompressOperation_tD941F40367DFE0A376269FCBE02234C5C8E9BFB6_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AssetBundleRecompressOperation_tD941F40367DFE0A376269FCBE02234C5C8E9BFB6_0_0_0;
extern "C" void AssetBundleRequest_tF8897443AF1FC6C3E04911FAA9EDAE89B0A0A962_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AssetBundleRequest_tF8897443AF1FC6C3E04911FAA9EDAE89B0A0A962_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AssetBundleRequest_tF8897443AF1FC6C3E04911FAA9EDAE89B0A0A962_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AssetBundleRequest_tF8897443AF1FC6C3E04911FAA9EDAE89B0A0A962_0_0_0;
extern "C" void DelegatePInvokeWrapper_PCMReaderCallback_t9B87AB13DCD37957B045554BF28A57697E6B8EFB();
extern const RuntimeType PCMReaderCallback_t9B87AB13DCD37957B045554BF28A57697E6B8EFB_0_0_0;
extern "C" void DelegatePInvokeWrapper_PCMSetPositionCallback_t092ED33043C0279B5E4D343EBCBD516CEF260801();
extern const RuntimeType PCMSetPositionCallback_t092ED33043C0279B5E4D343EBCBD516CEF260801_0_0_0;
extern "C" void DelegatePInvokeWrapper_AudioConfigurationChangeHandler_t8E0E05D0198D95B5412DC716F87D97020EF54926();
extern const RuntimeType AudioConfigurationChangeHandler_t8E0E05D0198D95B5412DC716F87D97020EF54926_0_0_0;
extern "C" void DelegatePInvokeWrapper_ConsumeSampleFramesNativeFunction_tC1E0B1BFCF2C3D7F87D66FCFA2022369327D931D();
extern const RuntimeType ConsumeSampleFramesNativeFunction_tC1E0B1BFCF2C3D7F87D66FCFA2022369327D931D_0_0_0;
extern "C" void Event_t187FF6A6B357447B83EC2064823EE0AEC5263210_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Event_t187FF6A6B357447B83EC2064823EE0AEC5263210_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Event_t187FF6A6B357447B83EC2064823EE0AEC5263210_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Event_t187FF6A6B357447B83EC2064823EE0AEC5263210_0_0_0;
extern "C" void DelegatePInvokeWrapper_WindowFunction_t9AF05117863D95AA9F85D497A3B9B53216708100();
extern const RuntimeType WindowFunction_t9AF05117863D95AA9F85D497A3B9B53216708100_0_0_0;
extern "C" void GUIContent_t2A00F8961C69C0A382168840CFB2111FB00B5EA0_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void GUIContent_t2A00F8961C69C0A382168840CFB2111FB00B5EA0_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void GUIContent_t2A00F8961C69C0A382168840CFB2111FB00B5EA0_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType GUIContent_t2A00F8961C69C0A382168840CFB2111FB00B5EA0_0_0_0;
extern "C" void DelegatePInvokeWrapper_SkinChangedDelegate_tAB4CEEA8C8A0BDCFD51C9624AE173C46A40135D8();
extern const RuntimeType SkinChangedDelegate_tAB4CEEA8C8A0BDCFD51C9624AE173C46A40135D8_0_0_0;
extern "C" void GUIStyle_t671F175A201A19166385EE3392292A5F50070572_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void GUIStyle_t671F175A201A19166385EE3392292A5F50070572_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void GUIStyle_t671F175A201A19166385EE3392292A5F50070572_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType GUIStyle_t671F175A201A19166385EE3392292A5F50070572_0_0_0;
extern "C" void GUIStyleState_t2AA5CB82EB2571B0496D1F0B9D29D2B8D8B1E7E5_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void GUIStyleState_t2AA5CB82EB2571B0496D1F0B9D29D2B8D8B1E7E5_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void GUIStyleState_t2AA5CB82EB2571B0496D1F0B9D29D2B8D8B1E7E5_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType GUIStyleState_t2AA5CB82EB2571B0496D1F0B9D29D2B8D8B1E7E5_0_0_0;
extern "C" void SliderHandler_t80CE53884BFA87A9FA360D2862DA4B504BFBEF7C_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SliderHandler_t80CE53884BFA87A9FA360D2862DA4B504BFBEF7C_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SliderHandler_t80CE53884BFA87A9FA360D2862DA4B504BFBEF7C_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SliderHandler_t80CE53884BFA87A9FA360D2862DA4B504BFBEF7C_0_0_0;
extern "C" void Collision2D_t45DC963DE1229CFFC7D0B666800F0AE93688764D_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Collision2D_t45DC963DE1229CFFC7D0B666800F0AE93688764D_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Collision2D_t45DC963DE1229CFFC7D0B666800F0AE93688764D_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Collision2D_t45DC963DE1229CFFC7D0B666800F0AE93688764D_0_0_0;
extern "C" void ContactFilter2D_t1BEAE75CCD5614B40E8AD9031BBD72543E2C37B4_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ContactFilter2D_t1BEAE75CCD5614B40E8AD9031BBD72543E2C37B4_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ContactFilter2D_t1BEAE75CCD5614B40E8AD9031BBD72543E2C37B4_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ContactFilter2D_t1BEAE75CCD5614B40E8AD9031BBD72543E2C37B4_0_0_0;
extern "C" void CertificateHandler_tBD070BF4150A44AB482FD36EA3882C363117E8C0_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void CertificateHandler_tBD070BF4150A44AB482FD36EA3882C363117E8C0_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void CertificateHandler_tBD070BF4150A44AB482FD36EA3882C363117E8C0_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType CertificateHandler_tBD070BF4150A44AB482FD36EA3882C363117E8C0_0_0_0;
extern "C" void DownloadHandler_t4A7802ADC97024B469C87FA454B6973951980EE9_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void DownloadHandler_t4A7802ADC97024B469C87FA454B6973951980EE9_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void DownloadHandler_t4A7802ADC97024B469C87FA454B6973951980EE9_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType DownloadHandler_t4A7802ADC97024B469C87FA454B6973951980EE9_0_0_0;
extern "C" void DownloadHandlerBuffer_tF6A73B82C9EC807D36B904A58E1DF2DDA696B255_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void DownloadHandlerBuffer_tF6A73B82C9EC807D36B904A58E1DF2DDA696B255_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void DownloadHandlerBuffer_tF6A73B82C9EC807D36B904A58E1DF2DDA696B255_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType DownloadHandlerBuffer_tF6A73B82C9EC807D36B904A58E1DF2DDA696B255_0_0_0;
extern "C" void UnityWebRequest_t9120F5A2C7D43B936B49C0B7E4CA54C822689129_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void UnityWebRequest_t9120F5A2C7D43B936B49C0B7E4CA54C822689129_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void UnityWebRequest_t9120F5A2C7D43B936B49C0B7E4CA54C822689129_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType UnityWebRequest_t9120F5A2C7D43B936B49C0B7E4CA54C822689129_0_0_0;
extern "C" void UnityWebRequestAsyncOperation_t726E134F16701A2671D40BEBE22110DC57156353_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void UnityWebRequestAsyncOperation_t726E134F16701A2671D40BEBE22110DC57156353_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void UnityWebRequestAsyncOperation_t726E134F16701A2671D40BEBE22110DC57156353_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType UnityWebRequestAsyncOperation_t726E134F16701A2671D40BEBE22110DC57156353_0_0_0;
extern "C" void UploadHandler_t24F4097D30A1E7C689D8881A27F251B4741601E4_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void UploadHandler_t24F4097D30A1E7C689D8881A27F251B4741601E4_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void UploadHandler_t24F4097D30A1E7C689D8881A27F251B4741601E4_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType UploadHandler_t24F4097D30A1E7C689D8881A27F251B4741601E4_0_0_0;
extern "C" void UploadHandlerRaw_t9E6A69B7726F134F31F6744F5EFDF611E7C54F27_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void UploadHandlerRaw_t9E6A69B7726F134F31F6744F5EFDF611E7C54F27_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void UploadHandlerRaw_t9E6A69B7726F134F31F6744F5EFDF611E7C54F27_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType UploadHandlerRaw_t9E6A69B7726F134F31F6744F5EFDF611E7C54F27_0_0_0;
extern "C" void IntegratedSubsystem_tF67A736CD38F3A64A40687C90024FA7326AF7D86_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void IntegratedSubsystem_tF67A736CD38F3A64A40687C90024FA7326AF7D86_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void IntegratedSubsystem_tF67A736CD38F3A64A40687C90024FA7326AF7D86_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType IntegratedSubsystem_tF67A736CD38F3A64A40687C90024FA7326AF7D86_0_0_0;
extern "C" void IntegratedSubsystemDescriptor_tD52D7E7BD7FFA6121E7AAC6FE3E1CCB2C671E8C0_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void IntegratedSubsystemDescriptor_tD52D7E7BD7FFA6121E7AAC6FE3E1CCB2C671E8C0_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void IntegratedSubsystemDescriptor_tD52D7E7BD7FFA6121E7AAC6FE3E1CCB2C671E8C0_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType IntegratedSubsystemDescriptor_tD52D7E7BD7FFA6121E7AAC6FE3E1CCB2C671E8C0_0_0_0;
extern "C" void FrameReceivedEventArgs_t4637B6D2FC28197602B18C1815C4A778645479DD_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void FrameReceivedEventArgs_t4637B6D2FC28197602B18C1815C4A778645479DD_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void FrameReceivedEventArgs_t4637B6D2FC28197602B18C1815C4A778645479DD_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType FrameReceivedEventArgs_t4637B6D2FC28197602B18C1815C4A778645479DD_0_0_0;
extern "C" void MeshGenerationResult_t24F21E71F8F697D7D216BA4F3F064FB5434E6056_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void MeshGenerationResult_t24F21E71F8F697D7D216BA4F3F064FB5434E6056_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void MeshGenerationResult_t24F21E71F8F697D7D216BA4F3F064FB5434E6056_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType MeshGenerationResult_t24F21E71F8F697D7D216BA4F3F064FB5434E6056_0_0_0;
extern "C" void PlaneAddedEventArgs_t06BF8697BA4D8CD3A8C9AB8DF51F8D01D2910002_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void PlaneAddedEventArgs_t06BF8697BA4D8CD3A8C9AB8DF51F8D01D2910002_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void PlaneAddedEventArgs_t06BF8697BA4D8CD3A8C9AB8DF51F8D01D2910002_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType PlaneAddedEventArgs_t06BF8697BA4D8CD3A8C9AB8DF51F8D01D2910002_0_0_0;
extern "C" void PlaneRemovedEventArgs_t21E9C5879A8317E5F72263ED2235116F609E4C6A_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void PlaneRemovedEventArgs_t21E9C5879A8317E5F72263ED2235116F609E4C6A_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void PlaneRemovedEventArgs_t21E9C5879A8317E5F72263ED2235116F609E4C6A_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType PlaneRemovedEventArgs_t21E9C5879A8317E5F72263ED2235116F609E4C6A_0_0_0;
extern "C" void PlaneUpdatedEventArgs_tD63FB1655000C0BC238033545144C1FD81CED133_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void PlaneUpdatedEventArgs_tD63FB1655000C0BC238033545144C1FD81CED133_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void PlaneUpdatedEventArgs_tD63FB1655000C0BC238033545144C1FD81CED133_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType PlaneUpdatedEventArgs_tD63FB1655000C0BC238033545144C1FD81CED133_0_0_0;
extern "C" void PointCloudUpdatedEventArgs_tE7E1E32A6042806B927B110250C0D4FE755C6B07_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void PointCloudUpdatedEventArgs_tE7E1E32A6042806B927B110250C0D4FE755C6B07_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void PointCloudUpdatedEventArgs_tE7E1E32A6042806B927B110250C0D4FE755C6B07_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType PointCloudUpdatedEventArgs_tE7E1E32A6042806B927B110250C0D4FE755C6B07_0_0_0;
extern "C" void SessionTrackingStateChangedEventArgs_tE4B00077E5AAE143593A0BB3FA2C57237525E7BA_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SessionTrackingStateChangedEventArgs_tE4B00077E5AAE143593A0BB3FA2C57237525E7BA_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SessionTrackingStateChangedEventArgs_tE4B00077E5AAE143593A0BB3FA2C57237525E7BA_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SessionTrackingStateChangedEventArgs_tE4B00077E5AAE143593A0BB3FA2C57237525E7BA_0_0_0;
extern "C" void DelegatePInvokeWrapper_OnNavMeshPreUpdate_tA3A16B3CAFF83530076BF839EA5699AAAD6C6353();
extern const RuntimeType OnNavMeshPreUpdate_tA3A16B3CAFF83530076BF839EA5699AAAD6C6353_0_0_0;
extern "C" void AnimationEvent_tEDD4E45FEA5CA4657CBBF1E0CFF657191D90673F_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AnimationEvent_tEDD4E45FEA5CA4657CBBF1E0CFF657191D90673F_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AnimationEvent_tEDD4E45FEA5CA4657CBBF1E0CFF657191D90673F_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AnimationEvent_tEDD4E45FEA5CA4657CBBF1E0CFF657191D90673F_0_0_0;
extern "C" void AnimatorControllerParameter_t63F7756B07B981111CB00490DE84B06BC2A25E68_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AnimatorControllerParameter_t63F7756B07B981111CB00490DE84B06BC2A25E68_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AnimatorControllerParameter_t63F7756B07B981111CB00490DE84B06BC2A25E68_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AnimatorControllerParameter_t63F7756B07B981111CB00490DE84B06BC2A25E68_0_0_0;
extern "C" void DelegatePInvokeWrapper_OnOverrideControllerDirtyCallback_t73560E6E30067C09BC58A15F9D2726051B077E2E();
extern const RuntimeType OnOverrideControllerDirtyCallback_t73560E6E30067C09BC58A15F9D2726051B077E2E_0_0_0;
extern "C" void AnimatorTransitionInfo_t66D37578B8898C817BD5A5781B420BF92F60AA6B_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void AnimatorTransitionInfo_t66D37578B8898C817BD5A5781B420BF92F60AA6B_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void AnimatorTransitionInfo_t66D37578B8898C817BD5A5781B420BF92F60AA6B_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType AnimatorTransitionInfo_t66D37578B8898C817BD5A5781B420BF92F60AA6B_0_0_0;
extern "C" void HumanBone_t2CE168CF8638CEABF48FB7B7CCF77BBE0CECF995_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void HumanBone_t2CE168CF8638CEABF48FB7B7CCF77BBE0CECF995_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void HumanBone_t2CE168CF8638CEABF48FB7B7CCF77BBE0CECF995_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType HumanBone_t2CE168CF8638CEABF48FB7B7CCF77BBE0CECF995_0_0_0;
extern "C" void SkeletonBone_tCDF297229129311214294465F3FA353DB09726F5_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SkeletonBone_tCDF297229129311214294465F3FA353DB09726F5_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SkeletonBone_tCDF297229129311214294465F3FA353DB09726F5_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SkeletonBone_tCDF297229129311214294465F3FA353DB09726F5_0_0_0;
extern "C" void GcAchievementData_t5CBCF44628981C91C76C552716A7D551670DCE55_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void GcAchievementData_t5CBCF44628981C91C76C552716A7D551670DCE55_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void GcAchievementData_t5CBCF44628981C91C76C552716A7D551670DCE55_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType GcAchievementData_t5CBCF44628981C91C76C552716A7D551670DCE55_0_0_0;
extern "C" void GcAchievementDescriptionData_t12849233B11B5241066E0D33B3681C2352CAF0A0_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void GcAchievementDescriptionData_t12849233B11B5241066E0D33B3681C2352CAF0A0_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void GcAchievementDescriptionData_t12849233B11B5241066E0D33B3681C2352CAF0A0_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType GcAchievementDescriptionData_t12849233B11B5241066E0D33B3681C2352CAF0A0_0_0_0;
extern "C" void GcLeaderboard_t363887C9C2BFA6F02D08CC6F6BB93E8ABE9A42D2_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void GcLeaderboard_t363887C9C2BFA6F02D08CC6F6BB93E8ABE9A42D2_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void GcLeaderboard_t363887C9C2BFA6F02D08CC6F6BB93E8ABE9A42D2_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType GcLeaderboard_t363887C9C2BFA6F02D08CC6F6BB93E8ABE9A42D2_0_0_0;
extern "C" void GcScoreData_t45EF6CC4038C34CE5823D33D1978C5A3F2E0D09A_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void GcScoreData_t45EF6CC4038C34CE5823D33D1978C5A3F2E0D09A_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void GcScoreData_t45EF6CC4038C34CE5823D33D1978C5A3F2E0D09A_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType GcScoreData_t45EF6CC4038C34CE5823D33D1978C5A3F2E0D09A_0_0_0;
extern "C" void GcUserProfileData_tDCEBF6CF74E9EBC0B9F9847CE96118169391B57D_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void GcUserProfileData_tDCEBF6CF74E9EBC0B9F9847CE96118169391B57D_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void GcUserProfileData_tDCEBF6CF74E9EBC0B9F9847CE96118169391B57D_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType GcUserProfileData_tDCEBF6CF74E9EBC0B9F9847CE96118169391B57D_0_0_0;
extern "C" void DelegatePInvokeWrapper_NativeUpdateCallback_tCC4B5A2692C21C00FC2FC1E4EC5280E98423B8D5();
extern const RuntimeType NativeUpdateCallback_tCC4B5A2692C21C00FC2FC1E4EC5280E98423B8D5_0_0_0;
extern "C" void EmitParams_t03557E552852EC6B71876CD05C4098733702A219_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void EmitParams_t03557E552852EC6B71876CD05C4098733702A219_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void EmitParams_t03557E552852EC6B71876CD05C4098733702A219_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType EmitParams_t03557E552852EC6B71876CD05C4098733702A219_0_0_0;
extern "C" void MainModule_t99C675667E0A363368324132DFA34B27FFEE6FC7_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void MainModule_t99C675667E0A363368324132DFA34B27FFEE6FC7_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void MainModule_t99C675667E0A363368324132DFA34B27FFEE6FC7_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType MainModule_t99C675667E0A363368324132DFA34B27FFEE6FC7_0_0_0;
extern "C" void TextureSheetAnimationModule_t2F7A981851D997DFEB56E31A73824CA8595A96BD_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void TextureSheetAnimationModule_t2F7A981851D997DFEB56E31A73824CA8595A96BD_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void TextureSheetAnimationModule_t2F7A981851D997DFEB56E31A73824CA8595A96BD_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType TextureSheetAnimationModule_t2F7A981851D997DFEB56E31A73824CA8595A96BD_0_0_0;
extern "C" void TileAnimationData_t2A9C81AD1F3E916C2DE292A6F3953FC8C38EFDA8_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void TileAnimationData_t2A9C81AD1F3E916C2DE292A6F3953FC8C38EFDA8_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void TileAnimationData_t2A9C81AD1F3E916C2DE292A6F3953FC8C38EFDA8_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType TileAnimationData_t2A9C81AD1F3E916C2DE292A6F3953FC8C38EFDA8_0_0_0;
extern "C" void TileData_t8A50A35CAFD87C12E27D7E596D968C9114A4CBB5_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void TileData_t8A50A35CAFD87C12E27D7E596D968C9114A4CBB5_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void TileData_t8A50A35CAFD87C12E27D7E596D968C9114A4CBB5_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType TileData_t8A50A35CAFD87C12E27D7E596D968C9114A4CBB5_0_0_0;
extern "C" void DelegatePInvokeWrapper_WillRenderCanvases_tBD5AD090B5938021DEAA679A5AEEA790F60A8BEE();
extern const RuntimeType WillRenderCanvases_tBD5AD090B5938021DEAA679A5AEEA790F60A8BEE_0_0_0;
extern "C" void ConnectionConfigInternal_t442D383D4EE17B207D66709528D4C68FE979E97B_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ConnectionConfigInternal_t442D383D4EE17B207D66709528D4C68FE979E97B_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ConnectionConfigInternal_t442D383D4EE17B207D66709528D4C68FE979E97B_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ConnectionConfigInternal_t442D383D4EE17B207D66709528D4C68FE979E97B_0_0_0;
extern "C" void DelegatePInvokeWrapper_BasicResponseDelegate_t8187C8191D81C2DDE9FFEFCBEF4197628151DF66();
extern const RuntimeType BasicResponseDelegate_t8187C8191D81C2DDE9FFEFCBEF4197628151DF66_0_0_0;
extern "C" void Analytics_tCA6E11F003D5B8AD0A5F0780BF5954566C7EB724_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Analytics_tCA6E11F003D5B8AD0A5F0780BF5954566C7EB724_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Analytics_tCA6E11F003D5B8AD0A5F0780BF5954566C7EB724_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Analytics_tCA6E11F003D5B8AD0A5F0780BF5954566C7EB724_0_0_0;
extern "C" void DelegatePInvokeWrapper_SessionStateChanged_t9084549A636BD45086D66CC6765DA8C3DD31066F();
extern const RuntimeType SessionStateChanged_t9084549A636BD45086D66CC6765DA8C3DD31066F_0_0_0;
extern "C" void CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37_0_0_0;
extern "C" void RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A_0_0_0;
extern "C" void DelegatePInvokeWrapper_UpdatedEventHandler_tB0230BC83686D7126AB4D3800A66351028CA514F();
extern const RuntimeType UpdatedEventHandler_tB0230BC83686D7126AB4D3800A66351028CA514F_0_0_0;
extern "C" void VFXEventAttribute_t8FE74C5425505C55B4F79299C569CCE1A47BE325_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void VFXEventAttribute_t8FE74C5425505C55B4F79299C569CCE1A47BE325_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void VFXEventAttribute_t8FE74C5425505C55B4F79299C569CCE1A47BE325_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType VFXEventAttribute_t8FE74C5425505C55B4F79299C569CCE1A47BE325_0_0_0;
extern "C" void VFXExpressionValues_tBEEC793A9CD5134400899D1AAE1ABF13AF6562F2_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void VFXExpressionValues_tBEEC793A9CD5134400899D1AAE1ABF13AF6562F2_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void VFXExpressionValues_tBEEC793A9CD5134400899D1AAE1ABF13AF6562F2_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType VFXExpressionValues_tBEEC793A9CD5134400899D1AAE1ABF13AF6562F2_0_0_0;
extern "C" void VFXSpawnerState_t614A1AADC2EDB20E82A625BE053A22DB31D89AC7_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void VFXSpawnerState_t614A1AADC2EDB20E82A625BE053A22DB31D89AC7_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void VFXSpawnerState_t614A1AADC2EDB20E82A625BE053A22DB31D89AC7_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType VFXSpawnerState_t614A1AADC2EDB20E82A625BE053A22DB31D89AC7_0_0_0;
extern "C" void DelegatePInvokeWrapper_UnityPurchasingCallback_tF3081DE4B67FBD9771C293C52885EC15C279810C();
extern const RuntimeType UnityPurchasingCallback_tF3081DE4B67FBD9771C293C52885EC15C279810C_0_0_0;
extern "C" void NumberBuffer_t523F9CCA824CB72F54893DDB17C47553B942A2F8_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void NumberBuffer_t523F9CCA824CB72F54893DDB17C47553B942A2F8_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void NumberBuffer_t523F9CCA824CB72F54893DDB17C47553B942A2F8_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType NumberBuffer_t523F9CCA824CB72F54893DDB17C47553B942A2F8_0_0_0;
extern "C" void BigNumberBuffer_t9F40EEF6DD8AB26815DE5A7B877478BA0EB7E1BE_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void BigNumberBuffer_t9F40EEF6DD8AB26815DE5A7B877478BA0EB7E1BE_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void BigNumberBuffer_t9F40EEF6DD8AB26815DE5A7B877478BA0EB7E1BE_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType BigNumberBuffer_t9F40EEF6DD8AB26815DE5A7B877478BA0EB7E1BE_0_0_0;
extern "C" void DelegatePInvokeWrapper_OnChangeCallback_tFEBD666F7C9F71FC3D5DB3647CDA057E5A1CAC63();
extern const RuntimeType OnChangeCallback_tFEBD666F7C9F71FC3D5DB3647CDA057E5A1CAC63_0_0_0;
extern "C" void SchemaInfo_t2D049DAB3BE8BB8A771550C703D63474924D9921_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SchemaInfo_t2D049DAB3BE8BB8A771550C703D63474924D9921_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SchemaInfo_t2D049DAB3BE8BB8A771550C703D63474924D9921_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SchemaInfo_t2D049DAB3BE8BB8A771550C703D63474924D9921_0_0_0;
extern "C" void ColumnError_t24D74F834948955F6EC5949F7D308787C8AE77C3_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ColumnError_t24D74F834948955F6EC5949F7D308787C8AE77C3_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ColumnError_t24D74F834948955F6EC5949F7D308787C8AE77C3_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ColumnError_t24D74F834948955F6EC5949F7D308787C8AE77C3_0_0_0;
extern "C" void DataKey_tCD4DE54A5F9CE06F835061308FC04C1ADEE23B2B_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void DataKey_tCD4DE54A5F9CE06F835061308FC04C1ADEE23B2B_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void DataKey_tCD4DE54A5F9CE06F835061308FC04C1ADEE23B2B_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType DataKey_tCD4DE54A5F9CE06F835061308FC04C1ADEE23B2B_0_0_0;
extern "C" void DSRowDiffIdUsageSection_t25F76FD76EED1640B7E237B8949AB8FDBB0C627B_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void DSRowDiffIdUsageSection_t25F76FD76EED1640B7E237B8949AB8FDBB0C627B_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void DSRowDiffIdUsageSection_t25F76FD76EED1640B7E237B8949AB8FDBB0C627B_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType DSRowDiffIdUsageSection_t25F76FD76EED1640B7E237B8949AB8FDBB0C627B_0_0_0;
extern "C" void RowDiffIdUsageSection_t18F9526B89CAEC918AA011882C3730D5ABBB9F49_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void RowDiffIdUsageSection_t18F9526B89CAEC918AA011882C3730D5ABBB9F49_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void RowDiffIdUsageSection_t18F9526B89CAEC918AA011882C3730D5ABBB9F49_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType RowDiffIdUsageSection_t18F9526B89CAEC918AA011882C3730D5ABBB9F49_0_0_0;
extern "C" void ReservedWords_t4A019A68B07A6165275A53E7F8C9CA3DA7D39837_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ReservedWords_t4A019A68B07A6165275A53E7F8C9CA3DA7D39837_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ReservedWords_t4A019A68B07A6165275A53E7F8C9CA3DA7D39837_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ReservedWords_t4A019A68B07A6165275A53E7F8C9CA3DA7D39837_0_0_0;
extern "C" void IndexField_t8AA3B4B340507FBDDC4826EDA70F86CCA3E0CE23_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void IndexField_t8AA3B4B340507FBDDC4826EDA70F86CCA3E0CE23_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void IndexField_t8AA3B4B340507FBDDC4826EDA70F86CCA3E0CE23_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType IndexField_t8AA3B4B340507FBDDC4826EDA70F86CCA3E0CE23_0_0_0;
extern "C" void Range_tBD1B3028D3E83275591B483FAAC93C8A23DF4E00_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Range_tBD1B3028D3E83275591B483FAAC93C8A23DF4E00_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Range_tBD1B3028D3E83275591B483FAAC93C8A23DF4E00_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Range_tBD1B3028D3E83275591B483FAAC93C8A23DF4E00_0_0_0;
extern "C" void SqlByte_tE6ADE9170D3F24E713655AD509DF9ACF7EDF5D60_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SqlByte_tE6ADE9170D3F24E713655AD509DF9ACF7EDF5D60_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SqlByte_tE6ADE9170D3F24E713655AD509DF9ACF7EDF5D60_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SqlByte_tE6ADE9170D3F24E713655AD509DF9ACF7EDF5D60_0_0_0;
extern "C" void SqlDateTime_t88C29083A1080E1FEBFE04250DB71BD1BEAC21B6_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SqlDateTime_t88C29083A1080E1FEBFE04250DB71BD1BEAC21B6_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SqlDateTime_t88C29083A1080E1FEBFE04250DB71BD1BEAC21B6_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SqlDateTime_t88C29083A1080E1FEBFE04250DB71BD1BEAC21B6_0_0_0;
extern "C" void SqlDouble_tE8F480EB5A508F211DF027033077AAD495085AD3_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SqlDouble_tE8F480EB5A508F211DF027033077AAD495085AD3_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SqlDouble_tE8F480EB5A508F211DF027033077AAD495085AD3_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SqlDouble_tE8F480EB5A508F211DF027033077AAD495085AD3_0_0_0;
extern "C" void SqlInt16_t4BDD94EC1FE5FFDDB0E5C1E816F12DC03D897868_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SqlInt16_t4BDD94EC1FE5FFDDB0E5C1E816F12DC03D897868_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SqlInt16_t4BDD94EC1FE5FFDDB0E5C1E816F12DC03D897868_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SqlInt16_t4BDD94EC1FE5FFDDB0E5C1E816F12DC03D897868_0_0_0;
extern "C" void SqlInt32_tA53F3E3847008FF7C15F2A2043BBDE6800C81F78_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SqlInt32_tA53F3E3847008FF7C15F2A2043BBDE6800C81F78_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SqlInt32_tA53F3E3847008FF7C15F2A2043BBDE6800C81F78_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SqlInt32_tA53F3E3847008FF7C15F2A2043BBDE6800C81F78_0_0_0;
extern "C" void SqlInt64_tFE4BADAABAE9E38BE4CFFC3FFF5ED3544A8E1612_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SqlInt64_tFE4BADAABAE9E38BE4CFFC3FFF5ED3544A8E1612_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SqlInt64_tFE4BADAABAE9E38BE4CFFC3FFF5ED3544A8E1612_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SqlInt64_tFE4BADAABAE9E38BE4CFFC3FFF5ED3544A8E1612_0_0_0;
extern "C" void SqlMoney_tE28D6EE20627835412ABEA9A26513F16A1C34C67_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SqlMoney_tE28D6EE20627835412ABEA9A26513F16A1C34C67_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SqlMoney_tE28D6EE20627835412ABEA9A26513F16A1C34C67_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SqlMoney_tE28D6EE20627835412ABEA9A26513F16A1C34C67_0_0_0;
extern "C" void SqlSingle_t4300B130B28611DF2331C8A6FE105EC9BAE75CD0_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SqlSingle_t4300B130B28611DF2331C8A6FE105EC9BAE75CD0_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SqlSingle_t4300B130B28611DF2331C8A6FE105EC9BAE75CD0_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SqlSingle_t4300B130B28611DF2331C8A6FE105EC9BAE75CD0_0_0_0;
extern "C" void SqlString_t54E2DCD6922BD82058A86F08813770E597FC14E3_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SqlString_t54E2DCD6922BD82058A86F08813770E597FC14E3_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SqlString_t54E2DCD6922BD82058A86F08813770E597FC14E3_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SqlString_t54E2DCD6922BD82058A86F08813770E597FC14E3_0_0_0;
extern "C" void DelegatePInvokeWrapper_UnityNativePurchasingCallback_t58A016E25D4C5E8E9C7709A2EE87766ED4D02136();
extern const RuntimeType UnityNativePurchasingCallback_t58A016E25D4C5E8E9C7709A2EE87766ED4D02136_0_0_0;
extern "C" void RaycastResult_t991BCED43A91EDD8580F39631DA07B1F88C58B91_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void RaycastResult_t991BCED43A91EDD8580F39631DA07B1F88C58B91_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void RaycastResult_t991BCED43A91EDD8580F39631DA07B1F88C58B91_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType RaycastResult_t991BCED43A91EDD8580F39631DA07B1F88C58B91_0_0_0;
extern "C" void ColorTween_t4CBBF5875FA391053DB62E98D8D9603040413228_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ColorTween_t4CBBF5875FA391053DB62E98D8D9603040413228_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ColorTween_t4CBBF5875FA391053DB62E98D8D9603040413228_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ColorTween_t4CBBF5875FA391053DB62E98D8D9603040413228_0_0_0;
extern "C" void FloatTween_tF6BB24C266F36BD80E20C91AED453F7CE516919A_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void FloatTween_tF6BB24C266F36BD80E20C91AED453F7CE516919A_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void FloatTween_tF6BB24C266F36BD80E20C91AED453F7CE516919A_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType FloatTween_tF6BB24C266F36BD80E20C91AED453F7CE516919A_0_0_0;
extern "C" void Resources_t0D3248037D186E6B8BB5CF2BD1EB021CF3E6DEE4_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Resources_t0D3248037D186E6B8BB5CF2BD1EB021CF3E6DEE4_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Resources_t0D3248037D186E6B8BB5CF2BD1EB021CF3E6DEE4_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Resources_t0D3248037D186E6B8BB5CF2BD1EB021CF3E6DEE4_0_0_0;
extern "C" void DelegatePInvokeWrapper_OnValidateInput_t3E857B491A319A5B22F6AD3D02CFD22C1BBFD8D0();
extern const RuntimeType OnValidateInput_t3E857B491A319A5B22F6AD3D02CFD22C1BBFD8D0_0_0_0;
extern "C" void Navigation_t761250C05C09773B75F5E0D52DDCBBFE60288A07_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Navigation_t761250C05C09773B75F5E0D52DDCBBFE60288A07_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Navigation_t761250C05C09773B75F5E0D52DDCBBFE60288A07_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Navigation_t761250C05C09773B75F5E0D52DDCBBFE60288A07_0_0_0;
extern "C" void DelegatePInvokeWrapper_GetRayIntersectionAllCallback_t68C2581CCF05E868297EBD3F3361274954845095();
extern const RuntimeType GetRayIntersectionAllCallback_t68C2581CCF05E868297EBD3F3361274954845095_0_0_0;
extern "C" void DelegatePInvokeWrapper_GetRayIntersectionAllNonAllocCallback_tAD7508D45DB6679B6394983579AD18D967CC2AD4();
extern const RuntimeType GetRayIntersectionAllNonAllocCallback_tAD7508D45DB6679B6394983579AD18D967CC2AD4_0_0_0;
extern "C" void DelegatePInvokeWrapper_GetRaycastNonAllocCallback_tC13D9767CFF00EAB26E9FCC4BDD505F0721A2B4D();
extern const RuntimeType GetRaycastNonAllocCallback_tC13D9767CFF00EAB26E9FCC4BDD505F0721A2B4D_0_0_0;
extern "C" void DelegatePInvokeWrapper_Raycast2DCallback_tE99ABF9ABC3A380677949E8C05A3E477889B82BE();
extern const RuntimeType Raycast2DCallback_tE99ABF9ABC3A380677949E8C05A3E477889B82BE_0_0_0;
extern "C" void DelegatePInvokeWrapper_Raycast3DCallback_t83483916473C9710AEDB316A65CBE62C58935C5F();
extern const RuntimeType Raycast3DCallback_t83483916473C9710AEDB316A65CBE62C58935C5F_0_0_0;
extern "C" void DelegatePInvokeWrapper_RaycastAllCallback_t751407A44270E02FAA43D0846A58EE6A8C4AE1CE();
extern const RuntimeType RaycastAllCallback_t751407A44270E02FAA43D0846A58EE6A8C4AE1CE_0_0_0;
extern "C" void SpriteState_t58B9DD66A79CD69AB4CFC3AD0C41E45DC2192C0A_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SpriteState_t58B9DD66A79CD69AB4CFC3AD0C41E45DC2192C0A_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SpriteState_t58B9DD66A79CD69AB4CFC3AD0C41E45DC2192C0A_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SpriteState_t58B9DD66A79CD69AB4CFC3AD0C41E45DC2192C0A_0_0_0;
extern "C" void DelegatePInvokeWrapper_OnDLLLoaded_tAF568D819FCD091C003142925B7CE144C63DCA1B();
extern const RuntimeType OnDLLLoaded_tAF568D819FCD091C003142925B7CE144C63DCA1B_0_0_0;
extern "C" void DelegatePInvokeWrapper_HideUnityDelegate_tE5AD84D37D94FD7829357528123F1DB1061CBB0F();
extern const RuntimeType HideUnityDelegate_tE5AD84D37D94FD7829357528123F1DB1061CBB0F_0_0_0;
extern "C" void DelegatePInvokeWrapper_InitDelegate_tC8A60730C250DA905E53C3B2E9A16F0EC9498F31();
extern const RuntimeType InitDelegate_tC8A60730C250DA905E53C3B2E9A16F0EC9498F31_0_0_0;
extern "C" void DelegatePInvokeWrapper_SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22();
extern const RuntimeType SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22_0_0_0;
extern "C" void DelegatePInvokeWrapper_SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B();
extern const RuntimeType SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B_0_0_0;
extern "C" void DelegatePInvokeWrapper_SQLiteCommitCallback_t4A2F244F9FCADC58BAEFCDB1F9A4AEA018294B4F();
extern const RuntimeType SQLiteCommitCallback_t4A2F244F9FCADC58BAEFCDB1F9A4AEA018294B4F_0_0_0;
extern "C" void DelegatePInvokeWrapper_SQLiteFinalCallback_tDADE001E38D3B50F9259C9D956A11D3B4D875453();
extern const RuntimeType SQLiteFinalCallback_tDADE001E38D3B50F9259C9D956A11D3B4D875453_0_0_0;
extern "C" void DelegatePInvokeWrapper_SQLiteRollbackCallback_t0879E30A50B184087AFBA2EC348DAF30A4646D8A();
extern const RuntimeType SQLiteRollbackCallback_t0879E30A50B184087AFBA2EC348DAF30A4646D8A_0_0_0;
extern "C" void SQLiteTypeNames_tCB9EBCDDD03CE6495A5CA9DB9C5B91FE66BB8B0F_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void SQLiteTypeNames_tCB9EBCDDD03CE6495A5CA9DB9C5B91FE66BB8B0F_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void SQLiteTypeNames_tCB9EBCDDD03CE6495A5CA9DB9C5B91FE66BB8B0F_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType SQLiteTypeNames_tCB9EBCDDD03CE6495A5CA9DB9C5B91FE66BB8B0F_0_0_0;
extern "C" void DelegatePInvokeWrapper_SQLiteUpdateCallback_t3252735A38A0D75E6E9CB742FBFB194CD942712F();
extern const RuntimeType SQLiteUpdateCallback_t3252735A38A0D75E6E9CB742FBFB194CD942712F_0_0_0;
extern "C" void KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC_0_0_0;
extern "C" void DelegatePInvokeWrapper_unityAdsBannerClick_t8F2B887BAF928A1DF8F8E0CF5B87713FF3ABC32E();
extern const RuntimeType unityAdsBannerClick_t8F2B887BAF928A1DF8F8E0CF5B87713FF3ABC32E_0_0_0;
extern "C" void DelegatePInvokeWrapper_unityAdsBannerError_t3435EC218C4E75B7B16D343D8C0B42EABF865582();
extern const RuntimeType unityAdsBannerError_t3435EC218C4E75B7B16D343D8C0B42EABF865582_0_0_0;
extern "C" void DelegatePInvokeWrapper_unityAdsBannerHide_t9EC0D722659D6A7CE6DFC32266580E291D71FE38();
extern const RuntimeType unityAdsBannerHide_t9EC0D722659D6A7CE6DFC32266580E291D71FE38_0_0_0;
extern "C" void DelegatePInvokeWrapper_unityAdsBannerLoad_tF0E1DAC48BC4DE378A6B59DFE0703533F0428A3A();
extern const RuntimeType unityAdsBannerLoad_tF0E1DAC48BC4DE378A6B59DFE0703533F0428A3A_0_0_0;
extern "C" void DelegatePInvokeWrapper_unityAdsBannerShow_t4522189E90DC4FD255574AD403FBEC003522F593();
extern const RuntimeType unityAdsBannerShow_t4522189E90DC4FD255574AD403FBEC003522F593_0_0_0;
extern "C" void DelegatePInvokeWrapper_unityAdsBannerUnload_tA6E54A057FA4B8FCFD61C42B82ACBF2E7423A1A0();
extern const RuntimeType unityAdsBannerUnload_tA6E54A057FA4B8FCFD61C42B82ACBF2E7423A1A0_0_0_0;
extern "C" void DelegatePInvokeWrapper_ErrorCallback_t3CEC714BB3F6AD7FCBB4D6C54706A97AA7C512E7();
extern const RuntimeType ErrorCallback_t3CEC714BB3F6AD7FCBB4D6C54706A97AA7C512E7_0_0_0;
extern "C" void DelegatePInvokeWrapper_LoadCallback_tCBBAB2E31C3EFD41C203210652E34DF84B65C88B();
extern const RuntimeType LoadCallback_tCBBAB2E31C3EFD41C203210652E34DF84B65C88B_0_0_0;
extern "C" void DelegatePInvokeWrapper_BannerCallback_t802365DBFC08D767D12D99D72BF668E07EDE5EB6();
extern const RuntimeType BannerCallback_t802365DBFC08D767D12D99D72BF668E07EDE5EB6_0_0_0;
extern "C" void DelegatePInvokeWrapper_unityAdsDidError_tB860C08AEB1B516A0F53E6F6BC9985FFC516B56A();
extern const RuntimeType unityAdsDidError_tB860C08AEB1B516A0F53E6F6BC9985FFC516B56A_0_0_0;
extern "C" void DelegatePInvokeWrapper_unityAdsDidFinish_t59DC1F5EA6E1771A80EC9B06BE941A7947323E41();
extern const RuntimeType unityAdsDidFinish_t59DC1F5EA6E1771A80EC9B06BE941A7947323E41_0_0_0;
extern "C" void DelegatePInvokeWrapper_unityAdsDidStart_t88F5E9F8951465F4CA4AE7B5E50752B4310F4066();
extern const RuntimeType unityAdsDidStart_t88F5E9F8951465F4CA4AE7B5E50752B4310F4066_0_0_0;
extern "C" void DelegatePInvokeWrapper_unityAdsReady_t9DD2598EDDEB8A66AEA565E66348E68FBAAC7A42();
extern const RuntimeType unityAdsReady_t9DD2598EDDEB8A66AEA565E66348E68FBAAC7A42_0_0_0;
extern "C" void DelegatePInvokeWrapper_unityAdsPurchasingDidInitiatePurchasingCommand_t759E05AD4B853DEA5F3728EF572321D9239FCF89();
extern const RuntimeType unityAdsPurchasingDidInitiatePurchasingCommand_t759E05AD4B853DEA5F3728EF572321D9239FCF89_0_0_0;
extern "C" void DelegatePInvokeWrapper_unityAdsPurchasingGetProductCatalog_tBC1786FAA2E7C404DEC81DB2CB0EB2B8CA4037A7();
extern const RuntimeType unityAdsPurchasingGetProductCatalog_tBC1786FAA2E7C404DEC81DB2CB0EB2B8CA4037A7_0_0_0;
extern "C" void DelegatePInvokeWrapper_unityAdsPurchasingGetPurchasingVersion_tE5CC48324CE3D72814A6E45EB735EF90FF886F44();
extern const RuntimeType unityAdsPurchasingGetPurchasingVersion_tE5CC48324CE3D72814A6E45EB735EF90FF886F44_0_0_0;
extern "C" void DelegatePInvokeWrapper_unityAdsPurchasingInitialize_tF23E33D0423E2EE4F014591F599E0615B3DC31A5();
extern const RuntimeType unityAdsPurchasingInitialize_tF23E33D0423E2EE4F014591F599E0615B3DC31A5_0_0_0;
extern "C" void ChannelPacket_t1463DDB5D2C734160303B94DBF5E8E8C220AA6B3_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ChannelPacket_t1463DDB5D2C734160303B94DBF5E8E8C220AA6B3_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ChannelPacket_t1463DDB5D2C734160303B94DBF5E8E8C220AA6B3_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ChannelPacket_t1463DDB5D2C734160303B94DBF5E8E8C220AA6B3_0_0_0;
extern "C" void NetworkBroadcastResult_t362C44B9A7CF56BBBA0D2CD5E9EB640F95A6F6EB_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void NetworkBroadcastResult_t362C44B9A7CF56BBBA0D2CD5E9EB640F95A6F6EB_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void NetworkBroadcastResult_t362C44B9A7CF56BBBA0D2CD5E9EB640F95A6F6EB_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType NetworkBroadcastResult_t362C44B9A7CF56BBBA0D2CD5E9EB640F95A6F6EB_0_0_0;
extern "C" void PendingPlayer_t2D703F7EA98B24BE443F6FF1FF4ABDA6E5B2ECE1_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void PendingPlayer_t2D703F7EA98B24BE443F6FF1FF4ABDA6E5B2ECE1_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void PendingPlayer_t2D703F7EA98B24BE443F6FF1FF4ABDA6E5B2ECE1_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType PendingPlayer_t2D703F7EA98B24BE443F6FF1FF4ABDA6E5B2ECE1_0_0_0;
extern "C" void ConnectionPendingPlayers_tC607E3F095B410BC34839FB3AEA767B20C6E6ACE_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ConnectionPendingPlayers_tC607E3F095B410BC34839FB3AEA767B20C6E6ACE_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ConnectionPendingPlayers_tC607E3F095B410BC34839FB3AEA767B20C6E6ACE_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ConnectionPendingPlayers_tC607E3F095B410BC34839FB3AEA767B20C6E6ACE_0_0_0;
extern "C" void PendingPlayerInfo_t585C3975FF9CBE89020F5AB4C6BDEA018DC4BA3A_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void PendingPlayerInfo_t585C3975FF9CBE89020F5AB4C6BDEA018DC4BA3A_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void PendingPlayerInfo_t585C3975FF9CBE89020F5AB4C6BDEA018DC4BA3A_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType PendingPlayerInfo_t585C3975FF9CBE89020F5AB4C6BDEA018DC4BA3A_0_0_0;
extern "C" void CRCMessageEntry_tA0C9B1AED99C4DA3F62AF6B9D63440E4024A8B3D_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void CRCMessageEntry_tA0C9B1AED99C4DA3F62AF6B9D63440E4024A8B3D_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void CRCMessageEntry_tA0C9B1AED99C4DA3F62AF6B9D63440E4024A8B3D_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType CRCMessageEntry_tA0C9B1AED99C4DA3F62AF6B9D63440E4024A8B3D_0_0_0;
extern "C" void DelegatePInvokeWrapper_ClientMoveCallback2D_t8B84768DE7682C54CEB63E3C8265F817CF34B5C6();
extern const RuntimeType ClientMoveCallback2D_t8B84768DE7682C54CEB63E3C8265F817CF34B5C6_0_0_0;
extern "C" void DelegatePInvokeWrapper_ClientMoveCallback3D_t7BA9288D0A33613F8C6CB39E58F47F22C4F80636();
extern const RuntimeType ClientMoveCallback3D_t7BA9288D0A33613F8C6CB39E58F47F22C4F80636_0_0_0;
extern "C" void CameraData_t1E464C8FD597DAF030BB0CEBCD3E7BA8137EB3A6_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void CameraData_t1E464C8FD597DAF030BB0CEBCD3E7BA8137EB3A6_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void CameraData_t1E464C8FD597DAF030BB0CEBCD3E7BA8137EB3A6_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType CameraData_t1E464C8FD597DAF030BB0CEBCD3E7BA8137EB3A6_0_0_0;
extern "C" void DelegatePInvokeWrapper_CompressFunc_t81FC687403DA94FC5391CE904E3B1E3E0A16951B();
extern const RuntimeType CompressFunc_t81FC687403DA94FC5391CE904E3B1E3E0A16951B_0_0_0;
extern "C" void ClientMessage_t58311ADBFA310AE409AA6E39AE5FD76E18EE8879_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ClientMessage_t58311ADBFA310AE409AA6E39AE5FD76E18EE8879_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ClientMessage_t58311ADBFA310AE409AA6E39AE5FD76E18EE8879_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ClientMessage_t58311ADBFA310AE409AA6E39AE5FD76E18EE8879_0_0_0;
extern "C" void NeedRequest_t61DF4E7A3EEE21EF00172BCC0FF6D0203875E690_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void NeedRequest_t61DF4E7A3EEE21EF00172BCC0FF6D0203875E690_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void NeedRequest_t61DF4E7A3EEE21EF00172BCC0FF6D0203875E690_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType NeedRequest_t61DF4E7A3EEE21EF00172BCC0FF6D0203875E690_0_0_0;
extern "C" void Result_t772620F01E211D420E5495A876E007FB3EA78B28_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void Result_t772620F01E211D420E5495A876E007FB3EA78B28_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void Result_t772620F01E211D420E5495A876E007FB3EA78B28_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType Result_t772620F01E211D420E5495A876E007FB3EA78B28_0_0_0;
extern "C" void WordMatch_tF996DCE69EAEA187A3F4510FFB330524886D4DBF_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void WordMatch_tF996DCE69EAEA187A3F4510FFB330524886D4DBF_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void WordMatch_tF996DCE69EAEA187A3F4510FFB330524886D4DBF_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType WordMatch_tF996DCE69EAEA187A3F4510FFB330524886D4DBF_0_0_0;
extern "C" void DelegatePInvokeWrapper_GADUAdLoaderDidFailToReceiveAdWithErrorCallback_tD0A3FBA4FEFCEA84156E6DD5FBC14C7120B39370();
extern const RuntimeType GADUAdLoaderDidFailToReceiveAdWithErrorCallback_tD0A3FBA4FEFCEA84156E6DD5FBC14C7120B39370_0_0_0;
extern "C" void DelegatePInvokeWrapper_GADUAdLoaderDidReceiveNativeCustomTemplateAdCallback_t3CAC1C526BCCD015267BEEB4408990038E75846A();
extern const RuntimeType GADUAdLoaderDidReceiveNativeCustomTemplateAdCallback_t3CAC1C526BCCD015267BEEB4408990038E75846A_0_0_0;
extern "C" void DelegatePInvokeWrapper_GADUAdViewDidDismissScreenCallback_tA439B758F1D283C6F1D4BFF4DFAF8400969D596E();
extern const RuntimeType GADUAdViewDidDismissScreenCallback_tA439B758F1D283C6F1D4BFF4DFAF8400969D596E_0_0_0;
extern "C" void DelegatePInvokeWrapper_GADUAdViewDidFailToReceiveAdWithErrorCallback_tDD709BA804FCBBC8575C993E22D5C592AC2AABFB();
extern const RuntimeType GADUAdViewDidFailToReceiveAdWithErrorCallback_tDD709BA804FCBBC8575C993E22D5C592AC2AABFB_0_0_0;
extern "C" void DelegatePInvokeWrapper_GADUAdViewDidReceiveAdCallback_tD0EDCCD0E01B583C423B8899736B917A109DD33F();
extern const RuntimeType GADUAdViewDidReceiveAdCallback_tD0EDCCD0E01B583C423B8899736B917A109DD33F_0_0_0;
extern "C" void DelegatePInvokeWrapper_GADUAdViewWillLeaveApplicationCallback_t25CB512D2FBBC084029828A8AAF881B352974915();
extern const RuntimeType GADUAdViewWillLeaveApplicationCallback_t25CB512D2FBBC084029828A8AAF881B352974915_0_0_0;
extern "C" void DelegatePInvokeWrapper_GADUAdViewWillPresentScreenCallback_t6DD8BA1A4EA4BAD158808A5CA9DAFEA14CA58225();
extern const RuntimeType GADUAdViewWillPresentScreenCallback_t6DD8BA1A4EA4BAD158808A5CA9DAFEA14CA58225_0_0_0;
extern "C" void DelegatePInvokeWrapper_GADUNativeCustomTemplateDidReceiveClick_tC701439AFDA476706B49DD67AC24524100FF1647();
extern const RuntimeType GADUNativeCustomTemplateDidReceiveClick_tC701439AFDA476706B49DD67AC24524100FF1647_0_0_0;
extern "C" void DelegatePInvokeWrapper_GADUInterstitialDidDismissScreenCallback_t26B11CDFFD2C154F696686C0277235F5E63F17BD();
extern const RuntimeType GADUInterstitialDidDismissScreenCallback_t26B11CDFFD2C154F696686C0277235F5E63F17BD_0_0_0;
extern "C" void DelegatePInvokeWrapper_GADUInterstitialDidFailToReceiveAdWithErrorCallback_tEE8B8CB712217A5D36EA3709647A40C8EB3A0FE3();
extern const RuntimeType GADUInterstitialDidFailToReceiveAdWithErrorCallback_tEE8B8CB712217A5D36EA3709647A40C8EB3A0FE3_0_0_0;
extern "C" void DelegatePInvokeWrapper_GADUInterstitialDidReceiveAdCallback_t070DE72316EE0F86A1B260139133C47EDDFEA632();
extern const RuntimeType GADUInterstitialDidReceiveAdCallback_t070DE72316EE0F86A1B260139133C47EDDFEA632_0_0_0;
extern "C" void DelegatePInvokeWrapper_GADUInterstitialWillLeaveApplicationCallback_t8C3AEFD8BC6C59EF9108F7120396315B5365151C();
extern const RuntimeType GADUInterstitialWillLeaveApplicationCallback_t8C3AEFD8BC6C59EF9108F7120396315B5365151C_0_0_0;
extern "C" void DelegatePInvokeWrapper_GADUInterstitialWillPresentScreenCallback_t4298A1AC94E8279F7C37AC1837949144BA779756();
extern const RuntimeType GADUInterstitialWillPresentScreenCallback_t4298A1AC94E8279F7C37AC1837949144BA779756_0_0_0;
extern "C" void DelegatePInvokeWrapper_GADUInitializationCompleteCallback_t64C73660F404CB5C59D8522D84AA0235FF10E05A();
extern const RuntimeType GADUInitializationCompleteCallback_t64C73660F404CB5C59D8522D84AA0235FF10E05A_0_0_0;
extern "C" void DelegatePInvokeWrapper_GADURewardBasedVideoAdDidCloseCallback_t26F05B6279C5EFCAAC89142AC46398ECA18ED67E();
extern const RuntimeType GADURewardBasedVideoAdDidCloseCallback_t26F05B6279C5EFCAAC89142AC46398ECA18ED67E_0_0_0;
extern "C" void DelegatePInvokeWrapper_GADURewardBasedVideoAdDidCompleteCallback_t43AB49809F1D6B1439D437FD0EF3639BCC118A46();
extern const RuntimeType GADURewardBasedVideoAdDidCompleteCallback_t43AB49809F1D6B1439D437FD0EF3639BCC118A46_0_0_0;
extern "C" void DelegatePInvokeWrapper_GADURewardBasedVideoAdDidFailToReceiveAdWithErrorCallback_t5F82EB9B6F0AB22D402E0CC2A494949C780D2390();
extern const RuntimeType GADURewardBasedVideoAdDidFailToReceiveAdWithErrorCallback_t5F82EB9B6F0AB22D402E0CC2A494949C780D2390_0_0_0;
extern "C" void DelegatePInvokeWrapper_GADURewardBasedVideoAdDidOpenCallback_tB06CAA1CE4826577744A13A26AC89A3B42FD1C34();
extern const RuntimeType GADURewardBasedVideoAdDidOpenCallback_tB06CAA1CE4826577744A13A26AC89A3B42FD1C34_0_0_0;
extern "C" void DelegatePInvokeWrapper_GADURewardBasedVideoAdDidReceiveAdCallback_t30E1E6C6EAD75C6D8A8A5782AEF818C774EC8966();
extern const RuntimeType GADURewardBasedVideoAdDidReceiveAdCallback_t30E1E6C6EAD75C6D8A8A5782AEF818C774EC8966_0_0_0;
extern "C" void DelegatePInvokeWrapper_GADURewardBasedVideoAdDidRewardCallback_t779286F8D8719CD813D24794528D170B6CE6758B();
extern const RuntimeType GADURewardBasedVideoAdDidRewardCallback_t779286F8D8719CD813D24794528D170B6CE6758B_0_0_0;
extern "C" void DelegatePInvokeWrapper_GADURewardBasedVideoAdDidStartCallback_t47B2088607E2F7B610BFF96B02315DB970D3BE8A();
extern const RuntimeType GADURewardBasedVideoAdDidStartCallback_t47B2088607E2F7B610BFF96B02315DB970D3BE8A_0_0_0;
extern "C" void DelegatePInvokeWrapper_GADURewardBasedVideoAdWillLeaveApplicationCallback_t0056DE714C24D44E29732E1C20F113CB30974404();
extern const RuntimeType GADURewardBasedVideoAdWillLeaveApplicationCallback_t0056DE714C24D44E29732E1C20F113CB30974404_0_0_0;
extern "C" void DelegatePInvokeWrapper_GADURewardedAdDidCloseCallback_t506A5A3B01F7221AB06AC6E689610FDCE627BCAF();
extern const RuntimeType GADURewardedAdDidCloseCallback_t506A5A3B01F7221AB06AC6E689610FDCE627BCAF_0_0_0;
extern "C" void DelegatePInvokeWrapper_GADURewardedAdDidFailToReceiveAdWithErrorCallback_tCDA36987E2F970C589B4F9B0D153AF5EC883F9BE();
extern const RuntimeType GADURewardedAdDidFailToReceiveAdWithErrorCallback_tCDA36987E2F970C589B4F9B0D153AF5EC883F9BE_0_0_0;
extern "C" void DelegatePInvokeWrapper_GADURewardedAdDidFailToShowAdWithErrorCallback_t7ECC0C4E4E19D517843B7F217597B1365D6B2BF8();
extern const RuntimeType GADURewardedAdDidFailToShowAdWithErrorCallback_t7ECC0C4E4E19D517843B7F217597B1365D6B2BF8_0_0_0;
extern "C" void DelegatePInvokeWrapper_GADURewardedAdDidOpenCallback_t3C1F9C88CBDD1DDE862D771C31FBFDFD30BCBB9C();
extern const RuntimeType GADURewardedAdDidOpenCallback_t3C1F9C88CBDD1DDE862D771C31FBFDFD30BCBB9C_0_0_0;
extern "C" void DelegatePInvokeWrapper_GADURewardedAdDidReceiveAdCallback_t643161A4F15EE54392448B33D32F455E4F988E5A();
extern const RuntimeType GADURewardedAdDidReceiveAdCallback_t643161A4F15EE54392448B33D32F455E4F988E5A_0_0_0;
extern "C" void DelegatePInvokeWrapper_GADUUserEarnedRewardCallback_tD3405735D8FA00F085D1F680CBA864C85F5CEC62();
extern const RuntimeType GADUUserEarnedRewardCallback_tD3405735D8FA00F085D1F680CBA864C85F5CEC62_0_0_0;
extern "C" void IndexInfo_t75C3B4925D65E1980EC9978D31AFC9117378E06A_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void IndexInfo_t75C3B4925D65E1980EC9978D31AFC9117378E06A_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void IndexInfo_t75C3B4925D65E1980EC9978D31AFC9117378E06A_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType IndexInfo_t75C3B4925D65E1980EC9978D31AFC9117378E06A_0_0_0;
extern "C" void IndexedColumn_t7383ED01B7BE144DD5EE244105C11BA46C86AD99_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void IndexedColumn_t7383ED01B7BE144DD5EE244105C11BA46C86AD99_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void IndexedColumn_t7383ED01B7BE144DD5EE244105C11BA46C86AD99_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType IndexedColumn_t7383ED01B7BE144DD5EE244105C11BA46C86AD99_0_0_0;
extern "C" void DelegatePInvokeWrapper_TimeExecutionHandler_t08BC9A715B49879CA2DE8B562C19D18E1AB656F1();
extern const RuntimeType TimeExecutionHandler_t08BC9A715B49879CA2DE8B562C19D18E1AB656F1_0_0_0;
extern "C" void DelegatePInvokeWrapper_TraceHandler_tA80182197ED4D58961A46F9CA9D2D027FB5006A2();
extern const RuntimeType TraceHandler_tA80182197ED4D58961A46F9CA9D2D027FB5006A2_0_0_0;
extern "C" void DelegatePInvokeWrapper_OnHide_t5A8285735A2689F2DC221FC307F1C6C091C1392F();
extern const RuntimeType OnHide_t5A8285735A2689F2DC221FC307F1C6C091C1392F_0_0_0;
extern "C" void ReorderableListEventStruct_tC682CA0A096D5C473503F24E5EA5EF6DD40EBB2A_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void ReorderableListEventStruct_tC682CA0A096D5C473503F24E5EA5EF6DD40EBB2A_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void ReorderableListEventStruct_tC682CA0A096D5C473503F24E5EA5EF6DD40EBB2A_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType ReorderableListEventStruct_tC682CA0A096D5C473503F24E5EA5EF6DD40EBB2A_0_0_0;
extern "C" void DelegatePInvokeWrapper_PageSnapChange_tD3924B00988BFBCA67B474FF7164B0F6A5C3DE29();
extern const RuntimeType PageSnapChange_tD3924B00988BFBCA67B474FF7164B0F6A5C3DE29_0_0_0;
extern "C" void IconName_t2F8CB22FF220F36D0B91C6D837ACFC15FEAFB94A_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void IconName_t2F8CB22FF220F36D0B91C6D837ACFC15FEAFB94A_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void IconName_t2F8CB22FF220F36D0B91C6D837ACFC15FEAFB94A_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType IconName_t2F8CB22FF220F36D0B91C6D837ACFC15FEAFB94A_0_0_0;
extern "C" void FloatTween_t5DC81A16395042EEFF03576EC81EF9D6F96E1201_marshal_pinvoke(void* managedStructure, void* marshaledStructure);
extern "C" void FloatTween_t5DC81A16395042EEFF03576EC81EF9D6F96E1201_marshal_pinvoke_back(void* marshaledStructure, void* managedStructure);
extern "C" void FloatTween_t5DC81A16395042EEFF03576EC81EF9D6F96E1201_marshal_pinvoke_cleanup(void* marshaledStructure);
extern const RuntimeType FloatTween_t5DC81A16395042EEFF03576EC81EF9D6F96E1201_0_0_0;
extern "C" void DelegatePInvokeWrapper_OnResponseDelegate_t5828875905266804DAF8CBA5F2770818AA5FEBDA();
extern const RuntimeType OnResponseDelegate_t5828875905266804DAF8CBA5F2770818AA5FEBDA_0_0_0;
extern const RuntimeType ZlibException_t2F0C2A9C169C9729EA1A649DD3A2D58AFA7F7028_0_0_0;
extern Il2CppInteropData g_Il2CppInteropData[388] = 
{
	{ NULL, Escape_t7D205DCBE40F7D5FE25F443E2DBF79A63870C5C6_marshal_pinvoke, Escape_t7D205DCBE40F7D5FE25F443E2DBF79A63870C5C6_marshal_pinvoke_back, Escape_t7D205DCBE40F7D5FE25F443E2DBF79A63870C5C6_marshal_pinvoke_cleanup, NULL, NULL, &Escape_t7D205DCBE40F7D5FE25F443E2DBF79A63870C5C6_0_0_0 } /* Mono.Globalization.Unicode.SimpleCollator/Escape */,
	{ NULL, SafeStringMarshal_tD41B530333F2C9F500BD6FEC91735D16F06C9A6F_marshal_pinvoke, SafeStringMarshal_tD41B530333F2C9F500BD6FEC91735D16F06C9A6F_marshal_pinvoke_back, SafeStringMarshal_tD41B530333F2C9F500BD6FEC91735D16F06C9A6F_marshal_pinvoke_cleanup, NULL, NULL, &SafeStringMarshal_tD41B530333F2C9F500BD6FEC91735D16F06C9A6F_0_0_0 } /* Mono.SafeStringMarshal */,
	{ NULL, UriScheme_tD4C9E109AAE4DEFCAA20A5D4D756767924C8F089_marshal_pinvoke, UriScheme_tD4C9E109AAE4DEFCAA20A5D4D756767924C8F089_marshal_pinvoke_back, UriScheme_tD4C9E109AAE4DEFCAA20A5D4D756767924C8F089_marshal_pinvoke_cleanup, NULL, NULL, &UriScheme_tD4C9E109AAE4DEFCAA20A5D4D756767924C8F089_0_0_0 } /* Mono.Security.Uri/UriScheme */,
	{ DelegatePInvokeWrapper_Action_t591D2A86165F896B4B800BB5C25CE18672A55579, NULL, NULL, NULL, NULL, NULL, &Action_t591D2A86165F896B4B800BB5C25CE18672A55579_0_0_0 } /* System.Action */,
	{ NULL, AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8_marshal_pinvoke, AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8_marshal_pinvoke_back, AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8_marshal_pinvoke_cleanup, NULL, NULL, &AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8_0_0_0 } /* System.AppDomain */,
	{ NULL, AppDomainSetup_t80DF2915BB100D4BD515920B49C959E9FA451306_marshal_pinvoke, AppDomainSetup_t80DF2915BB100D4BD515920B49C959E9FA451306_marshal_pinvoke_back, AppDomainSetup_t80DF2915BB100D4BD515920B49C959E9FA451306_marshal_pinvoke_cleanup, NULL, NULL, &AppDomainSetup_t80DF2915BB100D4BD515920B49C959E9FA451306_0_0_0 } /* System.AppDomainSetup */,
	{ NULL, SorterGenericArray_t4742EBDD434279DCC671369AB18AD4DC64587891_marshal_pinvoke, SorterGenericArray_t4742EBDD434279DCC671369AB18AD4DC64587891_marshal_pinvoke_back, SorterGenericArray_t4742EBDD434279DCC671369AB18AD4DC64587891_marshal_pinvoke_cleanup, NULL, NULL, &SorterGenericArray_t4742EBDD434279DCC671369AB18AD4DC64587891_0_0_0 } /* System.Array/SorterGenericArray */,
	{ NULL, SorterObjectArray_tFBBE2F63F86573B28BE7E3BE0BFF9C614F12BDB4_marshal_pinvoke, SorterObjectArray_tFBBE2F63F86573B28BE7E3BE0BFF9C614F12BDB4_marshal_pinvoke_back, SorterObjectArray_tFBBE2F63F86573B28BE7E3BE0BFF9C614F12BDB4_marshal_pinvoke_cleanup, NULL, NULL, &SorterObjectArray_tFBBE2F63F86573B28BE7E3BE0BFF9C614F12BDB4_0_0_0 } /* System.Array/SorterObjectArray */,
	{ NULL, DictionaryEntry_tB5348A26B94274FCC1DD77185BD5946E283B11A4_marshal_pinvoke, DictionaryEntry_tB5348A26B94274FCC1DD77185BD5946E283B11A4_marshal_pinvoke_back, DictionaryEntry_tB5348A26B94274FCC1DD77185BD5946E283B11A4_marshal_pinvoke_cleanup, NULL, NULL, &DictionaryEntry_tB5348A26B94274FCC1DD77185BD5946E283B11A4_0_0_0 } /* System.Collections.DictionaryEntry */,
	{ NULL, bucket_t1C848488DF65838689F7773D46F9E7E8C881B083_marshal_pinvoke, bucket_t1C848488DF65838689F7773D46F9E7E8C881B083_marshal_pinvoke_back, bucket_t1C848488DF65838689F7773D46F9E7E8C881B083_marshal_pinvoke_cleanup, NULL, NULL, &bucket_t1C848488DF65838689F7773D46F9E7E8C881B083_0_0_0 } /* System.Collections.Hashtable/bucket */,
	{ DelegatePInvokeWrapper_InternalCancelHandler_t2DD134D8150B67E2F9FAD1BC2E6BE92EED57968A, NULL, NULL, NULL, NULL, NULL, &InternalCancelHandler_t2DD134D8150B67E2F9FAD1BC2E6BE92EED57968A_0_0_0 } /* System.Console/InternalCancelHandler */,
	{ DelegatePInvokeWrapper_WindowsCancelHandler_t1D05BCFB512603DCF87A126FE9969F1D876B9B51, NULL, NULL, NULL, NULL, NULL, &WindowsCancelHandler_t1D05BCFB512603DCF87A126FE9969F1D876B9B51_0_0_0 } /* System.Console/WindowsConsole/WindowsCancelHandler */,
	{ NULL, ConsoleKeyInfo_t5BE3CE05E8258CDB5404256E96AF7C22BC5DE768_marshal_pinvoke, ConsoleKeyInfo_t5BE3CE05E8258CDB5404256E96AF7C22BC5DE768_marshal_pinvoke_back, ConsoleKeyInfo_t5BE3CE05E8258CDB5404256E96AF7C22BC5DE768_marshal_pinvoke_cleanup, NULL, NULL, &ConsoleKeyInfo_t5BE3CE05E8258CDB5404256E96AF7C22BC5DE768_0_0_0 } /* System.ConsoleKeyInfo */,
	{ NULL, DTSubString_t0B5F9998AD0833CCE29248DE20EFEBFE9EBFB93D_marshal_pinvoke, DTSubString_t0B5F9998AD0833CCE29248DE20EFEBFE9EBFB93D_marshal_pinvoke_back, DTSubString_t0B5F9998AD0833CCE29248DE20EFEBFE9EBFB93D_marshal_pinvoke_cleanup, NULL, NULL, &DTSubString_t0B5F9998AD0833CCE29248DE20EFEBFE9EBFB93D_0_0_0 } /* System.DTSubString */,
	{ NULL, DateTimeRawInfo_t9FCF0836569E074269DCA1D04061D8E3720D451E_marshal_pinvoke, DateTimeRawInfo_t9FCF0836569E074269DCA1D04061D8E3720D451E_marshal_pinvoke_back, DateTimeRawInfo_t9FCF0836569E074269DCA1D04061D8E3720D451E_marshal_pinvoke_cleanup, NULL, NULL, &DateTimeRawInfo_t9FCF0836569E074269DCA1D04061D8E3720D451E_0_0_0 } /* System.DateTimeRawInfo */,
	{ NULL, DateTimeResult_tF71BA2895BFBF33241086E9BDF836567EBD2F6AB_marshal_pinvoke, DateTimeResult_tF71BA2895BFBF33241086E9BDF836567EBD2F6AB_marshal_pinvoke_back, DateTimeResult_tF71BA2895BFBF33241086E9BDF836567EBD2F6AB_marshal_pinvoke_cleanup, NULL, NULL, &DateTimeResult_tF71BA2895BFBF33241086E9BDF836567EBD2F6AB_0_0_0 } /* System.DateTimeResult */,
	{ NULL, Delegate_t_marshal_pinvoke, Delegate_t_marshal_pinvoke_back, Delegate_t_marshal_pinvoke_cleanup, NULL, NULL, &Delegate_t_0_0_0 } /* System.Delegate */,
	{ NULL, StackFrame_tD06959DD2B585E9BEB73C60AB5C110DE69F23A00_marshal_pinvoke, StackFrame_tD06959DD2B585E9BEB73C60AB5C110DE69F23A00_marshal_pinvoke_back, StackFrame_tD06959DD2B585E9BEB73C60AB5C110DE69F23A00_marshal_pinvoke_cleanup, NULL, NULL, &StackFrame_tD06959DD2B585E9BEB73C60AB5C110DE69F23A00_0_0_0 } /* System.Diagnostics.StackFrame */,
	{ NULL, Enum_t2AF27C02B8653AE29442467390005ABC74D8F521_marshal_pinvoke, Enum_t2AF27C02B8653AE29442467390005ABC74D8F521_marshal_pinvoke_back, Enum_t2AF27C02B8653AE29442467390005ABC74D8F521_marshal_pinvoke_cleanup, NULL, NULL, &Enum_t2AF27C02B8653AE29442467390005ABC74D8F521_0_0_0 } /* System.Enum */,
	{ NULL, EnumResult_t35D8EE76FAC6638FD89A5338957F377BF893566C_marshal_pinvoke, EnumResult_t35D8EE76FAC6638FD89A5338957F377BF893566C_marshal_pinvoke_back, EnumResult_t35D8EE76FAC6638FD89A5338957F377BF893566C_marshal_pinvoke_cleanup, NULL, NULL, &EnumResult_t35D8EE76FAC6638FD89A5338957F377BF893566C_0_0_0 } /* System.Enum/EnumResult */,
	{ NULL, Exception_t_marshal_pinvoke, Exception_t_marshal_pinvoke_back, Exception_t_marshal_pinvoke_cleanup, NULL, NULL, &Exception_t_0_0_0 } /* System.Exception */,
	{ NULL, CalendarData_t1D4C55E2ECDDE4EB7B69C75D0E28AA0AF9952B3E_marshal_pinvoke, CalendarData_t1D4C55E2ECDDE4EB7B69C75D0E28AA0AF9952B3E_marshal_pinvoke_back, CalendarData_t1D4C55E2ECDDE4EB7B69C75D0E28AA0AF9952B3E_marshal_pinvoke_cleanup, NULL, NULL, &CalendarData_t1D4C55E2ECDDE4EB7B69C75D0E28AA0AF9952B3E_0_0_0 } /* System.Globalization.CalendarData */,
	{ NULL, CultureData_tF43B080FFA6EB278F4F289BCDA3FB74B6C208ECD_marshal_pinvoke, CultureData_tF43B080FFA6EB278F4F289BCDA3FB74B6C208ECD_marshal_pinvoke_back, CultureData_tF43B080FFA6EB278F4F289BCDA3FB74B6C208ECD_marshal_pinvoke_cleanup, NULL, NULL, &CultureData_tF43B080FFA6EB278F4F289BCDA3FB74B6C208ECD_0_0_0 } /* System.Globalization.CultureData */,
	{ NULL, CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_marshal_pinvoke, CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_marshal_pinvoke_back, CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_marshal_pinvoke_cleanup, NULL, NULL, &CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_0_0_0 } /* System.Globalization.CultureInfo */,
	{ NULL, Data_t25CAFAACB31D34B4A9385638281C56D4D250BA2F_marshal_pinvoke, Data_t25CAFAACB31D34B4A9385638281C56D4D250BA2F_marshal_pinvoke_back, Data_t25CAFAACB31D34B4A9385638281C56D4D250BA2F_marshal_pinvoke_cleanup, NULL, NULL, &Data_t25CAFAACB31D34B4A9385638281C56D4D250BA2F_0_0_0 } /* System.Globalization.CultureInfo/Data */,
	{ NULL, InternalCodePageDataItem_t34EE39DE4A481B875348BB9BC6751E2A109AD0D4_marshal_pinvoke, InternalCodePageDataItem_t34EE39DE4A481B875348BB9BC6751E2A109AD0D4_marshal_pinvoke_back, InternalCodePageDataItem_t34EE39DE4A481B875348BB9BC6751E2A109AD0D4_marshal_pinvoke_cleanup, NULL, NULL, &InternalCodePageDataItem_t34EE39DE4A481B875348BB9BC6751E2A109AD0D4_0_0_0 } /* System.Globalization.InternalCodePageDataItem */,
	{ NULL, InternalEncodingDataItem_t34BEF550D56496035752E8E0607127CD43378211_marshal_pinvoke, InternalEncodingDataItem_t34BEF550D56496035752E8E0607127CD43378211_marshal_pinvoke_back, InternalEncodingDataItem_t34BEF550D56496035752E8E0607127CD43378211_marshal_pinvoke_cleanup, NULL, NULL, &InternalEncodingDataItem_t34BEF550D56496035752E8E0607127CD43378211_0_0_0 } /* System.Globalization.InternalEncodingDataItem */,
	{ NULL, RegionInfo_tC410DA2D1030267AF1E8F6AD7026990EE9A9F0C1_marshal_pinvoke, RegionInfo_tC410DA2D1030267AF1E8F6AD7026990EE9A9F0C1_marshal_pinvoke_back, RegionInfo_tC410DA2D1030267AF1E8F6AD7026990EE9A9F0C1_marshal_pinvoke_cleanup, NULL, NULL, &RegionInfo_tC410DA2D1030267AF1E8F6AD7026990EE9A9F0C1_0_0_0 } /* System.Globalization.RegionInfo */,
	{ NULL, SortKey_tD5C96B638D8C6D0C4C2F49F27387D51202D78FD9_marshal_pinvoke, SortKey_tD5C96B638D8C6D0C4C2F49F27387D51202D78FD9_marshal_pinvoke_back, SortKey_tD5C96B638D8C6D0C4C2F49F27387D51202D78FD9_marshal_pinvoke_cleanup, NULL, NULL, &SortKey_tD5C96B638D8C6D0C4C2F49F27387D51202D78FD9_0_0_0 } /* System.Globalization.SortKey */,
	{ NULL, FormatLiterals_tE93C12450F24FECD414C8FC2B3F3EE606F807223_marshal_pinvoke, FormatLiterals_tE93C12450F24FECD414C8FC2B3F3EE606F807223_marshal_pinvoke_back, FormatLiterals_tE93C12450F24FECD414C8FC2B3F3EE606F807223_marshal_pinvoke_cleanup, NULL, NULL, &FormatLiterals_tE93C12450F24FECD414C8FC2B3F3EE606F807223_0_0_0 } /* System.Globalization.TimeSpanFormat/FormatLiterals */,
	{ NULL, TimeSpanRawInfo_t41C41424D2A6BC45542E49CB1843F08221F844FB_marshal_pinvoke, TimeSpanRawInfo_t41C41424D2A6BC45542E49CB1843F08221F844FB_marshal_pinvoke_back, TimeSpanRawInfo_t41C41424D2A6BC45542E49CB1843F08221F844FB_marshal_pinvoke_cleanup, NULL, NULL, &TimeSpanRawInfo_t41C41424D2A6BC45542E49CB1843F08221F844FB_0_0_0 } /* System.Globalization.TimeSpanParse/TimeSpanRawInfo */,
	{ NULL, TimeSpanResult_t7C77BD9AF32E298E8818A8C884A2428C92283963_marshal_pinvoke, TimeSpanResult_t7C77BD9AF32E298E8818A8C884A2428C92283963_marshal_pinvoke_back, TimeSpanResult_t7C77BD9AF32E298E8818A8C884A2428C92283963_marshal_pinvoke_cleanup, NULL, NULL, &TimeSpanResult_t7C77BD9AF32E298E8818A8C884A2428C92283963_0_0_0 } /* System.Globalization.TimeSpanParse/TimeSpanResult */,
	{ NULL, TimeSpanToken_tAD6BBF1FE7922C2D3281576FD816F33901C87492_marshal_pinvoke, TimeSpanToken_tAD6BBF1FE7922C2D3281576FD816F33901C87492_marshal_pinvoke_back, TimeSpanToken_tAD6BBF1FE7922C2D3281576FD816F33901C87492_marshal_pinvoke_cleanup, NULL, NULL, &TimeSpanToken_tAD6BBF1FE7922C2D3281576FD816F33901C87492_0_0_0 } /* System.Globalization.TimeSpanParse/TimeSpanToken */,
	{ NULL, TimeSpanTokenizer_t7A2B1F99E6478C1B3D12EB1F7765D3C6E545B000_marshal_pinvoke, TimeSpanTokenizer_t7A2B1F99E6478C1B3D12EB1F7765D3C6E545B000_marshal_pinvoke_back, TimeSpanTokenizer_t7A2B1F99E6478C1B3D12EB1F7765D3C6E545B000_marshal_pinvoke_cleanup, NULL, NULL, &TimeSpanTokenizer_t7A2B1F99E6478C1B3D12EB1F7765D3C6E545B000_0_0_0 } /* System.Globalization.TimeSpanParse/TimeSpanTokenizer */,
	{ NULL, GuidResult_t8E78929A7A732656B7BAF6A5482FD037F81DB3F3_marshal_pinvoke, GuidResult_t8E78929A7A732656B7BAF6A5482FD037F81DB3F3_marshal_pinvoke_back, GuidResult_t8E78929A7A732656B7BAF6A5482FD037F81DB3F3_marshal_pinvoke_cleanup, NULL, NULL, &GuidResult_t8E78929A7A732656B7BAF6A5482FD037F81DB3F3_0_0_0 } /* System.Guid/GuidResult */,
	{ DelegatePInvokeWrapper_ReadDelegate_tC33791FF7613756CDEEC3ADFE91B2EE59A24FB48, NULL, NULL, NULL, NULL, NULL, &ReadDelegate_tC33791FF7613756CDEEC3ADFE91B2EE59A24FB48_0_0_0 } /* System.IO.FileStream/ReadDelegate */,
	{ DelegatePInvokeWrapper_WriteDelegate_t905F47C2C01F98FB87E2E19894AB9BAC6F02838C, NULL, NULL, NULL, NULL, NULL, &WriteDelegate_t905F47C2C01F98FB87E2E19894AB9BAC6F02838C_0_0_0 } /* System.IO.FileStream/WriteDelegate */,
	{ NULL, InputRecord_tAB007C739F339BE208F3C4796B53E9044ADF0A78_marshal_pinvoke, InputRecord_tAB007C739F339BE208F3C4796B53E9044ADF0A78_marshal_pinvoke_back, InputRecord_tAB007C739F339BE208F3C4796B53E9044ADF0A78_marshal_pinvoke_cleanup, NULL, NULL, &InputRecord_tAB007C739F339BE208F3C4796B53E9044ADF0A78_0_0_0 } /* System.InputRecord */,
	{ NULL, MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF_marshal_pinvoke, MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF_marshal_pinvoke_back, MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF_marshal_pinvoke_cleanup, NULL, NULL, &MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF_0_0_0 } /* System.MarshalByRefObject */,
	{ NULL, MonoAsyncCall_t5D4F895C7FEF7A36A60AFD3C64078A86BAF681FD_marshal_pinvoke, MonoAsyncCall_t5D4F895C7FEF7A36A60AFD3C64078A86BAF681FD_marshal_pinvoke_back, MonoAsyncCall_t5D4F895C7FEF7A36A60AFD3C64078A86BAF681FD_marshal_pinvoke_cleanup, NULL, NULL, &MonoAsyncCall_t5D4F895C7FEF7A36A60AFD3C64078A86BAF681FD_0_0_0 } /* System.MonoAsyncCall */,
	{ NULL, MonoTypeInfo_t9A65BA5324D14FDFEB7644EEE6E1BDF74B8A393D_marshal_pinvoke, MonoTypeInfo_t9A65BA5324D14FDFEB7644EEE6E1BDF74B8A393D_marshal_pinvoke_back, MonoTypeInfo_t9A65BA5324D14FDFEB7644EEE6E1BDF74B8A393D_marshal_pinvoke_cleanup, NULL, NULL, &MonoTypeInfo_t9A65BA5324D14FDFEB7644EEE6E1BDF74B8A393D_0_0_0 } /* System.MonoTypeInfo */,
	{ NULL, MulticastDelegate_t_marshal_pinvoke, MulticastDelegate_t_marshal_pinvoke_back, MulticastDelegate_t_marshal_pinvoke_cleanup, NULL, NULL, &MulticastDelegate_t_0_0_0 } /* System.MulticastDelegate */,
	{ NULL, NumberBuffer_tBD2266C521F098915F124D7A62AFF8DB05918075_marshal_pinvoke, NumberBuffer_tBD2266C521F098915F124D7A62AFF8DB05918075_marshal_pinvoke_back, NumberBuffer_tBD2266C521F098915F124D7A62AFF8DB05918075_marshal_pinvoke_cleanup, NULL, NULL, &NumberBuffer_tBD2266C521F098915F124D7A62AFF8DB05918075_0_0_0 } /* System.Number/NumberBuffer */,
	{ NULL, FormatParam_t1901DD0E7CD1B3A17B09040A6E2FCA5307328800_marshal_pinvoke, FormatParam_t1901DD0E7CD1B3A17B09040A6E2FCA5307328800_marshal_pinvoke_back, FormatParam_t1901DD0E7CD1B3A17B09040A6E2FCA5307328800_marshal_pinvoke_cleanup, NULL, NULL, &FormatParam_t1901DD0E7CD1B3A17B09040A6E2FCA5307328800_0_0_0 } /* System.ParameterizedStrings/FormatParam */,
	{ NULL, ParamsArray_t2DD480A5C806C0920DC218523EF3673332A68023_marshal_pinvoke, ParamsArray_t2DD480A5C806C0920DC218523EF3673332A68023_marshal_pinvoke_back, ParamsArray_t2DD480A5C806C0920DC218523EF3673332A68023_marshal_pinvoke_cleanup, NULL, NULL, &ParamsArray_t2DD480A5C806C0920DC218523EF3673332A68023_0_0_0 } /* System.ParamsArray */,
	{ NULL, ParsingInfo_t7E92EB1D56110F024979E1E497A675BC596BA7B7_marshal_pinvoke, ParsingInfo_t7E92EB1D56110F024979E1E497A675BC596BA7B7_marshal_pinvoke_back, ParsingInfo_t7E92EB1D56110F024979E1E497A675BC596BA7B7_marshal_pinvoke_cleanup, NULL, NULL, &ParsingInfo_t7E92EB1D56110F024979E1E497A675BC596BA7B7_0_0_0 } /* System.ParsingInfo */,
	{ NULL, Assembly_t_marshal_pinvoke, Assembly_t_marshal_pinvoke_back, Assembly_t_marshal_pinvoke_cleanup, NULL, NULL, &Assembly_t_0_0_0 } /* System.Reflection.Assembly */,
	{ NULL, AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82_marshal_pinvoke, AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82_marshal_pinvoke_back, AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82_marshal_pinvoke_cleanup, NULL, NULL, &AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82_0_0_0 } /* System.Reflection.AssemblyName */,
	{ NULL, CustomAttributeNamedArgument_t08BA731A94FD7F173551DF3098384CB9B3056E9E_marshal_pinvoke, CustomAttributeNamedArgument_t08BA731A94FD7F173551DF3098384CB9B3056E9E_marshal_pinvoke_back, CustomAttributeNamedArgument_t08BA731A94FD7F173551DF3098384CB9B3056E9E_marshal_pinvoke_cleanup, NULL, NULL, &CustomAttributeNamedArgument_t08BA731A94FD7F173551DF3098384CB9B3056E9E_0_0_0 } /* System.Reflection.CustomAttributeNamedArgument */,
	{ NULL, CustomAttributeTypedArgument_t238ACCB3A438CB5EDE4A924C637B288CCEC958E8_marshal_pinvoke, CustomAttributeTypedArgument_t238ACCB3A438CB5EDE4A924C637B288CCEC958E8_marshal_pinvoke_back, CustomAttributeTypedArgument_t238ACCB3A438CB5EDE4A924C637B288CCEC958E8_marshal_pinvoke_cleanup, NULL, NULL, &CustomAttributeTypedArgument_t238ACCB3A438CB5EDE4A924C637B288CCEC958E8_0_0_0 } /* System.Reflection.CustomAttributeTypedArgument */,
	{ NULL, LocalBuilder_t7A455571119EA1514A1158BBB78890FF7AB6A469_marshal_pinvoke, LocalBuilder_t7A455571119EA1514A1158BBB78890FF7AB6A469_marshal_pinvoke_back, LocalBuilder_t7A455571119EA1514A1158BBB78890FF7AB6A469_marshal_pinvoke_cleanup, NULL, NULL, &LocalBuilder_t7A455571119EA1514A1158BBB78890FF7AB6A469_0_0_0 } /* System.Reflection.Emit.LocalBuilder */,
	{ NULL, ExceptionHandlingClause_t112046BB7ECF503629487282AC37B55A6C2FEDC8_marshal_pinvoke, ExceptionHandlingClause_t112046BB7ECF503629487282AC37B55A6C2FEDC8_marshal_pinvoke_back, ExceptionHandlingClause_t112046BB7ECF503629487282AC37B55A6C2FEDC8_marshal_pinvoke_cleanup, NULL, NULL, &ExceptionHandlingClause_t112046BB7ECF503629487282AC37B55A6C2FEDC8_0_0_0 } /* System.Reflection.ExceptionHandlingClause */,
	{ NULL, LocalVariableInfo_t9DBEDBE3F55EEEA102C20A450433E3ECB255858C_marshal_pinvoke, LocalVariableInfo_t9DBEDBE3F55EEEA102C20A450433E3ECB255858C_marshal_pinvoke_back, LocalVariableInfo_t9DBEDBE3F55EEEA102C20A450433E3ECB255858C_marshal_pinvoke_cleanup, NULL, NULL, &LocalVariableInfo_t9DBEDBE3F55EEEA102C20A450433E3ECB255858C_0_0_0 } /* System.Reflection.LocalVariableInfo */,
	{ NULL, MethodBody_t900C79A470F33FA739168B232092420240DC11F2_marshal_pinvoke, MethodBody_t900C79A470F33FA739168B232092420240DC11F2_marshal_pinvoke_back, MethodBody_t900C79A470F33FA739168B232092420240DC11F2_marshal_pinvoke_cleanup, NULL, NULL, &MethodBody_t900C79A470F33FA739168B232092420240DC11F2_0_0_0 } /* System.Reflection.MethodBody */,
	{ NULL, Module_t882FB0C491B9CD194BE7CD1AC62FEFB31EEBE5D7_marshal_pinvoke, Module_t882FB0C491B9CD194BE7CD1AC62FEFB31EEBE5D7_marshal_pinvoke_back, Module_t882FB0C491B9CD194BE7CD1AC62FEFB31EEBE5D7_marshal_pinvoke_cleanup, NULL, NULL, &Module_t882FB0C491B9CD194BE7CD1AC62FEFB31EEBE5D7_0_0_0 } /* System.Reflection.Module */,
	{ NULL, MonoEventInfo_t4DD903D7D2A55C62BF50165523ADC010115A4DAB_marshal_pinvoke, MonoEventInfo_t4DD903D7D2A55C62BF50165523ADC010115A4DAB_marshal_pinvoke_back, MonoEventInfo_t4DD903D7D2A55C62BF50165523ADC010115A4DAB_marshal_pinvoke_cleanup, NULL, NULL, &MonoEventInfo_t4DD903D7D2A55C62BF50165523ADC010115A4DAB_0_0_0 } /* System.Reflection.MonoEventInfo */,
	{ NULL, MonoMethodInfo_t846D423B6DB28262B9AC22C1D07EC38D23DF7D5D_marshal_pinvoke, MonoMethodInfo_t846D423B6DB28262B9AC22C1D07EC38D23DF7D5D_marshal_pinvoke_back, MonoMethodInfo_t846D423B6DB28262B9AC22C1D07EC38D23DF7D5D_marshal_pinvoke_cleanup, NULL, NULL, &MonoMethodInfo_t846D423B6DB28262B9AC22C1D07EC38D23DF7D5D_0_0_0 } /* System.Reflection.MonoMethodInfo */,
	{ NULL, MonoPropertyInfo_tC5EFF918A3DCFB6A5DBAFB9B7DE3DEB56C72885F_marshal_pinvoke, MonoPropertyInfo_tC5EFF918A3DCFB6A5DBAFB9B7DE3DEB56C72885F_marshal_pinvoke_back, MonoPropertyInfo_tC5EFF918A3DCFB6A5DBAFB9B7DE3DEB56C72885F_marshal_pinvoke_cleanup, NULL, NULL, &MonoPropertyInfo_tC5EFF918A3DCFB6A5DBAFB9B7DE3DEB56C72885F_0_0_0 } /* System.Reflection.MonoPropertyInfo */,
	{ NULL, ParameterInfo_t37AB8D79D44E14C48CDA9004CB696E240C3FD4DB_marshal_pinvoke, ParameterInfo_t37AB8D79D44E14C48CDA9004CB696E240C3FD4DB_marshal_pinvoke_back, ParameterInfo_t37AB8D79D44E14C48CDA9004CB696E240C3FD4DB_marshal_pinvoke_cleanup, NULL, NULL, &ParameterInfo_t37AB8D79D44E14C48CDA9004CB696E240C3FD4DB_0_0_0 } /* System.Reflection.ParameterInfo */,
	{ NULL, ParameterModifier_t7BEFF7C52C8D7CD73D787BDAE6A1A50196204E3E_marshal_pinvoke, ParameterModifier_t7BEFF7C52C8D7CD73D787BDAE6A1A50196204E3E_marshal_pinvoke_back, ParameterModifier_t7BEFF7C52C8D7CD73D787BDAE6A1A50196204E3E_marshal_pinvoke_cleanup, NULL, NULL, &ParameterModifier_t7BEFF7C52C8D7CD73D787BDAE6A1A50196204E3E_0_0_0 } /* System.Reflection.ParameterModifier */,
	{ NULL, ResourceLocator_t1783916E271C27CB09DF57E7E5ED08ECA4B3275C_marshal_pinvoke, ResourceLocator_t1783916E271C27CB09DF57E7E5ED08ECA4B3275C_marshal_pinvoke_back, ResourceLocator_t1783916E271C27CB09DF57E7E5ED08ECA4B3275C_marshal_pinvoke_cleanup, NULL, NULL, &ResourceLocator_t1783916E271C27CB09DF57E7E5ED08ECA4B3275C_0_0_0 } /* System.Resources.ResourceLocator */,
	{ NULL, AsyncMethodBuilderCore_t4CE6C1E4B0621A6EC45CF6E0E8F1F633FFF9FF01_marshal_pinvoke, AsyncMethodBuilderCore_t4CE6C1E4B0621A6EC45CF6E0E8F1F633FFF9FF01_marshal_pinvoke_back, AsyncMethodBuilderCore_t4CE6C1E4B0621A6EC45CF6E0E8F1F633FFF9FF01_marshal_pinvoke_cleanup, NULL, NULL, &AsyncMethodBuilderCore_t4CE6C1E4B0621A6EC45CF6E0E8F1F633FFF9FF01_0_0_0 } /* System.Runtime.CompilerServices.AsyncMethodBuilderCore */,
	{ NULL, AsyncTaskMethodBuilder_t0CD1893D670405BED201BE8CA6F2E811F2C0F487_marshal_pinvoke, AsyncTaskMethodBuilder_t0CD1893D670405BED201BE8CA6F2E811F2C0F487_marshal_pinvoke_back, AsyncTaskMethodBuilder_t0CD1893D670405BED201BE8CA6F2E811F2C0F487_marshal_pinvoke_cleanup, NULL, NULL, &AsyncTaskMethodBuilder_t0CD1893D670405BED201BE8CA6F2E811F2C0F487_0_0_0 } /* System.Runtime.CompilerServices.AsyncTaskMethodBuilder */,
	{ NULL, ConfiguredTaskAwaitable_t24DE1415466EE20060BE5AD528DC5C812CFA53A9_marshal_pinvoke, ConfiguredTaskAwaitable_t24DE1415466EE20060BE5AD528DC5C812CFA53A9_marshal_pinvoke_back, ConfiguredTaskAwaitable_t24DE1415466EE20060BE5AD528DC5C812CFA53A9_marshal_pinvoke_cleanup, NULL, NULL, &ConfiguredTaskAwaitable_t24DE1415466EE20060BE5AD528DC5C812CFA53A9_0_0_0 } /* System.Runtime.CompilerServices.ConfiguredTaskAwaitable */,
	{ NULL, ConfiguredTaskAwaiter_tF1AAA16B8A1250CA037E32157A3424CD2BA47874_marshal_pinvoke, ConfiguredTaskAwaiter_tF1AAA16B8A1250CA037E32157A3424CD2BA47874_marshal_pinvoke_back, ConfiguredTaskAwaiter_tF1AAA16B8A1250CA037E32157A3424CD2BA47874_marshal_pinvoke_cleanup, NULL, NULL, &ConfiguredTaskAwaiter_tF1AAA16B8A1250CA037E32157A3424CD2BA47874_0_0_0 } /* System.Runtime.CompilerServices.ConfiguredTaskAwaitable/ConfiguredTaskAwaiter */,
	{ NULL, Ephemeron_t6F0B12401657FF132AB44052E5BCD06D358FF1BA_marshal_pinvoke, Ephemeron_t6F0B12401657FF132AB44052E5BCD06D358FF1BA_marshal_pinvoke_back, Ephemeron_t6F0B12401657FF132AB44052E5BCD06D358FF1BA_marshal_pinvoke_cleanup, NULL, NULL, &Ephemeron_t6F0B12401657FF132AB44052E5BCD06D358FF1BA_0_0_0 } /* System.Runtime.CompilerServices.Ephemeron */,
	{ NULL, TaskAwaiter_t0CDE8DBB564F0A0EA55FA6B3D43EEF96BC26252F_marshal_pinvoke, TaskAwaiter_t0CDE8DBB564F0A0EA55FA6B3D43EEF96BC26252F_marshal_pinvoke_back, TaskAwaiter_t0CDE8DBB564F0A0EA55FA6B3D43EEF96BC26252F_marshal_pinvoke_cleanup, NULL, NULL, &TaskAwaiter_t0CDE8DBB564F0A0EA55FA6B3D43EEF96BC26252F_0_0_0 } /* System.Runtime.CompilerServices.TaskAwaiter */,
	{ NULL, ProcessMessageRes_t17F028A89C1685A6BE96D7B59DD490E4CB859957_marshal_pinvoke, ProcessMessageRes_t17F028A89C1685A6BE96D7B59DD490E4CB859957_marshal_pinvoke_back, ProcessMessageRes_t17F028A89C1685A6BE96D7B59DD490E4CB859957_marshal_pinvoke_cleanup, NULL, NULL, &ProcessMessageRes_t17F028A89C1685A6BE96D7B59DD490E4CB859957_0_0_0 } /* System.Runtime.Remoting.Channels.CrossAppDomainSink/ProcessMessageRes */,
	{ NULL, Context_tE86AB6B3D9759C8E715184808579EFE761683724_marshal_pinvoke, Context_tE86AB6B3D9759C8E715184808579EFE761683724_marshal_pinvoke_back, Context_tE86AB6B3D9759C8E715184808579EFE761683724_marshal_pinvoke_cleanup, NULL, NULL, &Context_tE86AB6B3D9759C8E715184808579EFE761683724_0_0_0 } /* System.Runtime.Remoting.Contexts.Context */,
	{ DelegatePInvokeWrapper_CrossContextDelegate_tB042FB42C495873AAE7558740B190D857C74CD9F, NULL, NULL, NULL, NULL, NULL, &CrossContextDelegate_tB042FB42C495873AAE7558740B190D857C74CD9F_0_0_0 } /* System.Runtime.Remoting.Contexts.CrossContextDelegate */,
	{ NULL, AsyncResult_tCCDC69FF29D3DE32F7BD57870BBC329EFF8E58E2_marshal_pinvoke, AsyncResult_tCCDC69FF29D3DE32F7BD57870BBC329EFF8E58E2_marshal_pinvoke_back, AsyncResult_tCCDC69FF29D3DE32F7BD57870BBC329EFF8E58E2_marshal_pinvoke_cleanup, NULL, NULL, &AsyncResult_tCCDC69FF29D3DE32F7BD57870BBC329EFF8E58E2_0_0_0 } /* System.Runtime.Remoting.Messaging.AsyncResult */,
	{ NULL, Reader_t8A0F3818A710941785287CE8D7184C05480C2EA6_marshal_pinvoke, Reader_t8A0F3818A710941785287CE8D7184C05480C2EA6_marshal_pinvoke_back, Reader_t8A0F3818A710941785287CE8D7184C05480C2EA6_marshal_pinvoke_cleanup, NULL, NULL, &Reader_t8A0F3818A710941785287CE8D7184C05480C2EA6_0_0_0 } /* System.Runtime.Remoting.Messaging.LogicalCallContext/Reader */,
	{ NULL, MonoMethodMessage_t0846334ADE91F66FECE638BEF57256CFF6EEA234_marshal_pinvoke, MonoMethodMessage_t0846334ADE91F66FECE638BEF57256CFF6EEA234_marshal_pinvoke_back, MonoMethodMessage_t0846334ADE91F66FECE638BEF57256CFF6EEA234_marshal_pinvoke_cleanup, NULL, NULL, &MonoMethodMessage_t0846334ADE91F66FECE638BEF57256CFF6EEA234_0_0_0 } /* System.Runtime.Remoting.Messaging.MonoMethodMessage */,
	{ NULL, RealProxy_t4B0A745F7C99373132CC67FE86D13421411361EF_marshal_pinvoke, RealProxy_t4B0A745F7C99373132CC67FE86D13421411361EF_marshal_pinvoke_back, RealProxy_t4B0A745F7C99373132CC67FE86D13421411361EF_marshal_pinvoke_cleanup, NULL, NULL, &RealProxy_t4B0A745F7C99373132CC67FE86D13421411361EF_0_0_0 } /* System.Runtime.Remoting.Proxies.RealProxy */,
	{ NULL, TransparentProxy_t86DE1FBB00F5A5B8859BB8E8375ED2F5C42D8000_marshal_pinvoke, TransparentProxy_t86DE1FBB00F5A5B8859BB8E8375ED2F5C42D8000_marshal_pinvoke_back, TransparentProxy_t86DE1FBB00F5A5B8859BB8E8375ED2F5C42D8000_marshal_pinvoke_cleanup, NULL, NULL, &TransparentProxy_t86DE1FBB00F5A5B8859BB8E8375ED2F5C42D8000_0_0_0 } /* System.Runtime.Remoting.Proxies.TransparentProxy */,
	{ NULL, SerializationEntry_tA4CE7B0176B45BD820A7802C84479174F5EBE5EA_marshal_pinvoke, SerializationEntry_tA4CE7B0176B45BD820A7802C84479174F5EBE5EA_marshal_pinvoke_back, SerializationEntry_tA4CE7B0176B45BD820A7802C84479174F5EBE5EA_marshal_pinvoke_cleanup, NULL, NULL, &SerializationEntry_tA4CE7B0176B45BD820A7802C84479174F5EBE5EA_0_0_0 } /* System.Runtime.Serialization.SerializationEntry */,
	{ DelegatePInvokeWrapper_SerializationEventHandler_t89AF9E752DCE27CE604337BD1FFE644B37D5CB6A, NULL, NULL, NULL, NULL, NULL, &SerializationEventHandler_t89AF9E752DCE27CE604337BD1FFE644B37D5CB6A_0_0_0 } /* System.Runtime.Serialization.SerializationEventHandler */,
	{ NULL, StreamingContext_t2CCDC54E0E8D078AF4A50E3A8B921B828A900034_marshal_pinvoke, StreamingContext_t2CCDC54E0E8D078AF4A50E3A8B921B828A900034_marshal_pinvoke_back, StreamingContext_t2CCDC54E0E8D078AF4A50E3A8B921B828A900034_marshal_pinvoke_cleanup, NULL, NULL, &StreamingContext_t2CCDC54E0E8D078AF4A50E3A8B921B828A900034_0_0_0 } /* System.Runtime.Serialization.StreamingContext */,
	{ NULL, HashAlgorithmName_tD62515D9082F4E5599534680DC6E20D5B638A18F_marshal_pinvoke, HashAlgorithmName_tD62515D9082F4E5599534680DC6E20D5B638A18F_marshal_pinvoke_back, HashAlgorithmName_tD62515D9082F4E5599534680DC6E20D5B638A18F_marshal_pinvoke_cleanup, NULL, NULL, &HashAlgorithmName_tD62515D9082F4E5599534680DC6E20D5B638A18F_0_0_0 } /* System.Security.Cryptography.HashAlgorithmName */,
	{ NULL, CancellationCallbackCoreWorkArguments_t6290788CA17D8028FC4BC98AE2EDD437396675DB_marshal_pinvoke, CancellationCallbackCoreWorkArguments_t6290788CA17D8028FC4BC98AE2EDD437396675DB_marshal_pinvoke_back, CancellationCallbackCoreWorkArguments_t6290788CA17D8028FC4BC98AE2EDD437396675DB_marshal_pinvoke_cleanup, NULL, NULL, &CancellationCallbackCoreWorkArguments_t6290788CA17D8028FC4BC98AE2EDD437396675DB_0_0_0 } /* System.Threading.CancellationCallbackCoreWorkArguments */,
	{ NULL, CancellationToken_t9E956952F7F20908F2AE72EDF36D97E6C7DB63AB_marshal_pinvoke, CancellationToken_t9E956952F7F20908F2AE72EDF36D97E6C7DB63AB_marshal_pinvoke_back, CancellationToken_t9E956952F7F20908F2AE72EDF36D97E6C7DB63AB_marshal_pinvoke_cleanup, NULL, NULL, &CancellationToken_t9E956952F7F20908F2AE72EDF36D97E6C7DB63AB_0_0_0 } /* System.Threading.CancellationToken */,
	{ NULL, CancellationTokenRegistration_tCDB9825D1854DD0D7FF737C82B099FC468107BB2_marshal_pinvoke, CancellationTokenRegistration_tCDB9825D1854DD0D7FF737C82B099FC468107BB2_marshal_pinvoke_back, CancellationTokenRegistration_tCDB9825D1854DD0D7FF737C82B099FC468107BB2_marshal_pinvoke_cleanup, NULL, NULL, &CancellationTokenRegistration_tCDB9825D1854DD0D7FF737C82B099FC468107BB2_0_0_0 } /* System.Threading.CancellationTokenRegistration */,
	{ NULL, Reader_t5766DE258B6B590281150D8DB517B651F9F4F33B_marshal_pinvoke, Reader_t5766DE258B6B590281150D8DB517B651F9F4F33B_marshal_pinvoke_back, Reader_t5766DE258B6B590281150D8DB517B651F9F4F33B_marshal_pinvoke_cleanup, NULL, NULL, &Reader_t5766DE258B6B590281150D8DB517B651F9F4F33B_0_0_0 } /* System.Threading.ExecutionContext/Reader */,
	{ NULL, ExecutionContextSwitcher_t739C861A327D724A4E59DE865463B32097395159_marshal_pinvoke, ExecutionContextSwitcher_t739C861A327D724A4E59DE865463B32097395159_marshal_pinvoke_back, ExecutionContextSwitcher_t739C861A327D724A4E59DE865463B32097395159_marshal_pinvoke_cleanup, NULL, NULL, &ExecutionContextSwitcher_t739C861A327D724A4E59DE865463B32097395159_0_0_0 } /* System.Threading.ExecutionContextSwitcher */,
	{ DelegatePInvokeWrapper_ThreadStart_t09FFA4371E4B2A713F212B157CC9B8B61983B5BF, NULL, NULL, NULL, NULL, NULL, &ThreadStart_t09FFA4371E4B2A713F212B157CC9B8B61983B5BF_0_0_0 } /* System.Threading.ThreadStart */,
	{ NULL, WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6_marshal_pinvoke, WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6_marshal_pinvoke_back, WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6_marshal_pinvoke_cleanup, NULL, NULL, &WaitHandle_tFD46B5B45A6BB296EA3A104C91DF2A7C03C10AC6_0_0_0 } /* System.Threading.WaitHandle */,
	{ NULL, DYNAMIC_TIME_ZONE_INFORMATION_tE2A7A07ADC8726A5FC7954EA9CDE9168756C9B1F_marshal_pinvoke, DYNAMIC_TIME_ZONE_INFORMATION_tE2A7A07ADC8726A5FC7954EA9CDE9168756C9B1F_marshal_pinvoke_back, DYNAMIC_TIME_ZONE_INFORMATION_tE2A7A07ADC8726A5FC7954EA9CDE9168756C9B1F_marshal_pinvoke_cleanup, NULL, NULL, &DYNAMIC_TIME_ZONE_INFORMATION_tE2A7A07ADC8726A5FC7954EA9CDE9168756C9B1F_0_0_0 } /* System.TimeZoneInfo/DYNAMIC_TIME_ZONE_INFORMATION */,
	{ NULL, TIME_ZONE_INFORMATION_tE8C6F24D5D50D01E03E52B00DDF74849F3DE9811_marshal_pinvoke, TIME_ZONE_INFORMATION_tE8C6F24D5D50D01E03E52B00DDF74849F3DE9811_marshal_pinvoke_back, TIME_ZONE_INFORMATION_tE8C6F24D5D50D01E03E52B00DDF74849F3DE9811_marshal_pinvoke_cleanup, NULL, NULL, &TIME_ZONE_INFORMATION_tE8C6F24D5D50D01E03E52B00DDF74849F3DE9811_0_0_0 } /* System.TimeZoneInfo/TIME_ZONE_INFORMATION */,
	{ NULL, TransitionTime_t9958178434A0688FD45EF028B1AE9EA665C3E116_marshal_pinvoke, TransitionTime_t9958178434A0688FD45EF028B1AE9EA665C3E116_marshal_pinvoke_back, TransitionTime_t9958178434A0688FD45EF028B1AE9EA665C3E116_marshal_pinvoke_cleanup, NULL, NULL, &TransitionTime_t9958178434A0688FD45EF028B1AE9EA665C3E116_0_0_0 } /* System.TimeZoneInfo/TransitionTime */,
	{ NULL, UnSafeCharBuffer_t99F0962CE65E71C4BA612D5434276C51AC33AF0C_marshal_pinvoke, UnSafeCharBuffer_t99F0962CE65E71C4BA612D5434276C51AC33AF0C_marshal_pinvoke_back, UnSafeCharBuffer_t99F0962CE65E71C4BA612D5434276C51AC33AF0C_marshal_pinvoke_cleanup, NULL, NULL, &UnSafeCharBuffer_t99F0962CE65E71C4BA612D5434276C51AC33AF0C_0_0_0 } /* System.UnSafeCharBuffer */,
	{ NULL, ValueType_t4D0C27076F7C36E76190FB3328E232BCB1CD1FFF_marshal_pinvoke, ValueType_t4D0C27076F7C36E76190FB3328E232BCB1CD1FFF_marshal_pinvoke_back, ValueType_t4D0C27076F7C36E76190FB3328E232BCB1CD1FFF_marshal_pinvoke_cleanup, NULL, NULL, &ValueType_t4D0C27076F7C36E76190FB3328E232BCB1CD1FFF_0_0_0 } /* System.ValueType */,
	{ NULL, VersionResult_tA97F3FDF3CF3FF5D0E43768C08D1C4D4568E88CE_marshal_pinvoke, VersionResult_tA97F3FDF3CF3FF5D0E43768C08D1C4D4568E88CE_marshal_pinvoke_back, VersionResult_tA97F3FDF3CF3FF5D0E43768C08D1C4D4568E88CE_marshal_pinvoke_cleanup, NULL, NULL, &VersionResult_tA97F3FDF3CF3FF5D0E43768C08D1C4D4568E88CE_0_0_0 } /* System.Version/VersionResult */,
	{ NULL, __DTString_t6E7DE2A99E4F15F384EC29CC6CD5185F46818DD9_marshal_pinvoke, __DTString_t6E7DE2A99E4F15F384EC29CC6CD5185F46818DD9_marshal_pinvoke_back, __DTString_t6E7DE2A99E4F15F384EC29CC6CD5185F46818DD9_marshal_pinvoke_cleanup, NULL, NULL, &__DTString_t6E7DE2A99E4F15F384EC29CC6CD5185F46818DD9_0_0_0 } /* System.__DTString */,
	{ NULL, XPathNode_tC207ED6C653E80055FE6C5ECD3E6137A326659A0_marshal_pinvoke, XPathNode_tC207ED6C653E80055FE6C5ECD3E6137A326659A0_marshal_pinvoke_back, XPathNode_tC207ED6C653E80055FE6C5ECD3E6137A326659A0_marshal_pinvoke_cleanup, NULL, NULL, &XPathNode_tC207ED6C653E80055FE6C5ECD3E6137A326659A0_0_0_0 } /* MS.Internal.Xml.Cache.XPathNode */,
	{ NULL, XPathNodeRef_t6F631244BF7B58CE7DB9239662B4EE745CD54E14_marshal_pinvoke, XPathNodeRef_t6F631244BF7B58CE7DB9239662B4EE745CD54E14_marshal_pinvoke_back, XPathNodeRef_t6F631244BF7B58CE7DB9239662B4EE745CD54E14_marshal_pinvoke_cleanup, NULL, NULL, &XPathNodeRef_t6F631244BF7B58CE7DB9239662B4EE745CD54E14_0_0_0 } /* MS.Internal.Xml.Cache.XPathNodeRef */,
	{ NULL, FacetsCompiler_t91E639F7F083D79393593CD660539AC912314233_marshal_pinvoke, FacetsCompiler_t91E639F7F083D79393593CD660539AC912314233_marshal_pinvoke_back, FacetsCompiler_t91E639F7F083D79393593CD660539AC912314233_marshal_pinvoke_cleanup, NULL, NULL, &FacetsCompiler_t91E639F7F083D79393593CD660539AC912314233_0_0_0 } /* System.Xml.Schema.FacetsChecker/FacetsCompiler */,
	{ NULL, Map_t95CF8863CD8CAC88704F399964E9ED0524DD731D_marshal_pinvoke, Map_t95CF8863CD8CAC88704F399964E9ED0524DD731D_marshal_pinvoke_back, Map_t95CF8863CD8CAC88704F399964E9ED0524DD731D_marshal_pinvoke_cleanup, NULL, NULL, &Map_t95CF8863CD8CAC88704F399964E9ED0524DD731D_0_0_0 } /* System.Xml.Schema.FacetsChecker/FacetsCompiler/Map */,
	{ NULL, Position_t089976E4BEB3D345DA28CFA95786EE065063E228_marshal_pinvoke, Position_t089976E4BEB3D345DA28CFA95786EE065063E228_marshal_pinvoke_back, Position_t089976E4BEB3D345DA28CFA95786EE065063E228_marshal_pinvoke_cleanup, NULL, NULL, &Position_t089976E4BEB3D345DA28CFA95786EE065063E228_0_0_0 } /* System.Xml.Schema.Position */,
	{ NULL, RangePositionInfo_tDCA2617E7E1292998A9700E38DBBA177330A80CA_marshal_pinvoke, RangePositionInfo_tDCA2617E7E1292998A9700E38DBBA177330A80CA_marshal_pinvoke_back, RangePositionInfo_tDCA2617E7E1292998A9700E38DBBA177330A80CA_marshal_pinvoke_cleanup, NULL, NULL, &RangePositionInfo_tDCA2617E7E1292998A9700E38DBBA177330A80CA_0_0_0 } /* System.Xml.Schema.RangePositionInfo */,
	{ NULL, SequenceConstructPosContext_t72DF930B1BE2676BD225E8D9622C78EF2B0DFAC1_marshal_pinvoke, SequenceConstructPosContext_t72DF930B1BE2676BD225E8D9622C78EF2B0DFAC1_marshal_pinvoke_back, SequenceConstructPosContext_t72DF930B1BE2676BD225E8D9622C78EF2B0DFAC1_marshal_pinvoke_cleanup, NULL, NULL, &SequenceConstructPosContext_t72DF930B1BE2676BD225E8D9622C78EF2B0DFAC1_0_0_0 } /* System.Xml.Schema.SequenceNode/SequenceConstructPosContext */,
	{ NULL, Union_t75FE76D5ECF7F32BF3656D21BD446F4E42996391_marshal_pinvoke, Union_t75FE76D5ECF7F32BF3656D21BD446F4E42996391_marshal_pinvoke_back, Union_t75FE76D5ECF7F32BF3656D21BD446F4E42996391_marshal_pinvoke_cleanup, NULL, NULL, &Union_t75FE76D5ECF7F32BF3656D21BD446F4E42996391_0_0_0 } /* System.Xml.Schema.XmlAtomicValue/Union */,
	{ NULL, XmlSchemaObjectEntry_tD7A5D31C794A4D04759882DDAD01103D2C19D63B_marshal_pinvoke, XmlSchemaObjectEntry_tD7A5D31C794A4D04759882DDAD01103D2C19D63B_marshal_pinvoke_back, XmlSchemaObjectEntry_tD7A5D31C794A4D04759882DDAD01103D2C19D63B_marshal_pinvoke_cleanup, NULL, NULL, &XmlSchemaObjectEntry_tD7A5D31C794A4D04759882DDAD01103D2C19D63B_0_0_0 } /* System.Xml.Schema.XmlSchemaObjectTable/XmlSchemaObjectEntry */,
	{ NULL, XsdDateTime_tEA54A4A77DD9458E97F1306F2013714582663CC5_marshal_pinvoke, XsdDateTime_tEA54A4A77DD9458E97F1306F2013714582663CC5_marshal_pinvoke_back, XsdDateTime_tEA54A4A77DD9458E97F1306F2013714582663CC5_marshal_pinvoke_cleanup, NULL, NULL, &XsdDateTime_tEA54A4A77DD9458E97F1306F2013714582663CC5_0_0_0 } /* System.Xml.Schema.XsdDateTime */,
	{ NULL, Parser_t402903C4103D1084228988A8DA76C1FCB8D890B9_marshal_pinvoke, Parser_t402903C4103D1084228988A8DA76C1FCB8D890B9_marshal_pinvoke_back, Parser_t402903C4103D1084228988A8DA76C1FCB8D890B9_marshal_pinvoke_cleanup, NULL, NULL, &Parser_t402903C4103D1084228988A8DA76C1FCB8D890B9_0_0_0 } /* System.Xml.Schema.XsdDateTime/Parser */,
	{ DelegatePInvokeWrapper_HashCodeOfStringDelegate_tC8B9E43DCB47789C0CCA2921BE18838AB95B323E, NULL, NULL, NULL, NULL, NULL, &HashCodeOfStringDelegate_tC8B9E43DCB47789C0CCA2921BE18838AB95B323E_0_0_0 } /* System.Xml.SecureStringHasher/HashCodeOfStringDelegate */,
	{ NULL, SmallXmlNodeList_t962D7A66CF19950FE6DFA9476903952B76844A1E_marshal_pinvoke, SmallXmlNodeList_t962D7A66CF19950FE6DFA9476903952B76844A1E_marshal_pinvoke_back, SmallXmlNodeList_t962D7A66CF19950FE6DFA9476903952B76844A1E_marshal_pinvoke_cleanup, NULL, NULL, &SmallXmlNodeList_t962D7A66CF19950FE6DFA9476903952B76844A1E_0_0_0 } /* System.Xml.XmlNamedNodeMap/SmallXmlNodeList */,
	{ NULL, NamespaceDeclaration_tFD9A771E0585F887CE869FA7D0FAD365A40D436A_marshal_pinvoke, NamespaceDeclaration_tFD9A771E0585F887CE869FA7D0FAD365A40D436A_marshal_pinvoke_back, NamespaceDeclaration_tFD9A771E0585F887CE869FA7D0FAD365A40D436A_marshal_pinvoke_cleanup, NULL, NULL, &NamespaceDeclaration_tFD9A771E0585F887CE869FA7D0FAD365A40D436A_0_0_0 } /* System.Xml.XmlNamespaceManager/NamespaceDeclaration */,
	{ NULL, VirtualAttribute_t3CED95AE4D2D98B3E1C79C4CA6C4B076326DC465_marshal_pinvoke, VirtualAttribute_t3CED95AE4D2D98B3E1C79C4CA6C4B076326DC465_marshal_pinvoke_back, VirtualAttribute_t3CED95AE4D2D98B3E1C79C4CA6C4B076326DC465_marshal_pinvoke_cleanup, NULL, NULL, &VirtualAttribute_t3CED95AE4D2D98B3E1C79C4CA6C4B076326DC465_0_0_0 } /* System.Xml.XmlNodeReaderNavigator/VirtualAttribute */,
	{ DelegatePInvokeWrapper_HashCodeOfStringDelegate_tCAF2245F039C500045953429EF1FB0BA86326AE8, NULL, NULL, NULL, NULL, NULL, &HashCodeOfStringDelegate_tCAF2245F039C500045953429EF1FB0BA86326AE8_0_0_0 } /* System.Xml.XmlQualifiedName/HashCodeOfStringDelegate */,
	{ NULL, AttrInfo_tC56788540A1F53E77E0A21E93000A66846FAFC0B_marshal_pinvoke, AttrInfo_tC56788540A1F53E77E0A21E93000A66846FAFC0B_marshal_pinvoke_back, AttrInfo_tC56788540A1F53E77E0A21E93000A66846FAFC0B_marshal_pinvoke_cleanup, NULL, NULL, &AttrInfo_tC56788540A1F53E77E0A21E93000A66846FAFC0B_0_0_0 } /* System.Xml.XmlSqlBinaryReader/AttrInfo */,
	{ NULL, ElemInfo_t930901F4C4D70BD460913E85E8B87AB5C5A8571F_marshal_pinvoke, ElemInfo_t930901F4C4D70BD460913E85E8B87AB5C5A8571F_marshal_pinvoke_back, ElemInfo_t930901F4C4D70BD460913E85E8B87AB5C5A8571F_marshal_pinvoke_cleanup, NULL, NULL, &ElemInfo_t930901F4C4D70BD460913E85E8B87AB5C5A8571F_0_0_0 } /* System.Xml.XmlSqlBinaryReader/ElemInfo */,
	{ NULL, QName_t49332A07486EFE325DF0D3F34BE798ED3497C42F_marshal_pinvoke, QName_t49332A07486EFE325DF0D3F34BE798ED3497C42F_marshal_pinvoke_back, QName_t49332A07486EFE325DF0D3F34BE798ED3497C42F_marshal_pinvoke_cleanup, NULL, NULL, &QName_t49332A07486EFE325DF0D3F34BE798ED3497C42F_0_0_0 } /* System.Xml.XmlSqlBinaryReader/QName */,
	{ NULL, SymbolTables_t8F49FC5423EF06561EBAF65E6130FA03C025325E_marshal_pinvoke, SymbolTables_t8F49FC5423EF06561EBAF65E6130FA03C025325E_marshal_pinvoke_back, SymbolTables_t8F49FC5423EF06561EBAF65E6130FA03C025325E_marshal_pinvoke_cleanup, NULL, NULL, &SymbolTables_t8F49FC5423EF06561EBAF65E6130FA03C025325E_0_0_0 } /* System.Xml.XmlSqlBinaryReader/SymbolTables */,
	{ NULL, ParsingState_tE4A8E7F14B2068AE43ECF99F81F55B0301A551A2_marshal_pinvoke, ParsingState_tE4A8E7F14B2068AE43ECF99F81F55B0301A551A2_marshal_pinvoke_back, ParsingState_tE4A8E7F14B2068AE43ECF99F81F55B0301A551A2_marshal_pinvoke_cleanup, NULL, NULL, &ParsingState_tE4A8E7F14B2068AE43ECF99F81F55B0301A551A2_0_0_0 } /* System.Xml.XmlTextReaderImpl/ParsingState */,
	{ NULL, Namespace_t092048EEBC7FF22AF20114DDA7633072C44CA26B_marshal_pinvoke, Namespace_t092048EEBC7FF22AF20114DDA7633072C44CA26B_marshal_pinvoke_back, Namespace_t092048EEBC7FF22AF20114DDA7633072C44CA26B_marshal_pinvoke_cleanup, NULL, NULL, &Namespace_t092048EEBC7FF22AF20114DDA7633072C44CA26B_0_0_0 } /* System.Xml.XmlTextWriter/Namespace */,
	{ NULL, TagInfo_t9F395B388162AB8B9277E4ABA1ADEF785AE197B5_marshal_pinvoke, TagInfo_t9F395B388162AB8B9277E4ABA1ADEF785AE197B5_marshal_pinvoke_back, TagInfo_t9F395B388162AB8B9277E4ABA1ADEF785AE197B5_marshal_pinvoke_cleanup, NULL, NULL, &TagInfo_t9F395B388162AB8B9277E4ABA1ADEF785AE197B5_0_0_0 } /* System.Xml.XmlTextWriter/TagInfo */,
	{ DelegatePInvokeWrapper_CFProxyAutoConfigurationResultCallback_t19A48665D1D7A47D6CEFF82779F5853E9B0B6506, NULL, NULL, NULL, NULL, NULL, &CFProxyAutoConfigurationResultCallback_t19A48665D1D7A47D6CEFF82779F5853E9B0B6506_0_0_0 } /* Mono.Net.CFNetwork/CFProxyAutoConfigurationResultCallback */,
	{ NULL, unitytls_interface_struct_t0AD7ED5EDF9F15F1879FC9140A7D40C8D95A1BAF_marshal_pinvoke, unitytls_interface_struct_t0AD7ED5EDF9F15F1879FC9140A7D40C8D95A1BAF_marshal_pinvoke_back, unitytls_interface_struct_t0AD7ED5EDF9F15F1879FC9140A7D40C8D95A1BAF_marshal_pinvoke_cleanup, NULL, NULL, &unitytls_interface_struct_t0AD7ED5EDF9F15F1879FC9140A7D40C8D95A1BAF_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct */,
	{ DelegatePInvokeWrapper_unitytls_errorstate_create_t_t104BADBBE1265BD1A3F84C153EB7A67CDDBF35A9, NULL, NULL, NULL, NULL, NULL, &unitytls_errorstate_create_t_t104BADBBE1265BD1A3F84C153EB7A67CDDBF35A9_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_errorstate_create_t */,
	{ DelegatePInvokeWrapper_unitytls_errorstate_raise_error_t_tC441A37D4A6F1BAC1AFCA0108D4F7570EFF9E0D1, NULL, NULL, NULL, NULL, NULL, &unitytls_errorstate_raise_error_t_tC441A37D4A6F1BAC1AFCA0108D4F7570EFF9E0D1_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_errorstate_raise_error_t */,
	{ DelegatePInvokeWrapper_unitytls_key_free_t_tCC7AD95D3B758BB99785645E65EDCD65A1D243AB, NULL, NULL, NULL, NULL, NULL, &unitytls_key_free_t_tCC7AD95D3B758BB99785645E65EDCD65A1D243AB_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_key_free_t */,
	{ DelegatePInvokeWrapper_unitytls_key_get_ref_t_t2F4EF4CD2F6AFC4F2D166953E834C6F0A13382A7, NULL, NULL, NULL, NULL, NULL, &unitytls_key_get_ref_t_t2F4EF4CD2F6AFC4F2D166953E834C6F0A13382A7_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_key_get_ref_t */,
	{ DelegatePInvokeWrapper_unitytls_key_parse_der_t_t2ABD1C146C8B9405F6E5A78CD59A779EA607741B, NULL, NULL, NULL, NULL, NULL, &unitytls_key_parse_der_t_t2ABD1C146C8B9405F6E5A78CD59A779EA607741B_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_key_parse_der_t */,
	{ DelegatePInvokeWrapper_unitytls_key_parse_pem_t_tB4BCEBA4194442C8C85FA19E80B808D0EDA462AB, NULL, NULL, NULL, NULL, NULL, &unitytls_key_parse_pem_t_tB4BCEBA4194442C8C85FA19E80B808D0EDA462AB_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_key_parse_pem_t */,
	{ DelegatePInvokeWrapper_unitytls_random_generate_bytes_t_t494B8599A6D4247BB0C8AB7341DDC73BE42623F7, NULL, NULL, NULL, NULL, NULL, &unitytls_random_generate_bytes_t_t494B8599A6D4247BB0C8AB7341DDC73BE42623F7_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_random_generate_bytes_t */,
	{ DelegatePInvokeWrapper_unitytls_tlsctx_create_client_t_tD9DFBDB5559983F0E11A67FA92E0F7182114C8F2, NULL, NULL, NULL, NULL, NULL, &unitytls_tlsctx_create_client_t_tD9DFBDB5559983F0E11A67FA92E0F7182114C8F2_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_tlsctx_create_client_t */,
	{ DelegatePInvokeWrapper_unitytls_tlsctx_create_server_t_t6E7812D40DDD91958E3CFBB92B5F5748D477E19D, NULL, NULL, NULL, NULL, NULL, &unitytls_tlsctx_create_server_t_t6E7812D40DDD91958E3CFBB92B5F5748D477E19D_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_tlsctx_create_server_t */,
	{ DelegatePInvokeWrapper_unitytls_tlsctx_free_t_tB27A3B6F9D1B784ABE082849EAB6B81F51FAC8E2, NULL, NULL, NULL, NULL, NULL, &unitytls_tlsctx_free_t_tB27A3B6F9D1B784ABE082849EAB6B81F51FAC8E2_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_tlsctx_free_t */,
	{ DelegatePInvokeWrapper_unitytls_tlsctx_get_ciphersuite_t_t94A91CB42A2EBB2CC598EF3E278770AFD80696A0, NULL, NULL, NULL, NULL, NULL, &unitytls_tlsctx_get_ciphersuite_t_t94A91CB42A2EBB2CC598EF3E278770AFD80696A0_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_tlsctx_get_ciphersuite_t */,
	{ DelegatePInvokeWrapper_unitytls_tlsctx_get_protocol_t_tB29092875D3CBD25E4461BFD165B5373FA54DB14, NULL, NULL, NULL, NULL, NULL, &unitytls_tlsctx_get_protocol_t_tB29092875D3CBD25E4461BFD165B5373FA54DB14_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_tlsctx_get_protocol_t */,
	{ DelegatePInvokeWrapper_unitytls_tlsctx_notify_close_t_t2FC4C08BACF1AEA509ABCAF3B22475E196E74A0D, NULL, NULL, NULL, NULL, NULL, &unitytls_tlsctx_notify_close_t_t2FC4C08BACF1AEA509ABCAF3B22475E196E74A0D_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_tlsctx_notify_close_t */,
	{ DelegatePInvokeWrapper_unitytls_tlsctx_process_handshake_t_tC8AAF317CBE4CA216F22BF031ECF89315B963C9D, NULL, NULL, NULL, NULL, NULL, &unitytls_tlsctx_process_handshake_t_tC8AAF317CBE4CA216F22BF031ECF89315B963C9D_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_tlsctx_process_handshake_t */,
	{ DelegatePInvokeWrapper_unitytls_tlsctx_read_t_tA8D1209D5F488E02F826EE2362F5AA61C8FF2EE2, NULL, NULL, NULL, NULL, NULL, &unitytls_tlsctx_read_t_tA8D1209D5F488E02F826EE2362F5AA61C8FF2EE2_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_tlsctx_read_t */,
	{ DelegatePInvokeWrapper_unitytls_tlsctx_server_require_client_authentication_t_t77B3CAFF25690A45405E3C957E40CC4FF83B49C6, NULL, NULL, NULL, NULL, NULL, &unitytls_tlsctx_server_require_client_authentication_t_t77B3CAFF25690A45405E3C957E40CC4FF83B49C6_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_tlsctx_server_require_client_authentication_t */,
	{ DelegatePInvokeWrapper_unitytls_tlsctx_set_certificate_callback_t_tC4864FE0F6A3398A572F2511AA64C72126640937, NULL, NULL, NULL, NULL, NULL, &unitytls_tlsctx_set_certificate_callback_t_tC4864FE0F6A3398A572F2511AA64C72126640937_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_tlsctx_set_certificate_callback_t */,
	{ DelegatePInvokeWrapper_unitytls_tlsctx_set_supported_ciphersuites_t_t6914054EA0F7A59C8A4ED4B9CDD5AF143F7D8BFE, NULL, NULL, NULL, NULL, NULL, &unitytls_tlsctx_set_supported_ciphersuites_t_t6914054EA0F7A59C8A4ED4B9CDD5AF143F7D8BFE_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_tlsctx_set_supported_ciphersuites_t */,
	{ DelegatePInvokeWrapper_unitytls_tlsctx_set_trace_callback_t_tA11F424F68D297B6FD2B2EA26C6764F80146662A, NULL, NULL, NULL, NULL, NULL, &unitytls_tlsctx_set_trace_callback_t_tA11F424F68D297B6FD2B2EA26C6764F80146662A_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_tlsctx_set_trace_callback_t */,
	{ DelegatePInvokeWrapper_unitytls_tlsctx_set_x509verify_callback_t_t34EEB7BA38CA2C86F847416785ADB22BC4A04F4B, NULL, NULL, NULL, NULL, NULL, &unitytls_tlsctx_set_x509verify_callback_t_t34EEB7BA38CA2C86F847416785ADB22BC4A04F4B_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_tlsctx_set_x509verify_callback_t */,
	{ DelegatePInvokeWrapper_unitytls_tlsctx_write_t_t0B4A49BBA592FE4EC0630B490463AE116AF07C9C, NULL, NULL, NULL, NULL, NULL, &unitytls_tlsctx_write_t_t0B4A49BBA592FE4EC0630B490463AE116AF07C9C_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_tlsctx_write_t */,
	{ DelegatePInvokeWrapper_unitytls_x509_export_der_t_tB0D0A02DE7E75757AFCA780298BF95467BF82856, NULL, NULL, NULL, NULL, NULL, &unitytls_x509_export_der_t_tB0D0A02DE7E75757AFCA780298BF95467BF82856_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_x509_export_der_t */,
	{ DelegatePInvokeWrapper_unitytls_x509list_append_der_t_tDA1C93A382058FB563F8772B119D5B598DC37A5C, NULL, NULL, NULL, NULL, NULL, &unitytls_x509list_append_der_t_tDA1C93A382058FB563F8772B119D5B598DC37A5C_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_x509list_append_der_t */,
	{ DelegatePInvokeWrapper_unitytls_x509list_append_t_tAB1C185C77DFD6BD96DF7909370AA1FAD6BB90AF, NULL, NULL, NULL, NULL, NULL, &unitytls_x509list_append_t_tAB1C185C77DFD6BD96DF7909370AA1FAD6BB90AF_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_x509list_append_t */,
	{ DelegatePInvokeWrapper_unitytls_x509list_create_t_tC040C2CF47D5426B7F6B1D6A2751507DC681CFF3, NULL, NULL, NULL, NULL, NULL, &unitytls_x509list_create_t_tC040C2CF47D5426B7F6B1D6A2751507DC681CFF3_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_x509list_create_t */,
	{ DelegatePInvokeWrapper_unitytls_x509list_free_t_tE3FC523507F07BD9901D84E9F6968CD8A583FF09, NULL, NULL, NULL, NULL, NULL, &unitytls_x509list_free_t_tE3FC523507F07BD9901D84E9F6968CD8A583FF09_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_x509list_free_t */,
	{ DelegatePInvokeWrapper_unitytls_x509list_get_ref_t_t1FAB0CD82E536E0C9EB5255B145FC5AF434B3986, NULL, NULL, NULL, NULL, NULL, &unitytls_x509list_get_ref_t_t1FAB0CD82E536E0C9EB5255B145FC5AF434B3986_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_x509list_get_ref_t */,
	{ DelegatePInvokeWrapper_unitytls_x509list_get_x509_t_t028BB06EEB95E8F62511F2301B90D8181F4FFDB5, NULL, NULL, NULL, NULL, NULL, &unitytls_x509list_get_x509_t_t028BB06EEB95E8F62511F2301B90D8181F4FFDB5_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_x509list_get_x509_t */,
	{ DelegatePInvokeWrapper_unitytls_x509verify_default_ca_t_t4BACB6B49AA85C025AF9B18B3F30F63C9881DE2D, NULL, NULL, NULL, NULL, NULL, &unitytls_x509verify_default_ca_t_t4BACB6B49AA85C025AF9B18B3F30F63C9881DE2D_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_x509verify_default_ca_t */,
	{ DelegatePInvokeWrapper_unitytls_x509verify_explicit_ca_t_t6C8BE964C5EE9B24D3734F028EFCD83F5893D2E6, NULL, NULL, NULL, NULL, NULL, &unitytls_x509verify_explicit_ca_t_t6C8BE964C5EE9B24D3734F028EFCD83F5893D2E6_0_0_0 } /* Mono.Unity.UnityTls/unitytls_interface_struct/unitytls_x509verify_explicit_ca_t */,
	{ NULL, unitytls_tlsctx_callbacks_t7BB5F622E014A8EC300C578657E2B0550DA828B2_marshal_pinvoke, unitytls_tlsctx_callbacks_t7BB5F622E014A8EC300C578657E2B0550DA828B2_marshal_pinvoke_back, unitytls_tlsctx_callbacks_t7BB5F622E014A8EC300C578657E2B0550DA828B2_marshal_pinvoke_cleanup, NULL, NULL, &unitytls_tlsctx_callbacks_t7BB5F622E014A8EC300C578657E2B0550DA828B2_0_0_0 } /* Mono.Unity.UnityTls/unitytls_tlsctx_callbacks */,
	{ DelegatePInvokeWrapper_unitytls_tlsctx_certificate_callback_t55149A988CA1CE32772ACAC0031DAF4DC0F6D740, NULL, NULL, NULL, NULL, NULL, &unitytls_tlsctx_certificate_callback_t55149A988CA1CE32772ACAC0031DAF4DC0F6D740_0_0_0 } /* Mono.Unity.UnityTls/unitytls_tlsctx_certificate_callback */,
	{ DelegatePInvokeWrapper_unitytls_tlsctx_read_callback_tD85E7923018681355C1D851137CEC527F04093F5, NULL, NULL, NULL, NULL, NULL, &unitytls_tlsctx_read_callback_tD85E7923018681355C1D851137CEC527F04093F5_0_0_0 } /* Mono.Unity.UnityTls/unitytls_tlsctx_read_callback */,
	{ DelegatePInvokeWrapper_unitytls_tlsctx_trace_callback_t2C8F0895EF17ECAC042835D68A6BFDB9CBC7F2AA, NULL, NULL, NULL, NULL, NULL, &unitytls_tlsctx_trace_callback_t2C8F0895EF17ECAC042835D68A6BFDB9CBC7F2AA_0_0_0 } /* Mono.Unity.UnityTls/unitytls_tlsctx_trace_callback */,
	{ DelegatePInvokeWrapper_unitytls_tlsctx_write_callback_tBDF40F27E011F577C3E834B14788491861F870D6, NULL, NULL, NULL, NULL, NULL, &unitytls_tlsctx_write_callback_tBDF40F27E011F577C3E834B14788491861F870D6_0_0_0 } /* Mono.Unity.UnityTls/unitytls_tlsctx_write_callback */,
	{ DelegatePInvokeWrapper_unitytls_tlsctx_x509verify_callback_t5FCF0307C4AB263BC611FE396EC4D2B9CF93528A, NULL, NULL, NULL, NULL, NULL, &unitytls_tlsctx_x509verify_callback_t5FCF0307C4AB263BC611FE396EC4D2B9CF93528A_0_0_0 } /* Mono.Unity.UnityTls/unitytls_tlsctx_x509verify_callback */,
	{ DelegatePInvokeWrapper_unitytls_x509verify_callback_t90C02C529DB2B9F434C18797BACC456BCB5400A9, NULL, NULL, NULL, NULL, NULL, &unitytls_x509verify_callback_t90C02C529DB2B9F434C18797BACC456BCB5400A9_0_0_0 } /* Mono.Unity.UnityTls/unitytls_x509verify_callback */,
	{ NULL, AttributeEntry_t03E9BFE6BF6BE56EA2568359ACD774FE8C8661DD_marshal_pinvoke, AttributeEntry_t03E9BFE6BF6BE56EA2568359ACD774FE8C8661DD_marshal_pinvoke_back, AttributeEntry_t03E9BFE6BF6BE56EA2568359ACD774FE8C8661DD_marshal_pinvoke_cleanup, NULL, NULL, &AttributeEntry_t03E9BFE6BF6BE56EA2568359ACD774FE8C8661DD_0_0_0 } /* System.ComponentModel.AttributeCollection/AttributeEntry */,
	{ NULL, DefaultExtendedTypeDescriptor_t89890252F6A685D141ECBB0C2878C6E913883ECE_marshal_pinvoke, DefaultExtendedTypeDescriptor_t89890252F6A685D141ECBB0C2878C6E913883ECE_marshal_pinvoke_back, DefaultExtendedTypeDescriptor_t89890252F6A685D141ECBB0C2878C6E913883ECE_marshal_pinvoke_cleanup, NULL, NULL, &DefaultExtendedTypeDescriptor_t89890252F6A685D141ECBB0C2878C6E913883ECE_0_0_0 } /* System.ComponentModel.TypeDescriptor/TypeDescriptionNode/DefaultExtendedTypeDescriptor */,
	{ NULL, DefaultTypeDescriptor_t45C7CF272F02817B0F1C69470B4E786E746996F4_marshal_pinvoke, DefaultTypeDescriptor_t45C7CF272F02817B0F1C69470B4E786E746996F4_marshal_pinvoke_back, DefaultTypeDescriptor_t45C7CF272F02817B0F1C69470B4E786E746996F4_marshal_pinvoke_cleanup, NULL, NULL, &DefaultTypeDescriptor_t45C7CF272F02817B0F1C69470B4E786E746996F4_0_0_0 } /* System.ComponentModel.TypeDescriptor/TypeDescriptionNode/DefaultTypeDescriptor */,
	{ NULL, ProcInfo_t3E3017C52253681B44DDCB325D45E7D7526E9424_marshal_pinvoke, ProcInfo_t3E3017C52253681B44DDCB325D45E7D7526E9424_marshal_pinvoke_back, ProcInfo_t3E3017C52253681B44DDCB325D45E7D7526E9424_marshal_pinvoke_cleanup, NULL, NULL, &ProcInfo_t3E3017C52253681B44DDCB325D45E7D7526E9424_0_0_0 } /* System.Diagnostics.Process/ProcInfo */,
	{ NULL, ProcessStartInfo_t5130526E78224EE02475E7A0FBF5BCE821977706_marshal_pinvoke, ProcessStartInfo_t5130526E78224EE02475E7A0FBF5BCE821977706_marshal_pinvoke_back, ProcessStartInfo_t5130526E78224EE02475E7A0FBF5BCE821977706_marshal_pinvoke_cleanup, NULL, NULL, &ProcessStartInfo_t5130526E78224EE02475E7A0FBF5BCE821977706_0_0_0 } /* System.Diagnostics.ProcessStartInfo */,
	{ DelegatePInvokeWrapper_ReadMethod_t6D92A091070756743232D28A30A05FFCFB7928C4, NULL, NULL, NULL, NULL, NULL, &ReadMethod_t6D92A091070756743232D28A30A05FFCFB7928C4_0_0_0 } /* System.IO.Compression.DeflateStream/ReadMethod */,
	{ DelegatePInvokeWrapper_WriteMethod_tA5073EA0B599530C5CB5FF202832E16DD4C48397, NULL, NULL, NULL, NULL, NULL, &WriteMethod_tA5073EA0B599530C5CB5FF202832E16DD4C48397_0_0_0 } /* System.IO.Compression.DeflateStream/WriteMethod */,
	{ DelegatePInvokeWrapper_UnmanagedReadOrWrite_tE27F26A26800EB8FA74A54956323F29F04E055B0, NULL, NULL, NULL, NULL, NULL, &UnmanagedReadOrWrite_tE27F26A26800EB8FA74A54956323F29F04E055B0_0_0_0 } /* System.IO.Compression.DeflateStreamNative/UnmanagedReadOrWrite */,
	{ NULL, IOAsyncResult_tB02ABC485035B18A731F1B61FB27EE17F4B792AD_marshal_pinvoke, IOAsyncResult_tB02ABC485035B18A731F1B61FB27EE17F4B792AD_marshal_pinvoke_back, IOAsyncResult_tB02ABC485035B18A731F1B61FB27EE17F4B792AD_marshal_pinvoke_cleanup, NULL, NULL, &IOAsyncResult_tB02ABC485035B18A731F1B61FB27EE17F4B792AD_0_0_0 } /* System.IOAsyncResult */,
	{ NULL, IOSelectorJob_t2B03604D19B81660C4C1C06590C76BC8630DDE99_marshal_pinvoke, IOSelectorJob_t2B03604D19B81660C4C1C06590C76BC8630DDE99_marshal_pinvoke_back, IOSelectorJob_t2B03604D19B81660C4C1C06590C76BC8630DDE99_marshal_pinvoke_cleanup, NULL, NULL, &IOSelectorJob_t2B03604D19B81660C4C1C06590C76BC8630DDE99_0_0_0 } /* System.IOSelectorJob */,
	{ NULL, RecognizedAttribute_t300D9F628CDAED6F665BFE996936B9CE0FA0D95B_marshal_pinvoke, RecognizedAttribute_t300D9F628CDAED6F665BFE996936B9CE0FA0D95B_marshal_pinvoke_back, RecognizedAttribute_t300D9F628CDAED6F665BFE996936B9CE0FA0D95B_marshal_pinvoke_cleanup, NULL, NULL, &RecognizedAttribute_t300D9F628CDAED6F665BFE996936B9CE0FA0D95B_0_0_0 } /* System.Net.CookieTokenizer/RecognizedAttribute */,
	{ DelegatePInvokeWrapper_ReadDelegate_tBC77AE628966A21E63D8BB344BC3D7C79441A6DE, NULL, NULL, NULL, NULL, NULL, &ReadDelegate_tBC77AE628966A21E63D8BB344BC3D7C79441A6DE_0_0_0 } /* System.Net.FtpDataStream/ReadDelegate */,
	{ DelegatePInvokeWrapper_WriteDelegate_tCA763F3444D2578FB21239EDFC1C3632E469FC49, NULL, NULL, NULL, NULL, NULL, &WriteDelegate_tCA763F3444D2578FB21239EDFC1C3632E469FC49_0_0_0 } /* System.Net.FtpDataStream/WriteDelegate */,
	{ DelegatePInvokeWrapper_HeaderParser_t6B59FF0FD79FFD511A019AE5383DCEF641BA822E, NULL, NULL, NULL, NULL, NULL, &HeaderParser_t6B59FF0FD79FFD511A019AE5383DCEF641BA822E_0_0_0 } /* System.Net.HeaderParser */,
	{ NULL, HeaderVariantInfo_tFF12EDB71F2B9508779B160689F99BA209DA9E64_marshal_pinvoke, HeaderVariantInfo_tFF12EDB71F2B9508779B160689F99BA209DA9E64_marshal_pinvoke_back, HeaderVariantInfo_tFF12EDB71F2B9508779B160689F99BA209DA9E64_marshal_pinvoke_cleanup, NULL, NULL, &HeaderVariantInfo_tFF12EDB71F2B9508779B160689F99BA209DA9E64_0_0_0 } /* System.Net.HeaderVariantInfo */,
	{ NULL, AuthorizationState_t5C342070F47B5DBAE0089B8B6A391FDEB6914AAB_marshal_pinvoke, AuthorizationState_t5C342070F47B5DBAE0089B8B6A391FDEB6914AAB_marshal_pinvoke_back, AuthorizationState_t5C342070F47B5DBAE0089B8B6A391FDEB6914AAB_marshal_pinvoke_cleanup, NULL, NULL, &AuthorizationState_t5C342070F47B5DBAE0089B8B6A391FDEB6914AAB_0_0_0 } /* System.Net.HttpWebRequest/AuthorizationState */,
	{ NULL, Win32_FIXED_INFO_t3A3D06BDBE4DDA090E3A7151E5D761E867A870DD_marshal_pinvoke, Win32_FIXED_INFO_t3A3D06BDBE4DDA090E3A7151E5D761E867A870DD_marshal_pinvoke_back, Win32_FIXED_INFO_t3A3D06BDBE4DDA090E3A7151E5D761E867A870DD_marshal_pinvoke_cleanup, NULL, NULL, &Win32_FIXED_INFO_t3A3D06BDBE4DDA090E3A7151E5D761E867A870DD_0_0_0 } /* System.Net.NetworkInformation.Win32_FIXED_INFO */,
	{ NULL, Win32_IP_ADDR_STRING_tDA9F56F72EA92CA09591BA7A512706A1A3BCC16F_marshal_pinvoke, Win32_IP_ADDR_STRING_tDA9F56F72EA92CA09591BA7A512706A1A3BCC16F_marshal_pinvoke_back, Win32_IP_ADDR_STRING_tDA9F56F72EA92CA09591BA7A512706A1A3BCC16F_marshal_pinvoke_cleanup, NULL, NULL, &Win32_IP_ADDR_STRING_tDA9F56F72EA92CA09591BA7A512706A1A3BCC16F_0_0_0 } /* System.Net.NetworkInformation.Win32_IP_ADDR_STRING */,
	{ NULL, SocketAsyncResult_t63145D172556590482549D41328C0668E19CB69C_marshal_pinvoke, SocketAsyncResult_t63145D172556590482549D41328C0668E19CB69C_marshal_pinvoke_back, SocketAsyncResult_t63145D172556590482549D41328C0668E19CB69C_marshal_pinvoke_cleanup, NULL, NULL, &SocketAsyncResult_t63145D172556590482549D41328C0668E19CB69C_0_0_0 } /* System.Net.Sockets.SocketAsyncResult */,
	{ NULL, X509ChainStatus_t9E05BD8700EA6158AC82F71CBE53AD20F6B99B0C_marshal_pinvoke, X509ChainStatus_t9E05BD8700EA6158AC82F71CBE53AD20F6B99B0C_marshal_pinvoke_back, X509ChainStatus_t9E05BD8700EA6158AC82F71CBE53AD20F6B99B0C_marshal_pinvoke_cleanup, NULL, NULL, &X509ChainStatus_t9E05BD8700EA6158AC82F71CBE53AD20F6B99B0C_0_0_0 } /* System.Security.Cryptography.X509Certificates.X509ChainStatus */,
	{ NULL, LowerCaseMapping_t3F087D71A4D7A309FD5492CE33501FD4F4709D7B_marshal_pinvoke, LowerCaseMapping_t3F087D71A4D7A309FD5492CE33501FD4F4709D7B_marshal_pinvoke_back, LowerCaseMapping_t3F087D71A4D7A309FD5492CE33501FD4F4709D7B_marshal_pinvoke_cleanup, NULL, NULL, &LowerCaseMapping_t3F087D71A4D7A309FD5492CE33501FD4F4709D7B_0_0_0 } /* System.Text.RegularExpressions.RegexCharClass/LowerCaseMapping */,
	{ DelegatePInvokeWrapper_AndroidJavaRunnable_tBE7371D29A525C4F51DC1CBEBA5E193644F6AFE1, NULL, NULL, NULL, NULL, NULL, &AndroidJavaRunnable_tBE7371D29A525C4F51DC1CBEBA5E193644F6AFE1_0_0_0 } /* UnityEngine.AndroidJavaRunnable */,
	{ NULL, AnimationCurve_tD2F265379583AAF1BF8D84F1BB8DB12980FA504C_marshal_pinvoke, AnimationCurve_tD2F265379583AAF1BF8D84F1BB8DB12980FA504C_marshal_pinvoke_back, AnimationCurve_tD2F265379583AAF1BF8D84F1BB8DB12980FA504C_marshal_pinvoke_cleanup, NULL, NULL, &AnimationCurve_tD2F265379583AAF1BF8D84F1BB8DB12980FA504C_0_0_0 } /* UnityEngine.AnimationCurve */,
	{ DelegatePInvokeWrapper_LogCallback_t73139DDD22E0DAFAB5F0E39D4D9B1522682C4778, NULL, NULL, NULL, NULL, NULL, &LogCallback_t73139DDD22E0DAFAB5F0E39D4D9B1522682C4778_0_0_0 } /* UnityEngine.Application/LogCallback */,
	{ DelegatePInvokeWrapper_LowMemoryCallback_t3862486677D10CD16ECDA703CFB75039A4B3AE00, NULL, NULL, NULL, NULL, NULL, &LowMemoryCallback_t3862486677D10CD16ECDA703CFB75039A4B3AE00_0_0_0 } /* UnityEngine.Application/LowMemoryCallback */,
	{ NULL, AsyncOperation_t304C51ABED8AE734CC8DDDFE13013D8D5A44641D_marshal_pinvoke, AsyncOperation_t304C51ABED8AE734CC8DDDFE13013D8D5A44641D_marshal_pinvoke_back, AsyncOperation_t304C51ABED8AE734CC8DDDFE13013D8D5A44641D_marshal_pinvoke_cleanup, NULL, NULL, &AsyncOperation_t304C51ABED8AE734CC8DDDFE13013D8D5A44641D_0_0_0 } /* UnityEngine.AsyncOperation */,
	{ NULL, OrderBlock_t3B2BBCE8320FAEC3DB605F7DC9AB641102F53727_marshal_pinvoke, OrderBlock_t3B2BBCE8320FAEC3DB605F7DC9AB641102F53727_marshal_pinvoke_back, OrderBlock_t3B2BBCE8320FAEC3DB605F7DC9AB641102F53727_marshal_pinvoke_cleanup, NULL, NULL, &OrderBlock_t3B2BBCE8320FAEC3DB605F7DC9AB641102F53727_0_0_0 } /* UnityEngine.BeforeRenderHelper/OrderBlock */,
	{ NULL, Coroutine_tAE7DB2FC70A0AE6477F896F852057CB0754F06EC_marshal_pinvoke, Coroutine_tAE7DB2FC70A0AE6477F896F852057CB0754F06EC_marshal_pinvoke_back, Coroutine_tAE7DB2FC70A0AE6477F896F852057CB0754F06EC_marshal_pinvoke_cleanup, NULL, NULL, &Coroutine_tAE7DB2FC70A0AE6477F896F852057CB0754F06EC_0_0_0 } /* UnityEngine.Coroutine */,
	{ NULL, CullingGroup_t7F71E48F69794B87C5A7F3F27AD1F1517B2FBF1F_marshal_pinvoke, CullingGroup_t7F71E48F69794B87C5A7F3F27AD1F1517B2FBF1F_marshal_pinvoke_back, CullingGroup_t7F71E48F69794B87C5A7F3F27AD1F1517B2FBF1F_marshal_pinvoke_cleanup, NULL, NULL, &CullingGroup_t7F71E48F69794B87C5A7F3F27AD1F1517B2FBF1F_0_0_0 } /* UnityEngine.CullingGroup */,
	{ DelegatePInvokeWrapper_StateChanged_t6B81A48F3E917979B3F56CE50FEEB8E4DE46F161, NULL, NULL, NULL, NULL, NULL, &StateChanged_t6B81A48F3E917979B3F56CE50FEEB8E4DE46F161_0_0_0 } /* UnityEngine.CullingGroup/StateChanged */,
	{ DelegatePInvokeWrapper_DisplaysUpdatedDelegate_t2FAF995B47D691BD7C5BBC17D533DD8B19BE9A90, NULL, NULL, NULL, NULL, NULL, &DisplaysUpdatedDelegate_t2FAF995B47D691BD7C5BBC17D533DD8B19BE9A90_0_0_0 } /* UnityEngine.Display/DisplaysUpdatedDelegate */,
	{ DelegatePInvokeWrapper_UnityAction_tD19B26F1B2C048E38FD5801A33573BE01064CAF4, NULL, NULL, NULL, NULL, NULL, &UnityAction_tD19B26F1B2C048E38FD5801A33573BE01064CAF4_0_0_0 } /* UnityEngine.Events.UnityAction */,
	{ NULL, PlayerLoopSystem_t89BC6208BDD3B7C57FED7B0201341A7D4E846A6D_marshal_pinvoke, PlayerLoopSystem_t89BC6208BDD3B7C57FED7B0201341A7D4E846A6D_marshal_pinvoke_back, PlayerLoopSystem_t89BC6208BDD3B7C57FED7B0201341A7D4E846A6D_marshal_pinvoke_cleanup, NULL, NULL, &PlayerLoopSystem_t89BC6208BDD3B7C57FED7B0201341A7D4E846A6D_0_0_0 } /* UnityEngine.Experimental.LowLevel.PlayerLoopSystem */,
	{ DelegatePInvokeWrapper_UpdateFunction_tE0936D5A5B8C3367F0E6E464162E1FB1E9F304A8, NULL, NULL, NULL, NULL, NULL, &UpdateFunction_tE0936D5A5B8C3367F0E6E464162E1FB1E9F304A8_0_0_0 } /* UnityEngine.Experimental.LowLevel.PlayerLoopSystem/UpdateFunction */,
	{ NULL, PlayerLoopSystemInternal_tE0D30607A74F1E0D695E5E83717C26308CB5C9E9_marshal_pinvoke, PlayerLoopSystemInternal_tE0D30607A74F1E0D695E5E83717C26308CB5C9E9_marshal_pinvoke_back, PlayerLoopSystemInternal_tE0D30607A74F1E0D695E5E83717C26308CB5C9E9_marshal_pinvoke_cleanup, NULL, NULL, &PlayerLoopSystemInternal_tE0D30607A74F1E0D695E5E83717C26308CB5C9E9_0_0_0 } /* UnityEngine.Experimental.LowLevel.PlayerLoopSystemInternal */,
	{ NULL, SpriteBone_tD75C1B533C9282AEC369B66DF430C1CAC3C8BEB2_marshal_pinvoke, SpriteBone_tD75C1B533C9282AEC369B66DF430C1CAC3C8BEB2_marshal_pinvoke_back, SpriteBone_tD75C1B533C9282AEC369B66DF430C1CAC3C8BEB2_marshal_pinvoke_cleanup, NULL, NULL, &SpriteBone_tD75C1B533C9282AEC369B66DF430C1CAC3C8BEB2_0_0_0 } /* UnityEngine.Experimental.U2D.SpriteBone */,
	{ NULL, FailedToLoadScriptObject_tB9D2DBB36BA1E86F2A7392AF112B455206E8E83B_marshal_pinvoke, FailedToLoadScriptObject_tB9D2DBB36BA1E86F2A7392AF112B455206E8E83B_marshal_pinvoke_back, FailedToLoadScriptObject_tB9D2DBB36BA1E86F2A7392AF112B455206E8E83B_marshal_pinvoke_cleanup, NULL, NULL, &FailedToLoadScriptObject_tB9D2DBB36BA1E86F2A7392AF112B455206E8E83B_0_0_0 } /* UnityEngine.FailedToLoadScriptObject */,
	{ NULL, Gradient_t35A694DDA1066524440E325E582B01E33DE66A3A_marshal_pinvoke, Gradient_t35A694DDA1066524440E325E582B01E33DE66A3A_marshal_pinvoke_back, Gradient_t35A694DDA1066524440E325E582B01E33DE66A3A_marshal_pinvoke_cleanup, NULL, NULL, &Gradient_t35A694DDA1066524440E325E582B01E33DE66A3A_0_0_0 } /* UnityEngine.Gradient */,
	{ NULL, Internal_DrawTextureArguments_t4C3F2D141F43C3EF7D12FEA79BAD68985C0C52AF_marshal_pinvoke, Internal_DrawTextureArguments_t4C3F2D141F43C3EF7D12FEA79BAD68985C0C52AF_marshal_pinvoke_back, Internal_DrawTextureArguments_t4C3F2D141F43C3EF7D12FEA79BAD68985C0C52AF_marshal_pinvoke_cleanup, NULL, NULL, &Internal_DrawTextureArguments_t4C3F2D141F43C3EF7D12FEA79BAD68985C0C52AF_0_0_0 } /* UnityEngine.Internal_DrawTextureArguments */,
	{ NULL, Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_marshal_pinvoke, Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_marshal_pinvoke_back, Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_marshal_pinvoke_cleanup, NULL, NULL, &Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_0_0_0 } /* UnityEngine.Object */,
	{ NULL, PlayableBinding_t4D92F4CF16B8608DD83947E5D40CB7690F23F9C8_marshal_pinvoke, PlayableBinding_t4D92F4CF16B8608DD83947E5D40CB7690F23F9C8_marshal_pinvoke_back, PlayableBinding_t4D92F4CF16B8608DD83947E5D40CB7690F23F9C8_marshal_pinvoke_cleanup, NULL, NULL, &PlayableBinding_t4D92F4CF16B8608DD83947E5D40CB7690F23F9C8_0_0_0 } /* UnityEngine.Playables.PlayableBinding */,
	{ DelegatePInvokeWrapper_CreateOutputMethod_tA7B649F49822FC5DD0B0D9F17247C73CAECB1CA3, NULL, NULL, NULL, NULL, NULL, &CreateOutputMethod_tA7B649F49822FC5DD0B0D9F17247C73CAECB1CA3_0_0_0 } /* UnityEngine.Playables.PlayableBinding/CreateOutputMethod */,
	{ NULL, RectOffset_tED44B1176E93501050480416699D1F11BAE8C87A_marshal_pinvoke, RectOffset_tED44B1176E93501050480416699D1F11BAE8C87A_marshal_pinvoke_back, RectOffset_tED44B1176E93501050480416699D1F11BAE8C87A_marshal_pinvoke_cleanup, NULL, NULL, &RectOffset_tED44B1176E93501050480416699D1F11BAE8C87A_0_0_0 } /* UnityEngine.RectOffset */,
	{ NULL, ResourceRequest_t22744D420D4DEF7C924A01EB117C0FEC6B07D486_marshal_pinvoke, ResourceRequest_t22744D420D4DEF7C924A01EB117C0FEC6B07D486_marshal_pinvoke_back, ResourceRequest_t22744D420D4DEF7C924A01EB117C0FEC6B07D486_marshal_pinvoke_cleanup, NULL, NULL, &ResourceRequest_t22744D420D4DEF7C924A01EB117C0FEC6B07D486_0_0_0 } /* UnityEngine.ResourceRequest */,
	{ NULL, ScriptableObject_tAB015486CEAB714DA0D5C1BA389B84FB90427734_marshal_pinvoke, ScriptableObject_tAB015486CEAB714DA0D5C1BA389B84FB90427734_marshal_pinvoke_back, ScriptableObject_tAB015486CEAB714DA0D5C1BA389B84FB90427734_marshal_pinvoke_cleanup, NULL, NULL, &ScriptableObject_tAB015486CEAB714DA0D5C1BA389B84FB90427734_0_0_0 } /* UnityEngine.ScriptableObject */,
	{ NULL, HitInfo_t3DDACA0CB28E94463E17542FA7F04245A8AE1C12_marshal_pinvoke, HitInfo_t3DDACA0CB28E94463E17542FA7F04245A8AE1C12_marshal_pinvoke_back, HitInfo_t3DDACA0CB28E94463E17542FA7F04245A8AE1C12_marshal_pinvoke_cleanup, NULL, NULL, &HitInfo_t3DDACA0CB28E94463E17542FA7F04245A8AE1C12_0_0_0 } /* UnityEngine.SendMouseEvents/HitInfo */,
	{ NULL, TrackedReference_tE93229EF7055CBB35B2A98DD2493947428D06107_marshal_pinvoke, TrackedReference_tE93229EF7055CBB35B2A98DD2493947428D06107_marshal_pinvoke_back, TrackedReference_tE93229EF7055CBB35B2A98DD2493947428D06107_marshal_pinvoke_cleanup, NULL, NULL, &TrackedReference_tE93229EF7055CBB35B2A98DD2493947428D06107_0_0_0 } /* UnityEngine.TrackedReference */,
	{ NULL, WorkRequest_t0247B62D135204EAA95FC0B2EC829CB27B433F94_marshal_pinvoke, WorkRequest_t0247B62D135204EAA95FC0B2EC829CB27B433F94_marshal_pinvoke_back, WorkRequest_t0247B62D135204EAA95FC0B2EC829CB27B433F94_marshal_pinvoke_cleanup, NULL, NULL, &WorkRequest_t0247B62D135204EAA95FC0B2EC829CB27B433F94_0_0_0 } /* UnityEngine.UnitySynchronizationContext/WorkRequest */,
	{ NULL, WaitForSeconds_t3E9E78D3BB53F03F96C7F28BA9B9086CD1A5F4E8_marshal_pinvoke, WaitForSeconds_t3E9E78D3BB53F03F96C7F28BA9B9086CD1A5F4E8_marshal_pinvoke_back, WaitForSeconds_t3E9E78D3BB53F03F96C7F28BA9B9086CD1A5F4E8_marshal_pinvoke_cleanup, NULL, NULL, &WaitForSeconds_t3E9E78D3BB53F03F96C7F28BA9B9086CD1A5F4E8_0_0_0 } /* UnityEngine.WaitForSeconds */,
	{ NULL, YieldInstruction_t836035AC7BD07A3C7909F7AD2A5B42DE99D91C44_marshal_pinvoke, YieldInstruction_t836035AC7BD07A3C7909F7AD2A5B42DE99D91C44_marshal_pinvoke_back, YieldInstruction_t836035AC7BD07A3C7909F7AD2A5B42DE99D91C44_marshal_pinvoke_cleanup, NULL, NULL, &YieldInstruction_t836035AC7BD07A3C7909F7AD2A5B42DE99D91C44_0_0_0 } /* UnityEngine.YieldInstruction */,
	{ NULL, Collision_t7FF0F4B0E24A2AEB1131DD980F63AB8CBF11FC3C_marshal_pinvoke, Collision_t7FF0F4B0E24A2AEB1131DD980F63AB8CBF11FC3C_marshal_pinvoke_back, Collision_t7FF0F4B0E24A2AEB1131DD980F63AB8CBF11FC3C_marshal_pinvoke_cleanup, NULL, NULL, &Collision_t7FF0F4B0E24A2AEB1131DD980F63AB8CBF11FC3C_0_0_0 } /* UnityEngine.Collision */,
	{ NULL, ControllerColliderHit_tB009AA7F769B4A3E988DEF71F4C5A29AB6A38968_marshal_pinvoke, ControllerColliderHit_tB009AA7F769B4A3E988DEF71F4C5A29AB6A38968_marshal_pinvoke_back, ControllerColliderHit_tB009AA7F769B4A3E988DEF71F4C5A29AB6A38968_marshal_pinvoke_cleanup, NULL, NULL, &ControllerColliderHit_tB009AA7F769B4A3E988DEF71F4C5A29AB6A38968_0_0_0 } /* UnityEngine.ControllerColliderHit */,
	{ DelegatePInvokeWrapper_FontTextureRebuildCallback_tD700C63BB1A449E3A0464C81701E981677D3021C, NULL, NULL, NULL, NULL, NULL, &FontTextureRebuildCallback_tD700C63BB1A449E3A0464C81701E981677D3021C_0_0_0 } /* UnityEngine.Font/FontTextureRebuildCallback */,
	{ NULL, TextGenerationSettings_t37703542535A1638D2A08F41DB629A483616AF68_marshal_pinvoke, TextGenerationSettings_t37703542535A1638D2A08F41DB629A483616AF68_marshal_pinvoke_back, TextGenerationSettings_t37703542535A1638D2A08F41DB629A483616AF68_marshal_pinvoke_cleanup, NULL, NULL, &TextGenerationSettings_t37703542535A1638D2A08F41DB629A483616AF68_0_0_0 } /* UnityEngine.TextGenerationSettings */,
	{ NULL, TextGenerator_tD455BE18A64C7DDF854F6DB3CCEBF705121C58A8_marshal_pinvoke, TextGenerator_tD455BE18A64C7DDF854F6DB3CCEBF705121C58A8_marshal_pinvoke_back, TextGenerator_tD455BE18A64C7DDF854F6DB3CCEBF705121C58A8_marshal_pinvoke_cleanup, NULL, NULL, &TextGenerator_tD455BE18A64C7DDF854F6DB3CCEBF705121C58A8_0_0_0 } /* UnityEngine.TextGenerator */,
	{ NULL, AssetBundleCreateRequest_t8D8FCFC0424680D7B5E04346D932442D5886CD2E_marshal_pinvoke, AssetBundleCreateRequest_t8D8FCFC0424680D7B5E04346D932442D5886CD2E_marshal_pinvoke_back, AssetBundleCreateRequest_t8D8FCFC0424680D7B5E04346D932442D5886CD2E_marshal_pinvoke_cleanup, NULL, NULL, &AssetBundleCreateRequest_t8D8FCFC0424680D7B5E04346D932442D5886CD2E_0_0_0 } /* UnityEngine.AssetBundleCreateRequest */,
	{ NULL, AssetBundleRecompressOperation_tD941F40367DFE0A376269FCBE02234C5C8E9BFB6_marshal_pinvoke, AssetBundleRecompressOperation_tD941F40367DFE0A376269FCBE02234C5C8E9BFB6_marshal_pinvoke_back, AssetBundleRecompressOperation_tD941F40367DFE0A376269FCBE02234C5C8E9BFB6_marshal_pinvoke_cleanup, NULL, NULL, &AssetBundleRecompressOperation_tD941F40367DFE0A376269FCBE02234C5C8E9BFB6_0_0_0 } /* UnityEngine.AssetBundleRecompressOperation */,
	{ NULL, AssetBundleRequest_tF8897443AF1FC6C3E04911FAA9EDAE89B0A0A962_marshal_pinvoke, AssetBundleRequest_tF8897443AF1FC6C3E04911FAA9EDAE89B0A0A962_marshal_pinvoke_back, AssetBundleRequest_tF8897443AF1FC6C3E04911FAA9EDAE89B0A0A962_marshal_pinvoke_cleanup, NULL, NULL, &AssetBundleRequest_tF8897443AF1FC6C3E04911FAA9EDAE89B0A0A962_0_0_0 } /* UnityEngine.AssetBundleRequest */,
	{ DelegatePInvokeWrapper_PCMReaderCallback_t9B87AB13DCD37957B045554BF28A57697E6B8EFB, NULL, NULL, NULL, NULL, NULL, &PCMReaderCallback_t9B87AB13DCD37957B045554BF28A57697E6B8EFB_0_0_0 } /* UnityEngine.AudioClip/PCMReaderCallback */,
	{ DelegatePInvokeWrapper_PCMSetPositionCallback_t092ED33043C0279B5E4D343EBCBD516CEF260801, NULL, NULL, NULL, NULL, NULL, &PCMSetPositionCallback_t092ED33043C0279B5E4D343EBCBD516CEF260801_0_0_0 } /* UnityEngine.AudioClip/PCMSetPositionCallback */,
	{ DelegatePInvokeWrapper_AudioConfigurationChangeHandler_t8E0E05D0198D95B5412DC716F87D97020EF54926, NULL, NULL, NULL, NULL, NULL, &AudioConfigurationChangeHandler_t8E0E05D0198D95B5412DC716F87D97020EF54926_0_0_0 } /* UnityEngine.AudioSettings/AudioConfigurationChangeHandler */,
	{ DelegatePInvokeWrapper_ConsumeSampleFramesNativeFunction_tC1E0B1BFCF2C3D7F87D66FCFA2022369327D931D, NULL, NULL, NULL, NULL, NULL, &ConsumeSampleFramesNativeFunction_tC1E0B1BFCF2C3D7F87D66FCFA2022369327D931D_0_0_0 } /* UnityEngine.Experimental.Audio.AudioSampleProvider/ConsumeSampleFramesNativeFunction */,
	{ NULL, Event_t187FF6A6B357447B83EC2064823EE0AEC5263210_marshal_pinvoke, Event_t187FF6A6B357447B83EC2064823EE0AEC5263210_marshal_pinvoke_back, Event_t187FF6A6B357447B83EC2064823EE0AEC5263210_marshal_pinvoke_cleanup, NULL, NULL, &Event_t187FF6A6B357447B83EC2064823EE0AEC5263210_0_0_0 } /* UnityEngine.Event */,
	{ DelegatePInvokeWrapper_WindowFunction_t9AF05117863D95AA9F85D497A3B9B53216708100, NULL, NULL, NULL, NULL, NULL, &WindowFunction_t9AF05117863D95AA9F85D497A3B9B53216708100_0_0_0 } /* UnityEngine.GUI/WindowFunction */,
	{ NULL, GUIContent_t2A00F8961C69C0A382168840CFB2111FB00B5EA0_marshal_pinvoke, GUIContent_t2A00F8961C69C0A382168840CFB2111FB00B5EA0_marshal_pinvoke_back, GUIContent_t2A00F8961C69C0A382168840CFB2111FB00B5EA0_marshal_pinvoke_cleanup, NULL, NULL, &GUIContent_t2A00F8961C69C0A382168840CFB2111FB00B5EA0_0_0_0 } /* UnityEngine.GUIContent */,
	{ DelegatePInvokeWrapper_SkinChangedDelegate_tAB4CEEA8C8A0BDCFD51C9624AE173C46A40135D8, NULL, NULL, NULL, NULL, NULL, &SkinChangedDelegate_tAB4CEEA8C8A0BDCFD51C9624AE173C46A40135D8_0_0_0 } /* UnityEngine.GUISkin/SkinChangedDelegate */,
	{ NULL, GUIStyle_t671F175A201A19166385EE3392292A5F50070572_marshal_pinvoke, GUIStyle_t671F175A201A19166385EE3392292A5F50070572_marshal_pinvoke_back, GUIStyle_t671F175A201A19166385EE3392292A5F50070572_marshal_pinvoke_cleanup, NULL, NULL, &GUIStyle_t671F175A201A19166385EE3392292A5F50070572_0_0_0 } /* UnityEngine.GUIStyle */,
	{ NULL, GUIStyleState_t2AA5CB82EB2571B0496D1F0B9D29D2B8D8B1E7E5_marshal_pinvoke, GUIStyleState_t2AA5CB82EB2571B0496D1F0B9D29D2B8D8B1E7E5_marshal_pinvoke_back, GUIStyleState_t2AA5CB82EB2571B0496D1F0B9D29D2B8D8B1E7E5_marshal_pinvoke_cleanup, NULL, NULL, &GUIStyleState_t2AA5CB82EB2571B0496D1F0B9D29D2B8D8B1E7E5_0_0_0 } /* UnityEngine.GUIStyleState */,
	{ NULL, SliderHandler_t80CE53884BFA87A9FA360D2862DA4B504BFBEF7C_marshal_pinvoke, SliderHandler_t80CE53884BFA87A9FA360D2862DA4B504BFBEF7C_marshal_pinvoke_back, SliderHandler_t80CE53884BFA87A9FA360D2862DA4B504BFBEF7C_marshal_pinvoke_cleanup, NULL, NULL, &SliderHandler_t80CE53884BFA87A9FA360D2862DA4B504BFBEF7C_0_0_0 } /* UnityEngine.SliderHandler */,
	{ NULL, Collision2D_t45DC963DE1229CFFC7D0B666800F0AE93688764D_marshal_pinvoke, Collision2D_t45DC963DE1229CFFC7D0B666800F0AE93688764D_marshal_pinvoke_back, Collision2D_t45DC963DE1229CFFC7D0B666800F0AE93688764D_marshal_pinvoke_cleanup, NULL, NULL, &Collision2D_t45DC963DE1229CFFC7D0B666800F0AE93688764D_0_0_0 } /* UnityEngine.Collision2D */,
	{ NULL, ContactFilter2D_t1BEAE75CCD5614B40E8AD9031BBD72543E2C37B4_marshal_pinvoke, ContactFilter2D_t1BEAE75CCD5614B40E8AD9031BBD72543E2C37B4_marshal_pinvoke_back, ContactFilter2D_t1BEAE75CCD5614B40E8AD9031BBD72543E2C37B4_marshal_pinvoke_cleanup, NULL, NULL, &ContactFilter2D_t1BEAE75CCD5614B40E8AD9031BBD72543E2C37B4_0_0_0 } /* UnityEngine.ContactFilter2D */,
	{ NULL, CertificateHandler_tBD070BF4150A44AB482FD36EA3882C363117E8C0_marshal_pinvoke, CertificateHandler_tBD070BF4150A44AB482FD36EA3882C363117E8C0_marshal_pinvoke_back, CertificateHandler_tBD070BF4150A44AB482FD36EA3882C363117E8C0_marshal_pinvoke_cleanup, NULL, NULL, &CertificateHandler_tBD070BF4150A44AB482FD36EA3882C363117E8C0_0_0_0 } /* UnityEngine.Networking.CertificateHandler */,
	{ NULL, DownloadHandler_t4A7802ADC97024B469C87FA454B6973951980EE9_marshal_pinvoke, DownloadHandler_t4A7802ADC97024B469C87FA454B6973951980EE9_marshal_pinvoke_back, DownloadHandler_t4A7802ADC97024B469C87FA454B6973951980EE9_marshal_pinvoke_cleanup, NULL, NULL, &DownloadHandler_t4A7802ADC97024B469C87FA454B6973951980EE9_0_0_0 } /* UnityEngine.Networking.DownloadHandler */,
	{ NULL, DownloadHandlerBuffer_tF6A73B82C9EC807D36B904A58E1DF2DDA696B255_marshal_pinvoke, DownloadHandlerBuffer_tF6A73B82C9EC807D36B904A58E1DF2DDA696B255_marshal_pinvoke_back, DownloadHandlerBuffer_tF6A73B82C9EC807D36B904A58E1DF2DDA696B255_marshal_pinvoke_cleanup, NULL, NULL, &DownloadHandlerBuffer_tF6A73B82C9EC807D36B904A58E1DF2DDA696B255_0_0_0 } /* UnityEngine.Networking.DownloadHandlerBuffer */,
	{ NULL, UnityWebRequest_t9120F5A2C7D43B936B49C0B7E4CA54C822689129_marshal_pinvoke, UnityWebRequest_t9120F5A2C7D43B936B49C0B7E4CA54C822689129_marshal_pinvoke_back, UnityWebRequest_t9120F5A2C7D43B936B49C0B7E4CA54C822689129_marshal_pinvoke_cleanup, NULL, NULL, &UnityWebRequest_t9120F5A2C7D43B936B49C0B7E4CA54C822689129_0_0_0 } /* UnityEngine.Networking.UnityWebRequest */,
	{ NULL, UnityWebRequestAsyncOperation_t726E134F16701A2671D40BEBE22110DC57156353_marshal_pinvoke, UnityWebRequestAsyncOperation_t726E134F16701A2671D40BEBE22110DC57156353_marshal_pinvoke_back, UnityWebRequestAsyncOperation_t726E134F16701A2671D40BEBE22110DC57156353_marshal_pinvoke_cleanup, NULL, NULL, &UnityWebRequestAsyncOperation_t726E134F16701A2671D40BEBE22110DC57156353_0_0_0 } /* UnityEngine.Networking.UnityWebRequestAsyncOperation */,
	{ NULL, UploadHandler_t24F4097D30A1E7C689D8881A27F251B4741601E4_marshal_pinvoke, UploadHandler_t24F4097D30A1E7C689D8881A27F251B4741601E4_marshal_pinvoke_back, UploadHandler_t24F4097D30A1E7C689D8881A27F251B4741601E4_marshal_pinvoke_cleanup, NULL, NULL, &UploadHandler_t24F4097D30A1E7C689D8881A27F251B4741601E4_0_0_0 } /* UnityEngine.Networking.UploadHandler */,
	{ NULL, UploadHandlerRaw_t9E6A69B7726F134F31F6744F5EFDF611E7C54F27_marshal_pinvoke, UploadHandlerRaw_t9E6A69B7726F134F31F6744F5EFDF611E7C54F27_marshal_pinvoke_back, UploadHandlerRaw_t9E6A69B7726F134F31F6744F5EFDF611E7C54F27_marshal_pinvoke_cleanup, NULL, NULL, &UploadHandlerRaw_t9E6A69B7726F134F31F6744F5EFDF611E7C54F27_0_0_0 } /* UnityEngine.Networking.UploadHandlerRaw */,
	{ NULL, IntegratedSubsystem_tF67A736CD38F3A64A40687C90024FA7326AF7D86_marshal_pinvoke, IntegratedSubsystem_tF67A736CD38F3A64A40687C90024FA7326AF7D86_marshal_pinvoke_back, IntegratedSubsystem_tF67A736CD38F3A64A40687C90024FA7326AF7D86_marshal_pinvoke_cleanup, NULL, NULL, &IntegratedSubsystem_tF67A736CD38F3A64A40687C90024FA7326AF7D86_0_0_0 } /* UnityEngine.Experimental.IntegratedSubsystem */,
	{ NULL, IntegratedSubsystemDescriptor_tD52D7E7BD7FFA6121E7AAC6FE3E1CCB2C671E8C0_marshal_pinvoke, IntegratedSubsystemDescriptor_tD52D7E7BD7FFA6121E7AAC6FE3E1CCB2C671E8C0_marshal_pinvoke_back, IntegratedSubsystemDescriptor_tD52D7E7BD7FFA6121E7AAC6FE3E1CCB2C671E8C0_marshal_pinvoke_cleanup, NULL, NULL, &IntegratedSubsystemDescriptor_tD52D7E7BD7FFA6121E7AAC6FE3E1CCB2C671E8C0_0_0_0 } /* UnityEngine.Experimental.IntegratedSubsystemDescriptor */,
	{ NULL, FrameReceivedEventArgs_t4637B6D2FC28197602B18C1815C4A778645479DD_marshal_pinvoke, FrameReceivedEventArgs_t4637B6D2FC28197602B18C1815C4A778645479DD_marshal_pinvoke_back, FrameReceivedEventArgs_t4637B6D2FC28197602B18C1815C4A778645479DD_marshal_pinvoke_cleanup, NULL, NULL, &FrameReceivedEventArgs_t4637B6D2FC28197602B18C1815C4A778645479DD_0_0_0 } /* UnityEngine.Experimental.XR.FrameReceivedEventArgs */,
	{ NULL, MeshGenerationResult_t24F21E71F8F697D7D216BA4F3F064FB5434E6056_marshal_pinvoke, MeshGenerationResult_t24F21E71F8F697D7D216BA4F3F064FB5434E6056_marshal_pinvoke_back, MeshGenerationResult_t24F21E71F8F697D7D216BA4F3F064FB5434E6056_marshal_pinvoke_cleanup, NULL, NULL, &MeshGenerationResult_t24F21E71F8F697D7D216BA4F3F064FB5434E6056_0_0_0 } /* UnityEngine.Experimental.XR.MeshGenerationResult */,
	{ NULL, PlaneAddedEventArgs_t06BF8697BA4D8CD3A8C9AB8DF51F8D01D2910002_marshal_pinvoke, PlaneAddedEventArgs_t06BF8697BA4D8CD3A8C9AB8DF51F8D01D2910002_marshal_pinvoke_back, PlaneAddedEventArgs_t06BF8697BA4D8CD3A8C9AB8DF51F8D01D2910002_marshal_pinvoke_cleanup, NULL, NULL, &PlaneAddedEventArgs_t06BF8697BA4D8CD3A8C9AB8DF51F8D01D2910002_0_0_0 } /* UnityEngine.Experimental.XR.PlaneAddedEventArgs */,
	{ NULL, PlaneRemovedEventArgs_t21E9C5879A8317E5F72263ED2235116F609E4C6A_marshal_pinvoke, PlaneRemovedEventArgs_t21E9C5879A8317E5F72263ED2235116F609E4C6A_marshal_pinvoke_back, PlaneRemovedEventArgs_t21E9C5879A8317E5F72263ED2235116F609E4C6A_marshal_pinvoke_cleanup, NULL, NULL, &PlaneRemovedEventArgs_t21E9C5879A8317E5F72263ED2235116F609E4C6A_0_0_0 } /* UnityEngine.Experimental.XR.PlaneRemovedEventArgs */,
	{ NULL, PlaneUpdatedEventArgs_tD63FB1655000C0BC238033545144C1FD81CED133_marshal_pinvoke, PlaneUpdatedEventArgs_tD63FB1655000C0BC238033545144C1FD81CED133_marshal_pinvoke_back, PlaneUpdatedEventArgs_tD63FB1655000C0BC238033545144C1FD81CED133_marshal_pinvoke_cleanup, NULL, NULL, &PlaneUpdatedEventArgs_tD63FB1655000C0BC238033545144C1FD81CED133_0_0_0 } /* UnityEngine.Experimental.XR.PlaneUpdatedEventArgs */,
	{ NULL, PointCloudUpdatedEventArgs_tE7E1E32A6042806B927B110250C0D4FE755C6B07_marshal_pinvoke, PointCloudUpdatedEventArgs_tE7E1E32A6042806B927B110250C0D4FE755C6B07_marshal_pinvoke_back, PointCloudUpdatedEventArgs_tE7E1E32A6042806B927B110250C0D4FE755C6B07_marshal_pinvoke_cleanup, NULL, NULL, &PointCloudUpdatedEventArgs_tE7E1E32A6042806B927B110250C0D4FE755C6B07_0_0_0 } /* UnityEngine.Experimental.XR.PointCloudUpdatedEventArgs */,
	{ NULL, SessionTrackingStateChangedEventArgs_tE4B00077E5AAE143593A0BB3FA2C57237525E7BA_marshal_pinvoke, SessionTrackingStateChangedEventArgs_tE4B00077E5AAE143593A0BB3FA2C57237525E7BA_marshal_pinvoke_back, SessionTrackingStateChangedEventArgs_tE4B00077E5AAE143593A0BB3FA2C57237525E7BA_marshal_pinvoke_cleanup, NULL, NULL, &SessionTrackingStateChangedEventArgs_tE4B00077E5AAE143593A0BB3FA2C57237525E7BA_0_0_0 } /* UnityEngine.Experimental.XR.SessionTrackingStateChangedEventArgs */,
	{ DelegatePInvokeWrapper_OnNavMeshPreUpdate_tA3A16B3CAFF83530076BF839EA5699AAAD6C6353, NULL, NULL, NULL, NULL, NULL, &OnNavMeshPreUpdate_tA3A16B3CAFF83530076BF839EA5699AAAD6C6353_0_0_0 } /* UnityEngine.AI.NavMesh/OnNavMeshPreUpdate */,
	{ NULL, AnimationEvent_tEDD4E45FEA5CA4657CBBF1E0CFF657191D90673F_marshal_pinvoke, AnimationEvent_tEDD4E45FEA5CA4657CBBF1E0CFF657191D90673F_marshal_pinvoke_back, AnimationEvent_tEDD4E45FEA5CA4657CBBF1E0CFF657191D90673F_marshal_pinvoke_cleanup, NULL, NULL, &AnimationEvent_tEDD4E45FEA5CA4657CBBF1E0CFF657191D90673F_0_0_0 } /* UnityEngine.AnimationEvent */,
	{ NULL, AnimatorControllerParameter_t63F7756B07B981111CB00490DE84B06BC2A25E68_marshal_pinvoke, AnimatorControllerParameter_t63F7756B07B981111CB00490DE84B06BC2A25E68_marshal_pinvoke_back, AnimatorControllerParameter_t63F7756B07B981111CB00490DE84B06BC2A25E68_marshal_pinvoke_cleanup, NULL, NULL, &AnimatorControllerParameter_t63F7756B07B981111CB00490DE84B06BC2A25E68_0_0_0 } /* UnityEngine.AnimatorControllerParameter */,
	{ DelegatePInvokeWrapper_OnOverrideControllerDirtyCallback_t73560E6E30067C09BC58A15F9D2726051B077E2E, NULL, NULL, NULL, NULL, NULL, &OnOverrideControllerDirtyCallback_t73560E6E30067C09BC58A15F9D2726051B077E2E_0_0_0 } /* UnityEngine.AnimatorOverrideController/OnOverrideControllerDirtyCallback */,
	{ NULL, AnimatorTransitionInfo_t66D37578B8898C817BD5A5781B420BF92F60AA6B_marshal_pinvoke, AnimatorTransitionInfo_t66D37578B8898C817BD5A5781B420BF92F60AA6B_marshal_pinvoke_back, AnimatorTransitionInfo_t66D37578B8898C817BD5A5781B420BF92F60AA6B_marshal_pinvoke_cleanup, NULL, NULL, &AnimatorTransitionInfo_t66D37578B8898C817BD5A5781B420BF92F60AA6B_0_0_0 } /* UnityEngine.AnimatorTransitionInfo */,
	{ NULL, HumanBone_t2CE168CF8638CEABF48FB7B7CCF77BBE0CECF995_marshal_pinvoke, HumanBone_t2CE168CF8638CEABF48FB7B7CCF77BBE0CECF995_marshal_pinvoke_back, HumanBone_t2CE168CF8638CEABF48FB7B7CCF77BBE0CECF995_marshal_pinvoke_cleanup, NULL, NULL, &HumanBone_t2CE168CF8638CEABF48FB7B7CCF77BBE0CECF995_0_0_0 } /* UnityEngine.HumanBone */,
	{ NULL, SkeletonBone_tCDF297229129311214294465F3FA353DB09726F5_marshal_pinvoke, SkeletonBone_tCDF297229129311214294465F3FA353DB09726F5_marshal_pinvoke_back, SkeletonBone_tCDF297229129311214294465F3FA353DB09726F5_marshal_pinvoke_cleanup, NULL, NULL, &SkeletonBone_tCDF297229129311214294465F3FA353DB09726F5_0_0_0 } /* UnityEngine.SkeletonBone */,
	{ NULL, GcAchievementData_t5CBCF44628981C91C76C552716A7D551670DCE55_marshal_pinvoke, GcAchievementData_t5CBCF44628981C91C76C552716A7D551670DCE55_marshal_pinvoke_back, GcAchievementData_t5CBCF44628981C91C76C552716A7D551670DCE55_marshal_pinvoke_cleanup, NULL, NULL, &GcAchievementData_t5CBCF44628981C91C76C552716A7D551670DCE55_0_0_0 } /* UnityEngine.SocialPlatforms.GameCenter.GcAchievementData */,
	{ NULL, GcAchievementDescriptionData_t12849233B11B5241066E0D33B3681C2352CAF0A0_marshal_pinvoke, GcAchievementDescriptionData_t12849233B11B5241066E0D33B3681C2352CAF0A0_marshal_pinvoke_back, GcAchievementDescriptionData_t12849233B11B5241066E0D33B3681C2352CAF0A0_marshal_pinvoke_cleanup, NULL, NULL, &GcAchievementDescriptionData_t12849233B11B5241066E0D33B3681C2352CAF0A0_0_0_0 } /* UnityEngine.SocialPlatforms.GameCenter.GcAchievementDescriptionData */,
	{ NULL, GcLeaderboard_t363887C9C2BFA6F02D08CC6F6BB93E8ABE9A42D2_marshal_pinvoke, GcLeaderboard_t363887C9C2BFA6F02D08CC6F6BB93E8ABE9A42D2_marshal_pinvoke_back, GcLeaderboard_t363887C9C2BFA6F02D08CC6F6BB93E8ABE9A42D2_marshal_pinvoke_cleanup, NULL, NULL, &GcLeaderboard_t363887C9C2BFA6F02D08CC6F6BB93E8ABE9A42D2_0_0_0 } /* UnityEngine.SocialPlatforms.GameCenter.GcLeaderboard */,
	{ NULL, GcScoreData_t45EF6CC4038C34CE5823D33D1978C5A3F2E0D09A_marshal_pinvoke, GcScoreData_t45EF6CC4038C34CE5823D33D1978C5A3F2E0D09A_marshal_pinvoke_back, GcScoreData_t45EF6CC4038C34CE5823D33D1978C5A3F2E0D09A_marshal_pinvoke_cleanup, NULL, NULL, &GcScoreData_t45EF6CC4038C34CE5823D33D1978C5A3F2E0D09A_0_0_0 } /* UnityEngine.SocialPlatforms.GameCenter.GcScoreData */,
	{ NULL, GcUserProfileData_tDCEBF6CF74E9EBC0B9F9847CE96118169391B57D_marshal_pinvoke, GcUserProfileData_tDCEBF6CF74E9EBC0B9F9847CE96118169391B57D_marshal_pinvoke_back, GcUserProfileData_tDCEBF6CF74E9EBC0B9F9847CE96118169391B57D_marshal_pinvoke_cleanup, NULL, NULL, &GcUserProfileData_tDCEBF6CF74E9EBC0B9F9847CE96118169391B57D_0_0_0 } /* UnityEngine.SocialPlatforms.GameCenter.GcUserProfileData */,
	{ DelegatePInvokeWrapper_NativeUpdateCallback_tCC4B5A2692C21C00FC2FC1E4EC5280E98423B8D5, NULL, NULL, NULL, NULL, NULL, &NativeUpdateCallback_tCC4B5A2692C21C00FC2FC1E4EC5280E98423B8D5_0_0_0 } /* UnityEngineInternal.Input.NativeUpdateCallback */,
	{ NULL, EmitParams_t03557E552852EC6B71876CD05C4098733702A219_marshal_pinvoke, EmitParams_t03557E552852EC6B71876CD05C4098733702A219_marshal_pinvoke_back, EmitParams_t03557E552852EC6B71876CD05C4098733702A219_marshal_pinvoke_cleanup, NULL, NULL, &EmitParams_t03557E552852EC6B71876CD05C4098733702A219_0_0_0 } /* UnityEngine.ParticleSystem/EmitParams */,
	{ NULL, MainModule_t99C675667E0A363368324132DFA34B27FFEE6FC7_marshal_pinvoke, MainModule_t99C675667E0A363368324132DFA34B27FFEE6FC7_marshal_pinvoke_back, MainModule_t99C675667E0A363368324132DFA34B27FFEE6FC7_marshal_pinvoke_cleanup, NULL, NULL, &MainModule_t99C675667E0A363368324132DFA34B27FFEE6FC7_0_0_0 } /* UnityEngine.ParticleSystem/MainModule */,
	{ NULL, TextureSheetAnimationModule_t2F7A981851D997DFEB56E31A73824CA8595A96BD_marshal_pinvoke, TextureSheetAnimationModule_t2F7A981851D997DFEB56E31A73824CA8595A96BD_marshal_pinvoke_back, TextureSheetAnimationModule_t2F7A981851D997DFEB56E31A73824CA8595A96BD_marshal_pinvoke_cleanup, NULL, NULL, &TextureSheetAnimationModule_t2F7A981851D997DFEB56E31A73824CA8595A96BD_0_0_0 } /* UnityEngine.ParticleSystem/TextureSheetAnimationModule */,
	{ NULL, TileAnimationData_t2A9C81AD1F3E916C2DE292A6F3953FC8C38EFDA8_marshal_pinvoke, TileAnimationData_t2A9C81AD1F3E916C2DE292A6F3953FC8C38EFDA8_marshal_pinvoke_back, TileAnimationData_t2A9C81AD1F3E916C2DE292A6F3953FC8C38EFDA8_marshal_pinvoke_cleanup, NULL, NULL, &TileAnimationData_t2A9C81AD1F3E916C2DE292A6F3953FC8C38EFDA8_0_0_0 } /* UnityEngine.Tilemaps.TileAnimationData */,
	{ NULL, TileData_t8A50A35CAFD87C12E27D7E596D968C9114A4CBB5_marshal_pinvoke, TileData_t8A50A35CAFD87C12E27D7E596D968C9114A4CBB5_marshal_pinvoke_back, TileData_t8A50A35CAFD87C12E27D7E596D968C9114A4CBB5_marshal_pinvoke_cleanup, NULL, NULL, &TileData_t8A50A35CAFD87C12E27D7E596D968C9114A4CBB5_0_0_0 } /* UnityEngine.Tilemaps.TileData */,
	{ DelegatePInvokeWrapper_WillRenderCanvases_tBD5AD090B5938021DEAA679A5AEEA790F60A8BEE, NULL, NULL, NULL, NULL, NULL, &WillRenderCanvases_tBD5AD090B5938021DEAA679A5AEEA790F60A8BEE_0_0_0 } /* UnityEngine.Canvas/WillRenderCanvases */,
	{ NULL, ConnectionConfigInternal_t442D383D4EE17B207D66709528D4C68FE979E97B_marshal_pinvoke, ConnectionConfigInternal_t442D383D4EE17B207D66709528D4C68FE979E97B_marshal_pinvoke_back, ConnectionConfigInternal_t442D383D4EE17B207D66709528D4C68FE979E97B_marshal_pinvoke_cleanup, NULL, NULL, &ConnectionConfigInternal_t442D383D4EE17B207D66709528D4C68FE979E97B_0_0_0 } /* UnityEngine.Networking.ConnectionConfigInternal */,
	{ DelegatePInvokeWrapper_BasicResponseDelegate_t8187C8191D81C2DDE9FFEFCBEF4197628151DF66, NULL, NULL, NULL, NULL, NULL, &BasicResponseDelegate_t8187C8191D81C2DDE9FFEFCBEF4197628151DF66_0_0_0 } /* UnityEngine.Networking.Match.NetworkMatch/BasicResponseDelegate */,
	{ NULL, Analytics_tCA6E11F003D5B8AD0A5F0780BF5954566C7EB724_marshal_pinvoke, Analytics_tCA6E11F003D5B8AD0A5F0780BF5954566C7EB724_marshal_pinvoke_back, Analytics_tCA6E11F003D5B8AD0A5F0780BF5954566C7EB724_marshal_pinvoke_cleanup, NULL, NULL, &Analytics_tCA6E11F003D5B8AD0A5F0780BF5954566C7EB724_0_0_0 } /* UnityEngine.Analytics.Analytics */,
	{ DelegatePInvokeWrapper_SessionStateChanged_t9084549A636BD45086D66CC6765DA8C3DD31066F, NULL, NULL, NULL, NULL, NULL, &SessionStateChanged_t9084549A636BD45086D66CC6765DA8C3DD31066F_0_0_0 } /* UnityEngine.Analytics.AnalyticsSessionInfo/SessionStateChanged */,
	{ NULL, CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37_marshal_pinvoke, CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37_marshal_pinvoke_back, CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37_marshal_pinvoke_cleanup, NULL, NULL, &CustomEventData_t0FB0E3B1FD10141E3ADDA256C8F00C46B7BCCA37_0_0_0 } /* UnityEngine.Analytics.CustomEventData */,
	{ NULL, RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A_marshal_pinvoke, RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A_marshal_pinvoke_back, RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A_marshal_pinvoke_cleanup, NULL, NULL, &RemoteConfigSettings_t97154F5546B47CE72257CC2F0B677BDF696AEC4A_0_0_0 } /* UnityEngine.RemoteConfigSettings */,
	{ DelegatePInvokeWrapper_UpdatedEventHandler_tB0230BC83686D7126AB4D3800A66351028CA514F, NULL, NULL, NULL, NULL, NULL, &UpdatedEventHandler_tB0230BC83686D7126AB4D3800A66351028CA514F_0_0_0 } /* UnityEngine.RemoteSettings/UpdatedEventHandler */,
	{ NULL, VFXEventAttribute_t8FE74C5425505C55B4F79299C569CCE1A47BE325_marshal_pinvoke, VFXEventAttribute_t8FE74C5425505C55B4F79299C569CCE1A47BE325_marshal_pinvoke_back, VFXEventAttribute_t8FE74C5425505C55B4F79299C569CCE1A47BE325_marshal_pinvoke_cleanup, NULL, NULL, &VFXEventAttribute_t8FE74C5425505C55B4F79299C569CCE1A47BE325_0_0_0 } /* UnityEngine.Experimental.VFX.VFXEventAttribute */,
	{ NULL, VFXExpressionValues_tBEEC793A9CD5134400899D1AAE1ABF13AF6562F2_marshal_pinvoke, VFXExpressionValues_tBEEC793A9CD5134400899D1AAE1ABF13AF6562F2_marshal_pinvoke_back, VFXExpressionValues_tBEEC793A9CD5134400899D1AAE1ABF13AF6562F2_marshal_pinvoke_cleanup, NULL, NULL, &VFXExpressionValues_tBEEC793A9CD5134400899D1AAE1ABF13AF6562F2_0_0_0 } /* UnityEngine.Experimental.VFX.VFXExpressionValues */,
	{ NULL, VFXSpawnerState_t614A1AADC2EDB20E82A625BE053A22DB31D89AC7_marshal_pinvoke, VFXSpawnerState_t614A1AADC2EDB20E82A625BE053A22DB31D89AC7_marshal_pinvoke_back, VFXSpawnerState_t614A1AADC2EDB20E82A625BE053A22DB31D89AC7_marshal_pinvoke_cleanup, NULL, NULL, &VFXSpawnerState_t614A1AADC2EDB20E82A625BE053A22DB31D89AC7_0_0_0 } /* UnityEngine.Experimental.VFX.VFXSpawnerState */,
	{ DelegatePInvokeWrapper_UnityPurchasingCallback_tF3081DE4B67FBD9771C293C52885EC15C279810C, NULL, NULL, NULL, NULL, NULL, &UnityPurchasingCallback_tF3081DE4B67FBD9771C293C52885EC15C279810C_0_0_0 } /* UnityEngine.Purchasing.UnityPurchasingCallback */,
	{ NULL, NumberBuffer_t523F9CCA824CB72F54893DDB17C47553B942A2F8_marshal_pinvoke, NumberBuffer_t523F9CCA824CB72F54893DDB17C47553B942A2F8_marshal_pinvoke_back, NumberBuffer_t523F9CCA824CB72F54893DDB17C47553B942A2F8_marshal_pinvoke_cleanup, NULL, NULL, &NumberBuffer_t523F9CCA824CB72F54893DDB17C47553B942A2F8_0_0_0 } /* System.Globalization.FormatProvider/Number/NumberBuffer */,
	{ NULL, BigNumberBuffer_t9F40EEF6DD8AB26815DE5A7B877478BA0EB7E1BE_marshal_pinvoke, BigNumberBuffer_t9F40EEF6DD8AB26815DE5A7B877478BA0EB7E1BE_marshal_pinvoke_back, BigNumberBuffer_t9F40EEF6DD8AB26815DE5A7B877478BA0EB7E1BE_marshal_pinvoke_cleanup, NULL, NULL, &BigNumberBuffer_t9F40EEF6DD8AB26815DE5A7B877478BA0EB7E1BE_0_0_0 } /* System.Numerics.BigNumber/BigNumberBuffer */,
	{ DelegatePInvokeWrapper_OnChangeCallback_tFEBD666F7C9F71FC3D5DB3647CDA057E5A1CAC63, NULL, NULL, NULL, NULL, NULL, &OnChangeCallback_tFEBD666F7C9F71FC3D5DB3647CDA057E5A1CAC63_0_0_0 } /* Facebook.Unity.Settings.FacebookSettings/OnChangeCallback */,
	{ NULL, SchemaInfo_t2D049DAB3BE8BB8A771550C703D63474924D9921_marshal_pinvoke, SchemaInfo_t2D049DAB3BE8BB8A771550C703D63474924D9921_marshal_pinvoke_back, SchemaInfo_t2D049DAB3BE8BB8A771550C703D63474924D9921_marshal_pinvoke_cleanup, NULL, NULL, &SchemaInfo_t2D049DAB3BE8BB8A771550C703D63474924D9921_0_0_0 } /* System.Data.Common.SchemaInfo */,
	{ NULL, ColumnError_t24D74F834948955F6EC5949F7D308787C8AE77C3_marshal_pinvoke, ColumnError_t24D74F834948955F6EC5949F7D308787C8AE77C3_marshal_pinvoke_back, ColumnError_t24D74F834948955F6EC5949F7D308787C8AE77C3_marshal_pinvoke_cleanup, NULL, NULL, &ColumnError_t24D74F834948955F6EC5949F7D308787C8AE77C3_0_0_0 } /* System.Data.DataError/ColumnError */,
	{ NULL, DataKey_tCD4DE54A5F9CE06F835061308FC04C1ADEE23B2B_marshal_pinvoke, DataKey_tCD4DE54A5F9CE06F835061308FC04C1ADEE23B2B_marshal_pinvoke_back, DataKey_tCD4DE54A5F9CE06F835061308FC04C1ADEE23B2B_marshal_pinvoke_cleanup, NULL, NULL, &DataKey_tCD4DE54A5F9CE06F835061308FC04C1ADEE23B2B_0_0_0 } /* System.Data.DataKey */,
	{ NULL, DSRowDiffIdUsageSection_t25F76FD76EED1640B7E237B8949AB8FDBB0C627B_marshal_pinvoke, DSRowDiffIdUsageSection_t25F76FD76EED1640B7E237B8949AB8FDBB0C627B_marshal_pinvoke_back, DSRowDiffIdUsageSection_t25F76FD76EED1640B7E237B8949AB8FDBB0C627B_marshal_pinvoke_cleanup, NULL, NULL, &DSRowDiffIdUsageSection_t25F76FD76EED1640B7E237B8949AB8FDBB0C627B_0_0_0 } /* System.Data.DataTable/DSRowDiffIdUsageSection */,
	{ NULL, RowDiffIdUsageSection_t18F9526B89CAEC918AA011882C3730D5ABBB9F49_marshal_pinvoke, RowDiffIdUsageSection_t18F9526B89CAEC918AA011882C3730D5ABBB9F49_marshal_pinvoke_back, RowDiffIdUsageSection_t18F9526B89CAEC918AA011882C3730D5ABBB9F49_marshal_pinvoke_cleanup, NULL, NULL, &RowDiffIdUsageSection_t18F9526B89CAEC918AA011882C3730D5ABBB9F49_0_0_0 } /* System.Data.DataTable/RowDiffIdUsageSection */,
	{ NULL, ReservedWords_t4A019A68B07A6165275A53E7F8C9CA3DA7D39837_marshal_pinvoke, ReservedWords_t4A019A68B07A6165275A53E7F8C9CA3DA7D39837_marshal_pinvoke_back, ReservedWords_t4A019A68B07A6165275A53E7F8C9CA3DA7D39837_marshal_pinvoke_cleanup, NULL, NULL, &ReservedWords_t4A019A68B07A6165275A53E7F8C9CA3DA7D39837_0_0_0 } /* System.Data.ExpressionParser/ReservedWords */,
	{ NULL, IndexField_t8AA3B4B340507FBDDC4826EDA70F86CCA3E0CE23_marshal_pinvoke, IndexField_t8AA3B4B340507FBDDC4826EDA70F86CCA3E0CE23_marshal_pinvoke_back, IndexField_t8AA3B4B340507FBDDC4826EDA70F86CCA3E0CE23_marshal_pinvoke_cleanup, NULL, NULL, &IndexField_t8AA3B4B340507FBDDC4826EDA70F86CCA3E0CE23_0_0_0 } /* System.Data.IndexField */,
	{ NULL, Range_tBD1B3028D3E83275591B483FAAC93C8A23DF4E00_marshal_pinvoke, Range_tBD1B3028D3E83275591B483FAAC93C8A23DF4E00_marshal_pinvoke_back, Range_tBD1B3028D3E83275591B483FAAC93C8A23DF4E00_marshal_pinvoke_cleanup, NULL, NULL, &Range_tBD1B3028D3E83275591B483FAAC93C8A23DF4E00_0_0_0 } /* System.Data.Range */,
	{ NULL, SqlByte_tE6ADE9170D3F24E713655AD509DF9ACF7EDF5D60_marshal_pinvoke, SqlByte_tE6ADE9170D3F24E713655AD509DF9ACF7EDF5D60_marshal_pinvoke_back, SqlByte_tE6ADE9170D3F24E713655AD509DF9ACF7EDF5D60_marshal_pinvoke_cleanup, NULL, NULL, &SqlByte_tE6ADE9170D3F24E713655AD509DF9ACF7EDF5D60_0_0_0 } /* System.Data.SqlTypes.SqlByte */,
	{ NULL, SqlDateTime_t88C29083A1080E1FEBFE04250DB71BD1BEAC21B6_marshal_pinvoke, SqlDateTime_t88C29083A1080E1FEBFE04250DB71BD1BEAC21B6_marshal_pinvoke_back, SqlDateTime_t88C29083A1080E1FEBFE04250DB71BD1BEAC21B6_marshal_pinvoke_cleanup, NULL, NULL, &SqlDateTime_t88C29083A1080E1FEBFE04250DB71BD1BEAC21B6_0_0_0 } /* System.Data.SqlTypes.SqlDateTime */,
	{ NULL, SqlDouble_tE8F480EB5A508F211DF027033077AAD495085AD3_marshal_pinvoke, SqlDouble_tE8F480EB5A508F211DF027033077AAD495085AD3_marshal_pinvoke_back, SqlDouble_tE8F480EB5A508F211DF027033077AAD495085AD3_marshal_pinvoke_cleanup, NULL, NULL, &SqlDouble_tE8F480EB5A508F211DF027033077AAD495085AD3_0_0_0 } /* System.Data.SqlTypes.SqlDouble */,
	{ NULL, SqlInt16_t4BDD94EC1FE5FFDDB0E5C1E816F12DC03D897868_marshal_pinvoke, SqlInt16_t4BDD94EC1FE5FFDDB0E5C1E816F12DC03D897868_marshal_pinvoke_back, SqlInt16_t4BDD94EC1FE5FFDDB0E5C1E816F12DC03D897868_marshal_pinvoke_cleanup, NULL, NULL, &SqlInt16_t4BDD94EC1FE5FFDDB0E5C1E816F12DC03D897868_0_0_0 } /* System.Data.SqlTypes.SqlInt16 */,
	{ NULL, SqlInt32_tA53F3E3847008FF7C15F2A2043BBDE6800C81F78_marshal_pinvoke, SqlInt32_tA53F3E3847008FF7C15F2A2043BBDE6800C81F78_marshal_pinvoke_back, SqlInt32_tA53F3E3847008FF7C15F2A2043BBDE6800C81F78_marshal_pinvoke_cleanup, NULL, NULL, &SqlInt32_tA53F3E3847008FF7C15F2A2043BBDE6800C81F78_0_0_0 } /* System.Data.SqlTypes.SqlInt32 */,
	{ NULL, SqlInt64_tFE4BADAABAE9E38BE4CFFC3FFF5ED3544A8E1612_marshal_pinvoke, SqlInt64_tFE4BADAABAE9E38BE4CFFC3FFF5ED3544A8E1612_marshal_pinvoke_back, SqlInt64_tFE4BADAABAE9E38BE4CFFC3FFF5ED3544A8E1612_marshal_pinvoke_cleanup, NULL, NULL, &SqlInt64_tFE4BADAABAE9E38BE4CFFC3FFF5ED3544A8E1612_0_0_0 } /* System.Data.SqlTypes.SqlInt64 */,
	{ NULL, SqlMoney_tE28D6EE20627835412ABEA9A26513F16A1C34C67_marshal_pinvoke, SqlMoney_tE28D6EE20627835412ABEA9A26513F16A1C34C67_marshal_pinvoke_back, SqlMoney_tE28D6EE20627835412ABEA9A26513F16A1C34C67_marshal_pinvoke_cleanup, NULL, NULL, &SqlMoney_tE28D6EE20627835412ABEA9A26513F16A1C34C67_0_0_0 } /* System.Data.SqlTypes.SqlMoney */,
	{ NULL, SqlSingle_t4300B130B28611DF2331C8A6FE105EC9BAE75CD0_marshal_pinvoke, SqlSingle_t4300B130B28611DF2331C8A6FE105EC9BAE75CD0_marshal_pinvoke_back, SqlSingle_t4300B130B28611DF2331C8A6FE105EC9BAE75CD0_marshal_pinvoke_cleanup, NULL, NULL, &SqlSingle_t4300B130B28611DF2331C8A6FE105EC9BAE75CD0_0_0_0 } /* System.Data.SqlTypes.SqlSingle */,
	{ NULL, SqlString_t54E2DCD6922BD82058A86F08813770E597FC14E3_marshal_pinvoke, SqlString_t54E2DCD6922BD82058A86F08813770E597FC14E3_marshal_pinvoke_back, SqlString_t54E2DCD6922BD82058A86F08813770E597FC14E3_marshal_pinvoke_cleanup, NULL, NULL, &SqlString_t54E2DCD6922BD82058A86F08813770E597FC14E3_0_0_0 } /* System.Data.SqlTypes.SqlString */,
	{ DelegatePInvokeWrapper_UnityNativePurchasingCallback_t58A016E25D4C5E8E9C7709A2EE87766ED4D02136, NULL, NULL, NULL, NULL, NULL, &UnityNativePurchasingCallback_t58A016E25D4C5E8E9C7709A2EE87766ED4D02136_0_0_0 } /* UnityEngine.Purchasing.UnityNativePurchasingCallback */,
	{ NULL, RaycastResult_t991BCED43A91EDD8580F39631DA07B1F88C58B91_marshal_pinvoke, RaycastResult_t991BCED43A91EDD8580F39631DA07B1F88C58B91_marshal_pinvoke_back, RaycastResult_t991BCED43A91EDD8580F39631DA07B1F88C58B91_marshal_pinvoke_cleanup, NULL, NULL, &RaycastResult_t991BCED43A91EDD8580F39631DA07B1F88C58B91_0_0_0 } /* UnityEngine.EventSystems.RaycastResult */,
	{ NULL, ColorTween_t4CBBF5875FA391053DB62E98D8D9603040413228_marshal_pinvoke, ColorTween_t4CBBF5875FA391053DB62E98D8D9603040413228_marshal_pinvoke_back, ColorTween_t4CBBF5875FA391053DB62E98D8D9603040413228_marshal_pinvoke_cleanup, NULL, NULL, &ColorTween_t4CBBF5875FA391053DB62E98D8D9603040413228_0_0_0 } /* UnityEngine.UI.CoroutineTween.ColorTween */,
	{ NULL, FloatTween_tF6BB24C266F36BD80E20C91AED453F7CE516919A_marshal_pinvoke, FloatTween_tF6BB24C266F36BD80E20C91AED453F7CE516919A_marshal_pinvoke_back, FloatTween_tF6BB24C266F36BD80E20C91AED453F7CE516919A_marshal_pinvoke_cleanup, NULL, NULL, &FloatTween_tF6BB24C266F36BD80E20C91AED453F7CE516919A_0_0_0 } /* UnityEngine.UI.CoroutineTween.FloatTween */,
	{ NULL, Resources_t0D3248037D186E6B8BB5CF2BD1EB021CF3E6DEE4_marshal_pinvoke, Resources_t0D3248037D186E6B8BB5CF2BD1EB021CF3E6DEE4_marshal_pinvoke_back, Resources_t0D3248037D186E6B8BB5CF2BD1EB021CF3E6DEE4_marshal_pinvoke_cleanup, NULL, NULL, &Resources_t0D3248037D186E6B8BB5CF2BD1EB021CF3E6DEE4_0_0_0 } /* UnityEngine.UI.DefaultControls/Resources */,
	{ DelegatePInvokeWrapper_OnValidateInput_t3E857B491A319A5B22F6AD3D02CFD22C1BBFD8D0, NULL, NULL, NULL, NULL, NULL, &OnValidateInput_t3E857B491A319A5B22F6AD3D02CFD22C1BBFD8D0_0_0_0 } /* UnityEngine.UI.InputField/OnValidateInput */,
	{ NULL, Navigation_t761250C05C09773B75F5E0D52DDCBBFE60288A07_marshal_pinvoke, Navigation_t761250C05C09773B75F5E0D52DDCBBFE60288A07_marshal_pinvoke_back, Navigation_t761250C05C09773B75F5E0D52DDCBBFE60288A07_marshal_pinvoke_cleanup, NULL, NULL, &Navigation_t761250C05C09773B75F5E0D52DDCBBFE60288A07_0_0_0 } /* UnityEngine.UI.Navigation */,
	{ DelegatePInvokeWrapper_GetRayIntersectionAllCallback_t68C2581CCF05E868297EBD3F3361274954845095, NULL, NULL, NULL, NULL, NULL, &GetRayIntersectionAllCallback_t68C2581CCF05E868297EBD3F3361274954845095_0_0_0 } /* UnityEngine.UI.ReflectionMethodsCache/GetRayIntersectionAllCallback */,
	{ DelegatePInvokeWrapper_GetRayIntersectionAllNonAllocCallback_tAD7508D45DB6679B6394983579AD18D967CC2AD4, NULL, NULL, NULL, NULL, NULL, &GetRayIntersectionAllNonAllocCallback_tAD7508D45DB6679B6394983579AD18D967CC2AD4_0_0_0 } /* UnityEngine.UI.ReflectionMethodsCache/GetRayIntersectionAllNonAllocCallback */,
	{ DelegatePInvokeWrapper_GetRaycastNonAllocCallback_tC13D9767CFF00EAB26E9FCC4BDD505F0721A2B4D, NULL, NULL, NULL, NULL, NULL, &GetRaycastNonAllocCallback_tC13D9767CFF00EAB26E9FCC4BDD505F0721A2B4D_0_0_0 } /* UnityEngine.UI.ReflectionMethodsCache/GetRaycastNonAllocCallback */,
	{ DelegatePInvokeWrapper_Raycast2DCallback_tE99ABF9ABC3A380677949E8C05A3E477889B82BE, NULL, NULL, NULL, NULL, NULL, &Raycast2DCallback_tE99ABF9ABC3A380677949E8C05A3E477889B82BE_0_0_0 } /* UnityEngine.UI.ReflectionMethodsCache/Raycast2DCallback */,
	{ DelegatePInvokeWrapper_Raycast3DCallback_t83483916473C9710AEDB316A65CBE62C58935C5F, NULL, NULL, NULL, NULL, NULL, &Raycast3DCallback_t83483916473C9710AEDB316A65CBE62C58935C5F_0_0_0 } /* UnityEngine.UI.ReflectionMethodsCache/Raycast3DCallback */,
	{ DelegatePInvokeWrapper_RaycastAllCallback_t751407A44270E02FAA43D0846A58EE6A8C4AE1CE, NULL, NULL, NULL, NULL, NULL, &RaycastAllCallback_t751407A44270E02FAA43D0846A58EE6A8C4AE1CE_0_0_0 } /* UnityEngine.UI.ReflectionMethodsCache/RaycastAllCallback */,
	{ NULL, SpriteState_t58B9DD66A79CD69AB4CFC3AD0C41E45DC2192C0A_marshal_pinvoke, SpriteState_t58B9DD66A79CD69AB4CFC3AD0C41E45DC2192C0A_marshal_pinvoke_back, SpriteState_t58B9DD66A79CD69AB4CFC3AD0C41E45DC2192C0A_marshal_pinvoke_cleanup, NULL, NULL, &SpriteState_t58B9DD66A79CD69AB4CFC3AD0C41E45DC2192C0A_0_0_0 } /* UnityEngine.UI.SpriteState */,
	{ DelegatePInvokeWrapper_OnDLLLoaded_tAF568D819FCD091C003142925B7CE144C63DCA1B, NULL, NULL, NULL, NULL, NULL, &OnDLLLoaded_tAF568D819FCD091C003142925B7CE144C63DCA1B_0_0_0 } /* Facebook.Unity.FB/OnDLLLoaded */,
	{ DelegatePInvokeWrapper_HideUnityDelegate_tE5AD84D37D94FD7829357528123F1DB1061CBB0F, NULL, NULL, NULL, NULL, NULL, &HideUnityDelegate_tE5AD84D37D94FD7829357528123F1DB1061CBB0F_0_0_0 } /* Facebook.Unity.HideUnityDelegate */,
	{ DelegatePInvokeWrapper_InitDelegate_tC8A60730C250DA905E53C3B2E9A16F0EC9498F31, NULL, NULL, NULL, NULL, NULL, &InitDelegate_tC8A60730C250DA905E53C3B2E9A16F0EC9498F31_0_0_0 } /* Facebook.Unity.InitDelegate */,
	{ DelegatePInvokeWrapper_SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22, NULL, NULL, NULL, NULL, NULL, &SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22_0_0_0 } /* Mono.Data.Sqlite.SQLiteCallback */,
	{ DelegatePInvokeWrapper_SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B, NULL, NULL, NULL, NULL, NULL, &SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B_0_0_0 } /* Mono.Data.Sqlite.SQLiteCollation */,
	{ DelegatePInvokeWrapper_SQLiteCommitCallback_t4A2F244F9FCADC58BAEFCDB1F9A4AEA018294B4F, NULL, NULL, NULL, NULL, NULL, &SQLiteCommitCallback_t4A2F244F9FCADC58BAEFCDB1F9A4AEA018294B4F_0_0_0 } /* Mono.Data.Sqlite.SQLiteCommitCallback */,
	{ DelegatePInvokeWrapper_SQLiteFinalCallback_tDADE001E38D3B50F9259C9D956A11D3B4D875453, NULL, NULL, NULL, NULL, NULL, &SQLiteFinalCallback_tDADE001E38D3B50F9259C9D956A11D3B4D875453_0_0_0 } /* Mono.Data.Sqlite.SQLiteFinalCallback */,
	{ DelegatePInvokeWrapper_SQLiteRollbackCallback_t0879E30A50B184087AFBA2EC348DAF30A4646D8A, NULL, NULL, NULL, NULL, NULL, &SQLiteRollbackCallback_t0879E30A50B184087AFBA2EC348DAF30A4646D8A_0_0_0 } /* Mono.Data.Sqlite.SQLiteRollbackCallback */,
	{ NULL, SQLiteTypeNames_tCB9EBCDDD03CE6495A5CA9DB9C5B91FE66BB8B0F_marshal_pinvoke, SQLiteTypeNames_tCB9EBCDDD03CE6495A5CA9DB9C5B91FE66BB8B0F_marshal_pinvoke_back, SQLiteTypeNames_tCB9EBCDDD03CE6495A5CA9DB9C5B91FE66BB8B0F_marshal_pinvoke_cleanup, NULL, NULL, &SQLiteTypeNames_tCB9EBCDDD03CE6495A5CA9DB9C5B91FE66BB8B0F_0_0_0 } /* Mono.Data.Sqlite.SQLiteTypeNames */,
	{ DelegatePInvokeWrapper_SQLiteUpdateCallback_t3252735A38A0D75E6E9CB742FBFB194CD942712F, NULL, NULL, NULL, NULL, NULL, &SQLiteUpdateCallback_t3252735A38A0D75E6E9CB742FBFB194CD942712F_0_0_0 } /* Mono.Data.Sqlite.SQLiteUpdateCallback */,
	{ NULL, KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC_marshal_pinvoke, KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC_marshal_pinvoke_back, KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC_marshal_pinvoke_cleanup, NULL, NULL, &KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC_0_0_0 } /* Mono.Data.Sqlite.SqliteKeyReader/KeyInfo */,
	{ DelegatePInvokeWrapper_unityAdsBannerClick_t8F2B887BAF928A1DF8F8E0CF5B87713FF3ABC32E, NULL, NULL, NULL, NULL, NULL, &unityAdsBannerClick_t8F2B887BAF928A1DF8F8E0CF5B87713FF3ABC32E_0_0_0 } /* UnityEngine.Advertisements.Banner/unityAdsBannerClick */,
	{ DelegatePInvokeWrapper_unityAdsBannerError_t3435EC218C4E75B7B16D343D8C0B42EABF865582, NULL, NULL, NULL, NULL, NULL, &unityAdsBannerError_t3435EC218C4E75B7B16D343D8C0B42EABF865582_0_0_0 } /* UnityEngine.Advertisements.Banner/unityAdsBannerError */,
	{ DelegatePInvokeWrapper_unityAdsBannerHide_t9EC0D722659D6A7CE6DFC32266580E291D71FE38, NULL, NULL, NULL, NULL, NULL, &unityAdsBannerHide_t9EC0D722659D6A7CE6DFC32266580E291D71FE38_0_0_0 } /* UnityEngine.Advertisements.Banner/unityAdsBannerHide */,
	{ DelegatePInvokeWrapper_unityAdsBannerLoad_tF0E1DAC48BC4DE378A6B59DFE0703533F0428A3A, NULL, NULL, NULL, NULL, NULL, &unityAdsBannerLoad_tF0E1DAC48BC4DE378A6B59DFE0703533F0428A3A_0_0_0 } /* UnityEngine.Advertisements.Banner/unityAdsBannerLoad */,
	{ DelegatePInvokeWrapper_unityAdsBannerShow_t4522189E90DC4FD255574AD403FBEC003522F593, NULL, NULL, NULL, NULL, NULL, &unityAdsBannerShow_t4522189E90DC4FD255574AD403FBEC003522F593_0_0_0 } /* UnityEngine.Advertisements.Banner/unityAdsBannerShow */,
	{ DelegatePInvokeWrapper_unityAdsBannerUnload_tA6E54A057FA4B8FCFD61C42B82ACBF2E7423A1A0, NULL, NULL, NULL, NULL, NULL, &unityAdsBannerUnload_tA6E54A057FA4B8FCFD61C42B82ACBF2E7423A1A0_0_0_0 } /* UnityEngine.Advertisements.Banner/unityAdsBannerUnload */,
	{ DelegatePInvokeWrapper_ErrorCallback_t3CEC714BB3F6AD7FCBB4D6C54706A97AA7C512E7, NULL, NULL, NULL, NULL, NULL, &ErrorCallback_t3CEC714BB3F6AD7FCBB4D6C54706A97AA7C512E7_0_0_0 } /* UnityEngine.Advertisements.BannerLoadOptions/ErrorCallback */,
	{ DelegatePInvokeWrapper_LoadCallback_tCBBAB2E31C3EFD41C203210652E34DF84B65C88B, NULL, NULL, NULL, NULL, NULL, &LoadCallback_tCBBAB2E31C3EFD41C203210652E34DF84B65C88B_0_0_0 } /* UnityEngine.Advertisements.BannerLoadOptions/LoadCallback */,
	{ DelegatePInvokeWrapper_BannerCallback_t802365DBFC08D767D12D99D72BF668E07EDE5EB6, NULL, NULL, NULL, NULL, NULL, &BannerCallback_t802365DBFC08D767D12D99D72BF668E07EDE5EB6_0_0_0 } /* UnityEngine.Advertisements.BannerOptions/BannerCallback */,
	{ DelegatePInvokeWrapper_unityAdsDidError_tB860C08AEB1B516A0F53E6F6BC9985FFC516B56A, NULL, NULL, NULL, NULL, NULL, &unityAdsDidError_tB860C08AEB1B516A0F53E6F6BC9985FFC516B56A_0_0_0 } /* UnityEngine.Advertisements.Platform/unityAdsDidError */,
	{ DelegatePInvokeWrapper_unityAdsDidFinish_t59DC1F5EA6E1771A80EC9B06BE941A7947323E41, NULL, NULL, NULL, NULL, NULL, &unityAdsDidFinish_t59DC1F5EA6E1771A80EC9B06BE941A7947323E41_0_0_0 } /* UnityEngine.Advertisements.Platform/unityAdsDidFinish */,
	{ DelegatePInvokeWrapper_unityAdsDidStart_t88F5E9F8951465F4CA4AE7B5E50752B4310F4066, NULL, NULL, NULL, NULL, NULL, &unityAdsDidStart_t88F5E9F8951465F4CA4AE7B5E50752B4310F4066_0_0_0 } /* UnityEngine.Advertisements.Platform/unityAdsDidStart */,
	{ DelegatePInvokeWrapper_unityAdsReady_t9DD2598EDDEB8A66AEA565E66348E68FBAAC7A42, NULL, NULL, NULL, NULL, NULL, &unityAdsReady_t9DD2598EDDEB8A66AEA565E66348E68FBAAC7A42_0_0_0 } /* UnityEngine.Advertisements.Platform/unityAdsReady */,
	{ DelegatePInvokeWrapper_unityAdsPurchasingDidInitiatePurchasingCommand_t759E05AD4B853DEA5F3728EF572321D9239FCF89, NULL, NULL, NULL, NULL, NULL, &unityAdsPurchasingDidInitiatePurchasingCommand_t759E05AD4B853DEA5F3728EF572321D9239FCF89_0_0_0 } /* UnityEngine.Advertisements.PurchasingPlatform/unityAdsPurchasingDidInitiatePurchasingCommand */,
	{ DelegatePInvokeWrapper_unityAdsPurchasingGetProductCatalog_tBC1786FAA2E7C404DEC81DB2CB0EB2B8CA4037A7, NULL, NULL, NULL, NULL, NULL, &unityAdsPurchasingGetProductCatalog_tBC1786FAA2E7C404DEC81DB2CB0EB2B8CA4037A7_0_0_0 } /* UnityEngine.Advertisements.PurchasingPlatform/unityAdsPurchasingGetProductCatalog */,
	{ DelegatePInvokeWrapper_unityAdsPurchasingGetPurchasingVersion_tE5CC48324CE3D72814A6E45EB735EF90FF886F44, NULL, NULL, NULL, NULL, NULL, &unityAdsPurchasingGetPurchasingVersion_tE5CC48324CE3D72814A6E45EB735EF90FF886F44_0_0_0 } /* UnityEngine.Advertisements.PurchasingPlatform/unityAdsPurchasingGetPurchasingVersion */,
	{ DelegatePInvokeWrapper_unityAdsPurchasingInitialize_tF23E33D0423E2EE4F014591F599E0615B3DC31A5, NULL, NULL, NULL, NULL, NULL, &unityAdsPurchasingInitialize_tF23E33D0423E2EE4F014591F599E0615B3DC31A5_0_0_0 } /* UnityEngine.Advertisements.PurchasingPlatform/unityAdsPurchasingInitialize */,
	{ NULL, ChannelPacket_t1463DDB5D2C734160303B94DBF5E8E8C220AA6B3_marshal_pinvoke, ChannelPacket_t1463DDB5D2C734160303B94DBF5E8E8C220AA6B3_marshal_pinvoke_back, ChannelPacket_t1463DDB5D2C734160303B94DBF5E8E8C220AA6B3_marshal_pinvoke_cleanup, NULL, NULL, &ChannelPacket_t1463DDB5D2C734160303B94DBF5E8E8C220AA6B3_0_0_0 } /* UnityEngine.Networking.ChannelPacket */,
	{ NULL, NetworkBroadcastResult_t362C44B9A7CF56BBBA0D2CD5E9EB640F95A6F6EB_marshal_pinvoke, NetworkBroadcastResult_t362C44B9A7CF56BBBA0D2CD5E9EB640F95A6F6EB_marshal_pinvoke_back, NetworkBroadcastResult_t362C44B9A7CF56BBBA0D2CD5E9EB640F95A6F6EB_marshal_pinvoke_cleanup, NULL, NULL, &NetworkBroadcastResult_t362C44B9A7CF56BBBA0D2CD5E9EB640F95A6F6EB_0_0_0 } /* UnityEngine.Networking.NetworkBroadcastResult */,
	{ NULL, PendingPlayer_t2D703F7EA98B24BE443F6FF1FF4ABDA6E5B2ECE1_marshal_pinvoke, PendingPlayer_t2D703F7EA98B24BE443F6FF1FF4ABDA6E5B2ECE1_marshal_pinvoke_back, PendingPlayer_t2D703F7EA98B24BE443F6FF1FF4ABDA6E5B2ECE1_marshal_pinvoke_cleanup, NULL, NULL, &PendingPlayer_t2D703F7EA98B24BE443F6FF1FF4ABDA6E5B2ECE1_0_0_0 } /* UnityEngine.Networking.NetworkLobbyManager/PendingPlayer */,
	{ NULL, ConnectionPendingPlayers_tC607E3F095B410BC34839FB3AEA767B20C6E6ACE_marshal_pinvoke, ConnectionPendingPlayers_tC607E3F095B410BC34839FB3AEA767B20C6E6ACE_marshal_pinvoke_back, ConnectionPendingPlayers_tC607E3F095B410BC34839FB3AEA767B20C6E6ACE_marshal_pinvoke_cleanup, NULL, NULL, &ConnectionPendingPlayers_tC607E3F095B410BC34839FB3AEA767B20C6E6ACE_0_0_0 } /* UnityEngine.Networking.NetworkMigrationManager/ConnectionPendingPlayers */,
	{ NULL, PendingPlayerInfo_t585C3975FF9CBE89020F5AB4C6BDEA018DC4BA3A_marshal_pinvoke, PendingPlayerInfo_t585C3975FF9CBE89020F5AB4C6BDEA018DC4BA3A_marshal_pinvoke_back, PendingPlayerInfo_t585C3975FF9CBE89020F5AB4C6BDEA018DC4BA3A_marshal_pinvoke_cleanup, NULL, NULL, &PendingPlayerInfo_t585C3975FF9CBE89020F5AB4C6BDEA018DC4BA3A_0_0_0 } /* UnityEngine.Networking.NetworkMigrationManager/PendingPlayerInfo */,
	{ NULL, CRCMessageEntry_tA0C9B1AED99C4DA3F62AF6B9D63440E4024A8B3D_marshal_pinvoke, CRCMessageEntry_tA0C9B1AED99C4DA3F62AF6B9D63440E4024A8B3D_marshal_pinvoke_back, CRCMessageEntry_tA0C9B1AED99C4DA3F62AF6B9D63440E4024A8B3D_marshal_pinvoke_cleanup, NULL, NULL, &CRCMessageEntry_tA0C9B1AED99C4DA3F62AF6B9D63440E4024A8B3D_0_0_0 } /* UnityEngine.Networking.NetworkSystem.CRCMessageEntry */,
	{ DelegatePInvokeWrapper_ClientMoveCallback2D_t8B84768DE7682C54CEB63E3C8265F817CF34B5C6, NULL, NULL, NULL, NULL, NULL, &ClientMoveCallback2D_t8B84768DE7682C54CEB63E3C8265F817CF34B5C6_0_0_0 } /* UnityEngine.Networking.NetworkTransform/ClientMoveCallback2D */,
	{ DelegatePInvokeWrapper_ClientMoveCallback3D_t7BA9288D0A33613F8C6CB39E58F47F22C4F80636, NULL, NULL, NULL, NULL, NULL, &ClientMoveCallback3D_t7BA9288D0A33613F8C6CB39E58F47F22C4F80636_0_0_0 } /* UnityEngine.Networking.NetworkTransform/ClientMoveCallback3D */,
	{ NULL, CameraData_t1E464C8FD597DAF030BB0CEBCD3E7BA8137EB3A6_marshal_pinvoke, CameraData_t1E464C8FD597DAF030BB0CEBCD3E7BA8137EB3A6_marshal_pinvoke_back, CameraData_t1E464C8FD597DAF030BB0CEBCD3E7BA8137EB3A6_marshal_pinvoke_cleanup, NULL, NULL, &CameraData_t1E464C8FD597DAF030BB0CEBCD3E7BA8137EB3A6_0_0_0 } /* AdvancedCoroutines.AdvancedCoroutinesMonoContoller/CameraData */,
	{ DelegatePInvokeWrapper_CompressFunc_t81FC687403DA94FC5391CE904E3B1E3E0A16951B, NULL, NULL, NULL, NULL, NULL, &CompressFunc_t81FC687403DA94FC5391CE904E3B1E3E0A16951B_0_0_0 } /* BestHTTP.Decompression.Zlib.DeflateManager/CompressFunc */,
	{ NULL, ClientMessage_t58311ADBFA310AE409AA6E39AE5FD76E18EE8879_marshal_pinvoke, ClientMessage_t58311ADBFA310AE409AA6E39AE5FD76E18EE8879_marshal_pinvoke_back, ClientMessage_t58311ADBFA310AE409AA6E39AE5FD76E18EE8879_marshal_pinvoke_cleanup, NULL, NULL, &ClientMessage_t58311ADBFA310AE409AA6E39AE5FD76E18EE8879_0_0_0 } /* BestHTTP.SignalR.Messages.ClientMessage */,
	{ NULL, NeedRequest_t61DF4E7A3EEE21EF00172BCC0FF6D0203875E690_marshal_pinvoke, NeedRequest_t61DF4E7A3EEE21EF00172BCC0FF6D0203875E690_marshal_pinvoke_back, NeedRequest_t61DF4E7A3EEE21EF00172BCC0FF6D0203875E690_marshal_pinvoke_cleanup, NULL, NULL, &NeedRequest_t61DF4E7A3EEE21EF00172BCC0FF6D0203875E690_0_0_0 } /* Data/NeedRequest */,
	{ NULL, Result_t772620F01E211D420E5495A876E007FB3EA78B28_marshal_pinvoke, Result_t772620F01E211D420E5495A876E007FB3EA78B28_marshal_pinvoke_back, Result_t772620F01E211D420E5495A876E007FB3EA78B28_marshal_pinvoke_cleanup, NULL, NULL, &Result_t772620F01E211D420E5495A876E007FB3EA78B28_0_0_0 } /* GameType/Result */,
	{ NULL, WordMatch_tF996DCE69EAEA187A3F4510FFB330524886D4DBF_marshal_pinvoke, WordMatch_tF996DCE69EAEA187A3F4510FFB330524886D4DBF_marshal_pinvoke_back, WordMatch_tF996DCE69EAEA187A3F4510FFB330524886D4DBF_marshal_pinvoke_cleanup, NULL, NULL, &WordMatch_tF996DCE69EAEA187A3F4510FFB330524886D4DBF_0_0_0 } /* Ganss.Text.WordMatch */,
	{ DelegatePInvokeWrapper_GADUAdLoaderDidFailToReceiveAdWithErrorCallback_tD0A3FBA4FEFCEA84156E6DD5FBC14C7120B39370, NULL, NULL, NULL, NULL, NULL, &GADUAdLoaderDidFailToReceiveAdWithErrorCallback_tD0A3FBA4FEFCEA84156E6DD5FBC14C7120B39370_0_0_0 } /* GoogleMobileAds.iOS.AdLoaderClient/GADUAdLoaderDidFailToReceiveAdWithErrorCallback */,
	{ DelegatePInvokeWrapper_GADUAdLoaderDidReceiveNativeCustomTemplateAdCallback_t3CAC1C526BCCD015267BEEB4408990038E75846A, NULL, NULL, NULL, NULL, NULL, &GADUAdLoaderDidReceiveNativeCustomTemplateAdCallback_t3CAC1C526BCCD015267BEEB4408990038E75846A_0_0_0 } /* GoogleMobileAds.iOS.AdLoaderClient/GADUAdLoaderDidReceiveNativeCustomTemplateAdCallback */,
	{ DelegatePInvokeWrapper_GADUAdViewDidDismissScreenCallback_tA439B758F1D283C6F1D4BFF4DFAF8400969D596E, NULL, NULL, NULL, NULL, NULL, &GADUAdViewDidDismissScreenCallback_tA439B758F1D283C6F1D4BFF4DFAF8400969D596E_0_0_0 } /* GoogleMobileAds.iOS.BannerClient/GADUAdViewDidDismissScreenCallback */,
	{ DelegatePInvokeWrapper_GADUAdViewDidFailToReceiveAdWithErrorCallback_tDD709BA804FCBBC8575C993E22D5C592AC2AABFB, NULL, NULL, NULL, NULL, NULL, &GADUAdViewDidFailToReceiveAdWithErrorCallback_tDD709BA804FCBBC8575C993E22D5C592AC2AABFB_0_0_0 } /* GoogleMobileAds.iOS.BannerClient/GADUAdViewDidFailToReceiveAdWithErrorCallback */,
	{ DelegatePInvokeWrapper_GADUAdViewDidReceiveAdCallback_tD0EDCCD0E01B583C423B8899736B917A109DD33F, NULL, NULL, NULL, NULL, NULL, &GADUAdViewDidReceiveAdCallback_tD0EDCCD0E01B583C423B8899736B917A109DD33F_0_0_0 } /* GoogleMobileAds.iOS.BannerClient/GADUAdViewDidReceiveAdCallback */,
	{ DelegatePInvokeWrapper_GADUAdViewWillLeaveApplicationCallback_t25CB512D2FBBC084029828A8AAF881B352974915, NULL, NULL, NULL, NULL, NULL, &GADUAdViewWillLeaveApplicationCallback_t25CB512D2FBBC084029828A8AAF881B352974915_0_0_0 } /* GoogleMobileAds.iOS.BannerClient/GADUAdViewWillLeaveApplicationCallback */,
	{ DelegatePInvokeWrapper_GADUAdViewWillPresentScreenCallback_t6DD8BA1A4EA4BAD158808A5CA9DAFEA14CA58225, NULL, NULL, NULL, NULL, NULL, &GADUAdViewWillPresentScreenCallback_t6DD8BA1A4EA4BAD158808A5CA9DAFEA14CA58225_0_0_0 } /* GoogleMobileAds.iOS.BannerClient/GADUAdViewWillPresentScreenCallback */,
	{ DelegatePInvokeWrapper_GADUNativeCustomTemplateDidReceiveClick_tC701439AFDA476706B49DD67AC24524100FF1647, NULL, NULL, NULL, NULL, NULL, &GADUNativeCustomTemplateDidReceiveClick_tC701439AFDA476706B49DD67AC24524100FF1647_0_0_0 } /* GoogleMobileAds.iOS.CustomNativeTemplateClient/GADUNativeCustomTemplateDidReceiveClick */,
	{ DelegatePInvokeWrapper_GADUInterstitialDidDismissScreenCallback_t26B11CDFFD2C154F696686C0277235F5E63F17BD, NULL, NULL, NULL, NULL, NULL, &GADUInterstitialDidDismissScreenCallback_t26B11CDFFD2C154F696686C0277235F5E63F17BD_0_0_0 } /* GoogleMobileAds.iOS.InterstitialClient/GADUInterstitialDidDismissScreenCallback */,
	{ DelegatePInvokeWrapper_GADUInterstitialDidFailToReceiveAdWithErrorCallback_tEE8B8CB712217A5D36EA3709647A40C8EB3A0FE3, NULL, NULL, NULL, NULL, NULL, &GADUInterstitialDidFailToReceiveAdWithErrorCallback_tEE8B8CB712217A5D36EA3709647A40C8EB3A0FE3_0_0_0 } /* GoogleMobileAds.iOS.InterstitialClient/GADUInterstitialDidFailToReceiveAdWithErrorCallback */,
	{ DelegatePInvokeWrapper_GADUInterstitialDidReceiveAdCallback_t070DE72316EE0F86A1B260139133C47EDDFEA632, NULL, NULL, NULL, NULL, NULL, &GADUInterstitialDidReceiveAdCallback_t070DE72316EE0F86A1B260139133C47EDDFEA632_0_0_0 } /* GoogleMobileAds.iOS.InterstitialClient/GADUInterstitialDidReceiveAdCallback */,
	{ DelegatePInvokeWrapper_GADUInterstitialWillLeaveApplicationCallback_t8C3AEFD8BC6C59EF9108F7120396315B5365151C, NULL, NULL, NULL, NULL, NULL, &GADUInterstitialWillLeaveApplicationCallback_t8C3AEFD8BC6C59EF9108F7120396315B5365151C_0_0_0 } /* GoogleMobileAds.iOS.InterstitialClient/GADUInterstitialWillLeaveApplicationCallback */,
	{ DelegatePInvokeWrapper_GADUInterstitialWillPresentScreenCallback_t4298A1AC94E8279F7C37AC1837949144BA779756, NULL, NULL, NULL, NULL, NULL, &GADUInterstitialWillPresentScreenCallback_t4298A1AC94E8279F7C37AC1837949144BA779756_0_0_0 } /* GoogleMobileAds.iOS.InterstitialClient/GADUInterstitialWillPresentScreenCallback */,
	{ DelegatePInvokeWrapper_GADUInitializationCompleteCallback_t64C73660F404CB5C59D8522D84AA0235FF10E05A, NULL, NULL, NULL, NULL, NULL, &GADUInitializationCompleteCallback_t64C73660F404CB5C59D8522D84AA0235FF10E05A_0_0_0 } /* GoogleMobileAds.iOS.MobileAdsClient/GADUInitializationCompleteCallback */,
	{ DelegatePInvokeWrapper_GADURewardBasedVideoAdDidCloseCallback_t26F05B6279C5EFCAAC89142AC46398ECA18ED67E, NULL, NULL, NULL, NULL, NULL, &GADURewardBasedVideoAdDidCloseCallback_t26F05B6279C5EFCAAC89142AC46398ECA18ED67E_0_0_0 } /* GoogleMobileAds.iOS.RewardBasedVideoAdClient/GADURewardBasedVideoAdDidCloseCallback */,
	{ DelegatePInvokeWrapper_GADURewardBasedVideoAdDidCompleteCallback_t43AB49809F1D6B1439D437FD0EF3639BCC118A46, NULL, NULL, NULL, NULL, NULL, &GADURewardBasedVideoAdDidCompleteCallback_t43AB49809F1D6B1439D437FD0EF3639BCC118A46_0_0_0 } /* GoogleMobileAds.iOS.RewardBasedVideoAdClient/GADURewardBasedVideoAdDidCompleteCallback */,
	{ DelegatePInvokeWrapper_GADURewardBasedVideoAdDidFailToReceiveAdWithErrorCallback_t5F82EB9B6F0AB22D402E0CC2A494949C780D2390, NULL, NULL, NULL, NULL, NULL, &GADURewardBasedVideoAdDidFailToReceiveAdWithErrorCallback_t5F82EB9B6F0AB22D402E0CC2A494949C780D2390_0_0_0 } /* GoogleMobileAds.iOS.RewardBasedVideoAdClient/GADURewardBasedVideoAdDidFailToReceiveAdWithErrorCallback */,
	{ DelegatePInvokeWrapper_GADURewardBasedVideoAdDidOpenCallback_tB06CAA1CE4826577744A13A26AC89A3B42FD1C34, NULL, NULL, NULL, NULL, NULL, &GADURewardBasedVideoAdDidOpenCallback_tB06CAA1CE4826577744A13A26AC89A3B42FD1C34_0_0_0 } /* GoogleMobileAds.iOS.RewardBasedVideoAdClient/GADURewardBasedVideoAdDidOpenCallback */,
	{ DelegatePInvokeWrapper_GADURewardBasedVideoAdDidReceiveAdCallback_t30E1E6C6EAD75C6D8A8A5782AEF818C774EC8966, NULL, NULL, NULL, NULL, NULL, &GADURewardBasedVideoAdDidReceiveAdCallback_t30E1E6C6EAD75C6D8A8A5782AEF818C774EC8966_0_0_0 } /* GoogleMobileAds.iOS.RewardBasedVideoAdClient/GADURewardBasedVideoAdDidReceiveAdCallback */,
	{ DelegatePInvokeWrapper_GADURewardBasedVideoAdDidRewardCallback_t779286F8D8719CD813D24794528D170B6CE6758B, NULL, NULL, NULL, NULL, NULL, &GADURewardBasedVideoAdDidRewardCallback_t779286F8D8719CD813D24794528D170B6CE6758B_0_0_0 } /* GoogleMobileAds.iOS.RewardBasedVideoAdClient/GADURewardBasedVideoAdDidRewardCallback */,
	{ DelegatePInvokeWrapper_GADURewardBasedVideoAdDidStartCallback_t47B2088607E2F7B610BFF96B02315DB970D3BE8A, NULL, NULL, NULL, NULL, NULL, &GADURewardBasedVideoAdDidStartCallback_t47B2088607E2F7B610BFF96B02315DB970D3BE8A_0_0_0 } /* GoogleMobileAds.iOS.RewardBasedVideoAdClient/GADURewardBasedVideoAdDidStartCallback */,
	{ DelegatePInvokeWrapper_GADURewardBasedVideoAdWillLeaveApplicationCallback_t0056DE714C24D44E29732E1C20F113CB30974404, NULL, NULL, NULL, NULL, NULL, &GADURewardBasedVideoAdWillLeaveApplicationCallback_t0056DE714C24D44E29732E1C20F113CB30974404_0_0_0 } /* GoogleMobileAds.iOS.RewardBasedVideoAdClient/GADURewardBasedVideoAdWillLeaveApplicationCallback */,
	{ DelegatePInvokeWrapper_GADURewardedAdDidCloseCallback_t506A5A3B01F7221AB06AC6E689610FDCE627BCAF, NULL, NULL, NULL, NULL, NULL, &GADURewardedAdDidCloseCallback_t506A5A3B01F7221AB06AC6E689610FDCE627BCAF_0_0_0 } /* GoogleMobileAds.iOS.RewardedAdClient/GADURewardedAdDidCloseCallback */,
	{ DelegatePInvokeWrapper_GADURewardedAdDidFailToReceiveAdWithErrorCallback_tCDA36987E2F970C589B4F9B0D153AF5EC883F9BE, NULL, NULL, NULL, NULL, NULL, &GADURewardedAdDidFailToReceiveAdWithErrorCallback_tCDA36987E2F970C589B4F9B0D153AF5EC883F9BE_0_0_0 } /* GoogleMobileAds.iOS.RewardedAdClient/GADURewardedAdDidFailToReceiveAdWithErrorCallback */,
	{ DelegatePInvokeWrapper_GADURewardedAdDidFailToShowAdWithErrorCallback_t7ECC0C4E4E19D517843B7F217597B1365D6B2BF8, NULL, NULL, NULL, NULL, NULL, &GADURewardedAdDidFailToShowAdWithErrorCallback_t7ECC0C4E4E19D517843B7F217597B1365D6B2BF8_0_0_0 } /* GoogleMobileAds.iOS.RewardedAdClient/GADURewardedAdDidFailToShowAdWithErrorCallback */,
	{ DelegatePInvokeWrapper_GADURewardedAdDidOpenCallback_t3C1F9C88CBDD1DDE862D771C31FBFDFD30BCBB9C, NULL, NULL, NULL, NULL, NULL, &GADURewardedAdDidOpenCallback_t3C1F9C88CBDD1DDE862D771C31FBFDFD30BCBB9C_0_0_0 } /* GoogleMobileAds.iOS.RewardedAdClient/GADURewardedAdDidOpenCallback */,
	{ DelegatePInvokeWrapper_GADURewardedAdDidReceiveAdCallback_t643161A4F15EE54392448B33D32F455E4F988E5A, NULL, NULL, NULL, NULL, NULL, &GADURewardedAdDidReceiveAdCallback_t643161A4F15EE54392448B33D32F455E4F988E5A_0_0_0 } /* GoogleMobileAds.iOS.RewardedAdClient/GADURewardedAdDidReceiveAdCallback */,
	{ DelegatePInvokeWrapper_GADUUserEarnedRewardCallback_tD3405735D8FA00F085D1F680CBA864C85F5CEC62, NULL, NULL, NULL, NULL, NULL, &GADUUserEarnedRewardCallback_tD3405735D8FA00F085D1F680CBA864C85F5CEC62_0_0_0 } /* GoogleMobileAds.iOS.RewardedAdClient/GADUUserEarnedRewardCallback */,
	{ NULL, IndexInfo_t75C3B4925D65E1980EC9978D31AFC9117378E06A_marshal_pinvoke, IndexInfo_t75C3B4925D65E1980EC9978D31AFC9117378E06A_marshal_pinvoke_back, IndexInfo_t75C3B4925D65E1980EC9978D31AFC9117378E06A_marshal_pinvoke_cleanup, NULL, NULL, &IndexInfo_t75C3B4925D65E1980EC9978D31AFC9117378E06A_0_0_0 } /* SQLite4Unity3d.SQLiteConnection/IndexInfo */,
	{ NULL, IndexedColumn_t7383ED01B7BE144DD5EE244105C11BA46C86AD99_marshal_pinvoke, IndexedColumn_t7383ED01B7BE144DD5EE244105C11BA46C86AD99_marshal_pinvoke_back, IndexedColumn_t7383ED01B7BE144DD5EE244105C11BA46C86AD99_marshal_pinvoke_cleanup, NULL, NULL, &IndexedColumn_t7383ED01B7BE144DD5EE244105C11BA46C86AD99_0_0_0 } /* SQLite4Unity3d.SQLiteConnection/IndexedColumn */,
	{ DelegatePInvokeWrapper_TimeExecutionHandler_t08BC9A715B49879CA2DE8B562C19D18E1AB656F1, NULL, NULL, NULL, NULL, NULL, &TimeExecutionHandler_t08BC9A715B49879CA2DE8B562C19D18E1AB656F1_0_0_0 } /* SQLite4Unity3d.SQLiteConnection/TimeExecutionHandler */,
	{ DelegatePInvokeWrapper_TraceHandler_tA80182197ED4D58961A46F9CA9D2D027FB5006A2, NULL, NULL, NULL, NULL, NULL, &TraceHandler_tA80182197ED4D58961A46F9CA9D2D027FB5006A2_0_0_0 } /* SQLite4Unity3d.SQLiteConnection/TraceHandler */,
	{ DelegatePInvokeWrapper_OnHide_t5A8285735A2689F2DC221FC307F1C6C091C1392F, NULL, NULL, NULL, NULL, NULL, &OnHide_t5A8285735A2689F2DC221FC307F1C6C091C1392F_0_0_0 } /* ShowAnimationUI/UIData/OnHide */,
	{ NULL, ReorderableListEventStruct_tC682CA0A096D5C473503F24E5EA5EF6DD40EBB2A_marshal_pinvoke, ReorderableListEventStruct_tC682CA0A096D5C473503F24E5EA5EF6DD40EBB2A_marshal_pinvoke_back, ReorderableListEventStruct_tC682CA0A096D5C473503F24E5EA5EF6DD40EBB2A_marshal_pinvoke_cleanup, NULL, NULL, &ReorderableListEventStruct_tC682CA0A096D5C473503F24E5EA5EF6DD40EBB2A_0_0_0 } /* UnityEngine.UI.Extensions.ReorderableList/ReorderableListEventStruct */,
	{ DelegatePInvokeWrapper_PageSnapChange_tD3924B00988BFBCA67B474FF7164B0F6A5C3DE29, NULL, NULL, NULL, NULL, NULL, &PageSnapChange_tD3924B00988BFBCA67B474FF7164B0F6A5C3DE29_0_0_0 } /* UnityEngine.UI.Extensions.ScrollSnap/PageSnapChange */,
	{ NULL, IconName_t2F8CB22FF220F36D0B91C6D837ACFC15FEAFB94A_marshal_pinvoke, IconName_t2F8CB22FF220F36D0B91C6D837ACFC15FEAFB94A_marshal_pinvoke_back, IconName_t2F8CB22FF220F36D0B91C6D837ACFC15FEAFB94A_marshal_pinvoke_cleanup, NULL, NULL, &IconName_t2F8CB22FF220F36D0B91C6D837ACFC15FEAFB94A_0_0_0 } /* UnityEngine.UI.Extensions.TextPic/IconName */,
	{ NULL, FloatTween_t5DC81A16395042EEFF03576EC81EF9D6F96E1201_marshal_pinvoke, FloatTween_t5DC81A16395042EEFF03576EC81EF9D6F96E1201_marshal_pinvoke_back, FloatTween_t5DC81A16395042EEFF03576EC81EF9D6F96E1201_marshal_pinvoke_cleanup, NULL, NULL, &FloatTween_t5DC81A16395042EEFF03576EC81EF9D6F96E1201_0_0_0 } /* UnityEngine.UI.Extensions.Tweens.FloatTween */,
	{ DelegatePInvokeWrapper_OnResponseDelegate_t5828875905266804DAF8CBA5F2770818AA5FEBDA, NULL, NULL, NULL, NULL, NULL, &OnResponseDelegate_t5828875905266804DAF8CBA5F2770818AA5FEBDA_0_0_0 } /* UnityImageLoader.Http.AbstractHttp/OnResponseDelegate */,
	{ NULL, NULL, NULL, NULL, NULL, &ZlibException_t2F0C2A9C169C9729EA1A649DD3A2D58AFA7F7028::CLSID, &ZlibException_t2F0C2A9C169C9729EA1A649DD3A2D58AFA7F7028_0_0_0 } /* BestHTTP.Decompression.Zlib.ZlibException */,
	NULL,
};
