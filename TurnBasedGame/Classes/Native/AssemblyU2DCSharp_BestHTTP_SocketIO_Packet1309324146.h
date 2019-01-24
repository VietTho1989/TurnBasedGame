#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "AssemblyU2DCSharp_BestHTTP_SocketIO_TransportEvent2410498534.h"
#include "AssemblyU2DCSharp_BestHTTP_SocketIO_SocketIOEventT2290781438.h"

// System.String
struct String_t;
// System.Collections.Generic.List`1<System.Byte[]>
struct List_1_t2766455145;
// System.Object[]
struct ObjectU5BU5D_t3614634134;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.SocketIO.Packet
struct  Packet_t1309324146  : public Il2CppObject
{
public:
	// BestHTTP.SocketIO.TransportEventTypes BestHTTP.SocketIO.Packet::<TransportEvent>k__BackingField
	int32_t ___U3CTransportEventU3Ek__BackingField_1;
	// BestHTTP.SocketIO.SocketIOEventTypes BestHTTP.SocketIO.Packet::<SocketIOEvent>k__BackingField
	int32_t ___U3CSocketIOEventU3Ek__BackingField_2;
	// System.Int32 BestHTTP.SocketIO.Packet::<AttachmentCount>k__BackingField
	int32_t ___U3CAttachmentCountU3Ek__BackingField_3;
	// System.Int32 BestHTTP.SocketIO.Packet::<Id>k__BackingField
	int32_t ___U3CIdU3Ek__BackingField_4;
	// System.String BestHTTP.SocketIO.Packet::<Namespace>k__BackingField
	String_t* ___U3CNamespaceU3Ek__BackingField_5;
	// System.String BestHTTP.SocketIO.Packet::<Payload>k__BackingField
	String_t* ___U3CPayloadU3Ek__BackingField_6;
	// System.String BestHTTP.SocketIO.Packet::<EventName>k__BackingField
	String_t* ___U3CEventNameU3Ek__BackingField_7;
	// System.Collections.Generic.List`1<System.Byte[]> BestHTTP.SocketIO.Packet::attachments
	List_1_t2766455145 * ___attachments_8;
	// System.Boolean BestHTTP.SocketIO.Packet::<IsDecoded>k__BackingField
	bool ___U3CIsDecodedU3Ek__BackingField_9;
	// System.Object[] BestHTTP.SocketIO.Packet::<DecodedArgs>k__BackingField
	ObjectU5BU5D_t3614634134* ___U3CDecodedArgsU3Ek__BackingField_10;

public:
	inline static int32_t get_offset_of_U3CTransportEventU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(Packet_t1309324146, ___U3CTransportEventU3Ek__BackingField_1)); }
	inline int32_t get_U3CTransportEventU3Ek__BackingField_1() const { return ___U3CTransportEventU3Ek__BackingField_1; }
	inline int32_t* get_address_of_U3CTransportEventU3Ek__BackingField_1() { return &___U3CTransportEventU3Ek__BackingField_1; }
	inline void set_U3CTransportEventU3Ek__BackingField_1(int32_t value)
	{
		___U3CTransportEventU3Ek__BackingField_1 = value;
	}

	inline static int32_t get_offset_of_U3CSocketIOEventU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(Packet_t1309324146, ___U3CSocketIOEventU3Ek__BackingField_2)); }
	inline int32_t get_U3CSocketIOEventU3Ek__BackingField_2() const { return ___U3CSocketIOEventU3Ek__BackingField_2; }
	inline int32_t* get_address_of_U3CSocketIOEventU3Ek__BackingField_2() { return &___U3CSocketIOEventU3Ek__BackingField_2; }
	inline void set_U3CSocketIOEventU3Ek__BackingField_2(int32_t value)
	{
		___U3CSocketIOEventU3Ek__BackingField_2 = value;
	}

	inline static int32_t get_offset_of_U3CAttachmentCountU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(Packet_t1309324146, ___U3CAttachmentCountU3Ek__BackingField_3)); }
	inline int32_t get_U3CAttachmentCountU3Ek__BackingField_3() const { return ___U3CAttachmentCountU3Ek__BackingField_3; }
	inline int32_t* get_address_of_U3CAttachmentCountU3Ek__BackingField_3() { return &___U3CAttachmentCountU3Ek__BackingField_3; }
	inline void set_U3CAttachmentCountU3Ek__BackingField_3(int32_t value)
	{
		___U3CAttachmentCountU3Ek__BackingField_3 = value;
	}

	inline static int32_t get_offset_of_U3CIdU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(Packet_t1309324146, ___U3CIdU3Ek__BackingField_4)); }
	inline int32_t get_U3CIdU3Ek__BackingField_4() const { return ___U3CIdU3Ek__BackingField_4; }
	inline int32_t* get_address_of_U3CIdU3Ek__BackingField_4() { return &___U3CIdU3Ek__BackingField_4; }
	inline void set_U3CIdU3Ek__BackingField_4(int32_t value)
	{
		___U3CIdU3Ek__BackingField_4 = value;
	}

	inline static int32_t get_offset_of_U3CNamespaceU3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(Packet_t1309324146, ___U3CNamespaceU3Ek__BackingField_5)); }
	inline String_t* get_U3CNamespaceU3Ek__BackingField_5() const { return ___U3CNamespaceU3Ek__BackingField_5; }
	inline String_t** get_address_of_U3CNamespaceU3Ek__BackingField_5() { return &___U3CNamespaceU3Ek__BackingField_5; }
	inline void set_U3CNamespaceU3Ek__BackingField_5(String_t* value)
	{
		___U3CNamespaceU3Ek__BackingField_5 = value;
		Il2CppCodeGenWriteBarrier(&___U3CNamespaceU3Ek__BackingField_5, value);
	}

	inline static int32_t get_offset_of_U3CPayloadU3Ek__BackingField_6() { return static_cast<int32_t>(offsetof(Packet_t1309324146, ___U3CPayloadU3Ek__BackingField_6)); }
	inline String_t* get_U3CPayloadU3Ek__BackingField_6() const { return ___U3CPayloadU3Ek__BackingField_6; }
	inline String_t** get_address_of_U3CPayloadU3Ek__BackingField_6() { return &___U3CPayloadU3Ek__BackingField_6; }
	inline void set_U3CPayloadU3Ek__BackingField_6(String_t* value)
	{
		___U3CPayloadU3Ek__BackingField_6 = value;
		Il2CppCodeGenWriteBarrier(&___U3CPayloadU3Ek__BackingField_6, value);
	}

	inline static int32_t get_offset_of_U3CEventNameU3Ek__BackingField_7() { return static_cast<int32_t>(offsetof(Packet_t1309324146, ___U3CEventNameU3Ek__BackingField_7)); }
	inline String_t* get_U3CEventNameU3Ek__BackingField_7() const { return ___U3CEventNameU3Ek__BackingField_7; }
	inline String_t** get_address_of_U3CEventNameU3Ek__BackingField_7() { return &___U3CEventNameU3Ek__BackingField_7; }
	inline void set_U3CEventNameU3Ek__BackingField_7(String_t* value)
	{
		___U3CEventNameU3Ek__BackingField_7 = value;
		Il2CppCodeGenWriteBarrier(&___U3CEventNameU3Ek__BackingField_7, value);
	}

	inline static int32_t get_offset_of_attachments_8() { return static_cast<int32_t>(offsetof(Packet_t1309324146, ___attachments_8)); }
	inline List_1_t2766455145 * get_attachments_8() const { return ___attachments_8; }
	inline List_1_t2766455145 ** get_address_of_attachments_8() { return &___attachments_8; }
	inline void set_attachments_8(List_1_t2766455145 * value)
	{
		___attachments_8 = value;
		Il2CppCodeGenWriteBarrier(&___attachments_8, value);
	}

	inline static int32_t get_offset_of_U3CIsDecodedU3Ek__BackingField_9() { return static_cast<int32_t>(offsetof(Packet_t1309324146, ___U3CIsDecodedU3Ek__BackingField_9)); }
	inline bool get_U3CIsDecodedU3Ek__BackingField_9() const { return ___U3CIsDecodedU3Ek__BackingField_9; }
	inline bool* get_address_of_U3CIsDecodedU3Ek__BackingField_9() { return &___U3CIsDecodedU3Ek__BackingField_9; }
	inline void set_U3CIsDecodedU3Ek__BackingField_9(bool value)
	{
		___U3CIsDecodedU3Ek__BackingField_9 = value;
	}

	inline static int32_t get_offset_of_U3CDecodedArgsU3Ek__BackingField_10() { return static_cast<int32_t>(offsetof(Packet_t1309324146, ___U3CDecodedArgsU3Ek__BackingField_10)); }
	inline ObjectU5BU5D_t3614634134* get_U3CDecodedArgsU3Ek__BackingField_10() const { return ___U3CDecodedArgsU3Ek__BackingField_10; }
	inline ObjectU5BU5D_t3614634134** get_address_of_U3CDecodedArgsU3Ek__BackingField_10() { return &___U3CDecodedArgsU3Ek__BackingField_10; }
	inline void set_U3CDecodedArgsU3Ek__BackingField_10(ObjectU5BU5D_t3614634134* value)
	{
		___U3CDecodedArgsU3Ek__BackingField_10 = value;
		Il2CppCodeGenWriteBarrier(&___U3CDecodedArgsU3Ek__BackingField_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
