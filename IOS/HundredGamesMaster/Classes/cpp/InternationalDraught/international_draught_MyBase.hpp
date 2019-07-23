//
//  MyBase.hpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/19/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef international_draught_MyBase_hpp
#define international_draught_MyBase_hpp

#include <stdio.h>
#include <vector>
#include <mutex>
#include "international_draught_common.hpp"

namespace InternationalDraught
{
    namespace bb
    {
        // types
        
        enum Value { Draw, Loss, Win, Unknown };
        
        class Index_ {
            
            private :
            
            Index p_size;
            std::vector<uint8> p_table;
            std::vector<Index> p_index;
            
        public:
            
            bool load(const std::string & file_name, Index size);
            
            Index size ()          const { return p_size; }
            int32_t   get  (Index pos) const;
        };
        
        // base
        
        class Base {
            
        private:
            
            ID p_id;
            Index p_size;
            Index_ p_index;
            
        public:
            
            bool load(Variant_Type variantType, ID id);
            
            ID    id   () const { return p_id; }
            Index size () const { return p_size; }
            
            Value get (Index index) const { return Value(p_index.get(index)); }
        };
        
        struct MyBase
        {
            Base G_Base[ID_Size];
            
            bool init (Variant_Type variantType);
        };
        
        extern char bbPath[1024];
        extern MyBase* myBaseNormal;
        extern MyBase* myBaseKiller;
        extern MyBase* myBaseBT;
        
        extern std::mutex myBaseMutext;
        
        MyBase* getMyBase(Variant_Type variantType);
    }
}

#endif /* MyBase_hpp */
