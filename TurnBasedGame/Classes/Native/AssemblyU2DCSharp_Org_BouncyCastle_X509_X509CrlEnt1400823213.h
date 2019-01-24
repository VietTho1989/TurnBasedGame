#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_X509_X509Extens1429324694.h"

// Org.BouncyCastle.Asn1.X509.CrlEntry
struct CrlEntry_t4200172927;
// Org.BouncyCastle.Asn1.X509.X509Name
struct X509Name_t2936077305;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.X509.X509CrlEntry
struct  X509CrlEntry_t1400823213  : public X509ExtensionBase_t1429324694
{
public:
	// Org.BouncyCastle.Asn1.X509.CrlEntry Org.BouncyCastle.X509.X509CrlEntry::c
	CrlEntry_t4200172927 * ___c_0;
	// System.Boolean Org.BouncyCastle.X509.X509CrlEntry::isIndirect
	bool ___isIndirect_1;
	// Org.BouncyCastle.Asn1.X509.X509Name Org.BouncyCastle.X509.X509CrlEntry::previousCertificateIssuer
	X509Name_t2936077305 * ___previousCertificateIssuer_2;
	// Org.BouncyCastle.Asn1.X509.X509Name Org.BouncyCastle.X509.X509CrlEntry::certificateIssuer
	X509Name_t2936077305 * ___certificateIssuer_3;

public:
	inline static int32_t get_offset_of_c_0() { return static_cast<int32_t>(offsetof(X509CrlEntry_t1400823213, ___c_0)); }
	inline CrlEntry_t4200172927 * get_c_0() const { return ___c_0; }
	inline CrlEntry_t4200172927 ** get_address_of_c_0() { return &___c_0; }
	inline void set_c_0(CrlEntry_t4200172927 * value)
	{
		___c_0 = value;
		Il2CppCodeGenWriteBarrier(&___c_0, value);
	}

	inline static int32_t get_offset_of_isIndirect_1() { return static_cast<int32_t>(offsetof(X509CrlEntry_t1400823213, ___isIndirect_1)); }
	inline bool get_isIndirect_1() const { return ___isIndirect_1; }
	inline bool* get_address_of_isIndirect_1() { return &___isIndirect_1; }
	inline void set_isIndirect_1(bool value)
	{
		___isIndirect_1 = value;
	}

	inline static int32_t get_offset_of_previousCertificateIssuer_2() { return static_cast<int32_t>(offsetof(X509CrlEntry_t1400823213, ___previousCertificateIssuer_2)); }
	inline X509Name_t2936077305 * get_previousCertificateIssuer_2() const { return ___previousCertificateIssuer_2; }
	inline X509Name_t2936077305 ** get_address_of_previousCertificateIssuer_2() { return &___previousCertificateIssuer_2; }
	inline void set_previousCertificateIssuer_2(X509Name_t2936077305 * value)
	{
		___previousCertificateIssuer_2 = value;
		Il2CppCodeGenWriteBarrier(&___previousCertificateIssuer_2, value);
	}

	inline static int32_t get_offset_of_certificateIssuer_3() { return static_cast<int32_t>(offsetof(X509CrlEntry_t1400823213, ___certificateIssuer_3)); }
	inline X509Name_t2936077305 * get_certificateIssuer_3() const { return ___certificateIssuer_3; }
	inline X509Name_t2936077305 ** get_address_of_certificateIssuer_3() { return &___certificateIssuer_3; }
	inline void set_certificateIssuer_3(X509Name_t2936077305 * value)
	{
		___certificateIssuer_3 = value;
		Il2CppCodeGenWriteBarrier(&___certificateIssuer_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
