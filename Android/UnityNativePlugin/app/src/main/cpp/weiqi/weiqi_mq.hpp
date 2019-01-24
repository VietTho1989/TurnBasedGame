//
//  mq.hpp
//  weiqi
//
//  Created by Viet Tho on 3/27/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_mq_hpp
#define weiqi_mq_hpp

/* Move queues; in fact, they are more like move lists, usually used
 * to accumulate equally good move candidates, then choosing from them
 * randomly. But they are also used to juggle group lists (using the
 * fact that coord_t == group_t). */

#include <stdio.h>
#include <assert.h>
#include "weiqi_move.hpp"
#include "weiqi_random.hpp"
#include "weiqi_fixp.hpp"

namespace weiqi
{
#define MQL 512 /* XXX: On larger board this might not be enough. */
    struct move_queue {
        uint32_t moves;
        coord_t move[MQL];
        /* Each move can have an optional tag or set of tags.
         * The usage of these is user-dependent. */
        unsigned char tag[MQL];
    };
    
    /* Pick a random move from the queue. */
    // bo static
    inline coord_t mq_pick(struct move_queue *q)
    {
        return q->moves ? q->move[fast_random(q->moves)] : pass;
    }
    
    /* Add a move to the queue. */
    // bo static
    inline void mq_add(struct move_queue *q, coord_t c, unsigned char tag)
    {
        {
            // assert(q->moves < MQL);
            if(!(q->moves < MQL)){
                printf("error, assert(q->moves < MQL)\n");
            }
        }
        q->tag[q->moves] = tag;
        q->move[q->moves++] = c;
    }
    
    /* Is move in the queue ? */
    // bo static
    inline bool mq_has(struct move_queue *q, coord_t c)
    {
        for (uint32_t i = 0; i < q->moves; i++)
            if (q->move[i] == c)
                return true;
        return false;
    }
    
    /* Cat two queues together. */
    // bo static
    inline void mq_append(struct move_queue *qd, struct move_queue *qs)
    {
        {
            // assert(qd->moves + qs->moves < MQL);
            if(!(qd->moves + qs->moves < MQL)){
                printf("error, assert(qd->moves + qs->moves < MQL)\n");
            }
        }
        memcpy(&qd->tag[qd->moves], qs->tag, qs->moves * sizeof(*qs->tag));
        memcpy(&qd->move[qd->moves], qs->move, qs->moves * sizeof(*qs->move));
        qd->moves += qs->moves;
    }
    
    /* Check if the last move in queue is not a dupe, and remove it
     * in that case. */
    // bo static
    inline void mq_nodup(struct move_queue *q)
    {
        for (uint32_t i = 1; i < 4; i++) {
            if (q->moves <= i)
                return;
            if (q->move[q->moves - 1 - i] == q->move[q->moves - 1]) {
                q->tag[q->moves - 1 - i] |= q->tag[q->moves - 1];
                q->moves--;
                return;
            }
        }
    }
    
    /* Print queue contents on stderr. */
    // bo static
    inline void mq_print(struct move_queue *q, struct board *b, char *label)
    {
        printf("%s candidate moves: ", label);
        for (uint32_t i = 0; i < q->moves; i++) {
            char strCoord[256];
            {
                coord2sstr(strCoord, q->move[i], b);
            }
            printf("%s ", strCoord);
        }
        printf("\n");
    }
    
    /* Variations of the above that allow move weighting. */
    /* XXX: The "kinds of move queue" issue (it's even worse in some other
     * branches) is one of the few good arguments for C++ in Pachi...
     * At least rewrite it to be less hacky and maybe make a move_gamma_queue
     * that encapsulates move_queue. */
    
    // bo static
    inline coord_t mq_gamma_pick(struct move_queue *q, fixp_t *gammas)
    {
        if (!q->moves)
            return pass;
        fixp_t total = 0;
        for (uint32_t i = 0; i < q->moves; i++) {
            total += gammas[i];
        }
        if (!total)
            return pass;
        fixp_t stab = fast_irandom(total);
        for (uint32_t i = 0; i < q->moves; i++) {
            if (stab < gammas[i])
                return q->move[i];
            stab -= gammas[i];
        }
        {
            //  assert(0);
            printf("error, assert(0)\n");
        }
        return pass;
    }
    // bo static
    inline void mq_gamma_add(struct move_queue *q, fixp_t *gammas, coord_t c, double gamma, unsigned char tag)
    {
        mq_add(q, c, tag);
        gammas[q->moves - 1] = double_to_fixp(gamma);
    }
    // bo static
    inline void mq_gamma_print(struct move_queue *q, fixp_t *gammas, struct board *b, char *label)
    {
        printf("%s candidate moves: ", label);
        for (uint32_t i = 0; i < q->moves; i++) {
            char strCoord[256];
            {
                coord2sstr(strCoord, q->move[i], b);
            }
            printf("%s(%.3f) ", strCoord, fixp_to_double(gammas[i]));
        }
        printf("\n");
    }
}

#endif /* mq_hpp */
