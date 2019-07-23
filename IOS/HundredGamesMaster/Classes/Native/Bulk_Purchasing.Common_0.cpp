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
template <typename T1, typename T2, typename T3>
struct VirtActionInvoker3
{
	typedef void (*Action)(void*, T1, T2, T3, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2, T3 p3)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, invokeData.method);
	}
};
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
template <typename T1, typename T2, typename T3>
struct GenericVirtActionInvoker3
{
	typedef void (*Action)(void*, T1, T2, T3, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2, T3 p3)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_virtual_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, invokeData.method);
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
struct InterfaceActionInvoker0
{
	typedef void (*Action)(void*, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, invokeData.method);
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
template <typename T1, typename T2, typename T3>
struct InterfaceActionInvoker3
{
	typedef void (*Action)(void*, T1, T2, T3, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2, T3 p3)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, invokeData.method);
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
template <typename T1, typename T2, typename T3>
struct GenericInterfaceActionInvoker3
{
	typedef void (*Action)(void*, T1, T2, T3, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2, T3 p3)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_interface_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, invokeData.method);
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

// System.AsyncCallback
struct AsyncCallback_t3F3DA3BEDAEE81DD1D24125DF8EB30E85EE14DA4;
// System.Byte[]
struct ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821;
// System.Char[]
struct CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2;
// System.Collections.Generic.Dictionary`2/Entry<System.String,System.Object>[]
struct EntryU5BU5D_tED6676A6535375B72FAC3BE58CAB9DC30BE201CD;
// System.Collections.Generic.Dictionary`2/Entry<System.String,System.String>[]
struct EntryU5BU5D_t034347107F1D23C91DE1D712EA637D904789415C;
// System.Collections.Generic.Dictionary`2/KeyCollection<System.String,System.Object>
struct KeyCollection_t9BB02C59F6A73E760F875CCD8AA6D1A1ACE61970;
// System.Collections.Generic.Dictionary`2/KeyCollection<System.String,System.String>
struct KeyCollection_tC73654392B284B89334464107B696C9BD89776D9;
// System.Collections.Generic.Dictionary`2/ValueCollection<System.String,System.Object>
struct ValueCollection_t059E2E9F339047F683CA7038812E624189E7F0CD;
// System.Collections.Generic.Dictionary`2/ValueCollection<System.String,System.String>
struct ValueCollection_tA3B972EF56F7C97E35054155C33556C55FAAFD43;
// System.Collections.Generic.Dictionary`2<System.Int32,System.Globalization.CultureInfo>
struct Dictionary_2_tC88A56872F7C79DBB9582D4F3FC22ED5D8E0B98B;
// System.Collections.Generic.Dictionary`2<System.Object,System.Object>
struct Dictionary_2_t32F25F093828AA9F93CB11C2A2B4648FD62A09BA;
// System.Collections.Generic.Dictionary`2<System.String,System.Globalization.CultureInfo>
struct Dictionary_2_tBA5388DBB42BF620266F9A48E8B859BBBB224E25;
// System.Collections.Generic.Dictionary`2<System.String,System.Object>
struct Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA;
// System.Collections.Generic.Dictionary`2<System.String,System.String>
struct Dictionary_2_t931BF283048C4E74FC063C3036E5F3FE328861FC;
// System.Collections.Generic.IEqualityComparer`1<System.String>
struct IEqualityComparer_1_t1F07EAC22CC1D4F279164B144240E4718BD7E7A9;
// System.Collections.Generic.List`1<System.Object>
struct List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D;
// System.Collections.IDictionary
struct IDictionary_t1BD5C1546718A374EA8122FBD6C6EE45331E8CE7;
// System.Collections.IList
struct IList_tA637AB426E16F84F84ACC2813BDCF3A0414AF0AA;
// System.Delegate
struct Delegate_t;
// System.DelegateData
struct DelegateData_t1BF9F691B56DAE5F8C28C5E084FDE94F15F27BBE;
// System.Delegate[]
struct DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86;
// System.Func`2<System.Object,System.Int32>
struct Func_2_t8B2DA3FB30280CE3D92F50E9CCAACEE4828789A6;
// System.Func`2<System.Object,System.String>
struct Func_2_t44B347E67E515867D995E8BD5EFD67FA88CE53CF;
// System.Globalization.Calendar
struct Calendar_tF55A785ACD277504CF0D2F2C6AD56F76C6E91BD5;
// System.Globalization.CompareInfo
struct CompareInfo_tB9A071DBC11AC00AF2EA2066D0C2AE1DCB1865D1;
// System.Globalization.CultureData
struct CultureData_tF43B080FFA6EB278F4F289BCDA3FB74B6C208ECD;
// System.Globalization.CultureInfo
struct CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F;
// System.Globalization.DateTimeFormatInfo
struct DateTimeFormatInfo_tF4BB3AA482C2F772D2A9022F78BF8727830FAF5F;
// System.Globalization.NumberFormatInfo
struct NumberFormatInfo_tFDF57037EBC5BC833D0A53EF0327B805994860A8;
// System.Globalization.TextInfo
struct TextInfo_t5F1E697CB6A7E5EC80F0DC3A968B9B4A70C291D8;
// System.IAsyncResult
struct IAsyncResult_t8E194308510B375B42432981AE5E7488C458D598;
// System.IFormatProvider
struct IFormatProvider_t4247E13AE2D97A079B88D594B7ABABF313259901;
// System.IO.StringReader
struct StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12;
// System.IO.TextReader
struct TextReader_t7DF8314B601D202ECFEDF623093A87BFDAB58D0A;
// System.Int32[]
struct Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83;
// System.Object[]
struct ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A;
// System.Reflection.MethodInfo
struct MethodInfo_t;
// System.String
struct String_t;
// System.String[]
struct StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E;
// System.Text.StringBuilder
struct StringBuilder_t;
// System.UInt32[]
struct UInt32U5BU5D_t9AA834AF2940E75BBF8E3F08FF0D20D266DB71CB;
// System.Void
struct Void_t22962CB4C05B1D89B55A6E1139F0E87A90987017;
// UnityEngine.Purchasing.MiniJSON.Json/Parser
struct Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543;
// UnityEngine.Purchasing.MiniJSON.Json/Serializer
struct Serializer_t8E477D61E7D27FA878E7A6D57F4619E5C5B0611D;
// UnityEngine.Purchasing.UnityPurchasingCallback
struct UnityPurchasingCallback_tF3081DE4B67FBD9771C293C52885EC15C279810C;

extern RuntimeClass* Boolean_tB53F6830F670160873277339AA58F15CAED4399C_il2cpp_TypeInfo_var;
extern RuntimeClass* Byte_tF87C579059BD4633E6840EBBBEEF899C6E33EF07_il2cpp_TypeInfo_var;
extern RuntimeClass* CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2_il2cpp_TypeInfo_var;
extern RuntimeClass* Char_tBF22D9FC341BE970735250BB6FF1A4A92BBA58B9_il2cpp_TypeInfo_var;
extern RuntimeClass* Convert_t1C7A851BFB2F0782FD7F72F6AA1DCBB7B53A9C7E_il2cpp_TypeInfo_var;
extern RuntimeClass* CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_il2cpp_TypeInfo_var;
extern RuntimeClass* Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8_il2cpp_TypeInfo_var;
extern RuntimeClass* Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA_il2cpp_TypeInfo_var;
extern RuntimeClass* Double_t358B8F23BDC52A5DD700E727E204F9F7CDE12409_il2cpp_TypeInfo_var;
extern RuntimeClass* IDictionary_t1BD5C1546718A374EA8122FBD6C6EE45331E8CE7_il2cpp_TypeInfo_var;
extern RuntimeClass* IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var;
extern RuntimeClass* IEnumerable_tD74549CEA1AA48E768382B94FEACBB07E2E3FA2C_il2cpp_TypeInfo_var;
extern RuntimeClass* IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var;
extern RuntimeClass* IList_tA637AB426E16F84F84ACC2813BDCF3A0414AF0AA_il2cpp_TypeInfo_var;
extern RuntimeClass* Int16_t823A20635DAF5A3D93A1E01CFBF3CBA27CF00B4D_il2cpp_TypeInfo_var;
extern RuntimeClass* Int32_t585191389E07734F19F3156FF88FB3EF4800D102_il2cpp_TypeInfo_var;
extern RuntimeClass* Int64_t7A386C2FF7B0280A0F516992401DDFCF0FF7B436_il2cpp_TypeInfo_var;
extern RuntimeClass* List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D_il2cpp_TypeInfo_var;
extern RuntimeClass* Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543_il2cpp_TypeInfo_var;
extern RuntimeClass* SByte_t9070AEA2966184235653CB9B4D33B149CDA831DF_il2cpp_TypeInfo_var;
extern RuntimeClass* Serializer_t8E477D61E7D27FA878E7A6D57F4619E5C5B0611D_il2cpp_TypeInfo_var;
extern RuntimeClass* Single_tDDDA9169C4E4E308AC6D7A824F9B28DC82204AE1_il2cpp_TypeInfo_var;
extern RuntimeClass* StringBuilder_t_il2cpp_TypeInfo_var;
extern RuntimeClass* StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12_il2cpp_TypeInfo_var;
extern RuntimeClass* String_t_il2cpp_TypeInfo_var;
extern RuntimeClass* UInt16_tAE45CEF73BF720100519F6867F32145D075F928E_il2cpp_TypeInfo_var;
extern RuntimeClass* UInt32_t4980FA09003AFAAB5A6E361BA2748EA9A005709B_il2cpp_TypeInfo_var;
extern RuntimeClass* UInt64_tA02DF3B59C8FC4A849BD207DA11038CC64E4CB4E_il2cpp_TypeInfo_var;
extern String_t* _stringLiteral06576556D1AD802F247CAD11AE748BE47B70CD9C;
extern String_t* _stringLiteral153809851B33CE0CDCE06E5A572C675E18D0C3B5;
extern String_t* _stringLiteral21AE27F947EF77236FD5E0029FDFE3E0913B464B;
extern String_t* _stringLiteral2BE88CA4242C76E8253AC62474851065032D6833;
extern String_t* _stringLiteral2BFBE0BC53277529025720589E902C25BF01F2F4;
extern String_t* _stringLiteral4629CA1B60E263BDC4326334B23323E0434717A5;
extern String_t* _stringLiteral5FFE533B830F08A0326348A9160AFAFC8ADA44DB;
extern String_t* _stringLiteral794A729D2E4FFBB094FEC03AE9B3ACD219371385;
extern String_t* _stringLiteral7CB6EFB98BA5972A9B5090DC2E517FE14D12CB04;
extern String_t* _stringLiteral8BF81043E29DFC96A6FE1F30F7116F552DE6E7D7;
extern String_t* _stringLiteral9E94758983980504AF303EF297FD2BF9D9CEA063;
extern String_t* _stringLiteralAB006BB8AACDF6E68299BC1DFFCCC9BCC8AC3EAF;
extern String_t* _stringLiteralEF7E6794CA9C6A06B54B66F279237FB8DAAAEEA8;
extern String_t* _stringLiteralF12C84902108895980702C88DB900CEEA2D2EC01;
extern const RuntimeMethod* Dictionary_2_ContainsKey_mAD4B2095526B4742201B24C5ADF1717AFB15EF89_RuntimeMethod_var;
extern const RuntimeMethod* Dictionary_2__ctor_mCA7075EA6548A18B929368520217975094841997_RuntimeMethod_var;
extern const RuntimeMethod* Dictionary_2_get_Item_mB490F7029D7451FAF06E3020040E604B500BA3B2_RuntimeMethod_var;
extern const RuntimeMethod* Dictionary_2_set_Item_mEA41AEAE79570A9410777F6B90969532564025DD_RuntimeMethod_var;
extern const RuntimeMethod* List_1_Add_m6930161974C7504C80F52EC379EF012387D43138_RuntimeMethod_var;
extern const RuntimeMethod* List_1__ctor_mC832F1AC0F814BAEB19175F5D7972A7507508BC3_RuntimeMethod_var;
extern const uint32_t MiniJsonExtensions_GetString_mB42DECB2528309B3A49269120548258B3E0B6142_MetadataUsageId;
extern const uint32_t MiniJsonExtensions_HashtableFromJson_m924DE4EC163F926FCAC0ACB6890D9865E1A3D0D9_MetadataUsageId;
extern const uint32_t Parser_EatWhitespace_m8A09F4A69DD67898D517E9772A47500CF798548F_MetadataUsageId;
extern const uint32_t Parser_IsWordBreak_m395241B2FB531CE679C9BBDE1784EA50D937D210_MetadataUsageId;
extern const uint32_t Parser_ParseArray_m12FC39460D64ACE1AE58275BCEA66644DD28BBF2_MetadataUsageId;
extern const uint32_t Parser_ParseByToken_mF99905D919F1D2A54466793D3D938043E10AE5BA_MetadataUsageId;
extern const uint32_t Parser_ParseNumber_m244426CB90761E4326DD8678646DE2715929077F_MetadataUsageId;
extern const uint32_t Parser_ParseObject_m5A34882277CE52DF62AB0CA09CEA3005716398FF_MetadataUsageId;
extern const uint32_t Parser_ParseString_mB6994A848988FDCE117674ABC2F085E460B12635_MetadataUsageId;
extern const uint32_t Parser_Parse_mFDB5642E0F39901529C00E41650C0E40384996C5_MetadataUsageId;
extern const uint32_t Parser__ctor_m3D3193C5644C380E18422E83B0F0E3F8E7D78E70_MetadataUsageId;
extern const uint32_t Parser_get_NextChar_mB16EDBEAEFDF5B7AB13A22E5420B9BAF3FB8B4B2_MetadataUsageId;
extern const uint32_t Parser_get_NextToken_m0B0637C375655D15C6D9C4BDEDF2A2A9E6DA69CE_MetadataUsageId;
extern const uint32_t Parser_get_NextWord_m6D4BE7C1F45368E40593F0F712B80DD40D1E9034_MetadataUsageId;
extern const uint32_t Parser_get_PeekChar_mC4F636B592D572D313318820C35D3B8A70661931_MetadataUsageId;
extern const uint32_t Serializer_SerializeArray_mA4DB26A2353A1FE3838E765DB7A6F6B4E4460ECC_MetadataUsageId;
extern const uint32_t Serializer_SerializeObject_mFF26F5476F7F35A992B893E7A19717B972018A83_MetadataUsageId;
extern const uint32_t Serializer_SerializeOther_m39DC0396BC829EDA0A4086E711BCF48BFDF79351_MetadataUsageId;
extern const uint32_t Serializer_SerializeString_m71208E9D67CAB89BF60CE2CAA22264221B8110EE_MetadataUsageId;
extern const uint32_t Serializer_SerializeValue_mDA3C31227389EF6116A3D5490FDAB12CE3AC28DC_MetadataUsageId;
extern const uint32_t Serializer_Serialize_m3ADBCAEE90D7C194CF45992E4B8C6D25557A3809_MetadataUsageId;
extern const uint32_t Serializer__ctor_m5596317D8D472AE91B9CC27CAF9241149191B796_MetadataUsageId;
struct CultureData_tF43B080FFA6EB278F4F289BCDA3FB74B6C208ECD_marshaled_com;
struct CultureData_tF43B080FFA6EB278F4F289BCDA3FB74B6C208ECD_marshaled_pinvoke;
struct CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_marshaled_com;
struct CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_marshaled_pinvoke;
struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;

struct CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2;
struct DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86;


#ifndef U3CMODULEU3E_T032354C4F637C16A7A2B5EA55E751506F0124745_H
#define U3CMODULEU3E_T032354C4F637C16A7A2B5EA55E751506F0124745_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct  U3CModuleU3E_t032354C4F637C16A7A2B5EA55E751506F0124745 
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // U3CMODULEU3E_T032354C4F637C16A7A2B5EA55E751506F0124745_H
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
#ifndef DICTIONARY_2_T9140A71329927AE4FD0F3CF4D4D66668EBE151EA_H
#define DICTIONARY_2_T9140A71329927AE4FD0F3CF4D4D66668EBE151EA_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.Dictionary`2<System.String,System.Object>
struct  Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA  : public RuntimeObject
{
public:
	// System.Int32[] System.Collections.Generic.Dictionary`2::buckets
	Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* ___buckets_0;
	// System.Collections.Generic.Dictionary`2_Entry<TKey,TValue>[] System.Collections.Generic.Dictionary`2::entries
	EntryU5BU5D_tED6676A6535375B72FAC3BE58CAB9DC30BE201CD* ___entries_1;
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
	KeyCollection_t9BB02C59F6A73E760F875CCD8AA6D1A1ACE61970 * ___keys_7;
	// System.Collections.Generic.Dictionary`2_ValueCollection<TKey,TValue> System.Collections.Generic.Dictionary`2::values
	ValueCollection_t059E2E9F339047F683CA7038812E624189E7F0CD * ___values_8;
	// System.Object System.Collections.Generic.Dictionary`2::_syncRoot
	RuntimeObject * ____syncRoot_9;

public:
	inline static int32_t get_offset_of_buckets_0() { return static_cast<int32_t>(offsetof(Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA, ___buckets_0)); }
	inline Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* get_buckets_0() const { return ___buckets_0; }
	inline Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83** get_address_of_buckets_0() { return &___buckets_0; }
	inline void set_buckets_0(Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* value)
	{
		___buckets_0 = value;
		Il2CppCodeGenWriteBarrier((&___buckets_0), value);
	}

	inline static int32_t get_offset_of_entries_1() { return static_cast<int32_t>(offsetof(Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA, ___entries_1)); }
	inline EntryU5BU5D_tED6676A6535375B72FAC3BE58CAB9DC30BE201CD* get_entries_1() const { return ___entries_1; }
	inline EntryU5BU5D_tED6676A6535375B72FAC3BE58CAB9DC30BE201CD** get_address_of_entries_1() { return &___entries_1; }
	inline void set_entries_1(EntryU5BU5D_tED6676A6535375B72FAC3BE58CAB9DC30BE201CD* value)
	{
		___entries_1 = value;
		Il2CppCodeGenWriteBarrier((&___entries_1), value);
	}

	inline static int32_t get_offset_of_count_2() { return static_cast<int32_t>(offsetof(Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA, ___count_2)); }
	inline int32_t get_count_2() const { return ___count_2; }
	inline int32_t* get_address_of_count_2() { return &___count_2; }
	inline void set_count_2(int32_t value)
	{
		___count_2 = value;
	}

	inline static int32_t get_offset_of_version_3() { return static_cast<int32_t>(offsetof(Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA, ___version_3)); }
	inline int32_t get_version_3() const { return ___version_3; }
	inline int32_t* get_address_of_version_3() { return &___version_3; }
	inline void set_version_3(int32_t value)
	{
		___version_3 = value;
	}

	inline static int32_t get_offset_of_freeList_4() { return static_cast<int32_t>(offsetof(Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA, ___freeList_4)); }
	inline int32_t get_freeList_4() const { return ___freeList_4; }
	inline int32_t* get_address_of_freeList_4() { return &___freeList_4; }
	inline void set_freeList_4(int32_t value)
	{
		___freeList_4 = value;
	}

	inline static int32_t get_offset_of_freeCount_5() { return static_cast<int32_t>(offsetof(Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA, ___freeCount_5)); }
	inline int32_t get_freeCount_5() const { return ___freeCount_5; }
	inline int32_t* get_address_of_freeCount_5() { return &___freeCount_5; }
	inline void set_freeCount_5(int32_t value)
	{
		___freeCount_5 = value;
	}

	inline static int32_t get_offset_of_comparer_6() { return static_cast<int32_t>(offsetof(Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA, ___comparer_6)); }
	inline RuntimeObject* get_comparer_6() const { return ___comparer_6; }
	inline RuntimeObject** get_address_of_comparer_6() { return &___comparer_6; }
	inline void set_comparer_6(RuntimeObject* value)
	{
		___comparer_6 = value;
		Il2CppCodeGenWriteBarrier((&___comparer_6), value);
	}

	inline static int32_t get_offset_of_keys_7() { return static_cast<int32_t>(offsetof(Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA, ___keys_7)); }
	inline KeyCollection_t9BB02C59F6A73E760F875CCD8AA6D1A1ACE61970 * get_keys_7() const { return ___keys_7; }
	inline KeyCollection_t9BB02C59F6A73E760F875CCD8AA6D1A1ACE61970 ** get_address_of_keys_7() { return &___keys_7; }
	inline void set_keys_7(KeyCollection_t9BB02C59F6A73E760F875CCD8AA6D1A1ACE61970 * value)
	{
		___keys_7 = value;
		Il2CppCodeGenWriteBarrier((&___keys_7), value);
	}

	inline static int32_t get_offset_of_values_8() { return static_cast<int32_t>(offsetof(Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA, ___values_8)); }
	inline ValueCollection_t059E2E9F339047F683CA7038812E624189E7F0CD * get_values_8() const { return ___values_8; }
	inline ValueCollection_t059E2E9F339047F683CA7038812E624189E7F0CD ** get_address_of_values_8() { return &___values_8; }
	inline void set_values_8(ValueCollection_t059E2E9F339047F683CA7038812E624189E7F0CD * value)
	{
		___values_8 = value;
		Il2CppCodeGenWriteBarrier((&___values_8), value);
	}

	inline static int32_t get_offset_of__syncRoot_9() { return static_cast<int32_t>(offsetof(Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA, ____syncRoot_9)); }
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
#endif // DICTIONARY_2_T9140A71329927AE4FD0F3CF4D4D66668EBE151EA_H
#ifndef DICTIONARY_2_T931BF283048C4E74FC063C3036E5F3FE328861FC_H
#define DICTIONARY_2_T931BF283048C4E74FC063C3036E5F3FE328861FC_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.Dictionary`2<System.String,System.String>
struct  Dictionary_2_t931BF283048C4E74FC063C3036E5F3FE328861FC  : public RuntimeObject
{
public:
	// System.Int32[] System.Collections.Generic.Dictionary`2::buckets
	Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* ___buckets_0;
	// System.Collections.Generic.Dictionary`2_Entry<TKey,TValue>[] System.Collections.Generic.Dictionary`2::entries
	EntryU5BU5D_t034347107F1D23C91DE1D712EA637D904789415C* ___entries_1;
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
	KeyCollection_tC73654392B284B89334464107B696C9BD89776D9 * ___keys_7;
	// System.Collections.Generic.Dictionary`2_ValueCollection<TKey,TValue> System.Collections.Generic.Dictionary`2::values
	ValueCollection_tA3B972EF56F7C97E35054155C33556C55FAAFD43 * ___values_8;
	// System.Object System.Collections.Generic.Dictionary`2::_syncRoot
	RuntimeObject * ____syncRoot_9;

public:
	inline static int32_t get_offset_of_buckets_0() { return static_cast<int32_t>(offsetof(Dictionary_2_t931BF283048C4E74FC063C3036E5F3FE328861FC, ___buckets_0)); }
	inline Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* get_buckets_0() const { return ___buckets_0; }
	inline Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83** get_address_of_buckets_0() { return &___buckets_0; }
	inline void set_buckets_0(Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* value)
	{
		___buckets_0 = value;
		Il2CppCodeGenWriteBarrier((&___buckets_0), value);
	}

	inline static int32_t get_offset_of_entries_1() { return static_cast<int32_t>(offsetof(Dictionary_2_t931BF283048C4E74FC063C3036E5F3FE328861FC, ___entries_1)); }
	inline EntryU5BU5D_t034347107F1D23C91DE1D712EA637D904789415C* get_entries_1() const { return ___entries_1; }
	inline EntryU5BU5D_t034347107F1D23C91DE1D712EA637D904789415C** get_address_of_entries_1() { return &___entries_1; }
	inline void set_entries_1(EntryU5BU5D_t034347107F1D23C91DE1D712EA637D904789415C* value)
	{
		___entries_1 = value;
		Il2CppCodeGenWriteBarrier((&___entries_1), value);
	}

