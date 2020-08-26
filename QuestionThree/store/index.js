export const state = () => ({
  loading: false,
  characters: [],
  books: [],
  houses: [],
  links: {
    first: {
      active: false,
      url: ''
    },
    prev: {
      active: false,
      url: ''
    },
    next: {
      active: false,
      url: ''
    },
    last: {
      active: false,
      url: ''
    }
  },
  cached_characters: []
});

export const mutations = {
  toggle(state, value) {
    state.loading = value;
  },
  updateCharacters(state, new_characters) {
    state.characters = new_characters;
  },
  updateLinks(state, new_links) {
    // reset links
    state.links =  {
      first: {
        active: false,
          url: ''
      },
      prev: {
        active: false,
          url: ''
      },
      next: {
        active: false,
          url: ''
      },
      last: {
        active: false,
          url: ''
      }
    };

    let link = new_links;
    link = link.split(',');
    link.map((currentValue, index, arr) => {
      let temp = currentValue.split(';');
      let url = temp[0];
      url = url.replace(' ','').trim().slice(1, url.length-1).replace('>','');
      let label = temp[1];
      label = label.replace(' ', '').trim().slice(5,label.length-2);

      state.links[label].active = true;
      state.links[label].url = url;
    });
  },
  updateBooks(state, new_books) {
    state.books = new_books;
  },
  updateHouses(state, new_houses) {
    state.houses = new_houses;
  },
  saveCharacter(state, {index, character}) {
    console.log(`saving index ${index}`,character);
    state.cached_characters[index] = character;
  }
};

export const actions = {
  toggle(context, state) {
    context.commit('toggle', state);
  },
  async fetchCharacters(context, link = null) {
    let url = `https://anapioficeandfire.com/api/characters?page=1&pageSize=10`;
    if(link !== null){
      url = link;
    }
    await context.dispatch('toggle',true);
    try {
      const res = await this.$axios.get(url);
      await context.dispatch('toggle',false);
      context.commit('updateCharacters', res.data);
      context.commit('updateLinks', res.headers.link);
    } catch (e) {
      await context.dispatch('toggle',false);
      console.log('error',e);
      throw e;
    }
  },
  async fetchBooks(context) {
    let url = `https://anapioficeandfire.com/api/books`;
    await context.dispatch('toggle',true);
    try {
      const res = await this.$axios.$get(url);
      await context.dispatch('toggle',false);
      context.commit('updateBooks', res);
    } catch (e) {
      await context.dispatch('toggle',false);
      console.log('error',e);
      throw e;
    }
  },
  async fetchHouses(context) {
    let url = `https://anapioficeandfire.com/api/houses`;
    await context.dispatch('toggle',true);
    try {
      const res = await this.$axios.$get(url);
      await context.dispatch('toggle',false);
      context.commit('updateHouses', res);
    } catch (e) {
      await context.dispatch('toggle',false);
      console.log('error',e);
      throw e;
    }
  },
};

export const getters = {
  is_loading (state) {
    return state.loading
  },
  characters (state) {
    return state.characters;
  },
  links (state) {
    return state.links;
  },
  books (state) {
    return state.books;
  },
  houses (state) {
    return state.houses;
  },
  cached_characters(state) {
    return state.cached_characters;
  }
};
