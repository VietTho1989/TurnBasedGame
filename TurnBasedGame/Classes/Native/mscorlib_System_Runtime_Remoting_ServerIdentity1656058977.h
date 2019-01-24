#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Runtime_Remoting_Identity3647548000.h"

// System.Type
struct Type_t;
// System.MarshalByRefObject
struct MarshalByRefObject_t1285298191;
// System.Runtime.Remoting.Messaging.IMessageSink
struct IMessageSink_t2189618969;
// System.Runtime.Remoting.Contexts.Context
struct Context_t502196753;
// System.Runtime.Remoting.Lifetime.Lease
struct Lease_t3663008028;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Runtime.Remoting.ServerIdentity
struct  ServerIdentity_t1656058977  : public Identity_t3647548000
{
public:
	// System.Type System.Runtime.Remoting.ServerIdentity::_objectType
	Type_t * ____objectType_7;
	// System.MarshalByRefObject System.Runtime.Remoting.ServerIdentity::_serverObject
	MarshalByRefObject_t1285298191 * ____serverObject_8;
	// System.Runtime.Remoting.Messaging.IMessageSink System.Runtime.Remoting.ServerIdentity::_serverSink
	Il2CppObject * ____serverSink_9;
	// System.Runtime.Remoting.Contexts.Context System.Runtime.Remoting.ServerIdentity::_context
	Context_t502196753 * ____context_10;
	// System.Runtime.Remoting.Lifetime.Lease System.Runtime.Remoting.ServerIdentity::_lease
	Lease_t3663008028 * ____lease_11;

public:
	inline static int32_t get_offset_of__objectType_7() { return static_cast<int32_t>(offsetof(ServerIdentity_t1656058977, ____objectType_7)); }
	inline Type_t * get__objectType_7() const { return ____objectType_7; }
	inline Type_t ** get_address_of__objectType_7() { return &____objectType_7; }
	inline void set__objectType_7(Type_t * value)
	{
		____objectType_7 = value;
		Il2CppCodeGenWriteBarrier(&____objectType_7, value);
	}

	inline static int32_t get_offset_of__serverObject_8() { return static_cast<int32_t>(offsetof(ServerIdentity_t1656058977, ____serverObject_8)); }
	inline MarshalByRefObject_t1285298191 * get__serverObject_8() const { return ____serverObject_8; }
	inline MarshalByRefObject_t1285298191 ** get_address_of__serverObject_8() { return &____serverObject_8; }
	inline void set__serverObject_8(MarshalByRefObject_t1285298191 * value)
	{
		____serverObject_8 = value;
		Il2CppCodeGenWriteBarrier(&____serverObject_8, value);
	}

	inline static int32_t get_offset_of__serverSink_9() { return static_cast<int32_t>(offsetof(ServerIdentity_t1656058977, ____serverSink_9)); }
	inline Il2CppObject * get__serverSink_9() const { return ____serverSink_9; }
	inline Il2CppObject ** get_address_of__serverSink_9() { return &____serverSink_9; }
	inline void set__serverSink_9(Il2CppObject * value)
	{
		____serverSink_9 = value;
		Il2CppCodeGenWriteBarrier(&____serverSink_9, value);
	}

	inline static int32_t get_offset_of__context_10() { return static_cast<int32_t>(offsetof(ServerIdentity_t1656058977, ____context_10)); }
	inline Context_t502196753 * get__context_10() const { return ____context_10; }
	inline Context_t502196753 ** get_address_of__context_10() { return &____context_10; }
	inline void set__context_10(Context_t502196753 * value)
	{
		____context_10 = value;
		Il2CppCodeGenWriteBarrier(&____context_10, value);
	}

	inline static int32_t get_offset_of__lease_11() { return static_cast<int32_t>(offsetof(ServerIdentity_t1656058977, ____lease_11)); }
	inline Lease_t3663008028 * get__lease_11() const { return ____lease_11; }
	inline Lease_t3663008028 ** get_address_of__lease_11() { return &____lease_11; }
	inline void set__lease_11(Lease_t3663008028 * value)
	{
		____lease_11 = value;
		Il2CppCodeGenWriteBarrier(&____lease_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
