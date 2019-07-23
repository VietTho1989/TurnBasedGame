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
struct VirtActionInvoker0
{
	typedef void (*Action)(void*, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, invokeData.method);
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
template <typename R, typename T1, typename T2>
struct GenericVirtFuncInvoker2
{
	typedef R (*Func)(void*, T1, T2, const RuntimeMethod*);

	static inline R Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_virtual_invoke_data(method, obj, &invokeData);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
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
template <typename R, typename T1, typename T2>
struct InterfaceFuncInvoker2
{
	typedef R (*Func)(void*, T1, T2, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
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
template <typename R, typename T1, typename T2>
struct GenericInterfaceFuncInvoker2
{
	typedef R (*Func)(void*, T1, T2, const RuntimeMethod*);

	static inline R Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_interface_invoke_data(method, obj, &invokeData);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
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

// System.AsyncCallback
struct AsyncCallback_t3F3DA3BEDAEE81DD1D24125DF8EB30E85EE14DA4;
// System.Attribute
struct Attribute_tF048C13FB3C8CFCC53F82290E4A3F621089F9A74;
// System.Byte[]
struct ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821;
// System.Char[]
struct CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2;
// System.Collections.Generic.Dictionary`2<System.Int16,UnityEngine.Networking.NetworkConnection/PacketStat>
struct Dictionary_2_t54E37BF67529C9F5102EFE87DA44E03601FD81B3;
// System.Collections.Generic.Dictionary`2<System.Int16,UnityEngine.Networking.NetworkMessageDelegate>
struct Dictionary_2_t3EE17E04A60D3EFD00303E7BA32A76AD9EB4C915;
// System.Collections.Generic.HashSet`1<System.Int32>
struct HashSet_1_t2BC1A062E48809D18CE313B19D603CA8BA5A0671;
// System.Collections.Generic.HashSet`1<UnityEngine.Networking.NetworkIdentity>
struct HashSet_1_t9E1A096DD1BBF3CF3EC3960E4B06BE62EF44899F;
// System.Collections.Generic.HashSet`1<UnityEngine.Networking.NetworkInstanceId>
struct HashSet_1_t1BC96DC84B747356758BC27E32E41C0DE178DE9F;
// System.Collections.Generic.List`1<System.Boolean>
struct List_1_t3DDB9FC102E84D6C6A4430CB071C8EF31975D03D;
// System.Collections.Generic.List`1<System.Int32>
struct List_1_tE1526161A558A17A39A8B69D8EEF3801393B6226;
// System.Collections.Generic.List`1<System.Single>
struct List_1_tC02C2993D5A6DDB73B1126E4EECDEB641C54A03E;
// System.Collections.Generic.List`1<System.String>
struct List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3;
// System.Collections.Generic.List`1<System.UInt32>
struct List_1_t49B315A213A231954A3718D77EE3A2AFF443C38E;
// System.Collections.Generic.List`1<UnityEngine.Networking.LocalClient/InternalMsg>
struct List_1_t15071630529F513887505BDF0C319691DC872E67;
// System.Collections.Generic.List`1<UnityEngine.Networking.NetworkClient>
struct List_1_t1FC2269ECC4BFEB8703A654A2B0609F3F00FB235;
// System.Collections.Generic.List`1<UnityEngine.Networking.NetworkConnection>
struct List_1_tEAA5B392FDC99D3335523D390FFCD08C48ACE455;
// System.Collections.Generic.List`1<UnityEngine.Networking.PlayerController>
struct List_1_tD98B647A610CD658E1C3314FBD41B5B03F500623;
// System.Collections.Generic.Stack`1<UnityEngine.Networking.LocalClient/InternalMsg>
struct Stack_1_tBFA1BD85E65A89CD8DE923E3997C832E44300C96;
// System.Delegate
struct Delegate_t;
// System.DelegateData
struct DelegateData_t1BF9F691B56DAE5F8C28C5E084FDE94F15F27BBE;
// System.Delegate[]
struct DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86;
// System.IAsyncResult
struct IAsyncResult_t8E194308510B375B42432981AE5E7488C458D598;
// System.Net.EndPoint
struct EndPoint_tD87FCEF2780A951E8CE8D808C345FBF2C088D980;
// System.Object[]
struct ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A;
// System.Reflection.MethodInfo
struct MethodInfo_t;
// System.String
struct String_t;
// System.Text.Encoding
struct Encoding_t7837A3C0F55EAE0E3959A53C6D6E88B113ED78A4;
// System.Type
struct Type_t;
// System.UInt32[]
struct UInt32U5BU5D_t9AA834AF2940E75BBF8E3F08FF0D20D266DB71CB;
// System.Void
struct Void_t22962CB4C05B1D89B55A6E1139F0E87A90987017;
// UnityEngine.GameObject
struct GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F;
// UnityEngine.Networking.ChannelBuffer[]
struct ChannelBufferU5BU5D_t1663CEF38281E45A3D44618712BBF705C113DD1D;
// UnityEngine.Networking.HostTopology
struct HostTopology_tD01D253330A0DAA736EDFC67EE9585C363FA9B0E;
// UnityEngine.Networking.LocalClient
struct LocalClient_t71A1C7B4DA47285F6F6970F60F1624C62DEB0ACD;
// UnityEngine.Networking.MessageBase
struct MessageBase_tAAFE9A29B9F4BDD2AFDB6135902A007560820C93;
// UnityEngine.Networking.NetBuffer
struct NetBuffer_t366B1D5A52CE9F15DC3DE61505E90EFCFE999BC2;
// UnityEngine.Networking.NetworkBehaviour
struct NetworkBehaviour_t18F8E5E1C259C5D9740A446FA1EA9480A61CF492;
// UnityEngine.Networking.NetworkBehaviour[]
struct NetworkBehaviourU5BU5D_tCE47FAA00B6A49ACB7B734CE7A6FDEA819263500;
// UnityEngine.Networking.NetworkConnection
struct NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632;
// UnityEngine.Networking.NetworkIdentity
struct NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C;
// UnityEngine.Networking.NetworkIdentity/ClientAuthorityCallback
struct ClientAuthorityCallback_t84681ACFA43178557C6346AACE03B504C3C63FDE;
// UnityEngine.Networking.NetworkMessage
struct NetworkMessage_t8CF95D238C0966D1811596D78D3C4A57A431A8CF;
// UnityEngine.Networking.NetworkMessageDelegate
struct NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7;
// UnityEngine.Networking.NetworkMessageHandlers
struct NetworkMessageHandlers_tD09C2A81D21EEF2F513794293A5CD6639C70EE2C;
// UnityEngine.Networking.NetworkReader
struct NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173;
// UnityEngine.Networking.NetworkScene
struct NetworkScene_t28D4F38045D478A8DDE74F997D5014E4D447C0EB;
// UnityEngine.Networking.NetworkServer
struct NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08;
// UnityEngine.Networking.NetworkServer/ServerSimpleWrapper
struct ServerSimpleWrapper_tDCE94E2482C93C6C2CE3BA118DC722A59E3598E9;
// UnityEngine.Networking.NetworkSystem.CRCMessage
struct CRCMessage_tA86EAAF7BAA45FD9B4F26A6C8FD1392C60C35743;
// UnityEngine.Networking.NetworkSystem.RemovePlayerMessage
struct RemovePlayerMessage_t0617C5B59FBA6A829E8793A6F0764BE282E988D4;
// UnityEngine.Networking.NetworkWriter
struct NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231;
// UnityEngine.Networking.PlayerController
struct PlayerController_tD0BA5C3E7CAD2CE52BFFBAB61C21F86752B32EA6;
// UnityEngine.Networking.ServerAttribute
struct ServerAttribute_t8EDD5C7824A540E38F713A2F26FFB1D756FA6F57;
// UnityEngine.Networking.ServerCallbackAttribute
struct ServerCallbackAttribute_t1E84676A0DB622681E63343EA55890C92A1EA3EE;
// UnityEngine.Networking.SpawnDelegate
struct SpawnDelegate_t45423EB746AE4539766BCEBD1BBD7D21DEC4AB7B;
// UnityEngine.Networking.SyncEventAttribute
struct SyncEventAttribute_t2D5695F58C45D4EE6A5303719EEDF84073160086;
// UnityEngine.Networking.SyncListBool
struct SyncListBool_t923ECFA13FD645E25323073E9D533ADF88B0443D;
// UnityEngine.Networking.SyncListFloat
struct SyncListFloat_t645D206D30E48C66279A460EFF51EE1122F25708;
// UnityEngine.Networking.SyncListInt
struct SyncListInt_t983DECC70C3DF63128B79CC3F65E9153AC31E91C;
// UnityEngine.Networking.SyncListString
struct SyncListString_t60A178543A04A4418DB27AEAABA7D8E224C5CCF0;
// UnityEngine.Networking.SyncListUInt
struct SyncListUInt_t07AD639C74DD935A6A0A498026B4BD89A222A2B9;
// UnityEngine.Networking.SyncList`1/SyncListChanged<System.Boolean>
struct SyncListChanged_t65EA534172DEE5CFC308FFBBEBB6D52EC2A4631C;
// UnityEngine.Networking.SyncList`1/SyncListChanged<System.Int32>
struct SyncListChanged_tE411A925A916D890FFE042735E1AC0436E8F56DE;
// UnityEngine.Networking.SyncList`1/SyncListChanged<System.Single>
struct SyncListChanged_t6BD906472E58E409D0ECECA453CD560D0E726A47;
// UnityEngine.Networking.SyncList`1/SyncListChanged<System.String>
struct SyncListChanged_t6D43F29A0B1156F70E4A643C6AC2DCFEA0820CC6;
// UnityEngine.Networking.SyncList`1/SyncListChanged<System.UInt32>
struct SyncListChanged_t1EC03E4D6A4ED535AAFB72EC4D2D20A7C965740A;
// UnityEngine.Networking.SyncList`1<System.Boolean>
struct SyncList_1_t6497C1ACAB6EB42D6D7F298D4AB6B2EE5E9CF6EF;
// UnityEngine.Networking.SyncList`1<System.Int32>
struct SyncList_1_t9939BD2C6A6D9D6EB338E4D0254A8720285B7EC2;
// UnityEngine.Networking.SyncList`1<System.Object>
struct SyncList_1_tEE50F611A8EFCCD059E955DDE35879647424A4F5;
// UnityEngine.Networking.SyncList`1<System.Single>
struct SyncList_1_t491D70D47353E92E83C01A9E23BC5C5ADAAE7311;
// UnityEngine.Networking.SyncList`1<System.String>
struct SyncList_1_tD7067A1EED06B4DCC141C47BEDD2B2ADDF546EB6;
// UnityEngine.Networking.SyncList`1<System.UInt32>
struct SyncList_1_tF7370C9EAD80F16C94714515A80898967A7AC85C;
// UnityEngine.Networking.SyncVarAttribute
struct SyncVarAttribute_t9F652FDE52D8EEA95040A1BED1DDDE54939FBA83;
// UnityEngine.Networking.TargetRpcAttribute
struct TargetRpcAttribute_t25BFBC0FF05FDE98CBF816FD2B0ED7FD275AD1FE;
// UnityEngine.Networking.ULocalConnectionToClient
struct ULocalConnectionToClient_t270486B97F92181CBD9C89E72E7D9D0BF9100AB0;
// UnityEngine.Networking.ULocalConnectionToServer
struct ULocalConnectionToServer_tAEFE862DB3377D88819D6799DADC10C89D4C19AA;
// UnityEngine.Networking.UnSpawnDelegate
struct UnSpawnDelegate_t82FEE1FA0B957BFC00EFF737B34478C3ABBD04BD;
// UnityEngine.Object
struct Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0;

extern RuntimeClass* Debug_t7B5FCB117E2FD63B6838BC52821B252E2BFB61C4_il2cpp_TypeInfo_var;
extern RuntimeClass* Int16_t823A20635DAF5A3D93A1E01CFBF3CBA27CF00B4D_il2cpp_TypeInfo_var;
extern RuntimeClass* LogFilter_t7F5DC717851FC49ACAA3C288FEF0ECAE0E9589E2_il2cpp_TypeInfo_var;
extern RuntimeClass* NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6_il2cpp_TypeInfo_var;
extern RuntimeClass* ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A_il2cpp_TypeInfo_var;
extern RuntimeClass* Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_il2cpp_TypeInfo_var;
extern RuntimeClass* SyncListBool_t923ECFA13FD645E25323073E9D533ADF88B0443D_il2cpp_TypeInfo_var;
extern RuntimeClass* SyncListFloat_t645D206D30E48C66279A460EFF51EE1122F25708_il2cpp_TypeInfo_var;
extern RuntimeClass* SyncListInt_t983DECC70C3DF63128B79CC3F65E9153AC31E91C_il2cpp_TypeInfo_var;
extern RuntimeClass* SyncListString_t60A178543A04A4418DB27AEAABA7D8E224C5CCF0_il2cpp_TypeInfo_var;
extern RuntimeClass* SyncListUInt_t07AD639C74DD935A6A0A498026B4BD89A222A2B9_il2cpp_TypeInfo_var;
extern RuntimeClass* Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_il2cpp_TypeInfo_var;
extern String_t* _stringLiteral0C84AC39FC120C1E579C09FEAA062CA04994E08F;
extern String_t* _stringLiteral13F4B303180B12CAF8F069E93D7C4FAF969D3BC4;
extern String_t* _stringLiteral1FB72BA5614BA625FBF384ACEA5077F842DEAC45;
extern String_t* _stringLiteral2BE88CA4242C76E8253AC62474851065032D6833;
extern String_t* _stringLiteral8A90E4187AA462FD7BCD9E2521B1C4F09372DBAF;
extern const RuntimeMethod* GameObject_GetComponent_TisNetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C_m3FCBB476BF3F550DB91E3EA0DE9DB5391D48E35E_RuntimeMethod_var;
extern const RuntimeMethod* SyncList_1_AddInternal_m2F72C06D79DB5999144BE943EDF36DA2DCE13599_RuntimeMethod_var;
extern const RuntimeMethod* SyncList_1_AddInternal_m778318507B8DC58EA01286B69E8D1232F3A4309D_RuntimeMethod_var;
extern const RuntimeMethod* SyncList_1_AddInternal_mAC8442A4CFDDAB13EBCE69278F9F342AF9630DBC_RuntimeMethod_var;
extern const RuntimeMethod* SyncList_1_AddInternal_mB027582F168CCBF56CD4D628BE448D5844C9F80A_RuntimeMethod_var;
extern const RuntimeMethod* SyncList_1_AddInternal_mDFCBDA7FC93AEC328AD072BB6BDBB707A0748FC3_RuntimeMethod_var;
extern const RuntimeMethod* SyncList_1_Clear_m14176FDE294F9E7974EAF85D73604B4A83581B8A_RuntimeMethod_var;
extern const RuntimeMethod* SyncList_1_Clear_m71C81796CC1C8CF6FCE17DA6AB788CE0D59F5960_RuntimeMethod_var;
extern const RuntimeMethod* SyncList_1_Clear_mA3628B737C052F7946F55AB625CAED61652DC83A_RuntimeMethod_var;
extern const RuntimeMethod* SyncList_1_Clear_mB73C836DB01C1A8E9E57A7825CB6685D9ABC3C27_RuntimeMethod_var;
extern const RuntimeMethod* SyncList_1_Clear_mD7144B94F9EAAA3B749EFA1B57157DE24CD8B23C_RuntimeMethod_var;
extern const RuntimeMethod* SyncList_1__ctor_m0621B589247DA8D6F0BEA24C5FC134480F08C34D_RuntimeMethod_var;
extern const RuntimeMethod* SyncList_1__ctor_m68F5839757D4DBBAABD3E723CC4E78FD592E5207_RuntimeMethod_var;
extern const RuntimeMethod* SyncList_1__ctor_m9BD7FD9E27578465E832618C449AC896BE95E6E7_RuntimeMethod_var;
extern const RuntimeMethod* SyncList_1__ctor_mDEF6DFE7474225B062A33F15C066C73E5508D7D8_RuntimeMethod_var;
extern const RuntimeMethod* SyncList_1__ctor_mE221DB165D01DD8F6EC144B5A2B0AE8E39C864D5_RuntimeMethod_var;
extern const RuntimeMethod* SyncList_1_get_Count_m2ADDACB4181D1FA4E62543D708BC8C74371F5D32_RuntimeMethod_var;
extern const RuntimeMethod* SyncList_1_get_Count_m3F7E989F3BB9E1AC489A24126B8F9CECF8F66A73_RuntimeMethod_var;
extern const RuntimeMethod* SyncList_1_get_Count_m84C111D456738F05E1B8D83E1FB99E92B48FB961_RuntimeMethod_var;
extern const RuntimeMethod* SyncList_1_get_Count_m99C6CCCA1B63690490BAFEF3FFA0671E6E873C0C_RuntimeMethod_var;
extern const RuntimeMethod* SyncList_1_get_Count_mBFD13B7B0896759864013263CC517D1E50FA1C03_RuntimeMethod_var;
extern const RuntimeMethod* SyncList_1_get_Item_m4265393B3FFC88909E4FE7CB10B454AE5D1E2C46_RuntimeMethod_var;
extern const RuntimeMethod* SyncList_1_get_Item_m44091CDDCB00A7A165E3AA3DA56CD7A30F0F5877_RuntimeMethod_var;
extern const RuntimeMethod* SyncList_1_get_Item_mA90ABECE21F6FB9FC65FF17CCFDD262D781B52D0_RuntimeMethod_var;
extern const RuntimeMethod* SyncList_1_get_Item_mA921A397406B074A972CFAD9DA2F60322B933DE5_RuntimeMethod_var;
extern const RuntimeMethod* SyncList_1_get_Item_mF15B67FFBE3107CD3CC0F540BE68CE60FE5F6D44_RuntimeMethod_var;
extern const uint32_t PlayerController_ToString_m98847EBE32863A0A759753BA489E97671DB6D5F3_MetadataUsageId;
extern const uint32_t PlayerController__ctor_mD6C6B070FAEF299B5F11E3CD418B92A468D6C7ED_MetadataUsageId;
extern const uint32_t SpawnDelegate_BeginInvoke_mCA92C40891128B24CA301A2E987DEBE09FC0C424_MetadataUsageId;
extern const uint32_t SyncListBool_ReadInstance_m2006DD3AE73F46FA87B75CDF067B72CA9074DF3A_MetadataUsageId;
extern const uint32_t SyncListBool_ReadReference_m923850A087D74C3DAB16A2F630757E81E1D1D66C_MetadataUsageId;
extern const uint32_t SyncListBool_WriteInstance_m191A012991FEEA98B3BF674B5878E05A7362C12E_MetadataUsageId;
extern const uint32_t SyncListBool__ctor_m18A45510AC1614D6502BA34A4A4E037047B37A0D_MetadataUsageId;
extern const uint32_t SyncListFloat_ReadInstance_mE3506BECB67837FCA9BC62E64804FE3DA279B2E0_MetadataUsageId;
extern const uint32_t SyncListFloat_ReadReference_mB93225FCEBB336A623B4DD8911978E2C2D52D74B_MetadataUsageId;
extern const uint32_t SyncListFloat_WriteInstance_mCC397A2AC2F98D4BD2BFA98BDE725F95F5D4EAE7_MetadataUsageId;
extern const uint32_t SyncListFloat__ctor_m2C6A41F93235AF1128C0E6883254084AE2532778_MetadataUsageId;
extern const uint32_t SyncListInt_ReadInstance_mC5D254D6BCF6AE56A077FB2C765E49BD8544B7B3_MetadataUsageId;
extern const uint32_t SyncListInt_ReadReference_m3BE6DC095D913B6DE87F56AC593C71D86AF36E13_MetadataUsageId;
extern const uint32_t SyncListInt_WriteInstance_mC3E5CCF06A7D3ED297CF51CD09BF664F7A011B9D_MetadataUsageId;
extern const uint32_t SyncListInt__ctor_m7C40E1815DE1B26F03960F291E1AC823FF9B2074_MetadataUsageId;
extern const uint32_t SyncListString_ReadInstance_m258E8428BE0D7C24181E04B010B127E7E18FDA93_MetadataUsageId;
extern const uint32_t SyncListString_ReadReference_m89E0E9B55F87EA04987CC55094778F08C417C9E3_MetadataUsageId;
extern const uint32_t SyncListString_WriteInstance_mE8B283C13B8E8A55730AD1F8072266E45F68AD9C_MetadataUsageId;
extern const uint32_t SyncListString__ctor_m40228C5CFE34EBE1B805E8A011765A3D2809361C_MetadataUsageId;
extern const uint32_t SyncListUInt_ReadInstance_m2A353CA5F8E70C4AC78FCA15BD49B6D7E6BFBB20_MetadataUsageId;
extern const uint32_t SyncListUInt_ReadReference_m273B2EEEF69D9D8F6BF34334CF6CB250674003FA_MetadataUsageId;
extern const uint32_t SyncListUInt_WriteInstance_m1EE5BFD6B9A80C59E05EDF9C818ED5DAED967FB1_MetadataUsageId;
extern const uint32_t SyncListUInt__ctor_m12DC8C5F857A8BD4AB16591B2E097AFE8B037549_MetadataUsageId;
extern const uint32_t ULocalConnectionToClient__ctor_mAC4885FC07B8FD7C5E1BB17B942CB23ABCD20540_MetadataUsageId;
extern const uint32_t ULocalConnectionToServer_SendBytes_mB1AEBEA8E225F14284848487789D1D642FF10CCE_MetadataUsageId;
extern const uint32_t ULocalConnectionToServer__ctor_m8370756937F61813D5891A6DEC55A65F9E1D6B1D_MetadataUsageId;
struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;

struct ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821;
struct DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86;
struct ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A;


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
#ifndef MESSAGEBASE_TAAFE9A29B9F4BDD2AFDB6135902A007560820C93_H
#define MESSAGEBASE_TAAFE9A29B9F4BDD2AFDB6135902A007560820C93_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.MessageBase
struct  MessageBase_tAAFE9A29B9F4BDD2AFDB6135902A007560820C93  : public RuntimeObject
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MESSAGEBASE_TAAFE9A29B9F4BDD2AFDB6135902A007560820C93_H
#ifndef NETWORKREADER_T7AA956F248BAA72DA3A7A91F1DBD1DCD10072173_H
#define NETWORKREADER_T7AA956F248BAA72DA3A7A91F1DBD1DCD10072173_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkReader
struct  NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173  : public RuntimeObject
{
public:
	// UnityEngine.Networking.NetBuffer UnityEngine.Networking.NetworkReader::m_buf
	NetBuffer_t366B1D5A52CE9F15DC3DE61505E90EFCFE999BC2 * ___m_buf_0;

public:
	inline static int32_t get_offset_of_m_buf_0() { return static_cast<int32_t>(offsetof(NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173, ___m_buf_0)); }
	inline NetBuffer_t366B1D5A52CE9F15DC3DE61505E90EFCFE999BC2 * get_m_buf_0() const { return ___m_buf_0; }
	inline NetBuffer_t366B1D5A52CE9F15DC3DE61505E90EFCFE999BC2 ** get_address_of_m_buf_0() { return &___m_buf_0; }
	inline void set_m_buf_0(NetBuffer_t366B1D5A52CE9F15DC3DE61505E90EFCFE999BC2 * value)
	{
		___m_buf_0 = value;
		Il2CppCodeGenWriteBarrier((&___m_buf_0), value);
	}
};

struct NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173_StaticFields
{
public:
	// System.Byte[] UnityEngine.Networking.NetworkReader::s_StringReaderBuffer
	ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___s_StringReaderBuffer_3;
	// System.Text.Encoding UnityEngine.Networking.NetworkReader::s_Encoding
	Encoding_t7837A3C0F55EAE0E3959A53C6D6E88B113ED78A4 * ___s_Encoding_4;

public:
	inline static int32_t get_offset_of_s_StringReaderBuffer_3() { return static_cast<int32_t>(offsetof(NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173_StaticFields, ___s_StringReaderBuffer_3)); }
	inline ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* get_s_StringReaderBuffer_3() const { return ___s_StringReaderBuffer_3; }
	inline ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821** get_address_of_s_StringReaderBuffer_3() { return &___s_StringReaderBuffer_3; }
	inline void set_s_StringReaderBuffer_3(ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* value)
	{
		___s_StringReaderBuffer_3 = value;
		Il2CppCodeGenWriteBarrier((&___s_StringReaderBuffer_3), value);
	}

	inline static int32_t get_offset_of_s_Encoding_4() { return static_cast<int32_t>(offsetof(NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173_StaticFields, ___s_Encoding_4)); }
	inline Encoding_t7837A3C0F55EAE0E3959A53C6D6E88B113ED78A4 * get_s_Encoding_4() const { return ___s_Encoding_4; }
	inline Encoding_t7837A3C0F55EAE0E3959A53C6D6E88B113ED78A4 ** get_address_of_s_Encoding_4() { return &___s_Encoding_4; }
	inline void set_s_Encoding_4(Encoding_t7837A3C0F55EAE0E3959A53C6D6E88B113ED78A4 * value)
	{
		___s_Encoding_4 = value;
		Il2CppCodeGenWriteBarrier((&___s_Encoding_4), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // NETWORKREADER_T7AA956F248BAA72DA3A7A91F1DBD1DCD10072173_H
#ifndef NETWORKSERVER_T7853DBCA77A6C479067BF35ADD08A40320C90B08_H
#define NETWORKSERVER_T7853DBCA77A6C479067BF35ADD08A40320C90B08_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkServer
struct  NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08  : public RuntimeObject
{
public:
	// System.Boolean UnityEngine.Networking.NetworkServer::m_LocalClientActive
	bool ___m_LocalClientActive_4;
	// System.Collections.Generic.List`1<UnityEngine.Networking.NetworkConnection> UnityEngine.Networking.NetworkServer::m_LocalConnectionsFakeList
	List_1_tEAA5B392FDC99D3335523D390FFCD08C48ACE455 * ___m_LocalConnectionsFakeList_5;
	// UnityEngine.Networking.ULocalConnectionToClient UnityEngine.Networking.NetworkServer::m_LocalConnection
	ULocalConnectionToClient_t270486B97F92181CBD9C89E72E7D9D0BF9100AB0 * ___m_LocalConnection_6;
	// UnityEngine.Networking.NetworkScene UnityEngine.Networking.NetworkServer::m_NetworkScene
	NetworkScene_t28D4F38045D478A8DDE74F997D5014E4D447C0EB * ___m_NetworkScene_7;
	// System.Collections.Generic.HashSet`1<System.Int32> UnityEngine.Networking.NetworkServer::m_ExternalConnections
	HashSet_1_t2BC1A062E48809D18CE313B19D603CA8BA5A0671 * ___m_ExternalConnections_8;
	// UnityEngine.Networking.NetworkServer_ServerSimpleWrapper UnityEngine.Networking.NetworkServer::m_SimpleServerSimple
	ServerSimpleWrapper_tDCE94E2482C93C6C2CE3BA118DC722A59E3598E9 * ___m_SimpleServerSimple_9;
	// System.Single UnityEngine.Networking.NetworkServer::m_MaxDelay
	float ___m_MaxDelay_10;
	// System.Collections.Generic.HashSet`1<UnityEngine.Networking.NetworkInstanceId> UnityEngine.Networking.NetworkServer::m_RemoveList
	HashSet_1_t1BC96DC84B747356758BC27E32E41C0DE178DE9F * ___m_RemoveList_11;
	// System.Int32 UnityEngine.Networking.NetworkServer::m_RemoveListCount
	int32_t ___m_RemoveListCount_12;

public:
	inline static int32_t get_offset_of_m_LocalClientActive_4() { return static_cast<int32_t>(offsetof(NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08, ___m_LocalClientActive_4)); }
	inline bool get_m_LocalClientActive_4() const { return ___m_LocalClientActive_4; }
	inline bool* get_address_of_m_LocalClientActive_4() { return &___m_LocalClientActive_4; }
	inline void set_m_LocalClientActive_4(bool value)
	{
		___m_LocalClientActive_4 = value;
	}

	inline static int32_t get_offset_of_m_LocalConnectionsFakeList_5() { return static_cast<int32_t>(offsetof(NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08, ___m_LocalConnectionsFakeList_5)); }
	inline List_1_tEAA5B392FDC99D3335523D390FFCD08C48ACE455 * get_m_LocalConnectionsFakeList_5() const { return ___m_LocalConnectionsFakeList_5; }
	inline List_1_tEAA5B392FDC99D3335523D390FFCD08C48ACE455 ** get_address_of_m_LocalConnectionsFakeList_5() { return &___m_LocalConnectionsFakeList_5; }
	inline void set_m_LocalConnectionsFakeList_5(List_1_tEAA5B392FDC99D3335523D390FFCD08C48ACE455 * value)
	{
		___m_LocalConnectionsFakeList_5 = value;
		Il2CppCodeGenWriteBarrier((&___m_LocalConnectionsFakeList_5), value);
	}

	inline static int32_t get_offset_of_m_LocalConnection_6() { return static_cast<int32_t>(offsetof(NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08, ___m_LocalConnection_6)); }
	inline ULocalConnectionToClient_t270486B97F92181CBD9C89E72E7D9D0BF9100AB0 * get_m_LocalConnection_6() const { return ___m_LocalConnection_6; }
	inline ULocalConnectionToClient_t270486B97F92181CBD9C89E72E7D9D0BF9100AB0 ** get_address_of_m_LocalConnection_6() { return &___m_LocalConnection_6; }
	inline void set_m_LocalConnection_6(ULocalConnectionToClient_t270486B97F92181CBD9C89E72E7D9D0BF9100AB0 * value)
	{
		___m_LocalConnection_6 = value;
		Il2CppCodeGenWriteBarrier((&___m_LocalConnection_6), value);
	}

	inline static int32_t get_offset_of_m_NetworkScene_7() { return static_cast<int32_t>(offsetof(NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08, ___m_NetworkScene_7)); }
	inline NetworkScene_t28D4F38045D478A8DDE74F997D5014E4D447C0EB * get_m_NetworkScene_7() const { return ___m_NetworkScene_7; }
	inline NetworkScene_t28D4F38045D478A8DDE74F997D5014E4D447C0EB ** get_address_of_m_NetworkScene_7() { return &___m_NetworkScene_7; }
	inline void set_m_NetworkScene_7(NetworkScene_t28D4F38045D478A8DDE74F997D5014E4D447C0EB * value)
	{
		___m_NetworkScene_7 = value;
		Il2CppCodeGenWriteBarrier((&___m_NetworkScene_7), value);
	}

	inline static int32_t get_offset_of_m_ExternalConnections_8() { return static_cast<int32_t>(offsetof(NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08, ___m_ExternalConnections_8)); }
	inline HashSet_1_t2BC1A062E48809D18CE313B19D603CA8BA5A0671 * get_m_ExternalConnections_8() const { return ___m_ExternalConnections_8; }
	inline HashSet_1_t2BC1A062E48809D18CE313B19D603CA8BA5A0671 ** get_address_of_m_ExternalConnections_8() { return &___m_ExternalConnections_8; }
	inline void set_m_ExternalConnections_8(HashSet_1_t2BC1A062E48809D18CE313B19D603CA8BA5A0671 * value)
	{
		___m_ExternalConnections_8 = value;
		Il2CppCodeGenWriteBarrier((&___m_ExternalConnections_8), value);
	}

	inline static int32_t get_offset_of_m_SimpleServerSimple_9() { return static_cast<int32_t>(offsetof(NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08, ___m_SimpleServerSimple_9)); }
	inline ServerSimpleWrapper_tDCE94E2482C93C6C2CE3BA118DC722A59E3598E9 * get_m_SimpleServerSimple_9() const { return ___m_SimpleServerSimple_9; }
	inline ServerSimpleWrapper_tDCE94E2482C93C6C2CE3BA118DC722A59E3598E9 ** get_address_of_m_SimpleServerSimple_9() { return &___m_SimpleServerSimple_9; }
	inline void set_m_SimpleServerSimple_9(ServerSimpleWrapper_tDCE94E2482C93C6C2CE3BA118DC722A59E3598E9 * value)
	{
		___m_SimpleServerSimple_9 = value;
		Il2CppCodeGenWriteBarrier((&___m_SimpleServerSimple_9), value);
	}

	inline static int32_t get_offset_of_m_MaxDelay_10() { return static_cast<int32_t>(offsetof(NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08, ___m_MaxDelay_10)); }
	inline float get_m_MaxDelay_10() const { return ___m_MaxDelay_10; }
	inline float* get_address_of_m_MaxDelay_10() { return &___m_MaxDelay_10; }
	inline void set_m_MaxDelay_10(float value)
	{
		___m_MaxDelay_10 = value;
	}

	inline static int32_t get_offset_of_m_RemoveList_11() { return static_cast<int32_t>(offsetof(NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08, ___m_RemoveList_11)); }
	inline HashSet_1_t1BC96DC84B747356758BC27E32E41C0DE178DE9F * get_m_RemoveList_11() const { return ___m_RemoveList_11; }
	inline HashSet_1_t1BC96DC84B747356758BC27E32E41C0DE178DE9F ** get_address_of_m_RemoveList_11() { return &___m_RemoveList_11; }
	inline void set_m_RemoveList_11(HashSet_1_t1BC96DC84B747356758BC27E32E41C0DE178DE9F * value)
	{
		___m_RemoveList_11 = value;
		Il2CppCodeGenWriteBarrier((&___m_RemoveList_11), value);
	}

	inline static int32_t get_offset_of_m_RemoveListCount_12() { return static_cast<int32_t>(offsetof(NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08, ___m_RemoveListCount_12)); }
	inline int32_t get_m_RemoveListCount_12() const { return ___m_RemoveListCount_12; }
	inline int32_t* get_address_of_m_RemoveListCount_12() { return &___m_RemoveListCount_12; }
	inline void set_m_RemoveListCount_12(int32_t value)
	{
		___m_RemoveListCount_12 = value;
	}
};

struct NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08_StaticFields
{
public:
	// System.Boolean UnityEngine.Networking.NetworkServer::s_Active
	bool ___s_Active_0;
	// UnityEngine.Networking.NetworkServer modreq(System.Runtime.CompilerServices.IsVolatile) UnityEngine.Networking.NetworkServer::s_Instance
	NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08 * ___s_Instance_1;
	// System.Object UnityEngine.Networking.NetworkServer::s_Sync
	RuntimeObject * ___s_Sync_2;
	// System.Boolean UnityEngine.Networking.NetworkServer::m_DontListen
	bool ___m_DontListen_3;
	// System.UInt16 UnityEngine.Networking.NetworkServer::maxPacketSize
	uint16_t ___maxPacketSize_14;
	// UnityEngine.Networking.NetworkSystem.RemovePlayerMessage UnityEngine.Networking.NetworkServer::s_RemovePlayerMessage
	RemovePlayerMessage_t0617C5B59FBA6A829E8793A6F0764BE282E988D4 * ___s_RemovePlayerMessage_15;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.NetworkServer::<>f__mgU24cache0
	NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * ___U3CU3Ef__mgU24cache0_16;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.NetworkServer::<>f__mgU24cache1
	NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * ___U3CU3Ef__mgU24cache1_17;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.NetworkServer::<>f__mgU24cache2
	NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * ___U3CU3Ef__mgU24cache2_18;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.NetworkServer::<>f__mgU24cache3
	NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * ___U3CU3Ef__mgU24cache3_19;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.NetworkServer::<>f__mgU24cache4
	NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * ___U3CU3Ef__mgU24cache4_20;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.NetworkServer::<>f__mgU24cache5
	NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * ___U3CU3Ef__mgU24cache5_21;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.NetworkServer::<>f__mgU24cache6
	NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * ___U3CU3Ef__mgU24cache6_22;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.NetworkServer::<>f__mgU24cache7
	NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * ___U3CU3Ef__mgU24cache7_23;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.NetworkServer::<>f__mgU24cache8
	NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * ___U3CU3Ef__mgU24cache8_24;

public:
	inline static int32_t get_offset_of_s_Active_0() { return static_cast<int32_t>(offsetof(NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08_StaticFields, ___s_Active_0)); }
	inline bool get_s_Active_0() const { return ___s_Active_0; }
	inline bool* get_address_of_s_Active_0() { return &___s_Active_0; }
	inline void set_s_Active_0(bool value)
	{
		___s_Active_0 = value;
	}

	inline static int32_t get_offset_of_s_Instance_1() { return static_cast<int32_t>(offsetof(NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08_StaticFields, ___s_Instance_1)); }
	inline NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08 * get_s_Instance_1() const { return ___s_Instance_1; }
	inline NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08 ** get_address_of_s_Instance_1() { return &___s_Instance_1; }
	inline void set_s_Instance_1(NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08 * value)
	{
		___s_Instance_1 = value;
		Il2CppCodeGenWriteBarrier((&___s_Instance_1), value);
	}

	inline static int32_t get_offset_of_s_Sync_2() { return static_cast<int32_t>(offsetof(NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08_StaticFields, ___s_Sync_2)); }
	inline RuntimeObject * get_s_Sync_2() const { return ___s_Sync_2; }
	inline RuntimeObject ** get_address_of_s_Sync_2() { return &___s_Sync_2; }
	inline void set_s_Sync_2(RuntimeObject * value)
	{
		___s_Sync_2 = value;
		Il2CppCodeGenWriteBarrier((&___s_Sync_2), value);
	}

	inline static int32_t get_offset_of_m_DontListen_3() { return static_cast<int32_t>(offsetof(NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08_StaticFields, ___m_DontListen_3)); }
	inline bool get_m_DontListen_3() const { return ___m_DontListen_3; }
	inline bool* get_address_of_m_DontListen_3() { return &___m_DontListen_3; }
	inline void set_m_DontListen_3(bool value)
	{
		___m_DontListen_3 = value;
	}

	inline static int32_t get_offset_of_maxPacketSize_14() { return static_cast<int32_t>(offsetof(NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08_StaticFields, ___maxPacketSize_14)); }
	inline uint16_t get_maxPacketSize_14() const { return ___maxPacketSize_14; }
	inline uint16_t* get_address_of_maxPacketSize_14() { return &___maxPacketSize_14; }
	inline void set_maxPacketSize_14(uint16_t value)
	{
		___maxPacketSize_14 = value;
	}

	inline static int32_t get_offset_of_s_RemovePlayerMessage_15() { return static_cast<int32_t>(offsetof(NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08_StaticFields, ___s_RemovePlayerMessage_15)); }
	inline RemovePlayerMessage_t0617C5B59FBA6A829E8793A6F0764BE282E988D4 * get_s_RemovePlayerMessage_15() const { return ___s_RemovePlayerMessage_15; }
	inline RemovePlayerMessage_t0617C5B59FBA6A829E8793A6F0764BE282E988D4 ** get_address_of_s_RemovePlayerMessage_15() { return &___s_RemovePlayerMessage_15; }
	inline void set_s_RemovePlayerMessage_15(RemovePlayerMessage_t0617C5B59FBA6A829E8793A6F0764BE282E988D4 * value)
	{
		___s_RemovePlayerMessage_15 = value;
		Il2CppCodeGenWriteBarrier((&___s_RemovePlayerMessage_15), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache0_16() { return static_cast<int32_t>(offsetof(NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08_StaticFields, ___U3CU3Ef__mgU24cache0_16)); }
	inline NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * get_U3CU3Ef__mgU24cache0_16() const { return ___U3CU3Ef__mgU24cache0_16; }
	inline NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 ** get_address_of_U3CU3Ef__mgU24cache0_16() { return &___U3CU3Ef__mgU24cache0_16; }
	inline void set_U3CU3Ef__mgU24cache0_16(NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * value)
	{
		___U3CU3Ef__mgU24cache0_16 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__mgU24cache0_16), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache1_17() { return static_cast<int32_t>(offsetof(NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08_StaticFields, ___U3CU3Ef__mgU24cache1_17)); }
	inline NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * get_U3CU3Ef__mgU24cache1_17() const { return ___U3CU3Ef__mgU24cache1_17; }
	inline NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 ** get_address_of_U3CU3Ef__mgU24cache1_17() { return &___U3CU3Ef__mgU24cache1_17; }
	inline void set_U3CU3Ef__mgU24cache1_17(NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * value)
	{
		___U3CU3Ef__mgU24cache1_17 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__mgU24cache1_17), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache2_18() { return static_cast<int32_t>(offsetof(NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08_StaticFields, ___U3CU3Ef__mgU24cache2_18)); }
	inline NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * get_U3CU3Ef__mgU24cache2_18() const { return ___U3CU3Ef__mgU24cache2_18; }
	inline NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 ** get_address_of_U3CU3Ef__mgU24cache2_18() { return &___U3CU3Ef__mgU24cache2_18; }
	inline void set_U3CU3Ef__mgU24cache2_18(NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * value)
	{
		___U3CU3Ef__mgU24cache2_18 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__mgU24cache2_18), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache3_19() { return static_cast<int32_t>(offsetof(NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08_StaticFields, ___U3CU3Ef__mgU24cache3_19)); }
	inline NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * get_U3CU3Ef__mgU24cache3_19() const { return ___U3CU3Ef__mgU24cache3_19; }
	inline NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 ** get_address_of_U3CU3Ef__mgU24cache3_19() { return &___U3CU3Ef__mgU24cache3_19; }
	inline void set_U3CU3Ef__mgU24cache3_19(NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * value)
	{
		___U3CU3Ef__mgU24cache3_19 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__mgU24cache3_19), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache4_20() { return static_cast<int32_t>(offsetof(NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08_StaticFields, ___U3CU3Ef__mgU24cache4_20)); }
	inline NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * get_U3CU3Ef__mgU24cache4_20() const { return ___U3CU3Ef__mgU24cache4_20; }
	inline NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 ** get_address_of_U3CU3Ef__mgU24cache4_20() { return &___U3CU3Ef__mgU24cache4_20; }
	inline void set_U3CU3Ef__mgU24cache4_20(NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * value)
	{
		___U3CU3Ef__mgU24cache4_20 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__mgU24cache4_20), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache5_21() { return static_cast<int32_t>(offsetof(NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08_StaticFields, ___U3CU3Ef__mgU24cache5_21)); }
	inline NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * get_U3CU3Ef__mgU24cache5_21() const { return ___U3CU3Ef__mgU24cache5_21; }
	inline NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 ** get_address_of_U3CU3Ef__mgU24cache5_21() { return &___U3CU3Ef__mgU24cache5_21; }
	inline void set_U3CU3Ef__mgU24cache5_21(NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * value)
	{
		___U3CU3Ef__mgU24cache5_21 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__mgU24cache5_21), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache6_22() { return static_cast<int32_t>(offsetof(NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08_StaticFields, ___U3CU3Ef__mgU24cache6_22)); }
	inline NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * get_U3CU3Ef__mgU24cache6_22() const { return ___U3CU3Ef__mgU24cache6_22; }
	inline NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 ** get_address_of_U3CU3Ef__mgU24cache6_22() { return &___U3CU3Ef__mgU24cache6_22; }
	inline void set_U3CU3Ef__mgU24cache6_22(NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * value)
	{
		___U3CU3Ef__mgU24cache6_22 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__mgU24cache6_22), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache7_23() { return static_cast<int32_t>(offsetof(NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08_StaticFields, ___U3CU3Ef__mgU24cache7_23)); }
	inline NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * get_U3CU3Ef__mgU24cache7_23() const { return ___U3CU3Ef__mgU24cache7_23; }
	inline NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 ** get_address_of_U3CU3Ef__mgU24cache7_23() { return &___U3CU3Ef__mgU24cache7_23; }
	inline void set_U3CU3Ef__mgU24cache7_23(NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * value)
	{
		___U3CU3Ef__mgU24cache7_23 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__mgU24cache7_23), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache8_24() { return static_cast<int32_t>(offsetof(NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08_StaticFields, ___U3CU3Ef__mgU24cache8_24)); }
	inline NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * get_U3CU3Ef__mgU24cache8_24() const { return ___U3CU3Ef__mgU24cache8_24; }
	inline NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 ** get_address_of_U3CU3Ef__mgU24cache8_24() { return &___U3CU3Ef__mgU24cache8_24; }
	inline void set_U3CU3Ef__mgU24cache8_24(NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * value)
	{
		___U3CU3Ef__mgU24cache8_24 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__mgU24cache8_24), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // NETWORKSERVER_T7853DBCA77A6C479067BF35ADD08A40320C90B08_H
#ifndef PLAYERCONTROLLER_TD0BA5C3E7CAD2CE52BFFBAB61C21F86752B32EA6_H
#define PLAYERCONTROLLER_TD0BA5C3E7CAD2CE52BFFBAB61C21F86752B32EA6_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.PlayerController
struct  PlayerController_tD0BA5C3E7CAD2CE52BFFBAB61C21F86752B32EA6  : public RuntimeObject
{
public:
	// System.Int16 UnityEngine.Networking.PlayerController::playerControllerId
	int16_t ___playerControllerId_1;
	// UnityEngine.Networking.NetworkIdentity UnityEngine.Networking.PlayerController::unetView
	NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C * ___unetView_2;
	// UnityEngine.GameObject UnityEngine.Networking.PlayerController::gameObject
	GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * ___gameObject_3;

public:
	inline static int32_t get_offset_of_playerControllerId_1() { return static_cast<int32_t>(offsetof(PlayerController_tD0BA5C3E7CAD2CE52BFFBAB61C21F86752B32EA6, ___playerControllerId_1)); }
	inline int16_t get_playerControllerId_1() const { return ___playerControllerId_1; }
	inline int16_t* get_address_of_playerControllerId_1() { return &___playerControllerId_1; }
	inline void set_playerControllerId_1(int16_t value)
	{
		___playerControllerId_1 = value;
	}

	inline static int32_t get_offset_of_unetView_2() { return static_cast<int32_t>(offsetof(PlayerController_tD0BA5C3E7CAD2CE52BFFBAB61C21F86752B32EA6, ___unetView_2)); }
	inline NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C * get_unetView_2() const { return ___unetView_2; }
	inline NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C ** get_address_of_unetView_2() { return &___unetView_2; }
	inline void set_unetView_2(NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C * value)
	{
		___unetView_2 = value;
		Il2CppCodeGenWriteBarrier((&___unetView_2), value);
	}

	inline static int32_t get_offset_of_gameObject_3() { return static_cast<int32_t>(offsetof(PlayerController_tD0BA5C3E7CAD2CE52BFFBAB61C21F86752B32EA6, ___gameObject_3)); }
	inline GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * get_gameObject_3() const { return ___gameObject_3; }
	inline GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F ** get_address_of_gameObject_3() { return &___gameObject_3; }
	inline void set_gameObject_3(GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * value)
	{
		___gameObject_3 = value;
		Il2CppCodeGenWriteBarrier((&___gameObject_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // PLAYERCONTROLLER_TD0BA5C3E7CAD2CE52BFFBAB61C21F86752B32EA6_H
#ifndef SYNCLIST_1_T6497C1ACAB6EB42D6D7F298D4AB6B2EE5E9CF6EF_H
#define SYNCLIST_1_T6497C1ACAB6EB42D6D7F298D4AB6B2EE5E9CF6EF_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.SyncList`1<System.Boolean>
struct  SyncList_1_t6497C1ACAB6EB42D6D7F298D4AB6B2EE5E9CF6EF  : public RuntimeObject
{
public:
	// System.Collections.Generic.List`1<T> UnityEngine.Networking.SyncList`1::m_Objects
	List_1_t3DDB9FC102E84D6C6A4430CB071C8EF31975D03D * ___m_Objects_0;
	// UnityEngine.Networking.NetworkBehaviour UnityEngine.Networking.SyncList`1::m_Behaviour
	NetworkBehaviour_t18F8E5E1C259C5D9740A446FA1EA9480A61CF492 * ___m_Behaviour_1;
	// System.Int32 UnityEngine.Networking.SyncList`1::m_CmdHash
	int32_t ___m_CmdHash_2;
	// UnityEngine.Networking.SyncList`1_SyncListChanged<T> UnityEngine.Networking.SyncList`1::m_Callback
	SyncListChanged_t65EA534172DEE5CFC308FFBBEBB6D52EC2A4631C * ___m_Callback_3;

public:
	inline static int32_t get_offset_of_m_Objects_0() { return static_cast<int32_t>(offsetof(SyncList_1_t6497C1ACAB6EB42D6D7F298D4AB6B2EE5E9CF6EF, ___m_Objects_0)); }
	inline List_1_t3DDB9FC102E84D6C6A4430CB071C8EF31975D03D * get_m_Objects_0() const { return ___m_Objects_0; }
	inline List_1_t3DDB9FC102E84D6C6A4430CB071C8EF31975D03D ** get_address_of_m_Objects_0() { return &___m_Objects_0; }
	inline void set_m_Objects_0(List_1_t3DDB9FC102E84D6C6A4430CB071C8EF31975D03D * value)
	{
		___m_Objects_0 = value;
		Il2CppCodeGenWriteBarrier((&___m_Objects_0), value);
	}

	inline static int32_t get_offset_of_m_Behaviour_1() { return static_cast<int32_t>(offsetof(SyncList_1_t6497C1ACAB6EB42D6D7F298D4AB6B2EE5E9CF6EF, ___m_Behaviour_1)); }
	inline NetworkBehaviour_t18F8E5E1C259C5D9740A446FA1EA9480A61CF492 * get_m_Behaviour_1() const { return ___m_Behaviour_1; }
	inline NetworkBehaviour_t18F8E5E1C259C5D9740A446FA1EA9480A61CF492 ** get_address_of_m_Behaviour_1() { return &___m_Behaviour_1; }
	inline void set_m_Behaviour_1(NetworkBehaviour_t18F8E5E1C259C5D9740A446FA1EA9480A61CF492 * value)
	{
		___m_Behaviour_1 = value;
		Il2CppCodeGenWriteBarrier((&___m_Behaviour_1), value);
	}

	inline static int32_t get_offset_of_m_CmdHash_2() { return static_cast<int32_t>(offsetof(SyncList_1_t6497C1ACAB6EB42D6D7F298D4AB6B2EE5E9CF6EF, ___m_CmdHash_2)); }
	inline int32_t get_m_CmdHash_2() const { return ___m_CmdHash_2; }
	inline int32_t* get_address_of_m_CmdHash_2() { return &___m_CmdHash_2; }
	inline void set_m_CmdHash_2(int32_t value)
	{
		___m_CmdHash_2 = value;
	}

	inline static int32_t get_offset_of_m_Callback_3() { return static_cast<int32_t>(offsetof(SyncList_1_t6497C1ACAB6EB42D6D7F298D4AB6B2EE5E9CF6EF, ___m_Callback_3)); }
	inline SyncListChanged_t65EA534172DEE5CFC308FFBBEBB6D52EC2A4631C * get_m_Callback_3() const { return ___m_Callback_3; }
	inline SyncListChanged_t65EA534172DEE5CFC308FFBBEBB6D52EC2A4631C ** get_address_of_m_Callback_3() { return &___m_Callback_3; }
	inline void set_m_Callback_3(SyncListChanged_t65EA534172DEE5CFC308FFBBEBB6D52EC2A4631C * value)
	{
		___m_Callback_3 = value;
		Il2CppCodeGenWriteBarrier((&___m_Callback_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SYNCLIST_1_T6497C1ACAB6EB42D6D7F298D4AB6B2EE5E9CF6EF_H
#ifndef SYNCLIST_1_T9939BD2C6A6D9D6EB338E4D0254A8720285B7EC2_H
#define SYNCLIST_1_T9939BD2C6A6D9D6EB338E4D0254A8720285B7EC2_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.SyncList`1<System.Int32>
struct  SyncList_1_t9939BD2C6A6D9D6EB338E4D0254A8720285B7EC2  : public RuntimeObject
{
public:
	// System.Collections.Generic.List`1<T> UnityEngine.Networking.SyncList`1::m_Objects
	List_1_tE1526161A558A17A39A8B69D8EEF3801393B6226 * ___m_Objects_0;
	// UnityEngine.Networking.NetworkBehaviour UnityEngine.Networking.SyncList`1::m_Behaviour
	NetworkBehaviour_t18F8E5E1C259C5D9740A446FA1EA9480A61CF492 * ___m_Behaviour_1;
	// System.Int32 UnityEngine.Networking.SyncList`1::m_CmdHash
	int32_t ___m_CmdHash_2;
	// UnityEngine.Networking.SyncList`1_SyncListChanged<T> UnityEngine.Networking.SyncList`1::m_Callback
	SyncListChanged_tE411A925A916D890FFE042735E1AC0436E8F56DE * ___m_Callback_3;

public:
	inline static int32_t get_offset_of_m_Objects_0() { return static_cast<int32_t>(offsetof(SyncList_1_t9939BD2C6A6D9D6EB338E4D0254A8720285B7EC2, ___m_Objects_0)); }
	inline List_1_tE1526161A558A17A39A8B69D8EEF3801393B6226 * get_m_Objects_0() const { return ___m_Objects_0; }
	inline List_1_tE1526161A558A17A39A8B69D8EEF3801393B6226 ** get_address_of_m_Objects_0() { return &___m_Objects_0; }
	inline void set_m_Objects_0(List_1_tE1526161A558A17A39A8B69D8EEF3801393B6226 * value)
	{
		___m_Objects_0 = value;
		Il2CppCodeGenWriteBarrier((&___m_Objects_0), value);
	}

	inline static int32_t get_offset_of_m_Behaviour_1() { return static_cast<int32_t>(offsetof(SyncList_1_t9939BD2C6A6D9D6EB338E4D0254A8720285B7EC2, ___m_Behaviour_1)); }
	inline NetworkBehaviour_t18F8E5E1C259C5D9740A446FA1EA9480A61CF492 * get_m_Behaviour_1() const { return ___m_Behaviour_1; }
	inline NetworkBehaviour_t18F8E5E1C259C5D9740A446FA1EA9480A61CF492 ** get_address_of_m_Behaviour_1() { return &___m_Behaviour_1; }
	inline void set_m_Behaviour_1(NetworkBehaviour_t18F8E5E1C259C5D9740A446FA1EA9480A61CF492 * value)
	{
		___m_Behaviour_1 = value;
		Il2CppCodeGenWriteBarrier((&___m_Behaviour_1), value);
	}

	inline static int32_t get_offset_of_m_CmdHash_2() { return static_cast<int32_t>(offsetof(SyncList_1_t9939BD2C6A6D9D6EB338E4D0254A8720285B7EC2, ___m_CmdHash_2)); }
	inline int32_t get_m_CmdHash_2() const { return ___m_CmdHash_2; }
	inline int32_t* get_address_of_m_CmdHash_2() { return &___m_CmdHash_2; }
	inline void set_m_CmdHash_2(int32_t value)
	{
		___m_CmdHash_2 = value;
	}

	inline static int32_t get_offset_of_m_Callback_3() { return static_cast<int32_t>(offsetof(SyncList_1_t9939BD2C6A6D9D6EB338E4D0254A8720285B7EC2, ___m_Callback_3)); }
	inline SyncListChanged_tE411A925A916D890FFE042735E1AC0436E8F56DE * get_m_Callback_3() const { return ___m_Callback_3; }
	inline SyncListChanged_tE411A925A916D890FFE042735E1AC0436E8F56DE ** get_address_of_m_Callback_3() { return &___m_Callback_3; }
	inline void set_m_Callback_3(SyncListChanged_tE411A925A916D890FFE042735E1AC0436E8F56DE * value)
	{
		___m_Callback_3 = value;
		Il2CppCodeGenWriteBarrier((&___m_Callback_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SYNCLIST_1_T9939BD2C6A6D9D6EB338E4D0254A8720285B7EC2_H
#ifndef SYNCLIST_1_T491D70D47353E92E83C01A9E23BC5C5ADAAE7311_H
#define SYNCLIST_1_T491D70D47353E92E83C01A9E23BC5C5ADAAE7311_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.SyncList`1<System.Single>
struct  SyncList_1_t491D70D47353E92E83C01A9E23BC5C5ADAAE7311  : public RuntimeObject
{
public:
	// System.Collections.Generic.List`1<T> UnityEngine.Networking.SyncList`1::m_Objects
	List_1_tC02C2993D5A6DDB73B1126E4EECDEB641C54A03E * ___m_Objects_0;
	// UnityEngine.Networking.NetworkBehaviour UnityEngine.Networking.SyncList`1::m_Behaviour
	NetworkBehaviour_t18F8E5E1C259C5D9740A446FA1EA9480A61CF492 * ___m_Behaviour_1;
	// System.Int32 UnityEngine.Networking.SyncList`1::m_CmdHash
	int32_t ___m_CmdHash_2;
	// UnityEngine.Networking.SyncList`1_SyncListChanged<T> UnityEngine.Networking.SyncList`1::m_Callback
	SyncListChanged_t6BD906472E58E409D0ECECA453CD560D0E726A47 * ___m_Callback_3;

public:
	inline static int32_t get_offset_of_m_Objects_0() { return static_cast<int32_t>(offsetof(SyncList_1_t491D70D47353E92E83C01A9E23BC5C5ADAAE7311, ___m_Objects_0)); }
	inline List_1_tC02C2993D5A6DDB73B1126E4EECDEB641C54A03E * get_m_Objects_0() const { return ___m_Objects_0; }
	inline List_1_tC02C2993D5A6DDB73B1126E4EECDEB641C54A03E ** get_address_of_m_Objects_0() { return &___m_Objects_0; }
	inline void set_m_Objects_0(List_1_tC02C2993D5A6DDB73B1126E4EECDEB641C54A03E * value)
	{
		___m_Objects_0 = value;
		Il2CppCodeGenWriteBarrier((&___m_Objects_0), value);
	}

	inline static int32_t get_offset_of_m_Behaviour_1() { return static_cast<int32_t>(offsetof(SyncList_1_t491D70D47353E92E83C01A9E23BC5C5ADAAE7311, ___m_Behaviour_1)); }
	inline NetworkBehaviour_t18F8E5E1C259C5D9740A446FA1EA9480A61CF492 * get_m_Behaviour_1() const { return ___m_Behaviour_1; }
	inline NetworkBehaviour_t18F8E5E1C259C5D9740A446FA1EA9480A61CF492 ** get_address_of_m_Behaviour_1() { return &___m_Behaviour_1; }
	inline void set_m_Behaviour_1(NetworkBehaviour_t18F8E5E1C259C5D9740A446FA1EA9480A61CF492 * value)
	{
		___m_Behaviour_1 = value;
		Il2CppCodeGenWriteBarrier((&___m_Behaviour_1), value);
	}

	inline static int32_t get_offset_of_m_CmdHash_2() { return static_cast<int32_t>(offsetof(SyncList_1_t491D70D47353E92E83C01A9E23BC5C5ADAAE7311, ___m_CmdHash_2)); }
	inline int32_t get_m_CmdHash_2() const { return ___m_CmdHash_2; }
	inline int32_t* get_address_of_m_CmdHash_2() { return &___m_CmdHash_2; }
	inline void set_m_CmdHash_2(int32_t value)
	{
		___m_CmdHash_2 = value;
	}

	inline static int32_t get_offset_of_m_Callback_3() { return static_cast<int32_t>(offsetof(SyncList_1_t491D70D47353E92E83C01A9E23BC5C5ADAAE7311, ___m_Callback_3)); }
	inline SyncListChanged_t6BD906472E58E409D0ECECA453CD560D0E726A47 * get_m_Callback_3() const { return ___m_Callback_3; }
	inline SyncListChanged_t6BD906472E58E409D0ECECA453CD560D0E726A47 ** get_address_of_m_Callback_3() { return &___m_Callback_3; }
	inline void set_m_Callback_3(SyncListChanged_t6BD906472E58E409D0ECECA453CD560D0E726A47 * value)
	{
		___m_Callback_3 = value;
		Il2CppCodeGenWriteBarrier((&___m_Callback_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SYNCLIST_1_T491D70D47353E92E83C01A9E23BC5C5ADAAE7311_H
#ifndef SYNCLIST_1_TD7067A1EED06B4DCC141C47BEDD2B2ADDF546EB6_H
#define SYNCLIST_1_TD7067A1EED06B4DCC141C47BEDD2B2ADDF546EB6_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.SyncList`1<System.String>
struct  SyncList_1_tD7067A1EED06B4DCC141C47BEDD2B2ADDF546EB6  : public RuntimeObject
{
public:
	// System.Collections.Generic.List`1<T> UnityEngine.Networking.SyncList`1::m_Objects
	List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * ___m_Objects_0;
	// UnityEngine.Networking.NetworkBehaviour UnityEngine.Networking.SyncList`1::m_Behaviour
	NetworkBehaviour_t18F8E5E1C259C5D9740A446FA1EA9480A61CF492 * ___m_Behaviour_1;
	// System.Int32 UnityEngine.Networking.SyncList`1::m_CmdHash
	int32_t ___m_CmdHash_2;
	// UnityEngine.Networking.SyncList`1_SyncListChanged<T> UnityEngine.Networking.SyncList`1::m_Callback
	SyncListChanged_t6D43F29A0B1156F70E4A643C6AC2DCFEA0820CC6 * ___m_Callback_3;

public:
	inline static int32_t get_offset_of_m_Objects_0() { return static_cast<int32_t>(offsetof(SyncList_1_tD7067A1EED06B4DCC141C47BEDD2B2ADDF546EB6, ___m_Objects_0)); }
	inline List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * get_m_Objects_0() const { return ___m_Objects_0; }
	inline List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 ** get_address_of_m_Objects_0() { return &___m_Objects_0; }
	inline void set_m_Objects_0(List_1_tE8032E48C661C350FF9550E9063D595C0AB25CD3 * value)
	{
		___m_Objects_0 = value;
		Il2CppCodeGenWriteBarrier((&___m_Objects_0), value);
	}

	inline static int32_t get_offset_of_m_Behaviour_1() { return static_cast<int32_t>(offsetof(SyncList_1_tD7067A1EED06B4DCC141C47BEDD2B2ADDF546EB6, ___m_Behaviour_1)); }
	inline NetworkBehaviour_t18F8E5E1C259C5D9740A446FA1EA9480A61CF492 * get_m_Behaviour_1() const { return ___m_Behaviour_1; }
	inline NetworkBehaviour_t18F8E5E1C259C5D9740A446FA1EA9480A61CF492 ** get_address_of_m_Behaviour_1() { return &___m_Behaviour_1; }
	inline void set_m_Behaviour_1(NetworkBehaviour_t18F8E5E1C259C5D9740A446FA1EA9480A61CF492 * value)
	{
		___m_Behaviour_1 = value;
		Il2CppCodeGenWriteBarrier((&___m_Behaviour_1), value);
	}

	inline static int32_t get_offset_of_m_CmdHash_2() { return static_cast<int32_t>(offsetof(SyncList_1_tD7067A1EED06B4DCC141C47BEDD2B2ADDF546EB6, ___m_CmdHash_2)); }
	inline int32_t get_m_CmdHash_2() const { return ___m_CmdHash_2; }
	inline int32_t* get_address_of_m_CmdHash_2() { return &___m_CmdHash_2; }
	inline void set_m_CmdHash_2(int32_t value)
	{
		___m_CmdHash_2 = value;
	}

	inline static int32_t get_offset_of_m_Callback_3() { return static_cast<int32_t>(offsetof(SyncList_1_tD7067A1EED06B4DCC141C47BEDD2B2ADDF546EB6, ___m_Callback_3)); }
	inline SyncListChanged_t6D43F29A0B1156F70E4A643C6AC2DCFEA0820CC6 * get_m_Callback_3() const { return ___m_Callback_3; }
	inline SyncListChanged_t6D43F29A0B1156F70E4A643C6AC2DCFEA0820CC6 ** get_address_of_m_Callback_3() { return &___m_Callback_3; }
	inline void set_m_Callback_3(SyncListChanged_t6D43F29A0B1156F70E4A643C6AC2DCFEA0820CC6 * value)
	{
		___m_Callback_3 = value;
		Il2CppCodeGenWriteBarrier((&___m_Callback_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SYNCLIST_1_TD7067A1EED06B4DCC141C47BEDD2B2ADDF546EB6_H
#ifndef SYNCLIST_1_TF7370C9EAD80F16C94714515A80898967A7AC85C_H
#define SYNCLIST_1_TF7370C9EAD80F16C94714515A80898967A7AC85C_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.SyncList`1<System.UInt32>
struct  SyncList_1_tF7370C9EAD80F16C94714515A80898967A7AC85C  : public RuntimeObject
{
public:
	// System.Collections.Generic.List`1<T> UnityEngine.Networking.SyncList`1::m_Objects
	List_1_t49B315A213A231954A3718D77EE3A2AFF443C38E * ___m_Objects_0;
	// UnityEngine.Networking.NetworkBehaviour UnityEngine.Networking.SyncList`1::m_Behaviour
	NetworkBehaviour_t18F8E5E1C259C5D9740A446FA1EA9480A61CF492 * ___m_Behaviour_1;
	// System.Int32 UnityEngine.Networking.SyncList`1::m_CmdHash
	int32_t ___m_CmdHash_2;
	// UnityEngine.Networking.SyncList`1_SyncListChanged<T> UnityEngine.Networking.SyncList`1::m_Callback
	SyncListChanged_t1EC03E4D6A4ED535AAFB72EC4D2D20A7C965740A * ___m_Callback_3;

public:
	inline static int32_t get_offset_of_m_Objects_0() { return static_cast<int32_t>(offsetof(SyncList_1_tF7370C9EAD80F16C94714515A80898967A7AC85C, ___m_Objects_0)); }
	inline List_1_t49B315A213A231954A3718D77EE3A2AFF443C38E * get_m_Objects_0() const { return ___m_Objects_0; }
	inline List_1_t49B315A213A231954A3718D77EE3A2AFF443C38E ** get_address_of_m_Objects_0() { return &___m_Objects_0; }
	inline void set_m_Objects_0(List_1_t49B315A213A231954A3718D77EE3A2AFF443C38E * value)
	{
		___m_Objects_0 = value;
		Il2CppCodeGenWriteBarrier((&___m_Objects_0), value);
	}

	inline static int32_t get_offset_of_m_Behaviour_1() { return static_cast<int32_t>(offsetof(SyncList_1_tF7370C9EAD80F16C94714515A80898967A7AC85C, ___m_Behaviour_1)); }
	inline NetworkBehaviour_t18F8E5E1C259C5D9740A446FA1EA9480A61CF492 * get_m_Behaviour_1() const { return ___m_Behaviour_1; }
	inline NetworkBehaviour_t18F8E5E1C259C5D9740A446FA1EA9480A61CF492 ** get_address_of_m_Behaviour_1() { return &___m_Behaviour_1; }
	inline void set_m_Behaviour_1(NetworkBehaviour_t18F8E5E1C259C5D9740A446FA1EA9480A61CF492 * value)
	{
		___m_Behaviour_1 = value;
		Il2CppCodeGenWriteBarrier((&___m_Behaviour_1), value);
	}

	inline static int32_t get_offset_of_m_CmdHash_2() { return static_cast<int32_t>(offsetof(SyncList_1_tF7370C9EAD80F16C94714515A80898967A7AC85C, ___m_CmdHash_2)); }
	inline int32_t get_m_CmdHash_2() const { return ___m_CmdHash_2; }
	inline int32_t* get_address_of_m_CmdHash_2() { return &___m_CmdHash_2; }
	inline void set_m_CmdHash_2(int32_t value)
	{
		___m_CmdHash_2 = value;
	}

	inline static int32_t get_offset_of_m_Callback_3() { return static_cast<int32_t>(offsetof(SyncList_1_tF7370C9EAD80F16C94714515A80898967A7AC85C, ___m_Callback_3)); }
	inline SyncListChanged_t1EC03E4D6A4ED535AAFB72EC4D2D20A7C965740A * get_m_Callback_3() const { return ___m_Callback_3; }
	inline SyncListChanged_t1EC03E4D6A4ED535AAFB72EC4D2D20A7C965740A ** get_address_of_m_Callback_3() { return &___m_Callback_3; }
	inline void set_m_Callback_3(SyncListChanged_t1EC03E4D6A4ED535AAFB72EC4D2D20A7C965740A * value)
	{
		___m_Callback_3 = value;
		Il2CppCodeGenWriteBarrier((&___m_Callback_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SYNCLIST_1_TF7370C9EAD80F16C94714515A80898967A7AC85C_H
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
#ifndef NETWORKHASH128_TFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6_H
#define NETWORKHASH128_TFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkHash128
struct  NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6 
{
public:
	// System.Byte UnityEngine.Networking.NetworkHash128::i0
	uint8_t ___i0_0;
	// System.Byte UnityEngine.Networking.NetworkHash128::i1
	uint8_t ___i1_1;
	// System.Byte UnityEngine.Networking.NetworkHash128::i2
	uint8_t ___i2_2;
	// System.Byte UnityEngine.Networking.NetworkHash128::i3
	uint8_t ___i3_3;
	// System.Byte UnityEngine.Networking.NetworkHash128::i4
	uint8_t ___i4_4;
	// System.Byte UnityEngine.Networking.NetworkHash128::i5
	uint8_t ___i5_5;
	// System.Byte UnityEngine.Networking.NetworkHash128::i6
	uint8_t ___i6_6;
	// System.Byte UnityEngine.Networking.NetworkHash128::i7
	uint8_t ___i7_7;
	// System.Byte UnityEngine.Networking.NetworkHash128::i8
	uint8_t ___i8_8;
	// System.Byte UnityEngine.Networking.NetworkHash128::i9
	uint8_t ___i9_9;
	// System.Byte UnityEngine.Networking.NetworkHash128::i10
	uint8_t ___i10_10;
	// System.Byte UnityEngine.Networking.NetworkHash128::i11
	uint8_t ___i11_11;
	// System.Byte UnityEngine.Networking.NetworkHash128::i12
	uint8_t ___i12_12;
	// System.Byte UnityEngine.Networking.NetworkHash128::i13
	uint8_t ___i13_13;
	// System.Byte UnityEngine.Networking.NetworkHash128::i14
	uint8_t ___i14_14;
	// System.Byte UnityEngine.Networking.NetworkHash128::i15
	uint8_t ___i15_15;

public:
	inline static int32_t get_offset_of_i0_0() { return static_cast<int32_t>(offsetof(NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6, ___i0_0)); }
	inline uint8_t get_i0_0() const { return ___i0_0; }
	inline uint8_t* get_address_of_i0_0() { return &___i0_0; }
	inline void set_i0_0(uint8_t value)
	{
		___i0_0 = value;
	}

	inline static int32_t get_offset_of_i1_1() { return static_cast<int32_t>(offsetof(NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6, ___i1_1)); }
	inline uint8_t get_i1_1() const { return ___i1_1; }
	inline uint8_t* get_address_of_i1_1() { return &___i1_1; }
	inline void set_i1_1(uint8_t value)
	{
		___i1_1 = value;
	}

	inline static int32_t get_offset_of_i2_2() { return static_cast<int32_t>(offsetof(NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6, ___i2_2)); }
	inline uint8_t get_i2_2() const { return ___i2_2; }
	inline uint8_t* get_address_of_i2_2() { return &___i2_2; }
	inline void set_i2_2(uint8_t value)
	{
		___i2_2 = value;
	}

	inline static int32_t get_offset_of_i3_3() { return static_cast<int32_t>(offsetof(NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6, ___i3_3)); }
	inline uint8_t get_i3_3() const { return ___i3_3; }
	inline uint8_t* get_address_of_i3_3() { return &___i3_3; }
	inline void set_i3_3(uint8_t value)
	{
		___i3_3 = value;
	}

	inline static int32_t get_offset_of_i4_4() { return static_cast<int32_t>(offsetof(NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6, ___i4_4)); }
	inline uint8_t get_i4_4() const { return ___i4_4; }
	inline uint8_t* get_address_of_i4_4() { return &___i4_4; }
	inline void set_i4_4(uint8_t value)
	{
		___i4_4 = value;
	}

	inline static int32_t get_offset_of_i5_5() { return static_cast<int32_t>(offsetof(NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6, ___i5_5)); }
	inline uint8_t get_i5_5() const { return ___i5_5; }
	inline uint8_t* get_address_of_i5_5() { return &___i5_5; }
	inline void set_i5_5(uint8_t value)
	{
		___i5_5 = value;
	}

	inline static int32_t get_offset_of_i6_6() { return static_cast<int32_t>(offsetof(NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6, ___i6_6)); }
	inline uint8_t get_i6_6() const { return ___i6_6; }
	inline uint8_t* get_address_of_i6_6() { return &___i6_6; }
	inline void set_i6_6(uint8_t value)
	{
		___i6_6 = value;
	}

	inline static int32_t get_offset_of_i7_7() { return static_cast<int32_t>(offsetof(NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6, ___i7_7)); }
	inline uint8_t get_i7_7() const { return ___i7_7; }
	inline uint8_t* get_address_of_i7_7() { return &___i7_7; }
	inline void set_i7_7(uint8_t value)
	{
		___i7_7 = value;
	}

	inline static int32_t get_offset_of_i8_8() { return static_cast<int32_t>(offsetof(NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6, ___i8_8)); }
	inline uint8_t get_i8_8() const { return ___i8_8; }
	inline uint8_t* get_address_of_i8_8() { return &___i8_8; }
	inline void set_i8_8(uint8_t value)
	{
		___i8_8 = value;
	}

	inline static int32_t get_offset_of_i9_9() { return static_cast<int32_t>(offsetof(NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6, ___i9_9)); }
	inline uint8_t get_i9_9() const { return ___i9_9; }
	inline uint8_t* get_address_of_i9_9() { return &___i9_9; }
	inline void set_i9_9(uint8_t value)
	{
		___i9_9 = value;
	}

	inline static int32_t get_offset_of_i10_10() { return static_cast<int32_t>(offsetof(NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6, ___i10_10)); }
	inline uint8_t get_i10_10() const { return ___i10_10; }
	inline uint8_t* get_address_of_i10_10() { return &___i10_10; }
	inline void set_i10_10(uint8_t value)
	{
		___i10_10 = value;
	}

	inline static int32_t get_offset_of_i11_11() { return static_cast<int32_t>(offsetof(NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6, ___i11_11)); }
	inline uint8_t get_i11_11() const { return ___i11_11; }
	inline uint8_t* get_address_of_i11_11() { return &___i11_11; }
	inline void set_i11_11(uint8_t value)
	{
		___i11_11 = value;
	}

	inline static int32_t get_offset_of_i12_12() { return static_cast<int32_t>(offsetof(NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6, ___i12_12)); }
	inline uint8_t get_i12_12() const { return ___i12_12; }
	inline uint8_t* get_address_of_i12_12() { return &___i12_12; }
	inline void set_i12_12(uint8_t value)
	{
		___i12_12 = value;
	}

	inline static int32_t get_offset_of_i13_13() { return static_cast<int32_t>(offsetof(NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6, ___i13_13)); }
	inline uint8_t get_i13_13() const { return ___i13_13; }
	inline uint8_t* get_address_of_i13_13() { return &___i13_13; }
	inline void set_i13_13(uint8_t value)
	{
		___i13_13 = value;
	}

	inline static int32_t get_offset_of_i14_14() { return static_cast<int32_t>(offsetof(NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6, ___i14_14)); }
	inline uint8_t get_i14_14() const { return ___i14_14; }
	inline uint8_t* get_address_of_i14_14() { return &___i14_14; }
	inline void set_i14_14(uint8_t value)
	{
		___i14_14 = value;
	}

	inline static int32_t get_offset_of_i15_15() { return static_cast<int32_t>(offsetof(NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6, ___i15_15)); }
	inline uint8_t get_i15_15() const { return ___i15_15; }
	inline uint8_t* get_address_of_i15_15() { return &___i15_15; }
	inline void set_i15_15(uint8_t value)
	{
		___i15_15 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // NETWORKHASH128_TFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6_H
#ifndef NETWORKINSTANCEID_T52D82C12D9E18FD105D62C40BC0528CAD1C571A0_H
#define NETWORKINSTANCEID_T52D82C12D9E18FD105D62C40BC0528CAD1C571A0_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkInstanceId
struct  NetworkInstanceId_t52D82C12D9E18FD105D62C40BC0528CAD1C571A0 
{
public:
	// System.UInt32 UnityEngine.Networking.NetworkInstanceId::m_Value
	uint32_t ___m_Value_0;

public:
	inline static int32_t get_offset_of_m_Value_0() { return static_cast<int32_t>(offsetof(NetworkInstanceId_t52D82C12D9E18FD105D62C40BC0528CAD1C571A0, ___m_Value_0)); }
	inline uint32_t get_m_Value_0() const { return ___m_Value_0; }
	inline uint32_t* get_address_of_m_Value_0() { return &___m_Value_0; }
	inline void set_m_Value_0(uint32_t value)
	{
		___m_Value_0 = value;
	}
};

struct NetworkInstanceId_t52D82C12D9E18FD105D62C40BC0528CAD1C571A0_StaticFields
{
public:
	// UnityEngine.Networking.NetworkInstanceId UnityEngine.Networking.NetworkInstanceId::Invalid
	NetworkInstanceId_t52D82C12D9E18FD105D62C40BC0528CAD1C571A0  ___Invalid_1;
	// UnityEngine.Networking.NetworkInstanceId UnityEngine.Networking.NetworkInstanceId::Zero
	NetworkInstanceId_t52D82C12D9E18FD105D62C40BC0528CAD1C571A0  ___Zero_2;

public:
	inline static int32_t get_offset_of_Invalid_1() { return static_cast<int32_t>(offsetof(NetworkInstanceId_t52D82C12D9E18FD105D62C40BC0528CAD1C571A0_StaticFields, ___Invalid_1)); }
	inline NetworkInstanceId_t52D82C12D9E18FD105D62C40BC0528CAD1C571A0  get_Invalid_1() const { return ___Invalid_1; }
	inline NetworkInstanceId_t52D82C12D9E18FD105D62C40BC0528CAD1C571A0 * get_address_of_Invalid_1() { return &___Invalid_1; }
	inline void set_Invalid_1(NetworkInstanceId_t52D82C12D9E18FD105D62C40BC0528CAD1C571A0  value)
	{
		___Invalid_1 = value;
	}

	inline static int32_t get_offset_of_Zero_2() { return static_cast<int32_t>(offsetof(NetworkInstanceId_t52D82C12D9E18FD105D62C40BC0528CAD1C571A0_StaticFields, ___Zero_2)); }
	inline NetworkInstanceId_t52D82C12D9E18FD105D62C40BC0528CAD1C571A0  get_Zero_2() const { return ___Zero_2; }
	inline NetworkInstanceId_t52D82C12D9E18FD105D62C40BC0528CAD1C571A0 * get_address_of_Zero_2() { return &___Zero_2; }
	inline void set_Zero_2(NetworkInstanceId_t52D82C12D9E18FD105D62C40BC0528CAD1C571A0  value)
	{
		___Zero_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // NETWORKINSTANCEID_T52D82C12D9E18FD105D62C40BC0528CAD1C571A0_H
#ifndef NETWORKSCENEID_T5B68395705D998766CE75794410ACFF5A3019823_H
#define NETWORKSCENEID_T5B68395705D998766CE75794410ACFF5A3019823_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkSceneId
struct  NetworkSceneId_t5B68395705D998766CE75794410ACFF5A3019823 
{
public:
	// System.UInt32 UnityEngine.Networking.NetworkSceneId::m_Value
	uint32_t ___m_Value_0;

public:
	inline static int32_t get_offset_of_m_Value_0() { return static_cast<int32_t>(offsetof(NetworkSceneId_t5B68395705D998766CE75794410ACFF5A3019823, ___m_Value_0)); }
	inline uint32_t get_m_Value_0() const { return ___m_Value_0; }
	inline uint32_t* get_address_of_m_Value_0() { return &___m_Value_0; }
	inline void set_m_Value_0(uint32_t value)
	{
		___m_Value_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // NETWORKSCENEID_T5B68395705D998766CE75794410ACFF5A3019823_H
#ifndef SERVERATTRIBUTE_T8EDD5C7824A540E38F713A2F26FFB1D756FA6F57_H
#define SERVERATTRIBUTE_T8EDD5C7824A540E38F713A2F26FFB1D756FA6F57_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.ServerAttribute
struct  ServerAttribute_t8EDD5C7824A540E38F713A2F26FFB1D756FA6F57  : public Attribute_tF048C13FB3C8CFCC53F82290E4A3F621089F9A74
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SERVERATTRIBUTE_T8EDD5C7824A540E38F713A2F26FFB1D756FA6F57_H
#ifndef SERVERCALLBACKATTRIBUTE_T1E84676A0DB622681E63343EA55890C92A1EA3EE_H
#define SERVERCALLBACKATTRIBUTE_T1E84676A0DB622681E63343EA55890C92A1EA3EE_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.ServerCallbackAttribute
struct  ServerCallbackAttribute_t1E84676A0DB622681E63343EA55890C92A1EA3EE  : public Attribute_tF048C13FB3C8CFCC53F82290E4A3F621089F9A74
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SERVERCALLBACKATTRIBUTE_T1E84676A0DB622681E63343EA55890C92A1EA3EE_H
#ifndef SYNCEVENTATTRIBUTE_T2D5695F58C45D4EE6A5303719EEDF84073160086_H
#define SYNCEVENTATTRIBUTE_T2D5695F58C45D4EE6A5303719EEDF84073160086_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.SyncEventAttribute
struct  SyncEventAttribute_t2D5695F58C45D4EE6A5303719EEDF84073160086  : public Attribute_tF048C13FB3C8CFCC53F82290E4A3F621089F9A74
{
public:
	// System.Int32 UnityEngine.Networking.SyncEventAttribute::channel
	int32_t ___channel_0;

public:
	inline static int32_t get_offset_of_channel_0() { return static_cast<int32_t>(offsetof(SyncEventAttribute_t2D5695F58C45D4EE6A5303719EEDF84073160086, ___channel_0)); }
	inline int32_t get_channel_0() const { return ___channel_0; }
	inline int32_t* get_address_of_channel_0() { return &___channel_0; }
	inline void set_channel_0(int32_t value)
	{
		___channel_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SYNCEVENTATTRIBUTE_T2D5695F58C45D4EE6A5303719EEDF84073160086_H
#ifndef SYNCLISTBOOL_T923ECFA13FD645E25323073E9D533ADF88B0443D_H
#define SYNCLISTBOOL_T923ECFA13FD645E25323073E9D533ADF88B0443D_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.SyncListBool
struct  SyncListBool_t923ECFA13FD645E25323073E9D533ADF88B0443D  : public SyncList_1_t6497C1ACAB6EB42D6D7F298D4AB6B2EE5E9CF6EF
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SYNCLISTBOOL_T923ECFA13FD645E25323073E9D533ADF88B0443D_H
#ifndef SYNCLISTFLOAT_T645D206D30E48C66279A460EFF51EE1122F25708_H
#define SYNCLISTFLOAT_T645D206D30E48C66279A460EFF51EE1122F25708_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.SyncListFloat
struct  SyncListFloat_t645D206D30E48C66279A460EFF51EE1122F25708  : public SyncList_1_t491D70D47353E92E83C01A9E23BC5C5ADAAE7311
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SYNCLISTFLOAT_T645D206D30E48C66279A460EFF51EE1122F25708_H
#ifndef SYNCLISTINT_T983DECC70C3DF63128B79CC3F65E9153AC31E91C_H
#define SYNCLISTINT_T983DECC70C3DF63128B79CC3F65E9153AC31E91C_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.SyncListInt
struct  SyncListInt_t983DECC70C3DF63128B79CC3F65E9153AC31E91C  : public SyncList_1_t9939BD2C6A6D9D6EB338E4D0254A8720285B7EC2
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SYNCLISTINT_T983DECC70C3DF63128B79CC3F65E9153AC31E91C_H
#ifndef SYNCLISTSTRING_T60A178543A04A4418DB27AEAABA7D8E224C5CCF0_H
#define SYNCLISTSTRING_T60A178543A04A4418DB27AEAABA7D8E224C5CCF0_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.SyncListString
struct  SyncListString_t60A178543A04A4418DB27AEAABA7D8E224C5CCF0  : public SyncList_1_tD7067A1EED06B4DCC141C47BEDD2B2ADDF546EB6
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SYNCLISTSTRING_T60A178543A04A4418DB27AEAABA7D8E224C5CCF0_H
#ifndef SYNCLISTUINT_T07AD639C74DD935A6A0A498026B4BD89A222A2B9_H
#define SYNCLISTUINT_T07AD639C74DD935A6A0A498026B4BD89A222A2B9_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.SyncListUInt
struct  SyncListUInt_t07AD639C74DD935A6A0A498026B4BD89A222A2B9  : public SyncList_1_tF7370C9EAD80F16C94714515A80898967A7AC85C
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SYNCLISTUINT_T07AD639C74DD935A6A0A498026B4BD89A222A2B9_H
#ifndef SYNCVARATTRIBUTE_T9F652FDE52D8EEA95040A1BED1DDDE54939FBA83_H
#define SYNCVARATTRIBUTE_T9F652FDE52D8EEA95040A1BED1DDDE54939FBA83_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.SyncVarAttribute
struct  SyncVarAttribute_t9F652FDE52D8EEA95040A1BED1DDDE54939FBA83  : public Attribute_tF048C13FB3C8CFCC53F82290E4A3F621089F9A74
{
public:
	// System.String UnityEngine.Networking.SyncVarAttribute::hook
	String_t* ___hook_0;

public:
	inline static int32_t get_offset_of_hook_0() { return static_cast<int32_t>(offsetof(SyncVarAttribute_t9F652FDE52D8EEA95040A1BED1DDDE54939FBA83, ___hook_0)); }
	inline String_t* get_hook_0() const { return ___hook_0; }
	inline String_t** get_address_of_hook_0() { return &___hook_0; }
	inline void set_hook_0(String_t* value)
	{
		___hook_0 = value;
		Il2CppCodeGenWriteBarrier((&___hook_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SYNCVARATTRIBUTE_T9F652FDE52D8EEA95040A1BED1DDDE54939FBA83_H
#ifndef TARGETRPCATTRIBUTE_T25BFBC0FF05FDE98CBF816FD2B0ED7FD275AD1FE_H
#define TARGETRPCATTRIBUTE_T25BFBC0FF05FDE98CBF816FD2B0ED7FD275AD1FE_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.TargetRpcAttribute
struct  TargetRpcAttribute_t25BFBC0FF05FDE98CBF816FD2B0ED7FD275AD1FE  : public Attribute_tF048C13FB3C8CFCC53F82290E4A3F621089F9A74
{
public:
	// System.Int32 UnityEngine.Networking.TargetRpcAttribute::channel
	int32_t ___channel_0;

public:
	inline static int32_t get_offset_of_channel_0() { return static_cast<int32_t>(offsetof(TargetRpcAttribute_t25BFBC0FF05FDE98CBF816FD2B0ED7FD275AD1FE, ___channel_0)); }
	inline int32_t get_channel_0() const { return ___channel_0; }
	inline int32_t* get_address_of_channel_0() { return &___channel_0; }
	inline void set_channel_0(int32_t value)
	{
		___channel_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TARGETRPCATTRIBUTE_T25BFBC0FF05FDE98CBF816FD2B0ED7FD275AD1FE_H
#ifndef UINTFLOAT_T6DD551096A5610B603FFAA3B4EFD2FC65CA56E7A_H
#define UINTFLOAT_T6DD551096A5610B603FFAA3B4EFD2FC65CA56E7A_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.UIntFloat
struct  UIntFloat_t6DD551096A5610B603FFAA3B4EFD2FC65CA56E7A 
{
public:
	union
	{
		#pragma pack(push, tp, 1)
		struct
		{
			// System.Single UnityEngine.Networking.UIntFloat::floatValue
			float ___floatValue_0;
		};
		#pragma pack(pop, tp)
		struct
		{
			float ___floatValue_0_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			// System.UInt32 UnityEngine.Networking.UIntFloat::intValue
			uint32_t ___intValue_1;
		};
		#pragma pack(pop, tp)
		struct
		{
			uint32_t ___intValue_1_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			// System.Double UnityEngine.Networking.UIntFloat::doubleValue
			double ___doubleValue_2;
		};
		#pragma pack(pop, tp)
		struct
		{
			double ___doubleValue_2_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			// System.UInt64 UnityEngine.Networking.UIntFloat::longValue
			uint64_t ___longValue_3;
		};
		#pragma pack(pop, tp)
		struct
		{
			uint64_t ___longValue_3_forAlignmentOnly;
		};
	};

public:
	inline static int32_t get_offset_of_floatValue_0() { return static_cast<int32_t>(offsetof(UIntFloat_t6DD551096A5610B603FFAA3B4EFD2FC65CA56E7A, ___floatValue_0)); }
	inline float get_floatValue_0() const { return ___floatValue_0; }
	inline float* get_address_of_floatValue_0() { return &___floatValue_0; }
	inline void set_floatValue_0(float value)
	{
		___floatValue_0 = value;
	}

	inline static int32_t get_offset_of_intValue_1() { return static_cast<int32_t>(offsetof(UIntFloat_t6DD551096A5610B603FFAA3B4EFD2FC65CA56E7A, ___intValue_1)); }
	inline uint32_t get_intValue_1() const { return ___intValue_1; }
	inline uint32_t* get_address_of_intValue_1() { return &___intValue_1; }
	inline void set_intValue_1(uint32_t value)
	{
		___intValue_1 = value;
	}

	inline static int32_t get_offset_of_doubleValue_2() { return static_cast<int32_t>(offsetof(UIntFloat_t6DD551096A5610B603FFAA3B4EFD2FC65CA56E7A, ___doubleValue_2)); }
	inline double get_doubleValue_2() const { return ___doubleValue_2; }
	inline double* get_address_of_doubleValue_2() { return &___doubleValue_2; }
	inline void set_doubleValue_2(double value)
	{
		___doubleValue_2 = value;
	}

	inline static int32_t get_offset_of_longValue_3() { return static_cast<int32_t>(offsetof(UIntFloat_t6DD551096A5610B603FFAA3B4EFD2FC65CA56E7A, ___longValue_3)); }
	inline uint64_t get_longValue_3() const { return ___longValue_3; }
	inline uint64_t* get_address_of_longValue_3() { return &___longValue_3; }
	inline void set_longValue_3(uint64_t value)
	{
		___longValue_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UINTFLOAT_T6DD551096A5610B603FFAA3B4EFD2FC65CA56E7A_H
#ifndef VECTOR3_TDCF05E21F632FE2BA260C06E0D10CA81513E6720_H
#define VECTOR3_TDCF05E21F632FE2BA260C06E0D10CA81513E6720_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Vector3
struct  Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 
{
public:
	// System.Single UnityEngine.Vector3::x
	float ___x_2;
	// System.Single UnityEngine.Vector3::y
	float ___y_3;
	// System.Single UnityEngine.Vector3::z
	float ___z_4;

public:
	inline static int32_t get_offset_of_x_2() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720, ___x_2)); }
	inline float get_x_2() const { return ___x_2; }
	inline float* get_address_of_x_2() { return &___x_2; }
	inline void set_x_2(float value)
	{
		___x_2 = value;
	}

	inline static int32_t get_offset_of_y_3() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720, ___y_3)); }
	inline float get_y_3() const { return ___y_3; }
	inline float* get_address_of_y_3() { return &___y_3; }
	inline void set_y_3(float value)
	{
		___y_3 = value;
	}

	inline static int32_t get_offset_of_z_4() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720, ___z_4)); }
	inline float get_z_4() const { return ___z_4; }
	inline float* get_address_of_z_4() { return &___z_4; }
	inline void set_z_4(float value)
	{
		___z_4 = value;
	}
};

struct Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields
{
public:
	// UnityEngine.Vector3 UnityEngine.Vector3::zeroVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___zeroVector_5;
	// UnityEngine.Vector3 UnityEngine.Vector3::oneVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___oneVector_6;
	// UnityEngine.Vector3 UnityEngine.Vector3::upVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___upVector_7;
	// UnityEngine.Vector3 UnityEngine.Vector3::downVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___downVector_8;
	// UnityEngine.Vector3 UnityEngine.Vector3::leftVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___leftVector_9;
	// UnityEngine.Vector3 UnityEngine.Vector3::rightVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___rightVector_10;
	// UnityEngine.Vector3 UnityEngine.Vector3::forwardVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___forwardVector_11;
	// UnityEngine.Vector3 UnityEngine.Vector3::backVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___backVector_12;
	// UnityEngine.Vector3 UnityEngine.Vector3::positiveInfinityVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___positiveInfinityVector_13;
	// UnityEngine.Vector3 UnityEngine.Vector3::negativeInfinityVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___negativeInfinityVector_14;

public:
	inline static int32_t get_offset_of_zeroVector_5() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___zeroVector_5)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_zeroVector_5() const { return ___zeroVector_5; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_zeroVector_5() { return &___zeroVector_5; }
	inline void set_zeroVector_5(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___zeroVector_5 = value;
	}

	inline static int32_t get_offset_of_oneVector_6() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___oneVector_6)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_oneVector_6() const { return ___oneVector_6; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_oneVector_6() { return &___oneVector_6; }
	inline void set_oneVector_6(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___oneVector_6 = value;
	}

	inline static int32_t get_offset_of_upVector_7() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___upVector_7)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_upVector_7() const { return ___upVector_7; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_upVector_7() { return &___upVector_7; }
	inline void set_upVector_7(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___upVector_7 = value;
	}

	inline static int32_t get_offset_of_downVector_8() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___downVector_8)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_downVector_8() const { return ___downVector_8; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_downVector_8() { return &___downVector_8; }
	inline void set_downVector_8(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___downVector_8 = value;
	}

	inline static int32_t get_offset_of_leftVector_9() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___leftVector_9)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_leftVector_9() const { return ___leftVector_9; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_leftVector_9() { return &___leftVector_9; }
	inline void set_leftVector_9(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___leftVector_9 = value;
	}

	inline static int32_t get_offset_of_rightVector_10() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___rightVector_10)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_rightVector_10() const { return ___rightVector_10; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_rightVector_10() { return &___rightVector_10; }
	inline void set_rightVector_10(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___rightVector_10 = value;
	}

	inline static int32_t get_offset_of_forwardVector_11() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___forwardVector_11)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_forwardVector_11() const { return ___forwardVector_11; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_forwardVector_11() { return &___forwardVector_11; }
	inline void set_forwardVector_11(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___forwardVector_11 = value;
	}

	inline static int32_t get_offset_of_backVector_12() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___backVector_12)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_backVector_12() const { return ___backVector_12; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_backVector_12() { return &___backVector_12; }
	inline void set_backVector_12(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___backVector_12 = value;
	}

	inline static int32_t get_offset_of_positiveInfinityVector_13() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___positiveInfinityVector_13)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_positiveInfinityVector_13() const { return ___positiveInfinityVector_13; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_positiveInfinityVector_13() { return &___positiveInfinityVector_13; }
	inline void set_positiveInfinityVector_13(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___positiveInfinityVector_13 = value;
	}

	inline static int32_t get_offset_of_negativeInfinityVector_14() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___negativeInfinityVector_14)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_negativeInfinityVector_14() const { return ___negativeInfinityVector_14; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_negativeInfinityVector_14() { return &___negativeInfinityVector_14; }
	inline void set_negativeInfinityVector_14(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___negativeInfinityVector_14 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // VECTOR3_TDCF05E21F632FE2BA260C06E0D10CA81513E6720_H
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
#ifndef CONNECTSTATE_T4566897AFB28CE2847C766507EBB0797E40D8A9C_H
#define CONNECTSTATE_T4566897AFB28CE2847C766507EBB0797E40D8A9C_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkClient_ConnectState
struct  ConnectState_t4566897AFB28CE2847C766507EBB0797E40D8A9C 
{
public:
	// System.Int32 UnityEngine.Networking.NetworkClient_ConnectState::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(ConnectState_t4566897AFB28CE2847C766507EBB0797E40D8A9C, ___value___2)); }
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
#endif // CONNECTSTATE_T4566897AFB28CE2847C766507EBB0797E40D8A9C_H
#ifndef NETWORKERROR_T2F4C5EEB3EF2313DB6E035334EC2D73885BDEDEC_H
#define NETWORKERROR_T2F4C5EEB3EF2313DB6E035334EC2D73885BDEDEC_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkError
struct  NetworkError_t2F4C5EEB3EF2313DB6E035334EC2D73885BDEDEC 
{
public:
	// System.Int32 UnityEngine.Networking.NetworkError::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(NetworkError_t2F4C5EEB3EF2313DB6E035334EC2D73885BDEDEC, ___value___2)); }
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
#endif // NETWORKERROR_T2F4C5EEB3EF2313DB6E035334EC2D73885BDEDEC_H
#ifndef NETWORKWRITER_TD88D576C5A1634D9755F462ADB7484AA5BEAC231_H
#define NETWORKWRITER_TD88D576C5A1634D9755F462ADB7484AA5BEAC231_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkWriter
struct  NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231  : public RuntimeObject
{
public:
	// UnityEngine.Networking.NetBuffer UnityEngine.Networking.NetworkWriter::m_Buffer
	NetBuffer_t366B1D5A52CE9F15DC3DE61505E90EFCFE999BC2 * ___m_Buffer_1;

public:
	inline static int32_t get_offset_of_m_Buffer_1() { return static_cast<int32_t>(offsetof(NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231, ___m_Buffer_1)); }
	inline NetBuffer_t366B1D5A52CE9F15DC3DE61505E90EFCFE999BC2 * get_m_Buffer_1() const { return ___m_Buffer_1; }
	inline NetBuffer_t366B1D5A52CE9F15DC3DE61505E90EFCFE999BC2 ** get_address_of_m_Buffer_1() { return &___m_Buffer_1; }
	inline void set_m_Buffer_1(NetBuffer_t366B1D5A52CE9F15DC3DE61505E90EFCFE999BC2 * value)
	{
		___m_Buffer_1 = value;
		Il2CppCodeGenWriteBarrier((&___m_Buffer_1), value);
	}
};

struct NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231_StaticFields
{
public:
	// System.Text.Encoding UnityEngine.Networking.NetworkWriter::s_Encoding
	Encoding_t7837A3C0F55EAE0E3959A53C6D6E88B113ED78A4 * ___s_Encoding_2;
	// System.Byte[] UnityEngine.Networking.NetworkWriter::s_StringWriteBuffer
	ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___s_StringWriteBuffer_3;
	// UnityEngine.Networking.UIntFloat UnityEngine.Networking.NetworkWriter::s_FloatConverter
	UIntFloat_t6DD551096A5610B603FFAA3B4EFD2FC65CA56E7A  ___s_FloatConverter_4;

public:
	inline static int32_t get_offset_of_s_Encoding_2() { return static_cast<int32_t>(offsetof(NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231_StaticFields, ___s_Encoding_2)); }
	inline Encoding_t7837A3C0F55EAE0E3959A53C6D6E88B113ED78A4 * get_s_Encoding_2() const { return ___s_Encoding_2; }
	inline Encoding_t7837A3C0F55EAE0E3959A53C6D6E88B113ED78A4 ** get_address_of_s_Encoding_2() { return &___s_Encoding_2; }
	inline void set_s_Encoding_2(Encoding_t7837A3C0F55EAE0E3959A53C6D6E88B113ED78A4 * value)
	{
		___s_Encoding_2 = value;
		Il2CppCodeGenWriteBarrier((&___s_Encoding_2), value);
	}

	inline static int32_t get_offset_of_s_StringWriteBuffer_3() { return static_cast<int32_t>(offsetof(NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231_StaticFields, ___s_StringWriteBuffer_3)); }
	inline ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* get_s_StringWriteBuffer_3() const { return ___s_StringWriteBuffer_3; }
	inline ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821** get_address_of_s_StringWriteBuffer_3() { return &___s_StringWriteBuffer_3; }
	inline void set_s_StringWriteBuffer_3(ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* value)
	{
		___s_StringWriteBuffer_3 = value;
		Il2CppCodeGenWriteBarrier((&___s_StringWriteBuffer_3), value);
	}

	inline static int32_t get_offset_of_s_FloatConverter_4() { return static_cast<int32_t>(offsetof(NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231_StaticFields, ___s_FloatConverter_4)); }
	inline UIntFloat_t6DD551096A5610B603FFAA3B4EFD2FC65CA56E7A  get_s_FloatConverter_4() const { return ___s_FloatConverter_4; }
	inline UIntFloat_t6DD551096A5610B603FFAA3B4EFD2FC65CA56E7A * get_address_of_s_FloatConverter_4() { return &___s_FloatConverter_4; }
	inline void set_s_FloatConverter_4(UIntFloat_t6DD551096A5610B603FFAA3B4EFD2FC65CA56E7A  value)
	{
		___s_FloatConverter_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // NETWORKWRITER_TD88D576C5A1634D9755F462ADB7484AA5BEAC231_H
#ifndef PLAYERSPAWNMETHOD_TC2E4BADB68C936359547A233C7FC3A3724E62B47_H
#define PLAYERSPAWNMETHOD_TC2E4BADB68C936359547A233C7FC3A3724E62B47_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.PlayerSpawnMethod
struct  PlayerSpawnMethod_tC2E4BADB68C936359547A233C7FC3A3724E62B47 
{
public:
	// System.Int32 UnityEngine.Networking.PlayerSpawnMethod::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(PlayerSpawnMethod_tC2E4BADB68C936359547A233C7FC3A3724E62B47, ___value___2)); }
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
#endif // PLAYERSPAWNMETHOD_TC2E4BADB68C936359547A233C7FC3A3724E62B47_H
#ifndef UINTDECIMAL_T8A44436C7074D72195F4825B06BBF5A6880FF399_H
#define UINTDECIMAL_T8A44436C7074D72195F4825B06BBF5A6880FF399_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.UIntDecimal
struct  UIntDecimal_t8A44436C7074D72195F4825B06BBF5A6880FF399 
{
public:
	union
	{
		#pragma pack(push, tp, 1)
		struct
		{
			// System.UInt64 UnityEngine.Networking.UIntDecimal::longValue1
			uint64_t ___longValue1_0;
		};
		#pragma pack(pop, tp)
		struct
		{
			uint64_t ___longValue1_0_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___longValue2_1_OffsetPadding[8];
			// System.UInt64 UnityEngine.Networking.UIntDecimal::longValue2
			uint64_t ___longValue2_1;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___longValue2_1_OffsetPadding_forAlignmentOnly[8];
			uint64_t ___longValue2_1_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			// System.Decimal UnityEngine.Networking.UIntDecimal::decimalValue
			Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  ___decimalValue_2;
		};
		#pragma pack(pop, tp)
		struct
		{
			Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  ___decimalValue_2_forAlignmentOnly;
		};
	};

public:
	inline static int32_t get_offset_of_longValue1_0() { return static_cast<int32_t>(offsetof(UIntDecimal_t8A44436C7074D72195F4825B06BBF5A6880FF399, ___longValue1_0)); }
	inline uint64_t get_longValue1_0() const { return ___longValue1_0; }
	inline uint64_t* get_address_of_longValue1_0() { return &___longValue1_0; }
	inline void set_longValue1_0(uint64_t value)
	{
		___longValue1_0 = value;
	}

	inline static int32_t get_offset_of_longValue2_1() { return static_cast<int32_t>(offsetof(UIntDecimal_t8A44436C7074D72195F4825B06BBF5A6880FF399, ___longValue2_1)); }
	inline uint64_t get_longValue2_1() const { return ___longValue2_1; }
	inline uint64_t* get_address_of_longValue2_1() { return &___longValue2_1; }
	inline void set_longValue2_1(uint64_t value)
	{
		___longValue2_1 = value;
	}

	inline static int32_t get_offset_of_decimalValue_2() { return static_cast<int32_t>(offsetof(UIntDecimal_t8A44436C7074D72195F4825B06BBF5A6880FF399, ___decimalValue_2)); }
	inline Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  get_decimalValue_2() const { return ___decimalValue_2; }
	inline Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8 * get_address_of_decimalValue_2() { return &___decimalValue_2; }
	inline void set_decimalValue_2(Decimal_t44EE9DA309A1BF848308DE4DDFC070CAE6D95EE8  value)
	{
		___decimalValue_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UINTDECIMAL_T8A44436C7074D72195F4825B06BBF5A6880FF399_H
#ifndef VERSION_T7C5C3C079FEE772311BFB68B2AFB47408B121353_H
#define VERSION_T7C5C3C079FEE772311BFB68B2AFB47408B121353_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.Version
struct  Version_t7C5C3C079FEE772311BFB68B2AFB47408B121353 
{
public:
	// System.Int32 UnityEngine.Networking.Version::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(Version_t7C5C3C079FEE772311BFB68B2AFB47408B121353, ___value___2)); }
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
#endif // VERSION_T7C5C3C079FEE772311BFB68B2AFB47408B121353_H
#ifndef OBJECT_TAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_H
#define OBJECT_TAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Object
struct  Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0  : public RuntimeObject
{
public:
	// System.IntPtr UnityEngine.Object::m_CachedPtr
	intptr_t ___m_CachedPtr_0;

public:
	inline static int32_t get_offset_of_m_CachedPtr_0() { return static_cast<int32_t>(offsetof(Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0, ___m_CachedPtr_0)); }
	inline intptr_t get_m_CachedPtr_0() const { return ___m_CachedPtr_0; }
	inline intptr_t* get_address_of_m_CachedPtr_0() { return &___m_CachedPtr_0; }
	inline void set_m_CachedPtr_0(intptr_t value)
	{
		___m_CachedPtr_0 = value;
	}
};

struct Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_StaticFields
{
public:
	// System.Int32 UnityEngine.Object::OffsetOfInstanceIDInCPlusPlusObject
	int32_t ___OffsetOfInstanceIDInCPlusPlusObject_1;

public:
	inline static int32_t get_offset_of_OffsetOfInstanceIDInCPlusPlusObject_1() { return static_cast<int32_t>(offsetof(Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_StaticFields, ___OffsetOfInstanceIDInCPlusPlusObject_1)); }
	inline int32_t get_OffsetOfInstanceIDInCPlusPlusObject_1() const { return ___OffsetOfInstanceIDInCPlusPlusObject_1; }
	inline int32_t* get_address_of_OffsetOfInstanceIDInCPlusPlusObject_1() { return &___OffsetOfInstanceIDInCPlusPlusObject_1; }
	inline void set_OffsetOfInstanceIDInCPlusPlusObject_1(int32_t value)
	{
		___OffsetOfInstanceIDInCPlusPlusObject_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.Object
struct Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_marshaled_pinvoke
{
	intptr_t ___m_CachedPtr_0;
};
// Native definition for COM marshalling of UnityEngine.Object
struct Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_marshaled_com
{
	intptr_t ___m_CachedPtr_0;
};
#endif // OBJECT_TAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_H
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
#ifndef COMPONENT_T05064EF382ABCAF4B8C94F8A350EA85184C26621_H
#define COMPONENT_T05064EF382ABCAF4B8C94F8A350EA85184C26621_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Component
struct  Component_t05064EF382ABCAF4B8C94F8A350EA85184C26621  : public Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // COMPONENT_T05064EF382ABCAF4B8C94F8A350EA85184C26621_H
#ifndef GAMEOBJECT_TBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F_H
#define GAMEOBJECT_TBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.GameObject
struct  GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F  : public Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // GAMEOBJECT_TBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F_H
#ifndef NETWORKCLIENT_T145A53DC925106E6D60DEEAA7D616B0A39F07172_H
#define NETWORKCLIENT_T145A53DC925106E6D60DEEAA7D616B0A39F07172_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkClient
struct  NetworkClient_t145A53DC925106E6D60DEEAA7D616B0A39F07172  : public RuntimeObject
{
public:
	// System.Type UnityEngine.Networking.NetworkClient::m_NetworkConnectionClass
	Type_t * ___m_NetworkConnectionClass_0;
	// UnityEngine.Networking.HostTopology UnityEngine.Networking.NetworkClient::m_HostTopology
	HostTopology_tD01D253330A0DAA736EDFC67EE9585C363FA9B0E * ___m_HostTopology_4;
	// System.Int32 UnityEngine.Networking.NetworkClient::m_HostPort
	int32_t ___m_HostPort_5;
	// System.Boolean UnityEngine.Networking.NetworkClient::m_UseSimulator
	bool ___m_UseSimulator_6;
	// System.Int32 UnityEngine.Networking.NetworkClient::m_SimulatedLatency
	int32_t ___m_SimulatedLatency_7;
	// System.Single UnityEngine.Networking.NetworkClient::m_PacketLoss
	float ___m_PacketLoss_8;
	// System.String UnityEngine.Networking.NetworkClient::m_ServerIp
	String_t* ___m_ServerIp_9;
	// System.Int32 UnityEngine.Networking.NetworkClient::m_ServerPort
	int32_t ___m_ServerPort_10;
	// System.Int32 UnityEngine.Networking.NetworkClient::m_ClientId
	int32_t ___m_ClientId_11;
	// System.Int32 UnityEngine.Networking.NetworkClient::m_ClientConnectionId
	int32_t ___m_ClientConnectionId_12;
	// System.Int32 UnityEngine.Networking.NetworkClient::m_StatResetTime
	int32_t ___m_StatResetTime_13;
	// System.Net.EndPoint UnityEngine.Networking.NetworkClient::m_RemoteEndPoint
	EndPoint_tD87FCEF2780A951E8CE8D808C345FBF2C088D980 * ___m_RemoteEndPoint_14;
	// UnityEngine.Networking.NetworkMessageHandlers UnityEngine.Networking.NetworkClient::m_MessageHandlers
	NetworkMessageHandlers_tD09C2A81D21EEF2F513794293A5CD6639C70EE2C * ___m_MessageHandlers_16;
	// UnityEngine.Networking.NetworkConnection UnityEngine.Networking.NetworkClient::m_Connection
	NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632 * ___m_Connection_17;
	// System.Byte[] UnityEngine.Networking.NetworkClient::m_MsgBuffer
	ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___m_MsgBuffer_18;
	// UnityEngine.Networking.NetworkReader UnityEngine.Networking.NetworkClient::m_MsgReader
	NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * ___m_MsgReader_19;
	// UnityEngine.Networking.NetworkClient_ConnectState UnityEngine.Networking.NetworkClient::m_AsyncConnect
	int32_t ___m_AsyncConnect_20;
	// System.String UnityEngine.Networking.NetworkClient::m_RequestedServerHost
	String_t* ___m_RequestedServerHost_21;

public:
	inline static int32_t get_offset_of_m_NetworkConnectionClass_0() { return static_cast<int32_t>(offsetof(NetworkClient_t145A53DC925106E6D60DEEAA7D616B0A39F07172, ___m_NetworkConnectionClass_0)); }
	inline Type_t * get_m_NetworkConnectionClass_0() const { return ___m_NetworkConnectionClass_0; }
	inline Type_t ** get_address_of_m_NetworkConnectionClass_0() { return &___m_NetworkConnectionClass_0; }
	inline void set_m_NetworkConnectionClass_0(Type_t * value)
	{
		___m_NetworkConnectionClass_0 = value;
		Il2CppCodeGenWriteBarrier((&___m_NetworkConnectionClass_0), value);
	}

	inline static int32_t get_offset_of_m_HostTopology_4() { return static_cast<int32_t>(offsetof(NetworkClient_t145A53DC925106E6D60DEEAA7D616B0A39F07172, ___m_HostTopology_4)); }
	inline HostTopology_tD01D253330A0DAA736EDFC67EE9585C363FA9B0E * get_m_HostTopology_4() const { return ___m_HostTopology_4; }
	inline HostTopology_tD01D253330A0DAA736EDFC67EE9585C363FA9B0E ** get_address_of_m_HostTopology_4() { return &___m_HostTopology_4; }
	inline void set_m_HostTopology_4(HostTopology_tD01D253330A0DAA736EDFC67EE9585C363FA9B0E * value)
	{
		___m_HostTopology_4 = value;
		Il2CppCodeGenWriteBarrier((&___m_HostTopology_4), value);
	}

	inline static int32_t get_offset_of_m_HostPort_5() { return static_cast<int32_t>(offsetof(NetworkClient_t145A53DC925106E6D60DEEAA7D616B0A39F07172, ___m_HostPort_5)); }
	inline int32_t get_m_HostPort_5() const { return ___m_HostPort_5; }
	inline int32_t* get_address_of_m_HostPort_5() { return &___m_HostPort_5; }
	inline void set_m_HostPort_5(int32_t value)
	{
		___m_HostPort_5 = value;
	}

	inline static int32_t get_offset_of_m_UseSimulator_6() { return static_cast<int32_t>(offsetof(NetworkClient_t145A53DC925106E6D60DEEAA7D616B0A39F07172, ___m_UseSimulator_6)); }
	inline bool get_m_UseSimulator_6() const { return ___m_UseSimulator_6; }
	inline bool* get_address_of_m_UseSimulator_6() { return &___m_UseSimulator_6; }
	inline void set_m_UseSimulator_6(bool value)
	{
		___m_UseSimulator_6 = value;
	}

	inline static int32_t get_offset_of_m_SimulatedLatency_7() { return static_cast<int32_t>(offsetof(NetworkClient_t145A53DC925106E6D60DEEAA7D616B0A39F07172, ___m_SimulatedLatency_7)); }
	inline int32_t get_m_SimulatedLatency_7() const { return ___m_SimulatedLatency_7; }
	inline int32_t* get_address_of_m_SimulatedLatency_7() { return &___m_SimulatedLatency_7; }
	inline void set_m_SimulatedLatency_7(int32_t value)
	{
		___m_SimulatedLatency_7 = value;
	}

	inline static int32_t get_offset_of_m_PacketLoss_8() { return static_cast<int32_t>(offsetof(NetworkClient_t145A53DC925106E6D60DEEAA7D616B0A39F07172, ___m_PacketLoss_8)); }
	inline float get_m_PacketLoss_8() const { return ___m_PacketLoss_8; }
	inline float* get_address_of_m_PacketLoss_8() { return &___m_PacketLoss_8; }
	inline void set_m_PacketLoss_8(float value)
	{
		___m_PacketLoss_8 = value;
	}

	inline static int32_t get_offset_of_m_ServerIp_9() { return static_cast<int32_t>(offsetof(NetworkClient_t145A53DC925106E6D60DEEAA7D616B0A39F07172, ___m_ServerIp_9)); }
	inline String_t* get_m_ServerIp_9() const { return ___m_ServerIp_9; }
	inline String_t** get_address_of_m_ServerIp_9() { return &___m_ServerIp_9; }
	inline void set_m_ServerIp_9(String_t* value)
	{
		___m_ServerIp_9 = value;
		Il2CppCodeGenWriteBarrier((&___m_ServerIp_9), value);
	}

	inline static int32_t get_offset_of_m_ServerPort_10() { return static_cast<int32_t>(offsetof(NetworkClient_t145A53DC925106E6D60DEEAA7D616B0A39F07172, ___m_ServerPort_10)); }
	inline int32_t get_m_ServerPort_10() const { return ___m_ServerPort_10; }
	inline int32_t* get_address_of_m_ServerPort_10() { return &___m_ServerPort_10; }
	inline void set_m_ServerPort_10(int32_t value)
	{
		___m_ServerPort_10 = value;
	}

	inline static int32_t get_offset_of_m_ClientId_11() { return static_cast<int32_t>(offsetof(NetworkClient_t145A53DC925106E6D60DEEAA7D616B0A39F07172, ___m_ClientId_11)); }
	inline int32_t get_m_ClientId_11() const { return ___m_ClientId_11; }
	inline int32_t* get_address_of_m_ClientId_11() { return &___m_ClientId_11; }
	inline void set_m_ClientId_11(int32_t value)
	{
		___m_ClientId_11 = value;
	}

	inline static int32_t get_offset_of_m_ClientConnectionId_12() { return static_cast<int32_t>(offsetof(NetworkClient_t145A53DC925106E6D60DEEAA7D616B0A39F07172, ___m_ClientConnectionId_12)); }
	inline int32_t get_m_ClientConnectionId_12() const { return ___m_ClientConnectionId_12; }
	inline int32_t* get_address_of_m_ClientConnectionId_12() { return &___m_ClientConnectionId_12; }
	inline void set_m_ClientConnectionId_12(int32_t value)
	{
		___m_ClientConnectionId_12 = value;
	}

	inline static int32_t get_offset_of_m_StatResetTime_13() { return static_cast<int32_t>(offsetof(NetworkClient_t145A53DC925106E6D60DEEAA7D616B0A39F07172, ___m_StatResetTime_13)); }
	inline int32_t get_m_StatResetTime_13() const { return ___m_StatResetTime_13; }
	inline int32_t* get_address_of_m_StatResetTime_13() { return &___m_StatResetTime_13; }
	inline void set_m_StatResetTime_13(int32_t value)
	{
		___m_StatResetTime_13 = value;
	}

	inline static int32_t get_offset_of_m_RemoteEndPoint_14() { return static_cast<int32_t>(offsetof(NetworkClient_t145A53DC925106E6D60DEEAA7D616B0A39F07172, ___m_RemoteEndPoint_14)); }
	inline EndPoint_tD87FCEF2780A951E8CE8D808C345FBF2C088D980 * get_m_RemoteEndPoint_14() const { return ___m_RemoteEndPoint_14; }
	inline EndPoint_tD87FCEF2780A951E8CE8D808C345FBF2C088D980 ** get_address_of_m_RemoteEndPoint_14() { return &___m_RemoteEndPoint_14; }
	inline void set_m_RemoteEndPoint_14(EndPoint_tD87FCEF2780A951E8CE8D808C345FBF2C088D980 * value)
	{
		___m_RemoteEndPoint_14 = value;
		Il2CppCodeGenWriteBarrier((&___m_RemoteEndPoint_14), value);
	}

	inline static int32_t get_offset_of_m_MessageHandlers_16() { return static_cast<int32_t>(offsetof(NetworkClient_t145A53DC925106E6D60DEEAA7D616B0A39F07172, ___m_MessageHandlers_16)); }
	inline NetworkMessageHandlers_tD09C2A81D21EEF2F513794293A5CD6639C70EE2C * get_m_MessageHandlers_16() const { return ___m_MessageHandlers_16; }
	inline NetworkMessageHandlers_tD09C2A81D21EEF2F513794293A5CD6639C70EE2C ** get_address_of_m_MessageHandlers_16() { return &___m_MessageHandlers_16; }
	inline void set_m_MessageHandlers_16(NetworkMessageHandlers_tD09C2A81D21EEF2F513794293A5CD6639C70EE2C * value)
	{
		___m_MessageHandlers_16 = value;
		Il2CppCodeGenWriteBarrier((&___m_MessageHandlers_16), value);
	}

	inline static int32_t get_offset_of_m_Connection_17() { return static_cast<int32_t>(offsetof(NetworkClient_t145A53DC925106E6D60DEEAA7D616B0A39F07172, ___m_Connection_17)); }
	inline NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632 * get_m_Connection_17() const { return ___m_Connection_17; }
	inline NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632 ** get_address_of_m_Connection_17() { return &___m_Connection_17; }
	inline void set_m_Connection_17(NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632 * value)
	{
		___m_Connection_17 = value;
		Il2CppCodeGenWriteBarrier((&___m_Connection_17), value);
	}

	inline static int32_t get_offset_of_m_MsgBuffer_18() { return static_cast<int32_t>(offsetof(NetworkClient_t145A53DC925106E6D60DEEAA7D616B0A39F07172, ___m_MsgBuffer_18)); }
	inline ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* get_m_MsgBuffer_18() const { return ___m_MsgBuffer_18; }
	inline ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821** get_address_of_m_MsgBuffer_18() { return &___m_MsgBuffer_18; }
	inline void set_m_MsgBuffer_18(ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* value)
	{
		___m_MsgBuffer_18 = value;
		Il2CppCodeGenWriteBarrier((&___m_MsgBuffer_18), value);
	}

	inline static int32_t get_offset_of_m_MsgReader_19() { return static_cast<int32_t>(offsetof(NetworkClient_t145A53DC925106E6D60DEEAA7D616B0A39F07172, ___m_MsgReader_19)); }
	inline NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * get_m_MsgReader_19() const { return ___m_MsgReader_19; }
	inline NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 ** get_address_of_m_MsgReader_19() { return &___m_MsgReader_19; }
	inline void set_m_MsgReader_19(NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * value)
	{
		___m_MsgReader_19 = value;
		Il2CppCodeGenWriteBarrier((&___m_MsgReader_19), value);
	}

	inline static int32_t get_offset_of_m_AsyncConnect_20() { return static_cast<int32_t>(offsetof(NetworkClient_t145A53DC925106E6D60DEEAA7D616B0A39F07172, ___m_AsyncConnect_20)); }
	inline int32_t get_m_AsyncConnect_20() const { return ___m_AsyncConnect_20; }
	inline int32_t* get_address_of_m_AsyncConnect_20() { return &___m_AsyncConnect_20; }
	inline void set_m_AsyncConnect_20(int32_t value)
	{
		___m_AsyncConnect_20 = value;
	}

	inline static int32_t get_offset_of_m_RequestedServerHost_21() { return static_cast<int32_t>(offsetof(NetworkClient_t145A53DC925106E6D60DEEAA7D616B0A39F07172, ___m_RequestedServerHost_21)); }
	inline String_t* get_m_RequestedServerHost_21() const { return ___m_RequestedServerHost_21; }
	inline String_t** get_address_of_m_RequestedServerHost_21() { return &___m_RequestedServerHost_21; }
	inline void set_m_RequestedServerHost_21(String_t* value)
	{
		___m_RequestedServerHost_21 = value;
		Il2CppCodeGenWriteBarrier((&___m_RequestedServerHost_21), value);
	}
};

struct NetworkClient_t145A53DC925106E6D60DEEAA7D616B0A39F07172_StaticFields
{
public:
	// System.Collections.Generic.List`1<UnityEngine.Networking.NetworkClient> UnityEngine.Networking.NetworkClient::s_Clients
	List_1_t1FC2269ECC4BFEB8703A654A2B0609F3F00FB235 * ___s_Clients_2;
	// System.Boolean UnityEngine.Networking.NetworkClient::s_IsActive
	bool ___s_IsActive_3;
	// UnityEngine.Networking.NetworkSystem.CRCMessage UnityEngine.Networking.NetworkClient::s_CRCMessage
	CRCMessage_tA86EAAF7BAA45FD9B4F26A6C8FD1392C60C35743 * ___s_CRCMessage_15;
	// System.AsyncCallback UnityEngine.Networking.NetworkClient::<>f__mgU24cache0
	AsyncCallback_t3F3DA3BEDAEE81DD1D24125DF8EB30E85EE14DA4 * ___U3CU3Ef__mgU24cache0_22;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.NetworkClient::<>f__mgU24cache1
	NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * ___U3CU3Ef__mgU24cache1_23;

public:
	inline static int32_t get_offset_of_s_Clients_2() { return static_cast<int32_t>(offsetof(NetworkClient_t145A53DC925106E6D60DEEAA7D616B0A39F07172_StaticFields, ___s_Clients_2)); }
	inline List_1_t1FC2269ECC4BFEB8703A654A2B0609F3F00FB235 * get_s_Clients_2() const { return ___s_Clients_2; }
	inline List_1_t1FC2269ECC4BFEB8703A654A2B0609F3F00FB235 ** get_address_of_s_Clients_2() { return &___s_Clients_2; }
	inline void set_s_Clients_2(List_1_t1FC2269ECC4BFEB8703A654A2B0609F3F00FB235 * value)
	{
		___s_Clients_2 = value;
		Il2CppCodeGenWriteBarrier((&___s_Clients_2), value);
	}

	inline static int32_t get_offset_of_s_IsActive_3() { return static_cast<int32_t>(offsetof(NetworkClient_t145A53DC925106E6D60DEEAA7D616B0A39F07172_StaticFields, ___s_IsActive_3)); }
	inline bool get_s_IsActive_3() const { return ___s_IsActive_3; }
	inline bool* get_address_of_s_IsActive_3() { return &___s_IsActive_3; }
	inline void set_s_IsActive_3(bool value)
	{
		___s_IsActive_3 = value;
	}

	inline static int32_t get_offset_of_s_CRCMessage_15() { return static_cast<int32_t>(offsetof(NetworkClient_t145A53DC925106E6D60DEEAA7D616B0A39F07172_StaticFields, ___s_CRCMessage_15)); }
	inline CRCMessage_tA86EAAF7BAA45FD9B4F26A6C8FD1392C60C35743 * get_s_CRCMessage_15() const { return ___s_CRCMessage_15; }
	inline CRCMessage_tA86EAAF7BAA45FD9B4F26A6C8FD1392C60C35743 ** get_address_of_s_CRCMessage_15() { return &___s_CRCMessage_15; }
	inline void set_s_CRCMessage_15(CRCMessage_tA86EAAF7BAA45FD9B4F26A6C8FD1392C60C35743 * value)
	{
		___s_CRCMessage_15 = value;
		Il2CppCodeGenWriteBarrier((&___s_CRCMessage_15), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache0_22() { return static_cast<int32_t>(offsetof(NetworkClient_t145A53DC925106E6D60DEEAA7D616B0A39F07172_StaticFields, ___U3CU3Ef__mgU24cache0_22)); }
	inline AsyncCallback_t3F3DA3BEDAEE81DD1D24125DF8EB30E85EE14DA4 * get_U3CU3Ef__mgU24cache0_22() const { return ___U3CU3Ef__mgU24cache0_22; }
	inline AsyncCallback_t3F3DA3BEDAEE81DD1D24125DF8EB30E85EE14DA4 ** get_address_of_U3CU3Ef__mgU24cache0_22() { return &___U3CU3Ef__mgU24cache0_22; }
	inline void set_U3CU3Ef__mgU24cache0_22(AsyncCallback_t3F3DA3BEDAEE81DD1D24125DF8EB30E85EE14DA4 * value)
	{
		___U3CU3Ef__mgU24cache0_22 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__mgU24cache0_22), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache1_23() { return static_cast<int32_t>(offsetof(NetworkClient_t145A53DC925106E6D60DEEAA7D616B0A39F07172_StaticFields, ___U3CU3Ef__mgU24cache1_23)); }
	inline NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * get_U3CU3Ef__mgU24cache1_23() const { return ___U3CU3Ef__mgU24cache1_23; }
	inline NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 ** get_address_of_U3CU3Ef__mgU24cache1_23() { return &___U3CU3Ef__mgU24cache1_23; }
	inline void set_U3CU3Ef__mgU24cache1_23(NetworkMessageDelegate_tAAC9FF43307E8DDA3446230A95AFAD1DBE9172C7 * value)
	{
		___U3CU3Ef__mgU24cache1_23 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__mgU24cache1_23), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // NETWORKCLIENT_T145A53DC925106E6D60DEEAA7D616B0A39F07172_H
#ifndef NETWORKCONNECTION_TC00D92CEDB25DBEE926BBC4B45BCE182A5675632_H
#define NETWORKCONNECTION_TC00D92CEDB25DBEE926BBC4B45BCE182A5675632_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkConnection
struct  NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632  : public RuntimeObject
{
public:
	// UnityEngine.Networking.ChannelBuffer[] UnityEngine.Networking.NetworkConnection::m_Channels
	ChannelBufferU5BU5D_t1663CEF38281E45A3D44618712BBF705C113DD1D* ___m_Channels_0;
	// System.Collections.Generic.List`1<UnityEngine.Networking.PlayerController> UnityEngine.Networking.NetworkConnection::m_PlayerControllers
	List_1_tD98B647A610CD658E1C3314FBD41B5B03F500623 * ___m_PlayerControllers_1;
	// UnityEngine.Networking.NetworkMessage UnityEngine.Networking.NetworkConnection::m_NetMsg
	NetworkMessage_t8CF95D238C0966D1811596D78D3C4A57A431A8CF * ___m_NetMsg_2;
	// System.Collections.Generic.HashSet`1<UnityEngine.Networking.NetworkIdentity> UnityEngine.Networking.NetworkConnection::m_VisList
	HashSet_1_t9E1A096DD1BBF3CF3EC3960E4B06BE62EF44899F * ___m_VisList_3;
	// UnityEngine.Networking.NetworkWriter UnityEngine.Networking.NetworkConnection::m_Writer
	NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * ___m_Writer_4;
	// System.Collections.Generic.Dictionary`2<System.Int16,UnityEngine.Networking.NetworkMessageDelegate> UnityEngine.Networking.NetworkConnection::m_MessageHandlersDict
	Dictionary_2_t3EE17E04A60D3EFD00303E7BA32A76AD9EB4C915 * ___m_MessageHandlersDict_5;
	// UnityEngine.Networking.NetworkMessageHandlers UnityEngine.Networking.NetworkConnection::m_MessageHandlers
	NetworkMessageHandlers_tD09C2A81D21EEF2F513794293A5CD6639C70EE2C * ___m_MessageHandlers_6;
	// System.Collections.Generic.HashSet`1<UnityEngine.Networking.NetworkInstanceId> UnityEngine.Networking.NetworkConnection::m_ClientOwnedObjects
	HashSet_1_t1BC96DC84B747356758BC27E32E41C0DE178DE9F * ___m_ClientOwnedObjects_7;
	// UnityEngine.Networking.NetworkMessage UnityEngine.Networking.NetworkConnection::m_MessageInfo
	NetworkMessage_t8CF95D238C0966D1811596D78D3C4A57A431A8CF * ___m_MessageInfo_8;
	// UnityEngine.Networking.NetworkError UnityEngine.Networking.NetworkConnection::error
	int32_t ___error_10;
	// System.Int32 UnityEngine.Networking.NetworkConnection::hostId
	int32_t ___hostId_11;
	// System.Int32 UnityEngine.Networking.NetworkConnection::connectionId
	int32_t ___connectionId_12;
	// System.Boolean UnityEngine.Networking.NetworkConnection::isReady
	bool ___isReady_13;
	// System.String UnityEngine.Networking.NetworkConnection::address
	String_t* ___address_14;
	// System.Single UnityEngine.Networking.NetworkConnection::lastMessageTime
	float ___lastMessageTime_15;
	// System.Boolean UnityEngine.Networking.NetworkConnection::logNetworkMessages
	bool ___logNetworkMessages_16;
	// System.Collections.Generic.Dictionary`2<System.Int16,UnityEngine.Networking.NetworkConnection_PacketStat> UnityEngine.Networking.NetworkConnection::m_PacketStats
	Dictionary_2_t54E37BF67529C9F5102EFE87DA44E03601FD81B3 * ___m_PacketStats_17;
	// System.Boolean UnityEngine.Networking.NetworkConnection::m_Disposed
	bool ___m_Disposed_18;

public:
	inline static int32_t get_offset_of_m_Channels_0() { return static_cast<int32_t>(offsetof(NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632, ___m_Channels_0)); }
	inline ChannelBufferU5BU5D_t1663CEF38281E45A3D44618712BBF705C113DD1D* get_m_Channels_0() const { return ___m_Channels_0; }
	inline ChannelBufferU5BU5D_t1663CEF38281E45A3D44618712BBF705C113DD1D** get_address_of_m_Channels_0() { return &___m_Channels_0; }
	inline void set_m_Channels_0(ChannelBufferU5BU5D_t1663CEF38281E45A3D44618712BBF705C113DD1D* value)
	{
		___m_Channels_0 = value;
		Il2CppCodeGenWriteBarrier((&___m_Channels_0), value);
	}

	inline static int32_t get_offset_of_m_PlayerControllers_1() { return static_cast<int32_t>(offsetof(NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632, ___m_PlayerControllers_1)); }
	inline List_1_tD98B647A610CD658E1C3314FBD41B5B03F500623 * get_m_PlayerControllers_1() const { return ___m_PlayerControllers_1; }
	inline List_1_tD98B647A610CD658E1C3314FBD41B5B03F500623 ** get_address_of_m_PlayerControllers_1() { return &___m_PlayerControllers_1; }
	inline void set_m_PlayerControllers_1(List_1_tD98B647A610CD658E1C3314FBD41B5B03F500623 * value)
	{
		___m_PlayerControllers_1 = value;
		Il2CppCodeGenWriteBarrier((&___m_PlayerControllers_1), value);
	}

	inline static int32_t get_offset_of_m_NetMsg_2() { return static_cast<int32_t>(offsetof(NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632, ___m_NetMsg_2)); }
	inline NetworkMessage_t8CF95D238C0966D1811596D78D3C4A57A431A8CF * get_m_NetMsg_2() const { return ___m_NetMsg_2; }
	inline NetworkMessage_t8CF95D238C0966D1811596D78D3C4A57A431A8CF ** get_address_of_m_NetMsg_2() { return &___m_NetMsg_2; }
	inline void set_m_NetMsg_2(NetworkMessage_t8CF95D238C0966D1811596D78D3C4A57A431A8CF * value)
	{
		___m_NetMsg_2 = value;
		Il2CppCodeGenWriteBarrier((&___m_NetMsg_2), value);
	}

	inline static int32_t get_offset_of_m_VisList_3() { return static_cast<int32_t>(offsetof(NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632, ___m_VisList_3)); }
	inline HashSet_1_t9E1A096DD1BBF3CF3EC3960E4B06BE62EF44899F * get_m_VisList_3() const { return ___m_VisList_3; }
	inline HashSet_1_t9E1A096DD1BBF3CF3EC3960E4B06BE62EF44899F ** get_address_of_m_VisList_3() { return &___m_VisList_3; }
	inline void set_m_VisList_3(HashSet_1_t9E1A096DD1BBF3CF3EC3960E4B06BE62EF44899F * value)
	{
		___m_VisList_3 = value;
		Il2CppCodeGenWriteBarrier((&___m_VisList_3), value);
	}

	inline static int32_t get_offset_of_m_Writer_4() { return static_cast<int32_t>(offsetof(NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632, ___m_Writer_4)); }
	inline NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * get_m_Writer_4() const { return ___m_Writer_4; }
	inline NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 ** get_address_of_m_Writer_4() { return &___m_Writer_4; }
	inline void set_m_Writer_4(NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * value)
	{
		___m_Writer_4 = value;
		Il2CppCodeGenWriteBarrier((&___m_Writer_4), value);
	}

	inline static int32_t get_offset_of_m_MessageHandlersDict_5() { return static_cast<int32_t>(offsetof(NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632, ___m_MessageHandlersDict_5)); }
	inline Dictionary_2_t3EE17E04A60D3EFD00303E7BA32A76AD9EB4C915 * get_m_MessageHandlersDict_5() const { return ___m_MessageHandlersDict_5; }
	inline Dictionary_2_t3EE17E04A60D3EFD00303E7BA32A76AD9EB4C915 ** get_address_of_m_MessageHandlersDict_5() { return &___m_MessageHandlersDict_5; }
	inline void set_m_MessageHandlersDict_5(Dictionary_2_t3EE17E04A60D3EFD00303E7BA32A76AD9EB4C915 * value)
	{
		___m_MessageHandlersDict_5 = value;
		Il2CppCodeGenWriteBarrier((&___m_MessageHandlersDict_5), value);
	}

	inline static int32_t get_offset_of_m_MessageHandlers_6() { return static_cast<int32_t>(offsetof(NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632, ___m_MessageHandlers_6)); }
	inline NetworkMessageHandlers_tD09C2A81D21EEF2F513794293A5CD6639C70EE2C * get_m_MessageHandlers_6() const { return ___m_MessageHandlers_6; }
	inline NetworkMessageHandlers_tD09C2A81D21EEF2F513794293A5CD6639C70EE2C ** get_address_of_m_MessageHandlers_6() { return &___m_MessageHandlers_6; }
	inline void set_m_MessageHandlers_6(NetworkMessageHandlers_tD09C2A81D21EEF2F513794293A5CD6639C70EE2C * value)
	{
		___m_MessageHandlers_6 = value;
		Il2CppCodeGenWriteBarrier((&___m_MessageHandlers_6), value);
	}

	inline static int32_t get_offset_of_m_ClientOwnedObjects_7() { return static_cast<int32_t>(offsetof(NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632, ___m_ClientOwnedObjects_7)); }
	inline HashSet_1_t1BC96DC84B747356758BC27E32E41C0DE178DE9F * get_m_ClientOwnedObjects_7() const { return ___m_ClientOwnedObjects_7; }
	inline HashSet_1_t1BC96DC84B747356758BC27E32E41C0DE178DE9F ** get_address_of_m_ClientOwnedObjects_7() { return &___m_ClientOwnedObjects_7; }
	inline void set_m_ClientOwnedObjects_7(HashSet_1_t1BC96DC84B747356758BC27E32E41C0DE178DE9F * value)
	{
		___m_ClientOwnedObjects_7 = value;
		Il2CppCodeGenWriteBarrier((&___m_ClientOwnedObjects_7), value);
	}

	inline static int32_t get_offset_of_m_MessageInfo_8() { return static_cast<int32_t>(offsetof(NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632, ___m_MessageInfo_8)); }
	inline NetworkMessage_t8CF95D238C0966D1811596D78D3C4A57A431A8CF * get_m_MessageInfo_8() const { return ___m_MessageInfo_8; }
	inline NetworkMessage_t8CF95D238C0966D1811596D78D3C4A57A431A8CF ** get_address_of_m_MessageInfo_8() { return &___m_MessageInfo_8; }
	inline void set_m_MessageInfo_8(NetworkMessage_t8CF95D238C0966D1811596D78D3C4A57A431A8CF * value)
	{
		___m_MessageInfo_8 = value;
		Il2CppCodeGenWriteBarrier((&___m_MessageInfo_8), value);
	}

	inline static int32_t get_offset_of_error_10() { return static_cast<int32_t>(offsetof(NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632, ___error_10)); }
	inline int32_t get_error_10() const { return ___error_10; }
	inline int32_t* get_address_of_error_10() { return &___error_10; }
	inline void set_error_10(int32_t value)
	{
		___error_10 = value;
	}

	inline static int32_t get_offset_of_hostId_11() { return static_cast<int32_t>(offsetof(NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632, ___hostId_11)); }
	inline int32_t get_hostId_11() const { return ___hostId_11; }
	inline int32_t* get_address_of_hostId_11() { return &___hostId_11; }
	inline void set_hostId_11(int32_t value)
	{
		___hostId_11 = value;
	}

	inline static int32_t get_offset_of_connectionId_12() { return static_cast<int32_t>(offsetof(NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632, ___connectionId_12)); }
	inline int32_t get_connectionId_12() const { return ___connectionId_12; }
	inline int32_t* get_address_of_connectionId_12() { return &___connectionId_12; }
	inline void set_connectionId_12(int32_t value)
	{
		___connectionId_12 = value;
	}

	inline static int32_t get_offset_of_isReady_13() { return static_cast<int32_t>(offsetof(NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632, ___isReady_13)); }
	inline bool get_isReady_13() const { return ___isReady_13; }
	inline bool* get_address_of_isReady_13() { return &___isReady_13; }
	inline void set_isReady_13(bool value)
	{
		___isReady_13 = value;
	}

	inline static int32_t get_offset_of_address_14() { return static_cast<int32_t>(offsetof(NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632, ___address_14)); }
	inline String_t* get_address_14() const { return ___address_14; }
	inline String_t** get_address_of_address_14() { return &___address_14; }
	inline void set_address_14(String_t* value)
	{
		___address_14 = value;
		Il2CppCodeGenWriteBarrier((&___address_14), value);
	}

	inline static int32_t get_offset_of_lastMessageTime_15() { return static_cast<int32_t>(offsetof(NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632, ___lastMessageTime_15)); }
	inline float get_lastMessageTime_15() const { return ___lastMessageTime_15; }
	inline float* get_address_of_lastMessageTime_15() { return &___lastMessageTime_15; }
	inline void set_lastMessageTime_15(float value)
	{
		___lastMessageTime_15 = value;
	}

	inline static int32_t get_offset_of_logNetworkMessages_16() { return static_cast<int32_t>(offsetof(NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632, ___logNetworkMessages_16)); }
	inline bool get_logNetworkMessages_16() const { return ___logNetworkMessages_16; }
	inline bool* get_address_of_logNetworkMessages_16() { return &___logNetworkMessages_16; }
	inline void set_logNetworkMessages_16(bool value)
	{
		___logNetworkMessages_16 = value;
	}

	inline static int32_t get_offset_of_m_PacketStats_17() { return static_cast<int32_t>(offsetof(NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632, ___m_PacketStats_17)); }
	inline Dictionary_2_t54E37BF67529C9F5102EFE87DA44E03601FD81B3 * get_m_PacketStats_17() const { return ___m_PacketStats_17; }
	inline Dictionary_2_t54E37BF67529C9F5102EFE87DA44E03601FD81B3 ** get_address_of_m_PacketStats_17() { return &___m_PacketStats_17; }
	inline void set_m_PacketStats_17(Dictionary_2_t54E37BF67529C9F5102EFE87DA44E03601FD81B3 * value)
	{
		___m_PacketStats_17 = value;
		Il2CppCodeGenWriteBarrier((&___m_PacketStats_17), value);
	}

	inline static int32_t get_offset_of_m_Disposed_18() { return static_cast<int32_t>(offsetof(NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632, ___m_Disposed_18)); }
	inline bool get_m_Disposed_18() const { return ___m_Disposed_18; }
	inline bool* get_address_of_m_Disposed_18() { return &___m_Disposed_18; }
	inline void set_m_Disposed_18(bool value)
	{
		___m_Disposed_18 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // NETWORKCONNECTION_TC00D92CEDB25DBEE926BBC4B45BCE182A5675632_H
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
#ifndef BEHAVIOUR_TBDC7E9C3C898AD8348891B82D3E345801D920CA8_H
#define BEHAVIOUR_TBDC7E9C3C898AD8348891B82D3E345801D920CA8_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Behaviour
struct  Behaviour_tBDC7E9C3C898AD8348891B82D3E345801D920CA8  : public Component_t05064EF382ABCAF4B8C94F8A350EA85184C26621
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // BEHAVIOUR_TBDC7E9C3C898AD8348891B82D3E345801D920CA8_H
#ifndef LOCALCLIENT_T71A1C7B4DA47285F6F6970F60F1624C62DEB0ACD_H
#define LOCALCLIENT_T71A1C7B4DA47285F6F6970F60F1624C62DEB0ACD_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.LocalClient
struct  LocalClient_t71A1C7B4DA47285F6F6970F60F1624C62DEB0ACD  : public NetworkClient_t145A53DC925106E6D60DEEAA7D616B0A39F07172
{
public:
	// System.Collections.Generic.List`1<UnityEngine.Networking.LocalClient_InternalMsg> UnityEngine.Networking.LocalClient::m_InternalMsgs
	List_1_t15071630529F513887505BDF0C319691DC872E67 * ___m_InternalMsgs_25;
	// System.Collections.Generic.List`1<UnityEngine.Networking.LocalClient_InternalMsg> UnityEngine.Networking.LocalClient::m_InternalMsgs2
	List_1_t15071630529F513887505BDF0C319691DC872E67 * ___m_InternalMsgs2_26;
	// System.Collections.Generic.Stack`1<UnityEngine.Networking.LocalClient_InternalMsg> UnityEngine.Networking.LocalClient::m_FreeMessages
	Stack_1_tBFA1BD85E65A89CD8DE923E3997C832E44300C96 * ___m_FreeMessages_27;
	// UnityEngine.Networking.NetworkServer UnityEngine.Networking.LocalClient::m_LocalServer
	NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08 * ___m_LocalServer_28;
	// System.Boolean UnityEngine.Networking.LocalClient::m_Connected
	bool ___m_Connected_29;
	// UnityEngine.Networking.NetworkMessage UnityEngine.Networking.LocalClient::s_InternalMessage
	NetworkMessage_t8CF95D238C0966D1811596D78D3C4A57A431A8CF * ___s_InternalMessage_30;

public:
	inline static int32_t get_offset_of_m_InternalMsgs_25() { return static_cast<int32_t>(offsetof(LocalClient_t71A1C7B4DA47285F6F6970F60F1624C62DEB0ACD, ___m_InternalMsgs_25)); }
	inline List_1_t15071630529F513887505BDF0C319691DC872E67 * get_m_InternalMsgs_25() const { return ___m_InternalMsgs_25; }
	inline List_1_t15071630529F513887505BDF0C319691DC872E67 ** get_address_of_m_InternalMsgs_25() { return &___m_InternalMsgs_25; }
	inline void set_m_InternalMsgs_25(List_1_t15071630529F513887505BDF0C319691DC872E67 * value)
	{
		___m_InternalMsgs_25 = value;
		Il2CppCodeGenWriteBarrier((&___m_InternalMsgs_25), value);
	}

	inline static int32_t get_offset_of_m_InternalMsgs2_26() { return static_cast<int32_t>(offsetof(LocalClient_t71A1C7B4DA47285F6F6970F60F1624C62DEB0ACD, ___m_InternalMsgs2_26)); }
	inline List_1_t15071630529F513887505BDF0C319691DC872E67 * get_m_InternalMsgs2_26() const { return ___m_InternalMsgs2_26; }
	inline List_1_t15071630529F513887505BDF0C319691DC872E67 ** get_address_of_m_InternalMsgs2_26() { return &___m_InternalMsgs2_26; }
	inline void set_m_InternalMsgs2_26(List_1_t15071630529F513887505BDF0C319691DC872E67 * value)
	{
		___m_InternalMsgs2_26 = value;
		Il2CppCodeGenWriteBarrier((&___m_InternalMsgs2_26), value);
	}

	inline static int32_t get_offset_of_m_FreeMessages_27() { return static_cast<int32_t>(offsetof(LocalClient_t71A1C7B4DA47285F6F6970F60F1624C62DEB0ACD, ___m_FreeMessages_27)); }
	inline Stack_1_tBFA1BD85E65A89CD8DE923E3997C832E44300C96 * get_m_FreeMessages_27() const { return ___m_FreeMessages_27; }
	inline Stack_1_tBFA1BD85E65A89CD8DE923E3997C832E44300C96 ** get_address_of_m_FreeMessages_27() { return &___m_FreeMessages_27; }
	inline void set_m_FreeMessages_27(Stack_1_tBFA1BD85E65A89CD8DE923E3997C832E44300C96 * value)
	{
		___m_FreeMessages_27 = value;
		Il2CppCodeGenWriteBarrier((&___m_FreeMessages_27), value);
	}

	inline static int32_t get_offset_of_m_LocalServer_28() { return static_cast<int32_t>(offsetof(LocalClient_t71A1C7B4DA47285F6F6970F60F1624C62DEB0ACD, ___m_LocalServer_28)); }
	inline NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08 * get_m_LocalServer_28() const { return ___m_LocalServer_28; }
	inline NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08 ** get_address_of_m_LocalServer_28() { return &___m_LocalServer_28; }
	inline void set_m_LocalServer_28(NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08 * value)
	{
		___m_LocalServer_28 = value;
		Il2CppCodeGenWriteBarrier((&___m_LocalServer_28), value);
	}

	inline static int32_t get_offset_of_m_Connected_29() { return static_cast<int32_t>(offsetof(LocalClient_t71A1C7B4DA47285F6F6970F60F1624C62DEB0ACD, ___m_Connected_29)); }
	inline bool get_m_Connected_29() const { return ___m_Connected_29; }
	inline bool* get_address_of_m_Connected_29() { return &___m_Connected_29; }
	inline void set_m_Connected_29(bool value)
	{
		___m_Connected_29 = value;
	}

	inline static int32_t get_offset_of_s_InternalMessage_30() { return static_cast<int32_t>(offsetof(LocalClient_t71A1C7B4DA47285F6F6970F60F1624C62DEB0ACD, ___s_InternalMessage_30)); }
	inline NetworkMessage_t8CF95D238C0966D1811596D78D3C4A57A431A8CF * get_s_InternalMessage_30() const { return ___s_InternalMessage_30; }
	inline NetworkMessage_t8CF95D238C0966D1811596D78D3C4A57A431A8CF ** get_address_of_s_InternalMessage_30() { return &___s_InternalMessage_30; }
	inline void set_s_InternalMessage_30(NetworkMessage_t8CF95D238C0966D1811596D78D3C4A57A431A8CF * value)
	{
		___s_InternalMessage_30 = value;
		Il2CppCodeGenWriteBarrier((&___s_InternalMessage_30), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LOCALCLIENT_T71A1C7B4DA47285F6F6970F60F1624C62DEB0ACD_H
#ifndef SPAWNDELEGATE_T45423EB746AE4539766BCEBD1BBD7D21DEC4AB7B_H
#define SPAWNDELEGATE_T45423EB746AE4539766BCEBD1BBD7D21DEC4AB7B_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.SpawnDelegate
struct  SpawnDelegate_t45423EB746AE4539766BCEBD1BBD7D21DEC4AB7B  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SPAWNDELEGATE_T45423EB746AE4539766BCEBD1BBD7D21DEC4AB7B_H
#ifndef ULOCALCONNECTIONTOCLIENT_T270486B97F92181CBD9C89E72E7D9D0BF9100AB0_H
#define ULOCALCONNECTIONTOCLIENT_T270486B97F92181CBD9C89E72E7D9D0BF9100AB0_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.ULocalConnectionToClient
struct  ULocalConnectionToClient_t270486B97F92181CBD9C89E72E7D9D0BF9100AB0  : public NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632
{
public:
	// UnityEngine.Networking.LocalClient UnityEngine.Networking.ULocalConnectionToClient::m_LocalClient
	LocalClient_t71A1C7B4DA47285F6F6970F60F1624C62DEB0ACD * ___m_LocalClient_19;

public:
	inline static int32_t get_offset_of_m_LocalClient_19() { return static_cast<int32_t>(offsetof(ULocalConnectionToClient_t270486B97F92181CBD9C89E72E7D9D0BF9100AB0, ___m_LocalClient_19)); }
	inline LocalClient_t71A1C7B4DA47285F6F6970F60F1624C62DEB0ACD * get_m_LocalClient_19() const { return ___m_LocalClient_19; }
	inline LocalClient_t71A1C7B4DA47285F6F6970F60F1624C62DEB0ACD ** get_address_of_m_LocalClient_19() { return &___m_LocalClient_19; }
	inline void set_m_LocalClient_19(LocalClient_t71A1C7B4DA47285F6F6970F60F1624C62DEB0ACD * value)
	{
		___m_LocalClient_19 = value;
		Il2CppCodeGenWriteBarrier((&___m_LocalClient_19), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ULOCALCONNECTIONTOCLIENT_T270486B97F92181CBD9C89E72E7D9D0BF9100AB0_H
#ifndef ULOCALCONNECTIONTOSERVER_TAEFE862DB3377D88819D6799DADC10C89D4C19AA_H
#define ULOCALCONNECTIONTOSERVER_TAEFE862DB3377D88819D6799DADC10C89D4C19AA_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.ULocalConnectionToServer
struct  ULocalConnectionToServer_tAEFE862DB3377D88819D6799DADC10C89D4C19AA  : public NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632
{
public:
	// UnityEngine.Networking.NetworkServer UnityEngine.Networking.ULocalConnectionToServer::m_LocalServer
	NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08 * ___m_LocalServer_19;

public:
	inline static int32_t get_offset_of_m_LocalServer_19() { return static_cast<int32_t>(offsetof(ULocalConnectionToServer_tAEFE862DB3377D88819D6799DADC10C89D4C19AA, ___m_LocalServer_19)); }
	inline NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08 * get_m_LocalServer_19() const { return ___m_LocalServer_19; }
	inline NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08 ** get_address_of_m_LocalServer_19() { return &___m_LocalServer_19; }
	inline void set_m_LocalServer_19(NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08 * value)
	{
		___m_LocalServer_19 = value;
		Il2CppCodeGenWriteBarrier((&___m_LocalServer_19), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ULOCALCONNECTIONTOSERVER_TAEFE862DB3377D88819D6799DADC10C89D4C19AA_H
#ifndef UNSPAWNDELEGATE_T82FEE1FA0B957BFC00EFF737B34478C3ABBD04BD_H
#define UNSPAWNDELEGATE_T82FEE1FA0B957BFC00EFF737B34478C3ABBD04BD_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.UnSpawnDelegate
struct  UnSpawnDelegate_t82FEE1FA0B957BFC00EFF737B34478C3ABBD04BD  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UNSPAWNDELEGATE_T82FEE1FA0B957BFC00EFF737B34478C3ABBD04BD_H
#ifndef MONOBEHAVIOUR_T4A60845CF505405AF8BE8C61CC07F75CADEF6429_H
#define MONOBEHAVIOUR_T4A60845CF505405AF8BE8C61CC07F75CADEF6429_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.MonoBehaviour
struct  MonoBehaviour_t4A60845CF505405AF8BE8C61CC07F75CADEF6429  : public Behaviour_tBDC7E9C3C898AD8348891B82D3E345801D920CA8
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MONOBEHAVIOUR_T4A60845CF505405AF8BE8C61CC07F75CADEF6429_H
#ifndef NETWORKIDENTITY_T488C94C904793122E99D9C492C11E86343D6FA7C_H
#define NETWORKIDENTITY_T488C94C904793122E99D9C492C11E86343D6FA7C_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkIdentity
struct  NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C  : public MonoBehaviour_t4A60845CF505405AF8BE8C61CC07F75CADEF6429
{
public:
	// UnityEngine.Networking.NetworkSceneId UnityEngine.Networking.NetworkIdentity::m_SceneId
	NetworkSceneId_t5B68395705D998766CE75794410ACFF5A3019823  ___m_SceneId_4;
	// UnityEngine.Networking.NetworkHash128 UnityEngine.Networking.NetworkIdentity::m_AssetId
	NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6  ___m_AssetId_5;
	// System.Boolean UnityEngine.Networking.NetworkIdentity::m_ServerOnly
	bool ___m_ServerOnly_6;
	// System.Boolean UnityEngine.Networking.NetworkIdentity::m_LocalPlayerAuthority
	bool ___m_LocalPlayerAuthority_7;
	// System.Boolean UnityEngine.Networking.NetworkIdentity::m_IsClient
	bool ___m_IsClient_8;
	// System.Boolean UnityEngine.Networking.NetworkIdentity::m_IsServer
	bool ___m_IsServer_9;
	// System.Boolean UnityEngine.Networking.NetworkIdentity::m_HasAuthority
	bool ___m_HasAuthority_10;
	// UnityEngine.Networking.NetworkInstanceId UnityEngine.Networking.NetworkIdentity::m_NetId
	NetworkInstanceId_t52D82C12D9E18FD105D62C40BC0528CAD1C571A0  ___m_NetId_11;
	// System.Boolean UnityEngine.Networking.NetworkIdentity::m_IsLocalPlayer
	bool ___m_IsLocalPlayer_12;
	// UnityEngine.Networking.NetworkConnection UnityEngine.Networking.NetworkIdentity::m_ConnectionToServer
	NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632 * ___m_ConnectionToServer_13;
	// UnityEngine.Networking.NetworkConnection UnityEngine.Networking.NetworkIdentity::m_ConnectionToClient
	NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632 * ___m_ConnectionToClient_14;
	// System.Int16 UnityEngine.Networking.NetworkIdentity::m_PlayerId
	int16_t ___m_PlayerId_15;
	// UnityEngine.Networking.NetworkBehaviour[] UnityEngine.Networking.NetworkIdentity::m_NetworkBehaviours
	NetworkBehaviourU5BU5D_tCE47FAA00B6A49ACB7B734CE7A6FDEA819263500* ___m_NetworkBehaviours_16;
	// System.Collections.Generic.HashSet`1<System.Int32> UnityEngine.Networking.NetworkIdentity::m_ObserverConnections
	HashSet_1_t2BC1A062E48809D18CE313B19D603CA8BA5A0671 * ___m_ObserverConnections_17;
	// System.Collections.Generic.List`1<UnityEngine.Networking.NetworkConnection> UnityEngine.Networking.NetworkIdentity::m_Observers
	List_1_tEAA5B392FDC99D3335523D390FFCD08C48ACE455 * ___m_Observers_18;
	// UnityEngine.Networking.NetworkConnection UnityEngine.Networking.NetworkIdentity::m_ClientAuthorityOwner
	NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632 * ___m_ClientAuthorityOwner_19;
	// System.Boolean UnityEngine.Networking.NetworkIdentity::m_Reset
	bool ___m_Reset_20;

public:
	inline static int32_t get_offset_of_m_SceneId_4() { return static_cast<int32_t>(offsetof(NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C, ___m_SceneId_4)); }
	inline NetworkSceneId_t5B68395705D998766CE75794410ACFF5A3019823  get_m_SceneId_4() const { return ___m_SceneId_4; }
	inline NetworkSceneId_t5B68395705D998766CE75794410ACFF5A3019823 * get_address_of_m_SceneId_4() { return &___m_SceneId_4; }
	inline void set_m_SceneId_4(NetworkSceneId_t5B68395705D998766CE75794410ACFF5A3019823  value)
	{
		___m_SceneId_4 = value;
	}

	inline static int32_t get_offset_of_m_AssetId_5() { return static_cast<int32_t>(offsetof(NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C, ___m_AssetId_5)); }
	inline NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6  get_m_AssetId_5() const { return ___m_AssetId_5; }
	inline NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6 * get_address_of_m_AssetId_5() { return &___m_AssetId_5; }
	inline void set_m_AssetId_5(NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6  value)
	{
		___m_AssetId_5 = value;
	}

	inline static int32_t get_offset_of_m_ServerOnly_6() { return static_cast<int32_t>(offsetof(NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C, ___m_ServerOnly_6)); }
	inline bool get_m_ServerOnly_6() const { return ___m_ServerOnly_6; }
	inline bool* get_address_of_m_ServerOnly_6() { return &___m_ServerOnly_6; }
	inline void set_m_ServerOnly_6(bool value)
	{
		___m_ServerOnly_6 = value;
	}

	inline static int32_t get_offset_of_m_LocalPlayerAuthority_7() { return static_cast<int32_t>(offsetof(NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C, ___m_LocalPlayerAuthority_7)); }
	inline bool get_m_LocalPlayerAuthority_7() const { return ___m_LocalPlayerAuthority_7; }
	inline bool* get_address_of_m_LocalPlayerAuthority_7() { return &___m_LocalPlayerAuthority_7; }
	inline void set_m_LocalPlayerAuthority_7(bool value)
	{
		___m_LocalPlayerAuthority_7 = value;
	}

	inline static int32_t get_offset_of_m_IsClient_8() { return static_cast<int32_t>(offsetof(NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C, ___m_IsClient_8)); }
	inline bool get_m_IsClient_8() const { return ___m_IsClient_8; }
	inline bool* get_address_of_m_IsClient_8() { return &___m_IsClient_8; }
	inline void set_m_IsClient_8(bool value)
	{
		___m_IsClient_8 = value;
	}

	inline static int32_t get_offset_of_m_IsServer_9() { return static_cast<int32_t>(offsetof(NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C, ___m_IsServer_9)); }
	inline bool get_m_IsServer_9() const { return ___m_IsServer_9; }
	inline bool* get_address_of_m_IsServer_9() { return &___m_IsServer_9; }
	inline void set_m_IsServer_9(bool value)
	{
		___m_IsServer_9 = value;
	}

	inline static int32_t get_offset_of_m_HasAuthority_10() { return static_cast<int32_t>(offsetof(NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C, ___m_HasAuthority_10)); }
	inline bool get_m_HasAuthority_10() const { return ___m_HasAuthority_10; }
	inline bool* get_address_of_m_HasAuthority_10() { return &___m_HasAuthority_10; }
	inline void set_m_HasAuthority_10(bool value)
	{
		___m_HasAuthority_10 = value;
	}

	inline static int32_t get_offset_of_m_NetId_11() { return static_cast<int32_t>(offsetof(NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C, ___m_NetId_11)); }
	inline NetworkInstanceId_t52D82C12D9E18FD105D62C40BC0528CAD1C571A0  get_m_NetId_11() const { return ___m_NetId_11; }
	inline NetworkInstanceId_t52D82C12D9E18FD105D62C40BC0528CAD1C571A0 * get_address_of_m_NetId_11() { return &___m_NetId_11; }
	inline void set_m_NetId_11(NetworkInstanceId_t52D82C12D9E18FD105D62C40BC0528CAD1C571A0  value)
	{
		___m_NetId_11 = value;
	}

	inline static int32_t get_offset_of_m_IsLocalPlayer_12() { return static_cast<int32_t>(offsetof(NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C, ___m_IsLocalPlayer_12)); }
	inline bool get_m_IsLocalPlayer_12() const { return ___m_IsLocalPlayer_12; }
	inline bool* get_address_of_m_IsLocalPlayer_12() { return &___m_IsLocalPlayer_12; }
	inline void set_m_IsLocalPlayer_12(bool value)
	{
		___m_IsLocalPlayer_12 = value;
	}

	inline static int32_t get_offset_of_m_ConnectionToServer_13() { return static_cast<int32_t>(offsetof(NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C, ___m_ConnectionToServer_13)); }
	inline NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632 * get_m_ConnectionToServer_13() const { return ___m_ConnectionToServer_13; }
	inline NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632 ** get_address_of_m_ConnectionToServer_13() { return &___m_ConnectionToServer_13; }
	inline void set_m_ConnectionToServer_13(NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632 * value)
	{
		___m_ConnectionToServer_13 = value;
		Il2CppCodeGenWriteBarrier((&___m_ConnectionToServer_13), value);
	}

	inline static int32_t get_offset_of_m_ConnectionToClient_14() { return static_cast<int32_t>(offsetof(NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C, ___m_ConnectionToClient_14)); }
	inline NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632 * get_m_ConnectionToClient_14() const { return ___m_ConnectionToClient_14; }
	inline NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632 ** get_address_of_m_ConnectionToClient_14() { return &___m_ConnectionToClient_14; }
	inline void set_m_ConnectionToClient_14(NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632 * value)
	{
		___m_ConnectionToClient_14 = value;
		Il2CppCodeGenWriteBarrier((&___m_ConnectionToClient_14), value);
	}

	inline static int32_t get_offset_of_m_PlayerId_15() { return static_cast<int32_t>(offsetof(NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C, ___m_PlayerId_15)); }
	inline int16_t get_m_PlayerId_15() const { return ___m_PlayerId_15; }
	inline int16_t* get_address_of_m_PlayerId_15() { return &___m_PlayerId_15; }
	inline void set_m_PlayerId_15(int16_t value)
	{
		___m_PlayerId_15 = value;
	}

	inline static int32_t get_offset_of_m_NetworkBehaviours_16() { return static_cast<int32_t>(offsetof(NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C, ___m_NetworkBehaviours_16)); }
	inline NetworkBehaviourU5BU5D_tCE47FAA00B6A49ACB7B734CE7A6FDEA819263500* get_m_NetworkBehaviours_16() const { return ___m_NetworkBehaviours_16; }
	inline NetworkBehaviourU5BU5D_tCE47FAA00B6A49ACB7B734CE7A6FDEA819263500** get_address_of_m_NetworkBehaviours_16() { return &___m_NetworkBehaviours_16; }
	inline void set_m_NetworkBehaviours_16(NetworkBehaviourU5BU5D_tCE47FAA00B6A49ACB7B734CE7A6FDEA819263500* value)
	{
		___m_NetworkBehaviours_16 = value;
		Il2CppCodeGenWriteBarrier((&___m_NetworkBehaviours_16), value);
	}

	inline static int32_t get_offset_of_m_ObserverConnections_17() { return static_cast<int32_t>(offsetof(NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C, ___m_ObserverConnections_17)); }
	inline HashSet_1_t2BC1A062E48809D18CE313B19D603CA8BA5A0671 * get_m_ObserverConnections_17() const { return ___m_ObserverConnections_17; }
	inline HashSet_1_t2BC1A062E48809D18CE313B19D603CA8BA5A0671 ** get_address_of_m_ObserverConnections_17() { return &___m_ObserverConnections_17; }
	inline void set_m_ObserverConnections_17(HashSet_1_t2BC1A062E48809D18CE313B19D603CA8BA5A0671 * value)
	{
		___m_ObserverConnections_17 = value;
		Il2CppCodeGenWriteBarrier((&___m_ObserverConnections_17), value);
	}

	inline static int32_t get_offset_of_m_Observers_18() { return static_cast<int32_t>(offsetof(NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C, ___m_Observers_18)); }
	inline List_1_tEAA5B392FDC99D3335523D390FFCD08C48ACE455 * get_m_Observers_18() const { return ___m_Observers_18; }
	inline List_1_tEAA5B392FDC99D3335523D390FFCD08C48ACE455 ** get_address_of_m_Observers_18() { return &___m_Observers_18; }
	inline void set_m_Observers_18(List_1_tEAA5B392FDC99D3335523D390FFCD08C48ACE455 * value)
	{
		___m_Observers_18 = value;
		Il2CppCodeGenWriteBarrier((&___m_Observers_18), value);
	}

	inline static int32_t get_offset_of_m_ClientAuthorityOwner_19() { return static_cast<int32_t>(offsetof(NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C, ___m_ClientAuthorityOwner_19)); }
	inline NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632 * get_m_ClientAuthorityOwner_19() const { return ___m_ClientAuthorityOwner_19; }
	inline NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632 ** get_address_of_m_ClientAuthorityOwner_19() { return &___m_ClientAuthorityOwner_19; }
	inline void set_m_ClientAuthorityOwner_19(NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632 * value)
	{
		___m_ClientAuthorityOwner_19 = value;
		Il2CppCodeGenWriteBarrier((&___m_ClientAuthorityOwner_19), value);
	}

	inline static int32_t get_offset_of_m_Reset_20() { return static_cast<int32_t>(offsetof(NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C, ___m_Reset_20)); }
	inline bool get_m_Reset_20() const { return ___m_Reset_20; }
	inline bool* get_address_of_m_Reset_20() { return &___m_Reset_20; }
	inline void set_m_Reset_20(bool value)
	{
		___m_Reset_20 = value;
	}
};

struct NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C_StaticFields
{
public:
	// System.UInt32 UnityEngine.Networking.NetworkIdentity::s_NextNetworkId
	uint32_t ___s_NextNetworkId_21;
	// UnityEngine.Networking.NetworkWriter UnityEngine.Networking.NetworkIdentity::s_UpdateWriter
	NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * ___s_UpdateWriter_22;
	// UnityEngine.Networking.NetworkIdentity_ClientAuthorityCallback UnityEngine.Networking.NetworkIdentity::clientAuthorityCallback
	ClientAuthorityCallback_t84681ACFA43178557C6346AACE03B504C3C63FDE * ___clientAuthorityCallback_23;

public:
	inline static int32_t get_offset_of_s_NextNetworkId_21() { return static_cast<int32_t>(offsetof(NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C_StaticFields, ___s_NextNetworkId_21)); }
	inline uint32_t get_s_NextNetworkId_21() const { return ___s_NextNetworkId_21; }
	inline uint32_t* get_address_of_s_NextNetworkId_21() { return &___s_NextNetworkId_21; }
	inline void set_s_NextNetworkId_21(uint32_t value)
	{
		___s_NextNetworkId_21 = value;
	}

	inline static int32_t get_offset_of_s_UpdateWriter_22() { return static_cast<int32_t>(offsetof(NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C_StaticFields, ___s_UpdateWriter_22)); }
	inline NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * get_s_UpdateWriter_22() const { return ___s_UpdateWriter_22; }
	inline NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 ** get_address_of_s_UpdateWriter_22() { return &___s_UpdateWriter_22; }
	inline void set_s_UpdateWriter_22(NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * value)
	{
		___s_UpdateWriter_22 = value;
		Il2CppCodeGenWriteBarrier((&___s_UpdateWriter_22), value);
	}

	inline static int32_t get_offset_of_clientAuthorityCallback_23() { return static_cast<int32_t>(offsetof(NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C_StaticFields, ___clientAuthorityCallback_23)); }
	inline ClientAuthorityCallback_t84681ACFA43178557C6346AACE03B504C3C63FDE * get_clientAuthorityCallback_23() const { return ___clientAuthorityCallback_23; }
	inline ClientAuthorityCallback_t84681ACFA43178557C6346AACE03B504C3C63FDE ** get_address_of_clientAuthorityCallback_23() { return &___clientAuthorityCallback_23; }
	inline void set_clientAuthorityCallback_23(ClientAuthorityCallback_t84681ACFA43178557C6346AACE03B504C3C63FDE * value)
	{
		___clientAuthorityCallback_23 = value;
		Il2CppCodeGenWriteBarrier((&___clientAuthorityCallback_23), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // NETWORKIDENTITY_T488C94C904793122E99D9C492C11E86343D6FA7C_H
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


// !!0 UnityEngine.GameObject::GetComponent<System.Object>()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * GameObject_GetComponent_TisRuntimeObject_m41E09C4CA476451FE275573062956CED105CB79A_gshared (GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Networking.SyncList`1<System.Boolean>::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SyncList_1__ctor_mE221DB165D01DD8F6EC144B5A2B0AE8E39C864D5_gshared (SyncList_1_t6497C1ACAB6EB42D6D7F298D4AB6B2EE5E9CF6EF * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Networking.SyncList`1<System.Boolean>::AddInternal(T)
extern "C" IL2CPP_METHOD_ATTR void SyncList_1_AddInternal_mAC8442A4CFDDAB13EBCE69278F9F342AF9630DBC_gshared (SyncList_1_t6497C1ACAB6EB42D6D7F298D4AB6B2EE5E9CF6EF * __this, bool p0, const RuntimeMethod* method);
// System.Void UnityEngine.Networking.SyncList`1<System.Boolean>::Clear()
extern "C" IL2CPP_METHOD_ATTR void SyncList_1_Clear_m14176FDE294F9E7974EAF85D73604B4A83581B8A_gshared (SyncList_1_t6497C1ACAB6EB42D6D7F298D4AB6B2EE5E9CF6EF * __this, const RuntimeMethod* method);
// System.Int32 UnityEngine.Networking.SyncList`1<System.Boolean>::get_Count()
extern "C" IL2CPP_METHOD_ATTR int32_t SyncList_1_get_Count_m99C6CCCA1B63690490BAFEF3FFA0671E6E873C0C_gshared (SyncList_1_t6497C1ACAB6EB42D6D7F298D4AB6B2EE5E9CF6EF * __this, const RuntimeMethod* method);
// T UnityEngine.Networking.SyncList`1<System.Boolean>::get_Item(System.Int32)
extern "C" IL2CPP_METHOD_ATTR bool SyncList_1_get_Item_mA921A397406B074A972CFAD9DA2F60322B933DE5_gshared (SyncList_1_t6497C1ACAB6EB42D6D7F298D4AB6B2EE5E9CF6EF * __this, int32_t p0, const RuntimeMethod* method);
// System.Void UnityEngine.Networking.SyncList`1<System.Single>::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SyncList_1__ctor_m68F5839757D4DBBAABD3E723CC4E78FD592E5207_gshared (SyncList_1_t491D70D47353E92E83C01A9E23BC5C5ADAAE7311 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Networking.SyncList`1<System.Single>::AddInternal(T)
extern "C" IL2CPP_METHOD_ATTR void SyncList_1_AddInternal_m2F72C06D79DB5999144BE943EDF36DA2DCE13599_gshared (SyncList_1_t491D70D47353E92E83C01A9E23BC5C5ADAAE7311 * __this, float p0, const RuntimeMethod* method);
// System.Void UnityEngine.Networking.SyncList`1<System.Single>::Clear()
extern "C" IL2CPP_METHOD_ATTR void SyncList_1_Clear_m71C81796CC1C8CF6FCE17DA6AB788CE0D59F5960_gshared (SyncList_1_t491D70D47353E92E83C01A9E23BC5C5ADAAE7311 * __this, const RuntimeMethod* method);
// System.Int32 UnityEngine.Networking.SyncList`1<System.Single>::get_Count()
extern "C" IL2CPP_METHOD_ATTR int32_t SyncList_1_get_Count_m84C111D456738F05E1B8D83E1FB99E92B48FB961_gshared (SyncList_1_t491D70D47353E92E83C01A9E23BC5C5ADAAE7311 * __this, const RuntimeMethod* method);
// T UnityEngine.Networking.SyncList`1<System.Single>::get_Item(System.Int32)
extern "C" IL2CPP_METHOD_ATTR float SyncList_1_get_Item_m4265393B3FFC88909E4FE7CB10B454AE5D1E2C46_gshared (SyncList_1_t491D70D47353E92E83C01A9E23BC5C5ADAAE7311 * __this, int32_t p0, const RuntimeMethod* method);
// System.Void UnityEngine.Networking.SyncList`1<System.Int32>::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SyncList_1__ctor_m0621B589247DA8D6F0BEA24C5FC134480F08C34D_gshared (SyncList_1_t9939BD2C6A6D9D6EB338E4D0254A8720285B7EC2 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Networking.SyncList`1<System.Int32>::AddInternal(T)
extern "C" IL2CPP_METHOD_ATTR void SyncList_1_AddInternal_mDFCBDA7FC93AEC328AD072BB6BDBB707A0748FC3_gshared (SyncList_1_t9939BD2C6A6D9D6EB338E4D0254A8720285B7EC2 * __this, int32_t p0, const RuntimeMethod* method);
// System.Void UnityEngine.Networking.SyncList`1<System.Int32>::Clear()
extern "C" IL2CPP_METHOD_ATTR void SyncList_1_Clear_mD7144B94F9EAAA3B749EFA1B57157DE24CD8B23C_gshared (SyncList_1_t9939BD2C6A6D9D6EB338E4D0254A8720285B7EC2 * __this, const RuntimeMethod* method);
// System.Int32 UnityEngine.Networking.SyncList`1<System.Int32>::get_Count()
extern "C" IL2CPP_METHOD_ATTR int32_t SyncList_1_get_Count_m2ADDACB4181D1FA4E62543D708BC8C74371F5D32_gshared (SyncList_1_t9939BD2C6A6D9D6EB338E4D0254A8720285B7EC2 * __this, const RuntimeMethod* method);
// T UnityEngine.Networking.SyncList`1<System.Int32>::get_Item(System.Int32)
extern "C" IL2CPP_METHOD_ATTR int32_t SyncList_1_get_Item_mA90ABECE21F6FB9FC65FF17CCFDD262D781B52D0_gshared (SyncList_1_t9939BD2C6A6D9D6EB338E4D0254A8720285B7EC2 * __this, int32_t p0, const RuntimeMethod* method);
// System.Void UnityEngine.Networking.SyncList`1<System.Object>::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SyncList_1__ctor_m9F4A720A0BB6304076A07366F7E32E0A42181D14_gshared (SyncList_1_tEE50F611A8EFCCD059E955DDE35879647424A4F5 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Networking.SyncList`1<System.Object>::AddInternal(T)
extern "C" IL2CPP_METHOD_ATTR void SyncList_1_AddInternal_mD26193C688B4966133E8BC16E7356800DE3C2918_gshared (SyncList_1_tEE50F611A8EFCCD059E955DDE35879647424A4F5 * __this, RuntimeObject * p0, const RuntimeMethod* method);
// System.Void UnityEngine.Networking.SyncList`1<System.Object>::Clear()
extern "C" IL2CPP_METHOD_ATTR void SyncList_1_Clear_m5A37394AA2EAE37CF95AC25E1F1BB03DFFC4A2CA_gshared (SyncList_1_tEE50F611A8EFCCD059E955DDE35879647424A4F5 * __this, const RuntimeMethod* method);
// System.Int32 UnityEngine.Networking.SyncList`1<System.Object>::get_Count()
extern "C" IL2CPP_METHOD_ATTR int32_t SyncList_1_get_Count_m3AC518FD1BBA86869CC02E85C687A6171E9FB2E8_gshared (SyncList_1_tEE50F611A8EFCCD059E955DDE35879647424A4F5 * __this, const RuntimeMethod* method);
// T UnityEngine.Networking.SyncList`1<System.Object>::get_Item(System.Int32)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * SyncList_1_get_Item_m2A50938AA883E0D704B42DD4A1005F395BD02A5F_gshared (SyncList_1_tEE50F611A8EFCCD059E955DDE35879647424A4F5 * __this, int32_t p0, const RuntimeMethod* method);
// System.Void UnityEngine.Networking.SyncList`1<System.UInt32>::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SyncList_1__ctor_m9BD7FD9E27578465E832618C449AC896BE95E6E7_gshared (SyncList_1_tF7370C9EAD80F16C94714515A80898967A7AC85C * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Networking.SyncList`1<System.UInt32>::AddInternal(T)
extern "C" IL2CPP_METHOD_ATTR void SyncList_1_AddInternal_m778318507B8DC58EA01286B69E8D1232F3A4309D_gshared (SyncList_1_tF7370C9EAD80F16C94714515A80898967A7AC85C * __this, uint32_t p0, const RuntimeMethod* method);
// System.Void UnityEngine.Networking.SyncList`1<System.UInt32>::Clear()
extern "C" IL2CPP_METHOD_ATTR void SyncList_1_Clear_mB73C836DB01C1A8E9E57A7825CB6685D9ABC3C27_gshared (SyncList_1_tF7370C9EAD80F16C94714515A80898967A7AC85C * __this, const RuntimeMethod* method);
// System.Int32 UnityEngine.Networking.SyncList`1<System.UInt32>::get_Count()
extern "C" IL2CPP_METHOD_ATTR int32_t SyncList_1_get_Count_m3F7E989F3BB9E1AC489A24126B8F9CECF8F66A73_gshared (SyncList_1_tF7370C9EAD80F16C94714515A80898967A7AC85C * __this, const RuntimeMethod* method);
// T UnityEngine.Networking.SyncList`1<System.UInt32>::get_Item(System.Int32)
extern "C" IL2CPP_METHOD_ATTR uint32_t SyncList_1_get_Item_mF15B67FFBE3107CD3CC0F540BE68CE60FE5F6D44_gshared (SyncList_1_tF7370C9EAD80F16C94714515A80898967A7AC85C * __this, int32_t p0, const RuntimeMethod* method);

// System.Void System.Object::.ctor()
extern "C" IL2CPP_METHOD_ATTR void Object__ctor_m925ECA5E85CA100E3FB86A4F9E15C120E9A184C0 (RuntimeObject * __this, const RuntimeMethod* method);
// !!0 UnityEngine.GameObject::GetComponent<UnityEngine.Networking.NetworkIdentity>()
inline NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C * GameObject_GetComponent_TisNetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C_m3FCBB476BF3F550DB91E3EA0DE9DB5391D48E35E (GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * __this, const RuntimeMethod* method)
{
	return ((  NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C * (*) (GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F *, const RuntimeMethod*))GameObject_GetComponent_TisRuntimeObject_m41E09C4CA476451FE275573062956CED105CB79A_gshared)(__this, method);
}
// System.Boolean UnityEngine.Object::op_Inequality(UnityEngine.Object,UnityEngine.Object)
extern "C" IL2CPP_METHOD_ATTR bool Object_op_Inequality_m31EF58E217E8F4BDD3E409DEF79E1AEE95874FC1 (Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 * p0, Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 * p1, const RuntimeMethod* method);
// UnityEngine.Networking.NetworkInstanceId UnityEngine.Networking.NetworkIdentity::get_netId()
extern "C" IL2CPP_METHOD_ATTR NetworkInstanceId_t52D82C12D9E18FD105D62C40BC0528CAD1C571A0  NetworkIdentity_get_netId_m00C2793526826F470D466F6312B0C7C2B9902CDD (NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C * __this, const RuntimeMethod* method);
// System.String UnityEngine.Networking.NetworkInstanceId::ToString()
extern "C" IL2CPP_METHOD_ATTR String_t* NetworkInstanceId_ToString_m9BD1DDAFF0D8351529653F19245759229324DFAF (NetworkInstanceId_t52D82C12D9E18FD105D62C40BC0528CAD1C571A0 * __this, const RuntimeMethod* method);
// System.String UnityEngine.Object::get_name()
extern "C" IL2CPP_METHOD_ATTR String_t* Object_get_name_mA2D400141CB3C991C87A2556429781DE961A83CE (Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 * __this, const RuntimeMethod* method);
// System.String System.String::Format(System.String,System.Object[])
extern "C" IL2CPP_METHOD_ATTR String_t* String_Format_mA3AC3FE7B23D97F3A5BAA082D25B0E01B341A865 (String_t* p0, ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* p1, const RuntimeMethod* method);
// System.Void System.Attribute::.ctor()
extern "C" IL2CPP_METHOD_ATTR void Attribute__ctor_m45CAD4B01265CC84CC5A84F62EE2DBE85DE89EC0 (Attribute_tF048C13FB3C8CFCC53F82290E4A3F621089F9A74 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Networking.SyncList`1<System.Boolean>::.ctor()
inline void SyncList_1__ctor_mE221DB165D01DD8F6EC144B5A2B0AE8E39C864D5 (SyncList_1_t6497C1ACAB6EB42D6D7F298D4AB6B2EE5E9CF6EF * __this, const RuntimeMethod* method)
{
	((  void (*) (SyncList_1_t6497C1ACAB6EB42D6D7F298D4AB6B2EE5E9CF6EF *, const RuntimeMethod*))SyncList_1__ctor_mE221DB165D01DD8F6EC144B5A2B0AE8E39C864D5_gshared)(__this, method);
}
// System.Void UnityEngine.Networking.NetworkWriter::Write(System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void NetworkWriter_Write_mCEBCF51F9BB104776054B0ED7408DBB9D3A05B4E (NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * __this, bool ___value0, const RuntimeMethod* method);
// System.Boolean UnityEngine.Networking.NetworkReader::ReadBoolean()
extern "C" IL2CPP_METHOD_ATTR bool NetworkReader_ReadBoolean_m3B1FC61F5DCB833A891149F0906CA556DE4D960C (NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * __this, const RuntimeMethod* method);
// System.UInt16 UnityEngine.Networking.NetworkReader::ReadUInt16()
extern "C" IL2CPP_METHOD_ATTR uint16_t NetworkReader_ReadUInt16_m7658B3C3B70B33A4B7BFB0E385D7FC6BE3AA0608 (NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Networking.SyncListBool::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SyncListBool__ctor_m18A45510AC1614D6502BA34A4A4E037047B37A0D (SyncListBool_t923ECFA13FD645E25323073E9D533ADF88B0443D * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Networking.SyncList`1<System.Boolean>::AddInternal(T)
inline void SyncList_1_AddInternal_mAC8442A4CFDDAB13EBCE69278F9F342AF9630DBC (SyncList_1_t6497C1ACAB6EB42D6D7F298D4AB6B2EE5E9CF6EF * __this, bool p0, const RuntimeMethod* method)
{
	((  void (*) (SyncList_1_t6497C1ACAB6EB42D6D7F298D4AB6B2EE5E9CF6EF *, bool, const RuntimeMethod*))SyncList_1_AddInternal_mAC8442A4CFDDAB13EBCE69278F9F342AF9630DBC_gshared)(__this, p0, method);
}
// System.Void UnityEngine.Networking.SyncList`1<System.Boolean>::Clear()
inline void SyncList_1_Clear_m14176FDE294F9E7974EAF85D73604B4A83581B8A (SyncList_1_t6497C1ACAB6EB42D6D7F298D4AB6B2EE5E9CF6EF * __this, const RuntimeMethod* method)
{
	((  void (*) (SyncList_1_t6497C1ACAB6EB42D6D7F298D4AB6B2EE5E9CF6EF *, const RuntimeMethod*))SyncList_1_Clear_m14176FDE294F9E7974EAF85D73604B4A83581B8A_gshared)(__this, method);
}
// System.Int32 UnityEngine.Networking.SyncList`1<System.Boolean>::get_Count()
inline int32_t SyncList_1_get_Count_m99C6CCCA1B63690490BAFEF3FFA0671E6E873C0C (SyncList_1_t6497C1ACAB6EB42D6D7F298D4AB6B2EE5E9CF6EF * __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (SyncList_1_t6497C1ACAB6EB42D6D7F298D4AB6B2EE5E9CF6EF *, const RuntimeMethod*))SyncList_1_get_Count_m99C6CCCA1B63690490BAFEF3FFA0671E6E873C0C_gshared)(__this, method);
}
// System.Void UnityEngine.Networking.NetworkWriter::Write(System.UInt16)
extern "C" IL2CPP_METHOD_ATTR void NetworkWriter_Write_m7B4B1BA926F562D7D2FD2C58DAB509D8D9C7AACF (NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * __this, uint16_t ___value0, const RuntimeMethod* method);
// T UnityEngine.Networking.SyncList`1<System.Boolean>::get_Item(System.Int32)
inline bool SyncList_1_get_Item_mA921A397406B074A972CFAD9DA2F60322B933DE5 (SyncList_1_t6497C1ACAB6EB42D6D7F298D4AB6B2EE5E9CF6EF * __this, int32_t p0, const RuntimeMethod* method)
{
	return ((  bool (*) (SyncList_1_t6497C1ACAB6EB42D6D7F298D4AB6B2EE5E9CF6EF *, int32_t, const RuntimeMethod*))SyncList_1_get_Item_mA921A397406B074A972CFAD9DA2F60322B933DE5_gshared)(__this, p0, method);
}
// System.Void UnityEngine.Networking.SyncList`1<System.Single>::.ctor()
inline void SyncList_1__ctor_m68F5839757D4DBBAABD3E723CC4E78FD592E5207 (SyncList_1_t491D70D47353E92E83C01A9E23BC5C5ADAAE7311 * __this, const RuntimeMethod* method)
{
	((  void (*) (SyncList_1_t491D70D47353E92E83C01A9E23BC5C5ADAAE7311 *, const RuntimeMethod*))SyncList_1__ctor_m68F5839757D4DBBAABD3E723CC4E78FD592E5207_gshared)(__this, method);
}
// System.Void UnityEngine.Networking.NetworkWriter::Write(System.Single)
extern "C" IL2CPP_METHOD_ATTR void NetworkWriter_Write_mACF2C6CFE6CA681BB0503089300AE3E7B35C118F (NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * __this, float ___value0, const RuntimeMethod* method);
// System.Single UnityEngine.Networking.NetworkReader::ReadSingle()
extern "C" IL2CPP_METHOD_ATTR float NetworkReader_ReadSingle_m5298329FA8D90CA249DD882915FF76785318B04C (NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Networking.SyncListFloat::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SyncListFloat__ctor_m2C6A41F93235AF1128C0E6883254084AE2532778 (SyncListFloat_t645D206D30E48C66279A460EFF51EE1122F25708 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Networking.SyncList`1<System.Single>::AddInternal(T)
inline void SyncList_1_AddInternal_m2F72C06D79DB5999144BE943EDF36DA2DCE13599 (SyncList_1_t491D70D47353E92E83C01A9E23BC5C5ADAAE7311 * __this, float p0, const RuntimeMethod* method)
{
	((  void (*) (SyncList_1_t491D70D47353E92E83C01A9E23BC5C5ADAAE7311 *, float, const RuntimeMethod*))SyncList_1_AddInternal_m2F72C06D79DB5999144BE943EDF36DA2DCE13599_gshared)(__this, p0, method);
}
// System.Void UnityEngine.Networking.SyncList`1<System.Single>::Clear()
inline void SyncList_1_Clear_m71C81796CC1C8CF6FCE17DA6AB788CE0D59F5960 (SyncList_1_t491D70D47353E92E83C01A9E23BC5C5ADAAE7311 * __this, const RuntimeMethod* method)
{
	((  void (*) (SyncList_1_t491D70D47353E92E83C01A9E23BC5C5ADAAE7311 *, const RuntimeMethod*))SyncList_1_Clear_m71C81796CC1C8CF6FCE17DA6AB788CE0D59F5960_gshared)(__this, method);
}
// System.Int32 UnityEngine.Networking.SyncList`1<System.Single>::get_Count()
inline int32_t SyncList_1_get_Count_m84C111D456738F05E1B8D83E1FB99E92B48FB961 (SyncList_1_t491D70D47353E92E83C01A9E23BC5C5ADAAE7311 * __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (SyncList_1_t491D70D47353E92E83C01A9E23BC5C5ADAAE7311 *, const RuntimeMethod*))SyncList_1_get_Count_m84C111D456738F05E1B8D83E1FB99E92B48FB961_gshared)(__this, method);
}
// T UnityEngine.Networking.SyncList`1<System.Single>::get_Item(System.Int32)
inline float SyncList_1_get_Item_m4265393B3FFC88909E4FE7CB10B454AE5D1E2C46 (SyncList_1_t491D70D47353E92E83C01A9E23BC5C5ADAAE7311 * __this, int32_t p0, const RuntimeMethod* method)
{
	return ((  float (*) (SyncList_1_t491D70D47353E92E83C01A9E23BC5C5ADAAE7311 *, int32_t, const RuntimeMethod*))SyncList_1_get_Item_m4265393B3FFC88909E4FE7CB10B454AE5D1E2C46_gshared)(__this, p0, method);
}
// System.Void UnityEngine.Networking.SyncList`1<System.Int32>::.ctor()
inline void SyncList_1__ctor_m0621B589247DA8D6F0BEA24C5FC134480F08C34D (SyncList_1_t9939BD2C6A6D9D6EB338E4D0254A8720285B7EC2 * __this, const RuntimeMethod* method)
{
	((  void (*) (SyncList_1_t9939BD2C6A6D9D6EB338E4D0254A8720285B7EC2 *, const RuntimeMethod*))SyncList_1__ctor_m0621B589247DA8D6F0BEA24C5FC134480F08C34D_gshared)(__this, method);
}
// System.Void UnityEngine.Networking.NetworkWriter::WritePackedUInt32(System.UInt32)
extern "C" IL2CPP_METHOD_ATTR void NetworkWriter_WritePackedUInt32_mB6C5E298454EA701B12AD8A4AE29BCEF4B4C1532 (NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * __this, uint32_t ___value0, const RuntimeMethod* method);
// System.UInt32 UnityEngine.Networking.NetworkReader::ReadPackedUInt32()
extern "C" IL2CPP_METHOD_ATTR uint32_t NetworkReader_ReadPackedUInt32_m89366E6F099C10A68B35DA5BAF6287C5C0A3F2B8 (NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Networking.SyncListInt::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SyncListInt__ctor_m7C40E1815DE1B26F03960F291E1AC823FF9B2074 (SyncListInt_t983DECC70C3DF63128B79CC3F65E9153AC31E91C * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Networking.SyncList`1<System.Int32>::AddInternal(T)
inline void SyncList_1_AddInternal_mDFCBDA7FC93AEC328AD072BB6BDBB707A0748FC3 (SyncList_1_t9939BD2C6A6D9D6EB338E4D0254A8720285B7EC2 * __this, int32_t p0, const RuntimeMethod* method)
{
	((  void (*) (SyncList_1_t9939BD2C6A6D9D6EB338E4D0254A8720285B7EC2 *, int32_t, const RuntimeMethod*))SyncList_1_AddInternal_mDFCBDA7FC93AEC328AD072BB6BDBB707A0748FC3_gshared)(__this, p0, method);
}
// System.Void UnityEngine.Networking.SyncList`1<System.Int32>::Clear()
inline void SyncList_1_Clear_mD7144B94F9EAAA3B749EFA1B57157DE24CD8B23C (SyncList_1_t9939BD2C6A6D9D6EB338E4D0254A8720285B7EC2 * __this, const RuntimeMethod* method)
{
	((  void (*) (SyncList_1_t9939BD2C6A6D9D6EB338E4D0254A8720285B7EC2 *, const RuntimeMethod*))SyncList_1_Clear_mD7144B94F9EAAA3B749EFA1B57157DE24CD8B23C_gshared)(__this, method);
}
// System.Int32 UnityEngine.Networking.SyncList`1<System.Int32>::get_Count()
inline int32_t SyncList_1_get_Count_m2ADDACB4181D1FA4E62543D708BC8C74371F5D32 (SyncList_1_t9939BD2C6A6D9D6EB338E4D0254A8720285B7EC2 * __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (SyncList_1_t9939BD2C6A6D9D6EB338E4D0254A8720285B7EC2 *, const RuntimeMethod*))SyncList_1_get_Count_m2ADDACB4181D1FA4E62543D708BC8C74371F5D32_gshared)(__this, method);
}
// T UnityEngine.Networking.SyncList`1<System.Int32>::get_Item(System.Int32)
inline int32_t SyncList_1_get_Item_mA90ABECE21F6FB9FC65FF17CCFDD262D781B52D0 (SyncList_1_t9939BD2C6A6D9D6EB338E4D0254A8720285B7EC2 * __this, int32_t p0, const RuntimeMethod* method)
{
	return ((  int32_t (*) (SyncList_1_t9939BD2C6A6D9D6EB338E4D0254A8720285B7EC2 *, int32_t, const RuntimeMethod*))SyncList_1_get_Item_mA90ABECE21F6FB9FC65FF17CCFDD262D781B52D0_gshared)(__this, p0, method);
}
// System.Void UnityEngine.Networking.SyncList`1<System.String>::.ctor()
inline void SyncList_1__ctor_mDEF6DFE7474225B062A33F15C066C73E5508D7D8 (SyncList_1_tD7067A1EED06B4DCC141C47BEDD2B2ADDF546EB6 * __this, const RuntimeMethod* method)
{
	((  void (*) (SyncList_1_tD7067A1EED06B4DCC141C47BEDD2B2ADDF546EB6 *, const RuntimeMethod*))SyncList_1__ctor_m9F4A720A0BB6304076A07366F7E32E0A42181D14_gshared)(__this, method);
}
// System.Void UnityEngine.Networking.NetworkWriter::Write(System.String)
extern "C" IL2CPP_METHOD_ATTR void NetworkWriter_Write_m7C72E7D3ECE798F6B0D811475E363A526B2E78EE (NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * __this, String_t* ___value0, const RuntimeMethod* method);
// System.String UnityEngine.Networking.NetworkReader::ReadString()
extern "C" IL2CPP_METHOD_ATTR String_t* NetworkReader_ReadString_m0AE36FB1124CA37666D2C4340D5397E35DAF3EA0 (NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Networking.SyncListString::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SyncListString__ctor_m40228C5CFE34EBE1B805E8A011765A3D2809361C (SyncListString_t60A178543A04A4418DB27AEAABA7D8E224C5CCF0 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Networking.SyncList`1<System.String>::AddInternal(T)
inline void SyncList_1_AddInternal_mB027582F168CCBF56CD4D628BE448D5844C9F80A (SyncList_1_tD7067A1EED06B4DCC141C47BEDD2B2ADDF546EB6 * __this, String_t* p0, const RuntimeMethod* method)
{
	((  void (*) (SyncList_1_tD7067A1EED06B4DCC141C47BEDD2B2ADDF546EB6 *, String_t*, const RuntimeMethod*))SyncList_1_AddInternal_mD26193C688B4966133E8BC16E7356800DE3C2918_gshared)(__this, p0, method);
}
// System.Void UnityEngine.Networking.SyncList`1<System.String>::Clear()
inline void SyncList_1_Clear_mA3628B737C052F7946F55AB625CAED61652DC83A (SyncList_1_tD7067A1EED06B4DCC141C47BEDD2B2ADDF546EB6 * __this, const RuntimeMethod* method)
{
	((  void (*) (SyncList_1_tD7067A1EED06B4DCC141C47BEDD2B2ADDF546EB6 *, const RuntimeMethod*))SyncList_1_Clear_m5A37394AA2EAE37CF95AC25E1F1BB03DFFC4A2CA_gshared)(__this, method);
}
// System.Int32 UnityEngine.Networking.SyncList`1<System.String>::get_Count()
inline int32_t SyncList_1_get_Count_mBFD13B7B0896759864013263CC517D1E50FA1C03 (SyncList_1_tD7067A1EED06B4DCC141C47BEDD2B2ADDF546EB6 * __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (SyncList_1_tD7067A1EED06B4DCC141C47BEDD2B2ADDF546EB6 *, const RuntimeMethod*))SyncList_1_get_Count_m3AC518FD1BBA86869CC02E85C687A6171E9FB2E8_gshared)(__this, method);
}
// T UnityEngine.Networking.SyncList`1<System.String>::get_Item(System.Int32)
inline String_t* SyncList_1_get_Item_m44091CDDCB00A7A165E3AA3DA56CD7A30F0F5877 (SyncList_1_tD7067A1EED06B4DCC141C47BEDD2B2ADDF546EB6 * __this, int32_t p0, const RuntimeMethod* method)
{
	return ((  String_t* (*) (SyncList_1_tD7067A1EED06B4DCC141C47BEDD2B2ADDF546EB6 *, int32_t, const RuntimeMethod*))SyncList_1_get_Item_m2A50938AA883E0D704B42DD4A1005F395BD02A5F_gshared)(__this, p0, method);
}
// System.Void UnityEngine.Networking.SyncList`1<System.UInt32>::.ctor()
inline void SyncList_1__ctor_m9BD7FD9E27578465E832618C449AC896BE95E6E7 (SyncList_1_tF7370C9EAD80F16C94714515A80898967A7AC85C * __this, const RuntimeMethod* method)
{
	((  void (*) (SyncList_1_tF7370C9EAD80F16C94714515A80898967A7AC85C *, const RuntimeMethod*))SyncList_1__ctor_m9BD7FD9E27578465E832618C449AC896BE95E6E7_gshared)(__this, method);
}
// System.Void UnityEngine.Networking.SyncListUInt::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SyncListUInt__ctor_m12DC8C5F857A8BD4AB16591B2E097AFE8B037549 (SyncListUInt_t07AD639C74DD935A6A0A498026B4BD89A222A2B9 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Networking.SyncList`1<System.UInt32>::AddInternal(T)
inline void SyncList_1_AddInternal_m778318507B8DC58EA01286B69E8D1232F3A4309D (SyncList_1_tF7370C9EAD80F16C94714515A80898967A7AC85C * __this, uint32_t p0, const RuntimeMethod* method)
{
	((  void (*) (SyncList_1_tF7370C9EAD80F16C94714515A80898967A7AC85C *, uint32_t, const RuntimeMethod*))SyncList_1_AddInternal_m778318507B8DC58EA01286B69E8D1232F3A4309D_gshared)(__this, p0, method);
}
// System.Void UnityEngine.Networking.SyncList`1<System.UInt32>::Clear()
inline void SyncList_1_Clear_mB73C836DB01C1A8E9E57A7825CB6685D9ABC3C27 (SyncList_1_tF7370C9EAD80F16C94714515A80898967A7AC85C * __this, const RuntimeMethod* method)
{
	((  void (*) (SyncList_1_tF7370C9EAD80F16C94714515A80898967A7AC85C *, const RuntimeMethod*))SyncList_1_Clear_mB73C836DB01C1A8E9E57A7825CB6685D9ABC3C27_gshared)(__this, method);
}
// System.Int32 UnityEngine.Networking.SyncList`1<System.UInt32>::get_Count()
inline int32_t SyncList_1_get_Count_m3F7E989F3BB9E1AC489A24126B8F9CECF8F66A73 (SyncList_1_tF7370C9EAD80F16C94714515A80898967A7AC85C * __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (SyncList_1_tF7370C9EAD80F16C94714515A80898967A7AC85C *, const RuntimeMethod*))SyncList_1_get_Count_m3F7E989F3BB9E1AC489A24126B8F9CECF8F66A73_gshared)(__this, method);
}
// T UnityEngine.Networking.SyncList`1<System.UInt32>::get_Item(System.Int32)
inline uint32_t SyncList_1_get_Item_mF15B67FFBE3107CD3CC0F540BE68CE60FE5F6D44 (SyncList_1_tF7370C9EAD80F16C94714515A80898967A7AC85C * __this, int32_t p0, const RuntimeMethod* method)
{
	return ((  uint32_t (*) (SyncList_1_tF7370C9EAD80F16C94714515A80898967A7AC85C *, int32_t, const RuntimeMethod*))SyncList_1_get_Item_mF15B67FFBE3107CD3CC0F540BE68CE60FE5F6D44_gshared)(__this, p0, method);
}
// System.Void UnityEngine.Networking.NetworkConnection::.ctor()
extern "C" IL2CPP_METHOD_ATTR void NetworkConnection__ctor_m46DC560CC3D18779639B2F2201ED9C4B4F37DF66 (NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Networking.LocalClient::InvokeHandlerOnClient(System.Int16,UnityEngine.Networking.MessageBase,System.Int32)
extern "C" IL2CPP_METHOD_ATTR void LocalClient_InvokeHandlerOnClient_mA5F8585DC0BDC7508EB3BEF98208EDAAD5595B03 (LocalClient_t71A1C7B4DA47285F6F6970F60F1624C62DEB0ACD * __this, int16_t ___msgType0, MessageBase_tAAFE9A29B9F4BDD2AFDB6135902A007560820C93 * ___msg1, int32_t ___channelId2, const RuntimeMethod* method);
// System.Void UnityEngine.Networking.LocalClient::InvokeBytesOnClient(System.Byte[],System.Int32)
extern "C" IL2CPP_METHOD_ATTR void LocalClient_InvokeBytesOnClient_mB6FFA5459DB60E83265A3287292420D9A992511A (LocalClient_t71A1C7B4DA47285F6F6970F60F1624C62DEB0ACD * __this, ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___buffer0, int32_t ___channelId1, const RuntimeMethod* method);
// System.Byte[] UnityEngine.Networking.NetworkWriter::AsArray()
extern "C" IL2CPP_METHOD_ATTR ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* NetworkWriter_AsArray_m99ED1AA7647B87ACAB80A9BAFD0C9A7913845D32 (NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * __this, const RuntimeMethod* method);
// System.Boolean UnityEngine.Networking.NetworkServer::InvokeHandlerOnServer(UnityEngine.Networking.ULocalConnectionToServer,System.Int16,UnityEngine.Networking.MessageBase,System.Int32)
extern "C" IL2CPP_METHOD_ATTR bool NetworkServer_InvokeHandlerOnServer_m59281A60BF922D55EF91B931FDE478AFC4BDED7A (NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08 * __this, ULocalConnectionToServer_tAEFE862DB3377D88819D6799DADC10C89D4C19AA * ___conn0, int16_t ___msgType1, MessageBase_tAAFE9A29B9F4BDD2AFDB6135902A007560820C93 * ___msg2, int32_t ___channelId3, const RuntimeMethod* method);
// System.Boolean UnityEngine.Networking.LogFilter::get_logError()
extern "C" IL2CPP_METHOD_ATTR bool LogFilter_get_logError_mFA7FB0106EF4A5833829D37D63072EF7FD60C1A9 (const RuntimeMethod* method);
// System.Void UnityEngine.Debug::LogError(System.Object)
extern "C" IL2CPP_METHOD_ATTR void Debug_LogError_m3BCF9B78263152261565DCA9DB7D55F0C391ED29 (RuntimeObject * p0, const RuntimeMethod* method);
// System.Boolean UnityEngine.Networking.NetworkServer::InvokeBytes(UnityEngine.Networking.ULocalConnectionToServer,System.Byte[],System.Int32,System.Int32)
extern "C" IL2CPP_METHOD_ATTR bool NetworkServer_InvokeBytes_m95C4388BDBDD256C9D129E82560E6D3CD2BDDB3B (NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08 * __this, ULocalConnectionToServer_tAEFE862DB3377D88819D6799DADC10C89D4C19AA * ___conn0, ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___buffer1, int32_t ___numBytes2, int32_t ___channelId3, const RuntimeMethod* method);
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void UnityEngine.Networking.PlayerController::.ctor()
extern "C" IL2CPP_METHOD_ATTR void PlayerController__ctor_mC11EB0F8F29A160589072F3FAE1113B20E33B06A (PlayerController_tD0BA5C3E7CAD2CE52BFFBAB61C21F86752B32EA6 * __this, const RuntimeMethod* method)
{
	{
		__this->set_playerControllerId_1((int16_t)(-1));
		Object__ctor_m925ECA5E85CA100E3FB86A4F9E15C120E9A184C0(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void UnityEngine.Networking.PlayerController::.ctor(UnityEngine.GameObject,System.Int16)
extern "C" IL2CPP_METHOD_ATTR void PlayerController__ctor_mD6C6B070FAEF299B5F11E3CD418B92A468D6C7ED (PlayerController_tD0BA5C3E7CAD2CE52BFFBAB61C21F86752B32EA6 * __this, GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * ___go0, int16_t ___playerControllerId1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (PlayerController__ctor_mD6C6B070FAEF299B5F11E3CD418B92A468D6C7ED_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		__this->set_playerControllerId_1((int16_t)(-1));
		Object__ctor_m925ECA5E85CA100E3FB86A4F9E15C120E9A184C0(__this, /*hidden argument*/NULL);
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_0 = ___go0;
		__this->set_gameObject_3(L_0);
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_1 = ___go0;
		NullCheck(L_1);
		NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C * L_2 = GameObject_GetComponent_TisNetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C_m3FCBB476BF3F550DB91E3EA0DE9DB5391D48E35E(L_1, /*hidden argument*/GameObject_GetComponent_TisNetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C_m3FCBB476BF3F550DB91E3EA0DE9DB5391D48E35E_RuntimeMethod_var);
		__this->set_unetView_2(L_2);
		int16_t L_3 = ___playerControllerId1;
		__this->set_playerControllerId_1(L_3);
		return;
	}
}
// System.Boolean UnityEngine.Networking.PlayerController::get_IsValid()
extern "C" IL2CPP_METHOD_ATTR bool PlayerController_get_IsValid_m191C1A3C30BCE7BFA6E2F36259D19806A269E7AA (PlayerController_tD0BA5C3E7CAD2CE52BFFBAB61C21F86752B32EA6 * __this, const RuntimeMethod* method)
{
	bool V_0 = false;
	{
		int16_t L_0 = __this->get_playerControllerId_1();
		V_0 = (bool)((((int32_t)((((int32_t)L_0) == ((int32_t)(-1)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0013;
	}

IL_0013:
	{
		bool L_1 = V_0;
		return L_1;
	}
}
// System.String UnityEngine.Networking.PlayerController::ToString()
extern "C" IL2CPP_METHOD_ATTR String_t* PlayerController_ToString_m98847EBE32863A0A759753BA489E97671DB6D5F3 (PlayerController_tD0BA5C3E7CAD2CE52BFFBAB61C21F86752B32EA6 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (PlayerController_ToString_m98847EBE32863A0A759753BA489E97671DB6D5F3_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	NetworkInstanceId_t52D82C12D9E18FD105D62C40BC0528CAD1C571A0  V_0;
	memset(&V_0, 0, sizeof(V_0));
	String_t* V_1 = NULL;
	int32_t G_B2_0 = 0;
	ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* G_B2_1 = NULL;
	ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* G_B2_2 = NULL;
	String_t* G_B2_3 = NULL;
	int32_t G_B1_0 = 0;
	ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* G_B1_1 = NULL;
	ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* G_B1_2 = NULL;
	String_t* G_B1_3 = NULL;
	String_t* G_B3_0 = NULL;
	int32_t G_B3_1 = 0;
	ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* G_B3_2 = NULL;
	ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* G_B3_3 = NULL;
	String_t* G_B3_4 = NULL;
	int32_t G_B5_0 = 0;
	ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* G_B5_1 = NULL;
	ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* G_B5_2 = NULL;
	String_t* G_B5_3 = NULL;
	int32_t G_B4_0 = 0;
	ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* G_B4_1 = NULL;
	ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* G_B4_2 = NULL;
	String_t* G_B4_3 = NULL;
	String_t* G_B6_0 = NULL;
	int32_t G_B6_1 = 0;
	ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* G_B6_2 = NULL;
	ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* G_B6_3 = NULL;
	String_t* G_B6_4 = NULL;
	{
		ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* L_0 = (ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A*)SZArrayNew(ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A_il2cpp_TypeInfo_var, (uint32_t)3);
		ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* L_1 = L_0;
		int16_t L_2 = __this->get_playerControllerId_1();
		int16_t L_3 = L_2;
		RuntimeObject * L_4 = Box(Int16_t823A20635DAF5A3D93A1E01CFBF3CBA27CF00B4D_il2cpp_TypeInfo_var, &L_3);
		NullCheck(L_1);
		ArrayElementTypeCheck (L_1, L_4);
		(L_1)->SetAt(static_cast<il2cpp_array_size_t>(0), (RuntimeObject *)L_4);
		ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* L_5 = L_1;
		NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C * L_6 = __this->get_unetView_2();
		IL2CPP_RUNTIME_CLASS_INIT(Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_il2cpp_TypeInfo_var);
		bool L_7 = Object_op_Inequality_m31EF58E217E8F4BDD3E409DEF79E1AEE95874FC1(L_6, (Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 *)NULL, /*hidden argument*/NULL);
		G_B1_0 = 1;
		G_B1_1 = L_5;
		G_B1_2 = L_5;
		G_B1_3 = _stringLiteral1FB72BA5614BA625FBF384ACEA5077F842DEAC45;
		if (!L_7)
		{
			G_B2_0 = 1;
			G_B2_1 = L_5;
			G_B2_2 = L_5;
			G_B2_3 = _stringLiteral1FB72BA5614BA625FBF384ACEA5077F842DEAC45;
			goto IL_004b;
		}
	}
	{
		NetworkIdentity_t488C94C904793122E99D9C492C11E86343D6FA7C * L_8 = __this->get_unetView_2();
		NullCheck(L_8);
		NetworkInstanceId_t52D82C12D9E18FD105D62C40BC0528CAD1C571A0  L_9 = NetworkIdentity_get_netId_m00C2793526826F470D466F6312B0C7C2B9902CDD(L_8, /*hidden argument*/NULL);
		V_0 = L_9;
		String_t* L_10 = NetworkInstanceId_ToString_m9BD1DDAFF0D8351529653F19245759229324DFAF((NetworkInstanceId_t52D82C12D9E18FD105D62C40BC0528CAD1C571A0 *)(&V_0), /*hidden argument*/NULL);
		G_B3_0 = L_10;
		G_B3_1 = G_B1_0;
		G_B3_2 = G_B1_1;
		G_B3_3 = G_B1_2;
		G_B3_4 = G_B1_3;
		goto IL_0050;
	}

IL_004b:
	{
		G_B3_0 = _stringLiteral2BE88CA4242C76E8253AC62474851065032D6833;
		G_B3_1 = G_B2_0;
		G_B3_2 = G_B2_1;
		G_B3_3 = G_B2_2;
		G_B3_4 = G_B2_3;
	}

IL_0050:
	{
		NullCheck(G_B3_2);
		ArrayElementTypeCheck (G_B3_2, G_B3_0);
		(G_B3_2)->SetAt(static_cast<il2cpp_array_size_t>(G_B3_1), (RuntimeObject *)G_B3_0);
		ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* L_11 = G_B3_3;
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_12 = __this->get_gameObject_3();
		IL2CPP_RUNTIME_CLASS_INIT(Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_il2cpp_TypeInfo_var);
		bool L_13 = Object_op_Inequality_m31EF58E217E8F4BDD3E409DEF79E1AEE95874FC1(L_12, (Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 *)NULL, /*hidden argument*/NULL);
		G_B4_0 = 2;
		G_B4_1 = L_11;
		G_B4_2 = L_11;
		G_B4_3 = G_B3_4;
		if (!L_13)
		{
			G_B5_0 = 2;
			G_B5_1 = L_11;
			G_B5_2 = L_11;
			G_B5_3 = G_B3_4;
			goto IL_0074;
		}
	}
	{
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_14 = __this->get_gameObject_3();
		NullCheck(L_14);
		String_t* L_15 = Object_get_name_mA2D400141CB3C991C87A2556429781DE961A83CE(L_14, /*hidden argument*/NULL);
		G_B6_0 = L_15;
		G_B6_1 = G_B4_0;
		G_B6_2 = G_B4_1;
		G_B6_3 = G_B4_2;
		G_B6_4 = G_B4_3;
		goto IL_0079;
	}

IL_0074:
	{
		G_B6_0 = _stringLiteral2BE88CA4242C76E8253AC62474851065032D6833;
		G_B6_1 = G_B5_0;
		G_B6_2 = G_B5_1;
		G_B6_3 = G_B5_2;
		G_B6_4 = G_B5_3;
	}

IL_0079:
	{
		NullCheck(G_B6_2);
		ArrayElementTypeCheck (G_B6_2, G_B6_0);
		(G_B6_2)->SetAt(static_cast<il2cpp_array_size_t>(G_B6_1), (RuntimeObject *)G_B6_0);
		String_t* L_16 = String_Format_mA3AC3FE7B23D97F3A5BAA082D25B0E01B341A865(G_B6_4, G_B6_3, /*hidden argument*/NULL);
		V_1 = L_16;
		goto IL_0085;
	}

IL_0085:
	{
		String_t* L_17 = V_1;
		return L_17;
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
// System.Void UnityEngine.Networking.ServerAttribute::.ctor()
extern "C" IL2CPP_METHOD_ATTR void ServerAttribute__ctor_m2176997974FD0FB0EC1788414A3EE15B7DAC65A7 (ServerAttribute_t8EDD5C7824A540E38F713A2F26FFB1D756FA6F57 * __this, const RuntimeMethod* method)
{
	{
		Attribute__ctor_m45CAD4B01265CC84CC5A84F62EE2DBE85DE89EC0(__this, /*hidden argument*/NULL);
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
// System.Void UnityEngine.Networking.ServerCallbackAttribute::.ctor()
extern "C" IL2CPP_METHOD_ATTR void ServerCallbackAttribute__ctor_mD37933792B8569127BE75CADDDABBD4C335E099F (ServerCallbackAttribute_t1E84676A0DB622681E63343EA55890C92A1EA3EE * __this, const RuntimeMethod* method)
{
	{
		Attribute__ctor_m45CAD4B01265CC84CC5A84F62EE2DBE85DE89EC0(__this, /*hidden argument*/NULL);
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
// System.Void UnityEngine.Networking.SpawnDelegate::.ctor(System.Object,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR void SpawnDelegate__ctor_m6FD7294E753840E5E1B799D7BB694B41DCF0B015 (SpawnDelegate_t45423EB746AE4539766BCEBD1BBD7D21DEC4AB7B * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method)
{
	__this->set_method_ptr_0(il2cpp_codegen_get_method_pointer((RuntimeMethod*)___method1));
	__this->set_method_3(___method1);
	__this->set_m_target_2(___object0);
}
// UnityEngine.GameObject UnityEngine.Networking.SpawnDelegate::Invoke(UnityEngine.Vector3,UnityEngine.Networking.NetworkHash128)
extern "C" IL2CPP_METHOD_ATTR GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * SpawnDelegate_Invoke_m4EEE713563C64CB424892CA2B016744D076FC795 (SpawnDelegate_t45423EB746AE4539766BCEBD1BBD7D21DEC4AB7B * __this, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___position0, NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6  ___assetId1, const RuntimeMethod* method)
{
	GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * result = NULL;
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
					typedef GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * (*FunctionPointerType) (Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 , NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6 , const RuntimeMethod*);
					result = ((FunctionPointerType)targetMethodPointer)(___position0, ___assetId1, targetMethod);
				}
				else
				{
					// closed
					typedef GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * (*FunctionPointerType) (void*, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 , NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6 , const RuntimeMethod*);
					result = ((FunctionPointerType)targetMethodPointer)(targetThis, ___position0, ___assetId1, targetMethod);
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
							typedef GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * (*FunctionPointerType) (Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 , NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6 , const RuntimeMethod*);
							result = ((FunctionPointerType)targetMethodPointer)(___position0, ___assetId1, targetMethod);
						}
						else if (il2cpp_codegen_method_is_generic_instance(targetMethod))
						{
							if (il2cpp_codegen_method_is_interface_method(targetMethod))
								result = GenericInterfaceFuncInvoker2< GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F *, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 , NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6  >::Invoke(targetMethod, targetThis, ___position0, ___assetId1);
							else
								result = GenericVirtFuncInvoker2< GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F *, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 , NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6  >::Invoke(targetMethod, targetThis, ___position0, ___assetId1);
						}
						else
						{
							if (il2cpp_codegen_method_is_interface_method(targetMethod))
								result = InterfaceFuncInvoker2< GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F *, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 , NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6  >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), targetThis, ___position0, ___assetId1);
							else
								result = VirtFuncInvoker2< GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F *, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 , NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6  >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), targetThis, ___position0, ___assetId1);
						}
					}
				}
				else
				{
					typedef GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * (*FunctionPointerType) (void*, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 , NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6 , const RuntimeMethod*);
					result = ((FunctionPointerType)targetMethodPointer)(targetThis, ___position0, ___assetId1, targetMethod);
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
				typedef GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * (*FunctionPointerType) (Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 , NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6 , const RuntimeMethod*);
				result = ((FunctionPointerType)targetMethodPointer)(___position0, ___assetId1, targetMethod);
			}
			else
			{
				// closed
				typedef GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * (*FunctionPointerType) (void*, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 , NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6 , const RuntimeMethod*);
				result = ((FunctionPointerType)targetMethodPointer)(targetThis, ___position0, ___assetId1, targetMethod);
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
						typedef GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * (*FunctionPointerType) (Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 , NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6 , const RuntimeMethod*);
						result = ((FunctionPointerType)targetMethodPointer)(___position0, ___assetId1, targetMethod);
					}
					else if (il2cpp_codegen_method_is_generic_instance(targetMethod))
					{
						if (il2cpp_codegen_method_is_interface_method(targetMethod))
							result = GenericInterfaceFuncInvoker2< GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F *, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 , NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6  >::Invoke(targetMethod, targetThis, ___position0, ___assetId1);
						else
							result = GenericVirtFuncInvoker2< GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F *, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 , NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6  >::Invoke(targetMethod, targetThis, ___position0, ___assetId1);
					}
					else
					{
						if (il2cpp_codegen_method_is_interface_method(targetMethod))
							result = InterfaceFuncInvoker2< GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F *, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 , NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6  >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), targetThis, ___position0, ___assetId1);
						else
							result = VirtFuncInvoker2< GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F *, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 , NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6  >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), targetThis, ___position0, ___assetId1);
					}
				}
			}
			else
			{
				typedef GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * (*FunctionPointerType) (void*, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 , NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6 , const RuntimeMethod*);
				result = ((FunctionPointerType)targetMethodPointer)(targetThis, ___position0, ___assetId1, targetMethod);
			}
		}
	}
	return result;
}
// System.IAsyncResult UnityEngine.Networking.SpawnDelegate::BeginInvoke(UnityEngine.Vector3,UnityEngine.Networking.NetworkHash128,System.AsyncCallback,System.Object)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject* SpawnDelegate_BeginInvoke_mCA92C40891128B24CA301A2E987DEBE09FC0C424 (SpawnDelegate_t45423EB746AE4539766BCEBD1BBD7D21DEC4AB7B * __this, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___position0, NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6  ___assetId1, AsyncCallback_t3F3DA3BEDAEE81DD1D24125DF8EB30E85EE14DA4 * ___callback2, RuntimeObject * ___object3, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SpawnDelegate_BeginInvoke_mCA92C40891128B24CA301A2E987DEBE09FC0C424_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	void *__d_args[3] = {0};
	__d_args[0] = Box(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_il2cpp_TypeInfo_var, &___position0);
	__d_args[1] = Box(NetworkHash128_tFCA322BFD322F3FC6F0C2115A209BB2DA90C57B6_il2cpp_TypeInfo_var, &___assetId1);
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback2, (RuntimeObject*)___object3);
}
// UnityEngine.GameObject UnityEngine.Networking.SpawnDelegate::EndInvoke(System.IAsyncResult)
extern "C" IL2CPP_METHOD_ATTR GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * SpawnDelegate_EndInvoke_m8B8CE8CC969A4EA46CA32DA065BB767AC10841F5 (SpawnDelegate_t45423EB746AE4539766BCEBD1BBD7D21DEC4AB7B * __this, RuntimeObject* ___result0, const RuntimeMethod* method)
{
	RuntimeObject *__result = il2cpp_codegen_delegate_end_invoke((Il2CppAsyncResult*) ___result0, 0);
	return (GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F *)__result;
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void UnityEngine.Networking.SyncEventAttribute::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SyncEventAttribute__ctor_m8CD9BC240525F068E48B6129ECCA50C9FC1273E2 (SyncEventAttribute_t2D5695F58C45D4EE6A5303719EEDF84073160086 * __this, const RuntimeMethod* method)
{
	{
		__this->set_channel_0(0);
		Attribute__ctor_m45CAD4B01265CC84CC5A84F62EE2DBE85DE89EC0(__this, /*hidden argument*/NULL);
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
// System.Void UnityEngine.Networking.SyncListBool::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SyncListBool__ctor_m18A45510AC1614D6502BA34A4A4E037047B37A0D (SyncListBool_t923ECFA13FD645E25323073E9D533ADF88B0443D * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SyncListBool__ctor_m18A45510AC1614D6502BA34A4A4E037047B37A0D_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		SyncList_1__ctor_mE221DB165D01DD8F6EC144B5A2B0AE8E39C864D5(__this, /*hidden argument*/SyncList_1__ctor_mE221DB165D01DD8F6EC144B5A2B0AE8E39C864D5_RuntimeMethod_var);
		return;
	}
}
// System.Void UnityEngine.Networking.SyncListBool::SerializeItem(UnityEngine.Networking.NetworkWriter,System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void SyncListBool_SerializeItem_m5143187A76047555477C41207CDD0277FD4C1B91 (SyncListBool_t923ECFA13FD645E25323073E9D533ADF88B0443D * __this, NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * ___writer0, bool ___item1, const RuntimeMethod* method)
{
	{
		NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * L_0 = ___writer0;
		bool L_1 = ___item1;
		NullCheck(L_0);
		NetworkWriter_Write_mCEBCF51F9BB104776054B0ED7408DBB9D3A05B4E(L_0, L_1, /*hidden argument*/NULL);
		return;
	}
}
// System.Boolean UnityEngine.Networking.SyncListBool::DeserializeItem(UnityEngine.Networking.NetworkReader)
extern "C" IL2CPP_METHOD_ATTR bool SyncListBool_DeserializeItem_m018CEB97C5C293EC13F5BE40CEB9148447E89E01 (SyncListBool_t923ECFA13FD645E25323073E9D533ADF88B0443D * __this, NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * ___reader0, const RuntimeMethod* method)
{
	bool V_0 = false;
	{
		NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * L_0 = ___reader0;
		NullCheck(L_0);
		bool L_1 = NetworkReader_ReadBoolean_m3B1FC61F5DCB833A891149F0906CA556DE4D960C(L_0, /*hidden argument*/NULL);
		V_0 = L_1;
		goto IL_000d;
	}

IL_000d:
	{
		bool L_2 = V_0;
		return L_2;
	}
}
// UnityEngine.Networking.SyncListBool UnityEngine.Networking.SyncListBool::ReadInstance(UnityEngine.Networking.NetworkReader)
extern "C" IL2CPP_METHOD_ATTR SyncListBool_t923ECFA13FD645E25323073E9D533ADF88B0443D * SyncListBool_ReadInstance_m2006DD3AE73F46FA87B75CDF067B72CA9074DF3A (NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * ___reader0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SyncListBool_ReadInstance_m2006DD3AE73F46FA87B75CDF067B72CA9074DF3A_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	uint16_t V_0 = 0;
	SyncListBool_t923ECFA13FD645E25323073E9D533ADF88B0443D * V_1 = NULL;
	uint16_t V_2 = 0;
	SyncListBool_t923ECFA13FD645E25323073E9D533ADF88B0443D * V_3 = NULL;
	{
		NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * L_0 = ___reader0;
		NullCheck(L_0);
		uint16_t L_1 = NetworkReader_ReadUInt16_m7658B3C3B70B33A4B7BFB0E385D7FC6BE3AA0608(L_0, /*hidden argument*/NULL);
		V_0 = L_1;
		SyncListBool_t923ECFA13FD645E25323073E9D533ADF88B0443D * L_2 = (SyncListBool_t923ECFA13FD645E25323073E9D533ADF88B0443D *)il2cpp_codegen_object_new(SyncListBool_t923ECFA13FD645E25323073E9D533ADF88B0443D_il2cpp_TypeInfo_var);
		SyncListBool__ctor_m18A45510AC1614D6502BA34A4A4E037047B37A0D(L_2, /*hidden argument*/NULL);
		V_1 = L_2;
		V_2 = (uint16_t)0;
		goto IL_0028;
	}

IL_0015:
	{
		SyncListBool_t923ECFA13FD645E25323073E9D533ADF88B0443D * L_3 = V_1;
		NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * L_4 = ___reader0;
		NullCheck(L_4);
		bool L_5 = NetworkReader_ReadBoolean_m3B1FC61F5DCB833A891149F0906CA556DE4D960C(L_4, /*hidden argument*/NULL);
		NullCheck(L_3);
		SyncList_1_AddInternal_mAC8442A4CFDDAB13EBCE69278F9F342AF9630DBC(L_3, L_5, /*hidden argument*/SyncList_1_AddInternal_mAC8442A4CFDDAB13EBCE69278F9F342AF9630DBC_RuntimeMethod_var);
		uint16_t L_6 = V_2;
		V_2 = (uint16_t)(((int32_t)((uint16_t)((int32_t)il2cpp_codegen_add((int32_t)L_6, (int32_t)1)))));
	}

IL_0028:
	{
		uint16_t L_7 = V_2;
		uint16_t L_8 = V_0;
		if ((((int32_t)L_7) < ((int32_t)L_8)))
		{
			goto IL_0015;
		}
	}
	{
		SyncListBool_t923ECFA13FD645E25323073E9D533ADF88B0443D * L_9 = V_1;
		V_3 = L_9;
		goto IL_0036;
	}

IL_0036:
	{
		SyncListBool_t923ECFA13FD645E25323073E9D533ADF88B0443D * L_10 = V_3;
		return L_10;
	}
}
// System.Void UnityEngine.Networking.SyncListBool::ReadReference(UnityEngine.Networking.NetworkReader,UnityEngine.Networking.SyncListBool)
extern "C" IL2CPP_METHOD_ATTR void SyncListBool_ReadReference_m923850A087D74C3DAB16A2F630757E81E1D1D66C (NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * ___reader0, SyncListBool_t923ECFA13FD645E25323073E9D533ADF88B0443D * ___syncList1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SyncListBool_ReadReference_m923850A087D74C3DAB16A2F630757E81E1D1D66C_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	uint16_t V_0 = 0;
	uint16_t V_1 = 0;
	{
		NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * L_0 = ___reader0;
		NullCheck(L_0);
		uint16_t L_1 = NetworkReader_ReadUInt16_m7658B3C3B70B33A4B7BFB0E385D7FC6BE3AA0608(L_0, /*hidden argument*/NULL);
		V_0 = L_1;
		SyncListBool_t923ECFA13FD645E25323073E9D533ADF88B0443D * L_2 = ___syncList1;
		NullCheck(L_2);
		SyncList_1_Clear_m14176FDE294F9E7974EAF85D73604B4A83581B8A(L_2, /*hidden argument*/SyncList_1_Clear_m14176FDE294F9E7974EAF85D73604B4A83581B8A_RuntimeMethod_var);
		V_1 = (uint16_t)0;
		goto IL_0028;
	}

IL_0015:
	{
		SyncListBool_t923ECFA13FD645E25323073E9D533ADF88B0443D * L_3 = ___syncList1;
		NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * L_4 = ___reader0;
		NullCheck(L_4);
		bool L_5 = NetworkReader_ReadBoolean_m3B1FC61F5DCB833A891149F0906CA556DE4D960C(L_4, /*hidden argument*/NULL);
		NullCheck(L_3);
		SyncList_1_AddInternal_mAC8442A4CFDDAB13EBCE69278F9F342AF9630DBC(L_3, L_5, /*hidden argument*/SyncList_1_AddInternal_mAC8442A4CFDDAB13EBCE69278F9F342AF9630DBC_RuntimeMethod_var);
		uint16_t L_6 = V_1;
		V_1 = (uint16_t)(((int32_t)((uint16_t)((int32_t)il2cpp_codegen_add((int32_t)L_6, (int32_t)1)))));
	}

IL_0028:
	{
		uint16_t L_7 = V_1;
		uint16_t L_8 = V_0;
		if ((((int32_t)L_7) < ((int32_t)L_8)))
		{
			goto IL_0015;
		}
	}
	{
		return;
	}
}
// System.Void UnityEngine.Networking.SyncListBool::WriteInstance(UnityEngine.Networking.NetworkWriter,UnityEngine.Networking.SyncListBool)
extern "C" IL2CPP_METHOD_ATTR void SyncListBool_WriteInstance_m191A012991FEEA98B3BF674B5878E05A7362C12E (NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * ___writer0, SyncListBool_t923ECFA13FD645E25323073E9D533ADF88B0443D * ___items1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SyncListBool_WriteInstance_m191A012991FEEA98B3BF674B5878E05A7362C12E_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * L_0 = ___writer0;
		SyncListBool_t923ECFA13FD645E25323073E9D533ADF88B0443D * L_1 = ___items1;
		NullCheck(L_1);
		int32_t L_2 = SyncList_1_get_Count_m99C6CCCA1B63690490BAFEF3FFA0671E6E873C0C(L_1, /*hidden argument*/SyncList_1_get_Count_m99C6CCCA1B63690490BAFEF3FFA0671E6E873C0C_RuntimeMethod_var);
		NullCheck(L_0);
		NetworkWriter_Write_m7B4B1BA926F562D7D2FD2C58DAB509D8D9C7AACF(L_0, (uint16_t)(((int32_t)((uint16_t)L_2))), /*hidden argument*/NULL);
		V_0 = 0;
		goto IL_0028;
	}

IL_0015:
	{
		NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * L_3 = ___writer0;
		SyncListBool_t923ECFA13FD645E25323073E9D533ADF88B0443D * L_4 = ___items1;
		int32_t L_5 = V_0;
		NullCheck(L_4);
		bool L_6 = SyncList_1_get_Item_mA921A397406B074A972CFAD9DA2F60322B933DE5(L_4, L_5, /*hidden argument*/SyncList_1_get_Item_mA921A397406B074A972CFAD9DA2F60322B933DE5_RuntimeMethod_var);
		NullCheck(L_3);
		NetworkWriter_Write_mCEBCF51F9BB104776054B0ED7408DBB9D3A05B4E(L_3, L_6, /*hidden argument*/NULL);
		int32_t L_7 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add((int32_t)L_7, (int32_t)1));
	}

IL_0028:
	{
		int32_t L_8 = V_0;
		SyncListBool_t923ECFA13FD645E25323073E9D533ADF88B0443D * L_9 = ___items1;
		NullCheck(L_9);
		int32_t L_10 = SyncList_1_get_Count_m99C6CCCA1B63690490BAFEF3FFA0671E6E873C0C(L_9, /*hidden argument*/SyncList_1_get_Count_m99C6CCCA1B63690490BAFEF3FFA0671E6E873C0C_RuntimeMethod_var);
		if ((((int32_t)L_8) < ((int32_t)L_10)))
		{
			goto IL_0015;
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
// System.Void UnityEngine.Networking.SyncListFloat::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SyncListFloat__ctor_m2C6A41F93235AF1128C0E6883254084AE2532778 (SyncListFloat_t645D206D30E48C66279A460EFF51EE1122F25708 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SyncListFloat__ctor_m2C6A41F93235AF1128C0E6883254084AE2532778_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		SyncList_1__ctor_m68F5839757D4DBBAABD3E723CC4E78FD592E5207(__this, /*hidden argument*/SyncList_1__ctor_m68F5839757D4DBBAABD3E723CC4E78FD592E5207_RuntimeMethod_var);
		return;
	}
}
// System.Void UnityEngine.Networking.SyncListFloat::SerializeItem(UnityEngine.Networking.NetworkWriter,System.Single)
extern "C" IL2CPP_METHOD_ATTR void SyncListFloat_SerializeItem_m1F0A423D216D47A1CA780361D732AC595D00EA9B (SyncListFloat_t645D206D30E48C66279A460EFF51EE1122F25708 * __this, NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * ___writer0, float ___item1, const RuntimeMethod* method)
{
	{
		NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * L_0 = ___writer0;
		float L_1 = ___item1;
		NullCheck(L_0);
		NetworkWriter_Write_mACF2C6CFE6CA681BB0503089300AE3E7B35C118F(L_0, L_1, /*hidden argument*/NULL);
		return;
	}
}
// System.Single UnityEngine.Networking.SyncListFloat::DeserializeItem(UnityEngine.Networking.NetworkReader)
extern "C" IL2CPP_METHOD_ATTR float SyncListFloat_DeserializeItem_m35516D4AD8B1F3E59F422328D1BF59B54F06BD18 (SyncListFloat_t645D206D30E48C66279A460EFF51EE1122F25708 * __this, NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * ___reader0, const RuntimeMethod* method)
{
	float V_0 = 0.0f;
	{
		NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * L_0 = ___reader0;
		NullCheck(L_0);
		float L_1 = NetworkReader_ReadSingle_m5298329FA8D90CA249DD882915FF76785318B04C(L_0, /*hidden argument*/NULL);
		V_0 = L_1;
		goto IL_000d;
	}

IL_000d:
	{
		float L_2 = V_0;
		return L_2;
	}
}
// UnityEngine.Networking.SyncListFloat UnityEngine.Networking.SyncListFloat::ReadInstance(UnityEngine.Networking.NetworkReader)
extern "C" IL2CPP_METHOD_ATTR SyncListFloat_t645D206D30E48C66279A460EFF51EE1122F25708 * SyncListFloat_ReadInstance_mE3506BECB67837FCA9BC62E64804FE3DA279B2E0 (NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * ___reader0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SyncListFloat_ReadInstance_mE3506BECB67837FCA9BC62E64804FE3DA279B2E0_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	uint16_t V_0 = 0;
	SyncListFloat_t645D206D30E48C66279A460EFF51EE1122F25708 * V_1 = NULL;
	uint16_t V_2 = 0;
	SyncListFloat_t645D206D30E48C66279A460EFF51EE1122F25708 * V_3 = NULL;
	{
		NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * L_0 = ___reader0;
		NullCheck(L_0);
		uint16_t L_1 = NetworkReader_ReadUInt16_m7658B3C3B70B33A4B7BFB0E385D7FC6BE3AA0608(L_0, /*hidden argument*/NULL);
		V_0 = L_1;
		SyncListFloat_t645D206D30E48C66279A460EFF51EE1122F25708 * L_2 = (SyncListFloat_t645D206D30E48C66279A460EFF51EE1122F25708 *)il2cpp_codegen_object_new(SyncListFloat_t645D206D30E48C66279A460EFF51EE1122F25708_il2cpp_TypeInfo_var);
		SyncListFloat__ctor_m2C6A41F93235AF1128C0E6883254084AE2532778(L_2, /*hidden argument*/NULL);
		V_1 = L_2;
		V_2 = (uint16_t)0;
		goto IL_0028;
	}

IL_0015:
	{
		SyncListFloat_t645D206D30E48C66279A460EFF51EE1122F25708 * L_3 = V_1;
		NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * L_4 = ___reader0;
		NullCheck(L_4);
		float L_5 = NetworkReader_ReadSingle_m5298329FA8D90CA249DD882915FF76785318B04C(L_4, /*hidden argument*/NULL);
		NullCheck(L_3);
		SyncList_1_AddInternal_m2F72C06D79DB5999144BE943EDF36DA2DCE13599(L_3, L_5, /*hidden argument*/SyncList_1_AddInternal_m2F72C06D79DB5999144BE943EDF36DA2DCE13599_RuntimeMethod_var);
		uint16_t L_6 = V_2;
		V_2 = (uint16_t)(((int32_t)((uint16_t)((int32_t)il2cpp_codegen_add((int32_t)L_6, (int32_t)1)))));
	}

IL_0028:
	{
		uint16_t L_7 = V_2;
		uint16_t L_8 = V_0;
		if ((((int32_t)L_7) < ((int32_t)L_8)))
		{
			goto IL_0015;
		}
	}
	{
		SyncListFloat_t645D206D30E48C66279A460EFF51EE1122F25708 * L_9 = V_1;
		V_3 = L_9;
		goto IL_0036;
	}

IL_0036:
	{
		SyncListFloat_t645D206D30E48C66279A460EFF51EE1122F25708 * L_10 = V_3;
		return L_10;
	}
}
// System.Void UnityEngine.Networking.SyncListFloat::ReadReference(UnityEngine.Networking.NetworkReader,UnityEngine.Networking.SyncListFloat)
extern "C" IL2CPP_METHOD_ATTR void SyncListFloat_ReadReference_mB93225FCEBB336A623B4DD8911978E2C2D52D74B (NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * ___reader0, SyncListFloat_t645D206D30E48C66279A460EFF51EE1122F25708 * ___syncList1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SyncListFloat_ReadReference_mB93225FCEBB336A623B4DD8911978E2C2D52D74B_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	uint16_t V_0 = 0;
	uint16_t V_1 = 0;
	{
		NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * L_0 = ___reader0;
		NullCheck(L_0);
		uint16_t L_1 = NetworkReader_ReadUInt16_m7658B3C3B70B33A4B7BFB0E385D7FC6BE3AA0608(L_0, /*hidden argument*/NULL);
		V_0 = L_1;
		SyncListFloat_t645D206D30E48C66279A460EFF51EE1122F25708 * L_2 = ___syncList1;
		NullCheck(L_2);
		SyncList_1_Clear_m71C81796CC1C8CF6FCE17DA6AB788CE0D59F5960(L_2, /*hidden argument*/SyncList_1_Clear_m71C81796CC1C8CF6FCE17DA6AB788CE0D59F5960_RuntimeMethod_var);
		V_1 = (uint16_t)0;
		goto IL_0028;
	}

IL_0015:
	{
		SyncListFloat_t645D206D30E48C66279A460EFF51EE1122F25708 * L_3 = ___syncList1;
		NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * L_4 = ___reader0;
		NullCheck(L_4);
		float L_5 = NetworkReader_ReadSingle_m5298329FA8D90CA249DD882915FF76785318B04C(L_4, /*hidden argument*/NULL);
		NullCheck(L_3);
		SyncList_1_AddInternal_m2F72C06D79DB5999144BE943EDF36DA2DCE13599(L_3, L_5, /*hidden argument*/SyncList_1_AddInternal_m2F72C06D79DB5999144BE943EDF36DA2DCE13599_RuntimeMethod_var);
		uint16_t L_6 = V_1;
		V_1 = (uint16_t)(((int32_t)((uint16_t)((int32_t)il2cpp_codegen_add((int32_t)L_6, (int32_t)1)))));
	}

IL_0028:
	{
		uint16_t L_7 = V_1;
		uint16_t L_8 = V_0;
		if ((((int32_t)L_7) < ((int32_t)L_8)))
		{
			goto IL_0015;
		}
	}
	{
		return;
	}
}
// System.Void UnityEngine.Networking.SyncListFloat::WriteInstance(UnityEngine.Networking.NetworkWriter,UnityEngine.Networking.SyncListFloat)
extern "C" IL2CPP_METHOD_ATTR void SyncListFloat_WriteInstance_mCC397A2AC2F98D4BD2BFA98BDE725F95F5D4EAE7 (NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * ___writer0, SyncListFloat_t645D206D30E48C66279A460EFF51EE1122F25708 * ___items1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SyncListFloat_WriteInstance_mCC397A2AC2F98D4BD2BFA98BDE725F95F5D4EAE7_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * L_0 = ___writer0;
		SyncListFloat_t645D206D30E48C66279A460EFF51EE1122F25708 * L_1 = ___items1;
		NullCheck(L_1);
		int32_t L_2 = SyncList_1_get_Count_m84C111D456738F05E1B8D83E1FB99E92B48FB961(L_1, /*hidden argument*/SyncList_1_get_Count_m84C111D456738F05E1B8D83E1FB99E92B48FB961_RuntimeMethod_var);
		NullCheck(L_0);
		NetworkWriter_Write_m7B4B1BA926F562D7D2FD2C58DAB509D8D9C7AACF(L_0, (uint16_t)(((int32_t)((uint16_t)L_2))), /*hidden argument*/NULL);
		V_0 = 0;
		goto IL_0028;
	}

IL_0015:
	{
		NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * L_3 = ___writer0;
		SyncListFloat_t645D206D30E48C66279A460EFF51EE1122F25708 * L_4 = ___items1;
		int32_t L_5 = V_0;
		NullCheck(L_4);
		float L_6 = SyncList_1_get_Item_m4265393B3FFC88909E4FE7CB10B454AE5D1E2C46(L_4, L_5, /*hidden argument*/SyncList_1_get_Item_m4265393B3FFC88909E4FE7CB10B454AE5D1E2C46_RuntimeMethod_var);
		NullCheck(L_3);
		NetworkWriter_Write_mACF2C6CFE6CA681BB0503089300AE3E7B35C118F(L_3, L_6, /*hidden argument*/NULL);
		int32_t L_7 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add((int32_t)L_7, (int32_t)1));
	}

IL_0028:
	{
		int32_t L_8 = V_0;
		SyncListFloat_t645D206D30E48C66279A460EFF51EE1122F25708 * L_9 = ___items1;
		NullCheck(L_9);
		int32_t L_10 = SyncList_1_get_Count_m84C111D456738F05E1B8D83E1FB99E92B48FB961(L_9, /*hidden argument*/SyncList_1_get_Count_m84C111D456738F05E1B8D83E1FB99E92B48FB961_RuntimeMethod_var);
		if ((((int32_t)L_8) < ((int32_t)L_10)))
		{
			goto IL_0015;
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
// System.Void UnityEngine.Networking.SyncListInt::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SyncListInt__ctor_m7C40E1815DE1B26F03960F291E1AC823FF9B2074 (SyncListInt_t983DECC70C3DF63128B79CC3F65E9153AC31E91C * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SyncListInt__ctor_m7C40E1815DE1B26F03960F291E1AC823FF9B2074_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		SyncList_1__ctor_m0621B589247DA8D6F0BEA24C5FC134480F08C34D(__this, /*hidden argument*/SyncList_1__ctor_m0621B589247DA8D6F0BEA24C5FC134480F08C34D_RuntimeMethod_var);
		return;
	}
}
// System.Void UnityEngine.Networking.SyncListInt::SerializeItem(UnityEngine.Networking.NetworkWriter,System.Int32)
extern "C" IL2CPP_METHOD_ATTR void SyncListInt_SerializeItem_m1EFF7C4A718410B997D459D3F7B814AB079817A7 (SyncListInt_t983DECC70C3DF63128B79CC3F65E9153AC31E91C * __this, NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * ___writer0, int32_t ___item1, const RuntimeMethod* method)
{
	{
		NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * L_0 = ___writer0;
		int32_t L_1 = ___item1;
		NullCheck(L_0);
		NetworkWriter_WritePackedUInt32_mB6C5E298454EA701B12AD8A4AE29BCEF4B4C1532(L_0, L_1, /*hidden argument*/NULL);
		return;
	}
}
// System.Int32 UnityEngine.Networking.SyncListInt::DeserializeItem(UnityEngine.Networking.NetworkReader)
extern "C" IL2CPP_METHOD_ATTR int32_t SyncListInt_DeserializeItem_m2EFE9B328517046A396D10A63C4742A4E861AD80 (SyncListInt_t983DECC70C3DF63128B79CC3F65E9153AC31E91C * __this, NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * ___reader0, const RuntimeMethod* method)
{
	int32_t V_0 = 0;
	{
		NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * L_0 = ___reader0;
		NullCheck(L_0);
		uint32_t L_1 = NetworkReader_ReadPackedUInt32_m89366E6F099C10A68B35DA5BAF6287C5C0A3F2B8(L_0, /*hidden argument*/NULL);
		V_0 = L_1;
		goto IL_000d;
	}

IL_000d:
	{
		int32_t L_2 = V_0;
		return L_2;
	}
}
// UnityEngine.Networking.SyncListInt UnityEngine.Networking.SyncListInt::ReadInstance(UnityEngine.Networking.NetworkReader)
extern "C" IL2CPP_METHOD_ATTR SyncListInt_t983DECC70C3DF63128B79CC3F65E9153AC31E91C * SyncListInt_ReadInstance_mC5D254D6BCF6AE56A077FB2C765E49BD8544B7B3 (NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * ___reader0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SyncListInt_ReadInstance_mC5D254D6BCF6AE56A077FB2C765E49BD8544B7B3_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	uint16_t V_0 = 0;
	SyncListInt_t983DECC70C3DF63128B79CC3F65E9153AC31E91C * V_1 = NULL;
	uint16_t V_2 = 0;
	SyncListInt_t983DECC70C3DF63128B79CC3F65E9153AC31E91C * V_3 = NULL;
	{
		NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * L_0 = ___reader0;
		NullCheck(L_0);
		uint16_t L_1 = NetworkReader_ReadUInt16_m7658B3C3B70B33A4B7BFB0E385D7FC6BE3AA0608(L_0, /*hidden argument*/NULL);
		V_0 = L_1;
		SyncListInt_t983DECC70C3DF63128B79CC3F65E9153AC31E91C * L_2 = (SyncListInt_t983DECC70C3DF63128B79CC3F65E9153AC31E91C *)il2cpp_codegen_object_new(SyncListInt_t983DECC70C3DF63128B79CC3F65E9153AC31E91C_il2cpp_TypeInfo_var);
		SyncListInt__ctor_m7C40E1815DE1B26F03960F291E1AC823FF9B2074(L_2, /*hidden argument*/NULL);
		V_1 = L_2;
		V_2 = (uint16_t)0;
		goto IL_0028;
	}

IL_0015:
	{
		SyncListInt_t983DECC70C3DF63128B79CC3F65E9153AC31E91C * L_3 = V_1;
		NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * L_4 = ___reader0;
		NullCheck(L_4);
		uint32_t L_5 = NetworkReader_ReadPackedUInt32_m89366E6F099C10A68B35DA5BAF6287C5C0A3F2B8(L_4, /*hidden argument*/NULL);
		NullCheck(L_3);
		SyncList_1_AddInternal_mDFCBDA7FC93AEC328AD072BB6BDBB707A0748FC3(L_3, L_5, /*hidden argument*/SyncList_1_AddInternal_mDFCBDA7FC93AEC328AD072BB6BDBB707A0748FC3_RuntimeMethod_var);
		uint16_t L_6 = V_2;
		V_2 = (uint16_t)(((int32_t)((uint16_t)((int32_t)il2cpp_codegen_add((int32_t)L_6, (int32_t)1)))));
	}

IL_0028:
	{
		uint16_t L_7 = V_2;
		uint16_t L_8 = V_0;
		if ((((int32_t)L_7) < ((int32_t)L_8)))
		{
			goto IL_0015;
		}
	}
	{
		SyncListInt_t983DECC70C3DF63128B79CC3F65E9153AC31E91C * L_9 = V_1;
		V_3 = L_9;
		goto IL_0036;
	}

IL_0036:
	{
		SyncListInt_t983DECC70C3DF63128B79CC3F65E9153AC31E91C * L_10 = V_3;
		return L_10;
	}
}
// System.Void UnityEngine.Networking.SyncListInt::ReadReference(UnityEngine.Networking.NetworkReader,UnityEngine.Networking.SyncListInt)
extern "C" IL2CPP_METHOD_ATTR void SyncListInt_ReadReference_m3BE6DC095D913B6DE87F56AC593C71D86AF36E13 (NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * ___reader0, SyncListInt_t983DECC70C3DF63128B79CC3F65E9153AC31E91C * ___syncList1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SyncListInt_ReadReference_m3BE6DC095D913B6DE87F56AC593C71D86AF36E13_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	uint16_t V_0 = 0;
	uint16_t V_1 = 0;
	{
		NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * L_0 = ___reader0;
		NullCheck(L_0);
		uint16_t L_1 = NetworkReader_ReadUInt16_m7658B3C3B70B33A4B7BFB0E385D7FC6BE3AA0608(L_0, /*hidden argument*/NULL);
		V_0 = L_1;
		SyncListInt_t983DECC70C3DF63128B79CC3F65E9153AC31E91C * L_2 = ___syncList1;
		NullCheck(L_2);
		SyncList_1_Clear_mD7144B94F9EAAA3B749EFA1B57157DE24CD8B23C(L_2, /*hidden argument*/SyncList_1_Clear_mD7144B94F9EAAA3B749EFA1B57157DE24CD8B23C_RuntimeMethod_var);
		V_1 = (uint16_t)0;
		goto IL_0028;
	}

IL_0015:
	{
		SyncListInt_t983DECC70C3DF63128B79CC3F65E9153AC31E91C * L_3 = ___syncList1;
		NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * L_4 = ___reader0;
		NullCheck(L_4);
		uint32_t L_5 = NetworkReader_ReadPackedUInt32_m89366E6F099C10A68B35DA5BAF6287C5C0A3F2B8(L_4, /*hidden argument*/NULL);
		NullCheck(L_3);
		SyncList_1_AddInternal_mDFCBDA7FC93AEC328AD072BB6BDBB707A0748FC3(L_3, L_5, /*hidden argument*/SyncList_1_AddInternal_mDFCBDA7FC93AEC328AD072BB6BDBB707A0748FC3_RuntimeMethod_var);
		uint16_t L_6 = V_1;
		V_1 = (uint16_t)(((int32_t)((uint16_t)((int32_t)il2cpp_codegen_add((int32_t)L_6, (int32_t)1)))));
	}

IL_0028:
	{
		uint16_t L_7 = V_1;
		uint16_t L_8 = V_0;
		if ((((int32_t)L_7) < ((int32_t)L_8)))
		{
			goto IL_0015;
		}
	}
	{
		return;
	}
}
// System.Void UnityEngine.Networking.SyncListInt::WriteInstance(UnityEngine.Networking.NetworkWriter,UnityEngine.Networking.SyncListInt)
extern "C" IL2CPP_METHOD_ATTR void SyncListInt_WriteInstance_mC3E5CCF06A7D3ED297CF51CD09BF664F7A011B9D (NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * ___writer0, SyncListInt_t983DECC70C3DF63128B79CC3F65E9153AC31E91C * ___items1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SyncListInt_WriteInstance_mC3E5CCF06A7D3ED297CF51CD09BF664F7A011B9D_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * L_0 = ___writer0;
		SyncListInt_t983DECC70C3DF63128B79CC3F65E9153AC31E91C * L_1 = ___items1;
		NullCheck(L_1);
		int32_t L_2 = SyncList_1_get_Count_m2ADDACB4181D1FA4E62543D708BC8C74371F5D32(L_1, /*hidden argument*/SyncList_1_get_Count_m2ADDACB4181D1FA4E62543D708BC8C74371F5D32_RuntimeMethod_var);
		NullCheck(L_0);
		NetworkWriter_Write_m7B4B1BA926F562D7D2FD2C58DAB509D8D9C7AACF(L_0, (uint16_t)(((int32_t)((uint16_t)L_2))), /*hidden argument*/NULL);
		V_0 = 0;
		goto IL_0028;
	}

IL_0015:
	{
		NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * L_3 = ___writer0;
		SyncListInt_t983DECC70C3DF63128B79CC3F65E9153AC31E91C * L_4 = ___items1;
		int32_t L_5 = V_0;
		NullCheck(L_4);
		int32_t L_6 = SyncList_1_get_Item_mA90ABECE21F6FB9FC65FF17CCFDD262D781B52D0(L_4, L_5, /*hidden argument*/SyncList_1_get_Item_mA90ABECE21F6FB9FC65FF17CCFDD262D781B52D0_RuntimeMethod_var);
		NullCheck(L_3);
		NetworkWriter_WritePackedUInt32_mB6C5E298454EA701B12AD8A4AE29BCEF4B4C1532(L_3, L_6, /*hidden argument*/NULL);
		int32_t L_7 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add((int32_t)L_7, (int32_t)1));
	}

IL_0028:
	{
		int32_t L_8 = V_0;
		SyncListInt_t983DECC70C3DF63128B79CC3F65E9153AC31E91C * L_9 = ___items1;
		NullCheck(L_9);
		int32_t L_10 = SyncList_1_get_Count_m2ADDACB4181D1FA4E62543D708BC8C74371F5D32(L_9, /*hidden argument*/SyncList_1_get_Count_m2ADDACB4181D1FA4E62543D708BC8C74371F5D32_RuntimeMethod_var);
		if ((((int32_t)L_8) < ((int32_t)L_10)))
		{
			goto IL_0015;
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
// System.Void UnityEngine.Networking.SyncListString::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SyncListString__ctor_m40228C5CFE34EBE1B805E8A011765A3D2809361C (SyncListString_t60A178543A04A4418DB27AEAABA7D8E224C5CCF0 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SyncListString__ctor_m40228C5CFE34EBE1B805E8A011765A3D2809361C_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		SyncList_1__ctor_mDEF6DFE7474225B062A33F15C066C73E5508D7D8(__this, /*hidden argument*/SyncList_1__ctor_mDEF6DFE7474225B062A33F15C066C73E5508D7D8_RuntimeMethod_var);
		return;
	}
}
// System.Void UnityEngine.Networking.SyncListString::SerializeItem(UnityEngine.Networking.NetworkWriter,System.String)
extern "C" IL2CPP_METHOD_ATTR void SyncListString_SerializeItem_mFCC04E8D7B1A72D065359873FFEDA93E09FF0902 (SyncListString_t60A178543A04A4418DB27AEAABA7D8E224C5CCF0 * __this, NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * ___writer0, String_t* ___item1, const RuntimeMethod* method)
{
	{
		NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * L_0 = ___writer0;
		String_t* L_1 = ___item1;
		NullCheck(L_0);
		NetworkWriter_Write_m7C72E7D3ECE798F6B0D811475E363A526B2E78EE(L_0, L_1, /*hidden argument*/NULL);
		return;
	}
}
// System.String UnityEngine.Networking.SyncListString::DeserializeItem(UnityEngine.Networking.NetworkReader)
extern "C" IL2CPP_METHOD_ATTR String_t* SyncListString_DeserializeItem_mB1ADF7F921FBFBC692897F6528083485B2704517 (SyncListString_t60A178543A04A4418DB27AEAABA7D8E224C5CCF0 * __this, NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * ___reader0, const RuntimeMethod* method)
{
	String_t* V_0 = NULL;
	{
		NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * L_0 = ___reader0;
		NullCheck(L_0);
		String_t* L_1 = NetworkReader_ReadString_m0AE36FB1124CA37666D2C4340D5397E35DAF3EA0(L_0, /*hidden argument*/NULL);
		V_0 = L_1;
		goto IL_000d;
	}

IL_000d:
	{
		String_t* L_2 = V_0;
		return L_2;
	}
}
// UnityEngine.Networking.SyncListString UnityEngine.Networking.SyncListString::ReadInstance(UnityEngine.Networking.NetworkReader)
extern "C" IL2CPP_METHOD_ATTR SyncListString_t60A178543A04A4418DB27AEAABA7D8E224C5CCF0 * SyncListString_ReadInstance_m258E8428BE0D7C24181E04B010B127E7E18FDA93 (NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * ___reader0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SyncListString_ReadInstance_m258E8428BE0D7C24181E04B010B127E7E18FDA93_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	uint16_t V_0 = 0;
	SyncListString_t60A178543A04A4418DB27AEAABA7D8E224C5CCF0 * V_1 = NULL;
	uint16_t V_2 = 0;
	SyncListString_t60A178543A04A4418DB27AEAABA7D8E224C5CCF0 * V_3 = NULL;
	{
		NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * L_0 = ___reader0;
		NullCheck(L_0);
		uint16_t L_1 = NetworkReader_ReadUInt16_m7658B3C3B70B33A4B7BFB0E385D7FC6BE3AA0608(L_0, /*hidden argument*/NULL);
		V_0 = L_1;
		SyncListString_t60A178543A04A4418DB27AEAABA7D8E224C5CCF0 * L_2 = (SyncListString_t60A178543A04A4418DB27AEAABA7D8E224C5CCF0 *)il2cpp_codegen_object_new(SyncListString_t60A178543A04A4418DB27AEAABA7D8E224C5CCF0_il2cpp_TypeInfo_var);
		SyncListString__ctor_m40228C5CFE34EBE1B805E8A011765A3D2809361C(L_2, /*hidden argument*/NULL);
		V_1 = L_2;
		V_2 = (uint16_t)0;
		goto IL_0028;
	}

IL_0015:
	{
		SyncListString_t60A178543A04A4418DB27AEAABA7D8E224C5CCF0 * L_3 = V_1;
		NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * L_4 = ___reader0;
		NullCheck(L_4);
		String_t* L_5 = NetworkReader_ReadString_m0AE36FB1124CA37666D2C4340D5397E35DAF3EA0(L_4, /*hidden argument*/NULL);
		NullCheck(L_3);
		SyncList_1_AddInternal_mB027582F168CCBF56CD4D628BE448D5844C9F80A(L_3, L_5, /*hidden argument*/SyncList_1_AddInternal_mB027582F168CCBF56CD4D628BE448D5844C9F80A_RuntimeMethod_var);
		uint16_t L_6 = V_2;
		V_2 = (uint16_t)(((int32_t)((uint16_t)((int32_t)il2cpp_codegen_add((int32_t)L_6, (int32_t)1)))));
	}

IL_0028:
	{
		uint16_t L_7 = V_2;
		uint16_t L_8 = V_0;
		if ((((int32_t)L_7) < ((int32_t)L_8)))
		{
			goto IL_0015;
		}
	}
	{
		SyncListString_t60A178543A04A4418DB27AEAABA7D8E224C5CCF0 * L_9 = V_1;
		V_3 = L_9;
		goto IL_0036;
	}

IL_0036:
	{
		SyncListString_t60A178543A04A4418DB27AEAABA7D8E224C5CCF0 * L_10 = V_3;
		return L_10;
	}
}
// System.Void UnityEngine.Networking.SyncListString::ReadReference(UnityEngine.Networking.NetworkReader,UnityEngine.Networking.SyncListString)
extern "C" IL2CPP_METHOD_ATTR void SyncListString_ReadReference_m89E0E9B55F87EA04987CC55094778F08C417C9E3 (NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * ___reader0, SyncListString_t60A178543A04A4418DB27AEAABA7D8E224C5CCF0 * ___syncList1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SyncListString_ReadReference_m89E0E9B55F87EA04987CC55094778F08C417C9E3_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	uint16_t V_0 = 0;
	uint16_t V_1 = 0;
	{
		NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * L_0 = ___reader0;
		NullCheck(L_0);
		uint16_t L_1 = NetworkReader_ReadUInt16_m7658B3C3B70B33A4B7BFB0E385D7FC6BE3AA0608(L_0, /*hidden argument*/NULL);
		V_0 = L_1;
		SyncListString_t60A178543A04A4418DB27AEAABA7D8E224C5CCF0 * L_2 = ___syncList1;
		NullCheck(L_2);
		SyncList_1_Clear_mA3628B737C052F7946F55AB625CAED61652DC83A(L_2, /*hidden argument*/SyncList_1_Clear_mA3628B737C052F7946F55AB625CAED61652DC83A_RuntimeMethod_var);
		V_1 = (uint16_t)0;
		goto IL_0028;
	}

IL_0015:
	{
		SyncListString_t60A178543A04A4418DB27AEAABA7D8E224C5CCF0 * L_3 = ___syncList1;
		NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * L_4 = ___reader0;
		NullCheck(L_4);
		String_t* L_5 = NetworkReader_ReadString_m0AE36FB1124CA37666D2C4340D5397E35DAF3EA0(L_4, /*hidden argument*/NULL);
		NullCheck(L_3);
		SyncList_1_AddInternal_mB027582F168CCBF56CD4D628BE448D5844C9F80A(L_3, L_5, /*hidden argument*/SyncList_1_AddInternal_mB027582F168CCBF56CD4D628BE448D5844C9F80A_RuntimeMethod_var);
		uint16_t L_6 = V_1;
		V_1 = (uint16_t)(((int32_t)((uint16_t)((int32_t)il2cpp_codegen_add((int32_t)L_6, (int32_t)1)))));
	}

IL_0028:
	{
		uint16_t L_7 = V_1;
		uint16_t L_8 = V_0;
		if ((((int32_t)L_7) < ((int32_t)L_8)))
		{
			goto IL_0015;
		}
	}
	{
		return;
	}
}
// System.Void UnityEngine.Networking.SyncListString::WriteInstance(UnityEngine.Networking.NetworkWriter,UnityEngine.Networking.SyncListString)
extern "C" IL2CPP_METHOD_ATTR void SyncListString_WriteInstance_mE8B283C13B8E8A55730AD1F8072266E45F68AD9C (NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * ___writer0, SyncListString_t60A178543A04A4418DB27AEAABA7D8E224C5CCF0 * ___items1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SyncListString_WriteInstance_mE8B283C13B8E8A55730AD1F8072266E45F68AD9C_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * L_0 = ___writer0;
		SyncListString_t60A178543A04A4418DB27AEAABA7D8E224C5CCF0 * L_1 = ___items1;
		NullCheck(L_1);
		int32_t L_2 = SyncList_1_get_Count_mBFD13B7B0896759864013263CC517D1E50FA1C03(L_1, /*hidden argument*/SyncList_1_get_Count_mBFD13B7B0896759864013263CC517D1E50FA1C03_RuntimeMethod_var);
		NullCheck(L_0);
		NetworkWriter_Write_m7B4B1BA926F562D7D2FD2C58DAB509D8D9C7AACF(L_0, (uint16_t)(((int32_t)((uint16_t)L_2))), /*hidden argument*/NULL);
		V_0 = 0;
		goto IL_0028;
	}

IL_0015:
	{
		NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * L_3 = ___writer0;
		SyncListString_t60A178543A04A4418DB27AEAABA7D8E224C5CCF0 * L_4 = ___items1;
		int32_t L_5 = V_0;
		NullCheck(L_4);
		String_t* L_6 = SyncList_1_get_Item_m44091CDDCB00A7A165E3AA3DA56CD7A30F0F5877(L_4, L_5, /*hidden argument*/SyncList_1_get_Item_m44091CDDCB00A7A165E3AA3DA56CD7A30F0F5877_RuntimeMethod_var);
		NullCheck(L_3);
		NetworkWriter_Write_m7C72E7D3ECE798F6B0D811475E363A526B2E78EE(L_3, L_6, /*hidden argument*/NULL);
		int32_t L_7 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add((int32_t)L_7, (int32_t)1));
	}

IL_0028:
	{
		int32_t L_8 = V_0;
		SyncListString_t60A178543A04A4418DB27AEAABA7D8E224C5CCF0 * L_9 = ___items1;
		NullCheck(L_9);
		int32_t L_10 = SyncList_1_get_Count_mBFD13B7B0896759864013263CC517D1E50FA1C03(L_9, /*hidden argument*/SyncList_1_get_Count_mBFD13B7B0896759864013263CC517D1E50FA1C03_RuntimeMethod_var);
		if ((((int32_t)L_8) < ((int32_t)L_10)))
		{
			goto IL_0015;
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
// System.Void UnityEngine.Networking.SyncListUInt::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SyncListUInt__ctor_m12DC8C5F857A8BD4AB16591B2E097AFE8B037549 (SyncListUInt_t07AD639C74DD935A6A0A498026B4BD89A222A2B9 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SyncListUInt__ctor_m12DC8C5F857A8BD4AB16591B2E097AFE8B037549_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		SyncList_1__ctor_m9BD7FD9E27578465E832618C449AC896BE95E6E7(__this, /*hidden argument*/SyncList_1__ctor_m9BD7FD9E27578465E832618C449AC896BE95E6E7_RuntimeMethod_var);
		return;
	}
}
// System.Void UnityEngine.Networking.SyncListUInt::SerializeItem(UnityEngine.Networking.NetworkWriter,System.UInt32)
extern "C" IL2CPP_METHOD_ATTR void SyncListUInt_SerializeItem_mDA55C1999FC1D48B797A29A459086EF483941C9F (SyncListUInt_t07AD639C74DD935A6A0A498026B4BD89A222A2B9 * __this, NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * ___writer0, uint32_t ___item1, const RuntimeMethod* method)
{
	{
		NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * L_0 = ___writer0;
		uint32_t L_1 = ___item1;
		NullCheck(L_0);
		NetworkWriter_WritePackedUInt32_mB6C5E298454EA701B12AD8A4AE29BCEF4B4C1532(L_0, L_1, /*hidden argument*/NULL);
		return;
	}
}
// System.UInt32 UnityEngine.Networking.SyncListUInt::DeserializeItem(UnityEngine.Networking.NetworkReader)
extern "C" IL2CPP_METHOD_ATTR uint32_t SyncListUInt_DeserializeItem_mCBD304A30CBEFFEF4AE0DC3D175A2BE67718B0B1 (SyncListUInt_t07AD639C74DD935A6A0A498026B4BD89A222A2B9 * __this, NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * ___reader0, const RuntimeMethod* method)
{
	uint32_t V_0 = 0;
	{
		NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * L_0 = ___reader0;
		NullCheck(L_0);
		uint32_t L_1 = NetworkReader_ReadPackedUInt32_m89366E6F099C10A68B35DA5BAF6287C5C0A3F2B8(L_0, /*hidden argument*/NULL);
		V_0 = L_1;
		goto IL_000d;
	}

IL_000d:
	{
		uint32_t L_2 = V_0;
		return L_2;
	}
}
// UnityEngine.Networking.SyncListUInt UnityEngine.Networking.SyncListUInt::ReadInstance(UnityEngine.Networking.NetworkReader)
extern "C" IL2CPP_METHOD_ATTR SyncListUInt_t07AD639C74DD935A6A0A498026B4BD89A222A2B9 * SyncListUInt_ReadInstance_m2A353CA5F8E70C4AC78FCA15BD49B6D7E6BFBB20 (NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * ___reader0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SyncListUInt_ReadInstance_m2A353CA5F8E70C4AC78FCA15BD49B6D7E6BFBB20_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	uint16_t V_0 = 0;
	SyncListUInt_t07AD639C74DD935A6A0A498026B4BD89A222A2B9 * V_1 = NULL;
	uint16_t V_2 = 0;
	SyncListUInt_t07AD639C74DD935A6A0A498026B4BD89A222A2B9 * V_3 = NULL;
	{
		NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * L_0 = ___reader0;
		NullCheck(L_0);
		uint16_t L_1 = NetworkReader_ReadUInt16_m7658B3C3B70B33A4B7BFB0E385D7FC6BE3AA0608(L_0, /*hidden argument*/NULL);
		V_0 = L_1;
		SyncListUInt_t07AD639C74DD935A6A0A498026B4BD89A222A2B9 * L_2 = (SyncListUInt_t07AD639C74DD935A6A0A498026B4BD89A222A2B9 *)il2cpp_codegen_object_new(SyncListUInt_t07AD639C74DD935A6A0A498026B4BD89A222A2B9_il2cpp_TypeInfo_var);
		SyncListUInt__ctor_m12DC8C5F857A8BD4AB16591B2E097AFE8B037549(L_2, /*hidden argument*/NULL);
		V_1 = L_2;
		V_2 = (uint16_t)0;
		goto IL_0028;
	}

IL_0015:
	{
		SyncListUInt_t07AD639C74DD935A6A0A498026B4BD89A222A2B9 * L_3 = V_1;
		NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * L_4 = ___reader0;
		NullCheck(L_4);
		uint32_t L_5 = NetworkReader_ReadPackedUInt32_m89366E6F099C10A68B35DA5BAF6287C5C0A3F2B8(L_4, /*hidden argument*/NULL);
		NullCheck(L_3);
		SyncList_1_AddInternal_m778318507B8DC58EA01286B69E8D1232F3A4309D(L_3, L_5, /*hidden argument*/SyncList_1_AddInternal_m778318507B8DC58EA01286B69E8D1232F3A4309D_RuntimeMethod_var);
		uint16_t L_6 = V_2;
		V_2 = (uint16_t)(((int32_t)((uint16_t)((int32_t)il2cpp_codegen_add((int32_t)L_6, (int32_t)1)))));
	}

IL_0028:
	{
		uint16_t L_7 = V_2;
		uint16_t L_8 = V_0;
		if ((((int32_t)L_7) < ((int32_t)L_8)))
		{
			goto IL_0015;
		}
	}
	{
		SyncListUInt_t07AD639C74DD935A6A0A498026B4BD89A222A2B9 * L_9 = V_1;
		V_3 = L_9;
		goto IL_0036;
	}

IL_0036:
	{
		SyncListUInt_t07AD639C74DD935A6A0A498026B4BD89A222A2B9 * L_10 = V_3;
		return L_10;
	}
}
// System.Void UnityEngine.Networking.SyncListUInt::ReadReference(UnityEngine.Networking.NetworkReader,UnityEngine.Networking.SyncListUInt)
extern "C" IL2CPP_METHOD_ATTR void SyncListUInt_ReadReference_m273B2EEEF69D9D8F6BF34334CF6CB250674003FA (NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * ___reader0, SyncListUInt_t07AD639C74DD935A6A0A498026B4BD89A222A2B9 * ___syncList1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SyncListUInt_ReadReference_m273B2EEEF69D9D8F6BF34334CF6CB250674003FA_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	uint16_t V_0 = 0;
	uint16_t V_1 = 0;
	{
		NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * L_0 = ___reader0;
		NullCheck(L_0);
		uint16_t L_1 = NetworkReader_ReadUInt16_m7658B3C3B70B33A4B7BFB0E385D7FC6BE3AA0608(L_0, /*hidden argument*/NULL);
		V_0 = L_1;
		SyncListUInt_t07AD639C74DD935A6A0A498026B4BD89A222A2B9 * L_2 = ___syncList1;
		NullCheck(L_2);
		SyncList_1_Clear_mB73C836DB01C1A8E9E57A7825CB6685D9ABC3C27(L_2, /*hidden argument*/SyncList_1_Clear_mB73C836DB01C1A8E9E57A7825CB6685D9ABC3C27_RuntimeMethod_var);
		V_1 = (uint16_t)0;
		goto IL_0028;
	}

IL_0015:
	{
		SyncListUInt_t07AD639C74DD935A6A0A498026B4BD89A222A2B9 * L_3 = ___syncList1;
		NetworkReader_t7AA956F248BAA72DA3A7A91F1DBD1DCD10072173 * L_4 = ___reader0;
		NullCheck(L_4);
		uint32_t L_5 = NetworkReader_ReadPackedUInt32_m89366E6F099C10A68B35DA5BAF6287C5C0A3F2B8(L_4, /*hidden argument*/NULL);
		NullCheck(L_3);
		SyncList_1_AddInternal_m778318507B8DC58EA01286B69E8D1232F3A4309D(L_3, L_5, /*hidden argument*/SyncList_1_AddInternal_m778318507B8DC58EA01286B69E8D1232F3A4309D_RuntimeMethod_var);
		uint16_t L_6 = V_1;
		V_1 = (uint16_t)(((int32_t)((uint16_t)((int32_t)il2cpp_codegen_add((int32_t)L_6, (int32_t)1)))));
	}

IL_0028:
	{
		uint16_t L_7 = V_1;
		uint16_t L_8 = V_0;
		if ((((int32_t)L_7) < ((int32_t)L_8)))
		{
			goto IL_0015;
		}
	}
	{
		return;
	}
}
// System.Void UnityEngine.Networking.SyncListUInt::WriteInstance(UnityEngine.Networking.NetworkWriter,UnityEngine.Networking.SyncListUInt)
extern "C" IL2CPP_METHOD_ATTR void SyncListUInt_WriteInstance_m1EE5BFD6B9A80C59E05EDF9C818ED5DAED967FB1 (NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * ___writer0, SyncListUInt_t07AD639C74DD935A6A0A498026B4BD89A222A2B9 * ___items1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SyncListUInt_WriteInstance_m1EE5BFD6B9A80C59E05EDF9C818ED5DAED967FB1_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * L_0 = ___writer0;
		SyncListUInt_t07AD639C74DD935A6A0A498026B4BD89A222A2B9 * L_1 = ___items1;
		NullCheck(L_1);
		int32_t L_2 = SyncList_1_get_Count_m3F7E989F3BB9E1AC489A24126B8F9CECF8F66A73(L_1, /*hidden argument*/SyncList_1_get_Count_m3F7E989F3BB9E1AC489A24126B8F9CECF8F66A73_RuntimeMethod_var);
		NullCheck(L_0);
		NetworkWriter_Write_m7B4B1BA926F562D7D2FD2C58DAB509D8D9C7AACF(L_0, (uint16_t)(((int32_t)((uint16_t)L_2))), /*hidden argument*/NULL);
		V_0 = 0;
		goto IL_0028;
	}

IL_0015:
	{
		NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * L_3 = ___writer0;
		SyncListUInt_t07AD639C74DD935A6A0A498026B4BD89A222A2B9 * L_4 = ___items1;
		int32_t L_5 = V_0;
		NullCheck(L_4);
		uint32_t L_6 = SyncList_1_get_Item_mF15B67FFBE3107CD3CC0F540BE68CE60FE5F6D44(L_4, L_5, /*hidden argument*/SyncList_1_get_Item_mF15B67FFBE3107CD3CC0F540BE68CE60FE5F6D44_RuntimeMethod_var);
		NullCheck(L_3);
		NetworkWriter_WritePackedUInt32_mB6C5E298454EA701B12AD8A4AE29BCEF4B4C1532(L_3, L_6, /*hidden argument*/NULL);
		int32_t L_7 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add((int32_t)L_7, (int32_t)1));
	}

IL_0028:
	{
		int32_t L_8 = V_0;
		SyncListUInt_t07AD639C74DD935A6A0A498026B4BD89A222A2B9 * L_9 = ___items1;
		NullCheck(L_9);
		int32_t L_10 = SyncList_1_get_Count_m3F7E989F3BB9E1AC489A24126B8F9CECF8F66A73(L_9, /*hidden argument*/SyncList_1_get_Count_m3F7E989F3BB9E1AC489A24126B8F9CECF8F66A73_RuntimeMethod_var);
		if ((((int32_t)L_8) < ((int32_t)L_10)))
		{
			goto IL_0015;
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
// System.Void UnityEngine.Networking.SyncVarAttribute::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SyncVarAttribute__ctor_m66F9C5AA09E3D11E42225BD6E4690F1399EE00E9 (SyncVarAttribute_t9F652FDE52D8EEA95040A1BED1DDDE54939FBA83 * __this, const RuntimeMethod* method)
{
	{
		Attribute__ctor_m45CAD4B01265CC84CC5A84F62EE2DBE85DE89EC0(__this, /*hidden argument*/NULL);
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
// System.Void UnityEngine.Networking.TargetRpcAttribute::.ctor()
extern "C" IL2CPP_METHOD_ATTR void TargetRpcAttribute__ctor_mDEEDE10E8DAA4F8455FDD84C48E2C109B3A17965 (TargetRpcAttribute_t25BFBC0FF05FDE98CBF816FD2B0ED7FD275AD1FE * __this, const RuntimeMethod* method)
{
	{
		__this->set_channel_0(0);
		Attribute__ctor_m45CAD4B01265CC84CC5A84F62EE2DBE85DE89EC0(__this, /*hidden argument*/NULL);
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
// System.Void UnityEngine.Networking.ULocalConnectionToClient::.ctor(UnityEngine.Networking.LocalClient)
extern "C" IL2CPP_METHOD_ATTR void ULocalConnectionToClient__ctor_mAC4885FC07B8FD7C5E1BB17B942CB23ABCD20540 (ULocalConnectionToClient_t270486B97F92181CBD9C89E72E7D9D0BF9100AB0 * __this, LocalClient_t71A1C7B4DA47285F6F6970F60F1624C62DEB0ACD * ___localClient0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (ULocalConnectionToClient__ctor_mAC4885FC07B8FD7C5E1BB17B942CB23ABCD20540_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		NetworkConnection__ctor_m46DC560CC3D18779639B2F2201ED9C4B4F37DF66(__this, /*hidden argument*/NULL);
		((NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632 *)__this)->set_address_14(_stringLiteral0C84AC39FC120C1E579C09FEAA062CA04994E08F);
		LocalClient_t71A1C7B4DA47285F6F6970F60F1624C62DEB0ACD * L_0 = ___localClient0;
		__this->set_m_LocalClient_19(L_0);
		return;
	}
}
// UnityEngine.Networking.LocalClient UnityEngine.Networking.ULocalConnectionToClient::get_localClient()
extern "C" IL2CPP_METHOD_ATTR LocalClient_t71A1C7B4DA47285F6F6970F60F1624C62DEB0ACD * ULocalConnectionToClient_get_localClient_mA1D98F334462E2F322740919B8F42109B74FBCDB (ULocalConnectionToClient_t270486B97F92181CBD9C89E72E7D9D0BF9100AB0 * __this, const RuntimeMethod* method)
{
	LocalClient_t71A1C7B4DA47285F6F6970F60F1624C62DEB0ACD * V_0 = NULL;
	{
		LocalClient_t71A1C7B4DA47285F6F6970F60F1624C62DEB0ACD * L_0 = __this->get_m_LocalClient_19();
		V_0 = L_0;
		goto IL_000d;
	}

IL_000d:
	{
		LocalClient_t71A1C7B4DA47285F6F6970F60F1624C62DEB0ACD * L_1 = V_0;
		return L_1;
	}
}
// System.Boolean UnityEngine.Networking.ULocalConnectionToClient::Send(System.Int16,UnityEngine.Networking.MessageBase)
extern "C" IL2CPP_METHOD_ATTR bool ULocalConnectionToClient_Send_m137A9350D4EEF4831F8C4679A59AA8C000DD4EF0 (ULocalConnectionToClient_t270486B97F92181CBD9C89E72E7D9D0BF9100AB0 * __this, int16_t ___msgType0, MessageBase_tAAFE9A29B9F4BDD2AFDB6135902A007560820C93 * ___msg1, const RuntimeMethod* method)
{
	bool V_0 = false;
	{
		LocalClient_t71A1C7B4DA47285F6F6970F60F1624C62DEB0ACD * L_0 = __this->get_m_LocalClient_19();
		int16_t L_1 = ___msgType0;
		MessageBase_tAAFE9A29B9F4BDD2AFDB6135902A007560820C93 * L_2 = ___msg1;
		NullCheck(L_0);
		LocalClient_InvokeHandlerOnClient_mA5F8585DC0BDC7508EB3BEF98208EDAAD5595B03(L_0, L_1, L_2, 0, /*hidden argument*/NULL);
		V_0 = (bool)1;
		goto IL_0016;
	}

IL_0016:
	{
		bool L_3 = V_0;
		return L_3;
	}
}
// System.Boolean UnityEngine.Networking.ULocalConnectionToClient::SendUnreliable(System.Int16,UnityEngine.Networking.MessageBase)
extern "C" IL2CPP_METHOD_ATTR bool ULocalConnectionToClient_SendUnreliable_mD7728C4A80C63F20B6A1D024A3F825B6AE6B3390 (ULocalConnectionToClient_t270486B97F92181CBD9C89E72E7D9D0BF9100AB0 * __this, int16_t ___msgType0, MessageBase_tAAFE9A29B9F4BDD2AFDB6135902A007560820C93 * ___msg1, const RuntimeMethod* method)
{
	bool V_0 = false;
	{
		LocalClient_t71A1C7B4DA47285F6F6970F60F1624C62DEB0ACD * L_0 = __this->get_m_LocalClient_19();
		int16_t L_1 = ___msgType0;
		MessageBase_tAAFE9A29B9F4BDD2AFDB6135902A007560820C93 * L_2 = ___msg1;
		NullCheck(L_0);
		LocalClient_InvokeHandlerOnClient_mA5F8585DC0BDC7508EB3BEF98208EDAAD5595B03(L_0, L_1, L_2, 1, /*hidden argument*/NULL);
		V_0 = (bool)1;
		goto IL_0016;
	}

IL_0016:
	{
		bool L_3 = V_0;
		return L_3;
	}
}
// System.Boolean UnityEngine.Networking.ULocalConnectionToClient::SendByChannel(System.Int16,UnityEngine.Networking.MessageBase,System.Int32)
extern "C" IL2CPP_METHOD_ATTR bool ULocalConnectionToClient_SendByChannel_m3747E290050DE4D7F4BD900DEACA4C0FF2A725D7 (ULocalConnectionToClient_t270486B97F92181CBD9C89E72E7D9D0BF9100AB0 * __this, int16_t ___msgType0, MessageBase_tAAFE9A29B9F4BDD2AFDB6135902A007560820C93 * ___msg1, int32_t ___channelId2, const RuntimeMethod* method)
{
	bool V_0 = false;
	{
		LocalClient_t71A1C7B4DA47285F6F6970F60F1624C62DEB0ACD * L_0 = __this->get_m_LocalClient_19();
		int16_t L_1 = ___msgType0;
		MessageBase_tAAFE9A29B9F4BDD2AFDB6135902A007560820C93 * L_2 = ___msg1;
		int32_t L_3 = ___channelId2;
		NullCheck(L_0);
		LocalClient_InvokeHandlerOnClient_mA5F8585DC0BDC7508EB3BEF98208EDAAD5595B03(L_0, L_1, L_2, L_3, /*hidden argument*/NULL);
		V_0 = (bool)1;
		goto IL_0016;
	}

IL_0016:
	{
		bool L_4 = V_0;
		return L_4;
	}
}
// System.Boolean UnityEngine.Networking.ULocalConnectionToClient::SendBytes(System.Byte[],System.Int32,System.Int32)
extern "C" IL2CPP_METHOD_ATTR bool ULocalConnectionToClient_SendBytes_m3142228BAACC227FCBE4EDB6CDF49676E2AC8C4A (ULocalConnectionToClient_t270486B97F92181CBD9C89E72E7D9D0BF9100AB0 * __this, ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___bytes0, int32_t ___numBytes1, int32_t ___channelId2, const RuntimeMethod* method)
{
	bool V_0 = false;
	{
		LocalClient_t71A1C7B4DA47285F6F6970F60F1624C62DEB0ACD * L_0 = __this->get_m_LocalClient_19();
		ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* L_1 = ___bytes0;
		int32_t L_2 = ___channelId2;
		NullCheck(L_0);
		LocalClient_InvokeBytesOnClient_mB6FFA5459DB60E83265A3287292420D9A992511A(L_0, L_1, L_2, /*hidden argument*/NULL);
		V_0 = (bool)1;
		goto IL_0015;
	}

IL_0015:
	{
		bool L_3 = V_0;
		return L_3;
	}
}
// System.Boolean UnityEngine.Networking.ULocalConnectionToClient::SendWriter(UnityEngine.Networking.NetworkWriter,System.Int32)
extern "C" IL2CPP_METHOD_ATTR bool ULocalConnectionToClient_SendWriter_m40C07A3D7959BF668CD248651BCA737B4579EE6D (ULocalConnectionToClient_t270486B97F92181CBD9C89E72E7D9D0BF9100AB0 * __this, NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * ___writer0, int32_t ___channelId1, const RuntimeMethod* method)
{
	bool V_0 = false;
	{
		LocalClient_t71A1C7B4DA47285F6F6970F60F1624C62DEB0ACD * L_0 = __this->get_m_LocalClient_19();
		NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * L_1 = ___writer0;
		NullCheck(L_1);
		ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* L_2 = NetworkWriter_AsArray_m99ED1AA7647B87ACAB80A9BAFD0C9A7913845D32(L_1, /*hidden argument*/NULL);
		int32_t L_3 = ___channelId1;
		NullCheck(L_0);
		LocalClient_InvokeBytesOnClient_mB6FFA5459DB60E83265A3287292420D9A992511A(L_0, L_2, L_3, /*hidden argument*/NULL);
		V_0 = (bool)1;
		goto IL_001a;
	}

IL_001a:
	{
		bool L_4 = V_0;
		return L_4;
	}
}
// System.Void UnityEngine.Networking.ULocalConnectionToClient::GetStatsOut(System.Int32U26,System.Int32U26,System.Int32U26,System.Int32U26)
extern "C" IL2CPP_METHOD_ATTR void ULocalConnectionToClient_GetStatsOut_m88351F39BF3C30244ED450BBF5FA48AD29E2A571 (ULocalConnectionToClient_t270486B97F92181CBD9C89E72E7D9D0BF9100AB0 * __this, int32_t* ___numMsgs0, int32_t* ___numBufferedMsgs1, int32_t* ___numBytes2, int32_t* ___lastBufferedPerSecond3, const RuntimeMethod* method)
{
	{
		int32_t* L_0 = ___numMsgs0;
		*((int32_t*)L_0) = (int32_t)0;
		int32_t* L_1 = ___numBufferedMsgs1;
		*((int32_t*)L_1) = (int32_t)0;
		int32_t* L_2 = ___numBytes2;
		*((int32_t*)L_2) = (int32_t)0;
		int32_t* L_3 = ___lastBufferedPerSecond3;
		*((int32_t*)L_3) = (int32_t)0;
		return;
	}
}
// System.Void UnityEngine.Networking.ULocalConnectionToClient::GetStatsIn(System.Int32U26,System.Int32U26)
extern "C" IL2CPP_METHOD_ATTR void ULocalConnectionToClient_GetStatsIn_m2620D6DDDE5A35FA6F21CF6C3FF42D709960CD12 (ULocalConnectionToClient_t270486B97F92181CBD9C89E72E7D9D0BF9100AB0 * __this, int32_t* ___numMsgs0, int32_t* ___numBytes1, const RuntimeMethod* method)
{
	{
		int32_t* L_0 = ___numMsgs0;
		*((int32_t*)L_0) = (int32_t)0;
		int32_t* L_1 = ___numBytes1;
		*((int32_t*)L_1) = (int32_t)0;
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
// System.Void UnityEngine.Networking.ULocalConnectionToServer::.ctor(UnityEngine.Networking.NetworkServer)
extern "C" IL2CPP_METHOD_ATTR void ULocalConnectionToServer__ctor_m8370756937F61813D5891A6DEC55A65F9E1D6B1D (ULocalConnectionToServer_tAEFE862DB3377D88819D6799DADC10C89D4C19AA * __this, NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08 * ___localServer0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (ULocalConnectionToServer__ctor_m8370756937F61813D5891A6DEC55A65F9E1D6B1D_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		NetworkConnection__ctor_m46DC560CC3D18779639B2F2201ED9C4B4F37DF66(__this, /*hidden argument*/NULL);
		((NetworkConnection_tC00D92CEDB25DBEE926BBC4B45BCE182A5675632 *)__this)->set_address_14(_stringLiteral8A90E4187AA462FD7BCD9E2521B1C4F09372DBAF);
		NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08 * L_0 = ___localServer0;
		__this->set_m_LocalServer_19(L_0);
		return;
	}
}
// System.Boolean UnityEngine.Networking.ULocalConnectionToServer::Send(System.Int16,UnityEngine.Networking.MessageBase)
extern "C" IL2CPP_METHOD_ATTR bool ULocalConnectionToServer_Send_m1AFEFB238D5D5D7D0EBB00D55206145ED7ABCE67 (ULocalConnectionToServer_tAEFE862DB3377D88819D6799DADC10C89D4C19AA * __this, int16_t ___msgType0, MessageBase_tAAFE9A29B9F4BDD2AFDB6135902A007560820C93 * ___msg1, const RuntimeMethod* method)
{
	bool V_0 = false;
	{
		NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08 * L_0 = __this->get_m_LocalServer_19();
		int16_t L_1 = ___msgType0;
		MessageBase_tAAFE9A29B9F4BDD2AFDB6135902A007560820C93 * L_2 = ___msg1;
		NullCheck(L_0);
		bool L_3 = NetworkServer_InvokeHandlerOnServer_m59281A60BF922D55EF91B931FDE478AFC4BDED7A(L_0, __this, L_1, L_2, 0, /*hidden argument*/NULL);
		V_0 = L_3;
		goto IL_0016;
	}

IL_0016:
	{
		bool L_4 = V_0;
		return L_4;
	}
}
// System.Boolean UnityEngine.Networking.ULocalConnectionToServer::SendUnreliable(System.Int16,UnityEngine.Networking.MessageBase)
extern "C" IL2CPP_METHOD_ATTR bool ULocalConnectionToServer_SendUnreliable_m11521AD1BBDE2D1CE07ADB9046101DC55F9959CE (ULocalConnectionToServer_tAEFE862DB3377D88819D6799DADC10C89D4C19AA * __this, int16_t ___msgType0, MessageBase_tAAFE9A29B9F4BDD2AFDB6135902A007560820C93 * ___msg1, const RuntimeMethod* method)
{
	bool V_0 = false;
	{
		NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08 * L_0 = __this->get_m_LocalServer_19();
		int16_t L_1 = ___msgType0;
		MessageBase_tAAFE9A29B9F4BDD2AFDB6135902A007560820C93 * L_2 = ___msg1;
		NullCheck(L_0);
		bool L_3 = NetworkServer_InvokeHandlerOnServer_m59281A60BF922D55EF91B931FDE478AFC4BDED7A(L_0, __this, L_1, L_2, 1, /*hidden argument*/NULL);
		V_0 = L_3;
		goto IL_0016;
	}

IL_0016:
	{
		bool L_4 = V_0;
		return L_4;
	}
}
// System.Boolean UnityEngine.Networking.ULocalConnectionToServer::SendByChannel(System.Int16,UnityEngine.Networking.MessageBase,System.Int32)
extern "C" IL2CPP_METHOD_ATTR bool ULocalConnectionToServer_SendByChannel_m4BAD6C95E0B9DB0139551C3B36D5B156E31C517E (ULocalConnectionToServer_tAEFE862DB3377D88819D6799DADC10C89D4C19AA * __this, int16_t ___msgType0, MessageBase_tAAFE9A29B9F4BDD2AFDB6135902A007560820C93 * ___msg1, int32_t ___channelId2, const RuntimeMethod* method)
{
	bool V_0 = false;
	{
		NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08 * L_0 = __this->get_m_LocalServer_19();
		int16_t L_1 = ___msgType0;
		MessageBase_tAAFE9A29B9F4BDD2AFDB6135902A007560820C93 * L_2 = ___msg1;
		int32_t L_3 = ___channelId2;
		NullCheck(L_0);
		bool L_4 = NetworkServer_InvokeHandlerOnServer_m59281A60BF922D55EF91B931FDE478AFC4BDED7A(L_0, __this, L_1, L_2, L_3, /*hidden argument*/NULL);
		V_0 = L_4;
		goto IL_0016;
	}

IL_0016:
	{
		bool L_5 = V_0;
		return L_5;
	}
}
// System.Boolean UnityEngine.Networking.ULocalConnectionToServer::SendBytes(System.Byte[],System.Int32,System.Int32)
extern "C" IL2CPP_METHOD_ATTR bool ULocalConnectionToServer_SendBytes_mB1AEBEA8E225F14284848487789D1D642FF10CCE (ULocalConnectionToServer_tAEFE862DB3377D88819D6799DADC10C89D4C19AA * __this, ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___bytes0, int32_t ___numBytes1, int32_t ___channelId2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (ULocalConnectionToServer_SendBytes_mB1AEBEA8E225F14284848487789D1D642FF10CCE_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	{
		int32_t L_0 = ___numBytes1;
		if ((((int32_t)L_0) > ((int32_t)0)))
		{
			goto IL_0026;
		}
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(LogFilter_t7F5DC717851FC49ACAA3C288FEF0ECAE0E9589E2_il2cpp_TypeInfo_var);
		bool L_1 = LogFilter_get_logError_mFA7FB0106EF4A5833829D37D63072EF7FD60C1A9(/*hidden argument*/NULL);
		if (!L_1)
		{
			goto IL_001f;
		}
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t7B5FCB117E2FD63B6838BC52821B252E2BFB61C4_il2cpp_TypeInfo_var);
		Debug_LogError_m3BCF9B78263152261565DCA9DB7D55F0C391ED29(_stringLiteral13F4B303180B12CAF8F069E93D7C4FAF969D3BC4, /*hidden argument*/NULL);
	}

IL_001f:
	{
		V_0 = (bool)0;
		goto IL_003b;
	}

IL_0026:
	{
		NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08 * L_2 = __this->get_m_LocalServer_19();
		ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* L_3 = ___bytes0;
		int32_t L_4 = ___numBytes1;
		int32_t L_5 = ___channelId2;
		NullCheck(L_2);
		bool L_6 = NetworkServer_InvokeBytes_m95C4388BDBDD256C9D129E82560E6D3CD2BDDB3B(L_2, __this, L_3, L_4, L_5, /*hidden argument*/NULL);
		V_0 = L_6;
		goto IL_003b;
	}

IL_003b:
	{
		bool L_7 = V_0;
		return L_7;
	}
}
// System.Boolean UnityEngine.Networking.ULocalConnectionToServer::SendWriter(UnityEngine.Networking.NetworkWriter,System.Int32)
extern "C" IL2CPP_METHOD_ATTR bool ULocalConnectionToServer_SendWriter_m52EF8B5443A00CE4A7BE18A7F80FC894E8EEB8AC (ULocalConnectionToServer_tAEFE862DB3377D88819D6799DADC10C89D4C19AA * __this, NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * ___writer0, int32_t ___channelId1, const RuntimeMethod* method)
{
	bool V_0 = false;
	{
		NetworkServer_t7853DBCA77A6C479067BF35ADD08A40320C90B08 * L_0 = __this->get_m_LocalServer_19();
		NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * L_1 = ___writer0;
		NullCheck(L_1);
		ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* L_2 = NetworkWriter_AsArray_m99ED1AA7647B87ACAB80A9BAFD0C9A7913845D32(L_1, /*hidden argument*/NULL);
		NetworkWriter_tD88D576C5A1634D9755F462ADB7484AA5BEAC231 * L_3 = ___writer0;
		NullCheck(L_3);
		ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* L_4 = NetworkWriter_AsArray_m99ED1AA7647B87ACAB80A9BAFD0C9A7913845D32(L_3, /*hidden argument*/NULL);
		NullCheck(L_4);
		int32_t L_5 = ___channelId1;
		NullCheck(L_0);
		bool L_6 = NetworkServer_InvokeBytes_m95C4388BDBDD256C9D129E82560E6D3CD2BDDB3B(L_0, __this, L_2, (((int16_t)((int16_t)(((int32_t)((int32_t)(((RuntimeArray *)L_4)->max_length))))))), L_5, /*hidden argument*/NULL);
		V_0 = L_6;
		goto IL_0023;
	}

IL_0023:
	{
		bool L_7 = V_0;
		return L_7;
	}
}
// System.Void UnityEngine.Networking.ULocalConnectionToServer::GetStatsOut(System.Int32U26,System.Int32U26,System.Int32U26,System.Int32U26)
extern "C" IL2CPP_METHOD_ATTR void ULocalConnectionToServer_GetStatsOut_m5E64D0EEAD4F55FE1EBC97916774239F4C4AE2D8 (ULocalConnectionToServer_tAEFE862DB3377D88819D6799DADC10C89D4C19AA * __this, int32_t* ___numMsgs0, int32_t* ___numBufferedMsgs1, int32_t* ___numBytes2, int32_t* ___lastBufferedPerSecond3, const RuntimeMethod* method)
{
	{
		int32_t* L_0 = ___numMsgs0;
		*((int32_t*)L_0) = (int32_t)0;
		int32_t* L_1 = ___numBufferedMsgs1;
		*((int32_t*)L_1) = (int32_t)0;
		int32_t* L_2 = ___numBytes2;
		*((int32_t*)L_2) = (int32_t)0;
		int32_t* L_3 = ___lastBufferedPerSecond3;
		*((int32_t*)L_3) = (int32_t)0;
		return;
	}
}
// System.Void UnityEngine.Networking.ULocalConnectionToServer::GetStatsIn(System.Int32U26,System.Int32U26)
extern "C" IL2CPP_METHOD_ATTR void ULocalConnectionToServer_GetStatsIn_m1E481119225E978400885A9DCA5FE79316908A5C (ULocalConnectionToServer_tAEFE862DB3377D88819D6799DADC10C89D4C19AA * __this, int32_t* ___numMsgs0, int32_t* ___numBytes1, const RuntimeMethod* method)
{
	{
		int32_t* L_0 = ___numMsgs0;
		*((int32_t*)L_0) = (int32_t)0;
		int32_t* L_1 = ___numBytes1;
		*((int32_t*)L_1) = (int32_t)0;
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
// System.Void UnityEngine.Networking.UnSpawnDelegate::.ctor(System.Object,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR void UnSpawnDelegate__ctor_m60CE7B69BD8765577BF8ED1A30FAE2D9A24E93CA (UnSpawnDelegate_t82FEE1FA0B957BFC00EFF737B34478C3ABBD04BD * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method)
{
	__this->set_method_ptr_0(il2cpp_codegen_get_method_pointer((RuntimeMethod*)___method1));
	__this->set_method_3(___method1);
	__this->set_m_target_2(___object0);
}
// System.Void UnityEngine.Networking.UnSpawnDelegate::Invoke(UnityEngine.GameObject)
extern "C" IL2CPP_METHOD_ATTR void UnSpawnDelegate_Invoke_m2A14C7E79ECFBB7C2B9C8A5D7EC0DFAB9F1F99BB (UnSpawnDelegate_t82FEE1FA0B957BFC00EFF737B34478C3ABBD04BD * __this, GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * ___spawned0, const RuntimeMethod* method)
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
				if (___parameterCount == 1)
				{
					// open
					typedef void (*FunctionPointerType) (GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F *, const RuntimeMethod*);
					((FunctionPointerType)targetMethodPointer)(___spawned0, targetMethod);
				}
				else
				{
					// closed
					typedef void (*FunctionPointerType) (void*, GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F *, const RuntimeMethod*);
					((FunctionPointerType)targetMethodPointer)(targetThis, ___spawned0, targetMethod);
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
								GenericInterfaceActionInvoker0::Invoke(targetMethod, ___spawned0);
							else
								GenericVirtActionInvoker0::Invoke(targetMethod, ___spawned0);
						}
						else
						{
							if (il2cpp_codegen_method_is_interface_method(targetMethod))
								InterfaceActionInvoker0::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), ___spawned0);
							else
								VirtActionInvoker0::Invoke(il2cpp_codegen_method_get_slot(targetMethod), ___spawned0);
						}
					}
				}
				else
				{
					typedef void (*FunctionPointerType) (GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F *, const RuntimeMethod*);
					((FunctionPointerType)targetMethodPointer)(___spawned0, targetMethod);
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
							typedef void (*FunctionPointerType) (GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F *, const RuntimeMethod*);
							((FunctionPointerType)targetMethodPointer)(___spawned0, targetMethod);
						}
						else if (il2cpp_codegen_method_is_generic_instance(targetMethod))
						{
							if (il2cpp_codegen_method_is_interface_method(targetMethod))
								GenericInterfaceActionInvoker1< GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * >::Invoke(targetMethod, targetThis, ___spawned0);
							else
								GenericVirtActionInvoker1< GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * >::Invoke(targetMethod, targetThis, ___spawned0);
						}
						else
						{
							if (il2cpp_codegen_method_is_interface_method(targetMethod))
								InterfaceActionInvoker1< GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), targetThis, ___spawned0);
							else
								VirtActionInvoker1< GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), targetThis, ___spawned0);
						}
					}
				}
				else
				{
					typedef void (*FunctionPointerType) (void*, GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F *, const RuntimeMethod*);
					((FunctionPointerType)targetMethodPointer)(targetThis, ___spawned0, targetMethod);
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
				typedef void (*FunctionPointerType) (GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F *, const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(___spawned0, targetMethod);
			}
			else
			{
				// closed
				typedef void (*FunctionPointerType) (void*, GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F *, const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(targetThis, ___spawned0, targetMethod);
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
							GenericInterfaceActionInvoker0::Invoke(targetMethod, ___spawned0);
						else
							GenericVirtActionInvoker0::Invoke(targetMethod, ___spawned0);
					}
					else
					{
						if (il2cpp_codegen_method_is_interface_method(targetMethod))
							InterfaceActionInvoker0::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), ___spawned0);
						else
							VirtActionInvoker0::Invoke(il2cpp_codegen_method_get_slot(targetMethod), ___spawned0);
					}
				}
			}
			else
			{
				typedef void (*FunctionPointerType) (GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F *, const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(___spawned0, targetMethod);
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
						typedef void (*FunctionPointerType) (GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F *, const RuntimeMethod*);
						((FunctionPointerType)targetMethodPointer)(___spawned0, targetMethod);
					}
					else if (il2cpp_codegen_method_is_generic_instance(targetMethod))
					{
						if (il2cpp_codegen_method_is_interface_method(targetMethod))
							GenericInterfaceActionInvoker1< GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * >::Invoke(targetMethod, targetThis, ___spawned0);
						else
							GenericVirtActionInvoker1< GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * >::Invoke(targetMethod, targetThis, ___spawned0);
					}
					else
					{
						if (il2cpp_codegen_method_is_interface_method(targetMethod))
							InterfaceActionInvoker1< GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), targetThis, ___spawned0);
						else
							VirtActionInvoker1< GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), targetThis, ___spawned0);
					}
				}
			}
			else
			{
				typedef void (*FunctionPointerType) (void*, GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F *, const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(targetThis, ___spawned0, targetMethod);
			}
		}
	}
}
// System.IAsyncResult UnityEngine.Networking.UnSpawnDelegate::BeginInvoke(UnityEngine.GameObject,System.AsyncCallback,System.Object)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject* UnSpawnDelegate_BeginInvoke_mEC16D85B211785BD83B4439657BB68A873BC3EF3 (UnSpawnDelegate_t82FEE1FA0B957BFC00EFF737B34478C3ABBD04BD * __this, GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * ___spawned0, AsyncCallback_t3F3DA3BEDAEE81DD1D24125DF8EB30E85EE14DA4 * ___callback1, RuntimeObject * ___object2, const RuntimeMethod* method)
{
	void *__d_args[2] = {0};
	__d_args[0] = ___spawned0;
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback1, (RuntimeObject*)___object2);
}
// System.Void UnityEngine.Networking.UnSpawnDelegate::EndInvoke(System.IAsyncResult)
extern "C" IL2CPP_METHOD_ATTR void UnSpawnDelegate_EndInvoke_mE56C15D6D16CC3DE8B01A4ED5CDB6731765D0BE0 (UnSpawnDelegate_t82FEE1FA0B957BFC00EFF737B34478C3ABBD04BD * __this, RuntimeObject* ___result0, const RuntimeMethod* method)
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
