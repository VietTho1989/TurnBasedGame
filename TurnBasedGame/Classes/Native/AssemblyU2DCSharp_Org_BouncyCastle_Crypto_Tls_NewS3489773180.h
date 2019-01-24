#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.NewSessionTicket
struct  NewSessionTicket_t3489773180  : public Il2CppObject
{
public:
	// System.Int64 Org.BouncyCastle.Crypto.Tls.NewSessionTicket::mTicketLifetimeHint
	int64_t ___mTicketLifetimeHint_0;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.NewSessionTicket::mTicket
	ByteU5BU5D_t3397334013* ___mTicket_1;

public:
	inline static int32_t get_offset_of_mTicketLifetimeHint_0() { return static_cast<int32_t>(offsetof(NewSessionTicket_t3489773180, ___mTicketLifetimeHint_0)); }
	inline int64_t get_mTicketLifetimeHint_0() const { return ___mTicketLifetimeHint_0; }
	inline int64_t* get_address_of_mTicketLifetimeHint_0() { return &___mTicketLifetimeHint_0; }
	inline void set_mTicketLifetimeHint_0(int64_t value)
	{
		___mTicketLifetimeHint_0 = value;
	}

	inline static int32_t get_offset_of_mTicket_1() { return static_cast<int32_t>(offsetof(NewSessionTicket_t3489773180, ___mTicket_1)); }
	inline ByteU5BU5D_t3397334013* get_mTicket_1() const { return ___mTicket_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_mTicket_1() { return &___mTicket_1; }
	inline void set_mTicket_1(ByteU5BU5D_t3397334013* value)
	{
		___mTicket_1 = value;
		Il2CppCodeGenWriteBarrier(&___mTicket_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
