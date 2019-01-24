//
//  endgame.hpp
//  Shatranj
//
//  Created by Viet Tho on 7/7/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef shatranj_endgame_hpp
#define shatranj_endgame_hpp

#include <stdio.h>
#include <map>
#include <memory>
#include <string>
#include <type_traits>
#include <utility>

#include "shatranj_position.hpp"
#include "shatranj_types.hpp"

namespace Shatranj
{
    /// EndgameCode lists all supported endgame functions by corresponding codes
    
    enum EndgameCode {
        
        EVALUATION_FUNCTIONS,
        KRKP,  // KR vs KP
        KRKB,  // KR vs KB
        KRKN,  // KR vs KN
        KNKB,  // KN vs KB
        KQKP,  // KQ vs KP
        KRKQ,  // KR vs KQ
        KPKP,  // KP vs KP
        KQQKQ,  // KQQ vs KQ
        
        SCALING_FUNCTIONS,
        KRPKR,   // KRP vs KR
        KRPPKRP, // KRPP vs KRP
        KBPKB,   // KBP vs KB
        KBPPKB,  // KBPP vs KB
        KBPKN,   // KBP vs KN
        KNPKB    // KNP vs KB
    };
    
    
    /// Endgame functions can be of two types depending on whether they return a
    /// Value or a ScaleFactor.
    template<EndgameCode E> using
    eg_type = typename std::conditional<(E < SCALING_FUNCTIONS), Value, ScaleFactor>::type;
    
    
    /// Base and derived functors for endgame evaluation and scaling functions
    
    template<typename T>
    struct EndgameBase {
        
        explicit EndgameBase(Color c) : strongSide(c), weakSide(~c) {}
        virtual ~EndgameBase() = default;
        virtual T operator()(const Position&) const = 0;
        
        const Color strongSide, weakSide;
    };
    
    
    template<EndgameCode E, typename T = eg_type<E>>
    struct Endgame : public EndgameBase<T> {
        
        explicit Endgame(Color c) : EndgameBase<T>(c) {}
        T operator()(const Position&) const override;
    };
    
    
    /// The Endgames class stores the pointers to endgame evaluation and scaling
    /// base objects in two std::map. We use polymorphism to invoke the actual
    /// endgame function by calling its virtual operator().
    
    class Endgames {
        
        template<typename T> using Ptr = std::unique_ptr<EndgameBase<T>>;
        template<typename T> using Map = std::map<Key, Ptr<T>>;
        
        template<typename T>
        Map<T>& map() {
            return std::get<std::is_same<T, ScaleFactor>::value>(maps);
        }
        
        template<EndgameCode E, typename T = eg_type<E>, typename P = Ptr<T>>
        void add(const std::string& code) {
            
            StateInfo st;
            map<T>()[Position().set(code, WHITE, &st).material_key()] = P(new Endgame<E>(WHITE));
            map<T>()[Position().set(code, BLACK, &st).material_key()] = P(new Endgame<E>(BLACK));
        }
        
        std::pair<Map<Value>, Map<ScaleFactor>> maps;
        
    public:
        Endgames();
        
        template<typename T>
        EndgameBase<T>* probe(Key key) {
            return map<T>().count(key) ? map<T>()[key].get() : nullptr;
        }
    };
}

#endif /* endgame_hpp */