	inline static int32_t get_offset_of_count_2() { return static_cast<int32_t>(offsetof(Dictionary_2_t931BF283048C4E74FC063C3036E5F3FE328861FC, ___count_2)); }
	inline int32_t get_count_2() const { return ___count_2; }
	inline int32_t* get_address_of_count_2() { return &___count_2; }
	inline void set_count_2(int32_t value)
	{
		___count_2 = value;
	}

	inline static int32_t get_offset_of_version_3() { return static_cast<int32_t>(offsetof(Dictionary_2_t931BF283048C4E74FC063C3036E5F3FE328861FC, ___version_3)); }
	inline int32_t get_version_3() const { return ___version_3; }
	inline int32_t* get_address_of_version_3() { return &___version_3; }
	inline void set_version_3(int32_t value)
	{
		___version_3 = value;
	}

	inline static int32_t get_offset_of_freeList_4() { return static_cast<int32_t>(offsetof(Dictionary_2_t931BF283048C4E74FC063C3036E5F3FE328861FC, ___freeList_4)); }
	inline int32_t get_freeList_4() const { return ___freeList_4; }
	inline int32_t* get_address_of_freeList_4() { return &___freeList_4; }
	inline void set_freeList_4(int32_t value)
	{
		___freeList_4 = value;
	}

	inline static int32_t get_offset_of_freeCount_5() { return static_cast<int32_t>(offsetof(Dictionary_2_t931BF283048C4E74FC063C3036E5F3FE328861FC, ___freeCount_5)); }
	inline int32_t get_freeCount_5() const { return ___freeCount_5; }
	inline int32_t* get_address_of_freeCount_5() { return &___freeCount_5; }
	inline void set_freeCount_5(int32_t value)
	{
		___freeCount_5 = value;
	}

	inline static int32_t get_offset_of_comparer_6() { return static_cast<int32_t>(offsetof(Dictionary_2_t931BF283048C4E74FC063C3036E5F3FE328861FC, ___comparer_6)); }
	inline RuntimeObject* get_comparer_6() const { return ___comparer_6; }
	inline RuntimeObject** get_address_of_comparer_6() { return &___comparer_6; }
	inline void set_comparer_6(RuntimeObject* value)
	{
		___comparer_6 = value;
		Il2CppCodeGenWriteBarrier((&___comparer_6), value);
	}

	inline static int32_t get_offset_of_keys_7() { return static_cast<int32_t>(offsetof(Dictionary_2_t931BF283048C4E74FC063C3036E5F3FE328861FC, ___keys_7)); }
	inline KeyCollection_tC73654392B284B89334464107B696C9BD89776D9 * get_keys_7() const { return ___keys_7; }
	inline KeyCollection_tC73654392B284B89334464107B696C9BD89776D9 ** get_address_of_keys_7() { return &___keys_7; }
	inline void set_keys_7(KeyCollection_tC73654392B284B89334464107B696C9BD89776D9 * value)
	{
		___keys_7 = value;
		Il2CppCodeGenWriteBarrier((&___keys_7), value);
	}

	inline static int32_t get_offset_of_values_8() { return static_cast<int32_t>(offsetof(Dictionary_2_t931BF283048C4E74FC063C3036E5F3FE328861FC, ___values_8)); }
	inline ValueCollection_tA3B972EF56F7C97E35054155C33556C55FAAFD43 * get_values_8() const { return ___values_8; }
	inline ValueCollection_tA3B972EF56F7C97E35054155C33556C55FAAFD43 ** get_address_of_values_8() { return &___values_8; }
	inline void set_values_8(ValueCollection_tA3B972EF56F7C97E35054155C33556C55FAAFD43 * value)
	{
		___values_8 = value;
		Il2CppCodeGenWriteBarrier((&___values_8), value);
	}

	inline static int32_t get_offset_of__syncRoot_9() { return static_cast<int32_t>(offsetof(Dictionary_2_t931BF283048C4E74FC063C3036E5F3FE328861FC, ____syncRoot_9)); }
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
#endif // DICTIONARY_2_T931BF283048C4E74FC063C3036E5F3FE328861FC_H
#ifndef LIST_1_T05CC3C859AB5E6024394EF9A42E3E696628CA02D_H
#define LIST_1_T05CC3C859AB5E6024394EF9A42E3E696628CA02D_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.List`1<System.Object>
struct  List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject * ____syncRoot_4;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D, ____items_1)); }
	inline ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* get__items_1() const { return ____items_1; }
	inline ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((&____items_1), value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}

	inline static int32_t get_offset_of__syncRoot_4() { return static_cast<int32_t>(offsetof(List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D, ____syncRoot_4)); }
	inline RuntimeObject * get__syncRoot_4() const { return ____syncRoot_4; }
	inline RuntimeObject ** get_address_of__syncRoot_4() { return &____syncRoot_4; }
	inline void set__syncRoot_4(RuntimeObject * value)
	{
		____syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier((&____syncRoot_4), value);
	}
};

struct List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::_emptyArray
	ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* ____emptyArray_5;

public:
	inline static int32_t get_offset_of__emptyArray_5() { return static_cast<int32_t>(offsetof(List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D_StaticFields, ____emptyArray_5)); }
	inline ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* get__emptyArray_5() const { return ____emptyArray_5; }
	inline ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A** get_address_of__emptyArray_5() { return &____emptyArray_5; }
	inline void set__emptyArray_5(ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* value)
	{
		____emptyArray_5 = value;
		Il2CppCodeGenWriteBarrier((&____emptyArray_5), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LIST_1_T05CC3C859AB5E6024394EF9A42E3E696628CA02D_H
#ifndef CULTUREINFO_T345AC6924134F039ED9A11F3E03F8E91B6A3225F_H
#define CULTUREINFO_T345AC6924134F039ED9A11F3E03F8E91B6A3225F_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Globalization.CultureInfo
struct  CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F  : public RuntimeObject
{
public:
	// System.Boolean System.Globalization.CultureInfo::m_isReadOnly
	bool ___m_isReadOnly_3;
	// System.Int32 System.Globalization.CultureInfo::cultureID
	int32_t ___cultureID_4;
	// System.Int32 System.Globalization.CultureInfo::parent_lcid
	int32_t ___parent_lcid_5;
	// System.Int32 System.Globalization.CultureInfo::datetime_index
	int32_t ___datetime_index_6;
	// System.Int32 System.Globalization.CultureInfo::number_index
	int32_t ___number_index_7;
	// System.Int32 System.Globalization.CultureInfo::default_calendar_type
	int32_t ___default_calendar_type_8;
	// System.Boolean System.Globalization.CultureInfo::m_useUserOverride
	bool ___m_useUserOverride_9;
	// System.Globalization.NumberFormatInfo modreq(System.Runtime.CompilerServices.IsVolatile) System.Globalization.CultureInfo::numInfo
	NumberFormatInfo_tFDF57037EBC5BC833D0A53EF0327B805994860A8 * ___numInfo_10;
	// System.Globalization.DateTimeFormatInfo modreq(System.Runtime.CompilerServices.IsVolatile) System.Globalization.CultureInfo::dateTimeInfo
	DateTimeFormatInfo_tF4BB3AA482C2F772D2A9022F78BF8727830FAF5F * ___dateTimeInfo_11;
	// System.Globalization.TextInfo modreq(System.Runtime.CompilerServices.IsVolatile) System.Globalization.CultureInfo::textInfo
	TextInfo_t5F1E697CB6A7E5EC80F0DC3A968B9B4A70C291D8 * ___textInfo_12;
	// System.String System.Globalization.CultureInfo::m_name
	String_t* ___m_name_13;
	// System.String System.Globalization.CultureInfo::englishname
	String_t* ___englishname_14;
	// System.String System.Globalization.CultureInfo::nativename
	String_t* ___nativename_15;
	// System.String System.Globalization.CultureInfo::iso3lang
	String_t* ___iso3lang_16;
	// System.String System.Globalization.CultureInfo::iso2lang
	String_t* ___iso2lang_17;
	// System.String System.Globalization.CultureInfo::win3lang
	String_t* ___win3lang_18;
	// System.String System.Globalization.CultureInfo::territory
	String_t* ___territory_19;
	// System.String[] System.Globalization.CultureInfo::native_calendar_names
	StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* ___native_calendar_names_20;
	// System.Globalization.CompareInfo modreq(System.Runtime.CompilerServices.IsVolatile) System.Globalization.CultureInfo::compareInfo
	CompareInfo_tB9A071DBC11AC00AF2EA2066D0C2AE1DCB1865D1 * ___compareInfo_21;
	// System.Void* System.Globalization.CultureInfo::textinfo_data
	void* ___textinfo_data_22;
	// System.Int32 System.Globalization.CultureInfo::m_dataItem
	int32_t ___m_dataItem_23;
	// System.Globalization.Calendar System.Globalization.CultureInfo::calendar
	Calendar_tF55A785ACD277504CF0D2F2C6AD56F76C6E91BD5 * ___calendar_24;
	// System.Globalization.CultureInfo System.Globalization.CultureInfo::parent_culture
	CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * ___parent_culture_25;
	// System.Boolean System.Globalization.CultureInfo::constructed
	bool ___constructed_26;
	// System.Byte[] System.Globalization.CultureInfo::cached_serialized_form
	ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___cached_serialized_form_27;
	// System.Globalization.CultureData System.Globalization.CultureInfo::m_cultureData
	CultureData_tF43B080FFA6EB278F4F289BCDA3FB74B6C208ECD * ___m_cultureData_28;
	// System.Boolean System.Globalization.CultureInfo::m_isInherited
	bool ___m_isInherited_29;

public:
	inline static int32_t get_offset_of_m_isReadOnly_3() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F, ___m_isReadOnly_3)); }
	inline bool get_m_isReadOnly_3() const { return ___m_isReadOnly_3; }
	inline bool* get_address_of_m_isReadOnly_3() { return &___m_isReadOnly_3; }
	inline void set_m_isReadOnly_3(bool value)
	{
		___m_isReadOnly_3 = value;
	}

	inline static int32_t get_offset_of_cultureID_4() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F, ___cultureID_4)); }
	inline int32_t get_cultureID_4() const { return ___cultureID_4; }
	inline int32_t* get_address_of_cultureID_4() { return &___cultureID_4; }
	inline void set_cultureID_4(int32_t value)
	{
		___cultureID_4 = value;
	}

	inline static int32_t get_offset_of_parent_lcid_5() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F, ___parent_lcid_5)); }
	inline int32_t get_parent_lcid_5() const { return ___parent_lcid_5; }
	inline int32_t* get_address_of_parent_lcid_5() { return &___parent_lcid_5; }
	inline void set_parent_lcid_5(int32_t value)
	{
		___parent_lcid_5 = value;
	}

	inline static int32_t get_offset_of_datetime_index_6() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F, ___datetime_index_6)); }
	inline int32_t get_datetime_index_6() const { return ___datetime_index_6; }
	inline int32_t* get_address_of_datetime_index_6() { return &___datetime_index_6; }
	inline void set_datetime_index_6(int32_t value)
	{
		___datetime_index_6 = value;
	}

	inline static int32_t get_offset_of_number_index_7() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F, ___number_index_7)); }
	inline int32_t get_number_index_7() const { return ___number_index_7; }
	inline int32_t* get_address_of_number_index_7() { return &___number_index_7; }
	inline void set_number_index_7(int32_t value)
	{
		___number_index_7 = value;
	}

	inline static int32_t get_offset_of_default_calendar_type_8() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F, ___default_calendar_type_8)); }
	inline int32_t get_default_calendar_type_8() const { return ___default_calendar_type_8; }
	inline int32_t* get_address_of_default_calendar_type_8() { return &___default_calendar_type_8; }
	inline void set_default_calendar_type_8(int32_t value)
	{
		___default_calendar_type_8 = value;
	}

	inline static int32_t get_offset_of_m_useUserOverride_9() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F, ___m_useUserOverride_9)); }
	inline bool get_m_useUserOverride_9() const { return ___m_useUserOverride_9; }
	inline bool* get_address_of_m_useUserOverride_9() { return &___m_useUserOverride_9; }
	inline void set_m_useUserOverride_9(bool value)
	{
		___m_useUserOverride_9 = value;
	}

	inline static int32_t get_offset_of_numInfo_10() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F, ___numInfo_10)); }
	inline NumberFormatInfo_tFDF57037EBC5BC833D0A53EF0327B805994860A8 * get_numInfo_10() const { return ___numInfo_10; }
	inline NumberFormatInfo_tFDF57037EBC5BC833D0A53EF0327B805994860A8 ** get_address_of_numInfo_10() { return &___numInfo_10; }
	inline void set_numInfo_10(NumberFormatInfo_tFDF57037EBC5BC833D0A53EF0327B805994860A8 * value)
	{
		___numInfo_10 = value;
		Il2CppCodeGenWriteBarrier((&___numInfo_10), value);
	}

	inline static int32_t get_offset_of_dateTimeInfo_11() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F, ___dateTimeInfo_11)); }
	inline DateTimeFormatInfo_tF4BB3AA482C2F772D2A9022F78BF8727830FAF5F * get_dateTimeInfo_11() const { return ___dateTimeInfo_11; }
	inline DateTimeFormatInfo_tF4BB3AA482C2F772D2A9022F78BF8727830FAF5F ** get_address_of_dateTimeInfo_11() { return &___dateTimeInfo_11; }
	inline void set_dateTimeInfo_11(DateTimeFormatInfo_tF4BB3AA482C2F772D2A9022F78BF8727830FAF5F * value)
	{
		___dateTimeInfo_11 = value;
		Il2CppCodeGenWriteBarrier((&___dateTimeInfo_11), value);
	}

	inline static int32_t get_offset_of_textInfo_12() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F, ___textInfo_12)); }
	inline TextInfo_t5F1E697CB6A7E5EC80F0DC3A968B9B4A70C291D8 * get_textInfo_12() const { return ___textInfo_12; }
	inline TextInfo_t5F1E697CB6A7E5EC80F0DC3A968B9B4A70C291D8 ** get_address_of_textInfo_12() { return &___textInfo_12; }
	inline void set_textInfo_12(TextInfo_t5F1E697CB6A7E5EC80F0DC3A968B9B4A70C291D8 * value)
	{
		___textInfo_12 = value;
		Il2CppCodeGenWriteBarrier((&___textInfo_12), value);
	}

	inline static int32_t get_offset_of_m_name_13() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F, ___m_name_13)); }
	inline String_t* get_m_name_13() const { return ___m_name_13; }
	inline String_t** get_address_of_m_name_13() { return &___m_name_13; }
	inline void set_m_name_13(String_t* value)
	{
		___m_name_13 = value;
		Il2CppCodeGenWriteBarrier((&___m_name_13), value);
	}

	inline static int32_t get_offset_of_englishname_14() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F, ___englishname_14)); }
	inline String_t* get_englishname_14() const { return ___englishname_14; }
	inline String_t** get_address_of_englishname_14() { return &___englishname_14; }
	inline void set_englishname_14(String_t* value)
	{
		___englishname_14 = value;
		Il2CppCodeGenWriteBarrier((&___englishname_14), value);
	}

	inline static int32_t get_offset_of_nativename_15() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F, ___nativename_15)); }
	inline String_t* get_nativename_15() const { return ___nativename_15; }
	inline String_t** get_address_of_nativename_15() { return &___nativename_15; }
	inline void set_nativename_15(String_t* value)
	{
		___nativename_15 = value;
		Il2CppCodeGenWriteBarrier((&___nativename_15), value);
	}

	inline static int32_t get_offset_of_iso3lang_16() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F, ___iso3lang_16)); }
	inline String_t* get_iso3lang_16() const { return ___iso3lang_16; }
	inline String_t** get_address_of_iso3lang_16() { return &___iso3lang_16; }
	inline void set_iso3lang_16(String_t* value)
	{
		___iso3lang_16 = value;
		Il2CppCodeGenWriteBarrier((&___iso3lang_16), value);
	}

	inline static int32_t get_offset_of_iso2lang_17() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F, ___iso2lang_17)); }
	inline String_t* get_iso2lang_17() const { return ___iso2lang_17; }
	inline String_t** get_address_of_iso2lang_17() { return &___iso2lang_17; }
	inline void set_iso2lang_17(String_t* value)
	{
		___iso2lang_17 = value;
		Il2CppCodeGenWriteBarrier((&___iso2lang_17), value);
	}

	inline static int32_t get_offset_of_win3lang_18() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F, ___win3lang_18)); }
	inline String_t* get_win3lang_18() const { return ___win3lang_18; }
	inline String_t** get_address_of_win3lang_18() { return &___win3lang_18; }
	inline void set_win3lang_18(String_t* value)
	{
		___win3lang_18 = value;
		Il2CppCodeGenWriteBarrier((&___win3lang_18), value);
	}

	inline static int32_t get_offset_of_territory_19() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F, ___territory_19)); }
	inline String_t* get_territory_19() const { return ___territory_19; }
	inline String_t** get_address_of_territory_19() { return &___territory_19; }
	inline void set_territory_19(String_t* value)
	{
		___territory_19 = value;
		Il2CppCodeGenWriteBarrier((&___territory_19), value);
	}

	inline static int32_t get_offset_of_native_calendar_names_20() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F, ___native_calendar_names_20)); }
	inline StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* get_native_calendar_names_20() const { return ___native_calendar_names_20; }
	inline StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E** get_address_of_native_calendar_names_20() { return &___native_calendar_names_20; }
	inline void set_native_calendar_names_20(StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* value)
	{
		___native_calendar_names_20 = value;
		Il2CppCodeGenWriteBarrier((&___native_calendar_names_20), value);
	}

	inline static int32_t get_offset_of_compareInfo_21() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F, ___compareInfo_21)); }
	inline CompareInfo_tB9A071DBC11AC00AF2EA2066D0C2AE1DCB1865D1 * get_compareInfo_21() const { return ___compareInfo_21; }
	inline CompareInfo_tB9A071DBC11AC00AF2EA2066D0C2AE1DCB1865D1 ** get_address_of_compareInfo_21() { return &___compareInfo_21; }
	inline void set_compareInfo_21(CompareInfo_tB9A071DBC11AC00AF2EA2066D0C2AE1DCB1865D1 * value)
	{
		___compareInfo_21 = value;
		Il2CppCodeGenWriteBarrier((&___compareInfo_21), value);
	}

	inline static int32_t get_offset_of_textinfo_data_22() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F, ___textinfo_data_22)); }
	inline void* get_textinfo_data_22() const { return ___textinfo_data_22; }
	inline void** get_address_of_textinfo_data_22() { return &___textinfo_data_22; }
	inline void set_textinfo_data_22(void* value)
	{
		___textinfo_data_22 = value;
	}

	inline static int32_t get_offset_of_m_dataItem_23() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F, ___m_dataItem_23)); }
	inline int32_t get_m_dataItem_23() const { return ___m_dataItem_23; }
	inline int32_t* get_address_of_m_dataItem_23() { return &___m_dataItem_23; }
	inline void set_m_dataItem_23(int32_t value)
	{
		___m_dataItem_23 = value;
	}

	inline static int32_t get_offset_of_calendar_24() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F, ___calendar_24)); }
	inline Calendar_tF55A785ACD277504CF0D2F2C6AD56F76C6E91BD5 * get_calendar_24() const { return ___calendar_24; }
	inline Calendar_tF55A785ACD277504CF0D2F2C6AD56F76C6E91BD5 ** get_address_of_calendar_24() { return &___calendar_24; }
	inline void set_calendar_24(Calendar_tF55A785ACD277504CF0D2F2C6AD56F76C6E91BD5 * value)
	{
		___calendar_24 = value;
		Il2CppCodeGenWriteBarrier((&___calendar_24), value);
	}

	inline static int32_t get_offset_of_parent_culture_25() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F, ___parent_culture_25)); }
	inline CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * get_parent_culture_25() const { return ___parent_culture_25; }
	inline CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F ** get_address_of_parent_culture_25() { return &___parent_culture_25; }
	inline void set_parent_culture_25(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * value)
	{
		___parent_culture_25 = value;
		Il2CppCodeGenWriteBarrier((&___parent_culture_25), value);
	}

	inline static int32_t get_offset_of_constructed_26() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F, ___constructed_26)); }
	inline bool get_constructed_26() const { return ___constructed_26; }
	inline bool* get_address_of_constructed_26() { return &___constructed_26; }
	inline void set_constructed_26(bool value)
	{
		___constructed_26 = value;
	}

	inline static int32_t get_offset_of_cached_serialized_form_27() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F, ___cached_serialized_form_27)); }
	inline ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* get_cached_serialized_form_27() const { return ___cached_serialized_form_27; }
	inline ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821** get_address_of_cached_serialized_form_27() { return &___cached_serialized_form_27; }
	inline void set_cached_serialized_form_27(ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* value)
	{
		___cached_serialized_form_27 = value;
		Il2CppCodeGenWriteBarrier((&___cached_serialized_form_27), value);
	}

	inline static int32_t get_offset_of_m_cultureData_28() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F, ___m_cultureData_28)); }
	inline CultureData_tF43B080FFA6EB278F4F289BCDA3FB74B6C208ECD * get_m_cultureData_28() const { return ___m_cultureData_28; }
	inline CultureData_tF43B080FFA6EB278F4F289BCDA3FB74B6C208ECD ** get_address_of_m_cultureData_28() { return &___m_cultureData_28; }
	inline void set_m_cultureData_28(CultureData_tF43B080FFA6EB278F4F289BCDA3FB74B6C208ECD * value)
	{
		___m_cultureData_28 = value;
		Il2CppCodeGenWriteBarrier((&___m_cultureData_28), value);
	}

	inline static int32_t get_offset_of_m_isInherited_29() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F, ___m_isInherited_29)); }
	inline bool get_m_isInherited_29() const { return ___m_isInherited_29; }
	inline bool* get_address_of_m_isInherited_29() { return &___m_isInherited_29; }
	inline void set_m_isInherited_29(bool value)
	{
		___m_isInherited_29 = value;
	}
};

