//
//  generic.hpp
//  weiqi
//
//  Created by Viet Tho on 3/28/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_generic_hpp
#define weiqi_generic_hpp

#include <stdio.h>
#include <cfloat>

#include "../../../Platform.h"
#include "../../weiqi_board.hpp"
#include "../../weiqi_stone.hpp"
#include "../weiqi_tree.hpp"
#include "../weiqi_uct.hpp"

namespace weiqi
{
    struct tree_node *uctp_generic_choose(struct uct_policy *p, struct tree_node *node, struct board *b, enum stone color, coord_t exclude);
    void uctp_generic_winner(struct uct_policy *p, struct tree *tree, struct uct_descent *descent);
    
    
    /* Some generic stitching for tree descent. */
    
#if 0
#define uctd_debug(fmt...) fprintf(stderr, fmt);
#else
#define uctd_debug(fmt)
#endif
    
    
#ifdef _MSC_VER
    
#define uctd_try_node_children(tree, descent, allow_pass, parity, tenuki_d, di, urgency) \
/* Information abound best children. */ \
/* XXX: We assume board <=25x25. */ \
struct uct_descent dbest[BOARD_MAX_MOVES + 1] = { { dbest[0].node = descent->node->children, dbest[0].lnode = NULL } }; int32_t dbests = 1; \
floating_t best_urgency = -9999; \
/* Descent children iterator. */ \
struct uct_descent dci = { dci.node = descent->node->children, dci.lnode = descent->lnode ? descent->lnode->children : NULL }; \
\
for (; dci.node; dci.node = dci.node->sibling) { \
floating_t urgency; \
/* Do not consider passing early. */ \
if (unlikely((!allow_pass && is_pass(node_coord(dci.node))) || (dci.node->hints & TREE_HINT_INVALID))) \
continue; \
/* Position dci.lnode to point at or right after the local
* node corresponding to dci.node. */ \
while (dci.lnode && node_coord(dci.lnode) < node_coord(dci.node)) \
dci.lnode = dci.lnode->sibling; \
/* Set up descent-further iterator. This is the public-accessible
* one, and usually is similar to dci. However, in case of local
* trees, we may keep next-candidate pointer in dci while storing
* actual-specimen in di. */ \
struct uct_descent di = dci; \
if (dci.lnode) { \
/* Set lnode to local tree node corresponding
* to node (dci.lnode, pass-lnode or NULL). */ \
di.lnode = tree_lnode_for_node(tree, dci.node, dci.lnode, tenuki_d); \
}
    
#else

#define uctd_try_node_children(tree, descent, allow_pass, parity, tenuki_d, di, urgency) \
/* Information abound best children. */ \
/* XXX: We assume board <=25x25. */ \
struct uct_descent dbest[BOARD_MAX_MOVES + 1] = { { .node = descent->node->children, .lnode = NULL } }; int32_t dbests = 1; \
floating_t best_urgency = -9999; \
/* Descent children iterator. */ \
struct uct_descent dci = { .node = descent->node->children, .lnode = descent->lnode ? descent->lnode->children : NULL }; \
\
for (; dci.node; dci.node = dci.node->sibling) { \
floating_t urgency; \
/* Do not consider passing early. */ \
if (unlikely((!allow_pass && is_pass(node_coord(dci.node))) || (dci.node->hints & TREE_HINT_INVALID))) \
continue; \
/* Position dci.lnode to point at or right after the local
* node corresponding to dci.node. */ \
while (dci.lnode && node_coord(dci.lnode) < node_coord(dci.node)) \
dci.lnode = dci.lnode->sibling; \
/* Set up descent-further iterator. This is the public-accessible
* one, and usually is similar to dci. However, in case of local
* trees, we may keep next-candidate pointer in dci while storing
* actual-specimen in di. */ \
struct uct_descent di = dci; \
if (dci.lnode) { \
/* Set lnode to local tree node corresponding
* to node (dci.lnode, pass-lnode or NULL). */ \
di.lnode = tree_lnode_for_node(tree, dci.node, dci.lnode, tenuki_d); \
}
    
#endif
    
    
    
    /* ...your urgency computation code goes here... */
    
#define uctd_set_best_child(di, urgency) \
/*uctd_debug("(%s) %f\n", coord2sstr(node_coord(di.node), tree->board), urgency);*/ \
if (urgency - best_urgency > __FLT_EPSILON__) { /* urgency > best_urgency */ \
/*uctd_debug("new best\n");*/ \
best_urgency = urgency; dbests = 0; \
} \
if (urgency - best_urgency > -__FLT_EPSILON__) { /* urgency >= best_urgency */ \
/*uctd_debug("another best\n");*/ \
/* We want to always choose something else than a pass \
* in case of a tie. pass causes degenerative behaviour. */ \
if (dbests == 1 && is_pass(node_coord(dbest[0].node))) { \
dbests--; \
} \
struct uct_descent db = di; \
/* Make sure lnode information is meaningful. */ \
if (db.lnode && is_pass(node_coord(db.lnode))) \
db.lnode = NULL; \
dbest[dbests++] = db; \
} \
}
    
#define uctd_get_best_child(descent) *(descent) = dbest[fast_random(dbests)];
}

#endif /* generic_hpp */
