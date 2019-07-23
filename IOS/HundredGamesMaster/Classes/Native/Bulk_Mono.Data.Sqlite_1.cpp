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
template <typename R, typename T1, typename T2, typename T3, typename T4, typename T5>
struct VirtFuncInvoker5
{
	typedef R (*Func)(void*, T1, T2, T3, T4, T5, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, p3, p4, p5, invokeData.method);
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
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6>
struct VirtActionInvoker6
{
	typedef void (*Action)(void*, T1, T2, T3, T4, T5, T6, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, p5, p6, invokeData.method);
	}
};
template <typename R, typename T1, typename T2, typename T3>
struct VirtFuncInvoker3
{
	typedef R (*Func)(void*, T1, T2, T3, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2, T3 p3)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, p3, invokeData.method);
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

// Mono.Data.Sqlite.SQLiteBase
struct SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699;
// Mono.Data.Sqlite.SQLiteCallback
struct SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22;
// Mono.Data.Sqlite.SQLiteCollation
struct SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B;
// Mono.Data.Sqlite.SQLiteCommitCallback
struct SQLiteCommitCallback_t4A2F244F9FCADC58BAEFCDB1F9A4AEA018294B4F;
// Mono.Data.Sqlite.SQLiteCommitHandler
struct SQLiteCommitHandler_t52225EF37741FF54E821E0BB250CF29BC4C4D97E;
// Mono.Data.Sqlite.SQLiteEnlistment
struct SQLiteEnlistment_t67F908A6773D493F8205DF68972AABB98085B494;
// Mono.Data.Sqlite.SQLiteFinalCallback
struct SQLiteFinalCallback_tDADE001E38D3B50F9259C9D956A11D3B4D875453;
// Mono.Data.Sqlite.SQLiteRollbackCallback
struct SQLiteRollbackCallback_t0879E30A50B184087AFBA2EC348DAF30A4646D8A;
// Mono.Data.Sqlite.SQLiteTypeNames[]
struct SQLiteTypeNamesU5BU5D_t8BB731A7E5681259586D843C75AA295972D1D5EA;
// Mono.Data.Sqlite.SQLiteType[]
struct SQLiteTypeU5BU5D_tE231A43BBC9182DD6A96128D1840BD3FD4440644;
// Mono.Data.Sqlite.SQLiteUpdateCallback
struct SQLiteUpdateCallback_t3252735A38A0D75E6E9CB742FBFB194CD942712F;
// Mono.Data.Sqlite.SQLiteUpdateEventHandler
struct SQLiteUpdateEventHandler_t36E8A27FD858F0A7228A1E41FB87DD693D3C4AC8;
// Mono.Data.Sqlite.SqliteCommand
struct SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365;
// Mono.Data.Sqlite.SqliteCommandBuilder
struct SqliteCommandBuilder_tB1BC265E1A177F0CEC2518E29F44C25E6CFBFB64;
// Mono.Data.Sqlite.SqliteConnection
struct SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2;
// Mono.Data.Sqlite.SqliteConvert
struct SqliteConvert_t9FED20EF4CA9E373EBD857ECBA9C74B6307EE6E7;
// Mono.Data.Sqlite.SqliteDataReader
struct SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69;
// Mono.Data.Sqlite.SqliteException
struct SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6;
// Mono.Data.Sqlite.SqliteFactory
struct SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7;
// Mono.Data.Sqlite.SqliteFunction
struct SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B;
// Mono.Data.Sqlite.SqliteFunction/AggregateData
struct AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755;
// Mono.Data.Sqlite.SqliteFunctionAttribute
struct SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD;
// Mono.Data.Sqlite.SqliteFunctionAttribute[]
struct SqliteFunctionAttributeU5BU5D_t9F2FD4AAE7DD86A410B87458717B795133C08EF6;
// Mono.Data.Sqlite.SqliteFunction[]
struct SqliteFunctionU5BU5D_t8AFADE2E07F0DC165BCF00EA921B1DB88D1A160F;
// Mono.Data.Sqlite.SqliteKeyReader
struct SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793;
// Mono.Data.Sqlite.SqliteKeyReader/KeyInfo[]
struct KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4;
// Mono.Data.Sqlite.SqliteKeyReader/KeyQuery
struct KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4;
// Mono.Data.Sqlite.SqliteParameter
struct SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E;
// Mono.Data.Sqlite.SqliteParameterCollection
struct SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523;
// Mono.Data.Sqlite.SqliteParameter[]
struct SqliteParameterU5BU5D_t76F2417476AE80EE92606466B015185F4EEF2C27;
// Mono.Data.Sqlite.SqliteStatement
struct SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A;
// Mono.Data.Sqlite.SqliteStatementHandle
struct SqliteStatementHandle_t6121E676E0AB6EA25E9168EB18C7A064E83DBBBE;
// Mono.Data.Sqlite.SqliteStatement[]
struct SqliteStatementU5BU5D_t7674D72DA7D8260C0E759CCDD34C29166C2E231C;
// Mono.Data.Sqlite.SqliteTransaction
struct SqliteTransaction_t588D1AEC987A56478BF3B4254D6F83A4740F1560;
// Mono.Data.Sqlite.TypeAffinity[]
struct TypeAffinityU5BU5D_t6635EBE59009DFC162BD783072F772B336F3A288;
// System.AppDomain
struct AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8;
// System.ArgumentException
struct ArgumentException_tEDCD16F20A09ECE461C3DA766C16EDA8864057D1;
// System.ArgumentNullException
struct ArgumentNullException_t581DF992B1F3E0EC6EFB30CC5DC43519A79B27AD;
// System.ArgumentOutOfRangeException
struct ArgumentOutOfRangeException_t94D19DF918A54511AEDF4784C9A08741BAD1DEDA;
// System.AssemblyLoadEventHandler
struct AssemblyLoadEventHandler_t53F8340027F9EE67E8A22E7D8C1A3770345153C9;
// System.AsyncCallback
struct AsyncCallback_t3F3DA3BEDAEE81DD1D24125DF8EB30E85EE14DA4;
// System.Byte[]
struct ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821;
// System.Char[]
struct CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2;
// System.Collections.Generic.Dictionary`2/Entry<System.Int64,Mono.Data.Sqlite.SqliteFunction/AggregateData>[]
struct EntryU5BU5D_tEC0B53694229BD41D0F484C7CFE5964202A03AE6;
// System.Collections.Generic.Dictionary`2/Entry<System.String,System.Collections.Generic.List`1<System.String>>[]
struct EntryU5BU5D_tA5B97EA90D4BE7F710BABB9A39F974A38394D3C0;
// System.Collections.Generic.Dictionary`2/Entry<System.String,System.Int32>[]
struct EntryU5BU5D_tAD4FDE2B2578C6625A7296B1C46DCB06DCB45186;
// System.Collections.Generic.Dictionary`2/KeyCollection<System.Int64,Mono.Data.Sqlite.SqliteFunction/AggregateData>
struct KeyCollection_t8A750217C1CC343BE0B88C820DCEE5525A1D67A8;
// System.Collections.Generic.Dictionary`2/KeyCollection<System.String,System.Collections.Generic.List`1<System.String>>
struct KeyCollection_t1BABBEA8121C5B4211355214E8C46B26B8DFC956;
// System.Collections.Generic.Dictionary`2/KeyCollection<System.String,System.Int32>
struct KeyCollection_t666396E67E50284D48938851873CE562083D67F2;
// System.Collections.Generic.Dictionary`2/ValueCollection<System.Int64,Mono.Data.Sqlite.SqliteFunction/AggregateData>
struct ValueCollection_tB817FAD5802BC4B63621952300D59847EE6B3490;
// System.Collections.Generic.Dictionary`2/ValueCollection<System.String,System.Collections.Generic.List`1<System.String>>
struct ValueCollection_t745348FB9874C30D8D3EA37349A25BACE57545DD;
// System.Collections.Generic.Dictionary`2/ValueCollection<System.String,System.Int32>
struct ValueCollection_t532E2FD863D0D47B87202BE6B4F7C7EDB5DD7CBF;
// System.Collections.Generic.Dictionary`2<System.Int32,System.Globalization.CultureInfo>
struct Dictionary_2_tC88A56872F7C79DBB9582D4F3FC22ED5D8E0B98B;
// System.Collections.Generic.Dictionary`2<System.Int64,Mono.Data.Sqlite.SqliteFunction/AggregateData>
struct Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3;
// System.Collections.Generic.Dictionary`2<System.Int64,System.Object>
struct Dictionary_2_tBB5CC0896C16F33861F997E1B67002AC4E1F2B8A;
// System.Collections.Generic.Dictionary`2<System.Object,System.Int32>
struct Dictionary_2_t81923CE2A312318AE13F58085CCF7FA8D879B77A;
// System.Collections.Generic.Dictionary`2<System.Object,System.Object>
struct Dictionary_2_t32F25F093828AA9F93CB11C2A2B4648FD62A09BA;
// System.Collections.Generic.Dictionary`2<System.String,System.Collections.Generic.List`1<System.String>>
struct Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF;
// System.Collections.Generic.Dictionary`2<System.String,System.Globalization.CultureInfo>
struct Dictionary_2_tBA5388DBB42BF620266F9A48E8B859BBBB224E25;
// System.Collections.Generic.Dictionary`2<System.String,System.Int32>
struct Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB;
// System.Collections.Generic.Dictionary`2<System.String,System.Object>
struct Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA;
// System.Collections.Generic.IEqualityComparer`1<System.Int64>
struct IEqualityComparer_1_t57AACDEDED3C147134F40F07A1E196DEEFA4AB12;
// System.Collections.Generic.IEqualityComparer`1<System.String>
struct IEqualityComparer_1_t1F07EAC22CC1D4F279164B144240E4718BD7E7A9;
// System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteFunction>
struct List_1_tC332B4E87767ADFB1672A499D53D94AE897CD4A3;
// System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteFunctionAttribute>
struct List_1_t575BD1306846C6646814C99C87872FD64E8954AB;
// System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteKeyReader/KeyInfo>
struct List_1_tD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD;
// System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteParameter>
struct List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657;
// System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteStatement>
struct List_1_t061A89EAEE080F1782627C91C598BD546671C91A;
// System.Collections.Generic.List`1<System.Data.DataColumn>
struct List_1_t70187E1F2F9140ADB155B98F17D5D765F84B9204;
// System.Collections.Generic.List`1<System.Data.DataView>
struct List_1_tD0DF2B545957BB968E2D9198A87C3B784F3837F8;
// System.Collections.Generic.List`1<System.Data.DataViewListener>
struct List_1_t1748BC8A0D25EE6A55AA236787A9AA35B5AF8808;
// System.Collections.Generic.List`1<System.Data.Index>
struct List_1_tA40E855828D2BD351AE459CC0CEFC5246704CDEA;
// System.Collections.Generic.List`1<System.Object>
struct List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D;
// System.Collections.Generic.List`1<System.String>
struct List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3;
// System.Collections.Hashtable
struct Hashtable_t978F65B8006C8F5504B286526AEC6608FF983FC9;
// System.Collections.IDictionary
struct IDictionary_t1BD5C1546718A374EA8122FBD6C6EE45331E8CE7;
// System.Collections.IEnumerator
struct IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A;
// System.ComponentModel.CollectionChangeEventArgs
struct CollectionChangeEventArgs_t63CA165C1F7D765B04CB139EB6577577479E57B0;
// System.ComponentModel.Component
struct Component_t7AEFE153F6778CF52E1981BC3E811A9604B29473;
// System.ComponentModel.EventHandlerList
struct EventHandlerList_tFE9EF79E85419EBB2C206CF475E29A9960699BE4;
// System.ComponentModel.ISite
struct ISite_t6804B48BC23ABB5F4141903F878589BCEF6097A2;
// System.ComponentModel.PropertyChangedEventHandler
struct PropertyChangedEventHandler_t617E98E1876A8EB394D2B329340CE02D21FFFC82;
// System.ComponentModel.PropertyDescriptorCollection
struct PropertyDescriptorCollection_t19FEFDD6CEF7609BB10282A4B52C3C09A04B41A2;
// System.Data.Common.DbCommand
struct DbCommand_t818F90E565B3D0FB3D6C653214D5C8E4211A5A55;
// System.Data.Common.DbCommandBuilder/ParameterNames
struct ParameterNames_tC8571837DB584F0E7ED76EEF1B6C27507CEB0755;
// System.Data.Common.DbDataAdapter
struct DbDataAdapter_tD491D36DE53638EDEC3069CE96717AD87D4225CA;
// System.Data.Common.DbDataReader
struct DbDataReader_t4CADA7880D6F85CABC4096FA5AE10C327A07CCD8;
// System.Data.Common.DbException
struct DbException_t7601D64CEA3E4A5396F01EDC71423DE6209F7F0D;
// System.Data.Common.DbParameter
struct DbParameter_tEE5AEAD8B429B8EF8994063C151A25A76B94B76F;
// System.Data.Common.DbParameterCollection
struct DbParameterCollection_t6FF3670B12D04B797F09E79DFEA4CF93E92D249C;
// System.Data.Common.DbProviderFactory
struct DbProviderFactory_tD097542E2A2591557E9349A9AA0C1DD301D50DD4;
// System.Data.Common.DbSchemaRow[]
struct DbSchemaRowU5BU5D_tBD2A74D689F73CA84C5390B2A586C6AE904C9A31;
// System.Data.Common.DbTransaction
struct DbTransaction_tADC1A857259448190F882AC47E0B18317779FE56;
// System.Data.ConstraintCollection
struct ConstraintCollection_t349E02C7469F2E3DF17D381D9BCACF8B7E7CCF62;
// System.Data.DataColumn
struct DataColumn_t397593FCD95F7B10FA2D2E706EFDA54B05E5835D;
// System.Data.DataColumnChangeEventHandler
struct DataColumnChangeEventHandler_tC860540A9091FE1BB1DF718AB44874A54585FE07;
// System.Data.DataColumnCollection
struct DataColumnCollection_t398628201192B6EF9DB23A650DAB1E79CEA1796A;
// System.Data.DataColumn[]
struct DataColumnU5BU5D_t5E093A4F34F11AFCA04923FE842DCC5ED1B398BC;
// System.Data.DataError
struct DataError_tD52C55EF7C5FABAA58B11DBB0C55BE671F18F786;
// System.Data.DataExpression
struct DataExpression_tECCBF728C87CAF0185856F73F7DB54BB94EF094D;
// System.Data.DataRelationCollection
struct DataRelationCollection_tB592C84F2EE6B60DFB933CC67B8DE1065098269B;
// System.Data.DataRelation[]
struct DataRelationU5BU5D_t705BDBA68D45143524D5C70D82EA04F0B676C15B;
// System.Data.DataRow
struct DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B;
// System.Data.DataRowBuilder
struct DataRowBuilder_t1686A02FA53DF491D826A981024C255668E94CC6;
// System.Data.DataRowChangeEventHandler
struct DataRowChangeEventHandler_t528DC5369A320B2397E1E5CF4E27CC518C0C72A0;
// System.Data.DataRowCollection
struct DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0;
// System.Data.DataRowCollection/DataRowTree
struct DataRowTree_t885C3CBC17060B726BFEE177710D6E9E57FEA230;
// System.Data.DataRow[]
struct DataRowU5BU5D_tCA5181B3540ACD7702228F224388EA4B4F5885CA;
// System.Data.DataSet
struct DataSet_t6D7B0F1EC989A523B88F4BDABABD8B828631E1B8;
// System.Data.DataTable
struct DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863;
// System.Data.DataTableClearEventHandler
struct DataTableClearEventHandler_t661CB2EAAB20D6574190694F4DDD86BDD06FA982;
// System.Data.DataTableNewRowEventHandler
struct DataTableNewRowEventHandler_tA2A38967A9C8796075CBF1C31585C4C6E3C6F43B;
// System.Data.DataView
struct DataView_t6489092472EA45039A541483F0E43D26C6723E4C;
// System.Data.DbType[]
struct DbTypeU5BU5D_tD00A0B946DB9A3654BCF020D2E36A47C1DE81DB3;
// System.Data.Index
struct Index_t0B13AD066A6CAA0045DCA5BB8912F8E599BE9AF7;
// System.Data.IndexField[]
struct IndexFieldU5BU5D_tE0FF1739A3834C07A83EAF2EC3B32E14CC967548;
// System.Data.PropertyCollection
struct PropertyCollection_tA766717BE7105BC47681AD434BF66003DEDB68F4;
// System.Data.RecordManager
struct RecordManager_t923097B51945932B6775CB40CF53683A864A3C65;
// System.Data.StateChangeEventHandler
struct StateChangeEventHandler_tCBE614D6F8C0E81076DE3A3368E258B6F1B1C6F1;
// System.Data.UniqueConstraint
struct UniqueConstraint_t291F6C173D4820C1ACAE889805C3649A44DC1D22;
// System.DelegateData
struct DelegateData_t1BF9F691B56DAE5F8C28C5E084FDE94F15F27BBE;
// System.Delegate[]
struct DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86;
// System.Diagnostics.StackTrace[]
struct StackTraceU5BU5D_t855F09649EA34DEE7C1B6F088E0538E3CCC3F196;
// System.EventHandler
struct EventHandler_t2B84E745E28BA26C49C4E99A387FC3B534D1110C;
// System.EventHandler`1<System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs>
struct EventHandler_1_t1E35ED2E29145994C6C03E57601C6D48C61083FF;
// System.Exception[]
struct ExceptionU5BU5D_t09C3EFFA7CF3F84DA802016E2017E1608442F209;
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
// System.Int32[]
struct Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83;
// System.IntPtr[]
struct IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD;
// System.InvalidCastException
struct InvalidCastException_t91DF9E7D7FCCDA6C562CB4A9A18903E016680FDA;
// System.NotImplementedException
struct NotImplementedException_t8AD6EBE5FEDB0AEBECEE0961CF73C35B372EFFA4;
// System.NotSupportedException
struct NotSupportedException_tE75B318D6590A02A5D9B29FD97409B1750FA0010;
// System.Object[]
struct ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A;
// System.Reflection.Assembly
struct Assembly_t;
// System.Reflection.Assembly/ResolveEventHolder
struct ResolveEventHolder_t5267893EB7CB9C12F7B9B463FD4C221BEA03326E;
// System.Reflection.AssemblyName
struct AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82;
// System.Reflection.Assembly[]
struct AssemblyU5BU5D_t90BF014AA048450526A42C74F9583341A138DE58;
// System.Reflection.Binder
struct Binder_t4D5CB06963501D32847C057B57157D6DC49CA759;
// System.Reflection.MemberFilter
struct MemberFilter_t25C1BD92C42BE94426E300787C13C452CB89B381;
// System.Reflection.MethodInfo
struct MethodInfo_t;
// System.Reflection.ReflectionTypeLoadException
struct ReflectionTypeLoadException_t1306B3A246E2959E8F23575AAAB9D59945314115;
// System.Reflection.StrongNameKeyPair
struct StrongNameKeyPair_tD9AA282E59F4526338781AFD862680ED461FCCFD;
// System.ResolveEventHandler
struct ResolveEventHandler_t045C469BEA8B632FA99FE8867C921BA8DAE0BEE5;
// System.Runtime.InteropServices.CriticalHandle
struct CriticalHandle_tDF3AA1D1AA9E07599C316DB1C5449D3FB7BFD4C9;
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
// System.StringComparer
struct StringComparer_t588BC7FEF85D6E7425E0A8147A3D5A334F1F82DE;
// System.String[]
struct StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E;
// System.Text.Encoding
struct Encoding_t7837A3C0F55EAE0E3959A53C6D6E88B113ED78A4;
// System.Threading.ReaderWriterLockSlim
struct ReaderWriterLockSlim_tD820AC67812C645B2F8C16ABB4DE694A19D6A315;
// System.Type
struct Type_t;
// System.Type[]
struct TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F;
// System.UInt32[]
struct UInt32U5BU5D_t9AA834AF2940E75BBF8E3F08FF0D20D266DB71CB;
// System.UnhandledExceptionEventHandler
struct UnhandledExceptionEventHandler_tB0DFF05ABF7A3A234C87D4F7A71F98E9AB2D91DE;
// System.Version
struct Version_tDBE6876C59B6F56D4F8CAA03851177ABC6FE0DFD;
// System.Void
struct Void_t22962CB4C05B1D89B55A6E1139F0E87A90987017;
// System.WeakReference
struct WeakReference_t0495CC81CD6403E662B7700B802443F6F730E39D;

extern RuntimeClass* AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755_il2cpp_TypeInfo_var;
extern RuntimeClass* ArgumentException_tEDCD16F20A09ECE461C3DA766C16EDA8864057D1_il2cpp_TypeInfo_var;
extern RuntimeClass* ArgumentNullException_t581DF992B1F3E0EC6EFB30CC5DC43519A79B27AD_il2cpp_TypeInfo_var;
extern RuntimeClass* ArgumentOutOfRangeException_t94D19DF918A54511AEDF4784C9A08741BAD1DEDA_il2cpp_TypeInfo_var;
extern RuntimeClass* Boolean_tB53F6830F670160873277339AA58F15CAED4399C_il2cpp_TypeInfo_var;
extern RuntimeClass* ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821_il2cpp_TypeInfo_var;
extern RuntimeClass* CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2_il2cpp_TypeInfo_var;
extern RuntimeClass* Convert_t1C7A851BFB2F0782FD7F72F6AA1DCBB7B53A9C7E_il2cpp_TypeInfo_var;
extern RuntimeClass* CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_il2cpp_TypeInfo_var;
extern RuntimeClass* DBNull_t7400E04939C2C29699B389B106997892BF53A8E5_il2cpp_TypeInfo_var;
extern RuntimeClass* DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B_il2cpp_TypeInfo_var;
extern RuntimeClass* DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132_il2cpp_TypeInfo_var;
extern RuntimeClass* DbType_t46DC393C53E0CB52DF1792FD357A7E596C5F432E_il2cpp_TypeInfo_var;
extern RuntimeClass* Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB_il2cpp_TypeInfo_var;
extern RuntimeClass* Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF_il2cpp_TypeInfo_var;
extern RuntimeClass* Double_t358B8F23BDC52A5DD700E727E204F9F7CDE12409_il2cpp_TypeInfo_var;
extern RuntimeClass* Enumerator_t38C41296850665F3643D772F9790D4B3880BD9AA_il2cpp_TypeInfo_var;
extern RuntimeClass* Enumerator_tA18C55D69C7008726BD92603BF88561F27BB708A_il2cpp_TypeInfo_var;
extern RuntimeClass* Enumerator_tB5FE7F21928FA8D45CBB7BD3D57A481548319510_il2cpp_TypeInfo_var;
extern RuntimeClass* Enumerator_tC72BD0EE9002D5F9476F8E5D172DD8D523493303_il2cpp_TypeInfo_var;
extern RuntimeClass* Exception_t_il2cpp_TypeInfo_var;
extern RuntimeClass* Guid_t_il2cpp_TypeInfo_var;
extern RuntimeClass* IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var;
extern RuntimeClass* IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var;
extern RuntimeClass* Int32_t585191389E07734F19F3156FF88FB3EF4800D102_il2cpp_TypeInfo_var;
extern RuntimeClass* Int64_t7A386C2FF7B0280A0F516992401DDFCF0FF7B436_il2cpp_TypeInfo_var;
extern RuntimeClass* IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD_il2cpp_TypeInfo_var;
extern RuntimeClass* IntPtr_t_il2cpp_TypeInfo_var;
extern RuntimeClass* InvalidCastException_t91DF9E7D7FCCDA6C562CB4A9A18903E016680FDA_il2cpp_TypeInfo_var;
extern RuntimeClass* KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4_il2cpp_TypeInfo_var;
extern RuntimeClass* KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4_il2cpp_TypeInfo_var;
extern RuntimeClass* List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657_il2cpp_TypeInfo_var;
extern RuntimeClass* List_1_t575BD1306846C6646814C99C87872FD64E8954AB_il2cpp_TypeInfo_var;
extern RuntimeClass* List_1_tC332B4E87767ADFB1672A499D53D94AE897CD4A3_il2cpp_TypeInfo_var;
extern RuntimeClass* List_1_tD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD_il2cpp_TypeInfo_var;
extern RuntimeClass* List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3_il2cpp_TypeInfo_var;
extern RuntimeClass* Marshal_tC795CE9CC2FFBA41EDB1AC1C0FEC04607DFA8A40_il2cpp_TypeInfo_var;
extern RuntimeClass* Math_tFB388E53C7FDC6FCCF9A19ABF5A4E521FBD52E19_il2cpp_TypeInfo_var;
extern RuntimeClass* NotImplementedException_t8AD6EBE5FEDB0AEBECEE0961CF73C35B372EFFA4_il2cpp_TypeInfo_var;
extern RuntimeClass* NotSupportedException_tE75B318D6590A02A5D9B29FD97409B1750FA0010_il2cpp_TypeInfo_var;
extern RuntimeClass* ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A_il2cpp_TypeInfo_var;
extern RuntimeClass* ReflectionTypeLoadException_t1306B3A246E2959E8F23575AAAB9D59945314115_il2cpp_TypeInfo_var;
extern RuntimeClass* RuntimeObject_il2cpp_TypeInfo_var;
extern RuntimeClass* SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699_il2cpp_TypeInfo_var;
extern RuntimeClass* SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22_il2cpp_TypeInfo_var;
extern RuntimeClass* SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B_il2cpp_TypeInfo_var;
extern RuntimeClass* SQLiteFinalCallback_tDADE001E38D3B50F9259C9D956A11D3B4D875453_il2cpp_TypeInfo_var;
extern RuntimeClass* SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_il2cpp_TypeInfo_var;
extern RuntimeClass* SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_il2cpp_TypeInfo_var;
extern RuntimeClass* SqliteCommandBuilder_tB1BC265E1A177F0CEC2518E29F44C25E6CFBFB64_il2cpp_TypeInfo_var;
extern RuntimeClass* SqliteConvert_t9FED20EF4CA9E373EBD857ECBA9C74B6307EE6E7_il2cpp_TypeInfo_var;
extern RuntimeClass* SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6_il2cpp_TypeInfo_var;
extern RuntimeClass* SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7_il2cpp_TypeInfo_var;
extern RuntimeClass* SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD_il2cpp_TypeInfo_var;
extern RuntimeClass* SqliteFunctionEx_t7D4B1395222C65E48CBA8BF483FEAEEA24FFC75A_il2cpp_TypeInfo_var;
extern RuntimeClass* SqliteFunctionU5BU5D_t8AFADE2E07F0DC165BCF00EA921B1DB88D1A160F_il2cpp_TypeInfo_var;
extern RuntimeClass* SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B_il2cpp_TypeInfo_var;
extern RuntimeClass* SqliteParameterU5BU5D_t76F2417476AE80EE92606466B015185F4EEF2C27_il2cpp_TypeInfo_var;
extern RuntimeClass* SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E_il2cpp_TypeInfo_var;
extern RuntimeClass* SqliteStatementHandle_t6121E676E0AB6EA25E9168EB18C7A064E83DBBBE_il2cpp_TypeInfo_var;
extern RuntimeClass* StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E_il2cpp_TypeInfo_var;
extern RuntimeClass* String_t_il2cpp_TypeInfo_var;
extern RuntimeClass* Type_t_il2cpp_TypeInfo_var;
extern RuntimeField* U3CPrivateImplementationDetailsU3E_t0F71ABB0B2D76FF373FCA1CFC6711DBF4293313F____U24U24fieldU2D1_1_FieldInfo_var;
extern String_t* _stringLiteral08868372FCC6DF03923FF0A62B6740AAB4B59A1D;
extern String_t* _stringLiteral1178CAFBD64BBBFA77F5AC0A9D5032ED88162781;
extern String_t* _stringLiteral17E4D773881595E83EED7274990576CB3C33D081;
extern String_t* _stringLiteral193DAF137ED8B89DE36D47C3DF5FD8F66C0E1D14;
extern String_t* _stringLiteral1E5C2F367F02E47A8C160CDA1CD9D91DECBAC441;
extern String_t* _stringLiteral2301A3AED57BDF6FA84FA74B2553B52161EE1A1B;
extern String_t* _stringLiteral246AFB2A711D8CCEC2D90C6953074DABA1E3FF7E;
extern String_t* _stringLiteral2ACE62C1BEFA19E3EA37DD52BE9F6D508C5163E6;
extern String_t* _stringLiteral2ADF0A0954741E1AF5766479C5643CD51B0B69B5;
extern String_t* _stringLiteral2CE42E824F2163751D62C49D3226C338EFA1179D;
extern String_t* _stringLiteral2D14AB97CC3DC294C51C0D6814F4EA45F4B4E312;
extern String_t* _stringLiteral3598517C826F1480A241800CE73F781AE2B1CD6A;
extern String_t* _stringLiteral40EA9041285003E004A8F6FE2DD14EBB07961AF2;
extern String_t* _stringLiteral4152C03A902AA9F8A5A2B4A510C2AB07BF79F058;
extern String_t* _stringLiteral427AF4F4D3D5F55621070F2B61A550075D057138;
extern String_t* _stringLiteral4821EDEB87E72FFADC6BC2DD7758D1AF495E515F;
extern String_t* _stringLiteral4FF447B8EF42CA51FA6FB287BED8D40F49BE58F1;
extern String_t* _stringLiteral5277F74EC6B2C07897AE08C4150298F4A47BFEE7;
extern String_t* _stringLiteral56184EC642B956FAF32203EDC14DB32A5BB3377F;
extern String_t* _stringLiteral58DF3A419CF3B1ABF1540CA19363117D737798BC;
extern String_t* _stringLiteral58F69C9012CFB997F9D3FFE4F607D66F6E932A1F;
extern String_t* _stringLiteral5C10B5B2CD673A0616D529AA5234B12EE7153808;
extern String_t* _stringLiteral5E44B1AE3D4CE260D0B6E54DFE79B9E83C8A047E;
extern String_t* _stringLiteral5F97F8775628E86310829AB9E8C465258AB92A5E;
extern String_t* _stringLiteral5FC00849B213BD1E4B88D515FA3A807DCB282C84;
extern String_t* _stringLiteral62F94C337A62422091EEC8AF220557BC9D2A0F7D;
extern String_t* _stringLiteral634EC12D9C33E3B4FA5EE77192789853C0944473;
extern String_t* _stringLiteral654053DB7D1826E8BC0FB8C5C17C5E62B7C9C87C;
extern String_t* _stringLiteral660C1D424389A5FB82204BA7BB89B07419AAC1C0;
extern String_t* _stringLiteral66D2C601FBFA7B406B77381952D6A78FC0BD2564;
extern String_t* _stringLiteral66D5524BC6E9A905BCD8AD67AE1EB457C570B564;
extern String_t* _stringLiteral78B3F17895B8C6A1EC55D26A5815C6B3E2F691AD;
extern String_t* _stringLiteral79AEF385243E2292791E733AF2A99ACEF86C3DCE;
extern String_t* _stringLiteral7E15BB5C01E7DD56499E37C634CF791D3A519AEE;
extern String_t* _stringLiteral7F97480B11C2DFEFA56814087360C69E4B05A84D;
extern String_t* _stringLiteral805E631B2C4331634631AB9D3D378E6F37AE988C;
extern String_t* _stringLiteral84B715DD42CB515250F3406C66517DD9D7115450;
extern String_t* _stringLiteral89865DF2AE553E13CE078A7680590FE066489642;
extern String_t* _stringLiteral89F89C02CF47E091E726A4E07B88AF0966806897;
extern String_t* _stringLiteral96B270E30E3C5C4FDE9E03F6B30D4F2F1657F16C;
extern String_t* _stringLiteral99B3C2C49461425BF6CFF4391127F75D483D0614;
extern String_t* _stringLiteral9BD63A04AE7FE42E2B683DEF764089A3D56FFE25;
extern String_t* _stringLiteral9BF86E4634BA8C788A847BD10019CC0D59BCC00C;
extern String_t* _stringLiteralA7362D38845D769AB9292607291056855E2183B1;
extern String_t* _stringLiteralAB2A2923359CC254D1142CB254FA079493CE8064;
extern String_t* _stringLiteralB858CB282617FB0956D960215C8E84D1CCF909C6;
extern String_t* _stringLiteralBA7B74E6880085D4646D2D47931AD9243932EB41;
extern String_t* _stringLiteralBA8AB5A0280B953AA97435FF8946CBCBB2755A27;
extern String_t* _stringLiteralBB4B470AC8E8BC7DB9A08102DEBACDD14B1D6379;
extern String_t* _stringLiteralC039B00BFF507642D69C98D494E70774AA200821;
extern String_t* _stringLiteralC41E97B906298C39611A796CAB1539411C1CF874;
extern String_t* _stringLiteralC9E6A29D14F3F27CD2EE75B65407552AD50A3078;
extern String_t* _stringLiteralCF0AD5ADA4DB8ECDE7F83BAC072E7C784CDC3F1F;
extern String_t* _stringLiteralD1C6600798D630F9B1438048EE63D61789E1AF88;
extern String_t* _stringLiteralD1D50AF319576CA6C6CBA296631E193D490A5370;
extern String_t* _stringLiteralD87C8562414047004383CEFAB06DDE994AB29260;
extern String_t* _stringLiteralD99C226D02CB06DF9C4F96D0E0140B91C9B8F41F;
extern String_t* _stringLiteralDC2DB8AB152AE696D77BDC87D45929DEB94DE5DC;
extern String_t* _stringLiteralDD64AB817AB410403092565BB65F18EDEE243B7F;
extern String_t* _stringLiteralDF063BF53C8E8CB3FD9AA4249D1FA6357775527C;
extern String_t* _stringLiteralED503B617B69F0DA3889F48E0D624A31DABDAE45;
extern String_t* _stringLiteralF0057D58EF952A7C3FAC90EE4D6ACBCD891B847A;
extern String_t* _stringLiteralF642EE196088372EA886186C6C617515599AFD3F;
extern String_t* _stringLiteralF6ECAD2FBBDD77D9B35BA368C2417FA482DD0A58;
extern String_t* _stringLiteralFF736B7140FADCCC4ABF6A7A3CAA5B49362CE730;
extern const RuntimeMethod* Dictionary_2_Add_m5453726952CE3720733822DBF38A0091037F0F76_RuntimeMethod_var;
extern const RuntimeMethod* Dictionary_2_Add_m77DD1AAE607EDC7C550C45F4AC4FC935DF0380CC_RuntimeMethod_var;
extern const RuntimeMethod* Dictionary_2_Clear_m850B2AC5BADCAF602C38B462F787A0D00CD3D950_RuntimeMethod_var;
extern const RuntimeMethod* Dictionary_2_ContainsKey_m425FDC14DB7C7CAA236D528A12C3DB3577AD0C96_RuntimeMethod_var;
extern const RuntimeMethod* Dictionary_2_ContainsKey_m81AE5386AFCDA3805EA9ADCC78F00C3EF903428A_RuntimeMethod_var;
extern const RuntimeMethod* Dictionary_2_GetEnumerator_m24CA20639785613D0692E7B7813D7525CA3E3FCF_RuntimeMethod_var;
extern const RuntimeMethod* Dictionary_2_GetEnumerator_mF81DC76A58E19C2640CF6C8BE06F78361512F6E6_RuntimeMethod_var;
extern const RuntimeMethod* Dictionary_2_Remove_mFA8845405F1AE81B12E4078977BE667CCC962ECB_RuntimeMethod_var;
extern const RuntimeMethod* Dictionary_2_TryGetValue_m7F2FAA8FE25A7B605BF2247E4719C18AD9D18B18_RuntimeMethod_var;
extern const RuntimeMethod* Dictionary_2__ctor_m20A5B6C6950ACF998FE28F7FACEA19C755593E62_RuntimeMethod_var;
extern const RuntimeMethod* Dictionary_2__ctor_mEAAF465A79EE99997A8CF0556CEC5334BCE44EF2_RuntimeMethod_var;
extern const RuntimeMethod* Dictionary_2_get_Item_m1A6FE099B56685CD45A75254ABA787E313A5D792_RuntimeMethod_var;
extern const RuntimeMethod* Dictionary_2_get_Item_m1F9B397B583526C8C45854B8B60A308A2227F889_RuntimeMethod_var;
extern const RuntimeMethod* Dictionary_2_get_Item_m8B16E8CBD6B9EE71984601DB60ADB40673ADD5CC_RuntimeMethod_var;
extern const RuntimeMethod* Dictionary_2_set_Item_m6307BB9AD542728546442D9CE477BC5815AE1412_RuntimeMethod_var;
extern const RuntimeMethod* Enumerator_Dispose_m20DEE1B61D35A4F881D24FDE0FC3E8C0A7DBF89D_RuntimeMethod_var;
extern const RuntimeMethod* Enumerator_Dispose_m2B9B3D7D2D9369C06369FD5D7D9A75660ADF6A46_RuntimeMethod_var;
extern const RuntimeMethod* Enumerator_Dispose_m69EFA6DF9BD1ACE3D21EC0B240A2FB37E3AC96D0_RuntimeMethod_var;
extern const RuntimeMethod* Enumerator_Dispose_mA0BB472958EA47C65935F98FBEF0EAACFEACCE0D_RuntimeMethod_var;
extern const RuntimeMethod* Enumerator_MoveNext_m1534F8F536B5DDFE0019172C7CD4B38969DBE226_RuntimeMethod_var;
extern const RuntimeMethod* Enumerator_MoveNext_m37DC9F68F91CA42C4DF0800613544AFFE63A4076_RuntimeMethod_var;
extern const RuntimeMethod* Enumerator_MoveNext_mAA17145AA0994543090AFFF741659D345AC64F9F_RuntimeMethod_var;
extern const RuntimeMethod* Enumerator_MoveNext_mF5DE5F7301F752CEF6FC1274061C972E315C5018_RuntimeMethod_var;
extern const RuntimeMethod* Enumerator_get_Current_m0C79D6B8A354C9E3D29D7B654F902B30868E0949_RuntimeMethod_var;
extern const RuntimeMethod* Enumerator_get_Current_m152C218D70BA6E16353FC590C1A91BE28782074D_RuntimeMethod_var;
extern const RuntimeMethod* Enumerator_get_Current_m48D218F99C929FE08EB673C9DC0B5A5FBDE5820F_RuntimeMethod_var;
extern const RuntimeMethod* Enumerator_get_Current_m7FA4FE3198E9A2BC1613C4C7107826F8FF14C1A3_RuntimeMethod_var;
extern const RuntimeMethod* KeyQuery_set_IsValid_mA4632D8CAB6B73258A401162467D7CB5C7E73B6D_RuntimeMethod_var;
extern const RuntimeMethod* KeyValuePair_2_get_Key_m30085F04A06E53139F92FFF128B01098A85D75E4_RuntimeMethod_var;
extern const RuntimeMethod* KeyValuePair_2_get_Value_m37365A13759E8A8548BE04A755D69B74D6BBF2AB_RuntimeMethod_var;
extern const RuntimeMethod* KeyValuePair_2_get_Value_m8476A7D87325D4D7A32A4FFF66D2F2AEE1C30E36_RuntimeMethod_var;
extern const RuntimeMethod* List_1_Add_m2E293E26CF280C896A634CC8D9DD5E622583050F_RuntimeMethod_var;
extern const RuntimeMethod* List_1_Add_m335FACF62F79155D36F4BD6E4CE541AFBCCCDAEA_RuntimeMethod_var;
extern const RuntimeMethod* List_1_Add_m37ACF8547D171B0E3F525F0F9DEC80D46E9673C3_RuntimeMethod_var;
extern const RuntimeMethod* List_1_Add_mA348FA1140766465189459D25B01EB179001DE83_RuntimeMethod_var;
extern const RuntimeMethod* List_1_Add_mDB86C4D19D3AFD79C5C0CEB04AC08E5A8C5353D6_RuntimeMethod_var;
extern const RuntimeMethod* List_1_Clear_m03F5799F64050A07C3C1144F3492F3E44B715707_RuntimeMethod_var;
extern const RuntimeMethod* List_1_Contains_mB71B12DBCE2F9899460DF6F0DB4584748FAAE603_RuntimeMethod_var;
extern const RuntimeMethod* List_1_Contains_mC1D01A0D94C03E4225EEF9D6506D7D91C6976B7B_RuntimeMethod_var;
extern const RuntimeMethod* List_1_CopyTo_m152A529573840F5373AD90FD98B33D00070920FE_RuntimeMethod_var;
extern const RuntimeMethod* List_1_CopyTo_m95F1898958F30634E03CFF8A0CDC2F863259B2F4_RuntimeMethod_var;
extern const RuntimeMethod* List_1_CopyTo_mD3FBBD792230E4756C75F7F245B815CFEB65836A_RuntimeMethod_var;
extern const RuntimeMethod* List_1_GetEnumerator_m7E68AD2A26A6D8F70A2C5B6D22E0983B86407DF3_RuntimeMethod_var;
extern const RuntimeMethod* List_1_GetEnumerator_m92C59AC36F29D46CF1B7938CDC2C2241FC24907E_RuntimeMethod_var;
extern const RuntimeMethod* List_1_IndexOf_mA304FB7C0E2D8FA02C0D7A8A31F6BACE2D5E89FB_RuntimeMethod_var;
extern const RuntimeMethod* List_1_Insert_m4EF8AEFAFE722E8BD0BA8C841C92194EBFF18325_RuntimeMethod_var;
extern const RuntimeMethod* List_1_RemoveAt_m1408E3DEDB4B543DE4A55EFDB57226904F6967E4_RuntimeMethod_var;
extern const RuntimeMethod* List_1_RemoveAt_mD17877118EA5CCF90E0D36CF420287270492A0F2_RuntimeMethod_var;
extern const RuntimeMethod* List_1_Remove_m1A3186B1F195851183DDCD11C2A5190A6F70F11D_RuntimeMethod_var;
extern const RuntimeMethod* List_1__ctor_m0CAC003C972BC97F57D0BBC18BCF1BD28F6F18B3_RuntimeMethod_var;
extern const RuntimeMethod* List_1__ctor_m7E6858F17402F616F6E74BB4E9C06624018F6BFE_RuntimeMethod_var;
extern const RuntimeMethod* List_1__ctor_mB58ED77706DFDF497D9DEA17FE42A5C700DED840_RuntimeMethod_var;
extern const RuntimeMethod* List_1__ctor_mD4890D8BA3B1549E470AFD135AFB74728CD64516_RuntimeMethod_var;
extern const RuntimeMethod* List_1__ctor_mDA22758D73530683C950C5CCF39BDB4E7E1F3F06_RuntimeMethod_var;
extern const RuntimeMethod* List_1_get_Count_m0283B39AA2691EE274CBD01927A6175AC6C2F5BF_RuntimeMethod_var;
extern const RuntimeMethod* List_1_get_Count_m368529D7DE6BD7EBBA3E9FA3551350AFB4384EF8_RuntimeMethod_var;
extern const RuntimeMethod* List_1_get_Count_m4151A68BD4CB1D737213E7595F574987F8C812B4_RuntimeMethod_var;
extern const RuntimeMethod* List_1_get_Count_mBF71B71F277DBD1ECF0136FBEDB2F5DB5BC2D7E7_RuntimeMethod_var;
extern const RuntimeMethod* List_1_get_Count_mCAA6783F6B5B8ADE95B9FE96AACB89704F116A12_RuntimeMethod_var;
extern const RuntimeMethod* List_1_get_Item_mB739B0066E5F7EBDBA9978F24A73D26D4FAE5BED_RuntimeMethod_var;
extern const RuntimeMethod* List_1_get_Item_mC7944FE39CD3751E41C887D3901B49E003741BC2_RuntimeMethod_var;
extern const RuntimeMethod* List_1_get_Item_mD187885178D9436A3BEB6CF28A3C2AD837B26467_RuntimeMethod_var;
extern const RuntimeMethod* List_1_set_Item_mEDB88DF97C46BC3FD98495E2248B13827DB0E974_RuntimeMethod_var;
extern const RuntimeMethod* SqliteFunction_CompareCallback16_mD310867D85DB029BC1E7E2F48CD1210BD70A9162_RuntimeMethod_var;
extern const RuntimeMethod* SqliteFunction_CompareCallback_mBE735C82605FEF47F8B6E78E3CF04130049CA95D_RuntimeMethod_var;
extern const RuntimeMethod* SqliteFunction_FinalCallback_m68052B0AE75F0054D840A7E7E42B3019A61F0322_RuntimeMethod_var;
extern const RuntimeMethod* SqliteFunction_ScalarCallback_m3D05C042753B243F0AC40FC6C01A4D34E9897D44_RuntimeMethod_var;
extern const RuntimeMethod* SqliteFunction_StepCallback_m4CCDD48061DE3BF6A14CEDCF099829179E4F1878_RuntimeMethod_var;
extern const RuntimeMethod* SqliteKeyReader_GetBoolean_mF164552CBD10F49417C97F7FFF3454143AFE536C_RuntimeMethod_var;
extern const RuntimeMethod* SqliteKeyReader_GetInt32_m57C62C425E04BA112B42914E60A88E0BA147710F_RuntimeMethod_var;
extern const RuntimeMethod* SqliteKeyReader_GetInt64_m88F6AC8A38D351C10514E8BE8A6EC30F819C833A_RuntimeMethod_var;
extern const RuntimeMethod* SqliteKeyReader_GetString_m14BF706D0E90330C84A3F322D435728903F5EF46_RuntimeMethod_var;
extern const RuntimeMethod* SqliteKeyReader_Sync_mF6A76D7FF2131664DCAFC47426C77959060A7560_RuntimeMethod_var;
extern const RuntimeMethod* SqliteParameterCollection_CopyTo_m40835944C1939CF6CB6CB431742B56226376A643_RuntimeMethod_var;
extern const RuntimeMethod* SqliteParameter_set_Direction_m80D8677C3C1484EF27734AAB1FDC814CF24A1814_RuntimeMethod_var;
extern const RuntimeMethod* SqliteStatement_BindParameter_m5CB198F61BDB753FDF1067AB5B624BBB5E44E513_RuntimeMethod_var;
extern const RuntimeMethod* SqliteStatement_SetTypes_m21B385B07A712E6813527EF3590E0CA231F77F15_RuntimeMethod_var;
extern const RuntimeMethod* SqliteTransaction_IsValid_mFFDD476AD513E92FB025CB46A52D5734FAE54897_RuntimeMethod_var;
extern const RuntimeMethod* SqliteTransaction__ctor_m59995FF6874597512ED2217BBC41266B2A0F7CAF_RuntimeMethod_var;
extern const RuntimeType* DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132_0_0_0_var;
extern const RuntimeType* ISQLiteSchemaExtensions_t9BD0010F9CF0685AAAFFAF3EF5EDD9B2DCD8E772_0_0_0_var;
extern const RuntimeType* Int64_t7A386C2FF7B0280A0F516992401DDFCF0FF7B436_0_0_0_var;
extern const RuntimeType* SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD_0_0_0_var;
extern const uint32_t KeyQuery_Sync_m19A2575566EEFC07F5FC36F2E200FA23EE8A7390_MetadataUsageId;
extern const uint32_t KeyQuery__ctor_m3095086FBBB97A6899ED7F47A9F349AC1D767E83_MetadataUsageId;
extern const uint32_t KeyQuery_set_IsValid_mA4632D8CAB6B73258A401162467D7CB5C7E73B6D_MetadataUsageId;
extern const uint32_t SqliteException_GetStockErrorMessage_mE888DD0F857775252F88B86D4B072AFADC9D9BC3_MetadataUsageId;
extern const uint32_t SqliteException__cctor_m1083BC3EF38EEE9940DC7796BC0D748910FFBBEB_MetadataUsageId;
extern const uint32_t SqliteException__ctor_m6FC576E18D88881DC33CAFC00042DCCF5D70F057_MetadataUsageId;
extern const uint32_t SqliteFactory_GetSQLiteProviderServicesInstance_m54787EE0DDCA751DC83B454F4A69E50725B0BF77_MetadataUsageId;
extern const uint32_t SqliteFactory_System_IServiceProvider_GetService_m28A88FAC3C28EAB28480E4AC7B1510578C080143_MetadataUsageId;
extern const uint32_t SqliteFactory__cctor_m52241130E4EAA219059982F548B4923ED536CA97_MetadataUsageId;
extern const uint32_t SqliteFunction_BindFunctions_m8CF5514376BCBB914639517136181467868E3238_MetadataUsageId;
extern const uint32_t SqliteFunction_CompareCallback_mBE735C82605FEF47F8B6E78E3CF04130049CA95D_MetadataUsageId;
extern const uint32_t SqliteFunction_ConvertParams_m3B967FF80BD969603C902F1DF9EB2704FBD0357D_MetadataUsageId;
extern const uint32_t SqliteFunction_Dispose_mAB16F5749E6C97AC3EED16355894CC849529D4F5_MetadataUsageId;
extern const uint32_t SqliteFunction_FinalCallback_m68052B0AE75F0054D840A7E7E42B3019A61F0322_MetadataUsageId;
extern const uint32_t SqliteFunction_SetReturnValue_mD2B822ACF24A89AE1902E00A3AED96982254D5C5_MetadataUsageId;
extern const uint32_t SqliteFunction_StepCallback_m4CCDD48061DE3BF6A14CEDCF099829179E4F1878_MetadataUsageId;
extern const uint32_t SqliteFunction__cctor_mE760607CEA3BAE76B31DBD6C66192AF98DC6FDDE_MetadataUsageId;
extern const uint32_t SqliteKeyReader_AppendSchemaTable_m0245FED7609ADB0AE58ADF42A24846C32EE49950_MetadataUsageId;
extern const uint32_t SqliteKeyReader_GetBoolean_mF164552CBD10F49417C97F7FFF3454143AFE536C_MetadataUsageId;
extern const uint32_t SqliteKeyReader_GetDataTypeName_m8B7888A532923B94DB2A26A2B2C8D10B1FC24288_MetadataUsageId;
extern const uint32_t SqliteKeyReader_GetFieldType_mA8359394C7BE6432E1544530EA6DDD3E90BABB09_MetadataUsageId;
extern const uint32_t SqliteKeyReader_GetInt32_m57C62C425E04BA112B42914E60A88E0BA147710F_MetadataUsageId;
extern const uint32_t SqliteKeyReader_GetInt64_m88F6AC8A38D351C10514E8BE8A6EC30F819C833A_MetadataUsageId;
extern const uint32_t SqliteKeyReader_GetString_m14BF706D0E90330C84A3F322D435728903F5EF46_MetadataUsageId;
extern const uint32_t SqliteKeyReader_GetValue_mF018DD89A0AC47D114E3174A9D7477237046E8A8_MetadataUsageId;
extern const uint32_t SqliteKeyReader_Sync_mF6A76D7FF2131664DCAFC47426C77959060A7560_MetadataUsageId;
extern const uint32_t SqliteKeyReader__ctor_m3264CB39D870C5E959D0D0C103B31EF2FDAA4AC2_MetadataUsageId;
extern const uint32_t SqliteParameterCollection_AddWithValue_mF4F505D0FCEB4D850A40BEA47A730246088E871E_MetadataUsageId;
extern const uint32_t SqliteParameterCollection_Add_mAFFCEFBEC7E1F1E9AB23DC340654A0DACA0B786F_MetadataUsageId;
extern const uint32_t SqliteParameterCollection_Add_mBF596B1E9C33A5BEFE50A6F49A608B5D4D464FF9_MetadataUsageId;
extern const uint32_t SqliteParameterCollection_Clear_m44945F7C1DF0F720B9C6C746EB557D5CA37AE0F6_MetadataUsageId;
extern const uint32_t SqliteParameterCollection_Contains_mEB901C67AB25CF497B7857AA0DD615DCB931C9D7_MetadataUsageId;
extern const uint32_t SqliteParameterCollection_CopyTo_m40835944C1939CF6CB6CB431742B56226376A643_MetadataUsageId;
extern const uint32_t SqliteParameterCollection_GetEnumerator_mE813133D39F61EAE4358CB136F5ECEC815EE8DCA_MetadataUsageId;
extern const uint32_t SqliteParameterCollection_GetParameter_mFB68E8A80CCD474525471D67CFBA3117C3D54096_MetadataUsageId;
extern const uint32_t SqliteParameterCollection_IndexOf_m3EBE7087E87273E22E1F60F48441484F94607421_MetadataUsageId;
extern const uint32_t SqliteParameterCollection_IndexOf_mBD3C478CCDC30F206087A1CCBD995FAD93556C1C_MetadataUsageId;
extern const uint32_t SqliteParameterCollection_Insert_m69D0F90223F0BD7B3F94EF0873733239CD9696F0_MetadataUsageId;
extern const uint32_t SqliteParameterCollection_MapParameters_m76D14599AF9FF70EC7586705A28C2E6AD6E74121_MetadataUsageId;
extern const uint32_t SqliteParameterCollection_RemoveAt_m6A53370209BCD6A94AA591F236F8D459C984BF49_MetadataUsageId;
extern const uint32_t SqliteParameterCollection_Remove_mDD2FD25D1A426D635287917709D1B55592061B94_MetadataUsageId;
extern const uint32_t SqliteParameterCollection_SetParameter_m8A77372FD9D393D3493E145532C580D3FAB3CEC6_MetadataUsageId;
extern const uint32_t SqliteParameterCollection__ctor_mBCC625E0A40AE96F7BB16AD2CEF18A22A03A9BF6_MetadataUsageId;
extern const uint32_t SqliteParameterCollection_get_Count_m6B327DADE924BD93FFADF92E4AD56E194F6F1D93_MetadataUsageId;
extern const uint32_t SqliteParameterCollection_get_Item_m6807F61A4D898F719FF3EDAE8097A6FADC9E92F8_MetadataUsageId;
extern const uint32_t SqliteParameter_Clone_mBA5E17A105E1534F29C9F273109F123530CC9C9B_MetadataUsageId;
extern const uint32_t SqliteParameter_get_DbType_m8622A28055C14CA1BC4A004A909780FB9A13E691_MetadataUsageId;
extern const uint32_t SqliteParameter_set_Direction_m80D8677C3C1484EF27734AAB1FDC814CF24A1814_MetadataUsageId;
extern const uint32_t SqliteParameter_set_Value_mA4215B49D68583CF87D786F3A54D2202ACFAD3C9_MetadataUsageId;
extern const uint32_t SqliteStatementHandle_ReleaseHandle_m262CB72DCE79FFCF324BF8DD459EB17C6B1C1FD6_MetadataUsageId;
extern const uint32_t SqliteStatementHandle__ctor_m6F5DE40FE027CE6BE127C05AFA4D20161B8D9FA6_MetadataUsageId;
extern const uint32_t SqliteStatementHandle_get_IsInvalid_mEFD73F5A7BD13FAA13C92CF31E97D7D0B5CFD883_MetadataUsageId;
extern const uint32_t SqliteStatementHandle_op_Implicit_mD49D21BFB9C321E8F0ECC04E0469EBC6DF58AD05_MetadataUsageId;
extern const uint32_t SqliteStatement_BindParameter_m5CB198F61BDB753FDF1067AB5B624BBB5E44E513_MetadataUsageId;
extern const uint32_t SqliteStatement_MapParameter_mF2B1590F36C785FA5CDC5D79CA0F998584E5021C_MetadataUsageId;
extern const uint32_t SqliteStatement_SetTypes_m21B385B07A712E6813527EF3590E0CA231F77F15_MetadataUsageId;
extern const uint32_t SqliteStatement__ctor_m8917E2A4F6C6F85D238593B8A14E454FC11E12C4_MetadataUsageId;
extern const uint32_t SqliteTransaction_Commit_mBA94CBAD9278B782DF84E22E2764D0612F551B68_MetadataUsageId;
extern const uint32_t SqliteTransaction_IsValid_mFFDD476AD513E92FB025CB46A52D5734FAE54897_MetadataUsageId;
extern const uint32_t SqliteTransaction_IssueRollback_m8BCB6D8EC3F0770626222A8929B6D61C4EF9C17A_MetadataUsageId;
extern const uint32_t SqliteTransaction__ctor_m59995FF6874597512ED2217BBC41266B2A0F7CAF_MetadataUsageId;
struct CultureData_tF43B080FFA6EB278F4F289BCDA3FB74B6C208ECD_marshaled_com;
struct CultureData_tF43B080FFA6EB278F4F289BCDA3FB74B6C208ECD_marshaled_pinvoke;
struct CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_marshaled_com;
struct CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_marshaled_pinvoke;
struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;

struct SqliteFunctionU5BU5D_t8AFADE2E07F0DC165BCF00EA921B1DB88D1A160F;
struct KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4;
struct SqliteParameterU5BU5D_t76F2417476AE80EE92606466B015185F4EEF2C27;
struct ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821;
struct CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2;
struct IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD;
struct ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A;
struct AssemblyNameU5BU5D_tE1C9584468498B9897F558EE8EF4872260CEB34B;
struct AssemblyU5BU5D_t90BF014AA048450526A42C74F9583341A138DE58;
struct StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E;
struct TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F;


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
#ifndef AGGREGATEDATA_TFFE2516CCD63C95431946BC11AA3907DF2F16755_H
#define AGGREGATEDATA_TFFE2516CCD63C95431946BC11AA3907DF2F16755_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.SqliteFunction_AggregateData
struct  AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755  : public RuntimeObject
{
public:
	// System.Int32 Mono.Data.Sqlite.SqliteFunction_AggregateData::_count
	int32_t ____count_0;
	// System.Object Mono.Data.Sqlite.SqliteFunction_AggregateData::_data
	RuntimeObject * ____data_1;

public:
	inline static int32_t get_offset_of__count_0() { return static_cast<int32_t>(offsetof(AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755, ____count_0)); }
	inline int32_t get__count_0() const { return ____count_0; }
	inline int32_t* get_address_of__count_0() { return &____count_0; }
	inline void set__count_0(int32_t value)
	{
		____count_0 = value;
	}

	inline static int32_t get_offset_of__data_1() { return static_cast<int32_t>(offsetof(AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755, ____data_1)); }
	inline RuntimeObject * get__data_1() const { return ____data_1; }
	inline RuntimeObject ** get_address_of__data_1() { return &____data_1; }
	inline void set__data_1(RuntimeObject * value)
	{
		____data_1 = value;
		Il2CppCodeGenWriteBarrier((&____data_1), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // AGGREGATEDATA_TFFE2516CCD63C95431946BC11AA3907DF2F16755_H
#ifndef SQLITEKEYREADER_TC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793_H
#define SQLITEKEYREADER_TC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.SqliteKeyReader
struct  SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793  : public RuntimeObject
{
public:
	// Mono.Data.Sqlite.SqliteKeyReader_KeyInfo[] Mono.Data.Sqlite.SqliteKeyReader::_keyInfo
	KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* ____keyInfo_0;
	// Mono.Data.Sqlite.SqliteStatement Mono.Data.Sqlite.SqliteKeyReader::_stmt
	SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * ____stmt_1;
	// System.Boolean Mono.Data.Sqlite.SqliteKeyReader::_isValid
	bool ____isValid_2;

public:
	inline static int32_t get_offset_of__keyInfo_0() { return static_cast<int32_t>(offsetof(SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793, ____keyInfo_0)); }
	inline KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* get__keyInfo_0() const { return ____keyInfo_0; }
	inline KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4** get_address_of__keyInfo_0() { return &____keyInfo_0; }
	inline void set__keyInfo_0(KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* value)
	{
		____keyInfo_0 = value;
		Il2CppCodeGenWriteBarrier((&____keyInfo_0), value);
	}

	inline static int32_t get_offset_of__stmt_1() { return static_cast<int32_t>(offsetof(SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793, ____stmt_1)); }
	inline SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * get__stmt_1() const { return ____stmt_1; }
	inline SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A ** get_address_of__stmt_1() { return &____stmt_1; }
	inline void set__stmt_1(SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * value)
	{
		____stmt_1 = value;
		Il2CppCodeGenWriteBarrier((&____stmt_1), value);
	}

	inline static int32_t get_offset_of__isValid_2() { return static_cast<int32_t>(offsetof(SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793, ____isValid_2)); }
	inline bool get__isValid_2() const { return ____isValid_2; }
	inline bool* get_address_of__isValid_2() { return &____isValid_2; }
	inline void set__isValid_2(bool value)
	{
		____isValid_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SQLITEKEYREADER_TC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793_H
#ifndef KEYQUERY_TA3A1B612E12E7B391B1CD1936451DB37B70EF4B4_H
#define KEYQUERY_TA3A1B612E12E7B391B1CD1936451DB37B70EF4B4_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.SqliteKeyReader_KeyQuery
struct  KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4  : public RuntimeObject
{
public:
	// Mono.Data.Sqlite.SqliteCommand Mono.Data.Sqlite.SqliteKeyReader_KeyQuery::_command
	SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * ____command_0;
	// Mono.Data.Sqlite.SqliteDataReader Mono.Data.Sqlite.SqliteKeyReader_KeyQuery::_reader
	SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * ____reader_1;

public:
	inline static int32_t get_offset_of__command_0() { return static_cast<int32_t>(offsetof(KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4, ____command_0)); }
	inline SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * get__command_0() const { return ____command_0; }
	inline SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 ** get_address_of__command_0() { return &____command_0; }
	inline void set__command_0(SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * value)
	{
		____command_0 = value;
		Il2CppCodeGenWriteBarrier((&____command_0), value);
	}

	inline static int32_t get_offset_of__reader_1() { return static_cast<int32_t>(offsetof(KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4, ____reader_1)); }
	inline SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * get__reader_1() const { return ____reader_1; }
	inline SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 ** get_address_of__reader_1() { return &____reader_1; }
	inline void set__reader_1(SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * value)
	{
		____reader_1 = value;
		Il2CppCodeGenWriteBarrier((&____reader_1), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // KEYQUERY_TA3A1B612E12E7B391B1CD1936451DB37B70EF4B4_H
#ifndef SQLITESTATEMENT_TA0BDCDA8DC5F25726EEF779D832B662E889BCA1A_H
#define SQLITESTATEMENT_TA0BDCDA8DC5F25726EEF779D832B662E889BCA1A_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.SqliteStatement
struct  SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A  : public RuntimeObject
{
public:
	// Mono.Data.Sqlite.SQLiteBase Mono.Data.Sqlite.SqliteStatement::_sql
	SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * ____sql_0;
	// System.String Mono.Data.Sqlite.SqliteStatement::_sqlStatement
	String_t* ____sqlStatement_1;
	// Mono.Data.Sqlite.SqliteStatementHandle Mono.Data.Sqlite.SqliteStatement::_sqlite_stmt
	SqliteStatementHandle_t6121E676E0AB6EA25E9168EB18C7A064E83DBBBE * ____sqlite_stmt_2;
	// System.Int32 Mono.Data.Sqlite.SqliteStatement::_unnamedParameters
	int32_t ____unnamedParameters_3;
	// System.String[] Mono.Data.Sqlite.SqliteStatement::_paramNames
	StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* ____paramNames_4;
	// Mono.Data.Sqlite.SqliteParameter[] Mono.Data.Sqlite.SqliteStatement::_paramValues
	SqliteParameterU5BU5D_t76F2417476AE80EE92606466B015185F4EEF2C27* ____paramValues_5;
	// Mono.Data.Sqlite.SqliteCommand Mono.Data.Sqlite.SqliteStatement::_command
	SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * ____command_6;
	// System.String[] Mono.Data.Sqlite.SqliteStatement::_types
	StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* ____types_7;

public:
	inline static int32_t get_offset_of__sql_0() { return static_cast<int32_t>(offsetof(SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A, ____sql_0)); }
	inline SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * get__sql_0() const { return ____sql_0; }
	inline SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 ** get_address_of__sql_0() { return &____sql_0; }
	inline void set__sql_0(SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * value)
	{
		____sql_0 = value;
		Il2CppCodeGenWriteBarrier((&____sql_0), value);
	}

	inline static int32_t get_offset_of__sqlStatement_1() { return static_cast<int32_t>(offsetof(SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A, ____sqlStatement_1)); }
	inline String_t* get__sqlStatement_1() const { return ____sqlStatement_1; }
	inline String_t** get_address_of__sqlStatement_1() { return &____sqlStatement_1; }
	inline void set__sqlStatement_1(String_t* value)
	{
		____sqlStatement_1 = value;
		Il2CppCodeGenWriteBarrier((&____sqlStatement_1), value);
	}

	inline static int32_t get_offset_of__sqlite_stmt_2() { return static_cast<int32_t>(offsetof(SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A, ____sqlite_stmt_2)); }
	inline SqliteStatementHandle_t6121E676E0AB6EA25E9168EB18C7A064E83DBBBE * get__sqlite_stmt_2() const { return ____sqlite_stmt_2; }
	inline SqliteStatementHandle_t6121E676E0AB6EA25E9168EB18C7A064E83DBBBE ** get_address_of__sqlite_stmt_2() { return &____sqlite_stmt_2; }
	inline void set__sqlite_stmt_2(SqliteStatementHandle_t6121E676E0AB6EA25E9168EB18C7A064E83DBBBE * value)
	{
		____sqlite_stmt_2 = value;
		Il2CppCodeGenWriteBarrier((&____sqlite_stmt_2), value);
	}

	inline static int32_t get_offset_of__unnamedParameters_3() { return static_cast<int32_t>(offsetof(SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A, ____unnamedParameters_3)); }
	inline int32_t get__unnamedParameters_3() const { return ____unnamedParameters_3; }
	inline int32_t* get_address_of__unnamedParameters_3() { return &____unnamedParameters_3; }
	inline void set__unnamedParameters_3(int32_t value)
	{
		____unnamedParameters_3 = value;
	}

	inline static int32_t get_offset_of__paramNames_4() { return static_cast<int32_t>(offsetof(SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A, ____paramNames_4)); }
	inline StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* get__paramNames_4() const { return ____paramNames_4; }
	inline StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E** get_address_of__paramNames_4() { return &____paramNames_4; }
	inline void set__paramNames_4(StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* value)
	{
		____paramNames_4 = value;
		Il2CppCodeGenWriteBarrier((&____paramNames_4), value);
	}

	inline static int32_t get_offset_of__paramValues_5() { return static_cast<int32_t>(offsetof(SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A, ____paramValues_5)); }
	inline SqliteParameterU5BU5D_t76F2417476AE80EE92606466B015185F4EEF2C27* get__paramValues_5() const { return ____paramValues_5; }
	inline SqliteParameterU5BU5D_t76F2417476AE80EE92606466B015185F4EEF2C27** get_address_of__paramValues_5() { return &____paramValues_5; }
	inline void set__paramValues_5(SqliteParameterU5BU5D_t76F2417476AE80EE92606466B015185F4EEF2C27* value)
	{
		____paramValues_5 = value;
		Il2CppCodeGenWriteBarrier((&____paramValues_5), value);
	}

	inline static int32_t get_offset_of__command_6() { return static_cast<int32_t>(offsetof(SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A, ____command_6)); }
	inline SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * get__command_6() const { return ____command_6; }
	inline SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 ** get_address_of__command_6() { return &____command_6; }
	inline void set__command_6(SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * value)
	{
		____command_6 = value;
		Il2CppCodeGenWriteBarrier((&____command_6), value);
	}

	inline static int32_t get_offset_of__types_7() { return static_cast<int32_t>(offsetof(SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A, ____types_7)); }
	inline StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* get__types_7() const { return ____types_7; }
	inline StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E** get_address_of__types_7() { return &____types_7; }
	inline void set__types_7(StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* value)
	{
		____types_7 = value;
		Il2CppCodeGenWriteBarrier((&____types_7), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SQLITESTATEMENT_TA0BDCDA8DC5F25726EEF779D832B662E889BCA1A_H
#ifndef UNSAFENATIVEMETHODS_TE4CEB008147D2CB5494390895D977A974D2B585E_H
#define UNSAFENATIVEMETHODS_TE4CEB008147D2CB5494390895D977A974D2B585E_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.UnsafeNativeMethods
struct  UnsafeNativeMethods_tE4CEB008147D2CB5494390895D977A974D2B585E  : public RuntimeObject
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UNSAFENATIVEMETHODS_TE4CEB008147D2CB5494390895D977A974D2B585E_H
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
#ifndef DICTIONARY_2_T25A4BDB3DBE4AC5313851F9DA72493859AE10BA3_H
#define DICTIONARY_2_T25A4BDB3DBE4AC5313851F9DA72493859AE10BA3_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.Dictionary`2<System.Int64,Mono.Data.Sqlite.SqliteFunction_AggregateData>
struct  Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3  : public RuntimeObject
{
public:
	// System.Int32[] System.Collections.Generic.Dictionary`2::buckets
	Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* ___buckets_0;
	// System.Collections.Generic.Dictionary`2_Entry<TKey,TValue>[] System.Collections.Generic.Dictionary`2::entries
	EntryU5BU5D_tEC0B53694229BD41D0F484C7CFE5964202A03AE6* ___entries_1;
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
	KeyCollection_t8A750217C1CC343BE0B88C820DCEE5525A1D67A8 * ___keys_7;
	// System.Collections.Generic.Dictionary`2_ValueCollection<TKey,TValue> System.Collections.Generic.Dictionary`2::values
	ValueCollection_tB817FAD5802BC4B63621952300D59847EE6B3490 * ___values_8;
	// System.Object System.Collections.Generic.Dictionary`2::_syncRoot
	RuntimeObject * ____syncRoot_9;

public:
	inline static int32_t get_offset_of_buckets_0() { return static_cast<int32_t>(offsetof(Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3, ___buckets_0)); }
	inline Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* get_buckets_0() const { return ___buckets_0; }
	inline Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83** get_address_of_buckets_0() { return &___buckets_0; }
	inline void set_buckets_0(Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* value)
	{
		___buckets_0 = value;
		Il2CppCodeGenWriteBarrier((&___buckets_0), value);
	}

	inline static int32_t get_offset_of_entries_1() { return static_cast<int32_t>(offsetof(Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3, ___entries_1)); }
	inline EntryU5BU5D_tEC0B53694229BD41D0F484C7CFE5964202A03AE6* get_entries_1() const { return ___entries_1; }
	inline EntryU5BU5D_tEC0B53694229BD41D0F484C7CFE5964202A03AE6** get_address_of_entries_1() { return &___entries_1; }
	inline void set_entries_1(EntryU5BU5D_tEC0B53694229BD41D0F484C7CFE5964202A03AE6* value)
	{
		___entries_1 = value;
		Il2CppCodeGenWriteBarrier((&___entries_1), value);
	}

	inline static int32_t get_offset_of_count_2() { return static_cast<int32_t>(offsetof(Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3, ___count_2)); }
	inline int32_t get_count_2() const { return ___count_2; }
	inline int32_t* get_address_of_count_2() { return &___count_2; }
	inline void set_count_2(int32_t value)
	{
		___count_2 = value;
	}

	inline static int32_t get_offset_of_version_3() { return static_cast<int32_t>(offsetof(Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3, ___version_3)); }
	inline int32_t get_version_3() const { return ___version_3; }
	inline int32_t* get_address_of_version_3() { return &___version_3; }
	inline void set_version_3(int32_t value)
	{
		___version_3 = value;
	}

	inline static int32_t get_offset_of_freeList_4() { return static_cast<int32_t>(offsetof(Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3, ___freeList_4)); }
	inline int32_t get_freeList_4() const { return ___freeList_4; }
	inline int32_t* get_address_of_freeList_4() { return &___freeList_4; }
	inline void set_freeList_4(int32_t value)
	{
		___freeList_4 = value;
	}

	inline static int32_t get_offset_of_freeCount_5() { return static_cast<int32_t>(offsetof(Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3, ___freeCount_5)); }
	inline int32_t get_freeCount_5() const { return ___freeCount_5; }
	inline int32_t* get_address_of_freeCount_5() { return &___freeCount_5; }
	inline void set_freeCount_5(int32_t value)
	{
		___freeCount_5 = value;
	}

	inline static int32_t get_offset_of_comparer_6() { return static_cast<int32_t>(offsetof(Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3, ___comparer_6)); }
	inline RuntimeObject* get_comparer_6() const { return ___comparer_6; }
	inline RuntimeObject** get_address_of_comparer_6() { return &___comparer_6; }
	inline void set_comparer_6(RuntimeObject* value)
	{
		___comparer_6 = value;
		Il2CppCodeGenWriteBarrier((&___comparer_6), value);
	}

	inline static int32_t get_offset_of_keys_7() { return static_cast<int32_t>(offsetof(Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3, ___keys_7)); }
	inline KeyCollection_t8A750217C1CC343BE0B88C820DCEE5525A1D67A8 * get_keys_7() const { return ___keys_7; }
	inline KeyCollection_t8A750217C1CC343BE0B88C820DCEE5525A1D67A8 ** get_address_of_keys_7() { return &___keys_7; }
	inline void set_keys_7(KeyCollection_t8A750217C1CC343BE0B88C820DCEE5525A1D67A8 * value)
	{
		___keys_7 = value;
		Il2CppCodeGenWriteBarrier((&___keys_7), value);
	}

	inline static int32_t get_offset_of_values_8() { return static_cast<int32_t>(offsetof(Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3, ___values_8)); }
	inline ValueCollection_tB817FAD5802BC4B63621952300D59847EE6B3490 * get_values_8() const { return ___values_8; }
	inline ValueCollection_tB817FAD5802BC4B63621952300D59847EE6B3490 ** get_address_of_values_8() { return &___values_8; }
	inline void set_values_8(ValueCollection_tB817FAD5802BC4B63621952300D59847EE6B3490 * value)
	{
		___values_8 = value;
		Il2CppCodeGenWriteBarrier((&___values_8), value);
	}

	inline static int32_t get_offset_of__syncRoot_9() { return static_cast<int32_t>(offsetof(Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3, ____syncRoot_9)); }
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
#endif // DICTIONARY_2_T25A4BDB3DBE4AC5313851F9DA72493859AE10BA3_H
#ifndef DICTIONARY_2_TDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF_H
#define DICTIONARY_2_TDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.Dictionary`2<System.String,System.Collections.Generic.List`1<System.String>>
struct  Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF  : public RuntimeObject
{
public:
	// System.Int32[] System.Collections.Generic.Dictionary`2::buckets
	Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* ___buckets_0;
	// System.Collections.Generic.Dictionary`2_Entry<TKey,TValue>[] System.Collections.Generic.Dictionary`2::entries
	EntryU5BU5D_tA5B97EA90D4BE7F710BABB9A39F974A38394D3C0* ___entries_1;
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
	KeyCollection_t1BABBEA8121C5B4211355214E8C46B26B8DFC956 * ___keys_7;
	// System.Collections.Generic.Dictionary`2_ValueCollection<TKey,TValue> System.Collections.Generic.Dictionary`2::values
	ValueCollection_t745348FB9874C30D8D3EA37349A25BACE57545DD * ___values_8;
	// System.Object System.Collections.Generic.Dictionary`2::_syncRoot
	RuntimeObject * ____syncRoot_9;

public:
	inline static int32_t get_offset_of_buckets_0() { return static_cast<int32_t>(offsetof(Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF, ___buckets_0)); }
	inline Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* get_buckets_0() const { return ___buckets_0; }
	inline Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83** get_address_of_buckets_0() { return &___buckets_0; }
	inline void set_buckets_0(Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* value)
	{
		___buckets_0 = value;
		Il2CppCodeGenWriteBarrier((&___buckets_0), value);
	}

	inline static int32_t get_offset_of_entries_1() { return static_cast<int32_t>(offsetof(Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF, ___entries_1)); }
	inline EntryU5BU5D_tA5B97EA90D4BE7F710BABB9A39F974A38394D3C0* get_entries_1() const { return ___entries_1; }
	inline EntryU5BU5D_tA5B97EA90D4BE7F710BABB9A39F974A38394D3C0** get_address_of_entries_1() { return &___entries_1; }
	inline void set_entries_1(EntryU5BU5D_tA5B97EA90D4BE7F710BABB9A39F974A38394D3C0* value)
	{
		___entries_1 = value;
		Il2CppCodeGenWriteBarrier((&___entries_1), value);
	}

	inline static int32_t get_offset_of_count_2() { return static_cast<int32_t>(offsetof(Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF, ___count_2)); }
	inline int32_t get_count_2() const { return ___count_2; }
	inline int32_t* get_address_of_count_2() { return &___count_2; }
	inline void set_count_2(int32_t value)
	{
		___count_2 = value;
	}

	inline static int32_t get_offset_of_version_3() { return static_cast<int32_t>(offsetof(Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF, ___version_3)); }
	inline int32_t get_version_3() const { return ___version_3; }
	inline int32_t* get_address_of_version_3() { return &___version_3; }
	inline void set_version_3(int32_t value)
	{
		___version_3 = value;
	}

	inline static int32_t get_offset_of_freeList_4() { return static_cast<int32_t>(offsetof(Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF, ___freeList_4)); }
	inline int32_t get_freeList_4() const { return ___freeList_4; }
	inline int32_t* get_address_of_freeList_4() { return &___freeList_4; }
	inline void set_freeList_4(int32_t value)
	{
		___freeList_4 = value;
	}

	inline static int32_t get_offset_of_freeCount_5() { return static_cast<int32_t>(offsetof(Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF, ___freeCount_5)); }
	inline int32_t get_freeCount_5() const { return ___freeCount_5; }
	inline int32_t* get_address_of_freeCount_5() { return &___freeCount_5; }
	inline void set_freeCount_5(int32_t value)
	{
		___freeCount_5 = value;
	}

	inline static int32_t get_offset_of_comparer_6() { return static_cast<int32_t>(offsetof(Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF, ___comparer_6)); }
	inline RuntimeObject* get_comparer_6() const { return ___comparer_6; }
	inline RuntimeObject** get_address_of_comparer_6() { return &___comparer_6; }
	inline void set_comparer_6(RuntimeObject* value)
	{
		___comparer_6 = value;
		Il2CppCodeGenWriteBarrier((&___comparer_6), value);
	}

	inline static int32_t get_offset_of_keys_7() { return static_cast<int32_t>(offsetof(Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF, ___keys_7)); }
	inline KeyCollection_t1BABBEA8121C5B4211355214E8C46B26B8DFC956 * get_keys_7() const { return ___keys_7; }
	inline KeyCollection_t1BABBEA8121C5B4211355214E8C46B26B8DFC956 ** get_address_of_keys_7() { return &___keys_7; }
	inline void set_keys_7(KeyCollection_t1BABBEA8121C5B4211355214E8C46B26B8DFC956 * value)
	{
		___keys_7 = value;
		Il2CppCodeGenWriteBarrier((&___keys_7), value);
	}

	inline static int32_t get_offset_of_values_8() { return static_cast<int32_t>(offsetof(Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF, ___values_8)); }
	inline ValueCollection_t745348FB9874C30D8D3EA37349A25BACE57545DD * get_values_8() const { return ___values_8; }
	inline ValueCollection_t745348FB9874C30D8D3EA37349A25BACE57545DD ** get_address_of_values_8() { return &___values_8; }
	inline void set_values_8(ValueCollection_t745348FB9874C30D8D3EA37349A25BACE57545DD * value)
	{
		___values_8 = value;
		Il2CppCodeGenWriteBarrier((&___values_8), value);
	}

	inline static int32_t get_offset_of__syncRoot_9() { return static_cast<int32_t>(offsetof(Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF, ____syncRoot_9)); }
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
#endif // DICTIONARY_2_TDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF_H
#ifndef DICTIONARY_2_TD6E204872BA9FD506A0287EF68E285BEB9EC0DFB_H
#define DICTIONARY_2_TD6E204872BA9FD506A0287EF68E285BEB9EC0DFB_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.Dictionary`2<System.String,System.Int32>
struct  Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB  : public RuntimeObject
{
public:
	// System.Int32[] System.Collections.Generic.Dictionary`2::buckets
	Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* ___buckets_0;
	// System.Collections.Generic.Dictionary`2_Entry<TKey,TValue>[] System.Collections.Generic.Dictionary`2::entries
	EntryU5BU5D_tAD4FDE2B2578C6625A7296B1C46DCB06DCB45186* ___entries_1;
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
	KeyCollection_t666396E67E50284D48938851873CE562083D67F2 * ___keys_7;
	// System.Collections.Generic.Dictionary`2_ValueCollection<TKey,TValue> System.Collections.Generic.Dictionary`2::values
	ValueCollection_t532E2FD863D0D47B87202BE6B4F7C7EDB5DD7CBF * ___values_8;
	// System.Object System.Collections.Generic.Dictionary`2::_syncRoot
	RuntimeObject * ____syncRoot_9;

public:
	inline static int32_t get_offset_of_buckets_0() { return static_cast<int32_t>(offsetof(Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB, ___buckets_0)); }
	inline Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* get_buckets_0() const { return ___buckets_0; }
	inline Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83** get_address_of_buckets_0() { return &___buckets_0; }
	inline void set_buckets_0(Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* value)
	{
		___buckets_0 = value;
		Il2CppCodeGenWriteBarrier((&___buckets_0), value);
	}

	inline static int32_t get_offset_of_entries_1() { return static_cast<int32_t>(offsetof(Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB, ___entries_1)); }
	inline EntryU5BU5D_tAD4FDE2B2578C6625A7296B1C46DCB06DCB45186* get_entries_1() const { return ___entries_1; }
	inline EntryU5BU5D_tAD4FDE2B2578C6625A7296B1C46DCB06DCB45186** get_address_of_entries_1() { return &___entries_1; }
	inline void set_entries_1(EntryU5BU5D_tAD4FDE2B2578C6625A7296B1C46DCB06DCB45186* value)
	{
		___entries_1 = value;
		Il2CppCodeGenWriteBarrier((&___entries_1), value);
	}

	inline static int32_t get_offset_of_count_2() { return static_cast<int32_t>(offsetof(Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB, ___count_2)); }
	inline int32_t get_count_2() const { return ___count_2; }
	inline int32_t* get_address_of_count_2() { return &___count_2; }
	inline void set_count_2(int32_t value)
	{
		___count_2 = value;
	}

	inline static int32_t get_offset_of_version_3() { return static_cast<int32_t>(offsetof(Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB, ___version_3)); }
	inline int32_t get_version_3() const { return ___version_3; }
	inline int32_t* get_address_of_version_3() { return &___version_3; }
	inline void set_version_3(int32_t value)
	{
		___version_3 = value;
	}

	inline static int32_t get_offset_of_freeList_4() { return static_cast<int32_t>(offsetof(Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB, ___freeList_4)); }
	inline int32_t get_freeList_4() const { return ___freeList_4; }
	inline int32_t* get_address_of_freeList_4() { return &___freeList_4; }
	inline void set_freeList_4(int32_t value)
	{
		___freeList_4 = value;
	}

	inline static int32_t get_offset_of_freeCount_5() { return static_cast<int32_t>(offsetof(Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB, ___freeCount_5)); }
	inline int32_t get_freeCount_5() const { return ___freeCount_5; }
	inline int32_t* get_address_of_freeCount_5() { return &___freeCount_5; }
	inline void set_freeCount_5(int32_t value)
	{
		___freeCount_5 = value;
	}

	inline static int32_t get_offset_of_comparer_6() { return static_cast<int32_t>(offsetof(Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB, ___comparer_6)); }
	inline RuntimeObject* get_comparer_6() const { return ___comparer_6; }
	inline RuntimeObject** get_address_of_comparer_6() { return &___comparer_6; }
	inline void set_comparer_6(RuntimeObject* value)
	{
		___comparer_6 = value;
		Il2CppCodeGenWriteBarrier((&___comparer_6), value);
	}

	inline static int32_t get_offset_of_keys_7() { return static_cast<int32_t>(offsetof(Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB, ___keys_7)); }
	inline KeyCollection_t666396E67E50284D48938851873CE562083D67F2 * get_keys_7() const { return ___keys_7; }
	inline KeyCollection_t666396E67E50284D48938851873CE562083D67F2 ** get_address_of_keys_7() { return &___keys_7; }
	inline void set_keys_7(KeyCollection_t666396E67E50284D48938851873CE562083D67F2 * value)
	{
		___keys_7 = value;
		Il2CppCodeGenWriteBarrier((&___keys_7), value);
	}

	inline static int32_t get_offset_of_values_8() { return static_cast<int32_t>(offsetof(Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB, ___values_8)); }
	inline ValueCollection_t532E2FD863D0D47B87202BE6B4F7C7EDB5DD7CBF * get_values_8() const { return ___values_8; }
	inline ValueCollection_t532E2FD863D0D47B87202BE6B4F7C7EDB5DD7CBF ** get_address_of_values_8() { return &___values_8; }
	inline void set_values_8(ValueCollection_t532E2FD863D0D47B87202BE6B4F7C7EDB5DD7CBF * value)
	{
		___values_8 = value;
		Il2CppCodeGenWriteBarrier((&___values_8), value);
	}

	inline static int32_t get_offset_of__syncRoot_9() { return static_cast<int32_t>(offsetof(Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB, ____syncRoot_9)); }
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
#endif // DICTIONARY_2_TD6E204872BA9FD506A0287EF68E285BEB9EC0DFB_H
#ifndef LIST_1_TC332B4E87767ADFB1672A499D53D94AE897CD4A3_H
#define LIST_1_TC332B4E87767ADFB1672A499D53D94AE897CD4A3_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteFunction>
struct  List_1_tC332B4E87767ADFB1672A499D53D94AE897CD4A3  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	SqliteFunctionU5BU5D_t8AFADE2E07F0DC165BCF00EA921B1DB88D1A160F* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject * ____syncRoot_4;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_tC332B4E87767ADFB1672A499D53D94AE897CD4A3, ____items_1)); }
	inline SqliteFunctionU5BU5D_t8AFADE2E07F0DC165BCF00EA921B1DB88D1A160F* get__items_1() const { return ____items_1; }
	inline SqliteFunctionU5BU5D_t8AFADE2E07F0DC165BCF00EA921B1DB88D1A160F** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(SqliteFunctionU5BU5D_t8AFADE2E07F0DC165BCF00EA921B1DB88D1A160F* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((&____items_1), value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_tC332B4E87767ADFB1672A499D53D94AE897CD4A3, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_tC332B4E87767ADFB1672A499D53D94AE897CD4A3, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}

	inline static int32_t get_offset_of__syncRoot_4() { return static_cast<int32_t>(offsetof(List_1_tC332B4E87767ADFB1672A499D53D94AE897CD4A3, ____syncRoot_4)); }
	inline RuntimeObject * get__syncRoot_4() const { return ____syncRoot_4; }
	inline RuntimeObject ** get_address_of__syncRoot_4() { return &____syncRoot_4; }
	inline void set__syncRoot_4(RuntimeObject * value)
	{
		____syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier((&____syncRoot_4), value);
	}
};

struct List_1_tC332B4E87767ADFB1672A499D53D94AE897CD4A3_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::_emptyArray
	SqliteFunctionU5BU5D_t8AFADE2E07F0DC165BCF00EA921B1DB88D1A160F* ____emptyArray_5;

public:
	inline static int32_t get_offset_of__emptyArray_5() { return static_cast<int32_t>(offsetof(List_1_tC332B4E87767ADFB1672A499D53D94AE897CD4A3_StaticFields, ____emptyArray_5)); }
	inline SqliteFunctionU5BU5D_t8AFADE2E07F0DC165BCF00EA921B1DB88D1A160F* get__emptyArray_5() const { return ____emptyArray_5; }
	inline SqliteFunctionU5BU5D_t8AFADE2E07F0DC165BCF00EA921B1DB88D1A160F** get_address_of__emptyArray_5() { return &____emptyArray_5; }
	inline void set__emptyArray_5(SqliteFunctionU5BU5D_t8AFADE2E07F0DC165BCF00EA921B1DB88D1A160F* value)
	{
		____emptyArray_5 = value;
		Il2CppCodeGenWriteBarrier((&____emptyArray_5), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LIST_1_TC332B4E87767ADFB1672A499D53D94AE897CD4A3_H
#ifndef LIST_1_T575BD1306846C6646814C99C87872FD64E8954AB_H
#define LIST_1_T575BD1306846C6646814C99C87872FD64E8954AB_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteFunctionAttribute>
struct  List_1_t575BD1306846C6646814C99C87872FD64E8954AB  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	SqliteFunctionAttributeU5BU5D_t9F2FD4AAE7DD86A410B87458717B795133C08EF6* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject * ____syncRoot_4;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_t575BD1306846C6646814C99C87872FD64E8954AB, ____items_1)); }
	inline SqliteFunctionAttributeU5BU5D_t9F2FD4AAE7DD86A410B87458717B795133C08EF6* get__items_1() const { return ____items_1; }
	inline SqliteFunctionAttributeU5BU5D_t9F2FD4AAE7DD86A410B87458717B795133C08EF6** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(SqliteFunctionAttributeU5BU5D_t9F2FD4AAE7DD86A410B87458717B795133C08EF6* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((&____items_1), value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_t575BD1306846C6646814C99C87872FD64E8954AB, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_t575BD1306846C6646814C99C87872FD64E8954AB, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}

	inline static int32_t get_offset_of__syncRoot_4() { return static_cast<int32_t>(offsetof(List_1_t575BD1306846C6646814C99C87872FD64E8954AB, ____syncRoot_4)); }
	inline RuntimeObject * get__syncRoot_4() const { return ____syncRoot_4; }
	inline RuntimeObject ** get_address_of__syncRoot_4() { return &____syncRoot_4; }
	inline void set__syncRoot_4(RuntimeObject * value)
	{
		____syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier((&____syncRoot_4), value);
	}
};

struct List_1_t575BD1306846C6646814C99C87872FD64E8954AB_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::_emptyArray
	SqliteFunctionAttributeU5BU5D_t9F2FD4AAE7DD86A410B87458717B795133C08EF6* ____emptyArray_5;

public:
	inline static int32_t get_offset_of__emptyArray_5() { return static_cast<int32_t>(offsetof(List_1_t575BD1306846C6646814C99C87872FD64E8954AB_StaticFields, ____emptyArray_5)); }
	inline SqliteFunctionAttributeU5BU5D_t9F2FD4AAE7DD86A410B87458717B795133C08EF6* get__emptyArray_5() const { return ____emptyArray_5; }
	inline SqliteFunctionAttributeU5BU5D_t9F2FD4AAE7DD86A410B87458717B795133C08EF6** get_address_of__emptyArray_5() { return &____emptyArray_5; }
	inline void set__emptyArray_5(SqliteFunctionAttributeU5BU5D_t9F2FD4AAE7DD86A410B87458717B795133C08EF6* value)
	{
		____emptyArray_5 = value;
		Il2CppCodeGenWriteBarrier((&____emptyArray_5), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LIST_1_T575BD1306846C6646814C99C87872FD64E8954AB_H
#ifndef LIST_1_TD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD_H
#define LIST_1_TD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteKeyReader_KeyInfo>
struct  List_1_tD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject * ____syncRoot_4;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_tD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD, ____items_1)); }
	inline KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* get__items_1() const { return ____items_1; }
	inline KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((&____items_1), value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_tD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_tD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}

	inline static int32_t get_offset_of__syncRoot_4() { return static_cast<int32_t>(offsetof(List_1_tD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD, ____syncRoot_4)); }
	inline RuntimeObject * get__syncRoot_4() const { return ____syncRoot_4; }
	inline RuntimeObject ** get_address_of__syncRoot_4() { return &____syncRoot_4; }
	inline void set__syncRoot_4(RuntimeObject * value)
	{
		____syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier((&____syncRoot_4), value);
	}
};

struct List_1_tD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::_emptyArray
	KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* ____emptyArray_5;

public:
	inline static int32_t get_offset_of__emptyArray_5() { return static_cast<int32_t>(offsetof(List_1_tD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD_StaticFields, ____emptyArray_5)); }
	inline KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* get__emptyArray_5() const { return ____emptyArray_5; }
	inline KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4** get_address_of__emptyArray_5() { return &____emptyArray_5; }
	inline void set__emptyArray_5(KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* value)
	{
		____emptyArray_5 = value;
		Il2CppCodeGenWriteBarrier((&____emptyArray_5), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LIST_1_TD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD_H
#ifndef LIST_1_T3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657_H
#define LIST_1_T3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteParameter>
struct  List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	SqliteParameterU5BU5D_t76F2417476AE80EE92606466B015185F4EEF2C27* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject * ____syncRoot_4;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657, ____items_1)); }
	inline SqliteParameterU5BU5D_t76F2417476AE80EE92606466B015185F4EEF2C27* get__items_1() const { return ____items_1; }
	inline SqliteParameterU5BU5D_t76F2417476AE80EE92606466B015185F4EEF2C27** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(SqliteParameterU5BU5D_t76F2417476AE80EE92606466B015185F4EEF2C27* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((&____items_1), value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}

	inline static int32_t get_offset_of__syncRoot_4() { return static_cast<int32_t>(offsetof(List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657, ____syncRoot_4)); }
	inline RuntimeObject * get__syncRoot_4() const { return ____syncRoot_4; }
	inline RuntimeObject ** get_address_of__syncRoot_4() { return &____syncRoot_4; }
	inline void set__syncRoot_4(RuntimeObject * value)
	{
		____syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier((&____syncRoot_4), value);
	}
};

struct List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::_emptyArray
	SqliteParameterU5BU5D_t76F2417476AE80EE92606466B015185F4EEF2C27* ____emptyArray_5;

public:
	inline static int32_t get_offset_of__emptyArray_5() { return static_cast<int32_t>(offsetof(List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657_StaticFields, ____emptyArray_5)); }
	inline SqliteParameterU5BU5D_t76F2417476AE80EE92606466B015185F4EEF2C27* get__emptyArray_5() const { return ____emptyArray_5; }
	inline SqliteParameterU5BU5D_t76F2417476AE80EE92606466B015185F4EEF2C27** get_address_of__emptyArray_5() { return &____emptyArray_5; }
	inline void set__emptyArray_5(SqliteParameterU5BU5D_t76F2417476AE80EE92606466B015185F4EEF2C27* value)
	{
		____emptyArray_5 = value;
		Il2CppCodeGenWriteBarrier((&____emptyArray_5), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LIST_1_T3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657_H
#ifndef LIST_1_T061A89EAEE080F1782627C91C598BD546671C91A_H
#define LIST_1_T061A89EAEE080F1782627C91C598BD546671C91A_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteStatement>
struct  List_1_t061A89EAEE080F1782627C91C598BD546671C91A  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	SqliteStatementU5BU5D_t7674D72DA7D8260C0E759CCDD34C29166C2E231C* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject * ____syncRoot_4;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_t061A89EAEE080F1782627C91C598BD546671C91A, ____items_1)); }
	inline SqliteStatementU5BU5D_t7674D72DA7D8260C0E759CCDD34C29166C2E231C* get__items_1() const { return ____items_1; }
	inline SqliteStatementU5BU5D_t7674D72DA7D8260C0E759CCDD34C29166C2E231C** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(SqliteStatementU5BU5D_t7674D72DA7D8260C0E759CCDD34C29166C2E231C* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((&____items_1), value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_t061A89EAEE080F1782627C91C598BD546671C91A, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_t061A89EAEE080F1782627C91C598BD546671C91A, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}

	inline static int32_t get_offset_of__syncRoot_4() { return static_cast<int32_t>(offsetof(List_1_t061A89EAEE080F1782627C91C598BD546671C91A, ____syncRoot_4)); }
	inline RuntimeObject * get__syncRoot_4() const { return ____syncRoot_4; }
	inline RuntimeObject ** get_address_of__syncRoot_4() { return &____syncRoot_4; }
	inline void set__syncRoot_4(RuntimeObject * value)
	{
		____syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier((&____syncRoot_4), value);
	}
};

struct List_1_t061A89EAEE080F1782627C91C598BD546671C91A_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::_emptyArray
	SqliteStatementU5BU5D_t7674D72DA7D8260C0E759CCDD34C29166C2E231C* ____emptyArray_5;

public:
	inline static int32_t get_offset_of__emptyArray_5() { return static_cast<int32_t>(offsetof(List_1_t061A89EAEE080F1782627C91C598BD546671C91A_StaticFields, ____emptyArray_5)); }
	inline SqliteStatementU5BU5D_t7674D72DA7D8260C0E759CCDD34C29166C2E231C* get__emptyArray_5() const { return ____emptyArray_5; }
	inline SqliteStatementU5BU5D_t7674D72DA7D8260C0E759CCDD34C29166C2E231C** get_address_of__emptyArray_5() { return &____emptyArray_5; }
	inline void set__emptyArray_5(SqliteStatementU5BU5D_t7674D72DA7D8260C0E759CCDD34C29166C2E231C* value)
	{
		____emptyArray_5 = value;
		Il2CppCodeGenWriteBarrier((&____emptyArray_5), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LIST_1_T061A89EAEE080F1782627C91C598BD546671C91A_H
#ifndef LIST_1_TE8032E48C661C350FF9550E9063D595C0AB25CD3_H
#define LIST_1_TE8032E48C661C350FF9550E9063D595C0AB25CD3_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.List`1<System.String>
struct  List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject * ____syncRoot_4;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3, ____items_1)); }
	inline StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* get__items_1() const { return ____items_1; }
	inline StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((&____items_1), value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}

	inline static int32_t get_offset_of__syncRoot_4() { return static_cast<int32_t>(offsetof(List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3, ____syncRoot_4)); }
	inline RuntimeObject * get__syncRoot_4() const { return ____syncRoot_4; }
	inline RuntimeObject ** get_address_of__syncRoot_4() { return &____syncRoot_4; }
	inline void set__syncRoot_4(RuntimeObject * value)
	{
		____syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier((&____syncRoot_4), value);
	}
};

struct List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::_emptyArray
	StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* ____emptyArray_5;

public:
	inline static int32_t get_offset_of__emptyArray_5() { return static_cast<int32_t>(offsetof(List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3_StaticFields, ____emptyArray_5)); }
	inline StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* get__emptyArray_5() const { return ____emptyArray_5; }
	inline StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E** get_address_of__emptyArray_5() { return &____emptyArray_5; }
	inline void set__emptyArray_5(StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* value)
	{
		____emptyArray_5 = value;
		Il2CppCodeGenWriteBarrier((&____emptyArray_5), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LIST_1_TE8032E48C661C350FF9550E9063D595C0AB25CD3_H
#ifndef MARSHALBYVALUECOMPONENT_TADC0E481D4D19F965AB659F9038A1D7D47FA636B_H
#define MARSHALBYVALUECOMPONENT_TADC0E481D4D19F965AB659F9038A1D7D47FA636B_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ComponentModel.MarshalByValueComponent
struct  MarshalByValueComponent_tADC0E481D4D19F965AB659F9038A1D7D47FA636B  : public RuntimeObject
{
public:
	// System.ComponentModel.ISite System.ComponentModel.MarshalByValueComponent::site
	RuntimeObject* ___site_1;
	// System.ComponentModel.EventHandlerList System.ComponentModel.MarshalByValueComponent::events
	EventHandlerList_tFE9EF79E85419EBB2C206CF475E29A9960699BE4 * ___events_2;

public:
	inline static int32_t get_offset_of_site_1() { return static_cast<int32_t>(offsetof(MarshalByValueComponent_tADC0E481D4D19F965AB659F9038A1D7D47FA636B, ___site_1)); }
	inline RuntimeObject* get_site_1() const { return ___site_1; }
	inline RuntimeObject** get_address_of_site_1() { return &___site_1; }
	inline void set_site_1(RuntimeObject* value)
	{
		___site_1 = value;
		Il2CppCodeGenWriteBarrier((&___site_1), value);
	}

	inline static int32_t get_offset_of_events_2() { return static_cast<int32_t>(offsetof(MarshalByValueComponent_tADC0E481D4D19F965AB659F9038A1D7D47FA636B, ___events_2)); }
	inline EventHandlerList_tFE9EF79E85419EBB2C206CF475E29A9960699BE4 * get_events_2() const { return ___events_2; }
	inline EventHandlerList_tFE9EF79E85419EBB2C206CF475E29A9960699BE4 ** get_address_of_events_2() { return &___events_2; }
	inline void set_events_2(EventHandlerList_tFE9EF79E85419EBB2C206CF475E29A9960699BE4 * value)
	{
		___events_2 = value;
		Il2CppCodeGenWriteBarrier((&___events_2), value);
	}
};

struct MarshalByValueComponent_tADC0E481D4D19F965AB659F9038A1D7D47FA636B_StaticFields
{
public:
	// System.Object System.ComponentModel.MarshalByValueComponent::EventDisposed
	RuntimeObject * ___EventDisposed_0;

public:
	inline static int32_t get_offset_of_EventDisposed_0() { return static_cast<int32_t>(offsetof(MarshalByValueComponent_tADC0E481D4D19F965AB659F9038A1D7D47FA636B_StaticFields, ___EventDisposed_0)); }
	inline RuntimeObject * get_EventDisposed_0() const { return ___EventDisposed_0; }
	inline RuntimeObject ** get_address_of_EventDisposed_0() { return &___EventDisposed_0; }
	inline void set_EventDisposed_0(RuntimeObject * value)
	{
		___EventDisposed_0 = value;
		Il2CppCodeGenWriteBarrier((&___EventDisposed_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MARSHALBYVALUECOMPONENT_TADC0E481D4D19F965AB659F9038A1D7D47FA636B_H
#ifndef DBNULL_T7400E04939C2C29699B389B106997892BF53A8E5_H
#define DBNULL_T7400E04939C2C29699B389B106997892BF53A8E5_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.DBNull
struct  DBNull_t7400E04939C2C29699B389B106997892BF53A8E5  : public RuntimeObject
{
public:

public:
};

struct DBNull_t7400E04939C2C29699B389B106997892BF53A8E5_StaticFields
{
public:
	// System.DBNull System.DBNull::Value
	DBNull_t7400E04939C2C29699B389B106997892BF53A8E5 * ___Value_0;

public:
	inline static int32_t get_offset_of_Value_0() { return static_cast<int32_t>(offsetof(DBNull_t7400E04939C2C29699B389B106997892BF53A8E5_StaticFields, ___Value_0)); }
	inline DBNull_t7400E04939C2C29699B389B106997892BF53A8E5 * get_Value_0() const { return ___Value_0; }
	inline DBNull_t7400E04939C2C29699B389B106997892BF53A8E5 ** get_address_of_Value_0() { return &___Value_0; }
	inline void set_Value_0(DBNull_t7400E04939C2C29699B389B106997892BF53A8E5 * value)
	{
		___Value_0 = value;
		Il2CppCodeGenWriteBarrier((&___Value_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // DBNULL_T7400E04939C2C29699B389B106997892BF53A8E5_H
#ifndef DBPROVIDERFACTORY_TD097542E2A2591557E9349A9AA0C1DD301D50DD4_H
#define DBPROVIDERFACTORY_TD097542E2A2591557E9349A9AA0C1DD301D50DD4_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Data.Common.DbProviderFactory
struct  DbProviderFactory_tD097542E2A2591557E9349A9AA0C1DD301D50DD4  : public RuntimeObject
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // DBPROVIDERFACTORY_TD097542E2A2591557E9349A9AA0C1DD301D50DD4_H
#ifndef SCHEMATABLECOLUMN_TBA9D4897119292BC737B937B41186DBFE71FFCCD_H
#define SCHEMATABLECOLUMN_TBA9D4897119292BC737B937B41186DBFE71FFCCD_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Data.Common.SchemaTableColumn
struct  SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD  : public RuntimeObject
{
public:

public:
};

struct SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields
{
public:
	// System.String System.Data.Common.SchemaTableColumn::ColumnName
	String_t* ___ColumnName_0;
	// System.String System.Data.Common.SchemaTableColumn::ColumnOrdinal
	String_t* ___ColumnOrdinal_1;
	// System.String System.Data.Common.SchemaTableColumn::ColumnSize
	String_t* ___ColumnSize_2;
	// System.String System.Data.Common.SchemaTableColumn::NumericPrecision
	String_t* ___NumericPrecision_3;
	// System.String System.Data.Common.SchemaTableColumn::NumericScale
	String_t* ___NumericScale_4;
	// System.String System.Data.Common.SchemaTableColumn::DataType
	String_t* ___DataType_5;
	// System.String System.Data.Common.SchemaTableColumn::ProviderType
	String_t* ___ProviderType_6;
	// System.String System.Data.Common.SchemaTableColumn::NonVersionedProviderType
	String_t* ___NonVersionedProviderType_7;
	// System.String System.Data.Common.SchemaTableColumn::IsLong
	String_t* ___IsLong_8;
	// System.String System.Data.Common.SchemaTableColumn::AllowDBNull
	String_t* ___AllowDBNull_9;
	// System.String System.Data.Common.SchemaTableColumn::IsAliased
	String_t* ___IsAliased_10;
	// System.String System.Data.Common.SchemaTableColumn::IsExpression
	String_t* ___IsExpression_11;
	// System.String System.Data.Common.SchemaTableColumn::IsKey
	String_t* ___IsKey_12;
	// System.String System.Data.Common.SchemaTableColumn::IsUnique
	String_t* ___IsUnique_13;
	// System.String System.Data.Common.SchemaTableColumn::BaseSchemaName
	String_t* ___BaseSchemaName_14;
	// System.String System.Data.Common.SchemaTableColumn::BaseTableName
	String_t* ___BaseTableName_15;
	// System.String System.Data.Common.SchemaTableColumn::BaseColumnName
	String_t* ___BaseColumnName_16;

public:
	inline static int32_t get_offset_of_ColumnName_0() { return static_cast<int32_t>(offsetof(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields, ___ColumnName_0)); }
	inline String_t* get_ColumnName_0() const { return ___ColumnName_0; }
	inline String_t** get_address_of_ColumnName_0() { return &___ColumnName_0; }
	inline void set_ColumnName_0(String_t* value)
	{
		___ColumnName_0 = value;
		Il2CppCodeGenWriteBarrier((&___ColumnName_0), value);
	}

	inline static int32_t get_offset_of_ColumnOrdinal_1() { return static_cast<int32_t>(offsetof(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields, ___ColumnOrdinal_1)); }
	inline String_t* get_ColumnOrdinal_1() const { return ___ColumnOrdinal_1; }
	inline String_t** get_address_of_ColumnOrdinal_1() { return &___ColumnOrdinal_1; }
	inline void set_ColumnOrdinal_1(String_t* value)
	{
		___ColumnOrdinal_1 = value;
		Il2CppCodeGenWriteBarrier((&___ColumnOrdinal_1), value);
	}

	inline static int32_t get_offset_of_ColumnSize_2() { return static_cast<int32_t>(offsetof(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields, ___ColumnSize_2)); }
	inline String_t* get_ColumnSize_2() const { return ___ColumnSize_2; }
	inline String_t** get_address_of_ColumnSize_2() { return &___ColumnSize_2; }
	inline void set_ColumnSize_2(String_t* value)
	{
		___ColumnSize_2 = value;
		Il2CppCodeGenWriteBarrier((&___ColumnSize_2), value);
	}

	inline static int32_t get_offset_of_NumericPrecision_3() { return static_cast<int32_t>(offsetof(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields, ___NumericPrecision_3)); }
	inline String_t* get_NumericPrecision_3() const { return ___NumericPrecision_3; }
	inline String_t** get_address_of_NumericPrecision_3() { return &___NumericPrecision_3; }
	inline void set_NumericPrecision_3(String_t* value)
	{
		___NumericPrecision_3 = value;
		Il2CppCodeGenWriteBarrier((&___NumericPrecision_3), value);
	}

	inline static int32_t get_offset_of_NumericScale_4() { return static_cast<int32_t>(offsetof(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields, ___NumericScale_4)); }
	inline String_t* get_NumericScale_4() const { return ___NumericScale_4; }
	inline String_t** get_address_of_NumericScale_4() { return &___NumericScale_4; }
	inline void set_NumericScale_4(String_t* value)
	{
		___NumericScale_4 = value;
		Il2CppCodeGenWriteBarrier((&___NumericScale_4), value);
	}

	inline static int32_t get_offset_of_DataType_5() { return static_cast<int32_t>(offsetof(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields, ___DataType_5)); }
	inline String_t* get_DataType_5() const { return ___DataType_5; }
	inline String_t** get_address_of_DataType_5() { return &___DataType_5; }
	inline void set_DataType_5(String_t* value)
	{
		___DataType_5 = value;
		Il2CppCodeGenWriteBarrier((&___DataType_5), value);
	}

	inline static int32_t get_offset_of_ProviderType_6() { return static_cast<int32_t>(offsetof(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields, ___ProviderType_6)); }
	inline String_t* get_ProviderType_6() const { return ___ProviderType_6; }
	inline String_t** get_address_of_ProviderType_6() { return &___ProviderType_6; }
	inline void set_ProviderType_6(String_t* value)
	{
		___ProviderType_6 = value;
		Il2CppCodeGenWriteBarrier((&___ProviderType_6), value);
	}

	inline static int32_t get_offset_of_NonVersionedProviderType_7() { return static_cast<int32_t>(offsetof(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields, ___NonVersionedProviderType_7)); }
	inline String_t* get_NonVersionedProviderType_7() const { return ___NonVersionedProviderType_7; }
	inline String_t** get_address_of_NonVersionedProviderType_7() { return &___NonVersionedProviderType_7; }
	inline void set_NonVersionedProviderType_7(String_t* value)
	{
		___NonVersionedProviderType_7 = value;
		Il2CppCodeGenWriteBarrier((&___NonVersionedProviderType_7), value);
	}

	inline static int32_t get_offset_of_IsLong_8() { return static_cast<int32_t>(offsetof(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields, ___IsLong_8)); }
	inline String_t* get_IsLong_8() const { return ___IsLong_8; }
	inline String_t** get_address_of_IsLong_8() { return &___IsLong_8; }
	inline void set_IsLong_8(String_t* value)
	{
		___IsLong_8 = value;
		Il2CppCodeGenWriteBarrier((&___IsLong_8), value);
	}

	inline static int32_t get_offset_of_AllowDBNull_9() { return static_cast<int32_t>(offsetof(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields, ___AllowDBNull_9)); }
	inline String_t* get_AllowDBNull_9() const { return ___AllowDBNull_9; }
	inline String_t** get_address_of_AllowDBNull_9() { return &___AllowDBNull_9; }
	inline void set_AllowDBNull_9(String_t* value)
	{
		___AllowDBNull_9 = value;
		Il2CppCodeGenWriteBarrier((&___AllowDBNull_9), value);
	}

	inline static int32_t get_offset_of_IsAliased_10() { return static_cast<int32_t>(offsetof(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields, ___IsAliased_10)); }
	inline String_t* get_IsAliased_10() const { return ___IsAliased_10; }
	inline String_t** get_address_of_IsAliased_10() { return &___IsAliased_10; }
	inline void set_IsAliased_10(String_t* value)
	{
		___IsAliased_10 = value;
		Il2CppCodeGenWriteBarrier((&___IsAliased_10), value);
	}

	inline static int32_t get_offset_of_IsExpression_11() { return static_cast<int32_t>(offsetof(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields, ___IsExpression_11)); }
	inline String_t* get_IsExpression_11() const { return ___IsExpression_11; }
	inline String_t** get_address_of_IsExpression_11() { return &___IsExpression_11; }
	inline void set_IsExpression_11(String_t* value)
	{
		___IsExpression_11 = value;
		Il2CppCodeGenWriteBarrier((&___IsExpression_11), value);
	}

	inline static int32_t get_offset_of_IsKey_12() { return static_cast<int32_t>(offsetof(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields, ___IsKey_12)); }
	inline String_t* get_IsKey_12() const { return ___IsKey_12; }
	inline String_t** get_address_of_IsKey_12() { return &___IsKey_12; }
	inline void set_IsKey_12(String_t* value)
	{
		___IsKey_12 = value;
		Il2CppCodeGenWriteBarrier((&___IsKey_12), value);
	}

	inline static int32_t get_offset_of_IsUnique_13() { return static_cast<int32_t>(offsetof(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields, ___IsUnique_13)); }
	inline String_t* get_IsUnique_13() const { return ___IsUnique_13; }
	inline String_t** get_address_of_IsUnique_13() { return &___IsUnique_13; }
	inline void set_IsUnique_13(String_t* value)
	{
		___IsUnique_13 = value;
		Il2CppCodeGenWriteBarrier((&___IsUnique_13), value);
	}

	inline static int32_t get_offset_of_BaseSchemaName_14() { return static_cast<int32_t>(offsetof(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields, ___BaseSchemaName_14)); }
	inline String_t* get_BaseSchemaName_14() const { return ___BaseSchemaName_14; }
	inline String_t** get_address_of_BaseSchemaName_14() { return &___BaseSchemaName_14; }
	inline void set_BaseSchemaName_14(String_t* value)
	{
		___BaseSchemaName_14 = value;
		Il2CppCodeGenWriteBarrier((&___BaseSchemaName_14), value);
	}

	inline static int32_t get_offset_of_BaseTableName_15() { return static_cast<int32_t>(offsetof(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields, ___BaseTableName_15)); }
	inline String_t* get_BaseTableName_15() const { return ___BaseTableName_15; }
	inline String_t** get_address_of_BaseTableName_15() { return &___BaseTableName_15; }
	inline void set_BaseTableName_15(String_t* value)
	{
		___BaseTableName_15 = value;
		Il2CppCodeGenWriteBarrier((&___BaseTableName_15), value);
	}

	inline static int32_t get_offset_of_BaseColumnName_16() { return static_cast<int32_t>(offsetof(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields, ___BaseColumnName_16)); }
	inline String_t* get_BaseColumnName_16() const { return ___BaseColumnName_16; }
	inline String_t** get_address_of_BaseColumnName_16() { return &___BaseColumnName_16; }
	inline void set_BaseColumnName_16(String_t* value)
	{
		___BaseColumnName_16 = value;
		Il2CppCodeGenWriteBarrier((&___BaseColumnName_16), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SCHEMATABLECOLUMN_TBA9D4897119292BC737B937B41186DBFE71FFCCD_H
#ifndef SCHEMATABLEOPTIONALCOLUMN_TBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_H
#define SCHEMATABLEOPTIONALCOLUMN_TBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Data.Common.SchemaTableOptionalColumn
struct  SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93  : public RuntimeObject
{
public:

public:
};

struct SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_StaticFields
{
public:
	// System.String System.Data.Common.SchemaTableOptionalColumn::ProviderSpecificDataType
	String_t* ___ProviderSpecificDataType_0;
	// System.String System.Data.Common.SchemaTableOptionalColumn::IsAutoIncrement
	String_t* ___IsAutoIncrement_1;
	// System.String System.Data.Common.SchemaTableOptionalColumn::IsHidden
	String_t* ___IsHidden_2;
	// System.String System.Data.Common.SchemaTableOptionalColumn::IsReadOnly
	String_t* ___IsReadOnly_3;
	// System.String System.Data.Common.SchemaTableOptionalColumn::IsRowVersion
	String_t* ___IsRowVersion_4;
	// System.String System.Data.Common.SchemaTableOptionalColumn::BaseServerName
	String_t* ___BaseServerName_5;
	// System.String System.Data.Common.SchemaTableOptionalColumn::BaseCatalogName
	String_t* ___BaseCatalogName_6;
	// System.String System.Data.Common.SchemaTableOptionalColumn::AutoIncrementSeed
	String_t* ___AutoIncrementSeed_7;
	// System.String System.Data.Common.SchemaTableOptionalColumn::AutoIncrementStep
	String_t* ___AutoIncrementStep_8;
	// System.String System.Data.Common.SchemaTableOptionalColumn::DefaultValue
	String_t* ___DefaultValue_9;
	// System.String System.Data.Common.SchemaTableOptionalColumn::Expression
	String_t* ___Expression_10;
	// System.String System.Data.Common.SchemaTableOptionalColumn::BaseTableNamespace
	String_t* ___BaseTableNamespace_11;
	// System.String System.Data.Common.SchemaTableOptionalColumn::BaseColumnNamespace
	String_t* ___BaseColumnNamespace_12;
	// System.String System.Data.Common.SchemaTableOptionalColumn::ColumnMapping
	String_t* ___ColumnMapping_13;

public:
	inline static int32_t get_offset_of_ProviderSpecificDataType_0() { return static_cast<int32_t>(offsetof(SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_StaticFields, ___ProviderSpecificDataType_0)); }
	inline String_t* get_ProviderSpecificDataType_0() const { return ___ProviderSpecificDataType_0; }
	inline String_t** get_address_of_ProviderSpecificDataType_0() { return &___ProviderSpecificDataType_0; }
	inline void set_ProviderSpecificDataType_0(String_t* value)
	{
		___ProviderSpecificDataType_0 = value;
		Il2CppCodeGenWriteBarrier((&___ProviderSpecificDataType_0), value);
	}

	inline static int32_t get_offset_of_IsAutoIncrement_1() { return static_cast<int32_t>(offsetof(SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_StaticFields, ___IsAutoIncrement_1)); }
	inline String_t* get_IsAutoIncrement_1() const { return ___IsAutoIncrement_1; }
	inline String_t** get_address_of_IsAutoIncrement_1() { return &___IsAutoIncrement_1; }
	inline void set_IsAutoIncrement_1(String_t* value)
	{
		___IsAutoIncrement_1 = value;
		Il2CppCodeGenWriteBarrier((&___IsAutoIncrement_1), value);
	}

	inline static int32_t get_offset_of_IsHidden_2() { return static_cast<int32_t>(offsetof(SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_StaticFields, ___IsHidden_2)); }
	inline String_t* get_IsHidden_2() const { return ___IsHidden_2; }
	inline String_t** get_address_of_IsHidden_2() { return &___IsHidden_2; }
	inline void set_IsHidden_2(String_t* value)
	{
		___IsHidden_2 = value;
		Il2CppCodeGenWriteBarrier((&___IsHidden_2), value);
	}

	inline static int32_t get_offset_of_IsReadOnly_3() { return static_cast<int32_t>(offsetof(SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_StaticFields, ___IsReadOnly_3)); }
	inline String_t* get_IsReadOnly_3() const { return ___IsReadOnly_3; }
	inline String_t** get_address_of_IsReadOnly_3() { return &___IsReadOnly_3; }
	inline void set_IsReadOnly_3(String_t* value)
	{
		___IsReadOnly_3 = value;
		Il2CppCodeGenWriteBarrier((&___IsReadOnly_3), value);
	}

	inline static int32_t get_offset_of_IsRowVersion_4() { return static_cast<int32_t>(offsetof(SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_StaticFields, ___IsRowVersion_4)); }
	inline String_t* get_IsRowVersion_4() const { return ___IsRowVersion_4; }
	inline String_t** get_address_of_IsRowVersion_4() { return &___IsRowVersion_4; }
	inline void set_IsRowVersion_4(String_t* value)
	{
		___IsRowVersion_4 = value;
		Il2CppCodeGenWriteBarrier((&___IsRowVersion_4), value);
	}

	inline static int32_t get_offset_of_BaseServerName_5() { return static_cast<int32_t>(offsetof(SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_StaticFields, ___BaseServerName_5)); }
	inline String_t* get_BaseServerName_5() const { return ___BaseServerName_5; }
	inline String_t** get_address_of_BaseServerName_5() { return &___BaseServerName_5; }
	inline void set_BaseServerName_5(String_t* value)
	{
		___BaseServerName_5 = value;
		Il2CppCodeGenWriteBarrier((&___BaseServerName_5), value);
	}

	inline static int32_t get_offset_of_BaseCatalogName_6() { return static_cast<int32_t>(offsetof(SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_StaticFields, ___BaseCatalogName_6)); }
	inline String_t* get_BaseCatalogName_6() const { return ___BaseCatalogName_6; }
	inline String_t** get_address_of_BaseCatalogName_6() { return &___BaseCatalogName_6; }
	inline void set_BaseCatalogName_6(String_t* value)
	{
		___BaseCatalogName_6 = value;
		Il2CppCodeGenWriteBarrier((&___BaseCatalogName_6), value);
	}

	inline static int32_t get_offset_of_AutoIncrementSeed_7() { return static_cast<int32_t>(offsetof(SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_StaticFields, ___AutoIncrementSeed_7)); }
	inline String_t* get_AutoIncrementSeed_7() const { return ___AutoIncrementSeed_7; }
	inline String_t** get_address_of_AutoIncrementSeed_7() { return &___AutoIncrementSeed_7; }
	inline void set_AutoIncrementSeed_7(String_t* value)
	{
		___AutoIncrementSeed_7 = value;
		Il2CppCodeGenWriteBarrier((&___AutoIncrementSeed_7), value);
	}

	inline static int32_t get_offset_of_AutoIncrementStep_8() { return static_cast<int32_t>(offsetof(SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_StaticFields, ___AutoIncrementStep_8)); }
	inline String_t* get_AutoIncrementStep_8() const { return ___AutoIncrementStep_8; }
	inline String_t** get_address_of_AutoIncrementStep_8() { return &___AutoIncrementStep_8; }
	inline void set_AutoIncrementStep_8(String_t* value)
	{
		___AutoIncrementStep_8 = value;
		Il2CppCodeGenWriteBarrier((&___AutoIncrementStep_8), value);
	}

	inline static int32_t get_offset_of_DefaultValue_9() { return static_cast<int32_t>(offsetof(SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_StaticFields, ___DefaultValue_9)); }
	inline String_t* get_DefaultValue_9() const { return ___DefaultValue_9; }
	inline String_t** get_address_of_DefaultValue_9() { return &___DefaultValue_9; }
	inline void set_DefaultValue_9(String_t* value)
	{
		___DefaultValue_9 = value;
		Il2CppCodeGenWriteBarrier((&___DefaultValue_9), value);
	}

	inline static int32_t get_offset_of_Expression_10() { return static_cast<int32_t>(offsetof(SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_StaticFields, ___Expression_10)); }
	inline String_t* get_Expression_10() const { return ___Expression_10; }
	inline String_t** get_address_of_Expression_10() { return &___Expression_10; }
	inline void set_Expression_10(String_t* value)
	{
		___Expression_10 = value;
		Il2CppCodeGenWriteBarrier((&___Expression_10), value);
	}

	inline static int32_t get_offset_of_BaseTableNamespace_11() { return static_cast<int32_t>(offsetof(SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_StaticFields, ___BaseTableNamespace_11)); }
	inline String_t* get_BaseTableNamespace_11() const { return ___BaseTableNamespace_11; }
	inline String_t** get_address_of_BaseTableNamespace_11() { return &___BaseTableNamespace_11; }
	inline void set_BaseTableNamespace_11(String_t* value)
	{
		___BaseTableNamespace_11 = value;
		Il2CppCodeGenWriteBarrier((&___BaseTableNamespace_11), value);
	}

	inline static int32_t get_offset_of_BaseColumnNamespace_12() { return static_cast<int32_t>(offsetof(SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_StaticFields, ___BaseColumnNamespace_12)); }
	inline String_t* get_BaseColumnNamespace_12() const { return ___BaseColumnNamespace_12; }
	inline String_t** get_address_of_BaseColumnNamespace_12() { return &___BaseColumnNamespace_12; }
	inline void set_BaseColumnNamespace_12(String_t* value)
	{
		___BaseColumnNamespace_12 = value;
		Il2CppCodeGenWriteBarrier((&___BaseColumnNamespace_12), value);
	}

	inline static int32_t get_offset_of_ColumnMapping_13() { return static_cast<int32_t>(offsetof(SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_StaticFields, ___ColumnMapping_13)); }
	inline String_t* get_ColumnMapping_13() const { return ___ColumnMapping_13; }
	inline String_t** get_address_of_ColumnMapping_13() { return &___ColumnMapping_13; }
	inline void set_ColumnMapping_13(String_t* value)
	{
		___ColumnMapping_13 = value;
		Il2CppCodeGenWriteBarrier((&___ColumnMapping_13), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SCHEMATABLEOPTIONALCOLUMN_TBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_H
#ifndef INTERNALDATACOLLECTIONBASE_T8A94DFD07E59FFED7EE80E5F808509E3B2DA7334_H
#define INTERNALDATACOLLECTIONBASE_T8A94DFD07E59FFED7EE80E5F808509E3B2DA7334_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Data.InternalDataCollectionBase
struct  InternalDataCollectionBase_t8A94DFD07E59FFED7EE80E5F808509E3B2DA7334  : public RuntimeObject
{
public:

public:
};

struct InternalDataCollectionBase_t8A94DFD07E59FFED7EE80E5F808509E3B2DA7334_StaticFields
{
public:
	// System.ComponentModel.CollectionChangeEventArgs System.Data.InternalDataCollectionBase::s_refreshEventArgs
	CollectionChangeEventArgs_t63CA165C1F7D765B04CB139EB6577577479E57B0 * ___s_refreshEventArgs_0;

public:
	inline static int32_t get_offset_of_s_refreshEventArgs_0() { return static_cast<int32_t>(offsetof(InternalDataCollectionBase_t8A94DFD07E59FFED7EE80E5F808509E3B2DA7334_StaticFields, ___s_refreshEventArgs_0)); }
	inline CollectionChangeEventArgs_t63CA165C1F7D765B04CB139EB6577577479E57B0 * get_s_refreshEventArgs_0() const { return ___s_refreshEventArgs_0; }
	inline CollectionChangeEventArgs_t63CA165C1F7D765B04CB139EB6577577479E57B0 ** get_address_of_s_refreshEventArgs_0() { return &___s_refreshEventArgs_0; }
	inline void set_s_refreshEventArgs_0(CollectionChangeEventArgs_t63CA165C1F7D765B04CB139EB6577577479E57B0 * value)
	{
		___s_refreshEventArgs_0 = value;
		Il2CppCodeGenWriteBarrier((&___s_refreshEventArgs_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // INTERNALDATACOLLECTIONBASE_T8A94DFD07E59FFED7EE80E5F808509E3B2DA7334_H
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
#ifndef CRITICALFINALIZEROBJECT_T8B006E1DEE084E781F5C0F3283E9226E28894DD9_H
#define CRITICALFINALIZEROBJECT_T8B006E1DEE084E781F5C0F3283E9226E28894DD9_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Runtime.ConstrainedExecution.CriticalFinalizerObject
struct  CriticalFinalizerObject_t8B006E1DEE084E781F5C0F3283E9226E28894DD9  : public RuntimeObject
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // CRITICALFINALIZEROBJECT_T8B006E1DEE084E781F5C0F3283E9226E28894DD9_H
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
#ifndef U24ARRAYTYPEU24104_T3338070C30A69BED9D16163FBBE9A7DB1E2C13D1_H
#define U24ARRAYTYPEU24104_T3338070C30A69BED9D16163FBBE9A7DB1E2C13D1_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <PrivateImplementationDetails>_U24ArrayTypeU24104
struct  U24ArrayTypeU24104_t3338070C30A69BED9D16163FBBE9A7DB1E2C13D1 
{
public:
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t U24ArrayTypeU24104_t3338070C30A69BED9D16163FBBE9A7DB1E2C13D1__padding[104];
	};

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // U24ARRAYTYPEU24104_T3338070C30A69BED9D16163FBBE9A7DB1E2C13D1_H
#ifndef U24ARRAYTYPEU248_TB8F27E5643A76658911515F707FABEC752436459_H
#define U24ARRAYTYPEU248_TB8F27E5643A76658911515F707FABEC752436459_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <PrivateImplementationDetails>_U24ArrayTypeU248
struct  U24ArrayTypeU248_tB8F27E5643A76658911515F707FABEC752436459 
{
public:
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t U24ArrayTypeU248_tB8F27E5643A76658911515F707FABEC752436459__padding[8];
	};

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // U24ARRAYTYPEU248_TB8F27E5643A76658911515F707FABEC752436459_H
#ifndef SQLITEFACTORY_TCD593DBD80F7C651562973746B9D3656C417B6F7_H
#define SQLITEFACTORY_TCD593DBD80F7C651562973746B9D3656C417B6F7_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.SqliteFactory
struct  SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7  : public DbProviderFactory_tD097542E2A2591557E9349A9AA0C1DD301D50DD4
{
public:

public:
};

struct SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7_StaticFields
{
public:
	// Mono.Data.Sqlite.SqliteFactory Mono.Data.Sqlite.SqliteFactory::Instance
	SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7 * ___Instance_0;
	// System.Type Mono.Data.Sqlite.SqliteFactory::_dbProviderServicesType
	Type_t * ____dbProviderServicesType_1;
	// System.Object Mono.Data.Sqlite.SqliteFactory::_sqliteServices
	RuntimeObject * ____sqliteServices_2;

public:
	inline static int32_t get_offset_of_Instance_0() { return static_cast<int32_t>(offsetof(SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7_StaticFields, ___Instance_0)); }
	inline SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7 * get_Instance_0() const { return ___Instance_0; }
	inline SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7 ** get_address_of_Instance_0() { return &___Instance_0; }
	inline void set_Instance_0(SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7 * value)
	{
		___Instance_0 = value;
		Il2CppCodeGenWriteBarrier((&___Instance_0), value);
	}

	inline static int32_t get_offset_of__dbProviderServicesType_1() { return static_cast<int32_t>(offsetof(SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7_StaticFields, ____dbProviderServicesType_1)); }
	inline Type_t * get__dbProviderServicesType_1() const { return ____dbProviderServicesType_1; }
	inline Type_t ** get_address_of__dbProviderServicesType_1() { return &____dbProviderServicesType_1; }
	inline void set__dbProviderServicesType_1(Type_t * value)
	{
		____dbProviderServicesType_1 = value;
		Il2CppCodeGenWriteBarrier((&____dbProviderServicesType_1), value);
	}

	inline static int32_t get_offset_of__sqliteServices_2() { return static_cast<int32_t>(offsetof(SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7_StaticFields, ____sqliteServices_2)); }
	inline RuntimeObject * get__sqliteServices_2() const { return ____sqliteServices_2; }
	inline RuntimeObject ** get_address_of__sqliteServices_2() { return &____sqliteServices_2; }
	inline void set__sqliteServices_2(RuntimeObject * value)
	{
		____sqliteServices_2 = value;
		Il2CppCodeGenWriteBarrier((&____sqliteServices_2), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SQLITEFACTORY_TCD593DBD80F7C651562973746B9D3656C417B6F7_H
#ifndef KEYINFO_TE5FC024B7C6507C910292D7D1B2A8D6B43E123AC_H
#define KEYINFO_TE5FC024B7C6507C910292D7D1B2A8D6B43E123AC_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.SqliteKeyReader_KeyInfo
struct  KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC 
{
public:
	// System.String Mono.Data.Sqlite.SqliteKeyReader_KeyInfo::databaseName
	String_t* ___databaseName_0;
	// System.String Mono.Data.Sqlite.SqliteKeyReader_KeyInfo::tableName
	String_t* ___tableName_1;
	// System.String Mono.Data.Sqlite.SqliteKeyReader_KeyInfo::columnName
	String_t* ___columnName_2;
	// System.Int32 Mono.Data.Sqlite.SqliteKeyReader_KeyInfo::database
	int32_t ___database_3;
	// System.Int32 Mono.Data.Sqlite.SqliteKeyReader_KeyInfo::rootPage
	int32_t ___rootPage_4;
	// System.Int32 Mono.Data.Sqlite.SqliteKeyReader_KeyInfo::cursor
	int32_t ___cursor_5;
	// Mono.Data.Sqlite.SqliteKeyReader_KeyQuery Mono.Data.Sqlite.SqliteKeyReader_KeyInfo::query
	KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * ___query_6;
	// System.Int32 Mono.Data.Sqlite.SqliteKeyReader_KeyInfo::column
	int32_t ___column_7;

public:
	inline static int32_t get_offset_of_databaseName_0() { return static_cast<int32_t>(offsetof(KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC, ___databaseName_0)); }
	inline String_t* get_databaseName_0() const { return ___databaseName_0; }
	inline String_t** get_address_of_databaseName_0() { return &___databaseName_0; }
	inline void set_databaseName_0(String_t* value)
	{
		___databaseName_0 = value;
		Il2CppCodeGenWriteBarrier((&___databaseName_0), value);
	}

	inline static int32_t get_offset_of_tableName_1() { return static_cast<int32_t>(offsetof(KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC, ___tableName_1)); }
	inline String_t* get_tableName_1() const { return ___tableName_1; }
	inline String_t** get_address_of_tableName_1() { return &___tableName_1; }
	inline void set_tableName_1(String_t* value)
	{
		___tableName_1 = value;
		Il2CppCodeGenWriteBarrier((&___tableName_1), value);
	}

	inline static int32_t get_offset_of_columnName_2() { return static_cast<int32_t>(offsetof(KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC, ___columnName_2)); }
	inline String_t* get_columnName_2() const { return ___columnName_2; }
	inline String_t** get_address_of_columnName_2() { return &___columnName_2; }
	inline void set_columnName_2(String_t* value)
	{
		___columnName_2 = value;
		Il2CppCodeGenWriteBarrier((&___columnName_2), value);
	}

	inline static int32_t get_offset_of_database_3() { return static_cast<int32_t>(offsetof(KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC, ___database_3)); }
	inline int32_t get_database_3() const { return ___database_3; }
	inline int32_t* get_address_of_database_3() { return &___database_3; }
	inline void set_database_3(int32_t value)
	{
		___database_3 = value;
	}

	inline static int32_t get_offset_of_rootPage_4() { return static_cast<int32_t>(offsetof(KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC, ___rootPage_4)); }
	inline int32_t get_rootPage_4() const { return ___rootPage_4; }
	inline int32_t* get_address_of_rootPage_4() { return &___rootPage_4; }
	inline void set_rootPage_4(int32_t value)
	{
		___rootPage_4 = value;
	}

	inline static int32_t get_offset_of_cursor_5() { return static_cast<int32_t>(offsetof(KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC, ___cursor_5)); }
	inline int32_t get_cursor_5() const { return ___cursor_5; }
	inline int32_t* get_address_of_cursor_5() { return &___cursor_5; }
	inline void set_cursor_5(int32_t value)
	{
		___cursor_5 = value;
	}

	inline static int32_t get_offset_of_query_6() { return static_cast<int32_t>(offsetof(KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC, ___query_6)); }
	inline KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * get_query_6() const { return ___query_6; }
	inline KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 ** get_address_of_query_6() { return &___query_6; }
	inline void set_query_6(KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * value)
	{
		___query_6 = value;
		Il2CppCodeGenWriteBarrier((&___query_6), value);
	}

	inline static int32_t get_offset_of_column_7() { return static_cast<int32_t>(offsetof(KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC, ___column_7)); }
	inline int32_t get_column_7() const { return ___column_7; }
	inline int32_t* get_address_of_column_7() { return &___column_7; }
	inline void set_column_7(int32_t value)
	{
		___column_7 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of Mono.Data.Sqlite.SqliteKeyReader/KeyInfo
struct KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC_marshaled_pinvoke
{
	char* ___databaseName_0;
	char* ___tableName_1;
	char* ___columnName_2;
	int32_t ___database_3;
	int32_t ___rootPage_4;
	int32_t ___cursor_5;
	KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * ___query_6;
	int32_t ___column_7;
};
// Native definition for COM marshalling of Mono.Data.Sqlite.SqliteKeyReader/KeyInfo
struct KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC_marshaled_com
{
	Il2CppChar* ___databaseName_0;
	Il2CppChar* ___tableName_1;
	Il2CppChar* ___columnName_2;
	int32_t ___database_3;
	int32_t ___rootPage_4;
	int32_t ___cursor_5;
	KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * ___query_6;
	int32_t ___column_7;
};
#endif // KEYINFO_TE5FC024B7C6507C910292D7D1B2A8D6B43E123AC_H
#ifndef UPDATEEVENTARGS_T746B5CB317589AB741D8928289260B488F917A5E_H
#define UPDATEEVENTARGS_T746B5CB317589AB741D8928289260B488F917A5E_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.UpdateEventArgs
struct  UpdateEventArgs_t746B5CB317589AB741D8928289260B488F917A5E  : public EventArgs_t8E6CA180BE0E56674C6407011A94BAF7C757352E
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UPDATEEVENTARGS_T746B5CB317589AB741D8928289260B488F917A5E_H
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
#ifndef KEYVALUEPAIR_2_T93C466ABB3C1789B9638D6DAE171650D781D5955_H
#define KEYVALUEPAIR_2_T93C466ABB3C1789B9638D6DAE171650D781D5955_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.KeyValuePair`2<System.Int64,Mono.Data.Sqlite.SqliteFunction_AggregateData>
struct  KeyValuePair_2_t93C466ABB3C1789B9638D6DAE171650D781D5955 
{
public:
	// TKey System.Collections.Generic.KeyValuePair`2::key
	int64_t ___key_0;
	// TValue System.Collections.Generic.KeyValuePair`2::value
	AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755 * ___value_1;

public:
	inline static int32_t get_offset_of_key_0() { return static_cast<int32_t>(offsetof(KeyValuePair_2_t93C466ABB3C1789B9638D6DAE171650D781D5955, ___key_0)); }
	inline int64_t get_key_0() const { return ___key_0; }
	inline int64_t* get_address_of_key_0() { return &___key_0; }
	inline void set_key_0(int64_t value)
	{
		___key_0 = value;
	}

	inline static int32_t get_offset_of_value_1() { return static_cast<int32_t>(offsetof(KeyValuePair_2_t93C466ABB3C1789B9638D6DAE171650D781D5955, ___value_1)); }
	inline AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755 * get_value_1() const { return ___value_1; }
	inline AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755 ** get_address_of_value_1() { return &___value_1; }
	inline void set_value_1(AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755 * value)
	{
		___value_1 = value;
		Il2CppCodeGenWriteBarrier((&___value_1), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // KEYVALUEPAIR_2_T93C466ABB3C1789B9638D6DAE171650D781D5955_H
#ifndef KEYVALUEPAIR_2_T63B92AF862B96BB211B19E9A360065FE8541A53E_H
#define KEYVALUEPAIR_2_T63B92AF862B96BB211B19E9A360065FE8541A53E_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.KeyValuePair`2<System.Int64,System.Object>
struct  KeyValuePair_2_t63B92AF862B96BB211B19E9A360065FE8541A53E 
{
public:
	// TKey System.Collections.Generic.KeyValuePair`2::key
	int64_t ___key_0;
	// TValue System.Collections.Generic.KeyValuePair`2::value
	RuntimeObject * ___value_1;

public:
	inline static int32_t get_offset_of_key_0() { return static_cast<int32_t>(offsetof(KeyValuePair_2_t63B92AF862B96BB211B19E9A360065FE8541A53E, ___key_0)); }
	inline int64_t get_key_0() const { return ___key_0; }
	inline int64_t* get_address_of_key_0() { return &___key_0; }
	inline void set_key_0(int64_t value)
	{
		___key_0 = value;
	}

	inline static int32_t get_offset_of_value_1() { return static_cast<int32_t>(offsetof(KeyValuePair_2_t63B92AF862B96BB211B19E9A360065FE8541A53E, ___value_1)); }
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
#endif // KEYVALUEPAIR_2_T63B92AF862B96BB211B19E9A360065FE8541A53E_H
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
#ifndef KEYVALUEPAIR_2_T9E20856DB65BAC258C27F3C359C8A86E2DCEEBBD_H
#define KEYVALUEPAIR_2_T9E20856DB65BAC258C27F3C359C8A86E2DCEEBBD_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.KeyValuePair`2<System.String,System.Collections.Generic.List`1<System.String>>
struct  KeyValuePair_2_t9E20856DB65BAC258C27F3C359C8A86E2DCEEBBD 
{
public:
	// TKey System.Collections.Generic.KeyValuePair`2::key
	String_t* ___key_0;
	// TValue System.Collections.Generic.KeyValuePair`2::value
	List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * ___value_1;

public:
	inline static int32_t get_offset_of_key_0() { return static_cast<int32_t>(offsetof(KeyValuePair_2_t9E20856DB65BAC258C27F3C359C8A86E2DCEEBBD, ___key_0)); }
	inline String_t* get_key_0() const { return ___key_0; }
	inline String_t** get_address_of_key_0() { return &___key_0; }
	inline void set_key_0(String_t* value)
	{
		___key_0 = value;
		Il2CppCodeGenWriteBarrier((&___key_0), value);
	}

	inline static int32_t get_offset_of_value_1() { return static_cast<int32_t>(offsetof(KeyValuePair_2_t9E20856DB65BAC258C27F3C359C8A86E2DCEEBBD, ___value_1)); }
	inline List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * get_value_1() const { return ___value_1; }
	inline List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 ** get_address_of_value_1() { return &___value_1; }
	inline void set_value_1(List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * value)
	{
		___value_1 = value;
		Il2CppCodeGenWriteBarrier((&___value_1), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // KEYVALUEPAIR_2_T9E20856DB65BAC258C27F3C359C8A86E2DCEEBBD_H
#ifndef ENUMERATOR_TB5FE7F21928FA8D45CBB7BD3D57A481548319510_H
#define ENUMERATOR_TB5FE7F21928FA8D45CBB7BD3D57A481548319510_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.List`1_Enumerator<Mono.Data.Sqlite.SqliteFunctionAttribute>
struct  Enumerator_tB5FE7F21928FA8D45CBB7BD3D57A481548319510 
{
public:
	// System.Collections.Generic.List`1<T> System.Collections.Generic.List`1_Enumerator::list
	List_1_t575BD1306846C6646814C99C87872FD64E8954AB * ___list_0;
	// System.Int32 System.Collections.Generic.List`1_Enumerator::index
	int32_t ___index_1;
	// System.Int32 System.Collections.Generic.List`1_Enumerator::version
	int32_t ___version_2;
	// T System.Collections.Generic.List`1_Enumerator::current
	SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD * ___current_3;

public:
	inline static int32_t get_offset_of_list_0() { return static_cast<int32_t>(offsetof(Enumerator_tB5FE7F21928FA8D45CBB7BD3D57A481548319510, ___list_0)); }
	inline List_1_t575BD1306846C6646814C99C87872FD64E8954AB * get_list_0() const { return ___list_0; }
	inline List_1_t575BD1306846C6646814C99C87872FD64E8954AB ** get_address_of_list_0() { return &___list_0; }
	inline void set_list_0(List_1_t575BD1306846C6646814C99C87872FD64E8954AB * value)
	{
		___list_0 = value;
		Il2CppCodeGenWriteBarrier((&___list_0), value);
	}

	inline static int32_t get_offset_of_index_1() { return static_cast<int32_t>(offsetof(Enumerator_tB5FE7F21928FA8D45CBB7BD3D57A481548319510, ___index_1)); }
	inline int32_t get_index_1() const { return ___index_1; }
	inline int32_t* get_address_of_index_1() { return &___index_1; }
	inline void set_index_1(int32_t value)
	{
		___index_1 = value;
	}

	inline static int32_t get_offset_of_version_2() { return static_cast<int32_t>(offsetof(Enumerator_tB5FE7F21928FA8D45CBB7BD3D57A481548319510, ___version_2)); }
	inline int32_t get_version_2() const { return ___version_2; }
	inline int32_t* get_address_of_version_2() { return &___version_2; }
	inline void set_version_2(int32_t value)
	{
		___version_2 = value;
	}

	inline static int32_t get_offset_of_current_3() { return static_cast<int32_t>(offsetof(Enumerator_tB5FE7F21928FA8D45CBB7BD3D57A481548319510, ___current_3)); }
	inline SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD * get_current_3() const { return ___current_3; }
	inline SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD ** get_address_of_current_3() { return &___current_3; }
	inline void set_current_3(SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD * value)
	{
		___current_3 = value;
		Il2CppCodeGenWriteBarrier((&___current_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ENUMERATOR_TB5FE7F21928FA8D45CBB7BD3D57A481548319510_H
#ifndef ENUMERATOR_TA18C55D69C7008726BD92603BF88561F27BB708A_H
#define ENUMERATOR_TA18C55D69C7008726BD92603BF88561F27BB708A_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.List`1_Enumerator<Mono.Data.Sqlite.SqliteParameter>
struct  Enumerator_tA18C55D69C7008726BD92603BF88561F27BB708A 
{
public:
	// System.Collections.Generic.List`1<T> System.Collections.Generic.List`1_Enumerator::list
	List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * ___list_0;
	// System.Int32 System.Collections.Generic.List`1_Enumerator::index
	int32_t ___index_1;
	// System.Int32 System.Collections.Generic.List`1_Enumerator::version
	int32_t ___version_2;
	// T System.Collections.Generic.List`1_Enumerator::current
	SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * ___current_3;

public:
	inline static int32_t get_offset_of_list_0() { return static_cast<int32_t>(offsetof(Enumerator_tA18C55D69C7008726BD92603BF88561F27BB708A, ___list_0)); }
	inline List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * get_list_0() const { return ___list_0; }
	inline List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 ** get_address_of_list_0() { return &___list_0; }
	inline void set_list_0(List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * value)
	{
		___list_0 = value;
		Il2CppCodeGenWriteBarrier((&___list_0), value);
	}

	inline static int32_t get_offset_of_index_1() { return static_cast<int32_t>(offsetof(Enumerator_tA18C55D69C7008726BD92603BF88561F27BB708A, ___index_1)); }
	inline int32_t get_index_1() const { return ___index_1; }
	inline int32_t* get_address_of_index_1() { return &___index_1; }
	inline void set_index_1(int32_t value)
	{
		___index_1 = value;
	}

	inline static int32_t get_offset_of_version_2() { return static_cast<int32_t>(offsetof(Enumerator_tA18C55D69C7008726BD92603BF88561F27BB708A, ___version_2)); }
	inline int32_t get_version_2() const { return ___version_2; }
	inline int32_t* get_address_of_version_2() { return &___version_2; }
	inline void set_version_2(int32_t value)
	{
		___version_2 = value;
	}

	inline static int32_t get_offset_of_current_3() { return static_cast<int32_t>(offsetof(Enumerator_tA18C55D69C7008726BD92603BF88561F27BB708A, ___current_3)); }
	inline SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * get_current_3() const { return ___current_3; }
	inline SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E ** get_address_of_current_3() { return &___current_3; }
	inline void set_current_3(SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * value)
	{
		___current_3 = value;
		Il2CppCodeGenWriteBarrier((&___current_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ENUMERATOR_TA18C55D69C7008726BD92603BF88561F27BB708A_H
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
#ifndef COMPONENT_T7AEFE153F6778CF52E1981BC3E811A9604B29473_H
#define COMPONENT_T7AEFE153F6778CF52E1981BC3E811A9604B29473_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ComponentModel.Component
struct  Component_t7AEFE153F6778CF52E1981BC3E811A9604B29473  : public MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF
{
public:
	// System.ComponentModel.ISite System.ComponentModel.Component::site
	RuntimeObject* ___site_2;
	// System.ComponentModel.EventHandlerList System.ComponentModel.Component::events
	EventHandlerList_tFE9EF79E85419EBB2C206CF475E29A9960699BE4 * ___events_3;

public:
	inline static int32_t get_offset_of_site_2() { return static_cast<int32_t>(offsetof(Component_t7AEFE153F6778CF52E1981BC3E811A9604B29473, ___site_2)); }
	inline RuntimeObject* get_site_2() const { return ___site_2; }
	inline RuntimeObject** get_address_of_site_2() { return &___site_2; }
	inline void set_site_2(RuntimeObject* value)
	{
		___site_2 = value;
		Il2CppCodeGenWriteBarrier((&___site_2), value);
	}

	inline static int32_t get_offset_of_events_3() { return static_cast<int32_t>(offsetof(Component_t7AEFE153F6778CF52E1981BC3E811A9604B29473, ___events_3)); }
	inline EventHandlerList_tFE9EF79E85419EBB2C206CF475E29A9960699BE4 * get_events_3() const { return ___events_3; }
	inline EventHandlerList_tFE9EF79E85419EBB2C206CF475E29A9960699BE4 ** get_address_of_events_3() { return &___events_3; }
	inline void set_events_3(EventHandlerList_tFE9EF79E85419EBB2C206CF475E29A9960699BE4 * value)
	{
		___events_3 = value;
		Il2CppCodeGenWriteBarrier((&___events_3), value);
	}
};

struct Component_t7AEFE153F6778CF52E1981BC3E811A9604B29473_StaticFields
{
public:
	// System.Object System.ComponentModel.Component::EventDisposed
	RuntimeObject * ___EventDisposed_1;

public:
	inline static int32_t get_offset_of_EventDisposed_1() { return static_cast<int32_t>(offsetof(Component_t7AEFE153F6778CF52E1981BC3E811A9604B29473_StaticFields, ___EventDisposed_1)); }
	inline RuntimeObject * get_EventDisposed_1() const { return ___EventDisposed_1; }
	inline RuntimeObject ** get_address_of_EventDisposed_1() { return &___EventDisposed_1; }
	inline void set_EventDisposed_1(RuntimeObject * value)
	{
		___EventDisposed_1 = value;
		Il2CppCodeGenWriteBarrier((&___EventDisposed_1), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // COMPONENT_T7AEFE153F6778CF52E1981BC3E811A9604B29473_H
#ifndef DBDATAREADER_T4CADA7880D6F85CABC4096FA5AE10C327A07CCD8_H
#define DBDATAREADER_T4CADA7880D6F85CABC4096FA5AE10C327A07CCD8_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Data.Common.DbDataReader
struct  DbDataReader_t4CADA7880D6F85CABC4096FA5AE10C327A07CCD8  : public MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // DBDATAREADER_T4CADA7880D6F85CABC4096FA5AE10C327A07CCD8_H
#ifndef DBPARAMETER_TEE5AEAD8B429B8EF8994063C151A25A76B94B76F_H
#define DBPARAMETER_TEE5AEAD8B429B8EF8994063C151A25A76B94B76F_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Data.Common.DbParameter
struct  DbParameter_tEE5AEAD8B429B8EF8994063C151A25A76B94B76F  : public MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // DBPARAMETER_TEE5AEAD8B429B8EF8994063C151A25A76B94B76F_H
#ifndef DBPARAMETERCOLLECTION_T6FF3670B12D04B797F09E79DFEA4CF93E92D249C_H
#define DBPARAMETERCOLLECTION_T6FF3670B12D04B797F09E79DFEA4CF93E92D249C_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Data.Common.DbParameterCollection
struct  DbParameterCollection_t6FF3670B12D04B797F09E79DFEA4CF93E92D249C  : public MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // DBPARAMETERCOLLECTION_T6FF3670B12D04B797F09E79DFEA4CF93E92D249C_H
#ifndef DBTRANSACTION_TADC1A857259448190F882AC47E0B18317779FE56_H
#define DBTRANSACTION_TADC1A857259448190F882AC47E0B18317779FE56_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Data.Common.DbTransaction
struct  DbTransaction_tADC1A857259448190F882AC47E0B18317779FE56  : public MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // DBTRANSACTION_TADC1A857259448190F882AC47E0B18317779FE56_H
#ifndef DATAROWCOLLECTION_T45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0_H
#define DATAROWCOLLECTION_T45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Data.DataRowCollection
struct  DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0  : public InternalDataCollectionBase_t8A94DFD07E59FFED7EE80E5F808509E3B2DA7334
{
public:
	// System.Data.DataTable System.Data.DataRowCollection::_table
	DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * ____table_1;
	// System.Data.DataRowCollection_DataRowTree System.Data.DataRowCollection::_list
	DataRowTree_t885C3CBC17060B726BFEE177710D6E9E57FEA230 * ____list_2;
	// System.Int32 System.Data.DataRowCollection::_nullInList
	int32_t ____nullInList_3;

public:
	inline static int32_t get_offset_of__table_1() { return static_cast<int32_t>(offsetof(DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0, ____table_1)); }
	inline DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * get__table_1() const { return ____table_1; }
	inline DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 ** get_address_of__table_1() { return &____table_1; }
	inline void set__table_1(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * value)
	{
		____table_1 = value;
		Il2CppCodeGenWriteBarrier((&____table_1), value);
	}

	inline static int32_t get_offset_of__list_2() { return static_cast<int32_t>(offsetof(DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0, ____list_2)); }
	inline DataRowTree_t885C3CBC17060B726BFEE177710D6E9E57FEA230 * get__list_2() const { return ____list_2; }
	inline DataRowTree_t885C3CBC17060B726BFEE177710D6E9E57FEA230 ** get_address_of__list_2() { return &____list_2; }
	inline void set__list_2(DataRowTree_t885C3CBC17060B726BFEE177710D6E9E57FEA230 * value)
	{
		____list_2 = value;
		Il2CppCodeGenWriteBarrier((&____list_2), value);
	}

	inline static int32_t get_offset_of__nullInList_3() { return static_cast<int32_t>(offsetof(DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0, ____nullInList_3)); }
	inline int32_t get__nullInList_3() const { return ____nullInList_3; }
	inline int32_t* get_address_of__nullInList_3() { return &____nullInList_3; }
	inline void set__nullInList_3(int32_t value)
	{
		____nullInList_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // DATAROWCOLLECTION_T45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0_H
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
#ifndef FIELDINFO_T_H
#define FIELDINFO_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Reflection.FieldInfo
struct  FieldInfo_t  : public MemberInfo_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // FIELDINFO_T_H
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
#ifndef U3CPRIVATEIMPLEMENTATIONDETAILSU3E_T0F71ABB0B2D76FF373FCA1CFC6711DBF4293313F_H
#define U3CPRIVATEIMPLEMENTATIONDETAILSU3E_T0F71ABB0B2D76FF373FCA1CFC6711DBF4293313F_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <PrivateImplementationDetails>
struct  U3CPrivateImplementationDetailsU3E_t0F71ABB0B2D76FF373FCA1CFC6711DBF4293313F  : public RuntimeObject
{
public:

public:
};

struct U3CPrivateImplementationDetailsU3E_t0F71ABB0B2D76FF373FCA1CFC6711DBF4293313F_StaticFields
{
public:
	// <PrivateImplementationDetails>_U24ArrayTypeU24104 <PrivateImplementationDetails>::U24U24fieldU2D0
	U24ArrayTypeU24104_t3338070C30A69BED9D16163FBBE9A7DB1E2C13D1  ___U24U24fieldU2D0_0;
	// <PrivateImplementationDetails>_U24ArrayTypeU248 <PrivateImplementationDetails>::U24U24fieldU2D1
	U24ArrayTypeU248_tB8F27E5643A76658911515F707FABEC752436459  ___U24U24fieldU2D1_1;

public:
	inline static int32_t get_offset_of_U24U24fieldU2D0_0() { return static_cast<int32_t>(offsetof(U3CPrivateImplementationDetailsU3E_t0F71ABB0B2D76FF373FCA1CFC6711DBF4293313F_StaticFields, ___U24U24fieldU2D0_0)); }
	inline U24ArrayTypeU24104_t3338070C30A69BED9D16163FBBE9A7DB1E2C13D1  get_U24U24fieldU2D0_0() const { return ___U24U24fieldU2D0_0; }
	inline U24ArrayTypeU24104_t3338070C30A69BED9D16163FBBE9A7DB1E2C13D1 * get_address_of_U24U24fieldU2D0_0() { return &___U24U24fieldU2D0_0; }
	inline void set_U24U24fieldU2D0_0(U24ArrayTypeU24104_t3338070C30A69BED9D16163FBBE9A7DB1E2C13D1  value)
	{
		___U24U24fieldU2D0_0 = value;
	}

	inline static int32_t get_offset_of_U24U24fieldU2D1_1() { return static_cast<int32_t>(offsetof(U3CPrivateImplementationDetailsU3E_t0F71ABB0B2D76FF373FCA1CFC6711DBF4293313F_StaticFields, ___U24U24fieldU2D1_1)); }
	inline U24ArrayTypeU248_tB8F27E5643A76658911515F707FABEC752436459  get_U24U24fieldU2D1_1() const { return ___U24U24fieldU2D1_1; }
	inline U24ArrayTypeU248_tB8F27E5643A76658911515F707FABEC752436459 * get_address_of_U24U24fieldU2D1_1() { return &___U24U24fieldU2D1_1; }
	inline void set_U24U24fieldU2D1_1(U24ArrayTypeU248_tB8F27E5643A76658911515F707FABEC752436459  value)
	{
		___U24U24fieldU2D1_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // U3CPRIVATEIMPLEMENTATIONDETAILSU3E_T0F71ABB0B2D76FF373FCA1CFC6711DBF4293313F_H
#ifndef FUNCTIONTYPE_TF0D0F0EFF3C72E24A4438DC981749BA373EE9FA7_H
#define FUNCTIONTYPE_TF0D0F0EFF3C72E24A4438DC981749BA373EE9FA7_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.FunctionType
struct  FunctionType_tF0D0F0EFF3C72E24A4438DC981749BA373EE9FA7 
{
public:
	// System.Int32 Mono.Data.Sqlite.FunctionType::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(FunctionType_tF0D0F0EFF3C72E24A4438DC981749BA373EE9FA7, ___value___2)); }
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
#endif // FUNCTIONTYPE_TF0D0F0EFF3C72E24A4438DC981749BA373EE9FA7_H
#ifndef SQLITEDATEFORMATS_T372D42A58E4FBC91FFDBD1A5A6435C63C02CFF1C_H
#define SQLITEDATEFORMATS_T372D42A58E4FBC91FFDBD1A5A6435C63C02CFF1C_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.SQLiteDateFormats
struct  SQLiteDateFormats_t372D42A58E4FBC91FFDBD1A5A6435C63C02CFF1C 
{
public:
	// System.Int32 Mono.Data.Sqlite.SQLiteDateFormats::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(SQLiteDateFormats_t372D42A58E4FBC91FFDBD1A5A6435C63C02CFF1C, ___value___2)); }
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
#endif // SQLITEDATEFORMATS_T372D42A58E4FBC91FFDBD1A5A6435C63C02CFF1C_H
#ifndef SQLITEERRORCODE_TF90D229C9CC45F112DC6489D32EDFB82F74D3ED8_H
#define SQLITEERRORCODE_TF90D229C9CC45F112DC6489D32EDFB82F74D3ED8_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.SQLiteErrorCode
struct  SQLiteErrorCode_tF90D229C9CC45F112DC6489D32EDFB82F74D3ED8 
{
public:
	// System.Int32 Mono.Data.Sqlite.SQLiteErrorCode::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(SQLiteErrorCode_tF90D229C9CC45F112DC6489D32EDFB82F74D3ED8, ___value___2)); }
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
#endif // SQLITEERRORCODE_TF90D229C9CC45F112DC6489D32EDFB82F74D3ED8_H
#ifndef SQLITEFUNCTION_TFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B_H
#define SQLITEFUNCTION_TFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.SqliteFunction
struct  SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B  : public RuntimeObject
{
public:
	// Mono.Data.Sqlite.SQLiteBase Mono.Data.Sqlite.SqliteFunction::_base
	SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * ____base_0;
	// System.Collections.Generic.Dictionary`2<System.Int64,Mono.Data.Sqlite.SqliteFunction_AggregateData> Mono.Data.Sqlite.SqliteFunction::_contextDataList
	Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 * ____contextDataList_1;
	// Mono.Data.Sqlite.SQLiteCallback Mono.Data.Sqlite.SqliteFunction::_InvokeFunc
	SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22 * ____InvokeFunc_2;
	// Mono.Data.Sqlite.SQLiteCallback Mono.Data.Sqlite.SqliteFunction::_StepFunc
	SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22 * ____StepFunc_3;
	// Mono.Data.Sqlite.SQLiteFinalCallback Mono.Data.Sqlite.SqliteFunction::_FinalFunc
	SQLiteFinalCallback_tDADE001E38D3B50F9259C9D956A11D3B4D875453 * ____FinalFunc_4;
	// Mono.Data.Sqlite.SQLiteCollation Mono.Data.Sqlite.SqliteFunction::_CompareFunc
	SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B * ____CompareFunc_5;
	// Mono.Data.Sqlite.SQLiteCollation Mono.Data.Sqlite.SqliteFunction::_CompareFunc16
	SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B * ____CompareFunc16_6;
	// System.IntPtr Mono.Data.Sqlite.SqliteFunction::_context
	intptr_t ____context_7;

public:
	inline static int32_t get_offset_of__base_0() { return static_cast<int32_t>(offsetof(SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B, ____base_0)); }
	inline SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * get__base_0() const { return ____base_0; }
	inline SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 ** get_address_of__base_0() { return &____base_0; }
	inline void set__base_0(SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * value)
	{
		____base_0 = value;
		Il2CppCodeGenWriteBarrier((&____base_0), value);
	}

	inline static int32_t get_offset_of__contextDataList_1() { return static_cast<int32_t>(offsetof(SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B, ____contextDataList_1)); }
	inline Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 * get__contextDataList_1() const { return ____contextDataList_1; }
	inline Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 ** get_address_of__contextDataList_1() { return &____contextDataList_1; }
	inline void set__contextDataList_1(Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 * value)
	{
		____contextDataList_1 = value;
		Il2CppCodeGenWriteBarrier((&____contextDataList_1), value);
	}

	inline static int32_t get_offset_of__InvokeFunc_2() { return static_cast<int32_t>(offsetof(SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B, ____InvokeFunc_2)); }
	inline SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22 * get__InvokeFunc_2() const { return ____InvokeFunc_2; }
	inline SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22 ** get_address_of__InvokeFunc_2() { return &____InvokeFunc_2; }
	inline void set__InvokeFunc_2(SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22 * value)
	{
		____InvokeFunc_2 = value;
		Il2CppCodeGenWriteBarrier((&____InvokeFunc_2), value);
	}

	inline static int32_t get_offset_of__StepFunc_3() { return static_cast<int32_t>(offsetof(SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B, ____StepFunc_3)); }
	inline SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22 * get__StepFunc_3() const { return ____StepFunc_3; }
	inline SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22 ** get_address_of__StepFunc_3() { return &____StepFunc_3; }
	inline void set__StepFunc_3(SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22 * value)
	{
		____StepFunc_3 = value;
		Il2CppCodeGenWriteBarrier((&____StepFunc_3), value);
	}

	inline static int32_t get_offset_of__FinalFunc_4() { return static_cast<int32_t>(offsetof(SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B, ____FinalFunc_4)); }
	inline SQLiteFinalCallback_tDADE001E38D3B50F9259C9D956A11D3B4D875453 * get__FinalFunc_4() const { return ____FinalFunc_4; }
	inline SQLiteFinalCallback_tDADE001E38D3B50F9259C9D956A11D3B4D875453 ** get_address_of__FinalFunc_4() { return &____FinalFunc_4; }
	inline void set__FinalFunc_4(SQLiteFinalCallback_tDADE001E38D3B50F9259C9D956A11D3B4D875453 * value)
	{
		____FinalFunc_4 = value;
		Il2CppCodeGenWriteBarrier((&____FinalFunc_4), value);
	}

	inline static int32_t get_offset_of__CompareFunc_5() { return static_cast<int32_t>(offsetof(SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B, ____CompareFunc_5)); }
	inline SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B * get__CompareFunc_5() const { return ____CompareFunc_5; }
	inline SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B ** get_address_of__CompareFunc_5() { return &____CompareFunc_5; }
	inline void set__CompareFunc_5(SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B * value)
	{
		____CompareFunc_5 = value;
		Il2CppCodeGenWriteBarrier((&____CompareFunc_5), value);
	}

	inline static int32_t get_offset_of__CompareFunc16_6() { return static_cast<int32_t>(offsetof(SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B, ____CompareFunc16_6)); }
	inline SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B * get__CompareFunc16_6() const { return ____CompareFunc16_6; }
	inline SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B ** get_address_of__CompareFunc16_6() { return &____CompareFunc16_6; }
	inline void set__CompareFunc16_6(SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B * value)
	{
		____CompareFunc16_6 = value;
		Il2CppCodeGenWriteBarrier((&____CompareFunc16_6), value);
	}

	inline static int32_t get_offset_of__context_7() { return static_cast<int32_t>(offsetof(SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B, ____context_7)); }
	inline intptr_t get__context_7() const { return ____context_7; }
	inline intptr_t* get_address_of__context_7() { return &____context_7; }
	inline void set__context_7(intptr_t value)
	{
		____context_7 = value;
	}
};

struct SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B_StaticFields
{
public:
	// System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteFunctionAttribute> Mono.Data.Sqlite.SqliteFunction::_registeredFunctions
	List_1_t575BD1306846C6646814C99C87872FD64E8954AB * ____registeredFunctions_8;

public:
	inline static int32_t get_offset_of__registeredFunctions_8() { return static_cast<int32_t>(offsetof(SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B_StaticFields, ____registeredFunctions_8)); }
	inline List_1_t575BD1306846C6646814C99C87872FD64E8954AB * get__registeredFunctions_8() const { return ____registeredFunctions_8; }
	inline List_1_t575BD1306846C6646814C99C87872FD64E8954AB ** get_address_of__registeredFunctions_8() { return &____registeredFunctions_8; }
	inline void set__registeredFunctions_8(List_1_t575BD1306846C6646814C99C87872FD64E8954AB * value)
	{
		____registeredFunctions_8 = value;
		Il2CppCodeGenWriteBarrier((&____registeredFunctions_8), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SQLITEFUNCTION_TFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B_H
#ifndef SQLITEPARAMETERCOLLECTION_TD518FC7690200D12DA3B779429941F988301B523_H
#define SQLITEPARAMETERCOLLECTION_TD518FC7690200D12DA3B779429941F988301B523_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.SqliteParameterCollection
struct  SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523  : public DbParameterCollection_t6FF3670B12D04B797F09E79DFEA4CF93E92D249C
{
public:
	// Mono.Data.Sqlite.SqliteCommand Mono.Data.Sqlite.SqliteParameterCollection::_command
	SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * ____command_1;
	// System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteParameter> Mono.Data.Sqlite.SqliteParameterCollection::_parameterList
	List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * ____parameterList_2;
	// System.Boolean Mono.Data.Sqlite.SqliteParameterCollection::_unboundFlag
	bool ____unboundFlag_3;

public:
	inline static int32_t get_offset_of__command_1() { return static_cast<int32_t>(offsetof(SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523, ____command_1)); }
	inline SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * get__command_1() const { return ____command_1; }
	inline SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 ** get_address_of__command_1() { return &____command_1; }
	inline void set__command_1(SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * value)
	{
		____command_1 = value;
		Il2CppCodeGenWriteBarrier((&____command_1), value);
	}

	inline static int32_t get_offset_of__parameterList_2() { return static_cast<int32_t>(offsetof(SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523, ____parameterList_2)); }
	inline List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * get__parameterList_2() const { return ____parameterList_2; }
	inline List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 ** get_address_of__parameterList_2() { return &____parameterList_2; }
	inline void set__parameterList_2(List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * value)
	{
		____parameterList_2 = value;
		Il2CppCodeGenWriteBarrier((&____parameterList_2), value);
	}

	inline static int32_t get_offset_of__unboundFlag_3() { return static_cast<int32_t>(offsetof(SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523, ____unboundFlag_3)); }
	inline bool get__unboundFlag_3() const { return ____unboundFlag_3; }
	inline bool* get_address_of__unboundFlag_3() { return &____unboundFlag_3; }
	inline void set__unboundFlag_3(bool value)
	{
		____unboundFlag_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SQLITEPARAMETERCOLLECTION_TD518FC7690200D12DA3B779429941F988301B523_H
#ifndef TYPEAFFINITY_TB1C66F6E6CA7CA2DA37D0BD309D29A58F68FF7CE_H
#define TYPEAFFINITY_TB1C66F6E6CA7CA2DA37D0BD309D29A58F68FF7CE_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.TypeAffinity
struct  TypeAffinity_tB1C66F6E6CA7CA2DA37D0BD309D29A58F68FF7CE 
{
public:
	// System.Int32 Mono.Data.Sqlite.TypeAffinity::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(TypeAffinity_tB1C66F6E6CA7CA2DA37D0BD309D29A58F68FF7CE, ___value___2)); }
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
#endif // TYPEAFFINITY_TB1C66F6E6CA7CA2DA37D0BD309D29A58F68FF7CE_H
#ifndef APPDOMAIN_T1B59572328F60585904DF52A59FE47CF5B5FFFF8_H
#define APPDOMAIN_T1B59572328F60585904DF52A59FE47CF5B5FFFF8_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.AppDomain
struct  AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8  : public MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF
{
public:
	// System.IntPtr System.AppDomain::_mono_app_domain
	intptr_t ____mono_app_domain_1;
	// System.Object System.AppDomain::_evidence
	RuntimeObject * ____evidence_6;
	// System.Object System.AppDomain::_granted
	RuntimeObject * ____granted_7;
	// System.Int32 System.AppDomain::_principalPolicy
	int32_t ____principalPolicy_8;
	// System.AssemblyLoadEventHandler System.AppDomain::AssemblyLoad
	AssemblyLoadEventHandler_t53F8340027F9EE67E8A22E7D8C1A3770345153C9 * ___AssemblyLoad_11;
	// System.ResolveEventHandler System.AppDomain::AssemblyResolve
	ResolveEventHandler_t045C469BEA8B632FA99FE8867C921BA8DAE0BEE5 * ___AssemblyResolve_12;
	// System.EventHandler System.AppDomain::DomainUnload
	EventHandler_t2B84E745E28BA26C49C4E99A387FC3B534D1110C * ___DomainUnload_13;
	// System.EventHandler System.AppDomain::ProcessExit
	EventHandler_t2B84E745E28BA26C49C4E99A387FC3B534D1110C * ___ProcessExit_14;
	// System.ResolveEventHandler System.AppDomain::ResourceResolve
	ResolveEventHandler_t045C469BEA8B632FA99FE8867C921BA8DAE0BEE5 * ___ResourceResolve_15;
	// System.ResolveEventHandler System.AppDomain::TypeResolve
	ResolveEventHandler_t045C469BEA8B632FA99FE8867C921BA8DAE0BEE5 * ___TypeResolve_16;
	// System.UnhandledExceptionEventHandler System.AppDomain::UnhandledException
	UnhandledExceptionEventHandler_tB0DFF05ABF7A3A234C87D4F7A71F98E9AB2D91DE * ___UnhandledException_17;
	// System.EventHandler`1<System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs> System.AppDomain::FirstChanceException
	EventHandler_1_t1E35ED2E29145994C6C03E57601C6D48C61083FF * ___FirstChanceException_18;
	// System.Object System.AppDomain::_domain_manager
	RuntimeObject * ____domain_manager_19;
	// System.ResolveEventHandler System.AppDomain::ReflectionOnlyAssemblyResolve
	ResolveEventHandler_t045C469BEA8B632FA99FE8867C921BA8DAE0BEE5 * ___ReflectionOnlyAssemblyResolve_20;
	// System.Object System.AppDomain::_activation
	RuntimeObject * ____activation_21;
	// System.Object System.AppDomain::_applicationIdentity
	RuntimeObject * ____applicationIdentity_22;
	// System.Collections.Generic.List`1<System.String> System.AppDomain::compatibility_switch
	List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * ___compatibility_switch_23;

public:
	inline static int32_t get_offset_of__mono_app_domain_1() { return static_cast<int32_t>(offsetof(AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8, ____mono_app_domain_1)); }
	inline intptr_t get__mono_app_domain_1() const { return ____mono_app_domain_1; }
	inline intptr_t* get_address_of__mono_app_domain_1() { return &____mono_app_domain_1; }
	inline void set__mono_app_domain_1(intptr_t value)
	{
		____mono_app_domain_1 = value;
	}

	inline static int32_t get_offset_of__evidence_6() { return static_cast<int32_t>(offsetof(AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8, ____evidence_6)); }
	inline RuntimeObject * get__evidence_6() const { return ____evidence_6; }
	inline RuntimeObject ** get_address_of__evidence_6() { return &____evidence_6; }
	inline void set__evidence_6(RuntimeObject * value)
	{
		____evidence_6 = value;
		Il2CppCodeGenWriteBarrier((&____evidence_6), value);
	}

	inline static int32_t get_offset_of__granted_7() { return static_cast<int32_t>(offsetof(AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8, ____granted_7)); }
	inline RuntimeObject * get__granted_7() const { return ____granted_7; }
	inline RuntimeObject ** get_address_of__granted_7() { return &____granted_7; }
	inline void set__granted_7(RuntimeObject * value)
	{
		____granted_7 = value;
		Il2CppCodeGenWriteBarrier((&____granted_7), value);
	}

	inline static int32_t get_offset_of__principalPolicy_8() { return static_cast<int32_t>(offsetof(AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8, ____principalPolicy_8)); }
	inline int32_t get__principalPolicy_8() const { return ____principalPolicy_8; }
	inline int32_t* get_address_of__principalPolicy_8() { return &____principalPolicy_8; }
	inline void set__principalPolicy_8(int32_t value)
	{
		____principalPolicy_8 = value;
	}

	inline static int32_t get_offset_of_AssemblyLoad_11() { return static_cast<int32_t>(offsetof(AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8, ___AssemblyLoad_11)); }
	inline AssemblyLoadEventHandler_t53F8340027F9EE67E8A22E7D8C1A3770345153C9 * get_AssemblyLoad_11() const { return ___AssemblyLoad_11; }
	inline AssemblyLoadEventHandler_t53F8340027F9EE67E8A22E7D8C1A3770345153C9 ** get_address_of_AssemblyLoad_11() { return &___AssemblyLoad_11; }
	inline void set_AssemblyLoad_11(AssemblyLoadEventHandler_t53F8340027F9EE67E8A22E7D8C1A3770345153C9 * value)
	{
		___AssemblyLoad_11 = value;
		Il2CppCodeGenWriteBarrier((&___AssemblyLoad_11), value);
	}

	inline static int32_t get_offset_of_AssemblyResolve_12() { return static_cast<int32_t>(offsetof(AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8, ___AssemblyResolve_12)); }
	inline ResolveEventHandler_t045C469BEA8B632FA99FE8867C921BA8DAE0BEE5 * get_AssemblyResolve_12() const { return ___AssemblyResolve_12; }
	inline ResolveEventHandler_t045C469BEA8B632FA99FE8867C921BA8DAE0BEE5 ** get_address_of_AssemblyResolve_12() { return &___AssemblyResolve_12; }
	inline void set_AssemblyResolve_12(ResolveEventHandler_t045C469BEA8B632FA99FE8867C921BA8DAE0BEE5 * value)
	{
		___AssemblyResolve_12 = value;
		Il2CppCodeGenWriteBarrier((&___AssemblyResolve_12), value);
	}

	inline static int32_t get_offset_of_DomainUnload_13() { return static_cast<int32_t>(offsetof(AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8, ___DomainUnload_13)); }
	inline EventHandler_t2B84E745E28BA26C49C4E99A387FC3B534D1110C * get_DomainUnload_13() const { return ___DomainUnload_13; }
	inline EventHandler_t2B84E745E28BA26C49C4E99A387FC3B534D1110C ** get_address_of_DomainUnload_13() { return &___DomainUnload_13; }
	inline void set_DomainUnload_13(EventHandler_t2B84E745E28BA26C49C4E99A387FC3B534D1110C * value)
	{
		___DomainUnload_13 = value;
		Il2CppCodeGenWriteBarrier((&___DomainUnload_13), value);
	}

	inline static int32_t get_offset_of_ProcessExit_14() { return static_cast<int32_t>(offsetof(AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8, ___ProcessExit_14)); }
	inline EventHandler_t2B84E745E28BA26C49C4E99A387FC3B534D1110C * get_ProcessExit_14() const { return ___ProcessExit_14; }
	inline EventHandler_t2B84E745E28BA26C49C4E99A387FC3B534D1110C ** get_address_of_ProcessExit_14() { return &___ProcessExit_14; }
	inline void set_ProcessExit_14(EventHandler_t2B84E745E28BA26C49C4E99A387FC3B534D1110C * value)
	{
		___ProcessExit_14 = value;
		Il2CppCodeGenWriteBarrier((&___ProcessExit_14), value);
	}

	inline static int32_t get_offset_of_ResourceResolve_15() { return static_cast<int32_t>(offsetof(AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8, ___ResourceResolve_15)); }
	inline ResolveEventHandler_t045C469BEA8B632FA99FE8867C921BA8DAE0BEE5 * get_ResourceResolve_15() const { return ___ResourceResolve_15; }
	inline ResolveEventHandler_t045C469BEA8B632FA99FE8867C921BA8DAE0BEE5 ** get_address_of_ResourceResolve_15() { return &___ResourceResolve_15; }
	inline void set_ResourceResolve_15(ResolveEventHandler_t045C469BEA8B632FA99FE8867C921BA8DAE0BEE5 * value)
	{
		___ResourceResolve_15 = value;
		Il2CppCodeGenWriteBarrier((&___ResourceResolve_15), value);
	}

	inline static int32_t get_offset_of_TypeResolve_16() { return static_cast<int32_t>(offsetof(AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8, ___TypeResolve_16)); }
	inline ResolveEventHandler_t045C469BEA8B632FA99FE8867C921BA8DAE0BEE5 * get_TypeResolve_16() const { return ___TypeResolve_16; }
	inline ResolveEventHandler_t045C469BEA8B632FA99FE8867C921BA8DAE0BEE5 ** get_address_of_TypeResolve_16() { return &___TypeResolve_16; }
	inline void set_TypeResolve_16(ResolveEventHandler_t045C469BEA8B632FA99FE8867C921BA8DAE0BEE5 * value)
	{
		___TypeResolve_16 = value;
		Il2CppCodeGenWriteBarrier((&___TypeResolve_16), value);
	}

	inline static int32_t get_offset_of_UnhandledException_17() { return static_cast<int32_t>(offsetof(AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8, ___UnhandledException_17)); }
	inline UnhandledExceptionEventHandler_tB0DFF05ABF7A3A234C87D4F7A71F98E9AB2D91DE * get_UnhandledException_17() const { return ___UnhandledException_17; }
	inline UnhandledExceptionEventHandler_tB0DFF05ABF7A3A234C87D4F7A71F98E9AB2D91DE ** get_address_of_UnhandledException_17() { return &___UnhandledException_17; }
	inline void set_UnhandledException_17(UnhandledExceptionEventHandler_tB0DFF05ABF7A3A234C87D4F7A71F98E9AB2D91DE * value)
	{
		___UnhandledException_17 = value;
		Il2CppCodeGenWriteBarrier((&___UnhandledException_17), value);
	}

	inline static int32_t get_offset_of_FirstChanceException_18() { return static_cast<int32_t>(offsetof(AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8, ___FirstChanceException_18)); }
	inline EventHandler_1_t1E35ED2E29145994C6C03E57601C6D48C61083FF * get_FirstChanceException_18() const { return ___FirstChanceException_18; }
	inline EventHandler_1_t1E35ED2E29145994C6C03E57601C6D48C61083FF ** get_address_of_FirstChanceException_18() { return &___FirstChanceException_18; }
	inline void set_FirstChanceException_18(EventHandler_1_t1E35ED2E29145994C6C03E57601C6D48C61083FF * value)
	{
		___FirstChanceException_18 = value;
		Il2CppCodeGenWriteBarrier((&___FirstChanceException_18), value);
	}

	inline static int32_t get_offset_of__domain_manager_19() { return static_cast<int32_t>(offsetof(AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8, ____domain_manager_19)); }
	inline RuntimeObject * get__domain_manager_19() const { return ____domain_manager_19; }
	inline RuntimeObject ** get_address_of__domain_manager_19() { return &____domain_manager_19; }
	inline void set__domain_manager_19(RuntimeObject * value)
	{
		____domain_manager_19 = value;
		Il2CppCodeGenWriteBarrier((&____domain_manager_19), value);
	}

	inline static int32_t get_offset_of_ReflectionOnlyAssemblyResolve_20() { return static_cast<int32_t>(offsetof(AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8, ___ReflectionOnlyAssemblyResolve_20)); }
	inline ResolveEventHandler_t045C469BEA8B632FA99FE8867C921BA8DAE0BEE5 * get_ReflectionOnlyAssemblyResolve_20() const { return ___ReflectionOnlyAssemblyResolve_20; }
	inline ResolveEventHandler_t045C469BEA8B632FA99FE8867C921BA8DAE0BEE5 ** get_address_of_ReflectionOnlyAssemblyResolve_20() { return &___ReflectionOnlyAssemblyResolve_20; }
	inline void set_ReflectionOnlyAssemblyResolve_20(ResolveEventHandler_t045C469BEA8B632FA99FE8867C921BA8DAE0BEE5 * value)
	{
		___ReflectionOnlyAssemblyResolve_20 = value;
		Il2CppCodeGenWriteBarrier((&___ReflectionOnlyAssemblyResolve_20), value);
	}

	inline static int32_t get_offset_of__activation_21() { return static_cast<int32_t>(offsetof(AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8, ____activation_21)); }
	inline RuntimeObject * get__activation_21() const { return ____activation_21; }
	inline RuntimeObject ** get_address_of__activation_21() { return &____activation_21; }
	inline void set__activation_21(RuntimeObject * value)
	{
		____activation_21 = value;
		Il2CppCodeGenWriteBarrier((&____activation_21), value);
	}

	inline static int32_t get_offset_of__applicationIdentity_22() { return static_cast<int32_t>(offsetof(AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8, ____applicationIdentity_22)); }
	inline RuntimeObject * get__applicationIdentity_22() const { return ____applicationIdentity_22; }
	inline RuntimeObject ** get_address_of__applicationIdentity_22() { return &____applicationIdentity_22; }
	inline void set__applicationIdentity_22(RuntimeObject * value)
	{
		____applicationIdentity_22 = value;
		Il2CppCodeGenWriteBarrier((&____applicationIdentity_22), value);
	}

	inline static int32_t get_offset_of_compatibility_switch_23() { return static_cast<int32_t>(offsetof(AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8, ___compatibility_switch_23)); }
	inline List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * get_compatibility_switch_23() const { return ___compatibility_switch_23; }
	inline List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 ** get_address_of_compatibility_switch_23() { return &___compatibility_switch_23; }
	inline void set_compatibility_switch_23(List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * value)
	{
		___compatibility_switch_23 = value;
		Il2CppCodeGenWriteBarrier((&___compatibility_switch_23), value);
	}
};

struct AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8_StaticFields
{
public:
	// System.String System.AppDomain::_process_guid
	String_t* ____process_guid_2;
	// System.AppDomain System.AppDomain::default_domain
	AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8 * ___default_domain_10;

public:
	inline static int32_t get_offset_of__process_guid_2() { return static_cast<int32_t>(offsetof(AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8_StaticFields, ____process_guid_2)); }
	inline String_t* get__process_guid_2() const { return ____process_guid_2; }
	inline String_t** get_address_of__process_guid_2() { return &____process_guid_2; }
	inline void set__process_guid_2(String_t* value)
	{
		____process_guid_2 = value;
		Il2CppCodeGenWriteBarrier((&____process_guid_2), value);
	}

	inline static int32_t get_offset_of_default_domain_10() { return static_cast<int32_t>(offsetof(AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8_StaticFields, ___default_domain_10)); }
	inline AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8 * get_default_domain_10() const { return ___default_domain_10; }
	inline AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8 ** get_address_of_default_domain_10() { return &___default_domain_10; }
	inline void set_default_domain_10(AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8 * value)
	{
		___default_domain_10 = value;
		Il2CppCodeGenWriteBarrier((&___default_domain_10), value);
	}
};

struct AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8_ThreadStaticFields
{
public:
	// System.Collections.Generic.Dictionary`2<System.String,System.Object> System.AppDomain::type_resolve_in_progress
	Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * ___type_resolve_in_progress_3;
	// System.Collections.Generic.Dictionary`2<System.String,System.Object> System.AppDomain::assembly_resolve_in_progress
	Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * ___assembly_resolve_in_progress_4;
	// System.Collections.Generic.Dictionary`2<System.String,System.Object> System.AppDomain::assembly_resolve_in_progress_refonly
	Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * ___assembly_resolve_in_progress_refonly_5;
	// System.Object System.AppDomain::_principal
	RuntimeObject * ____principal_9;

public:
	inline static int32_t get_offset_of_type_resolve_in_progress_3() { return static_cast<int32_t>(offsetof(AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8_ThreadStaticFields, ___type_resolve_in_progress_3)); }
	inline Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * get_type_resolve_in_progress_3() const { return ___type_resolve_in_progress_3; }
	inline Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA ** get_address_of_type_resolve_in_progress_3() { return &___type_resolve_in_progress_3; }
	inline void set_type_resolve_in_progress_3(Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * value)
	{
		___type_resolve_in_progress_3 = value;
		Il2CppCodeGenWriteBarrier((&___type_resolve_in_progress_3), value);
	}

	inline static int32_t get_offset_of_assembly_resolve_in_progress_4() { return static_cast<int32_t>(offsetof(AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8_ThreadStaticFields, ___assembly_resolve_in_progress_4)); }
	inline Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * get_assembly_resolve_in_progress_4() const { return ___assembly_resolve_in_progress_4; }
	inline Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA ** get_address_of_assembly_resolve_in_progress_4() { return &___assembly_resolve_in_progress_4; }
	inline void set_assembly_resolve_in_progress_4(Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * value)
	{
		___assembly_resolve_in_progress_4 = value;
		Il2CppCodeGenWriteBarrier((&___assembly_resolve_in_progress_4), value);
	}

	inline static int32_t get_offset_of_assembly_resolve_in_progress_refonly_5() { return static_cast<int32_t>(offsetof(AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8_ThreadStaticFields, ___assembly_resolve_in_progress_refonly_5)); }
	inline Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * get_assembly_resolve_in_progress_refonly_5() const { return ___assembly_resolve_in_progress_refonly_5; }
	inline Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA ** get_address_of_assembly_resolve_in_progress_refonly_5() { return &___assembly_resolve_in_progress_refonly_5; }
	inline void set_assembly_resolve_in_progress_refonly_5(Dictionary_2_t9140A71329927AE4FD0F3CF4D4D66668EBE151EA * value)
	{
		___assembly_resolve_in_progress_refonly_5 = value;
		Il2CppCodeGenWriteBarrier((&___assembly_resolve_in_progress_refonly_5), value);
	}

	inline static int32_t get_offset_of__principal_9() { return static_cast<int32_t>(offsetof(AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8_ThreadStaticFields, ____principal_9)); }
	inline RuntimeObject * get__principal_9() const { return ____principal_9; }
	inline RuntimeObject ** get_address_of__principal_9() { return &____principal_9; }
	inline void set__principal_9(RuntimeObject * value)
	{
		____principal_9 = value;
		Il2CppCodeGenWriteBarrier((&____principal_9), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.AppDomain
struct AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8_marshaled_pinvoke : public MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF_marshaled_pinvoke
{
	intptr_t ____mono_app_domain_1;
	Il2CppIUnknown* ____evidence_6;
	Il2CppIUnknown* ____granted_7;
	int32_t ____principalPolicy_8;
	Il2CppMethodPointer ___AssemblyLoad_11;
	Il2CppMethodPointer ___AssemblyResolve_12;
	Il2CppMethodPointer ___DomainUnload_13;
	Il2CppMethodPointer ___ProcessExit_14;
	Il2CppMethodPointer ___ResourceResolve_15;
	Il2CppMethodPointer ___TypeResolve_16;
	Il2CppMethodPointer ___UnhandledException_17;
	Il2CppMethodPointer ___FirstChanceException_18;
	Il2CppIUnknown* ____domain_manager_19;
	Il2CppMethodPointer ___ReflectionOnlyAssemblyResolve_20;
	Il2CppIUnknown* ____activation_21;
	Il2CppIUnknown* ____applicationIdentity_22;
	List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * ___compatibility_switch_23;
};
// Native definition for COM marshalling of System.AppDomain
struct AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8_marshaled_com : public MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF_marshaled_com
{
	intptr_t ____mono_app_domain_1;
	Il2CppIUnknown* ____evidence_6;
	Il2CppIUnknown* ____granted_7;
	int32_t ____principalPolicy_8;
	Il2CppMethodPointer ___AssemblyLoad_11;
	Il2CppMethodPointer ___AssemblyResolve_12;
	Il2CppMethodPointer ___DomainUnload_13;
	Il2CppMethodPointer ___ProcessExit_14;
	Il2CppMethodPointer ___ResourceResolve_15;
	Il2CppMethodPointer ___TypeResolve_16;
	Il2CppMethodPointer ___UnhandledException_17;
	Il2CppMethodPointer ___FirstChanceException_18;
	Il2CppIUnknown* ____domain_manager_19;
	Il2CppMethodPointer ___ReflectionOnlyAssemblyResolve_20;
	Il2CppIUnknown* ____activation_21;
	Il2CppIUnknown* ____applicationIdentity_22;
	List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * ___compatibility_switch_23;
};
#endif // APPDOMAIN_T1B59572328F60585904DF52A59FE47CF5B5FFFF8_H
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
#ifndef ENUMERATOR_TC72BD0EE9002D5F9476F8E5D172DD8D523493303_H
#define ENUMERATOR_TC72BD0EE9002D5F9476F8E5D172DD8D523493303_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.Dictionary`2_Enumerator<System.Int64,Mono.Data.Sqlite.SqliteFunction_AggregateData>
struct  Enumerator_tC72BD0EE9002D5F9476F8E5D172DD8D523493303 
{
public:
	// System.Collections.Generic.Dictionary`2<TKey,TValue> System.Collections.Generic.Dictionary`2_Enumerator::dictionary
	Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 * ___dictionary_0;
	// System.Int32 System.Collections.Generic.Dictionary`2_Enumerator::version
	int32_t ___version_1;
	// System.Int32 System.Collections.Generic.Dictionary`2_Enumerator::index
	int32_t ___index_2;
	// System.Collections.Generic.KeyValuePair`2<TKey,TValue> System.Collections.Generic.Dictionary`2_Enumerator::current
	KeyValuePair_2_t93C466ABB3C1789B9638D6DAE171650D781D5955  ___current_3;
	// System.Int32 System.Collections.Generic.Dictionary`2_Enumerator::getEnumeratorRetType
	int32_t ___getEnumeratorRetType_4;

public:
	inline static int32_t get_offset_of_dictionary_0() { return static_cast<int32_t>(offsetof(Enumerator_tC72BD0EE9002D5F9476F8E5D172DD8D523493303, ___dictionary_0)); }
	inline Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 * get_dictionary_0() const { return ___dictionary_0; }
	inline Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 ** get_address_of_dictionary_0() { return &___dictionary_0; }
	inline void set_dictionary_0(Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 * value)
	{
		___dictionary_0 = value;
		Il2CppCodeGenWriteBarrier((&___dictionary_0), value);
	}

	inline static int32_t get_offset_of_version_1() { return static_cast<int32_t>(offsetof(Enumerator_tC72BD0EE9002D5F9476F8E5D172DD8D523493303, ___version_1)); }
	inline int32_t get_version_1() const { return ___version_1; }
	inline int32_t* get_address_of_version_1() { return &___version_1; }
	inline void set_version_1(int32_t value)
	{
		___version_1 = value;
	}

	inline static int32_t get_offset_of_index_2() { return static_cast<int32_t>(offsetof(Enumerator_tC72BD0EE9002D5F9476F8E5D172DD8D523493303, ___index_2)); }
	inline int32_t get_index_2() const { return ___index_2; }
	inline int32_t* get_address_of_index_2() { return &___index_2; }
	inline void set_index_2(int32_t value)
	{
		___index_2 = value;
	}

	inline static int32_t get_offset_of_current_3() { return static_cast<int32_t>(offsetof(Enumerator_tC72BD0EE9002D5F9476F8E5D172DD8D523493303, ___current_3)); }
	inline KeyValuePair_2_t93C466ABB3C1789B9638D6DAE171650D781D5955  get_current_3() const { return ___current_3; }
	inline KeyValuePair_2_t93C466ABB3C1789B9638D6DAE171650D781D5955 * get_address_of_current_3() { return &___current_3; }
	inline void set_current_3(KeyValuePair_2_t93C466ABB3C1789B9638D6DAE171650D781D5955  value)
	{
		___current_3 = value;
	}

	inline static int32_t get_offset_of_getEnumeratorRetType_4() { return static_cast<int32_t>(offsetof(Enumerator_tC72BD0EE9002D5F9476F8E5D172DD8D523493303, ___getEnumeratorRetType_4)); }
	inline int32_t get_getEnumeratorRetType_4() const { return ___getEnumeratorRetType_4; }
	inline int32_t* get_address_of_getEnumeratorRetType_4() { return &___getEnumeratorRetType_4; }
	inline void set_getEnumeratorRetType_4(int32_t value)
	{
		___getEnumeratorRetType_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ENUMERATOR_TC72BD0EE9002D5F9476F8E5D172DD8D523493303_H
#ifndef ENUMERATOR_TDCE19FCEB15DD898D040471AAA04653C12CE59D2_H
#define ENUMERATOR_TDCE19FCEB15DD898D040471AAA04653C12CE59D2_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.Dictionary`2_Enumerator<System.Int64,System.Object>
struct  Enumerator_tDCE19FCEB15DD898D040471AAA04653C12CE59D2 
{
public:
	// System.Collections.Generic.Dictionary`2<TKey,TValue> System.Collections.Generic.Dictionary`2_Enumerator::dictionary
	Dictionary_2_tBB5CC0896C16F33861F997E1B67002AC4E1F2B8A * ___dictionary_0;
	// System.Int32 System.Collections.Generic.Dictionary`2_Enumerator::version
	int32_t ___version_1;
	// System.Int32 System.Collections.Generic.Dictionary`2_Enumerator::index
	int32_t ___index_2;
	// System.Collections.Generic.KeyValuePair`2<TKey,TValue> System.Collections.Generic.Dictionary`2_Enumerator::current
	KeyValuePair_2_t63B92AF862B96BB211B19E9A360065FE8541A53E  ___current_3;
	// System.Int32 System.Collections.Generic.Dictionary`2_Enumerator::getEnumeratorRetType
	int32_t ___getEnumeratorRetType_4;

public:
	inline static int32_t get_offset_of_dictionary_0() { return static_cast<int32_t>(offsetof(Enumerator_tDCE19FCEB15DD898D040471AAA04653C12CE59D2, ___dictionary_0)); }
	inline Dictionary_2_tBB5CC0896C16F33861F997E1B67002AC4E1F2B8A * get_dictionary_0() const { return ___dictionary_0; }
	inline Dictionary_2_tBB5CC0896C16F33861F997E1B67002AC4E1F2B8A ** get_address_of_dictionary_0() { return &___dictionary_0; }
	inline void set_dictionary_0(Dictionary_2_tBB5CC0896C16F33861F997E1B67002AC4E1F2B8A * value)
	{
		___dictionary_0 = value;
		Il2CppCodeGenWriteBarrier((&___dictionary_0), value);
	}

	inline static int32_t get_offset_of_version_1() { return static_cast<int32_t>(offsetof(Enumerator_tDCE19FCEB15DD898D040471AAA04653C12CE59D2, ___version_1)); }
	inline int32_t get_version_1() const { return ___version_1; }
	inline int32_t* get_address_of_version_1() { return &___version_1; }
	inline void set_version_1(int32_t value)
	{
		___version_1 = value;
	}

	inline static int32_t get_offset_of_index_2() { return static_cast<int32_t>(offsetof(Enumerator_tDCE19FCEB15DD898D040471AAA04653C12CE59D2, ___index_2)); }
	inline int32_t get_index_2() const { return ___index_2; }
	inline int32_t* get_address_of_index_2() { return &___index_2; }
	inline void set_index_2(int32_t value)
	{
		___index_2 = value;
	}

	inline static int32_t get_offset_of_current_3() { return static_cast<int32_t>(offsetof(Enumerator_tDCE19FCEB15DD898D040471AAA04653C12CE59D2, ___current_3)); }
	inline KeyValuePair_2_t63B92AF862B96BB211B19E9A360065FE8541A53E  get_current_3() const { return ___current_3; }
	inline KeyValuePair_2_t63B92AF862B96BB211B19E9A360065FE8541A53E * get_address_of_current_3() { return &___current_3; }
	inline void set_current_3(KeyValuePair_2_t63B92AF862B96BB211B19E9A360065FE8541A53E  value)
	{
		___current_3 = value;
	}

	inline static int32_t get_offset_of_getEnumeratorRetType_4() { return static_cast<int32_t>(offsetof(Enumerator_tDCE19FCEB15DD898D040471AAA04653C12CE59D2, ___getEnumeratorRetType_4)); }
	inline int32_t get_getEnumeratorRetType_4() const { return ___getEnumeratorRetType_4; }
	inline int32_t* get_address_of_getEnumeratorRetType_4() { return &___getEnumeratorRetType_4; }
	inline void set_getEnumeratorRetType_4(int32_t value)
	{
		___getEnumeratorRetType_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ENUMERATOR_TDCE19FCEB15DD898D040471AAA04653C12CE59D2_H
#ifndef ENUMERATOR_TED23DFBF3911229086C71CCE7A54D56F5FFB34CB_H
#define ENUMERATOR_TED23DFBF3911229086C71CCE7A54D56F5FFB34CB_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.Dictionary`2_Enumerator<System.Object,System.Object>
struct  Enumerator_tED23DFBF3911229086C71CCE7A54D56F5FFB34CB 
{
public:
	// System.Collections.Generic.Dictionary`2<TKey,TValue> System.Collections.Generic.Dictionary`2_Enumerator::dictionary
	Dictionary_2_t32F25F093828AA9F93CB11C2A2B4648FD62A09BA * ___dictionary_0;
	// System.Int32 System.Collections.Generic.Dictionary`2_Enumerator::version
	int32_t ___version_1;
	// System.Int32 System.Collections.Generic.Dictionary`2_Enumerator::index
	int32_t ___index_2;
	// System.Collections.Generic.KeyValuePair`2<TKey,TValue> System.Collections.Generic.Dictionary`2_Enumerator::current
	KeyValuePair_2_t23481547E419E16E3B96A303578C1EB685C99EEE  ___current_3;
	// System.Int32 System.Collections.Generic.Dictionary`2_Enumerator::getEnumeratorRetType
	int32_t ___getEnumeratorRetType_4;

public:
	inline static int32_t get_offset_of_dictionary_0() { return static_cast<int32_t>(offsetof(Enumerator_tED23DFBF3911229086C71CCE7A54D56F5FFB34CB, ___dictionary_0)); }
	inline Dictionary_2_t32F25F093828AA9F93CB11C2A2B4648FD62A09BA * get_dictionary_0() const { return ___dictionary_0; }
	inline Dictionary_2_t32F25F093828AA9F93CB11C2A2B4648FD62A09BA ** get_address_of_dictionary_0() { return &___dictionary_0; }
	inline void set_dictionary_0(Dictionary_2_t32F25F093828AA9F93CB11C2A2B4648FD62A09BA * value)
	{
		___dictionary_0 = value;
		Il2CppCodeGenWriteBarrier((&___dictionary_0), value);
	}

	inline static int32_t get_offset_of_version_1() { return static_cast<int32_t>(offsetof(Enumerator_tED23DFBF3911229086C71CCE7A54D56F5FFB34CB, ___version_1)); }
	inline int32_t get_version_1() const { return ___version_1; }
	inline int32_t* get_address_of_version_1() { return &___version_1; }
	inline void set_version_1(int32_t value)
	{
		___version_1 = value;
	}

	inline static int32_t get_offset_of_index_2() { return static_cast<int32_t>(offsetof(Enumerator_tED23DFBF3911229086C71CCE7A54D56F5FFB34CB, ___index_2)); }
	inline int32_t get_index_2() const { return ___index_2; }
	inline int32_t* get_address_of_index_2() { return &___index_2; }
	inline void set_index_2(int32_t value)
	{
		___index_2 = value;
	}

	inline static int32_t get_offset_of_current_3() { return static_cast<int32_t>(offsetof(Enumerator_tED23DFBF3911229086C71CCE7A54D56F5FFB34CB, ___current_3)); }
	inline KeyValuePair_2_t23481547E419E16E3B96A303578C1EB685C99EEE  get_current_3() const { return ___current_3; }
	inline KeyValuePair_2_t23481547E419E16E3B96A303578C1EB685C99EEE * get_address_of_current_3() { return &___current_3; }
	inline void set_current_3(KeyValuePair_2_t23481547E419E16E3B96A303578C1EB685C99EEE  value)
	{
		___current_3 = value;
	}

	inline static int32_t get_offset_of_getEnumeratorRetType_4() { return static_cast<int32_t>(offsetof(Enumerator_tED23DFBF3911229086C71CCE7A54D56F5FFB34CB, ___getEnumeratorRetType_4)); }
	inline int32_t get_getEnumeratorRetType_4() const { return ___getEnumeratorRetType_4; }
	inline int32_t* get_address_of_getEnumeratorRetType_4() { return &___getEnumeratorRetType_4; }
	inline void set_getEnumeratorRetType_4(int32_t value)
	{
		___getEnumeratorRetType_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ENUMERATOR_TED23DFBF3911229086C71CCE7A54D56F5FFB34CB_H
#ifndef ENUMERATOR_T38C41296850665F3643D772F9790D4B3880BD9AA_H
#define ENUMERATOR_T38C41296850665F3643D772F9790D4B3880BD9AA_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.Dictionary`2_Enumerator<System.String,System.Collections.Generic.List`1<System.String>>
struct  Enumerator_t38C41296850665F3643D772F9790D4B3880BD9AA 
{
public:
	// System.Collections.Generic.Dictionary`2<TKey,TValue> System.Collections.Generic.Dictionary`2_Enumerator::dictionary
	Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF * ___dictionary_0;
	// System.Int32 System.Collections.Generic.Dictionary`2_Enumerator::version
	int32_t ___version_1;
	// System.Int32 System.Collections.Generic.Dictionary`2_Enumerator::index
	int32_t ___index_2;
	// System.Collections.Generic.KeyValuePair`2<TKey,TValue> System.Collections.Generic.Dictionary`2_Enumerator::current
	KeyValuePair_2_t9E20856DB65BAC258C27F3C359C8A86E2DCEEBBD  ___current_3;
	// System.Int32 System.Collections.Generic.Dictionary`2_Enumerator::getEnumeratorRetType
	int32_t ___getEnumeratorRetType_4;

public:
	inline static int32_t get_offset_of_dictionary_0() { return static_cast<int32_t>(offsetof(Enumerator_t38C41296850665F3643D772F9790D4B3880BD9AA, ___dictionary_0)); }
	inline Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF * get_dictionary_0() const { return ___dictionary_0; }
	inline Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF ** get_address_of_dictionary_0() { return &___dictionary_0; }
	inline void set_dictionary_0(Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF * value)
	{
		___dictionary_0 = value;
		Il2CppCodeGenWriteBarrier((&___dictionary_0), value);
	}

	inline static int32_t get_offset_of_version_1() { return static_cast<int32_t>(offsetof(Enumerator_t38C41296850665F3643D772F9790D4B3880BD9AA, ___version_1)); }
	inline int32_t get_version_1() const { return ___version_1; }
	inline int32_t* get_address_of_version_1() { return &___version_1; }
	inline void set_version_1(int32_t value)
	{
		___version_1 = value;
	}

	inline static int32_t get_offset_of_index_2() { return static_cast<int32_t>(offsetof(Enumerator_t38C41296850665F3643D772F9790D4B3880BD9AA, ___index_2)); }
	inline int32_t get_index_2() const { return ___index_2; }
	inline int32_t* get_address_of_index_2() { return &___index_2; }
	inline void set_index_2(int32_t value)
	{
		___index_2 = value;
	}

	inline static int32_t get_offset_of_current_3() { return static_cast<int32_t>(offsetof(Enumerator_t38C41296850665F3643D772F9790D4B3880BD9AA, ___current_3)); }
	inline KeyValuePair_2_t9E20856DB65BAC258C27F3C359C8A86E2DCEEBBD  get_current_3() const { return ___current_3; }
	inline KeyValuePair_2_t9E20856DB65BAC258C27F3C359C8A86E2DCEEBBD * get_address_of_current_3() { return &___current_3; }
	inline void set_current_3(KeyValuePair_2_t9E20856DB65BAC258C27F3C359C8A86E2DCEEBBD  value)
	{
		___current_3 = value;
	}

	inline static int32_t get_offset_of_getEnumeratorRetType_4() { return static_cast<int32_t>(offsetof(Enumerator_t38C41296850665F3643D772F9790D4B3880BD9AA, ___getEnumeratorRetType_4)); }
	inline int32_t get_getEnumeratorRetType_4() const { return ___getEnumeratorRetType_4; }
	inline int32_t* get_address_of_getEnumeratorRetType_4() { return &___getEnumeratorRetType_4; }
	inline void set_getEnumeratorRetType_4(int32_t value)
	{
		___getEnumeratorRetType_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ENUMERATOR_T38C41296850665F3643D772F9790D4B3880BD9AA_H
#ifndef ASSEMBLYHASHALGORITHM_T31E4F1BC642CF668706C9D0FBD9DFDF5EE01CEB9_H
#define ASSEMBLYHASHALGORITHM_T31E4F1BC642CF668706C9D0FBD9DFDF5EE01CEB9_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Configuration.Assemblies.AssemblyHashAlgorithm
struct  AssemblyHashAlgorithm_t31E4F1BC642CF668706C9D0FBD9DFDF5EE01CEB9 
{
public:
	// System.Int32 System.Configuration.Assemblies.AssemblyHashAlgorithm::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(AssemblyHashAlgorithm_t31E4F1BC642CF668706C9D0FBD9DFDF5EE01CEB9, ___value___2)); }
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
#endif // ASSEMBLYHASHALGORITHM_T31E4F1BC642CF668706C9D0FBD9DFDF5EE01CEB9_H
#ifndef ASSEMBLYVERSIONCOMPATIBILITY_TEA062AB37A9A750B33F6CA2898EEF03A4EEA496C_H
#define ASSEMBLYVERSIONCOMPATIBILITY_TEA062AB37A9A750B33F6CA2898EEF03A4EEA496C_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Configuration.Assemblies.AssemblyVersionCompatibility
struct  AssemblyVersionCompatibility_tEA062AB37A9A750B33F6CA2898EEF03A4EEA496C 
{
public:
	// System.Int32 System.Configuration.Assemblies.AssemblyVersionCompatibility::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(AssemblyVersionCompatibility_tEA062AB37A9A750B33F6CA2898EEF03A4EEA496C, ___value___2)); }
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
#endif // ASSEMBLYVERSIONCOMPATIBILITY_TEA062AB37A9A750B33F6CA2898EEF03A4EEA496C_H
#ifndef COMMANDBEHAVIOR_T44AD8D7F0B6029BE0E79118321DA1061E90095D9_H
#define COMMANDBEHAVIOR_T44AD8D7F0B6029BE0E79118321DA1061E90095D9_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Data.CommandBehavior
struct  CommandBehavior_t44AD8D7F0B6029BE0E79118321DA1061E90095D9 
{
public:
	// System.Int32 System.Data.CommandBehavior::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(CommandBehavior_t44AD8D7F0B6029BE0E79118321DA1061E90095D9, ___value___2)); }
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
#endif // COMMANDBEHAVIOR_T44AD8D7F0B6029BE0E79118321DA1061E90095D9_H
#ifndef CATALOGLOCATION_T70D7B8F0E4A2AEF63022025AC052B6A153786370_H
#define CATALOGLOCATION_T70D7B8F0E4A2AEF63022025AC052B6A153786370_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Data.Common.CatalogLocation
struct  CatalogLocation_t70D7B8F0E4A2AEF63022025AC052B6A153786370 
{
public:
	// System.Int32 System.Data.Common.CatalogLocation::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(CatalogLocation_t70D7B8F0E4A2AEF63022025AC052B6A153786370, ___value___2)); }
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
#endif // CATALOGLOCATION_T70D7B8F0E4A2AEF63022025AC052B6A153786370_H
#ifndef DBCOMMAND_T818F90E565B3D0FB3D6C653214D5C8E4211A5A55_H
#define DBCOMMAND_T818F90E565B3D0FB3D6C653214D5C8E4211A5A55_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Data.Common.DbCommand
struct  DbCommand_t818F90E565B3D0FB3D6C653214D5C8E4211A5A55  : public Component_t7AEFE153F6778CF52E1981BC3E811A9604B29473
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // DBCOMMAND_T818F90E565B3D0FB3D6C653214D5C8E4211A5A55_H
#ifndef DBCONNECTION_TBCDED104D8D1B6EB4ED87AB6845D3ACF18C9807E_H
#define DBCONNECTION_TBCDED104D8D1B6EB4ED87AB6845D3ACF18C9807E_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Data.Common.DbConnection
struct  DbConnection_tBCDED104D8D1B6EB4ED87AB6845D3ACF18C9807E  : public Component_t7AEFE153F6778CF52E1981BC3E811A9604B29473
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // DBCONNECTION_TBCDED104D8D1B6EB4ED87AB6845D3ACF18C9807E_H
#ifndef CONFLICTOPTION_T8D450868FE5E02770715B6FDC0C1ADC398DB4D58_H
#define CONFLICTOPTION_T8D450868FE5E02770715B6FDC0C1ADC398DB4D58_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Data.ConflictOption
struct  ConflictOption_t8D450868FE5E02770715B6FDC0C1ADC398DB4D58 
{
public:
	// System.Int32 System.Data.ConflictOption::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(ConflictOption_t8D450868FE5E02770715B6FDC0C1ADC398DB4D58, ___value___2)); }
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
#endif // CONFLICTOPTION_T8D450868FE5E02770715B6FDC0C1ADC398DB4D58_H
#ifndef CONNECTIONSTATE_TAA8341EF50FDF898227D4EE5243C7841AC0AD0C9_H
#define CONNECTIONSTATE_TAA8341EF50FDF898227D4EE5243C7841AC0AD0C9_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Data.ConnectionState
struct  ConnectionState_tAA8341EF50FDF898227D4EE5243C7841AC0AD0C9 
{
public:
	// System.Int32 System.Data.ConnectionState::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(ConnectionState_tAA8341EF50FDF898227D4EE5243C7841AC0AD0C9, ___value___2)); }
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
#endif // CONNECTIONSTATE_TAA8341EF50FDF898227D4EE5243C7841AC0AD0C9_H
#ifndef DATAROWACTION_TDA5E813CDEE8ABF5D37A4A055D75B66DDBEB068F_H
#define DATAROWACTION_TDA5E813CDEE8ABF5D37A4A055D75B66DDBEB068F_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Data.DataRowAction
struct  DataRowAction_tDA5E813CDEE8ABF5D37A4A055D75B66DDBEB068F 
{
public:
	// System.Int32 System.Data.DataRowAction::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(DataRowAction_tDA5E813CDEE8ABF5D37A4A055D75B66DDBEB068F, ___value___2)); }
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
#endif // DATAROWACTION_TDA5E813CDEE8ABF5D37A4A055D75B66DDBEB068F_H
#ifndef DATAROWVERSION_TE3833F3D79C7978019CE3224F5C1AA86C503A219_H
#define DATAROWVERSION_TE3833F3D79C7978019CE3224F5C1AA86C503A219_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Data.DataRowVersion
struct  DataRowVersion_tE3833F3D79C7978019CE3224F5C1AA86C503A219 
{
public:
	// System.Int32 System.Data.DataRowVersion::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(DataRowVersion_tE3833F3D79C7978019CE3224F5C1AA86C503A219, ___value___2)); }
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
#endif // DATAROWVERSION_TE3833F3D79C7978019CE3224F5C1AA86C503A219_H
#ifndef DBTYPE_T46DC393C53E0CB52DF1792FD357A7E596C5F432E_H
#define DBTYPE_T46DC393C53E0CB52DF1792FD357A7E596C5F432E_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Data.DbType
struct  DbType_t46DC393C53E0CB52DF1792FD357A7E596C5F432E 
{
public:
	// System.Int32 System.Data.DbType::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(DbType_t46DC393C53E0CB52DF1792FD357A7E596C5F432E, ___value___2)); }
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
#endif // DBTYPE_T46DC393C53E0CB52DF1792FD357A7E596C5F432E_H
#ifndef ISOLATIONLEVEL_T0E1D740CF5F0A7D8142C442923C3613E02A7DC30_H
#define ISOLATIONLEVEL_T0E1D740CF5F0A7D8142C442923C3613E02A7DC30_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Data.IsolationLevel
struct  IsolationLevel_t0E1D740CF5F0A7D8142C442923C3613E02A7DC30 
{
public:
	// System.Int32 System.Data.IsolationLevel::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(IsolationLevel_t0E1D740CF5F0A7D8142C442923C3613E02A7DC30, ___value___2)); }
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
#endif // ISOLATIONLEVEL_T0E1D740CF5F0A7D8142C442923C3613E02A7DC30_H
#ifndef MISSINGMAPPINGACTION_T4409584F4138F01A0F7C4C3685C631111E98646B_H
#define MISSINGMAPPINGACTION_T4409584F4138F01A0F7C4C3685C631111E98646B_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Data.MissingMappingAction
struct  MissingMappingAction_t4409584F4138F01A0F7C4C3685C631111E98646B 
{
public:
	// System.Int32 System.Data.MissingMappingAction::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(MissingMappingAction_t4409584F4138F01A0F7C4C3685C631111E98646B, ___value___2)); }
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
#endif // MISSINGMAPPINGACTION_T4409584F4138F01A0F7C4C3685C631111E98646B_H
#ifndef PARAMETERDIRECTION_T1DFA1B38D7DEE0B5D5A97F26AF77351FDA8539EB_H
#define PARAMETERDIRECTION_T1DFA1B38D7DEE0B5D5A97F26AF77351FDA8539EB_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Data.ParameterDirection
struct  ParameterDirection_t1DFA1B38D7DEE0B5D5A97F26AF77351FDA8539EB 
{
public:
	// System.Int32 System.Data.ParameterDirection::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(ParameterDirection_t1DFA1B38D7DEE0B5D5A97F26AF77351FDA8539EB, ___value___2)); }
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
#endif // PARAMETERDIRECTION_T1DFA1B38D7DEE0B5D5A97F26AF77351FDA8539EB_H
#ifndef SERIALIZATIONFORMAT_T2E21C627CA0559AFC056EF32704C94DFF740DA4B_H
#define SERIALIZATIONFORMAT_T2E21C627CA0559AFC056EF32704C94DFF740DA4B_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Data.SerializationFormat
struct  SerializationFormat_t2E21C627CA0559AFC056EF32704C94DFF740DA4B 
{
public:
	// System.Int32 System.Data.SerializationFormat::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(SerializationFormat_t2E21C627CA0559AFC056EF32704C94DFF740DA4B, ___value___2)); }
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
#endif // SERIALIZATIONFORMAT_T2E21C627CA0559AFC056EF32704C94DFF740DA4B_H
#ifndef UPDATEROWSOURCE_T73E9A51EC13A3C2409EF35D94C972313D4F7DB54_H
#define UPDATEROWSOURCE_T73E9A51EC13A3C2409EF35D94C972313D4F7DB54_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Data.UpdateRowSource
struct  UpdateRowSource_t73E9A51EC13A3C2409EF35D94C972313D4F7DB54 
{
public:
	// System.Int32 System.Data.UpdateRowSource::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(UpdateRowSource_t73E9A51EC13A3C2409EF35D94C972313D4F7DB54, ___value___2)); }
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
#endif // UPDATEROWSOURCE_T73E9A51EC13A3C2409EF35D94C972313D4F7DB54_H
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
#ifndef COMPAREOPTIONS_T163DCEA9A0972750294CC1A8348E5CA69E943939_H
#define COMPAREOPTIONS_T163DCEA9A0972750294CC1A8348E5CA69E943939_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Globalization.CompareOptions
struct  CompareOptions_t163DCEA9A0972750294CC1A8348E5CA69E943939 
{
public:
	// System.Int32 System.Globalization.CompareOptions::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(CompareOptions_t163DCEA9A0972750294CC1A8348E5CA69E943939, ___value___2)); }
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
#endif // COMPAREOPTIONS_T163DCEA9A0972750294CC1A8348E5CA69E943939_H
#ifndef INVALIDCASTEXCEPTION_T91DF9E7D7FCCDA6C562CB4A9A18903E016680FDA_H
#define INVALIDCASTEXCEPTION_T91DF9E7D7FCCDA6C562CB4A9A18903E016680FDA_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.InvalidCastException
struct  InvalidCastException_t91DF9E7D7FCCDA6C562CB4A9A18903E016680FDA  : public SystemException_t5380468142AA850BE4A341D7AF3EAB9C78746782
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // INVALIDCASTEXCEPTION_T91DF9E7D7FCCDA6C562CB4A9A18903E016680FDA_H
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
#ifndef NOTSUPPORTEDEXCEPTION_TE75B318D6590A02A5D9B29FD97409B1750FA0010_H
#define NOTSUPPORTEDEXCEPTION_TE75B318D6590A02A5D9B29FD97409B1750FA0010_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.NotSupportedException
struct  NotSupportedException_tE75B318D6590A02A5D9B29FD97409B1750FA0010  : public SystemException_t5380468142AA850BE4A341D7AF3EAB9C78746782
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // NOTSUPPORTEDEXCEPTION_TE75B318D6590A02A5D9B29FD97409B1750FA0010_H
#ifndef ASSEMBLY_T_H
#define ASSEMBLY_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Reflection.Assembly
struct  Assembly_t  : public RuntimeObject
{
public:
	// System.IntPtr System.Reflection.Assembly::_mono_assembly
	intptr_t ____mono_assembly_0;
	// System.Reflection.Assembly_ResolveEventHolder System.Reflection.Assembly::resolve_event_holder
	ResolveEventHolder_t5267893EB7CB9C12F7B9B463FD4C221BEA03326E * ___resolve_event_holder_1;
	// System.Object System.Reflection.Assembly::_evidence
	RuntimeObject * ____evidence_2;
	// System.Object System.Reflection.Assembly::_minimum
	RuntimeObject * ____minimum_3;
	// System.Object System.Reflection.Assembly::_optional
	RuntimeObject * ____optional_4;
	// System.Object System.Reflection.Assembly::_refuse
	RuntimeObject * ____refuse_5;
	// System.Object System.Reflection.Assembly::_granted
	RuntimeObject * ____granted_6;
	// System.Object System.Reflection.Assembly::_denied
	RuntimeObject * ____denied_7;
	// System.Boolean System.Reflection.Assembly::fromByteArray
	bool ___fromByteArray_8;
	// System.String System.Reflection.Assembly::assemblyName
	String_t* ___assemblyName_9;

public:
	inline static int32_t get_offset_of__mono_assembly_0() { return static_cast<int32_t>(offsetof(Assembly_t, ____mono_assembly_0)); }
	inline intptr_t get__mono_assembly_0() const { return ____mono_assembly_0; }
	inline intptr_t* get_address_of__mono_assembly_0() { return &____mono_assembly_0; }
	inline void set__mono_assembly_0(intptr_t value)
	{
		____mono_assembly_0 = value;
	}

	inline static int32_t get_offset_of_resolve_event_holder_1() { return static_cast<int32_t>(offsetof(Assembly_t, ___resolve_event_holder_1)); }
	inline ResolveEventHolder_t5267893EB7CB9C12F7B9B463FD4C221BEA03326E * get_resolve_event_holder_1() const { return ___resolve_event_holder_1; }
	inline ResolveEventHolder_t5267893EB7CB9C12F7B9B463FD4C221BEA03326E ** get_address_of_resolve_event_holder_1() { return &___resolve_event_holder_1; }
	inline void set_resolve_event_holder_1(ResolveEventHolder_t5267893EB7CB9C12F7B9B463FD4C221BEA03326E * value)
	{
		___resolve_event_holder_1 = value;
		Il2CppCodeGenWriteBarrier((&___resolve_event_holder_1), value);
	}

	inline static int32_t get_offset_of__evidence_2() { return static_cast<int32_t>(offsetof(Assembly_t, ____evidence_2)); }
	inline RuntimeObject * get__evidence_2() const { return ____evidence_2; }
	inline RuntimeObject ** get_address_of__evidence_2() { return &____evidence_2; }
	inline void set__evidence_2(RuntimeObject * value)
	{
		____evidence_2 = value;
		Il2CppCodeGenWriteBarrier((&____evidence_2), value);
	}

	inline static int32_t get_offset_of__minimum_3() { return static_cast<int32_t>(offsetof(Assembly_t, ____minimum_3)); }
	inline RuntimeObject * get__minimum_3() const { return ____minimum_3; }
	inline RuntimeObject ** get_address_of__minimum_3() { return &____minimum_3; }
	inline void set__minimum_3(RuntimeObject * value)
	{
		____minimum_3 = value;
		Il2CppCodeGenWriteBarrier((&____minimum_3), value);
	}

	inline static int32_t get_offset_of__optional_4() { return static_cast<int32_t>(offsetof(Assembly_t, ____optional_4)); }
	inline RuntimeObject * get__optional_4() const { return ____optional_4; }
	inline RuntimeObject ** get_address_of__optional_4() { return &____optional_4; }
	inline void set__optional_4(RuntimeObject * value)
	{
		____optional_4 = value;
		Il2CppCodeGenWriteBarrier((&____optional_4), value);
	}

	inline static int32_t get_offset_of__refuse_5() { return static_cast<int32_t>(offsetof(Assembly_t, ____refuse_5)); }
	inline RuntimeObject * get__refuse_5() const { return ____refuse_5; }
	inline RuntimeObject ** get_address_of__refuse_5() { return &____refuse_5; }
	inline void set__refuse_5(RuntimeObject * value)
	{
		____refuse_5 = value;
		Il2CppCodeGenWriteBarrier((&____refuse_5), value);
	}

	inline static int32_t get_offset_of__granted_6() { return static_cast<int32_t>(offsetof(Assembly_t, ____granted_6)); }
	inline RuntimeObject * get__granted_6() const { return ____granted_6; }
	inline RuntimeObject ** get_address_of__granted_6() { return &____granted_6; }
	inline void set__granted_6(RuntimeObject * value)
	{
		____granted_6 = value;
		Il2CppCodeGenWriteBarrier((&____granted_6), value);
	}

	inline static int32_t get_offset_of__denied_7() { return static_cast<int32_t>(offsetof(Assembly_t, ____denied_7)); }
	inline RuntimeObject * get__denied_7() const { return ____denied_7; }
	inline RuntimeObject ** get_address_of__denied_7() { return &____denied_7; }
	inline void set__denied_7(RuntimeObject * value)
	{
		____denied_7 = value;
		Il2CppCodeGenWriteBarrier((&____denied_7), value);
	}

	inline static int32_t get_offset_of_fromByteArray_8() { return static_cast<int32_t>(offsetof(Assembly_t, ___fromByteArray_8)); }
	inline bool get_fromByteArray_8() const { return ___fromByteArray_8; }
	inline bool* get_address_of_fromByteArray_8() { return &___fromByteArray_8; }
	inline void set_fromByteArray_8(bool value)
	{
		___fromByteArray_8 = value;
	}

	inline static int32_t get_offset_of_assemblyName_9() { return static_cast<int32_t>(offsetof(Assembly_t, ___assemblyName_9)); }
	inline String_t* get_assemblyName_9() const { return ___assemblyName_9; }
	inline String_t** get_address_of_assemblyName_9() { return &___assemblyName_9; }
	inline void set_assemblyName_9(String_t* value)
	{
		___assemblyName_9 = value;
		Il2CppCodeGenWriteBarrier((&___assemblyName_9), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.Reflection.Assembly
struct Assembly_t_marshaled_pinvoke
{
	intptr_t ____mono_assembly_0;
	ResolveEventHolder_t5267893EB7CB9C12F7B9B463FD4C221BEA03326E * ___resolve_event_holder_1;
	Il2CppIUnknown* ____evidence_2;
	Il2CppIUnknown* ____minimum_3;
	Il2CppIUnknown* ____optional_4;
	Il2CppIUnknown* ____refuse_5;
	Il2CppIUnknown* ____granted_6;
	Il2CppIUnknown* ____denied_7;
	int32_t ___fromByteArray_8;
	char* ___assemblyName_9;
};
// Native definition for COM marshalling of System.Reflection.Assembly
struct Assembly_t_marshaled_com
{
	intptr_t ____mono_assembly_0;
	ResolveEventHolder_t5267893EB7CB9C12F7B9B463FD4C221BEA03326E * ___resolve_event_holder_1;
	Il2CppIUnknown* ____evidence_2;
	Il2CppIUnknown* ____minimum_3;
	Il2CppIUnknown* ____optional_4;
	Il2CppIUnknown* ____refuse_5;
	Il2CppIUnknown* ____granted_6;
	Il2CppIUnknown* ____denied_7;
	int32_t ___fromByteArray_8;
	Il2CppChar* ___assemblyName_9;
};
#endif // ASSEMBLY_T_H
#ifndef ASSEMBLYCONTENTTYPE_T9869DE40B7B1976B389F3B6A5A5D18B09E623401_H
#define ASSEMBLYCONTENTTYPE_T9869DE40B7B1976B389F3B6A5A5D18B09E623401_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Reflection.AssemblyContentType
struct  AssemblyContentType_t9869DE40B7B1976B389F3B6A5A5D18B09E623401 
{
public:
	// System.Int32 System.Reflection.AssemblyContentType::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(AssemblyContentType_t9869DE40B7B1976B389F3B6A5A5D18B09E623401, ___value___2)); }
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
#endif // ASSEMBLYCONTENTTYPE_T9869DE40B7B1976B389F3B6A5A5D18B09E623401_H
#ifndef ASSEMBLYNAMEFLAGS_T7834EDF078E7ECA985AA434A1EA0D95C2A44F256_H
#define ASSEMBLYNAMEFLAGS_T7834EDF078E7ECA985AA434A1EA0D95C2A44F256_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Reflection.AssemblyNameFlags
struct  AssemblyNameFlags_t7834EDF078E7ECA985AA434A1EA0D95C2A44F256 
{
public:
	// System.Int32 System.Reflection.AssemblyNameFlags::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(AssemblyNameFlags_t7834EDF078E7ECA985AA434A1EA0D95C2A44F256, ___value___2)); }
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
#endif // ASSEMBLYNAMEFLAGS_T7834EDF078E7ECA985AA434A1EA0D95C2A44F256_H
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
#ifndef PROCESSORARCHITECTURE_T0CFB73A83469D6AC222B9FE46E81EAC73C2627C7_H
#define PROCESSORARCHITECTURE_T0CFB73A83469D6AC222B9FE46E81EAC73C2627C7_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Reflection.ProcessorArchitecture
struct  ProcessorArchitecture_t0CFB73A83469D6AC222B9FE46E81EAC73C2627C7 
{
public:
	// System.Int32 System.Reflection.ProcessorArchitecture::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(ProcessorArchitecture_t0CFB73A83469D6AC222B9FE46E81EAC73C2627C7, ___value___2)); }
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
#endif // PROCESSORARCHITECTURE_T0CFB73A83469D6AC222B9FE46E81EAC73C2627C7_H
#ifndef REFLECTIONTYPELOADEXCEPTION_T1306B3A246E2959E8F23575AAAB9D59945314115_H
#define REFLECTIONTYPELOADEXCEPTION_T1306B3A246E2959E8F23575AAAB9D59945314115_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Reflection.ReflectionTypeLoadException
struct  ReflectionTypeLoadException_t1306B3A246E2959E8F23575AAAB9D59945314115  : public SystemException_t5380468142AA850BE4A341D7AF3EAB9C78746782
{
public:
	// System.Type[] System.Reflection.ReflectionTypeLoadException::_classes
	TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F* ____classes_17;
	// System.Exception[] System.Reflection.ReflectionTypeLoadException::_exceptions
	ExceptionU5BU5D_t09C3EFFA7CF3F84DA802016E2017E1608442F209* ____exceptions_18;

public:
	inline static int32_t get_offset_of__classes_17() { return static_cast<int32_t>(offsetof(ReflectionTypeLoadException_t1306B3A246E2959E8F23575AAAB9D59945314115, ____classes_17)); }
	inline TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F* get__classes_17() const { return ____classes_17; }
	inline TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F** get_address_of__classes_17() { return &____classes_17; }
	inline void set__classes_17(TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F* value)
	{
		____classes_17 = value;
		Il2CppCodeGenWriteBarrier((&____classes_17), value);
	}

	inline static int32_t get_offset_of__exceptions_18() { return static_cast<int32_t>(offsetof(ReflectionTypeLoadException_t1306B3A246E2959E8F23575AAAB9D59945314115, ____exceptions_18)); }
	inline ExceptionU5BU5D_t09C3EFFA7CF3F84DA802016E2017E1608442F209* get__exceptions_18() const { return ____exceptions_18; }
	inline ExceptionU5BU5D_t09C3EFFA7CF3F84DA802016E2017E1608442F209** get_address_of__exceptions_18() { return &____exceptions_18; }
	inline void set__exceptions_18(ExceptionU5BU5D_t09C3EFFA7CF3F84DA802016E2017E1608442F209* value)
	{
		____exceptions_18 = value;
		Il2CppCodeGenWriteBarrier((&____exceptions_18), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // REFLECTIONTYPELOADEXCEPTION_T1306B3A246E2959E8F23575AAAB9D59945314115_H
#ifndef CRITICALHANDLE_TDF3AA1D1AA9E07599C316DB1C5449D3FB7BFD4C9_H
#define CRITICALHANDLE_TDF3AA1D1AA9E07599C316DB1C5449D3FB7BFD4C9_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Runtime.InteropServices.CriticalHandle
struct  CriticalHandle_tDF3AA1D1AA9E07599C316DB1C5449D3FB7BFD4C9  : public CriticalFinalizerObject_t8B006E1DEE084E781F5C0F3283E9226E28894DD9
{
public:
	// System.IntPtr System.Runtime.InteropServices.CriticalHandle::handle
	intptr_t ___handle_0;
	// System.Boolean System.Runtime.InteropServices.CriticalHandle::_isClosed
	bool ____isClosed_1;

public:
	inline static int32_t get_offset_of_handle_0() { return static_cast<int32_t>(offsetof(CriticalHandle_tDF3AA1D1AA9E07599C316DB1C5449D3FB7BFD4C9, ___handle_0)); }
	inline intptr_t get_handle_0() const { return ___handle_0; }
	inline intptr_t* get_address_of_handle_0() { return &___handle_0; }
	inline void set_handle_0(intptr_t value)
	{
		___handle_0 = value;
	}

	inline static int32_t get_offset_of__isClosed_1() { return static_cast<int32_t>(offsetof(CriticalHandle_tDF3AA1D1AA9E07599C316DB1C5449D3FB7BFD4C9, ____isClosed_1)); }
	inline bool get__isClosed_1() const { return ____isClosed_1; }
	inline bool* get_address_of__isClosed_1() { return &____isClosed_1; }
	inline void set__isClosed_1(bool value)
	{
		____isClosed_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // CRITICALHANDLE_TDF3AA1D1AA9E07599C316DB1C5449D3FB7BFD4C9_H
#ifndef EXTERNALEXCEPTION_T68841FD169C0CB00CC950EDA7E2A59540D65B1CE_H
#define EXTERNALEXCEPTION_T68841FD169C0CB00CC950EDA7E2A59540D65B1CE_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Runtime.InteropServices.ExternalException
struct  ExternalException_t68841FD169C0CB00CC950EDA7E2A59540D65B1CE  : public SystemException_t5380468142AA850BE4A341D7AF3EAB9C78746782
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // EXTERNALEXCEPTION_T68841FD169C0CB00CC950EDA7E2A59540D65B1CE_H
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
#ifndef RUNTIMEFIELDHANDLE_T844BDF00E8E6FE69D9AEAA7657F09018B864F4EF_H
#define RUNTIMEFIELDHANDLE_T844BDF00E8E6FE69D9AEAA7657F09018B864F4EF_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.RuntimeFieldHandle
struct  RuntimeFieldHandle_t844BDF00E8E6FE69D9AEAA7657F09018B864F4EF 
{
public:
	// System.IntPtr System.RuntimeFieldHandle::value
	intptr_t ___value_0;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(RuntimeFieldHandle_t844BDF00E8E6FE69D9AEAA7657F09018B864F4EF, ___value_0)); }
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
#endif // RUNTIMEFIELDHANDLE_T844BDF00E8E6FE69D9AEAA7657F09018B864F4EF_H
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
#ifndef STRINGCOMPARISON_T02BAA95468CE9E91115C604577611FDF58FEDCF0_H
#define STRINGCOMPARISON_T02BAA95468CE9E91115C604577611FDF58FEDCF0_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.StringComparison
struct  StringComparison_t02BAA95468CE9E91115C604577611FDF58FEDCF0 
{
public:
	// System.Int32 System.StringComparison::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(StringComparison_t02BAA95468CE9E91115C604577611FDF58FEDCF0, ___value___2)); }
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
#endif // STRINGCOMPARISON_T02BAA95468CE9E91115C604577611FDF58FEDCF0_H
#ifndef SQLITECOMMAND_T200B8B48F8FC6F3537B5CC4C7D325708EE696365_H
#define SQLITECOMMAND_T200B8B48F8FC6F3537B5CC4C7D325708EE696365_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.SqliteCommand
struct  SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365  : public DbCommand_t818F90E565B3D0FB3D6C653214D5C8E4211A5A55
{
public:
	// System.String Mono.Data.Sqlite.SqliteCommand::_commandText
	String_t* ____commandText_4;
	// Mono.Data.Sqlite.SqliteConnection Mono.Data.Sqlite.SqliteCommand::_cnn
	SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * ____cnn_5;
	// System.Int64 Mono.Data.Sqlite.SqliteCommand::_version
	int64_t ____version_6;
	// System.WeakReference Mono.Data.Sqlite.SqliteCommand::_activeReader
	WeakReference_t0495CC81CD6403E662B7700B802443F6F730E39D * ____activeReader_7;
	// System.Int32 Mono.Data.Sqlite.SqliteCommand::_commandTimeout
	int32_t ____commandTimeout_8;
	// System.Boolean Mono.Data.Sqlite.SqliteCommand::_designTimeVisible
	bool ____designTimeVisible_9;
	// System.Data.UpdateRowSource Mono.Data.Sqlite.SqliteCommand::_updateRowSource
	int32_t ____updateRowSource_10;
	// Mono.Data.Sqlite.SqliteParameterCollection Mono.Data.Sqlite.SqliteCommand::_parameterCollection
	SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * ____parameterCollection_11;
	// System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteStatement> Mono.Data.Sqlite.SqliteCommand::_statementList
	List_1_t061A89EAEE080F1782627C91C598BD546671C91A * ____statementList_12;
	// System.String Mono.Data.Sqlite.SqliteCommand::_remainingText
	String_t* ____remainingText_13;
	// Mono.Data.Sqlite.SqliteTransaction Mono.Data.Sqlite.SqliteCommand::_transaction
	SqliteTransaction_t588D1AEC987A56478BF3B4254D6F83A4740F1560 * ____transaction_14;

public:
	inline static int32_t get_offset_of__commandText_4() { return static_cast<int32_t>(offsetof(SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365, ____commandText_4)); }
	inline String_t* get__commandText_4() const { return ____commandText_4; }
	inline String_t** get_address_of__commandText_4() { return &____commandText_4; }
	inline void set__commandText_4(String_t* value)
	{
		____commandText_4 = value;
		Il2CppCodeGenWriteBarrier((&____commandText_4), value);
	}

	inline static int32_t get_offset_of__cnn_5() { return static_cast<int32_t>(offsetof(SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365, ____cnn_5)); }
	inline SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * get__cnn_5() const { return ____cnn_5; }
	inline SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 ** get_address_of__cnn_5() { return &____cnn_5; }
	inline void set__cnn_5(SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * value)
	{
		____cnn_5 = value;
		Il2CppCodeGenWriteBarrier((&____cnn_5), value);
	}

	inline static int32_t get_offset_of__version_6() { return static_cast<int32_t>(offsetof(SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365, ____version_6)); }
	inline int64_t get__version_6() const { return ____version_6; }
	inline int64_t* get_address_of__version_6() { return &____version_6; }
	inline void set__version_6(int64_t value)
	{
		____version_6 = value;
	}

	inline static int32_t get_offset_of__activeReader_7() { return static_cast<int32_t>(offsetof(SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365, ____activeReader_7)); }
	inline WeakReference_t0495CC81CD6403E662B7700B802443F6F730E39D * get__activeReader_7() const { return ____activeReader_7; }
	inline WeakReference_t0495CC81CD6403E662B7700B802443F6F730E39D ** get_address_of__activeReader_7() { return &____activeReader_7; }
	inline void set__activeReader_7(WeakReference_t0495CC81CD6403E662B7700B802443F6F730E39D * value)
	{
		____activeReader_7 = value;
		Il2CppCodeGenWriteBarrier((&____activeReader_7), value);
	}

	inline static int32_t get_offset_of__commandTimeout_8() { return static_cast<int32_t>(offsetof(SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365, ____commandTimeout_8)); }
	inline int32_t get__commandTimeout_8() const { return ____commandTimeout_8; }
	inline int32_t* get_address_of__commandTimeout_8() { return &____commandTimeout_8; }
	inline void set__commandTimeout_8(int32_t value)
	{
		____commandTimeout_8 = value;
	}

	inline static int32_t get_offset_of__designTimeVisible_9() { return static_cast<int32_t>(offsetof(SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365, ____designTimeVisible_9)); }
	inline bool get__designTimeVisible_9() const { return ____designTimeVisible_9; }
	inline bool* get_address_of__designTimeVisible_9() { return &____designTimeVisible_9; }
	inline void set__designTimeVisible_9(bool value)
	{
		____designTimeVisible_9 = value;
	}

	inline static int32_t get_offset_of__updateRowSource_10() { return static_cast<int32_t>(offsetof(SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365, ____updateRowSource_10)); }
	inline int32_t get__updateRowSource_10() const { return ____updateRowSource_10; }
	inline int32_t* get_address_of__updateRowSource_10() { return &____updateRowSource_10; }
	inline void set__updateRowSource_10(int32_t value)
	{
		____updateRowSource_10 = value;
	}

	inline static int32_t get_offset_of__parameterCollection_11() { return static_cast<int32_t>(offsetof(SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365, ____parameterCollection_11)); }
	inline SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * get__parameterCollection_11() const { return ____parameterCollection_11; }
	inline SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 ** get_address_of__parameterCollection_11() { return &____parameterCollection_11; }
	inline void set__parameterCollection_11(SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * value)
	{
		____parameterCollection_11 = value;
		Il2CppCodeGenWriteBarrier((&____parameterCollection_11), value);
	}

	inline static int32_t get_offset_of__statementList_12() { return static_cast<int32_t>(offsetof(SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365, ____statementList_12)); }
	inline List_1_t061A89EAEE080F1782627C91C598BD546671C91A * get__statementList_12() const { return ____statementList_12; }
	inline List_1_t061A89EAEE080F1782627C91C598BD546671C91A ** get_address_of__statementList_12() { return &____statementList_12; }
	inline void set__statementList_12(List_1_t061A89EAEE080F1782627C91C598BD546671C91A * value)
	{
		____statementList_12 = value;
		Il2CppCodeGenWriteBarrier((&____statementList_12), value);
	}

	inline static int32_t get_offset_of__remainingText_13() { return static_cast<int32_t>(offsetof(SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365, ____remainingText_13)); }
	inline String_t* get__remainingText_13() const { return ____remainingText_13; }
	inline String_t** get_address_of__remainingText_13() { return &____remainingText_13; }
	inline void set__remainingText_13(String_t* value)
	{
		____remainingText_13 = value;
		Il2CppCodeGenWriteBarrier((&____remainingText_13), value);
	}

	inline static int32_t get_offset_of__transaction_14() { return static_cast<int32_t>(offsetof(SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365, ____transaction_14)); }
	inline SqliteTransaction_t588D1AEC987A56478BF3B4254D6F83A4740F1560 * get__transaction_14() const { return ____transaction_14; }
	inline SqliteTransaction_t588D1AEC987A56478BF3B4254D6F83A4740F1560 ** get_address_of__transaction_14() { return &____transaction_14; }
	inline void set__transaction_14(SqliteTransaction_t588D1AEC987A56478BF3B4254D6F83A4740F1560 * value)
	{
		____transaction_14 = value;
		Il2CppCodeGenWriteBarrier((&____transaction_14), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SQLITECOMMAND_T200B8B48F8FC6F3537B5CC4C7D325708EE696365_H
#ifndef SQLITECONNECTION_T655FF6D5EC3B19CBB105B23F15A3611D086F8CC2_H
#define SQLITECONNECTION_T655FF6D5EC3B19CBB105B23F15A3611D086F8CC2_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.SqliteConnection
struct  SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2  : public DbConnection_tBCDED104D8D1B6EB4ED87AB6845D3ACF18C9807E
{
public:
	// System.Data.ConnectionState Mono.Data.Sqlite.SqliteConnection::_connectionState
	int32_t ____connectionState_4;
	// System.String Mono.Data.Sqlite.SqliteConnection::_connectionString
	String_t* ____connectionString_5;
	// System.Int32 Mono.Data.Sqlite.SqliteConnection::_transactionLevel
	int32_t ____transactionLevel_6;
	// System.Data.IsolationLevel Mono.Data.Sqlite.SqliteConnection::_defaultIsolation
	int32_t ____defaultIsolation_7;
	// Mono.Data.Sqlite.SQLiteEnlistment Mono.Data.Sqlite.SqliteConnection::_enlistment
	SQLiteEnlistment_t67F908A6773D493F8205DF68972AABB98085B494 * ____enlistment_8;
	// Mono.Data.Sqlite.SQLiteBase Mono.Data.Sqlite.SqliteConnection::_sql
	SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * ____sql_9;
	// System.String Mono.Data.Sqlite.SqliteConnection::_dataSource
	String_t* ____dataSource_10;
	// System.Byte[] Mono.Data.Sqlite.SqliteConnection::_password
	ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ____password_11;
	// System.Int32 Mono.Data.Sqlite.SqliteConnection::_defaultTimeout
	int32_t ____defaultTimeout_12;
	// System.Boolean Mono.Data.Sqlite.SqliteConnection::_binaryGuid
	bool ____binaryGuid_13;
	// System.Int64 Mono.Data.Sqlite.SqliteConnection::_version
	int64_t ____version_14;
	// Mono.Data.Sqlite.SQLiteUpdateCallback Mono.Data.Sqlite.SqliteConnection::_updateCallback
	SQLiteUpdateCallback_t3252735A38A0D75E6E9CB742FBFB194CD942712F * ____updateCallback_15;
	// Mono.Data.Sqlite.SQLiteCommitCallback Mono.Data.Sqlite.SqliteConnection::_commitCallback
	SQLiteCommitCallback_t4A2F244F9FCADC58BAEFCDB1F9A4AEA018294B4F * ____commitCallback_16;
	// Mono.Data.Sqlite.SQLiteRollbackCallback Mono.Data.Sqlite.SqliteConnection::_rollbackCallback
	SQLiteRollbackCallback_t0879E30A50B184087AFBA2EC348DAF30A4646D8A * ____rollbackCallback_17;
	// Mono.Data.Sqlite.SQLiteUpdateEventHandler Mono.Data.Sqlite.SqliteConnection::_updateHandler
	SQLiteUpdateEventHandler_t36E8A27FD858F0A7228A1E41FB87DD693D3C4AC8 * ____updateHandler_18;
	// Mono.Data.Sqlite.SQLiteCommitHandler Mono.Data.Sqlite.SqliteConnection::_commitHandler
	SQLiteCommitHandler_t52225EF37741FF54E821E0BB250CF29BC4C4D97E * ____commitHandler_19;
	// System.EventHandler Mono.Data.Sqlite.SqliteConnection::_rollbackHandler
	EventHandler_t2B84E745E28BA26C49C4E99A387FC3B534D1110C * ____rollbackHandler_20;
	// System.Data.StateChangeEventHandler Mono.Data.Sqlite.SqliteConnection::StateChange
	StateChangeEventHandler_tCBE614D6F8C0E81076DE3A3368E258B6F1B1C6F1 * ___StateChange_21;

public:
	inline static int32_t get_offset_of__connectionState_4() { return static_cast<int32_t>(offsetof(SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2, ____connectionState_4)); }
	inline int32_t get__connectionState_4() const { return ____connectionState_4; }
	inline int32_t* get_address_of__connectionState_4() { return &____connectionState_4; }
	inline void set__connectionState_4(int32_t value)
	{
		____connectionState_4 = value;
	}

	inline static int32_t get_offset_of__connectionString_5() { return static_cast<int32_t>(offsetof(SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2, ____connectionString_5)); }
	inline String_t* get__connectionString_5() const { return ____connectionString_5; }
	inline String_t** get_address_of__connectionString_5() { return &____connectionString_5; }
	inline void set__connectionString_5(String_t* value)
	{
		____connectionString_5 = value;
		Il2CppCodeGenWriteBarrier((&____connectionString_5), value);
	}

	inline static int32_t get_offset_of__transactionLevel_6() { return static_cast<int32_t>(offsetof(SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2, ____transactionLevel_6)); }
	inline int32_t get__transactionLevel_6() const { return ____transactionLevel_6; }
	inline int32_t* get_address_of__transactionLevel_6() { return &____transactionLevel_6; }
	inline void set__transactionLevel_6(int32_t value)
	{
		____transactionLevel_6 = value;
	}

	inline static int32_t get_offset_of__defaultIsolation_7() { return static_cast<int32_t>(offsetof(SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2, ____defaultIsolation_7)); }
	inline int32_t get__defaultIsolation_7() const { return ____defaultIsolation_7; }
	inline int32_t* get_address_of__defaultIsolation_7() { return &____defaultIsolation_7; }
	inline void set__defaultIsolation_7(int32_t value)
	{
		____defaultIsolation_7 = value;
	}

	inline static int32_t get_offset_of__enlistment_8() { return static_cast<int32_t>(offsetof(SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2, ____enlistment_8)); }
	inline SQLiteEnlistment_t67F908A6773D493F8205DF68972AABB98085B494 * get__enlistment_8() const { return ____enlistment_8; }
	inline SQLiteEnlistment_t67F908A6773D493F8205DF68972AABB98085B494 ** get_address_of__enlistment_8() { return &____enlistment_8; }
	inline void set__enlistment_8(SQLiteEnlistment_t67F908A6773D493F8205DF68972AABB98085B494 * value)
	{
		____enlistment_8 = value;
		Il2CppCodeGenWriteBarrier((&____enlistment_8), value);
	}

	inline static int32_t get_offset_of__sql_9() { return static_cast<int32_t>(offsetof(SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2, ____sql_9)); }
	inline SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * get__sql_9() const { return ____sql_9; }
	inline SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 ** get_address_of__sql_9() { return &____sql_9; }
	inline void set__sql_9(SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * value)
	{
		____sql_9 = value;
		Il2CppCodeGenWriteBarrier((&____sql_9), value);
	}

	inline static int32_t get_offset_of__dataSource_10() { return static_cast<int32_t>(offsetof(SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2, ____dataSource_10)); }
	inline String_t* get__dataSource_10() const { return ____dataSource_10; }
	inline String_t** get_address_of__dataSource_10() { return &____dataSource_10; }
	inline void set__dataSource_10(String_t* value)
	{
		____dataSource_10 = value;
		Il2CppCodeGenWriteBarrier((&____dataSource_10), value);
	}

	inline static int32_t get_offset_of__password_11() { return static_cast<int32_t>(offsetof(SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2, ____password_11)); }
	inline ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* get__password_11() const { return ____password_11; }
	inline ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821** get_address_of__password_11() { return &____password_11; }
	inline void set__password_11(ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* value)
	{
		____password_11 = value;
		Il2CppCodeGenWriteBarrier((&____password_11), value);
	}

	inline static int32_t get_offset_of__defaultTimeout_12() { return static_cast<int32_t>(offsetof(SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2, ____defaultTimeout_12)); }
	inline int32_t get__defaultTimeout_12() const { return ____defaultTimeout_12; }
	inline int32_t* get_address_of__defaultTimeout_12() { return &____defaultTimeout_12; }
	inline void set__defaultTimeout_12(int32_t value)
	{
		____defaultTimeout_12 = value;
	}

	inline static int32_t get_offset_of__binaryGuid_13() { return static_cast<int32_t>(offsetof(SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2, ____binaryGuid_13)); }
	inline bool get__binaryGuid_13() const { return ____binaryGuid_13; }
	inline bool* get_address_of__binaryGuid_13() { return &____binaryGuid_13; }
	inline void set__binaryGuid_13(bool value)
	{
		____binaryGuid_13 = value;
	}

	inline static int32_t get_offset_of__version_14() { return static_cast<int32_t>(offsetof(SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2, ____version_14)); }
	inline int64_t get__version_14() const { return ____version_14; }
	inline int64_t* get_address_of__version_14() { return &____version_14; }
	inline void set__version_14(int64_t value)
	{
		____version_14 = value;
	}

	inline static int32_t get_offset_of__updateCallback_15() { return static_cast<int32_t>(offsetof(SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2, ____updateCallback_15)); }
	inline SQLiteUpdateCallback_t3252735A38A0D75E6E9CB742FBFB194CD942712F * get__updateCallback_15() const { return ____updateCallback_15; }
	inline SQLiteUpdateCallback_t3252735A38A0D75E6E9CB742FBFB194CD942712F ** get_address_of__updateCallback_15() { return &____updateCallback_15; }
	inline void set__updateCallback_15(SQLiteUpdateCallback_t3252735A38A0D75E6E9CB742FBFB194CD942712F * value)
	{
		____updateCallback_15 = value;
		Il2CppCodeGenWriteBarrier((&____updateCallback_15), value);
	}

	inline static int32_t get_offset_of__commitCallback_16() { return static_cast<int32_t>(offsetof(SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2, ____commitCallback_16)); }
	inline SQLiteCommitCallback_t4A2F244F9FCADC58BAEFCDB1F9A4AEA018294B4F * get__commitCallback_16() const { return ____commitCallback_16; }
	inline SQLiteCommitCallback_t4A2F244F9FCADC58BAEFCDB1F9A4AEA018294B4F ** get_address_of__commitCallback_16() { return &____commitCallback_16; }
	inline void set__commitCallback_16(SQLiteCommitCallback_t4A2F244F9FCADC58BAEFCDB1F9A4AEA018294B4F * value)
	{
		____commitCallback_16 = value;
		Il2CppCodeGenWriteBarrier((&____commitCallback_16), value);
	}

	inline static int32_t get_offset_of__rollbackCallback_17() { return static_cast<int32_t>(offsetof(SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2, ____rollbackCallback_17)); }
	inline SQLiteRollbackCallback_t0879E30A50B184087AFBA2EC348DAF30A4646D8A * get__rollbackCallback_17() const { return ____rollbackCallback_17; }
	inline SQLiteRollbackCallback_t0879E30A50B184087AFBA2EC348DAF30A4646D8A ** get_address_of__rollbackCallback_17() { return &____rollbackCallback_17; }
	inline void set__rollbackCallback_17(SQLiteRollbackCallback_t0879E30A50B184087AFBA2EC348DAF30A4646D8A * value)
	{
		____rollbackCallback_17 = value;
		Il2CppCodeGenWriteBarrier((&____rollbackCallback_17), value);
	}

	inline static int32_t get_offset_of__updateHandler_18() { return static_cast<int32_t>(offsetof(SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2, ____updateHandler_18)); }
	inline SQLiteUpdateEventHandler_t36E8A27FD858F0A7228A1E41FB87DD693D3C4AC8 * get__updateHandler_18() const { return ____updateHandler_18; }
	inline SQLiteUpdateEventHandler_t36E8A27FD858F0A7228A1E41FB87DD693D3C4AC8 ** get_address_of__updateHandler_18() { return &____updateHandler_18; }
	inline void set__updateHandler_18(SQLiteUpdateEventHandler_t36E8A27FD858F0A7228A1E41FB87DD693D3C4AC8 * value)
	{
		____updateHandler_18 = value;
		Il2CppCodeGenWriteBarrier((&____updateHandler_18), value);
	}

	inline static int32_t get_offset_of__commitHandler_19() { return static_cast<int32_t>(offsetof(SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2, ____commitHandler_19)); }
	inline SQLiteCommitHandler_t52225EF37741FF54E821E0BB250CF29BC4C4D97E * get__commitHandler_19() const { return ____commitHandler_19; }
	inline SQLiteCommitHandler_t52225EF37741FF54E821E0BB250CF29BC4C4D97E ** get_address_of__commitHandler_19() { return &____commitHandler_19; }
	inline void set__commitHandler_19(SQLiteCommitHandler_t52225EF37741FF54E821E0BB250CF29BC4C4D97E * value)
	{
		____commitHandler_19 = value;
		Il2CppCodeGenWriteBarrier((&____commitHandler_19), value);
	}

	inline static int32_t get_offset_of__rollbackHandler_20() { return static_cast<int32_t>(offsetof(SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2, ____rollbackHandler_20)); }
	inline EventHandler_t2B84E745E28BA26C49C4E99A387FC3B534D1110C * get__rollbackHandler_20() const { return ____rollbackHandler_20; }
	inline EventHandler_t2B84E745E28BA26C49C4E99A387FC3B534D1110C ** get_address_of__rollbackHandler_20() { return &____rollbackHandler_20; }
	inline void set__rollbackHandler_20(EventHandler_t2B84E745E28BA26C49C4E99A387FC3B534D1110C * value)
	{
		____rollbackHandler_20 = value;
		Il2CppCodeGenWriteBarrier((&____rollbackHandler_20), value);
	}

	inline static int32_t get_offset_of_StateChange_21() { return static_cast<int32_t>(offsetof(SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2, ___StateChange_21)); }
	inline StateChangeEventHandler_tCBE614D6F8C0E81076DE3A3368E258B6F1B1C6F1 * get_StateChange_21() const { return ___StateChange_21; }
	inline StateChangeEventHandler_tCBE614D6F8C0E81076DE3A3368E258B6F1B1C6F1 ** get_address_of_StateChange_21() { return &___StateChange_21; }
	inline void set_StateChange_21(StateChangeEventHandler_tCBE614D6F8C0E81076DE3A3368E258B6F1B1C6F1 * value)
	{
		___StateChange_21 = value;
		Il2CppCodeGenWriteBarrier((&___StateChange_21), value);
	}
};

struct SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2_StaticFields
{
public:
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> Mono.Data.Sqlite.SqliteConnection::<>f__switchU24map1
	Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB * ___U3CU3Ef__switchU24map1_22;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> Mono.Data.Sqlite.SqliteConnection::<>f__switchU24map2
	Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB * ___U3CU3Ef__switchU24map2_23;

public:
	inline static int32_t get_offset_of_U3CU3Ef__switchU24map1_22() { return static_cast<int32_t>(offsetof(SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2_StaticFields, ___U3CU3Ef__switchU24map1_22)); }
	inline Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB * get_U3CU3Ef__switchU24map1_22() const { return ___U3CU3Ef__switchU24map1_22; }
	inline Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB ** get_address_of_U3CU3Ef__switchU24map1_22() { return &___U3CU3Ef__switchU24map1_22; }
	inline void set_U3CU3Ef__switchU24map1_22(Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB * value)
	{
		___U3CU3Ef__switchU24map1_22 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__switchU24map1_22), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__switchU24map2_23() { return static_cast<int32_t>(offsetof(SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2_StaticFields, ___U3CU3Ef__switchU24map2_23)); }
	inline Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB * get_U3CU3Ef__switchU24map2_23() const { return ___U3CU3Ef__switchU24map2_23; }
	inline Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB ** get_address_of_U3CU3Ef__switchU24map2_23() { return &___U3CU3Ef__switchU24map2_23; }
	inline void set_U3CU3Ef__switchU24map2_23(Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB * value)
	{
		___U3CU3Ef__switchU24map2_23 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__switchU24map2_23), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SQLITECONNECTION_T655FF6D5EC3B19CBB105B23F15A3611D086F8CC2_H
#ifndef SQLITECONVERT_T9FED20EF4CA9E373EBD857ECBA9C74B6307EE6E7_H
#define SQLITECONVERT_T9FED20EF4CA9E373EBD857ECBA9C74B6307EE6E7_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.SqliteConvert
struct  SqliteConvert_t9FED20EF4CA9E373EBD857ECBA9C74B6307EE6E7  : public RuntimeObject
{
public:
	// Mono.Data.Sqlite.SQLiteDateFormats Mono.Data.Sqlite.SqliteConvert::_datetimeFormat
	int32_t ____datetimeFormat_2;

public:
	inline static int32_t get_offset_of__datetimeFormat_2() { return static_cast<int32_t>(offsetof(SqliteConvert_t9FED20EF4CA9E373EBD857ECBA9C74B6307EE6E7, ____datetimeFormat_2)); }
	inline int32_t get__datetimeFormat_2() const { return ____datetimeFormat_2; }
	inline int32_t* get_address_of__datetimeFormat_2() { return &____datetimeFormat_2; }
	inline void set__datetimeFormat_2(int32_t value)
	{
		____datetimeFormat_2 = value;
	}
};

struct SqliteConvert_t9FED20EF4CA9E373EBD857ECBA9C74B6307EE6E7_StaticFields
{
public:
	// System.String[] Mono.Data.Sqlite.SqliteConvert::_datetimeFormats
	StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* ____datetimeFormats_0;
	// System.Text.Encoding Mono.Data.Sqlite.SqliteConvert::_utf8
	Encoding_t7837A3C0F55EAE0E3959A53C6D6E88B113ED78A4 * ____utf8_1;
	// System.Type[] Mono.Data.Sqlite.SqliteConvert::_affinitytotype
	TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F* ____affinitytotype_3;
	// System.Data.DbType[] Mono.Data.Sqlite.SqliteConvert::_typetodbtype
	DbTypeU5BU5D_tD00A0B946DB9A3654BCF020D2E36A47C1DE81DB3* ____typetodbtype_4;
	// System.Int32[] Mono.Data.Sqlite.SqliteConvert::_dbtypetocolumnsize
	Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* ____dbtypetocolumnsize_5;
	// System.Object[] Mono.Data.Sqlite.SqliteConvert::_dbtypetonumericprecision
	ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* ____dbtypetonumericprecision_6;
	// System.Object[] Mono.Data.Sqlite.SqliteConvert::_dbtypetonumericscale
	ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* ____dbtypetonumericscale_7;
	// Mono.Data.Sqlite.SQLiteTypeNames[] Mono.Data.Sqlite.SqliteConvert::_dbtypeNames
	SQLiteTypeNamesU5BU5D_t8BB731A7E5681259586D843C75AA295972D1D5EA* ____dbtypeNames_8;
	// System.Type[] Mono.Data.Sqlite.SqliteConvert::_dbtypeToType
	TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F* ____dbtypeToType_9;
	// Mono.Data.Sqlite.TypeAffinity[] Mono.Data.Sqlite.SqliteConvert::_typecodeAffinities
	TypeAffinityU5BU5D_t6635EBE59009DFC162BD783072F772B336F3A288* ____typecodeAffinities_10;
	// Mono.Data.Sqlite.SQLiteTypeNames[] Mono.Data.Sqlite.SqliteConvert::_typeNames
	SQLiteTypeNamesU5BU5D_t8BB731A7E5681259586D843C75AA295972D1D5EA* ____typeNames_11;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> Mono.Data.Sqlite.SqliteConvert::<>f__switchU24map0
	Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB * ___U3CU3Ef__switchU24map0_12;

public:
	inline static int32_t get_offset_of__datetimeFormats_0() { return static_cast<int32_t>(offsetof(SqliteConvert_t9FED20EF4CA9E373EBD857ECBA9C74B6307EE6E7_StaticFields, ____datetimeFormats_0)); }
	inline StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* get__datetimeFormats_0() const { return ____datetimeFormats_0; }
	inline StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E** get_address_of__datetimeFormats_0() { return &____datetimeFormats_0; }
	inline void set__datetimeFormats_0(StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* value)
	{
		____datetimeFormats_0 = value;
		Il2CppCodeGenWriteBarrier((&____datetimeFormats_0), value);
	}

	inline static int32_t get_offset_of__utf8_1() { return static_cast<int32_t>(offsetof(SqliteConvert_t9FED20EF4CA9E373EBD857ECBA9C74B6307EE6E7_StaticFields, ____utf8_1)); }
	inline Encoding_t7837A3C0F55EAE0E3959A53C6D6E88B113ED78A4 * get__utf8_1() const { return ____utf8_1; }
	inline Encoding_t7837A3C0F55EAE0E3959A53C6D6E88B113ED78A4 ** get_address_of__utf8_1() { return &____utf8_1; }
	inline void set__utf8_1(Encoding_t7837A3C0F55EAE0E3959A53C6D6E88B113ED78A4 * value)
	{
		____utf8_1 = value;
		Il2CppCodeGenWriteBarrier((&____utf8_1), value);
	}

	inline static int32_t get_offset_of__affinitytotype_3() { return static_cast<int32_t>(offsetof(SqliteConvert_t9FED20EF4CA9E373EBD857ECBA9C74B6307EE6E7_StaticFields, ____affinitytotype_3)); }
	inline TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F* get__affinitytotype_3() const { return ____affinitytotype_3; }
	inline TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F** get_address_of__affinitytotype_3() { return &____affinitytotype_3; }
	inline void set__affinitytotype_3(TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F* value)
	{
		____affinitytotype_3 = value;
		Il2CppCodeGenWriteBarrier((&____affinitytotype_3), value);
	}

	inline static int32_t get_offset_of__typetodbtype_4() { return static_cast<int32_t>(offsetof(SqliteConvert_t9FED20EF4CA9E373EBD857ECBA9C74B6307EE6E7_StaticFields, ____typetodbtype_4)); }
	inline DbTypeU5BU5D_tD00A0B946DB9A3654BCF020D2E36A47C1DE81DB3* get__typetodbtype_4() const { return ____typetodbtype_4; }
	inline DbTypeU5BU5D_tD00A0B946DB9A3654BCF020D2E36A47C1DE81DB3** get_address_of__typetodbtype_4() { return &____typetodbtype_4; }
	inline void set__typetodbtype_4(DbTypeU5BU5D_tD00A0B946DB9A3654BCF020D2E36A47C1DE81DB3* value)
	{
		____typetodbtype_4 = value;
		Il2CppCodeGenWriteBarrier((&____typetodbtype_4), value);
	}

	inline static int32_t get_offset_of__dbtypetocolumnsize_5() { return static_cast<int32_t>(offsetof(SqliteConvert_t9FED20EF4CA9E373EBD857ECBA9C74B6307EE6E7_StaticFields, ____dbtypetocolumnsize_5)); }
	inline Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* get__dbtypetocolumnsize_5() const { return ____dbtypetocolumnsize_5; }
	inline Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83** get_address_of__dbtypetocolumnsize_5() { return &____dbtypetocolumnsize_5; }
	inline void set__dbtypetocolumnsize_5(Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* value)
	{
		____dbtypetocolumnsize_5 = value;
		Il2CppCodeGenWriteBarrier((&____dbtypetocolumnsize_5), value);
	}

	inline static int32_t get_offset_of__dbtypetonumericprecision_6() { return static_cast<int32_t>(offsetof(SqliteConvert_t9FED20EF4CA9E373EBD857ECBA9C74B6307EE6E7_StaticFields, ____dbtypetonumericprecision_6)); }
	inline ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* get__dbtypetonumericprecision_6() const { return ____dbtypetonumericprecision_6; }
	inline ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A** get_address_of__dbtypetonumericprecision_6() { return &____dbtypetonumericprecision_6; }
	inline void set__dbtypetonumericprecision_6(ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* value)
	{
		____dbtypetonumericprecision_6 = value;
		Il2CppCodeGenWriteBarrier((&____dbtypetonumericprecision_6), value);
	}

	inline static int32_t get_offset_of__dbtypetonumericscale_7() { return static_cast<int32_t>(offsetof(SqliteConvert_t9FED20EF4CA9E373EBD857ECBA9C74B6307EE6E7_StaticFields, ____dbtypetonumericscale_7)); }
	inline ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* get__dbtypetonumericscale_7() const { return ____dbtypetonumericscale_7; }
	inline ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A** get_address_of__dbtypetonumericscale_7() { return &____dbtypetonumericscale_7; }
	inline void set__dbtypetonumericscale_7(ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* value)
	{
		____dbtypetonumericscale_7 = value;
		Il2CppCodeGenWriteBarrier((&____dbtypetonumericscale_7), value);
	}

	inline static int32_t get_offset_of__dbtypeNames_8() { return static_cast<int32_t>(offsetof(SqliteConvert_t9FED20EF4CA9E373EBD857ECBA9C74B6307EE6E7_StaticFields, ____dbtypeNames_8)); }
	inline SQLiteTypeNamesU5BU5D_t8BB731A7E5681259586D843C75AA295972D1D5EA* get__dbtypeNames_8() const { return ____dbtypeNames_8; }
	inline SQLiteTypeNamesU5BU5D_t8BB731A7E5681259586D843C75AA295972D1D5EA** get_address_of__dbtypeNames_8() { return &____dbtypeNames_8; }
	inline void set__dbtypeNames_8(SQLiteTypeNamesU5BU5D_t8BB731A7E5681259586D843C75AA295972D1D5EA* value)
	{
		____dbtypeNames_8 = value;
		Il2CppCodeGenWriteBarrier((&____dbtypeNames_8), value);
	}

	inline static int32_t get_offset_of__dbtypeToType_9() { return static_cast<int32_t>(offsetof(SqliteConvert_t9FED20EF4CA9E373EBD857ECBA9C74B6307EE6E7_StaticFields, ____dbtypeToType_9)); }
	inline TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F* get__dbtypeToType_9() const { return ____dbtypeToType_9; }
	inline TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F** get_address_of__dbtypeToType_9() { return &____dbtypeToType_9; }
	inline void set__dbtypeToType_9(TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F* value)
	{
		____dbtypeToType_9 = value;
		Il2CppCodeGenWriteBarrier((&____dbtypeToType_9), value);
	}

	inline static int32_t get_offset_of__typecodeAffinities_10() { return static_cast<int32_t>(offsetof(SqliteConvert_t9FED20EF4CA9E373EBD857ECBA9C74B6307EE6E7_StaticFields, ____typecodeAffinities_10)); }
	inline TypeAffinityU5BU5D_t6635EBE59009DFC162BD783072F772B336F3A288* get__typecodeAffinities_10() const { return ____typecodeAffinities_10; }
	inline TypeAffinityU5BU5D_t6635EBE59009DFC162BD783072F772B336F3A288** get_address_of__typecodeAffinities_10() { return &____typecodeAffinities_10; }
	inline void set__typecodeAffinities_10(TypeAffinityU5BU5D_t6635EBE59009DFC162BD783072F772B336F3A288* value)
	{
		____typecodeAffinities_10 = value;
		Il2CppCodeGenWriteBarrier((&____typecodeAffinities_10), value);
	}

	inline static int32_t get_offset_of__typeNames_11() { return static_cast<int32_t>(offsetof(SqliteConvert_t9FED20EF4CA9E373EBD857ECBA9C74B6307EE6E7_StaticFields, ____typeNames_11)); }
	inline SQLiteTypeNamesU5BU5D_t8BB731A7E5681259586D843C75AA295972D1D5EA* get__typeNames_11() const { return ____typeNames_11; }
	inline SQLiteTypeNamesU5BU5D_t8BB731A7E5681259586D843C75AA295972D1D5EA** get_address_of__typeNames_11() { return &____typeNames_11; }
	inline void set__typeNames_11(SQLiteTypeNamesU5BU5D_t8BB731A7E5681259586D843C75AA295972D1D5EA* value)
	{
		____typeNames_11 = value;
		Il2CppCodeGenWriteBarrier((&____typeNames_11), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__switchU24map0_12() { return static_cast<int32_t>(offsetof(SqliteConvert_t9FED20EF4CA9E373EBD857ECBA9C74B6307EE6E7_StaticFields, ___U3CU3Ef__switchU24map0_12)); }
	inline Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB * get_U3CU3Ef__switchU24map0_12() const { return ___U3CU3Ef__switchU24map0_12; }
	inline Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB ** get_address_of_U3CU3Ef__switchU24map0_12() { return &___U3CU3Ef__switchU24map0_12; }
	inline void set_U3CU3Ef__switchU24map0_12(Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB * value)
	{
		___U3CU3Ef__switchU24map0_12 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__switchU24map0_12), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SQLITECONVERT_T9FED20EF4CA9E373EBD857ECBA9C74B6307EE6E7_H
#ifndef SQLITEDATAREADER_TFBE37A0F795AE78E5F4AAF7388AA05582CE90D69_H
#define SQLITEDATAREADER_TFBE37A0F795AE78E5F4AAF7388AA05582CE90D69_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.SqliteDataReader
struct  SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69  : public DbDataReader_t4CADA7880D6F85CABC4096FA5AE10C327A07CCD8
{
public:
	// Mono.Data.Sqlite.SqliteCommand Mono.Data.Sqlite.SqliteDataReader::_command
	SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * ____command_1;
	// System.Int32 Mono.Data.Sqlite.SqliteDataReader::_activeStatementIndex
	int32_t ____activeStatementIndex_2;
	// Mono.Data.Sqlite.SqliteStatement Mono.Data.Sqlite.SqliteDataReader::_activeStatement
	SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * ____activeStatement_3;
	// System.Int32 Mono.Data.Sqlite.SqliteDataReader::_readingState
	int32_t ____readingState_4;
	// System.Int32 Mono.Data.Sqlite.SqliteDataReader::_rowsAffected
	int32_t ____rowsAffected_5;
	// System.Int32 Mono.Data.Sqlite.SqliteDataReader::_fieldCount
	int32_t ____fieldCount_6;
	// Mono.Data.Sqlite.SQLiteType[] Mono.Data.Sqlite.SqliteDataReader::_fieldTypeArray
	SQLiteTypeU5BU5D_tE231A43BBC9182DD6A96128D1840BD3FD4440644* ____fieldTypeArray_7;
	// System.Data.CommandBehavior Mono.Data.Sqlite.SqliteDataReader::_commandBehavior
	int32_t ____commandBehavior_8;
	// System.Boolean Mono.Data.Sqlite.SqliteDataReader::_disposeCommand
	bool ____disposeCommand_9;
	// Mono.Data.Sqlite.SqliteKeyReader Mono.Data.Sqlite.SqliteDataReader::_keyInfo
	SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793 * ____keyInfo_10;
	// System.Int64 Mono.Data.Sqlite.SqliteDataReader::_version
	int64_t ____version_11;

public:
	inline static int32_t get_offset_of__command_1() { return static_cast<int32_t>(offsetof(SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69, ____command_1)); }
	inline SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * get__command_1() const { return ____command_1; }
	inline SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 ** get_address_of__command_1() { return &____command_1; }
	inline void set__command_1(SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * value)
	{
		____command_1 = value;
		Il2CppCodeGenWriteBarrier((&____command_1), value);
	}

	inline static int32_t get_offset_of__activeStatementIndex_2() { return static_cast<int32_t>(offsetof(SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69, ____activeStatementIndex_2)); }
	inline int32_t get__activeStatementIndex_2() const { return ____activeStatementIndex_2; }
	inline int32_t* get_address_of__activeStatementIndex_2() { return &____activeStatementIndex_2; }
	inline void set__activeStatementIndex_2(int32_t value)
	{
		____activeStatementIndex_2 = value;
	}

	inline static int32_t get_offset_of__activeStatement_3() { return static_cast<int32_t>(offsetof(SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69, ____activeStatement_3)); }
	inline SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * get__activeStatement_3() const { return ____activeStatement_3; }
	inline SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A ** get_address_of__activeStatement_3() { return &____activeStatement_3; }
	inline void set__activeStatement_3(SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * value)
	{
		____activeStatement_3 = value;
		Il2CppCodeGenWriteBarrier((&____activeStatement_3), value);
	}

	inline static int32_t get_offset_of__readingState_4() { return static_cast<int32_t>(offsetof(SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69, ____readingState_4)); }
	inline int32_t get__readingState_4() const { return ____readingState_4; }
	inline int32_t* get_address_of__readingState_4() { return &____readingState_4; }
	inline void set__readingState_4(int32_t value)
	{
		____readingState_4 = value;
	}

	inline static int32_t get_offset_of__rowsAffected_5() { return static_cast<int32_t>(offsetof(SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69, ____rowsAffected_5)); }
	inline int32_t get__rowsAffected_5() const { return ____rowsAffected_5; }
	inline int32_t* get_address_of__rowsAffected_5() { return &____rowsAffected_5; }
	inline void set__rowsAffected_5(int32_t value)
	{
		____rowsAffected_5 = value;
	}

	inline static int32_t get_offset_of__fieldCount_6() { return static_cast<int32_t>(offsetof(SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69, ____fieldCount_6)); }
	inline int32_t get__fieldCount_6() const { return ____fieldCount_6; }
	inline int32_t* get_address_of__fieldCount_6() { return &____fieldCount_6; }
	inline void set__fieldCount_6(int32_t value)
	{
		____fieldCount_6 = value;
	}

	inline static int32_t get_offset_of__fieldTypeArray_7() { return static_cast<int32_t>(offsetof(SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69, ____fieldTypeArray_7)); }
	inline SQLiteTypeU5BU5D_tE231A43BBC9182DD6A96128D1840BD3FD4440644* get__fieldTypeArray_7() const { return ____fieldTypeArray_7; }
	inline SQLiteTypeU5BU5D_tE231A43BBC9182DD6A96128D1840BD3FD4440644** get_address_of__fieldTypeArray_7() { return &____fieldTypeArray_7; }
	inline void set__fieldTypeArray_7(SQLiteTypeU5BU5D_tE231A43BBC9182DD6A96128D1840BD3FD4440644* value)
	{
		____fieldTypeArray_7 = value;
		Il2CppCodeGenWriteBarrier((&____fieldTypeArray_7), value);
	}

	inline static int32_t get_offset_of__commandBehavior_8() { return static_cast<int32_t>(offsetof(SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69, ____commandBehavior_8)); }
	inline int32_t get__commandBehavior_8() const { return ____commandBehavior_8; }
	inline int32_t* get_address_of__commandBehavior_8() { return &____commandBehavior_8; }
	inline void set__commandBehavior_8(int32_t value)
	{
		____commandBehavior_8 = value;
	}

	inline static int32_t get_offset_of__disposeCommand_9() { return static_cast<int32_t>(offsetof(SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69, ____disposeCommand_9)); }
	inline bool get__disposeCommand_9() const { return ____disposeCommand_9; }
	inline bool* get_address_of__disposeCommand_9() { return &____disposeCommand_9; }
	inline void set__disposeCommand_9(bool value)
	{
		____disposeCommand_9 = value;
	}

	inline static int32_t get_offset_of__keyInfo_10() { return static_cast<int32_t>(offsetof(SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69, ____keyInfo_10)); }
	inline SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793 * get__keyInfo_10() const { return ____keyInfo_10; }
	inline SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793 ** get_address_of__keyInfo_10() { return &____keyInfo_10; }
	inline void set__keyInfo_10(SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793 * value)
	{
		____keyInfo_10 = value;
		Il2CppCodeGenWriteBarrier((&____keyInfo_10), value);
	}

	inline static int32_t get_offset_of__version_11() { return static_cast<int32_t>(offsetof(SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69, ____version_11)); }
	inline int64_t get__version_11() const { return ____version_11; }
	inline int64_t* get_address_of__version_11() { return &____version_11; }
	inline void set__version_11(int64_t value)
	{
		____version_11 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SQLITEDATAREADER_TFBE37A0F795AE78E5F4AAF7388AA05582CE90D69_H
#ifndef SQLITEFUNCTIONATTRIBUTE_TFD557033F4837262FE7FA08336BA3FB3A9A51DCD_H
#define SQLITEFUNCTIONATTRIBUTE_TFD557033F4837262FE7FA08336BA3FB3A9A51DCD_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.SqliteFunctionAttribute
struct  SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD  : public Attribute_tF048C13FB3C8CFCC53F82290E4A3F621089F9A74
{
public:
	// System.String Mono.Data.Sqlite.SqliteFunctionAttribute::_name
	String_t* ____name_0;
	// System.Int32 Mono.Data.Sqlite.SqliteFunctionAttribute::_arguments
	int32_t ____arguments_1;
	// Mono.Data.Sqlite.FunctionType Mono.Data.Sqlite.SqliteFunctionAttribute::_functionType
	int32_t ____functionType_2;
	// System.Type Mono.Data.Sqlite.SqliteFunctionAttribute::_instanceType
	Type_t * ____instanceType_3;

public:
	inline static int32_t get_offset_of__name_0() { return static_cast<int32_t>(offsetof(SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD, ____name_0)); }
	inline String_t* get__name_0() const { return ____name_0; }
	inline String_t** get_address_of__name_0() { return &____name_0; }
	inline void set__name_0(String_t* value)
	{
		____name_0 = value;
		Il2CppCodeGenWriteBarrier((&____name_0), value);
	}

	inline static int32_t get_offset_of__arguments_1() { return static_cast<int32_t>(offsetof(SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD, ____arguments_1)); }
	inline int32_t get__arguments_1() const { return ____arguments_1; }
	inline int32_t* get_address_of__arguments_1() { return &____arguments_1; }
	inline void set__arguments_1(int32_t value)
	{
		____arguments_1 = value;
	}

	inline static int32_t get_offset_of__functionType_2() { return static_cast<int32_t>(offsetof(SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD, ____functionType_2)); }
	inline int32_t get__functionType_2() const { return ____functionType_2; }
	inline int32_t* get_address_of__functionType_2() { return &____functionType_2; }
	inline void set__functionType_2(int32_t value)
	{
		____functionType_2 = value;
	}

	inline static int32_t get_offset_of__instanceType_3() { return static_cast<int32_t>(offsetof(SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD, ____instanceType_3)); }
	inline Type_t * get__instanceType_3() const { return ____instanceType_3; }
	inline Type_t ** get_address_of__instanceType_3() { return &____instanceType_3; }
	inline void set__instanceType_3(Type_t * value)
	{
		____instanceType_3 = value;
		Il2CppCodeGenWriteBarrier((&____instanceType_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SQLITEFUNCTIONATTRIBUTE_TFD557033F4837262FE7FA08336BA3FB3A9A51DCD_H
#ifndef SQLITEFUNCTIONEX_T7D4B1395222C65E48CBA8BF483FEAEEA24FFC75A_H
#define SQLITEFUNCTIONEX_T7D4B1395222C65E48CBA8BF483FEAEEA24FFC75A_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.SqliteFunctionEx
struct  SqliteFunctionEx_t7D4B1395222C65E48CBA8BF483FEAEEA24FFC75A  : public SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SQLITEFUNCTIONEX_T7D4B1395222C65E48CBA8BF483FEAEEA24FFC75A_H
#ifndef SQLITEPARAMETER_T9FAC2B9C42E405F4AF730D28C70C5A226480B88E_H
#define SQLITEPARAMETER_T9FAC2B9C42E405F4AF730D28C70C5A226480B88E_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.SqliteParameter
struct  SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E  : public DbParameter_tEE5AEAD8B429B8EF8994063C151A25A76B94B76F
{
public:
	// System.Int32 Mono.Data.Sqlite.SqliteParameter::_dbType
	int32_t ____dbType_1;
	// System.Data.DataRowVersion Mono.Data.Sqlite.SqliteParameter::_rowVersion
	int32_t ____rowVersion_2;
	// System.Object Mono.Data.Sqlite.SqliteParameter::_objValue
	RuntimeObject * ____objValue_3;
	// System.String Mono.Data.Sqlite.SqliteParameter::_sourceColumn
	String_t* ____sourceColumn_4;
	// System.String Mono.Data.Sqlite.SqliteParameter::_parameterName
	String_t* ____parameterName_5;
	// System.Int32 Mono.Data.Sqlite.SqliteParameter::_dataSize
	int32_t ____dataSize_6;
	// System.Boolean Mono.Data.Sqlite.SqliteParameter::_nullable
	bool ____nullable_7;
	// System.Boolean Mono.Data.Sqlite.SqliteParameter::_nullMapping
	bool ____nullMapping_8;

public:
	inline static int32_t get_offset_of__dbType_1() { return static_cast<int32_t>(offsetof(SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E, ____dbType_1)); }
	inline int32_t get__dbType_1() const { return ____dbType_1; }
	inline int32_t* get_address_of__dbType_1() { return &____dbType_1; }
	inline void set__dbType_1(int32_t value)
	{
		____dbType_1 = value;
	}

	inline static int32_t get_offset_of__rowVersion_2() { return static_cast<int32_t>(offsetof(SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E, ____rowVersion_2)); }
	inline int32_t get__rowVersion_2() const { return ____rowVersion_2; }
	inline int32_t* get_address_of__rowVersion_2() { return &____rowVersion_2; }
	inline void set__rowVersion_2(int32_t value)
	{
		____rowVersion_2 = value;
	}

	inline static int32_t get_offset_of__objValue_3() { return static_cast<int32_t>(offsetof(SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E, ____objValue_3)); }
	inline RuntimeObject * get__objValue_3() const { return ____objValue_3; }
	inline RuntimeObject ** get_address_of__objValue_3() { return &____objValue_3; }
	inline void set__objValue_3(RuntimeObject * value)
	{
		____objValue_3 = value;
		Il2CppCodeGenWriteBarrier((&____objValue_3), value);
	}

	inline static int32_t get_offset_of__sourceColumn_4() { return static_cast<int32_t>(offsetof(SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E, ____sourceColumn_4)); }
	inline String_t* get__sourceColumn_4() const { return ____sourceColumn_4; }
	inline String_t** get_address_of__sourceColumn_4() { return &____sourceColumn_4; }
	inline void set__sourceColumn_4(String_t* value)
	{
		____sourceColumn_4 = value;
		Il2CppCodeGenWriteBarrier((&____sourceColumn_4), value);
	}

	inline static int32_t get_offset_of__parameterName_5() { return static_cast<int32_t>(offsetof(SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E, ____parameterName_5)); }
	inline String_t* get__parameterName_5() const { return ____parameterName_5; }
	inline String_t** get_address_of__parameterName_5() { return &____parameterName_5; }
	inline void set__parameterName_5(String_t* value)
	{
		____parameterName_5 = value;
		Il2CppCodeGenWriteBarrier((&____parameterName_5), value);
	}

	inline static int32_t get_offset_of__dataSize_6() { return static_cast<int32_t>(offsetof(SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E, ____dataSize_6)); }
	inline int32_t get__dataSize_6() const { return ____dataSize_6; }
	inline int32_t* get_address_of__dataSize_6() { return &____dataSize_6; }
	inline void set__dataSize_6(int32_t value)
	{
		____dataSize_6 = value;
	}

	inline static int32_t get_offset_of__nullable_7() { return static_cast<int32_t>(offsetof(SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E, ____nullable_7)); }
	inline bool get__nullable_7() const { return ____nullable_7; }
	inline bool* get_address_of__nullable_7() { return &____nullable_7; }
	inline void set__nullable_7(bool value)
	{
		____nullable_7 = value;
	}

	inline static int32_t get_offset_of__nullMapping_8() { return static_cast<int32_t>(offsetof(SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E, ____nullMapping_8)); }
	inline bool get__nullMapping_8() const { return ____nullMapping_8; }
	inline bool* get_address_of__nullMapping_8() { return &____nullMapping_8; }
	inline void set__nullMapping_8(bool value)
	{
		____nullMapping_8 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SQLITEPARAMETER_T9FAC2B9C42E405F4AF730D28C70C5A226480B88E_H
#ifndef SQLITESTATEMENTHANDLE_T6121E676E0AB6EA25E9168EB18C7A064E83DBBBE_H
#define SQLITESTATEMENTHANDLE_T6121E676E0AB6EA25E9168EB18C7A064E83DBBBE_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.SqliteStatementHandle
struct  SqliteStatementHandle_t6121E676E0AB6EA25E9168EB18C7A064E83DBBBE  : public CriticalHandle_tDF3AA1D1AA9E07599C316DB1C5449D3FB7BFD4C9
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SQLITESTATEMENTHANDLE_T6121E676E0AB6EA25E9168EB18C7A064E83DBBBE_H
#ifndef SQLITETRANSACTION_T588D1AEC987A56478BF3B4254D6F83A4740F1560_H
#define SQLITETRANSACTION_T588D1AEC987A56478BF3B4254D6F83A4740F1560_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.SqliteTransaction
struct  SqliteTransaction_t588D1AEC987A56478BF3B4254D6F83A4740F1560  : public DbTransaction_tADC1A857259448190F882AC47E0B18317779FE56
{
public:
	// Mono.Data.Sqlite.SqliteConnection Mono.Data.Sqlite.SqliteTransaction::_cnn
	SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * ____cnn_1;
	// System.Int64 Mono.Data.Sqlite.SqliteTransaction::_version
	int64_t ____version_2;
	// System.Data.IsolationLevel Mono.Data.Sqlite.SqliteTransaction::_level
	int32_t ____level_3;

public:
	inline static int32_t get_offset_of__cnn_1() { return static_cast<int32_t>(offsetof(SqliteTransaction_t588D1AEC987A56478BF3B4254D6F83A4740F1560, ____cnn_1)); }
	inline SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * get__cnn_1() const { return ____cnn_1; }
	inline SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 ** get_address_of__cnn_1() { return &____cnn_1; }
	inline void set__cnn_1(SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * value)
	{
		____cnn_1 = value;
		Il2CppCodeGenWriteBarrier((&____cnn_1), value);
	}

	inline static int32_t get_offset_of__version_2() { return static_cast<int32_t>(offsetof(SqliteTransaction_t588D1AEC987A56478BF3B4254D6F83A4740F1560, ____version_2)); }
	inline int64_t get__version_2() const { return ____version_2; }
	inline int64_t* get_address_of__version_2() { return &____version_2; }
	inline void set__version_2(int64_t value)
	{
		____version_2 = value;
	}

	inline static int32_t get_offset_of__level_3() { return static_cast<int32_t>(offsetof(SqliteTransaction_t588D1AEC987A56478BF3B4254D6F83A4740F1560, ____level_3)); }
	inline int32_t get__level_3() const { return ____level_3; }
	inline int32_t* get_address_of__level_3() { return &____level_3; }
	inline void set__level_3(int32_t value)
	{
		____level_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SQLITETRANSACTION_T588D1AEC987A56478BF3B4254D6F83A4740F1560_H
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
#ifndef ARGUMENTOUTOFRANGEEXCEPTION_T94D19DF918A54511AEDF4784C9A08741BAD1DEDA_H
#define ARGUMENTOUTOFRANGEEXCEPTION_T94D19DF918A54511AEDF4784C9A08741BAD1DEDA_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ArgumentOutOfRangeException
struct  ArgumentOutOfRangeException_t94D19DF918A54511AEDF4784C9A08741BAD1DEDA  : public ArgumentException_tEDCD16F20A09ECE461C3DA766C16EDA8864057D1
{
public:
	// System.Object System.ArgumentOutOfRangeException::m_actualValue
	RuntimeObject * ___m_actualValue_19;

public:
	inline static int32_t get_offset_of_m_actualValue_19() { return static_cast<int32_t>(offsetof(ArgumentOutOfRangeException_t94D19DF918A54511AEDF4784C9A08741BAD1DEDA, ___m_actualValue_19)); }
	inline RuntimeObject * get_m_actualValue_19() const { return ___m_actualValue_19; }
	inline RuntimeObject ** get_address_of_m_actualValue_19() { return &___m_actualValue_19; }
	inline void set_m_actualValue_19(RuntimeObject * value)
	{
		___m_actualValue_19 = value;
		Il2CppCodeGenWriteBarrier((&___m_actualValue_19), value);
	}
};

struct ArgumentOutOfRangeException_t94D19DF918A54511AEDF4784C9A08741BAD1DEDA_StaticFields
{
public:
	// System.String modreq(System.Runtime.CompilerServices.IsVolatile) System.ArgumentOutOfRangeException::_rangeMessage
	String_t* ____rangeMessage_18;

public:
	inline static int32_t get_offset_of__rangeMessage_18() { return static_cast<int32_t>(offsetof(ArgumentOutOfRangeException_t94D19DF918A54511AEDF4784C9A08741BAD1DEDA_StaticFields, ____rangeMessage_18)); }
	inline String_t* get__rangeMessage_18() const { return ____rangeMessage_18; }
	inline String_t** get_address_of__rangeMessage_18() { return &____rangeMessage_18; }
	inline void set__rangeMessage_18(String_t* value)
	{
		____rangeMessage_18 = value;
		Il2CppCodeGenWriteBarrier((&____rangeMessage_18), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARGUMENTOUTOFRANGEEXCEPTION_T94D19DF918A54511AEDF4784C9A08741BAD1DEDA_H
#ifndef DBCOMMANDBUILDER_T09ABFF5C5CEC0E32ED84FA0EA08D9631CAC24CD4_H
#define DBCOMMANDBUILDER_T09ABFF5C5CEC0E32ED84FA0EA08D9631CAC24CD4_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Data.Common.DbCommandBuilder
struct  DbCommandBuilder_t09ABFF5C5CEC0E32ED84FA0EA08D9631CAC24CD4  : public Component_t7AEFE153F6778CF52E1981BC3E811A9604B29473
{
public:
	// System.Data.Common.DbDataAdapter System.Data.Common.DbCommandBuilder::_dataAdapter
	DbDataAdapter_tD491D36DE53638EDEC3069CE96717AD87D4225CA * ____dataAdapter_4;
	// System.Data.Common.DbCommand System.Data.Common.DbCommandBuilder::_insertCommand
	DbCommand_t818F90E565B3D0FB3D6C653214D5C8E4211A5A55 * ____insertCommand_5;
	// System.Data.Common.DbCommand System.Data.Common.DbCommandBuilder::_updateCommand
	DbCommand_t818F90E565B3D0FB3D6C653214D5C8E4211A5A55 * ____updateCommand_6;
	// System.Data.Common.DbCommand System.Data.Common.DbCommandBuilder::_deleteCommand
	DbCommand_t818F90E565B3D0FB3D6C653214D5C8E4211A5A55 * ____deleteCommand_7;
	// System.Data.MissingMappingAction System.Data.Common.DbCommandBuilder::_missingMappingAction
	int32_t ____missingMappingAction_8;
	// System.Data.ConflictOption System.Data.Common.DbCommandBuilder::_conflictDetection
	int32_t ____conflictDetection_9;
	// System.Boolean System.Data.Common.DbCommandBuilder::_setAllValues
	bool ____setAllValues_10;
	// System.Boolean System.Data.Common.DbCommandBuilder::_hasPartialPrimaryKey
	bool ____hasPartialPrimaryKey_11;
	// System.Data.DataTable System.Data.Common.DbCommandBuilder::_dbSchemaTable
	DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * ____dbSchemaTable_12;
	// System.Data.Common.DbSchemaRow[] System.Data.Common.DbCommandBuilder::_dbSchemaRows
	DbSchemaRowU5BU5D_tBD2A74D689F73CA84C5390B2A586C6AE904C9A31* ____dbSchemaRows_13;
	// System.String[] System.Data.Common.DbCommandBuilder::_sourceColumnNames
	StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* ____sourceColumnNames_14;
	// System.Data.Common.DbCommandBuilder_ParameterNames System.Data.Common.DbCommandBuilder::_parameterNames
	ParameterNames_tC8571837DB584F0E7ED76EEF1B6C27507CEB0755 * ____parameterNames_15;
	// System.String System.Data.Common.DbCommandBuilder::_quotedBaseTableName
	String_t* ____quotedBaseTableName_16;
	// System.Data.Common.CatalogLocation System.Data.Common.DbCommandBuilder::_catalogLocation
	int32_t ____catalogLocation_17;
	// System.String System.Data.Common.DbCommandBuilder::_catalogSeparator
	String_t* ____catalogSeparator_18;
	// System.String System.Data.Common.DbCommandBuilder::_schemaSeparator
	String_t* ____schemaSeparator_19;
	// System.String System.Data.Common.DbCommandBuilder::_quotePrefix
	String_t* ____quotePrefix_20;
	// System.String System.Data.Common.DbCommandBuilder::_quoteSuffix
	String_t* ____quoteSuffix_21;
	// System.String System.Data.Common.DbCommandBuilder::_parameterNamePattern
	String_t* ____parameterNamePattern_22;
	// System.String System.Data.Common.DbCommandBuilder::_parameterMarkerFormat
	String_t* ____parameterMarkerFormat_23;
	// System.Int32 System.Data.Common.DbCommandBuilder::_parameterNameMaxLength
	int32_t ____parameterNameMaxLength_24;

public:
	inline static int32_t get_offset_of__dataAdapter_4() { return static_cast<int32_t>(offsetof(DbCommandBuilder_t09ABFF5C5CEC0E32ED84FA0EA08D9631CAC24CD4, ____dataAdapter_4)); }
	inline DbDataAdapter_tD491D36DE53638EDEC3069CE96717AD87D4225CA * get__dataAdapter_4() const { return ____dataAdapter_4; }
	inline DbDataAdapter_tD491D36DE53638EDEC3069CE96717AD87D4225CA ** get_address_of__dataAdapter_4() { return &____dataAdapter_4; }
	inline void set__dataAdapter_4(DbDataAdapter_tD491D36DE53638EDEC3069CE96717AD87D4225CA * value)
	{
		____dataAdapter_4 = value;
		Il2CppCodeGenWriteBarrier((&____dataAdapter_4), value);
	}

	inline static int32_t get_offset_of__insertCommand_5() { return static_cast<int32_t>(offsetof(DbCommandBuilder_t09ABFF5C5CEC0E32ED84FA0EA08D9631CAC24CD4, ____insertCommand_5)); }
	inline DbCommand_t818F90E565B3D0FB3D6C653214D5C8E4211A5A55 * get__insertCommand_5() const { return ____insertCommand_5; }
	inline DbCommand_t818F90E565B3D0FB3D6C653214D5C8E4211A5A55 ** get_address_of__insertCommand_5() { return &____insertCommand_5; }
	inline void set__insertCommand_5(DbCommand_t818F90E565B3D0FB3D6C653214D5C8E4211A5A55 * value)
	{
		____insertCommand_5 = value;
		Il2CppCodeGenWriteBarrier((&____insertCommand_5), value);
	}

	inline static int32_t get_offset_of__updateCommand_6() { return static_cast<int32_t>(offsetof(DbCommandBuilder_t09ABFF5C5CEC0E32ED84FA0EA08D9631CAC24CD4, ____updateCommand_6)); }
	inline DbCommand_t818F90E565B3D0FB3D6C653214D5C8E4211A5A55 * get__updateCommand_6() const { return ____updateCommand_6; }
	inline DbCommand_t818F90E565B3D0FB3D6C653214D5C8E4211A5A55 ** get_address_of__updateCommand_6() { return &____updateCommand_6; }
	inline void set__updateCommand_6(DbCommand_t818F90E565B3D0FB3D6C653214D5C8E4211A5A55 * value)
	{
		____updateCommand_6 = value;
		Il2CppCodeGenWriteBarrier((&____updateCommand_6), value);
	}

	inline static int32_t get_offset_of__deleteCommand_7() { return static_cast<int32_t>(offsetof(DbCommandBuilder_t09ABFF5C5CEC0E32ED84FA0EA08D9631CAC24CD4, ____deleteCommand_7)); }
	inline DbCommand_t818F90E565B3D0FB3D6C653214D5C8E4211A5A55 * get__deleteCommand_7() const { return ____deleteCommand_7; }
	inline DbCommand_t818F90E565B3D0FB3D6C653214D5C8E4211A5A55 ** get_address_of__deleteCommand_7() { return &____deleteCommand_7; }
	inline void set__deleteCommand_7(DbCommand_t818F90E565B3D0FB3D6C653214D5C8E4211A5A55 * value)
	{
		____deleteCommand_7 = value;
		Il2CppCodeGenWriteBarrier((&____deleteCommand_7), value);
	}

	inline static int32_t get_offset_of__missingMappingAction_8() { return static_cast<int32_t>(offsetof(DbCommandBuilder_t09ABFF5C5CEC0E32ED84FA0EA08D9631CAC24CD4, ____missingMappingAction_8)); }
	inline int32_t get__missingMappingAction_8() const { return ____missingMappingAction_8; }
	inline int32_t* get_address_of__missingMappingAction_8() { return &____missingMappingAction_8; }
	inline void set__missingMappingAction_8(int32_t value)
	{
		____missingMappingAction_8 = value;
	}

	inline static int32_t get_offset_of__conflictDetection_9() { return static_cast<int32_t>(offsetof(DbCommandBuilder_t09ABFF5C5CEC0E32ED84FA0EA08D9631CAC24CD4, ____conflictDetection_9)); }
	inline int32_t get__conflictDetection_9() const { return ____conflictDetection_9; }
	inline int32_t* get_address_of__conflictDetection_9() { return &____conflictDetection_9; }
	inline void set__conflictDetection_9(int32_t value)
	{
		____conflictDetection_9 = value;
	}

	inline static int32_t get_offset_of__setAllValues_10() { return static_cast<int32_t>(offsetof(DbCommandBuilder_t09ABFF5C5CEC0E32ED84FA0EA08D9631CAC24CD4, ____setAllValues_10)); }
	inline bool get__setAllValues_10() const { return ____setAllValues_10; }
	inline bool* get_address_of__setAllValues_10() { return &____setAllValues_10; }
	inline void set__setAllValues_10(bool value)
	{
		____setAllValues_10 = value;
	}

	inline static int32_t get_offset_of__hasPartialPrimaryKey_11() { return static_cast<int32_t>(offsetof(DbCommandBuilder_t09ABFF5C5CEC0E32ED84FA0EA08D9631CAC24CD4, ____hasPartialPrimaryKey_11)); }
	inline bool get__hasPartialPrimaryKey_11() const { return ____hasPartialPrimaryKey_11; }
	inline bool* get_address_of__hasPartialPrimaryKey_11() { return &____hasPartialPrimaryKey_11; }
	inline void set__hasPartialPrimaryKey_11(bool value)
	{
		____hasPartialPrimaryKey_11 = value;
	}

	inline static int32_t get_offset_of__dbSchemaTable_12() { return static_cast<int32_t>(offsetof(DbCommandBuilder_t09ABFF5C5CEC0E32ED84FA0EA08D9631CAC24CD4, ____dbSchemaTable_12)); }
	inline DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * get__dbSchemaTable_12() const { return ____dbSchemaTable_12; }
	inline DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 ** get_address_of__dbSchemaTable_12() { return &____dbSchemaTable_12; }
	inline void set__dbSchemaTable_12(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * value)
	{
		____dbSchemaTable_12 = value;
		Il2CppCodeGenWriteBarrier((&____dbSchemaTable_12), value);
	}

	inline static int32_t get_offset_of__dbSchemaRows_13() { return static_cast<int32_t>(offsetof(DbCommandBuilder_t09ABFF5C5CEC0E32ED84FA0EA08D9631CAC24CD4, ____dbSchemaRows_13)); }
	inline DbSchemaRowU5BU5D_tBD2A74D689F73CA84C5390B2A586C6AE904C9A31* get__dbSchemaRows_13() const { return ____dbSchemaRows_13; }
	inline DbSchemaRowU5BU5D_tBD2A74D689F73CA84C5390B2A586C6AE904C9A31** get_address_of__dbSchemaRows_13() { return &____dbSchemaRows_13; }
	inline void set__dbSchemaRows_13(DbSchemaRowU5BU5D_tBD2A74D689F73CA84C5390B2A586C6AE904C9A31* value)
	{
		____dbSchemaRows_13 = value;
		Il2CppCodeGenWriteBarrier((&____dbSchemaRows_13), value);
	}

	inline static int32_t get_offset_of__sourceColumnNames_14() { return static_cast<int32_t>(offsetof(DbCommandBuilder_t09ABFF5C5CEC0E32ED84FA0EA08D9631CAC24CD4, ____sourceColumnNames_14)); }
	inline StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* get__sourceColumnNames_14() const { return ____sourceColumnNames_14; }
	inline StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E** get_address_of__sourceColumnNames_14() { return &____sourceColumnNames_14; }
	inline void set__sourceColumnNames_14(StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* value)
	{
		____sourceColumnNames_14 = value;
		Il2CppCodeGenWriteBarrier((&____sourceColumnNames_14), value);
	}

	inline static int32_t get_offset_of__parameterNames_15() { return static_cast<int32_t>(offsetof(DbCommandBuilder_t09ABFF5C5CEC0E32ED84FA0EA08D9631CAC24CD4, ____parameterNames_15)); }
	inline ParameterNames_tC8571837DB584F0E7ED76EEF1B6C27507CEB0755 * get__parameterNames_15() const { return ____parameterNames_15; }
	inline ParameterNames_tC8571837DB584F0E7ED76EEF1B6C27507CEB0755 ** get_address_of__parameterNames_15() { return &____parameterNames_15; }
	inline void set__parameterNames_15(ParameterNames_tC8571837DB584F0E7ED76EEF1B6C27507CEB0755 * value)
	{
		____parameterNames_15 = value;
		Il2CppCodeGenWriteBarrier((&____parameterNames_15), value);
	}

	inline static int32_t get_offset_of__quotedBaseTableName_16() { return static_cast<int32_t>(offsetof(DbCommandBuilder_t09ABFF5C5CEC0E32ED84FA0EA08D9631CAC24CD4, ____quotedBaseTableName_16)); }
	inline String_t* get__quotedBaseTableName_16() const { return ____quotedBaseTableName_16; }
	inline String_t** get_address_of__quotedBaseTableName_16() { return &____quotedBaseTableName_16; }
	inline void set__quotedBaseTableName_16(String_t* value)
	{
		____quotedBaseTableName_16 = value;
		Il2CppCodeGenWriteBarrier((&____quotedBaseTableName_16), value);
	}

	inline static int32_t get_offset_of__catalogLocation_17() { return static_cast<int32_t>(offsetof(DbCommandBuilder_t09ABFF5C5CEC0E32ED84FA0EA08D9631CAC24CD4, ____catalogLocation_17)); }
	inline int32_t get__catalogLocation_17() const { return ____catalogLocation_17; }
	inline int32_t* get_address_of__catalogLocation_17() { return &____catalogLocation_17; }
	inline void set__catalogLocation_17(int32_t value)
	{
		____catalogLocation_17 = value;
	}

	inline static int32_t get_offset_of__catalogSeparator_18() { return static_cast<int32_t>(offsetof(DbCommandBuilder_t09ABFF5C5CEC0E32ED84FA0EA08D9631CAC24CD4, ____catalogSeparator_18)); }
	inline String_t* get__catalogSeparator_18() const { return ____catalogSeparator_18; }
	inline String_t** get_address_of__catalogSeparator_18() { return &____catalogSeparator_18; }
	inline void set__catalogSeparator_18(String_t* value)
	{
		____catalogSeparator_18 = value;
		Il2CppCodeGenWriteBarrier((&____catalogSeparator_18), value);
	}

	inline static int32_t get_offset_of__schemaSeparator_19() { return static_cast<int32_t>(offsetof(DbCommandBuilder_t09ABFF5C5CEC0E32ED84FA0EA08D9631CAC24CD4, ____schemaSeparator_19)); }
	inline String_t* get__schemaSeparator_19() const { return ____schemaSeparator_19; }
	inline String_t** get_address_of__schemaSeparator_19() { return &____schemaSeparator_19; }
	inline void set__schemaSeparator_19(String_t* value)
	{
		____schemaSeparator_19 = value;
		Il2CppCodeGenWriteBarrier((&____schemaSeparator_19), value);
	}

	inline static int32_t get_offset_of__quotePrefix_20() { return static_cast<int32_t>(offsetof(DbCommandBuilder_t09ABFF5C5CEC0E32ED84FA0EA08D9631CAC24CD4, ____quotePrefix_20)); }
	inline String_t* get__quotePrefix_20() const { return ____quotePrefix_20; }
	inline String_t** get_address_of__quotePrefix_20() { return &____quotePrefix_20; }
	inline void set__quotePrefix_20(String_t* value)
	{
		____quotePrefix_20 = value;
		Il2CppCodeGenWriteBarrier((&____quotePrefix_20), value);
	}

	inline static int32_t get_offset_of__quoteSuffix_21() { return static_cast<int32_t>(offsetof(DbCommandBuilder_t09ABFF5C5CEC0E32ED84FA0EA08D9631CAC24CD4, ____quoteSuffix_21)); }
	inline String_t* get__quoteSuffix_21() const { return ____quoteSuffix_21; }
	inline String_t** get_address_of__quoteSuffix_21() { return &____quoteSuffix_21; }
	inline void set__quoteSuffix_21(String_t* value)
	{
		____quoteSuffix_21 = value;
		Il2CppCodeGenWriteBarrier((&____quoteSuffix_21), value);
	}

	inline static int32_t get_offset_of__parameterNamePattern_22() { return static_cast<int32_t>(offsetof(DbCommandBuilder_t09ABFF5C5CEC0E32ED84FA0EA08D9631CAC24CD4, ____parameterNamePattern_22)); }
	inline String_t* get__parameterNamePattern_22() const { return ____parameterNamePattern_22; }
	inline String_t** get_address_of__parameterNamePattern_22() { return &____parameterNamePattern_22; }
	inline void set__parameterNamePattern_22(String_t* value)
	{
		____parameterNamePattern_22 = value;
		Il2CppCodeGenWriteBarrier((&____parameterNamePattern_22), value);
	}

	inline static int32_t get_offset_of__parameterMarkerFormat_23() { return static_cast<int32_t>(offsetof(DbCommandBuilder_t09ABFF5C5CEC0E32ED84FA0EA08D9631CAC24CD4, ____parameterMarkerFormat_23)); }
	inline String_t* get__parameterMarkerFormat_23() const { return ____parameterMarkerFormat_23; }
	inline String_t** get_address_of__parameterMarkerFormat_23() { return &____parameterMarkerFormat_23; }
	inline void set__parameterMarkerFormat_23(String_t* value)
	{
		____parameterMarkerFormat_23 = value;
		Il2CppCodeGenWriteBarrier((&____parameterMarkerFormat_23), value);
	}

	inline static int32_t get_offset_of__parameterNameMaxLength_24() { return static_cast<int32_t>(offsetof(DbCommandBuilder_t09ABFF5C5CEC0E32ED84FA0EA08D9631CAC24CD4, ____parameterNameMaxLength_24)); }
	inline int32_t get__parameterNameMaxLength_24() const { return ____parameterNameMaxLength_24; }
	inline int32_t* get_address_of__parameterNameMaxLength_24() { return &____parameterNameMaxLength_24; }
	inline void set__parameterNameMaxLength_24(int32_t value)
	{
		____parameterNameMaxLength_24 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // DBCOMMANDBUILDER_T09ABFF5C5CEC0E32ED84FA0EA08D9631CAC24CD4_H
#ifndef DBEXCEPTION_T7601D64CEA3E4A5396F01EDC71423DE6209F7F0D_H
#define DBEXCEPTION_T7601D64CEA3E4A5396F01EDC71423DE6209F7F0D_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Data.Common.DbException
struct  DbException_t7601D64CEA3E4A5396F01EDC71423DE6209F7F0D  : public ExternalException_t68841FD169C0CB00CC950EDA7E2A59540D65B1CE
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // DBEXCEPTION_T7601D64CEA3E4A5396F01EDC71423DE6209F7F0D_H
#ifndef DATAROW_TA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B_H
#define DATAROW_TA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Data.DataRow
struct  DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B  : public RuntimeObject
{
public:
	// System.Data.DataTable System.Data.DataRow::_table
	DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * ____table_0;
	// System.Data.DataColumnCollection System.Data.DataRow::_columns
	DataColumnCollection_t398628201192B6EF9DB23A650DAB1E79CEA1796A * ____columns_1;
	// System.Int32 System.Data.DataRow::_oldRecord
	int32_t ____oldRecord_2;
	// System.Int32 System.Data.DataRow::_newRecord
	int32_t ____newRecord_3;
	// System.Int32 System.Data.DataRow::_tempRecord
	int32_t ____tempRecord_4;
	// System.Int64 System.Data.DataRow::_rowID
	int64_t ____rowID_5;
	// System.Data.DataRowAction System.Data.DataRow::_action
	int32_t ____action_6;
	// System.Boolean System.Data.DataRow::_inChangingEvent
	bool ____inChangingEvent_7;
	// System.Boolean System.Data.DataRow::_inDeletingEvent
	bool ____inDeletingEvent_8;
	// System.Boolean System.Data.DataRow::_inCascade
	bool ____inCascade_9;
	// System.Data.DataColumn System.Data.DataRow::_lastChangedColumn
	DataColumn_t397593FCD95F7B10FA2D2E706EFDA54B05E5835D * ____lastChangedColumn_10;
	// System.Int32 System.Data.DataRow::_countColumnChange
	int32_t ____countColumnChange_11;
	// System.Data.DataError System.Data.DataRow::_error
	DataError_tD52C55EF7C5FABAA58B11DBB0C55BE671F18F786 * ____error_12;
	// System.Int32 System.Data.DataRow::_rbTreeNodeId
	int32_t ____rbTreeNodeId_13;
	// System.Int32 System.Data.DataRow::_objectID
	int32_t ____objectID_15;

public:
	inline static int32_t get_offset_of__table_0() { return static_cast<int32_t>(offsetof(DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B, ____table_0)); }
	inline DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * get__table_0() const { return ____table_0; }
	inline DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 ** get_address_of__table_0() { return &____table_0; }
	inline void set__table_0(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * value)
	{
		____table_0 = value;
		Il2CppCodeGenWriteBarrier((&____table_0), value);
	}

	inline static int32_t get_offset_of__columns_1() { return static_cast<int32_t>(offsetof(DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B, ____columns_1)); }
	inline DataColumnCollection_t398628201192B6EF9DB23A650DAB1E79CEA1796A * get__columns_1() const { return ____columns_1; }
	inline DataColumnCollection_t398628201192B6EF9DB23A650DAB1E79CEA1796A ** get_address_of__columns_1() { return &____columns_1; }
	inline void set__columns_1(DataColumnCollection_t398628201192B6EF9DB23A650DAB1E79CEA1796A * value)
	{
		____columns_1 = value;
		Il2CppCodeGenWriteBarrier((&____columns_1), value);
	}

	inline static int32_t get_offset_of__oldRecord_2() { return static_cast<int32_t>(offsetof(DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B, ____oldRecord_2)); }
	inline int32_t get__oldRecord_2() const { return ____oldRecord_2; }
	inline int32_t* get_address_of__oldRecord_2() { return &____oldRecord_2; }
	inline void set__oldRecord_2(int32_t value)
	{
		____oldRecord_2 = value;
	}

	inline static int32_t get_offset_of__newRecord_3() { return static_cast<int32_t>(offsetof(DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B, ____newRecord_3)); }
	inline int32_t get__newRecord_3() const { return ____newRecord_3; }
	inline int32_t* get_address_of__newRecord_3() { return &____newRecord_3; }
	inline void set__newRecord_3(int32_t value)
	{
		____newRecord_3 = value;
	}

	inline static int32_t get_offset_of__tempRecord_4() { return static_cast<int32_t>(offsetof(DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B, ____tempRecord_4)); }
	inline int32_t get__tempRecord_4() const { return ____tempRecord_4; }
	inline int32_t* get_address_of__tempRecord_4() { return &____tempRecord_4; }
	inline void set__tempRecord_4(int32_t value)
	{
		____tempRecord_4 = value;
	}

	inline static int32_t get_offset_of__rowID_5() { return static_cast<int32_t>(offsetof(DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B, ____rowID_5)); }
	inline int64_t get__rowID_5() const { return ____rowID_5; }
	inline int64_t* get_address_of__rowID_5() { return &____rowID_5; }
	inline void set__rowID_5(int64_t value)
	{
		____rowID_5 = value;
	}

	inline static int32_t get_offset_of__action_6() { return static_cast<int32_t>(offsetof(DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B, ____action_6)); }
	inline int32_t get__action_6() const { return ____action_6; }
	inline int32_t* get_address_of__action_6() { return &____action_6; }
	inline void set__action_6(int32_t value)
	{
		____action_6 = value;
	}

	inline static int32_t get_offset_of__inChangingEvent_7() { return static_cast<int32_t>(offsetof(DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B, ____inChangingEvent_7)); }
	inline bool get__inChangingEvent_7() const { return ____inChangingEvent_7; }
	inline bool* get_address_of__inChangingEvent_7() { return &____inChangingEvent_7; }
	inline void set__inChangingEvent_7(bool value)
	{
		____inChangingEvent_7 = value;
	}

	inline static int32_t get_offset_of__inDeletingEvent_8() { return static_cast<int32_t>(offsetof(DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B, ____inDeletingEvent_8)); }
	inline bool get__inDeletingEvent_8() const { return ____inDeletingEvent_8; }
	inline bool* get_address_of__inDeletingEvent_8() { return &____inDeletingEvent_8; }
	inline void set__inDeletingEvent_8(bool value)
	{
		____inDeletingEvent_8 = value;
	}

	inline static int32_t get_offset_of__inCascade_9() { return static_cast<int32_t>(offsetof(DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B, ____inCascade_9)); }
	inline bool get__inCascade_9() const { return ____inCascade_9; }
	inline bool* get_address_of__inCascade_9() { return &____inCascade_9; }
	inline void set__inCascade_9(bool value)
	{
		____inCascade_9 = value;
	}

	inline static int32_t get_offset_of__lastChangedColumn_10() { return static_cast<int32_t>(offsetof(DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B, ____lastChangedColumn_10)); }
	inline DataColumn_t397593FCD95F7B10FA2D2E706EFDA54B05E5835D * get__lastChangedColumn_10() const { return ____lastChangedColumn_10; }
	inline DataColumn_t397593FCD95F7B10FA2D2E706EFDA54B05E5835D ** get_address_of__lastChangedColumn_10() { return &____lastChangedColumn_10; }
	inline void set__lastChangedColumn_10(DataColumn_t397593FCD95F7B10FA2D2E706EFDA54B05E5835D * value)
	{
		____lastChangedColumn_10 = value;
		Il2CppCodeGenWriteBarrier((&____lastChangedColumn_10), value);
	}

	inline static int32_t get_offset_of__countColumnChange_11() { return static_cast<int32_t>(offsetof(DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B, ____countColumnChange_11)); }
	inline int32_t get__countColumnChange_11() const { return ____countColumnChange_11; }
	inline int32_t* get_address_of__countColumnChange_11() { return &____countColumnChange_11; }
	inline void set__countColumnChange_11(int32_t value)
	{
		____countColumnChange_11 = value;
	}

	inline static int32_t get_offset_of__error_12() { return static_cast<int32_t>(offsetof(DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B, ____error_12)); }
	inline DataError_tD52C55EF7C5FABAA58B11DBB0C55BE671F18F786 * get__error_12() const { return ____error_12; }
	inline DataError_tD52C55EF7C5FABAA58B11DBB0C55BE671F18F786 ** get_address_of__error_12() { return &____error_12; }
	inline void set__error_12(DataError_tD52C55EF7C5FABAA58B11DBB0C55BE671F18F786 * value)
	{
		____error_12 = value;
		Il2CppCodeGenWriteBarrier((&____error_12), value);
	}

	inline static int32_t get_offset_of__rbTreeNodeId_13() { return static_cast<int32_t>(offsetof(DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B, ____rbTreeNodeId_13)); }
	inline int32_t get__rbTreeNodeId_13() const { return ____rbTreeNodeId_13; }
	inline int32_t* get_address_of__rbTreeNodeId_13() { return &____rbTreeNodeId_13; }
	inline void set__rbTreeNodeId_13(int32_t value)
	{
		____rbTreeNodeId_13 = value;
	}

	inline static int32_t get_offset_of__objectID_15() { return static_cast<int32_t>(offsetof(DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B, ____objectID_15)); }
	inline int32_t get__objectID_15() const { return ____objectID_15; }
	inline int32_t* get_address_of__objectID_15() { return &____objectID_15; }
	inline void set__objectID_15(int32_t value)
	{
		____objectID_15 = value;
	}
};

struct DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B_StaticFields
{
public:
	// System.Int32 System.Data.DataRow::s_objectTypeCount
	int32_t ___s_objectTypeCount_14;

public:
	inline static int32_t get_offset_of_s_objectTypeCount_14() { return static_cast<int32_t>(offsetof(DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B_StaticFields, ___s_objectTypeCount_14)); }
	inline int32_t get_s_objectTypeCount_14() const { return ___s_objectTypeCount_14; }
	inline int32_t* get_address_of_s_objectTypeCount_14() { return &___s_objectTypeCount_14; }
	inline void set_s_objectTypeCount_14(int32_t value)
	{
		___s_objectTypeCount_14 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // DATAROW_TA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B_H
#ifndef DATATABLE_T44D8846CCB9E2EAE485EB76A1194CF55EC3ED863_H
#define DATATABLE_T44D8846CCB9E2EAE485EB76A1194CF55EC3ED863_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Data.DataTable
struct  DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863  : public MarshalByValueComponent_tADC0E481D4D19F965AB659F9038A1D7D47FA636B
{
public:
	// System.Data.DataSet System.Data.DataTable::_dataSet
	DataSet_t6D7B0F1EC989A523B88F4BDABABD8B828631E1B8 * ____dataSet_3;
	// System.Data.DataView System.Data.DataTable::_defaultView
	DataView_t6489092472EA45039A541483F0E43D26C6723E4C * ____defaultView_4;
	// System.Int64 System.Data.DataTable::_nextRowID
	int64_t ____nextRowID_5;
	// System.Data.DataRowCollection System.Data.DataTable::_rowCollection
	DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0 * ____rowCollection_6;
	// System.Data.DataColumnCollection System.Data.DataTable::_columnCollection
	DataColumnCollection_t398628201192B6EF9DB23A650DAB1E79CEA1796A * ____columnCollection_7;
	// System.Data.ConstraintCollection System.Data.DataTable::_constraintCollection
	ConstraintCollection_t349E02C7469F2E3DF17D381D9BCACF8B7E7CCF62 * ____constraintCollection_8;
	// System.Int32 System.Data.DataTable::_elementColumnCount
	int32_t ____elementColumnCount_9;
	// System.Data.DataRelationCollection System.Data.DataTable::_parentRelationsCollection
	DataRelationCollection_tB592C84F2EE6B60DFB933CC67B8DE1065098269B * ____parentRelationsCollection_10;
	// System.Data.DataRelationCollection System.Data.DataTable::_childRelationsCollection
	DataRelationCollection_tB592C84F2EE6B60DFB933CC67B8DE1065098269B * ____childRelationsCollection_11;
	// System.Data.RecordManager System.Data.DataTable::_recordManager
	RecordManager_t923097B51945932B6775CB40CF53683A864A3C65 * ____recordManager_12;
	// System.Collections.Generic.List`1<System.Data.Index> System.Data.DataTable::_indexes
	List_1_tA40E855828D2BD351AE459CC0CEFC5246704CDEA * ____indexes_13;
	// System.Collections.Generic.List`1<System.Data.Index> System.Data.DataTable::_shadowIndexes
	List_1_tA40E855828D2BD351AE459CC0CEFC5246704CDEA * ____shadowIndexes_14;
	// System.Int32 System.Data.DataTable::_shadowCount
	int32_t ____shadowCount_15;
	// System.Data.PropertyCollection System.Data.DataTable::_extendedProperties
	PropertyCollection_tA766717BE7105BC47681AD434BF66003DEDB68F4 * ____extendedProperties_16;
	// System.String System.Data.DataTable::_tableName
	String_t* ____tableName_17;
	// System.String System.Data.DataTable::_tableNamespace
	String_t* ____tableNamespace_18;
	// System.String System.Data.DataTable::_tablePrefix
	String_t* ____tablePrefix_19;
	// System.Data.DataExpression System.Data.DataTable::_displayExpression
	DataExpression_tECCBF728C87CAF0185856F73F7DB54BB94EF094D * ____displayExpression_20;
	// System.Boolean System.Data.DataTable::_fNestedInDataset
	bool ____fNestedInDataset_21;
	// System.Globalization.CultureInfo System.Data.DataTable::_culture
	CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * ____culture_22;
	// System.Boolean System.Data.DataTable::_cultureUserSet
	bool ____cultureUserSet_23;
	// System.Globalization.CompareInfo System.Data.DataTable::_compareInfo
	CompareInfo_tB9A071DBC11AC00AF2EA2066D0C2AE1DCB1865D1 * ____compareInfo_24;
	// System.Globalization.CompareOptions System.Data.DataTable::_compareFlags
	int32_t ____compareFlags_25;
	// System.IFormatProvider System.Data.DataTable::_formatProvider
	RuntimeObject* ____formatProvider_26;
	// System.StringComparer System.Data.DataTable::_hashCodeProvider
	StringComparer_t588BC7FEF85D6E7425E0A8147A3D5A334F1F82DE * ____hashCodeProvider_27;
	// System.Boolean System.Data.DataTable::_caseSensitive
	bool ____caseSensitive_28;
	// System.Boolean System.Data.DataTable::_caseSensitiveUserSet
	bool ____caseSensitiveUserSet_29;
	// System.String System.Data.DataTable::_encodedTableName
	String_t* ____encodedTableName_30;
	// System.Data.DataColumn System.Data.DataTable::_xmlText
	DataColumn_t397593FCD95F7B10FA2D2E706EFDA54B05E5835D * ____xmlText_31;
	// System.Data.DataColumn System.Data.DataTable::_colUnique
	DataColumn_t397593FCD95F7B10FA2D2E706EFDA54B05E5835D * ____colUnique_32;
	// System.Decimal System.Data.DataTable::_minOccurs
	Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  ____minOccurs_33;
	// System.Decimal System.Data.DataTable::_maxOccurs
	Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  ____maxOccurs_34;
	// System.Boolean System.Data.DataTable::_repeatableElement
	bool ____repeatableElement_35;
	// System.Object System.Data.DataTable::_typeName
	RuntimeObject * ____typeName_36;
	// System.Data.UniqueConstraint System.Data.DataTable::_primaryKey
	UniqueConstraint_t291F6C173D4820C1ACAE889805C3649A44DC1D22 * ____primaryKey_37;
	// System.Data.IndexField[] System.Data.DataTable::_primaryIndex
	IndexFieldU5BU5D_tE0FF1739A3834C07A83EAF2EC3B32E14CC967548* ____primaryIndex_38;
	// System.Data.DataColumn[] System.Data.DataTable::_delayedSetPrimaryKey
	DataColumnU5BU5D_t5E093A4F34F11AFCA04923FE842DCC5ED1B398BC* ____delayedSetPrimaryKey_39;
	// System.Data.Index System.Data.DataTable::_loadIndex
	Index_t0B13AD066A6CAA0045DCA5BB8912F8E599BE9AF7 * ____loadIndex_40;
	// System.Data.Index System.Data.DataTable::_loadIndexwithOriginalAdded
	Index_t0B13AD066A6CAA0045DCA5BB8912F8E599BE9AF7 * ____loadIndexwithOriginalAdded_41;
	// System.Data.Index System.Data.DataTable::_loadIndexwithCurrentDeleted
	Index_t0B13AD066A6CAA0045DCA5BB8912F8E599BE9AF7 * ____loadIndexwithCurrentDeleted_42;
	// System.Int32 System.Data.DataTable::_suspendIndexEvents
	int32_t ____suspendIndexEvents_43;
	// System.Boolean System.Data.DataTable::_savedEnforceConstraints
	bool ____savedEnforceConstraints_44;
	// System.Boolean System.Data.DataTable::_inDataLoad
	bool ____inDataLoad_45;
	// System.Boolean System.Data.DataTable::_initialLoad
	bool ____initialLoad_46;
	// System.Boolean System.Data.DataTable::_schemaLoading
	bool ____schemaLoading_47;
	// System.Boolean System.Data.DataTable::_enforceConstraints
	bool ____enforceConstraints_48;
	// System.Boolean System.Data.DataTable::_suspendEnforceConstraints
	bool ____suspendEnforceConstraints_49;
	// System.Boolean System.Data.DataTable::fInitInProgress
	bool ___fInitInProgress_50;
	// System.Boolean System.Data.DataTable::_inLoad
	bool ____inLoad_51;
	// System.Boolean System.Data.DataTable::_fInLoadDiffgram
	bool ____fInLoadDiffgram_52;
	// System.Byte System.Data.DataTable::_isTypedDataTable
	uint8_t ____isTypedDataTable_53;
	// System.Data.DataRow[] System.Data.DataTable::_emptyDataRowArray
	DataRowU5BU5D_tCA5181B3540ACD7702228F224388EA4B4F5885CA* ____emptyDataRowArray_54;
	// System.ComponentModel.PropertyDescriptorCollection System.Data.DataTable::_propertyDescriptorCollectionCache
	PropertyDescriptorCollection_t19FEFDD6CEF7609BB10282A4B52C3C09A04B41A2 * ____propertyDescriptorCollectionCache_55;
	// System.Data.DataRelation[] System.Data.DataTable::_nestedParentRelations
	DataRelationU5BU5D_t705BDBA68D45143524D5C70D82EA04F0B676C15B* ____nestedParentRelations_56;
	// System.Collections.Generic.List`1<System.Data.DataColumn> System.Data.DataTable::_dependentColumns
	List_1_t70187E1F2F9140ADB155B98F17D5D765F84B9204 * ____dependentColumns_57;
	// System.Boolean System.Data.DataTable::_mergingData
	bool ____mergingData_58;
	// System.Data.DataRowChangeEventHandler System.Data.DataTable::_onRowChangedDelegate
	DataRowChangeEventHandler_t528DC5369A320B2397E1E5CF4E27CC518C0C72A0 * ____onRowChangedDelegate_59;
	// System.Data.DataRowChangeEventHandler System.Data.DataTable::_onRowChangingDelegate
	DataRowChangeEventHandler_t528DC5369A320B2397E1E5CF4E27CC518C0C72A0 * ____onRowChangingDelegate_60;
	// System.Data.DataRowChangeEventHandler System.Data.DataTable::_onRowDeletingDelegate
	DataRowChangeEventHandler_t528DC5369A320B2397E1E5CF4E27CC518C0C72A0 * ____onRowDeletingDelegate_61;
	// System.Data.DataRowChangeEventHandler System.Data.DataTable::_onRowDeletedDelegate
	DataRowChangeEventHandler_t528DC5369A320B2397E1E5CF4E27CC518C0C72A0 * ____onRowDeletedDelegate_62;
	// System.Data.DataColumnChangeEventHandler System.Data.DataTable::_onColumnChangedDelegate
	DataColumnChangeEventHandler_tC860540A9091FE1BB1DF718AB44874A54585FE07 * ____onColumnChangedDelegate_63;
	// System.Data.DataColumnChangeEventHandler System.Data.DataTable::_onColumnChangingDelegate
	DataColumnChangeEventHandler_tC860540A9091FE1BB1DF718AB44874A54585FE07 * ____onColumnChangingDelegate_64;
	// System.Data.DataTableClearEventHandler System.Data.DataTable::_onTableClearingDelegate
	DataTableClearEventHandler_t661CB2EAAB20D6574190694F4DDD86BDD06FA982 * ____onTableClearingDelegate_65;
	// System.Data.DataTableClearEventHandler System.Data.DataTable::_onTableClearedDelegate
	DataTableClearEventHandler_t661CB2EAAB20D6574190694F4DDD86BDD06FA982 * ____onTableClearedDelegate_66;
	// System.Data.DataTableNewRowEventHandler System.Data.DataTable::_onTableNewRowDelegate
	DataTableNewRowEventHandler_tA2A38967A9C8796075CBF1C31585C4C6E3C6F43B * ____onTableNewRowDelegate_67;
	// System.ComponentModel.PropertyChangedEventHandler System.Data.DataTable::_onPropertyChangingDelegate
	PropertyChangedEventHandler_t617E98E1876A8EB394D2B329340CE02D21FFFC82 * ____onPropertyChangingDelegate_68;
	// System.Data.DataRowBuilder System.Data.DataTable::_rowBuilder
	DataRowBuilder_t1686A02FA53DF491D826A981024C255668E94CC6 * ____rowBuilder_69;
	// System.Collections.Generic.List`1<System.Data.DataView> System.Data.DataTable::_delayedViews
	List_1_tD0DF2B545957BB968E2D9198A87C3B784F3837F8 * ____delayedViews_70;
	// System.Collections.Generic.List`1<System.Data.DataViewListener> System.Data.DataTable::_dataViewListeners
	List_1_t1748BC8A0D25EE6A55AA236787A9AA35B5AF8808 * ____dataViewListeners_71;
	// System.Collections.Hashtable System.Data.DataTable::_rowDiffId
	Hashtable_t978F65B8006C8F5504B286526AEC6608FF983FC9 * ____rowDiffId_72;
	// System.Threading.ReaderWriterLockSlim System.Data.DataTable::_indexesLock
	ReaderWriterLockSlim_tD820AC67812C645B2F8C16ABB4DE694A19D6A315 * ____indexesLock_73;
	// System.Int32 System.Data.DataTable::_ukColumnPositionForInference
	int32_t ____ukColumnPositionForInference_74;
	// System.Data.SerializationFormat System.Data.DataTable::_remotingFormat
	int32_t ____remotingFormat_75;
	// System.Int32 System.Data.DataTable::_objectID
	int32_t ____objectID_77;

public:
	inline static int32_t get_offset_of__dataSet_3() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____dataSet_3)); }
	inline DataSet_t6D7B0F1EC989A523B88F4BDABABD8B828631E1B8 * get__dataSet_3() const { return ____dataSet_3; }
	inline DataSet_t6D7B0F1EC989A523B88F4BDABABD8B828631E1B8 ** get_address_of__dataSet_3() { return &____dataSet_3; }
	inline void set__dataSet_3(DataSet_t6D7B0F1EC989A523B88F4BDABABD8B828631E1B8 * value)
	{
		____dataSet_3 = value;
		Il2CppCodeGenWriteBarrier((&____dataSet_3), value);
	}

	inline static int32_t get_offset_of__defaultView_4() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____defaultView_4)); }
	inline DataView_t6489092472EA45039A541483F0E43D26C6723E4C * get__defaultView_4() const { return ____defaultView_4; }
	inline DataView_t6489092472EA45039A541483F0E43D26C6723E4C ** get_address_of__defaultView_4() { return &____defaultView_4; }
	inline void set__defaultView_4(DataView_t6489092472EA45039A541483F0E43D26C6723E4C * value)
	{
		____defaultView_4 = value;
		Il2CppCodeGenWriteBarrier((&____defaultView_4), value);
	}

	inline static int32_t get_offset_of__nextRowID_5() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____nextRowID_5)); }
	inline int64_t get__nextRowID_5() const { return ____nextRowID_5; }
	inline int64_t* get_address_of__nextRowID_5() { return &____nextRowID_5; }
	inline void set__nextRowID_5(int64_t value)
	{
		____nextRowID_5 = value;
	}

	inline static int32_t get_offset_of__rowCollection_6() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____rowCollection_6)); }
	inline DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0 * get__rowCollection_6() const { return ____rowCollection_6; }
	inline DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0 ** get_address_of__rowCollection_6() { return &____rowCollection_6; }
	inline void set__rowCollection_6(DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0 * value)
	{
		____rowCollection_6 = value;
		Il2CppCodeGenWriteBarrier((&____rowCollection_6), value);
	}

	inline static int32_t get_offset_of__columnCollection_7() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____columnCollection_7)); }
	inline DataColumnCollection_t398628201192B6EF9DB23A650DAB1E79CEA1796A * get__columnCollection_7() const { return ____columnCollection_7; }
	inline DataColumnCollection_t398628201192B6EF9DB23A650DAB1E79CEA1796A ** get_address_of__columnCollection_7() { return &____columnCollection_7; }
	inline void set__columnCollection_7(DataColumnCollection_t398628201192B6EF9DB23A650DAB1E79CEA1796A * value)
	{
		____columnCollection_7 = value;
		Il2CppCodeGenWriteBarrier((&____columnCollection_7), value);
	}

	inline static int32_t get_offset_of__constraintCollection_8() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____constraintCollection_8)); }
	inline ConstraintCollection_t349E02C7469F2E3DF17D381D9BCACF8B7E7CCF62 * get__constraintCollection_8() const { return ____constraintCollection_8; }
	inline ConstraintCollection_t349E02C7469F2E3DF17D381D9BCACF8B7E7CCF62 ** get_address_of__constraintCollection_8() { return &____constraintCollection_8; }
	inline void set__constraintCollection_8(ConstraintCollection_t349E02C7469F2E3DF17D381D9BCACF8B7E7CCF62 * value)
	{
		____constraintCollection_8 = value;
		Il2CppCodeGenWriteBarrier((&____constraintCollection_8), value);
	}

	inline static int32_t get_offset_of__elementColumnCount_9() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____elementColumnCount_9)); }
	inline int32_t get__elementColumnCount_9() const { return ____elementColumnCount_9; }
	inline int32_t* get_address_of__elementColumnCount_9() { return &____elementColumnCount_9; }
	inline void set__elementColumnCount_9(int32_t value)
	{
		____elementColumnCount_9 = value;
	}

	inline static int32_t get_offset_of__parentRelationsCollection_10() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____parentRelationsCollection_10)); }
	inline DataRelationCollection_tB592C84F2EE6B60DFB933CC67B8DE1065098269B * get__parentRelationsCollection_10() const { return ____parentRelationsCollection_10; }
	inline DataRelationCollection_tB592C84F2EE6B60DFB933CC67B8DE1065098269B ** get_address_of__parentRelationsCollection_10() { return &____parentRelationsCollection_10; }
	inline void set__parentRelationsCollection_10(DataRelationCollection_tB592C84F2EE6B60DFB933CC67B8DE1065098269B * value)
	{
		____parentRelationsCollection_10 = value;
		Il2CppCodeGenWriteBarrier((&____parentRelationsCollection_10), value);
	}

	inline static int32_t get_offset_of__childRelationsCollection_11() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____childRelationsCollection_11)); }
	inline DataRelationCollection_tB592C84F2EE6B60DFB933CC67B8DE1065098269B * get__childRelationsCollection_11() const { return ____childRelationsCollection_11; }
	inline DataRelationCollection_tB592C84F2EE6B60DFB933CC67B8DE1065098269B ** get_address_of__childRelationsCollection_11() { return &____childRelationsCollection_11; }
	inline void set__childRelationsCollection_11(DataRelationCollection_tB592C84F2EE6B60DFB933CC67B8DE1065098269B * value)
	{
		____childRelationsCollection_11 = value;
		Il2CppCodeGenWriteBarrier((&____childRelationsCollection_11), value);
	}

	inline static int32_t get_offset_of__recordManager_12() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____recordManager_12)); }
	inline RecordManager_t923097B51945932B6775CB40CF53683A864A3C65 * get__recordManager_12() const { return ____recordManager_12; }
	inline RecordManager_t923097B51945932B6775CB40CF53683A864A3C65 ** get_address_of__recordManager_12() { return &____recordManager_12; }
	inline void set__recordManager_12(RecordManager_t923097B51945932B6775CB40CF53683A864A3C65 * value)
	{
		____recordManager_12 = value;
		Il2CppCodeGenWriteBarrier((&____recordManager_12), value);
	}

	inline static int32_t get_offset_of__indexes_13() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____indexes_13)); }
	inline List_1_tA40E855828D2BD351AE459CC0CEFC5246704CDEA * get__indexes_13() const { return ____indexes_13; }
	inline List_1_tA40E855828D2BD351AE459CC0CEFC5246704CDEA ** get_address_of__indexes_13() { return &____indexes_13; }
	inline void set__indexes_13(List_1_tA40E855828D2BD351AE459CC0CEFC5246704CDEA * value)
	{
		____indexes_13 = value;
		Il2CppCodeGenWriteBarrier((&____indexes_13), value);
	}

	inline static int32_t get_offset_of__shadowIndexes_14() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____shadowIndexes_14)); }
	inline List_1_tA40E855828D2BD351AE459CC0CEFC5246704CDEA * get__shadowIndexes_14() const { return ____shadowIndexes_14; }
	inline List_1_tA40E855828D2BD351AE459CC0CEFC5246704CDEA ** get_address_of__shadowIndexes_14() { return &____shadowIndexes_14; }
	inline void set__shadowIndexes_14(List_1_tA40E855828D2BD351AE459CC0CEFC5246704CDEA * value)
	{
		____shadowIndexes_14 = value;
		Il2CppCodeGenWriteBarrier((&____shadowIndexes_14), value);
	}

	inline static int32_t get_offset_of__shadowCount_15() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____shadowCount_15)); }
	inline int32_t get__shadowCount_15() const { return ____shadowCount_15; }
	inline int32_t* get_address_of__shadowCount_15() { return &____shadowCount_15; }
	inline void set__shadowCount_15(int32_t value)
	{
		____shadowCount_15 = value;
	}

	inline static int32_t get_offset_of__extendedProperties_16() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____extendedProperties_16)); }
	inline PropertyCollection_tA766717BE7105BC47681AD434BF66003DEDB68F4 * get__extendedProperties_16() const { return ____extendedProperties_16; }
	inline PropertyCollection_tA766717BE7105BC47681AD434BF66003DEDB68F4 ** get_address_of__extendedProperties_16() { return &____extendedProperties_16; }
	inline void set__extendedProperties_16(PropertyCollection_tA766717BE7105BC47681AD434BF66003DEDB68F4 * value)
	{
		____extendedProperties_16 = value;
		Il2CppCodeGenWriteBarrier((&____extendedProperties_16), value);
	}

	inline static int32_t get_offset_of__tableName_17() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____tableName_17)); }
	inline String_t* get__tableName_17() const { return ____tableName_17; }
	inline String_t** get_address_of__tableName_17() { return &____tableName_17; }
	inline void set__tableName_17(String_t* value)
	{
		____tableName_17 = value;
		Il2CppCodeGenWriteBarrier((&____tableName_17), value);
	}

	inline static int32_t get_offset_of__tableNamespace_18() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____tableNamespace_18)); }
	inline String_t* get__tableNamespace_18() const { return ____tableNamespace_18; }
	inline String_t** get_address_of__tableNamespace_18() { return &____tableNamespace_18; }
	inline void set__tableNamespace_18(String_t* value)
	{
		____tableNamespace_18 = value;
		Il2CppCodeGenWriteBarrier((&____tableNamespace_18), value);
	}

	inline static int32_t get_offset_of__tablePrefix_19() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____tablePrefix_19)); }
	inline String_t* get__tablePrefix_19() const { return ____tablePrefix_19; }
	inline String_t** get_address_of__tablePrefix_19() { return &____tablePrefix_19; }
	inline void set__tablePrefix_19(String_t* value)
	{
		____tablePrefix_19 = value;
		Il2CppCodeGenWriteBarrier((&____tablePrefix_19), value);
	}

	inline static int32_t get_offset_of__displayExpression_20() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____displayExpression_20)); }
	inline DataExpression_tECCBF728C87CAF0185856F73F7DB54BB94EF094D * get__displayExpression_20() const { return ____displayExpression_20; }
	inline DataExpression_tECCBF728C87CAF0185856F73F7DB54BB94EF094D ** get_address_of__displayExpression_20() { return &____displayExpression_20; }
	inline void set__displayExpression_20(DataExpression_tECCBF728C87CAF0185856F73F7DB54BB94EF094D * value)
	{
		____displayExpression_20 = value;
		Il2CppCodeGenWriteBarrier((&____displayExpression_20), value);
	}

	inline static int32_t get_offset_of__fNestedInDataset_21() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____fNestedInDataset_21)); }
	inline bool get__fNestedInDataset_21() const { return ____fNestedInDataset_21; }
	inline bool* get_address_of__fNestedInDataset_21() { return &____fNestedInDataset_21; }
	inline void set__fNestedInDataset_21(bool value)
	{
		____fNestedInDataset_21 = value;
	}

	inline static int32_t get_offset_of__culture_22() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____culture_22)); }
	inline CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * get__culture_22() const { return ____culture_22; }
	inline CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F ** get_address_of__culture_22() { return &____culture_22; }
	inline void set__culture_22(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * value)
	{
		____culture_22 = value;
		Il2CppCodeGenWriteBarrier((&____culture_22), value);
	}

	inline static int32_t get_offset_of__cultureUserSet_23() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____cultureUserSet_23)); }
	inline bool get__cultureUserSet_23() const { return ____cultureUserSet_23; }
	inline bool* get_address_of__cultureUserSet_23() { return &____cultureUserSet_23; }
	inline void set__cultureUserSet_23(bool value)
	{
		____cultureUserSet_23 = value;
	}

	inline static int32_t get_offset_of__compareInfo_24() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____compareInfo_24)); }
	inline CompareInfo_tB9A071DBC11AC00AF2EA2066D0C2AE1DCB1865D1 * get__compareInfo_24() const { return ____compareInfo_24; }
	inline CompareInfo_tB9A071DBC11AC00AF2EA2066D0C2AE1DCB1865D1 ** get_address_of__compareInfo_24() { return &____compareInfo_24; }
	inline void set__compareInfo_24(CompareInfo_tB9A071DBC11AC00AF2EA2066D0C2AE1DCB1865D1 * value)
	{
		____compareInfo_24 = value;
		Il2CppCodeGenWriteBarrier((&____compareInfo_24), value);
	}

	inline static int32_t get_offset_of__compareFlags_25() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____compareFlags_25)); }
	inline int32_t get__compareFlags_25() const { return ____compareFlags_25; }
	inline int32_t* get_address_of__compareFlags_25() { return &____compareFlags_25; }
	inline void set__compareFlags_25(int32_t value)
	{
		____compareFlags_25 = value;
	}

	inline static int32_t get_offset_of__formatProvider_26() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____formatProvider_26)); }
	inline RuntimeObject* get__formatProvider_26() const { return ____formatProvider_26; }
	inline RuntimeObject** get_address_of__formatProvider_26() { return &____formatProvider_26; }
	inline void set__formatProvider_26(RuntimeObject* value)
	{
		____formatProvider_26 = value;
		Il2CppCodeGenWriteBarrier((&____formatProvider_26), value);
	}

	inline static int32_t get_offset_of__hashCodeProvider_27() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____hashCodeProvider_27)); }
	inline StringComparer_t588BC7FEF85D6E7425E0A8147A3D5A334F1F82DE * get__hashCodeProvider_27() const { return ____hashCodeProvider_27; }
	inline StringComparer_t588BC7FEF85D6E7425E0A8147A3D5A334F1F82DE ** get_address_of__hashCodeProvider_27() { return &____hashCodeProvider_27; }
	inline void set__hashCodeProvider_27(StringComparer_t588BC7FEF85D6E7425E0A8147A3D5A334F1F82DE * value)
	{
		____hashCodeProvider_27 = value;
		Il2CppCodeGenWriteBarrier((&____hashCodeProvider_27), value);
	}

	inline static int32_t get_offset_of__caseSensitive_28() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____caseSensitive_28)); }
	inline bool get__caseSensitive_28() const { return ____caseSensitive_28; }
	inline bool* get_address_of__caseSensitive_28() { return &____caseSensitive_28; }
	inline void set__caseSensitive_28(bool value)
	{
		____caseSensitive_28 = value;
	}

	inline static int32_t get_offset_of__caseSensitiveUserSet_29() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____caseSensitiveUserSet_29)); }
	inline bool get__caseSensitiveUserSet_29() const { return ____caseSensitiveUserSet_29; }
	inline bool* get_address_of__caseSensitiveUserSet_29() { return &____caseSensitiveUserSet_29; }
	inline void set__caseSensitiveUserSet_29(bool value)
	{
		____caseSensitiveUserSet_29 = value;
	}

	inline static int32_t get_offset_of__encodedTableName_30() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____encodedTableName_30)); }
	inline String_t* get__encodedTableName_30() const { return ____encodedTableName_30; }
	inline String_t** get_address_of__encodedTableName_30() { return &____encodedTableName_30; }
	inline void set__encodedTableName_30(String_t* value)
	{
		____encodedTableName_30 = value;
		Il2CppCodeGenWriteBarrier((&____encodedTableName_30), value);
	}

	inline static int32_t get_offset_of__xmlText_31() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____xmlText_31)); }
	inline DataColumn_t397593FCD95F7B10FA2D2E706EFDA54B05E5835D * get__xmlText_31() const { return ____xmlText_31; }
	inline DataColumn_t397593FCD95F7B10FA2D2E706EFDA54B05E5835D ** get_address_of__xmlText_31() { return &____xmlText_31; }
	inline void set__xmlText_31(DataColumn_t397593FCD95F7B10FA2D2E706EFDA54B05E5835D * value)
	{
		____xmlText_31 = value;
		Il2CppCodeGenWriteBarrier((&____xmlText_31), value);
	}

	inline static int32_t get_offset_of__colUnique_32() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____colUnique_32)); }
	inline DataColumn_t397593FCD95F7B10FA2D2E706EFDA54B05E5835D * get__colUnique_32() const { return ____colUnique_32; }
	inline DataColumn_t397593FCD95F7B10FA2D2E706EFDA54B05E5835D ** get_address_of__colUnique_32() { return &____colUnique_32; }
	inline void set__colUnique_32(DataColumn_t397593FCD95F7B10FA2D2E706EFDA54B05E5835D * value)
	{
		____colUnique_32 = value;
		Il2CppCodeGenWriteBarrier((&____colUnique_32), value);
	}

	inline static int32_t get_offset_of__minOccurs_33() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____minOccurs_33)); }
	inline Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  get__minOccurs_33() const { return ____minOccurs_33; }
	inline Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8 * get_address_of__minOccurs_33() { return &____minOccurs_33; }
	inline void set__minOccurs_33(Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  value)
	{
		____minOccurs_33 = value;
	}

	inline static int32_t get_offset_of__maxOccurs_34() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____maxOccurs_34)); }
	inline Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  get__maxOccurs_34() const { return ____maxOccurs_34; }
	inline Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8 * get_address_of__maxOccurs_34() { return &____maxOccurs_34; }
	inline void set__maxOccurs_34(Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  value)
	{
		____maxOccurs_34 = value;
	}

	inline static int32_t get_offset_of__repeatableElement_35() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____repeatableElement_35)); }
	inline bool get__repeatableElement_35() const { return ____repeatableElement_35; }
	inline bool* get_address_of__repeatableElement_35() { return &____repeatableElement_35; }
	inline void set__repeatableElement_35(bool value)
	{
		____repeatableElement_35 = value;
	}

	inline static int32_t get_offset_of__typeName_36() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____typeName_36)); }
	inline RuntimeObject * get__typeName_36() const { return ____typeName_36; }
	inline RuntimeObject ** get_address_of__typeName_36() { return &____typeName_36; }
	inline void set__typeName_36(RuntimeObject * value)
	{
		____typeName_36 = value;
		Il2CppCodeGenWriteBarrier((&____typeName_36), value);
	}

	inline static int32_t get_offset_of__primaryKey_37() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____primaryKey_37)); }
	inline UniqueConstraint_t291F6C173D4820C1ACAE889805C3649A44DC1D22 * get__primaryKey_37() const { return ____primaryKey_37; }
	inline UniqueConstraint_t291F6C173D4820C1ACAE889805C3649A44DC1D22 ** get_address_of__primaryKey_37() { return &____primaryKey_37; }
	inline void set__primaryKey_37(UniqueConstraint_t291F6C173D4820C1ACAE889805C3649A44DC1D22 * value)
	{
		____primaryKey_37 = value;
		Il2CppCodeGenWriteBarrier((&____primaryKey_37), value);
	}

	inline static int32_t get_offset_of__primaryIndex_38() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____primaryIndex_38)); }
	inline IndexFieldU5BU5D_tE0FF1739A3834C07A83EAF2EC3B32E14CC967548* get__primaryIndex_38() const { return ____primaryIndex_38; }
	inline IndexFieldU5BU5D_tE0FF1739A3834C07A83EAF2EC3B32E14CC967548** get_address_of__primaryIndex_38() { return &____primaryIndex_38; }
	inline void set__primaryIndex_38(IndexFieldU5BU5D_tE0FF1739A3834C07A83EAF2EC3B32E14CC967548* value)
	{
		____primaryIndex_38 = value;
		Il2CppCodeGenWriteBarrier((&____primaryIndex_38), value);
	}

	inline static int32_t get_offset_of__delayedSetPrimaryKey_39() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____delayedSetPrimaryKey_39)); }
	inline DataColumnU5BU5D_t5E093A4F34F11AFCA04923FE842DCC5ED1B398BC* get__delayedSetPrimaryKey_39() const { return ____delayedSetPrimaryKey_39; }
	inline DataColumnU5BU5D_t5E093A4F34F11AFCA04923FE842DCC5ED1B398BC** get_address_of__delayedSetPrimaryKey_39() { return &____delayedSetPrimaryKey_39; }
	inline void set__delayedSetPrimaryKey_39(DataColumnU5BU5D_t5E093A4F34F11AFCA04923FE842DCC5ED1B398BC* value)
	{
		____delayedSetPrimaryKey_39 = value;
		Il2CppCodeGenWriteBarrier((&____delayedSetPrimaryKey_39), value);
	}

	inline static int32_t get_offset_of__loadIndex_40() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____loadIndex_40)); }
	inline Index_t0B13AD066A6CAA0045DCA5BB8912F8E599BE9AF7 * get__loadIndex_40() const { return ____loadIndex_40; }
	inline Index_t0B13AD066A6CAA0045DCA5BB8912F8E599BE9AF7 ** get_address_of__loadIndex_40() { return &____loadIndex_40; }
	inline void set__loadIndex_40(Index_t0B13AD066A6CAA0045DCA5BB8912F8E599BE9AF7 * value)
	{
		____loadIndex_40 = value;
		Il2CppCodeGenWriteBarrier((&____loadIndex_40), value);
	}

	inline static int32_t get_offset_of__loadIndexwithOriginalAdded_41() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____loadIndexwithOriginalAdded_41)); }
	inline Index_t0B13AD066A6CAA0045DCA5BB8912F8E599BE9AF7 * get__loadIndexwithOriginalAdded_41() const { return ____loadIndexwithOriginalAdded_41; }
	inline Index_t0B13AD066A6CAA0045DCA5BB8912F8E599BE9AF7 ** get_address_of__loadIndexwithOriginalAdded_41() { return &____loadIndexwithOriginalAdded_41; }
	inline void set__loadIndexwithOriginalAdded_41(Index_t0B13AD066A6CAA0045DCA5BB8912F8E599BE9AF7 * value)
	{
		____loadIndexwithOriginalAdded_41 = value;
		Il2CppCodeGenWriteBarrier((&____loadIndexwithOriginalAdded_41), value);
	}

	inline static int32_t get_offset_of__loadIndexwithCurrentDeleted_42() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____loadIndexwithCurrentDeleted_42)); }
	inline Index_t0B13AD066A6CAA0045DCA5BB8912F8E599BE9AF7 * get__loadIndexwithCurrentDeleted_42() const { return ____loadIndexwithCurrentDeleted_42; }
	inline Index_t0B13AD066A6CAA0045DCA5BB8912F8E599BE9AF7 ** get_address_of__loadIndexwithCurrentDeleted_42() { return &____loadIndexwithCurrentDeleted_42; }
	inline void set__loadIndexwithCurrentDeleted_42(Index_t0B13AD066A6CAA0045DCA5BB8912F8E599BE9AF7 * value)
	{
		____loadIndexwithCurrentDeleted_42 = value;
		Il2CppCodeGenWriteBarrier((&____loadIndexwithCurrentDeleted_42), value);
	}

	inline static int32_t get_offset_of__suspendIndexEvents_43() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____suspendIndexEvents_43)); }
	inline int32_t get__suspendIndexEvents_43() const { return ____suspendIndexEvents_43; }
	inline int32_t* get_address_of__suspendIndexEvents_43() { return &____suspendIndexEvents_43; }
	inline void set__suspendIndexEvents_43(int32_t value)
	{
		____suspendIndexEvents_43 = value;
	}

	inline static int32_t get_offset_of__savedEnforceConstraints_44() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____savedEnforceConstraints_44)); }
	inline bool get__savedEnforceConstraints_44() const { return ____savedEnforceConstraints_44; }
	inline bool* get_address_of__savedEnforceConstraints_44() { return &____savedEnforceConstraints_44; }
	inline void set__savedEnforceConstraints_44(bool value)
	{
		____savedEnforceConstraints_44 = value;
	}

	inline static int32_t get_offset_of__inDataLoad_45() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____inDataLoad_45)); }
	inline bool get__inDataLoad_45() const { return ____inDataLoad_45; }
	inline bool* get_address_of__inDataLoad_45() { return &____inDataLoad_45; }
	inline void set__inDataLoad_45(bool value)
	{
		____inDataLoad_45 = value;
	}

	inline static int32_t get_offset_of__initialLoad_46() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____initialLoad_46)); }
	inline bool get__initialLoad_46() const { return ____initialLoad_46; }
	inline bool* get_address_of__initialLoad_46() { return &____initialLoad_46; }
	inline void set__initialLoad_46(bool value)
	{
		____initialLoad_46 = value;
	}

	inline static int32_t get_offset_of__schemaLoading_47() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____schemaLoading_47)); }
	inline bool get__schemaLoading_47() const { return ____schemaLoading_47; }
	inline bool* get_address_of__schemaLoading_47() { return &____schemaLoading_47; }
	inline void set__schemaLoading_47(bool value)
	{
		____schemaLoading_47 = value;
	}

	inline static int32_t get_offset_of__enforceConstraints_48() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____enforceConstraints_48)); }
	inline bool get__enforceConstraints_48() const { return ____enforceConstraints_48; }
	inline bool* get_address_of__enforceConstraints_48() { return &____enforceConstraints_48; }
	inline void set__enforceConstraints_48(bool value)
	{
		____enforceConstraints_48 = value;
	}

	inline static int32_t get_offset_of__suspendEnforceConstraints_49() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____suspendEnforceConstraints_49)); }
	inline bool get__suspendEnforceConstraints_49() const { return ____suspendEnforceConstraints_49; }
	inline bool* get_address_of__suspendEnforceConstraints_49() { return &____suspendEnforceConstraints_49; }
	inline void set__suspendEnforceConstraints_49(bool value)
	{
		____suspendEnforceConstraints_49 = value;
	}

	inline static int32_t get_offset_of_fInitInProgress_50() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ___fInitInProgress_50)); }
	inline bool get_fInitInProgress_50() const { return ___fInitInProgress_50; }
	inline bool* get_address_of_fInitInProgress_50() { return &___fInitInProgress_50; }
	inline void set_fInitInProgress_50(bool value)
	{
		___fInitInProgress_50 = value;
	}

	inline static int32_t get_offset_of__inLoad_51() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____inLoad_51)); }
	inline bool get__inLoad_51() const { return ____inLoad_51; }
	inline bool* get_address_of__inLoad_51() { return &____inLoad_51; }
	inline void set__inLoad_51(bool value)
	{
		____inLoad_51 = value;
	}

	inline static int32_t get_offset_of__fInLoadDiffgram_52() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____fInLoadDiffgram_52)); }
	inline bool get__fInLoadDiffgram_52() const { return ____fInLoadDiffgram_52; }
	inline bool* get_address_of__fInLoadDiffgram_52() { return &____fInLoadDiffgram_52; }
	inline void set__fInLoadDiffgram_52(bool value)
	{
		____fInLoadDiffgram_52 = value;
	}

	inline static int32_t get_offset_of__isTypedDataTable_53() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____isTypedDataTable_53)); }
	inline uint8_t get__isTypedDataTable_53() const { return ____isTypedDataTable_53; }
	inline uint8_t* get_address_of__isTypedDataTable_53() { return &____isTypedDataTable_53; }
	inline void set__isTypedDataTable_53(uint8_t value)
	{
		____isTypedDataTable_53 = value;
	}

	inline static int32_t get_offset_of__emptyDataRowArray_54() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____emptyDataRowArray_54)); }
	inline DataRowU5BU5D_tCA5181B3540ACD7702228F224388EA4B4F5885CA* get__emptyDataRowArray_54() const { return ____emptyDataRowArray_54; }
	inline DataRowU5BU5D_tCA5181B3540ACD7702228F224388EA4B4F5885CA** get_address_of__emptyDataRowArray_54() { return &____emptyDataRowArray_54; }
	inline void set__emptyDataRowArray_54(DataRowU5BU5D_tCA5181B3540ACD7702228F224388EA4B4F5885CA* value)
	{
		____emptyDataRowArray_54 = value;
		Il2CppCodeGenWriteBarrier((&____emptyDataRowArray_54), value);
	}

	inline static int32_t get_offset_of__propertyDescriptorCollectionCache_55() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____propertyDescriptorCollectionCache_55)); }
	inline PropertyDescriptorCollection_t19FEFDD6CEF7609BB10282A4B52C3C09A04B41A2 * get__propertyDescriptorCollectionCache_55() const { return ____propertyDescriptorCollectionCache_55; }
	inline PropertyDescriptorCollection_t19FEFDD6CEF7609BB10282A4B52C3C09A04B41A2 ** get_address_of__propertyDescriptorCollectionCache_55() { return &____propertyDescriptorCollectionCache_55; }
	inline void set__propertyDescriptorCollectionCache_55(PropertyDescriptorCollection_t19FEFDD6CEF7609BB10282A4B52C3C09A04B41A2 * value)
	{
		____propertyDescriptorCollectionCache_55 = value;
		Il2CppCodeGenWriteBarrier((&____propertyDescriptorCollectionCache_55), value);
	}

	inline static int32_t get_offset_of__nestedParentRelations_56() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____nestedParentRelations_56)); }
	inline DataRelationU5BU5D_t705BDBA68D45143524D5C70D82EA04F0B676C15B* get__nestedParentRelations_56() const { return ____nestedParentRelations_56; }
	inline DataRelationU5BU5D_t705BDBA68D45143524D5C70D82EA04F0B676C15B** get_address_of__nestedParentRelations_56() { return &____nestedParentRelations_56; }
	inline void set__nestedParentRelations_56(DataRelationU5BU5D_t705BDBA68D45143524D5C70D82EA04F0B676C15B* value)
	{
		____nestedParentRelations_56 = value;
		Il2CppCodeGenWriteBarrier((&____nestedParentRelations_56), value);
	}

	inline static int32_t get_offset_of__dependentColumns_57() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____dependentColumns_57)); }
	inline List_1_t70187E1F2F9140ADB155B98F17D5D765F84B9204 * get__dependentColumns_57() const { return ____dependentColumns_57; }
	inline List_1_t70187E1F2F9140ADB155B98F17D5D765F84B9204 ** get_address_of__dependentColumns_57() { return &____dependentColumns_57; }
	inline void set__dependentColumns_57(List_1_t70187E1F2F9140ADB155B98F17D5D765F84B9204 * value)
	{
		____dependentColumns_57 = value;
		Il2CppCodeGenWriteBarrier((&____dependentColumns_57), value);
	}

	inline static int32_t get_offset_of__mergingData_58() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____mergingData_58)); }
	inline bool get__mergingData_58() const { return ____mergingData_58; }
	inline bool* get_address_of__mergingData_58() { return &____mergingData_58; }
	inline void set__mergingData_58(bool value)
	{
		____mergingData_58 = value;
	}

	inline static int32_t get_offset_of__onRowChangedDelegate_59() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____onRowChangedDelegate_59)); }
	inline DataRowChangeEventHandler_t528DC5369A320B2397E1E5CF4E27CC518C0C72A0 * get__onRowChangedDelegate_59() const { return ____onRowChangedDelegate_59; }
	inline DataRowChangeEventHandler_t528DC5369A320B2397E1E5CF4E27CC518C0C72A0 ** get_address_of__onRowChangedDelegate_59() { return &____onRowChangedDelegate_59; }
	inline void set__onRowChangedDelegate_59(DataRowChangeEventHandler_t528DC5369A320B2397E1E5CF4E27CC518C0C72A0 * value)
	{
		____onRowChangedDelegate_59 = value;
		Il2CppCodeGenWriteBarrier((&____onRowChangedDelegate_59), value);
	}

	inline static int32_t get_offset_of__onRowChangingDelegate_60() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____onRowChangingDelegate_60)); }
	inline DataRowChangeEventHandler_t528DC5369A320B2397E1E5CF4E27CC518C0C72A0 * get__onRowChangingDelegate_60() const { return ____onRowChangingDelegate_60; }
	inline DataRowChangeEventHandler_t528DC5369A320B2397E1E5CF4E27CC518C0C72A0 ** get_address_of__onRowChangingDelegate_60() { return &____onRowChangingDelegate_60; }
	inline void set__onRowChangingDelegate_60(DataRowChangeEventHandler_t528DC5369A320B2397E1E5CF4E27CC518C0C72A0 * value)
	{
		____onRowChangingDelegate_60 = value;
		Il2CppCodeGenWriteBarrier((&____onRowChangingDelegate_60), value);
	}

	inline static int32_t get_offset_of__onRowDeletingDelegate_61() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____onRowDeletingDelegate_61)); }
	inline DataRowChangeEventHandler_t528DC5369A320B2397E1E5CF4E27CC518C0C72A0 * get__onRowDeletingDelegate_61() const { return ____onRowDeletingDelegate_61; }
	inline DataRowChangeEventHandler_t528DC5369A320B2397E1E5CF4E27CC518C0C72A0 ** get_address_of__onRowDeletingDelegate_61() { return &____onRowDeletingDelegate_61; }
	inline void set__onRowDeletingDelegate_61(DataRowChangeEventHandler_t528DC5369A320B2397E1E5CF4E27CC518C0C72A0 * value)
	{
		____onRowDeletingDelegate_61 = value;
		Il2CppCodeGenWriteBarrier((&____onRowDeletingDelegate_61), value);
	}

	inline static int32_t get_offset_of__onRowDeletedDelegate_62() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____onRowDeletedDelegate_62)); }
	inline DataRowChangeEventHandler_t528DC5369A320B2397E1E5CF4E27CC518C0C72A0 * get__onRowDeletedDelegate_62() const { return ____onRowDeletedDelegate_62; }
	inline DataRowChangeEventHandler_t528DC5369A320B2397E1E5CF4E27CC518C0C72A0 ** get_address_of__onRowDeletedDelegate_62() { return &____onRowDeletedDelegate_62; }
	inline void set__onRowDeletedDelegate_62(DataRowChangeEventHandler_t528DC5369A320B2397E1E5CF4E27CC518C0C72A0 * value)
	{
		____onRowDeletedDelegate_62 = value;
		Il2CppCodeGenWriteBarrier((&____onRowDeletedDelegate_62), value);
	}

	inline static int32_t get_offset_of__onColumnChangedDelegate_63() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____onColumnChangedDelegate_63)); }
	inline DataColumnChangeEventHandler_tC860540A9091FE1BB1DF718AB44874A54585FE07 * get__onColumnChangedDelegate_63() const { return ____onColumnChangedDelegate_63; }
	inline DataColumnChangeEventHandler_tC860540A9091FE1BB1DF718AB44874A54585FE07 ** get_address_of__onColumnChangedDelegate_63() { return &____onColumnChangedDelegate_63; }
	inline void set__onColumnChangedDelegate_63(DataColumnChangeEventHandler_tC860540A9091FE1BB1DF718AB44874A54585FE07 * value)
	{
		____onColumnChangedDelegate_63 = value;
		Il2CppCodeGenWriteBarrier((&____onColumnChangedDelegate_63), value);
	}

	inline static int32_t get_offset_of__onColumnChangingDelegate_64() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____onColumnChangingDelegate_64)); }
	inline DataColumnChangeEventHandler_tC860540A9091FE1BB1DF718AB44874A54585FE07 * get__onColumnChangingDelegate_64() const { return ____onColumnChangingDelegate_64; }
	inline DataColumnChangeEventHandler_tC860540A9091FE1BB1DF718AB44874A54585FE07 ** get_address_of__onColumnChangingDelegate_64() { return &____onColumnChangingDelegate_64; }
	inline void set__onColumnChangingDelegate_64(DataColumnChangeEventHandler_tC860540A9091FE1BB1DF718AB44874A54585FE07 * value)
	{
		____onColumnChangingDelegate_64 = value;
		Il2CppCodeGenWriteBarrier((&____onColumnChangingDelegate_64), value);
	}

	inline static int32_t get_offset_of__onTableClearingDelegate_65() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____onTableClearingDelegate_65)); }
	inline DataTableClearEventHandler_t661CB2EAAB20D6574190694F4DDD86BDD06FA982 * get__onTableClearingDelegate_65() const { return ____onTableClearingDelegate_65; }
	inline DataTableClearEventHandler_t661CB2EAAB20D6574190694F4DDD86BDD06FA982 ** get_address_of__onTableClearingDelegate_65() { return &____onTableClearingDelegate_65; }
	inline void set__onTableClearingDelegate_65(DataTableClearEventHandler_t661CB2EAAB20D6574190694F4DDD86BDD06FA982 * value)
	{
		____onTableClearingDelegate_65 = value;
		Il2CppCodeGenWriteBarrier((&____onTableClearingDelegate_65), value);
	}

	inline static int32_t get_offset_of__onTableClearedDelegate_66() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____onTableClearedDelegate_66)); }
	inline DataTableClearEventHandler_t661CB2EAAB20D6574190694F4DDD86BDD06FA982 * get__onTableClearedDelegate_66() const { return ____onTableClearedDelegate_66; }
	inline DataTableClearEventHandler_t661CB2EAAB20D6574190694F4DDD86BDD06FA982 ** get_address_of__onTableClearedDelegate_66() { return &____onTableClearedDelegate_66; }
	inline void set__onTableClearedDelegate_66(DataTableClearEventHandler_t661CB2EAAB20D6574190694F4DDD86BDD06FA982 * value)
	{
		____onTableClearedDelegate_66 = value;
		Il2CppCodeGenWriteBarrier((&____onTableClearedDelegate_66), value);
	}

	inline static int32_t get_offset_of__onTableNewRowDelegate_67() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____onTableNewRowDelegate_67)); }
	inline DataTableNewRowEventHandler_tA2A38967A9C8796075CBF1C31585C4C6E3C6F43B * get__onTableNewRowDelegate_67() const { return ____onTableNewRowDelegate_67; }
	inline DataTableNewRowEventHandler_tA2A38967A9C8796075CBF1C31585C4C6E3C6F43B ** get_address_of__onTableNewRowDelegate_67() { return &____onTableNewRowDelegate_67; }
	inline void set__onTableNewRowDelegate_67(DataTableNewRowEventHandler_tA2A38967A9C8796075CBF1C31585C4C6E3C6F43B * value)
	{
		____onTableNewRowDelegate_67 = value;
		Il2CppCodeGenWriteBarrier((&____onTableNewRowDelegate_67), value);
	}

	inline static int32_t get_offset_of__onPropertyChangingDelegate_68() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____onPropertyChangingDelegate_68)); }
	inline PropertyChangedEventHandler_t617E98E1876A8EB394D2B329340CE02D21FFFC82 * get__onPropertyChangingDelegate_68() const { return ____onPropertyChangingDelegate_68; }
	inline PropertyChangedEventHandler_t617E98E1876A8EB394D2B329340CE02D21FFFC82 ** get_address_of__onPropertyChangingDelegate_68() { return &____onPropertyChangingDelegate_68; }
	inline void set__onPropertyChangingDelegate_68(PropertyChangedEventHandler_t617E98E1876A8EB394D2B329340CE02D21FFFC82 * value)
	{
		____onPropertyChangingDelegate_68 = value;
		Il2CppCodeGenWriteBarrier((&____onPropertyChangingDelegate_68), value);
	}

	inline static int32_t get_offset_of__rowBuilder_69() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____rowBuilder_69)); }
	inline DataRowBuilder_t1686A02FA53DF491D826A981024C255668E94CC6 * get__rowBuilder_69() const { return ____rowBuilder_69; }
	inline DataRowBuilder_t1686A02FA53DF491D826A981024C255668E94CC6 ** get_address_of__rowBuilder_69() { return &____rowBuilder_69; }
	inline void set__rowBuilder_69(DataRowBuilder_t1686A02FA53DF491D826A981024C255668E94CC6 * value)
	{
		____rowBuilder_69 = value;
		Il2CppCodeGenWriteBarrier((&____rowBuilder_69), value);
	}

	inline static int32_t get_offset_of__delayedViews_70() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____delayedViews_70)); }
	inline List_1_tD0DF2B545957BB968E2D9198A87C3B784F3837F8 * get__delayedViews_70() const { return ____delayedViews_70; }
	inline List_1_tD0DF2B545957BB968E2D9198A87C3B784F3837F8 ** get_address_of__delayedViews_70() { return &____delayedViews_70; }
	inline void set__delayedViews_70(List_1_tD0DF2B545957BB968E2D9198A87C3B784F3837F8 * value)
	{
		____delayedViews_70 = value;
		Il2CppCodeGenWriteBarrier((&____delayedViews_70), value);
	}

	inline static int32_t get_offset_of__dataViewListeners_71() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____dataViewListeners_71)); }
	inline List_1_t1748BC8A0D25EE6A55AA236787A9AA35B5AF8808 * get__dataViewListeners_71() const { return ____dataViewListeners_71; }
	inline List_1_t1748BC8A0D25EE6A55AA236787A9AA35B5AF8808 ** get_address_of__dataViewListeners_71() { return &____dataViewListeners_71; }
	inline void set__dataViewListeners_71(List_1_t1748BC8A0D25EE6A55AA236787A9AA35B5AF8808 * value)
	{
		____dataViewListeners_71 = value;
		Il2CppCodeGenWriteBarrier((&____dataViewListeners_71), value);
	}

	inline static int32_t get_offset_of__rowDiffId_72() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____rowDiffId_72)); }
	inline Hashtable_t978F65B8006C8F5504B286526AEC6608FF983FC9 * get__rowDiffId_72() const { return ____rowDiffId_72; }
	inline Hashtable_t978F65B8006C8F5504B286526AEC6608FF983FC9 ** get_address_of__rowDiffId_72() { return &____rowDiffId_72; }
	inline void set__rowDiffId_72(Hashtable_t978F65B8006C8F5504B286526AEC6608FF983FC9 * value)
	{
		____rowDiffId_72 = value;
		Il2CppCodeGenWriteBarrier((&____rowDiffId_72), value);
	}

	inline static int32_t get_offset_of__indexesLock_73() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____indexesLock_73)); }
	inline ReaderWriterLockSlim_tD820AC67812C645B2F8C16ABB4DE694A19D6A315 * get__indexesLock_73() const { return ____indexesLock_73; }
	inline ReaderWriterLockSlim_tD820AC67812C645B2F8C16ABB4DE694A19D6A315 ** get_address_of__indexesLock_73() { return &____indexesLock_73; }
	inline void set__indexesLock_73(ReaderWriterLockSlim_tD820AC67812C645B2F8C16ABB4DE694A19D6A315 * value)
	{
		____indexesLock_73 = value;
		Il2CppCodeGenWriteBarrier((&____indexesLock_73), value);
	}

	inline static int32_t get_offset_of__ukColumnPositionForInference_74() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____ukColumnPositionForInference_74)); }
	inline int32_t get__ukColumnPositionForInference_74() const { return ____ukColumnPositionForInference_74; }
	inline int32_t* get_address_of__ukColumnPositionForInference_74() { return &____ukColumnPositionForInference_74; }
	inline void set__ukColumnPositionForInference_74(int32_t value)
	{
		____ukColumnPositionForInference_74 = value;
	}

	inline static int32_t get_offset_of__remotingFormat_75() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____remotingFormat_75)); }
	inline int32_t get__remotingFormat_75() const { return ____remotingFormat_75; }
	inline int32_t* get_address_of__remotingFormat_75() { return &____remotingFormat_75; }
	inline void set__remotingFormat_75(int32_t value)
	{
		____remotingFormat_75 = value;
	}

	inline static int32_t get_offset_of__objectID_77() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863, ____objectID_77)); }
	inline int32_t get__objectID_77() const { return ____objectID_77; }
	inline int32_t* get_address_of__objectID_77() { return &____objectID_77; }
	inline void set__objectID_77(int32_t value)
	{
		____objectID_77 = value;
	}
};

struct DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863_StaticFields
{
public:
	// System.Int32 System.Data.DataTable::s_objectTypeCount
	int32_t ___s_objectTypeCount_76;

public:
	inline static int32_t get_offset_of_s_objectTypeCount_76() { return static_cast<int32_t>(offsetof(DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863_StaticFields, ___s_objectTypeCount_76)); }
	inline int32_t get_s_objectTypeCount_76() const { return ___s_objectTypeCount_76; }
	inline int32_t* get_address_of_s_objectTypeCount_76() { return &___s_objectTypeCount_76; }
	inline void set_s_objectTypeCount_76(int32_t value)
	{
		___s_objectTypeCount_76 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // DATATABLE_T44D8846CCB9E2EAE485EB76A1194CF55EC3ED863_H
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
#ifndef ASSEMBLYNAME_T6F3EC58113268060348EE894DCB46F6EF6BBBB82_H
#define ASSEMBLYNAME_T6F3EC58113268060348EE894DCB46F6EF6BBBB82_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Reflection.AssemblyName
struct  AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82  : public RuntimeObject
{
public:
	// System.String System.Reflection.AssemblyName::name
	String_t* ___name_0;
	// System.String System.Reflection.AssemblyName::codebase
	String_t* ___codebase_1;
	// System.Int32 System.Reflection.AssemblyName::major
	int32_t ___major_2;
	// System.Int32 System.Reflection.AssemblyName::minor
	int32_t ___minor_3;
	// System.Int32 System.Reflection.AssemblyName::build
	int32_t ___build_4;
	// System.Int32 System.Reflection.AssemblyName::revision
	int32_t ___revision_5;
	// System.Globalization.CultureInfo System.Reflection.AssemblyName::cultureinfo
	CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * ___cultureinfo_6;
	// System.Reflection.AssemblyNameFlags System.Reflection.AssemblyName::flags
	int32_t ___flags_7;
	// System.Configuration.Assemblies.AssemblyHashAlgorithm System.Reflection.AssemblyName::hashalg
	int32_t ___hashalg_8;
	// System.Reflection.StrongNameKeyPair System.Reflection.AssemblyName::keypair
	StrongNameKeyPair_tD9AA282E59F4526338781AFD862680ED461FCCFD * ___keypair_9;
	// System.Byte[] System.Reflection.AssemblyName::publicKey
	ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___publicKey_10;
	// System.Byte[] System.Reflection.AssemblyName::keyToken
	ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___keyToken_11;
	// System.Configuration.Assemblies.AssemblyVersionCompatibility System.Reflection.AssemblyName::versioncompat
	int32_t ___versioncompat_12;
	// System.Version System.Reflection.AssemblyName::version
	Version_tDBE6876C59B6F56D4F8CAA03851177ABC6FE0DFD * ___version_13;
	// System.Reflection.ProcessorArchitecture System.Reflection.AssemblyName::processor_architecture
	int32_t ___processor_architecture_14;
	// System.Reflection.AssemblyContentType System.Reflection.AssemblyName::contentType
	int32_t ___contentType_15;

public:
	inline static int32_t get_offset_of_name_0() { return static_cast<int32_t>(offsetof(AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82, ___name_0)); }
	inline String_t* get_name_0() const { return ___name_0; }
	inline String_t** get_address_of_name_0() { return &___name_0; }
	inline void set_name_0(String_t* value)
	{
		___name_0 = value;
		Il2CppCodeGenWriteBarrier((&___name_0), value);
	}

	inline static int32_t get_offset_of_codebase_1() { return static_cast<int32_t>(offsetof(AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82, ___codebase_1)); }
	inline String_t* get_codebase_1() const { return ___codebase_1; }
	inline String_t** get_address_of_codebase_1() { return &___codebase_1; }
	inline void set_codebase_1(String_t* value)
	{
		___codebase_1 = value;
		Il2CppCodeGenWriteBarrier((&___codebase_1), value);
	}

	inline static int32_t get_offset_of_major_2() { return static_cast<int32_t>(offsetof(AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82, ___major_2)); }
	inline int32_t get_major_2() const { return ___major_2; }
	inline int32_t* get_address_of_major_2() { return &___major_2; }
	inline void set_major_2(int32_t value)
	{
		___major_2 = value;
	}

	inline static int32_t get_offset_of_minor_3() { return static_cast<int32_t>(offsetof(AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82, ___minor_3)); }
	inline int32_t get_minor_3() const { return ___minor_3; }
	inline int32_t* get_address_of_minor_3() { return &___minor_3; }
	inline void set_minor_3(int32_t value)
	{
		___minor_3 = value;
	}

	inline static int32_t get_offset_of_build_4() { return static_cast<int32_t>(offsetof(AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82, ___build_4)); }
	inline int32_t get_build_4() const { return ___build_4; }
	inline int32_t* get_address_of_build_4() { return &___build_4; }
	inline void set_build_4(int32_t value)
	{
		___build_4 = value;
	}

	inline static int32_t get_offset_of_revision_5() { return static_cast<int32_t>(offsetof(AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82, ___revision_5)); }
	inline int32_t get_revision_5() const { return ___revision_5; }
	inline int32_t* get_address_of_revision_5() { return &___revision_5; }
	inline void set_revision_5(int32_t value)
	{
		___revision_5 = value;
	}

	inline static int32_t get_offset_of_cultureinfo_6() { return static_cast<int32_t>(offsetof(AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82, ___cultureinfo_6)); }
	inline CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * get_cultureinfo_6() const { return ___cultureinfo_6; }
	inline CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F ** get_address_of_cultureinfo_6() { return &___cultureinfo_6; }
	inline void set_cultureinfo_6(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * value)
	{
		___cultureinfo_6 = value;
		Il2CppCodeGenWriteBarrier((&___cultureinfo_6), value);
	}

	inline static int32_t get_offset_of_flags_7() { return static_cast<int32_t>(offsetof(AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82, ___flags_7)); }
	inline int32_t get_flags_7() const { return ___flags_7; }
	inline int32_t* get_address_of_flags_7() { return &___flags_7; }
	inline void set_flags_7(int32_t value)
	{
		___flags_7 = value;
	}

	inline static int32_t get_offset_of_hashalg_8() { return static_cast<int32_t>(offsetof(AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82, ___hashalg_8)); }
	inline int32_t get_hashalg_8() const { return ___hashalg_8; }
	inline int32_t* get_address_of_hashalg_8() { return &___hashalg_8; }
	inline void set_hashalg_8(int32_t value)
	{
		___hashalg_8 = value;
	}

	inline static int32_t get_offset_of_keypair_9() { return static_cast<int32_t>(offsetof(AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82, ___keypair_9)); }
	inline StrongNameKeyPair_tD9AA282E59F4526338781AFD862680ED461FCCFD * get_keypair_9() const { return ___keypair_9; }
	inline StrongNameKeyPair_tD9AA282E59F4526338781AFD862680ED461FCCFD ** get_address_of_keypair_9() { return &___keypair_9; }
	inline void set_keypair_9(StrongNameKeyPair_tD9AA282E59F4526338781AFD862680ED461FCCFD * value)
	{
		___keypair_9 = value;
		Il2CppCodeGenWriteBarrier((&___keypair_9), value);
	}

	inline static int32_t get_offset_of_publicKey_10() { return static_cast<int32_t>(offsetof(AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82, ___publicKey_10)); }
	inline ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* get_publicKey_10() const { return ___publicKey_10; }
	inline ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821** get_address_of_publicKey_10() { return &___publicKey_10; }
	inline void set_publicKey_10(ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* value)
	{
		___publicKey_10 = value;
		Il2CppCodeGenWriteBarrier((&___publicKey_10), value);
	}

	inline static int32_t get_offset_of_keyToken_11() { return static_cast<int32_t>(offsetof(AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82, ___keyToken_11)); }
	inline ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* get_keyToken_11() const { return ___keyToken_11; }
	inline ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821** get_address_of_keyToken_11() { return &___keyToken_11; }
	inline void set_keyToken_11(ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* value)
	{
		___keyToken_11 = value;
		Il2CppCodeGenWriteBarrier((&___keyToken_11), value);
	}

	inline static int32_t get_offset_of_versioncompat_12() { return static_cast<int32_t>(offsetof(AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82, ___versioncompat_12)); }
	inline int32_t get_versioncompat_12() const { return ___versioncompat_12; }
	inline int32_t* get_address_of_versioncompat_12() { return &___versioncompat_12; }
	inline void set_versioncompat_12(int32_t value)
	{
		___versioncompat_12 = value;
	}

	inline static int32_t get_offset_of_version_13() { return static_cast<int32_t>(offsetof(AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82, ___version_13)); }
	inline Version_tDBE6876C59B6F56D4F8CAA03851177ABC6FE0DFD * get_version_13() const { return ___version_13; }
	inline Version_tDBE6876C59B6F56D4F8CAA03851177ABC6FE0DFD ** get_address_of_version_13() { return &___version_13; }
	inline void set_version_13(Version_tDBE6876C59B6F56D4F8CAA03851177ABC6FE0DFD * value)
	{
		___version_13 = value;
		Il2CppCodeGenWriteBarrier((&___version_13), value);
	}

	inline static int32_t get_offset_of_processor_architecture_14() { return static_cast<int32_t>(offsetof(AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82, ___processor_architecture_14)); }
	inline int32_t get_processor_architecture_14() const { return ___processor_architecture_14; }
	inline int32_t* get_address_of_processor_architecture_14() { return &___processor_architecture_14; }
	inline void set_processor_architecture_14(int32_t value)
	{
		___processor_architecture_14 = value;
	}

	inline static int32_t get_offset_of_contentType_15() { return static_cast<int32_t>(offsetof(AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82, ___contentType_15)); }
	inline int32_t get_contentType_15() const { return ___contentType_15; }
	inline int32_t* get_address_of_contentType_15() { return &___contentType_15; }
	inline void set_contentType_15(int32_t value)
	{
		___contentType_15 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.Reflection.AssemblyName
struct AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82_marshaled_pinvoke
{
	char* ___name_0;
	char* ___codebase_1;
	int32_t ___major_2;
	int32_t ___minor_3;
	int32_t ___build_4;
	int32_t ___revision_5;
	CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_marshaled_pinvoke* ___cultureinfo_6;
	int32_t ___flags_7;
	int32_t ___hashalg_8;
	StrongNameKeyPair_tD9AA282E59F4526338781AFD862680ED461FCCFD * ___keypair_9;
	uint8_t* ___publicKey_10;
	uint8_t* ___keyToken_11;
	int32_t ___versioncompat_12;
	Version_tDBE6876C59B6F56D4F8CAA03851177ABC6FE0DFD * ___version_13;
	int32_t ___processor_architecture_14;
	int32_t ___contentType_15;
};
// Native definition for COM marshalling of System.Reflection.AssemblyName
struct AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82_marshaled_com
{
	Il2CppChar* ___name_0;
	Il2CppChar* ___codebase_1;
	int32_t ___major_2;
	int32_t ___minor_3;
	int32_t ___build_4;
	int32_t ___revision_5;
	CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_marshaled_com* ___cultureinfo_6;
	int32_t ___flags_7;
	int32_t ___hashalg_8;
	StrongNameKeyPair_tD9AA282E59F4526338781AFD862680ED461FCCFD * ___keypair_9;
	uint8_t* ___publicKey_10;
	uint8_t* ___keyToken_11;
	int32_t ___versioncompat_12;
	Version_tDBE6876C59B6F56D4F8CAA03851177ABC6FE0DFD * ___version_13;
	int32_t ___processor_architecture_14;
	int32_t ___contentType_15;
};
#endif // ASSEMBLYNAME_T6F3EC58113268060348EE894DCB46F6EF6BBBB82_H
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
#ifndef SQLITEBASE_T59AAE9C52C98137708374575A69B76DB362B4699_H
#define SQLITEBASE_T59AAE9C52C98137708374575A69B76DB362B4699_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.SQLiteBase
struct  SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699  : public SqliteConvert_t9FED20EF4CA9E373EBD857ECBA9C74B6307EE6E7
{
public:

public:
};

struct SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699_StaticFields
{
public:
	// System.Object Mono.Data.Sqlite.SQLiteBase::_lock
	RuntimeObject * ____lock_13;

public:
	inline static int32_t get_offset_of__lock_13() { return static_cast<int32_t>(offsetof(SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699_StaticFields, ____lock_13)); }
	inline RuntimeObject * get__lock_13() const { return ____lock_13; }
	inline RuntimeObject ** get_address_of__lock_13() { return &____lock_13; }
	inline void set__lock_13(RuntimeObject * value)
	{
		____lock_13 = value;
		Il2CppCodeGenWriteBarrier((&____lock_13), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SQLITEBASE_T59AAE9C52C98137708374575A69B76DB362B4699_H
#ifndef SQLITECALLBACK_TD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22_H
#define SQLITECALLBACK_TD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.SQLiteCallback
struct  SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SQLITECALLBACK_TD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22_H
#ifndef SQLITECOLLATION_T14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B_H
#define SQLITECOLLATION_T14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.SQLiteCollation
struct  SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SQLITECOLLATION_T14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B_H
#ifndef SQLITECOMMITCALLBACK_T4A2F244F9FCADC58BAEFCDB1F9A4AEA018294B4F_H
#define SQLITECOMMITCALLBACK_T4A2F244F9FCADC58BAEFCDB1F9A4AEA018294B4F_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.SQLiteCommitCallback
struct  SQLiteCommitCallback_t4A2F244F9FCADC58BAEFCDB1F9A4AEA018294B4F  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SQLITECOMMITCALLBACK_T4A2F244F9FCADC58BAEFCDB1F9A4AEA018294B4F_H
#ifndef SQLITEFINALCALLBACK_TDADE001E38D3B50F9259C9D956A11D3B4D875453_H
#define SQLITEFINALCALLBACK_TDADE001E38D3B50F9259C9D956A11D3B4D875453_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.SQLiteFinalCallback
struct  SQLiteFinalCallback_tDADE001E38D3B50F9259C9D956A11D3B4D875453  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SQLITEFINALCALLBACK_TDADE001E38D3B50F9259C9D956A11D3B4D875453_H
#ifndef SQLITEROLLBACKCALLBACK_T0879E30A50B184087AFBA2EC348DAF30A4646D8A_H
#define SQLITEROLLBACKCALLBACK_T0879E30A50B184087AFBA2EC348DAF30A4646D8A_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.SQLiteRollbackCallback
struct  SQLiteRollbackCallback_t0879E30A50B184087AFBA2EC348DAF30A4646D8A  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SQLITEROLLBACKCALLBACK_T0879E30A50B184087AFBA2EC348DAF30A4646D8A_H
#ifndef SQLITEUPDATECALLBACK_T3252735A38A0D75E6E9CB742FBFB194CD942712F_H
#define SQLITEUPDATECALLBACK_T3252735A38A0D75E6E9CB742FBFB194CD942712F_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.SQLiteUpdateCallback
struct  SQLiteUpdateCallback_t3252735A38A0D75E6E9CB742FBFB194CD942712F  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SQLITEUPDATECALLBACK_T3252735A38A0D75E6E9CB742FBFB194CD942712F_H
#ifndef SQLITECOMMANDBUILDER_TB1BC265E1A177F0CEC2518E29F44C25E6CFBFB64_H
#define SQLITECOMMANDBUILDER_TB1BC265E1A177F0CEC2518E29F44C25E6CFBFB64_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.SqliteCommandBuilder
struct  SqliteCommandBuilder_tB1BC265E1A177F0CEC2518E29F44C25E6CFBFB64  : public DbCommandBuilder_t09ABFF5C5CEC0E32ED84FA0EA08D9631CAC24CD4
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SQLITECOMMANDBUILDER_TB1BC265E1A177F0CEC2518E29F44C25E6CFBFB64_H
#ifndef SQLITEEXCEPTION_T41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6_H
#define SQLITEEXCEPTION_T41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Data.Sqlite.SqliteException
struct  SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6  : public DbException_t7601D64CEA3E4A5396F01EDC71423DE6209F7F0D
{
public:
	// Mono.Data.Sqlite.SQLiteErrorCode Mono.Data.Sqlite.SqliteException::_errorCode
	int32_t ____errorCode_17;

public:
	inline static int32_t get_offset_of__errorCode_17() { return static_cast<int32_t>(offsetof(SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6, ____errorCode_17)); }
	inline int32_t get__errorCode_17() const { return ____errorCode_17; }
	inline int32_t* get_address_of__errorCode_17() { return &____errorCode_17; }
	inline void set__errorCode_17(int32_t value)
	{
		____errorCode_17 = value;
	}
};

struct SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6_StaticFields
{
public:
	// System.String[] Mono.Data.Sqlite.SqliteException::_errorMessages
	StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* ____errorMessages_18;

public:
	inline static int32_t get_offset_of__errorMessages_18() { return static_cast<int32_t>(offsetof(SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6_StaticFields, ____errorMessages_18)); }
	inline StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* get__errorMessages_18() const { return ____errorMessages_18; }
	inline StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E** get_address_of__errorMessages_18() { return &____errorMessages_18; }
	inline void set__errorMessages_18(StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* value)
	{
		____errorMessages_18 = value;
		Il2CppCodeGenWriteBarrier((&____errorMessages_18), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SQLITEEXCEPTION_T41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6_H
// System.String[]
struct StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) String_t* m_Items[1];

public:
	inline String_t* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline String_t** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, String_t* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
	inline String_t* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline String_t** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, String_t* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
};
// System.Reflection.Assembly[]
struct AssemblyU5BU5D_t90BF014AA048450526A42C74F9583341A138DE58  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) Assembly_t * m_Items[1];

public:
	inline Assembly_t * GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Assembly_t ** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Assembly_t * value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
	inline Assembly_t * GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Assembly_t ** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Assembly_t * value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
};
// System.Type[]
struct TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) Type_t * m_Items[1];

public:
	inline Type_t * GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Type_t ** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Type_t * value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
	inline Type_t * GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Type_t ** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Type_t * value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
};
// System.Reflection.AssemblyName[]
struct AssemblyNameU5BU5D_tE1C9584468498B9897F558EE8EF4872260CEB34B  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82 * m_Items[1];

public:
	inline AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82 * GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82 ** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82 * value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
	inline AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82 * GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82 ** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82 * value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
};
// System.Object[]
struct ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) RuntimeObject * m_Items[1];

public:
	inline RuntimeObject * GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline RuntimeObject ** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, RuntimeObject * value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
	inline RuntimeObject * GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline RuntimeObject ** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, RuntimeObject * value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
};
// System.IntPtr[]
struct IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) intptr_t m_Items[1];

public:
	inline intptr_t GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline intptr_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, intptr_t value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline intptr_t GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline intptr_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, intptr_t value)
	{
		m_Items[index] = value;
	}
};
// System.Byte[]
struct ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) uint8_t m_Items[1];

public:
	inline uint8_t GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline uint8_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, uint8_t value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline uint8_t GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline uint8_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, uint8_t value)
	{
		m_Items[index] = value;
	}
};
// Mono.Data.Sqlite.SqliteFunction[]
struct SqliteFunctionU5BU5D_t8AFADE2E07F0DC165BCF00EA921B1DB88D1A160F  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * m_Items[1];

public:
	inline SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B ** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
	inline SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B ** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
};
// Mono.Data.Sqlite.SqliteKeyReader_KeyInfo[]
struct KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC  m_Items[1];

public:
	inline KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC  GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC * GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC  value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC  GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC * GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC  value)
	{
		m_Items[index] = value;
	}
};
// Mono.Data.Sqlite.SqliteParameter[]
struct SqliteParameterU5BU5D_t76F2417476AE80EE92606466B015185F4EEF2C27  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * m_Items[1];

public:
	inline SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E ** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
	inline SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E ** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
};
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


// System.Void System.Collections.Generic.List`1<System.Object>::.ctor()
extern "C" IL2CPP_METHOD_ATTR void List_1__ctor_mC832F1AC0F814BAEB19175F5D7972A7507508BC3_gshared (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Object>::Add(!0)
extern "C" IL2CPP_METHOD_ATTR void List_1_Add_m6930161974C7504C80F52EC379EF012387D43138_gshared (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * __this, RuntimeObject * p0, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.Dictionary`2<System.Int64,System.Object>::TryGetValue(!0,!1&)
extern "C" IL2CPP_METHOD_ATTR bool Dictionary_2_TryGetValue_mDD1A5B9F98EE04B7825F52A2FD377899EA149320_gshared (Dictionary_2_tBB5CC0896C16F33861F997E1B67002AC4E1F2B8A * __this, int64_t p0, RuntimeObject ** p1, const RuntimeMethod* method);
// System.Void System.Collections.Generic.Dictionary`2<System.Int64,System.Object>::set_Item(!0,!1)
extern "C" IL2CPP_METHOD_ATTR void Dictionary_2_set_Item_m54FAE6489E4A42730C1AC54F76F67C882D4C9846_gshared (Dictionary_2_tBB5CC0896C16F33861F997E1B67002AC4E1F2B8A * __this, int64_t p0, RuntimeObject * p1, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.Dictionary`2<System.Int64,System.Object>::ContainsKey(!0)
extern "C" IL2CPP_METHOD_ATTR bool Dictionary_2_ContainsKey_mB20EE6684ACB512F860355B45F79CE2FE1AE8C93_gshared (Dictionary_2_tBB5CC0896C16F33861F997E1B67002AC4E1F2B8A * __this, int64_t p0, const RuntimeMethod* method);
// !1 System.Collections.Generic.Dictionary`2<System.Int64,System.Object>::get_Item(!0)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * Dictionary_2_get_Item_mA427841724835476406634CD55007428001A1D7F_gshared (Dictionary_2_tBB5CC0896C16F33861F997E1B67002AC4E1F2B8A * __this, int64_t p0, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.Dictionary`2<System.Int64,System.Object>::Remove(!0)
extern "C" IL2CPP_METHOD_ATTR bool Dictionary_2_Remove_mCDBAD7EE528BEBECA62C17EB7EB73FC3F6ACCBA6_gshared (Dictionary_2_tBB5CC0896C16F33861F997E1B67002AC4E1F2B8A * __this, int64_t p0, const RuntimeMethod* method);
// System.Collections.Generic.Dictionary`2/Enumerator<!0,!1> System.Collections.Generic.Dictionary`2<System.Int64,System.Object>::GetEnumerator()
extern "C" IL2CPP_METHOD_ATTR Enumerator_tDCE19FCEB15DD898D040471AAA04653C12CE59D2  Dictionary_2_GetEnumerator_mEC628ABAA8EEEE5BC1698F7263567D87D4F58404_gshared (Dictionary_2_tBB5CC0896C16F33861F997E1B67002AC4E1F2B8A * __this, const RuntimeMethod* method);
// System.Collections.Generic.KeyValuePair`2<!0,!1> System.Collections.Generic.Dictionary`2/Enumerator<System.Int64,System.Object>::get_Current()
extern "C" IL2CPP_METHOD_ATTR KeyValuePair_2_t63B92AF862B96BB211B19E9A360065FE8541A53E  Enumerator_get_Current_m08476ACAA0BDB801C4CE66D6DBE9D18FB1AE7E33_gshared (Enumerator_tDCE19FCEB15DD898D040471AAA04653C12CE59D2 * __this, const RuntimeMethod* method);
// !1 System.Collections.Generic.KeyValuePair`2<System.Int64,System.Object>::get_Value()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * KeyValuePair_2_get_Value_mB64B0651D2EC13F5D4A9B8625BCE7034807D5B60_gshared (KeyValuePair_2_t63B92AF862B96BB211B19E9A360065FE8541A53E * __this, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.Dictionary`2/Enumerator<System.Int64,System.Object>::MoveNext()
extern "C" IL2CPP_METHOD_ATTR bool Enumerator_MoveNext_mD3ACB0905F8A989F60564BFB24F0D55BD633A175_gshared (Enumerator_tDCE19FCEB15DD898D040471AAA04653C12CE59D2 * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.Dictionary`2/Enumerator<System.Int64,System.Object>::Dispose()
extern "C" IL2CPP_METHOD_ATTR void Enumerator_Dispose_m6B5A312AE1B3AB74CA5D9596FFC9D13208ABA85A_gshared (Enumerator_tDCE19FCEB15DD898D040471AAA04653C12CE59D2 * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.Dictionary`2<System.Int64,System.Object>::Clear()
extern "C" IL2CPP_METHOD_ATTR void Dictionary_2_Clear_m6E5E7DD9B41048453B6044632620EC538A060E72_gshared (Dictionary_2_tBB5CC0896C16F33861F997E1B67002AC4E1F2B8A * __this, const RuntimeMethod* method);
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
// System.Void System.Collections.Generic.List`1<System.Object>::CopyTo(!0[],System.Int32)
extern "C" IL2CPP_METHOD_ATTR void List_1_CopyTo_mBC8DEE264FD7E346D098E28FB1D5096B0F9132FB_gshared (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * __this, ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* p0, int32_t p1, const RuntimeMethod* method);
// System.Void System.Collections.Generic.Dictionary`2<System.Object,System.Int32>::.ctor()
extern "C" IL2CPP_METHOD_ATTR void Dictionary_2__ctor_m56FBD260A4D190AD833E9B108B1E80A574AA62C4_gshared (Dictionary_2_t81923CE2A312318AE13F58085CCF7FA8D879B77A * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.Dictionary`2<System.Object,System.Object>::.ctor()
extern "C" IL2CPP_METHOD_ATTR void Dictionary_2__ctor_m2C7E51568033239B506E15E7804A0B8658246498_gshared (Dictionary_2_t32F25F093828AA9F93CB11C2A2B4648FD62A09BA * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteKeyReader/KeyInfo>::.ctor()
extern "C" IL2CPP_METHOD_ATTR void List_1__ctor_m7E6858F17402F616F6E74BB4E9C06624018F6BFE_gshared (List_1_tD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.Dictionary`2<System.Object,System.Int32>::Add(!0,!1)
extern "C" IL2CPP_METHOD_ATTR void Dictionary_2_Add_m786A1D72D4E499C0776742D3B2921F47E3A54545_gshared (Dictionary_2_t81923CE2A312318AE13F58085CCF7FA8D879B77A * __this, RuntimeObject * p0, int32_t p1, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.Dictionary`2<System.Object,System.Object>::ContainsKey(!0)
extern "C" IL2CPP_METHOD_ATTR bool Dictionary_2_ContainsKey_m4EBC00E16E83DA33851A551757D2B7332D5756B9_gshared (Dictionary_2_t32F25F093828AA9F93CB11C2A2B4648FD62A09BA * __this, RuntimeObject * p0, const RuntimeMethod* method);
// System.Void System.Collections.Generic.Dictionary`2<System.Object,System.Object>::Add(!0,!1)
extern "C" IL2CPP_METHOD_ATTR void Dictionary_2_Add_mC741BBB0A647C814227953DB9B23CB1BDF571C5B_gshared (Dictionary_2_t32F25F093828AA9F93CB11C2A2B4648FD62A09BA * __this, RuntimeObject * p0, RuntimeObject * p1, const RuntimeMethod* method);
// !1 System.Collections.Generic.Dictionary`2<System.Object,System.Object>::get_Item(!0)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * Dictionary_2_get_Item_m6625C3BA931A6EE5D6DB46B9E743B40AAA30010B_gshared (Dictionary_2_t32F25F093828AA9F93CB11C2A2B4648FD62A09BA * __this, RuntimeObject * p0, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.List`1<System.Object>::Contains(!0)
extern "C" IL2CPP_METHOD_ATTR bool List_1_Contains_mE08D561E86879A26245096C572A8593279383FDB_gshared (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * __this, RuntimeObject * p0, const RuntimeMethod* method);
// System.Collections.Generic.Dictionary`2/Enumerator<!0,!1> System.Collections.Generic.Dictionary`2<System.Object,System.Object>::GetEnumerator()
extern "C" IL2CPP_METHOD_ATTR Enumerator_tED23DFBF3911229086C71CCE7A54D56F5FFB34CB  Dictionary_2_GetEnumerator_mF1CF1D13F3E70C6D20D96D9AC88E44454E4C0053_gshared (Dictionary_2_t32F25F093828AA9F93CB11C2A2B4648FD62A09BA * __this, const RuntimeMethod* method);
// System.Collections.Generic.KeyValuePair`2<!0,!1> System.Collections.Generic.Dictionary`2/Enumerator<System.Object,System.Object>::get_Current()
extern "C" IL2CPP_METHOD_ATTR KeyValuePair_2_t23481547E419E16E3B96A303578C1EB685C99EEE  Enumerator_get_Current_m5B32A9FC8294CB723DCD1171744B32E1775B6318_gshared (Enumerator_tED23DFBF3911229086C71CCE7A54D56F5FFB34CB * __this, const RuntimeMethod* method);
// !1 System.Collections.Generic.KeyValuePair`2<System.Object,System.Object>::get_Value()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * KeyValuePair_2_get_Value_m8C7B882C4D425535288FAAD08EAF11D289A43AEC_gshared (KeyValuePair_2_t23481547E419E16E3B96A303578C1EB685C99EEE * __this, const RuntimeMethod* method);
// !0 System.Collections.Generic.List`1<System.Object>::get_Item(System.Int32)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * List_1_get_Item_mFDB8AD680C600072736579BBF5F38F7416396588_gshared (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * __this, int32_t p0, const RuntimeMethod* method);
// !0 System.Collections.Generic.KeyValuePair`2<System.Object,System.Object>::get_Key()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * KeyValuePair_2_get_Key_m9D4E9BCBAB1BE560871A0889C851FC22A09975F4_gshared (KeyValuePair_2_t23481547E419E16E3B96A303578C1EB685C99EEE * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Object>::RemoveAt(System.Int32)
extern "C" IL2CPP_METHOD_ATTR void List_1_RemoveAt_m3CAF82E0FF61CD84E251E0F7231BBB867C9755C2_gshared (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * __this, int32_t p0, const RuntimeMethod* method);
// !1 System.Collections.Generic.Dictionary`2<System.Object,System.Int32>::get_Item(!0)
extern "C" IL2CPP_METHOD_ATTR int32_t Dictionary_2_get_Item_m6F2BB7FC61476D210FA060962086B5B21FB1B6CA_gshared (Dictionary_2_t81923CE2A312318AE13F58085CCF7FA8D879B77A * __this, RuntimeObject * p0, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Object>::CopyTo(!0[])
extern "C" IL2CPP_METHOD_ATTR void List_1_CopyTo_m54E18E9C1ECE23383EF0EA1E98330235DEAD7B39_gshared (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * __this, ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* p0, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteKeyReader/KeyInfo>::Add(!0)
extern "C" IL2CPP_METHOD_ATTR void List_1_Add_m335FACF62F79155D36F4BD6E4CE541AFBCCCDAEA_gshared (List_1_tD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD * __this, KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC  p0, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.Dictionary`2/Enumerator<System.Object,System.Object>::MoveNext()
extern "C" IL2CPP_METHOD_ATTR bool Enumerator_MoveNext_m9B9FB07EC2C1D82E921C9316A4E0901C933BBF6C_gshared (Enumerator_tED23DFBF3911229086C71CCE7A54D56F5FFB34CB * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.Dictionary`2/Enumerator<System.Object,System.Object>::Dispose()
extern "C" IL2CPP_METHOD_ATTR void Enumerator_Dispose_mE363888280B72ED50538416C060EF9FC94B3BB00_gshared (Enumerator_tED23DFBF3911229086C71CCE7A54D56F5FFB34CB * __this, const RuntimeMethod* method);
// System.Int32 System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteKeyReader/KeyInfo>::get_Count()
extern "C" IL2CPP_METHOD_ATTR int32_t List_1_get_Count_m0283B39AA2691EE274CBD01927A6175AC6C2F5BF_gshared (List_1_tD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteKeyReader/KeyInfo>::CopyTo(!0[])
extern "C" IL2CPP_METHOD_ATTR void List_1_CopyTo_mD3FBBD792230E4756C75F7F245B815CFEB65836A_gshared (List_1_tD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD * __this, KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* p0, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Object>::Clear()
extern "C" IL2CPP_METHOD_ATTR void List_1_Clear_mC5CFC6C9F3007FC24FE020198265D4B5B0659FFC_gshared (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * __this, const RuntimeMethod* method);
// System.Int32 System.Collections.Generic.List`1<System.Object>::IndexOf(!0)
extern "C" IL2CPP_METHOD_ATTR int32_t List_1_IndexOf_m98E4245F46A6D90AE3E96EFF3880D50ED6E2C728_gshared (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * __this, RuntimeObject * p0, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Object>::Insert(System.Int32,!0)
extern "C" IL2CPP_METHOD_ATTR void List_1_Insert_m327E513FB78F72441BBF2756AFCC788F89A4FA52_gshared (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * __this, int32_t p0, RuntimeObject * p1, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.List`1<System.Object>::Remove(!0)
extern "C" IL2CPP_METHOD_ATTR bool List_1_Remove_m908B647BB9F807676DACE34E3E73475C3C3751D4_gshared (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * __this, RuntimeObject * p0, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Object>::set_Item(System.Int32,!0)
extern "C" IL2CPP_METHOD_ATTR void List_1_set_Item_m451452782977192583A6374A799099FCCD9BD83E_gshared (List_1_t05CC3C859AB5E6024394EF9A42E3E696628CA02D * __this, int32_t p0, RuntimeObject * p1, const RuntimeMethod* method);

// System.Void System.Data.Common.DbException::.ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
extern "C" IL2CPP_METHOD_ATTR void DbException__ctor_mF3F74F35C2E4A18D1453D34B20D717AFC6E2B26E (DbException_t7601D64CEA3E4A5396F01EDC71423DE6209F7F0D * __this, SerializationInfo_t1BB80E9C9DEA52DBF464487234B045E2930ADA26 * p0, StreamingContext_t2CCDC54E0E8D078AF4A50E3A8B921B828A900034  p1, const RuntimeMethod* method);
// System.String Mono.Data.Sqlite.SqliteException::GetStockErrorMessage(System.Int32,System.String)
extern "C" IL2CPP_METHOD_ATTR String_t* SqliteException_GetStockErrorMessage_mE888DD0F857775252F88B86D4B072AFADC9D9BC3 (int32_t ___errorCode0, String_t* ___errorMessage1, const RuntimeMethod* method);
// System.Void System.Data.Common.DbException::.ctor(System.String)
extern "C" IL2CPP_METHOD_ATTR void DbException__ctor_m8D3347951D17C9738FD28FC7B47443DFF1EE8BAC (DbException_t7601D64CEA3E4A5396F01EDC71423DE6209F7F0D * __this, String_t* p0, const RuntimeMethod* method);
// System.Void System.Data.Common.DbException::.ctor()
extern "C" IL2CPP_METHOD_ATTR void DbException__ctor_m8ED5675B5AF207A2B903B620C936BEA5D27D2FAE (DbException_t7601D64CEA3E4A5396F01EDC71423DE6209F7F0D * __this, const RuntimeMethod* method);
// System.Int32 System.String::get_Length()
extern "C" IL2CPP_METHOD_ATTR int32_t String_get_Length_mD48C8A16A5CF1914F330DCE82D9BE15C3BEDD018 (String_t* __this, const RuntimeMethod* method);
// System.String System.String::Concat(System.String,System.String)
extern "C" IL2CPP_METHOD_ATTR String_t* String_Concat_mB78D0094592718DA6D5DB6C712A9C225631666BE (String_t* p0, String_t* p1, const RuntimeMethod* method);
// System.Void System.Data.Common.DbProviderFactory::.ctor()
extern "C" IL2CPP_METHOD_ATTR void DbProviderFactory__ctor_m1376F504CE5DDF21DAFA220AB675124C32B285CE (DbProviderFactory_tD097542E2A2591557E9349A9AA0C1DD301D50DD4 * __this, const RuntimeMethod* method);
// System.Void Mono.Data.Sqlite.SqliteFactory::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SqliteFactory__ctor_mB4B0F6DF58CF3726649B08768131170FC0A9F01B (SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7 * __this, const RuntimeMethod* method);
// System.Type System.Type::GetType(System.String,System.Boolean)
extern "C" IL2CPP_METHOD_ATTR Type_t * Type_GetType_m8A8A6481B24551476F2AF999A970AD705BA68C7A (String_t* p0, bool p1, const RuntimeMethod* method);
// System.Type System.Type::GetTypeFromHandle(System.RuntimeTypeHandle)
extern "C" IL2CPP_METHOD_ATTR Type_t * Type_GetTypeFromHandle_m9DC58ADF0512987012A8A016FB64B068F3B1AFF6 (RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  p0, const RuntimeMethod* method);
// System.Object Mono.Data.Sqlite.SqliteFactory::GetSQLiteProviderServicesInstance()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * SqliteFactory_GetSQLiteProviderServicesInstance_m54787EE0DDCA751DC83B454F4A69E50725B0BF77 (SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7 * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteFunctionAttribute>::.ctor()
inline void List_1__ctor_mD4890D8BA3B1549E470AFD135AFB74728CD64516 (List_1_t575BD1306846C6646814C99C87872FD64E8954AB * __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_t575BD1306846C6646814C99C87872FD64E8954AB *, const RuntimeMethod*))List_1__ctor_mC832F1AC0F814BAEB19175F5D7972A7507508BC3_gshared)(__this, method);
}
// System.AppDomain System.AppDomain::get_CurrentDomain()
extern "C" IL2CPP_METHOD_ATTR AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8 * AppDomain_get_CurrentDomain_m3D3D52C9382D6853E49551DA6182DBC5F1118BF0 (const RuntimeMethod* method);
// System.Reflection.Assembly[] System.AppDomain::GetAssemblies()
extern "C" IL2CPP_METHOD_ATTR AssemblyU5BU5D_t90BF014AA048450526A42C74F9583341A138DE58* AppDomain_GetAssemblies_mF1A63ADFC80562168DF846017BB72CAB09298A23 (AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8 * __this, const RuntimeMethod* method);
// System.Reflection.Assembly System.Reflection.Assembly::GetCallingAssembly()
extern "C" IL2CPP_METHOD_ATTR Assembly_t * Assembly_GetCallingAssembly_m0DB9F5D2B9770113FF2E239A9EB0DB0EC3A6E384 (const RuntimeMethod* method);
// System.String System.Reflection.AssemblyName::get_Name()
extern "C" IL2CPP_METHOD_ATTR String_t* AssemblyName_get_Name_m6EA5C18D2FF050D3AF58D4A21ED39D161DFF218B (AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82 * __this, const RuntimeMethod* method);
// System.Boolean System.String::op_Equality(System.String,System.String)
extern "C" IL2CPP_METHOD_ATTR bool String_op_Equality_m139F0E4195AE2F856019E63B241F36F016997FCE (String_t* p0, String_t* p1, const RuntimeMethod* method);
// System.Type[] System.Reflection.ReflectionTypeLoadException::get_Types()
extern "C" IL2CPP_METHOD_ATTR TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F* ReflectionTypeLoadException_get_Types_mF7DBBFDB3486667189D72A2A0B95DF42D463E3DE (ReflectionTypeLoadException_t1306B3A246E2959E8F23575AAAB9D59945314115 * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteFunctionAttribute>::Add(!0)
inline void List_1_Add_mDB86C4D19D3AFD79C5C0CEB04AC08E5A8C5353D6 (List_1_t575BD1306846C6646814C99C87872FD64E8954AB * __this, SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD * p0, const RuntimeMethod* method)
{
	((  void (*) (List_1_t575BD1306846C6646814C99C87872FD64E8954AB *, SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD *, const RuntimeMethod*))List_1_Add_m6930161974C7504C80F52EC379EF012387D43138_gshared)(__this, p0, method);
}
// System.Void System.Runtime.InteropServices.Marshal::Copy(System.IntPtr,System.IntPtr[],System.Int32,System.Int32)
extern "C" IL2CPP_METHOD_ATTR void Marshal_Copy_m1E0083CB21F1FE2109590AF0916893C349871CED (intptr_t p0, IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD* p1, int32_t p2, int32_t p3, const RuntimeMethod* method);
// System.DateTime Mono.Data.Sqlite.SqliteConvert::ToDateTime(System.String)
extern "C" IL2CPP_METHOD_ATTR DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132  SqliteConvert_ToDateTime_mF34ED11F61E5E5DC34567DBA1007F426E408DA62 (SqliteConvert_t9FED20EF4CA9E373EBD857ECBA9C74B6307EE6E7 * __this, String_t* ___dateText0, const RuntimeMethod* method);
// System.Type System.Object::GetType()
extern "C" IL2CPP_METHOD_ATTR Type_t * Object_GetType_m2E0B62414ECCAA3094B703790CE88CBB2F83EA60 (RuntimeObject * __this, const RuntimeMethod* method);
// System.String Mono.Data.Sqlite.SqliteConvert::ToString(System.DateTime)
extern "C" IL2CPP_METHOD_ATTR String_t* SqliteConvert_ToString_m69F17C6967A386680CBC71CE17F9358587A9E887 (SqliteConvert_t9FED20EF4CA9E373EBD857ECBA9C74B6307EE6E7 * __this, DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132  ___dateValue0, const RuntimeMethod* method);
// Mono.Data.Sqlite.TypeAffinity Mono.Data.Sqlite.SqliteConvert::TypeToAffinity(System.Type)
extern "C" IL2CPP_METHOD_ATTR int32_t SqliteConvert_TypeToAffinity_m98E047A53A1B862A3A5189FF172DAC05208DB41B (Type_t * ___typ0, const RuntimeMethod* method);
// System.Globalization.CultureInfo System.Globalization.CultureInfo::get_CurrentCulture()
extern "C" IL2CPP_METHOD_ATTR CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * CultureInfo_get_CurrentCulture_mD86F3D8E5D332FB304F80D9B9CA4DE849C2A6831 (const RuntimeMethod* method);
// System.Int64 System.Convert::ToInt64(System.Object,System.IFormatProvider)
extern "C" IL2CPP_METHOD_ATTR int64_t Convert_ToInt64_m8964FDE5D82FEC54106DBF35E1F67D70F6E73E29 (RuntimeObject * p0, RuntimeObject* p1, const RuntimeMethod* method);
// System.Double System.Convert::ToDouble(System.Object,System.IFormatProvider)
extern "C" IL2CPP_METHOD_ATTR double Convert_ToDouble_m053A47D87C59CA7A87D4E67E5E06368D775D7651 (RuntimeObject * p0, RuntimeObject* p1, const RuntimeMethod* method);
// System.Object[] Mono.Data.Sqlite.SqliteFunction::ConvertParams(System.Int32,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* SqliteFunction_ConvertParams_m3B967FF80BD969603C902F1DF9EB2704FBD0357D (SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * __this, int32_t ___nArgs0, intptr_t ___argsptr1, const RuntimeMethod* method);
// System.Void Mono.Data.Sqlite.SqliteFunction::SetReturnValue(System.IntPtr,System.Object)
extern "C" IL2CPP_METHOD_ATTR void SqliteFunction_SetReturnValue_mD2B822ACF24A89AE1902E00A3AED96982254D5C5 (SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * __this, intptr_t ___context0, RuntimeObject * ___returnValue1, const RuntimeMethod* method);
// System.String Mono.Data.Sqlite.SqliteConvert::UTF8ToString(System.IntPtr,System.Int32)
extern "C" IL2CPP_METHOD_ATTR String_t* SqliteConvert_UTF8ToString_m4491E391E180610172F5DB15472CA3836B3724A9 (intptr_t ___nativestring0, int32_t ___nativestringlen1, const RuntimeMethod* method);
// System.String Mono.Data.Sqlite.SQLite3_UTF16::UTF16ToString(System.IntPtr,System.Int32)
extern "C" IL2CPP_METHOD_ATTR String_t* SQLite3_UTF16_UTF16ToString_mEE1F2F51B58D112761CD33DCC1ADFF2B8F3412CD (intptr_t ___b0, int32_t ___nbytelen1, const RuntimeMethod* method);
// System.Int64 System.IntPtr::op_Explicit(System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR int64_t IntPtr_op_Explicit_m254924E8680FCCF870F18064DC0B114445B09172 (intptr_t p0, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.Dictionary`2<System.Int64,Mono.Data.Sqlite.SqliteFunction/AggregateData>::TryGetValue(!0,!1&)
inline bool Dictionary_2_TryGetValue_m7F2FAA8FE25A7B605BF2247E4719C18AD9D18B18 (Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 * __this, int64_t p0, AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755 ** p1, const RuntimeMethod* method)
{
	return ((  bool (*) (Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 *, int64_t, AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755 **, const RuntimeMethod*))Dictionary_2_TryGetValue_mDD1A5B9F98EE04B7825F52A2FD377899EA149320_gshared)(__this, p0, p1, method);
}
// System.Void Mono.Data.Sqlite.SqliteFunction/AggregateData::.ctor()
extern "C" IL2CPP_METHOD_ATTR void AggregateData__ctor_mD2DE3A53E4BAED4BB352B499ED040C24824FD6B3 (AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755 * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.Dictionary`2<System.Int64,Mono.Data.Sqlite.SqliteFunction/AggregateData>::set_Item(!0,!1)
inline void Dictionary_2_set_Item_m6307BB9AD542728546442D9CE477BC5815AE1412 (Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 * __this, int64_t p0, AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755 * p1, const RuntimeMethod* method)
{
	((  void (*) (Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 *, int64_t, AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755 *, const RuntimeMethod*))Dictionary_2_set_Item_m54FAE6489E4A42730C1AC54F76F67C882D4C9846_gshared)(__this, p0, p1, method);
}
// System.Boolean System.Collections.Generic.Dictionary`2<System.Int64,Mono.Data.Sqlite.SqliteFunction/AggregateData>::ContainsKey(!0)
inline bool Dictionary_2_ContainsKey_m425FDC14DB7C7CAA236D528A12C3DB3577AD0C96 (Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 * __this, int64_t p0, const RuntimeMethod* method)
{
	return ((  bool (*) (Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 *, int64_t, const RuntimeMethod*))Dictionary_2_ContainsKey_mB20EE6684ACB512F860355B45F79CE2FE1AE8C93_gshared)(__this, p0, method);
}
// !1 System.Collections.Generic.Dictionary`2<System.Int64,Mono.Data.Sqlite.SqliteFunction/AggregateData>::get_Item(!0)
inline AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755 * Dictionary_2_get_Item_m1A6FE099B56685CD45A75254ABA787E313A5D792 (Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 * __this, int64_t p0, const RuntimeMethod* method)
{
	return ((  AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755 * (*) (Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 *, int64_t, const RuntimeMethod*))Dictionary_2_get_Item_mA427841724835476406634CD55007428001A1D7F_gshared)(__this, p0, method);
}
// System.Boolean System.Collections.Generic.Dictionary`2<System.Int64,Mono.Data.Sqlite.SqliteFunction/AggregateData>::Remove(!0)
inline bool Dictionary_2_Remove_mFA8845405F1AE81B12E4078977BE667CCC962ECB (Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 * __this, int64_t p0, const RuntimeMethod* method)
{
	return ((  bool (*) (Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 *, int64_t, const RuntimeMethod*))Dictionary_2_Remove_mCDBAD7EE528BEBECA62C17EB7EB73FC3F6ACCBA6_gshared)(__this, p0, method);
}
// System.Collections.Generic.Dictionary`2/Enumerator<!0,!1> System.Collections.Generic.Dictionary`2<System.Int64,Mono.Data.Sqlite.SqliteFunction/AggregateData>::GetEnumerator()
inline Enumerator_tC72BD0EE9002D5F9476F8E5D172DD8D523493303  Dictionary_2_GetEnumerator_m24CA20639785613D0692E7B7813D7525CA3E3FCF (Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 * __this, const RuntimeMethod* method)
{
	return ((  Enumerator_tC72BD0EE9002D5F9476F8E5D172DD8D523493303  (*) (Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 *, const RuntimeMethod*))Dictionary_2_GetEnumerator_mEC628ABAA8EEEE5BC1698F7263567D87D4F58404_gshared)(__this, method);
}
// System.Collections.Generic.KeyValuePair`2<!0,!1> System.Collections.Generic.Dictionary`2/Enumerator<System.Int64,Mono.Data.Sqlite.SqliteFunction/AggregateData>::get_Current()
inline KeyValuePair_2_t93C466ABB3C1789B9638D6DAE171650D781D5955  Enumerator_get_Current_m48D218F99C929FE08EB673C9DC0B5A5FBDE5820F (Enumerator_tC72BD0EE9002D5F9476F8E5D172DD8D523493303 * __this, const RuntimeMethod* method)
{
	return ((  KeyValuePair_2_t93C466ABB3C1789B9638D6DAE171650D781D5955  (*) (Enumerator_tC72BD0EE9002D5F9476F8E5D172DD8D523493303 *, const RuntimeMethod*))Enumerator_get_Current_m08476ACAA0BDB801C4CE66D6DBE9D18FB1AE7E33_gshared)(__this, method);
}
// !1 System.Collections.Generic.KeyValuePair`2<System.Int64,Mono.Data.Sqlite.SqliteFunction/AggregateData>::get_Value()
inline AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755 * KeyValuePair_2_get_Value_m37365A13759E8A8548BE04A755D69B74D6BBF2AB (KeyValuePair_2_t93C466ABB3C1789B9638D6DAE171650D781D5955 * __this, const RuntimeMethod* method)
{
	return ((  AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755 * (*) (KeyValuePair_2_t93C466ABB3C1789B9638D6DAE171650D781D5955 *, const RuntimeMethod*))KeyValuePair_2_get_Value_mB64B0651D2EC13F5D4A9B8625BCE7034807D5B60_gshared)(__this, method);
}
// System.Boolean System.Collections.Generic.Dictionary`2/Enumerator<System.Int64,Mono.Data.Sqlite.SqliteFunction/AggregateData>::MoveNext()
inline bool Enumerator_MoveNext_m37DC9F68F91CA42C4DF0800613544AFFE63A4076 (Enumerator_tC72BD0EE9002D5F9476F8E5D172DD8D523493303 * __this, const RuntimeMethod* method)
{
	return ((  bool (*) (Enumerator_tC72BD0EE9002D5F9476F8E5D172DD8D523493303 *, const RuntimeMethod*))Enumerator_MoveNext_mD3ACB0905F8A989F60564BFB24F0D55BD633A175_gshared)(__this, method);
}
// System.Void System.Collections.Generic.Dictionary`2/Enumerator<System.Int64,Mono.Data.Sqlite.SqliteFunction/AggregateData>::Dispose()
inline void Enumerator_Dispose_m2B9B3D7D2D9369C06369FD5D7D9A75660ADF6A46 (Enumerator_tC72BD0EE9002D5F9476F8E5D172DD8D523493303 * __this, const RuntimeMethod* method)
{
	((  void (*) (Enumerator_tC72BD0EE9002D5F9476F8E5D172DD8D523493303 *, const RuntimeMethod*))Enumerator_Dispose_m6B5A312AE1B3AB74CA5D9596FFC9D13208ABA85A_gshared)(__this, method);
}
// System.Void System.Collections.Generic.Dictionary`2<System.Int64,Mono.Data.Sqlite.SqliteFunction/AggregateData>::Clear()
inline void Dictionary_2_Clear_m850B2AC5BADCAF602C38B462F787A0D00CD3D950 (Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 * __this, const RuntimeMethod* method)
{
	((  void (*) (Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 *, const RuntimeMethod*))Dictionary_2_Clear_m6E5E7DD9B41048453B6044632620EC538A060E72_gshared)(__this, method);
}
// System.Void System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteFunction>::.ctor()
inline void List_1__ctor_m0CAC003C972BC97F57D0BBC18BCF1BD28F6F18B3 (List_1_tC332B4E87767ADFB1672A499D53D94AE897CD4A3 * __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_tC332B4E87767ADFB1672A499D53D94AE897CD4A3 *, const RuntimeMethod*))List_1__ctor_mC832F1AC0F814BAEB19175F5D7972A7507508BC3_gshared)(__this, method);
}
// System.Collections.Generic.List`1/Enumerator<!0> System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteFunctionAttribute>::GetEnumerator()
inline Enumerator_tB5FE7F21928FA8D45CBB7BD3D57A481548319510  List_1_GetEnumerator_m92C59AC36F29D46CF1B7938CDC2C2241FC24907E (List_1_t575BD1306846C6646814C99C87872FD64E8954AB * __this, const RuntimeMethod* method)
{
	return ((  Enumerator_tB5FE7F21928FA8D45CBB7BD3D57A481548319510  (*) (List_1_t575BD1306846C6646814C99C87872FD64E8954AB *, const RuntimeMethod*))List_1_GetEnumerator_m52CC760E475D226A2B75048D70C4E22692F9F68D_gshared)(__this, method);
}
// !0 System.Collections.Generic.List`1/Enumerator<Mono.Data.Sqlite.SqliteFunctionAttribute>::get_Current()
inline SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD * Enumerator_get_Current_m7FA4FE3198E9A2BC1613C4C7107826F8FF14C1A3 (Enumerator_tB5FE7F21928FA8D45CBB7BD3D57A481548319510 * __this, const RuntimeMethod* method)
{
	return ((  SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD * (*) (Enumerator_tB5FE7F21928FA8D45CBB7BD3D57A481548319510 *, const RuntimeMethod*))Enumerator_get_Current_mD7829C7E8CFBEDD463B15A951CDE9B90A12CC55C_gshared)(__this, method);
}
// System.Object System.Activator::CreateInstance(System.Type)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * Activator_CreateInstance_mD06EE47879F606317C6DA91FB63E678CABAC6A16 (Type_t * p0, const RuntimeMethod* method);
// Mono.Data.Sqlite.FunctionType Mono.Data.Sqlite.SqliteFunctionAttribute::get_FuncType()
extern "C" IL2CPP_METHOD_ATTR int32_t SqliteFunctionAttribute_get_FuncType_m76454A5884A9DE9ACDABE2933B31A24B55CAC0E8 (SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD * __this, const RuntimeMethod* method);
// System.Void Mono.Data.Sqlite.SQLiteCallback::.ctor(System.Object,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR void SQLiteCallback__ctor_m01987E2713E968B8AA6EB91D9087D47FF08F870F (SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22 * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method);
// System.Void Mono.Data.Sqlite.SQLiteFinalCallback::.ctor(System.Object,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR void SQLiteFinalCallback__ctor_m7D2143264323FCB90438120888189D043A4133AF (SQLiteFinalCallback_tDADE001E38D3B50F9259C9D956A11D3B4D875453 * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method);
// System.Void Mono.Data.Sqlite.SQLiteCollation::.ctor(System.Object,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR void SQLiteCollation__ctor_m2DC974FD27FD29ADFCC89CDF0BA7869142C08639 (SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method);
// System.String Mono.Data.Sqlite.SqliteFunctionAttribute::get_Name()
extern "C" IL2CPP_METHOD_ATTR String_t* SqliteFunctionAttribute_get_Name_mB76AE39FB2090190D34E5D4034C8AEECF5E97A69 (SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD * __this, const RuntimeMethod* method);
// System.Int32 Mono.Data.Sqlite.SqliteFunctionAttribute::get_Arguments()
extern "C" IL2CPP_METHOD_ATTR int32_t SqliteFunctionAttribute_get_Arguments_m9F8733EEEDC8E195831DED64B65822EA1684EE70 (SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteFunction>::Add(!0)
inline void List_1_Add_m2E293E26CF280C896A634CC8D9DD5E622583050F (List_1_tC332B4E87767ADFB1672A499D53D94AE897CD4A3 * __this, SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * p0, const RuntimeMethod* method)
{
	((  void (*) (List_1_tC332B4E87767ADFB1672A499D53D94AE897CD4A3 *, SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B *, const RuntimeMethod*))List_1_Add_m6930161974C7504C80F52EC379EF012387D43138_gshared)(__this, p0, method);
}
// System.Boolean System.Collections.Generic.List`1/Enumerator<Mono.Data.Sqlite.SqliteFunctionAttribute>::MoveNext()
inline bool Enumerator_MoveNext_mF5DE5F7301F752CEF6FC1274061C972E315C5018 (Enumerator_tB5FE7F21928FA8D45CBB7BD3D57A481548319510 * __this, const RuntimeMethod* method)
{
	return ((  bool (*) (Enumerator_tB5FE7F21928FA8D45CBB7BD3D57A481548319510 *, const RuntimeMethod*))Enumerator_MoveNext_m38B1099DDAD7EEDE2F4CDAB11C095AC784AC2E34_gshared)(__this, method);
}
// System.Void System.Collections.Generic.List`1/Enumerator<Mono.Data.Sqlite.SqliteFunctionAttribute>::Dispose()
inline void Enumerator_Dispose_mA0BB472958EA47C65935F98FBEF0EAACFEACCE0D (Enumerator_tB5FE7F21928FA8D45CBB7BD3D57A481548319510 * __this, const RuntimeMethod* method)
{
	((  void (*) (Enumerator_tB5FE7F21928FA8D45CBB7BD3D57A481548319510 *, const RuntimeMethod*))Enumerator_Dispose_m94D0DAE031619503CDA6E53C5C3CC78AF3139472_gshared)(__this, method);
}
// System.Int32 System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteFunction>::get_Count()
inline int32_t List_1_get_Count_m368529D7DE6BD7EBBA3E9FA3551350AFB4384EF8 (List_1_tC332B4E87767ADFB1672A499D53D94AE897CD4A3 * __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (List_1_tC332B4E87767ADFB1672A499D53D94AE897CD4A3 *, const RuntimeMethod*))List_1_get_Count_m507C9149FF7F83AAC72C29091E745D557DA47D22_gshared)(__this, method);
}
// System.Void System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteFunction>::CopyTo(!0[],System.Int32)
inline void List_1_CopyTo_m95F1898958F30634E03CFF8A0CDC2F863259B2F4 (List_1_tC332B4E87767ADFB1672A499D53D94AE897CD4A3 * __this, SqliteFunctionU5BU5D_t8AFADE2E07F0DC165BCF00EA921B1DB88D1A160F* p0, int32_t p1, const RuntimeMethod* method)
{
	((  void (*) (List_1_tC332B4E87767ADFB1672A499D53D94AE897CD4A3 *, SqliteFunctionU5BU5D_t8AFADE2E07F0DC165BCF00EA921B1DB88D1A160F*, int32_t, const RuntimeMethod*))List_1_CopyTo_mBC8DEE264FD7E346D098E28FB1D5096B0F9132FB_gshared)(__this, p0, p1, method);
}
// System.Void System.Object::.ctor()
extern "C" IL2CPP_METHOD_ATTR void Object__ctor_m925ECA5E85CA100E3FB86A4F9E15C120E9A184C0 (RuntimeObject * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.Dictionary`2<System.String,System.Int32>::.ctor()
inline void Dictionary_2__ctor_m20A5B6C6950ACF998FE28F7FACEA19C755593E62 (Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB * __this, const RuntimeMethod* method)
{
	((  void (*) (Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB *, const RuntimeMethod*))Dictionary_2__ctor_m56FBD260A4D190AD833E9B108B1E80A574AA62C4_gshared)(__this, method);
}
// System.Void System.Collections.Generic.Dictionary`2<System.String,System.Collections.Generic.List`1<System.String>>::.ctor()
inline void Dictionary_2__ctor_mEAAF465A79EE99997A8CF0556CEC5334BCE44EF2 (Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF * __this, const RuntimeMethod* method)
{
	((  void (*) (Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF *, const RuntimeMethod*))Dictionary_2__ctor_m2C7E51568033239B506E15E7804A0B8658246498_gshared)(__this, method);
}
// System.Void System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteKeyReader/KeyInfo>::.ctor()
inline void List_1__ctor_m7E6858F17402F616F6E74BB4E9C06624018F6BFE (List_1_tD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD * __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_tD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD *, const RuntimeMethod*))List_1__ctor_m7E6858F17402F616F6E74BB4E9C06624018F6BFE_gshared)(__this, method);
}
// System.Data.DataTable Mono.Data.Sqlite.SqliteConnection::GetSchema(System.String)
extern "C" IL2CPP_METHOD_ATTR DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * SqliteConnection_GetSchema_mCF5A4BDF8CA03884BF3739EA8152C5C11D47A20A (SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * __this, String_t* ___collectionName0, const RuntimeMethod* method);
// System.Data.DataRowCollection System.Data.DataTable::get_Rows()
extern "C" IL2CPP_METHOD_ATTR DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0 * DataTable_get_Rows_m905B0636C268095F62E08B89B97A034E6BC483D3 (DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * __this, const RuntimeMethod* method);
// System.Object System.Data.DataRow::get_Item(System.String)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * DataRow_get_Item_mECAC0A4B3584FB64E6A6AE1E6EAE91B7E9B11C89 (DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * __this, String_t* p0, const RuntimeMethod* method);
// System.Int32 System.Convert::ToInt32(System.Object)
extern "C" IL2CPP_METHOD_ATTR int32_t Convert_ToInt32_mCF1152AF4138C1DD7A16643B22EE69A38373EF86 (RuntimeObject * p0, const RuntimeMethod* method);
// System.Void System.Collections.Generic.Dictionary`2<System.String,System.Int32>::Add(!0,!1)
inline void Dictionary_2_Add_m5453726952CE3720733822DBF38A0091037F0F76 (Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB * __this, String_t* p0, int32_t p1, const RuntimeMethod* method)
{
	((  void (*) (Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB *, String_t*, int32_t, const RuntimeMethod*))Dictionary_2_Add_m786A1D72D4E499C0776742D3B2921F47E3A54545_gshared)(__this, p0, p1, method);
}
// System.Data.DataTable Mono.Data.Sqlite.SqliteDataReader::GetSchemaTable(System.Boolean,System.Boolean)
extern "C" IL2CPP_METHOD_ATTR DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * SqliteDataReader_GetSchemaTable_m5F91D4DA3EB1F87D6308258D2513A1DF32B3EB0F (SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * __this, bool ___wantUniqueInfo0, bool ___wantDefaultValue1, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.Dictionary`2<System.String,System.Collections.Generic.List`1<System.String>>::ContainsKey(!0)
inline bool Dictionary_2_ContainsKey_m81AE5386AFCDA3805EA9ADCC78F00C3EF903428A (Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF * __this, String_t* p0, const RuntimeMethod* method)
{
	return ((  bool (*) (Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF *, String_t*, const RuntimeMethod*))Dictionary_2_ContainsKey_m4EBC00E16E83DA33851A551757D2B7332D5756B9_gshared)(__this, p0, method);
}
// System.Void System.Collections.Generic.List`1<System.String>::.ctor()
inline void List_1__ctor_mDA22758D73530683C950C5CCF39BDB4E7E1F3F06 (List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 *, const RuntimeMethod*))List_1__ctor_mC832F1AC0F814BAEB19175F5D7972A7507508BC3_gshared)(__this, method);
}
// System.Void System.Collections.Generic.Dictionary`2<System.String,System.Collections.Generic.List`1<System.String>>::Add(!0,!1)
inline void Dictionary_2_Add_m77DD1AAE607EDC7C550C45F4AC4FC935DF0380CC (Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF * __this, String_t* p0, List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * p1, const RuntimeMethod* method)
{
	((  void (*) (Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF *, String_t*, List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 *, const RuntimeMethod*))Dictionary_2_Add_mC741BBB0A647C814227953DB9B23CB1BDF571C5B_gshared)(__this, p0, p1, method);
}
// !1 System.Collections.Generic.Dictionary`2<System.String,System.Collections.Generic.List`1<System.String>>::get_Item(!0)
inline List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * Dictionary_2_get_Item_m1F9B397B583526C8C45854B8B60A308A2227F889 (Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF * __this, String_t* p0, const RuntimeMethod* method)
{
	return ((  List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * (*) (Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF *, String_t*, const RuntimeMethod*))Dictionary_2_get_Item_m6625C3BA931A6EE5D6DB46B9E743B40AAA30010B_gshared)(__this, p0, method);
}
// System.Boolean System.Collections.Generic.List`1<System.String>::Contains(!0)
inline bool List_1_Contains_mC1D01A0D94C03E4225EEF9D6506D7D91C6976B7B (List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * __this, String_t* p0, const RuntimeMethod* method)
{
	return ((  bool (*) (List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 *, String_t*, const RuntimeMethod*))List_1_Contains_mE08D561E86879A26245096C572A8593279383FDB_gshared)(__this, p0, method);
}
// System.Void System.Collections.Generic.List`1<System.String>::Add(!0)
inline void List_1_Add_mA348FA1140766465189459D25B01EB179001DE83 (List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * __this, String_t* p0, const RuntimeMethod* method)
{
	((  void (*) (List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 *, String_t*, const RuntimeMethod*))List_1_Add_m6930161974C7504C80F52EC379EF012387D43138_gshared)(__this, p0, method);
}
// System.Collections.Generic.Dictionary`2/Enumerator<!0,!1> System.Collections.Generic.Dictionary`2<System.String,System.Collections.Generic.List`1<System.String>>::GetEnumerator()
inline Enumerator_t38C41296850665F3643D772F9790D4B3880BD9AA  Dictionary_2_GetEnumerator_mF81DC76A58E19C2640CF6C8BE06F78361512F6E6 (Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF * __this, const RuntimeMethod* method)
{
	return ((  Enumerator_t38C41296850665F3643D772F9790D4B3880BD9AA  (*) (Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF *, const RuntimeMethod*))Dictionary_2_GetEnumerator_mF1CF1D13F3E70C6D20D96D9AC88E44454E4C0053_gshared)(__this, method);
}
// System.Collections.Generic.KeyValuePair`2<!0,!1> System.Collections.Generic.Dictionary`2/Enumerator<System.String,System.Collections.Generic.List`1<System.String>>::get_Current()
inline KeyValuePair_2_t9E20856DB65BAC258C27F3C359C8A86E2DCEEBBD  Enumerator_get_Current_m0C79D6B8A354C9E3D29D7B654F902B30868E0949 (Enumerator_t38C41296850665F3643D772F9790D4B3880BD9AA * __this, const RuntimeMethod* method)
{
	return ((  KeyValuePair_2_t9E20856DB65BAC258C27F3C359C8A86E2DCEEBBD  (*) (Enumerator_t38C41296850665F3643D772F9790D4B3880BD9AA *, const RuntimeMethod*))Enumerator_get_Current_m5B32A9FC8294CB723DCD1171744B32E1775B6318_gshared)(__this, method);
}
// !1 System.Collections.Generic.KeyValuePair`2<System.String,System.Collections.Generic.List`1<System.String>>::get_Value()
inline List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * KeyValuePair_2_get_Value_m8476A7D87325D4D7A32A4FFF66D2F2AEE1C30E36 (KeyValuePair_2_t9E20856DB65BAC258C27F3C359C8A86E2DCEEBBD * __this, const RuntimeMethod* method)
{
	return ((  List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * (*) (KeyValuePair_2_t9E20856DB65BAC258C27F3C359C8A86E2DCEEBBD *, const RuntimeMethod*))KeyValuePair_2_get_Value_m8C7B882C4D425535288FAAD08EAF11D289A43AEC_gshared)(__this, method);
}
// !0 System.Collections.Generic.List`1<System.String>::get_Item(System.Int32)
inline String_t* List_1_get_Item_mB739B0066E5F7EBDBA9978F24A73D26D4FAE5BED (List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * __this, int32_t p0, const RuntimeMethod* method)
{
	return ((  String_t* (*) (List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 *, int32_t, const RuntimeMethod*))List_1_get_Item_mFDB8AD680C600072736579BBF5F38F7416396588_gshared)(__this, p0, method);
}
// !0 System.Collections.Generic.KeyValuePair`2<System.String,System.Collections.Generic.List`1<System.String>>::get_Key()
inline String_t* KeyValuePair_2_get_Key_m30085F04A06E53139F92FFF128B01098A85D75E4 (KeyValuePair_2_t9E20856DB65BAC258C27F3C359C8A86E2DCEEBBD * __this, const RuntimeMethod* method)
{
	return ((  String_t* (*) (KeyValuePair_2_t9E20856DB65BAC258C27F3C359C8A86E2DCEEBBD *, const RuntimeMethod*))KeyValuePair_2_get_Key_m9D4E9BCBAB1BE560871A0889C851FC22A09975F4_gshared)(__this, method);
}
// System.Data.DataTable Mono.Data.Sqlite.SqliteConnection::GetSchema(System.String,System.String[])
extern "C" IL2CPP_METHOD_ATTR DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * SqliteConnection_GetSchema_mBD744C989445D4F7E5055D78A4AE20E02E0DB183 (SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * __this, String_t* ___collectionName0, StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* ___restrictionValues1, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.String>::RemoveAt(System.Int32)
inline void List_1_RemoveAt_mD17877118EA5CCF90E0D36CF420287270492A0F2 (List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * __this, int32_t p0, const RuntimeMethod* method)
{
	((  void (*) (List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 *, int32_t, const RuntimeMethod*))List_1_RemoveAt_m3CAF82E0FF61CD84E251E0F7231BBB867C9755C2_gshared)(__this, p0, method);
}
// !1 System.Collections.Generic.Dictionary`2<System.String,System.Int32>::get_Item(!0)
inline int32_t Dictionary_2_get_Item_m8B16E8CBD6B9EE71984601DB60ADB40673ADD5CC (Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB * __this, String_t* p0, const RuntimeMethod* method)
{
	return ((  int32_t (*) (Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB *, String_t*, const RuntimeMethod*))Dictionary_2_get_Item_m6F2BB7FC61476D210FA060962086B5B21FB1B6CA_gshared)(__this, p0, method);
}
// System.Data.DataRow System.Data.DataRowCollection::get_Item(System.Int32)
extern "C" IL2CPP_METHOD_ATTR DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * DataRowCollection_get_Item_mDF585AB070DEE6DB7B63881536E7072B0C87834F (DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0 * __this, int32_t p0, const RuntimeMethod* method);
// System.Boolean System.Data.DataRow::IsNull(System.String)
extern "C" IL2CPP_METHOD_ATTR bool DataRow_IsNull_mCF24987852F1AC348E419E59F28F1A84F90AF1D0 (DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * __this, String_t* p0, const RuntimeMethod* method);
// System.Void System.Data.DataRowCollection::RemoveAt(System.Int32)
extern "C" IL2CPP_METHOD_ATTR void DataRowCollection_RemoveAt_mC10D9EEAF5FD8346FA1CB1575543488540B93D08 (DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0 * __this, int32_t p0, const RuntimeMethod* method);
// System.Int32 System.Data.DataRowCollection::get_Count()
extern "C" IL2CPP_METHOD_ATTR int32_t DataRowCollection_get_Count_mA4B1179424DF0637C1E85C2148055F8035E0B1DA (DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0 * __this, const RuntimeMethod* method);
// System.Boolean System.String::op_Inequality(System.String,System.String)
extern "C" IL2CPP_METHOD_ATTR bool String_op_Inequality_m0BD184A74F453A72376E81CC6CAEE2556B80493E (String_t* p0, String_t* p1, const RuntimeMethod* method);
// System.Int32 System.Collections.Generic.List`1<System.String>::get_Count()
inline int32_t List_1_get_Count_m4151A68BD4CB1D737213E7595F574987F8C812B4 (List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 *, const RuntimeMethod*))List_1_get_Count_m507C9149FF7F83AAC72C29091E745D557DA47D22_gshared)(__this, method);
}
// System.Void System.Collections.Generic.List`1<System.String>::CopyTo(!0[])
inline void List_1_CopyTo_m152A529573840F5373AD90FD98B33D00070920FE (List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * __this, StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* p0, const RuntimeMethod* method)
{
	((  void (*) (List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 *, StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E*, const RuntimeMethod*))List_1_CopyTo_m54E18E9C1ECE23383EF0EA1E98330235DEAD7B39_gshared)(__this, p0, method);
}
// System.Void Mono.Data.Sqlite.SqliteKeyReader/KeyQuery::.ctor(Mono.Data.Sqlite.SqliteConnection,System.String,System.String,System.String[])
extern "C" IL2CPP_METHOD_ATTR void KeyQuery__ctor_m3095086FBBB97A6899ED7F47A9F349AC1D767E83 (KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * __this, SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * ___cnn0, String_t* ___database1, String_t* ___table2, StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* ___columns3, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteKeyReader/KeyInfo>::Add(!0)
inline void List_1_Add_m335FACF62F79155D36F4BD6E4CE541AFBCCCDAEA (List_1_tD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD * __this, KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC  p0, const RuntimeMethod* method)
{
	((  void (*) (List_1_tD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD *, KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC , const RuntimeMethod*))List_1_Add_m335FACF62F79155D36F4BD6E4CE541AFBCCCDAEA_gshared)(__this, p0, method);
}
// System.Boolean System.Collections.Generic.Dictionary`2/Enumerator<System.String,System.Collections.Generic.List`1<System.String>>::MoveNext()
inline bool Enumerator_MoveNext_m1534F8F536B5DDFE0019172C7CD4B38969DBE226 (Enumerator_t38C41296850665F3643D772F9790D4B3880BD9AA * __this, const RuntimeMethod* method)
{
	return ((  bool (*) (Enumerator_t38C41296850665F3643D772F9790D4B3880BD9AA *, const RuntimeMethod*))Enumerator_MoveNext_m9B9FB07EC2C1D82E921C9316A4E0901C933BBF6C_gshared)(__this, method);
}
// System.Void System.Collections.Generic.Dictionary`2/Enumerator<System.String,System.Collections.Generic.List`1<System.String>>::Dispose()
inline void Enumerator_Dispose_m20DEE1B61D35A4F881D24FDE0FC3E8C0A7DBF89D (Enumerator_t38C41296850665F3643D772F9790D4B3880BD9AA * __this, const RuntimeMethod* method)
{
	((  void (*) (Enumerator_t38C41296850665F3643D772F9790D4B3880BD9AA *, const RuntimeMethod*))Enumerator_Dispose_mE363888280B72ED50538416C060EF9FC94B3BB00_gshared)(__this, method);
}
// System.Int32 System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteKeyReader/KeyInfo>::get_Count()
inline int32_t List_1_get_Count_m0283B39AA2691EE274CBD01927A6175AC6C2F5BF (List_1_tD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD * __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (List_1_tD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD *, const RuntimeMethod*))List_1_get_Count_m0283B39AA2691EE274CBD01927A6175AC6C2F5BF_gshared)(__this, method);
}
// System.Void System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteKeyReader/KeyInfo>::CopyTo(!0[])
inline void List_1_CopyTo_mD3FBBD792230E4756C75F7F245B815CFEB65836A (List_1_tD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD * __this, KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* p0, const RuntimeMethod* method)
{
	((  void (*) (List_1_tD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD *, KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4*, const RuntimeMethod*))List_1_CopyTo_mD3FBBD792230E4756C75F7F245B815CFEB65836A_gshared)(__this, p0, method);
}
// System.Void Mono.Data.Sqlite.SqliteKeyReader::Sync()
extern "C" IL2CPP_METHOD_ATTR void SqliteKeyReader_Sync_m3DCE8016688D6FECE14616AC1DBBF62CD5ECF053 (SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793 * __this, const RuntimeMethod* method);
// System.Void System.InvalidCastException::.ctor()
extern "C" IL2CPP_METHOD_ATTR void InvalidCastException__ctor_mB14CE363FB346D9BC0C0763CAF0B67AF90902144 (InvalidCastException_t91DF9E7D7FCCDA6C562CB4A9A18903E016680FDA * __this, const RuntimeMethod* method);
// System.Void Mono.Data.Sqlite.SqliteKeyReader/KeyQuery::Sync(System.Int64)
extern "C" IL2CPP_METHOD_ATTR void KeyQuery_Sync_m19A2575566EEFC07F5FC36F2E200FA23EE8A7390 (KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * __this, int64_t ___rowid0, const RuntimeMethod* method);
// System.Void Mono.Data.Sqlite.SqliteKeyReader/KeyQuery::set_IsValid(System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void KeyQuery_set_IsValid_mA4632D8CAB6B73258A401162467D7CB5C7E73B6D (KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * __this, bool ___value0, const RuntimeMethod* method);
// System.Void Mono.Data.Sqlite.SqliteKeyReader/KeyQuery::Dispose()
extern "C" IL2CPP_METHOD_ATTR void KeyQuery_Dispose_m47A9B991C6566086FD3BAB27C8DB2DBAFC4A1F48 (KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * __this, const RuntimeMethod* method);
// System.String Mono.Data.Sqlite.SqliteDataReader::GetDataTypeName(System.Int32)
extern "C" IL2CPP_METHOD_ATTR String_t* SqliteDataReader_GetDataTypeName_m6D7FD4F16F98B3DAB780DD3AC1D27E2858F3EAC4 (SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * __this, int32_t ___i0, const RuntimeMethod* method);
// System.Type Mono.Data.Sqlite.SqliteDataReader::GetFieldType(System.Int32)
extern "C" IL2CPP_METHOD_ATTR Type_t * SqliteDataReader_GetFieldType_m9B70FC079ECDE5CCB617AFCE1EDC68377E8AE716 (SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * __this, int32_t ___i0, const RuntimeMethod* method);
// System.Void Mono.Data.Sqlite.SqliteKeyReader::Sync(System.Int32)
extern "C" IL2CPP_METHOD_ATTR void SqliteKeyReader_Sync_mF6A76D7FF2131664DCAFC47426C77959060A7560 (SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793 * __this, int32_t ___i0, const RuntimeMethod* method);
// System.Boolean Mono.Data.Sqlite.SqliteDataReader::GetBoolean(System.Int32)
extern "C" IL2CPP_METHOD_ATTR bool SqliteDataReader_GetBoolean_m7E53B25F643A31EC286A65BE8FFDE02769C6D903 (SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * __this, int32_t ___i0, const RuntimeMethod* method);
// System.Int32 Mono.Data.Sqlite.SqliteDataReader::GetInt32(System.Int32)
extern "C" IL2CPP_METHOD_ATTR int32_t SqliteDataReader_GetInt32_m4A41300087F430F13D90A6F70C66D13DBBC0D7BC (SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * __this, int32_t ___i0, const RuntimeMethod* method);
// System.Int32 System.Convert::ToInt32(System.Int64)
extern "C" IL2CPP_METHOD_ATTR int32_t Convert_ToInt32_m5CE30569A0A5B70CBD85954BEEF436F57D6FAE6B (int64_t p0, const RuntimeMethod* method);
// System.Int64 Mono.Data.Sqlite.SqliteDataReader::GetInt64(System.Int32)
extern "C" IL2CPP_METHOD_ATTR int64_t SqliteDataReader_GetInt64_mB9CF2BD85015CC2B72606BF77CA66CD2E0184C56 (SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * __this, int32_t ___i0, const RuntimeMethod* method);
// System.Int64 System.Convert::ToInt64(System.Int64)
extern "C" IL2CPP_METHOD_ATTR int64_t Convert_ToInt64_mA01BFA4EFA523B93F48D03811D44AE225059E0AD (int64_t p0, const RuntimeMethod* method);
// System.String Mono.Data.Sqlite.SqliteDataReader::GetString(System.Int32)
extern "C" IL2CPP_METHOD_ATTR String_t* SqliteDataReader_GetString_mF6D7C833507ADBE616334F91ABE7E3B73609042E (SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * __this, int32_t ___i0, const RuntimeMethod* method);
// System.Object Mono.Data.Sqlite.SqliteDataReader::GetValue(System.Int32)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * SqliteDataReader_GetValue_mE4F5C8119E84D78EDE732788C2185EC09672F2D0 (SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * __this, int32_t ___i0, const RuntimeMethod* method);
// System.Boolean Mono.Data.Sqlite.SqliteKeyReader::IsDBNull(System.Int32)
extern "C" IL2CPP_METHOD_ATTR bool SqliteKeyReader_IsDBNull_m0C44B5BED117982D60E7307BF4F0EE3CD96BE3E1 (SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793 * __this, int32_t ___i0, const RuntimeMethod* method);
// System.Int64 Mono.Data.Sqlite.SqliteKeyReader::GetInt64(System.Int32)
extern "C" IL2CPP_METHOD_ATTR int64_t SqliteKeyReader_GetInt64_m88F6AC8A38D351C10514E8BE8A6EC30F819C833A (SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793 * __this, int32_t ___i0, const RuntimeMethod* method);
// System.Boolean Mono.Data.Sqlite.SqliteDataReader::IsDBNull(System.Int32)
extern "C" IL2CPP_METHOD_ATTR bool SqliteDataReader_IsDBNull_m3B0ECC6EBCB6C8B1D98546F0D21B7A3DF7068B93 (SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * __this, int32_t ___i0, const RuntimeMethod* method);
// System.Data.DataRow System.Data.DataTable::NewRow()
extern "C" IL2CPP_METHOD_ATTR DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * DataTable_NewRow_m74E2026105B65A19E657631DDAC31916F004CBF1 (DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * __this, const RuntimeMethod* method);
// System.Void System.Data.DataRow::set_Item(System.String,System.Object)
extern "C" IL2CPP_METHOD_ATTR void DataRow_set_Item_m4AA7DFBB5987AECF475E177F56FFBA95CF6CFFA2 (DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * __this, String_t* p0, RuntimeObject * p1, const RuntimeMethod* method);
// System.Void System.Data.DataRowCollection::Add(System.Data.DataRow)
extern "C" IL2CPP_METHOD_ATTR void DataRowCollection_Add_mD58F34C8E5D4FD55D6CEFA56F121935E467C11F6 (DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0 * __this, DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * p0, const RuntimeMethod* method);
// System.Data.DataTable Mono.Data.Sqlite.SqliteDataReader::GetSchemaTable()
extern "C" IL2CPP_METHOD_ATTR DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * SqliteDataReader_GetSchemaTable_mEA3BE5A6DCD68BC32D7F0D30A57DA5177F96E33A (SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * __this, const RuntimeMethod* method);
// System.Object[] System.Data.DataRow::get_ItemArray()
extern "C" IL2CPP_METHOD_ATTR ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* DataRow_get_ItemArray_mABB1F804FE8BDE1C715C2609EBE1DC7E9668C2E7 (DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * __this, const RuntimeMethod* method);
// System.Data.DataRow System.Data.DataRowCollection::Add(System.Object[])
extern "C" IL2CPP_METHOD_ATTR DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * DataRowCollection_Add_mE9B4B34E992D02D8E1A859F2EB1FD2706B801983 (DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0 * __this, ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* p0, const RuntimeMethod* method);
// System.Void Mono.Data.Sqlite.SqliteCommandBuilder::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SqliteCommandBuilder__ctor_mA8D14724EECC99F7AD7AAA7C9118592DFF3EB74A (SqliteCommandBuilder_tB1BC265E1A177F0CEC2518E29F44C25E6CFBFB64 * __this, const RuntimeMethod* method);
// Mono.Data.Sqlite.SqliteCommand Mono.Data.Sqlite.SqliteConnection::CreateCommand()
extern "C" IL2CPP_METHOD_ATTR SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * SqliteConnection_CreateCommand_mE54467D789E72E02161682F6456682545037F3A3 (SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * __this, const RuntimeMethod* method);
// System.String Mono.Data.Sqlite.SqliteCommandBuilder::QuoteIdentifier(System.String)
extern "C" IL2CPP_METHOD_ATTR String_t* SqliteCommandBuilder_QuoteIdentifier_m2358474CD04B0F7182251DF584B07F381DB1FC3C (SqliteCommandBuilder_tB1BC265E1A177F0CEC2518E29F44C25E6CFBFB64 * __this, String_t* ___unquotedIdentifier0, const RuntimeMethod* method);
// System.String System.String::Join(System.String,System.String[])
extern "C" IL2CPP_METHOD_ATTR String_t* String_Join_m49371BED70248F0FCE970CB4F2E39E9A688AAFA4 (String_t* p0, StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* p1, const RuntimeMethod* method);
// System.String System.String::Format(System.String,System.Object,System.Object,System.Object)
extern "C" IL2CPP_METHOD_ATTR String_t* String_Format_m26BBF75F9609FAD0B39C2242FEBAAD7D68F14D99 (String_t* p0, RuntimeObject * p1, RuntimeObject * p2, RuntimeObject * p3, const RuntimeMethod* method);
// System.Void Mono.Data.Sqlite.SqliteCommand::set_CommandText(System.String)
extern "C" IL2CPP_METHOD_ATTR void SqliteCommand_set_CommandText_mE49B5EE0CD14901BC847B155D4B784B1EAE1D782 (SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * __this, String_t* ___value0, const RuntimeMethod* method);
// Mono.Data.Sqlite.SqliteParameterCollection Mono.Data.Sqlite.SqliteCommand::get_Parameters()
extern "C" IL2CPP_METHOD_ATTR SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * SqliteCommand_get_Parameters_mF4EA64A5EFD070514D13C782DAA883E45EA6DC0D (SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * __this, const RuntimeMethod* method);
// Mono.Data.Sqlite.SqliteParameter Mono.Data.Sqlite.SqliteParameterCollection::AddWithValue(System.String,System.Object)
extern "C" IL2CPP_METHOD_ATTR SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * SqliteParameterCollection_AddWithValue_mF4F505D0FCEB4D850A40BEA47A730246088E871E (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, String_t* ___parameterName0, RuntimeObject * ___value1, const RuntimeMethod* method);
// System.Void System.ArgumentException::.ctor()
extern "C" IL2CPP_METHOD_ATTR void ArgumentException__ctor_m77591C20EDA3ADEE2FAF1987321D686E249326C5 (ArgumentException_tEDCD16F20A09ECE461C3DA766C16EDA8864057D1 * __this, const RuntimeMethod* method);
// System.Void System.Data.Common.DbDataReader::Dispose()
extern "C" IL2CPP_METHOD_ATTR void DbDataReader_Dispose_mD3B8FDCD448F9FFB52287C8D4D95710EAA646B72 (DbDataReader_t4CADA7880D6F85CABC4096FA5AE10C327A07CCD8 * __this, const RuntimeMethod* method);
// Mono.Data.Sqlite.SqliteParameter Mono.Data.Sqlite.SqliteParameterCollection::get_Item(System.Int32)
extern "C" IL2CPP_METHOD_ATTR SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * SqliteParameterCollection_get_Item_m6807F61A4D898F719FF3EDAE8097A6FADC9E92F8 (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, int32_t ___index0, const RuntimeMethod* method);
// System.Void Mono.Data.Sqlite.SqliteParameter::set_Value(System.Object)
extern "C" IL2CPP_METHOD_ATTR void SqliteParameter_set_Value_mA4215B49D68583CF87D786F3A54D2202ACFAD3C9 (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, RuntimeObject * ___value0, const RuntimeMethod* method);
// Mono.Data.Sqlite.SqliteDataReader Mono.Data.Sqlite.SqliteCommand::ExecuteReader()
extern "C" IL2CPP_METHOD_ATTR SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * SqliteCommand_ExecuteReader_m8C72ED1B6C2B2CB567460300F665454ED122CA5A (SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * __this, const RuntimeMethod* method);
// System.Boolean Mono.Data.Sqlite.SqliteDataReader::Read()
extern "C" IL2CPP_METHOD_ATTR bool SqliteDataReader_Read_m6C689FF4A6EE5E3132E3FCF8E164DC42023727DE (SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * __this, const RuntimeMethod* method);
// System.Void System.ComponentModel.Component::Dispose()
extern "C" IL2CPP_METHOD_ATTR void Component_Dispose_m823396D3128BA14DDC7522A760EEEEAC30518E98 (Component_t7AEFE153F6778CF52E1981BC3E811A9604B29473 * __this, const RuntimeMethod* method);
// System.Void Mono.Data.Sqlite.SqliteParameter::.ctor(System.String,System.Data.DbType,System.Int32,System.String,System.Data.DataRowVersion)
extern "C" IL2CPP_METHOD_ATTR void SqliteParameter__ctor_m34D7E5F90F0DC7D53557D381DB24924F147258D1 (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, String_t* ___parameterName0, int32_t ___parameterType1, int32_t ___parameterSize2, String_t* ___sourceColumn3, int32_t ___rowVersion4, const RuntimeMethod* method);
// System.Void System.Data.Common.DbParameter::.ctor()
extern "C" IL2CPP_METHOD_ATTR void DbParameter__ctor_mBC6F98079269BE4009ED11B5581B93D7550921FF (DbParameter_tEE5AEAD8B429B8EF8994063C151A25A76B94B76F * __this, const RuntimeMethod* method);
// System.String Mono.Data.Sqlite.SqliteParameter::get_ParameterName()
extern "C" IL2CPP_METHOD_ATTR String_t* SqliteParameter_get_ParameterName_mA35635BDE12ACDEBD953F167C09F06AB44C213D0 (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, const RuntimeMethod* method);
// System.Data.ParameterDirection Mono.Data.Sqlite.SqliteParameter::get_Direction()
extern "C" IL2CPP_METHOD_ATTR int32_t SqliteParameter_get_Direction_mBA66BA9F6C2C9F3F23E5E95B5BD73F01B13AE78F (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, const RuntimeMethod* method);
// System.Boolean Mono.Data.Sqlite.SqliteParameter::get_IsNullable()
extern "C" IL2CPP_METHOD_ATTR bool SqliteParameter_get_IsNullable_mDAA849A593086C73841A07FF9992B14BD1A2E3F6 (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, const RuntimeMethod* method);
// System.String Mono.Data.Sqlite.SqliteParameter::get_SourceColumn()
extern "C" IL2CPP_METHOD_ATTR String_t* SqliteParameter_get_SourceColumn_mC6A8FA0D98F3AB4A76C9C32A850F519E0F726B28 (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, const RuntimeMethod* method);
// System.Data.DataRowVersion Mono.Data.Sqlite.SqliteParameter::get_SourceVersion()
extern "C" IL2CPP_METHOD_ATTR int32_t SqliteParameter_get_SourceVersion_m9D96666EF34C2549A30615586FC262E2EC1D7E5A (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, const RuntimeMethod* method);
// System.Object Mono.Data.Sqlite.SqliteParameter::get_Value()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * SqliteParameter_get_Value_mBA989781BF12F4716038CA0F772C9A033CD829C6 (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, const RuntimeMethod* method);
// System.Void Mono.Data.Sqlite.SqliteParameter::.ctor(System.String,System.Data.DbType,System.Int32,System.Data.ParameterDirection,System.Boolean,System.Byte,System.Byte,System.String,System.Data.DataRowVersion,System.Object)
extern "C" IL2CPP_METHOD_ATTR void SqliteParameter__ctor_m39B48921AAEF2BD21DEA574A8EAAF44C4594622A (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, String_t* ___parameterName0, int32_t ___parameterType1, int32_t ___parameterSize2, int32_t ___direction3, bool ___isNullable4, uint8_t ___precision5, uint8_t ___scale6, String_t* ___sourceColumn7, int32_t ___rowVersion8, RuntimeObject * ___value9, const RuntimeMethod* method);
// System.Void Mono.Data.Sqlite.SqliteParameter::set_Direction(System.Data.ParameterDirection)
extern "C" IL2CPP_METHOD_ATTR void SqliteParameter_set_Direction_m80D8677C3C1484EF27734AAB1FDC814CF24A1814 (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, int32_t ___value0, const RuntimeMethod* method);
// System.Void Mono.Data.Sqlite.SqliteParameter::set_IsNullable(System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void SqliteParameter_set_IsNullable_m3913742D2173DFCCACBCA79849A7E2E1F06C304D (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, bool ___value0, const RuntimeMethod* method);
// System.Data.DbType Mono.Data.Sqlite.SqliteConvert::TypeToDbType(System.Type)
extern "C" IL2CPP_METHOD_ATTR int32_t SqliteConvert_TypeToDbType_mCEFBA85B101BCF9131178D3E11B9D10198F0A026 (Type_t * ___typ0, const RuntimeMethod* method);
// System.Void System.NotSupportedException::.ctor()
extern "C" IL2CPP_METHOD_ATTR void NotSupportedException__ctor_mA121DE1CAC8F25277DEB489DC7771209D91CAE33 (NotSupportedException_tE75B318D6590A02A5D9B29FD97409B1750FA0010 * __this, const RuntimeMethod* method);
// System.Void Mono.Data.Sqlite.SqliteParameter::.ctor(Mono.Data.Sqlite.SqliteParameter)
extern "C" IL2CPP_METHOD_ATTR void SqliteParameter__ctor_mA114D3015932B1ED012F86087A1CB770ADDDAFB6 (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * ___source0, const RuntimeMethod* method);
// System.Void System.Data.Common.DbParameterCollection::.ctor()
extern "C" IL2CPP_METHOD_ATTR void DbParameterCollection__ctor_m1170B63FB42DB24CF67CDD28B2F1152DC0CDB6B2 (DbParameterCollection_t6FF3670B12D04B797F09E79DFEA4CF93E92D249C * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteParameter>::.ctor()
inline void List_1__ctor_mB58ED77706DFDF497D9DEA17FE42A5C700DED840 (List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 *, const RuntimeMethod*))List_1__ctor_mC832F1AC0F814BAEB19175F5D7972A7507508BC3_gshared)(__this, method);
}
// System.Collections.Generic.List`1/Enumerator<!0> System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteParameter>::GetEnumerator()
inline Enumerator_tA18C55D69C7008726BD92603BF88561F27BB708A  List_1_GetEnumerator_m7E68AD2A26A6D8F70A2C5B6D22E0983B86407DF3 (List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * __this, const RuntimeMethod* method)
{
	return ((  Enumerator_tA18C55D69C7008726BD92603BF88561F27BB708A  (*) (List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 *, const RuntimeMethod*))List_1_GetEnumerator_m52CC760E475D226A2B75048D70C4E22692F9F68D_gshared)(__this, method);
}
// System.Boolean System.String::IsNullOrEmpty(System.String)
extern "C" IL2CPP_METHOD_ATTR bool String_IsNullOrEmpty_m06A85A206AC2106D1982826C5665B9BD35324229 (String_t* p0, const RuntimeMethod* method);
// System.Int32 Mono.Data.Sqlite.SqliteParameterCollection::IndexOf(System.String)
extern "C" IL2CPP_METHOD_ATTR int32_t SqliteParameterCollection_IndexOf_m3EBE7087E87273E22E1F60F48441484F94607421 (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, String_t* ___parameterName0, const RuntimeMethod* method);
// System.Int32 System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteParameter>::get_Count()
inline int32_t List_1_get_Count_mBF71B71F277DBD1ECF0136FBEDB2F5DB5BC2D7E7 (List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 *, const RuntimeMethod*))List_1_get_Count_m507C9149FF7F83AAC72C29091E745D557DA47D22_gshared)(__this, method);
}
// System.Void System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteParameter>::Add(!0)
inline void List_1_Add_m37ACF8547D171B0E3F525F0F9DEC80D46E9673C3 (List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * __this, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * p0, const RuntimeMethod* method)
{
	((  void (*) (List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 *, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E *, const RuntimeMethod*))List_1_Add_m6930161974C7504C80F52EC379EF012387D43138_gshared)(__this, p0, method);
}
// System.Void Mono.Data.Sqlite.SqliteParameterCollection::SetParameter(System.Int32,System.Data.Common.DbParameter)
extern "C" IL2CPP_METHOD_ATTR void SqliteParameterCollection_SetParameter_m8A77372FD9D393D3493E145532C580D3FAB3CEC6 (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, int32_t ___index0, DbParameter_tEE5AEAD8B429B8EF8994063C151A25A76B94B76F * ___value1, const RuntimeMethod* method);
// System.Int32 Mono.Data.Sqlite.SqliteParameterCollection::Add(Mono.Data.Sqlite.SqliteParameter)
extern "C" IL2CPP_METHOD_ATTR int32_t SqliteParameterCollection_Add_mBF596B1E9C33A5BEFE50A6F49A608B5D4D464FF9 (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * ___parameter0, const RuntimeMethod* method);
// System.Void Mono.Data.Sqlite.SqliteParameter::.ctor(System.String,System.Object)
extern "C" IL2CPP_METHOD_ATTR void SqliteParameter__ctor_m98357CFB2616D646814795E2F4F73ABADCBB8630 (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, String_t* ___parameterName0, RuntimeObject * ___value1, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteParameter>::Clear()
inline void List_1_Clear_m03F5799F64050A07C3C1144F3492F3E44B715707 (List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 *, const RuntimeMethod*))List_1_Clear_mC5CFC6C9F3007FC24FE020198265D4B5B0659FFC_gshared)(__this, method);
}
// System.Boolean System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteParameter>::Contains(!0)
inline bool List_1_Contains_mB71B12DBCE2F9899460DF6F0DB4584748FAAE603 (List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * __this, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * p0, const RuntimeMethod* method)
{
	return ((  bool (*) (List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 *, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E *, const RuntimeMethod*))List_1_Contains_mE08D561E86879A26245096C572A8593279383FDB_gshared)(__this, p0, method);
}
// System.Void System.NotImplementedException::.ctor()
extern "C" IL2CPP_METHOD_ATTR void NotImplementedException__ctor_m8BEA657E260FC05F0C6D2C43A6E9BC08040F59C4 (NotImplementedException_t8AD6EBE5FEDB0AEBECEE0961CF73C35B372EFFA4 * __this, const RuntimeMethod* method);
// System.Data.Common.DbParameter Mono.Data.Sqlite.SqliteParameterCollection::GetParameter(System.Int32)
extern "C" IL2CPP_METHOD_ATTR DbParameter_tEE5AEAD8B429B8EF8994063C151A25A76B94B76F * SqliteParameterCollection_GetParameter_mFB68E8A80CCD474525471D67CFBA3117C3D54096 (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, int32_t ___index0, const RuntimeMethod* method);
// !0 System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteParameter>::get_Item(System.Int32)
inline SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * List_1_get_Item_mC7944FE39CD3751E41C887D3901B49E003741BC2 (List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * __this, int32_t p0, const RuntimeMethod* method)
{
	return ((  SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * (*) (List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 *, int32_t, const RuntimeMethod*))List_1_get_Item_mFDB8AD680C600072736579BBF5F38F7416396588_gshared)(__this, p0, method);
}
// System.Globalization.CultureInfo System.Globalization.CultureInfo::get_InvariantCulture()
extern "C" IL2CPP_METHOD_ATTR CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * CultureInfo_get_InvariantCulture_mF13B47F8A763CE6A9C8A8BB2EED33FF8F7A63A72 (const RuntimeMethod* method);
// System.Int32 System.String::Compare(System.String,System.String,System.Boolean,System.Globalization.CultureInfo)
extern "C" IL2CPP_METHOD_ATTR int32_t String_Compare_mA1D43767F882FE677F238637A8785FCCEE7173D9 (String_t* p0, String_t* p1, bool p2, CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * p3, const RuntimeMethod* method);
// System.Int32 System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteParameter>::IndexOf(!0)
inline int32_t List_1_IndexOf_mA304FB7C0E2D8FA02C0D7A8A31F6BACE2D5E89FB (List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * __this, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * p0, const RuntimeMethod* method)
{
	return ((  int32_t (*) (List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 *, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E *, const RuntimeMethod*))List_1_IndexOf_m98E4245F46A6D90AE3E96EFF3880D50ED6E2C728_gshared)(__this, p0, method);
}
// System.Void System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteParameter>::Insert(System.Int32,!0)
inline void List_1_Insert_m4EF8AEFAFE722E8BD0BA8C841C92194EBFF18325 (List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * __this, int32_t p0, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * p1, const RuntimeMethod* method)
{
	((  void (*) (List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 *, int32_t, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E *, const RuntimeMethod*))List_1_Insert_m327E513FB78F72441BBF2756AFCC788F89A4FA52_gshared)(__this, p0, p1, method);
}
// System.Boolean System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteParameter>::Remove(!0)
inline bool List_1_Remove_m1A3186B1F195851183DDCD11C2A5190A6F70F11D (List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * __this, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * p0, const RuntimeMethod* method)
{
	return ((  bool (*) (List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 *, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E *, const RuntimeMethod*))List_1_Remove_m908B647BB9F807676DACE34E3E73475C3C3751D4_gshared)(__this, p0, method);
}
// System.Void System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteParameter>::RemoveAt(System.Int32)
inline void List_1_RemoveAt_m1408E3DEDB4B543DE4A55EFDB57226904F6967E4 (List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * __this, int32_t p0, const RuntimeMethod* method)
{
	((  void (*) (List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 *, int32_t, const RuntimeMethod*))List_1_RemoveAt_m3CAF82E0FF61CD84E251E0F7231BBB867C9755C2_gshared)(__this, p0, method);
}
// System.Void System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteParameter>::set_Item(System.Int32,!0)
inline void List_1_set_Item_mEDB88DF97C46BC3FD98495E2248B13827DB0E974 (List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * __this, int32_t p0, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * p1, const RuntimeMethod* method)
{
	((  void (*) (List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 *, int32_t, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E *, const RuntimeMethod*))List_1_set_Item_m451452782977192583A6374A799099FCCD9BD83E_gshared)(__this, p0, p1, method);
}
// !0 System.Collections.Generic.List`1/Enumerator<Mono.Data.Sqlite.SqliteParameter>::get_Current()
inline SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * Enumerator_get_Current_m152C218D70BA6E16353FC590C1A91BE28782074D (Enumerator_tA18C55D69C7008726BD92603BF88561F27BB708A * __this, const RuntimeMethod* method)
{
	return ((  SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * (*) (Enumerator_tA18C55D69C7008726BD92603BF88561F27BB708A *, const RuntimeMethod*))Enumerator_get_Current_mD7829C7E8CFBEDD463B15A951CDE9B90A12CC55C_gshared)(__this, method);
}
// System.String System.String::Format(System.IFormatProvider,System.String,System.Object[])
extern "C" IL2CPP_METHOD_ATTR String_t* String_Format_mF68EE0DEC1AA5ADE9DFEF9AE0508E428FBB10EFD (RuntimeObject* p0, String_t* p1, ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* p2, const RuntimeMethod* method);
// System.Int32 System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteStatement>::get_Count()
inline int32_t List_1_get_Count_mCAA6783F6B5B8ADE95B9FE96AACB89704F116A12 (List_1_t061A89EAEE080F1782627C91C598BD546671C91A * __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (List_1_t061A89EAEE080F1782627C91C598BD546671C91A *, const RuntimeMethod*))List_1_get_Count_m507C9149FF7F83AAC72C29091E745D557DA47D22_gshared)(__this, method);
}
// !0 System.Collections.Generic.List`1<Mono.Data.Sqlite.SqliteStatement>::get_Item(System.Int32)
inline SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * List_1_get_Item_mD187885178D9436A3BEB6CF28A3C2AD837B26467 (List_1_t061A89EAEE080F1782627C91C598BD546671C91A * __this, int32_t p0, const RuntimeMethod* method)
{
	return ((  SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * (*) (List_1_t061A89EAEE080F1782627C91C598BD546671C91A *, int32_t, const RuntimeMethod*))List_1_get_Item_mFDB8AD680C600072736579BBF5F38F7416396588_gshared)(__this, p0, method);
}
// System.Boolean Mono.Data.Sqlite.SqliteStatement::MapParameter(System.String,Mono.Data.Sqlite.SqliteParameter)
extern "C" IL2CPP_METHOD_ATTR bool SqliteStatement_MapParameter_mF2B1590F36C785FA5CDC5D79CA0F998584E5021C (SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * __this, String_t* ___s0, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * ___p1, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.List`1/Enumerator<Mono.Data.Sqlite.SqliteParameter>::MoveNext()
inline bool Enumerator_MoveNext_mAA17145AA0994543090AFFF741659D345AC64F9F (Enumerator_tA18C55D69C7008726BD92603BF88561F27BB708A * __this, const RuntimeMethod* method)
{
	return ((  bool (*) (Enumerator_tA18C55D69C7008726BD92603BF88561F27BB708A *, const RuntimeMethod*))Enumerator_MoveNext_m38B1099DDAD7EEDE2F4CDAB11C095AC784AC2E34_gshared)(__this, method);
}
// System.Void System.Collections.Generic.List`1/Enumerator<Mono.Data.Sqlite.SqliteParameter>::Dispose()
inline void Enumerator_Dispose_m69EFA6DF9BD1ACE3D21EC0B240A2FB37E3AC96D0 (Enumerator_tA18C55D69C7008726BD92603BF88561F27BB708A * __this, const RuntimeMethod* method)
{
	((  void (*) (Enumerator_tA18C55D69C7008726BD92603BF88561F27BB708A *, const RuntimeMethod*))Enumerator_Dispose_m94D0DAE031619503CDA6E53C5C3CC78AF3139472_gshared)(__this, method);
}
// System.Char System.String::get_Chars(System.Int32)
extern "C" IL2CPP_METHOD_ATTR Il2CppChar String_get_Chars_m14308AC3B95F8C1D9F1D1055B116B37D595F1D96 (String_t* __this, int32_t p0, const RuntimeMethod* method);
// System.Int32 System.String::IndexOf(System.Char)
extern "C" IL2CPP_METHOD_ATTR int32_t String_IndexOf_m2909B8CF585E1BD0C81E11ACA2F48012156FD5BD (String_t* __this, Il2CppChar p0, const RuntimeMethod* method);
// System.Int32 System.Math::Max(System.Int32,System.Int32)
extern "C" IL2CPP_METHOD_ATTR int32_t Math_Max_mA99E48BB021F2E4B62D4EA9F52EA6928EED618A2 (int32_t p0, int32_t p1, const RuntimeMethod* method);
// System.Int32 System.String::Compare(System.String,System.Int32,System.String,System.Int32,System.Int32,System.Boolean,System.Globalization.CultureInfo)
extern "C" IL2CPP_METHOD_ATTR int32_t String_Compare_m759578081B55965D2CE733DF538FA20554F2F874 (String_t* p0, int32_t p1, String_t* p2, int32_t p3, int32_t p4, bool p5, CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * p6, const RuntimeMethod* method);
// System.Void System.Runtime.InteropServices.CriticalHandle::Dispose()
extern "C" IL2CPP_METHOD_ATTR void CriticalHandle_Dispose_mDBA1677ABB0EE5E4AB408B301A6FC58E2E75EBBF (CriticalHandle_tDF3AA1D1AA9E07599C316DB1C5449D3FB7BFD4C9 * __this, const RuntimeMethod* method);
// System.Void Mono.Data.Sqlite.SqliteStatement::BindParameter(System.Int32,Mono.Data.Sqlite.SqliteParameter)
extern "C" IL2CPP_METHOD_ATTR void SqliteStatement_BindParameter_m5CB198F61BDB753FDF1067AB5B624BBB5E44E513 (SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * __this, int32_t ___index0, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * ___param1, const RuntimeMethod* method);
// System.Void Mono.Data.Sqlite.SqliteException::.ctor(System.Int32,System.String)
extern "C" IL2CPP_METHOD_ATTR void SqliteException__ctor_m6FC576E18D88881DC33CAFC00042DCCF5D70F057 (SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6 * __this, int32_t ___errorCode0, String_t* ___extendedInformation1, const RuntimeMethod* method);
// System.Data.DbType Mono.Data.Sqlite.SqliteParameter::get_DbType()
extern "C" IL2CPP_METHOD_ATTR int32_t SqliteParameter_get_DbType_m8622A28055C14CA1BC4A004A909780FB9A13E691 (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, const RuntimeMethod* method);
// System.Boolean System.Convert::IsDBNull(System.Object)
extern "C" IL2CPP_METHOD_ATTR bool Convert_IsDBNull_m5523BC521CD361615CE6846388C7BD5BA1EDDCE5 (RuntimeObject * p0, const RuntimeMethod* method);
// System.DateTime System.Convert::ToDateTime(System.Object,System.IFormatProvider)
extern "C" IL2CPP_METHOD_ATTR DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132  Convert_ToDateTime_m246003CF3103F7DF9D6E817DCEFAE2CF8068862D (RuntimeObject * p0, RuntimeObject* p1, const RuntimeMethod* method);
// System.Int32 System.Convert::ToInt32(System.Object,System.IFormatProvider)
extern "C" IL2CPP_METHOD_ATTR int32_t Convert_ToInt32_m5D40340597602FB6C20BAB933E8B29617232757A (RuntimeObject * p0, RuntimeObject* p1, const RuntimeMethod* method);
// Mono.Data.Sqlite.SqliteConnection Mono.Data.Sqlite.SqliteCommand::get_Connection()
extern "C" IL2CPP_METHOD_ATTR SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * SqliteCommand_get_Connection_m7A2E3DCA5201FD25759EA80BB3F6B7421FF5D668 (SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * __this, const RuntimeMethod* method);
// System.Byte[] System.Guid::ToByteArray()
extern "C" IL2CPP_METHOD_ATTR ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* Guid_ToByteArray_m5E99B09A26EA3A1943CC8FE697E247DAC5465223 (Guid_t * __this, const RuntimeMethod* method);
// System.Decimal System.Convert::ToDecimal(System.Object,System.IFormatProvider)
extern "C" IL2CPP_METHOD_ATTR Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  Convert_ToDecimal_mD8F65E8B251DBE61789CAD032172D089375D1E5B (RuntimeObject * p0, RuntimeObject* p1, const RuntimeMethod* method);
// System.String System.Decimal::ToString(System.IFormatProvider)
extern "C" IL2CPP_METHOD_ATTR String_t* Decimal_ToString_mC257A35A991F88D3CFE6F29F619F8EC9D1D5ADFB (Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8 * __this, RuntimeObject* p0, const RuntimeMethod* method);
// System.Int32 System.String::IndexOf(System.String,System.Int32,System.StringComparison)
extern "C" IL2CPP_METHOD_ATTR int32_t String_IndexOf_m2B8FDE7216A37799B7B3A093EDDF1A820AAF4D01 (String_t* __this, String_t* p0, int32_t p1, int32_t p2, const RuntimeMethod* method);
// System.Void System.ArgumentOutOfRangeException::.ctor()
extern "C" IL2CPP_METHOD_ATTR void ArgumentOutOfRangeException__ctor_m215F35137EDD190A037E2E9BDA3BF5DC056FD7C3 (ArgumentOutOfRangeException_t94D19DF918A54511AEDF4784C9A08741BAD1DEDA * __this, const RuntimeMethod* method);
// System.String System.String::Substring(System.Int32)
extern "C" IL2CPP_METHOD_ATTR String_t* String_Substring_m2C4AFF5E79DD8BADFD2DFBCF156BF728FBB8E1AE (String_t* __this, int32_t p0, const RuntimeMethod* method);
// System.String System.String::Replace(System.String,System.String)
extern "C" IL2CPP_METHOD_ATTR String_t* String_Replace_m970DFB0A280952FA7D3BA20AB7A8FB9F80CF6470 (String_t* __this, String_t* p0, String_t* p1, const RuntimeMethod* method);
// System.Void System.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(System.Array,System.RuntimeFieldHandle)
extern "C" IL2CPP_METHOD_ATTR void RuntimeHelpers_InitializeArray_m29F50CDFEEE0AB868200291366253DD4737BC76A (RuntimeArray * p0, RuntimeFieldHandle_t844BDF00E8E6FE69D9AEAA7657F09018B864F4EF  p1, const RuntimeMethod* method);
// System.String[] System.String::Split(System.Char[])
extern "C" IL2CPP_METHOD_ATTR StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* String_Split_m13262358217AD2C119FD1B9733C3C0289D608512 (String_t* __this, CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* p0, const RuntimeMethod* method);
// System.Void Mono.Data.Sqlite.SqliteStatementHandle::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SqliteStatementHandle__ctor_m6F5DE40FE027CE6BE127C05AFA4D20161B8D9FA6 (SqliteStatementHandle_t6121E676E0AB6EA25E9168EB18C7A064E83DBBBE * __this, const RuntimeMethod* method);
// System.Void System.Runtime.InteropServices.CriticalHandle::SetHandle(System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR void CriticalHandle_SetHandle_m4EE9D69A73EF79440558738F688DA93682B8A955 (CriticalHandle_tDF3AA1D1AA9E07599C316DB1C5449D3FB7BFD4C9 * __this, intptr_t p0, const RuntimeMethod* method);
// System.Void System.Runtime.InteropServices.CriticalHandle::.ctor(System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR void CriticalHandle__ctor_m63298C852798FD29EC96265E0D6F5B3E72398349 (CriticalHandle_tDF3AA1D1AA9E07599C316DB1C5449D3FB7BFD4C9 * __this, intptr_t p0, const RuntimeMethod* method);
// System.Void Mono.Data.Sqlite.SQLiteBase::FinalizeStatement(Mono.Data.Sqlite.SqliteStatementHandle)
extern "C" IL2CPP_METHOD_ATTR void SQLiteBase_FinalizeStatement_m7C0B1BC424ADF09FD45F18EE242F5FADB0A324DA (SqliteStatementHandle_t6121E676E0AB6EA25E9168EB18C7A064E83DBBBE * ___stmt0, const RuntimeMethod* method);
// System.Boolean System.IntPtr::op_Equality(System.IntPtr,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR bool IntPtr_op_Equality_mEE8D9FD2DFE312BBAA8B4ED3BF7976B3142A5934 (intptr_t p0, intptr_t p1, const RuntimeMethod* method);
// System.Void Mono.Data.Sqlite.SqliteStatementHandle::.ctor(System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR void SqliteStatementHandle__ctor_m21BBF1AAEBF8FB0FF480424BD6DCC307CA524E31 (SqliteStatementHandle_t6121E676E0AB6EA25E9168EB18C7A064E83DBBBE * __this, intptr_t ___stmt0, const RuntimeMethod* method);
// System.Void System.Data.Common.DbTransaction::.ctor()
extern "C" IL2CPP_METHOD_ATTR void DbTransaction__ctor_mEB19A16BE9BED0A70FDCC7E5EC8134E85EEA327B (DbTransaction_tADC1A857259448190F882AC47E0B18317779FE56 * __this, const RuntimeMethod* method);
// System.Int32 Mono.Data.Sqlite.SqliteCommand::ExecuteNonQuery()
extern "C" IL2CPP_METHOD_ATTR int32_t SqliteCommand_ExecuteNonQuery_m0852FE0BAA62C3A909437FA9780008C4C1FAFE54 (SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * __this, const RuntimeMethod* method);
// System.Boolean Mono.Data.Sqlite.SqliteTransaction::IsValid(System.Boolean)
extern "C" IL2CPP_METHOD_ATTR bool SqliteTransaction_IsValid_mFFDD476AD513E92FB025CB46A52D5734FAE54897 (SqliteTransaction_t588D1AEC987A56478BF3B4254D6F83A4740F1560 * __this, bool ___throwError0, const RuntimeMethod* method);
// System.Void System.Threading.Monitor::Enter(System.Object)
extern "C" IL2CPP_METHOD_ATTR void Monitor_Enter_m903755FCC479745619842CCDBF5E6355319FA102 (RuntimeObject * p0, const RuntimeMethod* method);
// System.Void Mono.Data.Sqlite.SqliteTransaction::Rollback()
extern "C" IL2CPP_METHOD_ATTR void SqliteTransaction_Rollback_m8D8E47D6344B69998973381904AB21F90D3F9DE9 (SqliteTransaction_t588D1AEC987A56478BF3B4254D6F83A4740F1560 * __this, const RuntimeMethod* method);
// System.Void System.Threading.Monitor::Exit(System.Object)
extern "C" IL2CPP_METHOD_ATTR void Monitor_Exit_m49A1E5356D984D0B934BB97A305E2E5E207225C2 (RuntimeObject * p0, const RuntimeMethod* method);
// System.Void System.Data.Common.DbTransaction::Dispose(System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void DbTransaction_Dispose_m1D66CE2B68FF0CAAEE9B9110D58087350BBBDB6A (DbTransaction_tADC1A857259448190F882AC47E0B18317779FE56 * __this, bool p0, const RuntimeMethod* method);
// System.Void Mono.Data.Sqlite.SqliteTransaction::IssueRollback(Mono.Data.Sqlite.SqliteConnection)
extern "C" IL2CPP_METHOD_ATTR void SqliteTransaction_IssueRollback_m8BCB6D8EC3F0770626222A8929B6D61C4EF9C17A (SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * ___cnn0, const RuntimeMethod* method);
// System.Void System.ArgumentNullException::.ctor(System.String)
extern "C" IL2CPP_METHOD_ATTR void ArgumentNullException__ctor_mEE0C0D6FCB2D08CD7967DBB1329A0854BBED49ED (ArgumentNullException_t581DF992B1F3E0EC6EFB30CC5DC43519A79B27AD * __this, String_t* p0, const RuntimeMethod* method);
// System.Data.ConnectionState Mono.Data.Sqlite.SqliteConnection::get_State()
extern "C" IL2CPP_METHOD_ATTR int32_t SqliteConnection_get_State_m5209314BD40F54592BF6D6F7068E90D56BC9A45B (SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * __this, const RuntimeMethod* method);
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void Mono.Data.Sqlite.SqliteException::.ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
extern "C" IL2CPP_METHOD_ATTR void SqliteException__ctor_m116216FEC598A99C1A92CEE4F2BE83CD42A48CCA (SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6 * __this, SerializationInfo_t1BB80E9C9DEA52DBF464487234B045E2930ADA26 * ___info0, StreamingContext_t2CCDC54E0E8D078AF4A50E3A8B921B828A900034  ___context1, const RuntimeMethod* method)
{
	{
		SerializationInfo_t1BB80E9C9DEA52DBF464487234B045E2930ADA26 * L_0 = ___info0;
		StreamingContext_t2CCDC54E0E8D078AF4A50E3A8B921B828A900034  L_1 = ___context1;
		DbException__ctor_mF3F74F35C2E4A18D1453D34B20D717AFC6E2B26E(__this, L_0, L_1, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteException::.ctor(System.Int32,System.String)
extern "C" IL2CPP_METHOD_ATTR void SqliteException__ctor_m6FC576E18D88881DC33CAFC00042DCCF5D70F057 (SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6 * __this, int32_t ___errorCode0, String_t* ___extendedInformation1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteException__ctor_m6FC576E18D88881DC33CAFC00042DCCF5D70F057_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		int32_t L_0 = ___errorCode0;
		String_t* L_1 = ___extendedInformation1;
		IL2CPP_RUNTIME_CLASS_INIT(SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6_il2cpp_TypeInfo_var);
		String_t* L_2 = SqliteException_GetStockErrorMessage_mE888DD0F857775252F88B86D4B072AFADC9D9BC3(L_0, L_1, /*hidden argument*/NULL);
		DbException__ctor_m8D3347951D17C9738FD28FC7B47443DFF1EE8BAC(__this, L_2, /*hidden argument*/NULL);
		int32_t L_3 = ___errorCode0;
		__this->set__errorCode_17(L_3);
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteException::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SqliteException__ctor_m86CE6066D2FB9B6B8D350DE7E1DF9621544A1DF8 (SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6 * __this, const RuntimeMethod* method)
{
	{
		DbException__ctor_m8ED5675B5AF207A2B903B620C936BEA5D27D2FAE(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteException::.cctor()
extern "C" IL2CPP_METHOD_ATTR void SqliteException__cctor_m1083BC3EF38EEE9940DC7796BC0D748910FFBBEB (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteException__cctor_m1083BC3EF38EEE9940DC7796BC0D748910FFBBEB_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_0 = (StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E*)SZArrayNew(StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E_il2cpp_TypeInfo_var, (uint32_t)((int32_t)27));
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_1 = L_0;
		NullCheck(L_1);
		ArrayElementTypeCheck (L_1, _stringLiteralC41E97B906298C39611A796CAB1539411C1CF874);
		(L_1)->SetAt(static_cast<il2cpp_array_size_t>(0), (String_t*)_stringLiteralC41E97B906298C39611A796CAB1539411C1CF874);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_2 = L_1;
		NullCheck(L_2);
		ArrayElementTypeCheck (L_2, _stringLiteral58DF3A419CF3B1ABF1540CA19363117D737798BC);
		(L_2)->SetAt(static_cast<il2cpp_array_size_t>(1), (String_t*)_stringLiteral58DF3A419CF3B1ABF1540CA19363117D737798BC);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_3 = L_2;
		NullCheck(L_3);
		ArrayElementTypeCheck (L_3, _stringLiteral5FC00849B213BD1E4B88D515FA3A807DCB282C84);
		(L_3)->SetAt(static_cast<il2cpp_array_size_t>(2), (String_t*)_stringLiteral5FC00849B213BD1E4B88D515FA3A807DCB282C84);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_4 = L_3;
		NullCheck(L_4);
		ArrayElementTypeCheck (L_4, _stringLiteralCF0AD5ADA4DB8ECDE7F83BAC072E7C784CDC3F1F);
		(L_4)->SetAt(static_cast<il2cpp_array_size_t>(3), (String_t*)_stringLiteralCF0AD5ADA4DB8ECDE7F83BAC072E7C784CDC3F1F);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_5 = L_4;
		NullCheck(L_5);
		ArrayElementTypeCheck (L_5, _stringLiteral5277F74EC6B2C07897AE08C4150298F4A47BFEE7);
		(L_5)->SetAt(static_cast<il2cpp_array_size_t>(4), (String_t*)_stringLiteral5277F74EC6B2C07897AE08C4150298F4A47BFEE7);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_6 = L_5;
		NullCheck(L_6);
		ArrayElementTypeCheck (L_6, _stringLiteral99B3C2C49461425BF6CFF4391127F75D483D0614);
		(L_6)->SetAt(static_cast<il2cpp_array_size_t>(5), (String_t*)_stringLiteral99B3C2C49461425BF6CFF4391127F75D483D0614);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_7 = L_6;
		NullCheck(L_7);
		ArrayElementTypeCheck (L_7, _stringLiteral84B715DD42CB515250F3406C66517DD9D7115450);
		(L_7)->SetAt(static_cast<il2cpp_array_size_t>(6), (String_t*)_stringLiteral84B715DD42CB515250F3406C66517DD9D7115450);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_8 = L_7;
		NullCheck(L_8);
		ArrayElementTypeCheck (L_8, _stringLiteral634EC12D9C33E3B4FA5EE77192789853C0944473);
		(L_8)->SetAt(static_cast<il2cpp_array_size_t>(7), (String_t*)_stringLiteral634EC12D9C33E3B4FA5EE77192789853C0944473);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_9 = L_8;
		NullCheck(L_9);
		ArrayElementTypeCheck (L_9, _stringLiteralD1C6600798D630F9B1438048EE63D61789E1AF88);
		(L_9)->SetAt(static_cast<il2cpp_array_size_t>(8), (String_t*)_stringLiteralD1C6600798D630F9B1438048EE63D61789E1AF88);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_10 = L_9;
		NullCheck(L_10);
		ArrayElementTypeCheck (L_10, _stringLiteralDC2DB8AB152AE696D77BDC87D45929DEB94DE5DC);
		(L_10)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)9)), (String_t*)_stringLiteralDC2DB8AB152AE696D77BDC87D45929DEB94DE5DC);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_11 = L_10;
		NullCheck(L_11);
		ArrayElementTypeCheck (L_11, _stringLiteralED503B617B69F0DA3889F48E0D624A31DABDAE45);
		(L_11)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)10)), (String_t*)_stringLiteralED503B617B69F0DA3889F48E0D624A31DABDAE45);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_12 = L_11;
		NullCheck(L_12);
		ArrayElementTypeCheck (L_12, _stringLiteral78B3F17895B8C6A1EC55D26A5815C6B3E2F691AD);
		(L_12)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)11)), (String_t*)_stringLiteral78B3F17895B8C6A1EC55D26A5815C6B3E2F691AD);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_13 = L_12;
		NullCheck(L_13);
		ArrayElementTypeCheck (L_13, _stringLiteral9BD63A04AE7FE42E2B683DEF764089A3D56FFE25);
		(L_13)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)12)), (String_t*)_stringLiteral9BD63A04AE7FE42E2B683DEF764089A3D56FFE25);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_14 = L_13;
		NullCheck(L_14);
		ArrayElementTypeCheck (L_14, _stringLiteral79AEF385243E2292791E733AF2A99ACEF86C3DCE);
		(L_14)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)13)), (String_t*)_stringLiteral79AEF385243E2292791E733AF2A99ACEF86C3DCE);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_15 = L_14;
		NullCheck(L_15);
		ArrayElementTypeCheck (L_15, _stringLiteralA7362D38845D769AB9292607291056855E2183B1);
		(L_15)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)14)), (String_t*)_stringLiteralA7362D38845D769AB9292607291056855E2183B1);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_16 = L_15;
		NullCheck(L_16);
		ArrayElementTypeCheck (L_16, _stringLiteral08868372FCC6DF03923FF0A62B6740AAB4B59A1D);
		(L_16)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)15)), (String_t*)_stringLiteral08868372FCC6DF03923FF0A62B6740AAB4B59A1D);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_17 = L_16;
		NullCheck(L_17);
		ArrayElementTypeCheck (L_17, _stringLiteral427AF4F4D3D5F55621070F2B61A550075D057138);
		(L_17)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)16)), (String_t*)_stringLiteral427AF4F4D3D5F55621070F2B61A550075D057138);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_18 = L_17;
		NullCheck(L_18);
		ArrayElementTypeCheck (L_18, _stringLiteral5E44B1AE3D4CE260D0B6E54DFE79B9E83C8A047E);
		(L_18)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)17)), (String_t*)_stringLiteral5E44B1AE3D4CE260D0B6E54DFE79B9E83C8A047E);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_19 = L_18;
		NullCheck(L_19);
		ArrayElementTypeCheck (L_19, _stringLiteralF0057D58EF952A7C3FAC90EE4D6ACBCD891B847A);
		(L_19)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)18)), (String_t*)_stringLiteralF0057D58EF952A7C3FAC90EE4D6ACBCD891B847A);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_20 = L_19;
		NullCheck(L_20);
		ArrayElementTypeCheck (L_20, _stringLiteralD87C8562414047004383CEFAB06DDE994AB29260);
		(L_20)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)19)), (String_t*)_stringLiteralD87C8562414047004383CEFAB06DDE994AB29260);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_21 = L_20;
		NullCheck(L_21);
		ArrayElementTypeCheck (L_21, _stringLiteral805E631B2C4331634631AB9D3D378E6F37AE988C);
		(L_21)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)20)), (String_t*)_stringLiteral805E631B2C4331634631AB9D3D378E6F37AE988C);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_22 = L_21;
		NullCheck(L_22);
		ArrayElementTypeCheck (L_22, _stringLiteralDF063BF53C8E8CB3FD9AA4249D1FA6357775527C);
		(L_22)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)21)), (String_t*)_stringLiteralDF063BF53C8E8CB3FD9AA4249D1FA6357775527C);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_23 = L_22;
		NullCheck(L_23);
		ArrayElementTypeCheck (L_23, _stringLiteral89865DF2AE553E13CE078A7680590FE066489642);
		(L_23)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)22)), (String_t*)_stringLiteral89865DF2AE553E13CE078A7680590FE066489642);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_24 = L_23;
		NullCheck(L_24);
		ArrayElementTypeCheck (L_24, _stringLiteral66D5524BC6E9A905BCD8AD67AE1EB457C570B564);
		(L_24)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)23)), (String_t*)_stringLiteral66D5524BC6E9A905BCD8AD67AE1EB457C570B564);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_25 = L_24;
		NullCheck(L_25);
		ArrayElementTypeCheck (L_25, _stringLiteral56184EC642B956FAF32203EDC14DB32A5BB3377F);
		(L_25)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)24)), (String_t*)_stringLiteral56184EC642B956FAF32203EDC14DB32A5BB3377F);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_26 = L_25;
		NullCheck(L_26);
		ArrayElementTypeCheck (L_26, _stringLiteralC039B00BFF507642D69C98D494E70774AA200821);
		(L_26)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)25)), (String_t*)_stringLiteralC039B00BFF507642D69C98D494E70774AA200821);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_27 = L_26;
		NullCheck(L_27);
		ArrayElementTypeCheck (L_27, _stringLiteralAB2A2923359CC254D1142CB254FA079493CE8064);
		(L_27)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)26)), (String_t*)_stringLiteralAB2A2923359CC254D1142CB254FA079493CE8064);
		((SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6_StaticFields*)il2cpp_codegen_static_fields_for(SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6_il2cpp_TypeInfo_var))->set__errorMessages_18(L_27);
		return;
	}
}
// System.String Mono.Data.Sqlite.SqliteException::GetStockErrorMessage(System.Int32,System.String)
extern "C" IL2CPP_METHOD_ATTR String_t* SqliteException_GetStockErrorMessage_mE888DD0F857775252F88B86D4B072AFADC9D9BC3 (int32_t ___errorCode0, String_t* ___errorMessage1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteException_GetStockErrorMessage_mE888DD0F857775252F88B86D4B072AFADC9D9BC3_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		String_t* L_0 = ___errorMessage1;
		if (L_0)
		{
			goto IL_000d;
		}
	}
	{
		String_t* L_1 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_5();
		___errorMessage1 = L_1;
	}

IL_000d:
	{
		String_t* L_2 = ___errorMessage1;
		NullCheck(L_2);
		int32_t L_3 = String_get_Length_mD48C8A16A5CF1914F330DCE82D9BE15C3BEDD018(L_2, /*hidden argument*/NULL);
		if ((((int32_t)L_3) <= ((int32_t)0)))
		{
			goto IL_0026;
		}
	}
	{
		String_t* L_4 = ___errorMessage1;
		String_t* L_5 = String_Concat_mB78D0094592718DA6D5DB6C712A9C225631666BE(_stringLiteralBA8AB5A0280B953AA97435FF8946CBCBB2755A27, L_4, /*hidden argument*/NULL);
		___errorMessage1 = L_5;
	}

IL_0026:
	{
		int32_t L_6 = ___errorCode0;
		if ((((int32_t)L_6) < ((int32_t)0)))
		{
			goto IL_003a;
		}
	}
	{
		int32_t L_7 = ___errorCode0;
		IL2CPP_RUNTIME_CLASS_INIT(SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6_il2cpp_TypeInfo_var);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_8 = ((SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6_StaticFields*)il2cpp_codegen_static_fields_for(SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6_il2cpp_TypeInfo_var))->get__errorMessages_18();
		NullCheck(L_8);
		if ((((int32_t)L_7) < ((int32_t)(((int32_t)((int32_t)(((RuntimeArray *)L_8)->max_length)))))))
		{
			goto IL_003d;
		}
	}

IL_003a:
	{
		___errorCode0 = 1;
	}

IL_003d:
	{
		IL2CPP_RUNTIME_CLASS_INIT(SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6_il2cpp_TypeInfo_var);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_9 = ((SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6_StaticFields*)il2cpp_codegen_static_fields_for(SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6_il2cpp_TypeInfo_var))->get__errorMessages_18();
		int32_t L_10 = ___errorCode0;
		NullCheck(L_9);
		int32_t L_11 = L_10;
		String_t* L_12 = (L_9)->GetAt(static_cast<il2cpp_array_size_t>(L_11));
		String_t* L_13 = ___errorMessage1;
		String_t* L_14 = String_Concat_mB78D0094592718DA6D5DB6C712A9C225631666BE(L_12, L_13, /*hidden argument*/NULL);
		return L_14;
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
// System.Void Mono.Data.Sqlite.SqliteFactory::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SqliteFactory__ctor_mB4B0F6DF58CF3726649B08768131170FC0A9F01B (SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7 * __this, const RuntimeMethod* method)
{
	{
		DbProviderFactory__ctor_m1376F504CE5DDF21DAFA220AB675124C32B285CE(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteFactory::.cctor()
extern "C" IL2CPP_METHOD_ATTR void SqliteFactory__cctor_m52241130E4EAA219059982F548B4923ED536CA97 (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteFactory__cctor_m52241130E4EAA219059982F548B4923ED536CA97_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7 * L_0 = (SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7 *)il2cpp_codegen_object_new(SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7_il2cpp_TypeInfo_var);
		SqliteFactory__ctor_mB4B0F6DF58CF3726649B08768131170FC0A9F01B(L_0, /*hidden argument*/NULL);
		((SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7_StaticFields*)il2cpp_codegen_static_fields_for(SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7_il2cpp_TypeInfo_var))->set_Instance_0(L_0);
		IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
		Type_t * L_1 = il2cpp_codegen_get_type((Il2CppMethodPointer)&Type_GetType_m8A8A6481B24551476F2AF999A970AD705BA68C7A, _stringLiteralBA7B74E6880085D4646D2D47931AD9243932EB41, (bool)0, "Mono.Data.Sqlite, Version=2.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756");
		((SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7_StaticFields*)il2cpp_codegen_static_fields_for(SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7_il2cpp_TypeInfo_var))->set__dbProviderServicesType_1(L_1);
		return;
	}
}
// System.Object Mono.Data.Sqlite.SqliteFactory::System.IServiceProvider.GetService(System.Type)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * SqliteFactory_System_IServiceProvider_GetService_m28A88FAC3C28EAB28480E4AC7B1510578C080143 (SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7 * __this, Type_t * ___serviceType0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteFactory_System_IServiceProvider_GetService_m28A88FAC3C28EAB28480E4AC7B1510578C080143_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Type_t * L_0 = ___serviceType0;
		RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  L_1 = { reinterpret_cast<intptr_t> (ISQLiteSchemaExtensions_t9BD0010F9CF0685AAAFFAF3EF5EDD9B2DCD8E772_0_0_0_var) };
		IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
		Type_t * L_2 = Type_GetTypeFromHandle_m9DC58ADF0512987012A8A016FB64B068F3B1AFF6(L_1, /*hidden argument*/NULL);
		if ((((RuntimeObject*)(Type_t *)L_0) == ((RuntimeObject*)(Type_t *)L_2)))
		{
			goto IL_0025;
		}
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7_il2cpp_TypeInfo_var);
		Type_t * L_3 = ((SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7_StaticFields*)il2cpp_codegen_static_fields_for(SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7_il2cpp_TypeInfo_var))->get__dbProviderServicesType_1();
		if (!L_3)
		{
			goto IL_002c;
		}
	}
	{
		Type_t * L_4 = ___serviceType0;
		IL2CPP_RUNTIME_CLASS_INIT(SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7_il2cpp_TypeInfo_var);
		Type_t * L_5 = ((SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7_StaticFields*)il2cpp_codegen_static_fields_for(SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7_il2cpp_TypeInfo_var))->get__dbProviderServicesType_1();
		if ((!(((RuntimeObject*)(Type_t *)L_4) == ((RuntimeObject*)(Type_t *)L_5))))
		{
			goto IL_002c;
		}
	}

IL_0025:
	{
		RuntimeObject * L_6 = SqliteFactory_GetSQLiteProviderServicesInstance_m54787EE0DDCA751DC83B454F4A69E50725B0BF77(__this, /*hidden argument*/NULL);
		return L_6;
	}

IL_002c:
	{
		return NULL;
	}
}
// System.Object Mono.Data.Sqlite.SqliteFactory::GetSQLiteProviderServicesInstance()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * SqliteFactory_GetSQLiteProviderServicesInstance_m54787EE0DDCA751DC83B454F4A69E50725B0BF77 (SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteFactory_GetSQLiteProviderServicesInstance_m54787EE0DDCA751DC83B454F4A69E50725B0BF77_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Type_t * V_0 = NULL;
	FieldInfo_t * V_1 = NULL;
	{
		IL2CPP_RUNTIME_CLASS_INIT(SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7_il2cpp_TypeInfo_var);
		RuntimeObject * L_0 = ((SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7_StaticFields*)il2cpp_codegen_static_fields_for(SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7_il2cpp_TypeInfo_var))->get__sqliteServices_2();
		if (L_0)
		{
			goto IL_0036;
		}
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
		Type_t * L_1 = il2cpp_codegen_get_type((Il2CppMethodPointer)&Type_GetType_m8A8A6481B24551476F2AF999A970AD705BA68C7A, _stringLiteral246AFB2A711D8CCEC2D90C6953074DABA1E3FF7E, (bool)0, "Mono.Data.Sqlite, Version=2.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756");
		V_0 = L_1;
		Type_t * L_2 = V_0;
		if (!L_2)
		{
			goto IL_0036;
		}
	}
	{
		Type_t * L_3 = V_0;
		NullCheck(L_3);
		FieldInfo_t * L_4 = VirtFuncInvoker2< FieldInfo_t *, String_t*, int32_t >::Invoke(43 /* System.Reflection.FieldInfo System.Type::GetField(System.String,System.Reflection.BindingFlags) */, L_3, _stringLiteral5F97F8775628E86310829AB9E8C465258AB92A5E, ((int32_t)44));
		V_1 = L_4;
		FieldInfo_t * L_5 = V_1;
		NullCheck(L_5);
		RuntimeObject * L_6 = VirtFuncInvoker1< RuntimeObject *, RuntimeObject * >::Invoke(20 /* System.Object System.Reflection.FieldInfo::GetValue(System.Object) */, L_5, NULL);
		IL2CPP_RUNTIME_CLASS_INIT(SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7_il2cpp_TypeInfo_var);
		((SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7_StaticFields*)il2cpp_codegen_static_fields_for(SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7_il2cpp_TypeInfo_var))->set__sqliteServices_2(L_6);
	}

IL_0036:
	{
		IL2CPP_RUNTIME_CLASS_INIT(SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7_il2cpp_TypeInfo_var);
		RuntimeObject * L_7 = ((SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7_StaticFields*)il2cpp_codegen_static_fields_for(SqliteFactory_tCD593DBD80F7C651562973746B9D3656C417B6F7_il2cpp_TypeInfo_var))->get__sqliteServices_2();
		return L_7;
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
// System.Void Mono.Data.Sqlite.SqliteFunction::.cctor()
extern "C" IL2CPP_METHOD_ATTR void SqliteFunction__cctor_mE760607CEA3BAE76B31DBD6C66192AF98DC6FDDE (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteFunction__cctor_mE760607CEA3BAE76B31DBD6C66192AF98DC6FDDE_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD * V_0 = NULL;
	AssemblyU5BU5D_t90BF014AA048450526A42C74F9583341A138DE58* V_1 = NULL;
	int32_t V_2 = 0;
	AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82 * V_3 = NULL;
	int32_t V_4 = 0;
	TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F* V_5 = NULL;
	bool V_6 = false;
	AssemblyNameU5BU5D_tE1C9584468498B9897F558EE8EF4872260CEB34B* V_7 = NULL;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	ReflectionTypeLoadException_t1306B3A246E2959E8F23575AAAB9D59945314115 * V_10 = NULL;
	int32_t V_11 = 0;
	int32_t V_12 = 0;
	ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* V_13 = NULL;
	int32_t V_14 = 0;
	int32_t V_15 = 0;
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	void* __leave_targets_storage = alloca(sizeof(int32_t) * 5);
	il2cpp::utils::LeaveTargetStack __leave_targets(__leave_targets_storage);
	NO_UNUSED_WARNING (__leave_targets);
	{
		List_1_t575BD1306846C6646814C99C87872FD64E8954AB * L_0 = (List_1_t575BD1306846C6646814C99C87872FD64E8954AB *)il2cpp_codegen_object_new(List_1_t575BD1306846C6646814C99C87872FD64E8954AB_il2cpp_TypeInfo_var);
		List_1__ctor_mD4890D8BA3B1549E470AFD135AFB74728CD64516(L_0, /*hidden argument*/List_1__ctor_mD4890D8BA3B1549E470AFD135AFB74728CD64516_RuntimeMethod_var);
		((SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B_StaticFields*)il2cpp_codegen_static_fields_for(SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B_il2cpp_TypeInfo_var))->set__registeredFunctions_8(L_0);
	}

IL_000a:
	try
	{ // begin try (depth: 1)
		{
			AppDomain_t1B59572328F60585904DF52A59FE47CF5B5FFFF8 * L_1 = AppDomain_get_CurrentDomain_m3D3D52C9382D6853E49551DA6182DBC5F1118BF0(/*hidden argument*/NULL);
			NullCheck(L_1);
			AssemblyU5BU5D_t90BF014AA048450526A42C74F9583341A138DE58* L_2 = AppDomain_GetAssemblies_mF1A63ADFC80562168DF846017BB72CAB09298A23(L_1, /*hidden argument*/NULL);
			V_1 = L_2;
			AssemblyU5BU5D_t90BF014AA048450526A42C74F9583341A138DE58* L_3 = V_1;
			NullCheck(L_3);
			V_2 = (((int32_t)((int32_t)(((RuntimeArray *)L_3)->max_length))));
			Assembly_t * L_4 = Assembly_GetCallingAssembly_m0DB9F5D2B9770113FF2E239A9EB0DB0EC3A6E384(/*hidden argument*/NULL);
			NullCheck(L_4);
			AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82 * L_5 = VirtFuncInvoker0< AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82 * >::Invoke(22 /* System.Reflection.AssemblyName System.Reflection.Assembly::GetName() */, L_4);
			V_3 = L_5;
			V_4 = 0;
			goto IL_0132;
		}

IL_002c:
		{
			V_6 = (bool)0;
		}

IL_002f:
		try
		{ // begin try (depth: 2)
			{
				AssemblyU5BU5D_t90BF014AA048450526A42C74F9583341A138DE58* L_6 = V_1;
				int32_t L_7 = V_4;
				NullCheck(L_6);
				int32_t L_8 = L_7;
				Assembly_t * L_9 = (L_6)->GetAt(static_cast<il2cpp_array_size_t>(L_8));
				NullCheck(L_9);
				AssemblyNameU5BU5D_tE1C9584468498B9897F558EE8EF4872260CEB34B* L_10 = VirtFuncInvoker0< AssemblyNameU5BU5D_tE1C9584468498B9897F558EE8EF4872260CEB34B* >::Invoke(31 /* System.Reflection.AssemblyName[] System.Reflection.Assembly::GetReferencedAssemblies() */, L_9);
				V_7 = L_10;
				AssemblyNameU5BU5D_tE1C9584468498B9897F558EE8EF4872260CEB34B* L_11 = V_7;
				NullCheck(L_11);
				V_8 = (((int32_t)((int32_t)(((RuntimeArray *)L_11)->max_length))));
				V_9 = 0;
				goto IL_0070;
			}

IL_0048:
			{
				AssemblyNameU5BU5D_tE1C9584468498B9897F558EE8EF4872260CEB34B* L_12 = V_7;
				int32_t L_13 = V_9;
				NullCheck(L_12);
				int32_t L_14 = L_13;
				AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82 * L_15 = (L_12)->GetAt(static_cast<il2cpp_array_size_t>(L_14));
				NullCheck(L_15);
				String_t* L_16 = AssemblyName_get_Name_m6EA5C18D2FF050D3AF58D4A21ED39D161DFF218B(L_15, /*hidden argument*/NULL);
				AssemblyName_t6F3EC58113268060348EE894DCB46F6EF6BBBB82 * L_17 = V_3;
				NullCheck(L_17);
				String_t* L_18 = AssemblyName_get_Name_m6EA5C18D2FF050D3AF58D4A21ED39D161DFF218B(L_17, /*hidden argument*/NULL);
				bool L_19 = String_op_Equality_m139F0E4195AE2F856019E63B241F36F016997FCE(L_16, L_18, /*hidden argument*/NULL);
				if (!L_19)
				{
					goto IL_006a;
				}
			}

IL_0062:
			{
				V_6 = (bool)1;
				goto IL_0079;
			}

IL_006a:
			{
				int32_t L_20 = V_9;
				V_9 = ((int32_t)il2cpp_codegen_add((int32_t)L_20, (int32_t)1));
			}

IL_0070:
			{
				int32_t L_21 = V_9;
				int32_t L_22 = V_8;
				if ((((int32_t)L_21) < ((int32_t)L_22)))
				{
					goto IL_0048;
				}
			}

IL_0079:
			{
				bool L_23 = V_6;
				if (L_23)
				{
					goto IL_0085;
				}
			}

IL_0080:
			{
				goto IL_012c;
			}

IL_0085:
			{
				AssemblyU5BU5D_t90BF014AA048450526A42C74F9583341A138DE58* L_24 = V_1;
				int32_t L_25 = V_4;
				NullCheck(L_24);
				int32_t L_26 = L_25;
				Assembly_t * L_27 = (L_24)->GetAt(static_cast<il2cpp_array_size_t>(L_26));
				NullCheck(L_27);
				TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F* L_28 = VirtFuncInvoker0< TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F* >::Invoke(18 /* System.Type[] System.Reflection.Assembly::GetTypes() */, L_27);
				V_5 = L_28;
				goto IL_00a5;
			}
		} // end try (depth: 2)
		catch(Il2CppExceptionWrapper& e)
		{
			__exception_local = (Exception_t *)e.ex;
			if(il2cpp_codegen_class_is_assignable_from (ReflectionTypeLoadException_t1306B3A246E2959E8F23575AAAB9D59945314115_il2cpp_TypeInfo_var, il2cpp_codegen_object_class(e.ex)))
				goto CATCH_0095;
			throw e;
		}

CATCH_0095:
		{ // begin catch(System.Reflection.ReflectionTypeLoadException)
			V_10 = ((ReflectionTypeLoadException_t1306B3A246E2959E8F23575AAAB9D59945314115 *)__exception_local);
			ReflectionTypeLoadException_t1306B3A246E2959E8F23575AAAB9D59945314115 * L_29 = V_10;
			NullCheck(L_29);
			TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F* L_30 = ReflectionTypeLoadException_get_Types_mF7DBBFDB3486667189D72A2A0B95DF42D463E3DE(L_29, /*hidden argument*/NULL);
			V_5 = L_30;
			goto IL_00a5;
		} // end catch (depth: 2)

IL_00a5:
		{
			TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F* L_31 = V_5;
			NullCheck(L_31);
			V_11 = (((int32_t)((int32_t)(((RuntimeArray *)L_31)->max_length))));
			V_12 = 0;
			goto IL_0123;
		}

IL_00b3:
		{
			TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F* L_32 = V_5;
			int32_t L_33 = V_12;
			NullCheck(L_32);
			int32_t L_34 = L_33;
			Type_t * L_35 = (L_32)->GetAt(static_cast<il2cpp_array_size_t>(L_34));
			if (L_35)
			{
				goto IL_00c2;
			}
		}

IL_00bd:
		{
			goto IL_011d;
		}

IL_00c2:
		{
			TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F* L_36 = V_5;
			int32_t L_37 = V_12;
			NullCheck(L_36);
			int32_t L_38 = L_37;
			Type_t * L_39 = (L_36)->GetAt(static_cast<il2cpp_array_size_t>(L_38));
			RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  L_40 = { reinterpret_cast<intptr_t> (SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD_0_0_0_var) };
			IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
			Type_t * L_41 = Type_GetTypeFromHandle_m9DC58ADF0512987012A8A016FB64B068F3B1AFF6(L_40, /*hidden argument*/NULL);
			NullCheck(L_39);
			ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* L_42 = VirtFuncInvoker2< ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A*, Type_t *, bool >::Invoke(12 /* System.Object[] System.Reflection.MemberInfo::GetCustomAttributes(System.Type,System.Boolean) */, L_39, L_41, (bool)0);
			V_13 = L_42;
			ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* L_43 = V_13;
			NullCheck(L_43);
			V_14 = (((int32_t)((int32_t)(((RuntimeArray *)L_43)->max_length))));
			V_15 = 0;
			goto IL_0114;
		}

IL_00e7:
		{
			ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* L_44 = V_13;
			int32_t L_45 = V_15;
			NullCheck(L_44);
			int32_t L_46 = L_45;
			RuntimeObject * L_47 = (L_44)->GetAt(static_cast<il2cpp_array_size_t>(L_46));
			V_0 = ((SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD *)IsInstSealed((RuntimeObject*)L_47, SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD_il2cpp_TypeInfo_var));
			SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD * L_48 = V_0;
			if (!L_48)
			{
				goto IL_010e;
			}
		}

IL_00f8:
		{
			SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD * L_49 = V_0;
			TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F* L_50 = V_5;
			int32_t L_51 = V_12;
			NullCheck(L_50);
			int32_t L_52 = L_51;
			Type_t * L_53 = (L_50)->GetAt(static_cast<il2cpp_array_size_t>(L_52));
			NullCheck(L_49);
			L_49->set__instanceType_3(L_53);
			List_1_t575BD1306846C6646814C99C87872FD64E8954AB * L_54 = ((SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B_StaticFields*)il2cpp_codegen_static_fields_for(SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B_il2cpp_TypeInfo_var))->get__registeredFunctions_8();
			SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD * L_55 = V_0;
			NullCheck(L_54);
			List_1_Add_mDB86C4D19D3AFD79C5C0CEB04AC08E5A8C5353D6(L_54, L_55, /*hidden argument*/List_1_Add_mDB86C4D19D3AFD79C5C0CEB04AC08E5A8C5353D6_RuntimeMethod_var);
		}

IL_010e:
		{
			int32_t L_56 = V_15;
			V_15 = ((int32_t)il2cpp_codegen_add((int32_t)L_56, (int32_t)1));
		}

IL_0114:
		{
			int32_t L_57 = V_15;
			int32_t L_58 = V_14;
			if ((((int32_t)L_57) < ((int32_t)L_58)))
			{
				goto IL_00e7;
			}
		}

IL_011d:
		{
			int32_t L_59 = V_12;
			V_12 = ((int32_t)il2cpp_codegen_add((int32_t)L_59, (int32_t)1));
		}

IL_0123:
		{
			int32_t L_60 = V_12;
			int32_t L_61 = V_11;
			if ((((int32_t)L_60) < ((int32_t)L_61)))
			{
				goto IL_00b3;
			}
		}

IL_012c:
		{
			int32_t L_62 = V_4;
			V_4 = ((int32_t)il2cpp_codegen_add((int32_t)L_62, (int32_t)1));
		}

IL_0132:
		{
			int32_t L_63 = V_4;
			int32_t L_64 = V_2;
			if ((((int32_t)L_63) < ((int32_t)L_64)))
			{
				goto IL_002c;
			}
		}

IL_013a:
		{
			goto IL_0145;
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__exception_local = (Exception_t *)e.ex;
		if(il2cpp_codegen_class_is_assignable_from (RuntimeObject_il2cpp_TypeInfo_var, il2cpp_codegen_object_class(e.ex)))
			goto CATCH_013f;
		throw e;
	}

CATCH_013f:
	{ // begin catch(System.Object)
		goto IL_0145;
	} // end catch (depth: 1)

IL_0145:
	{
		return;
	}
}
// System.Object Mono.Data.Sqlite.SqliteFunction::Invoke(System.Object[])
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * SqliteFunction_Invoke_m8BAF02071C00BBA2B2970D17FE6823985062BAB6 (SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * __this, ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* ___args0, const RuntimeMethod* method)
{
	{
		return NULL;
	}
}
// System.Void Mono.Data.Sqlite.SqliteFunction::Step(System.Object[],System.Int32,System.ObjectU26)
extern "C" IL2CPP_METHOD_ATTR void SqliteFunction_Step_m6478F29C657336218EE8C964A7E499EBAA7DEB2D (SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * __this, ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* ___args0, int32_t ___stepNumber1, RuntimeObject ** ___contextData2, const RuntimeMethod* method)
{
	{
		return;
	}
}
// System.Object Mono.Data.Sqlite.SqliteFunction::Final(System.Object)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * SqliteFunction_Final_m79F8A4423678CA86902567255C3EE82D2583C48A (SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * __this, RuntimeObject * ___contextData0, const RuntimeMethod* method)
{
	{
		return NULL;
	}
}
// System.Int32 Mono.Data.Sqlite.SqliteFunction::Compare(System.String,System.String)
extern "C" IL2CPP_METHOD_ATTR int32_t SqliteFunction_Compare_m73198C891E0D46E9735D0FA2C07A41871E285406 (SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * __this, String_t* ___param10, String_t* ___param21, const RuntimeMethod* method)
{
	{
		return 0;
	}
}
// System.Object[] Mono.Data.Sqlite.SqliteFunction::ConvertParams(System.Int32,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* SqliteFunction_ConvertParams_m3B967FF80BD969603C902F1DF9EB2704FBD0357D (SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * __this, int32_t ___nArgs0, intptr_t ___argsptr1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteFunction_ConvertParams_m3B967FF80BD969603C902F1DF9EB2704FBD0357D_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* V_0 = NULL;
	IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD* V_1 = NULL;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* V_4 = NULL;
	int32_t V_5 = 0;
	{
		int32_t L_0 = ___nArgs0;
		ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* L_1 = (ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A*)SZArrayNew(ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A_il2cpp_TypeInfo_var, (uint32_t)L_0);
		V_0 = L_1;
		int32_t L_2 = ___nArgs0;
		IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD* L_3 = (IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD*)SZArrayNew(IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD_il2cpp_TypeInfo_var, (uint32_t)L_2);
		V_1 = L_3;
		intptr_t L_4 = ___argsptr1;
		IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD* L_5 = V_1;
		int32_t L_6 = ___nArgs0;
		IL2CPP_RUNTIME_CLASS_INIT(Marshal_tC795CE9CC2FFBA41EDB1AC1C0FEC04607DFA8A40_il2cpp_TypeInfo_var);
		Marshal_Copy_m1E0083CB21F1FE2109590AF0916893C349871CED((intptr_t)L_4, L_5, 0, L_6, /*hidden argument*/NULL);
		V_2 = 0;
		goto IL_0121;
	}

IL_001e:
	{
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_7 = __this->get__base_0();
		IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD* L_8 = V_1;
		int32_t L_9 = V_2;
		NullCheck(L_8);
		int32_t L_10 = L_9;
		intptr_t L_11 = (L_8)->GetAt(static_cast<il2cpp_array_size_t>(L_10));
		NullCheck(L_7);
		int32_t L_12 = VirtFuncInvoker1< int32_t, intptr_t >::Invoke(47 /* Mono.Data.Sqlite.TypeAffinity Mono.Data.Sqlite.SQLiteBase::GetParamValueType(System.IntPtr) */, L_7, (intptr_t)L_11);
		V_5 = L_12;
		int32_t L_13 = V_5;
		switch (((int32_t)il2cpp_codegen_subtract((int32_t)L_13, (int32_t)1)))
		{
			case 0:
			{
				goto IL_0071;
			}
			case 1:
			{
				goto IL_008c;
			}
			case 2:
			{
				goto IL_00a7;
			}
			case 3:
			{
				goto IL_00bd;
			}
			case 4:
			{
				goto IL_0064;
			}
			case 5:
			{
				goto IL_011d;
			}
			case 6:
			{
				goto IL_011d;
			}
			case 7:
			{
				goto IL_011d;
			}
			case 8:
			{
				goto IL_011d;
			}
			case 9:
			{
				goto IL_00f7;
			}
		}
	}
	{
		goto IL_011d;
	}

IL_0064:
	{
		ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* L_14 = V_0;
		int32_t L_15 = V_2;
		IL2CPP_RUNTIME_CLASS_INIT(DBNull_t7400E04939C2C29699B389B106997892BF53A8E5_il2cpp_TypeInfo_var);
		DBNull_t7400E04939C2C29699B389B106997892BF53A8E5 * L_16 = ((DBNull_t7400E04939C2C29699B389B106997892BF53A8E5_StaticFields*)il2cpp_codegen_static_fields_for(DBNull_t7400E04939C2C29699B389B106997892BF53A8E5_il2cpp_TypeInfo_var))->get_Value_0();
		NullCheck(L_14);
		ArrayElementTypeCheck (L_14, L_16);
		(L_14)->SetAt(static_cast<il2cpp_array_size_t>(L_15), (RuntimeObject *)L_16);
		goto IL_011d;
	}

IL_0071:
	{
		ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* L_17 = V_0;
		int32_t L_18 = V_2;
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_19 = __this->get__base_0();
		IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD* L_20 = V_1;
		int32_t L_21 = V_2;
		NullCheck(L_20);
		int32_t L_22 = L_21;
		intptr_t L_23 = (L_20)->GetAt(static_cast<il2cpp_array_size_t>(L_22));
		NullCheck(L_19);
		int64_t L_24 = VirtFuncInvoker1< int64_t, intptr_t >::Invoke(45 /* System.Int64 Mono.Data.Sqlite.SQLiteBase::GetParamValueInt64(System.IntPtr) */, L_19, (intptr_t)L_23);
		int64_t L_25 = L_24;
		RuntimeObject * L_26 = Box(Int64_t7A386C2FF7B0280A0F516992401DDFCF0FF7B436_il2cpp_TypeInfo_var, &L_25);
		NullCheck(L_17);
		ArrayElementTypeCheck (L_17, L_26);
		(L_17)->SetAt(static_cast<il2cpp_array_size_t>(L_18), (RuntimeObject *)L_26);
		goto IL_011d;
	}

IL_008c:
	{
		ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* L_27 = V_0;
		int32_t L_28 = V_2;
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_29 = __this->get__base_0();
		IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD* L_30 = V_1;
		int32_t L_31 = V_2;
		NullCheck(L_30);
		int32_t L_32 = L_31;
		intptr_t L_33 = (L_30)->GetAt(static_cast<il2cpp_array_size_t>(L_32));
		NullCheck(L_29);
		double L_34 = VirtFuncInvoker1< double, intptr_t >::Invoke(44 /* System.Double Mono.Data.Sqlite.SQLiteBase::GetParamValueDouble(System.IntPtr) */, L_29, (intptr_t)L_33);
		double L_35 = L_34;
		RuntimeObject * L_36 = Box(Double_t358B8F23BDC52A5DD700E727E204F9F7CDE12409_il2cpp_TypeInfo_var, &L_35);
		NullCheck(L_27);
		ArrayElementTypeCheck (L_27, L_36);
		(L_27)->SetAt(static_cast<il2cpp_array_size_t>(L_28), (RuntimeObject *)L_36);
		goto IL_011d;
	}

IL_00a7:
	{
		ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* L_37 = V_0;
		int32_t L_38 = V_2;
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_39 = __this->get__base_0();
		IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD* L_40 = V_1;
		int32_t L_41 = V_2;
		NullCheck(L_40);
		int32_t L_42 = L_41;
		intptr_t L_43 = (L_40)->GetAt(static_cast<il2cpp_array_size_t>(L_42));
		NullCheck(L_39);
		String_t* L_44 = VirtFuncInvoker1< String_t*, intptr_t >::Invoke(46 /* System.String Mono.Data.Sqlite.SQLiteBase::GetParamValueText(System.IntPtr) */, L_39, (intptr_t)L_43);
		NullCheck(L_37);
		ArrayElementTypeCheck (L_37, L_44);
		(L_37)->SetAt(static_cast<il2cpp_array_size_t>(L_38), (RuntimeObject *)L_44);
		goto IL_011d;
	}

IL_00bd:
	{
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_45 = __this->get__base_0();
		IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD* L_46 = V_1;
		int32_t L_47 = V_2;
		NullCheck(L_46);
		int32_t L_48 = L_47;
		intptr_t L_49 = (L_46)->GetAt(static_cast<il2cpp_array_size_t>(L_48));
		NullCheck(L_45);
		int64_t L_50 = VirtFuncInvoker5< int64_t, intptr_t, int32_t, ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821*, int32_t, int32_t >::Invoke(43 /* System.Int64 Mono.Data.Sqlite.SQLiteBase::GetParamValueBytes(System.IntPtr,System.Int32,System.Byte[],System.Int32,System.Int32) */, L_45, (intptr_t)L_49, 0, (ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821*)(ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821*)NULL, 0, 0);
		V_3 = (((int32_t)((int32_t)L_50)));
		int32_t L_51 = V_3;
		ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* L_52 = (ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821*)SZArrayNew(ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821_il2cpp_TypeInfo_var, (uint32_t)L_51);
		V_4 = L_52;
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_53 = __this->get__base_0();
		IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD* L_54 = V_1;
		int32_t L_55 = V_2;
		NullCheck(L_54);
		int32_t L_56 = L_55;
		intptr_t L_57 = (L_54)->GetAt(static_cast<il2cpp_array_size_t>(L_56));
		ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* L_58 = V_4;
		int32_t L_59 = V_3;
		NullCheck(L_53);
		VirtFuncInvoker5< int64_t, intptr_t, int32_t, ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821*, int32_t, int32_t >::Invoke(43 /* System.Int64 Mono.Data.Sqlite.SQLiteBase::GetParamValueBytes(System.IntPtr,System.Int32,System.Byte[],System.Int32,System.Int32) */, L_53, (intptr_t)L_57, 0, L_58, 0, L_59);
		ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* L_60 = V_0;
		int32_t L_61 = V_2;
		ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* L_62 = V_4;
		NullCheck(L_60);
		ArrayElementTypeCheck (L_60, L_62);
		(L_60)->SetAt(static_cast<il2cpp_array_size_t>(L_61), (RuntimeObject *)L_62);
		goto IL_011d;
	}

IL_00f7:
	{
		ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* L_63 = V_0;
		int32_t L_64 = V_2;
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_65 = __this->get__base_0();
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_66 = __this->get__base_0();
		IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD* L_67 = V_1;
		int32_t L_68 = V_2;
		NullCheck(L_67);
		int32_t L_69 = L_68;
		intptr_t L_70 = (L_67)->GetAt(static_cast<il2cpp_array_size_t>(L_69));
		NullCheck(L_66);
		String_t* L_71 = VirtFuncInvoker1< String_t*, intptr_t >::Invoke(46 /* System.String Mono.Data.Sqlite.SQLiteBase::GetParamValueText(System.IntPtr) */, L_66, (intptr_t)L_70);
		NullCheck(L_65);
		DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132  L_72 = SqliteConvert_ToDateTime_mF34ED11F61E5E5DC34567DBA1007F426E408DA62(L_65, L_71, /*hidden argument*/NULL);
		DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132  L_73 = L_72;
		RuntimeObject * L_74 = Box(DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132_il2cpp_TypeInfo_var, &L_73);
		NullCheck(L_63);
		ArrayElementTypeCheck (L_63, L_74);
		(L_63)->SetAt(static_cast<il2cpp_array_size_t>(L_64), (RuntimeObject *)L_74);
		goto IL_011d;
	}

IL_011d:
	{
		int32_t L_75 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add((int32_t)L_75, (int32_t)1));
	}

IL_0121:
	{
		int32_t L_76 = V_2;
		int32_t L_77 = ___nArgs0;
		if ((((int32_t)L_76) < ((int32_t)L_77)))
		{
			goto IL_001e;
		}
	}
	{
		ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* L_78 = V_0;
		return L_78;
	}
}
// System.Void Mono.Data.Sqlite.SqliteFunction::SetReturnValue(System.IntPtr,System.Object)
extern "C" IL2CPP_METHOD_ATTR void SqliteFunction_SetReturnValue_mD2B822ACF24A89AE1902E00A3AED96982254D5C5 (SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * __this, intptr_t ___context0, RuntimeObject * ___returnValue1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteFunction_SetReturnValue_mD2B822ACF24A89AE1902E00A3AED96982254D5C5_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Type_t * V_0 = NULL;
	Exception_t * V_1 = NULL;
	int32_t V_2 = 0;
	{
		RuntimeObject * L_0 = ___returnValue1;
		if (!L_0)
		{
			goto IL_0011;
		}
	}
	{
		RuntimeObject * L_1 = ___returnValue1;
		IL2CPP_RUNTIME_CLASS_INIT(DBNull_t7400E04939C2C29699B389B106997892BF53A8E5_il2cpp_TypeInfo_var);
		DBNull_t7400E04939C2C29699B389B106997892BF53A8E5 * L_2 = ((DBNull_t7400E04939C2C29699B389B106997892BF53A8E5_StaticFields*)il2cpp_codegen_static_fields_for(DBNull_t7400E04939C2C29699B389B106997892BF53A8E5_il2cpp_TypeInfo_var))->get_Value_0();
		if ((!(((RuntimeObject*)(RuntimeObject *)L_1) == ((RuntimeObject*)(DBNull_t7400E04939C2C29699B389B106997892BF53A8E5 *)L_2))))
		{
			goto IL_001e;
		}
	}

IL_0011:
	{
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_3 = __this->get__base_0();
		intptr_t L_4 = ___context0;
		NullCheck(L_3);
		VirtActionInvoker1< intptr_t >::Invoke(52 /* System.Void Mono.Data.Sqlite.SQLiteBase::ReturnNull(System.IntPtr) */, L_3, (intptr_t)L_4);
		return;
	}

IL_001e:
	{
		RuntimeObject * L_5 = ___returnValue1;
		NullCheck(L_5);
		Type_t * L_6 = Object_GetType_m2E0B62414ECCAA3094B703790CE88CBB2F83EA60(L_5, /*hidden argument*/NULL);
		V_0 = L_6;
		Type_t * L_7 = V_0;
		RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  L_8 = { reinterpret_cast<intptr_t> (DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132_0_0_0_var) };
		IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
		Type_t * L_9 = Type_GetTypeFromHandle_m9DC58ADF0512987012A8A016FB64B068F3B1AFF6(L_8, /*hidden argument*/NULL);
		if ((!(((RuntimeObject*)(Type_t *)L_7) == ((RuntimeObject*)(Type_t *)L_9))))
		{
			goto IL_0053;
		}
	}
	{
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_10 = __this->get__base_0();
		intptr_t L_11 = ___context0;
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_12 = __this->get__base_0();
		RuntimeObject * L_13 = ___returnValue1;
		NullCheck(L_12);
		String_t* L_14 = SqliteConvert_ToString_m69F17C6967A386680CBC71CE17F9358587A9E887(L_12, ((*(DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132 *)((DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132 *)UnBox(L_13, DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132_il2cpp_TypeInfo_var)))), /*hidden argument*/NULL);
		NullCheck(L_10);
		VirtActionInvoker2< intptr_t, String_t* >::Invoke(53 /* System.Void Mono.Data.Sqlite.SQLiteBase::ReturnText(System.IntPtr,System.String) */, L_10, (intptr_t)L_11, L_14);
		return;
	}

IL_0053:
	{
		RuntimeObject * L_15 = ___returnValue1;
		V_1 = ((Exception_t *)IsInstClass((RuntimeObject*)L_15, Exception_t_il2cpp_TypeInfo_var));
		Exception_t * L_16 = V_1;
		if (!L_16)
		{
			goto IL_0073;
		}
	}
	{
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_17 = __this->get__base_0();
		intptr_t L_18 = ___context0;
		Exception_t * L_19 = V_1;
		NullCheck(L_19);
		String_t* L_20 = VirtFuncInvoker0< String_t* >::Invoke(5 /* System.String System.Exception::get_Message() */, L_19);
		NullCheck(L_17);
		VirtActionInvoker2< intptr_t, String_t* >::Invoke(50 /* System.Void Mono.Data.Sqlite.SQLiteBase::ReturnError(System.IntPtr,System.String) */, L_17, (intptr_t)L_18, L_20);
		return;
	}

IL_0073:
	{
		Type_t * L_21 = V_0;
		IL2CPP_RUNTIME_CLASS_INIT(SqliteConvert_t9FED20EF4CA9E373EBD857ECBA9C74B6307EE6E7_il2cpp_TypeInfo_var);
		int32_t L_22 = SqliteConvert_TypeToAffinity_m98E047A53A1B862A3A5189FF172DAC05208DB41B(L_21, /*hidden argument*/NULL);
		V_2 = L_22;
		int32_t L_23 = V_2;
		switch (((int32_t)il2cpp_codegen_subtract((int32_t)L_23, (int32_t)1)))
		{
			case 0:
			{
				goto IL_00a8;
			}
			case 1:
			{
				goto IL_00c0;
			}
			case 2:
			{
				goto IL_00d8;
			}
			case 3:
			{
				goto IL_00eb;
			}
			case 4:
			{
				goto IL_009b;
			}
		}
	}
	{
		goto IL_00fe;
	}

IL_009b:
	{
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_24 = __this->get__base_0();
		intptr_t L_25 = ___context0;
		NullCheck(L_24);
		VirtActionInvoker1< intptr_t >::Invoke(52 /* System.Void Mono.Data.Sqlite.SQLiteBase::ReturnNull(System.IntPtr) */, L_24, (intptr_t)L_25);
		return;
	}

IL_00a8:
	{
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_26 = __this->get__base_0();
		intptr_t L_27 = ___context0;
		RuntimeObject * L_28 = ___returnValue1;
		IL2CPP_RUNTIME_CLASS_INIT(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_il2cpp_TypeInfo_var);
		CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * L_29 = CultureInfo_get_CurrentCulture_mD86F3D8E5D332FB304F80D9B9CA4DE849C2A6831(/*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Convert_t1C7A851BFB2F0782FD7F72F6AA1DCBB7B53A9C7E_il2cpp_TypeInfo_var);
		int64_t L_30 = Convert_ToInt64_m8964FDE5D82FEC54106DBF35E1F67D70F6E73E29(L_28, L_29, /*hidden argument*/NULL);
		NullCheck(L_26);
		VirtActionInvoker2< intptr_t, int64_t >::Invoke(51 /* System.Void Mono.Data.Sqlite.SQLiteBase::ReturnInt64(System.IntPtr,System.Int64) */, L_26, (intptr_t)L_27, L_30);
		return;
	}

IL_00c0:
	{
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_31 = __this->get__base_0();
		intptr_t L_32 = ___context0;
		RuntimeObject * L_33 = ___returnValue1;
		IL2CPP_RUNTIME_CLASS_INIT(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_il2cpp_TypeInfo_var);
		CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * L_34 = CultureInfo_get_CurrentCulture_mD86F3D8E5D332FB304F80D9B9CA4DE849C2A6831(/*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Convert_t1C7A851BFB2F0782FD7F72F6AA1DCBB7B53A9C7E_il2cpp_TypeInfo_var);
		double L_35 = Convert_ToDouble_m053A47D87C59CA7A87D4E67E5E06368D775D7651(L_33, L_34, /*hidden argument*/NULL);
		NullCheck(L_31);
		VirtActionInvoker2< intptr_t, double >::Invoke(49 /* System.Void Mono.Data.Sqlite.SQLiteBase::ReturnDouble(System.IntPtr,System.Double) */, L_31, (intptr_t)L_32, L_35);
		return;
	}

IL_00d8:
	{
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_36 = __this->get__base_0();
		intptr_t L_37 = ___context0;
		RuntimeObject * L_38 = ___returnValue1;
		NullCheck(L_38);
		String_t* L_39 = VirtFuncInvoker0< String_t* >::Invoke(3 /* System.String System.Object::ToString() */, L_38);
		NullCheck(L_36);
		VirtActionInvoker2< intptr_t, String_t* >::Invoke(53 /* System.Void Mono.Data.Sqlite.SQLiteBase::ReturnText(System.IntPtr,System.String) */, L_36, (intptr_t)L_37, L_39);
		return;
	}

IL_00eb:
	{
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_40 = __this->get__base_0();
		intptr_t L_41 = ___context0;
		RuntimeObject * L_42 = ___returnValue1;
		NullCheck(L_40);
		VirtActionInvoker2< intptr_t, ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* >::Invoke(48 /* System.Void Mono.Data.Sqlite.SQLiteBase::ReturnBlob(System.IntPtr,System.Byte[]) */, L_40, (intptr_t)L_41, ((ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821*)Castclass((RuntimeObject*)L_42, ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821_il2cpp_TypeInfo_var)));
		return;
	}

IL_00fe:
	{
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteFunction::ScalarCallback(System.IntPtr,System.Int32,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR void SqliteFunction_ScalarCallback_m3D05C042753B243F0AC40FC6C01A4D34E9897D44 (SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * __this, intptr_t ___context0, int32_t ___nArgs1, intptr_t ___argsptr2, const RuntimeMethod* method)
{
	{
		intptr_t L_0 = ___context0;
		__this->set__context_7((intptr_t)L_0);
		intptr_t L_1 = ___context0;
		int32_t L_2 = ___nArgs1;
		intptr_t L_3 = ___argsptr2;
		ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* L_4 = SqliteFunction_ConvertParams_m3B967FF80BD969603C902F1DF9EB2704FBD0357D(__this, L_2, (intptr_t)L_3, /*hidden argument*/NULL);
		RuntimeObject * L_5 = VirtFuncInvoker1< RuntimeObject *, ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* >::Invoke(5 /* System.Object Mono.Data.Sqlite.SqliteFunction::Invoke(System.Object[]) */, __this, L_4);
		SqliteFunction_SetReturnValue_mD2B822ACF24A89AE1902E00A3AED96982254D5C5(__this, (intptr_t)L_1, L_5, /*hidden argument*/NULL);
		return;
	}
}
// System.Int32 Mono.Data.Sqlite.SqliteFunction::CompareCallback(System.IntPtr,System.Int32,System.IntPtr,System.Int32,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR int32_t SqliteFunction_CompareCallback_mBE735C82605FEF47F8B6E78E3CF04130049CA95D (SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * __this, intptr_t ___ptr0, int32_t ___len11, intptr_t ___ptr12, int32_t ___len23, intptr_t ___ptr24, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteFunction_CompareCallback_mBE735C82605FEF47F8B6E78E3CF04130049CA95D_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		intptr_t L_0 = ___ptr12;
		int32_t L_1 = ___len11;
		IL2CPP_RUNTIME_CLASS_INIT(SqliteConvert_t9FED20EF4CA9E373EBD857ECBA9C74B6307EE6E7_il2cpp_TypeInfo_var);
		String_t* L_2 = SqliteConvert_UTF8ToString_m4491E391E180610172F5DB15472CA3836B3724A9((intptr_t)L_0, L_1, /*hidden argument*/NULL);
		intptr_t L_3 = ___ptr24;
		int32_t L_4 = ___len23;
		String_t* L_5 = SqliteConvert_UTF8ToString_m4491E391E180610172F5DB15472CA3836B3724A9((intptr_t)L_3, L_4, /*hidden argument*/NULL);
		int32_t L_6 = VirtFuncInvoker2< int32_t, String_t*, String_t* >::Invoke(8 /* System.Int32 Mono.Data.Sqlite.SqliteFunction::Compare(System.String,System.String) */, __this, L_2, L_5);
		return L_6;
	}
}
// System.Int32 Mono.Data.Sqlite.SqliteFunction::CompareCallback16(System.IntPtr,System.Int32,System.IntPtr,System.Int32,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR int32_t SqliteFunction_CompareCallback16_mD310867D85DB029BC1E7E2F48CD1210BD70A9162 (SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * __this, intptr_t ___ptr0, int32_t ___len11, intptr_t ___ptr12, int32_t ___len23, intptr_t ___ptr24, const RuntimeMethod* method)
{
	{
		intptr_t L_0 = ___ptr12;
		int32_t L_1 = ___len11;
		String_t* L_2 = SQLite3_UTF16_UTF16ToString_mEE1F2F51B58D112761CD33DCC1ADFF2B8F3412CD((intptr_t)L_0, L_1, /*hidden argument*/NULL);
		intptr_t L_3 = ___ptr24;
		int32_t L_4 = ___len23;
		String_t* L_5 = SQLite3_UTF16_UTF16ToString_mEE1F2F51B58D112761CD33DCC1ADFF2B8F3412CD((intptr_t)L_3, L_4, /*hidden argument*/NULL);
		int32_t L_6 = VirtFuncInvoker2< int32_t, String_t*, String_t* >::Invoke(8 /* System.Int32 Mono.Data.Sqlite.SqliteFunction::Compare(System.String,System.String) */, __this, L_2, L_5);
		return L_6;
	}
}
// System.Void Mono.Data.Sqlite.SqliteFunction::StepCallback(System.IntPtr,System.Int32,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR void SqliteFunction_StepCallback_m4CCDD48061DE3BF6A14CEDCF099829179E4F1878 (SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * __this, intptr_t ___context0, int32_t ___nArgs1, intptr_t ___argsptr2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteFunction_StepCallback_m4CCDD48061DE3BF6A14CEDCF099829179E4F1878_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int64_t V_0 = 0;
	AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755 * V_1 = NULL;
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	void* __leave_targets_storage = alloca(sizeof(int32_t) * 1);
	il2cpp::utils::LeaveTargetStack __leave_targets(__leave_targets_storage);
	NO_UNUSED_WARNING (__leave_targets);
	{
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_0 = __this->get__base_0();
		intptr_t L_1 = ___context0;
		NullCheck(L_0);
		intptr_t L_2 = VirtFuncInvoker1< intptr_t, intptr_t >::Invoke(42 /* System.IntPtr Mono.Data.Sqlite.SQLiteBase::AggregateContext(System.IntPtr) */, L_0, (intptr_t)L_1);
		int64_t L_3 = IntPtr_op_Explicit_m254924E8680FCCF870F18064DC0B114445B09172((intptr_t)L_2, /*hidden argument*/NULL);
		V_0 = L_3;
		Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 * L_4 = __this->get__contextDataList_1();
		int64_t L_5 = V_0;
		NullCheck(L_4);
		bool L_6 = Dictionary_2_TryGetValue_m7F2FAA8FE25A7B605BF2247E4719C18AD9D18B18(L_4, L_5, (AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755 **)(&V_1), /*hidden argument*/Dictionary_2_TryGetValue_m7F2FAA8FE25A7B605BF2247E4719C18AD9D18B18_RuntimeMethod_var);
		if (L_6)
		{
			goto IL_0038;
		}
	}
	{
		AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755 * L_7 = (AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755 *)il2cpp_codegen_object_new(AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755_il2cpp_TypeInfo_var);
		AggregateData__ctor_mD2DE3A53E4BAED4BB352B499ED040C24824FD6B3(L_7, /*hidden argument*/NULL);
		V_1 = L_7;
		Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 * L_8 = __this->get__contextDataList_1();
		int64_t L_9 = V_0;
		AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755 * L_10 = V_1;
		NullCheck(L_8);
		Dictionary_2_set_Item_m6307BB9AD542728546442D9CE477BC5815AE1412(L_8, L_9, L_10, /*hidden argument*/Dictionary_2_set_Item_m6307BB9AD542728546442D9CE477BC5815AE1412_RuntimeMethod_var);
	}

IL_0038:
	try
	{ // begin try (depth: 1)
		intptr_t L_11 = ___context0;
		__this->set__context_7((intptr_t)L_11);
		int32_t L_12 = ___nArgs1;
		intptr_t L_13 = ___argsptr2;
		ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* L_14 = SqliteFunction_ConvertParams_m3B967FF80BD969603C902F1DF9EB2704FBD0357D(__this, L_12, (intptr_t)L_13, /*hidden argument*/NULL);
		AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755 * L_15 = V_1;
		NullCheck(L_15);
		int32_t L_16 = L_15->get__count_0();
		AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755 * L_17 = V_1;
		NullCheck(L_17);
		RuntimeObject ** L_18 = L_17->get_address_of__data_1();
		VirtActionInvoker3< ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A*, int32_t, RuntimeObject ** >::Invoke(6 /* System.Void Mono.Data.Sqlite.SqliteFunction::Step(System.Object[],System.Int32,System.Object&) */, __this, L_14, L_16, (RuntimeObject **)L_18);
		IL2CPP_LEAVE(0x6D, FINALLY_005e);
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_005e;
	}

FINALLY_005e:
	{ // begin finally (depth: 1)
		AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755 * L_19 = V_1;
		AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755 * L_20 = L_19;
		NullCheck(L_20);
		int32_t L_21 = L_20->get__count_0();
		NullCheck(L_20);
		L_20->set__count_0(((int32_t)il2cpp_codegen_add((int32_t)L_21, (int32_t)1)));
		IL2CPP_END_FINALLY(94)
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(94)
	{
		IL2CPP_JUMP_TBL(0x6D, IL_006d)
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
	}

IL_006d:
	{
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteFunction::FinalCallback(System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR void SqliteFunction_FinalCallback_m68052B0AE75F0054D840A7E7E42B3019A61F0322 (SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * __this, intptr_t ___context0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteFunction_FinalCallback_m68052B0AE75F0054D840A7E7E42B3019A61F0322_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int64_t V_0 = 0;
	RuntimeObject * V_1 = NULL;
	RuntimeObject* V_2 = NULL;
	{
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_0 = __this->get__base_0();
		intptr_t L_1 = ___context0;
		NullCheck(L_0);
		intptr_t L_2 = VirtFuncInvoker1< intptr_t, intptr_t >::Invoke(42 /* System.IntPtr Mono.Data.Sqlite.SQLiteBase::AggregateContext(System.IntPtr) */, L_0, (intptr_t)L_1);
		int64_t L_3 = IntPtr_op_Explicit_m254924E8680FCCF870F18064DC0B114445B09172((intptr_t)L_2, /*hidden argument*/NULL);
		V_0 = L_3;
		V_1 = NULL;
		Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 * L_4 = __this->get__contextDataList_1();
		int64_t L_5 = V_0;
		NullCheck(L_4);
		bool L_6 = Dictionary_2_ContainsKey_m425FDC14DB7C7CAA236D528A12C3DB3577AD0C96(L_4, L_5, /*hidden argument*/Dictionary_2_ContainsKey_m425FDC14DB7C7CAA236D528A12C3DB3577AD0C96_RuntimeMethod_var);
		if (!L_6)
		{
			goto IL_0044;
		}
	}
	{
		Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 * L_7 = __this->get__contextDataList_1();
		int64_t L_8 = V_0;
		NullCheck(L_7);
		AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755 * L_9 = Dictionary_2_get_Item_m1A6FE099B56685CD45A75254ABA787E313A5D792(L_7, L_8, /*hidden argument*/Dictionary_2_get_Item_m1A6FE099B56685CD45A75254ABA787E313A5D792_RuntimeMethod_var);
		NullCheck(L_9);
		RuntimeObject * L_10 = L_9->get__data_1();
		V_1 = L_10;
		Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 * L_11 = __this->get__contextDataList_1();
		int64_t L_12 = V_0;
		NullCheck(L_11);
		Dictionary_2_Remove_mFA8845405F1AE81B12E4078977BE667CCC962ECB(L_11, L_12, /*hidden argument*/Dictionary_2_Remove_mFA8845405F1AE81B12E4078977BE667CCC962ECB_RuntimeMethod_var);
	}

IL_0044:
	{
		intptr_t L_13 = ___context0;
		__this->set__context_7((intptr_t)L_13);
		intptr_t L_14 = ___context0;
		RuntimeObject * L_15 = V_1;
		RuntimeObject * L_16 = VirtFuncInvoker1< RuntimeObject *, RuntimeObject * >::Invoke(7 /* System.Object Mono.Data.Sqlite.SqliteFunction::Final(System.Object) */, __this, L_15);
		SqliteFunction_SetReturnValue_mD2B822ACF24A89AE1902E00A3AED96982254D5C5(__this, (intptr_t)L_14, L_16, /*hidden argument*/NULL);
		RuntimeObject * L_17 = V_1;
		V_2 = ((RuntimeObject*)IsInst((RuntimeObject*)L_17, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var));
		RuntimeObject* L_18 = V_2;
		if (!L_18)
		{
			goto IL_006c;
		}
	}
	{
		RuntimeObject* L_19 = V_2;
		NullCheck(L_19);
		InterfaceActionInvoker0::Invoke(0 /* System.Void System.IDisposable::Dispose() */, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var, L_19);
	}

IL_006c:
	{
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteFunction::Dispose(System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void SqliteFunction_Dispose_mAB16F5749E6C97AC3EED16355894CC849529D4F5 (SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * __this, bool ___disposing0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteFunction_Dispose_mAB16F5749E6C97AC3EED16355894CC849529D4F5_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	RuntimeObject* V_0 = NULL;
	KeyValuePair_2_t93C466ABB3C1789B9638D6DAE171650D781D5955  V_1;
	memset(&V_1, 0, sizeof(V_1));
	Enumerator_tC72BD0EE9002D5F9476F8E5D172DD8D523493303  V_2;
	memset(&V_2, 0, sizeof(V_2));
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	void* __leave_targets_storage = alloca(sizeof(int32_t) * 1);
	il2cpp::utils::LeaveTargetStack __leave_targets(__leave_targets_storage);
	NO_UNUSED_WARNING (__leave_targets);
	{
		bool L_0 = ___disposing0;
		if (!L_0)
		{
			goto IL_008f;
		}
	}
	{
		Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 * L_1 = __this->get__contextDataList_1();
		NullCheck(L_1);
		Enumerator_tC72BD0EE9002D5F9476F8E5D172DD8D523493303  L_2 = Dictionary_2_GetEnumerator_m24CA20639785613D0692E7B7813D7525CA3E3FCF(L_1, /*hidden argument*/Dictionary_2_GetEnumerator_m24CA20639785613D0692E7B7813D7525CA3E3FCF_RuntimeMethod_var);
		V_2 = L_2;
	}

IL_0012:
	try
	{ // begin try (depth: 1)
		{
			goto IL_003d;
		}

IL_0017:
		{
			KeyValuePair_2_t93C466ABB3C1789B9638D6DAE171650D781D5955  L_3 = Enumerator_get_Current_m48D218F99C929FE08EB673C9DC0B5A5FBDE5820F((Enumerator_tC72BD0EE9002D5F9476F8E5D172DD8D523493303 *)(&V_2), /*hidden argument*/Enumerator_get_Current_m48D218F99C929FE08EB673C9DC0B5A5FBDE5820F_RuntimeMethod_var);
			V_1 = L_3;
			AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755 * L_4 = KeyValuePair_2_get_Value_m37365A13759E8A8548BE04A755D69B74D6BBF2AB((KeyValuePair_2_t93C466ABB3C1789B9638D6DAE171650D781D5955 *)(&V_1), /*hidden argument*/KeyValuePair_2_get_Value_m37365A13759E8A8548BE04A755D69B74D6BBF2AB_RuntimeMethod_var);
			NullCheck(L_4);
			RuntimeObject * L_5 = L_4->get__data_1();
			V_0 = ((RuntimeObject*)IsInst((RuntimeObject*)L_5, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var));
			RuntimeObject* L_6 = V_0;
			if (!L_6)
			{
				goto IL_003d;
			}
		}

IL_0037:
		{
			RuntimeObject* L_7 = V_0;
			NullCheck(L_7);
			InterfaceActionInvoker0::Invoke(0 /* System.Void System.IDisposable::Dispose() */, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var, L_7);
		}

IL_003d:
		{
			bool L_8 = Enumerator_MoveNext_m37DC9F68F91CA42C4DF0800613544AFFE63A4076((Enumerator_tC72BD0EE9002D5F9476F8E5D172DD8D523493303 *)(&V_2), /*hidden argument*/Enumerator_MoveNext_m37DC9F68F91CA42C4DF0800613544AFFE63A4076_RuntimeMethod_var);
			if (L_8)
			{
				goto IL_0017;
			}
		}

IL_0049:
		{
			IL2CPP_LEAVE(0x5A, FINALLY_004e);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_004e;
	}

FINALLY_004e:
	{ // begin finally (depth: 1)
		Enumerator_tC72BD0EE9002D5F9476F8E5D172DD8D523493303  L_9 = V_2;
		Enumerator_tC72BD0EE9002D5F9476F8E5D172DD8D523493303  L_10 = L_9;
		RuntimeObject * L_11 = Box(Enumerator_tC72BD0EE9002D5F9476F8E5D172DD8D523493303_il2cpp_TypeInfo_var, &L_10);
		Enumerator_Dispose_m2B9B3D7D2D9369C06369FD5D7D9A75660ADF6A46((Enumerator_tC72BD0EE9002D5F9476F8E5D172DD8D523493303 *)UnBox(L_11, Enumerator_tC72BD0EE9002D5F9476F8E5D172DD8D523493303_il2cpp_TypeInfo_var), /*hidden argument*/Enumerator_Dispose_m2B9B3D7D2D9369C06369FD5D7D9A75660ADF6A46_RuntimeMethod_var);
		IL2CPP_END_FINALLY(78)
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(78)
	{
		IL2CPP_JUMP_TBL(0x5A, IL_005a)
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
	}

IL_005a:
	{
		Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 * L_12 = __this->get__contextDataList_1();
		NullCheck(L_12);
		Dictionary_2_Clear_m850B2AC5BADCAF602C38B462F787A0D00CD3D950(L_12, /*hidden argument*/Dictionary_2_Clear_m850B2AC5BADCAF602C38B462F787A0D00CD3D950_RuntimeMethod_var);
		__this->set__InvokeFunc_2((SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22 *)NULL);
		__this->set__StepFunc_3((SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22 *)NULL);
		__this->set__FinalFunc_4((SQLiteFinalCallback_tDADE001E38D3B50F9259C9D956A11D3B4D875453 *)NULL);
		__this->set__CompareFunc_5((SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B *)NULL);
		__this->set__base_0((SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 *)NULL);
		__this->set__contextDataList_1((Dictionary_2_t25A4BDB3DBE4AC5313851F9DA72493859AE10BA3 *)NULL);
	}

IL_008f:
	{
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteFunction::Dispose()
extern "C" IL2CPP_METHOD_ATTR void SqliteFunction_Dispose_m468964898359396F9D4DF4F6107F339AB421DB7D (SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * __this, const RuntimeMethod* method)
{
	{
		VirtActionInvoker1< bool >::Invoke(9 /* System.Void Mono.Data.Sqlite.SqliteFunction::Dispose(System.Boolean) */, __this, (bool)1);
		return;
	}
}
// Mono.Data.Sqlite.SqliteFunction[] Mono.Data.Sqlite.SqliteFunction::BindFunctions(Mono.Data.Sqlite.SQLiteBase)
extern "C" IL2CPP_METHOD_ATTR SqliteFunctionU5BU5D_t8AFADE2E07F0DC165BCF00EA921B1DB88D1A160F* SqliteFunction_BindFunctions_m8CF5514376BCBB914639517136181467868E3238 (SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * ___sqlbase0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteFunction_BindFunctions_m8CF5514376BCBB914639517136181467868E3238_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * V_0 = NULL;
	List_1_tC332B4E87767ADFB1672A499D53D94AE897CD4A3 * V_1 = NULL;
	SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD * V_2 = NULL;
	Enumerator_tB5FE7F21928FA8D45CBB7BD3D57A481548319510  V_3;
	memset(&V_3, 0, sizeof(V_3));
	SqliteFunctionU5BU5D_t8AFADE2E07F0DC165BCF00EA921B1DB88D1A160F* V_4 = NULL;
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	void* __leave_targets_storage = alloca(sizeof(int32_t) * 1);
	il2cpp::utils::LeaveTargetStack __leave_targets(__leave_targets_storage);
	NO_UNUSED_WARNING (__leave_targets);
	SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * G_B4_0 = NULL;
	SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * G_B3_0 = NULL;
	SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22 * G_B5_0 = NULL;
	SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * G_B5_1 = NULL;
	SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * G_B7_0 = NULL;
	SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * G_B6_0 = NULL;
	SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22 * G_B8_0 = NULL;
	SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * G_B8_1 = NULL;
	SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * G_B10_0 = NULL;
	SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * G_B9_0 = NULL;
	SQLiteFinalCallback_tDADE001E38D3B50F9259C9D956A11D3B4D875453 * G_B11_0 = NULL;
	SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * G_B11_1 = NULL;
	SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * G_B13_0 = NULL;
	SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * G_B12_0 = NULL;
	SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B * G_B14_0 = NULL;
	SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * G_B14_1 = NULL;
	SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * G_B16_0 = NULL;
	SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * G_B15_0 = NULL;
	SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B * G_B17_0 = NULL;
	SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * G_B17_1 = NULL;
	{
		List_1_tC332B4E87767ADFB1672A499D53D94AE897CD4A3 * L_0 = (List_1_tC332B4E87767ADFB1672A499D53D94AE897CD4A3 *)il2cpp_codegen_object_new(List_1_tC332B4E87767ADFB1672A499D53D94AE897CD4A3_il2cpp_TypeInfo_var);
		List_1__ctor_m0CAC003C972BC97F57D0BBC18BCF1BD28F6F18B3(L_0, /*hidden argument*/List_1__ctor_m0CAC003C972BC97F57D0BBC18BCF1BD28F6F18B3_RuntimeMethod_var);
		V_1 = L_0;
		IL2CPP_RUNTIME_CLASS_INIT(SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B_il2cpp_TypeInfo_var);
		List_1_t575BD1306846C6646814C99C87872FD64E8954AB * L_1 = ((SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B_StaticFields*)il2cpp_codegen_static_fields_for(SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B_il2cpp_TypeInfo_var))->get__registeredFunctions_8();
		NullCheck(L_1);
		Enumerator_tB5FE7F21928FA8D45CBB7BD3D57A481548319510  L_2 = List_1_GetEnumerator_m92C59AC36F29D46CF1B7938CDC2C2241FC24907E(L_1, /*hidden argument*/List_1_GetEnumerator_m92C59AC36F29D46CF1B7938CDC2C2241FC24907E_RuntimeMethod_var);
		V_3 = L_2;
	}

IL_0011:
	try
	{ // begin try (depth: 1)
		{
			goto IL_0146;
		}

IL_0016:
		{
			SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD * L_3 = Enumerator_get_Current_m7FA4FE3198E9A2BC1613C4C7107826F8FF14C1A3((Enumerator_tB5FE7F21928FA8D45CBB7BD3D57A481548319510 *)(&V_3), /*hidden argument*/Enumerator_get_Current_m7FA4FE3198E9A2BC1613C4C7107826F8FF14C1A3_RuntimeMethod_var);
			V_2 = L_3;
			SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD * L_4 = V_2;
			NullCheck(L_4);
			Type_t * L_5 = L_4->get__instanceType_3();
			RuntimeObject * L_6 = Activator_CreateInstance_mD06EE47879F606317C6DA91FB63E678CABAC6A16(L_5, /*hidden argument*/NULL);
			V_0 = ((SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B *)CastclassClass((RuntimeObject*)L_6, SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B_il2cpp_TypeInfo_var));
			SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * L_7 = V_0;
			SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_8 = ___sqlbase0;
			NullCheck(L_7);
			L_7->set__base_0(L_8);
			SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * L_9 = V_0;
			SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD * L_10 = V_2;
			NullCheck(L_10);
			int32_t L_11 = SqliteFunctionAttribute_get_FuncType_m76454A5884A9DE9ACDABE2933B31A24B55CAC0E8(L_10, /*hidden argument*/NULL);
			G_B3_0 = L_9;
			if (L_11)
			{
				G_B4_0 = L_9;
				goto IL_0053;
			}
		}

IL_0042:
		{
			SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * L_12 = V_0;
			SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22 * L_13 = (SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22 *)il2cpp_codegen_object_new(SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22_il2cpp_TypeInfo_var);
			SQLiteCallback__ctor_m01987E2713E968B8AA6EB91D9087D47FF08F870F(L_13, L_12, (intptr_t)((intptr_t)SqliteFunction_ScalarCallback_m3D05C042753B243F0AC40FC6C01A4D34E9897D44_RuntimeMethod_var), /*hidden argument*/NULL);
			G_B5_0 = L_13;
			G_B5_1 = G_B3_0;
			goto IL_0054;
		}

IL_0053:
		{
			G_B5_0 = ((SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22 *)(NULL));
			G_B5_1 = G_B4_0;
		}

IL_0054:
		{
			NullCheck(G_B5_1);
			G_B5_1->set__InvokeFunc_2(G_B5_0);
			SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * L_14 = V_0;
			SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD * L_15 = V_2;
			NullCheck(L_15);
			int32_t L_16 = SqliteFunctionAttribute_get_FuncType_m76454A5884A9DE9ACDABE2933B31A24B55CAC0E8(L_15, /*hidden argument*/NULL);
			G_B6_0 = L_14;
			if ((!(((uint32_t)L_16) == ((uint32_t)1))))
			{
				G_B7_0 = L_14;
				goto IL_0077;
			}
		}

IL_0066:
		{
			SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * L_17 = V_0;
			SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22 * L_18 = (SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22 *)il2cpp_codegen_object_new(SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22_il2cpp_TypeInfo_var);
			SQLiteCallback__ctor_m01987E2713E968B8AA6EB91D9087D47FF08F870F(L_18, L_17, (intptr_t)((intptr_t)SqliteFunction_StepCallback_m4CCDD48061DE3BF6A14CEDCF099829179E4F1878_RuntimeMethod_var), /*hidden argument*/NULL);
			G_B8_0 = L_18;
			G_B8_1 = G_B6_0;
			goto IL_0078;
		}

IL_0077:
		{
			G_B8_0 = ((SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22 *)(NULL));
			G_B8_1 = G_B7_0;
		}

IL_0078:
		{
			NullCheck(G_B8_1);
			G_B8_1->set__StepFunc_3(G_B8_0);
			SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * L_19 = V_0;
			SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD * L_20 = V_2;
			NullCheck(L_20);
			int32_t L_21 = SqliteFunctionAttribute_get_FuncType_m76454A5884A9DE9ACDABE2933B31A24B55CAC0E8(L_20, /*hidden argument*/NULL);
			G_B9_0 = L_19;
			if ((!(((uint32_t)L_21) == ((uint32_t)1))))
			{
				G_B10_0 = L_19;
				goto IL_009b;
			}
		}

IL_008a:
		{
			SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * L_22 = V_0;
			SQLiteFinalCallback_tDADE001E38D3B50F9259C9D956A11D3B4D875453 * L_23 = (SQLiteFinalCallback_tDADE001E38D3B50F9259C9D956A11D3B4D875453 *)il2cpp_codegen_object_new(SQLiteFinalCallback_tDADE001E38D3B50F9259C9D956A11D3B4D875453_il2cpp_TypeInfo_var);
			SQLiteFinalCallback__ctor_m7D2143264323FCB90438120888189D043A4133AF(L_23, L_22, (intptr_t)((intptr_t)SqliteFunction_FinalCallback_m68052B0AE75F0054D840A7E7E42B3019A61F0322_RuntimeMethod_var), /*hidden argument*/NULL);
			G_B11_0 = L_23;
			G_B11_1 = G_B9_0;
			goto IL_009c;
		}

IL_009b:
		{
			G_B11_0 = ((SQLiteFinalCallback_tDADE001E38D3B50F9259C9D956A11D3B4D875453 *)(NULL));
			G_B11_1 = G_B10_0;
		}

IL_009c:
		{
			NullCheck(G_B11_1);
			G_B11_1->set__FinalFunc_4(G_B11_0);
			SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * L_24 = V_0;
			SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD * L_25 = V_2;
			NullCheck(L_25);
			int32_t L_26 = SqliteFunctionAttribute_get_FuncType_m76454A5884A9DE9ACDABE2933B31A24B55CAC0E8(L_25, /*hidden argument*/NULL);
			G_B12_0 = L_24;
			if ((!(((uint32_t)L_26) == ((uint32_t)2))))
			{
				G_B13_0 = L_24;
				goto IL_00bf;
			}
		}

IL_00ae:
		{
			SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * L_27 = V_0;
			SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B * L_28 = (SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B *)il2cpp_codegen_object_new(SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B_il2cpp_TypeInfo_var);
			SQLiteCollation__ctor_m2DC974FD27FD29ADFCC89CDF0BA7869142C08639(L_28, L_27, (intptr_t)((intptr_t)SqliteFunction_CompareCallback_mBE735C82605FEF47F8B6E78E3CF04130049CA95D_RuntimeMethod_var), /*hidden argument*/NULL);
			G_B14_0 = L_28;
			G_B14_1 = G_B12_0;
			goto IL_00c0;
		}

IL_00bf:
		{
			G_B14_0 = ((SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B *)(NULL));
			G_B14_1 = G_B13_0;
		}

IL_00c0:
		{
			NullCheck(G_B14_1);
			G_B14_1->set__CompareFunc_5(G_B14_0);
			SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * L_29 = V_0;
			SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD * L_30 = V_2;
			NullCheck(L_30);
			int32_t L_31 = SqliteFunctionAttribute_get_FuncType_m76454A5884A9DE9ACDABE2933B31A24B55CAC0E8(L_30, /*hidden argument*/NULL);
			G_B15_0 = L_29;
			if ((!(((uint32_t)L_31) == ((uint32_t)2))))
			{
				G_B16_0 = L_29;
				goto IL_00e3;
			}
		}

IL_00d2:
		{
			SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * L_32 = V_0;
			SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B * L_33 = (SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B *)il2cpp_codegen_object_new(SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B_il2cpp_TypeInfo_var);
			SQLiteCollation__ctor_m2DC974FD27FD29ADFCC89CDF0BA7869142C08639(L_33, L_32, (intptr_t)((intptr_t)SqliteFunction_CompareCallback16_mD310867D85DB029BC1E7E2F48CD1210BD70A9162_RuntimeMethod_var), /*hidden argument*/NULL);
			G_B17_0 = L_33;
			G_B17_1 = G_B15_0;
			goto IL_00e4;
		}

IL_00e3:
		{
			G_B17_0 = ((SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B *)(NULL));
			G_B17_1 = G_B16_0;
		}

IL_00e4:
		{
			NullCheck(G_B17_1);
			G_B17_1->set__CompareFunc16_6(G_B17_0);
			SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD * L_34 = V_2;
			NullCheck(L_34);
			int32_t L_35 = SqliteFunctionAttribute_get_FuncType_m76454A5884A9DE9ACDABE2933B31A24B55CAC0E8(L_34, /*hidden argument*/NULL);
			if ((((int32_t)L_35) == ((int32_t)2)))
			{
				goto IL_0127;
			}
		}

IL_00f5:
		{
			SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_36 = ___sqlbase0;
			SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD * L_37 = V_2;
			NullCheck(L_37);
			String_t* L_38 = SqliteFunctionAttribute_get_Name_mB76AE39FB2090190D34E5D4034C8AEECF5E97A69(L_37, /*hidden argument*/NULL);
			SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD * L_39 = V_2;
			NullCheck(L_39);
			int32_t L_40 = SqliteFunctionAttribute_get_Arguments_m9F8733EEEDC8E195831DED64B65822EA1684EE70(L_39, /*hidden argument*/NULL);
			SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * L_41 = V_0;
			SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * L_42 = V_0;
			NullCheck(L_42);
			SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22 * L_43 = L_42->get__InvokeFunc_2();
			SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * L_44 = V_0;
			NullCheck(L_44);
			SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22 * L_45 = L_44->get__StepFunc_3();
			SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * L_46 = V_0;
			NullCheck(L_46);
			SQLiteFinalCallback_tDADE001E38D3B50F9259C9D956A11D3B4D875453 * L_47 = L_46->get__FinalFunc_4();
			NullCheck(L_36);
			VirtActionInvoker6< String_t*, int32_t, bool, SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22 *, SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22 *, SQLiteFinalCallback_tDADE001E38D3B50F9259C9D956A11D3B4D875453 * >::Invoke(41 /* System.Void Mono.Data.Sqlite.SQLiteBase::CreateFunction(System.String,System.Int32,System.Boolean,Mono.Data.Sqlite.SQLiteCallback,Mono.Data.Sqlite.SQLiteCallback,Mono.Data.Sqlite.SQLiteFinalCallback) */, L_36, L_38, L_40, (bool)((!(((RuntimeObject*)(SqliteFunctionEx_t7D4B1395222C65E48CBA8BF483FEAEEA24FFC75A *)((SqliteFunctionEx_t7D4B1395222C65E48CBA8BF483FEAEEA24FFC75A *)IsInstClass((RuntimeObject*)L_41, SqliteFunctionEx_t7D4B1395222C65E48CBA8BF483FEAEEA24FFC75A_il2cpp_TypeInfo_var))) <= ((RuntimeObject*)(RuntimeObject *)NULL)))? 1 : 0), L_43, L_45, L_47);
			goto IL_013f;
		}

IL_0127:
		{
			SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_48 = ___sqlbase0;
			SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD * L_49 = V_2;
			NullCheck(L_49);
			String_t* L_50 = SqliteFunctionAttribute_get_Name_mB76AE39FB2090190D34E5D4034C8AEECF5E97A69(L_49, /*hidden argument*/NULL);
			SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * L_51 = V_0;
			NullCheck(L_51);
			SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B * L_52 = L_51->get__CompareFunc_5();
			SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * L_53 = V_0;
			NullCheck(L_53);
			SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B * L_54 = L_53->get__CompareFunc16_6();
			NullCheck(L_48);
			VirtActionInvoker3< String_t*, SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B *, SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B * >::Invoke(40 /* System.Void Mono.Data.Sqlite.SQLiteBase::CreateCollation(System.String,Mono.Data.Sqlite.SQLiteCollation,Mono.Data.Sqlite.SQLiteCollation) */, L_48, L_50, L_52, L_54);
		}

IL_013f:
		{
			List_1_tC332B4E87767ADFB1672A499D53D94AE897CD4A3 * L_55 = V_1;
			SqliteFunction_tFD6A09FDD5DA321D51C5F7B83D7FD3078FCB104B * L_56 = V_0;
			NullCheck(L_55);
			List_1_Add_m2E293E26CF280C896A634CC8D9DD5E622583050F(L_55, L_56, /*hidden argument*/List_1_Add_m2E293E26CF280C896A634CC8D9DD5E622583050F_RuntimeMethod_var);
		}

IL_0146:
		{
			bool L_57 = Enumerator_MoveNext_mF5DE5F7301F752CEF6FC1274061C972E315C5018((Enumerator_tB5FE7F21928FA8D45CBB7BD3D57A481548319510 *)(&V_3), /*hidden argument*/Enumerator_MoveNext_mF5DE5F7301F752CEF6FC1274061C972E315C5018_RuntimeMethod_var);
			if (L_57)
			{
				goto IL_0016;
			}
		}

IL_0152:
		{
			IL2CPP_LEAVE(0x163, FINALLY_0157);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_0157;
	}

FINALLY_0157:
	{ // begin finally (depth: 1)
		Enumerator_tB5FE7F21928FA8D45CBB7BD3D57A481548319510  L_58 = V_3;
		Enumerator_tB5FE7F21928FA8D45CBB7BD3D57A481548319510  L_59 = L_58;
		RuntimeObject * L_60 = Box(Enumerator_tB5FE7F21928FA8D45CBB7BD3D57A481548319510_il2cpp_TypeInfo_var, &L_59);
		Enumerator_Dispose_mA0BB472958EA47C65935F98FBEF0EAACFEACCE0D((Enumerator_tB5FE7F21928FA8D45CBB7BD3D57A481548319510 *)UnBox(L_60, Enumerator_tB5FE7F21928FA8D45CBB7BD3D57A481548319510_il2cpp_TypeInfo_var), /*hidden argument*/Enumerator_Dispose_mA0BB472958EA47C65935F98FBEF0EAACFEACCE0D_RuntimeMethod_var);
		IL2CPP_END_FINALLY(343)
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(343)
	{
		IL2CPP_JUMP_TBL(0x163, IL_0163)
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
	}

IL_0163:
	{
		List_1_tC332B4E87767ADFB1672A499D53D94AE897CD4A3 * L_61 = V_1;
		NullCheck(L_61);
		int32_t L_62 = List_1_get_Count_m368529D7DE6BD7EBBA3E9FA3551350AFB4384EF8(L_61, /*hidden argument*/List_1_get_Count_m368529D7DE6BD7EBBA3E9FA3551350AFB4384EF8_RuntimeMethod_var);
		SqliteFunctionU5BU5D_t8AFADE2E07F0DC165BCF00EA921B1DB88D1A160F* L_63 = (SqliteFunctionU5BU5D_t8AFADE2E07F0DC165BCF00EA921B1DB88D1A160F*)SZArrayNew(SqliteFunctionU5BU5D_t8AFADE2E07F0DC165BCF00EA921B1DB88D1A160F_il2cpp_TypeInfo_var, (uint32_t)L_62);
		V_4 = L_63;
		List_1_tC332B4E87767ADFB1672A499D53D94AE897CD4A3 * L_64 = V_1;
		SqliteFunctionU5BU5D_t8AFADE2E07F0DC165BCF00EA921B1DB88D1A160F* L_65 = V_4;
		NullCheck(L_64);
		List_1_CopyTo_m95F1898958F30634E03CFF8A0CDC2F863259B2F4(L_64, L_65, 0, /*hidden argument*/List_1_CopyTo_m95F1898958F30634E03CFF8A0CDC2F863259B2F4_RuntimeMethod_var);
		SqliteFunctionU5BU5D_t8AFADE2E07F0DC165BCF00EA921B1DB88D1A160F* L_66 = V_4;
		return L_66;
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
// System.Void Mono.Data.Sqlite.SqliteFunction_AggregateData::.ctor()
extern "C" IL2CPP_METHOD_ATTR void AggregateData__ctor_mD2DE3A53E4BAED4BB352B499ED040C24824FD6B3 (AggregateData_tFFE2516CCD63C95431946BC11AA3907DF2F16755 * __this, const RuntimeMethod* method)
{
	{
		__this->set__count_0(1);
		Object__ctor_m925ECA5E85CA100E3FB86A4F9E15C120E9A184C0(__this, /*hidden argument*/NULL);
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
// System.String Mono.Data.Sqlite.SqliteFunctionAttribute::get_Name()
extern "C" IL2CPP_METHOD_ATTR String_t* SqliteFunctionAttribute_get_Name_mB76AE39FB2090190D34E5D4034C8AEECF5E97A69 (SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD * __this, const RuntimeMethod* method)
{
	{
		String_t* L_0 = __this->get__name_0();
		return L_0;
	}
}
// System.Int32 Mono.Data.Sqlite.SqliteFunctionAttribute::get_Arguments()
extern "C" IL2CPP_METHOD_ATTR int32_t SqliteFunctionAttribute_get_Arguments_m9F8733EEEDC8E195831DED64B65822EA1684EE70 (SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD * __this, const RuntimeMethod* method)
{
	{
		int32_t L_0 = __this->get__arguments_1();
		return L_0;
	}
}
// Mono.Data.Sqlite.FunctionType Mono.Data.Sqlite.SqliteFunctionAttribute::get_FuncType()
extern "C" IL2CPP_METHOD_ATTR int32_t SqliteFunctionAttribute_get_FuncType_m76454A5884A9DE9ACDABE2933B31A24B55CAC0E8 (SqliteFunctionAttribute_tFD557033F4837262FE7FA08336BA3FB3A9A51DCD * __this, const RuntimeMethod* method)
{
	{
		int32_t L_0 = __this->get__functionType_2();
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
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void Mono.Data.Sqlite.SqliteKeyReader::.ctor(Mono.Data.Sqlite.SqliteConnection,Mono.Data.Sqlite.SqliteDataReader,Mono.Data.Sqlite.SqliteStatement)
extern "C" IL2CPP_METHOD_ATTR void SqliteKeyReader__ctor_m3264CB39D870C5E959D0D0C103B31EF2FDAA4AC2 (SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793 * __this, SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * ___cnn0, SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * ___reader1, SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * ___stmt2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteKeyReader__ctor_m3264CB39D870C5E959D0D0C103B31EF2FDAA4AC2_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB * V_0 = NULL;
	Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF * V_1 = NULL;
	List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * V_2 = NULL;
	List_1_tD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD * V_3 = NULL;
	DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * V_4 = NULL;
	DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * V_5 = NULL;
	RuntimeObject* V_6 = NULL;
	DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * V_7 = NULL;
	DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * V_8 = NULL;
	RuntimeObject* V_9 = NULL;
	String_t* V_10 = NULL;
	String_t* V_11 = NULL;
	KeyValuePair_2_t9E20856DB65BAC258C27F3C359C8A86E2DCEEBBD  V_12;
	memset(&V_12, 0, sizeof(V_12));
	Enumerator_t38C41296850665F3643D772F9790D4B3880BD9AA  V_13;
	memset(&V_13, 0, sizeof(V_13));
	int32_t V_14 = 0;
	String_t* V_15 = NULL;
	DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * V_16 = NULL;
	DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * V_17 = NULL;
	int32_t V_18 = 0;
	DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * V_19 = NULL;
	RuntimeObject* V_20 = NULL;
	DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * V_21 = NULL;
	int32_t V_22 = 0;
	int32_t V_23 = 0;
	int32_t V_24 = 0;
	DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * V_25 = NULL;
	KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * V_26 = NULL;
	List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * V_27 = NULL;
	int32_t V_28 = 0;
	bool V_29 = false;
	DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * V_30 = NULL;
	RuntimeObject* V_31 = NULL;
	StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* V_32 = NULL;
	int32_t V_33 = 0;
	String_t* V_34 = NULL;
	KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC  V_35;
	memset(&V_35, 0, sizeof(V_35));
	RuntimeObject* V_36 = NULL;
	RuntimeObject* V_37 = NULL;
	RuntimeObject* V_38 = NULL;
	RuntimeObject* V_39 = NULL;
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	void* __leave_targets_storage = alloca(sizeof(int32_t) * 10);
	il2cpp::utils::LeaveTargetStack __leave_targets(__leave_targets_storage);
	NO_UNUSED_WARNING (__leave_targets);
	{
		Object__ctor_m925ECA5E85CA100E3FB86A4F9E15C120E9A184C0(__this, /*hidden argument*/NULL);
		Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB * L_0 = (Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB *)il2cpp_codegen_object_new(Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB_il2cpp_TypeInfo_var);
		Dictionary_2__ctor_m20A5B6C6950ACF998FE28F7FACEA19C755593E62(L_0, /*hidden argument*/Dictionary_2__ctor_m20A5B6C6950ACF998FE28F7FACEA19C755593E62_RuntimeMethod_var);
		V_0 = L_0;
		Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF * L_1 = (Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF *)il2cpp_codegen_object_new(Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF_il2cpp_TypeInfo_var);
		Dictionary_2__ctor_mEAAF465A79EE99997A8CF0556CEC5334BCE44EF2(L_1, /*hidden argument*/Dictionary_2__ctor_mEAAF465A79EE99997A8CF0556CEC5334BCE44EF2_RuntimeMethod_var);
		V_1 = L_1;
		List_1_tD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD * L_2 = (List_1_tD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD *)il2cpp_codegen_object_new(List_1_tD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD_il2cpp_TypeInfo_var);
		List_1__ctor_m7E6858F17402F616F6E74BB4E9C06624018F6BFE(L_2, /*hidden argument*/List_1__ctor_m7E6858F17402F616F6E74BB4E9C06624018F6BFE_RuntimeMethod_var);
		V_3 = L_2;
		SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * L_3 = ___stmt2;
		__this->set__stmt_1(L_3);
		SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * L_4 = ___cnn0;
		NullCheck(L_4);
		DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_5 = SqliteConnection_GetSchema_mCF5A4BDF8CA03884BF3739EA8152C5C11D47A20A(L_4, _stringLiteralD99C226D02CB06DF9C4F96D0E0140B91C9B8F41F, /*hidden argument*/NULL);
		V_4 = L_5;
	}

IL_002c:
	try
	{ // begin try (depth: 1)
		{
			DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_6 = V_4;
			NullCheck(L_6);
			DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0 * L_7 = DataTable_get_Rows_m905B0636C268095F62E08B89B97A034E6BC483D3(L_6, /*hidden argument*/NULL);
			NullCheck(L_7);
			RuntimeObject* L_8 = VirtFuncInvoker0< RuntimeObject* >::Invoke(11 /* System.Collections.IEnumerator System.Data.InternalDataCollectionBase::GetEnumerator() */, L_7);
			V_6 = L_8;
		}

IL_003a:
		try
		{ // begin try (depth: 2)
			{
				goto IL_0075;
			}

IL_003f:
			{
				RuntimeObject* L_9 = V_6;
				NullCheck(L_9);
				RuntimeObject * L_10 = InterfaceFuncInvoker0< RuntimeObject * >::Invoke(1 /* System.Object System.Collections.IEnumerator::get_Current() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_9);
				V_5 = ((DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B *)CastclassClass((RuntimeObject*)L_10, DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B_il2cpp_TypeInfo_var));
				Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB * L_11 = V_0;
				DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_12 = V_5;
				NullCheck(L_12);
				RuntimeObject * L_13 = DataRow_get_Item_mECAC0A4B3584FB64E6A6AE1E6EAE91B7E9B11C89(L_12, _stringLiteral58F69C9012CFB997F9D3FFE4F607D66F6E932A1F, /*hidden argument*/NULL);
				DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_14 = V_5;
				NullCheck(L_14);
				RuntimeObject * L_15 = DataRow_get_Item_mECAC0A4B3584FB64E6A6AE1E6EAE91B7E9B11C89(L_14, _stringLiteral89F89C02CF47E091E726A4E07B88AF0966806897, /*hidden argument*/NULL);
				IL2CPP_RUNTIME_CLASS_INIT(Convert_t1C7A851BFB2F0782FD7F72F6AA1DCBB7B53A9C7E_il2cpp_TypeInfo_var);
				int32_t L_16 = Convert_ToInt32_mCF1152AF4138C1DD7A16643B22EE69A38373EF86(L_15, /*hidden argument*/NULL);
				NullCheck(L_11);
				Dictionary_2_Add_m5453726952CE3720733822DBF38A0091037F0F76(L_11, ((String_t*)CastclassSealed((RuntimeObject*)L_13, String_t_il2cpp_TypeInfo_var)), L_16, /*hidden argument*/Dictionary_2_Add_m5453726952CE3720733822DBF38A0091037F0F76_RuntimeMethod_var);
			}

IL_0075:
			{
				RuntimeObject* L_17 = V_6;
				NullCheck(L_17);
				bool L_18 = InterfaceFuncInvoker0< bool >::Invoke(0 /* System.Boolean System.Collections.IEnumerator::MoveNext() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_17);
				if (L_18)
				{
					goto IL_003f;
				}
			}

IL_0081:
			{
				IL2CPP_LEAVE(0x9C, FINALLY_0086);
			}
		} // end try (depth: 2)
		catch(Il2CppExceptionWrapper& e)
		{
			__last_unhandled_exception = (Exception_t *)e.ex;
			goto FINALLY_0086;
		}

FINALLY_0086:
		{ // begin finally (depth: 2)
			{
				RuntimeObject* L_19 = V_6;
				V_36 = ((RuntimeObject*)IsInst((RuntimeObject*)L_19, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var));
				RuntimeObject* L_20 = V_36;
				if (L_20)
				{
					goto IL_0094;
				}
			}

IL_0093:
			{
				IL2CPP_END_FINALLY(134)
			}

IL_0094:
			{
				RuntimeObject* L_21 = V_36;
				NullCheck(L_21);
				InterfaceActionInvoker0::Invoke(0 /* System.Void System.IDisposable::Dispose() */, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var, L_21);
				IL2CPP_END_FINALLY(134)
			}
		} // end finally (depth: 2)
		IL2CPP_CLEANUP(134)
		{
			IL2CPP_JUMP_TBL(0x9C, IL_009c)
			IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
		}

IL_009c:
		{
			IL2CPP_LEAVE(0xB0, FINALLY_00a1);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_00a1;
	}

FINALLY_00a1:
	{ // begin finally (depth: 1)
		{
			DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_22 = V_4;
			if (!L_22)
			{
				goto IL_00af;
			}
		}

IL_00a8:
		{
			DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_23 = V_4;
			NullCheck(L_23);
			InterfaceActionInvoker0::Invoke(0 /* System.Void System.IDisposable::Dispose() */, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var, L_23);
		}

IL_00af:
		{
			IL2CPP_END_FINALLY(161)
		}
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(161)
	{
		IL2CPP_JUMP_TBL(0xB0, IL_00b0)
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
	}

IL_00b0:
	{
		SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * L_24 = ___reader1;
		NullCheck(L_24);
		DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_25 = SqliteDataReader_GetSchemaTable_m5F91D4DA3EB1F87D6308258D2513A1DF32B3EB0F(L_24, (bool)0, (bool)0, /*hidden argument*/NULL);
		V_7 = L_25;
	}

IL_00ba:
	try
	{ // begin try (depth: 1)
		{
			DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_26 = V_7;
			NullCheck(L_26);
			DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0 * L_27 = DataTable_get_Rows_m905B0636C268095F62E08B89B97A034E6BC483D3(L_26, /*hidden argument*/NULL);
			NullCheck(L_27);
			RuntimeObject* L_28 = VirtFuncInvoker0< RuntimeObject* >::Invoke(11 /* System.Collections.IEnumerator System.Data.InternalDataCollectionBase::GetEnumerator() */, L_27);
			V_9 = L_28;
		}

IL_00c8:
		try
		{ // begin try (depth: 2)
			{
				goto IL_015b;
			}

IL_00cd:
			{
				RuntimeObject* L_29 = V_9;
				NullCheck(L_29);
				RuntimeObject * L_30 = InterfaceFuncInvoker0< RuntimeObject * >::Invoke(1 /* System.Object System.Collections.IEnumerator::get_Current() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_29);
				V_8 = ((DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B *)CastclassClass((RuntimeObject*)L_30, DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B_il2cpp_TypeInfo_var));
				DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_31 = V_8;
				IL2CPP_RUNTIME_CLASS_INIT(SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_il2cpp_TypeInfo_var);
				String_t* L_32 = ((SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_il2cpp_TypeInfo_var))->get_BaseCatalogName_6();
				NullCheck(L_31);
				RuntimeObject * L_33 = DataRow_get_Item_mECAC0A4B3584FB64E6A6AE1E6EAE91B7E9B11C89(L_31, L_32, /*hidden argument*/NULL);
				IL2CPP_RUNTIME_CLASS_INIT(DBNull_t7400E04939C2C29699B389B106997892BF53A8E5_il2cpp_TypeInfo_var);
				DBNull_t7400E04939C2C29699B389B106997892BF53A8E5 * L_34 = ((DBNull_t7400E04939C2C29699B389B106997892BF53A8E5_StaticFields*)il2cpp_codegen_static_fields_for(DBNull_t7400E04939C2C29699B389B106997892BF53A8E5_il2cpp_TypeInfo_var))->get_Value_0();
				if ((!(((RuntimeObject*)(RuntimeObject *)L_33) == ((RuntimeObject*)(DBNull_t7400E04939C2C29699B389B106997892BF53A8E5 *)L_34))))
				{
					goto IL_00f6;
				}
			}

IL_00f1:
			{
				goto IL_015b;
			}

IL_00f6:
			{
				DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_35 = V_8;
				IL2CPP_RUNTIME_CLASS_INIT(SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_il2cpp_TypeInfo_var);
				String_t* L_36 = ((SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_il2cpp_TypeInfo_var))->get_BaseCatalogName_6();
				NullCheck(L_35);
				RuntimeObject * L_37 = DataRow_get_Item_mECAC0A4B3584FB64E6A6AE1E6EAE91B7E9B11C89(L_35, L_36, /*hidden argument*/NULL);
				V_10 = ((String_t*)CastclassSealed((RuntimeObject*)L_37, String_t_il2cpp_TypeInfo_var));
				DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_38 = V_8;
				IL2CPP_RUNTIME_CLASS_INIT(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_il2cpp_TypeInfo_var);
				String_t* L_39 = ((SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_il2cpp_TypeInfo_var))->get_BaseTableName_15();
				NullCheck(L_38);
				RuntimeObject * L_40 = DataRow_get_Item_mECAC0A4B3584FB64E6A6AE1E6EAE91B7E9B11C89(L_38, L_39, /*hidden argument*/NULL);
				V_11 = ((String_t*)CastclassSealed((RuntimeObject*)L_40, String_t_il2cpp_TypeInfo_var));
				Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF * L_41 = V_1;
				String_t* L_42 = V_10;
				NullCheck(L_41);
				bool L_43 = Dictionary_2_ContainsKey_m81AE5386AFCDA3805EA9ADCC78F00C3EF903428A(L_41, L_42, /*hidden argument*/Dictionary_2_ContainsKey_m81AE5386AFCDA3805EA9ADCC78F00C3EF903428A_RuntimeMethod_var);
				if (L_43)
				{
					goto IL_013d;
				}
			}

IL_0129:
			{
				List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * L_44 = (List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 *)il2cpp_codegen_object_new(List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3_il2cpp_TypeInfo_var);
				List_1__ctor_mDA22758D73530683C950C5CCF39BDB4E7E1F3F06(L_44, /*hidden argument*/List_1__ctor_mDA22758D73530683C950C5CCF39BDB4E7E1F3F06_RuntimeMethod_var);
				V_2 = L_44;
				Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF * L_45 = V_1;
				String_t* L_46 = V_10;
				List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * L_47 = V_2;
				NullCheck(L_45);
				Dictionary_2_Add_m77DD1AAE607EDC7C550C45F4AC4FC935DF0380CC(L_45, L_46, L_47, /*hidden argument*/Dictionary_2_Add_m77DD1AAE607EDC7C550C45F4AC4FC935DF0380CC_RuntimeMethod_var);
				goto IL_0146;
			}

IL_013d:
			{
				Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF * L_48 = V_1;
				String_t* L_49 = V_10;
				NullCheck(L_48);
				List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * L_50 = Dictionary_2_get_Item_m1F9B397B583526C8C45854B8B60A308A2227F889(L_48, L_49, /*hidden argument*/Dictionary_2_get_Item_m1F9B397B583526C8C45854B8B60A308A2227F889_RuntimeMethod_var);
				V_2 = L_50;
			}

IL_0146:
			{
				List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * L_51 = V_2;
				String_t* L_52 = V_11;
				NullCheck(L_51);
				bool L_53 = List_1_Contains_mC1D01A0D94C03E4225EEF9D6506D7D91C6976B7B(L_51, L_52, /*hidden argument*/List_1_Contains_mC1D01A0D94C03E4225EEF9D6506D7D91C6976B7B_RuntimeMethod_var);
				if (L_53)
				{
					goto IL_015b;
				}
			}

IL_0153:
			{
				List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * L_54 = V_2;
				String_t* L_55 = V_11;
				NullCheck(L_54);
				List_1_Add_mA348FA1140766465189459D25B01EB179001DE83(L_54, L_55, /*hidden argument*/List_1_Add_mA348FA1140766465189459D25B01EB179001DE83_RuntimeMethod_var);
			}

IL_015b:
			{
				RuntimeObject* L_56 = V_9;
				NullCheck(L_56);
				bool L_57 = InterfaceFuncInvoker0< bool >::Invoke(0 /* System.Boolean System.Collections.IEnumerator::MoveNext() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_56);
				if (L_57)
				{
					goto IL_00cd;
				}
			}

IL_0167:
			{
				IL2CPP_LEAVE(0x182, FINALLY_016c);
			}
		} // end try (depth: 2)
		catch(Il2CppExceptionWrapper& e)
		{
			__last_unhandled_exception = (Exception_t *)e.ex;
			goto FINALLY_016c;
		}

FINALLY_016c:
		{ // begin finally (depth: 2)
			{
				RuntimeObject* L_58 = V_9;
				V_37 = ((RuntimeObject*)IsInst((RuntimeObject*)L_58, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var));
				RuntimeObject* L_59 = V_37;
				if (L_59)
				{
					goto IL_017a;
				}
			}

IL_0179:
			{
				IL2CPP_END_FINALLY(364)
			}

IL_017a:
			{
				RuntimeObject* L_60 = V_37;
				NullCheck(L_60);
				InterfaceActionInvoker0::Invoke(0 /* System.Void System.IDisposable::Dispose() */, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var, L_60);
				IL2CPP_END_FINALLY(364)
			}
		} // end finally (depth: 2)
		IL2CPP_CLEANUP(364)
		{
			IL2CPP_JUMP_TBL(0x182, IL_0182)
			IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
		}

IL_0182:
		{
			Dictionary_2_tDC22E8D85FFE7CF6700ED76FF14853FC1E99CCFF * L_61 = V_1;
			NullCheck(L_61);
			Enumerator_t38C41296850665F3643D772F9790D4B3880BD9AA  L_62 = Dictionary_2_GetEnumerator_mF81DC76A58E19C2640CF6C8BE06F78361512F6E6(L_61, /*hidden argument*/Dictionary_2_GetEnumerator_mF81DC76A58E19C2640CF6C8BE06F78361512F6E6_RuntimeMethod_var);
			V_13 = L_62;
		}

IL_018a:
		try
		{ // begin try (depth: 2)
			{
				goto IL_05d8;
			}

IL_018f:
			{
				KeyValuePair_2_t9E20856DB65BAC258C27F3C359C8A86E2DCEEBBD  L_63 = Enumerator_get_Current_m0C79D6B8A354C9E3D29D7B654F902B30868E0949((Enumerator_t38C41296850665F3643D772F9790D4B3880BD9AA *)(&V_13), /*hidden argument*/Enumerator_get_Current_m0C79D6B8A354C9E3D29D7B654F902B30868E0949_RuntimeMethod_var);
				V_12 = L_63;
				V_14 = 0;
				goto IL_05c5;
			}

IL_01a0:
			{
				List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * L_64 = KeyValuePair_2_get_Value_m8476A7D87325D4D7A32A4FFF66D2F2AEE1C30E36((KeyValuePair_2_t9E20856DB65BAC258C27F3C359C8A86E2DCEEBBD *)(&V_12), /*hidden argument*/KeyValuePair_2_get_Value_m8476A7D87325D4D7A32A4FFF66D2F2AEE1C30E36_RuntimeMethod_var);
				int32_t L_65 = V_14;
				NullCheck(L_64);
				String_t* L_66 = List_1_get_Item_mB739B0066E5F7EBDBA9978F24A73D26D4FAE5BED(L_64, L_65, /*hidden argument*/List_1_get_Item_mB739B0066E5F7EBDBA9978F24A73D26D4FAE5BED_RuntimeMethod_var);
				V_15 = L_66;
				V_16 = (DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B *)NULL;
				SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * L_67 = ___cnn0;
				StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_68 = (StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E*)SZArrayNew(StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E_il2cpp_TypeInfo_var, (uint32_t)3);
				StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_69 = L_68;
				String_t* L_70 = KeyValuePair_2_get_Key_m30085F04A06E53139F92FFF128B01098A85D75E4((KeyValuePair_2_t9E20856DB65BAC258C27F3C359C8A86E2DCEEBBD *)(&V_12), /*hidden argument*/KeyValuePair_2_get_Key_m30085F04A06E53139F92FFF128B01098A85D75E4_RuntimeMethod_var);
				NullCheck(L_69);
				ArrayElementTypeCheck (L_69, L_70);
				(L_69)->SetAt(static_cast<il2cpp_array_size_t>(0), (String_t*)L_70);
				StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_71 = L_69;
				String_t* L_72 = V_15;
				NullCheck(L_71);
				ArrayElementTypeCheck (L_71, L_72);
				(L_71)->SetAt(static_cast<il2cpp_array_size_t>(2), (String_t*)L_72);
				NullCheck(L_67);
				DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_73 = SqliteConnection_GetSchema_mBD744C989445D4F7E5055D78A4AE20E02E0DB183(L_67, _stringLiteralF642EE196088372EA886186C6C617515599AFD3F, L_71, /*hidden argument*/NULL);
				V_17 = L_73;
			}

IL_01d5:
			try
			{ // begin try (depth: 3)
				{
					V_18 = 0;
					goto IL_0278;
				}

IL_01dd:
				{
					DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_74 = V_17;
					NullCheck(L_74);
					DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0 * L_75 = DataTable_get_Rows_m905B0636C268095F62E08B89B97A034E6BC483D3(L_74, /*hidden argument*/NULL);
					NullCheck(L_75);
					RuntimeObject* L_76 = VirtFuncInvoker0< RuntimeObject* >::Invoke(11 /* System.Collections.IEnumerator System.Data.InternalDataCollectionBase::GetEnumerator() */, L_75);
					V_20 = L_76;
				}

IL_01eb:
				try
				{ // begin try (depth: 4)
					{
						goto IL_024b;
					}

IL_01f0:
					{
						RuntimeObject* L_77 = V_20;
						NullCheck(L_77);
						RuntimeObject * L_78 = InterfaceFuncInvoker0< RuntimeObject * >::Invoke(1 /* System.Object System.Collections.IEnumerator::get_Current() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_77);
						V_19 = ((DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B *)CastclassClass((RuntimeObject*)L_78, DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B_il2cpp_TypeInfo_var));
						int32_t L_79 = V_18;
						if (L_79)
						{
							goto IL_0224;
						}
					}

IL_0205:
					{
						DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_80 = V_19;
						NullCheck(L_80);
						RuntimeObject * L_81 = DataRow_get_Item_mECAC0A4B3584FB64E6A6AE1E6EAE91B7E9B11C89(L_80, _stringLiteral2301A3AED57BDF6FA84FA74B2553B52161EE1A1B, /*hidden argument*/NULL);
						if (!((*(bool*)((bool*)UnBox(L_81, Boolean_tB53F6830F670160873277339AA58F15CAED4399C_il2cpp_TypeInfo_var)))))
						{
							goto IL_0224;
						}
					}

IL_021b:
					{
						DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_82 = V_19;
						V_16 = L_82;
						goto IL_0257;
					}

IL_0224:
					{
						int32_t L_83 = V_18;
						if ((!(((uint32_t)L_83) == ((uint32_t)1))))
						{
							goto IL_024b;
						}
					}

IL_022c:
					{
						DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_84 = V_19;
						NullCheck(L_84);
						RuntimeObject * L_85 = DataRow_get_Item_mECAC0A4B3584FB64E6A6AE1E6EAE91B7E9B11C89(L_84, _stringLiteralC9E6A29D14F3F27CD2EE75B65407552AD50A3078, /*hidden argument*/NULL);
						if (!((*(bool*)((bool*)UnBox(L_85, Boolean_tB53F6830F670160873277339AA58F15CAED4399C_il2cpp_TypeInfo_var)))))
						{
							goto IL_024b;
						}
					}

IL_0242:
					{
						DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_86 = V_19;
						V_16 = L_86;
						goto IL_0257;
					}

IL_024b:
					{
						RuntimeObject* L_87 = V_20;
						NullCheck(L_87);
						bool L_88 = InterfaceFuncInvoker0< bool >::Invoke(0 /* System.Boolean System.Collections.IEnumerator::MoveNext() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_87);
						if (L_88)
						{
							goto IL_01f0;
						}
					}

IL_0257:
					{
						IL2CPP_LEAVE(0x272, FINALLY_025c);
					}
				} // end try (depth: 4)
				catch(Il2CppExceptionWrapper& e)
				{
					__last_unhandled_exception = (Exception_t *)e.ex;
					goto FINALLY_025c;
				}

FINALLY_025c:
				{ // begin finally (depth: 4)
					{
						RuntimeObject* L_89 = V_20;
						V_38 = ((RuntimeObject*)IsInst((RuntimeObject*)L_89, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var));
						RuntimeObject* L_90 = V_38;
						if (L_90)
						{
							goto IL_026a;
						}
					}

IL_0269:
					{
						IL2CPP_END_FINALLY(604)
					}

IL_026a:
					{
						RuntimeObject* L_91 = V_38;
						NullCheck(L_91);
						InterfaceActionInvoker0::Invoke(0 /* System.Void System.IDisposable::Dispose() */, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var, L_91);
						IL2CPP_END_FINALLY(604)
					}
				} // end finally (depth: 4)
				IL2CPP_CLEANUP(604)
				{
					IL2CPP_JUMP_TBL(0x272, IL_0272)
					IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
				}

IL_0272:
				{
					int32_t L_92 = V_18;
					V_18 = ((int32_t)il2cpp_codegen_add((int32_t)L_92, (int32_t)1));
				}

IL_0278:
				{
					int32_t L_93 = V_18;
					if ((((int32_t)L_93) >= ((int32_t)2)))
					{
						goto IL_0287;
					}
				}

IL_0280:
				{
					DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_94 = V_16;
					if (!L_94)
					{
						goto IL_01dd;
					}
				}

IL_0287:
				{
					DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_95 = V_16;
					if (L_95)
					{
						goto IL_02a7;
					}
				}

IL_028e:
				{
					List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * L_96 = KeyValuePair_2_get_Value_m8476A7D87325D4D7A32A4FFF66D2F2AEE1C30E36((KeyValuePair_2_t9E20856DB65BAC258C27F3C359C8A86E2DCEEBBD *)(&V_12), /*hidden argument*/KeyValuePair_2_get_Value_m8476A7D87325D4D7A32A4FFF66D2F2AEE1C30E36_RuntimeMethod_var);
					int32_t L_97 = V_14;
					NullCheck(L_96);
					List_1_RemoveAt_mD17877118EA5CCF90E0D36CF420287270492A0F2(L_96, L_97, /*hidden argument*/List_1_RemoveAt_mD17877118EA5CCF90E0D36CF420287270492A0F2_RuntimeMethod_var);
					int32_t L_98 = V_14;
					V_14 = ((int32_t)il2cpp_codegen_subtract((int32_t)L_98, (int32_t)1));
					goto IL_05ab;
				}

IL_02a7:
				{
					SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * L_99 = ___cnn0;
					StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_100 = (StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E*)SZArrayNew(StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E_il2cpp_TypeInfo_var, (uint32_t)3);
					StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_101 = L_100;
					String_t* L_102 = KeyValuePair_2_get_Key_m30085F04A06E53139F92FFF128B01098A85D75E4((KeyValuePair_2_t9E20856DB65BAC258C27F3C359C8A86E2DCEEBBD *)(&V_12), /*hidden argument*/KeyValuePair_2_get_Key_m30085F04A06E53139F92FFF128B01098A85D75E4_RuntimeMethod_var);
					NullCheck(L_101);
					ArrayElementTypeCheck (L_101, L_102);
					(L_101)->SetAt(static_cast<il2cpp_array_size_t>(0), (String_t*)L_102);
					StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_103 = L_101;
					String_t* L_104 = V_15;
					NullCheck(L_103);
					ArrayElementTypeCheck (L_103, L_104);
					(L_103)->SetAt(static_cast<il2cpp_array_size_t>(2), (String_t*)L_104);
					NullCheck(L_99);
					DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_105 = SqliteConnection_GetSchema_mBD744C989445D4F7E5055D78A4AE20E02E0DB183(L_99, _stringLiteral193DAF137ED8B89DE36D47C3DF5FD8F66C0E1D14, L_103, /*hidden argument*/NULL);
					V_21 = L_105;
				}

IL_02c9:
				try
				{ // begin try (depth: 4)
					{
						Dictionary_2_tD6E204872BA9FD506A0287EF68E285BEB9EC0DFB * L_106 = V_0;
						String_t* L_107 = KeyValuePair_2_get_Key_m30085F04A06E53139F92FFF128B01098A85D75E4((KeyValuePair_2_t9E20856DB65BAC258C27F3C359C8A86E2DCEEBBD *)(&V_12), /*hidden argument*/KeyValuePair_2_get_Key_m30085F04A06E53139F92FFF128B01098A85D75E4_RuntimeMethod_var);
						NullCheck(L_106);
						int32_t L_108 = Dictionary_2_get_Item_m8B16E8CBD6B9EE71984601DB60ADB40673ADD5CC(L_106, L_107, /*hidden argument*/Dictionary_2_get_Item_m8B16E8CBD6B9EE71984601DB60ADB40673ADD5CC_RuntimeMethod_var);
						V_22 = L_108;
						DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_109 = V_21;
						NullCheck(L_109);
						DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0 * L_110 = DataTable_get_Rows_m905B0636C268095F62E08B89B97A034E6BC483D3(L_109, /*hidden argument*/NULL);
						NullCheck(L_110);
						DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_111 = DataRowCollection_get_Item_mDF585AB070DEE6DB7B63881536E7072B0C87834F(L_110, 0, /*hidden argument*/NULL);
						NullCheck(L_111);
						RuntimeObject * L_112 = DataRow_get_Item_mECAC0A4B3584FB64E6A6AE1E6EAE91B7E9B11C89(L_111, _stringLiteralBB4B470AC8E8BC7DB9A08102DEBACDD14B1D6379, /*hidden argument*/NULL);
						IL2CPP_RUNTIME_CLASS_INIT(Convert_t1C7A851BFB2F0782FD7F72F6AA1DCBB7B53A9C7E_il2cpp_TypeInfo_var);
						int32_t L_113 = Convert_ToInt32_mCF1152AF4138C1DD7A16643B22EE69A38373EF86(L_112, /*hidden argument*/NULL);
						V_23 = L_113;
						SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * L_114 = ___stmt2;
						NullCheck(L_114);
						SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_115 = L_114->get__sql_0();
						SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * L_116 = ___stmt2;
						int32_t L_117 = V_22;
						int32_t L_118 = V_23;
						NullCheck(L_115);
						int32_t L_119 = VirtFuncInvoker3< int32_t, SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A *, int32_t, int32_t >::Invoke(58 /* System.Int32 Mono.Data.Sqlite.SQLiteBase::GetCursorForTable(Mono.Data.Sqlite.SqliteStatement,System.Int32,System.Int32) */, L_115, L_116, L_117, L_118);
						V_24 = L_119;
						SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * L_120 = ___cnn0;
						StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_121 = (StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E*)SZArrayNew(StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E_il2cpp_TypeInfo_var, (uint32_t)4);
						StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_122 = L_121;
						String_t* L_123 = KeyValuePair_2_get_Key_m30085F04A06E53139F92FFF128B01098A85D75E4((KeyValuePair_2_t9E20856DB65BAC258C27F3C359C8A86E2DCEEBBD *)(&V_12), /*hidden argument*/KeyValuePair_2_get_Key_m30085F04A06E53139F92FFF128B01098A85D75E4_RuntimeMethod_var);
						NullCheck(L_122);
						ArrayElementTypeCheck (L_122, L_123);
						(L_122)->SetAt(static_cast<il2cpp_array_size_t>(0), (String_t*)L_123);
						StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_124 = L_122;
						String_t* L_125 = V_15;
						NullCheck(L_124);
						ArrayElementTypeCheck (L_124, L_125);
						(L_124)->SetAt(static_cast<il2cpp_array_size_t>(2), (String_t*)L_125);
						StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_126 = L_124;
						DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_127 = V_16;
						NullCheck(L_127);
						RuntimeObject * L_128 = DataRow_get_Item_mECAC0A4B3584FB64E6A6AE1E6EAE91B7E9B11C89(L_127, _stringLiteral654053DB7D1826E8BC0FB8C5C17C5E62B7C9C87C, /*hidden argument*/NULL);
						NullCheck(L_126);
						ArrayElementTypeCheck (L_126, ((String_t*)CastclassSealed((RuntimeObject*)L_128, String_t_il2cpp_TypeInfo_var)));
						(L_126)->SetAt(static_cast<il2cpp_array_size_t>(3), (String_t*)((String_t*)CastclassSealed((RuntimeObject*)L_128, String_t_il2cpp_TypeInfo_var)));
						NullCheck(L_120);
						DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_129 = SqliteConnection_GetSchema_mBD744C989445D4F7E5055D78A4AE20E02E0DB183(L_120, _stringLiteralD1D50AF319576CA6C6CBA296631E193D490A5370, L_126, /*hidden argument*/NULL);
						V_25 = L_129;
					}

IL_033e:
					try
					{ // begin try (depth: 5)
						{
							V_26 = (KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 *)NULL;
							List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * L_130 = (List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 *)il2cpp_codegen_object_new(List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3_il2cpp_TypeInfo_var);
							List_1__ctor_mDA22758D73530683C950C5CCF39BDB4E7E1F3F06(L_130, /*hidden argument*/List_1__ctor_mDA22758D73530683C950C5CCF39BDB4E7E1F3F06_RuntimeMethod_var);
							V_27 = L_130;
							V_28 = 0;
							goto IL_0475;
						}

IL_0350:
						{
							V_29 = (bool)1;
							DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_131 = V_7;
							NullCheck(L_131);
							DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0 * L_132 = DataTable_get_Rows_m905B0636C268095F62E08B89B97A034E6BC483D3(L_131, /*hidden argument*/NULL);
							NullCheck(L_132);
							RuntimeObject* L_133 = VirtFuncInvoker0< RuntimeObject* >::Invoke(11 /* System.Collections.IEnumerator System.Data.InternalDataCollectionBase::GetEnumerator() */, L_132);
							V_31 = L_133;
						}

IL_0361:
						try
						{ // begin try (depth: 6)
							{
								goto IL_041d;
							}

IL_0366:
							{
								RuntimeObject* L_134 = V_31;
								NullCheck(L_134);
								RuntimeObject * L_135 = InterfaceFuncInvoker0< RuntimeObject * >::Invoke(1 /* System.Object System.Collections.IEnumerator::get_Current() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_134);
								V_30 = ((DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B *)CastclassClass((RuntimeObject*)L_135, DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B_il2cpp_TypeInfo_var));
								DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_136 = V_30;
								IL2CPP_RUNTIME_CLASS_INIT(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_il2cpp_TypeInfo_var);
								String_t* L_137 = ((SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_il2cpp_TypeInfo_var))->get_BaseColumnName_16();
								NullCheck(L_136);
								bool L_138 = DataRow_IsNull_mCF24987852F1AC348E419E59F28F1A84F90AF1D0(L_136, L_137, /*hidden argument*/NULL);
								if (!L_138)
								{
									goto IL_038a;
								}
							}

IL_0385:
							{
								goto IL_041d;
							}

IL_038a:
							{
								DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_139 = V_30;
								IL2CPP_RUNTIME_CLASS_INIT(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_il2cpp_TypeInfo_var);
								String_t* L_140 = ((SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_il2cpp_TypeInfo_var))->get_BaseColumnName_16();
								NullCheck(L_139);
								RuntimeObject * L_141 = DataRow_get_Item_mECAC0A4B3584FB64E6A6AE1E6EAE91B7E9B11C89(L_139, L_140, /*hidden argument*/NULL);
								DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_142 = V_25;
								NullCheck(L_142);
								DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0 * L_143 = DataTable_get_Rows_m905B0636C268095F62E08B89B97A034E6BC483D3(L_142, /*hidden argument*/NULL);
								int32_t L_144 = V_28;
								NullCheck(L_143);
								DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_145 = DataRowCollection_get_Item_mDF585AB070DEE6DB7B63881536E7072B0C87834F(L_143, L_144, /*hidden argument*/NULL);
								NullCheck(L_145);
								RuntimeObject * L_146 = DataRow_get_Item_mECAC0A4B3584FB64E6A6AE1E6EAE91B7E9B11C89(L_145, _stringLiteral62F94C337A62422091EEC8AF220557BC9D2A0F7D, /*hidden argument*/NULL);
								bool L_147 = String_op_Equality_m139F0E4195AE2F856019E63B241F36F016997FCE(((String_t*)CastclassSealed((RuntimeObject*)L_141, String_t_il2cpp_TypeInfo_var)), ((String_t*)CastclassSealed((RuntimeObject*)L_146, String_t_il2cpp_TypeInfo_var)), /*hidden argument*/NULL);
								if (!L_147)
								{
									goto IL_041d;
								}
							}

IL_03c2:
							{
								DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_148 = V_30;
								IL2CPP_RUNTIME_CLASS_INIT(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_il2cpp_TypeInfo_var);
								String_t* L_149 = ((SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_il2cpp_TypeInfo_var))->get_BaseTableName_15();
								NullCheck(L_148);
								RuntimeObject * L_150 = DataRow_get_Item_mECAC0A4B3584FB64E6A6AE1E6EAE91B7E9B11C89(L_148, L_149, /*hidden argument*/NULL);
								String_t* L_151 = V_15;
								bool L_152 = String_op_Equality_m139F0E4195AE2F856019E63B241F36F016997FCE(((String_t*)CastclassSealed((RuntimeObject*)L_150, String_t_il2cpp_TypeInfo_var)), L_151, /*hidden argument*/NULL);
								if (!L_152)
								{
									goto IL_041d;
								}
							}

IL_03df:
							{
								DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_153 = V_30;
								IL2CPP_RUNTIME_CLASS_INIT(SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_il2cpp_TypeInfo_var);
								String_t* L_154 = ((SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_il2cpp_TypeInfo_var))->get_BaseCatalogName_6();
								NullCheck(L_153);
								RuntimeObject * L_155 = DataRow_get_Item_mECAC0A4B3584FB64E6A6AE1E6EAE91B7E9B11C89(L_153, L_154, /*hidden argument*/NULL);
								String_t* L_156 = KeyValuePair_2_get_Key_m30085F04A06E53139F92FFF128B01098A85D75E4((KeyValuePair_2_t9E20856DB65BAC258C27F3C359C8A86E2DCEEBBD *)(&V_12), /*hidden argument*/KeyValuePair_2_get_Key_m30085F04A06E53139F92FFF128B01098A85D75E4_RuntimeMethod_var);
								bool L_157 = String_op_Equality_m139F0E4195AE2F856019E63B241F36F016997FCE(((String_t*)CastclassSealed((RuntimeObject*)L_155, String_t_il2cpp_TypeInfo_var)), L_156, /*hidden argument*/NULL);
								if (!L_157)
								{
									goto IL_041d;
								}
							}

IL_0401:
							{
								DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_158 = V_25;
								NullCheck(L_158);
								DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0 * L_159 = DataTable_get_Rows_m905B0636C268095F62E08B89B97A034E6BC483D3(L_158, /*hidden argument*/NULL);
								int32_t L_160 = V_28;
								NullCheck(L_159);
								DataRowCollection_RemoveAt_mC10D9EEAF5FD8346FA1CB1575543488540B93D08(L_159, L_160, /*hidden argument*/NULL);
								int32_t L_161 = V_28;
								V_28 = ((int32_t)il2cpp_codegen_subtract((int32_t)L_161, (int32_t)1));
								V_29 = (bool)0;
								goto IL_0429;
							}

IL_041d:
							{
								RuntimeObject* L_162 = V_31;
								NullCheck(L_162);
								bool L_163 = InterfaceFuncInvoker0< bool >::Invoke(0 /* System.Boolean System.Collections.IEnumerator::MoveNext() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_162);
								if (L_163)
								{
									goto IL_0366;
								}
							}

IL_0429:
							{
								IL2CPP_LEAVE(0x444, FINALLY_042e);
							}
						} // end try (depth: 6)
						catch(Il2CppExceptionWrapper& e)
						{
							__last_unhandled_exception = (Exception_t *)e.ex;
							goto FINALLY_042e;
						}

FINALLY_042e:
						{ // begin finally (depth: 6)
							{
								RuntimeObject* L_164 = V_31;
								V_39 = ((RuntimeObject*)IsInst((RuntimeObject*)L_164, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var));
								RuntimeObject* L_165 = V_39;
								if (L_165)
								{
									goto IL_043c;
								}
							}

IL_043b:
							{
								IL2CPP_END_FINALLY(1070)
							}

IL_043c:
							{
								RuntimeObject* L_166 = V_39;
								NullCheck(L_166);
								InterfaceActionInvoker0::Invoke(0 /* System.Void System.IDisposable::Dispose() */, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var, L_166);
								IL2CPP_END_FINALLY(1070)
							}
						} // end finally (depth: 6)
						IL2CPP_CLEANUP(1070)
						{
							IL2CPP_JUMP_TBL(0x444, IL_0444)
							IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
						}

IL_0444:
						{
							bool L_167 = V_29;
							if (!L_167)
							{
								goto IL_046f;
							}
						}

IL_044b:
						{
							List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * L_168 = V_27;
							DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_169 = V_25;
							NullCheck(L_169);
							DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0 * L_170 = DataTable_get_Rows_m905B0636C268095F62E08B89B97A034E6BC483D3(L_169, /*hidden argument*/NULL);
							int32_t L_171 = V_28;
							NullCheck(L_170);
							DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_172 = DataRowCollection_get_Item_mDF585AB070DEE6DB7B63881536E7072B0C87834F(L_170, L_171, /*hidden argument*/NULL);
							NullCheck(L_172);
							RuntimeObject * L_173 = DataRow_get_Item_mECAC0A4B3584FB64E6A6AE1E6EAE91B7E9B11C89(L_172, _stringLiteral62F94C337A62422091EEC8AF220557BC9D2A0F7D, /*hidden argument*/NULL);
							NullCheck(L_168);
							List_1_Add_mA348FA1140766465189459D25B01EB179001DE83(L_168, ((String_t*)CastclassSealed((RuntimeObject*)L_173, String_t_il2cpp_TypeInfo_var)), /*hidden argument*/List_1_Add_mA348FA1140766465189459D25B01EB179001DE83_RuntimeMethod_var);
						}

IL_046f:
						{
							int32_t L_174 = V_28;
							V_28 = ((int32_t)il2cpp_codegen_add((int32_t)L_174, (int32_t)1));
						}

IL_0475:
						{
							int32_t L_175 = V_28;
							DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_176 = V_25;
							NullCheck(L_176);
							DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0 * L_177 = DataTable_get_Rows_m905B0636C268095F62E08B89B97A034E6BC483D3(L_176, /*hidden argument*/NULL);
							NullCheck(L_177);
							int32_t L_178 = DataRowCollection_get_Count_mA4B1179424DF0637C1E85C2148055F8035E0B1DA(L_177, /*hidden argument*/NULL);
							if ((((int32_t)L_175) < ((int32_t)L_178)))
							{
								goto IL_0350;
							}
						}

IL_0488:
						{
							DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_179 = V_16;
							NullCheck(L_179);
							RuntimeObject * L_180 = DataRow_get_Item_mECAC0A4B3584FB64E6A6AE1E6EAE91B7E9B11C89(L_179, _stringLiteral654053DB7D1826E8BC0FB8C5C17C5E62B7C9C87C, /*hidden argument*/NULL);
							String_t* L_181 = V_15;
							String_t* L_182 = String_Concat_mB78D0094592718DA6D5DB6C712A9C225631666BE(_stringLiteral96B270E30E3C5C4FDE9E03F6B30D4F2F1657F16C, L_181, /*hidden argument*/NULL);
							bool L_183 = String_op_Inequality_m0BD184A74F453A72376E81CC6CAEE2556B80493E(((String_t*)CastclassSealed((RuntimeObject*)L_180, String_t_il2cpp_TypeInfo_var)), L_182, /*hidden argument*/NULL);
							if (!L_183)
							{
								goto IL_04e6;
							}
						}

IL_04af:
						{
							List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * L_184 = V_27;
							NullCheck(L_184);
							int32_t L_185 = List_1_get_Count_m4151A68BD4CB1D737213E7595F574987F8C812B4(L_184, /*hidden argument*/List_1_get_Count_m4151A68BD4CB1D737213E7595F574987F8C812B4_RuntimeMethod_var);
							if ((((int32_t)L_185) <= ((int32_t)0)))
							{
								goto IL_04e6;
							}
						}

IL_04bc:
						{
							List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * L_186 = V_27;
							NullCheck(L_186);
							int32_t L_187 = List_1_get_Count_m4151A68BD4CB1D737213E7595F574987F8C812B4(L_186, /*hidden argument*/List_1_get_Count_m4151A68BD4CB1D737213E7595F574987F8C812B4_RuntimeMethod_var);
							StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_188 = (StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E*)SZArrayNew(StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E_il2cpp_TypeInfo_var, (uint32_t)L_187);
							V_32 = L_188;
							List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * L_189 = V_27;
							StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_190 = V_32;
							NullCheck(L_189);
							List_1_CopyTo_m152A529573840F5373AD90FD98B33D00070920FE(L_189, L_190, /*hidden argument*/List_1_CopyTo_m152A529573840F5373AD90FD98B33D00070920FE_RuntimeMethod_var);
							SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * L_191 = ___cnn0;
							String_t* L_192 = KeyValuePair_2_get_Key_m30085F04A06E53139F92FFF128B01098A85D75E4((KeyValuePair_2_t9E20856DB65BAC258C27F3C359C8A86E2DCEEBBD *)(&V_12), /*hidden argument*/KeyValuePair_2_get_Key_m30085F04A06E53139F92FFF128B01098A85D75E4_RuntimeMethod_var);
							String_t* L_193 = V_15;
							StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_194 = V_32;
							KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_195 = (KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 *)il2cpp_codegen_object_new(KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4_il2cpp_TypeInfo_var);
							KeyQuery__ctor_m3095086FBBB97A6899ED7F47A9F349AC1D767E83(L_195, L_191, L_192, L_193, L_194, /*hidden argument*/NULL);
							V_26 = L_195;
						}

IL_04e6:
						{
							V_33 = 0;
							goto IL_0570;
						}

IL_04ee:
						{
							DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_196 = V_25;
							NullCheck(L_196);
							DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0 * L_197 = DataTable_get_Rows_m905B0636C268095F62E08B89B97A034E6BC483D3(L_196, /*hidden argument*/NULL);
							int32_t L_198 = V_33;
							NullCheck(L_197);
							DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_199 = DataRowCollection_get_Item_mDF585AB070DEE6DB7B63881536E7072B0C87834F(L_197, L_198, /*hidden argument*/NULL);
							NullCheck(L_199);
							RuntimeObject * L_200 = DataRow_get_Item_mECAC0A4B3584FB64E6A6AE1E6EAE91B7E9B11C89(L_199, _stringLiteral62F94C337A62422091EEC8AF220557BC9D2A0F7D, /*hidden argument*/NULL);
							V_34 = ((String_t*)CastclassSealed((RuntimeObject*)L_200, String_t_il2cpp_TypeInfo_var));
							il2cpp_codegen_initobj((&V_35), sizeof(KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC ));
							int32_t L_201 = V_23;
							(&V_35)->set_rootPage_4(L_201);
							int32_t L_202 = V_24;
							(&V_35)->set_cursor_5(L_202);
							int32_t L_203 = V_22;
							(&V_35)->set_database_3(L_203);
							String_t* L_204 = KeyValuePair_2_get_Key_m30085F04A06E53139F92FFF128B01098A85D75E4((KeyValuePair_2_t9E20856DB65BAC258C27F3C359C8A86E2DCEEBBD *)(&V_12), /*hidden argument*/KeyValuePair_2_get_Key_m30085F04A06E53139F92FFF128B01098A85D75E4_RuntimeMethod_var);
							(&V_35)->set_databaseName_0(L_204);
							String_t* L_205 = V_15;
							(&V_35)->set_tableName_1(L_205);
							String_t* L_206 = V_34;
							(&V_35)->set_columnName_2(L_206);
							KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_207 = V_26;
							(&V_35)->set_query_6(L_207);
							int32_t L_208 = V_33;
							(&V_35)->set_column_7(L_208);
							List_1_tD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD * L_209 = V_3;
							KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC  L_210 = V_35;
							NullCheck(L_209);
							List_1_Add_m335FACF62F79155D36F4BD6E4CE541AFBCCCDAEA(L_209, L_210, /*hidden argument*/List_1_Add_m335FACF62F79155D36F4BD6E4CE541AFBCCCDAEA_RuntimeMethod_var);
							int32_t L_211 = V_33;
							V_33 = ((int32_t)il2cpp_codegen_add((int32_t)L_211, (int32_t)1));
						}

IL_0570:
						{
							int32_t L_212 = V_33;
							DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_213 = V_25;
							NullCheck(L_213);
							DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0 * L_214 = DataTable_get_Rows_m905B0636C268095F62E08B89B97A034E6BC483D3(L_213, /*hidden argument*/NULL);
							NullCheck(L_214);
							int32_t L_215 = DataRowCollection_get_Count_mA4B1179424DF0637C1E85C2148055F8035E0B1DA(L_214, /*hidden argument*/NULL);
							if ((((int32_t)L_212) < ((int32_t)L_215)))
							{
								goto IL_04ee;
							}
						}

IL_0583:
						{
							IL2CPP_LEAVE(0x597, FINALLY_0588);
						}
					} // end try (depth: 5)
					catch(Il2CppExceptionWrapper& e)
					{
						__last_unhandled_exception = (Exception_t *)e.ex;
						goto FINALLY_0588;
					}

FINALLY_0588:
					{ // begin finally (depth: 5)
						{
							DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_216 = V_25;
							if (!L_216)
							{
								goto IL_0596;
							}
						}

IL_058f:
						{
							DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_217 = V_25;
							NullCheck(L_217);
							InterfaceActionInvoker0::Invoke(0 /* System.Void System.IDisposable::Dispose() */, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var, L_217);
						}

IL_0596:
						{
							IL2CPP_END_FINALLY(1416)
						}
					} // end finally (depth: 5)
					IL2CPP_CLEANUP(1416)
					{
						IL2CPP_JUMP_TBL(0x597, IL_0597)
						IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
					}

IL_0597:
					{
						IL2CPP_LEAVE(0x5AB, FINALLY_059c);
					}
				} // end try (depth: 4)
				catch(Il2CppExceptionWrapper& e)
				{
					__last_unhandled_exception = (Exception_t *)e.ex;
					goto FINALLY_059c;
				}

FINALLY_059c:
				{ // begin finally (depth: 4)
					{
						DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_218 = V_21;
						if (!L_218)
						{
							goto IL_05aa;
						}
					}

IL_05a3:
					{
						DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_219 = V_21;
						NullCheck(L_219);
						InterfaceActionInvoker0::Invoke(0 /* System.Void System.IDisposable::Dispose() */, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var, L_219);
					}

IL_05aa:
					{
						IL2CPP_END_FINALLY(1436)
					}
				} // end finally (depth: 4)
				IL2CPP_CLEANUP(1436)
				{
					IL2CPP_JUMP_TBL(0x5AB, IL_05ab)
					IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
				}

IL_05ab:
				{
					IL2CPP_LEAVE(0x5BF, FINALLY_05b0);
				}
			} // end try (depth: 3)
			catch(Il2CppExceptionWrapper& e)
			{
				__last_unhandled_exception = (Exception_t *)e.ex;
				goto FINALLY_05b0;
			}

FINALLY_05b0:
			{ // begin finally (depth: 3)
				{
					DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_220 = V_17;
					if (!L_220)
					{
						goto IL_05be;
					}
				}

IL_05b7:
				{
					DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_221 = V_17;
					NullCheck(L_221);
					InterfaceActionInvoker0::Invoke(0 /* System.Void System.IDisposable::Dispose() */, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var, L_221);
				}

IL_05be:
				{
					IL2CPP_END_FINALLY(1456)
				}
			} // end finally (depth: 3)
			IL2CPP_CLEANUP(1456)
			{
				IL2CPP_JUMP_TBL(0x5BF, IL_05bf)
				IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
			}

IL_05bf:
			{
				int32_t L_222 = V_14;
				V_14 = ((int32_t)il2cpp_codegen_add((int32_t)L_222, (int32_t)1));
			}

IL_05c5:
			{
				int32_t L_223 = V_14;
				List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * L_224 = KeyValuePair_2_get_Value_m8476A7D87325D4D7A32A4FFF66D2F2AEE1C30E36((KeyValuePair_2_t9E20856DB65BAC258C27F3C359C8A86E2DCEEBBD *)(&V_12), /*hidden argument*/KeyValuePair_2_get_Value_m8476A7D87325D4D7A32A4FFF66D2F2AEE1C30E36_RuntimeMethod_var);
				NullCheck(L_224);
				int32_t L_225 = List_1_get_Count_m4151A68BD4CB1D737213E7595F574987F8C812B4(L_224, /*hidden argument*/List_1_get_Count_m4151A68BD4CB1D737213E7595F574987F8C812B4_RuntimeMethod_var);
				if ((((int32_t)L_223) < ((int32_t)L_225)))
				{
					goto IL_01a0;
				}
			}

IL_05d8:
			{
				bool L_226 = Enumerator_MoveNext_m1534F8F536B5DDFE0019172C7CD4B38969DBE226((Enumerator_t38C41296850665F3643D772F9790D4B3880BD9AA *)(&V_13), /*hidden argument*/Enumerator_MoveNext_m1534F8F536B5DDFE0019172C7CD4B38969DBE226_RuntimeMethod_var);
				if (L_226)
				{
					goto IL_018f;
				}
			}

IL_05e4:
			{
				IL2CPP_LEAVE(0x5F6, FINALLY_05e9);
			}
		} // end try (depth: 2)
		catch(Il2CppExceptionWrapper& e)
		{
			__last_unhandled_exception = (Exception_t *)e.ex;
			goto FINALLY_05e9;
		}

FINALLY_05e9:
		{ // begin finally (depth: 2)
			Enumerator_t38C41296850665F3643D772F9790D4B3880BD9AA  L_227 = V_13;
			Enumerator_t38C41296850665F3643D772F9790D4B3880BD9AA  L_228 = L_227;
			RuntimeObject * L_229 = Box(Enumerator_t38C41296850665F3643D772F9790D4B3880BD9AA_il2cpp_TypeInfo_var, &L_228);
			Enumerator_Dispose_m20DEE1B61D35A4F881D24FDE0FC3E8C0A7DBF89D((Enumerator_t38C41296850665F3643D772F9790D4B3880BD9AA *)UnBox(L_229, Enumerator_t38C41296850665F3643D772F9790D4B3880BD9AA_il2cpp_TypeInfo_var), /*hidden argument*/Enumerator_Dispose_m20DEE1B61D35A4F881D24FDE0FC3E8C0A7DBF89D_RuntimeMethod_var);
			IL2CPP_END_FINALLY(1513)
		} // end finally (depth: 2)
		IL2CPP_CLEANUP(1513)
		{
			IL2CPP_JUMP_TBL(0x5F6, IL_05f6)
			IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
		}

IL_05f6:
		{
			IL2CPP_LEAVE(0x60A, FINALLY_05fb);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_05fb;
	}

FINALLY_05fb:
	{ // begin finally (depth: 1)
		{
			DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_230 = V_7;
			if (!L_230)
			{
				goto IL_0609;
			}
		}

IL_0602:
		{
			DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_231 = V_7;
			NullCheck(L_231);
			InterfaceActionInvoker0::Invoke(0 /* System.Void System.IDisposable::Dispose() */, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var, L_231);
		}

IL_0609:
		{
			IL2CPP_END_FINALLY(1531)
		}
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(1531)
	{
		IL2CPP_JUMP_TBL(0x60A, IL_060a)
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
	}

IL_060a:
	{
		List_1_tD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD * L_232 = V_3;
		NullCheck(L_232);
		int32_t L_233 = List_1_get_Count_m0283B39AA2691EE274CBD01927A6175AC6C2F5BF(L_232, /*hidden argument*/List_1_get_Count_m0283B39AA2691EE274CBD01927A6175AC6C2F5BF_RuntimeMethod_var);
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_234 = (KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4*)SZArrayNew(KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4_il2cpp_TypeInfo_var, (uint32_t)L_233);
		__this->set__keyInfo_0(L_234);
		List_1_tD5E21809D3E149B0024E02A89D78F9C8D5D6C9FD * L_235 = V_3;
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_236 = __this->get__keyInfo_0();
		NullCheck(L_235);
		List_1_CopyTo_mD3FBBD792230E4756C75F7F245B815CFEB65836A(L_235, L_236, /*hidden argument*/List_1_CopyTo_mD3FBBD792230E4756C75F7F245B815CFEB65836A_RuntimeMethod_var);
		return;
	}
}
// System.Int32 Mono.Data.Sqlite.SqliteKeyReader::get_Count()
extern "C" IL2CPP_METHOD_ATTR int32_t SqliteKeyReader_get_Count_mC91E64EFA695FD87CDC581141E957541E93F9946 (SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793 * __this, const RuntimeMethod* method)
{
	int32_t G_B3_0 = 0;
	{
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_0 = __this->get__keyInfo_0();
		if (L_0)
		{
			goto IL_0011;
		}
	}
	{
		G_B3_0 = 0;
		goto IL_0019;
	}

IL_0011:
	{
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_1 = __this->get__keyInfo_0();
		NullCheck(L_1);
		G_B3_0 = (((int32_t)((int32_t)(((RuntimeArray *)L_1)->max_length))));
	}

IL_0019:
	{
		return G_B3_0;
	}
}
// System.Void Mono.Data.Sqlite.SqliteKeyReader::Sync(System.Int32)
extern "C" IL2CPP_METHOD_ATTR void SqliteKeyReader_Sync_mF6A76D7FF2131664DCAFC47426C77959060A7560 (SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793 * __this, int32_t ___i0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteKeyReader_Sync_mF6A76D7FF2131664DCAFC47426C77959060A7560_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		SqliteKeyReader_Sync_m3DCE8016688D6FECE14616AC1DBBF62CD5ECF053(__this, /*hidden argument*/NULL);
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_0 = __this->get__keyInfo_0();
		int32_t L_1 = ___i0;
		NullCheck(L_0);
		int32_t L_2 = ((L_0)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_1)))->get_cursor_5();
		if ((!(((uint32_t)L_2) == ((uint32_t)(-1)))))
		{
			goto IL_0023;
		}
	}
	{
		InvalidCastException_t91DF9E7D7FCCDA6C562CB4A9A18903E016680FDA * L_3 = (InvalidCastException_t91DF9E7D7FCCDA6C562CB4A9A18903E016680FDA *)il2cpp_codegen_object_new(InvalidCastException_t91DF9E7D7FCCDA6C562CB4A9A18903E016680FDA_il2cpp_TypeInfo_var);
		InvalidCastException__ctor_mB14CE363FB346D9BC0C0763CAF0B67AF90902144(L_3, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_3, NULL, SqliteKeyReader_Sync_mF6A76D7FF2131664DCAFC47426C77959060A7560_RuntimeMethod_var);
	}

IL_0023:
	{
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteKeyReader::Sync()
extern "C" IL2CPP_METHOD_ATTR void SqliteKeyReader_Sync_m3DCE8016688D6FECE14616AC1DBBF62CD5ECF053 (SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793 * __this, const RuntimeMethod* method)
{
	KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * V_0 = NULL;
	int32_t V_1 = 0;
	{
		bool L_0 = __this->get__isValid_2();
		if (!L_0)
		{
			goto IL_000c;
		}
	}
	{
		return;
	}

IL_000c:
	{
		V_0 = (KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 *)NULL;
		V_1 = 0;
		goto IL_008b;
	}

IL_0015:
	{
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_1 = __this->get__keyInfo_0();
		int32_t L_2 = V_1;
		NullCheck(L_1);
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_3 = ((L_1)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_2)))->get_query_6();
		if (!L_3)
		{
			goto IL_0042;
		}
	}
	{
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_4 = __this->get__keyInfo_0();
		int32_t L_5 = V_1;
		NullCheck(L_4);
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_6 = ((L_4)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_5)))->get_query_6();
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_7 = V_0;
		if ((((RuntimeObject*)(KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 *)L_6) == ((RuntimeObject*)(KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 *)L_7)))
		{
			goto IL_0087;
		}
	}

IL_0042:
	{
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_8 = __this->get__keyInfo_0();
		int32_t L_9 = V_1;
		NullCheck(L_8);
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_10 = ((L_8)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_9)))->get_query_6();
		V_0 = L_10;
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_11 = V_0;
		if (!L_11)
		{
			goto IL_0087;
		}
	}
	{
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_12 = V_0;
		SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * L_13 = __this->get__stmt_1();
		NullCheck(L_13);
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_14 = L_13->get__sql_0();
		SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * L_15 = __this->get__stmt_1();
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_16 = __this->get__keyInfo_0();
		int32_t L_17 = V_1;
		NullCheck(L_16);
		int32_t L_18 = ((L_16)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_17)))->get_cursor_5();
		NullCheck(L_14);
		int64_t L_19 = VirtFuncInvoker2< int64_t, SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A *, int32_t >::Invoke(59 /* System.Int64 Mono.Data.Sqlite.SQLiteBase::GetRowIdForCursor(Mono.Data.Sqlite.SqliteStatement,System.Int32) */, L_14, L_15, L_18);
		NullCheck(L_12);
		KeyQuery_Sync_m19A2575566EEFC07F5FC36F2E200FA23EE8A7390(L_12, L_19, /*hidden argument*/NULL);
	}

IL_0087:
	{
		int32_t L_20 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add((int32_t)L_20, (int32_t)1));
	}

IL_008b:
	{
		int32_t L_21 = V_1;
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_22 = __this->get__keyInfo_0();
		NullCheck(L_22);
		if ((((int32_t)L_21) < ((int32_t)(((int32_t)((int32_t)(((RuntimeArray *)L_22)->max_length)))))))
		{
			goto IL_0015;
		}
	}
	{
		__this->set__isValid_2((bool)1);
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteKeyReader::Reset()
extern "C" IL2CPP_METHOD_ATTR void SqliteKeyReader_Reset_mCE67CC7FFDC73282E2AD4A47E302F59B3FB778D3 (SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793 * __this, const RuntimeMethod* method)
{
	int32_t V_0 = 0;
	{
		__this->set__isValid_2((bool)0);
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_0 = __this->get__keyInfo_0();
		if (L_0)
		{
			goto IL_0013;
		}
	}
	{
		return;
	}

IL_0013:
	{
		V_0 = 0;
		goto IL_004b;
	}

IL_001a:
	{
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_1 = __this->get__keyInfo_0();
		int32_t L_2 = V_0;
		NullCheck(L_1);
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_3 = ((L_1)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_2)))->get_query_6();
		if (!L_3)
		{
			goto IL_0047;
		}
	}
	{
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_4 = __this->get__keyInfo_0();
		int32_t L_5 = V_0;
		NullCheck(L_4);
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_6 = ((L_4)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_5)))->get_query_6();
		NullCheck(L_6);
		KeyQuery_set_IsValid_mA4632D8CAB6B73258A401162467D7CB5C7E73B6D(L_6, (bool)0, /*hidden argument*/NULL);
	}

IL_0047:
	{
		int32_t L_7 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add((int32_t)L_7, (int32_t)1));
	}

IL_004b:
	{
		int32_t L_8 = V_0;
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_9 = __this->get__keyInfo_0();
		NullCheck(L_9);
		if ((((int32_t)L_8) < ((int32_t)(((int32_t)((int32_t)(((RuntimeArray *)L_9)->max_length)))))))
		{
			goto IL_001a;
		}
	}
	{
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteKeyReader::Dispose()
extern "C" IL2CPP_METHOD_ATTR void SqliteKeyReader_Dispose_m3DC44CCDBB72B36CF6E8DB219F2336110CEC4837 (SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793 * __this, const RuntimeMethod* method)
{
	int32_t V_0 = 0;
	{
		__this->set__stmt_1((SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A *)NULL);
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_0 = __this->get__keyInfo_0();
		if (L_0)
		{
			goto IL_0013;
		}
	}
	{
		return;
	}

IL_0013:
	{
		V_0 = 0;
		goto IL_004a;
	}

IL_001a:
	{
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_1 = __this->get__keyInfo_0();
		int32_t L_2 = V_0;
		NullCheck(L_1);
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_3 = ((L_1)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_2)))->get_query_6();
		if (!L_3)
		{
			goto IL_0046;
		}
	}
	{
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_4 = __this->get__keyInfo_0();
		int32_t L_5 = V_0;
		NullCheck(L_4);
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_6 = ((L_4)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_5)))->get_query_6();
		NullCheck(L_6);
		KeyQuery_Dispose_m47A9B991C6566086FD3BAB27C8DB2DBAFC4A1F48(L_6, /*hidden argument*/NULL);
	}

IL_0046:
	{
		int32_t L_7 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add((int32_t)L_7, (int32_t)1));
	}

IL_004a:
	{
		int32_t L_8 = V_0;
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_9 = __this->get__keyInfo_0();
		NullCheck(L_9);
		if ((((int32_t)L_8) < ((int32_t)(((int32_t)((int32_t)(((RuntimeArray *)L_9)->max_length)))))))
		{
			goto IL_001a;
		}
	}
	{
		__this->set__keyInfo_0((KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4*)NULL);
		return;
	}
}
// System.String Mono.Data.Sqlite.SqliteKeyReader::GetDataTypeName(System.Int32)
extern "C" IL2CPP_METHOD_ATTR String_t* SqliteKeyReader_GetDataTypeName_m8B7888A532923B94DB2A26A2B2C8D10B1FC24288 (SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793 * __this, int32_t ___i0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteKeyReader_GetDataTypeName_m8B7888A532923B94DB2A26A2B2C8D10B1FC24288_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		SqliteKeyReader_Sync_m3DCE8016688D6FECE14616AC1DBBF62CD5ECF053(__this, /*hidden argument*/NULL);
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_0 = __this->get__keyInfo_0();
		int32_t L_1 = ___i0;
		NullCheck(L_0);
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_2 = ((L_0)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_1)))->get_query_6();
		if (!L_2)
		{
			goto IL_0049;
		}
	}
	{
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_3 = __this->get__keyInfo_0();
		int32_t L_4 = ___i0;
		NullCheck(L_3);
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_5 = ((L_3)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_4)))->get_query_6();
		NullCheck(L_5);
		SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * L_6 = L_5->get__reader_1();
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_7 = __this->get__keyInfo_0();
		int32_t L_8 = ___i0;
		NullCheck(L_7);
		int32_t L_9 = ((L_7)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_8)))->get_column_7();
		NullCheck(L_6);
		String_t* L_10 = SqliteDataReader_GetDataTypeName_m6D7FD4F16F98B3DAB780DD3AC1D27E2858F3EAC4(L_6, L_9, /*hidden argument*/NULL);
		return L_10;
	}

IL_0049:
	{
		return _stringLiteral1178CAFBD64BBBFA77F5AC0A9D5032ED88162781;
	}
}
// System.Type Mono.Data.Sqlite.SqliteKeyReader::GetFieldType(System.Int32)
extern "C" IL2CPP_METHOD_ATTR Type_t * SqliteKeyReader_GetFieldType_mA8359394C7BE6432E1544530EA6DDD3E90BABB09 (SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793 * __this, int32_t ___i0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteKeyReader_GetFieldType_mA8359394C7BE6432E1544530EA6DDD3E90BABB09_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		SqliteKeyReader_Sync_m3DCE8016688D6FECE14616AC1DBBF62CD5ECF053(__this, /*hidden argument*/NULL);
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_0 = __this->get__keyInfo_0();
		int32_t L_1 = ___i0;
		NullCheck(L_0);
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_2 = ((L_0)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_1)))->get_query_6();
		if (!L_2)
		{
			goto IL_0049;
		}
	}
	{
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_3 = __this->get__keyInfo_0();
		int32_t L_4 = ___i0;
		NullCheck(L_3);
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_5 = ((L_3)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_4)))->get_query_6();
		NullCheck(L_5);
		SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * L_6 = L_5->get__reader_1();
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_7 = __this->get__keyInfo_0();
		int32_t L_8 = ___i0;
		NullCheck(L_7);
		int32_t L_9 = ((L_7)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_8)))->get_column_7();
		NullCheck(L_6);
		Type_t * L_10 = SqliteDataReader_GetFieldType_m9B70FC079ECDE5CCB617AFCE1EDC68377E8AE716(L_6, L_9, /*hidden argument*/NULL);
		return L_10;
	}

IL_0049:
	{
		RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  L_11 = { reinterpret_cast<intptr_t> (Int64_t7A386C2FF7B0280A0F516992401DDFCF0FF7B436_0_0_0_var) };
		IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
		Type_t * L_12 = Type_GetTypeFromHandle_m9DC58ADF0512987012A8A016FB64B068F3B1AFF6(L_11, /*hidden argument*/NULL);
		return L_12;
	}
}
// System.String Mono.Data.Sqlite.SqliteKeyReader::GetName(System.Int32)
extern "C" IL2CPP_METHOD_ATTR String_t* SqliteKeyReader_GetName_m4276E391DEB90A1009690064A10873A863CE1556 (SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793 * __this, int32_t ___i0, const RuntimeMethod* method)
{
	{
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_0 = __this->get__keyInfo_0();
		int32_t L_1 = ___i0;
		NullCheck(L_0);
		String_t* L_2 = ((L_0)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_1)))->get_columnName_2();
		return L_2;
	}
}
// System.Boolean Mono.Data.Sqlite.SqliteKeyReader::GetBoolean(System.Int32)
extern "C" IL2CPP_METHOD_ATTR bool SqliteKeyReader_GetBoolean_mF164552CBD10F49417C97F7FFF3454143AFE536C (SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793 * __this, int32_t ___i0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteKeyReader_GetBoolean_mF164552CBD10F49417C97F7FFF3454143AFE536C_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		int32_t L_0 = ___i0;
		SqliteKeyReader_Sync_mF6A76D7FF2131664DCAFC47426C77959060A7560(__this, L_0, /*hidden argument*/NULL);
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_1 = __this->get__keyInfo_0();
		int32_t L_2 = ___i0;
		NullCheck(L_1);
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_3 = ((L_1)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_2)))->get_query_6();
		if (!L_3)
		{
			goto IL_004a;
		}
	}
	{
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_4 = __this->get__keyInfo_0();
		int32_t L_5 = ___i0;
		NullCheck(L_4);
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_6 = ((L_4)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_5)))->get_query_6();
		NullCheck(L_6);
		SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * L_7 = L_6->get__reader_1();
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_8 = __this->get__keyInfo_0();
		int32_t L_9 = ___i0;
		NullCheck(L_8);
		int32_t L_10 = ((L_8)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_9)))->get_column_7();
		NullCheck(L_7);
		bool L_11 = SqliteDataReader_GetBoolean_m7E53B25F643A31EC286A65BE8FFDE02769C6D903(L_7, L_10, /*hidden argument*/NULL);
		return L_11;
	}

IL_004a:
	{
		InvalidCastException_t91DF9E7D7FCCDA6C562CB4A9A18903E016680FDA * L_12 = (InvalidCastException_t91DF9E7D7FCCDA6C562CB4A9A18903E016680FDA *)il2cpp_codegen_object_new(InvalidCastException_t91DF9E7D7FCCDA6C562CB4A9A18903E016680FDA_il2cpp_TypeInfo_var);
		InvalidCastException__ctor_mB14CE363FB346D9BC0C0763CAF0B67AF90902144(L_12, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_12, NULL, SqliteKeyReader_GetBoolean_mF164552CBD10F49417C97F7FFF3454143AFE536C_RuntimeMethod_var);
	}
}
// System.Int32 Mono.Data.Sqlite.SqliteKeyReader::GetInt32(System.Int32)
extern "C" IL2CPP_METHOD_ATTR int32_t SqliteKeyReader_GetInt32_m57C62C425E04BA112B42914E60A88E0BA147710F (SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793 * __this, int32_t ___i0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteKeyReader_GetInt32_m57C62C425E04BA112B42914E60A88E0BA147710F_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int64_t V_0 = 0;
	{
		int32_t L_0 = ___i0;
		SqliteKeyReader_Sync_mF6A76D7FF2131664DCAFC47426C77959060A7560(__this, L_0, /*hidden argument*/NULL);
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_1 = __this->get__keyInfo_0();
		int32_t L_2 = ___i0;
		NullCheck(L_1);
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_3 = ((L_1)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_2)))->get_query_6();
		if (!L_3)
		{
			goto IL_004a;
		}
	}
	{
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_4 = __this->get__keyInfo_0();
		int32_t L_5 = ___i0;
		NullCheck(L_4);
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_6 = ((L_4)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_5)))->get_query_6();
		NullCheck(L_6);
		SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * L_7 = L_6->get__reader_1();
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_8 = __this->get__keyInfo_0();
		int32_t L_9 = ___i0;
		NullCheck(L_8);
		int32_t L_10 = ((L_8)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_9)))->get_column_7();
		NullCheck(L_7);
		int32_t L_11 = SqliteDataReader_GetInt32_m4A41300087F430F13D90A6F70C66D13DBBC0D7BC(L_7, L_10, /*hidden argument*/NULL);
		return L_11;
	}

IL_004a:
	{
		SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * L_12 = __this->get__stmt_1();
		NullCheck(L_12);
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_13 = L_12->get__sql_0();
		SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * L_14 = __this->get__stmt_1();
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_15 = __this->get__keyInfo_0();
		int32_t L_16 = ___i0;
		NullCheck(L_15);
		int32_t L_17 = ((L_15)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_16)))->get_cursor_5();
		NullCheck(L_13);
		int64_t L_18 = VirtFuncInvoker2< int64_t, SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A *, int32_t >::Invoke(59 /* System.Int64 Mono.Data.Sqlite.SQLiteBase::GetRowIdForCursor(Mono.Data.Sqlite.SqliteStatement,System.Int32) */, L_13, L_14, L_17);
		V_0 = L_18;
		int64_t L_19 = V_0;
		if (L_19)
		{
			goto IL_007e;
		}
	}
	{
		InvalidCastException_t91DF9E7D7FCCDA6C562CB4A9A18903E016680FDA * L_20 = (InvalidCastException_t91DF9E7D7FCCDA6C562CB4A9A18903E016680FDA *)il2cpp_codegen_object_new(InvalidCastException_t91DF9E7D7FCCDA6C562CB4A9A18903E016680FDA_il2cpp_TypeInfo_var);
		InvalidCastException__ctor_mB14CE363FB346D9BC0C0763CAF0B67AF90902144(L_20, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_20, NULL, SqliteKeyReader_GetInt32_m57C62C425E04BA112B42914E60A88E0BA147710F_RuntimeMethod_var);
	}

IL_007e:
	{
		int64_t L_21 = V_0;
		IL2CPP_RUNTIME_CLASS_INIT(Convert_t1C7A851BFB2F0782FD7F72F6AA1DCBB7B53A9C7E_il2cpp_TypeInfo_var);
		int32_t L_22 = Convert_ToInt32_m5CE30569A0A5B70CBD85954BEEF436F57D6FAE6B(L_21, /*hidden argument*/NULL);
		return L_22;
	}
}
// System.Int64 Mono.Data.Sqlite.SqliteKeyReader::GetInt64(System.Int32)
extern "C" IL2CPP_METHOD_ATTR int64_t SqliteKeyReader_GetInt64_m88F6AC8A38D351C10514E8BE8A6EC30F819C833A (SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793 * __this, int32_t ___i0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteKeyReader_GetInt64_m88F6AC8A38D351C10514E8BE8A6EC30F819C833A_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int64_t V_0 = 0;
	{
		int32_t L_0 = ___i0;
		SqliteKeyReader_Sync_mF6A76D7FF2131664DCAFC47426C77959060A7560(__this, L_0, /*hidden argument*/NULL);
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_1 = __this->get__keyInfo_0();
		int32_t L_2 = ___i0;
		NullCheck(L_1);
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_3 = ((L_1)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_2)))->get_query_6();
		if (!L_3)
		{
			goto IL_004a;
		}
	}
	{
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_4 = __this->get__keyInfo_0();
		int32_t L_5 = ___i0;
		NullCheck(L_4);
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_6 = ((L_4)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_5)))->get_query_6();
		NullCheck(L_6);
		SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * L_7 = L_6->get__reader_1();
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_8 = __this->get__keyInfo_0();
		int32_t L_9 = ___i0;
		NullCheck(L_8);
		int32_t L_10 = ((L_8)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_9)))->get_column_7();
		NullCheck(L_7);
		int64_t L_11 = SqliteDataReader_GetInt64_mB9CF2BD85015CC2B72606BF77CA66CD2E0184C56(L_7, L_10, /*hidden argument*/NULL);
		return L_11;
	}

IL_004a:
	{
		SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * L_12 = __this->get__stmt_1();
		NullCheck(L_12);
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_13 = L_12->get__sql_0();
		SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * L_14 = __this->get__stmt_1();
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_15 = __this->get__keyInfo_0();
		int32_t L_16 = ___i0;
		NullCheck(L_15);
		int32_t L_17 = ((L_15)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_16)))->get_cursor_5();
		NullCheck(L_13);
		int64_t L_18 = VirtFuncInvoker2< int64_t, SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A *, int32_t >::Invoke(59 /* System.Int64 Mono.Data.Sqlite.SQLiteBase::GetRowIdForCursor(Mono.Data.Sqlite.SqliteStatement,System.Int32) */, L_13, L_14, L_17);
		V_0 = L_18;
		int64_t L_19 = V_0;
		if (L_19)
		{
			goto IL_007e;
		}
	}
	{
		InvalidCastException_t91DF9E7D7FCCDA6C562CB4A9A18903E016680FDA * L_20 = (InvalidCastException_t91DF9E7D7FCCDA6C562CB4A9A18903E016680FDA *)il2cpp_codegen_object_new(InvalidCastException_t91DF9E7D7FCCDA6C562CB4A9A18903E016680FDA_il2cpp_TypeInfo_var);
		InvalidCastException__ctor_mB14CE363FB346D9BC0C0763CAF0B67AF90902144(L_20, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_20, NULL, SqliteKeyReader_GetInt64_m88F6AC8A38D351C10514E8BE8A6EC30F819C833A_RuntimeMethod_var);
	}

IL_007e:
	{
		int64_t L_21 = V_0;
		IL2CPP_RUNTIME_CLASS_INIT(Convert_t1C7A851BFB2F0782FD7F72F6AA1DCBB7B53A9C7E_il2cpp_TypeInfo_var);
		int64_t L_22 = Convert_ToInt64_mA01BFA4EFA523B93F48D03811D44AE225059E0AD(L_21, /*hidden argument*/NULL);
		return L_22;
	}
}
// System.String Mono.Data.Sqlite.SqliteKeyReader::GetString(System.Int32)
extern "C" IL2CPP_METHOD_ATTR String_t* SqliteKeyReader_GetString_m14BF706D0E90330C84A3F322D435728903F5EF46 (SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793 * __this, int32_t ___i0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteKeyReader_GetString_m14BF706D0E90330C84A3F322D435728903F5EF46_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		int32_t L_0 = ___i0;
		SqliteKeyReader_Sync_mF6A76D7FF2131664DCAFC47426C77959060A7560(__this, L_0, /*hidden argument*/NULL);
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_1 = __this->get__keyInfo_0();
		int32_t L_2 = ___i0;
		NullCheck(L_1);
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_3 = ((L_1)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_2)))->get_query_6();
		if (!L_3)
		{
			goto IL_004a;
		}
	}
	{
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_4 = __this->get__keyInfo_0();
		int32_t L_5 = ___i0;
		NullCheck(L_4);
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_6 = ((L_4)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_5)))->get_query_6();
		NullCheck(L_6);
		SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * L_7 = L_6->get__reader_1();
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_8 = __this->get__keyInfo_0();
		int32_t L_9 = ___i0;
		NullCheck(L_8);
		int32_t L_10 = ((L_8)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_9)))->get_column_7();
		NullCheck(L_7);
		String_t* L_11 = SqliteDataReader_GetString_mF6D7C833507ADBE616334F91ABE7E3B73609042E(L_7, L_10, /*hidden argument*/NULL);
		return L_11;
	}

IL_004a:
	{
		InvalidCastException_t91DF9E7D7FCCDA6C562CB4A9A18903E016680FDA * L_12 = (InvalidCastException_t91DF9E7D7FCCDA6C562CB4A9A18903E016680FDA *)il2cpp_codegen_object_new(InvalidCastException_t91DF9E7D7FCCDA6C562CB4A9A18903E016680FDA_il2cpp_TypeInfo_var);
		InvalidCastException__ctor_mB14CE363FB346D9BC0C0763CAF0B67AF90902144(L_12, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_12, NULL, SqliteKeyReader_GetString_m14BF706D0E90330C84A3F322D435728903F5EF46_RuntimeMethod_var);
	}
}
// System.Object Mono.Data.Sqlite.SqliteKeyReader::GetValue(System.Int32)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * SqliteKeyReader_GetValue_mF018DD89A0AC47D114E3174A9D7477237046E8A8 (SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793 * __this, int32_t ___i0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteKeyReader_GetValue_mF018DD89A0AC47D114E3174A9D7477237046E8A8_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_0 = __this->get__keyInfo_0();
		int32_t L_1 = ___i0;
		NullCheck(L_0);
		int32_t L_2 = ((L_0)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_1)))->get_cursor_5();
		if ((!(((uint32_t)L_2) == ((uint32_t)(-1)))))
		{
			goto IL_001d;
		}
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(DBNull_t7400E04939C2C29699B389B106997892BF53A8E5_il2cpp_TypeInfo_var);
		DBNull_t7400E04939C2C29699B389B106997892BF53A8E5 * L_3 = ((DBNull_t7400E04939C2C29699B389B106997892BF53A8E5_StaticFields*)il2cpp_codegen_static_fields_for(DBNull_t7400E04939C2C29699B389B106997892BF53A8E5_il2cpp_TypeInfo_var))->get_Value_0();
		return L_3;
	}

IL_001d:
	{
		int32_t L_4 = ___i0;
		SqliteKeyReader_Sync_mF6A76D7FF2131664DCAFC47426C77959060A7560(__this, L_4, /*hidden argument*/NULL);
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_5 = __this->get__keyInfo_0();
		int32_t L_6 = ___i0;
		NullCheck(L_5);
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_7 = ((L_5)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_6)))->get_query_6();
		if (!L_7)
		{
			goto IL_0067;
		}
	}
	{
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_8 = __this->get__keyInfo_0();
		int32_t L_9 = ___i0;
		NullCheck(L_8);
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_10 = ((L_8)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_9)))->get_query_6();
		NullCheck(L_10);
		SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * L_11 = L_10->get__reader_1();
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_12 = __this->get__keyInfo_0();
		int32_t L_13 = ___i0;
		NullCheck(L_12);
		int32_t L_14 = ((L_12)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_13)))->get_column_7();
		NullCheck(L_11);
		RuntimeObject * L_15 = SqliteDataReader_GetValue_mE4F5C8119E84D78EDE732788C2185EC09672F2D0(L_11, L_14, /*hidden argument*/NULL);
		return L_15;
	}

IL_0067:
	{
		int32_t L_16 = ___i0;
		bool L_17 = SqliteKeyReader_IsDBNull_m0C44B5BED117982D60E7307BF4F0EE3CD96BE3E1(__this, L_16, /*hidden argument*/NULL);
		if (!L_17)
		{
			goto IL_0079;
		}
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(DBNull_t7400E04939C2C29699B389B106997892BF53A8E5_il2cpp_TypeInfo_var);
		DBNull_t7400E04939C2C29699B389B106997892BF53A8E5 * L_18 = ((DBNull_t7400E04939C2C29699B389B106997892BF53A8E5_StaticFields*)il2cpp_codegen_static_fields_for(DBNull_t7400E04939C2C29699B389B106997892BF53A8E5_il2cpp_TypeInfo_var))->get_Value_0();
		return L_18;
	}

IL_0079:
	{
		int32_t L_19 = ___i0;
		int64_t L_20 = SqliteKeyReader_GetInt64_m88F6AC8A38D351C10514E8BE8A6EC30F819C833A(__this, L_19, /*hidden argument*/NULL);
		int64_t L_21 = L_20;
		RuntimeObject * L_22 = Box(Int64_t7A386C2FF7B0280A0F516992401DDFCF0FF7B436_il2cpp_TypeInfo_var, &L_21);
		return L_22;
	}
}
// System.Boolean Mono.Data.Sqlite.SqliteKeyReader::IsDBNull(System.Int32)
extern "C" IL2CPP_METHOD_ATTR bool SqliteKeyReader_IsDBNull_m0C44B5BED117982D60E7307BF4F0EE3CD96BE3E1 (SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793 * __this, int32_t ___i0, const RuntimeMethod* method)
{
	{
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_0 = __this->get__keyInfo_0();
		int32_t L_1 = ___i0;
		NullCheck(L_0);
		int32_t L_2 = ((L_0)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_1)))->get_cursor_5();
		if ((!(((uint32_t)L_2) == ((uint32_t)(-1)))))
		{
			goto IL_0019;
		}
	}
	{
		return (bool)1;
	}

IL_0019:
	{
		int32_t L_3 = ___i0;
		SqliteKeyReader_Sync_mF6A76D7FF2131664DCAFC47426C77959060A7560(__this, L_3, /*hidden argument*/NULL);
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_4 = __this->get__keyInfo_0();
		int32_t L_5 = ___i0;
		NullCheck(L_4);
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_6 = ((L_4)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_5)))->get_query_6();
		if (!L_6)
		{
			goto IL_0063;
		}
	}
	{
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_7 = __this->get__keyInfo_0();
		int32_t L_8 = ___i0;
		NullCheck(L_7);
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_9 = ((L_7)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_8)))->get_query_6();
		NullCheck(L_9);
		SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * L_10 = L_9->get__reader_1();
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_11 = __this->get__keyInfo_0();
		int32_t L_12 = ___i0;
		NullCheck(L_11);
		int32_t L_13 = ((L_11)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_12)))->get_column_7();
		NullCheck(L_10);
		bool L_14 = SqliteDataReader_IsDBNull_m3B0ECC6EBCB6C8B1D98546F0D21B7A3DF7068B93(L_10, L_13, /*hidden argument*/NULL);
		return L_14;
	}

IL_0063:
	{
		SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * L_15 = __this->get__stmt_1();
		NullCheck(L_15);
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_16 = L_15->get__sql_0();
		SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * L_17 = __this->get__stmt_1();
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_18 = __this->get__keyInfo_0();
		int32_t L_19 = ___i0;
		NullCheck(L_18);
		int32_t L_20 = ((L_18)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_19)))->get_cursor_5();
		NullCheck(L_16);
		int64_t L_21 = VirtFuncInvoker2< int64_t, SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A *, int32_t >::Invoke(59 /* System.Int64 Mono.Data.Sqlite.SQLiteBase::GetRowIdForCursor(Mono.Data.Sqlite.SqliteStatement,System.Int32) */, L_16, L_17, L_20);
		return (bool)((((int64_t)L_21) == ((int64_t)(((int64_t)((int64_t)0)))))? 1 : 0);
	}
}
// System.Void Mono.Data.Sqlite.SqliteKeyReader::AppendSchemaTable(System.Data.DataTable)
extern "C" IL2CPP_METHOD_ATTR void SqliteKeyReader_AppendSchemaTable_m0245FED7609ADB0AE58ADF42A24846C32EE49950 (SqliteKeyReader_tC0002952AB7EB62BFBAEEF16DF6A3E8D4FD62793 * __this, DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * ___tbl0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteKeyReader_AppendSchemaTable_m0245FED7609ADB0AE58ADF42A24846C32EE49950_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * V_0 = NULL;
	int32_t V_1 = 0;
	DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * V_2 = NULL;
	DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * V_3 = NULL;
	DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * V_4 = NULL;
	RuntimeObject* V_5 = NULL;
	ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* V_6 = NULL;
	DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * V_7 = NULL;
	RuntimeObject* V_8 = NULL;
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	void* __leave_targets_storage = alloca(sizeof(int32_t) * 2);
	il2cpp::utils::LeaveTargetStack __leave_targets(__leave_targets_storage);
	NO_UNUSED_WARNING (__leave_targets);
	{
		V_0 = (KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 *)NULL;
		V_1 = 0;
		goto IL_02c6;
	}

IL_0009:
	{
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_0 = __this->get__keyInfo_0();
		int32_t L_1 = V_1;
		NullCheck(L_0);
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_2 = ((L_0)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_1)))->get_query_6();
		if (!L_2)
		{
			goto IL_0036;
		}
	}
	{
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_3 = __this->get__keyInfo_0();
		int32_t L_4 = V_1;
		NullCheck(L_3);
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_5 = ((L_3)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_4)))->get_query_6();
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_6 = V_0;
		if ((((RuntimeObject*)(KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 *)L_5) == ((RuntimeObject*)(KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 *)L_6)))
		{
			goto IL_02c2;
		}
	}

IL_0036:
	{
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_7 = __this->get__keyInfo_0();
		int32_t L_8 = V_1;
		NullCheck(L_7);
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_9 = ((L_7)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_8)))->get_query_6();
		V_0 = L_9;
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_10 = V_0;
		if (L_10)
		{
			goto IL_020d;
		}
	}
	{
		DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_11 = ___tbl0;
		NullCheck(L_11);
		DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_12 = DataTable_NewRow_m74E2026105B65A19E657631DDAC31916F004CBF1(L_11, /*hidden argument*/NULL);
		V_2 = L_12;
		DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_13 = V_2;
		IL2CPP_RUNTIME_CLASS_INIT(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_il2cpp_TypeInfo_var);
		String_t* L_14 = ((SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_il2cpp_TypeInfo_var))->get_ColumnName_0();
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_15 = __this->get__keyInfo_0();
		int32_t L_16 = V_1;
		NullCheck(L_15);
		String_t* L_17 = ((L_15)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_16)))->get_columnName_2();
		NullCheck(L_13);
		DataRow_set_Item_m4AA7DFBB5987AECF475E177F56FFBA95CF6CFFA2(L_13, L_14, L_17, /*hidden argument*/NULL);
		DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_18 = V_2;
		String_t* L_19 = ((SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_il2cpp_TypeInfo_var))->get_ColumnOrdinal_1();
		DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_20 = ___tbl0;
		NullCheck(L_20);
		DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0 * L_21 = DataTable_get_Rows_m905B0636C268095F62E08B89B97A034E6BC483D3(L_20, /*hidden argument*/NULL);
		NullCheck(L_21);
		int32_t L_22 = DataRowCollection_get_Count_mA4B1179424DF0637C1E85C2148055F8035E0B1DA(L_21, /*hidden argument*/NULL);
		int32_t L_23 = L_22;
		RuntimeObject * L_24 = Box(Int32_t585191389E07734F19F3156FF88FB3EF4800D102_il2cpp_TypeInfo_var, &L_23);
		NullCheck(L_18);
		DataRow_set_Item_m4AA7DFBB5987AECF475E177F56FFBA95CF6CFFA2(L_18, L_19, L_24, /*hidden argument*/NULL);
		DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_25 = V_2;
		String_t* L_26 = ((SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_il2cpp_TypeInfo_var))->get_ColumnSize_2();
		int32_t L_27 = 8;
		RuntimeObject * L_28 = Box(Int32_t585191389E07734F19F3156FF88FB3EF4800D102_il2cpp_TypeInfo_var, &L_27);
		NullCheck(L_25);
		DataRow_set_Item_m4AA7DFBB5987AECF475E177F56FFBA95CF6CFFA2(L_25, L_26, L_28, /*hidden argument*/NULL);
		DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_29 = V_2;
		String_t* L_30 = ((SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_il2cpp_TypeInfo_var))->get_NumericPrecision_3();
		int32_t L_31 = ((int32_t)255);
		RuntimeObject * L_32 = Box(Int32_t585191389E07734F19F3156FF88FB3EF4800D102_il2cpp_TypeInfo_var, &L_31);
		NullCheck(L_29);
		DataRow_set_Item_m4AA7DFBB5987AECF475E177F56FFBA95CF6CFFA2(L_29, L_30, L_32, /*hidden argument*/NULL);
		DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_33 = V_2;
		String_t* L_34 = ((SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_il2cpp_TypeInfo_var))->get_NumericScale_4();
		int32_t L_35 = ((int32_t)255);
		RuntimeObject * L_36 = Box(Int32_t585191389E07734F19F3156FF88FB3EF4800D102_il2cpp_TypeInfo_var, &L_35);
		NullCheck(L_33);
		DataRow_set_Item_m4AA7DFBB5987AECF475E177F56FFBA95CF6CFFA2(L_33, L_34, L_36, /*hidden argument*/NULL);
		DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_37 = V_2;
		String_t* L_38 = ((SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_il2cpp_TypeInfo_var))->get_ProviderType_6();
		int32_t L_39 = ((int32_t)((int32_t)12));
		RuntimeObject * L_40 = Box(DbType_t46DC393C53E0CB52DF1792FD357A7E596C5F432E_il2cpp_TypeInfo_var, &L_39);
		NullCheck(L_37);
		DataRow_set_Item_m4AA7DFBB5987AECF475E177F56FFBA95CF6CFFA2(L_37, L_38, L_40, /*hidden argument*/NULL);
		DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_41 = V_2;
		String_t* L_42 = ((SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_il2cpp_TypeInfo_var))->get_IsLong_8();
		bool L_43 = ((bool)0);
		RuntimeObject * L_44 = Box(Boolean_tB53F6830F670160873277339AA58F15CAED4399C_il2cpp_TypeInfo_var, &L_43);
		NullCheck(L_41);
		DataRow_set_Item_m4AA7DFBB5987AECF475E177F56FFBA95CF6CFFA2(L_41, L_42, L_44, /*hidden argument*/NULL);
		DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_45 = V_2;
		String_t* L_46 = ((SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_il2cpp_TypeInfo_var))->get_AllowDBNull_9();
		bool L_47 = ((bool)0);
		RuntimeObject * L_48 = Box(Boolean_tB53F6830F670160873277339AA58F15CAED4399C_il2cpp_TypeInfo_var, &L_47);
		NullCheck(L_45);
		DataRow_set_Item_m4AA7DFBB5987AECF475E177F56FFBA95CF6CFFA2(L_45, L_46, L_48, /*hidden argument*/NULL);
		DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_49 = V_2;
		IL2CPP_RUNTIME_CLASS_INIT(SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_il2cpp_TypeInfo_var);
		String_t* L_50 = ((SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_il2cpp_TypeInfo_var))->get_IsReadOnly_3();
		bool L_51 = ((bool)0);
		RuntimeObject * L_52 = Box(Boolean_tB53F6830F670160873277339AA58F15CAED4399C_il2cpp_TypeInfo_var, &L_51);
		NullCheck(L_49);
		DataRow_set_Item_m4AA7DFBB5987AECF475E177F56FFBA95CF6CFFA2(L_49, L_50, L_52, /*hidden argument*/NULL);
		DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_53 = V_2;
		String_t* L_54 = ((SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_il2cpp_TypeInfo_var))->get_IsRowVersion_4();
		bool L_55 = ((bool)0);
		RuntimeObject * L_56 = Box(Boolean_tB53F6830F670160873277339AA58F15CAED4399C_il2cpp_TypeInfo_var, &L_55);
		NullCheck(L_53);
		DataRow_set_Item_m4AA7DFBB5987AECF475E177F56FFBA95CF6CFFA2(L_53, L_54, L_56, /*hidden argument*/NULL);
		DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_57 = V_2;
		String_t* L_58 = ((SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_il2cpp_TypeInfo_var))->get_IsUnique_13();
		bool L_59 = ((bool)0);
		RuntimeObject * L_60 = Box(Boolean_tB53F6830F670160873277339AA58F15CAED4399C_il2cpp_TypeInfo_var, &L_59);
		NullCheck(L_57);
		DataRow_set_Item_m4AA7DFBB5987AECF475E177F56FFBA95CF6CFFA2(L_57, L_58, L_60, /*hidden argument*/NULL);
		DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_61 = V_2;
		String_t* L_62 = ((SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_il2cpp_TypeInfo_var))->get_IsKey_12();
		bool L_63 = ((bool)1);
		RuntimeObject * L_64 = Box(Boolean_tB53F6830F670160873277339AA58F15CAED4399C_il2cpp_TypeInfo_var, &L_63);
		NullCheck(L_61);
		DataRow_set_Item_m4AA7DFBB5987AECF475E177F56FFBA95CF6CFFA2(L_61, L_62, L_64, /*hidden argument*/NULL);
		DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_65 = V_2;
		String_t* L_66 = ((SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_il2cpp_TypeInfo_var))->get_DataType_5();
		RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  L_67 = { reinterpret_cast<intptr_t> (Int64_t7A386C2FF7B0280A0F516992401DDFCF0FF7B436_0_0_0_var) };
		IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
		Type_t * L_68 = Type_GetTypeFromHandle_m9DC58ADF0512987012A8A016FB64B068F3B1AFF6(L_67, /*hidden argument*/NULL);
		NullCheck(L_65);
		DataRow_set_Item_m4AA7DFBB5987AECF475E177F56FFBA95CF6CFFA2(L_65, L_66, L_68, /*hidden argument*/NULL);
		DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_69 = V_2;
		String_t* L_70 = ((SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_il2cpp_TypeInfo_var))->get_IsHidden_2();
		bool L_71 = ((bool)1);
		RuntimeObject * L_72 = Box(Boolean_tB53F6830F670160873277339AA58F15CAED4399C_il2cpp_TypeInfo_var, &L_71);
		NullCheck(L_69);
		DataRow_set_Item_m4AA7DFBB5987AECF475E177F56FFBA95CF6CFFA2(L_69, L_70, L_72, /*hidden argument*/NULL);
		DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_73 = V_2;
		String_t* L_74 = ((SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_il2cpp_TypeInfo_var))->get_BaseColumnName_16();
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_75 = __this->get__keyInfo_0();
		int32_t L_76 = V_1;
		NullCheck(L_75);
		String_t* L_77 = ((L_75)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_76)))->get_columnName_2();
		NullCheck(L_73);
		DataRow_set_Item_m4AA7DFBB5987AECF475E177F56FFBA95CF6CFFA2(L_73, L_74, L_77, /*hidden argument*/NULL);
		DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_78 = V_2;
		String_t* L_79 = ((SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_il2cpp_TypeInfo_var))->get_IsExpression_11();
		bool L_80 = ((bool)0);
		RuntimeObject * L_81 = Box(Boolean_tB53F6830F670160873277339AA58F15CAED4399C_il2cpp_TypeInfo_var, &L_80);
		NullCheck(L_78);
		DataRow_set_Item_m4AA7DFBB5987AECF475E177F56FFBA95CF6CFFA2(L_78, L_79, L_81, /*hidden argument*/NULL);
		DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_82 = V_2;
		String_t* L_83 = ((SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_il2cpp_TypeInfo_var))->get_IsAliased_10();
		bool L_84 = ((bool)0);
		RuntimeObject * L_85 = Box(Boolean_tB53F6830F670160873277339AA58F15CAED4399C_il2cpp_TypeInfo_var, &L_84);
		NullCheck(L_82);
		DataRow_set_Item_m4AA7DFBB5987AECF475E177F56FFBA95CF6CFFA2(L_82, L_83, L_85, /*hidden argument*/NULL);
		DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_86 = V_2;
		String_t* L_87 = ((SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_il2cpp_TypeInfo_var))->get_BaseTableName_15();
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_88 = __this->get__keyInfo_0();
		int32_t L_89 = V_1;
		NullCheck(L_88);
		String_t* L_90 = ((L_88)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_89)))->get_tableName_1();
		NullCheck(L_86);
		DataRow_set_Item_m4AA7DFBB5987AECF475E177F56FFBA95CF6CFFA2(L_86, L_87, L_90, /*hidden argument*/NULL);
		DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_91 = V_2;
		String_t* L_92 = ((SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_il2cpp_TypeInfo_var))->get_BaseCatalogName_6();
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_93 = __this->get__keyInfo_0();
		int32_t L_94 = V_1;
		NullCheck(L_93);
		String_t* L_95 = ((L_93)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_94)))->get_databaseName_0();
		NullCheck(L_91);
		DataRow_set_Item_m4AA7DFBB5987AECF475E177F56FFBA95CF6CFFA2(L_91, L_92, L_95, /*hidden argument*/NULL);
		DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_96 = V_2;
		String_t* L_97 = ((SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_il2cpp_TypeInfo_var))->get_IsAutoIncrement_1();
		bool L_98 = ((bool)1);
		RuntimeObject * L_99 = Box(Boolean_tB53F6830F670160873277339AA58F15CAED4399C_il2cpp_TypeInfo_var, &L_98);
		NullCheck(L_96);
		DataRow_set_Item_m4AA7DFBB5987AECF475E177F56FFBA95CF6CFFA2(L_96, L_97, L_99, /*hidden argument*/NULL);
		DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_100 = V_2;
		NullCheck(L_100);
		DataRow_set_Item_m4AA7DFBB5987AECF475E177F56FFBA95CF6CFFA2(L_100, _stringLiteral66D2C601FBFA7B406B77381952D6A78FC0BD2564, _stringLiteral1178CAFBD64BBBFA77F5AC0A9D5032ED88162781, /*hidden argument*/NULL);
		DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_101 = ___tbl0;
		NullCheck(L_101);
		DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0 * L_102 = DataTable_get_Rows_m905B0636C268095F62E08B89B97A034E6BC483D3(L_101, /*hidden argument*/NULL);
		DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_103 = V_2;
		NullCheck(L_102);
		DataRowCollection_Add_mD58F34C8E5D4FD55D6CEFA56F121935E467C11F6(L_102, L_103, /*hidden argument*/NULL);
		goto IL_02c2;
	}

IL_020d:
	{
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_104 = V_0;
		NullCheck(L_104);
		KeyQuery_Sync_m19A2575566EEFC07F5FC36F2E200FA23EE8A7390(L_104, (((int64_t)((int64_t)0))), /*hidden argument*/NULL);
		KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * L_105 = V_0;
		NullCheck(L_105);
		SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * L_106 = L_105->get__reader_1();
		NullCheck(L_106);
		DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_107 = SqliteDataReader_GetSchemaTable_mEA3BE5A6DCD68BC32D7F0D30A57DA5177F96E33A(L_106, /*hidden argument*/NULL);
		V_3 = L_107;
	}

IL_0221:
	try
	{ // begin try (depth: 1)
		{
			DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_108 = V_3;
			NullCheck(L_108);
			DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0 * L_109 = DataTable_get_Rows_m905B0636C268095F62E08B89B97A034E6BC483D3(L_108, /*hidden argument*/NULL);
			NullCheck(L_109);
			RuntimeObject* L_110 = VirtFuncInvoker0< RuntimeObject* >::Invoke(11 /* System.Collections.IEnumerator System.Data.InternalDataCollectionBase::GetEnumerator() */, L_109);
			V_5 = L_110;
		}

IL_022e:
		try
		{ // begin try (depth: 2)
			{
				goto IL_0289;
			}

IL_0233:
			{
				RuntimeObject* L_111 = V_5;
				NullCheck(L_111);
				RuntimeObject * L_112 = InterfaceFuncInvoker0< RuntimeObject * >::Invoke(1 /* System.Object System.Collections.IEnumerator::get_Current() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_111);
				V_4 = ((DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B *)CastclassClass((RuntimeObject*)L_112, DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B_il2cpp_TypeInfo_var));
				DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_113 = V_4;
				NullCheck(L_113);
				ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* L_114 = DataRow_get_ItemArray_mABB1F804FE8BDE1C715C2609EBE1DC7E9668C2E7(L_113, /*hidden argument*/NULL);
				V_6 = L_114;
				DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_115 = ___tbl0;
				NullCheck(L_115);
				DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0 * L_116 = DataTable_get_Rows_m905B0636C268095F62E08B89B97A034E6BC483D3(L_115, /*hidden argument*/NULL);
				ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* L_117 = V_6;
				NullCheck(L_116);
				DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_118 = DataRowCollection_Add_mE9B4B34E992D02D8E1A859F2EB1FD2706B801983(L_116, L_117, /*hidden argument*/NULL);
				V_7 = L_118;
				DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_119 = V_7;
				IL2CPP_RUNTIME_CLASS_INIT(SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_il2cpp_TypeInfo_var);
				String_t* L_120 = ((SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableOptionalColumn_tBC4CD61B4F81E81AD54682A2A4A196ADD3720F93_il2cpp_TypeInfo_var))->get_IsHidden_2();
				bool L_121 = ((bool)1);
				RuntimeObject * L_122 = Box(Boolean_tB53F6830F670160873277339AA58F15CAED4399C_il2cpp_TypeInfo_var, &L_121);
				NullCheck(L_119);
				DataRow_set_Item_m4AA7DFBB5987AECF475E177F56FFBA95CF6CFFA2(L_119, L_120, L_122, /*hidden argument*/NULL);
				DataRow_tA8B1DC99E8A5582204ADB7122DD4C63A0CAF8D2B * L_123 = V_7;
				IL2CPP_RUNTIME_CLASS_INIT(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_il2cpp_TypeInfo_var);
				String_t* L_124 = ((SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_StaticFields*)il2cpp_codegen_static_fields_for(SchemaTableColumn_tBA9D4897119292BC737B937B41186DBFE71FFCCD_il2cpp_TypeInfo_var))->get_ColumnOrdinal_1();
				DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_125 = ___tbl0;
				NullCheck(L_125);
				DataRowCollection_t45B9FDFC3667C7FA9C0F7F14787B5ED70DC673E0 * L_126 = DataTable_get_Rows_m905B0636C268095F62E08B89B97A034E6BC483D3(L_125, /*hidden argument*/NULL);
				NullCheck(L_126);
				int32_t L_127 = DataRowCollection_get_Count_mA4B1179424DF0637C1E85C2148055F8035E0B1DA(L_126, /*hidden argument*/NULL);
				int32_t L_128 = ((int32_t)il2cpp_codegen_subtract((int32_t)L_127, (int32_t)1));
				RuntimeObject * L_129 = Box(Int32_t585191389E07734F19F3156FF88FB3EF4800D102_il2cpp_TypeInfo_var, &L_128);
				NullCheck(L_123);
				DataRow_set_Item_m4AA7DFBB5987AECF475E177F56FFBA95CF6CFFA2(L_123, L_124, L_129, /*hidden argument*/NULL);
			}

IL_0289:
			{
				RuntimeObject* L_130 = V_5;
				NullCheck(L_130);
				bool L_131 = InterfaceFuncInvoker0< bool >::Invoke(0 /* System.Boolean System.Collections.IEnumerator::MoveNext() */, IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A_il2cpp_TypeInfo_var, L_130);
				if (L_131)
				{
					goto IL_0233;
				}
			}

IL_0295:
			{
				IL2CPP_LEAVE(0x2B0, FINALLY_029a);
			}
		} // end try (depth: 2)
		catch(Il2CppExceptionWrapper& e)
		{
			__last_unhandled_exception = (Exception_t *)e.ex;
			goto FINALLY_029a;
		}

FINALLY_029a:
		{ // begin finally (depth: 2)
			{
				RuntimeObject* L_132 = V_5;
				V_8 = ((RuntimeObject*)IsInst((RuntimeObject*)L_132, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var));
				RuntimeObject* L_133 = V_8;
				if (L_133)
				{
					goto IL_02a8;
				}
			}

IL_02a7:
			{
				IL2CPP_END_FINALLY(666)
			}

IL_02a8:
			{
				RuntimeObject* L_134 = V_8;
				NullCheck(L_134);
				InterfaceActionInvoker0::Invoke(0 /* System.Void System.IDisposable::Dispose() */, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var, L_134);
				IL2CPP_END_FINALLY(666)
			}
		} // end finally (depth: 2)
		IL2CPP_CLEANUP(666)
		{
			IL2CPP_JUMP_TBL(0x2B0, IL_02b0)
			IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
		}

IL_02b0:
		{
			IL2CPP_LEAVE(0x2C2, FINALLY_02b5);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_02b5;
	}

FINALLY_02b5:
	{ // begin finally (depth: 1)
		{
			DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_135 = V_3;
			if (!L_135)
			{
				goto IL_02c1;
			}
		}

IL_02bb:
		{
			DataTable_t44D8846CCB9E2EAE485EB76A1194CF55EC3ED863 * L_136 = V_3;
			NullCheck(L_136);
			InterfaceActionInvoker0::Invoke(0 /* System.Void System.IDisposable::Dispose() */, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var, L_136);
		}

IL_02c1:
		{
			IL2CPP_END_FINALLY(693)
		}
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(693)
	{
		IL2CPP_JUMP_TBL(0x2C2, IL_02c2)
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
	}

IL_02c2:
	{
		int32_t L_137 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add((int32_t)L_137, (int32_t)1));
	}

IL_02c6:
	{
		int32_t L_138 = V_1;
		KeyInfoU5BU5D_t9D7A2D65507EA5B4FE10F3820356BD06F5E800C4* L_139 = __this->get__keyInfo_0();
		NullCheck(L_139);
		if ((((int32_t)L_138) < ((int32_t)(((int32_t)((int32_t)(((RuntimeArray *)L_139)->max_length)))))))
		{
			goto IL_0009;
		}
	}
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
// Conversion methods for marshalling of: Mono.Data.Sqlite.SqliteKeyReader/KeyInfo
extern "C" void KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC_marshal_pinvoke(const KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC& unmarshaled, KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC_marshaled_pinvoke& marshaled)
{
	Exception_t* ___query_6Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'query' of type 'KeyInfo': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___query_6Exception, NULL, NULL);
}
extern "C" void KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC_marshal_pinvoke_back(const KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC_marshaled_pinvoke& marshaled, KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC& unmarshaled)
{
	Exception_t* ___query_6Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'query' of type 'KeyInfo': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___query_6Exception, NULL, NULL);
}
// Conversion method for clean up from marshalling of: Mono.Data.Sqlite.SqliteKeyReader/KeyInfo
extern "C" void KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC_marshal_pinvoke_cleanup(KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC_marshaled_pinvoke& marshaled)
{
}
// Conversion methods for marshalling of: Mono.Data.Sqlite.SqliteKeyReader/KeyInfo
extern "C" void KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC_marshal_com(const KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC& unmarshaled, KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC_marshaled_com& marshaled)
{
	Exception_t* ___query_6Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'query' of type 'KeyInfo': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___query_6Exception, NULL, NULL);
}
extern "C" void KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC_marshal_com_back(const KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC_marshaled_com& marshaled, KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC& unmarshaled)
{
	Exception_t* ___query_6Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'query' of type 'KeyInfo': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___query_6Exception, NULL, NULL);
}
// Conversion method for clean up from marshalling of: Mono.Data.Sqlite.SqliteKeyReader/KeyInfo
extern "C" void KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC_marshal_com_cleanup(KeyInfo_tE5FC024B7C6507C910292D7D1B2A8D6B43E123AC_marshaled_com& marshaled)
{
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void Mono.Data.Sqlite.SqliteKeyReader_KeyQuery::.ctor(Mono.Data.Sqlite.SqliteConnection,System.String,System.String,System.String[])
extern "C" IL2CPP_METHOD_ATTR void KeyQuery__ctor_m3095086FBBB97A6899ED7F47A9F349AC1D767E83 (KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * __this, SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * ___cnn0, String_t* ___database1, String_t* ___table2, StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* ___columns3, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (KeyQuery__ctor_m3095086FBBB97A6899ED7F47A9F349AC1D767E83_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	SqliteCommandBuilder_tB1BC265E1A177F0CEC2518E29F44C25E6CFBFB64 * V_0 = NULL;
	int32_t V_1 = 0;
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	void* __leave_targets_storage = alloca(sizeof(int32_t) * 1);
	il2cpp::utils::LeaveTargetStack __leave_targets(__leave_targets_storage);
	NO_UNUSED_WARNING (__leave_targets);
	{
		Object__ctor_m925ECA5E85CA100E3FB86A4F9E15C120E9A184C0(__this, /*hidden argument*/NULL);
		SqliteCommandBuilder_tB1BC265E1A177F0CEC2518E29F44C25E6CFBFB64 * L_0 = (SqliteCommandBuilder_tB1BC265E1A177F0CEC2518E29F44C25E6CFBFB64 *)il2cpp_codegen_object_new(SqliteCommandBuilder_tB1BC265E1A177F0CEC2518E29F44C25E6CFBFB64_il2cpp_TypeInfo_var);
		SqliteCommandBuilder__ctor_mA8D14724EECC99F7AD7AAA7C9118592DFF3EB74A(L_0, /*hidden argument*/NULL);
		V_0 = L_0;
	}

IL_000c:
	try
	{ // begin try (depth: 1)
		{
			SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * L_1 = ___cnn0;
			NullCheck(L_1);
			SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_2 = SqliteConnection_CreateCommand_mE54467D789E72E02161682F6456682545037F3A3(L_1, /*hidden argument*/NULL);
			__this->set__command_0(L_2);
			V_1 = 0;
			goto IL_0031;
		}

IL_001f:
		{
			StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_3 = ___columns3;
			int32_t L_4 = V_1;
			SqliteCommandBuilder_tB1BC265E1A177F0CEC2518E29F44C25E6CFBFB64 * L_5 = V_0;
			StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_6 = ___columns3;
			int32_t L_7 = V_1;
			NullCheck(L_6);
			int32_t L_8 = L_7;
			String_t* L_9 = (L_6)->GetAt(static_cast<il2cpp_array_size_t>(L_8));
			NullCheck(L_5);
			String_t* L_10 = SqliteCommandBuilder_QuoteIdentifier_m2358474CD04B0F7182251DF584B07F381DB1FC3C(L_5, L_9, /*hidden argument*/NULL);
			NullCheck(L_3);
			ArrayElementTypeCheck (L_3, L_10);
			(L_3)->SetAt(static_cast<il2cpp_array_size_t>(L_4), (String_t*)L_10);
			int32_t L_11 = V_1;
			V_1 = ((int32_t)il2cpp_codegen_add((int32_t)L_11, (int32_t)1));
		}

IL_0031:
		{
			int32_t L_12 = V_1;
			StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_13 = ___columns3;
			NullCheck(L_13);
			if ((((int32_t)L_12) < ((int32_t)(((int32_t)((int32_t)(((RuntimeArray *)L_13)->max_length)))))))
			{
				goto IL_001f;
			}
		}

IL_003b:
		{
			IL2CPP_LEAVE(0x4D, FINALLY_0040);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_0040;
	}

FINALLY_0040:
	{ // begin finally (depth: 1)
		{
			SqliteCommandBuilder_tB1BC265E1A177F0CEC2518E29F44C25E6CFBFB64 * L_14 = V_0;
			if (!L_14)
			{
				goto IL_004c;
			}
		}

IL_0046:
		{
			SqliteCommandBuilder_tB1BC265E1A177F0CEC2518E29F44C25E6CFBFB64 * L_15 = V_0;
			NullCheck(L_15);
			InterfaceActionInvoker0::Invoke(0 /* System.Void System.IDisposable::Dispose() */, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var, L_15);
		}

IL_004c:
		{
			IL2CPP_END_FINALLY(64)
		}
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(64)
	{
		IL2CPP_JUMP_TBL(0x4D, IL_004d)
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
	}

IL_004d:
	{
		SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_16 = __this->get__command_0();
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_17 = ___columns3;
		String_t* L_18 = String_Join_m49371BED70248F0FCE970CB4F2E39E9A688AAFA4(_stringLiteral5C10B5B2CD673A0616D529AA5234B12EE7153808, L_17, /*hidden argument*/NULL);
		String_t* L_19 = ___database1;
		String_t* L_20 = ___table2;
		String_t* L_21 = String_Format_m26BBF75F9609FAD0B39C2242FEBAAD7D68F14D99(_stringLiteralDD64AB817AB410403092565BB65F18EDEE243B7F, L_18, L_19, L_20, /*hidden argument*/NULL);
		NullCheck(L_16);
		SqliteCommand_set_CommandText_mE49B5EE0CD14901BC847B155D4B784B1EAE1D782(L_16, L_21, /*hidden argument*/NULL);
		SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_22 = __this->get__command_0();
		NullCheck(L_22);
		SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * L_23 = SqliteCommand_get_Parameters_mF4EA64A5EFD070514D13C782DAA883E45EA6DC0D(L_22, /*hidden argument*/NULL);
		int64_t L_24 = (((int64_t)((int64_t)0)));
		RuntimeObject * L_25 = Box(Int64_t7A386C2FF7B0280A0F516992401DDFCF0FF7B436_il2cpp_TypeInfo_var, &L_24);
		NullCheck(L_23);
		SqliteParameterCollection_AddWithValue_mF4F505D0FCEB4D850A40BEA47A730246088E871E(L_23, (String_t*)NULL, L_25, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteKeyReader_KeyQuery::set_IsValid(System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void KeyQuery_set_IsValid_mA4632D8CAB6B73258A401162467D7CB5C7E73B6D (KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * __this, bool ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (KeyQuery_set_IsValid_mA4632D8CAB6B73258A401162467D7CB5C7E73B6D_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		bool L_0 = ___value0;
		if (!L_0)
		{
			goto IL_000c;
		}
	}
	{
		ArgumentException_tEDCD16F20A09ECE461C3DA766C16EDA8864057D1 * L_1 = (ArgumentException_tEDCD16F20A09ECE461C3DA766C16EDA8864057D1 *)il2cpp_codegen_object_new(ArgumentException_tEDCD16F20A09ECE461C3DA766C16EDA8864057D1_il2cpp_TypeInfo_var);
		ArgumentException__ctor_m77591C20EDA3ADEE2FAF1987321D686E249326C5(L_1, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1, NULL, KeyQuery_set_IsValid_mA4632D8CAB6B73258A401162467D7CB5C7E73B6D_RuntimeMethod_var);
	}

IL_000c:
	{
		SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * L_2 = __this->get__reader_1();
		if (!L_2)
		{
			goto IL_0029;
		}
	}
	{
		SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * L_3 = __this->get__reader_1();
		NullCheck(L_3);
		DbDataReader_Dispose_mD3B8FDCD448F9FFB52287C8D4D95710EAA646B72(L_3, /*hidden argument*/NULL);
		__this->set__reader_1((SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 *)NULL);
	}

IL_0029:
	{
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteKeyReader_KeyQuery::Sync(System.Int64)
extern "C" IL2CPP_METHOD_ATTR void KeyQuery_Sync_m19A2575566EEFC07F5FC36F2E200FA23EE8A7390 (KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * __this, int64_t ___rowid0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (KeyQuery_Sync_m19A2575566EEFC07F5FC36F2E200FA23EE8A7390_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		KeyQuery_set_IsValid_mA4632D8CAB6B73258A401162467D7CB5C7E73B6D(__this, (bool)0, /*hidden argument*/NULL);
		SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_0 = __this->get__command_0();
		NullCheck(L_0);
		SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * L_1 = SqliteCommand_get_Parameters_mF4EA64A5EFD070514D13C782DAA883E45EA6DC0D(L_0, /*hidden argument*/NULL);
		NullCheck(L_1);
		SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_2 = SqliteParameterCollection_get_Item_m6807F61A4D898F719FF3EDAE8097A6FADC9E92F8(L_1, 0, /*hidden argument*/NULL);
		int64_t L_3 = ___rowid0;
		int64_t L_4 = L_3;
		RuntimeObject * L_5 = Box(Int64_t7A386C2FF7B0280A0F516992401DDFCF0FF7B436_il2cpp_TypeInfo_var, &L_4);
		NullCheck(L_2);
		SqliteParameter_set_Value_mA4215B49D68583CF87D786F3A54D2202ACFAD3C9(L_2, L_5, /*hidden argument*/NULL);
		SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_6 = __this->get__command_0();
		NullCheck(L_6);
		SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * L_7 = SqliteCommand_ExecuteReader_m8C72ED1B6C2B2CB567460300F665454ED122CA5A(L_6, /*hidden argument*/NULL);
		__this->set__reader_1(L_7);
		SqliteDataReader_tFBE37A0F795AE78E5F4AAF7388AA05582CE90D69 * L_8 = __this->get__reader_1();
		NullCheck(L_8);
		SqliteDataReader_Read_m6C689FF4A6EE5E3132E3FCF8E164DC42023727DE(L_8, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteKeyReader_KeyQuery::Dispose()
extern "C" IL2CPP_METHOD_ATTR void KeyQuery_Dispose_m47A9B991C6566086FD3BAB27C8DB2DBAFC4A1F48 (KeyQuery_tA3A1B612E12E7B391B1CD1936451DB37B70EF4B4 * __this, const RuntimeMethod* method)
{
	{
		KeyQuery_set_IsValid_mA4632D8CAB6B73258A401162467D7CB5C7E73B6D(__this, (bool)0, /*hidden argument*/NULL);
		SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_0 = __this->get__command_0();
		if (!L_0)
		{
			goto IL_001d;
		}
	}
	{
		SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_1 = __this->get__command_0();
		NullCheck(L_1);
		Component_Dispose_m823396D3128BA14DDC7522A760EEEEAC30518E98(L_1, /*hidden argument*/NULL);
	}

IL_001d:
	{
		__this->set__command_0((SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 *)NULL);
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
// System.Void Mono.Data.Sqlite.SqliteParameter::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SqliteParameter__ctor_mF034A9489870E17DCC82BA484697A871AF196ACD (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, const RuntimeMethod* method)
{
	{
		SqliteParameter__ctor_m34D7E5F90F0DC7D53557D381DB24924F147258D1(__this, (String_t*)NULL, (-1), 0, (String_t*)NULL, ((int32_t)512), /*hidden argument*/NULL);
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteParameter::.ctor(System.String,System.Object)
extern "C" IL2CPP_METHOD_ATTR void SqliteParameter__ctor_m98357CFB2616D646814795E2F4F73ABADCBB8630 (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, String_t* ___parameterName0, RuntimeObject * ___value1, const RuntimeMethod* method)
{
	{
		String_t* L_0 = ___parameterName0;
		SqliteParameter__ctor_m34D7E5F90F0DC7D53557D381DB24924F147258D1(__this, L_0, (-1), 0, (String_t*)NULL, ((int32_t)512), /*hidden argument*/NULL);
		RuntimeObject * L_1 = ___value1;
		SqliteParameter_set_Value_mA4215B49D68583CF87D786F3A54D2202ACFAD3C9(__this, L_1, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteParameter::.ctor(System.String,System.Data.DbType,System.Int32,System.String,System.Data.DataRowVersion)
extern "C" IL2CPP_METHOD_ATTR void SqliteParameter__ctor_m34D7E5F90F0DC7D53557D381DB24924F147258D1 (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, String_t* ___parameterName0, int32_t ___parameterType1, int32_t ___parameterSize2, String_t* ___sourceColumn3, int32_t ___rowVersion4, const RuntimeMethod* method)
{
	{
		DbParameter__ctor_mBC6F98079269BE4009ED11B5581B93D7550921FF(__this, /*hidden argument*/NULL);
		String_t* L_0 = ___parameterName0;
		__this->set__parameterName_5(L_0);
		int32_t L_1 = ___parameterType1;
		__this->set__dbType_1(L_1);
		String_t* L_2 = ___sourceColumn3;
		__this->set__sourceColumn_4(L_2);
		int32_t L_3 = ___rowVersion4;
		__this->set__rowVersion_2(L_3);
		__this->set__objValue_3(NULL);
		int32_t L_4 = ___parameterSize2;
		__this->set__dataSize_6(L_4);
		__this->set__nullMapping_8((bool)0);
		__this->set__nullable_7((bool)1);
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteParameter::.ctor(Mono.Data.Sqlite.SqliteParameter)
extern "C" IL2CPP_METHOD_ATTR void SqliteParameter__ctor_mA114D3015932B1ED012F86087A1CB770ADDDAFB6 (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * ___source0, const RuntimeMethod* method)
{
	{
		SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_0 = ___source0;
		NullCheck(L_0);
		String_t* L_1 = SqliteParameter_get_ParameterName_mA35635BDE12ACDEBD953F167C09F06AB44C213D0(L_0, /*hidden argument*/NULL);
		SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_2 = ___source0;
		NullCheck(L_2);
		int32_t L_3 = L_2->get__dbType_1();
		SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_4 = ___source0;
		NullCheck(L_4);
		int32_t L_5 = SqliteParameter_get_Direction_mBA66BA9F6C2C9F3F23E5E95B5BD73F01B13AE78F(L_4, /*hidden argument*/NULL);
		SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_6 = ___source0;
		NullCheck(L_6);
		bool L_7 = SqliteParameter_get_IsNullable_mDAA849A593086C73841A07FF9992B14BD1A2E3F6(L_6, /*hidden argument*/NULL);
		SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_8 = ___source0;
		NullCheck(L_8);
		String_t* L_9 = SqliteParameter_get_SourceColumn_mC6A8FA0D98F3AB4A76C9C32A850F519E0F726B28(L_8, /*hidden argument*/NULL);
		SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_10 = ___source0;
		NullCheck(L_10);
		int32_t L_11 = SqliteParameter_get_SourceVersion_m9D96666EF34C2549A30615586FC262E2EC1D7E5A(L_10, /*hidden argument*/NULL);
		SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_12 = ___source0;
		NullCheck(L_12);
		RuntimeObject * L_13 = SqliteParameter_get_Value_mBA989781BF12F4716038CA0F772C9A033CD829C6(L_12, /*hidden argument*/NULL);
		SqliteParameter__ctor_m39B48921AAEF2BD21DEA574A8EAAF44C4594622A(__this, L_1, L_3, 0, L_5, L_7, (uint8_t)0, (uint8_t)0, L_9, L_11, L_13, /*hidden argument*/NULL);
		SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_14 = ___source0;
		NullCheck(L_14);
		bool L_15 = L_14->get__nullMapping_8();
		__this->set__nullMapping_8(L_15);
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteParameter::.ctor(System.String,System.Data.DbType,System.Int32,System.Data.ParameterDirection,System.Boolean,System.Byte,System.Byte,System.String,System.Data.DataRowVersion,System.Object)
extern "C" IL2CPP_METHOD_ATTR void SqliteParameter__ctor_m39B48921AAEF2BD21DEA574A8EAAF44C4594622A (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, String_t* ___parameterName0, int32_t ___parameterType1, int32_t ___parameterSize2, int32_t ___direction3, bool ___isNullable4, uint8_t ___precision5, uint8_t ___scale6, String_t* ___sourceColumn7, int32_t ___rowVersion8, RuntimeObject * ___value9, const RuntimeMethod* method)
{
	{
		String_t* L_0 = ___parameterName0;
		int32_t L_1 = ___parameterType1;
		int32_t L_2 = ___parameterSize2;
		String_t* L_3 = ___sourceColumn7;
		int32_t L_4 = ___rowVersion8;
		SqliteParameter__ctor_m34D7E5F90F0DC7D53557D381DB24924F147258D1(__this, L_0, L_1, L_2, L_3, L_4, /*hidden argument*/NULL);
		int32_t L_5 = ___direction3;
		SqliteParameter_set_Direction_m80D8677C3C1484EF27734AAB1FDC814CF24A1814(__this, L_5, /*hidden argument*/NULL);
		bool L_6 = ___isNullable4;
		SqliteParameter_set_IsNullable_m3913742D2173DFCCACBCA79849A7E2E1F06C304D(__this, L_6, /*hidden argument*/NULL);
		RuntimeObject * L_7 = ___value9;
		SqliteParameter_set_Value_mA4215B49D68583CF87D786F3A54D2202ACFAD3C9(__this, L_7, /*hidden argument*/NULL);
		return;
	}
}
// System.Boolean Mono.Data.Sqlite.SqliteParameter::get_IsNullable()
extern "C" IL2CPP_METHOD_ATTR bool SqliteParameter_get_IsNullable_mDAA849A593086C73841A07FF9992B14BD1A2E3F6 (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, const RuntimeMethod* method)
{
	{
		bool L_0 = __this->get__nullable_7();
		return L_0;
	}
}
// System.Void Mono.Data.Sqlite.SqliteParameter::set_IsNullable(System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void SqliteParameter_set_IsNullable_m3913742D2173DFCCACBCA79849A7E2E1F06C304D (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, bool ___value0, const RuntimeMethod* method)
{
	{
		bool L_0 = ___value0;
		__this->set__nullable_7(L_0);
		return;
	}
}
// System.Data.DbType Mono.Data.Sqlite.SqliteParameter::get_DbType()
extern "C" IL2CPP_METHOD_ATTR int32_t SqliteParameter_get_DbType_m8622A28055C14CA1BC4A004A909780FB9A13E691 (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteParameter_get_DbType_m8622A28055C14CA1BC4A004A909780FB9A13E691_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		int32_t L_0 = __this->get__dbType_1();
		if ((!(((uint32_t)L_0) == ((uint32_t)(-1)))))
		{
			goto IL_003b;
		}
	}
	{
		RuntimeObject * L_1 = __this->get__objValue_3();
		if (!L_1)
		{
			goto IL_0038;
		}
	}
	{
		RuntimeObject * L_2 = __this->get__objValue_3();
		IL2CPP_RUNTIME_CLASS_INIT(DBNull_t7400E04939C2C29699B389B106997892BF53A8E5_il2cpp_TypeInfo_var);
		DBNull_t7400E04939C2C29699B389B106997892BF53A8E5 * L_3 = ((DBNull_t7400E04939C2C29699B389B106997892BF53A8E5_StaticFields*)il2cpp_codegen_static_fields_for(DBNull_t7400E04939C2C29699B389B106997892BF53A8E5_il2cpp_TypeInfo_var))->get_Value_0();
		if ((((RuntimeObject*)(RuntimeObject *)L_2) == ((RuntimeObject*)(DBNull_t7400E04939C2C29699B389B106997892BF53A8E5 *)L_3)))
		{
			goto IL_0038;
		}
	}
	{
		RuntimeObject * L_4 = __this->get__objValue_3();
		NullCheck(L_4);
		Type_t * L_5 = Object_GetType_m2E0B62414ECCAA3094B703790CE88CBB2F83EA60(L_4, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(SqliteConvert_t9FED20EF4CA9E373EBD857ECBA9C74B6307EE6E7_il2cpp_TypeInfo_var);
		int32_t L_6 = SqliteConvert_TypeToDbType_mCEFBA85B101BCF9131178D3E11B9D10198F0A026(L_5, /*hidden argument*/NULL);
		return L_6;
	}

IL_0038:
	{
		return (int32_t)(((int32_t)16));
	}

IL_003b:
	{
		int32_t L_7 = __this->get__dbType_1();
		return (int32_t)(L_7);
	}
}
// System.Void Mono.Data.Sqlite.SqliteParameter::set_DbType(System.Data.DbType)
extern "C" IL2CPP_METHOD_ATTR void SqliteParameter_set_DbType_m91882A85B8EB920530197EA01C0F24307A602492 (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, int32_t ___value0, const RuntimeMethod* method)
{
	{
		int32_t L_0 = ___value0;
		__this->set__dbType_1(L_0);
		return;
	}
}
// System.Data.ParameterDirection Mono.Data.Sqlite.SqliteParameter::get_Direction()
extern "C" IL2CPP_METHOD_ATTR int32_t SqliteParameter_get_Direction_mBA66BA9F6C2C9F3F23E5E95B5BD73F01B13AE78F (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, const RuntimeMethod* method)
{
	{
		return (int32_t)(1);
	}
}
// System.Void Mono.Data.Sqlite.SqliteParameter::set_Direction(System.Data.ParameterDirection)
extern "C" IL2CPP_METHOD_ATTR void SqliteParameter_set_Direction_m80D8677C3C1484EF27734AAB1FDC814CF24A1814 (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, int32_t ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteParameter_set_Direction_m80D8677C3C1484EF27734AAB1FDC814CF24A1814_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		int32_t L_0 = ___value0;
		if ((((int32_t)L_0) == ((int32_t)1)))
		{
			goto IL_000d;
		}
	}
	{
		NotSupportedException_tE75B318D6590A02A5D9B29FD97409B1750FA0010 * L_1 = (NotSupportedException_tE75B318D6590A02A5D9B29FD97409B1750FA0010 *)il2cpp_codegen_object_new(NotSupportedException_tE75B318D6590A02A5D9B29FD97409B1750FA0010_il2cpp_TypeInfo_var);
		NotSupportedException__ctor_mA121DE1CAC8F25277DEB489DC7771209D91CAE33(L_1, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1, NULL, SqliteParameter_set_Direction_m80D8677C3C1484EF27734AAB1FDC814CF24A1814_RuntimeMethod_var);
	}

IL_000d:
	{
		return;
	}
}
// System.String Mono.Data.Sqlite.SqliteParameter::get_ParameterName()
extern "C" IL2CPP_METHOD_ATTR String_t* SqliteParameter_get_ParameterName_mA35635BDE12ACDEBD953F167C09F06AB44C213D0 (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, const RuntimeMethod* method)
{
	{
		String_t* L_0 = __this->get__parameterName_5();
		return L_0;
	}
}
// System.Void Mono.Data.Sqlite.SqliteParameter::set_ParameterName(System.String)
extern "C" IL2CPP_METHOD_ATTR void SqliteParameter_set_ParameterName_m034B2AC542A2149D1B1099E3B3D2F2FED7853357 (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, String_t* ___value0, const RuntimeMethod* method)
{
	{
		String_t* L_0 = ___value0;
		__this->set__parameterName_5(L_0);
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteParameter::set_Size(System.Int32)
extern "C" IL2CPP_METHOD_ATTR void SqliteParameter_set_Size_mA1C75C48F53CB3E854BB52CDE5371D9D4816C0E5 (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, int32_t ___value0, const RuntimeMethod* method)
{
	{
		int32_t L_0 = ___value0;
		__this->set__dataSize_6(L_0);
		return;
	}
}
// System.String Mono.Data.Sqlite.SqliteParameter::get_SourceColumn()
extern "C" IL2CPP_METHOD_ATTR String_t* SqliteParameter_get_SourceColumn_mC6A8FA0D98F3AB4A76C9C32A850F519E0F726B28 (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, const RuntimeMethod* method)
{
	{
		String_t* L_0 = __this->get__sourceColumn_4();
		return L_0;
	}
}
// System.Void Mono.Data.Sqlite.SqliteParameter::set_SourceColumn(System.String)
extern "C" IL2CPP_METHOD_ATTR void SqliteParameter_set_SourceColumn_m8A4E2B880E9BBB92D13BA90DAFA57787FEE13148 (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, String_t* ___value0, const RuntimeMethod* method)
{
	{
		String_t* L_0 = ___value0;
		__this->set__sourceColumn_4(L_0);
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteParameter::set_SourceColumnNullMapping(System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void SqliteParameter_set_SourceColumnNullMapping_mFD385F64F81FD4359DCD0ACECDB594DE897F245B (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, bool ___value0, const RuntimeMethod* method)
{
	{
		bool L_0 = ___value0;
		__this->set__nullMapping_8(L_0);
		return;
	}
}
// System.Data.DataRowVersion Mono.Data.Sqlite.SqliteParameter::get_SourceVersion()
extern "C" IL2CPP_METHOD_ATTR int32_t SqliteParameter_get_SourceVersion_m9D96666EF34C2549A30615586FC262E2EC1D7E5A (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, const RuntimeMethod* method)
{
	{
		int32_t L_0 = __this->get__rowVersion_2();
		return L_0;
	}
}
// System.Void Mono.Data.Sqlite.SqliteParameter::set_SourceVersion(System.Data.DataRowVersion)
extern "C" IL2CPP_METHOD_ATTR void SqliteParameter_set_SourceVersion_m19AC5C9647E29DC3B229DD5012FCBFFB226A7971 (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, int32_t ___value0, const RuntimeMethod* method)
{
	{
		int32_t L_0 = ___value0;
		__this->set__rowVersion_2(L_0);
		return;
	}
}
// System.Object Mono.Data.Sqlite.SqliteParameter::get_Value()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * SqliteParameter_get_Value_mBA989781BF12F4716038CA0F772C9A033CD829C6 (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, const RuntimeMethod* method)
{
	{
		RuntimeObject * L_0 = __this->get__objValue_3();
		return L_0;
	}
}
// System.Void Mono.Data.Sqlite.SqliteParameter::set_Value(System.Object)
extern "C" IL2CPP_METHOD_ATTR void SqliteParameter_set_Value_mA4215B49D68583CF87D786F3A54D2202ACFAD3C9 (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, RuntimeObject * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteParameter_set_Value_mA4215B49D68583CF87D786F3A54D2202ACFAD3C9_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject * L_0 = ___value0;
		__this->set__objValue_3(L_0);
		int32_t L_1 = __this->get__dbType_1();
		if ((!(((uint32_t)L_1) == ((uint32_t)(-1)))))
		{
			goto IL_0044;
		}
	}
	{
		RuntimeObject * L_2 = __this->get__objValue_3();
		if (!L_2)
		{
			goto IL_0044;
		}
	}
	{
		RuntimeObject * L_3 = __this->get__objValue_3();
		IL2CPP_RUNTIME_CLASS_INIT(DBNull_t7400E04939C2C29699B389B106997892BF53A8E5_il2cpp_TypeInfo_var);
		DBNull_t7400E04939C2C29699B389B106997892BF53A8E5 * L_4 = ((DBNull_t7400E04939C2C29699B389B106997892BF53A8E5_StaticFields*)il2cpp_codegen_static_fields_for(DBNull_t7400E04939C2C29699B389B106997892BF53A8E5_il2cpp_TypeInfo_var))->get_Value_0();
		if ((((RuntimeObject*)(RuntimeObject *)L_3) == ((RuntimeObject*)(DBNull_t7400E04939C2C29699B389B106997892BF53A8E5 *)L_4)))
		{
			goto IL_0044;
		}
	}
	{
		RuntimeObject * L_5 = __this->get__objValue_3();
		NullCheck(L_5);
		Type_t * L_6 = Object_GetType_m2E0B62414ECCAA3094B703790CE88CBB2F83EA60(L_5, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(SqliteConvert_t9FED20EF4CA9E373EBD857ECBA9C74B6307EE6E7_il2cpp_TypeInfo_var);
		int32_t L_7 = SqliteConvert_TypeToDbType_mCEFBA85B101BCF9131178D3E11B9D10198F0A026(L_6, /*hidden argument*/NULL);
		__this->set__dbType_1(L_7);
	}

IL_0044:
	{
		return;
	}
}
// System.Object Mono.Data.Sqlite.SqliteParameter::Clone()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * SqliteParameter_Clone_mBA5E17A105E1534F29C9F273109F123530CC9C9B (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteParameter_Clone_mBA5E17A105E1534F29C9F273109F123530CC9C9B_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * V_0 = NULL;
	{
		SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_0 = (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E *)il2cpp_codegen_object_new(SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E_il2cpp_TypeInfo_var);
		SqliteParameter__ctor_mA114D3015932B1ED012F86087A1CB770ADDDAFB6(L_0, __this, /*hidden argument*/NULL);
		V_0 = L_0;
		SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_1 = V_0;
		return L_1;
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
// System.Void Mono.Data.Sqlite.SqliteParameterCollection::.ctor(Mono.Data.Sqlite.SqliteCommand)
extern "C" IL2CPP_METHOD_ATTR void SqliteParameterCollection__ctor_mBCC625E0A40AE96F7BB16AD2CEF18A22A03A9BF6 (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * ___cmd0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteParameterCollection__ctor_mBCC625E0A40AE96F7BB16AD2CEF18A22A03A9BF6_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		DbParameterCollection__ctor_m1170B63FB42DB24CF67CDD28B2F1152DC0CDB6B2(__this, /*hidden argument*/NULL);
		SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_0 = ___cmd0;
		__this->set__command_1(L_0);
		List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * L_1 = (List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 *)il2cpp_codegen_object_new(List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657_il2cpp_TypeInfo_var);
		List_1__ctor_mB58ED77706DFDF497D9DEA17FE42A5C700DED840(L_1, /*hidden argument*/List_1__ctor_mB58ED77706DFDF497D9DEA17FE42A5C700DED840_RuntimeMethod_var);
		__this->set__parameterList_2(L_1);
		__this->set__unboundFlag_3((bool)1);
		return;
	}
}
// System.Boolean Mono.Data.Sqlite.SqliteParameterCollection::get_IsSynchronized()
extern "C" IL2CPP_METHOD_ATTR bool SqliteParameterCollection_get_IsSynchronized_mDA4A3CB33C9B46F5DE12906A90F5D6BF97BBBA6C (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, const RuntimeMethod* method)
{
	{
		return (bool)1;
	}
}
// System.Boolean Mono.Data.Sqlite.SqliteParameterCollection::get_IsFixedSize()
extern "C" IL2CPP_METHOD_ATTR bool SqliteParameterCollection_get_IsFixedSize_m5337F027CF9BBBA7E514E3374DD90A443FA9F2A0 (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, const RuntimeMethod* method)
{
	{
		return (bool)0;
	}
}
// System.Boolean Mono.Data.Sqlite.SqliteParameterCollection::get_IsReadOnly()
extern "C" IL2CPP_METHOD_ATTR bool SqliteParameterCollection_get_IsReadOnly_m1B312B2ED2C0F98C247E96B9A7AF4712083EDA5B (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, const RuntimeMethod* method)
{
	{
		return (bool)0;
	}
}
// System.Object Mono.Data.Sqlite.SqliteParameterCollection::get_SyncRoot()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * SqliteParameterCollection_get_SyncRoot_m0AA21837AD61AEE9BC6AE7712578FCEA972B117B (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, const RuntimeMethod* method)
{
	{
		return NULL;
	}
}
// System.Collections.IEnumerator Mono.Data.Sqlite.SqliteParameterCollection::GetEnumerator()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject* SqliteParameterCollection_GetEnumerator_mE813133D39F61EAE4358CB136F5ECEC815EE8DCA (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteParameterCollection_GetEnumerator_mE813133D39F61EAE4358CB136F5ECEC815EE8DCA_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * L_0 = __this->get__parameterList_2();
		NullCheck(L_0);
		Enumerator_tA18C55D69C7008726BD92603BF88561F27BB708A  L_1 = List_1_GetEnumerator_m7E68AD2A26A6D8F70A2C5B6D22E0983B86407DF3(L_0, /*hidden argument*/List_1_GetEnumerator_m7E68AD2A26A6D8F70A2C5B6D22E0983B86407DF3_RuntimeMethod_var);
		Enumerator_tA18C55D69C7008726BD92603BF88561F27BB708A  L_2 = L_1;
		RuntimeObject * L_3 = Box(Enumerator_tA18C55D69C7008726BD92603BF88561F27BB708A_il2cpp_TypeInfo_var, &L_2);
		return (RuntimeObject*)L_3;
	}
}
// System.Int32 Mono.Data.Sqlite.SqliteParameterCollection::Add(Mono.Data.Sqlite.SqliteParameter)
extern "C" IL2CPP_METHOD_ATTR int32_t SqliteParameterCollection_Add_mBF596B1E9C33A5BEFE50A6F49A608B5D4D464FF9 (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * ___parameter0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteParameterCollection_Add_mBF596B1E9C33A5BEFE50A6F49A608B5D4D464FF9_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		V_0 = (-1);
		SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_0 = ___parameter0;
		NullCheck(L_0);
		String_t* L_1 = SqliteParameter_get_ParameterName_mA35635BDE12ACDEBD953F167C09F06AB44C213D0(L_0, /*hidden argument*/NULL);
		bool L_2 = String_IsNullOrEmpty_m06A85A206AC2106D1982826C5665B9BD35324229(L_1, /*hidden argument*/NULL);
		if (L_2)
		{
			goto IL_001f;
		}
	}
	{
		SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_3 = ___parameter0;
		NullCheck(L_3);
		String_t* L_4 = SqliteParameter_get_ParameterName_mA35635BDE12ACDEBD953F167C09F06AB44C213D0(L_3, /*hidden argument*/NULL);
		int32_t L_5 = SqliteParameterCollection_IndexOf_m3EBE7087E87273E22E1F60F48441484F94607421(__this, L_4, /*hidden argument*/NULL);
		V_0 = L_5;
	}

IL_001f:
	{
		int32_t L_6 = V_0;
		if ((!(((uint32_t)L_6) == ((uint32_t)(-1)))))
		{
			goto IL_003e;
		}
	}
	{
		List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * L_7 = __this->get__parameterList_2();
		NullCheck(L_7);
		int32_t L_8 = List_1_get_Count_mBF71B71F277DBD1ECF0136FBEDB2F5DB5BC2D7E7(L_7, /*hidden argument*/List_1_get_Count_mBF71B71F277DBD1ECF0136FBEDB2F5DB5BC2D7E7_RuntimeMethod_var);
		V_0 = L_8;
		List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * L_9 = __this->get__parameterList_2();
		SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_10 = ___parameter0;
		NullCheck(L_9);
		List_1_Add_m37ACF8547D171B0E3F525F0F9DEC80D46E9673C3(L_9, L_10, /*hidden argument*/List_1_Add_m37ACF8547D171B0E3F525F0F9DEC80D46E9673C3_RuntimeMethod_var);
	}

IL_003e:
	{
		int32_t L_11 = V_0;
		SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_12 = ___parameter0;
		SqliteParameterCollection_SetParameter_m8A77372FD9D393D3493E145532C580D3FAB3CEC6(__this, L_11, L_12, /*hidden argument*/NULL);
		int32_t L_13 = V_0;
		return L_13;
	}
}
// System.Int32 Mono.Data.Sqlite.SqliteParameterCollection::Add(System.Object)
extern "C" IL2CPP_METHOD_ATTR int32_t SqliteParameterCollection_Add_mAFFCEFBEC7E1F1E9AB23DC340654A0DACA0B786F (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, RuntimeObject * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteParameterCollection_Add_mAFFCEFBEC7E1F1E9AB23DC340654A0DACA0B786F_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject * L_0 = ___value0;
		int32_t L_1 = SqliteParameterCollection_Add_mBF596B1E9C33A5BEFE50A6F49A608B5D4D464FF9(__this, ((SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E *)CastclassSealed((RuntimeObject*)L_0, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E_il2cpp_TypeInfo_var)), /*hidden argument*/NULL);
		return L_1;
	}
}
// Mono.Data.Sqlite.SqliteParameter Mono.Data.Sqlite.SqliteParameterCollection::AddWithValue(System.String,System.Object)
extern "C" IL2CPP_METHOD_ATTR SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * SqliteParameterCollection_AddWithValue_mF4F505D0FCEB4D850A40BEA47A730246088E871E (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, String_t* ___parameterName0, RuntimeObject * ___value1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteParameterCollection_AddWithValue_mF4F505D0FCEB4D850A40BEA47A730246088E871E_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * V_0 = NULL;
	{
		String_t* L_0 = ___parameterName0;
		RuntimeObject * L_1 = ___value1;
		SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_2 = (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E *)il2cpp_codegen_object_new(SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E_il2cpp_TypeInfo_var);
		SqliteParameter__ctor_m98357CFB2616D646814795E2F4F73ABADCBB8630(L_2, L_0, L_1, /*hidden argument*/NULL);
		V_0 = L_2;
		SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_3 = V_0;
		SqliteParameterCollection_Add_mBF596B1E9C33A5BEFE50A6F49A608B5D4D464FF9(__this, L_3, /*hidden argument*/NULL);
		SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_4 = V_0;
		return L_4;
	}
}
// System.Void Mono.Data.Sqlite.SqliteParameterCollection::Clear()
extern "C" IL2CPP_METHOD_ATTR void SqliteParameterCollection_Clear_m44945F7C1DF0F720B9C6C746EB557D5CA37AE0F6 (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteParameterCollection_Clear_m44945F7C1DF0F720B9C6C746EB557D5CA37AE0F6_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		__this->set__unboundFlag_3((bool)1);
		List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * L_0 = __this->get__parameterList_2();
		NullCheck(L_0);
		List_1_Clear_m03F5799F64050A07C3C1144F3492F3E44B715707(L_0, /*hidden argument*/List_1_Clear_m03F5799F64050A07C3C1144F3492F3E44B715707_RuntimeMethod_var);
		return;
	}
}
// System.Boolean Mono.Data.Sqlite.SqliteParameterCollection::Contains(System.Object)
extern "C" IL2CPP_METHOD_ATTR bool SqliteParameterCollection_Contains_mEB901C67AB25CF497B7857AA0DD615DCB931C9D7 (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, RuntimeObject * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteParameterCollection_Contains_mEB901C67AB25CF497B7857AA0DD615DCB931C9D7_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * L_0 = __this->get__parameterList_2();
		RuntimeObject * L_1 = ___value0;
		NullCheck(L_0);
		bool L_2 = List_1_Contains_mB71B12DBCE2F9899460DF6F0DB4584748FAAE603(L_0, ((SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E *)CastclassSealed((RuntimeObject*)L_1, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E_il2cpp_TypeInfo_var)), /*hidden argument*/List_1_Contains_mB71B12DBCE2F9899460DF6F0DB4584748FAAE603_RuntimeMethod_var);
		return L_2;
	}
}
// System.Void Mono.Data.Sqlite.SqliteParameterCollection::CopyTo(System.Array,System.Int32)
extern "C" IL2CPP_METHOD_ATTR void SqliteParameterCollection_CopyTo_m40835944C1939CF6CB6CB431742B56226376A643 (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, RuntimeArray * ___array0, int32_t ___index1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteParameterCollection_CopyTo_m40835944C1939CF6CB6CB431742B56226376A643_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		NotImplementedException_t8AD6EBE5FEDB0AEBECEE0961CF73C35B372EFFA4 * L_0 = (NotImplementedException_t8AD6EBE5FEDB0AEBECEE0961CF73C35B372EFFA4 *)il2cpp_codegen_object_new(NotImplementedException_t8AD6EBE5FEDB0AEBECEE0961CF73C35B372EFFA4_il2cpp_TypeInfo_var);
		NotImplementedException__ctor_m8BEA657E260FC05F0C6D2C43A6E9BC08040F59C4(L_0, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_0, NULL, SqliteParameterCollection_CopyTo_m40835944C1939CF6CB6CB431742B56226376A643_RuntimeMethod_var);
	}
}
// System.Int32 Mono.Data.Sqlite.SqliteParameterCollection::get_Count()
extern "C" IL2CPP_METHOD_ATTR int32_t SqliteParameterCollection_get_Count_m6B327DADE924BD93FFADF92E4AD56E194F6F1D93 (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteParameterCollection_get_Count_m6B327DADE924BD93FFADF92E4AD56E194F6F1D93_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * L_0 = __this->get__parameterList_2();
		NullCheck(L_0);
		int32_t L_1 = List_1_get_Count_mBF71B71F277DBD1ECF0136FBEDB2F5DB5BC2D7E7(L_0, /*hidden argument*/List_1_get_Count_mBF71B71F277DBD1ECF0136FBEDB2F5DB5BC2D7E7_RuntimeMethod_var);
		return L_1;
	}
}
// Mono.Data.Sqlite.SqliteParameter Mono.Data.Sqlite.SqliteParameterCollection::get_Item(System.Int32)
extern "C" IL2CPP_METHOD_ATTR SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * SqliteParameterCollection_get_Item_m6807F61A4D898F719FF3EDAE8097A6FADC9E92F8 (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, int32_t ___index0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteParameterCollection_get_Item_m6807F61A4D898F719FF3EDAE8097A6FADC9E92F8_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		int32_t L_0 = ___index0;
		DbParameter_tEE5AEAD8B429B8EF8994063C151A25A76B94B76F * L_1 = SqliteParameterCollection_GetParameter_mFB68E8A80CCD474525471D67CFBA3117C3D54096(__this, L_0, /*hidden argument*/NULL);
		return ((SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E *)CastclassSealed((RuntimeObject*)L_1, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E_il2cpp_TypeInfo_var));
	}
}
// System.Data.Common.DbParameter Mono.Data.Sqlite.SqliteParameterCollection::GetParameter(System.Int32)
extern "C" IL2CPP_METHOD_ATTR DbParameter_tEE5AEAD8B429B8EF8994063C151A25A76B94B76F * SqliteParameterCollection_GetParameter_mFB68E8A80CCD474525471D67CFBA3117C3D54096 (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, int32_t ___index0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteParameterCollection_GetParameter_mFB68E8A80CCD474525471D67CFBA3117C3D54096_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * L_0 = __this->get__parameterList_2();
		int32_t L_1 = ___index0;
		NullCheck(L_0);
		SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_2 = List_1_get_Item_mC7944FE39CD3751E41C887D3901B49E003741BC2(L_0, L_1, /*hidden argument*/List_1_get_Item_mC7944FE39CD3751E41C887D3901B49E003741BC2_RuntimeMethod_var);
		return L_2;
	}
}
// System.Int32 Mono.Data.Sqlite.SqliteParameterCollection::IndexOf(System.String)
extern "C" IL2CPP_METHOD_ATTR int32_t SqliteParameterCollection_IndexOf_m3EBE7087E87273E22E1F60F48441484F94607421 (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, String_t* ___parameterName0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteParameterCollection_IndexOf_m3EBE7087E87273E22E1F60F48441484F94607421_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	{
		List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * L_0 = __this->get__parameterList_2();
		NullCheck(L_0);
		int32_t L_1 = List_1_get_Count_mBF71B71F277DBD1ECF0136FBEDB2F5DB5BC2D7E7(L_0, /*hidden argument*/List_1_get_Count_mBF71B71F277DBD1ECF0136FBEDB2F5DB5BC2D7E7_RuntimeMethod_var);
		V_0 = L_1;
		V_1 = 0;
		goto IL_003b;
	}

IL_0013:
	{
		String_t* L_2 = ___parameterName0;
		List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * L_3 = __this->get__parameterList_2();
		int32_t L_4 = V_1;
		NullCheck(L_3);
		SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_5 = List_1_get_Item_mC7944FE39CD3751E41C887D3901B49E003741BC2(L_3, L_4, /*hidden argument*/List_1_get_Item_mC7944FE39CD3751E41C887D3901B49E003741BC2_RuntimeMethod_var);
		NullCheck(L_5);
		String_t* L_6 = SqliteParameter_get_ParameterName_mA35635BDE12ACDEBD953F167C09F06AB44C213D0(L_5, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_il2cpp_TypeInfo_var);
		CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * L_7 = CultureInfo_get_InvariantCulture_mF13B47F8A763CE6A9C8A8BB2EED33FF8F7A63A72(/*hidden argument*/NULL);
		int32_t L_8 = String_Compare_mA1D43767F882FE677F238637A8785FCCEE7173D9(L_2, L_6, (bool)1, L_7, /*hidden argument*/NULL);
		if (L_8)
		{
			goto IL_0037;
		}
	}
	{
		int32_t L_9 = V_1;
		return L_9;
	}

IL_0037:
	{
		int32_t L_10 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add((int32_t)L_10, (int32_t)1));
	}

IL_003b:
	{
		int32_t L_11 = V_1;
		int32_t L_12 = V_0;
		if ((((int32_t)L_11) < ((int32_t)L_12)))
		{
			goto IL_0013;
		}
	}
	{
		return (-1);
	}
}
// System.Int32 Mono.Data.Sqlite.SqliteParameterCollection::IndexOf(System.Object)
extern "C" IL2CPP_METHOD_ATTR int32_t SqliteParameterCollection_IndexOf_mBD3C478CCDC30F206087A1CCBD995FAD93556C1C (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, RuntimeObject * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteParameterCollection_IndexOf_mBD3C478CCDC30F206087A1CCBD995FAD93556C1C_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * L_0 = __this->get__parameterList_2();
		RuntimeObject * L_1 = ___value0;
		NullCheck(L_0);
		int32_t L_2 = List_1_IndexOf_mA304FB7C0E2D8FA02C0D7A8A31F6BACE2D5E89FB(L_0, ((SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E *)CastclassSealed((RuntimeObject*)L_1, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E_il2cpp_TypeInfo_var)), /*hidden argument*/List_1_IndexOf_mA304FB7C0E2D8FA02C0D7A8A31F6BACE2D5E89FB_RuntimeMethod_var);
		return L_2;
	}
}
// System.Void Mono.Data.Sqlite.SqliteParameterCollection::Insert(System.Int32,System.Object)
extern "C" IL2CPP_METHOD_ATTR void SqliteParameterCollection_Insert_m69D0F90223F0BD7B3F94EF0873733239CD9696F0 (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, int32_t ___index0, RuntimeObject * ___value1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteParameterCollection_Insert_m69D0F90223F0BD7B3F94EF0873733239CD9696F0_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		__this->set__unboundFlag_3((bool)1);
		List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * L_0 = __this->get__parameterList_2();
		int32_t L_1 = ___index0;
		RuntimeObject * L_2 = ___value1;
		NullCheck(L_0);
		List_1_Insert_m4EF8AEFAFE722E8BD0BA8C841C92194EBFF18325(L_0, L_1, ((SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E *)CastclassSealed((RuntimeObject*)L_2, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E_il2cpp_TypeInfo_var)), /*hidden argument*/List_1_Insert_m4EF8AEFAFE722E8BD0BA8C841C92194EBFF18325_RuntimeMethod_var);
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteParameterCollection::Remove(System.Object)
extern "C" IL2CPP_METHOD_ATTR void SqliteParameterCollection_Remove_mDD2FD25D1A426D635287917709D1B55592061B94 (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, RuntimeObject * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteParameterCollection_Remove_mDD2FD25D1A426D635287917709D1B55592061B94_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		__this->set__unboundFlag_3((bool)1);
		List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * L_0 = __this->get__parameterList_2();
		RuntimeObject * L_1 = ___value0;
		NullCheck(L_0);
		List_1_Remove_m1A3186B1F195851183DDCD11C2A5190A6F70F11D(L_0, ((SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E *)CastclassSealed((RuntimeObject*)L_1, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E_il2cpp_TypeInfo_var)), /*hidden argument*/List_1_Remove_m1A3186B1F195851183DDCD11C2A5190A6F70F11D_RuntimeMethod_var);
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteParameterCollection::RemoveAt(System.Int32)
extern "C" IL2CPP_METHOD_ATTR void SqliteParameterCollection_RemoveAt_m6A53370209BCD6A94AA591F236F8D459C984BF49 (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, int32_t ___index0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteParameterCollection_RemoveAt_m6A53370209BCD6A94AA591F236F8D459C984BF49_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		__this->set__unboundFlag_3((bool)1);
		List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * L_0 = __this->get__parameterList_2();
		int32_t L_1 = ___index0;
		NullCheck(L_0);
		List_1_RemoveAt_m1408E3DEDB4B543DE4A55EFDB57226904F6967E4(L_0, L_1, /*hidden argument*/List_1_RemoveAt_m1408E3DEDB4B543DE4A55EFDB57226904F6967E4_RuntimeMethod_var);
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteParameterCollection::SetParameter(System.Int32,System.Data.Common.DbParameter)
extern "C" IL2CPP_METHOD_ATTR void SqliteParameterCollection_SetParameter_m8A77372FD9D393D3493E145532C580D3FAB3CEC6 (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, int32_t ___index0, DbParameter_tEE5AEAD8B429B8EF8994063C151A25A76B94B76F * ___value1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteParameterCollection_SetParameter_m8A77372FD9D393D3493E145532C580D3FAB3CEC6_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		__this->set__unboundFlag_3((bool)1);
		List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * L_0 = __this->get__parameterList_2();
		int32_t L_1 = ___index0;
		DbParameter_tEE5AEAD8B429B8EF8994063C151A25A76B94B76F * L_2 = ___value1;
		NullCheck(L_0);
		List_1_set_Item_mEDB88DF97C46BC3FD98495E2248B13827DB0E974(L_0, L_1, ((SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E *)CastclassSealed((RuntimeObject*)L_2, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E_il2cpp_TypeInfo_var)), /*hidden argument*/List_1_set_Item_mEDB88DF97C46BC3FD98495E2248B13827DB0E974_RuntimeMethod_var);
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteParameterCollection::Unbind()
extern "C" IL2CPP_METHOD_ATTR void SqliteParameterCollection_Unbind_m5ED1ED65625AF1900A650DBF0D5711D188757B32 (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, const RuntimeMethod* method)
{
	{
		__this->set__unboundFlag_3((bool)1);
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteParameterCollection::MapParameters(Mono.Data.Sqlite.SqliteStatement)
extern "C" IL2CPP_METHOD_ATTR void SqliteParameterCollection_MapParameters_m76D14599AF9FF70EC7586705A28C2E6AD6E74121 (SqliteParameterCollection_tD518FC7690200D12DA3B779429941F988301B523 * __this, SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * ___activeStatement0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteParameterCollection_MapParameters_m76D14599AF9FF70EC7586705A28C2E6AD6E74121_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	String_t* V_1 = NULL;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * V_4 = NULL;
	SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * V_5 = NULL;
	Enumerator_tA18C55D69C7008726BD92603BF88561F27BB708A  V_6;
	memset(&V_6, 0, sizeof(V_6));
	int32_t V_7 = 0;
	bool V_8 = false;
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	void* __leave_targets_storage = alloca(sizeof(int32_t) * 1);
	il2cpp::utils::LeaveTargetStack __leave_targets(__leave_targets_storage);
	NO_UNUSED_WARNING (__leave_targets);
	{
		bool L_0 = __this->get__unboundFlag_3();
		if (!L_0)
		{
			goto IL_002b;
		}
	}
	{
		List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * L_1 = __this->get__parameterList_2();
		NullCheck(L_1);
		int32_t L_2 = List_1_get_Count_mBF71B71F277DBD1ECF0136FBEDB2F5DB5BC2D7E7(L_1, /*hidden argument*/List_1_get_Count_mBF71B71F277DBD1ECF0136FBEDB2F5DB5BC2D7E7_RuntimeMethod_var);
		if (!L_2)
		{
			goto IL_002b;
		}
	}
	{
		SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_3 = __this->get__command_1();
		NullCheck(L_3);
		List_1_t061A89EAEE080F1782627C91C598BD546671C91A * L_4 = L_3->get__statementList_12();
		if (L_4)
		{
			goto IL_002c;
		}
	}

IL_002b:
	{
		return;
	}

IL_002c:
	{
		V_0 = 0;
		V_3 = (-1);
		List_1_t3ECE5D45EA4667C779CDCD76FFCAB7F243B4E657 * L_5 = __this->get__parameterList_2();
		NullCheck(L_5);
		Enumerator_tA18C55D69C7008726BD92603BF88561F27BB708A  L_6 = List_1_GetEnumerator_m7E68AD2A26A6D8F70A2C5B6D22E0983B86407DF3(L_5, /*hidden argument*/List_1_GetEnumerator_m7E68AD2A26A6D8F70A2C5B6D22E0983B86407DF3_RuntimeMethod_var);
		V_6 = L_6;
	}

IL_003d:
	try
	{ // begin try (depth: 1)
		{
			goto IL_016e;
		}

IL_0042:
		{
			SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_7 = Enumerator_get_Current_m152C218D70BA6E16353FC590C1A91BE28782074D((Enumerator_tA18C55D69C7008726BD92603BF88561F27BB708A *)(&V_6), /*hidden argument*/Enumerator_get_Current_m152C218D70BA6E16353FC590C1A91BE28782074D_RuntimeMethod_var);
			V_5 = L_7;
			int32_t L_8 = V_3;
			V_3 = ((int32_t)il2cpp_codegen_add((int32_t)L_8, (int32_t)1));
			SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_9 = V_5;
			NullCheck(L_9);
			String_t* L_10 = SqliteParameter_get_ParameterName_mA35635BDE12ACDEBD953F167C09F06AB44C213D0(L_9, /*hidden argument*/NULL);
			V_1 = L_10;
			String_t* L_11 = V_1;
			if (L_11)
			{
				goto IL_0080;
			}
		}

IL_005d:
		{
			IL2CPP_RUNTIME_CLASS_INIT(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_il2cpp_TypeInfo_var);
			CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * L_12 = CultureInfo_get_InvariantCulture_mF13B47F8A763CE6A9C8A8BB2EED33FF8F7A63A72(/*hidden argument*/NULL);
			ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* L_13 = (ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A*)SZArrayNew(ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A_il2cpp_TypeInfo_var, (uint32_t)1);
			ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* L_14 = L_13;
			int32_t L_15 = V_0;
			int32_t L_16 = L_15;
			RuntimeObject * L_17 = Box(Int32_t585191389E07734F19F3156FF88FB3EF4800D102_il2cpp_TypeInfo_var, &L_16);
			NullCheck(L_14);
			ArrayElementTypeCheck (L_14, L_17);
			(L_14)->SetAt(static_cast<il2cpp_array_size_t>(0), (RuntimeObject *)L_17);
			String_t* L_18 = String_Format_mF68EE0DEC1AA5ADE9DFEF9AE0508E428FBB10EFD(L_12, _stringLiteralF6ECAD2FBBDD77D9B35BA368C2417FA482DD0A58, L_14, /*hidden argument*/NULL);
			V_1 = L_18;
			int32_t L_19 = V_0;
			V_0 = ((int32_t)il2cpp_codegen_add((int32_t)L_19, (int32_t)1));
		}

IL_0080:
		{
			V_8 = (bool)0;
			SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * L_20 = ___activeStatement0;
			if (L_20)
			{
				goto IL_00a0;
			}
		}

IL_0089:
		{
			SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_21 = __this->get__command_1();
			NullCheck(L_21);
			List_1_t061A89EAEE080F1782627C91C598BD546671C91A * L_22 = L_21->get__statementList_12();
			NullCheck(L_22);
			int32_t L_23 = List_1_get_Count_mCAA6783F6B5B8ADE95B9FE96AACB89704F116A12(L_22, /*hidden argument*/List_1_get_Count_mCAA6783F6B5B8ADE95B9FE96AACB89704F116A12_RuntimeMethod_var);
			V_7 = L_23;
			goto IL_00a3;
		}

IL_00a0:
		{
			V_7 = 1;
		}

IL_00a3:
		{
			SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * L_24 = ___activeStatement0;
			V_4 = L_24;
			V_2 = 0;
			goto IL_00ef;
		}

IL_00ad:
		{
			V_8 = (bool)0;
			SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * L_25 = V_4;
			if (L_25)
			{
				goto IL_00ca;
			}
		}

IL_00b7:
		{
			SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_26 = __this->get__command_1();
			NullCheck(L_26);
			List_1_t061A89EAEE080F1782627C91C598BD546671C91A * L_27 = L_26->get__statementList_12();
			int32_t L_28 = V_2;
			NullCheck(L_27);
			SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * L_29 = List_1_get_Item_mD187885178D9436A3BEB6CF28A3C2AD837B26467(L_27, L_28, /*hidden argument*/List_1_get_Item_mD187885178D9436A3BEB6CF28A3C2AD837B26467_RuntimeMethod_var);
			V_4 = L_29;
		}

IL_00ca:
		{
			SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * L_30 = V_4;
			NullCheck(L_30);
			StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_31 = L_30->get__paramNames_4();
			if (!L_31)
			{
				goto IL_00e8;
			}
		}

IL_00d6:
		{
			SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * L_32 = V_4;
			String_t* L_33 = V_1;
			SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_34 = V_5;
			NullCheck(L_32);
			bool L_35 = SqliteStatement_MapParameter_mF2B1590F36C785FA5CDC5D79CA0F998584E5021C(L_32, L_33, L_34, /*hidden argument*/NULL);
			if (!L_35)
			{
				goto IL_00e8;
			}
		}

IL_00e5:
		{
			V_8 = (bool)1;
		}

IL_00e8:
		{
			V_4 = (SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A *)NULL;
			int32_t L_36 = V_2;
			V_2 = ((int32_t)il2cpp_codegen_add((int32_t)L_36, (int32_t)1));
		}

IL_00ef:
		{
			int32_t L_37 = V_2;
			int32_t L_38 = V_7;
			if ((((int32_t)L_37) < ((int32_t)L_38)))
			{
				goto IL_00ad;
			}
		}

IL_00f7:
		{
			bool L_39 = V_8;
			if (L_39)
			{
				goto IL_016e;
			}
		}

IL_00fe:
		{
			IL2CPP_RUNTIME_CLASS_INIT(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_il2cpp_TypeInfo_var);
			CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * L_40 = CultureInfo_get_InvariantCulture_mF13B47F8A763CE6A9C8A8BB2EED33FF8F7A63A72(/*hidden argument*/NULL);
			ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* L_41 = (ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A*)SZArrayNew(ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A_il2cpp_TypeInfo_var, (uint32_t)1);
			ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* L_42 = L_41;
			int32_t L_43 = V_3;
			int32_t L_44 = L_43;
			RuntimeObject * L_45 = Box(Int32_t585191389E07734F19F3156FF88FB3EF4800D102_il2cpp_TypeInfo_var, &L_44);
			NullCheck(L_42);
			ArrayElementTypeCheck (L_42, L_45);
			(L_42)->SetAt(static_cast<il2cpp_array_size_t>(0), (RuntimeObject *)L_45);
			String_t* L_46 = String_Format_mF68EE0DEC1AA5ADE9DFEF9AE0508E428FBB10EFD(L_40, _stringLiteralF6ECAD2FBBDD77D9B35BA368C2417FA482DD0A58, L_42, /*hidden argument*/NULL);
			V_1 = L_46;
			SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * L_47 = ___activeStatement0;
			V_4 = L_47;
			V_2 = 0;
			goto IL_0166;
		}

IL_0127:
		{
			SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * L_48 = V_4;
			if (L_48)
			{
				goto IL_0141;
			}
		}

IL_012e:
		{
			SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_49 = __this->get__command_1();
			NullCheck(L_49);
			List_1_t061A89EAEE080F1782627C91C598BD546671C91A * L_50 = L_49->get__statementList_12();
			int32_t L_51 = V_2;
			NullCheck(L_50);
			SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * L_52 = List_1_get_Item_mD187885178D9436A3BEB6CF28A3C2AD837B26467(L_50, L_51, /*hidden argument*/List_1_get_Item_mD187885178D9436A3BEB6CF28A3C2AD837B26467_RuntimeMethod_var);
			V_4 = L_52;
		}

IL_0141:
		{
			SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * L_53 = V_4;
			NullCheck(L_53);
			StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_54 = L_53->get__paramNames_4();
			if (!L_54)
			{
				goto IL_015f;
			}
		}

IL_014d:
		{
			SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * L_55 = V_4;
			String_t* L_56 = V_1;
			SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_57 = V_5;
			NullCheck(L_55);
			bool L_58 = SqliteStatement_MapParameter_mF2B1590F36C785FA5CDC5D79CA0F998584E5021C(L_55, L_56, L_57, /*hidden argument*/NULL);
			if (!L_58)
			{
				goto IL_015f;
			}
		}

IL_015c:
		{
			V_8 = (bool)1;
		}

IL_015f:
		{
			V_4 = (SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A *)NULL;
			int32_t L_59 = V_2;
			V_2 = ((int32_t)il2cpp_codegen_add((int32_t)L_59, (int32_t)1));
		}

IL_0166:
		{
			int32_t L_60 = V_2;
			int32_t L_61 = V_7;
			if ((((int32_t)L_60) < ((int32_t)L_61)))
			{
				goto IL_0127;
			}
		}

IL_016e:
		{
			bool L_62 = Enumerator_MoveNext_mAA17145AA0994543090AFFF741659D345AC64F9F((Enumerator_tA18C55D69C7008726BD92603BF88561F27BB708A *)(&V_6), /*hidden argument*/Enumerator_MoveNext_mAA17145AA0994543090AFFF741659D345AC64F9F_RuntimeMethod_var);
			if (L_62)
			{
				goto IL_0042;
			}
		}

IL_017a:
		{
			IL2CPP_LEAVE(0x18C, FINALLY_017f);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_017f;
	}

FINALLY_017f:
	{ // begin finally (depth: 1)
		Enumerator_tA18C55D69C7008726BD92603BF88561F27BB708A  L_63 = V_6;
		Enumerator_tA18C55D69C7008726BD92603BF88561F27BB708A  L_64 = L_63;
		RuntimeObject * L_65 = Box(Enumerator_tA18C55D69C7008726BD92603BF88561F27BB708A_il2cpp_TypeInfo_var, &L_64);
		Enumerator_Dispose_m69EFA6DF9BD1ACE3D21EC0B240A2FB37E3AC96D0((Enumerator_tA18C55D69C7008726BD92603BF88561F27BB708A *)UnBox(L_65, Enumerator_tA18C55D69C7008726BD92603BF88561F27BB708A_il2cpp_TypeInfo_var), /*hidden argument*/Enumerator_Dispose_m69EFA6DF9BD1ACE3D21EC0B240A2FB37E3AC96D0_RuntimeMethod_var);
		IL2CPP_END_FINALLY(383)
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(383)
	{
		IL2CPP_JUMP_TBL(0x18C, IL_018c)
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
	}

IL_018c:
	{
		SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * L_66 = ___activeStatement0;
		if (L_66)
		{
			goto IL_0199;
		}
	}
	{
		__this->set__unboundFlag_3((bool)0);
	}

IL_0199:
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
// System.Void Mono.Data.Sqlite.SqliteStatement::.ctor(Mono.Data.Sqlite.SQLiteBase,Mono.Data.Sqlite.SqliteStatementHandle,System.String,Mono.Data.Sqlite.SqliteStatement)
extern "C" IL2CPP_METHOD_ATTR void SqliteStatement__ctor_m8917E2A4F6C6F85D238593B8A14E454FC11E12C4 (SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * __this, SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * ___sqlbase0, SqliteStatementHandle_t6121E676E0AB6EA25E9168EB18C7A064E83DBBBE * ___stmt1, String_t* ___strCommand2, SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * ___previous3, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteStatement__ctor_m8917E2A4F6C6F85D238593B8A14E454FC11E12C4_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	String_t* V_3 = NULL;
	{
		Object__ctor_m925ECA5E85CA100E3FB86A4F9E15C120E9A184C0(__this, /*hidden argument*/NULL);
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_0 = ___sqlbase0;
		__this->set__sql_0(L_0);
		SqliteStatementHandle_t6121E676E0AB6EA25E9168EB18C7A064E83DBBBE * L_1 = ___stmt1;
		__this->set__sqlite_stmt_2(L_1);
		String_t* L_2 = ___strCommand2;
		__this->set__sqlStatement_1(L_2);
		V_0 = 0;
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_3 = __this->get__sql_0();
		NullCheck(L_3);
		int32_t L_4 = VirtFuncInvoker1< int32_t, SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * >::Invoke(22 /* System.Int32 Mono.Data.Sqlite.SQLiteBase::Bind_ParamCount(Mono.Data.Sqlite.SqliteStatement) */, L_3, __this);
		V_1 = L_4;
		int32_t L_5 = V_1;
		if ((((int32_t)L_5) <= ((int32_t)0)))
		{
			goto IL_00c8;
		}
	}
	{
		SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * L_6 = ___previous3;
		if (!L_6)
		{
			goto IL_0040;
		}
	}
	{
		SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * L_7 = ___previous3;
		NullCheck(L_7);
		int32_t L_8 = L_7->get__unnamedParameters_3();
		V_0 = L_8;
	}

IL_0040:
	{
		int32_t L_9 = V_1;
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_10 = (StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E*)SZArrayNew(StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E_il2cpp_TypeInfo_var, (uint32_t)L_9);
		__this->set__paramNames_4(L_10);
		int32_t L_11 = V_1;
		SqliteParameterU5BU5D_t76F2417476AE80EE92606466B015185F4EEF2C27* L_12 = (SqliteParameterU5BU5D_t76F2417476AE80EE92606466B015185F4EEF2C27*)SZArrayNew(SqliteParameterU5BU5D_t76F2417476AE80EE92606466B015185F4EEF2C27_il2cpp_TypeInfo_var, (uint32_t)L_11);
		__this->set__paramValues_5(L_12);
		V_2 = 0;
		goto IL_00c1;
	}

IL_005f:
	{
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_13 = __this->get__sql_0();
		int32_t L_14 = V_2;
		NullCheck(L_13);
		String_t* L_15 = VirtFuncInvoker2< String_t*, SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A *, int32_t >::Invoke(23 /* System.String Mono.Data.Sqlite.SQLiteBase::Bind_ParamName(Mono.Data.Sqlite.SqliteStatement,System.Int32) */, L_13, __this, ((int32_t)il2cpp_codegen_add((int32_t)L_14, (int32_t)1)));
		V_3 = L_15;
		String_t* L_16 = V_3;
		bool L_17 = String_IsNullOrEmpty_m06A85A206AC2106D1982826C5665B9BD35324229(L_16, /*hidden argument*/NULL);
		if (!L_17)
		{
			goto IL_00ab;
		}
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_il2cpp_TypeInfo_var);
		CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * L_18 = CultureInfo_get_InvariantCulture_mF13B47F8A763CE6A9C8A8BB2EED33FF8F7A63A72(/*hidden argument*/NULL);
		ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* L_19 = (ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A*)SZArrayNew(ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A_il2cpp_TypeInfo_var, (uint32_t)1);
		ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* L_20 = L_19;
		int32_t L_21 = V_0;
		int32_t L_22 = L_21;
		RuntimeObject * L_23 = Box(Int32_t585191389E07734F19F3156FF88FB3EF4800D102_il2cpp_TypeInfo_var, &L_22);
		NullCheck(L_20);
		ArrayElementTypeCheck (L_20, L_23);
		(L_20)->SetAt(static_cast<il2cpp_array_size_t>(0), (RuntimeObject *)L_23);
		String_t* L_24 = String_Format_mF68EE0DEC1AA5ADE9DFEF9AE0508E428FBB10EFD(L_18, _stringLiteralF6ECAD2FBBDD77D9B35BA368C2417FA482DD0A58, L_20, /*hidden argument*/NULL);
		V_3 = L_24;
		int32_t L_25 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add((int32_t)L_25, (int32_t)1));
		int32_t L_26 = __this->get__unnamedParameters_3();
		__this->set__unnamedParameters_3(((int32_t)il2cpp_codegen_add((int32_t)L_26, (int32_t)1)));
	}

IL_00ab:
	{
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_27 = __this->get__paramNames_4();
		int32_t L_28 = V_2;
		String_t* L_29 = V_3;
		NullCheck(L_27);
		ArrayElementTypeCheck (L_27, L_29);
		(L_27)->SetAt(static_cast<il2cpp_array_size_t>(L_28), (String_t*)L_29);
		SqliteParameterU5BU5D_t76F2417476AE80EE92606466B015185F4EEF2C27* L_30 = __this->get__paramValues_5();
		int32_t L_31 = V_2;
		NullCheck(L_30);
		ArrayElementTypeCheck (L_30, NULL);
		(L_30)->SetAt(static_cast<il2cpp_array_size_t>(L_31), (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E *)NULL);
		int32_t L_32 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add((int32_t)L_32, (int32_t)1));
	}

IL_00c1:
	{
		int32_t L_33 = V_2;
		int32_t L_34 = V_1;
		if ((((int32_t)L_33) < ((int32_t)L_34)))
		{
			goto IL_005f;
		}
	}

IL_00c8:
	{
		return;
	}
}
// System.Boolean Mono.Data.Sqlite.SqliteStatement::MapParameter(System.String,Mono.Data.Sqlite.SqliteParameter)
extern "C" IL2CPP_METHOD_ATTR bool SqliteStatement_MapParameter_mF2B1590F36C785FA5CDC5D79CA0F998584E5021C (SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * __this, String_t* ___s0, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * ___p1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteStatement_MapParameter_mF2B1590F36C785FA5CDC5D79CA0F998584E5021C_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	{
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_0 = __this->get__paramNames_4();
		if (L_0)
		{
			goto IL_000d;
		}
	}
	{
		return (bool)0;
	}

IL_000d:
	{
		V_0 = 0;
		String_t* L_1 = ___s0;
		NullCheck(L_1);
		int32_t L_2 = String_get_Length_mD48C8A16A5CF1914F330DCE82D9BE15C3BEDD018(L_1, /*hidden argument*/NULL);
		if ((((int32_t)L_2) <= ((int32_t)0)))
		{
			goto IL_0034;
		}
	}
	{
		String_t* L_3 = ___s0;
		NullCheck(L_3);
		Il2CppChar L_4 = String_get_Chars_m14308AC3B95F8C1D9F1D1055B116B37D595F1D96(L_3, 0, /*hidden argument*/NULL);
		NullCheck(_stringLiteral4152C03A902AA9F8A5A2B4A510C2AB07BF79F058);
		int32_t L_5 = String_IndexOf_m2909B8CF585E1BD0C81E11ACA2F48012156FD5BD(_stringLiteral4152C03A902AA9F8A5A2B4A510C2AB07BF79F058, L_4, /*hidden argument*/NULL);
		if ((!(((uint32_t)L_5) == ((uint32_t)(-1)))))
		{
			goto IL_0034;
		}
	}
	{
		V_0 = 1;
	}

IL_0034:
	{
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_6 = __this->get__paramNames_4();
		NullCheck(L_6);
		V_1 = (((int32_t)((int32_t)(((RuntimeArray *)L_6)->max_length))));
		V_2 = 0;
		goto IL_0088;
	}

IL_0044:
	{
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_7 = __this->get__paramNames_4();
		int32_t L_8 = V_2;
		NullCheck(L_7);
		int32_t L_9 = L_8;
		String_t* L_10 = (L_7)->GetAt(static_cast<il2cpp_array_size_t>(L_9));
		int32_t L_11 = V_0;
		String_t* L_12 = ___s0;
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_13 = __this->get__paramNames_4();
		int32_t L_14 = V_2;
		NullCheck(L_13);
		int32_t L_15 = L_14;
		String_t* L_16 = (L_13)->GetAt(static_cast<il2cpp_array_size_t>(L_15));
		NullCheck(L_16);
		int32_t L_17 = String_get_Length_mD48C8A16A5CF1914F330DCE82D9BE15C3BEDD018(L_16, /*hidden argument*/NULL);
		int32_t L_18 = V_0;
		String_t* L_19 = ___s0;
		NullCheck(L_19);
		int32_t L_20 = String_get_Length_mD48C8A16A5CF1914F330DCE82D9BE15C3BEDD018(L_19, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Math_tFB388E53C7FDC6FCCF9A19ABF5A4E521FBD52E19_il2cpp_TypeInfo_var);
		int32_t L_21 = Math_Max_mA99E48BB021F2E4B62D4EA9F52EA6928EED618A2(((int32_t)il2cpp_codegen_subtract((int32_t)L_17, (int32_t)L_18)), L_20, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_il2cpp_TypeInfo_var);
		CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * L_22 = CultureInfo_get_InvariantCulture_mF13B47F8A763CE6A9C8A8BB2EED33FF8F7A63A72(/*hidden argument*/NULL);
		int32_t L_23 = String_Compare_m759578081B55965D2CE733DF538FA20554F2F874(L_10, L_11, L_12, 0, L_21, (bool)1, L_22, /*hidden argument*/NULL);
		if (L_23)
		{
			goto IL_0084;
		}
	}
	{
		SqliteParameterU5BU5D_t76F2417476AE80EE92606466B015185F4EEF2C27* L_24 = __this->get__paramValues_5();
		int32_t L_25 = V_2;
		SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_26 = ___p1;
		NullCheck(L_24);
		ArrayElementTypeCheck (L_24, L_26);
		(L_24)->SetAt(static_cast<il2cpp_array_size_t>(L_25), (SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E *)L_26);
		return (bool)1;
	}

IL_0084:
	{
		int32_t L_27 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add((int32_t)L_27, (int32_t)1));
	}

IL_0088:
	{
		int32_t L_28 = V_2;
		int32_t L_29 = V_1;
		if ((((int32_t)L_28) < ((int32_t)L_29)))
		{
			goto IL_0044;
		}
	}
	{
		return (bool)0;
	}
}
// System.Void Mono.Data.Sqlite.SqliteStatement::Dispose()
extern "C" IL2CPP_METHOD_ATTR void SqliteStatement_Dispose_mC6C2A8CEF0A1A98B84D4ADD4B081959BC47A93FA (SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * __this, const RuntimeMethod* method)
{
	{
		SqliteStatementHandle_t6121E676E0AB6EA25E9168EB18C7A064E83DBBBE * L_0 = __this->get__sqlite_stmt_2();
		if (!L_0)
		{
			goto IL_0016;
		}
	}
	{
		SqliteStatementHandle_t6121E676E0AB6EA25E9168EB18C7A064E83DBBBE * L_1 = __this->get__sqlite_stmt_2();
		NullCheck(L_1);
		CriticalHandle_Dispose_mDBA1677ABB0EE5E4AB408B301A6FC58E2E75EBBF(L_1, /*hidden argument*/NULL);
	}

IL_0016:
	{
		__this->set__sqlite_stmt_2((SqliteStatementHandle_t6121E676E0AB6EA25E9168EB18C7A064E83DBBBE *)NULL);
		__this->set__paramNames_4((StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E*)NULL);
		__this->set__paramValues_5((SqliteParameterU5BU5D_t76F2417476AE80EE92606466B015185F4EEF2C27*)NULL);
		__this->set__sql_0((SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 *)NULL);
		__this->set__sqlStatement_1((String_t*)NULL);
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteStatement::BindParameters()
extern "C" IL2CPP_METHOD_ATTR void SqliteStatement_BindParameters_m15651E3FC9CF3AC00F0918EBD88205E99F3A5FF7 (SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * __this, const RuntimeMethod* method)
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	{
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_0 = __this->get__paramNames_4();
		if (L_0)
		{
			goto IL_000c;
		}
	}
	{
		return;
	}

IL_000c:
	{
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_1 = __this->get__paramNames_4();
		NullCheck(L_1);
		V_0 = (((int32_t)((int32_t)(((RuntimeArray *)L_1)->max_length))));
		V_1 = 0;
		goto IL_0031;
	}

IL_001c:
	{
		int32_t L_2 = V_1;
		SqliteParameterU5BU5D_t76F2417476AE80EE92606466B015185F4EEF2C27* L_3 = __this->get__paramValues_5();
		int32_t L_4 = V_1;
		NullCheck(L_3);
		int32_t L_5 = L_4;
		SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_6 = (L_3)->GetAt(static_cast<il2cpp_array_size_t>(L_5));
		SqliteStatement_BindParameter_m5CB198F61BDB753FDF1067AB5B624BBB5E44E513(__this, ((int32_t)il2cpp_codegen_add((int32_t)L_2, (int32_t)1)), L_6, /*hidden argument*/NULL);
		int32_t L_7 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add((int32_t)L_7, (int32_t)1));
	}

IL_0031:
	{
		int32_t L_8 = V_1;
		int32_t L_9 = V_0;
		if ((((int32_t)L_8) < ((int32_t)L_9)))
		{
			goto IL_001c;
		}
	}
	{
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteStatement::BindParameter(System.Int32,Mono.Data.Sqlite.SqliteParameter)
extern "C" IL2CPP_METHOD_ATTR void SqliteStatement_BindParameter_m5CB198F61BDB753FDF1067AB5B624BBB5E44E513 (SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * __this, int32_t ___index0, SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * ___param1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteStatement_BindParameter_m5CB198F61BDB753FDF1067AB5B624BBB5E44E513_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	RuntimeObject * V_0 = NULL;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	Guid_t  V_3;
	memset(&V_3, 0, sizeof(V_3));
	Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  V_4;
	memset(&V_4, 0, sizeof(V_4));
	{
		SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_0 = ___param1;
		if (L_0)
		{
			goto IL_0012;
		}
	}
	{
		SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6 * L_1 = (SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6 *)il2cpp_codegen_object_new(SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6_il2cpp_TypeInfo_var);
		SqliteException__ctor_m6FC576E18D88881DC33CAFC00042DCCF5D70F057(L_1, 1, _stringLiteral2ADF0A0954741E1AF5766479C5643CD51B0B69B5, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1, NULL, SqliteStatement_BindParameter_m5CB198F61BDB753FDF1067AB5B624BBB5E44E513_RuntimeMethod_var);
	}

IL_0012:
	{
		SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_2 = ___param1;
		NullCheck(L_2);
		RuntimeObject * L_3 = SqliteParameter_get_Value_mBA989781BF12F4716038CA0F772C9A033CD829C6(L_2, /*hidden argument*/NULL);
		V_0 = L_3;
		SqliteParameter_t9FAC2B9C42E405F4AF730D28C70C5A226480B88E * L_4 = ___param1;
		NullCheck(L_4);
		int32_t L_5 = SqliteParameter_get_DbType_m8622A28055C14CA1BC4A004A909780FB9A13E691(L_4, /*hidden argument*/NULL);
		V_1 = L_5;
		RuntimeObject * L_6 = V_0;
		IL2CPP_RUNTIME_CLASS_INIT(Convert_t1C7A851BFB2F0782FD7F72F6AA1DCBB7B53A9C7E_il2cpp_TypeInfo_var);
		bool L_7 = Convert_IsDBNull_m5523BC521CD361615CE6846388C7BD5BA1EDDCE5(L_6, /*hidden argument*/NULL);
		if (L_7)
		{
			goto IL_0031;
		}
	}
	{
		RuntimeObject * L_8 = V_0;
		if (L_8)
		{
			goto IL_003f;
		}
	}

IL_0031:
	{
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_9 = __this->get__sql_0();
		int32_t L_10 = ___index0;
		NullCheck(L_9);
		VirtActionInvoker2< SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A *, int32_t >::Invoke(21 /* System.Void Mono.Data.Sqlite.SQLiteBase::Bind_Null(Mono.Data.Sqlite.SqliteStatement,System.Int32) */, L_9, __this, L_10);
		return;
	}

IL_003f:
	{
		int32_t L_11 = V_1;
		if ((!(((uint32_t)L_11) == ((uint32_t)((int32_t)13)))))
		{
			goto IL_0053;
		}
	}
	{
		RuntimeObject * L_12 = V_0;
		NullCheck(L_12);
		Type_t * L_13 = Object_GetType_m2E0B62414ECCAA3094B703790CE88CBB2F83EA60(L_12, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(SqliteConvert_t9FED20EF4CA9E373EBD857ECBA9C74B6307EE6E7_il2cpp_TypeInfo_var);
		int32_t L_14 = SqliteConvert_TypeToDbType_mCEFBA85B101BCF9131178D3E11B9D10198F0A026(L_13, /*hidden argument*/NULL);
		V_1 = L_14;
	}

IL_0053:
	{
		int32_t L_15 = V_1;
		V_2 = L_15;
		int32_t L_16 = V_2;
		switch (((int32_t)il2cpp_codegen_subtract((int32_t)L_16, (int32_t)1)))
		{
			case 0:
			{
				goto IL_0126;
			}
			case 1:
			{
				goto IL_00ec;
			}
			case 2:
			{
				goto IL_00ec;
			}
			case 3:
			{
				goto IL_0109;
			}
			case 4:
			{
				goto IL_00b2;
			}
			case 5:
			{
				goto IL_00b2;
			}
			case 6:
			{
				goto IL_018b;
			}
			case 7:
			{
				goto IL_0109;
			}
			case 8:
			{
				goto IL_013e;
			}
			case 9:
			{
				goto IL_00ec;
			}
			case 10:
			{
				goto IL_00ec;
			}
			case 11:
			{
				goto IL_00cf;
			}
			case 12:
			{
				goto IL_01b6;
			}
			case 13:
			{
				goto IL_00ec;
			}
			case 14:
			{
				goto IL_0109;
			}
			case 15:
			{
				goto IL_01b6;
			}
			case 16:
			{
				goto IL_00b2;
			}
			case 17:
			{
				goto IL_00ec;
			}
			case 18:
			{
				goto IL_00ec;
			}
			case 19:
			{
				goto IL_00cf;
			}
		}
	}
	{
		goto IL_01b6;
	}

IL_00b2:
	{
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_17 = __this->get__sql_0();
		int32_t L_18 = ___index0;
		RuntimeObject * L_19 = V_0;
		IL2CPP_RUNTIME_CLASS_INIT(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_il2cpp_TypeInfo_var);
		CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * L_20 = CultureInfo_get_CurrentCulture_mD86F3D8E5D332FB304F80D9B9CA4DE849C2A6831(/*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Convert_t1C7A851BFB2F0782FD7F72F6AA1DCBB7B53A9C7E_il2cpp_TypeInfo_var);
		DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132  L_21 = Convert_ToDateTime_m246003CF3103F7DF9D6E817DCEFAE2CF8068862D(L_19, L_20, /*hidden argument*/NULL);
		NullCheck(L_17);
		VirtActionInvoker3< SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A *, int32_t, DateTime_t349B7449FBAAFF4192636E2B7A07694DA9236132  >::Invoke(20 /* System.Void Mono.Data.Sqlite.SQLiteBase::Bind_DateTime(Mono.Data.Sqlite.SqliteStatement,System.Int32,System.DateTime) */, L_17, __this, L_18, L_21);
		goto IL_01ce;
	}

IL_00cf:
	{
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_22 = __this->get__sql_0();
		int32_t L_23 = ___index0;
		RuntimeObject * L_24 = V_0;
		IL2CPP_RUNTIME_CLASS_INIT(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_il2cpp_TypeInfo_var);
		CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * L_25 = CultureInfo_get_CurrentCulture_mD86F3D8E5D332FB304F80D9B9CA4DE849C2A6831(/*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Convert_t1C7A851BFB2F0782FD7F72F6AA1DCBB7B53A9C7E_il2cpp_TypeInfo_var);
		int64_t L_26 = Convert_ToInt64_m8964FDE5D82FEC54106DBF35E1F67D70F6E73E29(L_24, L_25, /*hidden argument*/NULL);
		NullCheck(L_22);
		VirtActionInvoker3< SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A *, int32_t, int64_t >::Invoke(17 /* System.Void Mono.Data.Sqlite.SQLiteBase::Bind_Int64(Mono.Data.Sqlite.SqliteStatement,System.Int32,System.Int64) */, L_22, __this, L_23, L_26);
		goto IL_01ce;
	}

IL_00ec:
	{
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_27 = __this->get__sql_0();
		int32_t L_28 = ___index0;
		RuntimeObject * L_29 = V_0;
		IL2CPP_RUNTIME_CLASS_INIT(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_il2cpp_TypeInfo_var);
		CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * L_30 = CultureInfo_get_CurrentCulture_mD86F3D8E5D332FB304F80D9B9CA4DE849C2A6831(/*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Convert_t1C7A851BFB2F0782FD7F72F6AA1DCBB7B53A9C7E_il2cpp_TypeInfo_var);
		int32_t L_31 = Convert_ToInt32_m5D40340597602FB6C20BAB933E8B29617232757A(L_29, L_30, /*hidden argument*/NULL);
		NullCheck(L_27);
		VirtActionInvoker3< SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A *, int32_t, int32_t >::Invoke(16 /* System.Void Mono.Data.Sqlite.SQLiteBase::Bind_Int32(Mono.Data.Sqlite.SqliteStatement,System.Int32,System.Int32) */, L_27, __this, L_28, L_31);
		goto IL_01ce;
	}

IL_0109:
	{
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_32 = __this->get__sql_0();
		int32_t L_33 = ___index0;
		RuntimeObject * L_34 = V_0;
		IL2CPP_RUNTIME_CLASS_INIT(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_il2cpp_TypeInfo_var);
		CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * L_35 = CultureInfo_get_CurrentCulture_mD86F3D8E5D332FB304F80D9B9CA4DE849C2A6831(/*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Convert_t1C7A851BFB2F0782FD7F72F6AA1DCBB7B53A9C7E_il2cpp_TypeInfo_var);
		double L_36 = Convert_ToDouble_m053A47D87C59CA7A87D4E67E5E06368D775D7651(L_34, L_35, /*hidden argument*/NULL);
		NullCheck(L_32);
		VirtActionInvoker3< SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A *, int32_t, double >::Invoke(15 /* System.Void Mono.Data.Sqlite.SQLiteBase::Bind_Double(Mono.Data.Sqlite.SqliteStatement,System.Int32,System.Double) */, L_32, __this, L_33, L_36);
		goto IL_01ce;
	}

IL_0126:
	{
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_37 = __this->get__sql_0();
		int32_t L_38 = ___index0;
		RuntimeObject * L_39 = V_0;
		NullCheck(L_37);
		VirtActionInvoker3< SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A *, int32_t, ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* >::Invoke(19 /* System.Void Mono.Data.Sqlite.SQLiteBase::Bind_Blob(Mono.Data.Sqlite.SqliteStatement,System.Int32,System.Byte[]) */, L_37, __this, L_38, ((ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821*)Castclass((RuntimeObject*)L_39, ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821_il2cpp_TypeInfo_var)));
		goto IL_01ce;
	}

IL_013e:
	{
		SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_40 = __this->get__command_6();
		NullCheck(L_40);
		SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * L_41 = SqliteCommand_get_Connection_m7A2E3DCA5201FD25759EA80BB3F6B7421FF5D668(L_40, /*hidden argument*/NULL);
		NullCheck(L_41);
		bool L_42 = L_41->get__binaryGuid_13();
		if (!L_42)
		{
			goto IL_0173;
		}
	}
	{
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_43 = __this->get__sql_0();
		int32_t L_44 = ___index0;
		RuntimeObject * L_45 = V_0;
		V_3 = ((*(Guid_t *)((Guid_t *)UnBox(L_45, Guid_t_il2cpp_TypeInfo_var))));
		ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* L_46 = Guid_ToByteArray_m5E99B09A26EA3A1943CC8FE697E247DAC5465223((Guid_t *)(&V_3), /*hidden argument*/NULL);
		NullCheck(L_43);
		VirtActionInvoker3< SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A *, int32_t, ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* >::Invoke(19 /* System.Void Mono.Data.Sqlite.SQLiteBase::Bind_Blob(Mono.Data.Sqlite.SqliteStatement,System.Int32,System.Byte[]) */, L_43, __this, L_44, L_46);
		goto IL_0186;
	}

IL_0173:
	{
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_47 = __this->get__sql_0();
		int32_t L_48 = ___index0;
		RuntimeObject * L_49 = V_0;
		NullCheck(L_49);
		String_t* L_50 = VirtFuncInvoker0< String_t* >::Invoke(3 /* System.String System.Object::ToString() */, L_49);
		NullCheck(L_47);
		VirtActionInvoker3< SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A *, int32_t, String_t* >::Invoke(18 /* System.Void Mono.Data.Sqlite.SQLiteBase::Bind_Text(Mono.Data.Sqlite.SqliteStatement,System.Int32,System.String) */, L_47, __this, L_48, L_50);
	}

IL_0186:
	{
		goto IL_01ce;
	}

IL_018b:
	{
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_51 = __this->get__sql_0();
		int32_t L_52 = ___index0;
		RuntimeObject * L_53 = V_0;
		IL2CPP_RUNTIME_CLASS_INIT(CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F_il2cpp_TypeInfo_var);
		CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * L_54 = CultureInfo_get_CurrentCulture_mD86F3D8E5D332FB304F80D9B9CA4DE849C2A6831(/*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Convert_t1C7A851BFB2F0782FD7F72F6AA1DCBB7B53A9C7E_il2cpp_TypeInfo_var);
		Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  L_55 = Convert_ToDecimal_mD8F65E8B251DBE61789CAD032172D089375D1E5B(L_53, L_54, /*hidden argument*/NULL);
		V_4 = L_55;
		CultureInfo_t345AC6924134F039ED9A11F3E03F8E91B6A3225F * L_56 = CultureInfo_get_InvariantCulture_mF13B47F8A763CE6A9C8A8BB2EED33FF8F7A63A72(/*hidden argument*/NULL);
		String_t* L_57 = Decimal_ToString_mC257A35A991F88D3CFE6F29F619F8EC9D1D5ADFB((Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8 *)(&V_4), L_56, /*hidden argument*/NULL);
		NullCheck(L_51);
		VirtActionInvoker3< SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A *, int32_t, String_t* >::Invoke(18 /* System.Void Mono.Data.Sqlite.SQLiteBase::Bind_Text(Mono.Data.Sqlite.SqliteStatement,System.Int32,System.String) */, L_51, __this, L_52, L_57);
		goto IL_01ce;
	}

IL_01b6:
	{
		SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699 * L_58 = __this->get__sql_0();
		int32_t L_59 = ___index0;
		RuntimeObject * L_60 = V_0;
		NullCheck(L_60);
		String_t* L_61 = VirtFuncInvoker0< String_t* >::Invoke(3 /* System.String System.Object::ToString() */, L_60);
		NullCheck(L_58);
		VirtActionInvoker3< SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A *, int32_t, String_t* >::Invoke(18 /* System.Void Mono.Data.Sqlite.SQLiteBase::Bind_Text(Mono.Data.Sqlite.SqliteStatement,System.Int32,System.String) */, L_58, __this, L_59, L_61);
		goto IL_01ce;
	}

IL_01ce:
	{
		return;
	}
}
// System.String[] Mono.Data.Sqlite.SqliteStatement::get_TypeDefinitions()
extern "C" IL2CPP_METHOD_ATTR StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* SqliteStatement_get_TypeDefinitions_m3739EF28FDC74AC6E2A8334190DF8D3E8A6D1B03 (SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * __this, const RuntimeMethod* method)
{
	{
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_0 = __this->get__types_7();
		return L_0;
	}
}
// System.Void Mono.Data.Sqlite.SqliteStatement::SetTypes(System.String)
extern "C" IL2CPP_METHOD_ATTR void SqliteStatement_SetTypes_m21B385B07A712E6813527EF3590E0CA231F77F15 (SqliteStatement_tA0BDCDA8DC5F25726EEF779D832B662E889BCA1A * __this, String_t* ___typedefs0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteStatement_SetTypes_m21B385B07A712E6813527EF3590E0CA231F77F15_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* V_1 = NULL;
	int32_t V_2 = 0;
	{
		String_t* L_0 = ___typedefs0;
		NullCheck(L_0);
		int32_t L_1 = String_IndexOf_m2B8FDE7216A37799B7B3A093EDDF1A820AAF4D01(L_0, _stringLiteral40EA9041285003E004A8F6FE2DD14EBB07961AF2, 0, 5, /*hidden argument*/NULL);
		V_0 = L_1;
		int32_t L_2 = V_0;
		if ((!(((uint32_t)L_2) == ((uint32_t)(-1)))))
		{
			goto IL_001b;
		}
	}
	{
		ArgumentOutOfRangeException_t94D19DF918A54511AEDF4784C9A08741BAD1DEDA * L_3 = (ArgumentOutOfRangeException_t94D19DF918A54511AEDF4784C9A08741BAD1DEDA *)il2cpp_codegen_object_new(ArgumentOutOfRangeException_t94D19DF918A54511AEDF4784C9A08741BAD1DEDA_il2cpp_TypeInfo_var);
		ArgumentOutOfRangeException__ctor_m215F35137EDD190A037E2E9BDA3BF5DC056FD7C3(L_3, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_3, NULL, SqliteStatement_SetTypes_m21B385B07A712E6813527EF3590E0CA231F77F15_RuntimeMethod_var);
	}

IL_001b:
	{
		String_t* L_4 = ___typedefs0;
		int32_t L_5 = V_0;
		NullCheck(L_4);
		String_t* L_6 = String_Substring_m2C4AFF5E79DD8BADFD2DFBCF156BF728FBB8E1AE(L_4, ((int32_t)il2cpp_codegen_add((int32_t)L_5, (int32_t)6)), /*hidden argument*/NULL);
		String_t* L_7 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_5();
		NullCheck(L_6);
		String_t* L_8 = String_Replace_m970DFB0A280952FA7D3BA20AB7A8FB9F80CF6470(L_6, _stringLiteralB858CB282617FB0956D960215C8E84D1CCF909C6, L_7, /*hidden argument*/NULL);
		String_t* L_9 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_5();
		NullCheck(L_8);
		String_t* L_10 = String_Replace_m970DFB0A280952FA7D3BA20AB7A8FB9F80CF6470(L_8, _stringLiteral2D14AB97CC3DC294C51C0D6814F4EA45F4B4E312, L_9, /*hidden argument*/NULL);
		String_t* L_11 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_5();
		NullCheck(L_10);
		String_t* L_12 = String_Replace_m970DFB0A280952FA7D3BA20AB7A8FB9F80CF6470(L_10, _stringLiteral2ACE62C1BEFA19E3EA37DD52BE9F6D508C5163E6, L_11, /*hidden argument*/NULL);
		String_t* L_13 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_5();
		NullCheck(L_12);
		String_t* L_14 = String_Replace_m970DFB0A280952FA7D3BA20AB7A8FB9F80CF6470(L_12, _stringLiteral1E5C2F367F02E47A8C160CDA1CD9D91DECBAC441, L_13, /*hidden argument*/NULL);
		String_t* L_15 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_5();
		NullCheck(L_14);
		String_t* L_16 = String_Replace_m970DFB0A280952FA7D3BA20AB7A8FB9F80CF6470(L_14, _stringLiteral4FF447B8EF42CA51FA6FB287BED8D40F49BE58F1, L_15, /*hidden argument*/NULL);
		String_t* L_17 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->get_Empty_5();
		NullCheck(L_16);
		String_t* L_18 = String_Replace_m970DFB0A280952FA7D3BA20AB7A8FB9F80CF6470(L_16, _stringLiteral7E15BB5C01E7DD56499E37C634CF791D3A519AEE, L_17, /*hidden argument*/NULL);
		CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* L_19 = (CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2*)SZArrayNew(CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2_il2cpp_TypeInfo_var, (uint32_t)4);
		CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* L_20 = L_19;
		RuntimeFieldHandle_t844BDF00E8E6FE69D9AEAA7657F09018B864F4EF  L_21 = { reinterpret_cast<intptr_t> (U3CPrivateImplementationDetailsU3E_t0F71ABB0B2D76FF373FCA1CFC6711DBF4293313F____U24U24fieldU2D1_1_FieldInfo_var) };
		RuntimeHelpers_InitializeArray_m29F50CDFEEE0AB868200291366253DD4737BC76A((RuntimeArray *)(RuntimeArray *)L_20, L_21, /*hidden argument*/NULL);
		NullCheck(L_18);
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_22 = String_Split_m13262358217AD2C119FD1B9733C3C0289D608512(L_18, L_20, /*hidden argument*/NULL);
		V_1 = L_22;
		V_2 = 0;
		goto IL_00b1;
	}

IL_009c:
	{
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_23 = V_1;
		int32_t L_24 = V_2;
		NullCheck(L_23);
		int32_t L_25 = L_24;
		String_t* L_26 = (L_23)->GetAt(static_cast<il2cpp_array_size_t>(L_25));
		bool L_27 = String_IsNullOrEmpty_m06A85A206AC2106D1982826C5665B9BD35324229(L_26, /*hidden argument*/NULL);
		if (!L_27)
		{
			goto IL_00ad;
		}
	}
	{
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_28 = V_1;
		int32_t L_29 = V_2;
		NullCheck(L_28);
		ArrayElementTypeCheck (L_28, NULL);
		(L_28)->SetAt(static_cast<il2cpp_array_size_t>(L_29), (String_t*)NULL);
	}

IL_00ad:
	{
		int32_t L_30 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add((int32_t)L_30, (int32_t)1));
	}

IL_00b1:
	{
		int32_t L_31 = V_2;
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_32 = V_1;
		NullCheck(L_32);
		if ((((int32_t)L_31) < ((int32_t)(((int32_t)((int32_t)(((RuntimeArray *)L_32)->max_length)))))))
		{
			goto IL_009c;
		}
	}
	{
		StringU5BU5D_t933FB07893230EA91C40FF900D5400665E87B14E* L_33 = V_1;
		__this->set__types_7(L_33);
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
// System.Void Mono.Data.Sqlite.SqliteStatementHandle::.ctor(System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR void SqliteStatementHandle__ctor_m21BBF1AAEBF8FB0FF480424BD6DCC307CA524E31 (SqliteStatementHandle_t6121E676E0AB6EA25E9168EB18C7A064E83DBBBE * __this, intptr_t ___stmt0, const RuntimeMethod* method)
{
	{
		SqliteStatementHandle__ctor_m6F5DE40FE027CE6BE127C05AFA4D20161B8D9FA6(__this, /*hidden argument*/NULL);
		intptr_t L_0 = ___stmt0;
		CriticalHandle_SetHandle_m4EE9D69A73EF79440558738F688DA93682B8A955(__this, (intptr_t)L_0, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteStatementHandle::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SqliteStatementHandle__ctor_m6F5DE40FE027CE6BE127C05AFA4D20161B8D9FA6 (SqliteStatementHandle_t6121E676E0AB6EA25E9168EB18C7A064E83DBBBE * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteStatementHandle__ctor_m6F5DE40FE027CE6BE127C05AFA4D20161B8D9FA6_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		CriticalHandle__ctor_m63298C852798FD29EC96265E0D6F5B3E72398349(__this, (intptr_t)(0), /*hidden argument*/NULL);
		return;
	}
}
// System.Boolean Mono.Data.Sqlite.SqliteStatementHandle::ReleaseHandle()
extern "C" IL2CPP_METHOD_ATTR bool SqliteStatementHandle_ReleaseHandle_m262CB72DCE79FFCF324BF8DD459EB17C6B1C1FD6 (SqliteStatementHandle_t6121E676E0AB6EA25E9168EB18C7A064E83DBBBE * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteStatementHandle_ReleaseHandle_m262CB72DCE79FFCF324BF8DD459EB17C6B1C1FD6_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	void* __leave_targets_storage = alloca(sizeof(int32_t) * 2);
	il2cpp::utils::LeaveTargetStack __leave_targets(__leave_targets_storage);
	NO_UNUSED_WARNING (__leave_targets);

IL_0000:
	try
	{ // begin try (depth: 1)
		IL2CPP_RUNTIME_CLASS_INIT(SQLiteBase_t59AAE9C52C98137708374575A69B76DB362B4699_il2cpp_TypeInfo_var);
		SQLiteBase_FinalizeStatement_m7C0B1BC424ADF09FD45F18EE242F5FADB0A324DA(__this, /*hidden argument*/NULL);
		goto IL_0011;
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__exception_local = (Exception_t *)e.ex;
		if(il2cpp_codegen_class_is_assignable_from (SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6_il2cpp_TypeInfo_var, il2cpp_codegen_object_class(e.ex)))
			goto CATCH_000b;
		throw e;
	}

CATCH_000b:
	{ // begin catch(Mono.Data.Sqlite.SqliteException)
		goto IL_0011;
	} // end catch (depth: 1)

IL_0011:
	{
		return (bool)1;
	}
}
// System.Boolean Mono.Data.Sqlite.SqliteStatementHandle::get_IsInvalid()
extern "C" IL2CPP_METHOD_ATTR bool SqliteStatementHandle_get_IsInvalid_mEFD73F5A7BD13FAA13C92CF31E97D7D0B5CFD883 (SqliteStatementHandle_t6121E676E0AB6EA25E9168EB18C7A064E83DBBBE * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteStatementHandle_get_IsInvalid_mEFD73F5A7BD13FAA13C92CF31E97D7D0B5CFD883_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		intptr_t L_0 = ((CriticalHandle_tDF3AA1D1AA9E07599C316DB1C5449D3FB7BFD4C9 *)__this)->get_handle_0();
		bool L_1 = IntPtr_op_Equality_mEE8D9FD2DFE312BBAA8B4ED3BF7976B3142A5934((intptr_t)L_0, (intptr_t)(0), /*hidden argument*/NULL);
		return L_1;
	}
}
// System.IntPtr Mono.Data.Sqlite.SqliteStatementHandle::op_Implicit(Mono.Data.Sqlite.SqliteStatementHandle)
extern "C" IL2CPP_METHOD_ATTR intptr_t SqliteStatementHandle_op_Implicit_m6B56216CED2A934DE65DD19564AB6953C0731834 (SqliteStatementHandle_t6121E676E0AB6EA25E9168EB18C7A064E83DBBBE * ___stmt0, const RuntimeMethod* method)
{
	{
		SqliteStatementHandle_t6121E676E0AB6EA25E9168EB18C7A064E83DBBBE * L_0 = ___stmt0;
		NullCheck(L_0);
		intptr_t L_1 = ((CriticalHandle_tDF3AA1D1AA9E07599C316DB1C5449D3FB7BFD4C9 *)L_0)->get_handle_0();
		return (intptr_t)L_1;
	}
}
// Mono.Data.Sqlite.SqliteStatementHandle Mono.Data.Sqlite.SqliteStatementHandle::op_Implicit(System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR SqliteStatementHandle_t6121E676E0AB6EA25E9168EB18C7A064E83DBBBE * SqliteStatementHandle_op_Implicit_mD49D21BFB9C321E8F0ECC04E0469EBC6DF58AD05 (intptr_t ___stmt0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteStatementHandle_op_Implicit_mD49D21BFB9C321E8F0ECC04E0469EBC6DF58AD05_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		intptr_t L_0 = ___stmt0;
		SqliteStatementHandle_t6121E676E0AB6EA25E9168EB18C7A064E83DBBBE * L_1 = (SqliteStatementHandle_t6121E676E0AB6EA25E9168EB18C7A064E83DBBBE *)il2cpp_codegen_object_new(SqliteStatementHandle_t6121E676E0AB6EA25E9168EB18C7A064E83DBBBE_il2cpp_TypeInfo_var);
		SqliteStatementHandle__ctor_m21BBF1AAEBF8FB0FF480424BD6DCC307CA524E31(L_1, (intptr_t)L_0, /*hidden argument*/NULL);
		return L_1;
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
// System.Void Mono.Data.Sqlite.SqliteTransaction::.ctor(Mono.Data.Sqlite.SqliteConnection,System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void SqliteTransaction__ctor_m59995FF6874597512ED2217BBC41266B2A0F7CAF (SqliteTransaction_t588D1AEC987A56478BF3B4254D6F83A4740F1560 * __this, SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * ___connection0, bool ___deferredLock1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteTransaction__ctor_m59995FF6874597512ED2217BBC41266B2A0F7CAF_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * V_0 = NULL;
	int32_t V_1 = 0;
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	void* __leave_targets_storage = alloca(sizeof(int32_t) * 3);
	il2cpp::utils::LeaveTargetStack __leave_targets(__leave_targets_storage);
	NO_UNUSED_WARNING (__leave_targets);
	SqliteTransaction_t588D1AEC987A56478BF3B4254D6F83A4740F1560 * G_B2_0 = NULL;
	SqliteTransaction_t588D1AEC987A56478BF3B4254D6F83A4740F1560 * G_B1_0 = NULL;
	int32_t G_B3_0 = 0;
	SqliteTransaction_t588D1AEC987A56478BF3B4254D6F83A4740F1560 * G_B3_1 = NULL;
	{
		DbTransaction__ctor_mEB19A16BE9BED0A70FDCC7E5EC8134E85EEA327B(__this, /*hidden argument*/NULL);
		SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * L_0 = ___connection0;
		__this->set__cnn_1(L_0);
		SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * L_1 = __this->get__cnn_1();
		NullCheck(L_1);
		int64_t L_2 = L_1->get__version_14();
		__this->set__version_2(L_2);
		bool L_3 = ___deferredLock1;
		G_B1_0 = __this;
		if (!L_3)
		{
			G_B2_0 = __this;
			goto IL_002f;
		}
	}
	{
		G_B3_0 = ((int32_t)4096);
		G_B3_1 = G_B1_0;
		goto IL_0034;
	}

IL_002f:
	{
		G_B3_0 = ((int32_t)1048576);
		G_B3_1 = G_B2_0;
	}

IL_0034:
	{
		NullCheck(G_B3_1);
		G_B3_1->set__level_3(G_B3_0);
		SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * L_4 = __this->get__cnn_1();
		SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * L_5 = L_4;
		NullCheck(L_5);
		int32_t L_6 = L_5->get__transactionLevel_6();
		int32_t L_7 = L_6;
		V_1 = L_7;
		NullCheck(L_5);
		L_5->set__transactionLevel_6(((int32_t)il2cpp_codegen_add((int32_t)L_7, (int32_t)1)));
		int32_t L_8 = V_1;
		if (L_8)
		{
			goto IL_00c1;
		}
	}

IL_0054:
	try
	{ // begin try (depth: 1)
		{
			SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * L_9 = __this->get__cnn_1();
			NullCheck(L_9);
			SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_10 = SqliteConnection_CreateCommand_mE54467D789E72E02161682F6456682545037F3A3(L_9, /*hidden argument*/NULL);
			V_0 = L_10;
		}

IL_0060:
		try
		{ // begin try (depth: 2)
			{
				bool L_11 = ___deferredLock1;
				if (L_11)
				{
					goto IL_0076;
				}
			}

IL_0066:
			{
				SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_12 = V_0;
				NullCheck(L_12);
				SqliteCommand_set_CommandText_mE49B5EE0CD14901BC847B155D4B784B1EAE1D782(L_12, _stringLiteral4821EDEB87E72FFADC6BC2DD7758D1AF495E515F, /*hidden argument*/NULL);
				goto IL_0081;
			}

IL_0076:
			{
				SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_13 = V_0;
				NullCheck(L_13);
				SqliteCommand_set_CommandText_mE49B5EE0CD14901BC847B155D4B784B1EAE1D782(L_13, _stringLiteral3598517C826F1480A241800CE73F781AE2B1CD6A, /*hidden argument*/NULL);
			}

IL_0081:
			{
				SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_14 = V_0;
				NullCheck(L_14);
				SqliteCommand_ExecuteNonQuery_m0852FE0BAA62C3A909437FA9780008C4C1FAFE54(L_14, /*hidden argument*/NULL);
				IL2CPP_LEAVE(0x9A, FINALLY_008d);
			}
		} // end try (depth: 2)
		catch(Il2CppExceptionWrapper& e)
		{
			__last_unhandled_exception = (Exception_t *)e.ex;
			goto FINALLY_008d;
		}

FINALLY_008d:
		{ // begin finally (depth: 2)
			{
				SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_15 = V_0;
				if (!L_15)
				{
					goto IL_0099;
				}
			}

IL_0093:
			{
				SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_16 = V_0;
				NullCheck(L_16);
				InterfaceActionInvoker0::Invoke(0 /* System.Void System.IDisposable::Dispose() */, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var, L_16);
			}

IL_0099:
			{
				IL2CPP_END_FINALLY(141)
			}
		} // end finally (depth: 2)
		IL2CPP_CLEANUP(141)
		{
			IL2CPP_JUMP_TBL(0x9A, IL_009a)
			IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
		}

IL_009a:
		{
			goto IL_00c1;
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__exception_local = (Exception_t *)e.ex;
		if(il2cpp_codegen_class_is_assignable_from (SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6_il2cpp_TypeInfo_var, il2cpp_codegen_object_class(e.ex)))
			goto CATCH_009f;
		throw e;
	}

CATCH_009f:
	{ // begin catch(Mono.Data.Sqlite.SqliteException)
		{
			SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * L_17 = __this->get__cnn_1();
			SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * L_18 = L_17;
			NullCheck(L_18);
			int32_t L_19 = L_18->get__transactionLevel_6();
			NullCheck(L_18);
			L_18->set__transactionLevel_6(((int32_t)il2cpp_codegen_subtract((int32_t)L_19, (int32_t)1)));
			__this->set__cnn_1((SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 *)NULL);
			IL2CPP_RAISE_MANAGED_EXCEPTION(__exception_local, NULL, SqliteTransaction__ctor_m59995FF6874597512ED2217BBC41266B2A0F7CAF_RuntimeMethod_var);
		}

IL_00bc:
		{
			goto IL_00c1;
		}
	} // end catch (depth: 1)

IL_00c1:
	{
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteTransaction::Commit()
extern "C" IL2CPP_METHOD_ATTR void SqliteTransaction_Commit_mBA94CBAD9278B782DF84E22E2764D0612F551B68 (SqliteTransaction_t588D1AEC987A56478BF3B4254D6F83A4740F1560 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteTransaction_Commit_mBA94CBAD9278B782DF84E22E2764D0612F551B68_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * V_0 = NULL;
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	void* __leave_targets_storage = alloca(sizeof(int32_t) * 1);
	il2cpp::utils::LeaveTargetStack __leave_targets(__leave_targets_storage);
	NO_UNUSED_WARNING (__leave_targets);
	{
		SqliteTransaction_IsValid_mFFDD476AD513E92FB025CB46A52D5734FAE54897(__this, (bool)1, /*hidden argument*/NULL);
		SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * L_0 = __this->get__cnn_1();
		NullCheck(L_0);
		int32_t L_1 = L_0->get__transactionLevel_6();
		if (((int32_t)il2cpp_codegen_subtract((int32_t)L_1, (int32_t)1)))
		{
			goto IL_004a;
		}
	}
	{
		SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * L_2 = __this->get__cnn_1();
		NullCheck(L_2);
		SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_3 = SqliteConnection_CreateCommand_mE54467D789E72E02161682F6456682545037F3A3(L_2, /*hidden argument*/NULL);
		V_0 = L_3;
	}

IL_0026:
	try
	{ // begin try (depth: 1)
		SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_4 = V_0;
		NullCheck(L_4);
		SqliteCommand_set_CommandText_mE49B5EE0CD14901BC847B155D4B784B1EAE1D782(L_4, _stringLiteral17E4D773881595E83EED7274990576CB3C33D081, /*hidden argument*/NULL);
		SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_5 = V_0;
		NullCheck(L_5);
		SqliteCommand_ExecuteNonQuery_m0852FE0BAA62C3A909437FA9780008C4C1FAFE54(L_5, /*hidden argument*/NULL);
		IL2CPP_LEAVE(0x4A, FINALLY_003d);
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_003d;
	}

FINALLY_003d:
	{ // begin finally (depth: 1)
		{
			SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_6 = V_0;
			if (!L_6)
			{
				goto IL_0049;
			}
		}

IL_0043:
		{
			SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_7 = V_0;
			NullCheck(L_7);
			InterfaceActionInvoker0::Invoke(0 /* System.Void System.IDisposable::Dispose() */, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var, L_7);
		}

IL_0049:
		{
			IL2CPP_END_FINALLY(61)
		}
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(61)
	{
		IL2CPP_JUMP_TBL(0x4A, IL_004a)
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
	}

IL_004a:
	{
		SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * L_8 = __this->get__cnn_1();
		SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * L_9 = L_8;
		NullCheck(L_9);
		int32_t L_10 = L_9->get__transactionLevel_6();
		NullCheck(L_9);
		L_9->set__transactionLevel_6(((int32_t)il2cpp_codegen_subtract((int32_t)L_10, (int32_t)1)));
		__this->set__cnn_1((SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 *)NULL);
		return;
	}
}
// Mono.Data.Sqlite.SqliteConnection Mono.Data.Sqlite.SqliteTransaction::get_Connection()
extern "C" IL2CPP_METHOD_ATTR SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * SqliteTransaction_get_Connection_mAB117FC0AD316EC2C5D0C950C6A4101DBF18734F (SqliteTransaction_t588D1AEC987A56478BF3B4254D6F83A4740F1560 * __this, const RuntimeMethod* method)
{
	{
		SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * L_0 = __this->get__cnn_1();
		return L_0;
	}
}
// System.Void Mono.Data.Sqlite.SqliteTransaction::Dispose(System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void SqliteTransaction_Dispose_mD5B85B26E05B2560BE08A8CA5B898D8E6164CA73 (SqliteTransaction_t588D1AEC987A56478BF3B4254D6F83A4740F1560 * __this, bool ___disposing0, const RuntimeMethod* method)
{
	SqliteTransaction_t588D1AEC987A56478BF3B4254D6F83A4740F1560 * V_0 = NULL;
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	void* __leave_targets_storage = alloca(sizeof(int32_t) * 1);
	il2cpp::utils::LeaveTargetStack __leave_targets(__leave_targets_storage);
	NO_UNUSED_WARNING (__leave_targets);
	{
		bool L_0 = ___disposing0;
		if (!L_0)
		{
			goto IL_0033;
		}
	}
	{
		V_0 = __this;
		SqliteTransaction_t588D1AEC987A56478BF3B4254D6F83A4740F1560 * L_1 = V_0;
		Monitor_Enter_m903755FCC479745619842CCDBF5E6355319FA102(L_1, /*hidden argument*/NULL);
	}

IL_000e:
	try
	{ // begin try (depth: 1)
		{
			bool L_2 = SqliteTransaction_IsValid_mFFDD476AD513E92FB025CB46A52D5734FAE54897(__this, (bool)0, /*hidden argument*/NULL);
			if (!L_2)
			{
				goto IL_0020;
			}
		}

IL_001a:
		{
			SqliteTransaction_Rollback_m8D8E47D6344B69998973381904AB21F90D3F9DE9(__this, /*hidden argument*/NULL);
		}

IL_0020:
		{
			__this->set__cnn_1((SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 *)NULL);
			IL2CPP_LEAVE(0x33, FINALLY_002c);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_002c;
	}

FINALLY_002c:
	{ // begin finally (depth: 1)
		SqliteTransaction_t588D1AEC987A56478BF3B4254D6F83A4740F1560 * L_3 = V_0;
		Monitor_Exit_m49A1E5356D984D0B934BB97A305E2E5E207225C2(L_3, /*hidden argument*/NULL);
		IL2CPP_END_FINALLY(44)
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(44)
	{
		IL2CPP_JUMP_TBL(0x33, IL_0033)
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
	}

IL_0033:
	{
		bool L_4 = ___disposing0;
		DbTransaction_Dispose_m1D66CE2B68FF0CAAEE9B9110D58087350BBBDB6A(__this, L_4, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteTransaction::Rollback()
extern "C" IL2CPP_METHOD_ATTR void SqliteTransaction_Rollback_m8D8E47D6344B69998973381904AB21F90D3F9DE9 (SqliteTransaction_t588D1AEC987A56478BF3B4254D6F83A4740F1560 * __this, const RuntimeMethod* method)
{
	{
		SqliteTransaction_IsValid_mFFDD476AD513E92FB025CB46A52D5734FAE54897(__this, (bool)1, /*hidden argument*/NULL);
		SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * L_0 = __this->get__cnn_1();
		SqliteTransaction_IssueRollback_m8BCB6D8EC3F0770626222A8929B6D61C4EF9C17A(L_0, /*hidden argument*/NULL);
		SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * L_1 = __this->get__cnn_1();
		NullCheck(L_1);
		L_1->set__transactionLevel_6(0);
		__this->set__cnn_1((SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 *)NULL);
		return;
	}
}
// System.Void Mono.Data.Sqlite.SqliteTransaction::IssueRollback(Mono.Data.Sqlite.SqliteConnection)
extern "C" IL2CPP_METHOD_ATTR void SqliteTransaction_IssueRollback_m8BCB6D8EC3F0770626222A8929B6D61C4EF9C17A (SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * ___cnn0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteTransaction_IssueRollback_m8BCB6D8EC3F0770626222A8929B6D61C4EF9C17A_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * V_0 = NULL;
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	void* __leave_targets_storage = alloca(sizeof(int32_t) * 1);
	il2cpp::utils::LeaveTargetStack __leave_targets(__leave_targets_storage);
	NO_UNUSED_WARNING (__leave_targets);
	{
		SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * L_0 = ___cnn0;
		NullCheck(L_0);
		SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_1 = SqliteConnection_CreateCommand_mE54467D789E72E02161682F6456682545037F3A3(L_0, /*hidden argument*/NULL);
		V_0 = L_1;
	}

IL_0007:
	try
	{ // begin try (depth: 1)
		SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_2 = V_0;
		NullCheck(L_2);
		SqliteCommand_set_CommandText_mE49B5EE0CD14901BC847B155D4B784B1EAE1D782(L_2, _stringLiteral2CE42E824F2163751D62C49D3226C338EFA1179D, /*hidden argument*/NULL);
		SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_3 = V_0;
		NullCheck(L_3);
		SqliteCommand_ExecuteNonQuery_m0852FE0BAA62C3A909437FA9780008C4C1FAFE54(L_3, /*hidden argument*/NULL);
		IL2CPP_LEAVE(0x2B, FINALLY_001e);
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_001e;
	}

FINALLY_001e:
	{ // begin finally (depth: 1)
		{
			SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_4 = V_0;
			if (!L_4)
			{
				goto IL_002a;
			}
		}

IL_0024:
		{
			SqliteCommand_t200B8B48F8FC6F3537B5CC4C7D325708EE696365 * L_5 = V_0;
			NullCheck(L_5);
			InterfaceActionInvoker0::Invoke(0 /* System.Void System.IDisposable::Dispose() */, IDisposable_t7218B22548186B208D65EA5B7870503810A2D15A_il2cpp_TypeInfo_var, L_5);
		}

IL_002a:
		{
			IL2CPP_END_FINALLY(30)
		}
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(30)
	{
		IL2CPP_JUMP_TBL(0x2B, IL_002b)
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
	}

IL_002b:
	{
		return;
	}
}
// System.Boolean Mono.Data.Sqlite.SqliteTransaction::IsValid(System.Boolean)
extern "C" IL2CPP_METHOD_ATTR bool SqliteTransaction_IsValid_mFFDD476AD513E92FB025CB46A52D5734FAE54897 (SqliteTransaction_t588D1AEC987A56478BF3B4254D6F83A4740F1560 * __this, bool ___throwError0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SqliteTransaction_IsValid_mFFDD476AD513E92FB025CB46A52D5734FAE54897_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * L_0 = __this->get__cnn_1();
		if (L_0)
		{
			goto IL_001e;
		}
	}
	{
		bool L_1 = ___throwError0;
		if (!L_1)
		{
			goto IL_001c;
		}
	}
	{
		ArgumentNullException_t581DF992B1F3E0EC6EFB30CC5DC43519A79B27AD * L_2 = (ArgumentNullException_t581DF992B1F3E0EC6EFB30CC5DC43519A79B27AD *)il2cpp_codegen_object_new(ArgumentNullException_t581DF992B1F3E0EC6EFB30CC5DC43519A79B27AD_il2cpp_TypeInfo_var);
		ArgumentNullException__ctor_mEE0C0D6FCB2D08CD7967DBB1329A0854BBED49ED(L_2, _stringLiteralFF736B7140FADCCC4ABF6A7A3CAA5B49362CE730, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_2, NULL, SqliteTransaction_IsValid_mFFDD476AD513E92FB025CB46A52D5734FAE54897_RuntimeMethod_var);
	}

IL_001c:
	{
		return (bool)0;
	}

IL_001e:
	{
		SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * L_3 = __this->get__cnn_1();
		NullCheck(L_3);
		int32_t L_4 = L_3->get__transactionLevel_6();
		if (L_4)
		{
			goto IL_0043;
		}
	}
	{
		bool L_5 = ___throwError0;
		if (!L_5)
		{
			goto IL_0041;
		}
	}
	{
		SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6 * L_6 = (SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6 *)il2cpp_codegen_object_new(SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6_il2cpp_TypeInfo_var);
		SqliteException__ctor_m6FC576E18D88881DC33CAFC00042DCCF5D70F057(L_6, ((int32_t)21), _stringLiteral9BF86E4634BA8C788A847BD10019CC0D59BCC00C, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_6, NULL, SqliteTransaction_IsValid_mFFDD476AD513E92FB025CB46A52D5734FAE54897_RuntimeMethod_var);
	}

IL_0041:
	{
		return (bool)0;
	}

IL_0043:
	{
		SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * L_7 = __this->get__cnn_1();
		NullCheck(L_7);
		int64_t L_8 = L_7->get__version_14();
		int64_t L_9 = __this->get__version_2();
		if ((((int64_t)L_8) == ((int64_t)L_9)))
		{
			goto IL_006e;
		}
	}
	{
		bool L_10 = ___throwError0;
		if (!L_10)
		{
			goto IL_006c;
		}
	}
	{
		SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6 * L_11 = (SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6 *)il2cpp_codegen_object_new(SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6_il2cpp_TypeInfo_var);
		SqliteException__ctor_m6FC576E18D88881DC33CAFC00042DCCF5D70F057(L_11, ((int32_t)21), _stringLiteral7F97480B11C2DFEFA56814087360C69E4B05A84D, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_11, NULL, SqliteTransaction_IsValid_mFFDD476AD513E92FB025CB46A52D5734FAE54897_RuntimeMethod_var);
	}

IL_006c:
	{
		return (bool)0;
	}

IL_006e:
	{
		SqliteConnection_t655FF6D5EC3B19CBB105B23F15A3611D086F8CC2 * L_12 = __this->get__cnn_1();
		NullCheck(L_12);
		int32_t L_13 = SqliteConnection_get_State_m5209314BD40F54592BF6D6F7068E90D56BC9A45B(L_12, /*hidden argument*/NULL);
		if ((((int32_t)L_13) == ((int32_t)1)))
		{
			goto IL_0094;
		}
	}
	{
		bool L_14 = ___throwError0;
		if (!L_14)
		{
			goto IL_0092;
		}
	}
	{
		SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6 * L_15 = (SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6 *)il2cpp_codegen_object_new(SqliteException_t41BEDCC0F5AEF456FE2B739B477A27258DBDEBD6_il2cpp_TypeInfo_var);
		SqliteException__ctor_m6FC576E18D88881DC33CAFC00042DCCF5D70F057(L_15, ((int32_t)21), _stringLiteral660C1D424389A5FB82204BA7BB89B07419AAC1C0, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_15, NULL, SqliteTransaction_IsValid_mFFDD476AD513E92FB025CB46A52D5734FAE54897_RuntimeMethod_var);
	}

IL_0092:
	{
		return (bool)0;
	}

IL_0094:
	{
		return (bool)1;
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
// System.Int32 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_close(System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_close_mB6BB1F9441289923A5F5C01D787AF71AD8C18795 (intptr_t ___db0, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (intptr_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_close", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_close'"), NULL, NULL);
		}
	}

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(___db0);

	return returnValue;
}
// System.Int32 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_create_function(System.IntPtr,System.Byte[],System.Int32,System.Int32,System.IntPtr,Mono.Data.Sqlite.SQLiteCallback,Mono.Data.Sqlite.SQLiteCallback,Mono.Data.Sqlite.SQLiteFinalCallback)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_create_function_mB436B8A578D2183FCBFBCE37FEA16D18A060D548 (intptr_t ___db0, ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___strName1, int32_t ___nArgs2, int32_t ___nType3, intptr_t ___pvUser4, SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22 * ___func5, SQLiteCallback_tD056FEEFA9DBF5515968A59AA4BF47FCF9BD4C22 * ___fstep6, SQLiteFinalCallback_tDADE001E38D3B50F9259C9D956A11D3B4D875453 * ___ffinal7, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (intptr_t, uint8_t*, int32_t, int32_t, intptr_t, Il2CppMethodPointer, Il2CppMethodPointer, Il2CppMethodPointer);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(void*) + sizeof(int32_t) + sizeof(int32_t) + sizeof(intptr_t) + sizeof(void*) + sizeof(void*) + sizeof(void*);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_create_function", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_create_function'"), NULL, NULL);
		}
	}

	// Marshaling of parameter U27___strName1U27 to native representation
	uint8_t* ____strName1_marshaled = NULL;
	if (___strName1 != NULL)
	{
		____strName1_marshaled = reinterpret_cast<uint8_t*>((___strName1)->GetAddressAtUnchecked(0));
	}

	// Marshaling of parameter U27___func5U27 to native representation
	Il2CppMethodPointer ____func5_marshaled = NULL;
	____func5_marshaled = il2cpp_codegen_marshal_delegate(reinterpret_cast<MulticastDelegate_t*>(___func5));

	// Marshaling of parameter U27___fstep6U27 to native representation
	Il2CppMethodPointer ____fstep6_marshaled = NULL;
	____fstep6_marshaled = il2cpp_codegen_marshal_delegate(reinterpret_cast<MulticastDelegate_t*>(___fstep6));

	// Marshaling of parameter U27___ffinal7U27 to native representation
	Il2CppMethodPointer ____ffinal7_marshaled = NULL;
	____ffinal7_marshaled = il2cpp_codegen_marshal_delegate(reinterpret_cast<MulticastDelegate_t*>(___ffinal7));

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(___db0, ____strName1_marshaled, ___nArgs2, ___nType3, ___pvUser4, ____func5_marshaled, ____fstep6_marshaled, ____ffinal7_marshaled);

	return returnValue;
}
// System.Int32 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_finalize(System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_finalize_mD6D6EC87FDF8D0CDA71BD0947FA7BD5D883B9292 (intptr_t ___stmt0, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (intptr_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_finalize", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_finalize'"), NULL, NULL);
		}
	}

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(___stmt0);

	return returnValue;
}
// System.Int32 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_open_v2(System.Byte[],System.IntPtrU26,System.Int32,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_open_v2_mDECE3F20B0BACF84352EC268F66ED04F2347A95D (ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___utf8Filename0, intptr_t* ___db1, int32_t ___flags2, intptr_t ___vfs3, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (uint8_t*, intptr_t*, int32_t, intptr_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(void*) + sizeof(intptr_t*) + sizeof(int32_t) + sizeof(intptr_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_open_v2", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_open_v2'"), NULL, NULL);
		}
	}

	// Marshaling of parameter U27___utf8Filename0U27 to native representation
	uint8_t* ____utf8Filename0_marshaled = NULL;
	if (___utf8Filename0 != NULL)
	{
		____utf8Filename0_marshaled = reinterpret_cast<uint8_t*>((___utf8Filename0)->GetAddressAtUnchecked(0));
	}

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(____utf8Filename0_marshaled, ___db1, ___flags2, ___vfs3);

	return returnValue;
}
// System.Int32 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_open(System.Byte[],System.IntPtrU26)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_open_mEA7CEEA379AA4A7FBACD959FDACF15A8F159FF43 (ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___utf8Filename0, intptr_t* ___db1, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (uint8_t*, intptr_t*);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(void*) + sizeof(intptr_t*);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_open", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_open'"), NULL, NULL);
		}
	}

	// Marshaling of parameter U27___utf8Filename0U27 to native representation
	uint8_t* ____utf8Filename0_marshaled = NULL;
	if (___utf8Filename0 != NULL)
	{
		____utf8Filename0_marshaled = reinterpret_cast<uint8_t*>((___utf8Filename0)->GetAddressAtUnchecked(0));
	}

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(____utf8Filename0_marshaled, ___db1);

	return returnValue;
}
// System.Int32 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_open16(System.String,System.IntPtrU26)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_open16_m9167C62ABE8BACD31D586BC81E21CA7F09463876 (String_t* ___fileName0, intptr_t* ___db1, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (Il2CppChar*, intptr_t*);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(Il2CppChar*) + sizeof(intptr_t*);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_open16", IL2CPP_CALL_C, CHARSET_UNICODE, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_open16'"), NULL, NULL);
		}
	}

	// Marshaling of parameter U27___fileName0U27 to native representation
	Il2CppChar* ____fileName0_marshaled = NULL;
	if (___fileName0 != NULL)
	{
		____fileName0_marshaled = ___fileName0->get_address_of_m_firstChar_1();
	}

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(____fileName0_marshaled, ___db1);

	return returnValue;
}
// System.Int32 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_reset(System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_reset_m1C494232B04D9162904657C362ECB2062808A947 (intptr_t ___stmt0, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (intptr_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_reset", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_reset'"), NULL, NULL);
		}
	}

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(___stmt0);

	return returnValue;
}
// System.IntPtr Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_bind_parameter_name(System.IntPtr,System.Int32)
extern "C" IL2CPP_METHOD_ATTR intptr_t UnsafeNativeMethods_sqlite3_bind_parameter_name_m233021BDC6E3F76ABBEC3B62A8C70AF1F2388A93 (intptr_t ___stmt0, int32_t ___index1, const RuntimeMethod* method)
{
	typedef intptr_t (CDECL *PInvokeFunc) (intptr_t, int32_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_bind_parameter_name", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_bind_parameter_name'"), NULL, NULL);
		}
	}

	// Native function invocation
	intptr_t returnValue = il2cppPInvokeFunc(___stmt0, ___index1);

	return returnValue;
}
// System.IntPtr Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_column_database_name(System.IntPtr,System.Int32)
extern "C" IL2CPP_METHOD_ATTR intptr_t UnsafeNativeMethods_sqlite3_column_database_name_m37276BB767B4F263FC7B5503EDB3D291BF5AAC09 (intptr_t ___stmt0, int32_t ___index1, const RuntimeMethod* method)
{
	typedef intptr_t (CDECL *PInvokeFunc) (intptr_t, int32_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_column_database_name", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_column_database_name'"), NULL, NULL);
		}
	}

	// Native function invocation
	intptr_t returnValue = il2cppPInvokeFunc(___stmt0, ___index1);

	return returnValue;
}
// System.IntPtr Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_column_database_name16(System.IntPtr,System.Int32)
extern "C" IL2CPP_METHOD_ATTR intptr_t UnsafeNativeMethods_sqlite3_column_database_name16_m6FE4FEA6D65E314C2F632455DA173E795D5E86E4 (intptr_t ___stmt0, int32_t ___index1, const RuntimeMethod* method)
{
	typedef intptr_t (CDECL *PInvokeFunc) (intptr_t, int32_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_column_database_name16", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_column_database_name16'"), NULL, NULL);
		}
	}

	// Native function invocation
	intptr_t returnValue = il2cppPInvokeFunc(___stmt0, ___index1);

	return returnValue;
}
// System.IntPtr Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_column_decltype(System.IntPtr,System.Int32)
extern "C" IL2CPP_METHOD_ATTR intptr_t UnsafeNativeMethods_sqlite3_column_decltype_m18A0DFC12860AE4A607E3062C90312D8D3B1EC1B (intptr_t ___stmt0, int32_t ___index1, const RuntimeMethod* method)
{
	typedef intptr_t (CDECL *PInvokeFunc) (intptr_t, int32_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_column_decltype", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_column_decltype'"), NULL, NULL);
		}
	}

	// Native function invocation
	intptr_t returnValue = il2cppPInvokeFunc(___stmt0, ___index1);

	return returnValue;
}
// System.IntPtr Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_column_name(System.IntPtr,System.Int32)
extern "C" IL2CPP_METHOD_ATTR intptr_t UnsafeNativeMethods_sqlite3_column_name_m96F93F5B944626EB4DDEFA8A5E69F53C7778C94E (intptr_t ___stmt0, int32_t ___index1, const RuntimeMethod* method)
{
	typedef intptr_t (CDECL *PInvokeFunc) (intptr_t, int32_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_column_name", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_column_name'"), NULL, NULL);
		}
	}

	// Native function invocation
	intptr_t returnValue = il2cppPInvokeFunc(___stmt0, ___index1);

	return returnValue;
}
// System.IntPtr Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_column_name16(System.IntPtr,System.Int32)
extern "C" IL2CPP_METHOD_ATTR intptr_t UnsafeNativeMethods_sqlite3_column_name16_m1F162A698114E6625E3CDF72C20038B76F7FAD08 (intptr_t ___stmt0, int32_t ___index1, const RuntimeMethod* method)
{
	typedef intptr_t (CDECL *PInvokeFunc) (intptr_t, int32_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_column_name16", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_column_name16'"), NULL, NULL);
		}
	}

	// Native function invocation
	intptr_t returnValue = il2cppPInvokeFunc(___stmt0, ___index1);

	return returnValue;
}
// System.IntPtr Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_column_origin_name(System.IntPtr,System.Int32)
extern "C" IL2CPP_METHOD_ATTR intptr_t UnsafeNativeMethods_sqlite3_column_origin_name_mC551186E0979298227902F3012F2943B32C5922A (intptr_t ___stmt0, int32_t ___index1, const RuntimeMethod* method)
{
	typedef intptr_t (CDECL *PInvokeFunc) (intptr_t, int32_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_column_origin_name", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_column_origin_name'"), NULL, NULL);
		}
	}

	// Native function invocation
	intptr_t returnValue = il2cppPInvokeFunc(___stmt0, ___index1);

	return returnValue;
}
// System.IntPtr Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_column_origin_name16(System.IntPtr,System.Int32)
extern "C" IL2CPP_METHOD_ATTR intptr_t UnsafeNativeMethods_sqlite3_column_origin_name16_m04ABFB0F7B18427A33F0F54F7A2CA2BDC8F6FA4D (intptr_t ___stmt0, int32_t ___index1, const RuntimeMethod* method)
{
	typedef intptr_t (CDECL *PInvokeFunc) (intptr_t, int32_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_column_origin_name16", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_column_origin_name16'"), NULL, NULL);
		}
	}

	// Native function invocation
	intptr_t returnValue = il2cppPInvokeFunc(___stmt0, ___index1);

	return returnValue;
}
// System.IntPtr Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_column_table_name(System.IntPtr,System.Int32)
extern "C" IL2CPP_METHOD_ATTR intptr_t UnsafeNativeMethods_sqlite3_column_table_name_m4E7921A3229B0B7D8558B6AA540B33EA36478E19 (intptr_t ___stmt0, int32_t ___index1, const RuntimeMethod* method)
{
	typedef intptr_t (CDECL *PInvokeFunc) (intptr_t, int32_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_column_table_name", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_column_table_name'"), NULL, NULL);
		}
	}

	// Native function invocation
	intptr_t returnValue = il2cppPInvokeFunc(___stmt0, ___index1);

	return returnValue;
}
// System.IntPtr Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_column_table_name16(System.IntPtr,System.Int32)
extern "C" IL2CPP_METHOD_ATTR intptr_t UnsafeNativeMethods_sqlite3_column_table_name16_mFE495B038E1DFD13D92EBDD6328CD60D70CC8C74 (intptr_t ___stmt0, int32_t ___index1, const RuntimeMethod* method)
{
	typedef intptr_t (CDECL *PInvokeFunc) (intptr_t, int32_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_column_table_name16", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_column_table_name16'"), NULL, NULL);
		}
	}

	// Native function invocation
	intptr_t returnValue = il2cppPInvokeFunc(___stmt0, ___index1);

	return returnValue;
}
// System.IntPtr Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_column_text(System.IntPtr,System.Int32)
extern "C" IL2CPP_METHOD_ATTR intptr_t UnsafeNativeMethods_sqlite3_column_text_m497BF387C7716E3709E62AB66636B5CCFF99BF6E (intptr_t ___stmt0, int32_t ___index1, const RuntimeMethod* method)
{
	typedef intptr_t (CDECL *PInvokeFunc) (intptr_t, int32_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_column_text", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_column_text'"), NULL, NULL);
		}
	}

	// Native function invocation
	intptr_t returnValue = il2cppPInvokeFunc(___stmt0, ___index1);

	return returnValue;
}
// System.IntPtr Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_column_text16(System.IntPtr,System.Int32)
extern "C" IL2CPP_METHOD_ATTR intptr_t UnsafeNativeMethods_sqlite3_column_text16_m9080EF286B3163B11C75D546BBCF25A8C71C4FDD (intptr_t ___stmt0, int32_t ___index1, const RuntimeMethod* method)
{
	typedef intptr_t (CDECL *PInvokeFunc) (intptr_t, int32_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_column_text16", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_column_text16'"), NULL, NULL);
		}
	}

	// Native function invocation
	intptr_t returnValue = il2cppPInvokeFunc(___stmt0, ___index1);

	return returnValue;
}
// System.IntPtr Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_errmsg(System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR intptr_t UnsafeNativeMethods_sqlite3_errmsg_mB4781FA5277C92662AA80C724DC89F4BF4C9E698 (intptr_t ___db0, const RuntimeMethod* method)
{
	typedef intptr_t (CDECL *PInvokeFunc) (intptr_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_errmsg", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_errmsg'"), NULL, NULL);
		}
	}

	// Native function invocation
	intptr_t returnValue = il2cppPInvokeFunc(___db0);

	return returnValue;
}
// System.Int32 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_prepare(System.IntPtr,System.IntPtr,System.Int32,System.IntPtrU26,System.IntPtrU26)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_prepare_m3399B2BF313E4B0FAE2DBFA98328DA8D2181B96E (intptr_t ___db0, intptr_t ___pSql1, int32_t ___nBytes2, intptr_t* ___stmt3, intptr_t* ___ptrRemain4, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (intptr_t, intptr_t, int32_t, intptr_t*, intptr_t*);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(intptr_t) + sizeof(int32_t) + sizeof(intptr_t*) + sizeof(intptr_t*);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_prepare", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_prepare'"), NULL, NULL);
		}
	}

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(___db0, ___pSql1, ___nBytes2, ___stmt3, ___ptrRemain4);

	return returnValue;
}
// System.Int32 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_table_column_metadata(System.IntPtr,System.Byte[],System.Byte[],System.Byte[],System.IntPtrU26,System.IntPtrU26,System.Int32U26,System.Int32U26,System.Int32U26)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_table_column_metadata_mB0EEAFEAE30C57D089A3BEEBFE2F56D6AD171C0B (intptr_t ___db0, ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___dbName1, ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___tblName2, ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___colName3, intptr_t* ___ptrDataType4, intptr_t* ___ptrCollSeq5, int32_t* ___notNull6, int32_t* ___primaryKey7, int32_t* ___autoInc8, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (intptr_t, uint8_t*, uint8_t*, uint8_t*, intptr_t*, intptr_t*, int32_t*, int32_t*, int32_t*);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(void*) + sizeof(void*) + sizeof(void*) + sizeof(intptr_t*) + sizeof(intptr_t*) + sizeof(int32_t*) + sizeof(int32_t*) + sizeof(int32_t*);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_table_column_metadata", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_table_column_metadata'"), NULL, NULL);
		}
	}

	// Marshaling of parameter U27___dbName1U27 to native representation
	uint8_t* ____dbName1_marshaled = NULL;
	if (___dbName1 != NULL)
	{
		____dbName1_marshaled = reinterpret_cast<uint8_t*>((___dbName1)->GetAddressAtUnchecked(0));
	}

	// Marshaling of parameter U27___tblName2U27 to native representation
	uint8_t* ____tblName2_marshaled = NULL;
	if (___tblName2 != NULL)
	{
		____tblName2_marshaled = reinterpret_cast<uint8_t*>((___tblName2)->GetAddressAtUnchecked(0));
	}

	// Marshaling of parameter U27___colName3U27 to native representation
	uint8_t* ____colName3_marshaled = NULL;
	if (___colName3 != NULL)
	{
		____colName3_marshaled = reinterpret_cast<uint8_t*>((___colName3)->GetAddressAtUnchecked(0));
	}

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(___db0, ____dbName1_marshaled, ____tblName2_marshaled, ____colName3_marshaled, ___ptrDataType4, ___ptrCollSeq5, ___notNull6, ___primaryKey7, ___autoInc8);

	return returnValue;
}
// System.IntPtr Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_value_text(System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR intptr_t UnsafeNativeMethods_sqlite3_value_text_mB50EB769C4812DCBD906A31F8968E776B7D7A1F1 (intptr_t ___p0, const RuntimeMethod* method)
{
	typedef intptr_t (CDECL *PInvokeFunc) (intptr_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_value_text", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_value_text'"), NULL, NULL);
		}
	}

	// Native function invocation
	intptr_t returnValue = il2cppPInvokeFunc(___p0);

	return returnValue;
}
// System.IntPtr Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_value_text16(System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR intptr_t UnsafeNativeMethods_sqlite3_value_text16_m2DD25A3D2726F3A50149E0423C3C7137D60AC1BE (intptr_t ___p0, const RuntimeMethod* method)
{
	typedef intptr_t (CDECL *PInvokeFunc) (intptr_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_value_text16", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_value_text16'"), NULL, NULL);
		}
	}

	// Native function invocation
	intptr_t returnValue = il2cppPInvokeFunc(___p0);

	return returnValue;
}
// System.IntPtr Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_libversion()
extern "C" IL2CPP_METHOD_ATTR intptr_t UnsafeNativeMethods_sqlite3_libversion_mBE3C2FA1C2FA4B592A3DAC122C71E168F6BC4AFF (const RuntimeMethod* method)
{
	typedef intptr_t (CDECL *PInvokeFunc) ();
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = 0;
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_libversion", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_libversion'"), NULL, NULL);
		}
	}

	// Native function invocation
	intptr_t returnValue = il2cppPInvokeFunc();

	return returnValue;
}
// System.Int32 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_changes(System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_changes_m00D91026811FA6D564420C269896111145EB5713 (intptr_t ___db0, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (intptr_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_changes", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_changes'"), NULL, NULL);
		}
	}

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(___db0);

	return returnValue;
}
// System.Int32 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_busy_timeout(System.IntPtr,System.Int32)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_busy_timeout_mAA2920C33B296E2A5208DAA9334504E1C06D108E (intptr_t ___db0, int32_t ___ms1, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (intptr_t, int32_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_busy_timeout", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_busy_timeout'"), NULL, NULL);
		}
	}

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(___db0, ___ms1);

	return returnValue;
}
// System.Int32 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_bind_blob(System.IntPtr,System.Int32,System.Byte[],System.Int32,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_bind_blob_mF14F9B2382CCBE332C6950E1880D60339F80EEDA (intptr_t ___stmt0, int32_t ___index1, ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___value2, int32_t ___nSize3, intptr_t ___nTransient4, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (intptr_t, int32_t, uint8_t*, int32_t, intptr_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(int32_t) + sizeof(void*) + sizeof(int32_t) + sizeof(intptr_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_bind_blob", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_bind_blob'"), NULL, NULL);
		}
	}

	// Marshaling of parameter U27___value2U27 to native representation
	uint8_t* ____value2_marshaled = NULL;
	if (___value2 != NULL)
	{
		____value2_marshaled = reinterpret_cast<uint8_t*>((___value2)->GetAddressAtUnchecked(0));
	}

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(___stmt0, ___index1, ____value2_marshaled, ___nSize3, ___nTransient4);

	return returnValue;
}
// System.Int32 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_bind_double(System.IntPtr,System.Int32,System.Double)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_bind_double_mFBC5055FF0954A92C7075141609C3D6798E9E2F7 (intptr_t ___stmt0, int32_t ___index1, double ___value2, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (intptr_t, int32_t, double);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(int32_t) + sizeof(double);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_bind_double", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_bind_double'"), NULL, NULL);
		}
	}

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(___stmt0, ___index1, ___value2);

	return returnValue;
}
// System.Int32 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_bind_int(System.IntPtr,System.Int32,System.Int32)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_bind_int_m02330D4274AD1342ACA38C7599FE0F1F121D38FC (intptr_t ___stmt0, int32_t ___index1, int32_t ___value2, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (intptr_t, int32_t, int32_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(int32_t) + sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_bind_int", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_bind_int'"), NULL, NULL);
		}
	}

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(___stmt0, ___index1, ___value2);

	return returnValue;
}
// System.Int32 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_bind_int64(System.IntPtr,System.Int32,System.Int64)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_bind_int64_mF6FBAD8EB964D6CE655C4E719466A2D10C63C893 (intptr_t ___stmt0, int32_t ___index1, int64_t ___value2, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (intptr_t, int32_t, int64_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(int32_t) + sizeof(int64_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_bind_int64", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_bind_int64'"), NULL, NULL);
		}
	}

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(___stmt0, ___index1, ___value2);

	return returnValue;
}
// System.Int32 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_bind_null(System.IntPtr,System.Int32)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_bind_null_m64C5DAF9CE40CBD87A4D5B3DB8D6CC0931DABE02 (intptr_t ___stmt0, int32_t ___index1, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (intptr_t, int32_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_bind_null", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_bind_null'"), NULL, NULL);
		}
	}

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(___stmt0, ___index1);

	return returnValue;
}
// System.Int32 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_bind_text(System.IntPtr,System.Int32,System.Byte[],System.Int32,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_bind_text_mDCBD77335E0BA57292067AC726048AC071C7D869 (intptr_t ___stmt0, int32_t ___index1, ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___value2, int32_t ___nlen3, intptr_t ___pvReserved4, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (intptr_t, int32_t, uint8_t*, int32_t, intptr_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(int32_t) + sizeof(void*) + sizeof(int32_t) + sizeof(intptr_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_bind_text", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_bind_text'"), NULL, NULL);
		}
	}

	// Marshaling of parameter U27___value2U27 to native representation
	uint8_t* ____value2_marshaled = NULL;
	if (___value2 != NULL)
	{
		____value2_marshaled = reinterpret_cast<uint8_t*>((___value2)->GetAddressAtUnchecked(0));
	}

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(___stmt0, ___index1, ____value2_marshaled, ___nlen3, ___pvReserved4);

	return returnValue;
}
// System.Int32 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_bind_parameter_count(System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_bind_parameter_count_m81677BA579F7B9CB7EAE6FBEE3BFC1DB1739D429 (intptr_t ___stmt0, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (intptr_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_bind_parameter_count", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_bind_parameter_count'"), NULL, NULL);
		}
	}

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(___stmt0);

	return returnValue;
}
// System.Int32 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_column_count(System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_column_count_mABA0D91480DA437C93B892F3B34ADA990D9F2685 (intptr_t ___stmt0, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (intptr_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_column_count", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_column_count'"), NULL, NULL);
		}
	}

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(___stmt0);

	return returnValue;
}
// System.Int32 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_step(System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_step_m48D6247277A812985A66DF80123E8FB2EB13FD64 (intptr_t ___stmt0, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (intptr_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_step", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_step'"), NULL, NULL);
		}
	}

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(___stmt0);

	return returnValue;
}
// System.Double Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_column_double(System.IntPtr,System.Int32)
extern "C" IL2CPP_METHOD_ATTR double UnsafeNativeMethods_sqlite3_column_double_m360BFB21EAD8C84D7D1B121F1F13376FA71D7647 (intptr_t ___stmt0, int32_t ___index1, const RuntimeMethod* method)
{
	typedef double (CDECL *PInvokeFunc) (intptr_t, int32_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_column_double", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_column_double'"), NULL, NULL);
		}
	}

	// Native function invocation
	double returnValue = il2cppPInvokeFunc(___stmt0, ___index1);

	return returnValue;
}
// System.Int32 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_column_int(System.IntPtr,System.Int32)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_column_int_m620ADCC03C7059A94F7846FE3DE8851C134EEB09 (intptr_t ___stmt0, int32_t ___index1, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (intptr_t, int32_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_column_int", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_column_int'"), NULL, NULL);
		}
	}

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(___stmt0, ___index1);

	return returnValue;
}
// System.Int64 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_column_int64(System.IntPtr,System.Int32)
extern "C" IL2CPP_METHOD_ATTR int64_t UnsafeNativeMethods_sqlite3_column_int64_m01B587AA9C61E2577BA06493B6D7E3E57B4A10CC (intptr_t ___stmt0, int32_t ___index1, const RuntimeMethod* method)
{
	typedef int64_t (CDECL *PInvokeFunc) (intptr_t, int32_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_column_int64", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_column_int64'"), NULL, NULL);
		}
	}

	// Native function invocation
	int64_t returnValue = il2cppPInvokeFunc(___stmt0, ___index1);

	return returnValue;
}
// System.IntPtr Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_column_blob(System.IntPtr,System.Int32)
extern "C" IL2CPP_METHOD_ATTR intptr_t UnsafeNativeMethods_sqlite3_column_blob_m6A96755126A5093BE276BF28BAEBDC6E2BE8FD70 (intptr_t ___stmt0, int32_t ___index1, const RuntimeMethod* method)
{
	typedef intptr_t (CDECL *PInvokeFunc) (intptr_t, int32_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_column_blob", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_column_blob'"), NULL, NULL);
		}
	}

	// Native function invocation
	intptr_t returnValue = il2cppPInvokeFunc(___stmt0, ___index1);

	return returnValue;
}
// System.Int32 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_column_bytes(System.IntPtr,System.Int32)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_column_bytes_mA92A22A8FF866C41CA8595EAA3D99C3220E3FA5E (intptr_t ___stmt0, int32_t ___index1, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (intptr_t, int32_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_column_bytes", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_column_bytes'"), NULL, NULL);
		}
	}

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(___stmt0, ___index1);

	return returnValue;
}
// Mono.Data.Sqlite.TypeAffinity Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_column_type(System.IntPtr,System.Int32)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_column_type_mD18742A27617BEA44D4E3A5EF69F5B081DF4555E (intptr_t ___stmt0, int32_t ___index1, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (intptr_t, int32_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_column_type", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_column_type'"), NULL, NULL);
		}
	}

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(___stmt0, ___index1);

	return returnValue;
}
// System.Int32 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_create_collation(System.IntPtr,System.Byte[],System.Int32,System.IntPtr,Mono.Data.Sqlite.SQLiteCollation)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_create_collation_mAFB3BC1C7DB579DB0EA3CA828F25C00F1C645526 (intptr_t ___db0, ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___strName1, int32_t ___nType2, intptr_t ___pvUser3, SQLiteCollation_t14D0BAEEB6E7E9672FB073420AB52B4F24F90D8B * ___func4, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (intptr_t, uint8_t*, int32_t, intptr_t, Il2CppMethodPointer);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(void*) + sizeof(int32_t) + sizeof(intptr_t) + sizeof(void*);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_create_collation", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_create_collation'"), NULL, NULL);
		}
	}

	// Marshaling of parameter U27___strName1U27 to native representation
	uint8_t* ____strName1_marshaled = NULL;
	if (___strName1 != NULL)
	{
		____strName1_marshaled = reinterpret_cast<uint8_t*>((___strName1)->GetAddressAtUnchecked(0));
	}

	// Marshaling of parameter U27___func4U27 to native representation
	Il2CppMethodPointer ____func4_marshaled = NULL;
	____func4_marshaled = il2cpp_codegen_marshal_delegate(reinterpret_cast<MulticastDelegate_t*>(___func4));

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(___db0, ____strName1_marshaled, ___nType2, ___pvUser3, ____func4_marshaled);

	return returnValue;
}
// System.IntPtr Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_value_blob(System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR intptr_t UnsafeNativeMethods_sqlite3_value_blob_m765F596E2E71884D48FDE091F935B011E12F66C4 (intptr_t ___p0, const RuntimeMethod* method)
{
	typedef intptr_t (CDECL *PInvokeFunc) (intptr_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_value_blob", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_value_blob'"), NULL, NULL);
		}
	}

	// Native function invocation
	intptr_t returnValue = il2cppPInvokeFunc(___p0);

	return returnValue;
}
// System.Int32 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_value_bytes(System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_value_bytes_mE3AD0C49F5E81E3DDDD282AA733D23EFE82D446C (intptr_t ___p0, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (intptr_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_value_bytes", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_value_bytes'"), NULL, NULL);
		}
	}

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(___p0);

	return returnValue;
}
// System.Double Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_value_double(System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR double UnsafeNativeMethods_sqlite3_value_double_mC14B14EB86AAE809120F8B72C2590233A92BE567 (intptr_t ___p0, const RuntimeMethod* method)
{
	typedef double (CDECL *PInvokeFunc) (intptr_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_value_double", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_value_double'"), NULL, NULL);
		}
	}

	// Native function invocation
	double returnValue = il2cppPInvokeFunc(___p0);

	return returnValue;
}
// System.Int64 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_value_int64(System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR int64_t UnsafeNativeMethods_sqlite3_value_int64_m2DDC6787F14375C3888B9B3207269396BDAC6EB8 (intptr_t ___p0, const RuntimeMethod* method)
{
	typedef int64_t (CDECL *PInvokeFunc) (intptr_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_value_int64", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_value_int64'"), NULL, NULL);
		}
	}

	// Native function invocation
	int64_t returnValue = il2cppPInvokeFunc(___p0);

	return returnValue;
}
// Mono.Data.Sqlite.TypeAffinity Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_value_type(System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_value_type_mC07109ECE093F0D474D74D7BA6394F1A1B1D78FC (intptr_t ___p0, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (intptr_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_value_type", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_value_type'"), NULL, NULL);
		}
	}

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(___p0);

	return returnValue;
}
// System.Void Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_result_blob(System.IntPtr,System.Byte[],System.Int32,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR void UnsafeNativeMethods_sqlite3_result_blob_m69E68441BA6EBB48AB92691D935C6C9659B75E90 (intptr_t ___context0, ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___value1, int32_t ___nSize2, intptr_t ___pvReserved3, const RuntimeMethod* method)
{
	typedef void (CDECL *PInvokeFunc) (intptr_t, uint8_t*, int32_t, intptr_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(void*) + sizeof(int32_t) + sizeof(intptr_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_result_blob", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_result_blob'"), NULL, NULL);
		}
	}

	// Marshaling of parameter U27___value1U27 to native representation
	uint8_t* ____value1_marshaled = NULL;
	if (___value1 != NULL)
	{
		____value1_marshaled = reinterpret_cast<uint8_t*>((___value1)->GetAddressAtUnchecked(0));
	}

	// Native function invocation
	il2cppPInvokeFunc(___context0, ____value1_marshaled, ___nSize2, ___pvReserved3);

}
// System.Void Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_result_double(System.IntPtr,System.Double)
extern "C" IL2CPP_METHOD_ATTR void UnsafeNativeMethods_sqlite3_result_double_mBEF89AAF00AD9CF7C822236B715BD6AC06CB0CCE (intptr_t ___context0, double ___value1, const RuntimeMethod* method)
{
	typedef void (CDECL *PInvokeFunc) (intptr_t, double);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(double);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_result_double", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_result_double'"), NULL, NULL);
		}
	}

	// Native function invocation
	il2cppPInvokeFunc(___context0, ___value1);

}
// System.Void Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_result_error(System.IntPtr,System.Byte[],System.Int32)
extern "C" IL2CPP_METHOD_ATTR void UnsafeNativeMethods_sqlite3_result_error_mA757F7DBE77FFE9699815D9133348BC389B61130 (intptr_t ___context0, ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___strErr1, int32_t ___nLen2, const RuntimeMethod* method)
{
	typedef void (CDECL *PInvokeFunc) (intptr_t, uint8_t*, int32_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(void*) + sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_result_error", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_result_error'"), NULL, NULL);
		}
	}

	// Marshaling of parameter U27___strErr1U27 to native representation
	uint8_t* ____strErr1_marshaled = NULL;
	if (___strErr1 != NULL)
	{
		____strErr1_marshaled = reinterpret_cast<uint8_t*>((___strErr1)->GetAddressAtUnchecked(0));
	}

	// Native function invocation
	il2cppPInvokeFunc(___context0, ____strErr1_marshaled, ___nLen2);

}
// System.Void Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_result_int64(System.IntPtr,System.Int64)
extern "C" IL2CPP_METHOD_ATTR void UnsafeNativeMethods_sqlite3_result_int64_m573C24BD5044E69185812731C43D7B63FEB524F2 (intptr_t ___context0, int64_t ___value1, const RuntimeMethod* method)
{
	typedef void (CDECL *PInvokeFunc) (intptr_t, int64_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(int64_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_result_int64", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_result_int64'"), NULL, NULL);
		}
	}

	// Native function invocation
	il2cppPInvokeFunc(___context0, ___value1);

}
// System.Void Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_result_null(System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR void UnsafeNativeMethods_sqlite3_result_null_m9E8CD596B8846DE9CACFE2EA08484DDBDF15620E (intptr_t ___context0, const RuntimeMethod* method)
{
	typedef void (CDECL *PInvokeFunc) (intptr_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_result_null", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_result_null'"), NULL, NULL);
		}
	}

	// Native function invocation
	il2cppPInvokeFunc(___context0);

}
// System.Void Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_result_text(System.IntPtr,System.Byte[],System.Int32,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR void UnsafeNativeMethods_sqlite3_result_text_mAE3070AB8BA15FA0A53B4A2A989A5C1B79BBECC6 (intptr_t ___context0, ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___value1, int32_t ___nLen2, intptr_t ___pvReserved3, const RuntimeMethod* method)
{
	typedef void (CDECL *PInvokeFunc) (intptr_t, uint8_t*, int32_t, intptr_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(void*) + sizeof(int32_t) + sizeof(intptr_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_result_text", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_result_text'"), NULL, NULL);
		}
	}

	// Marshaling of parameter U27___value1U27 to native representation
	uint8_t* ____value1_marshaled = NULL;
	if (___value1 != NULL)
	{
		____value1_marshaled = reinterpret_cast<uint8_t*>((___value1)->GetAddressAtUnchecked(0));
	}

	// Native function invocation
	il2cppPInvokeFunc(___context0, ____value1_marshaled, ___nLen2, ___pvReserved3);

}
// System.IntPtr Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_aggregate_context(System.IntPtr,System.Int32)
extern "C" IL2CPP_METHOD_ATTR intptr_t UnsafeNativeMethods_sqlite3_aggregate_context_m65B4D91EBC3DDD05F36159031609DE6312329476 (intptr_t ___context0, int32_t ___nBytes1, const RuntimeMethod* method)
{
	typedef intptr_t (CDECL *PInvokeFunc) (intptr_t, int32_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_aggregate_context", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_aggregate_context'"), NULL, NULL);
		}
	}

	// Native function invocation
	intptr_t returnValue = il2cppPInvokeFunc(___context0, ___nBytes1);

	return returnValue;
}
// System.Int32 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_bind_text16(System.IntPtr,System.Int32,System.String,System.Int32,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_bind_text16_mD7DE8DD8E1ED6FB4FBE8C928B8A276A02378EDE7 (intptr_t ___stmt0, int32_t ___index1, String_t* ___value2, int32_t ___nlen3, intptr_t ___pvReserved4, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (intptr_t, int32_t, Il2CppChar*, int32_t, intptr_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(int32_t) + sizeof(Il2CppChar*) + sizeof(int32_t) + sizeof(intptr_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_bind_text16", IL2CPP_CALL_C, CHARSET_UNICODE, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_bind_text16'"), NULL, NULL);
		}
	}

	// Marshaling of parameter U27___value2U27 to native representation
	Il2CppChar* ____value2_marshaled = NULL;
	if (___value2 != NULL)
	{
		____value2_marshaled = ___value2->get_address_of_m_firstChar_1();
	}

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(___stmt0, ___index1, ____value2_marshaled, ___nlen3, ___pvReserved4);

	return returnValue;
}
// System.Void Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_result_error16(System.IntPtr,System.String,System.Int32)
extern "C" IL2CPP_METHOD_ATTR void UnsafeNativeMethods_sqlite3_result_error16_mEB65BF83C38360690EB9FC0F98D0A319224B284E (intptr_t ___context0, String_t* ___strName1, int32_t ___nLen2, const RuntimeMethod* method)
{
	typedef void (CDECL *PInvokeFunc) (intptr_t, Il2CppChar*, int32_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(Il2CppChar*) + sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_result_error16", IL2CPP_CALL_C, CHARSET_UNICODE, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_result_error16'"), NULL, NULL);
		}
	}

	// Marshaling of parameter U27___strName1U27 to native representation
	Il2CppChar* ____strName1_marshaled = NULL;
	if (___strName1 != NULL)
	{
		____strName1_marshaled = ___strName1->get_address_of_m_firstChar_1();
	}

	// Native function invocation
	il2cppPInvokeFunc(___context0, ____strName1_marshaled, ___nLen2);

}
// System.Void Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_result_text16(System.IntPtr,System.String,System.Int32,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR void UnsafeNativeMethods_sqlite3_result_text16_m05B36D528C4036A7B5CDFAB83C8E828879977D0F (intptr_t ___context0, String_t* ___strName1, int32_t ___nLen2, intptr_t ___pvReserved3, const RuntimeMethod* method)
{
	typedef void (CDECL *PInvokeFunc) (intptr_t, Il2CppChar*, int32_t, intptr_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(Il2CppChar*) + sizeof(int32_t) + sizeof(intptr_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_result_text16", IL2CPP_CALL_C, CHARSET_UNICODE, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_result_text16'"), NULL, NULL);
		}
	}

	// Marshaling of parameter U27___strName1U27 to native representation
	Il2CppChar* ____strName1_marshaled = NULL;
	if (___strName1 != NULL)
	{
		____strName1_marshaled = ___strName1->get_address_of_m_firstChar_1();
	}

	// Native function invocation
	il2cppPInvokeFunc(___context0, ____strName1_marshaled, ___nLen2, ___pvReserved3);

}
// System.Int32 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_key(System.IntPtr,System.Byte[],System.Int32)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_key_m8174FEB4E9B75F23B80A3DA4A37A170EA6112283 (intptr_t ___db0, ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___key1, int32_t ___keylen2, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (intptr_t, uint8_t*, int32_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(void*) + sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_key", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_key'"), NULL, NULL);
		}
	}

	// Marshaling of parameter U27___key1U27 to native representation
	uint8_t* ____key1_marshaled = NULL;
	if (___key1 != NULL)
	{
		____key1_marshaled = reinterpret_cast<uint8_t*>((___key1)->GetAddressAtUnchecked(0));
	}

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(___db0, ____key1_marshaled, ___keylen2);

	return returnValue;
}
// System.IntPtr Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_update_hook(System.IntPtr,Mono.Data.Sqlite.SQLiteUpdateCallback,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR intptr_t UnsafeNativeMethods_sqlite3_update_hook_mD234F011990C5E319541AF51420E553E71748E52 (intptr_t ___db0, SQLiteUpdateCallback_t3252735A38A0D75E6E9CB742FBFB194CD942712F * ___func1, intptr_t ___pvUser2, const RuntimeMethod* method)
{
	typedef intptr_t (CDECL *PInvokeFunc) (intptr_t, Il2CppMethodPointer, intptr_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(void*) + sizeof(intptr_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_update_hook", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_update_hook'"), NULL, NULL);
		}
	}

	// Marshaling of parameter U27___func1U27 to native representation
	Il2CppMethodPointer ____func1_marshaled = NULL;
	____func1_marshaled = il2cpp_codegen_marshal_delegate(reinterpret_cast<MulticastDelegate_t*>(___func1));

	// Native function invocation
	intptr_t returnValue = il2cppPInvokeFunc(___db0, ____func1_marshaled, ___pvUser2);

	return returnValue;
}
// System.IntPtr Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_commit_hook(System.IntPtr,Mono.Data.Sqlite.SQLiteCommitCallback,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR intptr_t UnsafeNativeMethods_sqlite3_commit_hook_m87E17164DDD1094E7F635F3179DB2F15C2053E9F (intptr_t ___db0, SQLiteCommitCallback_t4A2F244F9FCADC58BAEFCDB1F9A4AEA018294B4F * ___func1, intptr_t ___pvUser2, const RuntimeMethod* method)
{
	typedef intptr_t (CDECL *PInvokeFunc) (intptr_t, Il2CppMethodPointer, intptr_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(void*) + sizeof(intptr_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_commit_hook", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_commit_hook'"), NULL, NULL);
		}
	}

	// Marshaling of parameter U27___func1U27 to native representation
	Il2CppMethodPointer ____func1_marshaled = NULL;
	____func1_marshaled = il2cpp_codegen_marshal_delegate(reinterpret_cast<MulticastDelegate_t*>(___func1));

	// Native function invocation
	intptr_t returnValue = il2cppPInvokeFunc(___db0, ____func1_marshaled, ___pvUser2);

	return returnValue;
}
// System.IntPtr Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_rollback_hook(System.IntPtr,Mono.Data.Sqlite.SQLiteRollbackCallback,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR intptr_t UnsafeNativeMethods_sqlite3_rollback_hook_mAC73D2E880C4648E348883AA97DB7981937E7A99 (intptr_t ___db0, SQLiteRollbackCallback_t0879E30A50B184087AFBA2EC348DAF30A4646D8A * ___func1, intptr_t ___pvUser2, const RuntimeMethod* method)
{
	typedef intptr_t (CDECL *PInvokeFunc) (intptr_t, Il2CppMethodPointer, intptr_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(void*) + sizeof(intptr_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_rollback_hook", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_rollback_hook'"), NULL, NULL);
		}
	}

	// Marshaling of parameter U27___func1U27 to native representation
	Il2CppMethodPointer ____func1_marshaled = NULL;
	____func1_marshaled = il2cpp_codegen_marshal_delegate(reinterpret_cast<MulticastDelegate_t*>(___func1));

	// Native function invocation
	intptr_t returnValue = il2cppPInvokeFunc(___db0, ____func1_marshaled, ___pvUser2);

	return returnValue;
}
// System.IntPtr Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_next_stmt(System.IntPtr,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR intptr_t UnsafeNativeMethods_sqlite3_next_stmt_m0E443A8E9992811A6ED4183B266FE38BA0526B68 (intptr_t ___db0, intptr_t ___stmt1, const RuntimeMethod* method)
{
	typedef intptr_t (CDECL *PInvokeFunc) (intptr_t, intptr_t);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(intptr_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_next_stmt", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_next_stmt'"), NULL, NULL);
		}
	}

	// Native function invocation
	intptr_t returnValue = il2cppPInvokeFunc(___db0, ___stmt1);

	return returnValue;
}
// System.Int32 Mono.Data.Sqlite.UnsafeNativeMethods::sqlite3_exec(System.IntPtr,System.Byte[],System.IntPtr,System.IntPtr,System.IntPtrU26)
extern "C" IL2CPP_METHOD_ATTR int32_t UnsafeNativeMethods_sqlite3_exec_m7B465921DBC8EAD8E307FC68707D290AFF20E676 (intptr_t ___db0, ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___strSql1, intptr_t ___pvCallback2, intptr_t ___pvParam3, intptr_t* ___errMsg4, const RuntimeMethod* method)
{
	typedef int32_t (CDECL *PInvokeFunc) (intptr_t, uint8_t*, intptr_t, intptr_t, intptr_t*);
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t) + sizeof(void*) + sizeof(intptr_t) + sizeof(intptr_t) + sizeof(intptr_t*);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("sqlite3"), "sqlite3_exec", IL2CPP_CALL_C, CHARSET_NOT_SPECIFIED, parameterSize, false);

		if (il2cppPInvokeFunc == NULL)
		{
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_not_supported_exception("Unable to find method for p/invoke: 'sqlite3_exec'"), NULL, NULL);
		}
	}

	// Marshaling of parameter U27___strSql1U27 to native representation
	uint8_t* ____strSql1_marshaled = NULL;
	if (___strSql1 != NULL)
	{
		____strSql1_marshaled = reinterpret_cast<uint8_t*>((___strSql1)->GetAddressAtUnchecked(0));
	}

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(___db0, ____strSql1_marshaled, ___pvCallback2, ___pvParam3, ___errMsg4);

	return returnValue;
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