struct CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_StaticFields
{
public:
	// System.Globalization.CultureInfo modreq(System.Runtime.CompilerServices.IsVolatile) System.Globalization.CultureInfo::invariant_culture_info
	CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * ___invariant_culture_info_0;
	// System.Object System.Globalization.CultureInfo::shared_table_lock
	RuntimeObject * ___shared_table_lock_1;
	// System.Globalization.CultureInfo System.Globalization.CultureInfo::default_current_culture
	CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * ___default_current_culture_2;
	// System.Globalization.CultureInfo modreq(System.Runtime.CompilerServices.IsVolatile) System.Globalization.CultureInfo::s_DefaultThreadCurrentUICulture
	CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * ___s_DefaultThreadCurrentUICulture_33;
	// System.Globalization.CultureInfo modreq(System.Runtime.CompilerServices.IsVolatile) System.Globalization.CultureInfo::s_DefaultThreadCurrentCulture
	CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * ___s_DefaultThreadCurrentCulture_34;
	// System.Collections.Generic.Dictionary`2<System.Int32,System.Globalization.CultureInfo> System.Globalization.CultureInfo::shared_by_number
	Dictionary_2_tC88A56872F7C79DBB9582D4F3FC22ED5D8E0B98B * ___shared_by_number_35;
	// System.Collections.Generic.Dictionary`2<System.String,System.Globalization.CultureInfo> System.Globalization.CultureInfo::shared_by_name
	Dictionary_2_tBA5388DBB42BF620266F9A48E8B859BBBB224E25 * ___shared_by_name_36;
	// System.Boolean System.Globalization.CultureInfo::IsTaiwanSku
	bool ___IsTaiwanSku_37;

public:
	inline static int32_t get_offset_of_invariant_culture_info_0() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_StaticFields, ___invariant_culture_info_0)); }
	inline CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * get_invariant_culture_info_0() const { return ___invariant_culture_info_0; }
	inline CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F ** get_address_of_invariant_culture_info_0() { return &___invariant_culture_info_0; }
	inline void set_invariant_culture_info_0(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * value)
	{
		___invariant_culture_info_0 = value;
		Il2CppCodeGenWriteBarrier((&___invariant_culture_info_0), value);
	}

	inline static int32_t get_offset_of_shared_table_lock_1() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_StaticFields, ___shared_table_lock_1)); }
	inline RuntimeObject * get_shared_table_lock_1() const { return ___shared_table_lock_1; }
	inline RuntimeObject ** get_address_of_shared_table_lock_1() { return &___shared_table_lock_1; }
	inline void set_shared_table_lock_1(RuntimeObject * value)
	{
		___shared_table_lock_1 = value;
		Il2CppCodeGenWriteBarrier((&___shared_table_lock_1), value);
	}

	inline static int32_t get_offset_of_default_current_culture_2() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_StaticFields, ___default_current_culture_2)); }
	inline CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * get_default_current_culture_2() const { return ___default_current_culture_2; }
	inline CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F ** get_address_of_default_current_culture_2() { return &___default_current_culture_2; }
	inline void set_default_current_culture_2(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * value)
	{
		___default_current_culture_2 = value;
		Il2CppCodeGenWriteBarrier((&___default_current_culture_2), value);
	}

	inline static int32_t get_offset_of_s_DefaultThreadCurrentUICulture_33() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_StaticFields, ___s_DefaultThreadCurrentUICulture_33)); }
	inline CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * get_s_DefaultThreadCurrentUICulture_33() const { return ___s_DefaultThreadCurrentUICulture_33; }
	inline CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F ** get_address_of_s_DefaultThreadCurrentUICulture_33() { return &___s_DefaultThreadCurrentUICulture_33; }
	inline void set_s_DefaultThreadCurrentUICulture_33(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * value)
	{
		___s_DefaultThreadCurrentUICulture_33 = value;
		Il2CppCodeGenWriteBarrier((&___s_DefaultThreadCurrentUICulture_33), value);
	}

	inline static int32_t get_offset_of_s_DefaultThreadCurrentCulture_34() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_StaticFields, ___s_DefaultThreadCurrentCulture_34)); }
	inline CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * get_s_DefaultThreadCurrentCulture_34() const { return ___s_DefaultThreadCurrentCulture_34; }
	inline CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F ** get_address_of_s_DefaultThreadCurrentCulture_34() { return &___s_DefaultThreadCurrentCulture_34; }
	inline void set_s_DefaultThreadCurrentCulture_34(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * value)
	{
		___s_DefaultThreadCurrentCulture_34 = value;
		Il2CppCodeGenWriteBarrier((&___s_DefaultThreadCurrentCulture_34), value);
	}

	inline static int32_t get_offset_of_shared_by_number_35() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_StaticFields, ___shared_by_number_35)); }
	inline Dictionary_2_tC88A56872F7C79DBB9582D4F3FC22ED5D8E0B98B * get_shared_by_number_35() const { return ___shared_by_number_35; }
	inline Dictionary_2_tC88A56872F7C79DBB9582D4F3FC22ED5D8E0B98B ** get_address_of_shared_by_number_35() { return &___shared_by_number_35; }
	inline void set_shared_by_number_35(Dictionary_2_tC88A56872F7C79DBB9582D4F3FC22ED5D8E0B98B * value)
	{
		___shared_by_number_35 = value;
		Il2CppCodeGenWriteBarrier((&___shared_by_number_35), value);
	}

	inline static int32_t get_offset_of_shared_by_name_36() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_StaticFields, ___shared_by_name_36)); }
	inline Dictionary_2_tBA5388DBB42BF620266F9A48E8B859BBBB224E25 * get_shared_by_name_36() const { return ___shared_by_name_36; }
	inline Dictionary_2_tBA5388DBB42BF620266F9A48E8B859BBBB224E25 ** get_address_of_shared_by_name_36() { return &___shared_by_name_36; }
	inline void set_shared_by_name_36(Dictionary_2_tBA5388DBB42BF620266F9A48E8B859BBBB224E25 * value)
	{
		___shared_by_name_36 = value;
		Il2CppCodeGenWriteBarrier((&___shared_by_name_36), value);
	}

	inline static int32_t get_offset_of_IsTaiwanSku_37() { return static_cast<int32_t>(offsetof(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_StaticFields, ___IsTaiwanSku_37)); }
	inline bool get_IsTaiwanSku_37() const { return ___IsTaiwanSku_37; }
	inline bool* get_address_of_IsTaiwanSku_37() { return &___IsTaiwanSku_37; }
	inline void set_IsTaiwanSku_37(bool value)
	{
		___IsTaiwanSku_37 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.Globalization.CultureInfo
struct CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_marshaled_pinvoke
{
	int32_t ___m_isReadOnly_3;
	int32_t ___cultureID_4;
	int32_t ___parent_lcid_5;
	int32_t ___datetime_index_6;
	int32_t ___number_index_7;
	int32_t ___default_calendar_type_8;
	int32_t ___m_useUserOverride_9;
	NumberFormatInfo_tFDF57037EBC5BC833D0A53EF0327B805994860A8 * ___numInfo_10;
	DateTimeFormatInfo_tF4BB3AA482C2F772D2A9022F78BF8727830FAF5F * ___dateTimeInfo_11;
	TextInfo_t5F1E697CB6A7E5EC80F0DC3A968B9B4A70C291D8 * ___textInfo_12;
	char* ___m_name_13;
	char* ___englishname_14;
	char* ___nativename_15;
	char* ___iso3lang_16;
	char* ___iso2lang_17;
	char* ___win3lang_18;
	char* ___territory_19;
	char** ___native_calendar_names_20;
	CompareInfo_tB9A071DBC11AC00AF2EA2066D0C2AE1DCB1865D1 * ___compareInfo_21;
	void* ___textinfo_data_22;
	int32_t ___m_dataItem_23;
	Calendar_tF55A785ACD277504CF0D2F2C6AD56F76C6E91BD5 * ___calendar_24;
	CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_marshaled_pinvoke* ___parent_culture_25;
	int32_t ___constructed_26;
	uint8_t* ___cached_serialized_form_27;
	CultureData_tF43B080FFA6EB278F4F289BCDA3FB74B6C208ECD_marshaled_pinvoke* ___m_cultureData_28;
	int32_t ___m_isInherited_29;
};
// Native definition for COM marshalling of System.Globalization.CultureInfo
struct CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_marshaled_com
{
	int32_t ___m_isReadOnly_3;
	int32_t ___cultureID_4;
	int32_t ___parent_lcid_5;
	int32_t ___datetime_index_6;
	int32_t ___number_index_7;
	int32_t ___default_calendar_type_8;
	int32_t ___m_useUserOverride_9;
	NumberFormatInfo_tFDF57037EBC5BC833D0A53EF0327B805994860A8 * ___numInfo_10;
	DateTimeFormatInfo_tF4BB3AA482C2F772D2A9022F78BF8727830FAF5F * ___dateTimeInfo_11;
	TextInfo_t5F1E697CB6A7E5EC80F0DC3A968B9B4A70C291D8 * ___textInfo_12;
	Il2CppChar* ___m_name_13;
	Il2CppChar* ___englishname_14;
	Il2CppChar* ___nativename_15;
	Il2CppChar* ___iso3lang_16;
	Il2CppChar* ___iso2lang_17;
	Il2CppChar* ___win3lang_18;
	Il2CppChar* ___territory_19;
	Il2CppChar** ___native_calendar_names_20;
	CompareInfo_tB9A071DBC11AC00AF2EA2066D0C2AE1DCB1865D1 * ___compareInfo_21;
	void* ___textinfo_data_22;
	int32_t ___m_dataItem_23;
	Calendar_tF55A785ACD277504CF0D2F2C6AD56F76C6E91BD5 * ___calendar_24;
	CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_marshaled_com* ___parent_culture_25;
	int32_t ___constructed_26;
	uint8_t* ___cached_serialized_form_27;
	CultureData_tF43B080FFA6EB278F4F289BCDA3FB74B6C208ECD_marshaled_com* ___m_cultureData_28;
	int32_t ___m_isInherited_29;
};
#endif // CULTUREINFO_T345AC6924134F039ED9A11F3E03F8E91B6A3225F_H
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
#ifndef STRINGBUILDER_T_H
#define STRINGBUILDER_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Text.StringBuilder
struct  StringBuilder_t  : public RuntimeObject
{
public:
	// System.Char[] System.Text.StringBuilder::m_ChunkChars
	CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* ___m_ChunkChars_0;
	// System.Text.StringBuilder System.Text.StringBuilder::m_ChunkPrevious
	StringBuilder_t * ___m_ChunkPrevious_1;
	// System.Int32 System.Text.StringBuilder::m_ChunkLength
	int32_t ___m_ChunkLength_2;
	// System.Int32 System.Text.StringBuilder::m_ChunkOffset
	int32_t ___m_ChunkOffset_3;
	// System.Int32 System.Text.StringBuilder::m_MaxCapacity
	int32_t ___m_MaxCapacity_4;

public:
	inline static int32_t get_offset_of_m_ChunkChars_0() { return static_cast<int32_t>(offsetof(StringBuilder_t, ___m_ChunkChars_0)); }
	inline CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* get_m_ChunkChars_0() const { return ___m_ChunkChars_0; }
	inline CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2** get_address_of_m_ChunkChars_0() { return &___m_ChunkChars_0; }
	inline void set_m_ChunkChars_0(CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* value)
	{
		___m_ChunkChars_0 = value;
		Il2CppCodeGenWriteBarrier((&___m_ChunkChars_0), value);
	}

	inline static int32_t get_offset_of_m_ChunkPrevious_1() { return static_cast<int32_t>(offsetof(StringBuilder_t, ___m_ChunkPrevious_1)); }
	inline StringBuilder_t * get_m_ChunkPrevious_1() const { return ___m_ChunkPrevious_1; }
	inline StringBuilder_t ** get_address_of_m_ChunkPrevious_1() { return &___m_ChunkPrevious_1; }
	inline void set_m_ChunkPrevious_1(StringBuilder_t * value)
	{
		___m_ChunkPrevious_1 = value;
		Il2CppCodeGenWriteBarrier((&___m_ChunkPrevious_1), value);
	}

	inline static int32_t get_offset_of_m_ChunkLength_2() { return static_cast<int32_t>(offsetof(StringBuilder_t, ___m_ChunkLength_2)); }
	inline int32_t get_m_ChunkLength_2() const { return ___m_ChunkLength_2; }
	inline int32_t* get_address_of_m_ChunkLength_2() { return &___m_ChunkLength_2; }
	inline void set_m_ChunkLength_2(int32_t value)
	{
		___m_ChunkLength_2 = value;
	}

	inline static int32_t get_offset_of_m_ChunkOffset_3() { return static_cast<int32_t>(offsetof(StringBuilder_t, ___m_ChunkOffset_3)); }
	inline int32_t get_m_ChunkOffset_3() const { return ___m_ChunkOffset_3; }
	inline int32_t* get_address_of_m_ChunkOffset_3() { return &___m_ChunkOffset_3; }
	inline void set_m_ChunkOffset_3(int32_t value)
	{
		___m_ChunkOffset_3 = value;
	}

	inline static int32_t get_offset_of_m_MaxCapacity_4() { return static_cast<int32_t>(offsetof(StringBuilder_t, ___m_MaxCapacity_4)); }
	inline int32_t get_m_MaxCapacity_4() const { return ___m_MaxCapacity_4; }
	inline int32_t* get_address_of_m_MaxCapacity_4() { return &___m_MaxCapacity_4; }
	inline void set_m_MaxCapacity_4(int32_t value)
	{
		___m_MaxCapacity_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // STRINGBUILDER_T_H
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
#ifndef JSON_T293914E1410C0E0619C7A71B68B0876B5ECFB333_H
#define JSON_T293914E1410C0E0619C7A71B68B0876B5ECFB333_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Purchasing.MiniJSON.Json
struct  Json_t293914E1410C0E0619C7A71B68B0876B5ECFB333  : public RuntimeObject
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // JSON_T293914E1410C0E0619C7A71B68B0876B5ECFB333_H
#ifndef PARSER_TB549FB05B57D479E2DE2176A23323313AF3E4543_H
#define PARSER_TB549FB05B57D479E2DE2176A23323313AF3E4543_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Purchasing.MiniJSON.Json_Parser
struct  Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543  : public RuntimeObject
{
public:
	// System.IO.StringReader UnityEngine.Purchasing.MiniJSON.Json_Parser::json
	StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12 * ___json_0;

public:
	inline static int32_t get_offset_of_json_0() { return static_cast<int32_t>(offsetof(Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543, ___json_0)); }
	inline StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12 * get_json_0() const { return ___json_0; }
	inline StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12 ** get_address_of_json_0() { return &___json_0; }
	inline void set_json_0(StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12 * value)
	{
		___json_0 = value;
		Il2CppCodeGenWriteBarrier((&___json_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // PARSER_TB549FB05B57D479E2DE2176A23323313AF3E4543_H
#ifndef SERIALIZER_T8E477D61E7D27FA878E7A6D57F4619E5C5B0611D_H
#define SERIALIZER_T8E477D61E7D27FA878E7A6D57F4619E5C5B0611D_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Purchasing.MiniJSON.Json_Serializer
struct  Serializer_t8E477D61E7D27FA878E7A6D57F4619E5C5B0611D  : public RuntimeObject
{
public:
	// System.Text.StringBuilder UnityEngine.Purchasing.MiniJSON.Json_Serializer::builder
	StringBuilder_t * ___builder_0;

public:
	inline static int32_t get_offset_of_builder_0() { return static_cast<int32_t>(offsetof(Serializer_t8E477D61E7D27FA878E7A6D57F4619E5C5B0611D, ___builder_0)); }
	inline StringBuilder_t * get_builder_0() const { return ___builder_0; }
	inline StringBuilder_t ** get_address_of_builder_0() { return &___builder_0; }
	inline void set_builder_0(StringBuilder_t * value)
	{
		___builder_0 = value;
		Il2CppCodeGenWriteBarrier((&___builder_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SERIALIZER_T8E477D61E7D27FA878E7A6D57F4619E5C5B0611D_H
#ifndef MINIJSONEXTENSIONS_TFFA17EEFDC64C5499F8B19278BE9CCD1A2BFCF35_H
#define MINIJSONEXTENSIONS_TFFA17EEFDC64C5499F8B19278BE9CCD1A2BFCF35_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Purchasing.MiniJSON.MiniJsonExtensions
struct  MiniJsonExtensions_tFFA17EEFDC64C5499F8B19278BE9CCD1A2BFCF35  : public RuntimeObject
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MINIJSONEXTENSIONS_TFFA17EEFDC64C5499F8B19278BE9CCD1A2BFCF35_H
#ifndef MINIJSON_TA9BE893B2BDF6A3ABF01A05A83B095CDD054A31E_H
#define MINIJSON_TA9BE893B2BDF6A3ABF01A05A83B095CDD054A31E_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Purchasing.MiniJson
struct  MiniJson_tA9BE893B2BDF6A3ABF01A05A83B095CDD054A31E  : public RuntimeObject
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MINIJSON_TA9BE893B2BDF6A3ABF01A05A83B095CDD054A31E_H
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
#ifndef TEXTREADER_T7DF8314B601D202ECFEDF623093A87BFDAB58D0A_H
#define TEXTREADER_T7DF8314B601D202ECFEDF623093A87BFDAB58D0A_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.IO.TextReader
struct  TextReader_t7DF8314B601D202ECFEDF623093A87BFDAB58D0A  : public MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF
{
public:

public:
};

struct TextReader_t7DF8314B601D202ECFEDF623093A87BFDAB58D0A_StaticFields
{
public:
	// System.Func`2<System.Object,System.String> System.IO.TextReader::_ReadLineDelegate
	Func_2_t44B347E67E515867D995E8BD5EFD67FA88CE53CF * ____ReadLineDelegate_1;
	// System.Func`2<System.Object,System.Int32> System.IO.TextReader::_ReadDelegate
	Func_2_t8B2DA3FB30280CE3D92F50E9CCAACEE4828789A6 * ____ReadDelegate_2;
	// System.IO.TextReader System.IO.TextReader::Null
	TextReader_t7DF8314B601D202ECFEDF623093A87BFDAB58D0A * ___Null_3;

public:
	inline static int32_t get_offset_of__ReadLineDelegate_1() { return static_cast<int32_t>(offsetof(TextReader_t7DF8314B601D202ECFEDF623093A87BFDAB58D0A_StaticFields, ____ReadLineDelegate_1)); }
	inline Func_2_t44B347E67E515867D995E8BD5EFD67FA88CE53CF * get__ReadLineDelegate_1() const { return ____ReadLineDelegate_1; }
	inline Func_2_t44B347E67E515867D995E8BD5EFD67FA88CE53CF ** get_address_of__ReadLineDelegate_1() { return &____ReadLineDelegate_1; }
	inline void set__ReadLineDelegate_1(Func_2_t44B347E67E515867D995E8BD5EFD67FA88CE53CF * value)
	{
		____ReadLineDelegate_1 = value;
		Il2CppCodeGenWriteBarrier((&____ReadLineDelegate_1), value);
	}

	inline static int32_t get_offset_of__ReadDelegate_2() { return static_cast<int32_t>(offsetof(TextReader_t7DF8314B601D202ECFEDF623093A87BFDAB58D0A_StaticFields, ____ReadDelegate_2)); }
	inline Func_2_t8B2DA3FB30280CE3D92F50E9CCAACEE4828789A6 * get__ReadDelegate_2() const { return ____ReadDelegate_2; }
	inline Func_2_t8B2DA3FB30280CE3D92F50E9CCAACEE4828789A6 ** get_address_of__ReadDelegate_2() { return &____ReadDelegate_2; }
	inline void set__ReadDelegate_2(Func_2_t8B2DA3FB30280CE3D92F50E9CCAACEE4828789A6 * value)
	{
		____ReadDelegate_2 = value;
		Il2CppCodeGenWriteBarrier((&____ReadDelegate_2), value);
	}

	inline static int32_t get_offset_of_Null_3() { return static_cast<int32_t>(offsetof(TextReader_t7DF8314B601D202ECFEDF623093A87BFDAB58D0A_StaticFields, ___Null_3)); }
	inline TextReader_t7DF8314B601D202ECFEDF623093A87BFDAB58D0A * get_Null_3() const { return ___Null_3; }
	inline TextReader_t7DF8314B601D202ECFEDF623093A87BFDAB58D0A ** get_address_of_Null_3() { return &___Null_3; }
	inline void set_Null_3(TextReader_t7DF8314B601D202ECFEDF623093A87BFDAB58D0A * value)
	{
		___Null_3 = value;
		Il2CppCodeGenWriteBarrier((&___Null_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TEXTREADER_T7DF8314B601D202ECFEDF623093A87BFDAB58D0A_H
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
#ifndef NUMBERSTYLES_TB0ADA2D9CCAA236331AED14C42BE5832B2351592_H
#define NUMBERSTYLES_TB0ADA2D9CCAA236331AED14C42BE5832B2351592_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Globalization.NumberStyles
struct  NumberStyles_tB0ADA2D9CCAA236331AED14C42BE5832B2351592 
{
public:
	// System.Int32 System.Globalization.NumberStyles::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(NumberStyles_tB0ADA2D9CCAA236331AED14C42BE5832B2351592, ___value___2)); }
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
#endif // NUMBERSTYLES_TB0ADA2D9CCAA236331AED14C42BE5832B2351592_H
#ifndef STRINGREADER_T3095DEB3D26F40D1A7F9B76835D80AFE70E47E12_H
#define STRINGREADER_T3095DEB3D26F40D1A7F9B76835D80AFE70E47E12_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.IO.StringReader
struct  StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12  : public TextReader_t7DF8314B601D202ECFEDF623093A87BFDAB58D0A
{
public:
	// System.String System.IO.StringReader::_s
	String_t* ____s_4;
	// System.Int32 System.IO.StringReader::_pos
	int32_t ____pos_5;
	// System.Int32 System.IO.StringReader::_length
	int32_t ____length_6;

public:
	inline static int32_t get_offset_of__s_4() { return static_cast<int32_t>(offsetof(StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12, ____s_4)); }
	inline String_t* get__s_4() const { return ____s_4; }
	inline String_t** get_address_of__s_4() { return &____s_4; }
	inline void set__s_4(String_t* value)
	{
		____s_4 = value;
		Il2CppCodeGenWriteBarrier((&____s_4), value);
	}

	inline static int32_t get_offset_of__pos_5() { return static_cast<int32_t>(offsetof(StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12, ____pos_5)); }
	inline int32_t get__pos_5() const { return ____pos_5; }
	inline int32_t* get_address_of__pos_5() { return &____pos_5; }
	inline void set__pos_5(int32_t value)
	{
		____pos_5 = value;
	}

	inline static int32_t get_offset_of__length_6() { return static_cast<int32_t>(offsetof(StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12, ____length_6)); }
	inline int32_t get__length_6() const { return ____length_6; }
	inline int32_t* get_address_of__length_6() { return &____length_6; }
	inline void set__length_6(int32_t value)
	{
		____length_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // STRINGREADER_T3095DEB3D26F40D1A7F9B76835D80AFE70E47E12_H
#ifndef TOKEN_T18DC0C7637DCFEA495D2F347E645AD65A48A2215_H
#define TOKEN_T18DC0C7637DCFEA495D2F347E645AD65A48A2215_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Purchasing.MiniJSON.Json_Parser_TOKEN
struct  TOKEN_t18DC0C7637DCFEA495D2F347E645AD65A48A2215 
{
public:
	// System.Int32 UnityEngine.Purchasing.MiniJSON.Json_Parser_TOKEN::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(TOKEN_t18DC0C7637DCFEA495D2F347E645AD65A48A2215, ___value___2)); }
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
#endif // TOKEN_T18DC0C7637DCFEA495D2F347E645AD65A48A2215_H
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
#ifndef UNITYPURCHASINGCALLBACK_TF3081DE4B67FBD9771C293C52885EC15C279810C_H
#define UNITYPURCHASINGCALLBACK_TF3081DE4B67FBD9771C293C52885EC15C279810C_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Purchasing.UnityPurchasingCallback
struct  UnityPurchasingCallback_tF3081DE4B67FBD9771C293C52885EC15C279810C  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UNITYPURCHASINGCALLBACK_TF3081DE4B67FBD9771C293C52885EC15C279810C_H
// System.Char[]
struct CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) Il2CppChar m_Items[1];

public:
	inline Il2CppChar GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Il2CppChar* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Il2CppChar value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline Il2CppChar GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Il2CppChar* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Il2CppChar value)
	{
		m_Items[index] = value;
	}
};
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


// System.Void System.Collections.Generic.Dictionary`2<System.Object,System.Object>::.ctor()
extern "C" IL2CPP_METHOD_ATTR void Dictionary_2__ctor_m2C7E51568033239B506E15E7804A0B8658246498_gshared (Dictionary_2_t32F25F093828AA9F93CB11C2A2B4648FD62A09BA * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.Dictionary`2<System.Object,System.Object>::set_Item(!0,!1)
extern "C" IL2CPP_METHOD_ATTR void Dictionary_2_set_Item_m466D001F105E25DEB5C9BCB17837EE92A27FDE93_gshared (Dictionary_2_t32F25F093828AA9F93CB11C2A2B4648FD62A09BA * __this, RuntimeObject * p0, RuntimeObject * p1, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Object>::.ctor()
extern "C" IL2CPP_METHOD_ATTR void List_1__ctor_mC832F1AC0F814BAEB19175F5D7972A7507508BC3_gshared (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Object>::Add(!0)
extern "C" IL2CPP_METHOD_ATTR void List_1_Add_m6930161974C7504C80F52EC379EF012387D43138_gshared (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * __this, RuntimeObject * p0, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.Dictionary`2<System.Object,System.Object>::ContainsKey(!0)
extern "C" IL2CPP_METHOD_ATTR bool Dictionary_2_ContainsKey_m4EBC00E16E83DA33851A551757D2B7332D5756B9_gshared (Dictionary_2_t32F25F093828AA9F93CB11C2A2B4648FD62A09BA * __this, RuntimeObject * p0, const RuntimeMethod* method);
// !1 System.Collections.Generic.Dictionary`2<System.Object,System.Object>::get_Item(!0)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * Dictionary_2_get_Item_m6625C3BA931A6EE5D6DB46B9E743B40AAA30010B_gshared (Dictionary_2_t32F25F093828AA9F93CB11C2A2B4648FD62A09BA * __this, RuntimeObject * p0, const RuntimeMethod* method);

// System.Object UnityEngine.Purchasing.MiniJSON.Json/Parser::Parse(System.String)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * Parser_Parse_mFDB5642E0F39901529C00E41650C0E40384996C5 (String_t* ___jsonString0, const RuntimeMethod* method);
// System.String UnityEngine.Purchasing.MiniJSON.Json/Serializer::Serialize(System.Object)
extern "C" IL2CPP_METHOD_ATTR String_t* Serializer_Serialize_m3ADBCAEE90D7C194CF45992E4B8C6D25557A3809 (RuntimeObject * ___obj0, const RuntimeMethod* method);
// System.Boolean System.Char::IsWhiteSpace(System.Char)
extern "C" IL2CPP_METHOD_ATTR bool Char_IsWhiteSpace_m8AE1C4157A1E1D8F5022630F4229AB26223BDC6B (Il2CppChar p0, const RuntimeMethod* method);
// System.Int32 System.String::IndexOf(System.Char)
extern "C" IL2CPP_METHOD_ATTR int32_t String_IndexOf_m2909B8CF585E1BD0C81E11ACA2F48012156FD5BD (String_t* __this, Il2CppChar p0, const RuntimeMethod* method);
// System.Void System.Object::.ctor()
extern "C" IL2CPP_METHOD_ATTR void Object__ctor_m925ECA5E85CA100E3FB86A4F9E15C120E9A184C0 (RuntimeObject * __this, const RuntimeMethod* method);
// System.Void System.IO.StringReader::.ctor(System.String)
extern "C" IL2CPP_METHOD_ATTR void StringReader__ctor_mA55383C19EFBC075E762145D88F15A2B8B0CDA17 (StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12 * __this, String_t* p0, const RuntimeMethod* method);
// System.Void UnityEngine.Purchasing.MiniJSON.Json/Parser::.ctor(System.String)
extern "C" IL2CPP_METHOD_ATTR void Parser__ctor_m3D3193C5644C380E18422E83B0F0E3F8E7D78E70 (Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * __this, String_t* ___jsonString0, const RuntimeMethod* method);
// System.Object UnityEngine.Purchasing.MiniJSON.Json/Parser::ParseValue()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * Parser_ParseValue_m730210460220F67469844AB7ABB37A994D359698 (Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * __this, const RuntimeMethod* method);
// System.Void System.IO.TextReader::Dispose()
extern "C" IL2CPP_METHOD_ATTR void TextReader_Dispose_m9DA31CD42D5E73A1452F4EEC014C5703B5872930 (TextReader_t7DF8314B601D202ECFEDF623093A87BFDAB58D0A * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.Dictionary`2<System.String,System.Object>::.ctor()
inline void Dictionary_2__ctor_mCA7075EA6548A18B929368520217975094841997 (Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * __this, const RuntimeMethod* method)
{
	((  void (*) (Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA *, const RuntimeMethod*))Dictionary_2__ctor_m2C7E51568033239B506E15E7804A0B8658246498_gshared)(__this, method);
}
// UnityEngine.Purchasing.MiniJSON.Json/Parser/TOKEN UnityEngine.Purchasing.MiniJSON.Json/Parser::get_NextToken()
extern "C" IL2CPP_METHOD_ATTR int32_t Parser_get_NextToken_m0B0637C375655D15C6D9C4BDEDF2A2A9E6DA69CE (Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * __this, const RuntimeMethod* method);
// System.String UnityEngine.Purchasing.MiniJSON.Json/Parser::ParseString()
extern "C" IL2CPP_METHOD_ATTR String_t* Parser_ParseString_mB6994A848988FDCE117674ABC2F085E460B12635 (Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.Dictionary`2<System.String,System.Object>::set_Item(!0,!1)
inline void Dictionary_2_set_Item_mEA41AEAE79570A9410777F6B90969532564025DD (Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * __this, String_t* p0, RuntimeObject * p1, const RuntimeMethod* method)
{
	((  void (*) (Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA *, String_t*, RuntimeObject *, const RuntimeMethod*))Dictionary_2_set_Item_m466D001F105E25DEB5C9BCB17837EE92A27FDE93_gshared)(__this, p0, p1, method);
}
// System.Void System.Collections.Generic.List`1<System.Object>::.ctor()
inline void List_1__ctor_mC832F1AC0F814BAEB19175F5D7972A7507508BC3 (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D *, const RuntimeMethod*))List_1__ctor_mC832F1AC0F814BAEB19175F5D7972A7507508BC3_gshared)(__this, method);
}
// System.Object UnityEngine.Purchasing.MiniJSON.Json/Parser::ParseByToken(UnityEngine.Purchasing.MiniJSON.Json/Parser/TOKEN)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * Parser_ParseByToken_mF99905D919F1D2A54466793D3D938043E10AE5BA (Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * __this, int32_t ___token0, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Object>::Add(!0)
inline void List_1_Add_m6930161974C7504C80F52EC379EF012387D43138 (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * __this, RuntimeObject * p0, const RuntimeMethod* method)
{
	((  void (*) (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D *, RuntimeObject *, const RuntimeMethod*))List_1_Add_m6930161974C7504C80F52EC379EF012387D43138_gshared)(__this, p0, method);
}
// System.Object UnityEngine.Purchasing.MiniJSON.Json/Parser::ParseNumber()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * Parser_ParseNumber_m244426CB90761E4326DD8678646DE2715929077F (Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * __this, const RuntimeMethod* method);
// System.Collections.Generic.Dictionary`2<System.String,System.Object> UnityEngine.Purchasing.MiniJSON.Json/Parser::ParseObject()
extern "C" IL2CPP_METHOD_ATTR Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * Parser_ParseObject_m5A34882277CE52DF62AB0CA09CEA3005716398FF (Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * __this, const RuntimeMethod* method);
// System.Collections.Generic.List`1<System.Object> UnityEngine.Purchasing.MiniJSON.Json/Parser::ParseArray()
extern "C" IL2CPP_METHOD_ATTR List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * Parser_ParseArray_m12FC39460D64ACE1AE58275BCEA66644DD28BBF2 (Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * __this, const RuntimeMethod* method);
// System.Void System.Text.StringBuilder::.ctor()
extern "C" IL2CPP_METHOD_ATTR void StringBuilder__ctor_mF928376F82E8C8FF3C11842C562DB8CF28B2735E (StringBuilder_t * __this, const RuntimeMethod* method);
// System.Char UnityEngine.Purchasing.MiniJSON.Json/Parser::get_NextChar()
extern "C" IL2CPP_METHOD_ATTR Il2CppChar Parser_get_NextChar_mB16EDBEAEFDF5B7AB13A22E5420B9BAF3FB8B4B2 (Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * __this, const RuntimeMethod* method);
// System.Text.StringBuilder System.Text.StringBuilder::Append(System.Char)
extern "C" IL2CPP_METHOD_ATTR StringBuilder_t * StringBuilder_Append_m05C12F58ADC2D807613A9301DF438CB3CD09B75A (StringBuilder_t * __this, Il2CppChar p0, const RuntimeMethod* method);
// System.String System.String::CreateString(System.Char[])
extern "C" IL2CPP_METHOD_ATTR String_t* String_CreateString_m394C06654854ADD4C51FF957BE0CC72EF52BAA96 (String_t* __this, CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* ___val0, const RuntimeMethod* method);
// System.Int32 System.Convert::ToInt32(System.String,System.Int32)
extern "C" IL2CPP_METHOD_ATTR int32_t Convert_ToInt32_m8DC81C7C49EE4A9334E71E45E3A220644E45B4F4 (String_t* p0, int32_t p1, const RuntimeMethod* method);
// System.String UnityEngine.Purchasing.MiniJSON.Json/Parser::get_NextWord()
extern "C" IL2CPP_METHOD_ATTR String_t* Parser_get_NextWord_m6D4BE7C1F45368E40593F0F712B80DD40D1E9034 (Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * __this, const RuntimeMethod* method);
// System.Globalization.CultureInfo System.Globalization.CultureInfo::get_InvariantCulture()
extern "C" IL2CPP_METHOD_ATTR CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * CultureInfo_get_InvariantCulture_mF13B47F8A763CE6A9C8A8BB2EED33FF8F7A63A72 (const RuntimeMethod* method);
// System.Boolean System.Int64::TryParse(System.String,System.Globalization.NumberStyles,System.IFormatProvider,System.Int64&)
extern "C" IL2CPP_METHOD_ATTR bool Int64_TryParse_m8CE5F89833C03A091273A4EF48C69E86E1F81ACC (String_t* p0, int32_t p1, RuntimeObject* p2, int64_t* p3, const RuntimeMethod* method);
// System.Boolean System.Double::TryParse(System.String,System.Globalization.NumberStyles,System.IFormatProvider,System.Double&)
extern "C" IL2CPP_METHOD_ATTR bool Double_TryParse_m1A7BCBA90DE896E448E3CA09AAD1CA43846567D7 (String_t* p0, int32_t p1, RuntimeObject* p2, double* p3, const RuntimeMethod* method);
// System.Char UnityEngine.Purchasing.MiniJSON.Json/Parser::get_PeekChar()
extern "C" IL2CPP_METHOD_ATTR Il2CppChar Parser_get_PeekChar_mC4F636B592D572D313318820C35D3B8A70661931 (Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * __this, const RuntimeMethod* method);
// System.Char System.Convert::ToChar(System.Int32)
extern "C" IL2CPP_METHOD_ATTR Il2CppChar Convert_ToChar_m5BD134B72978B879B81A824DFAC8FF29F5300245 (int32_t p0, const RuntimeMethod* method);
// System.Boolean UnityEngine.Purchasing.MiniJSON.Json/Parser::IsWordBreak(System.Char)
extern "C" IL2CPP_METHOD_ATTR bool Parser_IsWordBreak_m395241B2FB531CE679C9BBDE1784EA50D937D210 (Il2CppChar ___c0, const RuntimeMethod* method);
// System.Void UnityEngine.Purchasing.MiniJSON.Json/Parser::EatWhitespace()
extern "C" IL2CPP_METHOD_ATTR void Parser_EatWhitespace_m8A09F4A69DD67898D517E9772A47500CF798548F (Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * __this, const RuntimeMethod* method);
// System.Boolean System.String::op_Equality(System.String,System.String)
extern "C" IL2CPP_METHOD_ATTR bool String_op_Equality_m139F0E4195AE2F856019E63B241F36F016997FCE (String_t* p0, String_t* p1, const RuntimeMethod* method);
// System.Void UnityEngine.Purchasing.MiniJSON.Json/Serializer::.ctor()
extern "C" IL2CPP_METHOD_ATTR void Serializer__ctor_m5596317D8D472AE91B9CC27CAF9241149191B796 (Serializer_t8E477D61E7D27FA878E7A6D57F4619E5C5B0611D * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Purchasing.MiniJSON.Json/Serializer::SerializeValue(System.Object)
extern "C" IL2CPP_METHOD_ATTR void Serializer_SerializeValue_mDA3C31227389EF6116A3D5490FDAB12CE3AC28DC (Serializer_t8E477D61E7D27FA878E7A6D57F4619E5C5B0611D * __this, RuntimeObject * ___value0, const RuntimeMethod* method);
// System.Text.StringBuilder System.Text.StringBuilder::Append(System.String)
extern "C" IL2CPP_METHOD_ATTR StringBuilder_t * StringBuilder_Append_mDBB8CCBB7750C67BE2F2D92F47E6C0FA42793260 (StringBuilder_t * __this, String_t* p0, const RuntimeMethod* method);
// System.Void UnityEngine.Purchasing.MiniJSON.Json/Serializer::SerializeString(System.String)
extern "C" IL2CPP_METHOD_ATTR void Serializer_SerializeString_m71208E9D67CAB89BF60CE2CAA22264221B8110EE (Serializer_t8E477D61E7D27FA878E7A6D57F4619E5C5B0611D * __this, String_t* ___str0, const RuntimeMethod* method);
// System.Void UnityEngine.Purchasing.MiniJSON.Json/Serializer::SerializeArray(System.Collections.IList)
extern "C" IL2CPP_METHOD_ATTR void Serializer_SerializeArray_mA4DB26A2353A1FE3838E765DB7A6F6B4E4460ECC (Serializer_t8E477D61E7D27FA878E7A6D57F4619E5C5B0611D * __this, RuntimeObject* ___anArray0, const RuntimeMethod* method);
// System.Void UnityEngine.Purchasing.MiniJSON.Json/Serializer::SerializeObject(System.Collections.IDictionary)
extern "C" IL2CPP_METHOD_ATTR void Serializer_SerializeObject_mFF26F5476F7F35A992B893E7A19717B972018A83 (Serializer_t8E477D61E7D27FA878E7A6D57F4619E5C5B0611D * __this, RuntimeObject* ___obj0, const RuntimeMethod* method);
// System.String System.String::CreateString(System.Char,System.Int32)
extern "C" IL2CPP_METHOD_ATTR String_t* String_CreateString_m0E7BBCE09E386877E2B63BF7FA36B956BF221C93 (String_t* __this, Il2CppChar ___c0, int32_t ___count1, const RuntimeMethod* method);
// System.Void UnityEngine.Purchasing.MiniJSON.Json/Serializer::SerializeOther(System.Object)
extern "C" IL2CPP_METHOD_ATTR void Serializer_SerializeOther_m39DC0396BC829EDA0A4086E711BCF48BFDF79351 (Serializer_t8E477D61E7D27FA878E7A6D57F4619E5C5B0611D * __this, RuntimeObject * ___value0, const RuntimeMethod* method);
// System.Char[] System.String::ToCharArray()
extern "C" IL2CPP_METHOD_ATTR CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* String_ToCharArray_mFCFF32A5EC698E81075E0C72C874282B9ED197A6 (String_t* __this, const RuntimeMethod* method);
// System.Int32 System.Convert::ToInt32(System.Char)
extern "C" IL2CPP_METHOD_ATTR int32_t Convert_ToInt32_m8BE65713C8D5E0AD45D53B82A5A7BD187BEBA917 (Il2CppChar p0, const RuntimeMethod* method);
// System.String System.Int32::ToString(System.String)
extern "C" IL2CPP_METHOD_ATTR String_t* Int32_ToString_m5A125A41C41701E41FA0C4CC52CADBC73C1C96D8 (int32_t* __this, String_t* p0, const RuntimeMethod* method);
// System.String System.Single::ToString(System.String)
extern "C" IL2CPP_METHOD_ATTR String_t* Single_ToString_m211B5E14B0C60667C56838D5C3788CFA58670DDE (float* __this, String_t* p0, const RuntimeMethod* method);
// System.Text.StringBuilder System.Text.StringBuilder::Append(System.Object)
extern "C" IL2CPP_METHOD_ATTR StringBuilder_t * StringBuilder_Append_mA1A063A1388A21C8EA011DBA7FC98C24C3EE3D65 (StringBuilder_t * __this, RuntimeObject * p0, const RuntimeMethod* method);
// System.Double System.Convert::ToDouble(System.Object)
extern "C" IL2CPP_METHOD_ATTR double Convert_ToDouble_mAB66BA75AC3CDFA1FEC09E3125EA444B46CD7050 (RuntimeObject * p0, const RuntimeMethod* method);
// System.String System.Double::ToString(System.String)
extern "C" IL2CPP_METHOD_ATTR String_t* Double_ToString_m4A142BE5E5F1EF1434658FC874A19E124D95313F (double* __this, String_t* p0, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.Dictionary`2<System.String,System.Object>::ContainsKey(!0)
inline bool Dictionary_2_ContainsKey_mAD4B2095526B4742201B24C5ADF1717AFB15EF89 (Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * __this, String_t* p0, const RuntimeMethod* method)
{
	return ((  bool (*) (Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA *, String_t*, const RuntimeMethod*))Dictionary_2_ContainsKey_m4EBC00E16E83DA33851A551757D2B7332D5756B9_gshared)(__this, p0, method);
}
// !1 System.Collections.Generic.Dictionary`2<System.String,System.Object>::get_Item(!0)
inline RuntimeObject * Dictionary_2_get_Item_mB490F7029D7451FAF06E3020040E604B500BA3B2 (Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * __this, String_t* p0, const RuntimeMethod* method)
{
	return ((  RuntimeObject * (*) (Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA *, String_t*, const RuntimeMethod*))Dictionary_2_get_Item_m6625C3BA931A6EE5D6DB46B9E743B40AAA30010B_gshared)(__this, p0, method);
}
// System.String UnityEngine.Purchasing.MiniJson::JsonEncode(System.Object)
extern "C" IL2CPP_METHOD_ATTR String_t* MiniJson_JsonEncode_m224609728F07F11683AEE1398F8C2E6F1FC759E2 (RuntimeObject * ___json0, const RuntimeMethod* method);
// System.Object UnityEngine.Purchasing.MiniJson::JsonDecode(System.String)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * MiniJson_JsonDecode_m4F90554E3C783D4EA66473DCB81826937A6BA268 (String_t* ___json0, const RuntimeMethod* method);
// System.String UnityEngine.Purchasing.MiniJSON.Json::Serialize(System.Object)
extern "C" IL2CPP_METHOD_ATTR String_t* Json_Serialize_mD1295591A0B6F59C1A9BD7940B258EE79DC659EC (RuntimeObject * ___obj0, const RuntimeMethod* method);
// System.Object UnityEngine.Purchasing.MiniJSON.Json::Deserialize(System.String)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * Json_Deserialize_m63BB7C9B31E2AE1C78B8091D9D54CCCD64CC763E (String_t* ___json0, const RuntimeMethod* method);
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
// System.Object UnityEngine.Purchasing.MiniJSON.Json::Deserialize(System.String)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * Json_Deserialize_m63BB7C9B31E2AE1C78B8091D9D54CCCD64CC763E (String_t* ___json0, const RuntimeMethod* method)
{
	bool V_0 = false;
	RuntimeObject * V_1 = NULL;
	{
		String_t* L_0 = ___json0;
		V_0 = (bool)((((RuntimeObject*)(String_t*)L_0) == ((RuntimeObject*)(RuntimeObject *)NULL))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_000e;
		}
	}
	{
		V_1 = NULL;
		goto IL_0017;
	}

IL_000e:
	{
		String_t* L_2 = ___json0;
		RuntimeObject * L_3 = Parser_Parse_mFDB5642E0F39901529C00E41650C0E40384996C5(L_2, /*hidden argument*/NULL);
		V_1 = L_3;
		goto IL_0017;
	}

IL_0017:
	{
		RuntimeObject * L_4 = V_1;
		return L_4;
	}
}
// System.String UnityEngine.Purchasing.MiniJSON.Json::Serialize(System.Object)
extern "C" IL2CPP_METHOD_ATTR String_t* Json_Serialize_mD1295591A0B6F59C1A9BD7940B258EE79DC659EC (RuntimeObject * ___obj0, const RuntimeMethod* method)
{
	String_t* V_0 = NULL;
	{
		RuntimeObject * L_0 = ___obj0;
		String_t* L_1 = Serializer_Serialize_m3ADBCAEE90D7C194CF45992E4B8C6D25557A3809(L_0, /*hidden argument*/NULL);
		V_0 = L_1;
		goto IL_000a;
	}

IL_000a:
	{
		String_t* L_2 = V_0;
		return L_2;
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
// System.Boolean UnityEngine.Purchasing.MiniJSON.Json_Parser::IsWordBreak(System.Char)
extern "C" IL2CPP_METHOD_ATTR bool Parser_IsWordBreak_m395241B2FB531CE679C9BBDE1784EA50D937D210 (Il2CppChar ___c0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Parser_IsWordBreak_m395241B2FB531CE679C9BBDE1784EA50D937D210_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	int32_t G_B3_0 = 0;
	{
		Il2CppChar L_0 = ___c0;
		IL2CPP_RUNTIME_CLASS_INIT(Char_tBF22D9FC341BE970735250BB6FF1A4A92BBA58B9_il2cpp_TypeInfo_var);
		bool L_1 = Char_IsWhiteSpace_m8AE1C4157A1E1D8F5022630F4229AB26223BDC6B(L_0, /*hidden argument*/NULL);
		if (L_1)
		{
			goto IL_001c;
		}
	}
	{
		Il2CppChar L_2 = ___c0;
		NullCheck(_stringLiteral21AE27F947EF77236FD5E0029FDFE3E0913B464B);
		int32_t L_3 = String_IndexOf_m2909B8CF585E1BD0C81E11ACA2F48012156FD5BD(_stringLiteral21AE27F947EF77236FD5E0029FDFE3E0913B464B, L_2, /*hidden argument*/NULL);
		G_B3_0 = ((((int32_t)((((int32_t)L_3) == ((int32_t)(-1)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_001d;
	}

IL_001c:
	{
		G_B3_0 = 1;
	}

IL_001d:
	{
		V_0 = (bool)G_B3_0;
		goto IL_0020;
	}

IL_0020:
	{
		bool L_4 = V_0;
		return L_4;
	}
}
// System.Void UnityEngine.Purchasing.MiniJSON.Json_Parser::.ctor(System.String)
extern "C" IL2CPP_METHOD_ATTR void Parser__ctor_m3D3193C5644C380E18422E83B0F0E3F8E7D78E70 (Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * __this, String_t* ___jsonString0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Parser__ctor_m3D3193C5644C380E18422E83B0F0E3F8E7D78E70_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Object__ctor_m925ECA5E85CA100E3FB86A4F9E15C120E9A184C0(__this, /*hidden argument*/NULL);
		String_t* L_0 = ___jsonString0;
		StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12 * L_1 = (StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12 *)il2cpp_codegen_object_new(StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12_il2cpp_TypeInfo_var);
		StringReader__ctor_mA55383C19EFBC075E762145D88F15A2B8B0CDA17(L_1, L_0, /*hidden argument*/NULL);
		__this->set_json_0(L_1);
		return;
	}
}
// System.Object UnityEngine.Purchasing.MiniJSON.Json_Parser::Parse(System.String)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * Parser_Parse_mFDB5642E0F39901529C00E41650C0E40384996C5 (String_t* ___jsonString0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Parser_Parse_mFDB5642E0F39901529C00E41650C0E40384996C5_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * V_0 = NULL;
	RuntimeObject * V_1 = NULL;
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	void* __leave_targets_storage = alloca(sizeof(int32_t) * 1);
	il2cpp::utils::LeaveTargetStack __leave_targets(__leave_targets_storage);
	NO_UNUSED_WARNING (__leave_targets);
	{
		String_t* L_0 = ___jsonString0;
		Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * L_1 = (Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 *)il2cpp_codegen_object_new(Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543_il2cpp_TypeInfo_var);
		Parser__ctor_m3D3193C5644C380E18422E83B0F0E3F8E7D78E70(L_1, L_0, /*hidden argument*/NULL);
		V_0 = L_1;
	}

IL_0008:
	try
	{ // begin try (depth: 1)
		Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * L_2 = V_0;
		NullCheck(L_2);
		RuntimeObject * L_3 = Parser_ParseValue_m730210460220F67469844AB7ABB37A994D359698(L_2, /*hidden argument*/NULL);
		V_1 = L_3;
		IL2CPP_LEAVE(0x1D, FINALLY_0012);
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_0012;
	}

FINALLY_0012:
	{ // begin finally (depth: 1)
		{
			Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * L_4 = V_0;
			if (!L_4)
			{
				goto IL_001c;
			}
		}

IL_0015:
		{
			Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * L_5 = V_0;
			NullCheck(L_5);
			InterfaceActionInvoker0::Invoke(0 /* System.Void System.IDisposable::Dispose() */, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var, L_5);
		}

IL_001c:
		{
			IL2CPP_END_FINALLY(18)
		}
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(18)
	{
		IL2CPP_JUMP_TBL(0x1D, IL_001d)
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
	}

IL_001d:
	{
		RuntimeObject * L_6 = V_1;
		return L_6;
	}
}
// System.Void UnityEngine.Purchasing.MiniJSON.Json_Parser::Dispose()
extern "C" IL2CPP_METHOD_ATTR void Parser_Dispose_m44C3CAFDAE9D35BD6AB2369C3CECA26076BD4DB5 (Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * __this, const RuntimeMethod* method)
{
	{
		StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12 * L_0 = __this->get_json_0();
		NullCheck(L_0);
		TextReader_Dispose_m9DA31CD42D5E73A1452F4EEC014C5703B5872930(L_0, /*hidden argument*/NULL);
		__this->set_json_0((StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12 *)NULL);
		return;
	}
}
// System.Collections.Generic.Dictionary`2<System.String,System.Object> UnityEngine.Purchasing.MiniJSON.Json_Parser::ParseObject()
extern "C" IL2CPP_METHOD_ATTR Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * Parser_ParseObject_m5A34882277CE52DF62AB0CA09CEA3005716398FF (Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Parser_ParseObject_m5A34882277CE52DF62AB0CA09CEA3005716398FF_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * V_0 = NULL;
	int32_t V_1 = 0;
	String_t* V_2 = NULL;
	Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * V_3 = NULL;
	bool V_4 = false;
	bool V_5 = false;
	bool V_6 = false;
	{
		Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * L_0 = (Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA *)il2cpp_codegen_object_new(Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA_il2cpp_TypeInfo_var);
		Dictionary_2__ctor_mCA7075EA6548A18B929368520217975094841997(L_0, /*hidden argument*/Dictionary_2__ctor_mCA7075EA6548A18B929368520217975094841997_RuntimeMethod_var);
		V_0 = L_0;
		StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12 * L_1 = __this->get_json_0();
		NullCheck(L_1);
		VirtFuncInvoker0< int32_t >::Invoke(10 /* System.Int32 System.IO.TextReader::Read() */, L_1);
		goto IL_0082;
	}

IL_0015:
	{
		int32_t L_2 = Parser_get_NextToken_m0B0637C375655D15C6D9C4BDEDF2A2A9E6DA69CE(__this, /*hidden argument*/NULL);
		V_1 = L_2;
		int32_t L_3 = V_1;
		if (!L_3)
		{
			goto IL_002e;
		}
	}
	{
		goto IL_0022;
	}

IL_0022:
	{
		int32_t L_4 = V_1;
		if ((((int32_t)L_4) == ((int32_t)2)))
		{
			goto IL_0034;
		}
	}
	{
		goto IL_0028;
	}

IL_0028:
	{
		int32_t L_5 = V_1;
		if ((((int32_t)L_5) == ((int32_t)6)))
		{
			goto IL_0032;
		}
	}
	{
		goto IL_0038;
	}

IL_002e:
	{
		V_3 = (Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA *)NULL;
		goto IL_0087;
	}

IL_0032:
	{
		goto IL_0082;
	}

IL_0034:
	{
		Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * L_6 = V_0;
		V_3 = L_6;
		goto IL_0087;
	}

IL_0038:
	{
		String_t* L_7 = Parser_ParseString_mB6994A848988FDCE117674ABC2F085E460B12635(__this, /*hidden argument*/NULL);
		V_2 = L_7;
		String_t* L_8 = V_2;
		V_4 = (bool)((((RuntimeObject*)(String_t*)L_8) == ((RuntimeObject*)(RuntimeObject *)NULL))? 1 : 0);
		bool L_9 = V_4;
		if (!L_9)
		{
			goto IL_004e;
		}
	}
	{
		V_3 = (Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA *)NULL;
		goto IL_0087;
	}

IL_004e:
	{
		int32_t L_10 = Parser_get_NextToken_m0B0637C375655D15C6D9C4BDEDF2A2A9E6DA69CE(__this, /*hidden argument*/NULL);
		V_5 = (bool)((((int32_t)((((int32_t)L_10) == ((int32_t)5))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_11 = V_5;
		if (!L_11)
		{
			goto IL_0065;
		}
	}
	{
		V_3 = (Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA *)NULL;
		goto IL_0087;
	}

IL_0065:
	{
		StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12 * L_12 = __this->get_json_0();
		NullCheck(L_12);
		VirtFuncInvoker0< int32_t >::Invoke(10 /* System.Int32 System.IO.TextReader::Read() */, L_12);
		Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * L_13 = V_0;
		String_t* L_14 = V_2;
		RuntimeObject * L_15 = Parser_ParseValue_m730210460220F67469844AB7ABB37A994D359698(__this, /*hidden argument*/NULL);
		NullCheck(L_13);
		Dictionary_2_set_Item_mEA41AEAE79570A9410777F6B90969532564025DD(L_13, L_14, L_15, /*hidden argument*/Dictionary_2_set_Item_mEA41AEAE79570A9410777F6B90969532564025DD_RuntimeMethod_var);
		goto IL_0081;
	}

IL_0081:
	{
	}

IL_0082:
	{
		V_6 = (bool)1;
		goto IL_0015;
	}

IL_0087:
	{
		Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * L_16 = V_3;
		return L_16;
	}
}
// System.Collections.Generic.List`1<System.Object> UnityEngine.Purchasing.MiniJSON.Json_Parser::ParseArray()
extern "C" IL2CPP_METHOD_ATTR List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * Parser_ParseArray_m12FC39460D64ACE1AE58275BCEA66644DD28BBF2 (Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Parser_ParseArray_m12FC39460D64ACE1AE58275BCEA66644DD28BBF2_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * V_0 = NULL;
	bool V_1 = false;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	RuntimeObject * V_4 = NULL;
	List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * V_5 = NULL;
	bool V_6 = false;
	{
		List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * L_0 = (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D *)il2cpp_codegen_object_new(List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D_il2cpp_TypeInfo_var);
		List_1__ctor_mC832F1AC0F814BAEB19175F5D7972A7507508BC3(L_0, /*hidden argument*/List_1__ctor_mC832F1AC0F814BAEB19175F5D7972A7507508BC3_RuntimeMethod_var);
		V_0 = L_0;
		StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12 * L_1 = __this->get_json_0();
		NullCheck(L_1);
		VirtFuncInvoker0< int32_t >::Invoke(10 /* System.Int32 System.IO.TextReader::Read() */, L_1);
		V_1 = (bool)1;
		goto IL_0052;
	}

IL_0017:
	{
		int32_t L_2 = Parser_get_NextToken_m0B0637C375655D15C6D9C4BDEDF2A2A9E6DA69CE(__this, /*hidden argument*/NULL);
		V_2 = L_2;
		int32_t L_3 = V_2;
		V_3 = L_3;
		int32_t L_4 = V_3;
		if (!L_4)
		{
			goto IL_0032;
		}
	}
	{
		goto IL_0026;
	}

IL_0026:
	{
		int32_t L_5 = V_3;
		if ((((int32_t)L_5) == ((int32_t)4)))
		{
			goto IL_0039;
		}
	}
	{
		goto IL_002c;
	}

IL_002c:
	{
		int32_t L_6 = V_3;
		if ((((int32_t)L_6) == ((int32_t)6)))
		{
			goto IL_0037;
		}
	}
	{
		goto IL_003d;
	}

IL_0032:
	{
		V_5 = (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D *)NULL;
		goto IL_005e;
	}

IL_0037:
	{
		goto IL_0052;
	}

IL_0039:
	{
		V_1 = (bool)0;
		goto IL_0051;
	}

IL_003d:
	{
		int32_t L_7 = V_2;
		RuntimeObject * L_8 = Parser_ParseByToken_mF99905D919F1D2A54466793D3D938043E10AE5BA(__this, L_7, /*hidden argument*/NULL);
		V_4 = L_8;
		List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * L_9 = V_0;
		RuntimeObject * L_10 = V_4;
		NullCheck(L_9);
		List_1_Add_m6930161974C7504C80F52EC379EF012387D43138(L_9, L_10, /*hidden argument*/List_1_Add_m6930161974C7504C80F52EC379EF012387D43138_RuntimeMethod_var);
		goto IL_0051;
	}

IL_0051:
	{
	}

IL_0052:
	{
		bool L_11 = V_1;
		V_6 = L_11;
		bool L_12 = V_6;
		if (L_12)
		{
			goto IL_0017;
		}
	}
	{
		List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * L_13 = V_0;
		V_5 = L_13;
		goto IL_005e;
	}

IL_005e:
	{
		List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * L_14 = V_5;
		return L_14;
	}
}
// System.Object UnityEngine.Purchasing.MiniJSON.Json_Parser::ParseValue()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * Parser_ParseValue_m730210460220F67469844AB7ABB37A994D359698 (Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * __this, const RuntimeMethod* method)
{
	int32_t V_0 = 0;
	RuntimeObject * V_1 = NULL;
	{
		int32_t L_0 = Parser_get_NextToken_m0B0637C375655D15C6D9C4BDEDF2A2A9E6DA69CE(__this, /*hidden argument*/NULL);
		V_0 = L_0;
		int32_t L_1 = V_0;
		RuntimeObject * L_2 = Parser_ParseByToken_mF99905D919F1D2A54466793D3D938043E10AE5BA(__this, L_1, /*hidden argument*/NULL);
		V_1 = L_2;
		goto IL_0012;
	}

IL_0012:
	{
		RuntimeObject * L_3 = V_1;
		return L_3;
	}
}
// System.Object UnityEngine.Purchasing.MiniJSON.Json_Parser::ParseByToken(UnityEngine.Purchasing.MiniJSON.Json_Parser_TOKEN)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * Parser_ParseByToken_mF99905D919F1D2A54466793D3D938043E10AE5BA (Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * __this, int32_t ___token0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Parser_ParseByToken_mF99905D919F1D2A54466793D3D938043E10AE5BA_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	RuntimeObject * V_1 = NULL;
	{
		int32_t L_0 = ___token0;
		V_0 = L_0;
		int32_t L_1 = V_0;
		switch (((int32_t)il2cpp_codegen_subtract((int32_t)L_1, (int32_t)1)))
		{
			case 0:
			{
				goto IL_004b;
			}
			case 1:
			{
				goto IL_0073;
			}
			case 2:
			{
				goto IL_0054;
			}
			case 3:
			{
				goto IL_0073;
			}
			case 4:
			{
				goto IL_0073;
			}
			case 5:
			{
				goto IL_0073;
			}
			case 6:
			{
				goto IL_0039;
			}
			case 7:
			{
				goto IL_0042;
			}
			case 8:
			{
				goto IL_005d;
			}
			case 9:
			{
				goto IL_0066;
			}
			case 10:
			{
				goto IL_006f;
			}
		}
	}
	{
		goto IL_0073;
	}

IL_0039:
	{
		String_t* L_2 = Parser_ParseString_mB6994A848988FDCE117674ABC2F085E460B12635(__this, /*hidden argument*/NULL);
		V_1 = L_2;
		goto IL_0077;
	}

IL_0042:
	{
		RuntimeObject * L_3 = Parser_ParseNumber_m244426CB90761E4326DD8678646DE2715929077F(__this, /*hidden argument*/NULL);
		V_1 = L_3;
		goto IL_0077;
	}

IL_004b:
	{
		Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * L_4 = Parser_ParseObject_m5A34882277CE52DF62AB0CA09CEA3005716398FF(__this, /*hidden argument*/NULL);
		V_1 = L_4;
		goto IL_0077;
	}

IL_0054:
	{
		List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * L_5 = Parser_ParseArray_m12FC39460D64ACE1AE58275BCEA66644DD28BBF2(__this, /*hidden argument*/NULL);
		V_1 = L_5;
		goto IL_0077;
	}

IL_005d:
	{
		bool L_6 = ((bool)1);
		RuntimeObject * L_7 = Box(Boolean_tB53F6830F670160873277339AA58F15CAED4399C_il2cpp_TypeInfo_var, &L_6);
		V_1 = L_7;
		goto IL_0077;
	}

IL_0066:
	{
		bool L_8 = ((bool)0);
		RuntimeObject * L_9 = Box(Boolean_tB53F6830F670160873277339AA58F15CAED4399C_il2cpp_TypeInfo_var, &L_8);
		V_1 = L_9;
		goto IL_0077;
	}

IL_006f:
	{
		V_1 = NULL;
		goto IL_0077;
	}

IL_0073:
	{
		V_1 = NULL;
		goto IL_0077;
	}

IL_0077:
	{
		RuntimeObject * L_10 = V_1;
		return L_10;
	}
}
// System.String UnityEngine.Purchasing.MiniJSON.Json_Parser::ParseString()
extern "C" IL2CPP_METHOD_ATTR String_t* Parser_ParseString_mB6994A848988FDCE117674ABC2F085E460B12635 (Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Parser_ParseString_mB6994A848988FDCE117674ABC2F085E460B12635_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	StringBuilder_t * V_0 = NULL;
	Il2CppChar V_1 = 0x0;
	bool V_2 = false;
	bool V_3 = false;
	Il2CppChar V_4 = 0x0;
	bool V_5 = false;
	Il2CppChar V_6 = 0x0;
	CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* V_7 = NULL;
	int32_t V_8 = 0;
	bool V_9 = false;
	bool V_10 = false;
	String_t* V_11 = NULL;
	{
		StringBuilder_t * L_0 = (StringBuilder_t *)il2cpp_codegen_object_new(StringBuilder_t_il2cpp_TypeInfo_var);
		StringBuilder__ctor_mF928376F82E8C8FF3C11842C562DB8CF28B2735E(L_0, /*hidden argument*/NULL);
		V_0 = L_0;
		StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12 * L_1 = __this->get_json_0();
		NullCheck(L_1);
		VirtFuncInvoker0< int32_t >::Invoke(10 /* System.Int32 System.IO.TextReader::Read() */, L_1);
		V_2 = (bool)1;
		goto IL_0170;
	}

IL_001a:
	{
		StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12 * L_2 = __this->get_json_0();
		NullCheck(L_2);
		int32_t L_3 = VirtFuncInvoker0< int32_t >::Invoke(9 /* System.Int32 System.IO.TextReader::Peek() */, L_2);
		V_3 = (bool)((((int32_t)L_3) == ((int32_t)(-1)))? 1 : 0);
		bool L_4 = V_3;
		if (!L_4)
		{
			goto IL_0035;
		}
	}
	{
		V_2 = (bool)0;
		goto IL_017a;
	}

IL_0035:
	{
		Il2CppChar L_5 = Parser_get_NextChar_mB16EDBEAEFDF5B7AB13A22E5420B9BAF3FB8B4B2(__this, /*hidden argument*/NULL);
		V_1 = L_5;
		Il2CppChar L_6 = V_1;
		V_4 = L_6;
		Il2CppChar L_7 = V_4;
		if ((((int32_t)L_7) == ((int32_t)((int32_t)34))))
		{
			goto IL_0052;
		}
	}
	{
		goto IL_0047;
	}

IL_0047:
	{
		Il2CppChar L_8 = V_4;
		if ((((int32_t)L_8) == ((int32_t)((int32_t)92))))
		{
			goto IL_0059;
		}
	}
	{
		goto IL_0165;
	}

IL_0052:
	{
		V_2 = (bool)0;
		goto IL_016f;
	}

IL_0059:
	{
		StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12 * L_9 = __this->get_json_0();
		NullCheck(L_9);
		int32_t L_10 = VirtFuncInvoker0< int32_t >::Invoke(9 /* System.Int32 System.IO.TextReader::Peek() */, L_9);
		V_5 = (bool)((((int32_t)L_10) == ((int32_t)(-1)))? 1 : 0);
		bool L_11 = V_5;
		if (!L_11)
		{
			goto IL_0075;
		}
	}
	{
		V_2 = (bool)0;
		goto IL_016f;
	}

IL_0075:
	{
		Il2CppChar L_12 = Parser_get_NextChar_mB16EDBEAEFDF5B7AB13A22E5420B9BAF3FB8B4B2(__this, /*hidden argument*/NULL);
		V_1 = L_12;
		Il2CppChar L_13 = V_1;
		V_6 = L_13;
		Il2CppChar L_14 = V_6;
		if ((!(((uint32_t)L_14) <= ((uint32_t)((int32_t)92)))))
		{
			goto IL_00a0;
		}
	}
	{
		Il2CppChar L_15 = V_6;
		if ((((int32_t)L_15) == ((int32_t)((int32_t)34))))
		{
			goto IL_00e0;
		}
	}
	{
		goto IL_008d;
	}

IL_008d:
	{
		Il2CppChar L_16 = V_6;
		if ((((int32_t)L_16) == ((int32_t)((int32_t)47))))
		{
			goto IL_00e0;
		}
	}
	{
		goto IL_0095;
	}

IL_0095:
	{
		Il2CppChar L_17 = V_6;
		if ((((int32_t)L_17) == ((int32_t)((int32_t)92))))
		{
			goto IL_00e0;
		}
	}
	{
		goto IL_0163;
	}

IL_00a0:
	{
		Il2CppChar L_18 = V_6;
		if ((!(((uint32_t)L_18) <= ((uint32_t)((int32_t)102)))))
		{
			goto IL_00b9;
		}
	}
	{
		Il2CppChar L_19 = V_6;
		if ((((int32_t)L_19) == ((int32_t)((int32_t)98))))
		{
			goto IL_00ea;
		}
	}
	{
		goto IL_00ae;
	}

IL_00ae:
	{
		Il2CppChar L_20 = V_6;
		if ((((int32_t)L_20) == ((int32_t)((int32_t)102))))
		{
			goto IL_00f4;
		}
	}
	{
		goto IL_0163;
	}

IL_00b9:
	{
		Il2CppChar L_21 = V_6;
		if ((((int32_t)L_21) == ((int32_t)((int32_t)110))))
		{
			goto IL_00ff;
		}
	}
	{
		goto IL_00c1;
	}

IL_00c1:
	{
		Il2CppChar L_22 = V_6;
		switch (((int32_t)il2cpp_codegen_subtract((int32_t)L_22, (int32_t)((int32_t)114))))
		{
			case 0:
			{
				goto IL_010a;
			}
			case 1:
			{
				goto IL_0163;
			}
			case 2:
			{
				goto IL_0115;
			}
			case 3:
			{
				goto IL_0120;
			}
		}
	}
	{
		goto IL_0163;
	}

IL_00e0:
	{
		StringBuilder_t * L_23 = V_0;
		Il2CppChar L_24 = V_1;
		NullCheck(L_23);
		StringBuilder_Append_m05C12F58ADC2D807613A9301DF438CB3CD09B75A(L_23, L_24, /*hidden argument*/NULL);
		goto IL_0163;
	}

IL_00ea:
	{
		StringBuilder_t * L_25 = V_0;
		NullCheck(L_25);
		StringBuilder_Append_m05C12F58ADC2D807613A9301DF438CB3CD09B75A(L_25, 8, /*hidden argument*/NULL);
		goto IL_0163;
	}

IL_00f4:
	{
		StringBuilder_t * L_26 = V_0;
		NullCheck(L_26);
		StringBuilder_Append_m05C12F58ADC2D807613A9301DF438CB3CD09B75A(L_26, ((int32_t)12), /*hidden argument*/NULL);
		goto IL_0163;
	}

IL_00ff:
	{
		StringBuilder_t * L_27 = V_0;
		NullCheck(L_27);
		StringBuilder_Append_m05C12F58ADC2D807613A9301DF438CB3CD09B75A(L_27, ((int32_t)10), /*hidden argument*/NULL);
		goto IL_0163;
	}

IL_010a:
	{
		StringBuilder_t * L_28 = V_0;
		NullCheck(L_28);
		StringBuilder_Append_m05C12F58ADC2D807613A9301DF438CB3CD09B75A(L_28, ((int32_t)13), /*hidden argument*/NULL);
		goto IL_0163;
	}

IL_0115:
	{
		StringBuilder_t * L_29 = V_0;
		NullCheck(L_29);
		StringBuilder_Append_m05C12F58ADC2D807613A9301DF438CB3CD09B75A(L_29, ((int32_t)9), /*hidden argument*/NULL);
		goto IL_0163;
	}

IL_0120:
	{
		CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* L_30 = (CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2*)SZArrayNew(CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2_il2cpp_TypeInfo_var, (uint32_t)4);
		V_7 = L_30;
		V_8 = 0;
		goto IL_0140;
	}

IL_012d:
	{
		CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* L_31 = V_7;
		int32_t L_32 = V_8;
		Il2CppChar L_33 = Parser_get_NextChar_mB16EDBEAEFDF5B7AB13A22E5420B9BAF3FB8B4B2(__this, /*hidden argument*/NULL);
		NullCheck(L_31);
		(L_31)->SetAt(static_cast<il2cpp_array_size_t>(L_32), (Il2CppChar)L_33);
		int32_t L_34 = V_8;
		V_8 = ((int32_t)il2cpp_codegen_add((int32_t)L_34, (int32_t)1));
	}

IL_0140:
	{
		int32_t L_35 = V_8;
		V_9 = (bool)((((int32_t)L_35) < ((int32_t)4))? 1 : 0);
		bool L_36 = V_9;
		if (L_36)
		{
			goto IL_012d;
		}
	}
	{
		StringBuilder_t * L_37 = V_0;
		CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* L_38 = V_7;
		String_t* L_39 = String_CreateString_m394C06654854ADD4C51FF957BE0CC72EF52BAA96(NULL, L_38, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Convert_t1C7A851BFB2F0782FD7F72F6AA1DCBB7B53A9C7E_il2cpp_TypeInfo_var);
		int32_t L_40 = Convert_ToInt32_m8DC81C7C49EE4A9334E71E45E3A220644E45B4F4(L_39, ((int32_t)16), /*hidden argument*/NULL);
		NullCheck(L_37);
		StringBuilder_Append_m05C12F58ADC2D807613A9301DF438CB3CD09B75A(L_37, (((int32_t)((uint16_t)L_40))), /*hidden argument*/NULL);
		goto IL_0163;
	}

IL_0163:
	{
		goto IL_016f;
	}

IL_0165:
	{
		StringBuilder_t * L_41 = V_0;
		Il2CppChar L_42 = V_1;
		NullCheck(L_41);
		StringBuilder_Append_m05C12F58ADC2D807613A9301DF438CB3CD09B75A(L_41, L_42, /*hidden argument*/NULL);
		goto IL_016f;
	}

IL_016f:
	{
	}

IL_0170:
	{
		bool L_43 = V_2;
		V_10 = L_43;
		bool L_44 = V_10;
		if (L_44)
		{
			goto IL_001a;
		}
	}

IL_017a:
	{
		StringBuilder_t * L_45 = V_0;
		NullCheck(L_45);
		String_t* L_46 = VirtFuncInvoker0< String_t* >::Invoke(3 /* System.String System.Object::ToString() */, L_45);
		V_11 = L_46;
		goto IL_0184;
	}

IL_0184:
	{
		String_t* L_47 = V_11;
		return L_47;
	}
}
// System.Object UnityEngine.Purchasing.MiniJSON.Json_Parser::ParseNumber()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * Parser_ParseNumber_m244426CB90761E4326DD8678646DE2715929077F (Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Parser_ParseNumber_m244426CB90761E4326DD8678646DE2715929077F_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	String_t* V_0 = NULL;
	double V_1 = 0.0;
	bool V_2 = false;
	int64_t V_3 = 0;
	RuntimeObject * V_4 = NULL;
	int32_t G_B4_0 = 0;
	{
		String_t* L_0 = Parser_get_NextWord_m6D4BE7C1F45368E40593F0F712B80DD40D1E9034(__this, /*hidden argument*/NULL);
		V_0 = L_0;
		String_t* L_1 = V_0;
		NullCheck(L_1);
		int32_t L_2 = String_IndexOf_m2909B8CF585E1BD0C81E11ACA2F48012156FD5BD(L_1, ((int32_t)46), /*hidden argument*/NULL);
		if ((!(((uint32_t)L_2) == ((uint32_t)(-1)))))
		{
			goto IL_002b;
		}
	}
	{
		String_t* L_3 = V_0;
		NullCheck(L_3);
		int32_t L_4 = String_IndexOf_m2909B8CF585E1BD0C81E11ACA2F48012156FD5BD(L_3, ((int32_t)101), /*hidden argument*/NULL);
		if ((!(((uint32_t)L_4) == ((uint32_t)(-1)))))
		{
			goto IL_002b;
		}
	}
	{
		String_t* L_5 = V_0;
		NullCheck(L_5);
		int32_t L_6 = String_IndexOf_m2909B8CF585E1BD0C81E11ACA2F48012156FD5BD(L_5, ((int32_t)69), /*hidden argument*/NULL);
		G_B4_0 = ((((int32_t)L_6) == ((int32_t)(-1)))? 1 : 0);
		goto IL_002c;
	}

IL_002b:
	{
		G_B4_0 = 0;
	}

IL_002c:
	{
		V_2 = (bool)G_B4_0;
		bool L_7 = V_2;
		if (!L_7)
		{
			goto IL_004e;
		}
	}
	{
		String_t* L_8 = V_0;
		IL2CPP_RUNTIME_CLASS_INIT(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_il2cpp_TypeInfo_var);
		CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * L_9 = CultureInfo_get_InvariantCulture_mF13B47F8A763CE6A9C8A8BB2EED33FF8F7A63A72(/*hidden argument*/NULL);
		Int64_TryParse_m8CE5F89833C03A091273A4EF48C69E86E1F81ACC(L_8, ((int32_t)511), L_9, (int64_t*)(&V_3), /*hidden argument*/NULL);
		int64_t L_10 = V_3;
		int64_t L_11 = L_10;
		RuntimeObject * L_12 = Box(Int64_t7A386C2FF7B0280A0F516992401DDFCF0FF7B436_il2cpp_TypeInfo_var, &L_11);
		V_4 = L_12;
		goto IL_006b;
	}

IL_004e:
	{
		String_t* L_13 = V_0;
		IL2CPP_RUNTIME_CLASS_INIT(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_il2cpp_TypeInfo_var);
		CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * L_14 = CultureInfo_get_InvariantCulture_mF13B47F8A763CE6A9C8A8BB2EED33FF8F7A63A72(/*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Double_t358B8F23BDC52A5DD700E727E204F9F7CDE12409_il2cpp_TypeInfo_var);
		Double_TryParse_m1A7BCBA90DE896E448E3CA09AAD1CA43846567D7(L_13, ((int32_t)511), L_14, (double*)(&V_1), /*hidden argument*/NULL);
		double L_15 = V_1;
		double L_16 = L_15;
		RuntimeObject * L_17 = Box(Double_t358B8F23BDC52A5DD700E727E204F9F7CDE12409_il2cpp_TypeInfo_var, &L_16);
		V_4 = L_17;
		goto IL_006b;
	}

IL_006b:
	{
		RuntimeObject * L_18 = V_4;
		return L_18;
	}
}
// System.Void UnityEngine.Purchasing.MiniJSON.Json_Parser::EatWhitespace()
extern "C" IL2CPP_METHOD_ATTR void Parser_EatWhitespace_m8A09F4A69DD67898D517E9772A47500CF798548F (Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Parser_EatWhitespace_m8A09F4A69DD67898D517E9772A47500CF798548F_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	bool V_1 = false;
	{
		goto IL_0026;
	}

IL_0003:
	{
		StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12 * L_0 = __this->get_json_0();
		NullCheck(L_0);
		VirtFuncInvoker0< int32_t >::Invoke(10 /* System.Int32 System.IO.TextReader::Read() */, L_0);
		StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12 * L_1 = __this->get_json_0();
		NullCheck(L_1);
		int32_t L_2 = VirtFuncInvoker0< int32_t >::Invoke(9 /* System.Int32 System.IO.TextReader::Peek() */, L_1);
		V_0 = (bool)((((int32_t)L_2) == ((int32_t)(-1)))? 1 : 0);
		bool L_3 = V_0;
		if (!L_3)
		{
			goto IL_0025;
		}
	}
	{
		goto IL_0035;
	}

IL_0025:
	{
	}

IL_0026:
	{
		Il2CppChar L_4 = Parser_get_PeekChar_mC4F636B592D572D313318820C35D3B8A70661931(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Char_tBF22D9FC341BE970735250BB6FF1A4A92BBA58B9_il2cpp_TypeInfo_var);
		bool L_5 = Char_IsWhiteSpace_m8AE1C4157A1E1D8F5022630F4229AB26223BDC6B(L_4, /*hidden argument*/NULL);
		V_1 = L_5;
		bool L_6 = V_1;
		if (L_6)
		{
			goto IL_0003;
		}
	}

IL_0035:
	{
		return;
	}
}
// System.Char UnityEngine.Purchasing.MiniJSON.Json_Parser::get_PeekChar()
extern "C" IL2CPP_METHOD_ATTR Il2CppChar Parser_get_PeekChar_mC4F636B592D572D313318820C35D3B8A70661931 (Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Parser_get_PeekChar_mC4F636B592D572D313318820C35D3B8A70661931_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Il2CppChar V_0 = 0x0;
	{
		StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12 * L_0 = __this->get_json_0();
		NullCheck(L_0);
		int32_t L_1 = VirtFuncInvoker0< int32_t >::Invoke(9 /* System.Int32 System.IO.TextReader::Peek() */, L_0);
		IL2CPP_RUNTIME_CLASS_INIT(Convert_t1C7A851BFB2F0782FD7F72F6AA1DCBB7B53A9C7E_il2cpp_TypeInfo_var);
		Il2CppChar L_2 = Convert_ToChar_m5BD134B72978B879B81A824DFAC8FF29F5300245(L_1, /*hidden argument*/NULL);
		V_0 = L_2;
		goto IL_0014;
	}

IL_0014:
	{
		Il2CppChar L_3 = V_0;
		return L_3;
	}
}
// System.Char UnityEngine.Purchasing.MiniJSON.Json_Parser::get_NextChar()
extern "C" IL2CPP_METHOD_ATTR Il2CppChar Parser_get_NextChar_mB16EDBEAEFDF5B7AB13A22E5420B9BAF3FB8B4B2 (Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Parser_get_NextChar_mB16EDBEAEFDF5B7AB13A22E5420B9BAF3FB8B4B2_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Il2CppChar V_0 = 0x0;
	{
		StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12 * L_0 = __this->get_json_0();
		NullCheck(L_0);
		int32_t L_1 = VirtFuncInvoker0< int32_t >::Invoke(10 /* System.Int32 System.IO.TextReader::Read() */, L_0);
		IL2CPP_RUNTIME_CLASS_INIT(Convert_t1C7A851BFB2F0782FD7F72F6AA1DCBB7B53A9C7E_il2cpp_TypeInfo_var);
		Il2CppChar L_2 = Convert_ToChar_m5BD134B72978B879B81A824DFAC8FF29F5300245(L_1, /*hidden argument*/NULL);
		V_0 = L_2;
		goto IL_0014;
	}

IL_0014:
	{
		Il2CppChar L_3 = V_0;
		return L_3;
	}
}
// System.String UnityEngine.Purchasing.MiniJSON.Json_Parser::get_NextWord()
extern "C" IL2CPP_METHOD_ATTR String_t* Parser_get_NextWord_m6D4BE7C1F45368E40593F0F712B80DD40D1E9034 (Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Parser_get_NextWord_m6D4BE7C1F45368E40593F0F712B80DD40D1E9034_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	StringBuilder_t * V_0 = NULL;
	bool V_1 = false;
	bool V_2 = false;
	String_t* V_3 = NULL;
	{
		StringBuilder_t * L_0 = (StringBuilder_t *)il2cpp_codegen_object_new(StringBuilder_t_il2cpp_TypeInfo_var);
		StringBuilder__ctor_mF928376F82E8C8FF3C11842C562DB8CF28B2735E(L_0, /*hidden argument*/NULL);
		V_0 = L_0;
		goto IL_002d;
	}

IL_0009:
	{
		StringBuilder_t * L_1 = V_0;
		Il2CppChar L_2 = Parser_get_NextChar_mB16EDBEAEFDF5B7AB13A22E5420B9BAF3FB8B4B2(__this, /*hidden argument*/NULL);
		NullCheck(L_1);
		StringBuilder_Append_m05C12F58ADC2D807613A9301DF438CB3CD09B75A(L_1, L_2, /*hidden argument*/NULL);
		StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12 * L_3 = __this->get_json_0();
		NullCheck(L_3);
		int32_t L_4 = VirtFuncInvoker0< int32_t >::Invoke(9 /* System.Int32 System.IO.TextReader::Peek() */, L_3);
		V_1 = (bool)((((int32_t)L_4) == ((int32_t)(-1)))? 1 : 0);
		bool L_5 = V_1;
		if (!L_5)
		{
			goto IL_002c;
		}
	}
	{
		goto IL_003f;
	}

IL_002c:
	{
	}

IL_002d:
	{
		Il2CppChar L_6 = Parser_get_PeekChar_mC4F636B592D572D313318820C35D3B8A70661931(__this, /*hidden argument*/NULL);
		bool L_7 = Parser_IsWordBreak_m395241B2FB531CE679C9BBDE1784EA50D937D210(L_6, /*hidden argument*/NULL);
		V_2 = (bool)((((int32_t)L_7) == ((int32_t)0))? 1 : 0);
		bool L_8 = V_2;
		if (L_8)
		{
			goto IL_0009;
		}
	}

IL_003f:
	{
		StringBuilder_t * L_9 = V_0;
		NullCheck(L_9);
		String_t* L_10 = VirtFuncInvoker0< String_t* >::Invoke(3 /* System.String System.Object::ToString() */, L_9);
		V_3 = L_10;
		goto IL_0048;
	}

IL_0048:
	{
		String_t* L_11 = V_3;
		return L_11;
	}
}
// UnityEngine.Purchasing.MiniJSON.Json_Parser_TOKEN UnityEngine.Purchasing.MiniJSON.Json_Parser::get_NextToken()
extern "C" IL2CPP_METHOD_ATTR int32_t Parser_get_NextToken_m0B0637C375655D15C6D9C4BDEDF2A2A9E6DA69CE (Parser_tB549FB05B57D479E2DE2176A23323313AF3E4543 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Parser_get_NextToken_m0B0637C375655D15C6D9C4BDEDF2A2A9E6DA69CE_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	int32_t V_1 = 0;
	Il2CppChar V_2 = 0x0;
	String_t* V_3 = NULL;
	{
		Parser_EatWhitespace_m8A09F4A69DD67898D517E9772A47500CF798548F(__this, /*hidden argument*/NULL);
		StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12 * L_0 = __this->get_json_0();
		NullCheck(L_0);
		int32_t L_1 = VirtFuncInvoker0< int32_t >::Invoke(9 /* System.Int32 System.IO.TextReader::Peek() */, L_0);
		V_0 = (bool)((((int32_t)L_1) == ((int32_t)(-1)))? 1 : 0);
		bool L_2 = V_0;
		if (!L_2)
		{
			goto IL_0022;
		}
	}
	{
		V_1 = 0;
		goto IL_0143;
	}

IL_0022:
	{
		Il2CppChar L_3 = Parser_get_PeekChar_mC4F636B592D572D313318820C35D3B8A70661931(__this, /*hidden argument*/NULL);
		V_2 = L_3;
		Il2CppChar L_4 = V_2;
		if ((!(((uint32_t)L_4) <= ((uint32_t)((int32_t)91)))))
		{
			goto IL_00a4;
		}
	}
	{
		Il2CppChar L_5 = V_2;
		switch (((int32_t)il2cpp_codegen_subtract((int32_t)L_5, (int32_t)((int32_t)34))))
		{
			case 0:
			{
				goto IL_00f4;
			}
			case 1:
			{
				goto IL_0100;
			}
			case 2:
			{
				goto IL_0100;
			}
			case 3:
			{
				goto IL_0100;
			}
			case 4:
			{
				goto IL_0100;
			}
			case 5:
			{
				goto IL_0100;
			}
			case 6:
			{
				goto IL_0100;
			}
			case 7:
			{
				goto IL_0100;
			}
			case 8:
			{
				goto IL_0100;
			}
			case 9:
			{
				goto IL_0100;
			}
			case 10:
			{
				goto IL_00e4;
			}
			case 11:
			{
				goto IL_00fc;
			}
			case 12:
			{
				goto IL_0100;
			}
			case 13:
			{
				goto IL_0100;
			}
			case 14:
			{
				goto IL_00fc;
			}
			case 15:
			{
				goto IL_00fc;
			}
			case 16:
			{
				goto IL_00fc;
			}
			case 17:
			{
				goto IL_00fc;
			}
			case 18:
			{
				goto IL_00fc;
			}
			case 19:
			{
				goto IL_00fc;
			}
			case 20:
			{
				goto IL_00fc;
			}
			case 21:
			{
				goto IL_00fc;
			}
			case 22:
			{
				goto IL_00fc;
			}
			case 23:
			{
				goto IL_00fc;
			}
			case 24:
			{
				goto IL_00f8;
			}
		}
	}
	{
		goto IL_009d;
	}

IL_009d:
	{
		Il2CppChar L_6 = V_2;
		if ((((int32_t)L_6) == ((int32_t)((int32_t)91))))
		{
			goto IL_00d0;
		}
	}
	{
		goto IL_0100;
	}

IL_00a4:
	{
		Il2CppChar L_7 = V_2;
		if ((((int32_t)L_7) == ((int32_t)((int32_t)93))))
		{
			goto IL_00d4;
		}
	}
	{
		goto IL_00ab;
	}

IL_00ab:
	{
		Il2CppChar L_8 = V_2;
		if ((((int32_t)L_8) == ((int32_t)((int32_t)123))))
		{
			goto IL_00b9;
		}
	}
	{
		goto IL_00b2;
	}

IL_00b2:
	{
		Il2CppChar L_9 = V_2;
		if ((((int32_t)L_9) == ((int32_t)((int32_t)125))))
		{
			goto IL_00c0;
		}
	}
	{
		goto IL_0100;
	}

IL_00b9:
	{
		V_1 = 1;
		goto IL_0143;
	}

IL_00c0:
	{
		StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12 * L_10 = __this->get_json_0();
		NullCheck(L_10);
		VirtFuncInvoker0< int32_t >::Invoke(10 /* System.Int32 System.IO.TextReader::Read() */, L_10);
		V_1 = 2;
		goto IL_0143;
	}

IL_00d0:
	{
		V_1 = 3;
		goto IL_0143;
	}

IL_00d4:
	{
		StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12 * L_11 = __this->get_json_0();
		NullCheck(L_11);
		VirtFuncInvoker0< int32_t >::Invoke(10 /* System.Int32 System.IO.TextReader::Read() */, L_11);
		V_1 = 4;
		goto IL_0143;
	}

IL_00e4:
	{
		StringReader_t3095DEB3D26F40D1A7F9B76835D80AFE70E47E12 * L_12 = __this->get_json_0();
		NullCheck(L_12);
		VirtFuncInvoker0< int32_t >::Invoke(10 /* System.Int32 System.IO.TextReader::Read() */, L_12);
		V_1 = 6;
		goto IL_0143;
	}

IL_00f4:
	{
		V_1 = 7;
		goto IL_0143;
	}

IL_00f8:
	{
		V_1 = 5;
		goto IL_0143;
	}

IL_00fc:
	{
		V_1 = 8;
		goto IL_0143;
	}

IL_0100:
	{
		String_t* L_13 = Parser_get_NextWord_m6D4BE7C1F45368E40593F0F712B80DD40D1E9034(__this, /*hidden argument*/NULL);
		V_3 = L_13;
		String_t* L_14 = V_3;
		bool L_15 = String_op_Equality_m139F0E4195AE2F856019E63B241F36F016997FCE(L_14, _stringLiteral7CB6EFB98BA5972A9B5090DC2E517FE14D12CB04, /*hidden argument*/NULL);
		if (L_15)
		{
			goto IL_0130;
		}
	}
	{
		String_t* L_16 = V_3;
		bool L_17 = String_op_Equality_m139F0E4195AE2F856019E63B241F36F016997FCE(L_16, _stringLiteral5FFE533B830F08A0326348A9160AFAFC8ADA44DB, /*hidden argument*/NULL);
		if (L_17)
		{
			goto IL_0135;
		}
	}
	{
		String_t* L_18 = V_3;
		bool L_19 = String_op_Equality_m139F0E4195AE2F856019E63B241F36F016997FCE(L_18, _stringLiteral2BE88CA4242C76E8253AC62474851065032D6833, /*hidden argument*/NULL);
		if (L_19)
		{
			goto IL_013a;
		}
	}
	{
		goto IL_013f;
	}

IL_0130:
	{
		V_1 = ((int32_t)10);
		goto IL_0143;
	}

IL_0135:
	{
		V_1 = ((int32_t)9);
		goto IL_0143;
	}

IL_013a:
	{
		V_1 = ((int32_t)11);
		goto IL_0143;
	}

IL_013f:
	{
		V_1 = 0;
		goto IL_0143;
	}

IL_0143:
	{
		int32_t L_20 = V_1;
		return L_20;
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
// System.Void UnityEngine.Purchasing.MiniJSON.Json_Serializer::.ctor()
extern "C" IL2CPP_METHOD_ATTR void Serializer__ctor_m5596317D8D472AE91B9CC27CAF9241149191B796 (Serializer_t8E477D61E7D27FA878E7A6D57F4619E5C5B0611D * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Serializer__ctor_m5596317D8D472AE91B9CC27CAF9241149191B796_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Object__ctor_m925ECA5E85CA100E3FB86A4F9E15C120E9A184C0(__this, /*hidden argument*/NULL);
		StringBuilder_t * L_0 = (StringBuilder_t *)il2cpp_codegen_object_new(StringBuilder_t_il2cpp_TypeInfo_var);
		StringBuilder__ctor_mF928376F82E8C8FF3C11842C562DB8CF28B2735E(L_0, /*hidden argument*/NULL);
		__this->set_builder_0(L_0);
		return;
	}
}
// System.String UnityEngine.Purchasing.MiniJSON.Json_Serializer::Serialize(System.Object)
extern "C" IL2CPP_METHOD_ATTR String_t* Serializer_Serialize_m3ADBCAEE90D7C194CF45992E4B8C6D25557A3809 (RuntimeObject * ___obj0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Serializer_Serialize_m3ADBCAEE90D7C194CF45992E4B8C6D25557A3809_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Serializer_t8E477D61E7D27FA878E7A6D57F4619E5C5B0611D * V_0 = NULL;
	String_t* V_1 = NULL;
	{
		Serializer_t8E477D61E7D27FA878E7A6D57F4619E5C5B0611D * L_0 = (Serializer_t8E477D61E7D27FA878E7A6D57F4619E5C5B0611D *)il2cpp_codegen_object_new(Serializer_t8E477D61E7D27FA878E7A6D57F4619E5C5B0611D_il2cpp_TypeInfo_var);
		Serializer__ctor_m5596317D8D472AE91B9CC27CAF9241149191B796(L_0, /*hidden argument*/NULL);
		V_0 = L_0;
		Serializer_t8E477D61E7D27FA878E7A6D57F4619E5C5B0611D * L_1 = V_0;
		RuntimeObject * L_2 = ___obj0;
		NullCheck(L_1);
		Serializer_SerializeValue_mDA3C31227389EF6116A3D5490FDAB12CE3AC28DC(L_1, L_2, /*hidden argument*/NULL);
		Serializer_t8E477D61E7D27FA878E7A6D57F4619E5C5B0611D * L_3 = V_0;
		NullCheck(L_3);
		StringBuilder_t * L_4 = L_3->get_builder_0();
		NullCheck(L_4);
		String_t* L_5 = VirtFuncInvoker0< String_t* >::Invoke(3 /* System.String System.Object::ToString() */, L_4);
		V_1 = L_5;
		goto IL_001d;
	}

IL_001d:
	{
		String_t* L_6 = V_1;
		return L_6;
	}
}
// System.Void UnityEngine.Purchasing.MiniJSON.Json_Serializer::SerializeValue(System.Object)
extern "C" IL2CPP_METHOD_ATTR void Serializer_SerializeValue_mDA3C31227389EF6116A3D5490FDAB12CE3AC28DC (Serializer_t8E477D61E7D27FA878E7A6D57F4619E5C5B0611D * __this, RuntimeObject * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Serializer_SerializeValue_mDA3C31227389EF6116A3D5490FDAB12CE3AC28DC_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	RuntimeObject* V_0 = NULL;
	RuntimeObject* V_1 = NULL;
	String_t* V_2 = NULL;
	bool V_3 = false;
	bool V_4 = false;
	bool V_5 = false;
	bool V_6 = false;
	bool V_7 = false;
	bool V_8 = false;
	StringBuilder_t * G_B7_0 = NULL;
	StringBuilder_t * G_B6_0 = NULL;
	String_t* G_B8_0 = NULL;
	StringBuilder_t * G_B8_1 = NULL;
	{
		RuntimeObject * L_0 = ___value0;
		V_3 = (bool)((((RuntimeObject*)(RuntimeObject *)L_0) == ((RuntimeObject*)(RuntimeObject *)NULL))? 1 : 0);
		bool L_1 = V_3;
		if (!L_1)
		{
			goto IL_0021;
		}
	}
	{
		StringBuilder_t * L_2 = __this->get_builder_0();
		NullCheck(L_2);
		StringBuilder_Append_mDBB8CCBB7750C67BE2F2D92F47E6C0FA42793260(L_2, _stringLiteral2BE88CA4242C76E8253AC62474851065032D6833, /*hidden argument*/NULL);
		goto IL_00de;
	}

IL_0021:
	{
		RuntimeObject * L_3 = ___value0;
		String_t* L_4 = ((String_t*)IsInstSealed((RuntimeObject*)L_3, String_t_il2cpp_TypeInfo_var));
		V_2 = L_4;
		V_4 = (bool)((!(((RuntimeObject*)(String_t*)L_4) <= ((RuntimeObject*)(RuntimeObject *)NULL)))? 1 : 0);
		bool L_5 = V_4;
		if (!L_5)
		{
			goto IL_0041;
		}
	}
	{
		String_t* L_6 = V_2;
		Serializer_SerializeString_m71208E9D67CAB89BF60CE2CAA22264221B8110EE(__this, L_6, /*hidden argument*/NULL);
		goto IL_00de;
	}

IL_0041:
	{
		RuntimeObject * L_7 = ___value0;
		V_5 = (bool)((!(((RuntimeObject*)(RuntimeObject *)((RuntimeObject *)IsInstSealed((RuntimeObject*)L_7, Boolean_tB53F6830F670160873277339AA58F15CAED4399C_il2cpp_TypeInfo_var))) <= ((RuntimeObject*)(RuntimeObject *)NULL)))? 1 : 0);
		bool L_8 = V_5;
		if (!L_8)
		{
			goto IL_0074;
		}
	}
	{
		StringBuilder_t * L_9 = __this->get_builder_0();
		RuntimeObject * L_10 = ___value0;
		G_B6_0 = L_9;
		if (((*(bool*)((bool*)UnBox(L_10, Boolean_tB53F6830F670160873277339AA58F15CAED4399C_il2cpp_TypeInfo_var)))))
		{
			G_B7_0 = L_9;
			goto IL_0066;
		}
	}
	{
		G_B8_0 = _stringLiteral7CB6EFB98BA5972A9B5090DC2E517FE14D12CB04;
		G_B8_1 = G_B6_0;
		goto IL_006b;
	}

IL_0066:
	{
		G_B8_0 = _stringLiteral5FFE533B830F08A0326348A9160AFAFC8ADA44DB;
		G_B8_1 = G_B7_0;
	}

IL_006b:
	{
		NullCheck(G_B8_1);
		StringBuilder_Append_mDBB8CCBB7750C67BE2F2D92F47E6C0FA42793260(G_B8_1, G_B8_0, /*hidden argument*/NULL);
		goto IL_00de;
	}

IL_0074:
	{
		RuntimeObject * L_11 = ___value0;
		RuntimeObject* L_12 = ((RuntimeObject*)IsInst((RuntimeObject*)L_11, IList_tA637AB426E16F84F84ACC2813BDCF3A0414AF0AA_il2cpp_TypeInfo_var));
		V_0 = L_12;
		V_6 = (bool)((!(((RuntimeObject*)(RuntimeObject*)L_12) <= ((RuntimeObject*)(RuntimeObject *)NULL)))? 1 : 0);
		bool L_13 = V_6;
		if (!L_13)
		{
			goto IL_0091;
		}
	}
	{
		RuntimeObject* L_14 = V_0;
		Serializer_SerializeArray_mA4DB26A2353A1FE3838E765DB7A6F6B4E4460ECC(__this, L_14, /*hidden argument*/NULL);
		goto IL_00de;
	}

IL_0091:
	{
		RuntimeObject * L_15 = ___value0;
		RuntimeObject* L_16 = ((RuntimeObject*)IsInst((RuntimeObject*)L_15, IDictionary_t1BD5C1546718A374EA8122FBD6C6EE45331E8CE7_il2cpp_TypeInfo_var));
		V_1 = L_16;
		V_7 = (bool)((!(((RuntimeObject*)(RuntimeObject*)L_16) <= ((RuntimeObject*)(RuntimeObject *)NULL)))? 1 : 0);
		bool L_17 = V_7;
		if (!L_17)
		{
			goto IL_00ae;
		}
	}
	{
		RuntimeObject* L_18 = V_1;
		Serializer_SerializeObject_mFF26F5476F7F35A992B893E7A19717B972018A83(__this, L_18, /*hidden argument*/NULL);
		goto IL_00de;
	}

IL_00ae:
	{
		RuntimeObject * L_19 = ___value0;
		V_8 = (bool)((!(((RuntimeObject*)(RuntimeObject *)((RuntimeObject *)IsInstSealed((RuntimeObject*)L_19, Char_tBF22D9FC341BE970735250BB6FF1A4A92BBA58B9_il2cpp_TypeInfo_var))) <= ((RuntimeObject*)(RuntimeObject *)NULL)))? 1 : 0);
		bool L_20 = V_8;
		if (!L_20)
		{
			goto IL_00d4;
		}
	}
	{
		RuntimeObject * L_21 = ___value0;
		String_t* L_22 = String_CreateString_m0E7BBCE09E386877E2B63BF7FA36B956BF221C93(NULL, ((*(Il2CppChar*)((Il2CppChar*)UnBox(L_21, Char_tBF22D9FC341BE970735250BB6FF1A4A92BBA58B9_il2cpp_TypeInfo_var)))), 1, /*hidden argument*/NULL);
		Serializer_SerializeString_m71208E9D67CAB89BF60CE2CAA22264221B8110EE(__this, L_22, /*hidden argument*/NULL);
		goto IL_00de;
	}

IL_00d4:
	{
		RuntimeObject * L_23 = ___value0;
		Serializer_SerializeOther_m39DC0396BC829EDA0A4086E711BCF48BFDF79351(__this, L_23, /*hidden argument*/NULL);
	}

IL_00de:
	{
		return;
	}
}
// System.Void UnityEngine.Purchasing.MiniJSON.Json_Serializer::SerializeObject(System.Collections.IDictionary)
extern "C" IL2CPP_METHOD_ATTR void Serializer_SerializeObject_mFF26F5476F7F35A992B893E7A19717B972018A83 (Serializer_t8E477D61E7D27FA878E7A6D57F4619E5C5B0611D * __this, RuntimeObject* ___obj0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Serializer_SerializeObject_mFF26F5476F7F35A992B893E7A19717B972018A83_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	RuntimeObject* V_1 = NULL;
	RuntimeObject * V_2 = NULL;
	bool V_3 = false;
	RuntimeObject* V_4 = NULL;
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	void* __leave_targets_storage = alloca(sizeof(int32_t) * 1);
	il2cpp::utils::LeaveTargetStack __leave_targets(__leave_targets_storage);
	NO_UNUSED_WARNING (__leave_targets);
	{
		V_0 = (bool)1;
		StringBuilder_t * L_0 = __this->get_builder_0();
		NullCheck(L_0);
		StringBuilder_Append_m05C12F58ADC2D807613A9301DF438CB3CD09B75A(L_0, ((int32_t)123), /*hidden argument*/NULL);
		RuntimeObject* L_1 = ___obj0;
		NullCheck(L_1);
		RuntimeObject* L_2 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(2 /* System.Collections.ICollection System.Collections.IDictionary::get_Keys() */, IDictionary_t1BD5C1546718A374EA8122FBD6C6EE45331E8CE7_il2cpp_TypeInfo_var, L_1);
		NullCheck(L_2);
		RuntimeObject* L_3 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* System.Collections.IEnumerator System.Collections.IEnumerable::GetEnumerator() */, IEnumerable_tD74549CEA1AA48E768382B94FEACBB07E2E3FA2C_il2cpp_TypeInfo_var, L_2);
		V_1 = L_3;
	}

IL_001e:
	try
	{ // begin try (depth: 1)
		{
			goto IL_006c;
		}

IL_0020:
		{
			RuntimeObject* L_4 = V_1;
			NullCheck(L_4);
			RuntimeObject * L_5 = InterfaceFuncInvoker0< RuntimeObject * >::Invoke(1 /* System.Object System.Collections.IEnumerator::get_Current() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_4);
			V_2 = L_5;
			bool L_6 = V_0;
			V_3 = (bool)((((int32_t)L_6) == ((int32_t)0))? 1 : 0);
			bool L_7 = V_3;
			if (!L_7)
			{
				goto IL_0040;
			}
		}

IL_0030:
		{
			StringBuilder_t * L_8 = __this->get_builder_0();
			NullCheck(L_8);
			StringBuilder_Append_m05C12F58ADC2D807613A9301DF438CB3CD09B75A(L_8, ((int32_t)44), /*hidden argument*/NULL);
		}

IL_0040:
		{
			RuntimeObject * L_9 = V_2;
			NullCheck(L_9);
			String_t* L_10 = VirtFuncInvoker0< String_t* >::Invoke(3 /* System.String System.Object::ToString() */, L_9);
			Serializer_SerializeString_m71208E9D67CAB89BF60CE2CAA22264221B8110EE(__this, L_10, /*hidden argument*/NULL);
			StringBuilder_t * L_11 = __this->get_builder_0();
			NullCheck(L_11);
			StringBuilder_Append_m05C12F58ADC2D807613A9301DF438CB3CD09B75A(L_11, ((int32_t)58), /*hidden argument*/NULL);
			RuntimeObject* L_12 = ___obj0;
			RuntimeObject * L_13 = V_2;
			NullCheck(L_12);
			RuntimeObject * L_14 = InterfaceFuncInvoker1< RuntimeObject *, RuntimeObject * >::Invoke(0 /* System.Object System.Collections.IDictionary::get_Item(System.Object) */, IDictionary_t1BD5C1546718A374EA8122FBD6C6EE45331E8CE7_il2cpp_TypeInfo_var, L_12, L_13);
			Serializer_SerializeValue_mDA3C31227389EF6116A3D5490FDAB12CE3AC28DC(__this, L_14, /*hidden argument*/NULL);
			V_0 = (bool)0;
		}

IL_006c:
		{
			RuntimeObject* L_15 = V_1;
			NullCheck(L_15);
			bool L_16 = InterfaceFuncInvoker0< bool >::Invoke(0 /* System.Boolean System.Collections.IEnumerator::MoveNext() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_15);
			if (L_16)
			{
				goto IL_0020;
			}
		}

IL_0074:
		{
			IL2CPP_LEAVE(0x8B, FINALLY_0076);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_0076;
	}

FINALLY_0076:
	{ // begin finally (depth: 1)
		{
			RuntimeObject* L_17 = V_1;
			V_4 = ((RuntimeObject*)IsInst((RuntimeObject*)L_17, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var));
			RuntimeObject* L_18 = V_4;
			if (!L_18)
			{
				goto IL_008a;
			}
		}

IL_0082:
		{
			RuntimeObject* L_19 = V_4;
			NullCheck(L_19);
			InterfaceActionInvoker0::Invoke(0 /* System.Void System.IDisposable::Dispose() */, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var, L_19);
		}

IL_008a:
		{
			IL2CPP_END_FINALLY(118)
		}
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(118)
	{
		IL2CPP_JUMP_TBL(0x8B, IL_008b)
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
	}

IL_008b:
	{
		StringBuilder_t * L_20 = __this->get_builder_0();
		NullCheck(L_20);
		StringBuilder_Append_m05C12F58ADC2D807613A9301DF438CB3CD09B75A(L_20, ((int32_t)125), /*hidden argument*/NULL);
		return;
	}
}
// System.Void UnityEngine.Purchasing.MiniJSON.Json_Serializer::SerializeArray(System.Collections.IList)
extern "C" IL2CPP_METHOD_ATTR void Serializer_SerializeArray_mA4DB26A2353A1FE3838E765DB7A6F6B4E4460ECC (Serializer_t8E477D61E7D27FA878E7A6D57F4619E5C5B0611D * __this, RuntimeObject* ___anArray0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Serializer_SerializeArray_mA4DB26A2353A1FE3838E765DB7A6F6B4E4460ECC_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	RuntimeObject* V_1 = NULL;
	RuntimeObject * V_2 = NULL;
	bool V_3 = false;
	RuntimeObject* V_4 = NULL;
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	void* __leave_targets_storage = alloca(sizeof(int32_t) * 1);
	il2cpp::utils::LeaveTargetStack __leave_targets(__leave_targets_storage);
	NO_UNUSED_WARNING (__leave_targets);
	{
		StringBuilder_t * L_0 = __this->get_builder_0();
		NullCheck(L_0);
		StringBuilder_Append_m05C12F58ADC2D807613A9301DF438CB3CD09B75A(L_0, ((int32_t)91), /*hidden argument*/NULL);
		V_0 = (bool)1;
		RuntimeObject* L_1 = ___anArray0;
		NullCheck(L_1);
		RuntimeObject* L_2 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* System.Collections.IEnumerator System.Collections.IEnumerable::GetEnumerator() */, IEnumerable_tD74549CEA1AA48E768382B94FEACBB07E2E3FA2C_il2cpp_TypeInfo_var, L_1);
		V_1 = L_2;
	}

IL_0019:
	try
	{ // begin try (depth: 1)
		{
			goto IL_0046;
		}

IL_001b:
		{
			RuntimeObject* L_3 = V_1;
			NullCheck(L_3);
			RuntimeObject * L_4 = InterfaceFuncInvoker0< RuntimeObject * >::Invoke(1 /* System.Object System.Collections.IEnumerator::get_Current() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_3);
			V_2 = L_4;
			bool L_5 = V_0;
			V_3 = (bool)((((int32_t)L_5) == ((int32_t)0))? 1 : 0);
			bool L_6 = V_3;
			if (!L_6)
			{
				goto IL_003b;
			}
		}

IL_002b:
		{
			StringBuilder_t * L_7 = __this->get_builder_0();
			NullCheck(L_7);
			StringBuilder_Append_m05C12F58ADC2D807613A9301DF438CB3CD09B75A(L_7, ((int32_t)44), /*hidden argument*/NULL);
		}

IL_003b:
		{
			RuntimeObject * L_8 = V_2;
			Serializer_SerializeValue_mDA3C31227389EF6116A3D5490FDAB12CE3AC28DC(__this, L_8, /*hidden argument*/NULL);
			V_0 = (bool)0;
		}

IL_0046:
		{
			RuntimeObject* L_9 = V_1;
			NullCheck(L_9);
			bool L_10 = InterfaceFuncInvoker0< bool >::Invoke(0 /* System.Boolean System.Collections.IEnumerator::MoveNext() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_9);
			if (L_10)
			{
				goto IL_001b;
			}
		}

IL_004e:
		{
			IL2CPP_LEAVE(0x65, FINALLY_0050);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_0050;
	}

FINALLY_0050:
	{ // begin finally (depth: 1)
		{
			RuntimeObject* L_11 = V_1;
			V_4 = ((RuntimeObject*)IsInst((RuntimeObject*)L_11, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var));
			RuntimeObject* L_12 = V_4;
			if (!L_12)
			{
				goto IL_0064;
			}
		}

IL_005c:
		{
			RuntimeObject* L_13 = V_4;
			NullCheck(L_13);
			InterfaceActionInvoker0::Invoke(0 /* System.Void System.IDisposable::Dispose() */, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var, L_13);
		}

IL_0064:
		{
			IL2CPP_END_FINALLY(80)
		}
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(80)
	{
		IL2CPP_JUMP_TBL(0x65, IL_0065)
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
	}

IL_0065:
	{
		StringBuilder_t * L_14 = __this->get_builder_0();
		NullCheck(L_14);
		StringBuilder_Append_m05C12F58ADC2D807613A9301DF438CB3CD09B75A(L_14, ((int32_t)93), /*hidden argument*/NULL);
		return;
	}
}
// System.Void UnityEngine.Purchasing.MiniJSON.Json_Serializer::SerializeString(System.String)
extern "C" IL2CPP_METHOD_ATTR void Serializer_SerializeString_m71208E9D67CAB89BF60CE2CAA22264221B8110EE (Serializer_t8E477D61E7D27FA878E7A6D57F4619E5C5B0611D * __this, String_t* ___str0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Serializer_SerializeString_m71208E9D67CAB89BF60CE2CAA22264221B8110EE_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* V_0 = NULL;
	CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* V_1 = NULL;
	int32_t V_2 = 0;
	Il2CppChar V_3 = 0x0;
	Il2CppChar V_4 = 0x0;
	int32_t V_5 = 0;
	bool V_6 = false;
	int32_t G_B17_0 = 0;
	{
		StringBuilder_t * L_0 = __this->get_builder_0();
		NullCheck(L_0);
		StringBuilder_Append_m05C12F58ADC2D807613A9301DF438CB3CD09B75A(L_0, ((int32_t)34), /*hidden argument*/NULL);
		String_t* L_1 = ___str0;
		NullCheck(L_1);
		CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* L_2 = String_ToCharArray_mFCFF32A5EC698E81075E0C72C874282B9ED197A6(L_1, /*hidden argument*/NULL);
		V_0 = L_2;
		CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* L_3 = V_0;
		V_1 = L_3;
		V_2 = 0;
		goto IL_0155;
	}

IL_0020:
	{
		CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* L_4 = V_1;
		int32_t L_5 = V_2;
		NullCheck(L_4);
		int32_t L_6 = L_5;
		uint16_t L_7 = (uint16_t)(L_4)->GetAt(static_cast<il2cpp_array_size_t>(L_6));
		V_3 = L_7;
		Il2CppChar L_8 = V_3;
		V_4 = L_8;
		Il2CppChar L_9 = V_4;
		switch (((int32_t)il2cpp_codegen_subtract((int32_t)L_9, (int32_t)8)))
		{
			case 0:
			{
				goto IL_008a;
			}
			case 1:
			{
				goto IL_00df;
			}
			case 2:
			{
				goto IL_00b6;
			}
			case 3:
			{
				goto IL_00f2;
			}
			case 4:
			{
				goto IL_00a0;
			}
			case 5:
			{
				goto IL_00cc;
			}
		}
	}
	{
		goto IL_004b;
	}

IL_004b:
	{
		Il2CppChar L_10 = V_4;
		if ((((int32_t)L_10) == ((int32_t)((int32_t)34))))
		{
			goto IL_005e;
		}
	}
	{
		goto IL_0053;
	}

IL_0053:
	{
		Il2CppChar L_11 = V_4;
		if ((((int32_t)L_11) == ((int32_t)((int32_t)92))))
		{
			goto IL_0074;
		}
	}
	{
		goto IL_00f2;
	}

IL_005e:
	{
		StringBuilder_t * L_12 = __this->get_builder_0();
		NullCheck(L_12);
		StringBuilder_Append_mDBB8CCBB7750C67BE2F2D92F47E6C0FA42793260(L_12, _stringLiteralAB006BB8AACDF6E68299BC1DFFCCC9BCC8AC3EAF, /*hidden argument*/NULL);
		goto IL_0150;
	}

IL_0074:
	{
		StringBuilder_t * L_13 = __this->get_builder_0();
		NullCheck(L_13);
		StringBuilder_Append_mDBB8CCBB7750C67BE2F2D92F47E6C0FA42793260(L_13, _stringLiteral9E94758983980504AF303EF297FD2BF9D9CEA063, /*hidden argument*/NULL);
		goto IL_0150;
	}

IL_008a:
	{
		StringBuilder_t * L_14 = __this->get_builder_0();
		NullCheck(L_14);
		StringBuilder_Append_mDBB8CCBB7750C67BE2F2D92F47E6C0FA42793260(L_14, _stringLiteral4629CA1B60E263BDC4326334B23323E0434717A5, /*hidden argument*/NULL);
		goto IL_0150;
	}

IL_00a0:
	{
		StringBuilder_t * L_15 = __this->get_builder_0();
		NullCheck(L_15);
		StringBuilder_Append_mDBB8CCBB7750C67BE2F2D92F47E6C0FA42793260(L_15, _stringLiteral794A729D2E4FFBB094FEC03AE9B3ACD219371385, /*hidden argument*/NULL);
		goto IL_0150;
	}

IL_00b6:
	{
		StringBuilder_t * L_16 = __this->get_builder_0();
		NullCheck(L_16);
		StringBuilder_Append_mDBB8CCBB7750C67BE2F2D92F47E6C0FA42793260(L_16, _stringLiteralEF7E6794CA9C6A06B54B66F279237FB8DAAAEEA8, /*hidden argument*/NULL);
		goto IL_0150;
	}

IL_00cc:
	{
		StringBuilder_t * L_17 = __this->get_builder_0();
		NullCheck(L_17);
		StringBuilder_Append_mDBB8CCBB7750C67BE2F2D92F47E6C0FA42793260(L_17, _stringLiteralF12C84902108895980702C88DB900CEEA2D2EC01, /*hidden argument*/NULL);
		goto IL_0150;
	}

IL_00df:
	{
		StringBuilder_t * L_18 = __this->get_builder_0();
		NullCheck(L_18);
		StringBuilder_Append_mDBB8CCBB7750C67BE2F2D92F47E6C0FA42793260(L_18, _stringLiteral8BF81043E29DFC96A6FE1F30F7116F552DE6E7D7, /*hidden argument*/NULL);
		goto IL_0150;
	}

IL_00f2:
	{
		Il2CppChar L_19 = V_3;
		IL2CPP_RUNTIME_CLASS_INIT(Convert_t1C7A851BFB2F0782FD7F72F6AA1DCBB7B53A9C7E_il2cpp_TypeInfo_var);
		int32_t L_20 = Convert_ToInt32_m8BE65713C8D5E0AD45D53B82A5A7BD187BEBA917(L_19, /*hidden argument*/NULL);
		V_5 = L_20;
		int32_t L_21 = V_5;
		if ((((int32_t)L_21) < ((int32_t)((int32_t)32))))
		{
			goto IL_010b;
		}
	}
	{
		int32_t L_22 = V_5;
		G_B17_0 = ((((int32_t)((((int32_t)L_22) > ((int32_t)((int32_t)126)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_010c;
	}

IL_010b:
	{
		G_B17_0 = 0;
	}

IL_010c:
	{
		V_6 = (bool)G_B17_0;
		bool L_23 = V_6;
		if (!L_23)
		{
			goto IL_0123;
		}
	}
	{
		StringBuilder_t * L_24 = __this->get_builder_0();
		Il2CppChar L_25 = V_3;
		NullCheck(L_24);
		StringBuilder_Append_m05C12F58ADC2D807613A9301DF438CB3CD09B75A(L_24, L_25, /*hidden argument*/NULL);
		goto IL_014e;
	}

IL_0123:
	{
		StringBuilder_t * L_26 = __this->get_builder_0();
		NullCheck(L_26);
		StringBuilder_Append_mDBB8CCBB7750C67BE2F2D92F47E6C0FA42793260(L_26, _stringLiteral153809851B33CE0CDCE06E5A572C675E18D0C3B5, /*hidden argument*/NULL);
		StringBuilder_t * L_27 = __this->get_builder_0();
		String_t* L_28 = Int32_ToString_m5A125A41C41701E41FA0C4CC52CADBC73C1C96D8((int32_t*)(&V_5), _stringLiteral2BFBE0BC53277529025720589E902C25BF01F2F4, /*hidden argument*/NULL);
		NullCheck(L_27);
		StringBuilder_Append_mDBB8CCBB7750C67BE2F2D92F47E6C0FA42793260(L_27, L_28, /*hidden argument*/NULL);
	}

IL_014e:
	{
		goto IL_0150;
	}

IL_0150:
	{
		int32_t L_29 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add((int32_t)L_29, (int32_t)1));
	}

IL_0155:
	{
		int32_t L_30 = V_2;
		CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* L_31 = V_1;
		NullCheck(L_31);
		if ((((int32_t)L_30) < ((int32_t)(((int32_t)((int32_t)(((RuntimeArray *)L_31)->max_length)))))))
		{
			goto IL_0020;
		}
	}
	{
		StringBuilder_t * L_32 = __this->get_builder_0();
		NullCheck(L_32);
		StringBuilder_Append_m05C12F58ADC2D807613A9301DF438CB3CD09B75A(L_32, ((int32_t)34), /*hidden argument*/NULL);
		return;
	}
}
// System.Void UnityEngine.Purchasing.MiniJSON.Json_Serializer::SerializeOther(System.Object)
extern "C" IL2CPP_METHOD_ATTR void Serializer_SerializeOther_m39DC0396BC829EDA0A4086E711BCF48BFDF79351 (Serializer_t8E477D61E7D27FA878E7A6D57F4619E5C5B0611D * __this, RuntimeObject * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (Serializer_SerializeOther_m39DC0396BC829EDA0A4086E711BCF48BFDF79351_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	float V_1 = 0.0f;
	bool V_2 = false;
	bool V_3 = false;
	double V_4 = 0.0;
	int32_t G_B11_0 = 0;
	int32_t G_B16_0 = 0;
	{
		RuntimeObject * L_0 = ___value0;
		V_0 = (bool)((!(((RuntimeObject*)(RuntimeObject *)((RuntimeObject *)IsInstSealed((RuntimeObject*)L_0, Single_tDDDA9169C4E4E308AC6D7A824F9B28DC82204AE1_il2cpp_TypeInfo_var))) <= ((RuntimeObject*)(RuntimeObject *)NULL)))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0034;
		}
	}
	{
		StringBuilder_t * L_2 = __this->get_builder_0();
		RuntimeObject * L_3 = ___value0;
		V_1 = ((*(float*)((float*)UnBox(L_3, Single_tDDDA9169C4E4E308AC6D7A824F9B28DC82204AE1_il2cpp_TypeInfo_var))));
		String_t* L_4 = Single_ToString_m211B5E14B0C60667C56838D5C3788CFA58670DDE((float*)(&V_1), _stringLiteral06576556D1AD802F247CAD11AE748BE47B70CD9C, /*hidden argument*/NULL);
		NullCheck(L_2);
		StringBuilder_Append_mDBB8CCBB7750C67BE2F2D92F47E6C0FA42793260(L_2, L_4, /*hidden argument*/NULL);
		goto IL_00d8;
	}

IL_0034:
	{
		RuntimeObject * L_5 = ___value0;
		if (((RuntimeObject *)IsInstSealed((RuntimeObject*)L_5, Int32_t585191389E07734F19F3156FF88FB3EF4800D102_il2cpp_TypeInfo_var)))
		{
			goto IL_0077;
		}
	}
	{
		RuntimeObject * L_6 = ___value0;
		if (((RuntimeObject *)IsInstSealed((RuntimeObject*)L_6, UInt32_t4980FA09003AFAAB5A6E361BA2748EA9A005709B_il2cpp_TypeInfo_var)))
		{
			goto IL_0077;
		}
	}
	{
		RuntimeObject * L_7 = ___value0;
		if (((RuntimeObject *)IsInstSealed((RuntimeObject*)L_7, Int64_t7A386C2FF7B0280A0F516992401DDFCF0FF7B436_il2cpp_TypeInfo_var)))
		{
			goto IL_0077;
		}
	}
	{
		RuntimeObject * L_8 = ___value0;
		if (((RuntimeObject *)IsInstSealed((RuntimeObject*)L_8, SByte_t9070AEA2966184235653CB9B4D33B149CDA831DF_il2cpp_TypeInfo_var)))
		{
			goto IL_0077;
		}
	}
	{
		RuntimeObject * L_9 = ___value0;
		if (((RuntimeObject *)IsInstSealed((RuntimeObject*)L_9, Byte_tF87C579059BD4633E6840EBBBEEF899C6E33EF07_il2cpp_TypeInfo_var)))
		{
			goto IL_0077;
		}
	}
	{
		RuntimeObject * L_10 = ___value0;
		if (((RuntimeObject *)IsInstSealed((RuntimeObject*)L_10, Int16_t823A20635DAF5A3D93A1E01CFBF3CBA27CF00B4D_il2cpp_TypeInfo_var)))
		{
			goto IL_0077;
		}
	}
	{
		RuntimeObject * L_11 = ___value0;
		if (((RuntimeObject *)IsInstSealed((RuntimeObject*)L_11, UInt16_tAE45CEF73BF720100519F6867F32145D075F928E_il2cpp_TypeInfo_var)))
		{
			goto IL_0077;
		}
	}
	{
		RuntimeObject * L_12 = ___value0;
		G_B11_0 = ((!(((RuntimeObject*)(RuntimeObject *)((RuntimeObject *)IsInstSealed((RuntimeObject*)L_12, UInt64_tA02DF3B59C8FC4A849BD207DA11038CC64E4CB4E_il2cpp_TypeInfo_var))) <= ((RuntimeObject*)(RuntimeObject *)NULL)))? 1 : 0);
		goto IL_0078;
	}

IL_0077:
	{
		G_B11_0 = 1;
	}

IL_0078:
	{
		V_2 = (bool)G_B11_0;
		bool L_13 = V_2;
		if (!L_13)
		{
			goto IL_008d;
		}
	}
	{
		StringBuilder_t * L_14 = __this->get_builder_0();
		RuntimeObject * L_15 = ___value0;
		NullCheck(L_14);
		StringBuilder_Append_mA1A063A1388A21C8EA011DBA7FC98C24C3EE3D65(L_14, L_15, /*hidden argument*/NULL);
		goto IL_00d8;
	}

IL_008d:
	{
		RuntimeObject * L_16 = ___value0;
		if (((RuntimeObject *)IsInstSealed((RuntimeObject*)L_16, Double_t358B8F23BDC52A5DD700E727E204F9F7CDE12409_il2cpp_TypeInfo_var)))
		{
			goto IL_00a0;
		}
	}
	{
		RuntimeObject * L_17 = ___value0;
		G_B16_0 = ((!(((RuntimeObject*)(RuntimeObject *)((RuntimeObject *)IsInstSealed((RuntimeObject*)L_17, Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8_il2cpp_TypeInfo_var))) <= ((RuntimeObject*)(RuntimeObject *)NULL)))? 1 : 0);
		goto IL_00a1;
	}

IL_00a0:
	{
		G_B16_0 = 1;
	}

IL_00a1:
	{
		V_3 = (bool)G_B16_0;
		bool L_18 = V_3;
		if (!L_18)
		{
			goto IL_00c9;
		}
	}
	{
		StringBuilder_t * L_19 = __this->get_builder_0();
		RuntimeObject * L_20 = ___value0;
		IL2CPP_RUNTIME_CLASS_INIT(Convert_t1C7A851BFB2F0782FD7F72F6AA1DCBB7B53A9C7E_il2cpp_TypeInfo_var);
		double L_21 = Convert_ToDouble_mAB66BA75AC3CDFA1FEC09E3125EA444B46CD7050(L_20, /*hidden argument*/NULL);
		V_4 = L_21;
		String_t* L_22 = Double_ToString_m4A142BE5E5F1EF1434658FC874A19E124D95313F((double*)(&V_4), _stringLiteral06576556D1AD802F247CAD11AE748BE47B70CD9C, /*hidden argument*/NULL);
		NullCheck(L_19);
		StringBuilder_Append_mDBB8CCBB7750C67BE2F2D92F47E6C0FA42793260(L_19, L_22, /*hidden argument*/NULL);
		goto IL_00d8;
	}

IL_00c9:
	{
		RuntimeObject * L_23 = ___value0;
		NullCheck(L_23);
		String_t* L_24 = VirtFuncInvoker0< String_t* >::Invoke(3 /* System.String System.Object::ToString() */, L_23);
		Serializer_SerializeString_m71208E9D67CAB89BF60CE2CAA22264221B8110EE(__this, L_24, /*hidden argument*/NULL);
	}

IL_00d8:
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
// System.String UnityEngine.Purchasing.MiniJSON.MiniJsonExtensions::GetString(System.Collections.Generic.Dictionary`2<System.String,System.Object>,System.String,System.String)
extern "C" IL2CPP_METHOD_ATTR String_t* MiniJsonExtensions_GetString_mB42DECB2528309B3A49269120548258B3E0B6142 (Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * ___dic0, String_t* ___key1, String_t* ___defaultValue2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (MiniJsonExtensions_GetString_mB42DECB2528309B3A49269120548258B3E0B6142_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	String_t* V_1 = NULL;
	{
		Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * L_0 = ___dic0;
		String_t* L_1 = ___key1;
		NullCheck(L_0);
		bool L_2 = Dictionary_2_ContainsKey_mAD4B2095526B4742201B24C5ADF1717AFB15EF89(L_0, L_1, /*hidden argument*/Dictionary_2_ContainsKey_mAD4B2095526B4742201B24C5ADF1717AFB15EF89_RuntimeMethod_var);
		V_0 = L_2;
		bool L_3 = V_0;
		if (!L_3)
		{
			goto IL_001b;
		}
	}
	{
		Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * L_4 = ___dic0;
		String_t* L_5 = ___key1;
		NullCheck(L_4);
		RuntimeObject * L_6 = Dictionary_2_get_Item_mB490F7029D7451FAF06E3020040E604B500BA3B2(L_4, L_5, /*hidden argument*/Dictionary_2_get_Item_mB490F7029D7451FAF06E3020040E604B500BA3B2_RuntimeMethod_var);
		NullCheck(L_6);
		String_t* L_7 = VirtFuncInvoker0< String_t* >::Invoke(3 /* System.String System.Object::ToString() */, L_6);
		V_1 = L_7;
		goto IL_001f;
	}

IL_001b:
	{
		String_t* L_8 = ___defaultValue2;
		V_1 = L_8;
		goto IL_001f;
	}

IL_001f:
	{
		String_t* L_9 = V_1;
		return L_9;
	}
}
// System.String UnityEngine.Purchasing.MiniJSON.MiniJsonExtensions::toJson(System.Collections.Generic.Dictionary`2<System.String,System.Object>)
extern "C" IL2CPP_METHOD_ATTR String_t* MiniJsonExtensions_toJson_m990366CD4919BF3809E5C83E6F64A7B12D19F2DB (Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * ___obj0, const RuntimeMethod* method)
{
	String_t* V_0 = NULL;
	{
		Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * L_0 = ___obj0;
		String_t* L_1 = MiniJson_JsonEncode_m224609728F07F11683AEE1398F8C2E6F1FC759E2(L_0, /*hidden argument*/NULL);
		V_0 = L_1;
		goto IL_000a;
	}

IL_000a:
	{
		String_t* L_2 = V_0;
		return L_2;
	}
}
// System.String UnityEngine.Purchasing.MiniJSON.MiniJsonExtensions::toJson(System.Collections.Generic.Dictionary`2<System.String,System.String>)
extern "C" IL2CPP_METHOD_ATTR String_t* MiniJsonExtensions_toJson_mD043B50E39DCA34D4279C22E1A444A29645008F9 (Dictionary_2_t931BF283048C4E74FC063C3036E5F3FE328861FC * ___obj0, const RuntimeMethod* method)
{
	String_t* V_0 = NULL;
	{
		Dictionary_2_t931BF283048C4E74FC063C3036E5F3FE328861FC * L_0 = ___obj0;
		String_t* L_1 = MiniJson_JsonEncode_m224609728F07F11683AEE1398F8C2E6F1FC759E2(L_0, /*hidden argument*/NULL);
		V_0 = L_1;
		goto IL_000a;
	}

IL_000a:
	{
		String_t* L_2 = V_0;
		return L_2;
	}
}
// System.Collections.Generic.Dictionary`2<System.String,System.Object> UnityEngine.Purchasing.MiniJSON.MiniJsonExtensions::HashtableFromJson(System.String)
extern "C" IL2CPP_METHOD_ATTR Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * MiniJsonExtensions_HashtableFromJson_m924DE4EC163F926FCAC0ACB6890D9865E1A3D0D9 (String_t* ___json0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (MiniJsonExtensions_HashtableFromJson_m924DE4EC163F926FCAC0ACB6890D9865E1A3D0D9_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * V_0 = NULL;
	{
		String_t* L_0 = ___json0;
		RuntimeObject * L_1 = MiniJson_JsonDecode_m4F90554E3C783D4EA66473DCB81826937A6BA268(L_0, /*hidden argument*/NULL);
		V_0 = ((Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA *)IsInstClass((RuntimeObject*)L_1, Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA_il2cpp_TypeInfo_var));
		goto IL_000f;
	}

IL_000f:
	{
		Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * L_2 = V_0;
		return L_2;
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
// System.String UnityEngine.Purchasing.MiniJson::JsonEncode(System.Object)
extern "C" IL2CPP_METHOD_ATTR String_t* MiniJson_JsonEncode_m224609728F07F11683AEE1398F8C2E6F1FC759E2 (RuntimeObject * ___json0, const RuntimeMethod* method)
{
	String_t* V_0 = NULL;
	{
		RuntimeObject * L_0 = ___json0;
		String_t* L_1 = Json_Serialize_mD1295591A0B6F59C1A9BD7940B258EE79DC659EC(L_0, /*hidden argument*/NULL);
		V_0 = L_1;
		goto IL_000a;
	}

IL_000a:
	{
		String_t* L_2 = V_0;
		return L_2;
	}
}
// System.Object UnityEngine.Purchasing.MiniJson::JsonDecode(System.String)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * MiniJson_JsonDecode_m4F90554E3C783D4EA66473DCB81826937A6BA268 (String_t* ___json0, const RuntimeMethod* method)
{
	RuntimeObject * V_0 = NULL;
	{
		String_t* L_0 = ___json0;
		RuntimeObject * L_1 = Json_Deserialize_m63BB7C9B31E2AE1C78B8091D9D54CCCD64CC763E(L_0, /*hidden argument*/NULL);
		V_0 = L_1;
		goto IL_000a;
	}

IL_000a:
	{
		RuntimeObject * L_2 = V_0;
		return L_2;
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
extern "C"  void DelegatePInvokeWrapper_UnityPurchasingCallback_tF3081DE4B67FBD9771C293C52885EC15C279810C (UnityPurchasingCallback_tF3081DE4B67FBD9771C293C52885EC15C279810C * __this, String_t* ___subject0, String_t* ___payload1, String_t* ___receipt2, String_t* ___transactionId3, const RuntimeMethod* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc)(char*, char*, char*, char*);
	PInvokeFunc il2cppPInvokeFunc = reinterpret_cast<PInvokeFunc>(il2cpp_codegen_get_method_pointer(((RuntimeDelegate*)__this)->method));

	// Marshaling of parameter U27___subject0U27 to native representation
	char* ____subject0_marshaled = NULL;
	____subject0_marshaled = il2cpp_codegen_marshal_string(___subject0);

	// Marshaling of parameter U27___payload1U27 to native representation
	char* ____payload1_marshaled = NULL;
	____payload1_marshaled = il2cpp_codegen_marshal_string(___payload1);

	// Marshaling of parameter U27___receipt2U27 to native representation
	char* ____receipt2_marshaled = NULL;
	____receipt2_marshaled = il2cpp_codegen_marshal_string(___receipt2);

	// Marshaling of parameter U27___transactionId3U27 to native representation
	char* ____transactionId3_marshaled = NULL;
	____transactionId3_marshaled = il2cpp_codegen_marshal_string(___transactionId3);

	// Native function invocation
	il2cppPInvokeFunc(____subject0_marshaled, ____payload1_marshaled, ____receipt2_marshaled, ____transactionId3_marshaled);

	// Marshaling cleanup of parameter U27___subject0U27 native representation
	il2cpp_codegen_marshal_free(____subject0_marshaled);
	____subject0_marshaled = NULL;

	// Marshaling cleanup of parameter U27___payload1U27 native representation
	il2cpp_codegen_marshal_free(____payload1_marshaled);
	____payload1_marshaled = NULL;

	// Marshaling cleanup of parameter U27___receipt2U27 native representation
	il2cpp_codegen_marshal_free(____receipt2_marshaled);
	____receipt2_marshaled = NULL;

	// Marshaling cleanup of parameter U27___transactionId3U27 native representation
	il2cpp_codegen_marshal_free(____transactionId3_marshaled);
	____transactionId3_marshaled = NULL;

}
// System.Void UnityEngine.Purchasing.UnityPurchasingCallback::.ctor(System.Object,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR void UnityPurchasingCallback__ctor_mB88329347266EB7F49BFF497599BC464411337BB (UnityPurchasingCallback_tF3081DE4B67FBD9771C293C52885EC15C279810C * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method)
{
	__this->set_method_ptr_0(il2cpp_codegen_get_method_pointer((RuntimeMethod*)___method1));
	__this->set_method_3(___method1);
	__this->set_m_target_2(___object0);
}
// System.Void UnityEngine.Purchasing.UnityPurchasingCallback::Invoke(System.String,System.String,System.String,System.String)
extern "C" IL2CPP_METHOD_ATTR void UnityPurchasingCallback_Invoke_m3E24E3D1573B4BE73AB9D4AB153E938B8B2B5DB1 (UnityPurchasingCallback_tF3081DE4B67FBD9771C293C52885EC15C279810C * __this, String_t* ___subject0, String_t* ___payload1, String_t* ___receipt2, String_t* ___transactionId3, const RuntimeMethod* method)
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
					typedef void (*FunctionPointerType) (String_t*, String_t*, String_t*, String_t*, const RuntimeMethod*);
					((FunctionPointerType)targetMethodPointer)(___subject0, ___payload1, ___receipt2, ___transactionId3, targetMethod);
				}
				else
				{
					// closed
					typedef void (*FunctionPointerType) (void*, String_t*, String_t*, String_t*, String_t*, const RuntimeMethod*);
					((FunctionPointerType)targetMethodPointer)(targetThis, ___subject0, ___payload1, ___receipt2, ___transactionId3, targetMethod);
				}
			}
			else if (___parameterCount != 4)
			{
				// open
				if (il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
				{
					if (il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
					{
						if (il2cpp_codegen_method_is_generic_instance(targetMethod))
						{
							if (il2cpp_codegen_method_is_interface_method(targetMethod))
								GenericInterfaceActionInvoker3< String_t*, String_t*, String_t* >::Invoke(targetMethod, ___subject0, ___payload1, ___receipt2, ___transactionId3);
							else
								GenericVirtActionInvoker3< String_t*, String_t*, String_t* >::Invoke(targetMethod, ___subject0, ___payload1, ___receipt2, ___transactionId3);
						}
						else
						{
							if (il2cpp_codegen_method_is_interface_method(targetMethod))
								InterfaceActionInvoker3< String_t*, String_t*, String_t* >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), ___subject0, ___payload1, ___receipt2, ___transactionId3);
							else
								VirtActionInvoker3< String_t*, String_t*, String_t* >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), ___subject0, ___payload1, ___receipt2, ___transactionId3);
						}
					}
				}
				else
				{
					typedef void (*FunctionPointerType) (String_t*, String_t*, String_t*, String_t*, const RuntimeMethod*);
					((FunctionPointerType)targetMethodPointer)(___subject0, ___payload1, ___receipt2, ___transactionId3, targetMethod);
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
							typedef void (*FunctionPointerType) (String_t*, String_t*, String_t*, String_t*, const RuntimeMethod*);
							((FunctionPointerType)targetMethodPointer)(___subject0, ___payload1, ___receipt2, ___transactionId3, targetMethod);
						}
						else if (il2cpp_codegen_method_is_generic_instance(targetMethod))
						{
							if (il2cpp_codegen_method_is_interface_method(targetMethod))
								GenericInterfaceActionInvoker4< String_t*, String_t*, String_t*, String_t* >::Invoke(targetMethod, targetThis, ___subject0, ___payload1, ___receipt2, ___transactionId3);
							else
								GenericVirtActionInvoker4< String_t*, String_t*, String_t*, String_t* >::Invoke(targetMethod, targetThis, ___subject0, ___payload1, ___receipt2, ___transactionId3);
						}
						else
						{
							if (il2cpp_codegen_method_is_interface_method(targetMethod))
								InterfaceActionInvoker4< String_t*, String_t*, String_t*, String_t* >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), targetThis, ___subject0, ___payload1, ___receipt2, ___transactionId3);
							else
								VirtActionInvoker4< String_t*, String_t*, String_t*, String_t* >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), targetThis, ___subject0, ___payload1, ___receipt2, ___transactionId3);
						}
					}
				}
				else
				{
					typedef void (*FunctionPointerType) (void*, String_t*, String_t*, String_t*, String_t*, const RuntimeMethod*);
					((FunctionPointerType)targetMethodPointer)(targetThis, ___subject0, ___payload1, ___receipt2, ___transactionId3, targetMethod);
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
				typedef void (*FunctionPointerType) (String_t*, String_t*, String_t*, String_t*, const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(___subject0, ___payload1, ___receipt2, ___transactionId3, targetMethod);
			}
			else
			{
				// closed
				typedef void (*FunctionPointerType) (void*, String_t*, String_t*, String_t*, String_t*, const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(targetThis, ___subject0, ___payload1, ___receipt2, ___transactionId3, targetMethod);
			}
		}
		else if (___parameterCount != 4)
		{
			// open
			if (il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
			{
				if (il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
				{
					if (il2cpp_codegen_method_is_generic_instance(targetMethod))
					{
						if (il2cpp_codegen_method_is_interface_method(targetMethod))
							GenericInterfaceActionInvoker3< String_t*, String_t*, String_t* >::Invoke(targetMethod, ___subject0, ___payload1, ___receipt2, ___transactionId3);
						else
							GenericVirtActionInvoker3< String_t*, String_t*, String_t* >::Invoke(targetMethod, ___subject0, ___payload1, ___receipt2, ___transactionId3);
					}
					else
					{
						if (il2cpp_codegen_method_is_interface_method(targetMethod))
							InterfaceActionInvoker3< String_t*, String_t*, String_t* >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), ___subject0, ___payload1, ___receipt2, ___transactionId3);
						else
							VirtActionInvoker3< String_t*, String_t*, String_t* >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), ___subject0, ___payload1, ___receipt2, ___transactionId3);
					}
				}
			}
			else
			{
				typedef void (*FunctionPointerType) (String_t*, String_t*, String_t*, String_t*, const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(___subject0, ___payload1, ___receipt2, ___transactionId3, targetMethod);
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
						typedef void (*FunctionPointerType) (String_t*, String_t*, String_t*, String_t*, const RuntimeMethod*);
						((FunctionPointerType)targetMethodPointer)(___subject0, ___payload1, ___receipt2, ___transactionId3, targetMethod);
					}
					else if (il2cpp_codegen_method_is_generic_instance(targetMethod))
					{
						if (il2cpp_codegen_method_is_interface_method(targetMethod))
							GenericInterfaceActionInvoker4< String_t*, String_t*, String_t*, String_t* >::Invoke(targetMethod, targetThis, ___subject0, ___payload1, ___receipt2, ___transactionId3);
						else
							GenericVirtActionInvoker4< String_t*, String_t*, String_t*, String_t* >::Invoke(targetMethod, targetThis, ___subject0, ___payload1, ___receipt2, ___transactionId3);
					}
					else
					{
						if (il2cpp_codegen_method_is_interface_method(targetMethod))
							InterfaceActionInvoker4< String_t*, String_t*, String_t*, String_t* >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), targetThis, ___subject0, ___payload1, ___receipt2, ___transactionId3);
						else
							VirtActionInvoker4< String_t*, String_t*, String_t*, String_t* >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), targetThis, ___subject0, ___payload1, ___receipt2, ___transactionId3);
					}
				}
			}
			else
			{
				typedef void (*FunctionPointerType) (void*, String_t*, String_t*, String_t*, String_t*, const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(targetThis, ___subject0, ___payload1, ___receipt2, ___transactionId3, targetMethod);
			}
		}
	}
}
// System.IAsyncResult UnityEngine.Purchasing.UnityPurchasingCallback::BeginInvoke(System.String,System.String,System.String,System.String,System.AsyncCallback,System.Object)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject* UnityPurchasingCallback_BeginInvoke_mAB160462B80C6A2E9E925A2FF6A2254C8665F17B (UnityPurchasingCallback_tF3081DE4B67FBD9771C293C52885EC15C279810C * __this, String_t* ___subject0, String_t* ___payload1, String_t* ___receipt2, String_t* ___transactionId3, AsyncCallback_t3F3DA3BEDAEE81DD1D24125DF8EB30E85EE14DA4 * ___callback4, RuntimeObject * ___object5, const RuntimeMethod* method)
{
	void *__d_args[5] = {0};
	__d_args[0] = ___subject0;
	__d_args[1] = ___payload1;
	__d_args[2] = ___receipt2;
	__d_args[3] = ___transactionId3;
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback4, (RuntimeObject*)___object5);
}
// System.Void UnityEngine.Purchasing.UnityPurchasingCallback::EndInvoke(System.IAsyncResult)
extern "C" IL2CPP_METHOD_ATTR void UnityPurchasingCallback_EndInvoke_mB5774D1C98FBFCCE2BADCD64D62D04AC2DADC177 (UnityPurchasingCallback_tF3081DE4B67FBD9771C293C52885EC15C279810C * __this, RuntimeObject* ___result0, const RuntimeMethod* method)
{
	il2cpp_codegen_delegate_end_invoke((Il2CppAsyncResult*) ___result0, 0);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
