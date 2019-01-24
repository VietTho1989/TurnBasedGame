//
//  MyBase.cpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/19/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "international_draught_MyBase.hpp"
#include "international_draught_bb_index.hpp"

namespace InternationalDraught
{
    namespace bb
    {
        char bbPath[1024];
        MyBase* myBaseNormal = NULL;
        MyBase* myBaseKiller = NULL;
        MyBase* myBaseBT = NULL;
        
        std::mutex myBaseMutext;
        
        MyBase* getMyBase(Variant_Type variantType)
        {
            // get immediately
            {
                switch (variantType) {
                    case Normal:
                    {
                        if(myBaseNormal!=NULL){
                            return myBaseNormal;
                        }else{
                            // printf("myBaseNormal null\n");
                        }
                    }
                        break;
                    case Killer:
                    {
                        if(myBaseKiller!=NULL){
                            return myBaseKiller;
                        }else{
                            // printf("myBaseKiller null\n");
                        }
                    }
                        break;
                    case BT:
                    {
                        if(myBaseBT!=NULL){
                            return myBaseBT;
                        }else{
                            // printf("myBaseBT null\n");
                        }
                    }
                        break;
                    default:
                        printf("error, unknown variantType\n");
                        break;
                }
            }
            // make new
            MyBase* ret = NULL;
            myBaseMutext.lock();
            {
                // lay lai them 1 lan nua va tao moi
                switch (variantType) {
                    case Normal:
                    {
                        if(myBaseNormal!=NULL){
                            ret = myBaseNormal;
                        }else{
                            printf("make new myBaseNormal\n");
                            myBaseNormal = (MyBase*)calloc(1, sizeof(MyBase));
                            if(myBaseNormal->init(Normal)){
                                ret = myBaseNormal;
                            }else{
                                printf("myBase init normal fail\n");
                                free(myBaseNormal);
                                myBaseNormal = NULL;
                                ret = NULL;
                            }
                            
                        }
                    }
                        break;
                    case Killer:
                    {
                        if(myBaseKiller!=NULL){
                            ret = myBaseKiller;
                        }else{
                            printf("make new myBaseKiller\n");
                            myBaseKiller = (MyBase*)calloc(1, sizeof(MyBase));
                            if(myBaseKiller->init(Killer)){
                                ret = myBaseKiller;
                            }else{
                                printf("myBase init killer fail\n");
                                free(myBaseKiller);
                                myBaseKiller = NULL;
                                ret = NULL;
                            }
                            
                        }
                    }
                        break;
                    case BT:
                    {
                        if(myBaseBT!=NULL){
                            ret = myBaseBT;
                        }else{
                            printf("make new myBaseBT\n");
                            myBaseBT = (MyBase*)calloc(1, sizeof(MyBase));
                            if(myBaseBT->init(BT)){
                                ret = myBaseBT;
                            }else{
                                printf("myBaseBT init BT null\n");
                                free(myBaseBT);
                                myBaseBT = NULL;
                                ret = NULL;
                            }
                        }
                    }
                        break;
                    default:
                        printf("error, unknown variantType\n");
                        break;
                }
            }
            myBaseMutext.unlock();
            return ret;
        }
        
        bool MyBase::init(Variant_Type variantType) {
            printf("init bitbase: %d\n", ID_Size);
            for (int32_t i = 0; i < ID_Size; i++) {
                ID id = ID(i);
                if (!id_is_illegal(variantType, id) && !id_is_loss(variantType, id) && id_size(id)<=5) {
                    if(!G_Base[id].load(variantType, id)){
                        printf("myBase init fail\n");
                        return false;
                    }
                }
            }
            printf("myBase init success\n");
            return true;
        }
        
        bool Base::load(Variant_Type variantType, ID id) {
            p_id = id;
            p_size = index_size(id);
            std::string file_name = std::string(bbPath) + var::variant(variantType, "", "_killer", "_bt") + "/" + id_file(p_id);
            return p_index.load(file_name, p_size);
        }
    }
}
