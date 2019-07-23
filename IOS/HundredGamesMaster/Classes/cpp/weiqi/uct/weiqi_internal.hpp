//
//  internal.hpp
//  weiqi
//
//  Created by Viet Tho on 3/27/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_internal_hpp
#define weiqi_internal_hpp

#include <stdio.h>

#include "weiqi_tree.hpp"
#include "weiqi_dynkomi.hpp"
#include "weiqi_prior.hpp"

#include "../../Platform.h"
#include "../weiqi_pattern.hpp"
#include "../weiqi_ownermap.hpp"
#include "../weiqi_mq.hpp"
#include "../weiqi_debug.hpp"
#include "../weiqi_playout.hpp"

namespace weiqi
{
    /* How many games to consider at minimum before judging groups. */
#define GJ_MINGAMES	500
    
    /* Internal engine state. */
    enum uct_reporting {
        UR_TEXT,
        UR_JSON,
        UR_JSON_BIG,
    };
    
    enum LTE {
        LTE_ROOT,
        LTE_EACH,
        LTE_TOTAL,
    };
    
    enum uct_thread_model {
        TM_TREE, /* Tree parallelization w/o virtual loss. */
        TM_TREEVL, /* Tree parallelization with virtual loss. */
    };
    
    struct uct {
        int32_t debug_level;
        uct_reporting reporting;
        int32_t reportfreq;

        int32_t games, gamelen;
        floating_t resign_threshold, sure_win_threshold;
        double best2_ratio, bestr_ratio;
        floating_t max_maintime_ratio;
        bool pass_all_alive; /* Current value */
        bool allow_losing_pass;
        bool territory_scoring;
        int32_t expand_p;
        bool playout_amaf;
        bool amaf_prior;
        int32_t playout_amaf_cutoff;
        double dumpthres;
        int32_t force_seed;
        bool no_tbook;
        bool fast_alloc;
        size_t max_tree_size;
        size_t max_pruned_size;
        size_t pruning_threshold;
        int32_t mercymin;
        int32_t significant_threshold;

        int32_t threads = 1;
        uct_thread_model thread_model;
        int32_t virtual_loss;
        bool pondering_opt; /* User wants pondering */
        bool pondering; /* Actually pondering now */
        bool slave; /* Act as slave in distributed engine. */
        int32_t max_slaves; /* Optional, -1 if not set */
        int32_t slave_index; /* 0..max_slaves-1, or -1 if not set */
        enum stone my_color;

        int32_t fuseki_end;
        int32_t yose_start;

        int32_t dynkomi_mask;
        int32_t dynkomi_interval;
        struct uct_dynkomi *dynkomi;
        floating_t initial_extra_komi;
        
        floating_t val_scale;
        int32_t val_points;
        bool val_extra;
        bool val_byavg;
        bool val_bytemp;
        floating_t val_bytemp_min;

        int32_t random_policy_chance;
        bool local_tree;
        int32_t tenuki_d;
        floating_t local_tree_aging;
#define LTREE_PLAYOUTS_MULTIPLIER 100
        floating_t local_tree_depth_decay;
        bool local_tree_allseq;
        bool local_tree_neival;
        LTE local_tree_eval;
        bool local_tree_rootchoose;
        
        struct {
            int32_t level;
            int32_t playouts;
        } debug_after;
        
        char *banner;
        
        struct uct_policy *policy;
        struct uct_policy *random_policy;
        struct playout_policy *playout;
        struct uct_prior *prior;
        struct uct_pluginset *plugins;
        struct joseki_dict *jdict;
        
        struct pattern_setup pat;
        /* Various modules (prior, policy, ...) set this if they want pattern
         * database to be loaded. */
        bool want_pat;
        
        /* Used within frame of single genmove. */
        struct board_ownermap ownermap;
        /* Used for coordination among slaves of the distributed engine. */
        int32_t stats_hbits;
        int32_t shared_nodes;
        int32_t shared_levels;
        double stats_delay; /* stored in seconds */
        int32_t played_own;
        int32_t played_all; /* games played by all slaves */
        
        /* Saved dead groups, for final_status_list dead */
        struct move_queue dead_groups;
        int32_t dead_groups_move;
        
        /* Game state - maintained by setup_state(), reset_state(). */
        struct tree *t;
        
        volatile sig_atomic_t uct_halt = 0;
        struct uct_thread_ctx *pctx = NULL;
        
        int64_t time_start = 0;
        int64_t time = 5;
    };
    
#define UDEBUGL(n) DEBUGL_(u->debug_level, n)
    
    bool uct_pass_is_safe(struct uct *u, struct board *b, enum stone color, bool pass_all_alive, char **msg);
    void uct_prepare_move(struct uct *u, struct board *b, enum stone color);
    void uct_genmove_setup(struct uct *u, struct board *b, enum stone color);
    void uct_pondering_stop(struct uct *u);
    void uct_get_best_moves(struct tree *t, coord_t *best_c, float *best_r, int32_t nbest, bool winrates);
    
    /* This is the state used for descending the tree; we use this wrapper
     * structure in order to be able to easily descend in multiple trees
     * in parallel (e.g. main tree and local tree) or compute cummulative
     * "path value" throughout the tree descent. */
    struct uct_descent {
        /* Active tree nodes: */
        struct tree_node *node; /* Main tree. */
        struct tree_node *lnode; /* Local tree. */
        /* Value of main tree node (with all value factors, but unbiased
         * - without exploration factor), from black's perspective. */
        struct move_stats value;
    };
    
    
    typedef struct tree_node *(*uctp_choose)(struct uct_policy *p, struct tree_node *node, struct board *b, enum stone color, coord_t exclude);
    typedef floating_t (*uctp_evaluate)(struct uct_policy *p, struct tree *tree, struct uct_descent *descent, int32_t parity);
    typedef void (*uctp_descend)(struct uct_policy *p, struct tree *tree, struct uct_descent *descent, int32_t parity, bool allow_pass);
    typedef void (*uctp_winner)(struct uct_policy *p, struct tree *tree, struct uct_descent *descent);
    typedef void (*uctp_prior)(struct uct_policy *p, struct tree *tree, struct tree_node *node, struct board *b, enum stone color, int32_t parity);
    typedef void (*uctp_update)(struct uct_policy *p, struct tree *tree, struct tree_node *node, enum stone node_color, enum stone player_color, struct playout_amafmap *amaf, struct board *final_board, floating_t result);
    typedef void (*uctp_done)(struct uct_policy *p);
    
    struct uct_policy {
        struct uct *uct = NULL;
        uctp_choose choose;
        uctp_winner winner;
        uctp_evaluate evaluate;
        uctp_descend descend;
        uctp_update update;
        uctp_prior prior;
        uctp_done done;
        bool wants_amaf;
        void *data;
    };
}

#endif /* internal_hpp */
