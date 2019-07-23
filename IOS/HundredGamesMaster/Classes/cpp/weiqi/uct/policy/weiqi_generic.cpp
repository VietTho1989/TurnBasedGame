//
//  generic.cpp
//  weiqi
//
//  Created by Viet Tho on 3/28/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <assert.h>
#include <math.h>
#include <stdio.h>
#include <stdlib.h>

#include "weiqi_generic.hpp"

namespace weiqi
{
    struct tree_node* uctp_generic_choose(struct uct_policy *p, struct tree_node *node, struct board *b, enum stone color, coord_t exclude)
    {
        struct tree_node* nbest = node->children;
        if (!nbest) {
            printf("don't have nbest\n");
            return NULL;
        }
        struct tree_node *nbest2 = nbest->sibling;
        
        /* This function is called while the tree is updated by other threads.
         * We rely on node->children being set only after the node has been fully expanded. */
        for (struct tree_node *ni = nbest2; ni; ni = ni->sibling) {
            // we compare playouts and choose the best-explored
            // child; comparing values is more brittle
            if (node_coord(ni) == exclude || ni->hints & TREE_HINT_INVALID)
                continue;
            if (ni->u.playouts > nbest->u.playouts) {
                nbest2 = nbest;
                nbest = ni;
            } else if (ni->u.playouts > nbest2->u.playouts) {
                nbest2 = ni;
            }
        }
        
        /* Play pass only if we can afford scoring. But don't be silly and start filling
         * eyes in case uct_pass_is_safe() gets stuck and never allows passing.
         * (endgame situation that can't be clarified ...)
         * Call expensive uct_pass_is_safe() only if pass is indeed the best move. */
        char *msg;
        if (is_pass(node_coord(nbest)) &&
            !uct_pass_is_safe(p->uct, b, color, p->uct->pass_all_alive, &msg) &&
            nbest2 && !board_is_one_point_eye(b, node_coord(nbest2), color))
            return nbest2;
        return nbest;
    }
    
    /* Return the node with best value instead of best explored. We must use the heuristic
     * value (using prior and possibly rave), because the raw value is meaningless for
     * nodes evaluated rarely.
     * This function is called while the tree is updated by other threads */
    void uctp_generic_winner(struct uct_policy *p, struct tree *tree, struct uct_descent *descent)
    {
        if (!p->evaluate)
            return;
        bool allow_pass = false; /* At worst forces some extra playouts at the end */
        int32_t parity = tree_node_parity(tree, descent->node);
        
        uctd_try_node_children(tree, descent, allow_pass, parity, p->uct->tenuki_d, di, urgency) {
            urgency = p->evaluate(p, tree, &di, parity);
        } uctd_set_best_child(di, urgency);
        
        uctd_get_best_child(descent);
    }
}
