//
//  plugins.hpp
//  weiqi
//
//  Created by Viet Tho on 3/28/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_plugins_hpp
#define weiqi_plugins_hpp

#include <stdio.h>
#include <cstdint>

namespace weiqi
{
    /* The pluginset structure of current UCT context. */
    struct uct_pluginset *pluginset_init(struct board *b);
    void pluginset_done(struct uct_pluginset *ps);
    
    /* Load a new plugin with DLL at path, passed arguments in args. */
    void plugin_load(struct uct_pluginset *ps, char *path, char *args);
    
    /* Query plugins for priors of a node's leaves. */
    void plugin_prior(struct uct_pluginset *ps, struct tree_node *node, struct prior_map *map, int32_t eqex);
}

#endif /* plugins_hpp */
