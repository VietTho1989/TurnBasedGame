#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_System_Xml_XmlResolver2024571559.h"

// System.Net.ICredentials
struct ICredentials_t3855617113;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.XmlUrlResolver
struct  XmlUrlResolver_t896669594  : public XmlResolver_t2024571559
{
public:
	// System.Net.ICredentials System.Xml.XmlUrlResolver::credential
	Il2CppObject * ___credential_0;

public:
	inline static int32_t get_offset_of_credential_0() { return static_cast<int32_t>(offsetof(XmlUrlResolver_t896669594, ___credential_0)); }
	inline Il2CppObject * get_credential_0() const { return ___credential_0; }
	inline Il2CppObject ** get_address_of_credential_0() { return &___credential_0; }
	inline void set_credential_0(Il2CppObject * value)
	{
		___credential_0 = value;
		Il2CppCodeGenWriteBarrier(&___credential_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
