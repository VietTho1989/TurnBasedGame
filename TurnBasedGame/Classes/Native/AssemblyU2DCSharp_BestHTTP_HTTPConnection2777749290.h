#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_BestHTTP_ConnectionBase2782190729.h"

// BestHTTP.PlatformSupport.TcpClient.General.TcpClient
struct TcpClient_t4173427386;
// System.IO.Stream
struct Stream_t3255436806;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.HTTPConnection
struct  HTTPConnection_t2777749290  : public ConnectionBase_t2782190729
{
public:
	// BestHTTP.PlatformSupport.TcpClient.General.TcpClient BestHTTP.HTTPConnection::Client
	TcpClient_t4173427386 * ___Client_11;
	// System.IO.Stream BestHTTP.HTTPConnection::Stream
	Stream_t3255436806 * ___Stream_12;

public:
	inline static int32_t get_offset_of_Client_11() { return static_cast<int32_t>(offsetof(HTTPConnection_t2777749290, ___Client_11)); }
	inline TcpClient_t4173427386 * get_Client_11() const { return ___Client_11; }
	inline TcpClient_t4173427386 ** get_address_of_Client_11() { return &___Client_11; }
	inline void set_Client_11(TcpClient_t4173427386 * value)
	{
		___Client_11 = value;
		Il2CppCodeGenWriteBarrier(&___Client_11, value);
	}

	inline static int32_t get_offset_of_Stream_12() { return static_cast<int32_t>(offsetof(HTTPConnection_t2777749290, ___Stream_12)); }
	inline Stream_t3255436806 * get_Stream_12() const { return ___Stream_12; }
	inline Stream_t3255436806 ** get_address_of_Stream_12() { return &___Stream_12; }
	inline void set_Stream_12(Stream_t3255436806 * value)
	{
		___Stream_12 = value;
		Il2CppCodeGenWriteBarrier(&___Stream_12, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
