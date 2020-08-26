import Vue from 'vue'
import { Promised } from 'vue-promised'

Vue.component('Promised', Promised);

Vue.mixin({
  methods: {
    show_many(details) {
      if(details.length > 1){
        return details.join(", ");
      }
      if(details.length === 1 && details[0] !== ""){
        return details[0];
      }
      return "N/A";
    },
    show_one(details) {
      if(details){
        return details;
      }
      return "N/A";
    },
    async getCharacter(url, name_only = true) {
      if(url === ''){
        return 'N/A';
      }
      // Get ID
      let id = url.replace('https://anapioficeandfire.com/api/characters/','');
      // Check is local
      if(typeof this.$store.getters.cached_characters[id] !== 'undefined'){
        if(name_only){
          return  this.$store.getters.cached_characters[id].name !== '' ? this.$store.getters.cached_characters[id].name : 'N/A';
        }
        return this.$store.getters.cached_characters[id];
      }
      // fetch from API and save to store
      try{
        const res = await this.$axios.get(`https://anapioficeandfire.com/api/characters/${id}`);
        await this.$store.commit('saveCharacter',{index: id, character: res.data});
        if(name_only){
          return res.data.name !== '' ? res.data.name : 'N/A';
        }
        return  res.data;
      }
      catch (e) {
        return "N/A";
      }
    }
  }
});
