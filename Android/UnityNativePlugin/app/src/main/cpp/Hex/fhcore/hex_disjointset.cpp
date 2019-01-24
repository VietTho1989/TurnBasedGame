#include <map>
#include "hex_disjointset.hpp"

namespace Hex
{
    using namespace std;
    using namespace board;
    namespace disjointset
    {
        
#define REGISTER_CREATE_BY_SIZE(container, size) do { \
container[size] = DisjointSetT<size>::create; \
} while (0)
        
        typedef IDisjointSet *(*PF_CREATE)(IBoard *);
        static map<size_t, PF_CREATE> s2t;
        
        static struct initializer
        {
            initializer();
            ~initializer() {};
        } dummy;
        
        initializer::initializer()
        {
            REGISTER_CREATE_BY_SIZE(s2t, 4);
            REGISTER_CREATE_BY_SIZE(s2t, 5);
            REGISTER_CREATE_BY_SIZE(s2t, 6);
            REGISTER_CREATE_BY_SIZE(s2t, 7);
            REGISTER_CREATE_BY_SIZE(s2t, 8);
            REGISTER_CREATE_BY_SIZE(s2t, 9);
            REGISTER_CREATE_BY_SIZE(s2t, 10);
            REGISTER_CREATE_BY_SIZE(s2t, 11);
            REGISTER_CREATE_BY_SIZE(s2t, 12);
            REGISTER_CREATE_BY_SIZE(s2t, 13);
            REGISTER_CREATE_BY_SIZE(s2t, 14);
            REGISTER_CREATE_BY_SIZE(s2t, 15);
            REGISTER_CREATE_BY_SIZE(s2t, 16);
            REGISTER_CREATE_BY_SIZE(s2t, 17);
            REGISTER_CREATE_BY_SIZE(s2t, 18);
            REGISTER_CREATE_BY_SIZE(s2t, 19);
            REGISTER_CREATE_BY_SIZE(s2t, 20);
            REGISTER_CREATE_BY_SIZE(s2t, 21);
            REGISTER_CREATE_BY_SIZE(s2t, 22);
            REGISTER_CREATE_BY_SIZE(s2t, 23);
            REGISTER_CREATE_BY_SIZE(s2t, 24);
            REGISTER_CREATE_BY_SIZE(s2t, 25);
            REGISTER_CREATE_BY_SIZE(s2t, 26);
            REGISTER_CREATE_BY_SIZE(s2t, 27);
            REGISTER_CREATE_BY_SIZE(s2t, 28);
            REGISTER_CREATE_BY_SIZE(s2t, 29);
            REGISTER_CREATE_BY_SIZE(s2t, 30);
            REGISTER_CREATE_BY_SIZE(s2t, 31);
            REGISTER_CREATE_BY_SIZE(s2t, 32);
            REGISTER_CREATE_BY_SIZE(s2t, 33);
            REGISTER_CREATE_BY_SIZE(s2t, 34);
            REGISTER_CREATE_BY_SIZE(s2t, 35);
            REGISTER_CREATE_BY_SIZE(s2t, 36);
            REGISTER_CREATE_BY_SIZE(s2t, 37);
            REGISTER_CREATE_BY_SIZE(s2t, 38);
            REGISTER_CREATE_BY_SIZE(s2t, 39);
            REGISTER_CREATE_BY_SIZE(s2t, 40);
            REGISTER_CREATE_BY_SIZE(s2t, 41);
            REGISTER_CREATE_BY_SIZE(s2t, 42);
            REGISTER_CREATE_BY_SIZE(s2t, 43);
            REGISTER_CREATE_BY_SIZE(s2t, 44);
            REGISTER_CREATE_BY_SIZE(s2t, 45);
            REGISTER_CREATE_BY_SIZE(s2t, 46);
            REGISTER_CREATE_BY_SIZE(s2t, 47);
            REGISTER_CREATE_BY_SIZE(s2t, 48);
            REGISTER_CREATE_BY_SIZE(s2t, 49);
            REGISTER_CREATE_BY_SIZE(s2t, 50);
        }
        
        IDisjointSet * IDisjointSet::create(IBoard *pBoard)
        {
            map<size_t, PF_CREATE>::iterator iter = s2t.find(pBoard->boardsize());
            if (s2t.end() != iter)
            {
                PF_CREATE func = iter->second;
                return func(pBoard);
            }
            printf("error, cannot find disjoint set\n");
            return nullptr;
        }
        
    }
}
