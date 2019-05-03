//
//  random.cpp
//  weiqi
//
//  Created by Viet Tho on 3/26/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <stdio.h>

#include "weiqi_random.hpp"

namespace weiqi
{
    /* Simple Park-Miller for floating point; LCG as used in glibc and other places */
    
    
    /********************************************************************************************/
#ifdef _WIN32
    
    // bo static
    int32_t tls_index = -1;
    
    void random_init(void)
    {
        tls_index = TlsAlloc();
        fast_srandom(29264);
    }
    
    void fast_srandom(uint64_t seed_)
    {
        TlsSetValue(tls_index, (void*)(intptr_t)seed_);
    }
    
    uint64_t fast_getseed(void)
    {
        return (uint64_t)(intptr_t)TlsGetValue(tls_index);
    }
    
    uint16_t fast_random(uint32_t max)
    {
        uint64_t pmseed = fast_getseed();
        pmseed = ((pmseed * 1103515245) + 12345) & 0x7fffffff;
        fast_srandom(pmseed);
        return ((pmseed & 0xffff) * max) >> 16;
    }
    
    
#else
    
    
    /********************************************************************************************/
/*#ifndef NO_THREAD_LOCAL
    
    static __thread uint64_t pmseed = 29264;
    
    void fast_srandom(uint64_t seed_)
    {
        pmseed = seed_;
    }
    
    uint64_t fast_getseed(void)
    {
        return pmseed;
    }
    
    uint16_t fast_random(uint32_t max)
    {
        pmseed = ((pmseed * 1103515245) + 12345) & 0x7fffffff;
        return ((pmseed & 0xffff) * max) >> 16;
    }
    
    float fast_frandom(void)
    {
        union { uint64_t ul; floating_t f; } p;
        p.ul = (((pmseed *= 16807) & 0x007fffff) - 1) | 0x3f800000;
        return p.f - 1.0f;
    }
    
#else*/
    
    
    /********************************************************************************************/
    
    /* Thread local storage not supported through __thread,
     * use pthread_getspecific() instead. */
    
#include <pthread.h>
    
    static pthread_key_t seed_key;
    
    void random_init(void)
    {
        pthread_key_create(&seed_key, NULL);
        fast_srandom(29264UL);
    }
    
    void fast_srandom(uint64_t seed_)
    {
        pthread_setspecific(seed_key, (void *)seed_);
    }
    
    uint64_t fast_getseed(void)
    {
        return (uint64_t)pthread_getspecific(seed_key);
    }
    
    /*uint16_t fast_random(uint32_t max)
    {
        uint64_t pmseed = (uint64_t)pthread_getspecific(seed_key);
        pmseed = ((pmseed * 1103515245) + 12345) & 0x7fffffff;
        pthread_setspecific(seed_key, (void *)pmseed);
        uint16_t ret = ((pmseed & 0xffff) * max) >> 16;
        printf("fast_random: %d, %d\n", ret, max);
        return ret;
    }*/
    
    float fast_frandom(void)
    {
        /* Construct (1,2) IEEE floating_t from our random integer */
        /* http://rgba.org/articles/sfrand/sfrand.htm */
        uint64_t pmseed = (uint64_t)pthread_getspecific(seed_key);
        pmseed *= 16807;
        union { uint64_t ul; floating_t f; } p;
        p.ul = ((pmseed & 0x007fffff) - 1) | 0x3f800000;
        pthread_setspecific(seed_key, (void *)pmseed);
        return p.f - 1.0f;
    }
    
#endif
}

//#endif
