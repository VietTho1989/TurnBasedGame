#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Net.CookieCollection
struct CookieCollection_t521422364;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Net.CookieContainer
struct  CookieContainer_t2808809223  : public Il2CppObject
{
public:
	// System.Int32 System.Net.CookieContainer::capacity
	int32_t ___capacity_0;
	// System.Int32 System.Net.CookieContainer::perDomainCapacity
	int32_t ___perDomainCapacity_1;
	// System.Int32 System.Net.CookieContainer::maxCookieSize
	int32_t ___maxCookieSize_2;
	// System.Net.CookieCollection System.Net.CookieContainer::cookies
	CookieCollection_t521422364 * ___cookies_3;

public:
	inline static int32_t get_offset_of_capacity_0() { return static_cast<int32_t>(offsetof(CookieContainer_t2808809223, ___capacity_0)); }
	inline int32_t get_capacity_0() const { return ___capacity_0; }
	inline int32_t* get_address_of_capacity_0() { return &___capacity_0; }
	inline void set_capacity_0(int32_t value)
	{
		___capacity_0 = value;
	}

	inline static int32_t get_offset_of_perDomainCapacity_1() { return static_cast<int32_t>(offsetof(CookieContainer_t2808809223, ___perDomainCapacity_1)); }
	inline int32_t get_perDomainCapacity_1() const { return ___perDomainCapacity_1; }
	inline int32_t* get_address_of_perDomainCapacity_1() { return &___perDomainCapacity_1; }
	inline void set_perDomainCapacity_1(int32_t value)
	{
		___perDomainCapacity_1 = value;
	}

	inline static int32_t get_offset_of_maxCookieSize_2() { return static_cast<int32_t>(offsetof(CookieContainer_t2808809223, ___maxCookieSize_2)); }
	inline int32_t get_maxCookieSize_2() const { return ___maxCookieSize_2; }
	inline int32_t* get_address_of_maxCookieSize_2() { return &___maxCookieSize_2; }
	inline void set_maxCookieSize_2(int32_t value)
	{
		___maxCookieSize_2 = value;
	}

	inline static int32_t get_offset_of_cookies_3() { return static_cast<int32_t>(offsetof(CookieContainer_t2808809223, ___cookies_3)); }
	inline CookieCollection_t521422364 * get_cookies_3() const { return ___cookies_3; }
	inline CookieCollection_t521422364 ** get_address_of_cookies_3() { return &___cookies_3; }
	inline void set_cookies_3(CookieCollection_t521422364 * value)
	{
		___cookies_3 = value;
		Il2CppCodeGenWriteBarrier(&___cookies_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
