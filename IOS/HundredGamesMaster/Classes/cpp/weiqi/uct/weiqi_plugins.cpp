//
//  plugins.cpp
//  weiqi
//
//  Created by Viet Tho on 3/28/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <assert.h>
#ifndef _MSC_VER
#include <dlfcn.h>
#endif
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "weiqi_plugins.hpp"
#include "weiqi_prior.hpp"
#include "weiqi_tree.hpp"

#include "../../Platform.h"
#include "../weiqi_board.hpp"
#include "../weiqi_debug.hpp"
#include "../weiqi_move.hpp"
#include "../weiqi_random.hpp"

/* Plugin interface for UCT. External plugins may hook callbacks on various
 * events and e.g. bias the tree. */


/* Keep the API typedefs in sync with <uct/plugin.h>. */

namespace weiqi
{
    struct plugin {
        char *path;
        char *args;
        void *dlh;
        void *data;
        
        void *(*init)(char *args, struct board *b, int32_t seed);
        void (*prior)(void *data, struct tree_node *node, struct prior_map *map, int32_t eqex);
        void (*done)(void *data);
    };
    
    struct uct_pluginset {
        struct plugin *plugins;
        int32_t n_plugins;
        struct board *b;
    };
    
    struct uct_pluginset* pluginset_init(struct board *b)
    {
        struct uct_pluginset* ps = (struct uct_pluginset*)calloc(1, sizeof(*ps));
        ps->b = b;
        return ps;
    }
    
    void pluginset_done(struct uct_pluginset *ps)
    {
        for (int32_t i = 0; i < ps->n_plugins; i++) {
            struct plugin *p = &ps->plugins[i];
            p->done(p->data);
            // dlclose(p->dlh);
            free(p->path);
            free(p->args);
        }
        free(ps);
    }
    
    
    void plugin_load(struct uct_pluginset *ps, char *path, char *args)
    {
        ps->plugins = (struct plugin*)realloc(ps->plugins, ++ps->n_plugins * sizeof(ps->plugins[0]));
        struct plugin *p = &ps->plugins[ps->n_plugins - 1];
#ifdef _MSC_VER
        p->path = _strdup(path);
        p->args = args ? _strdup(args) : args;
#else
        p->path = strdup(path);
        p->args = args ? strdup(args) : args;
#endif
        /*p->dlh = dlopen(path, RTLD_NOW);
        if (!p->dlh) {
            printf("Cannot load plugin %s: %s\n", path, dlerror());
            exit(EXIT_FAILURE);
        }*/
#define loadsym(s_) do {\
p->s_ = dlsym(p->dlh, "pachi_plugin_" #s_); \
if (!p->s_) { \
fprintf(stderr, "Cannot find pachi_plugin_%s in plugin %s: %s\n", #s_, path, dlerror()); \
exit(EXIT_FAILURE); \
} \
} while (0)
        printf("error, not loadsym\n");
        // TODO can hoan thien
        /*loadsym(init);
         loadsym(prior);
         loadsym(done);*/
        {
            /*loadsym(init);
             loadsym(prior);
             loadsym(done);*/
        }
        
        p->data = p->init(p->args, ps->b, fast_random(65536));
    }
    
    void plugin_prior(struct uct_pluginset *ps, struct tree_node *node, struct prior_map *map, int32_t eqex)
    {
        for (int32_t i = 0; i < ps->n_plugins; i++) {
            struct plugin *p = &ps->plugins[i];
            p->prior(p->data, node, map, eqex);
        }
    }
}
